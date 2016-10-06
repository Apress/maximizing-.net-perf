using System;
using System.Threading;
using DotNetPerformance;

namespace PerfTest.Threads {
	public class ReaderWriterVsMonitor {
		ReaderWriterLock rwl = new ReaderWriterLock();

		//TEST 10.06
		[Benchmark("Compares ReaderWriterLock to Monitor")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 1000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.ReaderLock);
			testCases += new TestRunner.TestCase(this.WriterLock);
			testCases += new TestRunner.TestCase(this.Monitor);
			testCases += new TestRunner.TestCase(this.MonitorAndWriter);
			
			return tr.RunTests(testCases, System.Threading.ThreadPriority.Normal, true);
		}

		public void WriterLock(int NumberIterations){
			for(int i = 0; i < NumberIterations;){
				try{
					rwl.AcquireWriterLock(Timeout.Infinite);
					++i;
				}
				finally{
					rwl.ReleaseWriterLock();
				}

			}
		}

		public void ReaderLock(int NumberIterations){
			for(int i = 0; i < NumberIterations;++i){
				try{
					rwl.AcquireReaderLock(Timeout.Infinite);
				}
				finally{
					rwl.ReleaseReaderLock();
				}

			}
		}

		public void Monitor(int NumberIterations){
			for(int i = 0; i < NumberIterations;){
				lock(this){
					++i;
				}
			}
		}

		public void MonitorAndWriter(int NumberIterations){
			for(int i = 0; i < NumberIterations;){
				lock(this){
					rwl.AcquireWriterLock(Timeout.Infinite);
					++i;
					rwl.ReleaseWriterLock();
				}
			}
		}
	}
}
