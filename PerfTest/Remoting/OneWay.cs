using System;
using System.Windows.Forms;
using DotNetPerformance;
using RemotingPerfLibrary;

namespace PerfTest.Remoting {
	public class OneWay{
		public OneWay(){
			System.Runtime.Remoting.RemotingConfiguration.Configure("PerfTest.exe.config");
		}

		//TEST 12.06
		[Benchmark("Compares OneWay to standard remote calls.")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 500;
			const int numberTestRuns = 3;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(OneWayCall);
			testCases += new TestRunner.TestCase(StandardCall);
			
			return tr.RunTests(testCases);
		}

		public void OneWayCall(Int32 numberIterations){
			DataManager dm = new DataManager();
			for (int i = 0;i < numberIterations;++i) {
				dm.SlowMethodOneWay();
			}
		}

		public void StandardCall(Int32 numberIterations){
			DataManager dm = new DataManager();
			for (int i = 0;i < numberIterations;++i) {
				dm.SlowMethod();
			}
		}
	}
}
