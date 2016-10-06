using System;
using System.Configuration;
using System.Windows.Forms;
using DotNetPerformance;
using RemotingPerfLibrary;

namespace PerfTest.Remoting {
	public class IISHosted{
		string _remotingServer;
		string _remoteObjectHTTP;

		public IISHosted(){
			_remotingServer = ConfigurationSettings.AppSettings["RemotingServer"];
			_remoteObjectHTTP = "http://" + _remotingServer + ":"+
				ConfigurationSettings.AppSettings["RemotingServerHTTPPort"] + "/DataManager.rem";
		}

		//TEST 12.07
		[Benchmark("Compares IIS vs custom remoting hosts")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 1000;
			const int numberTestRuns = 3;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(IIS);
			testCases += new TestRunner.TestCase(Custom);
			
			return tr.RunTests(testCases);
		}

		public void IIS(Int32 numberIterations){
			DataManager dm = (DataManager)Activator.GetObject(typeof(DataManager),
				ConfigurationSettings.AppSettings["IISHost"]); 
			for (int i = 0;i < numberIterations;++i) {
				dm.Get100CharacterString();
			}
		}

		public void Custom(Int32 numberIterations){
			DataManager dm = (DataManager)Activator.GetObject(typeof(DataManager),
				_remoteObjectHTTP); 
			for (int i = 0;i < numberIterations;++i) {
				dm.Get100CharacterString();
			}
		}
	}
}
