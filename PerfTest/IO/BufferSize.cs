using System;
using System.IO;
using System.Windows.Forms;
using DotNetPerformance;

namespace PerfTest.IO {
	public class BufferSizeTest {
		private string _fileName;

		//TEST 11.01
		[Benchmark("Compares buufer size parameter for reading a file from disk")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 1;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Default);
			testCases += new TestRunner.TestCase(_8k);
			testCases += new TestRunner.TestCase(_16k);
			testCases += new TestRunner.TestCase(_32k);
			testCases += new TestRunner.TestCase(_64k);

			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" ;
			ofd.FilterIndex = 2 ;

			if(ofd.ShowDialog() == DialogResult.OK) {
				_fileName = ofd.FileName;
			}

			
			return tr.RunTests(testCases);
		}

		public void Default(Int32 numberIterations){
			FileStream fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 4096);
			byte[] buff = new byte[new FileInfo(_fileName).Length];
			fs.Read(buff, 0, buff.Length);
		}

		public void _8k(Int32 numberIterations){
			FileStream fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 8192);
			byte[] buff = new byte[new FileInfo(_fileName).Length];
			fs.Read(buff, 0, buff.Length);
		}

		public void _16k(Int32 numberIterations){
			FileStream fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 16384);
			byte[] buff = new byte[new FileInfo(_fileName).Length];
			fs.Read(buff, 0, buff.Length);
		}

		public void _32k(Int32 numberIterations){
			FileStream fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 32768);
			byte[] buff = new byte[new FileInfo(_fileName).Length];
			fs.Read(buff, 0, buff.Length);
		}

		public void _64k(Int32 numberIterations){
			FileStream fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 65536);
			byte[] buff = new byte[new FileInfo(_fileName).Length];
			fs.Read(buff, 0, buff.Length);
		}
	}
}
