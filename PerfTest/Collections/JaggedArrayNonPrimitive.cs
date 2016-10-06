using System;
using DotNetPerformance;

namespace PerfTest.Collections {
	public class ThreeDPoint{
		public ThreeDPoint(int x, int y, int z){
			this.x = x; this.y = y; this.z = z;
		}
		public int x;
		public int y;
		public int z;
	}

	public class JaggedArrayNonPrimitive {
		//TEST 05.02
		[Benchmark("Compares iteration speed of jagged vs rectangular array")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 100000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(JaggedArray.Jagged);
			testCases += new TestRunner.TestCase(JaggedArray.Rectangular);
			
			return tr.RunTests(testCases);
		}

		public static void Jagged(Int32 numberIterations) {
			ThreeDPoint [][] arr = new ThreeDPoint[numberIterations][];
			for (int i = 0;i < numberIterations;++i) {
				arr[i] = new ThreeDPoint[numberIterations];
			}
			for (int i = 0;i < arr.Length;++i) {
				for (int j = 0;j < arr[i].Length;++j) {
					arr[i][j].x = i;
					arr[i][j].y = j;
					arr[i][j].z = i + j;
				}
			}
		}

		public static void Rectangular(Int32 numberIterations) {
			ThreeDPoint [,] arr = new ThreeDPoint[numberIterations,numberIterations];
			for (int i = 0;i < arr.GetLength(0);++i) {
				for (int j = 0;j < arr.GetLength(1);++j) {
					arr[i,j].x = i;
					arr[i,j].y = j;
					arr[i,j].z = i + j;
				}
			}
		}
	}
}
