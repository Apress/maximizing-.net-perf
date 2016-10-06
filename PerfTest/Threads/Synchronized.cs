using System;
using System.Collections;
using System.Runtime.CompilerServices;
using DotNetPerformance;
using System.Runtime.Remoting.Contexts;

namespace PerfTest.Threads
{
	public class CompilerSync{
		ArrayList _data;
		public CompilerSync(ArrayList data){
			_data = data;
		}

		public object this[int element] {
			[MethodImpl(MethodImplOptions.Synchronized)]
			get {
				return _data[element];
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set {
				_data[element] = value;
			}
		}
	}

	[Synchronization()]
	public class Wrapper: ContextBoundObject{
		ArrayList _data;
		public Wrapper(ArrayList data){
			_data = data;
		}

		public object this[int element] {
			get {
				return _data[element];
			}
			set {
				_data[element] = value;
			}
		}
	}

	public class UnsynchronizedWrapper: ContextBoundObject{
		ArrayList _data;
		public UnsynchronizedWrapper(ArrayList data){
			_data = data;
		}

		public object this[int element] {
			get {
				return _data[element];
			}
			set {
				_data[element] = value;
			}
		}
	}
	public class Synchronized
	{
		ArrayList data;

		//TEST 10.01
		[Benchmark("Compares various forms of thread safety implementation.")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 1000000;
			const int numberTestRuns = 5;
			PopulateTestData(numberIterations);
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.ExplicitLockPerLoop);
			testCases += new TestRunner.TestCase(this.ExplicitLock);
			testCases += new TestRunner.TestCase(this.SynchronizedAL);
			testCases += new TestRunner.TestCase(this.ContextWrapper);
		    testCases += new TestRunner.TestCase(this.ContextWrapperNoSynch);
			testCases += new TestRunner.TestCase(this.MethodImplAttributeAL);
			testCases += new TestRunner.TestCase(this.NoSynch);
			
			return tr.RunTests(testCases);
		}

		void PopulateTestData(int NumberIterations){
			data = new ArrayList();
			for(int i = 0; i < NumberIterations; ++i){
				data.Add(i);
			}
		}

		public void NoSynch(int NumberIterations){
			for(int i = 0; i < NumberIterations; ++i){
				data[i] = (int)data[i] + 1;
			}
		}

		public void ContextWrapper(int NumberIterations){
			Wrapper synch = new Wrapper(data);
			for(int i = 0; i < NumberIterations; ++i){
				synch[i] = (int)synch[i] + 1;
			}
		}

		public void ContextWrapperNoSynch(int NumberIterations){
			UnsynchronizedWrapper synch = new UnsynchronizedWrapper(data);
			for(int i = 0; i < NumberIterations; ++i){
				synch[i] = (int)synch[i] + 1;
			}
		}

		public void ExplicitLockPerLoop(int NumberIterations){
			for(int i = 0; i < NumberIterations; ++i){
				System.Threading.Monitor.Enter(data);
				try{
					data[i] = (int)data[i] + 1;
				}
				finally{
					System.Threading.Monitor.Exit(data);
				}
			}
		}

		public void ExplicitLock(int NumberIterations){
			System.Threading.Monitor.Enter(data);
			try{
				for(int i = 0; i < NumberIterations; ++i){
					data[i] = (int)data[i] + 1;
				}
			}
			finally{
				System.Threading.Monitor.Exit(data);
			}
		}

		public void SynchronizedAL(int NumberIterations){
			ArrayList synch = ArrayList.Synchronized(data);
			for(int i = 0; i < NumberIterations; ++i){
				synch[i] = (int)synch[i] + 1;
			}
		}

		public void  MethodImplAttributeAL(int NumberIterations){
			CompilerSync synch = new CompilerSync(data);
			for(int i = 0; i < NumberIterations; ++i){
				synch[i] = (int)synch[i] + 1;
			}
		}
	}
}
