using System;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using DotNetPerformance;

namespace PerfTest.Strings {
	public class CultureInfoCompare {
		string[] _words;

		public CultureInfoCompare(){
			OpenFileDialog openFile = new OpenFileDialog();
			openFile.Title = "Select a text file";
			openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" ;
			if (openFile.ShowDialog() == DialogResult.OK){
				using (StreamReader sr = new StreamReader(openFile.FileName, System.Text.Encoding.ASCII)){
					string data = sr.ReadToEnd();
					_words = data.Split(' ');
				}
			}
		}

		//TEST 04.02
		[Benchmark("Compares Compare performance for US English and traditional Spanish")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 1;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(USEnglish);
			testCases += new TestRunner.TestCase(TraditonalSpanish);

			return tr.RunTests(testCases);
		}

		public void TraditonalSpanish(Int32 numberIterations) {
			int res = 0;
			CultureInfo tradSpain = new CultureInfo( 0x040A, false );
			for (int i = 0;i < _words.Length-1 ;++i) {
				res = String.Compare(_words[i], _words[i+1], false, tradSpain);
			}
		}

		public void USEnglish(Int32 numberIterations) {
			int res = 0;
			CultureInfo usEng = new CultureInfo( "en-US", false );
			for (int i = 0;i < _words.Length-1 ;++i) {
				res = String.Compare(_words[i], _words[i+1], false, usEng);
			}
		}
	}
}
