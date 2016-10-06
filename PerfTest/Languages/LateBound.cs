using System;
using System.Collections;
using DotNetPerformance;

namespace PerfTest.Languages {
	public class LateBound {
		private int _ix;
		//TEST 06.03
		[Benchmark("Compares VB.NET late and early bound method invocations")]
		public TestResultGrp RunTest() {	
			const int numberTestRuns = 5;
			const int numberIterations = 100000;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(EarlyBoundCall);
			testCases += new TestRunner.TestCase(LateBoundCall);
			return tr.RunTests(testCases);
		}

		public void EarlyBoundCall(Int32 numberIterations){
			VBExceptionHandling.LateBindingTest lb = new VBExceptionHandling.LateBindingTest();
			ArrayList al = new ArrayList(numberIterations/2);
			for (int i = 0;i < numberIterations;++i) {
				_ix += lb.EarlyBoundMethod(ref al);
			}
		}

		public void LateBoundCall(Int32 numberIterations){
			VBExceptionHandling.LateBindingTest lb = new VBExceptionHandling.LateBindingTest();
			ArrayList al = new ArrayList(numberIterations/2);
			object o = al;
			for (int i = 0;i < numberIterations;++i) {
				_ix += lb.LateBindingMethod(ref o);
			}
		}
	}
}
