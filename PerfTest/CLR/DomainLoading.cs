using System;
using System.Text;
using DotNetPerformance;
using System.Runtime.InteropServices;

namespace PerfTest.CLR {
	public class DomainLoading {
		//TEST 14.01
		[Benchmark("Looks at domain neutral loads on static member access speed.")]
		public TestResultGrp RunTest() {	
			System.Windows.Forms.MessageBox.Show("Run once as is, then uncomment the LoaderOptimization on the app entry point, and run again.  Compare results");
			const int numberIterations  = 100000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(NotThreadSafe);
			testCases += new TestRunner.TestCase(ThreadSafe);

			return tr.RunTests(testCases);
		}

		static int stat;

		public void NotThreadSafe(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				++stat;
			}
		}

		public void ThreadSafe(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				lock(typeof(DomainLoading)){
					++stat;
				}
			}
		}
	}
}
