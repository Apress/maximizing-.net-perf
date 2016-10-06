using System;
using System.IO;
using System.Text.RegularExpressions;
using DotNetPerformance;
using System.Windows.Forms;

namespace PerfTest.Strings {
	public class RegExCase {
		private string _data;

		public RegExCase(){
			OpenFileDialog openFile = new OpenFileDialog();
			openFile.Title = "Select a text file";
			openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" ;
			if (openFile.ShowDialog() == DialogResult.OK){
				using (StreamReader sr = new StreamReader(openFile.FileName, System.Text.Encoding.ASCII)){
					_data = sr.ReadToEnd();
				}
			}
		}

		//TEST 04.12
		[Benchmark("Looks at regex case insensitive test options.")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 1;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(CaseSensitive);
			testCases += new TestRunner.TestCase(CaseSensitiveToUpper);
			testCases += new TestRunner.TestCase(CaseInsensitive);

			return tr.RunTests(testCases);
		}

		public void CaseSensitive(Int32 numberIterations) {
			Regex regex = new Regex(@"(?<a>\w)\k<a>");
			int ix = regex.Matches(_data).Count;
		}

		public void CaseSensitiveToUpper(Int32 numberIterations) {
			Regex regex = new Regex(@"(?<a>\w)\k<a>");
			int ix = regex.Matches(_data.ToUpper()).Count;
		}

		public void CaseInsensitive(Int32 numberIterations) {
			Regex regex = new Regex(@"(?<a>\w)\k<a>", RegexOptions.IgnoreCase);
			int ix = regex.Matches(_data).Count;
		}
	}
}
