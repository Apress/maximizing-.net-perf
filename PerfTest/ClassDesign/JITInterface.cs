using System;
using DotNetPerformance;
namespace PerfTest.ClassDesign {
	interface IExpensive{int MethodA(); int MethodB();}
	class JITInterface: IExpensive {
		public int i = 0;
		public virtual int UnrelatedMethod(){return i;}

		//tear off
		private JITInterfaceImpl impl;
		private void CheckImpl(){if (impl == null) impl = new JITInterfaceImpl();}
		public virtual int MethodA(){CheckImpl(); return impl.MethodA();}
		public virtual int MethodB(){CheckImpl(); return impl.MethodB();}
	}

	class JITInterfaceImpl: JITInterface {
		private int a, b, c, d, e, f; //used for IExpensive
		public JITInterfaceImpl(){
			a = b = c = d = e = f = 1;
		}
		public override int MethodA() {return a + b + c + d + e + f;}
		public override int MethodB() {return a + b + c + d - e - f;}
	}

	public class StandardExpensiveImpl: IExpensive {
		//normal class stuff
		public int i = 0;
		public virtual int UnrelatedMethod(){return i;}
		public StandardExpensiveImpl(){
			a = b = c = d = e = f = 1;
		}

		//IExpensive
		private int a, b, c, d, e, f;
		public virtual int MethodA() {return a + b + c + d + e + f;}
		public virtual int MethodB() {return a + b + c + d - e - f;}
	}

	public class JITInterfaceTest {
		private static int InterfaceCallPeriod = 10;
		//TEST 03.07
		[Benchmark("Tests benefit of delegating expensive interface implementation to a derived type.")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 5000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(JITInterfaceTest.Normal);
			testCases += new TestRunner.TestCase(JITInterfaceTest.JIT);
			
			return tr.RunTests(testCases);
		}

		public static void Normal(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				StandardExpensiveImpl s = new StandardExpensiveImpl();
				s.UnrelatedMethod();
				if (i%InterfaceCallPeriod == 0) {IExpensive ie = (IExpensive)s; ie.MethodA(); ie.MethodB();}
			}
		}

		public static void JIT(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				JITInterface t = new JITInterface();
				t.UnrelatedMethod();
				if (i%InterfaceCallPeriod == 0) {IExpensive ie = (IExpensive)t; ie.MethodA(); ie.MethodB();}
			}
		}
	}

}
