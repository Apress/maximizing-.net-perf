using System;
using System.Windows.Forms;
using DotNetPerformance;

namespace PerfTest.Collections {
	public class Enumeration {
		string[] data;
		System.Collections.ArrayList al;
		//TEST 05.14
		[Benchmark("Compares various collection enumeration techniques.")]
		public TestResultGrp RunTest() {	
			PopulateTestData();
			const int numberIterations = 50000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.Enum);
			testCases += new TestRunner.TestCase(this.For);
			testCases += new TestRunner.TestCase(this.ForLengthRemoved);
			
			return tr.RunTests(testCases);
		}

		//TEST 05.15
		public TestResultGrp ArrayListTest() {	
			PopulateTestData();
			const int numberIterations = 1;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.EnumAL);
			testCases += new TestRunner.TestCase(this.ForAL);
			
			return tr.RunTests(testCases);
		}

		void PopulateTestData(){
			OpenFileDialog openFile = new OpenFileDialog();
			openFile.Title = "Select a text file to preform a word count on";
			if (openFile.ShowDialog() == DialogResult.OK){
				string s;
				using (System.IO.StreamReader sr = new System.IO.StreamReader(openFile.FileName)){
					s = sr.ReadToEnd();
				}
				char[] sep = {' '};
				data = s.Split(sep); 
				al = new System.Collections.ArrayList();
				al.AddRange(data);
			}
		}
		
		public void Enum(Int32 NumberIterations){
			int cnt = 0;
			foreach(string s in data){
				cnt += s.Length;
			}
		}

		public void For(Int32 NumberIterations){
			int cnt = 0;
			for(int i = 0; i < data.Length; ++i)
				cnt += data[i].Length;
		}

		public void ForLengthRemoved(Int32 NumberIterations){
			int cnt = 0;
			int length = data.Length;
			for(int i = 0; i < length; ++i)
				cnt += data[i].Length;
		}

		public void EnumAL(Int32 NumberIterations){
			int cnt = 0;
			foreach(string s in al){
				cnt += s.Length;
			}
		}

		public void ForAL(Int32 NumberIterations){
			int cnt = 0;
			int size = al.Count;
			for(int i = 0; i < size; ++i){
				string s = (string)(al[i]);
				cnt += s.Length;
			}
		}
	}
}
