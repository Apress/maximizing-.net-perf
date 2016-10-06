using System;
using DotNetPerformance;

namespace PerfTest.ClassDesign {
	public class NonInitialise{public int i;}
	public class Initialise{public int i;public Initialise(){i=0;}}

	public class VariableInitializers {
		//TEST 03.04
		[Benchmark("Compares allocation speed for types that are over cautious and re-zero memory compared to normal types.")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 100000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(VariableInitializers.InitialiseAlloc);
			testCases += new TestRunner.TestCase(VariableInitializers.NonInitialiseAlloc);
			
			return tr.RunTests(testCases);
		}

		public static void NonInitialiseAlloc(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				NonInitialise s = new NonInitialise();
				s.i = 23;
			}
		}
		public static void InitialiseAlloc(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				Initialise s = new Initialise();
				s.i = 23;
			}
		}
	}
}
