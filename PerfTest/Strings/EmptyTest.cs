using System;
using DotNetPerformance;
namespace PerfTest.Strings {
	public class EmptyTest {
		//TEST 04.07
		[Benchmark("Compares speed of emptiness checks on a string")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 100000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(EmptyTest.StringEmpty);
			testCases += new TestRunner.TestCase(EmptyTest.EmptyString);
			testCases += new TestRunner.TestCase(EmptyTest.Length);

			return tr.RunTests(testCases);
		}

		static string s = "";

		public static void StringEmpty(Int32 numberIterations) {
			for (int i = 0;i < numberIterations;++i) {
				bool b = (s == String.Empty);
			}
		}
		public static void EmptyString(Int32 numberIterations) {
			for (int i = 0;i < numberIterations;++i) {
				bool b = (s == "");
			}
		}
		public static void Length(Int32 numberIterations) {
			for (int i = 0;i < numberIterations;++i) {
				bool b = (s.Length == 0);
			}
		}
	}
}
