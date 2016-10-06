using System;
using System.Threading;
using DotNetPerformance;

namespace PerfTest.Threads {
	public class ReaderWriterVsMonitorMultiThreaded {
		ReaderWriterLock _rwl = new ReaderWriterLock();
		private uint _count;
		const int _numberIterations = 500000;
		const int _numberThreads = 5;

		//TEST 10.07
		[Benchmark("Compares ReaderWriterLock to Monitor when there are multiple threads.")]
		public TestResultGrp RunTest() {	
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(_numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.WriterLock);
			testCases += new TestRunner.TestCase(this.MonitorAndWriter);
			
			return tr.RunTests(testCases, System.Threading.ThreadPriority.Normal, true);
		}

		public void WriterLock(int NumberIterations){
			_count = 0;
			Thread[] threads = new Thread[_numberThreads];
			for (int ix = 0; ix < _numberThreads; ++ix)
				threads[ix] = new Thread(new ThreadStart(WriterLockIncrement));
			for (int ix = 0; ix < _numberThreads; ++ix)
				threads[ix].Start();
			for (int ix = 0; ix < _numberThreads; ++ix)
				threads[ix].Join();
		}

		private void WriterLockIncrement(){
			for(;_count < _numberIterations;){
				try{
					_rwl.AcquireWriterLock(Timeout.Infinite);
					++_count;
				}
				finally{
					_rwl.ReleaseWriterLock();
				}

			}
		}

		public void MonitorAndWriter(int NumberIterations){
			_count = 0;
			Thread[] threads = new Thread[_numberThreads];
			for (int ix = 0; ix < _numberThreads; ++ix)
				threads[ix] = new Thread(new ThreadStart(MonitorAndWriterIncrement));
			for (int ix = 0; ix < _numberThreads; ++ix)
				threads[ix].Start();
			for (int ix = 0; ix < _numberThreads; ++ix)
				threads[ix].Join();
		}

		public void MonitorAndWriterIncrement(){
			for(;_count < _numberIterations;){
				lock(this){
					try{
						_rwl.AcquireWriterLock(Timeout.Infinite);
						++_count;
					}
					finally{
						_rwl.ReleaseWriterLock();
					}
				}
			}
		}
	}
}
