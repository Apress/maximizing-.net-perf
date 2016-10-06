using System;
using System.Collections;
using DotNetPerformance;

namespace PerfTest.Collections {
	public class Synchronized {
		ArrayList data;

		//TEST 05.18
		[Benchmark("Compares standard ArrayList vs synchronized wrapper")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 1000000;
			const int numberTestRuns = 7;
			PopulateTestData(numberIterations);
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.ExplicitLockPerLoop);
			testCases += new TestRunner.TestCase(this.ExplicitLock);
			testCases += new TestRunner.TestCase(this.SynchronizedAL);
			
			return tr.RunTests(testCases);
		}

		void PopulateTestData(int numberIterations){
			data = new ArrayList();
			for(int i = 0; i < numberIterations; ++i){
				data.Add(i);
			}
		}

		public void ExplicitLockPerLoop(int numberIterations){
			for(int i = 0; i < numberIterations; ++i){
				System.Threading.Monitor.Enter(data.SyncRoot);
				try{
					data[i] = (int)data[i] + 1;
				}
				finally{
					System.Threading.Monitor.Exit(data.SyncRoot);
				}
			}
		}

		public void ExplicitLock(int numberIterations){
			System.Threading.Monitor.Enter(data.SyncRoot);
			try{
				for(int i = 0; i < numberIterations; ++i){
					data[i] = (int)data[i] + 1;
				}
			}
			finally{
				System.Threading.Monitor.Exit(data.SyncRoot);
			}
		}

		public void SynchronizedAL(int numberIterations){
			ArrayList synch = ArrayList.Synchronized(data);
			for(int i = 0; i < numberIterations; ++i){
				synch[i] = (int)synch[i] + 1;
			}
		}
	}
}
