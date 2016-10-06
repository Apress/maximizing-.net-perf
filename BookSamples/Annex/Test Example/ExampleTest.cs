using System;
using DotNetPerformance;

namespace Test_Example {
   public class ExampleTest {
      [Benchmark("Compares Technique 1 with Technique 2")]
      public TestResultGrp RunTest() {   
         const int numberIterations = 50000000;
         const int numberTestRuns = 5;
         TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
         TestRunner.TestCase testCases = null;
         testCases += new TestRunner.TestCase(Technique1);
         testCases += new TestRunner.TestCase(Technique2);
         
         return tr.RunTests(testCases);
      }

      public static void ForceGC(){
         GC.Collect();
      }

      [Benchmark("Compares Technique 1 with Technique 2")]
      public TestResultGrp RunTestWithGC() {   
         const int numberIterations = 50000000;
         const int numberTestRuns = 5;
         TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
         
         TestGroup tgTechnique1 = new TestGroup(
            new TestRunner.TestCase(Technique1),  //test case
            new TestRunner.TestCleanup(ForceGC),  //force a GC before test
            new TestRunner.TestCleanup(TestRunner.NoOp), //no action after test
            new TestRunner.TestValidity(TestRunner.TestOK)); //default validity test
         tr.AddTestGroup(tgTechnique1);

         TestGroup tgTechnique2 = new TestGroup(
            new TestRunner.TestCase(Technique2),
            new TestRunner.TestCleanup(ForceGC),
            new TestRunner.TestCleanup(TestRunner.NoOp),
            new TestRunner.TestValidity(TestRunner.TestOK));
         tr.AddTestGroup(tgTechnique2);

         return tr.RunTests(null);
      }

      public void Technique1(Int32 numberIterations){
         for (int i = 0;i < numberIterations;++i) {
            //actual code for Technique1 here
         }
      }

      public void Technique2(Int32 numberIterations){
         for (int i = 0;i < numberIterations;++i) {
            // Technique2
         }
      }
   }
}
