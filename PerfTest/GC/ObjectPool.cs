using System;
using DotNetPerformance;

namespace PerfTest.GC {
	public class ObjectPoolTest {
		//TEST 07.02
		[Benchmark("Looks at hand-rolled object pool compared to reallocation.")]
		public static TestResultGrp RunTest() {
			const int numberIterations = 10000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(ObjectPoolTest.Pool);
			testCases += new TestRunner.TestCase(ObjectPoolTest.NoPool);
			
			return tr.RunTests(testCases);
		}

		public static void Pool(Int32 numberIterations) {	
			ObjectPool op = new ObjectPool(typeof(ExpensiveObject), 10, 2);
			for (int i = 0;i < numberIterations;++i) {
				ExpensiveObject eo = (ExpensiveObject)op.GetObject();
				//use
				eo.Reset();
				op.ReturnObject(eo);
			}
		}

		public static void NoPool(Int32 numberIterations) {	
			for (int i = 0;i < numberIterations;++i) {
				ExpensiveObject eo = new ExpensiveObject();
			}
		}
	}

	public class ObjectPool {
		private readonly System.Type objectType;
		private int objectsInPool;
		private readonly int growthFactor;
		private WeakReference[] pool;

		public ObjectPool(System.Type objectType, int intialCapacity, int growthFactor) {
			this.growthFactor = growthFactor;
			this.objectType = objectType;
			pool = new WeakReference[intialCapacity];
		}

		public System.Object GetObject() {
			if (objectsInPool == 0) {
				return System.Activator.CreateInstance(objectType);
			}
			else {
				while (objectsInPool != 0) {
					WeakReference w = (WeakReference)pool.GetValue(--objectsInPool);
					System.Object o = w.Target;
					if (o != null)
						return o;
				}
				return System.Activator.CreateInstance(objectType);
			}
		}

		public void ReturnObject(System.Object obj) {
			if (obj.GetType() != objectType) {
				throw new ArgumentException("Wrong type returned to pool");
			}
			if (objectsInPool >= pool.Length) {
				IncreasePoolSize();
			}
			WeakReference w = new WeakReference(obj);
			pool.SetValue(w, objectsInPool);
			++objectsInPool;
		}

		private void IncreasePoolSize() {
			WeakReference[] newPool = new WeakReference[pool.Length * growthFactor];
			Array.Copy(pool, 0, newPool, 0, pool.Length);
			pool = newPool;
		}
	}

	public class ExpensiveObject {
		private int[] a;
		public ExpensiveObject() {
			a = new int[5000];
		}

		public void Reset(){
			for(int ix = 0; ix < a.Length; ++ix)
				a[ix] = 0;
		}
	}
}
