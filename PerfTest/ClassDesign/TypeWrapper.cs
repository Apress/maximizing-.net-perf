using System;
using DotNetPerformance;

namespace PerfTest.ClassDesign {
	public struct NegativeInt {
		private int _i;
		public NegativeInt(int i){_i = -Math.Abs(i);}
		public static implicit operator int(NegativeInt x) {return x._i;}
	}

	public class TypeWrapper {
		//TEST 03.09
		[Benchmark("Compares cost of have a type with a user defined conversion compared to a variable that does not require the conversion.")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 500000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(TypeWrapper.Wrapper);
			testCases += new TestRunner.TestCase(TypeWrapper.Int);

			return tr.RunTests(testCases);
		}
		public static void Wrapper(Int32 numberIterations) {	
			NegativeInt n= new NegativeInt(6);
			for (int i = 0;i < numberIterations;++i) {
				int j = n + 1;
			}
		}
		
		public static void Int(Int32 numberIterations) {	
			int n = 6;
			n = -Math.Abs(n);
			for (int i = 0;i < numberIterations;++i) {
				int j = n + 1;
			}
		}
	}
}
