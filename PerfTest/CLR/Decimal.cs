using System;
using System.Collections;
using DotNetPerformance;
using System.Runtime.InteropServices;

namespace PerfTest.CLR {
	public class DecimalTestCase {
		double _dbl;
		Decimal _dec;
		//TEST 14.06
		[Benchmark("Looks at performance cost of decimal vs double. The fact that decimal offers much greater precision is noted.")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 10000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(DecimalTest);
			testCases += new TestRunner.TestCase(DoubleTest);

			return tr.RunTests(testCases);
		}

		public void DoubleTest(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				double d = i + _dbl;
				d *= 2.0;
				d += 1.0;
				d /= 3.0;
				d -= 1.0;
				_dbl = d;
			}
		}

		public void DecimalTest(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				Decimal d = i + _dec;
				d *= 2.0M;
				d += 1.0M;
				d /= 3.0M;
				d -= 1.0M;
				_dec = d;
			}
		}
	}
}