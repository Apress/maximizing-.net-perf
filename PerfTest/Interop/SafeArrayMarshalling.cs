using System;
using DotNetPerformance;
using InteropSafeArray;
using System.Runtime.InteropServices;

namespace PerfTest.Interop {
	public class SafeArrayMarshalling {
		CArrayDataTransport _dataTransport = new InteropSafeArray.CArrayDataTransportClass();
		long _count = 0;

		[Benchmark("Compares SAFEARRAY to c-style array for COM calls")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 10000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(SafeArray);
			testCases += new TestRunner.TestCase(CStyle);
			//testCases += new TestRunner.TestCase(NullCase);

			return tr.RunTests(testCases);
		}

		public void SafeArray(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				Array a = (Array)_dataTransport.SafeArray();
				for (int ix = 0; ix < a.GetUpperBound(0); ++ix)
					_count = (int)a.GetValue(ix);
			}
		}

		public void NullCase(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				bool res = _dataTransport.NoArray();
			}
		}

		unsafe public void CStyle(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				int size;
				int* pData = (int*)_dataTransport.CStyle(out size);
				for (int ix = 0; ix < size; ++ix)
					_count = pData[ix];
				Marshal.FreeCoTaskMem((IntPtr)pData);
			}
		}
	}
}
