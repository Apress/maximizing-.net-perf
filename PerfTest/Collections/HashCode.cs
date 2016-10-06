using System;
using System.Windows.Forms;
using DotNetPerformance;

namespace PerfTest.Collections {
	public class PoorHC: System.Collections.IHashCodeProvider{
		public int GetHashCode(object x){
			return x.GetHashCode()%100;
		}
	}

	public class VeryPoorHC: System.Collections.IHashCodeProvider{
		public int GetHashCode(object x){
			return 1;
		}
	}

	public class HashCode {
		string[] data;
		//TEST 05.19
		[Benchmark("Compares effect of hash code distribution on HashTable performance.")]
		public TestResultGrp RunTest() {	
			PopulateTestData();
			const int numberIterations = 50000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.PoorHashCode);
			testCases += new TestRunner.TestCase(this.ConstantHashCode);
			testCases += new TestRunner.TestCase(this.DefaultHashcode);
			
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
				data = s.Split(sep, 100000000);
			}
		}
		
		public void PoorHashCode(Int32 NumberIterations){
			System.Collections.Hashtable ht =  new System.Collections.Hashtable(new PoorHC(), null);
			foreach(string s in data){
				ht[s] = 1;
			}
		}

		public void ConstantHashCode(Int32 NumberIterations){
			System.Collections.Hashtable ht =  new System.Collections.Hashtable(new VeryPoorHC(), null);
			foreach(string s in data){
				ht[s] = 1;
			}
		}

		public void DefaultHashcode(Int32 NumberIterations){
			System.Collections.Hashtable ht =  new System.Collections.Hashtable();
			foreach(string s in data){
				ht[s] = 1;
			}
		}

	}
}
