using System;
using System.Reflection;
using DotNetPerformance;
using System.Runtime.InteropServices;

namespace PerfTest.CLR {
	public class ConvertvsCast {
		short _s;
		//TEST 14.09
		[Benchmark("Compares cast to convert.")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 10000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Convert);
			testCases += new TestRunner.TestCase(Cast);

			return tr.RunTests(testCases);
		}

		public void Cast(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				_s = (short)(i % Int16.MaxValue);
			}
		}

		public void Convert(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				_s = System.Convert.ToInt16(i % Int16.MaxValue);
			}
		}
	}
}
