using System;
using System.Security;
using System.Security.Permissions;
using DotNetPerformance;

namespace PerfTest.Security {
	public class Asserts {
		//TEST 09.04
		[Benchmark("Compares imperative and declarative asserts.")]
		public TestResultGrp RunTest() {	
			const int numberTestRuns = 5;
			const int numberIterations = 100000;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Imperative);
			testCases += new TestRunner.TestCase(Declarative);
			return tr.RunTests(testCases);
		}

		public void Imperative(Int32 numberIterations){
			for (int i = 0;i < numberIterations;++i) {
				ImperativeMethod();
			}
		}

		public void ImperativeMethod(){
			ReflectionPermission rp = new ReflectionPermission(ReflectionPermissionFlag.AllFlags);
			rp.Assert();
		}

		public void Declarative(Int32 numberIterations){
			for (int i = 0;i < numberIterations;++i) {
				DeclarativeMethod();
			}
		}

		[ReflectionPermissionAttribute(SecurityAction.Assert, Unrestricted=true)]
		public void DeclarativeMethod(){
			;
		}
	}
}
