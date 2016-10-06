using System;
using DotNetPerformance;

namespace PerfTest.Exceptions {
	public class StackTrace {
		private static Array GetArray(){return null;}

		[Benchmark("Looks at cost of accessing stack trace property.")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 100000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(StackTrace.StackTraceAccessed);
			testCases += new TestRunner.TestCase(StackTrace.StackTraceNotAccessed);
			testCases += new TestRunner.TestCase(StackTrace.StackTraceDoubleAccessed);
			
			return tr.RunTests(testCases);
		}

		public static void StackTraceNotAccessed(Int32 numberIterations) {
			Array a  = GetArray();
			for (int i = 0;i < numberIterations;++i) {
				try{
					a.SetValue(i, i);
				}
				catch(Exception){
					System.Diagnostics.Trace.Write("Exception caught");
				}
			}
		}

		public static void StackTraceAccessed(Int32 numberIterations) {
			Array a  = GetArray();
			for (int i = 0;i < numberIterations;++i) {
				try{
					a.SetValue(i, i);
				}
				catch(Exception ex){
					System.Diagnostics.Trace.Write(ex.StackTrace);
				}
			}
		}

		
		public static void StackTraceDoubleAccessed(Int32 numberIterations) {
			Array a  = GetArray();
			for (int i = 0;i < numberIterations;++i) {
				try{
					a.SetValue(i, i);
				}
				catch(Exception ex){
					System.Diagnostics.Trace.Write(ex.StackTrace);
					System.Diagnostics.Trace.Write(ex.StackTrace);
				}
			}
		}
	}
}
