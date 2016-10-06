using System;
using System.Collections;
using DotNetPerformance;

namespace PerfTest.Collections {
	public class LoopTermination {

		ArrayList data;
		long l;
		//TEST 05.16
		[Benchmark("Looks at perf consequence of running to exception rather than checking colletion bounds.")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 10000000;
			const int numberTestRuns = 5;
			PopulateTestData(numberIterations);
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.Check);
			testCases += new TestRunner.TestCase(this.Exception);
			
			return tr.RunTests(testCases);
		}

		void PopulateTestData(int NumberIterations){
			data = new ArrayList(NumberIterations);
			for (int i = 0; i < NumberIterations; ++i)
				data.Add(i);
		}

		public void Check(Int32 NumberIterations){
			for (int i = 0; i < data.Count; ++i)
				l += data[i].GetHashCode();
		}

		public void Exception(Int32 NumberIterations){
			try{
				for (int i = 0;; ++i)
					l += data[i].GetHashCode();
			}
			catch(Exception){}
		}
	}
}
