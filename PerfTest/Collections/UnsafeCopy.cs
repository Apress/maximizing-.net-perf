using System;
using DotNetPerformance;

namespace PerfTest.Collections {
	public class UnsafeCopy {

		private byte[] _data;

		//TEST 05.06
		[Benchmark("Looks at 'optimized' byte array copy code from MSDN Library compared to Array.Copy")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 50000000;
			const int numberTestRuns = 5;
			PopulateTestData(numberIterations);
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.SafeCopy);
			testCases += new TestRunner.TestCase(this.UnsafeDataCopy);
			testCases += new TestRunner.TestCase(this.ArrayCopy);
			
			return tr.RunTests(testCases);
		}

		void PopulateTestData(int NumberIterations){
			_data = new byte[NumberIterations];
		}

		public void ArrayCopy(Int32 NumberIterations){
			byte[] dataCopy = new byte[_data.Length];
			_data.CopyTo(dataCopy, 0);
		}

		public void SafeCopy(Int32 NumberIterations){
			byte[] dataCopy = new byte[_data.Length];
			int maxCnt = _data.Length;
			for (int i = 0; i < maxCnt; ++i)
				dataCopy[i] = _data[i];
		}

		unsafe public void UnsafeDataCopy(Int32 NumberIterations){
			byte[] dataCopy = new byte[_data.Length];
			Copy(_data, 0, dataCopy, 0, _data.Length);
		}

		static unsafe void Copy(byte[] src, int srcIndex,
			byte[] dst, int dstIndex, int count) {  //MSDN sample app
			if (src == null || srcIndex < 0 ||
				dst == null || dstIndex < 0 || count < 0) {
				throw new ArgumentException();
			}
			int srcLen = src.Length;
			int dstLen = dst.Length;
			if (srcLen - srcIndex < count ||
				dstLen - dstIndex < count) {
				throw new ArgumentException();
			}
			// The following fixed statement pins the location of
			// the src and dst objects in memory so that they will
			// not be moved by garbage collection.
			fixed (byte* pSrc = src, pDst = dst) {
				byte* ps = pSrc;
				byte* pd = pDst;
				// Loop over the count in blocks of 4 bytes, copying an
				// integer (4 bytes) at a time:
				for (int n = count >> 2; n != 0; n--) {
					*((int*)pd) = *((int*)ps);
					pd += 4;
					ps += 4;
				}
				// Complete the copy by moving any bytes that weren't
				// moved in blocks of 4:
				for (count &= 3; count != 0; count--) {
					*pd = *ps;
					pd++;
					ps++;
				}
			}
		}
	}
}
