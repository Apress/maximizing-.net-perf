using System;
using DotNetPerformance;
namespace PerfTest.ClassDesign {
	public struct _4BytesStruct{public Int32 a;}
	public struct _8BytesStruct{public Int32 a;public Int32 b;}
	public struct _16BytesStruct{public Int32 a;public Int32 b;public Int32 c;public Int32 d;}
	public struct _32BytesStruct{public Int32 a;public Int32 b;public Int32 c;public Int32 d;
		public Int32 e;public Int32 f;public Int32 g;public Int32 h;}
	public struct _64BytesStruct{public Int32 a;public Int32 b;public Int32 c;public Int32 d;
		public Int32 e;public Int32 f;public Int32 g;public Int32 h;
		public Int32 i;public Int32 j;public Int32 k;public Int32 l;
		public Int32 m;public Int32 n;public Int32 o;public Int32 p;}
	public class _4BytesClass{public Int32 a;}
	public class _8BytesClass{public Int32 a;public Int32 b;}
	public class _16BytesClass{public Int32 a;public Int32 b;public Int32 c;public Int32 d;}
	public class _32BytesClass{public Int32 a;public Int32 b;public Int32 c;public Int32 d;
		public Int32 e;public Int32 f;public Int32 g;public Int32 h;}
	public class _64BytesClass{public Int32 a;public Int32 b;public Int32 c;public Int32 d;
		public Int32 e;public Int32 f;public Int32 g;public Int32 h;
		public Int32 i;public Int32 j;public Int32 k;public Int32 l;
		public Int32 m;public Int32 n;public Int32 o;public Int32 p;}
	

	public class StructVsClassParams {
		//TEST 03.02
		[Benchmark("Compares performance of reference vs value types when used as function parameters.")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 100000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(StructVsClassParams.Struct4);
			testCases += new TestRunner.TestCase(StructVsClassParams.Class4);
			testCases += new TestRunner.TestCase(StructVsClassParams.Struct8);
			testCases += new TestRunner.TestCase(StructVsClassParams.Class8);
			testCases += new TestRunner.TestCase(StructVsClassParams.Struct16);
			testCases += new TestRunner.TestCase(StructVsClassParams.Class16);
			testCases += new TestRunner.TestCase(StructVsClassParams.Struct32);
			testCases += new TestRunner.TestCase(StructVsClassParams.Class32);
			testCases += new TestRunner.TestCase(StructVsClassParams.Struct64);
			testCases += new TestRunner.TestCase(StructVsClassParams.Class64);
			testCases += new TestRunner.TestCase(StructVsClassParams.Struct64Ref);

			return tr.RunTests(testCases);
		}
		
		public static int f(_4BytesStruct s){return s.a+1;}
		public static void Struct4(Int32 numberIterations) {	
			_4BytesStruct s;
			s.a = 1;
			for (int i = 0;i < numberIterations;++i) {
				int j = f(s);
			}
		}

		public static int f(_4BytesClass s){return s.a+1;}
		public static void Class4(Int32 numberIterations) {	
			_4BytesClass s= new _4BytesClass();
			s.a = 1;
			for (int i = 0;i < numberIterations;++i) {
				int j = f(s);
			}
		}

		public static int f(_8BytesStruct s){return s.a+1;}
		public static void Struct8(Int32 numberIterations) {	
			_8BytesStruct s;
			s.a = 1; s.b = 1;
			for (int i = 0;i < numberIterations;++i){
				int j = f(s);
			}
		}

		public static int f(_8BytesClass s){return s.a+1;}
		public static void Class8(Int32 numberIterations) {	
			_8BytesClass s = new _8BytesClass();
			s.a = 1; s.b = 1;
			for (int i = 0;i < numberIterations;++i) {
				int j = f(s);
			}
		}

		public static int f(_16BytesStruct s){return s.a+1;}
		public static void Struct16(Int32 numberIterations) {	
			_16BytesStruct s;
			s.a = 1; s.b = 1; s.c = 1; s.d = 1;
			for (int i = 0;i < numberIterations;++i) {
				int j = f(s);
			}
		}

		public static int f(_16BytesClass s){return s.a+1;}
		public static void Class16(Int32 numberIterations) {	
			_16BytesClass s = new _16BytesClass();
			s.a = 1; s.b = 1; s.c = 1; s.d = 1;
			for (int i = 0;i < numberIterations;++i) {
				int j = f(s);
			}
		}

		public static int f(_32BytesStruct s){return s.a+1;}
		public static void Struct32(Int32 numberIterations) {	
			_32BytesStruct s;
			s.a = 1; s.b = 1; s.c = 1; s.d = 1; s.e = 1; s.f = 1; s.g = 1; s.h = 1;
			for (int i = 0;i < numberIterations;++i) {
				int j = f(s);
			}
		}

		public static int f(_32BytesClass s){return s.a+1;}
		public static void Class32(Int32 numberIterations) {	
			_32BytesClass s = new _32BytesClass();
			s.a = 1; s.b = 1; s.c = 1; s.d = 1; s.e = 1; s.f = 1; s.g = 1; s.h = 1;
			for (int i = 0;i < numberIterations;++i) {
				int j = f(s);
			}
		}

		public static int f(_64BytesStruct s){return s.a+1;}
		public static int fref(ref _64BytesStruct s){return s.a+1;}
		public static void Struct64(Int32 numberIterations) {	
			_64BytesStruct s;
			s.a = 1; s.b = 1; s.c = 1; s.d = 1; s.e = 1; s.f = 1; s.g = 1; s.h = 1;
			s.i = 1; s.j = 1; s.k = 1; s.l = 1; s.m = 1; s.n = 1; s.o = 1; s.p = 1;
			for (int i = 0;i < numberIterations;++i) {
				int j = f(s);
			}
		}

		public static void Struct64Ref(Int32 numberIterations) {	
			_64BytesStruct s;
			s.a = 1; s.b = 1; s.c = 1; s.d = 1; s.e = 1; s.f = 1; s.g = 1; s.h = 1;
			s.i = 1; s.j = 1; s.k = 1; s.l = 1; s.m = 1; s.n = 1; s.o = 1; s.p = 1;
			for (int i = 0;i < numberIterations;++i) {
				int j = fref(ref s);
			}
		}

		public static int f(_64BytesClass s){return s.a+1;}
		public static void Class64(Int32 numberIterations) {	
			_64BytesClass s = new _64BytesClass();
			s.a = 1; s.b = 1; s.c = 1; s.d = 1; s.e = 1; s.f = 1; s.g = 1; s.h = 1;
			s.i = 1; s.j = 1; s.k = 1; s.l = 1; s.m = 1; s.n = 1; s.o = 1; s.p = 1;
			for (int i = 0;i < numberIterations;++i) {
				int j = f(s);
			}
		}
	}
}
