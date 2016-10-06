using System;
using DotNetPerformance;

namespace PerfTest.GC {
	public class NoFinalize{}
	public class HandRolled: System.IDisposable {
		private bool _cleanup = false;
		public void Dispose(){_cleanup = true;} 
		~HandRolled(){if (!_cleanup){;}}
	}
	public class FinalizeImpl: IDisposable {
		public void Dispose(){System.GC.SuppressFinalize(this);} 
		~FinalizeImpl(){}
	}

	public class FinalizeTest {
		//TEST 07.01
		[Benchmark("Looks at effect of having a finalize method on a type, with and without a call to SuppressFinalize")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 1000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(FinalizeTest.NoFinalize);
			testCases += new TestRunner.TestCase(FinalizeTest.HandRolled);
			testCases += new TestRunner.TestCase(FinalizeTest.HandRolledDispose);
			testCases += new TestRunner.TestCase(FinalizeTest.FinalizeImpl);
			testCases += new TestRunner.TestCase(FinalizeTest.FinalizeImplDisposed);
			
			return tr.RunTests(testCases);
		}

		public static void NoFinalize(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				NoFinalize n = new NoFinalize();
			}
			System.GC.Collect();
			System.GC.WaitForPendingFinalizers();
		}
		public static void HandRolled(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				HandRolled n = new HandRolled();
			}
			System.GC.Collect();
			System.GC.WaitForPendingFinalizers();
		}
		public static void HandRolledDispose(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				HandRolled n = new HandRolled();
				n.Dispose();
			}
			System.GC.Collect();
			System.GC.WaitForPendingFinalizers();
		}
		public static void FinalizeImpl(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				FinalizeImpl n = new FinalizeImpl();
			}
			System.GC.Collect();
			System.GC.WaitForPendingFinalizers();
		}
		public static void FinalizeImplDisposed(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				FinalizeImpl n = new FinalizeImpl();
				n.Dispose();
			}
			System.GC.Collect();
			System.GC.WaitForPendingFinalizers();
		}
	}
}
