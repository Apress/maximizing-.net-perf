using System;
using System.Configuration;
using System.Windows.Forms;
using DotNetPerformance;
using RemotingPerfLibrary;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;

namespace PerfTest.Remoting {
	public class ChannelSelection {
		string _remotingServer;
		string _remoteObjectTCP;
		string _remoteObjectHTTP;

		public ChannelSelection(){
			_remotingServer = ConfigurationSettings.AppSettings["RemotingServer"];
			_remoteObjectTCP = "tcp://" + _remotingServer + ":" +
				ConfigurationSettings.AppSettings["RemotingServerTCPPort"] + "/DataManager.rem";
			_remoteObjectHTTP = "http://" + _remotingServer + ":"+
				ConfigurationSettings.AppSettings["RemotingServerHTTPPort"] + "/DataManager.rem";
		}

		private TestResultGrp RunTests(){
			const int numberIterations = 500;
			const int numberTestRuns = 3;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(_10BytesTCP);
			testCases += new TestRunner.TestCase(_100BytesTCP);
			testCases += new TestRunner.TestCase(_1000BytesTCP);
			testCases += new TestRunner.TestCase(_10BytesHTTP);
			testCases += new TestRunner.TestCase(_100BytesHTTP);
			testCases += new TestRunner.TestCase(_1000BytesHTTP);
			
			return tr.RunTests(testCases);
		}

		//TEST 12.02
		[Benchmark("Compares various channel and formatter options.", "RunTestDefault")]
		public TestResultGrp RunTestDefault() {
			foreach(IChannel channel in ChannelServices.RegisteredChannels){
				ChannelServices.UnregisterChannel(channel);
			}
			HttpChannel httpChannel = new HttpChannel();
			TcpChannel tcpChannel = new TcpChannel();
			ChannelServices.RegisterChannel(httpChannel);
			ChannelServices.RegisterChannel(tcpChannel);

			TestResultGrp trg = RunTests();
			return trg;
		}

		//TEST 12.03
		[Benchmark("Compares various channel and formatter options.", "RunTestBinary")]
		public TestResultGrp RunTestBinary() {
			foreach(IChannel channel in ChannelServices.RegisteredChannels){
				ChannelServices.UnregisterChannel(channel);
			}
			BinaryServerFormatterSinkProvider svr = new BinaryServerFormatterSinkProvider();
			BinaryClientFormatterSinkProvider clnt = new BinaryClientFormatterSinkProvider();
			HttpChannel httpChannel = new HttpChannel(null, clnt, svr);
			TcpChannel tcpChannel = new TcpChannel();
			ChannelServices.RegisterChannel(httpChannel);
			ChannelServices.RegisterChannel(tcpChannel);

			TestResultGrp trg = RunTests();
			return trg;
		}

		//TEST 12.04
		[Benchmark("Compares various channel and formatter options.", "RunTestSoap")]
		public TestResultGrp RunTestSoap() {
			foreach(IChannel channel in ChannelServices.RegisteredChannels){
				ChannelServices.UnregisterChannel(channel);
			}
			SoapServerFormatterSinkProvider svr = new SoapServerFormatterSinkProvider();
			SoapClientFormatterSinkProvider clnt = new SoapClientFormatterSinkProvider();
			HttpChannel httpChannel = new HttpChannel();
			TcpChannel tcpChannel = new TcpChannel(null, clnt, svr);
			ChannelServices.RegisterChannel(httpChannel);
			ChannelServices.RegisterChannel(tcpChannel);

			TestResultGrp trg = RunTests();
			return trg;
		}

		public void _10BytesTCP(Int32 numberIterations){
			DataManager dm = (DataManager)Activator.GetObject(typeof(DataManager),
				_remoteObjectTCP); 
			for (int i = 0;i < numberIterations;++i) {
				string s = dm.Get10CharacterString();
			}
		}

		public void _100BytesTCP(Int32 numberIterations){
			DataManager dm = (DataManager)Activator.GetObject(typeof(DataManager),
				_remoteObjectTCP); 
			for (int i = 0;i < numberIterations;++i) {
				string s = dm.Get100CharacterString();
			}
		}

		public void _1000BytesTCP(Int32 numberIterations){
			DataManager dm = (DataManager)Activator.GetObject(typeof(DataManager),
				_remoteObjectTCP); 
			for (int i = 0;i < numberIterations;++i) {
				string s = dm.Get1000CharacterString();
			}
		}

		public void _10BytesHTTP(Int32 numberIterations){
			DataManager dm = (DataManager)Activator.GetObject(typeof(DataManager),
				_remoteObjectHTTP); 
			for (int i = 0;i < numberIterations;++i) {
				string s = dm.Get10CharacterString();
			}
		}

		public void _100BytesHTTP(Int32 numberIterations){
			DataManager dm = (DataManager)Activator.GetObject(typeof(DataManager),
				_remoteObjectHTTP); 
			for (int i = 0;i < numberIterations;++i) {
				string s = dm.Get100CharacterString();
			}
		}

		public void _1000BytesHTTP(Int32 numberIterations){
			DataManager dm = (DataManager)Activator.GetObject(typeof(DataManager),
				_remoteObjectHTTP); 
			for (int i = 0;i < numberIterations;++i) {
				string s = dm.Get1000CharacterString();
			}
		}
	}
}
