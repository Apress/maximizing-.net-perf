using System;
using System.Text;
using DotNetPerformance;
using System.Runtime.InteropServices;

namespace PerfTest.CLR {
	public class CreateInstanceTester{}

	public class CreateInstanceTest {
		//TEST 14.08
		[Benchmark("Compares CreateInstance call to operator new for types inside and outside current app domain.")]
		public TestResultGrp RunTest() {	
			const int numberIterations  = 1000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(New);
			testCases += new TestRunner.TestCase(CreateInstance);
			testCases += new TestRunner.TestCase(CreateInstanceNoAssemblyLocationCost);
			testCases += new TestRunner.TestCase(NewOutsideCurrentAssembly);
			testCases += new TestRunner.TestCase(CreateInstanceOutsideCurrentAssembly);
			testCases += new TestRunner.TestCase(CreateInstanceOutsideCurrentAssemblyNoAssemblyLocationCost);

			return tr.RunTests(testCases);
		}

		public void New(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				CreateInstanceTester cit = new CreateInstanceTester();
			}
		}

		public void CreateInstance(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				CreateInstanceTester cit =  (CreateInstanceTester)
					GetType().Assembly.CreateInstance("PerfTest.CLR.CreateInstanceTester");
			}
		}

		public void CreateInstanceNoAssemblyLocationCost(Int32 numberIterations){
			System.Reflection.Assembly thisAssembly = GetType().Assembly;
			for (int i = 0; i < numberIterations; ++i){
				CreateInstanceTester cit =  (CreateInstanceTester)
					thisAssembly.CreateInstance("PerfTest.CLR.CreateInstanceTester");
			}
		}

		public void NewOutsideCurrentAssembly(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				object o = new object();
			}
		}

		public void CreateInstanceOutsideCurrentAssembly(Int32 numberIterations){
			for (int i = 0; i < numberIterations; ++i){
				System.Reflection.Assembly mscorlib = null;
				foreach(System.Reflection.Assembly ass in AppDomain.CurrentDomain.GetAssemblies()){
					if (ass.FullName.StartsWith("mscorlib")){
						mscorlib = ass;
						break;
					}
				}
				object o =  mscorlib.CreateInstance("System.Object");
			}
		}

		public void CreateInstanceOutsideCurrentAssemblyNoAssemblyLocationCost(Int32 numberIterations){
			System.Reflection.Assembly mscorlib = null;
			foreach(System.Reflection.Assembly ass in AppDomain.CurrentDomain.GetAssemblies()){
				if (ass.FullName.StartsWith("mscorlib")){
					mscorlib = ass;
					break;
				}
			}
			for (int i = 0; i < numberIterations; ++i){
				object o =  mscorlib.CreateInstance("System.Object");
			}
		}
	}
}
