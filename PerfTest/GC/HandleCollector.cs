using System;
using DotNetPerformance;

namespace PerfTest.GC {
	public class HandleCollector {
		private static System.IO.MemoryStream ms;
		public static void InitialiseStream(){
			string fileName = @"C:\WINSERV\Cursors\size4_rm.cur";
			byte[] data = new byte[new System.IO.FileInfo(fileName).Length];
			System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
			fs.Read(data, 0, data.Length);
			ms = new System.IO.MemoryStream(data);
		}

		[Benchmark("Compares handle collector pattern to explicit clean-up")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 10000;
			const int numberTestRuns = 2;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);

			TestGroup tgDisposed = new TestGroup(new TestRunner.TestCase(HandleCollector.Disposed),
				new TestRunner.TestCleanup(HandleCollector.InitialiseStream), new TestRunner.TestCleanup(TestRunner.NoOp),
				new TestRunner.TestValidity(TestRunner.TestOK));
			tr.AddTestGroup(tgDisposed);

			TestGroup tgCollected = new TestGroup(new TestRunner.TestCase(HandleCollector.Collected),
				new TestRunner.TestCleanup(HandleCollector.InitialiseStream), new TestRunner.TestCleanup(TestRunner.NoOp),
				new TestRunner.TestValidity(TestRunner.TestOK));
			tr.AddTestGroup(tgCollected);
			
			return tr.RunTests(null);
		}

		public static void Disposed(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				System.Windows.Forms.Cursor cu = new System.Windows.Forms.Cursor(ms);
				cu.Dispose();
				ms.Position = 0;
			}
		}
		public static void Collected(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				System.Windows.Forms.Cursor cu = new System.Windows.Forms.Cursor(ms);
				ms.Position = 0;
			}
		}
	}
}
