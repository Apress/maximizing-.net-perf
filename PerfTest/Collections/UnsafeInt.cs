using System;
using DotNetPerformance;

namespace PerfTest.Collections {
	public class UnsafeLong {

		long[] data;

		//TEST 05.04
		[Benchmark("Looks at unsafe data manipulation vs standard element access for longs.")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 10000000;
			const int numberTestRuns = 5;
			PopulateTestData(numberIterations);
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.CheckedAccess);
			testCases += new TestRunner.TestCase(this.UnsafeAccess);
			
			return tr.RunTests(testCases);
		}

		void PopulateTestData(int NumberIterations){
			data = new long[NumberIterations];
		}

		public void CheckedAccess(Int32 NumberIterations){
			long sum = 0;
			for (int i = 0; i < data.Length; ++i){
				data[i] = i;
			}
			for (int i = 0; i < data.Length; ++i){
				sum += data[i];
			}
		}

		unsafe public void UnsafeAccess(Int32 NumberIterations){
			long sum = 0;
			fixed (long* element = &data[0]) {
				for (int i = 0; i < data.Length; ++i){
					element[i] = i;
				}
				for (int i = 0; i < data.Length; ++i){
					sum += element[i];
				}
			}
		}
	}
}
