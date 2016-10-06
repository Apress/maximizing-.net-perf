using System;
using DotNetPerformance;

namespace PerfTest.Strings {
	public class InternCompareTest {
		string _compareTo;
		bool _res;
		string interned = "InternedCopy";
		public InternCompareTest(String CompareTo) {
			_compareTo = CompareTo;
		}

		//TEST 04.08
		[Benchmark("Looks at compare speed for interned and non-interned strings.")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 50000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.InternedCompare);
			testCases += new TestRunner.TestCase(this.NonInternedCompare);

			return tr.RunTests(testCases);
		}
		public void InternedCompare(Int32 numberIterations) {
			for (int i = 0; i < numberIterations; ++i) {
				_res = Object.ReferenceEquals(interned, "123");
			}
		}
		public void NonInternedCompare(Int32 numberIterations) {
			for (int i = 0; i < numberIterations; ++i) {
				_res = _compareTo == "123";
			}
		}
	}
}
