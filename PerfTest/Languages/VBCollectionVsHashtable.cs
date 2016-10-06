using System;
using Microsoft.VisualBasic;
using System.Collections;
using DotNetPerformance;

namespace PerfTest.Languages {
	public class VBCollectionVsHashtable {
		//TEST 06.01
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
				col.Add(i, i.ToString(), null, null);
		}

		public void ArrayList(Int32 numberIterations){
			Hashtable ht = new Hashtable();
			for (int i = 0;i < numberIterations;++i)
				ht[i] = i.ToString();
		}
	}
}
