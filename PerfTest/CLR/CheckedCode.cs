using System;
using System.Text;
using DotNetPerformance;
using System.Runtime.InteropServices;

namespace PerfTest.CLR {
	public class CheckedCode {
		//TEST 14.05
		[Benchmark("Compares checked and unchecked code for numeric operations.")]
		public TestResultGrp RunTest() {	
			const int numberIterations  = Int32.MaxValue-1;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(CheckedInt64);
			testCases += new TestRunner.TestCase(UncheckedInt64);
			testCases += new TestRunner.TestCase(CheckedInt32);
			testCases += new TestRunner.TestCase(UncheckedInt32);
			testCases += new TestRunner.TestCase(CheckedInt16);
			testCases += new TestRunner.TestCase(UncheckedInt16);

			return tr.RunTests(testCases);
		}

		public void CheckedInt16(Int32 numberIterations){
			for (short i = 0; i < Int16.MaxValue;){
				checked{
					++i;
					for (short j = 0; j < Int16.MaxValue;){
						++j;
					}
				}
			}
		}

		public void UncheckedInt16(Int32 numberIterations){
			for (short i = 0; i < Int16.MaxValue;){
					++i;
					for (short j = 0; j < Int16.MaxValue;){
						++j;
					}
			}
		}

		public void CheckedInt32(Int32 numberIterations){
			for (int i = 0; i < numberIterations;){
				checked{
					++i;
				}
			}
		}

		public void UncheckedInt32(Int32 numberIterations){
			for (int i = 0; i < numberIterations;){
				 ++i;
			}
		}

		public void CheckedInt64(Int32 numberIterations){
			for (long i = 0; i < numberIterations;){
				checked{
					++i;
				}
			}
		}

		public void UncheckedInt64(Int32 numberIterations){
			for (long i = 0; i < numberIterations; ++i){
				 ++i;
			}
		}
	}
}
