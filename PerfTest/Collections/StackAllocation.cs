using System;
using DotNetPerformance;

namespace PerfTest.Collections {
	public class StackAllocation {
		static readonly int colSize = 50;
		//TEST 05.20
		[Benchmark("Compared stack vs heap allocated memory in terms of allocation speed and usage.")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 1000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Array);
			testCases += new TestRunner.TestCase(Stack);
			
			return tr.RunTests(testCases);
		}

		void Array(int NumberIterations){
			for (int i = 0; i < NumberIterations; ++i){
				int sum = 0;
				int[] coll = new int[colSize];
				for(int ix = 0; ix < colSize; ++ix)
					coll[ix] = ix;

				for(int ix = 0; ix < colSize; ++ix)
					sum += coll[ix];
			}
		}

		public void Stack(Int32 NumberIterations){
			for (int i = 0; i < NumberIterations; ++i){
				StackTest();
			}
		}

		private unsafe void StackTest(){ //needed to clean up stack and prevent overflow
			int sum = 0;
			int* coll = stackalloc int[colSize];
			for(int ix = 0; ix < colSize; ++ix)
				coll[ix] = ix;

			for(int ix = 0; ix < colSize; ++ix)
				sum += coll[ix];
		}
	}
}
