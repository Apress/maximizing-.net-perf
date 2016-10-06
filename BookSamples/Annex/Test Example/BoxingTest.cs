using System;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DotNetPerformance;

namespace Test_Example
{
	public class BoxingTest
	{
		string _testDoc =String.Empty;
		StringReader _stream;
		const string regexString = @"[\s\,\.\?\!'""\(\)\;\:]+";
		
		[Benchmark("Assesses techniques for avoiding boxing hits in collections")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 1;
			const int numberTestRuns = 3;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			tr.AddTestGroup(new TestGroup(new TestRunner.TestCase(BoxedInt), 
				new TestRunner.TestCleanup(LoadDocument), new TestRunner.TestCleanup(TestRunner.NoOp),
				new TestRunner.TestValidity(TestRunner.TestOK)));
			tr.AddTestGroup(new TestGroup(new TestRunner.TestCase(IntHolder), 
				new TestRunner.TestCleanup(LoadDocument), new TestRunner.TestCleanup(TestRunner.NoOp),
				new TestRunner.TestValidity(TestRunner.TestOK)));
			tr.AddTestGroup(new TestGroup(new TestRunner.TestCase(Interface), 
				new TestRunner.TestCleanup(LoadDocument), new TestRunner.TestCleanup(TestRunner.NoOp),
				new TestRunner.TestValidity(TestRunner.TestOK)));
			return tr.RunTests(null);
		}

		public void LoadDocument(){
			if (_testDoc == String.Empty){
				OpenFileDialog openFile = new OpenFileDialog();
				openFile.Title = "Select a text file to preform a word count on";
				if (openFile.ShowDialog() == DialogResult.OK){
					using (System.IO.StreamReader sr = new System.IO.StreamReader(openFile.FileName)){
						_testDoc = sr.ReadToEnd();
					}
				}
			}
			_stream = new StringReader(_testDoc);
		}

		public void BoxedInt(Int32 NumberIterations){
			using (_stream){
				Regex regexSplit = new Regex(regexString);
				string line = null;
				Hashtable wordTable = new Hashtable();
				int wordCount = 0;
				while ((line = _stream.ReadLine()) != null) {
					foreach (string word in regexSplit.Split(line.ToLower())) {
						wordCount++;
						object value = wordTable[word];
						int count = 0;
						if (value != null)
							count = (int) value;
						wordTable[word] = count + 1;
					}
				}
			}
		}

		public void IntHolder(Int32 NumberIterations){
			using (_stream){
				Regex regexSplit = new Regex(regexString);
				string line = null;
				Hashtable wordTable = new Hashtable();
				DateTime startTime = DateTime.Now;
				int wordCount = 0;
				while ((line = _stream.ReadLine()) != null) {
					foreach (string word in regexSplit.Split(line.ToLower())) {
						wordCount++;
						IntHolderClass value = (IntHolderClass) wordTable[word];
						if (value == null) {
							wordTable[word] = new IntHolderClass();
						}
						else
							value.Count++;
					}
				}
			}
		}

		public void Interface(Int32 NumberIterations){
			using (_stream){
				Regex regexSplit = new Regex(regexString);
				string line = null;
				Hashtable wordTable = new Hashtable();
				DateTime startTime = DateTime.Now;
				int wordCount = 0;
				while ((line = _stream.ReadLine()) != null) {
					foreach (string word in regexSplit.Split(line.ToLower())) {
						wordCount++;
						object value = wordTable[word];
						if (value == null) {
							value = new IntHolderStruct(1);
							wordTable[word] = value;
						}
						else
							((IIncrement) value).Increment();
					}
				}
			}
		}
	}


	interface IIncrement {
		void Increment();
	}

	struct IntHolderStruct: IIncrement {
		int value;

		public IntHolderStruct(int value) {
			this.value = value;
		}
		public int Value {
			get {
				return(value);
			}
		}

		public void Increment() {
			value++;
		}

		public override string ToString() {
			return(value.ToString());
		}
	}

	class IntHolderClass {
		int count;

		public IntHolderClass() {
			count = 1;
		}

		public int Count {
			get {
				return(count);
			}
			set {
				count = value;
			}
		}

		public override string ToString() {
			return(count.ToString());
		}
	}
}
