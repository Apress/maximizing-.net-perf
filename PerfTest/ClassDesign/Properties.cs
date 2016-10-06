using System;
using DotNetPerformance;

namespace PerfTest.ClassDesign {
	public class TestProp {
		public TestProp(){i=1;j=1;}
		public int i;
		private int _j, _k;
		public int j{
			get{return _j;}
			set{_j = value;}
		}
		public virtual int k{
			get{return _k;}
			set{_k = value;}
		}
	}
	public class Properties {
		//TEST 03.06
		[Benchmark("Compares access speed of member variables vs properties.")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 100000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Properties.PublicFieldGet);
			testCases += new TestRunner.TestCase(Properties.PropertyGet);
			testCases += new TestRunner.TestCase(Properties.VirtualPropertyGet);
			testCases += new TestRunner.TestCase(Properties.PublicFieldSet);
			testCases += new TestRunner.TestCase(Properties.PropertySet);
			testCases += new TestRunner.TestCase(Properties.VirtualPropertySet);
			
			return tr.RunTests(testCases);
		}

		public static void PublicFieldGet(Int32 numberIterations) {	
			TestProp t = new TestProp();
			for (int i = 0;i < numberIterations;++i){
				int k = t.i;
			}
		}

		public static void PropertyGet(Int32 numberIterations) {	
			TestProp t = new TestProp();
			for (int i = 0;i < numberIterations;++i){
				int k = t.j;
			}
		}

		public static void VirtualPropertyGet(Int32 numberIterations) {	
			TestProp t = new TestProp();
			for (int i = 0;i < numberIterations;++i) {
				int k = t.k;
			}
		}

		public static void PublicFieldSet(Int32 numberIterations) {	
			TestProp t = new TestProp();
			for (int i = 0;i < numberIterations;++i) {
				t.i = i;
			}
		}

		public static void PropertySet(Int32 numberIterations) {	
			TestProp t = new TestProp();
			for (int i = 0;i < numberIterations;++i) {
				t.j = i;
			}
		}

		public static void VirtualPropertySet(Int32 numberIterations) {	
			TestProp t = new TestProp();
			for (int i = 0;i < numberIterations;++i) {
				t.k = i;
			}
		}

	}
}
