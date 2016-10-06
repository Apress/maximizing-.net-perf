using System;
using System.Text;
using DotNetPerformance;
using System.Runtime.InteropServices;

namespace PerfTest.Interop {
	public class ThrowVsCheck {
		//TEST 13.09
		[Benchmark("Compares performance of COM calls that thrown on non-S_OK to calls with original IDL signature")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 10000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Throw);
			testCases += new TestRunner.TestCase(Check);

			return tr.RunTests(testCases);
		}

		public void Throw(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				bool callWorkeded = true;
				try{
					InteropComTest.ITest t = new InteropComTest.CTestClass();
					t.Thrower();
				}
				catch(Exception){
					callWorkeded = false;
				}
				bool b = callWorkeded;
			}
		}

		public void Check(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				bool callWorkeded = true;
				try{
					InteropComTestNoThrow.ITest t = new InteropComTestNoThrow.CTestClass();
					if(t.Thrower()<0)
						callWorkeded = false;
				}
				catch(Exception){
					;
				}
				bool b = callWorkeded;
			}
		}
	}
}
