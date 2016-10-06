using System;
using System.Collections;
using DotNetPerformance;
using System.Runtime.InteropServices;

namespace PerfTest.Exceptions {
	public class CastvsAsNoFail {
		ArrayList _al;
		public CastvsAsNoFail(){
			_al = new ArrayList();
			for (int ix = 0; ix < 100; ++ix)
				_al.Add(ix);
		}

		//TEST 08.05
		[Benchmark("Compares 'as' keyword to a cast for a cast that won't fail")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 1000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(As);
			testCases += new TestRunner.TestCase(Cast);

			return tr.RunTests(testCases);
		}

		public void Cast(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				int[] ia =(int[])_al.ToArray(typeof(int));
			}
		}

		public void As(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				int[] ia =_al.ToArray(typeof(int)) as int[];
				}
		}
	}
}
