using System;
using System.Collections;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters.Binary;

namespace DotNetPerformance.Remoting.CachingSink {
	public class RemotingHash: System.Collections.IHashCodeProvider{
		internal static byte[] GetBinaryRepresentation(RemotingKey rk){
			BinaryFormatter bf = new BinaryFormatter();
			MemoryStream ms = new MemoryStream();
			try{
				bf.Serialize(ms, rk.Msg);
				bf.Serialize(ms, rk.Headers);
				bf.Serialize(ms, rk.IsAsync);
				return ms.GetBuffer();
			}
			catch(Exception){
			}
			return new byte[0];
		}

		public int GetHashCode(object obj){
			try{
				int ret = 0;
				foreach(byte b in GetBinaryRepresentation((RemotingKey)obj)){
					ret += b;
				}
				return ret << 16 | ret;
			}
			catch(Exception){
			}
			
			return 0;
		}
	}

	public class RemotingEquals: System.Collections.IComparer{
		public int Compare(object x, object y){
			try{
				byte[] bx = RemotingHash.GetBinaryRepresentation((RemotingKey)x);
				byte[] by = RemotingHash.GetBinaryRepresentation((RemotingKey)y);
				
				if (bx.Length != by.Length)
					return bx.Length - by.Length;

				for(int i = 0; i < by.Length; ++i){
					if (bx[i] != by[i])
						return bx[i] - by[i];
				}
			}
			catch(Exception){
			}

			return 0;
		}
	}

	[Serializable]
	public class RemotingKey{
		public RemotingKey(IMessage Msg, ITransportHeaders Headers, bool IsAsync){
			_msg = Msg;
			_headers = Headers;
			_isAsync = IsAsync;
		}

		public IMessage Msg{get{return _msg;}}
		public ITransportHeaders Headers{get{return _headers;}}
		public bool IsAsync{get{return _isAsync;}}

		private IMessage _msg;
		private ITransportHeaders _headers;
		private bool _isAsync;
	}

	[Serializable]
	public class RemotingResult{
		public RemotingResult(byte[] Response, ITransportHeaders ResponseHeaders, DateTime ValidTo){
			_response = Response;
			_headers = ResponseHeaders;
			_validTo = ValidTo;
		}

		public byte[] Response{get{return _response;}}
		public ITransportHeaders Headers{get{return _headers;}}
		public DateTime ValidTo{get{return _validTo;}}

		private byte[] _response;
		private ITransportHeaders _headers;
		private DateTime _validTo;
	}

	public class RemoteCallCache {
		private System.Collections.Hashtable _resultMap;
		public RemoteCallCache() {
			_resultMap = new Hashtable(new RemotingHash(), new RemotingEquals());
			_resultMap = Hashtable.Synchronized(_resultMap);
		}

		public RemotingResult GetPreviousResults(IMessage Msg, ITransportHeaders Headers, bool IsAsync){
			try{
				RemotingResult res = (RemotingResult)_resultMap[new RemotingKey(Msg, Headers, IsAsync)];
				if (res != null && res.ValidTo < DateTime.UtcNow){
					_resultMap[new RemotingKey(Msg, Headers, IsAsync)] = null;
					return null;
				}
				return res;
			}
			catch(Exception){
				return null;
			}
		}
	
		public void CacheResults(IMessage Msg, ITransportHeaders Headers, RemotingResult Result, bool IsAsync){
			_resultMap[new RemotingKey(Msg, Headers, IsAsync)] = Result;
		}
	}
}
