using System;
using System.Collections;
using DotNetPerformance;

namespace PerfTest.Threads
{
	public class IntWrap{
		public int data;
	}

	public class InterlockedTest {
		//TEST 10.04
		[Benchmark("Compares Interlocked to Monitor")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 5000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(InterlockedTest.Lock);
			testCases += new TestRunner.TestCase(InterlockedTest.Interlock);
			
			return tr.RunTests(testCases);
		}

		public static void Lock(int NumberIterations){
			IntWrap addMe = new IntWrap();
			for(int i = 0; i < NumberIterations; ++i){
				lock(addMe){
					++addMe.data;
				}
			}
		}

		public static void Interlock(int NumberIterations){
			IntWrap addMe = new IntWrap();
			for(int i = 0; i < NumberIterations; ++i){
				System.Threading.Interlocked.Increment(ref addMe.data);
			}
		}
	}
}
