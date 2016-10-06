using System;
using System.Text;
using DotNetPerformance;
using System.Runtime.InteropServices;

namespace PerfTest.Interop {
	public class COMvsPInvoke {
		[DllImport("InteropDllTest.dll")] public static extern int ZeroParams();

		//TEST 13.08
		public TestResultGrp RunTest() {	
			const int numberIterations = 5000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(COM);
			testCases += new TestRunner.TestCase(PInvoke);

			return tr.RunTests(testCases);
		}

		[Benchmark("Compares do-nothing COM and PInvoke calls")]
		public void COM(Int32 numberIterations){
			interopsafe.CTestClass c = new interopsafe.CTestClass();
			for (int i = 0; i < numberIterations; ++i){
				c.DoNothing();
			}
		}

		public void PInvoke(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				ZeroParams();
			}
		}
	}
}
