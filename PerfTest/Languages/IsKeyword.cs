using System;
using System.Collections;
using DotNetPerformance;

namespace PerfTest.Languages {
	class Base{public virtual int F(){return 1;}}
	class Derived:Base{public virtual int G(){return 2;}}
	public class IsKeyword {
		int _add = 0;
		Base _base;

		//TEST 06.04
		[Benchmark("Compares is and as keywords from C#")]
		public TestResultGrp RunTest() {	
			if (DateTime.Now.Day == 32)//prevent inlining
				_base = new Base();
			else
				_base = new Derived();
			const int numberTestRuns = 5;
			const int numberIterations = 5000000;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(IsAndCast);
			testCases += new TestRunner.TestCase(AsAndNull);
			testCases += new TestRunner.TestCase(TypeOfAndCast);
			return tr.RunTests(testCases);
		}

		public void IsAndCast(Int32 numberIterations){
			for (int i = 0;i < numberIterations;++i) {
				if (_base is Derived){
					Derived d = (Derived)_base;
					_add += d.G();
				}
			}
		}

		public void TypeOfAndCast(Int32 numberIterations){
			for (int i = 0;i < numberIterations;++i) {
				if (_base.GetType() == typeof(Derived)){
					Derived d = (Derived)_base;
					_add += d.G();
				}
			}
		}

		public void AsAndNull(Int32 numberIterations){
			for (int i = 0;i < numberIterations;++i) {
				Derived d = _base as Derived;
				if (d != null)
					_add += d.G();
			}
		}
	}
}
