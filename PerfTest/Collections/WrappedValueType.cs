using System;
using System.Collections;
using DotNetPerformance;

namespace PerfTest.Collections {
	public class IntWrapper{
		public int Int;
	}

	public class WrappedValueType {
		//TEST 05.07
		[Benchmark("Looks at manually wrapped vs boxed value types.")]
		public TestResultGrp RunTest() {	
			const int numberIterations = 10000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(this.Wrapped);
			testCases += new TestRunner.TestCase(this.Raw);
			
			return tr.RunTests(testCases);
		}

		public void Wrapped(Int32 NumberIterations){
			ArrayList al = new ArrayList();
			al.Add(new IntWrapper());
			for (int i = 0; i < NumberIterations; ++i){
				++(((IntWrapper)(al[0])).Int);
			}
		}

		public void Raw(Int32 NumberIterations){
			ArrayList al = new ArrayList();
			al.Add(new Int32());
			for (int i = 0; i < NumberIterations; ++i){
				al[0] = (int)(al[0]) + i;
			}
		}
	}
}
