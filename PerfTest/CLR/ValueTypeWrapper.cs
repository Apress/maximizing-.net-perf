using System;
using DotNetPerformance;
namespace PerfTest.CLR {
	public class IntWrapper {
		private int _val;
		public IntWrapper(){}
		public IntWrapper(int val){_val = val;}
		public int val {
			get{return _val;}
			set{_val = value;}
		}
	}
	public class ValueTypeWrapper {
		[Benchmark("Compares manual reference type wrapping compared to boxing.")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 1000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(ValueTypeWrapper.Wrapper);
			testCases += new TestRunner.TestCase(ValueTypeWrapper.Boxing);
			testCases += new TestRunner.TestCase(ValueTypeWrapper.BoxingObject);
			
			return tr.RunTests(testCases);
		}

		public static void Boxing(Int32 numberIterations) {	
			Random rand = new Random();
			Array numTracker = Array.CreateInstance(typeof(int), 100);
			for (int i = 0;i < numberIterations;++i) {
				int num = rand.Next(0, 99);
				int cumulativeCount = (int)numTracker.GetValue(num);
				numTracker.SetValue(++cumulativeCount, num);
			}
		}

		public static void BoxingObject(Int32 numberIterations) {	
			Random rand = new Random();
			Array numTracker = Array.CreateInstance(typeof(object), 100);
			for (int i = 0;i < numberIterations;++i) {
				int num = rand.Next(0, 99);
				object o = numTracker.GetValue(num);
				if (o == null)
					numTracker.SetValue((int)1, num);
				else {
					int cumulativeCount = (int)o;
					numTracker.SetValue(++cumulativeCount, num);
				}
			}
		}

		public static void Wrapper(Int32 numberIterations) {	
			Random rand = new Random();
			Array numTracker = Array.CreateInstance(typeof(IntWrapper), 100);
			for (int i = 0;i < numberIterations;++i) {
				int num = rand.Next(0, 99);
				IntWrapper cumulativeCount = (IntWrapper)numTracker.GetValue(num);
				if (cumulativeCount == null)
					numTracker.SetValue(new IntWrapper(), num);
				else
					++(cumulativeCount.val);
			}
		}
	}
}
