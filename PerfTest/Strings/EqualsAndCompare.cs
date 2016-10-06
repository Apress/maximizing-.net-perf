using System;
using DotNetPerformance;

namespace PerfTest.Strings {
	public class EqualsAndCompare {
		bool _res = false;
		string[] _strings = new string[]{"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"};
		string _s = "Zero";

		//TEST 04.03
		[Benchmark("Looks at benefit of using short-circuit evaluation to avoid an expensive Compare call")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 10000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Compare);
			testCases += new TestRunner.TestCase(EqualAndCompare);

			return tr.RunTests(testCases);
		}

		public void Compare(Int32 numberIterations) {
			for (int i = 0;i < numberIterations;++i) {
				_res = (String.Compare(_strings[i%10], _s) == 0);
			}
		}

		public void EqualAndCompare(Int32 numberIterations) {
			for (int i = 0;i < numberIterations;++i) {
				_res = (String.Equals(_strings[i%10], _s) || String.Compare(_strings[i%10], _s) == 0);
			}
		}
	}
}
