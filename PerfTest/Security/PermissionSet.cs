using System;
using System.Security;
using System.Security.Permissions;
using DotNetPerformance;

namespace PerfTest.Security {
	public class PermissionSet {
		//TEST 09.02
		[Benchmark("Compares individual permission demands compared to a PermissionSet demand")]
		public TestResultGrp RunTest() {	
			const int numberTestRuns = 5;
			const int numberIterations = 100000;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(Set);
			testCases += new TestRunner.TestCase(Individual);
			testCases += new TestRunner.TestCase(Declarative);
			return tr.RunTests(testCases);
		}

		public void Set(Int32 numberIterations){
			for (int i = 0;i < numberIterations;++i) {
				SetMethod();
			}
		}

		public void SetMethod(){
			ReflectionPermission rp = new ReflectionPermission(ReflectionPermissionFlag.AllFlags);
			IsolatedStorageFilePermission isp = new IsolatedStorageFilePermission(PermissionState.Unrestricted);
			System.Security.PermissionSet ps = new System.Security.PermissionSet(PermissionState.None);
			ps.AddPermission(rp);
			ps.AddPermission(isp);
			ps.Demand();
		}

		public void Individual(Int32 numberIterations){
			for (int i = 0;i < numberIterations;++i) {
				IndividualMethod();
			}
		}

		public void IndividualMethod(){
			ReflectionPermission rp = new ReflectionPermission(ReflectionPermissionFlag.AllFlags);
			rp.Demand();
			IsolatedStorageFilePermission isp = new IsolatedStorageFilePermission(PermissionState.Unrestricted);
			isp.Demand();
		}

		public void Declarative(Int32 numberIterations){
			for (int i = 0;i < numberIterations;++i) {
				DeclarativeMethod();
			}
		}

		[IsolatedStorageFilePermissionAttribute(SecurityAction.Demand, Unrestricted=true)]
		[ReflectionPermissionAttribute(SecurityAction.Demand, Unrestricted=true)]
		public void DeclarativeMethod(){
			;
		}
	}
}
