using System;
using DotNetPerformance;

namespace PerfTest.Collections {
	public class LoopInvariants {

		int[] data;
		//TEST 05.17
		[Benchmark("Looks at perf consequence of removing length check from loop termination condition.")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 50000000;
			const int numberTestRuns = 7;
			PopulateTestData(numberIterations);
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.Inline);
			testCases += new TestRunner.TestCase(this.Extracted);
			
			return tr.RunTests(testCases);
		}

		void PopulateTestData(int NumberIterations){
			data = new int[NumberIterations -1];
			for (int i = 0; i < data.Length; ++i)
				data[i] = i;
		}

		public void Inline(Int32 NumberIterations){
			long l = 0;
			for (int i = 0; i < data.Length; ++i)
				l += data[i];
		}

		public void Extracted(Int32 NumberIterations){
			long l = 0;
			int maxCnt = data.Length;
			for (int i = 0; i < maxCnt; ++i)
				l += data[i];
		}
	}
}
