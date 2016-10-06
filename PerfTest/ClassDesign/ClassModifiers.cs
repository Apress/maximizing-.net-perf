using System;
using DotNetPerformance;
namespace PerfTest.ClassDesign {
	/// <summary>
	/// Summary description for ClassModifiers.
	/// </summary>
	/// 
	public sealed class SealedClass{}
	public class NonSealedClass{}

	public class ClassModifiers {
		[Benchmark("Not for publication.")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 10000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(ClassModifiers.SealedClassAlloc);
			testCases += new TestRunner.TestCase(ClassModifiers.NonSealedClassAlloc);
			
			return tr.RunTests(testCases);
		}

		public static void SealedClassAlloc(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				SealedClass s = new SealedClass();
			}
		}

		public static void NonSealedClassAlloc(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				NonSealedClass s = new NonSealedClass();
			}
		}
	}
}
