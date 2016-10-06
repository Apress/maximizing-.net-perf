using System;
using System.Threading;
using DotNetPerformance;

namespace PerfTest.Threads
{
	public class MutexMonitor {
		//TEST 10.03
		[Benchmark("Compares Mutex to Monitor")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 5000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.MutexLock);
			testCases += new TestRunner.TestCase(this.MonitorLock);
			
			return tr.RunTests(testCases);
		}

		public void MonitorLock(int NumberIterations){
			for(int i = 0; i < NumberIterations;){
				lock(this){
					++i;
				}
			}
		}

		public void MutexLock(int NumberIterations){
			Mutex mutex = new Mutex();
			for(int i = 0; i < NumberIterations;){
				mutex.WaitOne();
				++i;
				mutex.ReleaseMutex();
			}
		}
	}
}
