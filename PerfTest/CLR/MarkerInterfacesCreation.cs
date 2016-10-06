using System;
using System.Text;
using DotNetPerformance;
using System.Runtime.InteropServices;

namespace PerfTest.CLR {
	public class MarkerInterfacesCreation {
		//TEST 14.03
		[Benchmark("Compares marker interfaces to custom attributes in terms of object creation cost.")]
		public TestResultGrp RunTest() {	
			const int numberIterations  = 50000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Unmarked);
			testCases += new TestRunner.TestCase(MarkerInterface);
			testCases += new TestRunner.TestCase(CustomAttribute);

			return tr.RunTests(testCases);
		}

		public void Unmarked(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				object o = new Unmarked();
			}
		}

		public void MarkerInterface(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				object o = new MarkedWithInterface();
			}
		}

		public void CustomAttribute(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				object o = new MarkedWithAttribute();
			}
		}
	}
}
