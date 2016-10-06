using System;
using System.IO;
using System.Text.RegularExpressions;
using DotNetPerformance;
using System.Windows.Forms;

namespace PerfTest.Strings {
	public class RegExCompiled {
		private string _data;

		public RegExCompiled(){
			OpenFileDialog openFile = new OpenFileDialog();
			openFile.Title = "Select a text file";
			openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" ;
			if (openFile.ShowDialog() == DialogResult.OK){
				using (StreamReader sr = new StreamReader(openFile.FileName, System.Text.Encoding.ASCII)){
					_data = sr.ReadToEnd();
				}
			}
		}

		//TEST 04.11
		[Benchmark("Compares compiled and interpretted regex options")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 1;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Interpretted);
			testCases += new TestRunner.TestCase(Compiled);

			return tr.RunTests(testCases);
		}

		public void Interpretted(Int32 numberIterations) {
			Regex regex = new Regex(@"(?<a>\w)\k<a>");
			int ix = regex.Matches(_data).Count;
		}
		public void Compiled(Int32 numberIterations) {
			Regex regex = new Regex(@"(?<a>\w)\k<a>", RegexOptions.Compiled);
			int ix = regex.Matches(_data).Count;
		}
	}
}
