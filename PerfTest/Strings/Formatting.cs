using System;
using System.Text;
using DotNetPerformance;

namespace PerfTest.Strings {
	public class Formatting {
		//TEST 04.05
		[Benchmark("Compares various options for creating a formatted string.")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 1000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Formatting.ToString);
			testCases += new TestRunner.TestCase(Formatting.Format);
			testCases += new TestRunner.TestCase(Formatting.StringBuilder);

			return tr.RunTests(testCases);
		}

		public static void ToString(Int32 numberIterations) {
			DateTime now = DateTime.Now;
			for (int i = 0;i < numberIterations;++i) {
				System.Text.StringBuilder sb = new System.Text.StringBuilder(30);
				sb.Append("Some start text ");
				sb.Append(now.ToString("DD MM YY", null));
				sb.Append(i);
				string s = sb.ToString();
			}
		}

		public static void Format(Int32 numberIterations) {
			DateTime now = DateTime.Now;
			for (int i = 0;i < numberIterations;++i) {
				string s = String.Format(null, "Some start text  {0:DD MM YY}{1}", now, i);
			}
		}

		public static void StringBuilder(Int32 numberIterations) {
			DateTime now = DateTime.Now;
			for (int i = 0;i < numberIterations;++i) {
				StringBuilder sb = new StringBuilder();
				sb.AppendFormat(null, "Some start text  {0:DD MM YY}{1}", now, i);
				string s = sb.ToString();
			}
		}
	}
}
