using System;
using DotNetPerformance;

namespace PerfTest.Strings {
	public class ValueRefTest {
		//TEST 04.01
		[Benchmark("Compares various string equality checks")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 10000000;
			const int numberTestRuns = 3;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(ValueRefTest.OperatorEquality);
			testCases += new TestRunner.TestCase(ValueRefTest.Compare);
			testCases += new TestRunner.TestCase(ValueRefTest.OperatorEqualityAndCompare);
			testCases += new TestRunner.TestCase(ValueRefTest.ReferenceEquals);
			testCases += new TestRunner.TestCase(ValueRefTest.StaticObject);
			testCases += new TestRunner.TestCase(ValueRefTest.InstanceString);
			testCases += new TestRunner.TestCase(ValueRefTest.StaticString);
			testCases += new TestRunner.TestCase(ValueRefTest.VBEquals);

			return tr.RunTests(testCases);
		}

		static string s1 = "abcdef";
		static string s2 = "abcdef";
		static string s3 = "uvwxyz";
			

		public static void OperatorEquality(Int32 numberIterations) {
			bool b;
			for (int i = 0;i < numberIterations;++i) {
				b = (s1 == s2);
				b = (s2 == s3);
			}
		}

		public static void OperatorEqualityAndCompare(Int32 numberIterations) {
			bool b;
			for (int i = 0;i < numberIterations;++i) {
				b = (s1 == s2 || String.Compare(s1, s2) == 0);
				b = (s2 == s3 || String.Compare(s2, s3) == 0);
			}
		}

		public static void Compare(Int32 numberIterations) {
			bool b;
			for (int i = 0;i < numberIterations;++i) {
				b = (String.Compare(s1, s2) == 0);
				b = (String.Compare(s2, s3) == 0);
			}
		}

		public static void VBEquals(Int32 numberIterations) {
			bool b;
			for (int i = 0;i < numberIterations;++i) {
				//VB.NET equivalent
				//Dim b As Boolean = s1 = s2
				//
				b = Microsoft.VisualBasic.Strings.StrComp(s1, s2, Microsoft.VisualBasic.CompareMethod.Binary) == 0;
				b = Microsoft.VisualBasic.Strings.StrComp(s2, s3, Microsoft.VisualBasic.CompareMethod.Binary) == 0;
			}
		}

		public static void ReferenceEquals(Int32 numberIterations) {
			bool b;
			for (int i = 0;i < numberIterations;++i) {
				b = String.ReferenceEquals(s1, s2);
				b = String.ReferenceEquals(s2, s3);
			}
		}

		public static void StaticObject(Int32 numberIterations) {
			bool b;
			for (int i = 0;i < numberIterations;++i) {
				b = Object.Equals(s1, s2);
				b = Object.Equals(s2, s3);
			}
		}

		public static void InstanceString(Int32 numberIterations) {
			bool b;
			for (int i = 0;i < numberIterations;++i) {
				b = s1.Equals(s2);
				b = s2.Equals(s3);
			}
		}

		public static void StaticString(Int32 numberIterations) {
			bool b;
			for (int i = 0;i < numberIterations;++i) {
				b = String.Equals(s1, s2);
				b = String.Equals(s2, s3);
			}
		}
	}
}
