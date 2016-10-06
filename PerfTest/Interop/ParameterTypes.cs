using System;
using DotNetPerformance;
using System.Text;
using System.Runtime.InteropServices;

namespace PerfTest.Interop {
	public class ParameterTypesTest {
		[DllImport("InteropDllTest.dll")] public static extern int ZeroParams();
		[DllImport("InteropDllTest.dll")] public static extern int OneBlittableParam(int i);
		[DllImport("InteropDllTest.dll", CharSet=CharSet.Unicode)] 
		public static extern int ConstantStringParam(string s);
		[DllImport("InteropDllTest.dll", CharSet=CharSet.Ansi)] 
		public static extern int ConstantStringParamAnsi(string s);
		[DllImport("InteropDllTest.dll", CharSet=CharSet.Unicode)] 
		public static extern int ChangeableStringParam(StringBuilder s, int length);
		[DllImport("InteropDllTest.dll", CharSet=CharSet.Unicode, EntryPoint="ChangeableStringParam")] 
		public static extern unsafe int ChangeableStringParamStackParam(byte* b, int length);
		[DllImport("InteropDllTest.dll")] public static extern int ConstArray([In] int[] data, int length);
		[DllImport("InteropDllTest.dll")] public static extern int ChangeableArray([In, Out]int[] data, int length);

		//TEST 13.01
		[Benchmark("Compares perf of various paramters passed to a PInvoke method.  See InteropDllTest solution for C DLL source.")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 1000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(ZeroParamsTest);
			testCases += new TestRunner.TestCase(OneBlittableParamTest);
			testCases += new TestRunner.TestCase(ConstantStringParamUnicodeTest);
			testCases += new TestRunner.TestCase(ConstantStringParamAnsiTest);
			testCases += new TestRunner.TestCase(ChangeableStringParamTest);
			testCases += new TestRunner.TestCase(ConstArrayTest);
			testCases += new TestRunner.TestCase(ChangeableArrayTest);

			return tr.RunTests(testCases);
		}

		//TEST 13.03
		[Benchmark("Compares perf of various techniques for converting raw bytes to managed strings")]
		public TestResultGrp RunTestParamDec() {	
			const int numberIterations = 500000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(StringBuilder);
			testCases += new TestRunner.TestCase(ByteArraySystemTextEncoding);
			testCases += new TestRunner.TestCase(ByteArrayPtrToString);
			testCases += new TestRunner.TestCase(ByteArrayPtrToStringNoSizeParam);

			return tr.RunTests(testCases);
		}

		//TEST 13.04
		[Benchmark("Compares perf of various techniques for converting raw bytes to managed strings")]
		public TestResultGrp RunTestParamDecBi() {	
			const int numberIterations = 500000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(StringBuilderBi);
			testCases += new TestRunner.TestCase(ByteArrayPtrToStringBi);

			return tr.RunTests(testCases);
		}

		public void ZeroParamsTest(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				int j = ZeroParams();
			}
		}

		public void OneBlittableParamTest(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				int j = OneBlittableParam(i);
			}
		}

		public void ConstantStringParamUnicodeTest(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				int j = ConstantStringParam("abc");
			}
		}

		public void ConstantStringParamAnsiTest(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				int j = ConstantStringParamAnsi("abc");
			}
		}

		public void ChangeableStringParamTest(Int32 numberIterations){
			StringBuilder sb = new StringBuilder(3);
			sb.Append("abc");
			for (int i = 0; i < numberIterations; ++i){
				int j = ChangeableStringParam(sb, 3);
			}
		}

		public void ConstArrayTest(Int32 numberIterations){
			int[] arr = new int[]{1,2,3};
			for (int i = 0; i < numberIterations; ++i){
				int j = ConstArray(arr, arr.Length);
			}
		}

		public void ChangeableArrayTest(Int32 numberIterations){
			int[] arr = new int[]{1,2,3};
			for (int i = 0; i < numberIterations; ++i){
				int j = ChangeableArray(arr, arr.Length);
			}
		}

		public void StringBuilder(Int32 numberIterations){
			const int bufferSize = 4;
			StringBuilder sb = new StringBuilder(bufferSize);
			
			for (int i = 0; i < numberIterations; ++i){
				int j = ChangeableStringParam(sb, bufferSize);
				string s = sb.ToString();
			}
		}

		public void StringBuilderBi(Int32 numberIterations){
			const int bufferSize = 4;
			StringBuilder sb = new StringBuilder(bufferSize);
			
			for (int i = 0; i < numberIterations; ++i){
				sb.Remove(0, sb.Length);
				sb.Append("abcd");
				int j = ChangeableStringParam(sb, bufferSize);
				string s = sb.ToString();
			}
		}

		public unsafe void ByteArraySystemTextEncoding(Int32 numberIterations){
			System.Text.UnicodeEncoding ue = new System.Text.UnicodeEncoding();
			const int arraySize = 8;
			byte* b = stackalloc byte[arraySize];
			for (int i = 0; i < numberIterations; ++i){
				int k = ChangeableStringParamStackParam(b, arraySize/2);
				
				byte[] outBytes = new byte[arraySize];
				Marshal.Copy(new IntPtr(b), outBytes, 0, arraySize);

				string s = ue.GetString(outBytes);
			}
		}

		public unsafe void ByteArrayPtrToString(Int32 numberIterations){
			const int arraySize = 10;
			byte* b = stackalloc byte[arraySize];
			for (int i = 0; i < numberIterations; ++i){
				int k = ChangeableStringParamStackParam(b, arraySize/2);
				string s = Marshal.PtrToStringUni(new IntPtr(b), arraySize/2);
			}
		}

		public unsafe void ByteArrayPtrToStringBi(Int32 numberIterations){
			const int arraySize = 8;
			byte* b = stackalloc byte[arraySize];
			for (int i = 0; i < numberIterations; ++i){
				Marshal.Copy("abcd".ToCharArray(), 0, new IntPtr(b), arraySize/2);
				int k = ChangeableStringParamStackParam(b, arraySize/2);
				string s = Marshal.PtrToStringUni(new IntPtr(b), arraySize/2);
			}
		}

		public unsafe void ByteArrayPtrToStringNoSizeParam(Int32 numberIterations){
			const int arraySize = 8;
			byte* b = stackalloc byte[arraySize];
			for (int i = 0; i < numberIterations; ++i){
				int k = ChangeableStringParamStackParam(b, arraySize/2);
				string s = Marshal.PtrToStringUni(new IntPtr(b));
			}
		}
	}
}
