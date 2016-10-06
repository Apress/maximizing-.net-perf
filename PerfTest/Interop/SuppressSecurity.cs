using System;
using System.Text;
using DotNetPerformance;
using System.Runtime.InteropServices;

namespace PerfTest.Interop {
	public class SuppressSecurity {
		[DllImport("InteropDllTest.dll")] public static extern int ZeroParams();

		[System.Security.SuppressUnmanagedCodeSecurity()]
		[DllImport("InteropDllTest.dll", EntryPoint="ZeroParams")] public static extern int ZeroParamsSuppress();

		//TEST 13.06
		[Benchmark("Compares SuppressUnmanagedCodeSecurity PInvoke call to call with stack walk")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 1000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Suppressed);
			testCases += new TestRunner.TestCase(Normal);

			return tr.RunTests(testCases);
		}
		
		public void Suppressed(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				ZeroParamsSuppress();
			}
		}

		public void Normal(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				ZeroParams();
			}
		}
	}
}
