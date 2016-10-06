using System;
using DotNetPerformance;

namespace PerfTest.Exceptions {
	public class ThrowEx {

		//TEST 08.04
		[Benchmark("Compares rethrow to a new throw")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 100000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(ThrowEx.NoCatch);
			testCases += new TestRunner.TestCase(ThrowEx.Rethrow);
			testCases += new TestRunner.TestCase(ThrowEx.ThrowNew);
			testCases += new TestRunner.TestCase(ThrowEx.ThrowInner);
			
			return tr.RunTests(testCases);
		}

		public static void BaseThrower(){
			String s = null;
			int i = s.Length;
		}

		public static void Rethrow(){
			try{
				BaseThrower();
			}
			catch(Exception ex){
				throw ex;
			}
		}

		public static void NoCatchMeth(){
			BaseThrower();
		}

		public static void ThrowOriginal(){
			try{
				BaseThrower();
			}
			catch(Exception){
				throw;
			}
		}

		public static void ThrowWithInner(){
			try{
				BaseThrower();
			}
			catch(Exception ex){
				throw new Exception("", ex);
			}
		}
		
		public static void NoCatch(Int32 numberIterations) {
			for (int i = 0;i < numberIterations;++i) {
				try{
					NoCatchMeth();
				}
				catch(Exception){;}
			}
		}

		public static void Rethrow(Int32 numberIterations) {
			for (int i = 0;i < numberIterations;++i) {
				try{
					Rethrow();
				}
				catch(Exception){;}
			}
		}

		public static void ThrowNew(Int32 numberIterations) {
			for (int i = 0;i < numberIterations;++i) {
				try{
					ThrowOriginal();
				}
				catch(Exception){;}
			}
		}

		public static void ThrowInner(Int32 numberIterations) {
			for (int i = 0;i < numberIterations;++i) {
				try{
					ThrowOriginal();
				}
				catch(Exception){;}
			}
		}
	}
}
