using System;
using DotNetPerformance;

namespace PerfTest.Exceptions {
	public class OnErrorResume {
		//TEST 08.02
		[Benchmark("Compares On Error Resume next to structured error handling")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 1000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(OnErrorResume.OnError);
			testCases += new TestRunner.TestCase(OnErrorResume.TryCatch);
			
			return tr.RunTests(testCases);
		}

		public static void OnError(Int32 numberIterations) {
			VBExceptionHandling.ExceptionTest vbTest = new VBExceptionHandling.ExceptionTest();
			for (int i = 0;i < numberIterations;++i) {
				vbTest.OnErrorMethod();
			}
		}

		public static void TryCatch(Int32 numberIterations) {
			VBExceptionHandling.ExceptionTest vbTest = new VBExceptionHandling.ExceptionTest();
			for (int i = 0;i < numberIterations;++i) {
				vbTest.TryCatchMethod();
			}
		}

	}
}
