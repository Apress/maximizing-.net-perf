using System;
using DotNetPerformance;

namespace PerfTest.ClassDesign {
	public struct NegativeIntOne {
		private int _i;
		public NegativeIntOne(int i){_i = -Math.Abs(i);}
		public static implicit operator int(NegativeIntOne x) {return x._i;}
	}

	public struct NegativeIntTwo {
		private int _i;
		public NegativeIntTwo(int i){_i = -Math.Abs(i);}
		public static explicit operator int(NegativeIntTwo x) {return x._i;}
	}

	public class TypeConversion {
		//TEST 03.08
		[Benchmark("Compares implicit vs explicit interface user defined operators.")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 100000000;
			const int numberTestRuns = 11;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(TypeConversion.Implicit);
			testCases += new TestRunner.TestCase(TypeConversion.Explicit);

			return tr.RunTests(testCases);
		}
		public static void Implicit(Int32 numberIterations) {	
			NegativeIntOne n= new NegativeIntOne(6);
			for (int i = 0;i < numberIterations;++i) {
				int j = n;
			}
		}
		
		public static void Explicit(Int32 numberIterations) {	
			NegativeIntTwo n= new NegativeIntTwo(6);
			for (int i = 0;i < numberIterations;++i) {
				int j = (int)n;
			}
		}

	}
}
