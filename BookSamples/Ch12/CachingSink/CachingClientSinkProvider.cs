using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.Collections;

namespace DotNetPerformance.Remoting.CachingSink {
	public class CachingClientSinkProvider: IClientChannelSinkProvider {
		private IClientChannelSinkProvider _next;

		public CachingClientSinkProvider(IDictionary properties, ICollection providerData) {
		}

		public IClientChannelSinkProvider Next {
			get {return _next; }
			set {_next = value;}
		}

		public IClientChannelSink CreateSink(IChannelSender channel, string url, object remoteChannelData) {
			IClientChannelSink next = _next.CreateSink(channel, url, remoteChannelData);	
			return new CachingClientSink(next);
		}
	}
}
