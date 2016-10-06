using System;
using System.Collections;
using DotNetPerformance;

namespace PerfTest.Collections {
	public class ArrayListTest {
		[Benchmark("Looks at boxing consequence of element addition to an ArrayList")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 5000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.BoxingAndDefaultInitialSize);
			testCases += new TestRunner.TestCase(this.BoxingAndCorrectInitialSize);
			testCases += new TestRunner.TestCase(this.NoBoxingAndDefaultInitialSize);
			testCases += new TestRunner.TestCase(this.NoBoxingAndCorrectInitialSize);
			
			return tr.RunTests(testCases);
		}

		public void BoxingAndDefaultInitialSize(Int32 NumberIterations){
			ArrayList al = new ArrayList();
			for (int i = 0; i < NumberIterations; ++i)
				al.Add(i);
		}

		public void BoxingAndCorrectInitialSize(Int32 NumberIterations){
			ArrayList al = new ArrayList(NumberIterations);
			for (int i = 0; i < NumberIterations; ++i)
				al.Add(i);
		}

		public void NoBoxingAndDefaultInitialSize(Int32 NumberIterations){
			ArrayList al = new ArrayList();
			for (int i = 0; i < NumberIterations; ++i)
				al.Add(null);
		}

		public void NoBoxingAndCorrectInitialSize(Int32 NumberIterations){
			ArrayList al = new ArrayList(NumberIterations);
			for (int i = 0; i < NumberIterations; ++i)
				al.Add(null);
		}
	}
}
