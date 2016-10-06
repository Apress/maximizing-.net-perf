using System;
using DotNetPerformance;
namespace PerfTest.Strings {
	public class EnumTest {
		//TEST 04.06
		[Benchmark("Compares string iteration techniques.")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 10000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(EnumTest.CharacterArray);
			testCases += new TestRunner.TestCase(EnumTest.ForEach);

			return tr.RunTests(testCases);
		}
		public static void CharacterArray(Int32 numberIterations) {
			string s = "1234567890";
			for (int i = 0;i < numberIterations;++i) {
				for (int j = 0; j < s.Length; ++j) {
					s[j].GetHashCode();
				}
			}
		}
		public static void ForEach(Int32 numberIterations) {
			string s = "1234567890";
			for (int i = 0;i < numberIterations;++i) {
				foreach(char c in s) {
					c.GetHashCode();
				}
			}
		}
	}
}
