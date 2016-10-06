using System;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting;
using System.Collections;

namespace DotNetPerformance.Remoting.CachingSink {
	public class CachingClientSink: BaseChannelSinkWithProperties, 
		IClientChannelSink {
		private IClientChannelSink _nextSink;
		private IMessage _asyncMessage = null;
		private ITransportHeaders _asyncHeaders = null;
		private static RemoteCallCache cache = new RemoteCallCache();

		public CachingClientSink(IClientChannelSink next) {
			Console.WriteLine("sink created");
			_nextSink = next;
		}

		public IClientChannelSink NextChannelSink {
			get {
				return _nextSink;
			}
		}

		public void AsyncProcessRequest(IClientChannelSinkStack sinkStack, 
			IMessage msg,  ITransportHeaders headers, Stream stream) {
			RemotingResult result = cache.GetPreviousResults(msg, headers, true);
			if (result == null){
				_asyncMessage = msg;
				_asyncHeaders = headers;
				sinkStack.Push(this,null);
				_nextSink.AsyncProcessRequest(sinkStack,msg,headers,stream);
			}
			else{
				_asyncMessage = null;
				AsyncProcessResponse(sinkStack, null, result.Headers, new MemoryStream(result.Response));
			}
		}


		public void AsyncProcessResponse(IClientResponseChannelSinkStack sinkStack, 
			object state,  ITransportHeaders headers, Stream stream) {
			if (_asyncMessage != null){
				try{
					object objCacheLimit = headers["X-Cache"];
					if (objCacheLimit != null && Convert.ToInt32(objCacheLimit) > 0){
						byte[] response = ExtractContents(stream);
						cache.CacheResults(_asyncMessage, _asyncHeaders, 
							new RemotingResult(response, headers, DateTime.UtcNow + TimeSpan.FromSeconds(Convert.ToInt32(objCacheLimit))), true);
						sinkStack.AsyncProcessResponse(headers,new MemoryStream(response));
					}
				}
				catch(Exception){
					sinkStack.AsyncProcessResponse(headers,stream);
				}
			}
			else
				sinkStack.AsyncProcessResponse(headers,stream);
		}


		public Stream GetRequestStream(IMessage msg, 
			ITransportHeaders headers) {
			return _nextSink.GetRequestStream(msg, headers);
		}


		public void ProcessMessage(IMessage msg, ITransportHeaders requestHeaders, 
			Stream requestStream, out ITransportHeaders responseHeaders, out Stream responseStream) {
			RemotingResult result = cache.GetPreviousResults(msg, requestHeaders, false);
			if (result == null){
				_nextSink.ProcessMessage(msg, requestHeaders, requestStream, out responseHeaders, out responseStream);
				object objCacheLimit = responseHeaders["X-Cache"];
				if (objCacheLimit != null && Convert.ToInt32(objCacheLimit) > 0){
					byte[] response = ExtractContents(responseStream);
					//responseStream can only be read once - give back new stream
					responseStream = new MemoryStream(response, 0, response.Length);
					//save for next time
					cache.CacheResults(msg, requestHeaders, 
						new RemotingResult(response, responseHeaders, DateTime.UtcNow + TimeSpan.FromSeconds(Convert.ToInt32(objCacheLimit))), false);
				}
			}
			else{
				responseStream = new MemoryStream(result.Response);
				responseHeaders = result.Headers;
			}
		}

		private byte[] ExtractContents(Stream input){
			//read the response into a byte array
			int length = 256;
			int oldLength = 0;
			byte[] response = new Byte[length];
			int bytesRead = 0;
			int totalBytesRead = 0;
			while ((bytesRead = input.Read(response, oldLength, length-oldLength)) == length-oldLength){
				totalBytesRead += bytesRead;
				oldLength = length;
				length *= 2;
				byte[] newResponse = new Byte[length];
				Array.Copy(response, 0, newResponse, 0, oldLength);
				response = newResponse;
			}
			totalBytesRead += bytesRead;
			byte[] correctLengthResponse = new byte[totalBytesRead];
			Array.Copy(response, 0, correctLengthResponse, 0, totalBytesRead);
			return correctLengthResponse;
		}
	}
}
