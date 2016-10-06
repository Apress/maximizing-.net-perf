using System;
using DotNetPerformance;
using System.Runtime.InteropServices;

namespace PerfTest.GC {
	[StructLayout(LayoutKind.Sequential)] public class InterOpObj{
		public InterOpObj(){a = 1; b = 2; c = 3; d = 4; e = 5;}
		public int a; public int b; public int c; public int d; public int e;
	}
	public class BlockPin {
		static readonly int giveOutEveryN = 5;
		static readonly int runGCEveryN = 500;

		//TEST 07.03
		[Benchmark("Looks at effect of various pinned and active reference of GC speed")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 100000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;

			testCases += new TestRunner.TestCase(BlockPin.Start);
			testCases += new TestRunner.TestCase(BlockPin.Fragment);
			testCases += new TestRunner.TestCase(BlockPin.End);
			testCases += new TestRunner.TestCase(BlockPin.NoPinStart);
			testCases += new TestRunner.TestCase(BlockPin.NoPinFragment);
			testCases += new TestRunner.TestCase(BlockPin.NoPinEnd);
			testCases += new TestRunner.TestCase(BlockPin.TempPin);
			testCases += new TestRunner.TestCase(BlockPin.TempGCHandle);
			testCases += new TestRunner.TestCase(BlockPin.AllocationOnly);
			testCases += new TestRunner.TestCase(BlockPin.NonGCHeap);
			
			return tr.RunTests(testCases);
		}

		public static void Start(Int32 numberIterations) {	
			System.Collections.ArrayList al = new System.Collections.ArrayList();
			for (int i = 0;i < numberIterations;++i) {
				InterOpObj ioo = new InterOpObj();
				if (i < numberIterations / giveOutEveryN) {
					al.Add(GCHandle.Alloc(ioo, GCHandleType.Pinned));
				}
				if (i % runGCEveryN == 0) System.GC.Collect();
			}
			foreach(GCHandle g in al) g.Free();
			al.Clear();
			System.GC.Collect();
		}

		public static void End(Int32 numberIterations) {	
			System.Collections.ArrayList al = new System.Collections.ArrayList();
			for (int i = 0;i < numberIterations;++i) {
				InterOpObj ioo = new InterOpObj();
				if (i > ((numberIterations - numberIterations / giveOutEveryN)-1)) {
					al.Add(GCHandle.Alloc(ioo, GCHandleType.Pinned));
				}
				if (i % runGCEveryN == 0) System.GC.Collect();
			}
			foreach(GCHandle g in al) g.Free();
			al.Clear();
			System.GC.Collect();
		}

		public static void Fragment(Int32 numberIterations) {	
			System.Collections.ArrayList al = new System.Collections.ArrayList();
			for (int i = 0;i < numberIterations;++i) {
				InterOpObj ioo = new InterOpObj();
				if (i % giveOutEveryN == 0) {
					al.Add(GCHandle.Alloc(ioo, GCHandleType.Pinned));
				}
				if (i % runGCEveryN == 0) System.GC.Collect();
			}
			foreach(GCHandle g in al) g.Free();
			al.Clear();
			System.GC.Collect();
		}

		public static void NoPinStart(Int32 numberIterations) {	
			System.Collections.ArrayList al = new System.Collections.ArrayList();
			for (int i = 0;i < numberIterations;++i) {
				InterOpObj ioo = new InterOpObj();
				if (i < numberIterations / giveOutEveryN) {
					al.Add(ioo);
				}
				if (i % runGCEveryN == 0) System.GC.Collect();
			}
			al.Clear();
			System.GC.Collect();
		}

		public static void NoPinFragment(Int32 numberIterations) {	
			System.Collections.ArrayList al = new System.Collections.ArrayList();
			for (int i = 0;i < numberIterations;++i) {
				InterOpObj ioo = new InterOpObj();
				if (i < numberIterations / giveOutEveryN) {
					al.Add(ioo);
				}
				if (i % runGCEveryN == 0) System.GC.Collect();
			}
			al.Clear();
			System.GC.Collect();
		}

		public static void NoPinEnd(Int32 numberIterations) {	
			System.Collections.ArrayList al = new System.Collections.ArrayList();
			for (int i = 0;i < numberIterations;++i) {
				InterOpObj ioo = new InterOpObj();
				if (i > ((numberIterations - numberIterations / giveOutEveryN)-1)){
					al.Add(ioo);
				}
				if (i % runGCEveryN == 0) System.GC.Collect();
			}
			al.Clear();
			System.GC.Collect();
		}

		unsafe public static void TempPin(Int32 numberIterations) {	
			System.Collections.ArrayList al = new System.Collections.ArrayList();
			for (int i = 0;i < numberIterations;++i) {
				InterOpObj ioo = new InterOpObj();
				if (i % giveOutEveryN == 0) {
					fixed (int* p = &ioo.a) {
						al.Add(*p);
					}

				}
				if (i % runGCEveryN == 0) System.GC.Collect();
			}
			System.GC.Collect();
		}

		public static void TempGCHandle(Int32 numberIterations) {	
			System.Collections.ArrayList al = new System.Collections.ArrayList();
			for (int i = 0;i < numberIterations;++i) {
				InterOpObj ioo = new InterOpObj();
				if (i % giveOutEveryN == 0) {
					al.Add(GCHandle.Alloc(ioo, GCHandleType.Pinned));
					GCHandle g = (GCHandle)al[al.Count-1];
					g.Free();
				}
				if (i % runGCEveryN == 0) System.GC.Collect();
			}
			al.Clear();
			System.GC.Collect();
		}

		public static void AllocationOnly(Int32 numberIterations) {	
			System.Collections.ArrayList al = new System.Collections.ArrayList();
			for (int i = 0;i < numberIterations;++i) {
				InterOpObj ioo = new InterOpObj();
				if (i % runGCEveryN == 0) System.GC.Collect();
			}
			al.Clear();
			System.GC.Collect();
		}

		public static unsafe void NonGCHeap(Int32 numberIterations) {	
			System.Collections.ArrayList al = new System.Collections.ArrayList();
			for (int i = 0;i < numberIterations;++i) {
				InterOpObj ioo = new InterOpObj();
				if (i % giveOutEveryN == 0) {
					IntPtr mem = Marshal.AllocHGlobal(sizeof(int)*5);
					Marshal.WriteInt32(new IntPtr(mem.ToInt32() + sizeof(int)*0), ioo.a);
					Marshal.WriteInt32(new IntPtr(mem.ToInt32() + sizeof(int)*1), ioo.b);
					Marshal.WriteInt32(new IntPtr(mem.ToInt32() + sizeof(int)*2), ioo.c);
					Marshal.WriteInt32(new IntPtr(mem.ToInt32() + sizeof(int)*3), ioo.d);
					Marshal.WriteInt32(new IntPtr(mem.ToInt32() + sizeof(int)*4), ioo.e);
					al.Add(mem);
				}
				if (i % runGCEveryN == 0) System.GC.Collect();
			}
			foreach(IntPtr mem in al)
				Marshal.FreeHGlobal(mem);
			al.Clear();
			System.GC.Collect();
		}
	}
}
