using System;
using DotNetPerformance;
namespace PerfTest.ClassDesign {
	public class StructVsClassAllocation {
		//TEST 03.01
		[Benchmark("Compares allocation speed for reference vs value types.")]
		public static TestResultGrp RunTest() {
			const int numberIterations = 10000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(StructVsClassAllocation.StructWithOnlyValueTypesAlloc);
			testCases += new TestRunner.TestCase(StructVsClassAllocation.ClassWithOnlyValueTypesAlloc);
			testCases += new TestRunner.TestCase(StructVsClassAllocation.StructWithMixedTypesAlloc);
			testCases += new TestRunner.TestCase(StructVsClassAllocation.ClassWithMixedTypesAlloc);
			testCases += new TestRunner.TestCase(StructVsClassAllocation.StructWithOnlyReferenceTypesAlloc);
			testCases += new TestRunner.TestCase(StructVsClassAllocation.ClassWithOnlyReferenceTypesAlloc);

			return tr.RunTests(testCases);
		}

		public static void StructWithOnlyValueTypesAlloc(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i){
				StructWithOnlyValueTypes s = new StructWithOnlyValueTypes(1,2,3);
			}
		}
		public static void ClassWithOnlyValueTypesAlloc(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i){
				ClassWithOnlyValueTypes s = new ClassWithOnlyValueTypes(1,2,3);
			}
		}
		public static void StructWithMixedTypesAlloc(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i){
				StructWithMixedTypes s = new StructWithMixedTypes(1,2,3,"123");
			}
		}
		public static void ClassWithMixedTypesAlloc(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i){
				ClassWithMixedTypes s = new ClassWithMixedTypes(1,2,3,"123");
			}
		}
		public static void StructWithOnlyReferenceTypesAlloc(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i){
				StructWithOnlyReferenceTypes s = new StructWithOnlyReferenceTypes("1,2,3");
			}
		}
		public static void ClassWithOnlyReferenceTypesAlloc(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i){
				ClassWithOnlyReferenceTypes s = new ClassWithOnlyReferenceTypes("1,2,3");
			}
		}
	}

	public struct StructWithOnlyValueTypes {
		public int _a, _b, _c;
		public StructWithOnlyValueTypes(int a, int b, int c){_a = a; _b = b; _c = c;}
	}

	public class ClassWithOnlyValueTypes {
		public int _a, _b, _c;
		public ClassWithOnlyValueTypes(int a, int b, int c){_a = a; _b = b; _c = c;}
	}

	public struct StructWithMixedTypes {
		public int _a, _b, _c;
		public string _s;
		public StructWithMixedTypes(int a, int b, int c, string s){_a = a; _b = b; _c = c; _s = s;}
	}

	public class ClassWithMixedTypes {
		public int _a, _b, _c;
		public string _s;
		public ClassWithMixedTypes(int a, int b, int c, string s){_a = a; _b = b; _c = c; _s = s;}
	}

	public struct StructWithOnlyReferenceTypes {
		public string _s;
		public StructWithOnlyReferenceTypes(string s){_s = s;}
	}

	public class ClassWithOnlyReferenceTypes {
		public string _s;
		public ClassWithOnlyReferenceTypes(string s){_s = s;}
	}
}
