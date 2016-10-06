using System;
using Microsoft.VisualBasic;
using System.Collections;
using DotNetPerformance;

namespace PerfTest.Languages {
	public class VBCollectionVsArrayList {
		//TEST 06.02
		[Benchmark("Compares VB.NET collection to ArrayList")]
		public TestResultGrp RunTest() {	
			const int numberTestRuns = 5;
			const int numberIterations = 100000;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(VBColl);
			testCases += new TestRunner.TestCase(ArrayList);
			return tr.RunTests(testCases);
		}

		public void VBColl(Int32 numberIterations){
			Collection col = new Collection();
			for (int i = 0;i < numberIterations;++i)
				col.Add(i, null, null, null);
			int sum = 0;
			foreach(int i in col)
				sum += i;
		}

		public void ArrayList(Int32 numberIterations){
			ArrayList al = new ArrayList(numberIterations);
			for (int i = 0;i < numberIterations;++i)
				al.Add(i);
			int sum = 0;
			foreach(int i in al)
				sum += i;
		}
	}
}
