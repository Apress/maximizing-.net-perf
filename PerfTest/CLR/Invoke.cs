using System;
using System.Reflection;
using DotNetPerformance;
using System.Runtime.InteropServices;

namespace PerfTest.CLR {
	public class Invoke {
		//TEST 14.07
		[Benchmark("Looks at performance cost of method invocation with reflection")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 10000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Reflection);
			testCases += new TestRunner.TestCase(EarlyBound);

			return tr.RunTests(testCases);
		}

		public void Reflection(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				int j = (int)this.GetType().InvokeMember("GetHashCode", 
					BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Instance, null, this, null);
			}
		}

		public void EarlyBound(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				int j = this.GetHashCode();
			}
		}
	}
}
