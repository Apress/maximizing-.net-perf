using System;
using System.Text;
using DotNetPerformance;

namespace PerfTest.Strings {
	public class StringBuilderSize {
		private string[] _testStrings;
		public StringBuilderSize(){
			BuildTestStringArray();
		}

		private void BuildTestStringArray(){
			_testStrings = new string[numberIterations * 100];
			Random rnd = new Random();
			for(int i = 0; i < _testStrings.Length; ++i){
				byte[] buff = new byte[(int)(25.0*rnd.NextDouble())];
				rnd.NextBytes(buff);
				_testStrings[i] = Convert.ToBase64String(buff);
			}
		}

		static readonly int numberIterations = 1000;

		[Benchmark("Compares effect of StringBuilder size on perf.")]
		public TestResultGrp RunTest() {	
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.One);
			testCases += new TestRunner.TestCase(this.Ten);
			testCases += new TestRunner.TestCase(this.Hundred);

			return tr.RunTests(testCases);
		}

		public void One(Int32 NumberIterations) {
			StringBuilder sb = new StringBuilder(50*NumberIterations);
			for (int i = 0; i < NumberIterations; ++i) {
				sb.Append(_testStrings[i]);
				sb.Append("\r\n");
			}
			sb.ToString();
		}

		public void Ten(Int32 NumberIterations) {
			StringBuilder sb = new StringBuilder(500*NumberIterations);
			for (int i = 0; i < (NumberIterations*10); ++i) {
				sb.Append(_testStrings[i]);
				sb.Append("\r\n");
			}
			sb.ToString();
		}

		public void Hundred(Int32 NumberIterations) {
			StringBuilder sb = new StringBuilder(5000*NumberIterations);
			for (int i = 0; i < (NumberIterations*100); ++i) {
				sb.Append(_testStrings[i]);
				sb.Append("\r\n");
			}
			sb.ToString();
		}
	}
}
