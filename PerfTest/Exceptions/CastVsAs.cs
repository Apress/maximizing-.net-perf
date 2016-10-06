using System;
using DotNetPerformance;

namespace PerfTest.Exceptions {
	public class CastVsAs {
		static int day = DateTime.Now.Day;

		static object GetObj(){
			if (day == 0)
				return "1";
			else
				return new object();
		}

		//TEST 08.06
		[Benchmark("Compares 'as' keyword to a cast for a cast that will fail.  Highlights benefit of checking before a cast if the likelihood of success is not high.")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 100000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(CastVsAs.As);
			testCases += new TestRunner.TestCase(CastVsAs.Cast);
			
			return tr.RunTests(testCases);
		}

		public static void As(Int32 numberIterations) {
			for (int i = 0;i < numberIterations;++i) {
				string s = GetObj() as string;
				if (s != null)
					System.Windows.Forms.MessageBox.Show(s);
			}
		}

		public static void Cast(Int32 numberIterations) {
			for (int i = 0;i < numberIterations;++i) {
				try{
					string s = (string)GetObj();
					System.Windows.Forms.MessageBox.Show(s);
				}
				catch(InvalidCastException){
				}
			}
		}
	}
}
