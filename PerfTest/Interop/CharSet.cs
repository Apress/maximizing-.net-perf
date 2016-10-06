using System;
using System.Text;
using DotNetPerformance;
using System.Runtime.InteropServices;

namespace PerfTest.Interop {
	public class CharSetTest {
		[DllImport("InteropDllTest.dll", CharSet=CharSet.Unicode, EntryPoint="CharacterSetTest")] 
		public static extern int CharacterSetTestUni(string s);
		[DllImport("InteropDllTest.dll", EntryPoint="CharacterSetTest")] 
		public static extern int CharacterSetTestAnsi(string s);

		[DllImport("kernel32.dll")]
		static extern int lstrlen(string s);
		[DllImport("kernel32.dll", CharSet=CharSet.Unicode, EntryPoint="lstrlen")]
		static extern int lstrlenw(string s);
		[DllImport("kernel32.dll", CharSet=CharSet.Auto, EntryPoint="lstrlen")]
		static extern int lstrlenAuto(string s);


		static readonly string s = "0123456789";

		[Benchmark("Compares effect of various CharSet settings on PInvoke calls")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 100000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Ansi);
			testCases += new TestRunner.TestCase(Unicode);

			return tr.RunTests(testCases);
		}

		//TEST 13.05
		public TestResultGrp RunTestStringLength() {	
			const int numberIterations = 1000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(StringLengthAnsi);
			testCases += new TestRunner.TestCase(StringLengthUni);
			testCases += new TestRunner.TestCase(StringLengthAuto);

			return tr.RunTests(testCases);
		}

		public void StringLengthAnsi(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				lstrlen(s);
			}
		}

		public void StringLengthAuto(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				lstrlenAuto(s);
			}
		}

		public void StringLengthUni(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				lstrlenw(s);
			}
		}

		public void Ansi(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				int j = CharacterSetTestAnsi(s);
			}
		}

		public void Unicode(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				int j = CharacterSetTestUni(s);
			}
		}
	}
}
