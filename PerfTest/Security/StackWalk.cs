using System;
using System.Security;
using System.Security.Permissions;
using VBExceptionHandling;
using DotNetPerformance;

namespace PerfTest.Security {
	public class StackWalk {
		//TEST 09.01
		[Benchmark("Compares various permission demand techniques.")]
		public TestResultGrp RunTest() {	
			const int numberTestRuns = 5;
			const int numberIterations = 10000000;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Full);
			testCases += new TestRunner.TestCase(Cached);
			testCases += new TestRunner.TestCase(Link);
			testCases += new TestRunner.TestCase(None);
			return tr.RunTests(testCases);
		}

		PermDemand _dmd = new PermDemand();


		public void Full(Int32 numberIterations){
			for (int i = 0;i < numberIterations;++i) {
				_dmd.DoubleValDemand(i);
			}
		}

		[ReflectionPermissionAttribute(SecurityAction.Demand, Unrestricted=true)]
		[ReflectionPermissionAttribute(SecurityAction.Assert, Unrestricted=true)]
		public void Cached(Int32 numberIterations){
			for (int i = 0;i < numberIterations;++i) {
				_dmd.DoubleValDemand(i);
			}
		}

		public void Link(Int32 numberIterations){
			for (int i = 0;i < numberIterations;++i) {
				_dmd.DoubleValLinkDemand(i);
			}
		}

		public void None(Int32 numberIterations){
			for (int i = 0;i < numberIterations;++i) {
				_dmd.DoubleValNone(i);
			}
		}
	}
}
