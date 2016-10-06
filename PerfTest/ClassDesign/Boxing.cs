using System;
using DotNetPerformance;

namespace PerfTest.ClassDesign {
	public class Boxing {
		[Benchmark("Test perf. advantage of providing overloads for common value types like int and long to avoid boxing.")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 10000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Boxing.BoxingMethod);
			testCases += new TestRunner.TestCase(Boxing.CorrectType);
			
			return tr.RunTests(testCases);
		}

		public static void CorrectType(Int32 numberIterations) {
			for (long i = 0;i < numberIterations;) {
				i = Convert.ToInt64((int)i) + 1;
			}
		}

		public static void BoxingMethod(Int32 numberIterations) {
			for (long i = 0;i < numberIterations;) {
				i = Convert.ToInt64((object)i) + 1;//cast to object forces a boxing op.
			}
		}
	}
}
