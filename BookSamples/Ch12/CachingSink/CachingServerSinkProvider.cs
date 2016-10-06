using System;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.Collections;

namespace DotNetPerformance.Remoting.CachingSink {
	public class CachingServerSinkProvider: IServerChannelSinkProvider {
		private IServerChannelSinkProvider _nextProvider;

		public CachingServerSinkProvider(IDictionary properties, ICollection providerData) { 
		}

		public IServerChannelSinkProvider Next {
			get {return _nextProvider; }
			set {_nextProvider = value;}
		}

		public IServerChannelSink CreateSink(IChannelReceiver channel) {
			IServerChannelSink next = _nextProvider.CreateSink(channel);				
				
			return new CachingServerSink(next);
		}

		public void GetChannelData(IChannelDataStore channelData) {
		}
	}
}
