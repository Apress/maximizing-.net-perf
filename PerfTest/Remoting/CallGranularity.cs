using System;
using System.Windows.Forms;
using DotNetPerformance;
using RemotingPerfLibrary;

namespace PerfTest.Remoting {
	public class CallGranularity {
		public CallGranularity(){
			System.Runtime.Remoting.RemotingConfiguration.Configure("PerfTest.exe.config");
		}

		//TEST 12.01
		[Benchmark("Looks at perf. relationship between amount of data passed and number of calls made.")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 500;
			const int numberTestRuns = 3;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(OneThousandCharsFiveTimes);
			testCases += new TestRunner.TestCase(OneThousandCharsOnce);
			testCases += new TestRunner.TestCase(FiveThousandChars);
			
			return tr.RunTests(testCases);
		}

		public void OneThousandCharsFiveTimes(Int32 numberIterations){
			DataManager dm = new DataManager();
			for (int i = 0;i < numberIterations * 5;++i) {
				string s = dm.Get1000CharacterString();
			}
		}

		public void OneThousandCharsOnce(Int32 numberIterations){
			DataManager dm = new DataManager();
			for (int i = 0;i < numberIterations;++i) {
				string s = dm.Get1000CharacterString();
			}
		}

		public void FiveThousandChars(Int32 numberIterations){
			DataManager dm = new DataManager();
			for (int i = 0;i < numberIterations;++i) {
				string s = dm.Get5000CharacterString();
			}
		}
	}
}
