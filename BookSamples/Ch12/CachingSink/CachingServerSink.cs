using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.IO;

namespace DotNetPerformance.Remoting.CachingSink {
	public class CachingServerSink: BaseChannelSinkWithProperties,
		IServerChannelSink {
		private IServerChannelSink _nextSink;

		public CachingServerSink(IServerChannelSink next) {
			_nextSink = next;
		}

		public IServerChannelSink NextChannelSink {
			get {
				return _nextSink;
			}
		}

		public void AsyncProcessResponse(IServerResponseChannelSinkStack sinkStack, 
			object state, IMessage msg, ITransportHeaders headers, Stream stream) {
			headers["X-Cache"] = "60";
			sinkStack.AsyncProcessResponse(msg,headers,stream);
		}

		public Stream GetResponseStream(IServerResponseChannelSinkStack sinkStack, 
			object state, IMessage msg, ITransportHeaders headers) {
			return null;
		}

		public ServerProcessing ProcessMessage(IServerChannelSinkStack sinkStack, IMessage requestMsg, 
			ITransportHeaders requestHeaders, Stream requestStream, out IMessage responseMsg, 
			out ITransportHeaders responseHeaders, out Stream responseStream) {

			sinkStack.Push(this,null);

			ServerProcessing res = _nextSink.ProcessMessage(sinkStack, requestMsg, requestHeaders,
				requestStream, out responseMsg, out responseHeaders, out responseStream);
			responseHeaders["X-Cache"] = "60";
			return res;
		}
	}
}
