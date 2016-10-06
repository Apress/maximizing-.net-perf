using System;
using DotNetPerformance;

namespace PerfTest.ClassDesign {
	public class Single{public string s;public Single(string s){this.s = s;}}
	public class Double{public string s = String.Empty;public Double(string s){this.s = s;}}
	public class DoubleInitialise {
		//TEST 03.05
		[Benchmark("Compares allocation speed for types that always iniatize memeber variables to a default value compared to normal types.")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 10000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(DoubleInitialise.SingleAlloc);
			testCases += new TestRunner.TestCase(DoubleInitialise.DoubleAlloc);
			
			return tr.RunTests(testCases);
		}

		public static void SingleAlloc(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				Single s = new Single("text");
			}
		}
		public static void DoubleAlloc(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				Double s = new Double("text");
			}
		}
	}
}
