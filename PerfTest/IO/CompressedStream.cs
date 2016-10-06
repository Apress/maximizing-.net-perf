using System;
using System.Windows.Forms;
using System.IO;
using DotNetPerformance;

namespace PerfTest.IO {
	public class CompressedStream {
		private byte[] _data = null;
		private string _fileName;
		public TestResultGrp WriteTest() {	
			const int numberIterations = 1;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestGroup tgComp = new TestGroup(new TestRunner.TestCase(CompressedWrite), new TestRunner.TestCleanup(ReadInit),
				new TestRunner.TestCleanup(WriteCleanUp), new TestRunner.TestValidity(TestRunner.TestOK));
			TestGroup tgUnComp = new TestGroup(new TestRunner.TestCase(UncompressedWrite), new TestRunner.TestCleanup(ReadInit),
				new TestRunner.TestCleanup(WriteCleanUp), new TestRunner.TestValidity(TestRunner.TestOK));
			tr.AddTestGroup(tgComp);
			tr.AddTestGroup(tgUnComp);
			
			return tr.RunTests(null);
		}

		[Benchmark("Compares custom CompressStream type to normal FileStream")]
		public TestResultGrp ReadTest() {	
			const int numberIterations = 1;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestGroup tgComp = new TestGroup(new TestRunner.TestCase(CompressedRead), new TestRunner.TestCleanup(ReadInit),
				new TestRunner.TestCleanup(TestRunner.NoOp), new TestRunner.TestValidity(TestRunner.TestOK));
			TestGroup tgUnComp = new TestGroup(new TestRunner.TestCase(UncompressedRead), new TestRunner.TestCleanup(ReadInit),
				new TestRunner.TestCleanup(TestRunner.NoOp), new TestRunner.TestValidity(TestRunner.TestOK));
			tr.AddTestGroup(tgComp);
			tr.AddTestGroup(tgUnComp);
			
			TestResultGrp ret = tr.RunTests(null);
			File.Delete(_fileName + ".cmp");
			return ret;
		}

		public void ReadInit(){
			if (_data == null){
				WriteInit();
				FileStream write = new FileStream(_fileName + ".cmp", FileMode.Create, FileAccess.Write, FileShare.None);
				DotNetPerformance.IO.CompressedStream cs = new DotNetPerformance.IO.CompressedStream(write);
				cs.Write(_data, 0, _data.Length);
				cs.Close();
			}
		}

		public void WriteInit(){
			if (_data == null){
				OpenFileDialog openFile = new OpenFileDialog();
				openFile.Title = "Select a file to compress";
				if (openFile.ShowDialog() == DialogResult.OK){
					_fileName = openFile.FileName;
					using (FileStream sr = new FileStream(openFile.FileName,
							   FileMode.Open, FileAccess.Read, FileShare.Read)){
						_data = new byte[new System.IO.FileInfo(openFile.FileName).Length];
						sr.Read(_data, 0, _data.Length);
					}
				}
			}
		}

		public void WriteCleanUp(){
			File.Delete(@"c:\comp_test.tst1");
			File.Delete(@"c:\comp_test.tst2");
		}

		public void UncompressedWrite(Int32 numberIterations) {	
			FileStream write = new FileStream(@"c:\comp_test.tst1", FileMode.Create, FileAccess.Write, FileShare.None);
			write.Write(_data, 0, _data.Length);
			write.Close();
		}
		public void CompressedWrite(Int32 numberIterations) {	
			FileStream write = new FileStream(@"c:\comp_test.tst2", FileMode.Create, FileAccess.Write, FileShare.None);
			DotNetPerformance.IO.CompressedStream cs = new DotNetPerformance.IO.CompressedStream(write);
			cs.Write(_data, 0, _data.Length);
			cs.Close();
		}

		public void UncompressedRead(Int32 numberIterations) {	
			FileStream read = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.None);

			const int buffSize = 1000;
			int lengthRead = 0;
			byte[] buff = new byte[buffSize];
			do{
				lengthRead = read.Read(buff, 0, buff.Length);
			}while (lengthRead == buffSize);

			read.Close();
		}
		public void CompressedRead(Int32 numberIterations) {	
			FileStream read = new FileStream(_fileName + ".cmp", FileMode.Open, FileAccess.Read, FileShare.None);
			DotNetPerformance.IO.CompressedStream cs = new DotNetPerformance.IO.CompressedStream(read);

			const int buffSize = 1000;
			int lengthRead = 0;
			byte[] buff = new byte[buffSize];
			do{
				lengthRead = cs.Read(buff, 0, buff.Length);
			}while (lengthRead == buffSize);

			cs.Close();
		}
	}
}
