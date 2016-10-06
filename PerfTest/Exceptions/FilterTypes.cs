using System;
using DotNetPerformance;

namespace PerfTest.Exceptions {
	public class FilterTypes {
		//TEST 08.01
		[Benchmark("Calls out to an IL assembly that uses two different types of protected block handlers")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 10000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(FilterTypes.TypeFiltered);
			testCases += new TestRunner.TestCase(FilterTypes.UserFiltered);
			
			return tr.RunTests(testCases);
		}

		public static void TypeFiltered(Int32 numberIterations) {
			ExceptionHandling.GenerateAndCatchException exTest 
				= new ExceptionHandling.GenerateAndCatchException();
			for (int i = 0;i < numberIterations;++i) {
				exTest.TypeFiltered();
			}
		}

		public static void UserFiltered(Int32 numberIterations) {
			ExceptionHandling.GenerateAndCatchException exTest 
				= new ExceptionHandling.GenerateAndCatchException();
			for (int i = 0;i < numberIterations;++i) {
				exTest.UserFiltered();
			}
		}
	}
}
