using System;
using DotNetPerformance;

namespace PerfTest.Interop {
	public unsafe class AllocationLocations {
		static readonly int ArraySize = 100;

		//TEST 13.02
		[Benchmark("Looks at raw speed difference between stack and heap allocation")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 10000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Stack);
			testCases += new TestRunner.TestCase(Heap);

			return tr.RunTests(testCases);
		}

		public unsafe void Stack(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				StackAllocCaller();
			}
		}

		private unsafe void StackAllocCaller(){
			byte* b = stackalloc byte[ArraySize];
		}

		public void Heap(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				byte[] b= new byte[ArraySize];
			}
		}
	}
}
