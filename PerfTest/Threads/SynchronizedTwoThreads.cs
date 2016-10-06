using System;
using System.Collections;
using DotNetPerformance;
using System.Runtime.Remoting.Contexts;

namespace PerfTest.Threads
{
	public class SynchronizedTwoThreads
	{
		ArrayList _data;
		int _nextNumberAvailable;
		const int _numberIterations = 4000000;

		[Benchmark("Compares various forms of thread safety for multiple threads.")]
		public TestResultGrp RunTest() {	
			const int numberTestRuns = 5;
			PopulateTestData();
			TestRunner tr = new TestRunner(_numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.LowGranularityLock);
			testCases += new TestRunner.TestCase(this.HighGranularityLock);
			
			return tr.RunTests(testCases, System.Threading.ThreadPriority.Normal, true);
		}

		void PopulateTestData(){
			_data = new ArrayList();
			for(int i = 0; i < _numberIterations; ++i){
				_data.Add(i);
			}
		}

		public void LowGranularityLock(int NumberIterations){
			_nextNumberAvailable = 0;
			System.Threading.Thread t1 = new System.Threading.Thread(new System.Threading.ThreadStart(ModifyCollectionHoldLock));
			System.Threading.Thread t2 = new System.Threading.Thread(new System.Threading.ThreadStart(ModifyCollectionHoldLock));
			t1.Start();
			t2.Start();
			t1.Join();
			t2.Join();
		}

		public void HighGranularityLock(int NumberIterations){
			_nextNumberAvailable = 0;
			System.Threading.Thread t1 = new System.Threading.Thread(new System.Threading.ThreadStart(ModifyCollection));
			System.Threading.Thread t2 = new System.Threading.Thread(new System.Threading.ThreadStart(ModifyCollection));
			t1.Start();
			t2.Start();
			t1.Join();
			t2.Join();
		}

		public void ModifyCollectionHoldLock(){
			System.Threading.Monitor.Enter(_data);
			try{
				for(;_nextNumberAvailable < _numberIterations;){
					_data[_nextNumberAvailable] = (int)_data[_nextNumberAvailable] + 1;
					System.Threading.Interlocked.Increment(ref _nextNumberAvailable);
				}
			}
			finally{
				System.Threading.Monitor.Exit(_data);
			}
		}

		public void ModifyCollection(){
			for(;_nextNumberAvailable < _numberIterations;){
				System.Threading.Monitor.Enter(_data);
				try{
					_data[_nextNumberAvailable] = (int)_data[_nextNumberAvailable] + 1;
				}
				finally{
					System.Threading.Monitor.Exit(_data);
				}
				System.Threading.Interlocked.Increment(ref _nextNumberAvailable);
			}
		}
	}
}
