using System;
using DotNetPerformance;
namespace PerfTest.ClassDesign {
	/// <summary>
	/// Summary description for StructVsClassAllocationAndParam.
	/// </summary>
	public class StructVsClassAllocationAndParam {
		//TEST 03.03
		[Benchmark("Compares performance of reference vs value types when used as function parameters with the cost of allocation also used as part of the test case.")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 10000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(StructVsClassAllocationAndParam.Struct);
			testCases += new TestRunner.TestCase(StructVsClassAllocationAndParam.Class);
			testCases += new TestRunner.TestCase(StructVsClassAllocationAndParam.StructRef);
			testCases += new TestRunner.TestCase(StructVsClassAllocationAndParam.Struct8Calls);
			testCases += new TestRunner.TestCase(StructVsClassAllocationAndParam.Class8Calls);

			return tr.RunTests(testCases);
		}
		
		public static void Struct(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				_64BytesStruct s;
				s.a = 1; s.b = 1; s.c = 1; s.d = 1; s.e = 1; s.f = 1; s.g = 1; s.h = 1;
				s.i = 1; s.j = 1; s.k = 1; s.l = 1; s.m = 1; s.n = 1; s.o = 1; s.p = 1;
				int j = StructVsClassParams.f(s);
			}
		}

		public static void Struct8Calls(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				_64BytesStruct s;
				s.a = 1; s.b = 1; s.c = 1; s.d = 1; s.e = 1; s.f = 1; s.g = 1; s.h = 1;
				s.i = 1; s.j = 1; s.k = 1; s.l = 1; s.m = 1; s.n = 1; s.o = 1; s.p = 1;
				int j = StructVsClassParams.f(s);
				int k = StructVsClassParams.f(s);
				int l = StructVsClassParams.f(s);
				int m = StructVsClassParams.f(s);
				int n = StructVsClassParams.f(s);
				int o = StructVsClassParams.f(s);
				int p = StructVsClassParams.f(s);
				int q = StructVsClassParams.f(s);
			}
		}

		public static void StructRef(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				_64BytesStruct s;
				s.a = 1; s.b = 1; s.c = 1; s.d = 1; s.e = 1; s.f = 1; s.g = 1; s.h = 1;
				s.i = 1; s.j = 1; s.k = 1; s.l = 1; s.m = 1; s.n = 1; s.o = 1; s.p = 1;
				int j = StructVsClassParams.fref(ref s);
			}
		}

		public static void Class(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				_64BytesClass s = new _64BytesClass();
				s.a = 1; s.b = 1; s.c = 1; s.d = 1; s.e = 1; s.f = 1; s.g = 1; s.h = 1;
				s.i = 1; s.j = 1; s.k = 1; s.l = 1; s.m = 1; s.n = 1; s.o = 1; s.p = 1;
				int j = StructVsClassParams.f(s);
			}
		}

		public static void Class8Calls(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				_64BytesClass s = new _64BytesClass();
				s.a = 1; s.b = 1; s.c = 1; s.d = 1; s.e = 1; s.f = 1; s.g = 1; s.h = 1;
				s.i = 1; s.j = 1; s.k = 1; s.l = 1; s.m = 1; s.n = 1; s.o = 1; s.p = 1;
				int j = StructVsClassParams.f(s);
				int k = StructVsClassParams.f(s);
				int l = StructVsClassParams.f(s);
				int m = StructVsClassParams.f(s);
				int n = StructVsClassParams.f(s);
				int o = StructVsClassParams.f(s);
				int p = StructVsClassParams.f(s);
				int q = StructVsClassParams.f(s);
			}
		}
	}
}
