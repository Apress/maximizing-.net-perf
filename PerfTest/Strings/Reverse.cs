using System;
using System.Text;
using DotNetPerformance;

namespace PerfTest.Strings {
	public class Reverse {
		static string _s = "1234567890";
		static string _res;

		//TEST 04.10
		[Benchmark("Compares various techniques for string reversal.")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 1000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Reverse.CharacterArrayReverse);
			testCases += new TestRunner.TestCase(Reverse.VBCompatibility);
			testCases += new TestRunner.TestCase(Reverse.StringBuilder);
			testCases += new TestRunner.TestCase(Reverse.CharArrayString);

			return tr.RunTests(testCases);
		}
		public static void CharacterArrayReverse(Int32 numberIterations) {
			for (int i = 0;i < numberIterations;++i) {
				if (_s != null && _s.Length != 0){
					char[] ca = _s.ToCharArray();
					Array.Reverse(ca);
					_res = new string(ca);
				}
			}
		}
		public static void VBCompatibility(Int32 numberIterations) {
			for (int i = 0;i < numberIterations;++i) {
				_res = Microsoft.VisualBasic.Strings.StrReverse(_s);
			}
		}
		public static void StringBuilder(Int32 numberIterations) {
			for (int i = 0;i < numberIterations;++i) {
				if (_s != null && _s.Length != 0){
					StringBuilder sb = new StringBuilder(_s.Length);
					for (int ix = _s.Length-1; ix != 0; --ix){
						sb.Append(_s[ix]);
					}
					_res = sb.ToString();
				}
			}
		}
		public static void CharArrayString(Int32 numberIterations) {
			for (int i = 0;i < numberIterations;++i) {
				if (_s != null && _s.Length != 0){
					char[] chars = new char[_s.Length];
					int ix = _s.Length - 1, j = 0;

					while(ix >= 0)
						chars[ix--] = _s[j++];

					_res = new string(chars);
				}
			}
		}
	}
}
