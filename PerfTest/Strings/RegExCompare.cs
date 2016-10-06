using System;
using System.IO;
using System.Text.RegularExpressions;
using DotNetPerformance;
using System.Windows.Forms;

namespace PerfTest.Strings {
	public class RegExCompare {
		private string _data, _A, _B;

		public RegExCompare(string RegExA, string RegExB){
			_A = RegExA;
			_B = RegExB;
			OpenFileDialog openFile = new OpenFileDialog();
			openFile.Title = "Select a text file";
			openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" ;
			if (openFile.ShowDialog() == DialogResult.OK){
				using (StreamReader sr = new StreamReader(openFile.FileName, System.Text.Encoding.ASCII)){
					_data = sr.ReadToEnd();
				}
			}
		}

		//TEST 04.13
		[Benchmark("Allows users to compare 2 regex expressions from the UI.")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 1;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(A);
			testCases += new TestRunner.TestCase(B);

			return tr.RunTests(testCases);
		}

		public void A(Int32 numberIterations) {
			Regex regex = new Regex(_A);
			int ix = regex.Matches(_data).Count;
		}
		public void B(Int32 numberIterations) {
			Regex regex = new Regex(_B);
			int ix = regex.Matches(_data).Count;
		}
	}
}