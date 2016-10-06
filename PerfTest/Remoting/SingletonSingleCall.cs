using System;
using System.Configuration;
using System.Windows.Forms;
using DotNetPerformance;
using RemotingPerfLibrary;

namespace PerfTest.Remoting {
	public class SingletonSingleCall{
		string _remotingServer;
		string _remoteObjectSingleton;
		string _remoteObjectSC;

		public SingletonSingleCall(){
			_remotingServer = ConfigurationSettings.AppSettings["RemotingServer"];
			_remoteObjectSingleton = "tcp://" + _remotingServer + ":"+
				ConfigurationSettings.AppSettings["RemotingServerTCPPort"] + "/DataManager.rem";
			_remoteObjectSC = "tcp://" + _remotingServer + ":"+
				ConfigurationSettings.AppSettings["RemotingServerTCPPort"] + "/DataManagerSC.rem";
		}

		//TEST 12.05
		[Benchmark("Compares singleton and single-call remote objects")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 5000;
			const int numberTestRuns = 3;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Singleton);
			testCases += new TestRunner.TestCase(Singlecall);
			
			return tr.RunTests(testCases);
		}

		public void Singleton(Int32 numberIterations){
			DataManager dm = (DataManager)Activator.GetObject(typeof(DataManager),
				_remoteObjectSingleton); 
			for (int i = 0;i < numberIterations;++i) {
				dm.Get100CharacterString();
			}
		}

		public void Singlecall(Int32 numberIterations){
			DataManager dm = (DataManager)Activator.GetObject(typeof(DataManager),
				_remoteObjectSC); 
			for (int i = 0;i < numberIterations;++i) {
				dm.Get100CharacterString();
			}
		}
	}
}
