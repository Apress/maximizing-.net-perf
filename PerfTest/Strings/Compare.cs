using System;
using DotNetPerformance;

namespace PerfTest.Strings {
	public class CompareTest {
		int _noOps;
		public CompareTest(int numberOfOps){
			_noOps = numberOfOps;
		}

		//TEST 04.04
		[Benchmark("Compares case-insensitive Compare to ToUpper + Equals")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 1000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Compare);
			testCases += new TestRunner.TestCase(ToUpperEquals);

			return tr.RunTests(testCases);
		}

		public void Compare(Int32 numberIterations) {
			string s1 = "abcdef";
			string s2 = "ABCDEF";
			int j;
			for (int i = 0;i < numberIterations;++i) {
				for (int k = 0; k < _noOps; ++k)
					j = String.Compare(s1, s2, true);
			}
		}

		public void ToUpperEquals(Int32 numberIterations) {
			string s1 = "abcdef";
			string s2 = "ABCDEF";
			bool b;
			for (int i = 0;i < numberIterations;++i) {
				string S1 = s1.ToUpper();
				string S2 = s2.ToUpper();
				for (int k = 0; k < _noOps; ++k)
					b = String.Equals(S1, S2);
			}
		}
	}
}
