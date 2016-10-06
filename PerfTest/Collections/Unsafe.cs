using System;
using DotNetPerformance;

namespace PerfTest.Collections {
	public struct Point{
		public int w;
		public int x;
		public int y;
		public int z;
	}

	public class Unsafe {

		Point[,] data;
		//TEST 05.05
		[Benchmark("Looks at unsafe data manipulation vs standard element access.")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 10000;
			const int numberTestRuns = 5;
			PopulateTestData(numberIterations);
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.CheckedAccess);
			testCases += new TestRunner.TestCase(this.UnsafeAccess);
			
			return tr.RunTests(testCases);
		}

		void PopulateTestData(int NumberIterations){
			data = new Point[NumberIterations -1,(NumberIterations -1)/10];
		}

		public void CheckedAccess(Int32 NumberIterations){
			int iUpper = data.GetUpperBound(0);
			int jUpper = data.GetUpperBound(1);
			for (int i = 0; i < iUpper; ++i){
				for (int j = 0; j < jUpper; ++j){
					data[i,j].x = i;
					data[i,j].y = j;
					data[i,j].z = i + j;
					data[i,j].w = i - j;
				}
			}

		}

		unsafe public void UnsafeAccess(Int32 NumberIterations){
			int iUpper = data.GetUpperBound(0);
			int jUpper = data.GetUpperBound(1);
			fixed (Point* element = &data[0,0]) {
				for (int i = 0; i < iUpper; ++i){
					for (int j = 0; j < jUpper; ++j){
						element[i*jUpper + j].x = i;
						element[i*jUpper + j].y = j;
						element[i*jUpper + j].z = i+j;
						element[i*jUpper + j].w = i - j;
					}
				}
			}
		}
	}
}
