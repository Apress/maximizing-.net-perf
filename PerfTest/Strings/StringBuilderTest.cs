using System;
using DotNetPerformance;

namespace PerfTest.Strings {
	public class StringBuilderTest {
		private int _numberOperations;
		private string _orgString;
		private string _appendString;
		public StringBuilderTest(int numberOperations, string orgString, string appendString) {
			_numberOperations = numberOperations;
			_orgString = orgString;
			_appendString = appendString;
		}

		//TEST 04.09
		[Benchmark("Test to determine when a StringBuilder becomes more performant than a String for concat.")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 100000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.StringOp);
			testCases += new TestRunner.TestCase(this.StringBuilderOp);
			testCases += new TestRunner.TestCase(this.StringBuilderOpSizeKnown);

			return tr.RunTests(testCases);
		}

		public void StringOp(Int32 NumberIterations) {
			for (int i = 0; i < NumberIterations; ++i) {
				string s1 = _orgString;
				string s2 = _appendString;
				for(int j= 0; j < _numberOperations; ++j) {
					s1 += s2;
				}
			}
		}

		public void StringBuilderOp(Int32 NumberIterations) {
			for (int i = 0; i < NumberIterations; ++i) {
				System.Text.StringBuilder sb = new System.Text.StringBuilder(_orgString);
				string s2 = _appendString;
				for(int j= 0; j < _numberOperations; ++j) {
					sb.Append(s2);
				}
				string s = sb.ToString();
			}
		}

		public void StringBuilderOpSizeKnown(Int32 numberIterations) {
			for (int i = 0; i < numberIterations; ++i) {
				System.Text.StringBuilder sb = new System.Text.StringBuilder(_orgString, _numberOperations);
				string s2 = _appendString;
				for(int j= 0; j < _numberOperations; ++j) {
					sb.Append(s2);
				}
				string s = sb.ToString();
			}
		}
	}
}
