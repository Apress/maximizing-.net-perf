using System;
using System.Reflection;
using DotNetPerformance;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PerfTest.CLR {

	public class JIT {
		string _exePath;
		public JIT(){
			_exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
			_exePath = new System.IO.FileInfo(_exePath).DirectoryName;
		}

		//TEST 14.02
		[Benchmark("Looks at performance benefit of NGEN.")]
		public TestResultGrp RunTest() {	
			System.Windows.Forms.MessageBox.Show("Make sure the Scribble version in the NGEN directory has NGEN run against it.");
			const int numberIterations = 1;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(NGEN);
			testCases += new TestRunner.TestCase(JITed);

			return tr.RunTests(testCases);
		}

		public void NGEN(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				Process p = Process.Start(_exePath + "\\NGEN\\Scribble.exe");
				p.WaitForInputIdle();  //wait for app to be up and running
			}
		}

		public void JITed(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				Process p = Process.Start(_exePath + "\\JIT\\Scribble.exe");
				p.WaitForInputIdle();

			}
		}
	}
}
