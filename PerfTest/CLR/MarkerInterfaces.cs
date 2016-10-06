using System;
using System.Text;
using DotNetPerformance;
using System.Runtime.InteropServices;

namespace PerfTest.CLR {
	interface IMarker{}
	public class MarkedWithInterface: IMarker{}
	[AttributeUsage(AttributeTargets.Class)] public class MarkedAttribute: Attribute{}
	[Marked] public class MarkedWithAttribute{}
	public class Unmarked{}

	public class MarkerInterfaces {
		//TEST 14.04
		[Benchmark("Compares marker interfaces to custom attributes.")]
		public TestResultGrp RunTest() {	
			const int numberIterations  = 1000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(MarkerInterface);
			testCases += new TestRunner.TestCase(CustomAttribute);

			return tr.RunTests(testCases);
		}

		public void MarkerInterface(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				object o = new MarkedWithInterface();
				IMarker m = o as IMarker;
				if (m != null){
					m.GetHashCode();
				}
			}
		}

		public void CustomAttribute(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				object o = new MarkedWithAttribute();
				object[] atts = o.GetType().GetCustomAttributes(typeof(MarkedAttribute), false);
				if (atts.Length != 0){
					o.GetHashCode();
				}
			}
		}
	}
}
