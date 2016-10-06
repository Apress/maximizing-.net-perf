using System;
using System.Collections;
using DotNetPerformance;

namespace PerfTest.Threads
{
	public class TLS {
		[Benchmark("Compares thread local storage to standard static variables")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 50000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(TLS.ThreadLocal);
			testCases += new TestRunner.TestCase(TLS.Static);
			testCases += new TestRunner.TestCase(TLS.StaticAndMonitor);
			
			return tr.RunTests(testCases);
		}

		[ThreadStatic] static int _ts;
		static int _stat;


		public static void StaticAndMonitor(int NumberIterations){
			for(int i = 0; i < NumberIterations; ++i){
				lock(typeof(TLS)){
					++_stat;
				}
			}
		}

		public static void Static(int NumberIterations){
			for(int i = 0; i < NumberIterations; ++i){
				++_stat;
			}
		}

		public static void ThreadLocal(int NumberIterations){
			for(int i = 0; i < NumberIterations; ++i){
				++_ts;
			}
		}
	}
}
