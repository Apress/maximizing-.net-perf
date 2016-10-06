using System;
using System.Collections;
using DotNetPerformance;

namespace PerfTest.Threads
{
	public class IntAdd{
		private int data;
		public virtual int Data{
			get{return data;} 
			set{data = value;}
		}

		public virtual bool IsSynchronized {
			get {
				return false;
			}
		}

		public virtual object SyncRoot {
			get {
				return this;
			}
		}

		public static PerfTest.Threads.IntAdd Synchronized(PerfTest.Threads.IntAdd inst) {
			return new SynchIntAdd(inst);
		}

		private class SynchIntAdd : PerfTest.Threads.IntAdd {
			private object _root;
			private PerfTest.Threads.IntAdd _parent;

			internal SynchIntAdd(IntAdd parent){
				_parent = parent;
				_root = parent.SyncRoot;
			}

			public override int Data {
				get {
					int ret;
					System.Threading.Monitor.Enter(_root);
					try{
						ret = _parent.Data;
					}
					finally{System.Threading.Monitor.Exit(_root);}
					return ret;
				}
				set {
					System.Threading.Monitor.Enter(_root);
					try{
						_parent.Data = value;
					}
					finally{System.Threading.Monitor.Exit(_root);}
				}
			}

			public override bool IsSynchronized {
				get {
					return true;
				}
			}

		}
	}

	public class IntAddSynch{
		private int data;
		public virtual int Data{
			get{
				int ret;
				lock(this){
					ret = data;
				}
				return ret;
			}
			set{
				lock(this){
					data = value;
				}
			}
		}
	}


	public class AddInSynch {
		//TEST 10.02
		[Benchmark("Compares performance of synchronized wrapper to non-sync case")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 10000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			//testCases += new TestRunner.TestCase(AddInSynch.NoLock);
			testCases += new TestRunner.TestCase(AddInSynch.Synch);
			testCases += new TestRunner.TestCase(AddInSynch.PreSynch);
			
			return tr.RunTests(testCases);
		}

		public static void NoLock(int NumberIterations){
			IntAdd ia = new IntAdd();
			for(int i = 0; i < NumberIterations; ++i){
				++ia.Data;
			}
		}

		public static void PreSynch(int NumberIterations){
			IntAddSynch ia = new IntAddSynch();
			for(int i = 0; i < NumberIterations; ++i){
				++ia.Data;
			}
		}

		public static void Synch(int NumberIterations){
			IntAdd ia = new IntAdd();
			ia = IntAdd.Synchronized(ia);
			for(int i = 0; i < NumberIterations; ++i){
				++ia.Data;
			}
		}
	}
}
