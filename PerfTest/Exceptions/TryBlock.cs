using System;
using DotNetPerformance;

namespace PerfTest.Exceptions {
	public class TryBlock {

		//TEST 08.03
		[Benchmark("Looks at cost of setting up a protected code block")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 50000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(TryBlock.Zero);
			testCases += new TestRunner.TestCase(TryBlock.One);
			testCases += new TestRunner.TestCase(TryBlock.OneWithThrow);
			testCases += new TestRunner.TestCase(TryBlock.Two);
			testCases += new TestRunner.TestCase(TryBlock.OneWithFinally);
			
			return tr.RunTests(testCases);
		}

		public static void Zero(Int32 numberIterations) {
			char[] s = {'1', '2', '3'};
			for (int i = 0;i < numberIterations;++i) {
				s[i%3] = '0';
				s[i%2] = '1';
			}
		}

		public static void OneWithThrow(Int32 numberIterations) {
			char[] s = {'1', '2', '3'};
			for (int i = 0;i < numberIterations;++i) {
				try{
					s[i%3] = '0';
					s[i%2] = '1';
				}
				catch(Exception){
					--i;
					throw;
				}
			}
		}

		public static void One(Int32 numberIterations) {
			char[] s = {'1', '2', '3'};
			for (int i = 0;i < numberIterations;++i) {
				try{
					s[i%3] = '0';
					s[i%2] = '1';
				}
				catch(Exception){
					--i;

				}
			}
		}

		public static void OneWithFinally(Int32 numberIterations) {
			char[] s = {'1', '2', '3'};
			for (int i = 0;i < numberIterations;++i) {
				try{
					s[i%3] = '0';
				}
				finally{
					s[i%2] = '1';
				}
			}
		}

		public static void Two(Int32 numberIterations) {
			char[] s = {'1', '2', '3'};
			for (int i = 0;i < numberIterations;++i) {
				try{
					try{
						s[i%3] = '0';
					}
					catch (Exception){
						--i;
					}
					s[i%2] = '1';
				}
				catch(Exception){
					--i;
				}
			}
		}

	}
}
