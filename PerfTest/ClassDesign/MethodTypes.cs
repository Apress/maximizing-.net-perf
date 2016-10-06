using System;
using DotNetPerformance;

namespace PerfTest.ClassDesign {
	public struct MethodTypeStruct {
		public static int StaticMethod(){return 1;}
		public int NormalMethod(){return 1;}
	}
	public interface IExplicitInterface{int ExplicitInterfaceMethod();}
	public interface IImplicitInterface{int ImplicitInterfaceMethod();}
	public class MethodTest: IExplicitInterface, IImplicitInterface {
		public static int StaticMethod(){return 1;}
		public int NormalMethod(){return 1;}
		public virtual int VirtualMethod(){return 1;}
		int IExplicitInterface.ExplicitInterfaceMethod(){return 1;}
		public int ImplicitInterfaceMethod(){return 1;}
	}
	public class MethodTestDerived:MethodTest {
		public override int VirtualMethod(){return 1;}
	}
	public class MethodTypes {
		//TEST 03.10
		[Benchmark("Looks at the perf. cost of various method modifiers.")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 100000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(MethodTypes.ValueStatic);
			testCases += new TestRunner.TestCase(MethodTypes.ValueNormal);
			testCases += new TestRunner.TestCase(MethodTypes.Virtual);
			testCases += new TestRunner.TestCase(MethodTypes.Static);
			testCases += new TestRunner.TestCase(MethodTypes.Normal);
			testCases += new TestRunner.TestCase(MethodTypes.ExplicitInterfaceMethod);
			testCases += new TestRunner.TestCase(MethodTypes.ImplicitInterfaceMethodThroughInterface);
			testCases += new TestRunner.TestCase(MethodTypes.ImplicitInterfaceMethodThroughClass);
			
			return tr.RunTests(testCases);
		}

		public static void ValueStatic(Int32 numberIterations) {
			for (int i = 0;i < numberIterations;++i) {
				MethodTypeStruct.StaticMethod();
			}
		}
		public static void ValueNormal(Int32 numberIterations) {	
			MethodTypeStruct m = new MethodTypeStruct();
			for (int i = 0;i < numberIterations;++i) {
				m.NormalMethod();
			}
		}

		public static void Static(Int32 numberIterations) {
			for (int i = 0;i < numberIterations;++i) {
				MethodTest.StaticMethod();
			}
		}
		public static void Normal(Int32 numberIterations) {	
			MethodTest m = new MethodTest();
			for (int i = 0;i < numberIterations;++i) {
				m.NormalMethod();
			}
		}
		public static void Virtual(Int32 numberIterations) {	
			MethodTest m = new MethodTestDerived();
			for (int i = 0;i < numberIterations;++i) {
				m.VirtualMethod();
			}
		}

		public static void ExplicitInterfaceMethod(Int32 numberIterations) {	
			MethodTest m = new MethodTestDerived();
			IExplicitInterface t = (IExplicitInterface)m;
			for (int i = 0;i < numberIterations;++i) {
				t.ExplicitInterfaceMethod();
			}
		}

		public static void ImplicitInterfaceMethodThroughInterface(Int32 numberIterations) {	
			MethodTest m = new MethodTestDerived();
			IImplicitInterface t = (IImplicitInterface)m;
			for (int i = 0;i < numberIterations;++i) {
				t.ImplicitInterfaceMethod();
			}
		}

		public static void ImplicitInterfaceMethodThroughClass(Int32 numberIterations) {	
			MethodTest m = new MethodTestDerived();
			for (int i = 0;i < numberIterations;++i) {
				m.ImplicitInterfaceMethod();
			}
		}
	}
}
