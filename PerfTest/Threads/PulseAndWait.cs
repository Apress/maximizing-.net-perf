using System;
using System.Collections;
using System.Threading;
using DotNetPerformance;

namespace PerfTest.Threads {
	public class PulseAndWait {
		public PulseAndWait(double ItemsInQueuePercentage){
			placeOnQueueEvery = (int)(1.0/(ItemsInQueuePercentage/100.0));
		}
		private Queue _queuePulse = new Queue();
		private Queue _queueSimple = new Queue();
		const int max = 100000;
		readonly int placeOnQueueEvery;
		private const int _maxPulse = max;
		private const int _maxSimple = max;

		//TEST 10.05
		[Benchmark("Compares Pulse to Monitor")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 1;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.PulseAndWaitTest);
			testCases += new TestRunner.TestCase(this.StandardLock);
			
			return tr.RunTests(testCases, System.Threading.ThreadPriority.Normal, true);
		}

		public void PulseAndWaitTest(int NumberIterations){
			ThreadStart tsAdd = new ThreadStart(AddToQueuePulse);
			ThreadStart tsRemove = new ThreadStart(RemoveFromQueuePulse);
			Thread threadAdd = new Thread(tsAdd);
			Thread threadRemove = new Thread(tsRemove);
			threadAdd.Start();
			threadRemove.Start();
			threadAdd.Join();
			threadRemove.Join();
		}

		public void StandardLock(int NumberIterations){
			ThreadStart tsAdd = new ThreadStart(AddToQueueSimple);
			ThreadStart tsRemove = new ThreadStart(RemoveFromQueueSimple);
			Thread threadAdd = new Thread(tsAdd);
			Thread threadRemove = new Thread(tsRemove);
			threadAdd.Start();
			threadRemove.Start();
			threadAdd.Join();
			threadRemove.Join();
		}

		public void RemoveFromQueuePulse(){
			for (;;){
				int topOfQueue = 0;
				lock(_queuePulse){
					if (_queuePulse.Count == 0){
						Monitor.Wait(_queuePulse);
					}
					topOfQueue = (int)_queuePulse.Dequeue();
					if (topOfQueue == 0){
						Monitor.Exit(_queuePulse);
						break;
					}
				}
			}
		}

		public void AddToQueuePulse(){
			for(int currentMaxPulse = _maxPulse;currentMaxPulse > -1;--currentMaxPulse){
				if (currentMaxPulse%placeOnQueueEvery == 0){
					lock(_queuePulse){
						_queuePulse.Enqueue(currentMaxPulse);
						Monitor.Pulse(_queuePulse);
					}
				}
				else
					Thread.Sleep(0);//give up rest of time slice
			}
		}

		public void RemoveFromQueueSimple(){
			for (;;){
				int topOfQueue = 0;
				lock(_queueSimple){
					if (_queueSimple.Count == 0){
						Monitor.Exit(_queueSimple);
						Thread.Sleep(0);
						continue;
					}
					topOfQueue = (int)_queueSimple.Dequeue();
					if (topOfQueue == 0){
						Monitor.Exit(_queueSimple);
						break;
					}
				}
			}
		}

		public void AddToQueueSimple(){
			for(int currentMaxSimple = _maxSimple;currentMaxSimple > -1;--currentMaxSimple){
				if (currentMaxSimple%placeOnQueueEvery == 0){
					lock(_queueSimple){
						_queueSimple.Enqueue(currentMaxSimple);
					}
				}
				else
					Thread.Sleep(0);//give up rest of time slice
			}
		}
	}
}
