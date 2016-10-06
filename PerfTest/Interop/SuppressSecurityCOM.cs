using System;
using System.Text;
using DotNetPerformance;
using System.Runtime.InteropServices;

namespace PerfTest.Interop {
	public class SuppressSecurityCOM {
		//TEST 13.07
		[Benchmark("Compares SuppressUnmanagedCodeSecurity COM call to call with stack walk")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 5000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Suppressed);
			testCases += new TestRunner.TestCase(Normal);

			return tr.RunTests(testCases);
		}
		
		public void Normal(Int32 numberIterations){
			interopsafe.CTestClass c = new interopsafe.CTestClass();
			for (int i = 0; i < numberIterations; ++i){
				c.DoNothing();
			}
		}

		public void Suppressed(Int32 numberIterations){
			interopunsafe.CTestClass c = new interopunsafe.CTestClass();
			for (int i = 0; i < numberIterations; ++i){
				c.DoNothing();
			}
		}
	}
}
