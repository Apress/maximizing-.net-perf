using System;
using System.Collections;
using DotNetPerformance;

namespace PerfTest.Collections{
	public class StronglyTypedTests {
		const int numberIterations = 1000000;
		private bool clearData;

		//TEST 05.10
		[Benchmark("Compares standard ArrayList vs strongly typed equivalent for doubles.", "BasicManipulationDouble")]
		public TestResultGrp BasicManipulationDouble() {	
			const int numberTestRuns = 5;
			clearData = true;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);

			TestGroup tgStrong = new TestGroup(new TestRunner.TestCase(this.StronglyTypedDouble),
				new TestRunner.TestCleanup(TestRunner.GCCollect), new TestRunner.TestCleanup(TestRunner.NoOp),
				new TestRunner.TestValidity(TestRunner.TestOK));
			tr.AddTestGroup(tgStrong);
			TestGroup tgAL = new TestGroup(new TestRunner.TestCase(this.ArrayList),
				new TestRunner.TestCleanup(TestRunner.GCCollect), new TestRunner.TestCleanup(TestRunner.NoOp),
				new TestRunner.TestValidity(TestRunner.TestOK));
			tr.AddTestGroup(tgAL);
			
			return tr.RunTests(null);
		}


		//TEST 05.08
		[Benchmark("Compares standard ArrayList vs strongly typed equivalent for ints", "BasicManipulationInt")]
		public TestResultGrp BasicManipulationInt() {	
			const int numberTestRuns = 5;
			clearData = true;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);

			TestGroup tgStrong = new TestGroup(new TestRunner.TestCase(this.StronglyTypedInt),
				new TestRunner.TestCleanup(TestRunner.GCCollect), new TestRunner.TestCleanup(TestRunner.NoOp),
				new TestRunner.TestValidity(TestRunner.TestOK));
			tr.AddTestGroup(tgStrong);

			TestGroup tgAL = new TestGroup(new TestRunner.TestCase(this.ArrayListInt),
				new TestRunner.TestCleanup(TestRunner.GCCollect), new TestRunner.TestCleanup(TestRunner.NoOp),
				new TestRunner.TestValidity(TestRunner.TestOK));
			tr.AddTestGroup(tgAL);

			return tr.RunTests(null);
		}


		//TEST 05.12
		[Benchmark("Compares standard ArrayList vs strongly typed equivalent for strings", "BasicManipulationString")]
		public TestResultGrp BasicManipulationString() {	
			const int numberTestRuns = 5;
			clearData = true;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);

			TestGroup tgStrong = new TestGroup(new TestRunner.TestCase(this.StronglyTypedString),
				new TestRunner.TestCleanup(TestRunner.GCCollect), new TestRunner.TestCleanup(TestRunner.NoOp),
				new TestRunner.TestValidity(TestRunner.TestOK));
			tr.AddTestGroup(tgStrong);

			TestGroup tgAL = new TestGroup(new TestRunner.TestCase(this.ArrayListString),
				new TestRunner.TestCleanup(TestRunner.GCCollect), new TestRunner.TestCleanup(TestRunner.NoOp),
				new TestRunner.TestValidity(TestRunner.TestOK));
			tr.AddTestGroup(tgAL);

			return tr.RunTests(null);
		}

		//TEST 05.11
		[Benchmark("Compares standard ArrayList vs strongly typed equivalent for doubles in terms of enumeration", "EnumerationDouble")]
		public TestResultGrp EnumerationDouble() {	
			clearData = false;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(0, numberTestRuns);

			//itialise test data
			const int collIncrease = 5;
			StronglyTypedDouble(numberIterations*collIncrease);
			ArrayList(numberIterations*collIncrease);

			TestGroup tgStrong = new TestGroup(new TestRunner.TestCase(this.StronglyTypedEnum),
				new TestRunner.TestCleanup(TestRunner.GCCollect), new TestRunner.TestCleanup(TestRunner.GCCollect),
				new TestRunner.TestValidity(TestRunner.TestOK));
			tr.AddTestGroup(tgStrong);
			TestGroup tgAL = new TestGroup(new TestRunner.TestCase(this.ArrayListEnum),
				new TestRunner.TestCleanup(TestRunner.GCCollect), new TestRunner.TestCleanup(TestRunner.GCCollect),
				new TestRunner.TestValidity(TestRunner.TestOK));
			tr.AddTestGroup(tgAL);
			
			return tr.RunTests(null);
		}

		//TEST 05.09
		[Benchmark("Compares standard ArrayList vs strongly typed equivalent for integers in terms of enumeration", "EnumerationInt")]
		public TestResultGrp EnumerationInt() {	
			clearData = false;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(0, numberTestRuns);

			//itialise test data
			const int collIncrease = 5;
			StronglyTypedInt(numberIterations*collIncrease);
			ArrayListInt(numberIterations*collIncrease);

			TestGroup tgStrong = new TestGroup(new TestRunner.TestCase(this.StronglyTypedEnumInt),
				new TestRunner.TestCleanup(TestRunner.GCCollect), new TestRunner.TestCleanup(TestRunner.GCCollect),
				new TestRunner.TestValidity(TestRunner.TestOK));
			tr.AddTestGroup(tgStrong);
			TestGroup tgAL = new TestGroup(new TestRunner.TestCase(this.ArrayListEnumInt),
				new TestRunner.TestCleanup(TestRunner.GCCollect), new TestRunner.TestCleanup(TestRunner.GCCollect),
				new TestRunner.TestValidity(TestRunner.TestOK));
			tr.AddTestGroup(tgAL);

			return tr.RunTests(null);
		}

		//TEST 05.13
		[Benchmark("Compares standard ArrayList vs strongly typed equivalent for strings in terms of enumeration", "EnumerationString")]
		public TestResultGrp EnumerationString() {	
			clearData = false;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(0, numberTestRuns);

			//itialise test data
			const int collIncrease = 5;
			StronglyTypedString(numberIterations*collIncrease);
			ArrayListString(numberIterations*collIncrease);

			TestGroup tgStrong = new TestGroup(new TestRunner.TestCase(this.StronglyTypedEnumString),
				new TestRunner.TestCleanup(TestRunner.GCCollect), new TestRunner.TestCleanup(TestRunner.GCCollect),
				new TestRunner.TestValidity(TestRunner.TestOK));
			tr.AddTestGroup(tgStrong);
			TestGroup tgAL = new TestGroup(new TestRunner.TestCase(this.ArrayListEnumString),
				new TestRunner.TestCleanup(TestRunner.GCCollect), new TestRunner.TestCleanup(TestRunner.GCCollect),
				new TestRunner.TestValidity(TestRunner.TestOK));
			tr.AddTestGroup(tgAL);

			return tr.RunTests(null);
		}

		StronglyTyped.Double.Collection dblColl;
		public void StronglyTypedDouble(Int32 numberIterations) {	
			dblColl = new StronglyTyped.Double.Collection();
			for (int i = 0;i < numberIterations;++i) {
				dblColl.Add((double)i);
				double d = dblColl[i];
				dblColl[i] += d;
			}
			if (clearData)
				dblColl = null;
		}

		public void StronglyTypedEnum(Int32 numberIterations) {
			double sum = 0.0;
			foreach(double d in dblColl)
				sum += d;
		}

		ArrayList al;
		public void ArrayList(Int32 numberIterations) {	
			al = new ArrayList();
			for (int i = 0;i < numberIterations;++i) {
				al.Add((double)i);
				double d = (double)al[i];
				al[i] = (double)al[i] + d;
			}
			if (clearData)
				al = null;
		}

		public void ArrayListEnum(Int32 numberIterations) {
			double sum = 0.0;
			foreach(double d in al)
				sum += d;
		}

		StronglyTyped.Int32.Collection intColl;
		public void StronglyTypedInt(Int32 numberIterations) {	
			intColl = new StronglyTyped.Int32.Collection();
			for (int i = 0;i < numberIterations;++i) {
				intColl.Add(i);
				int d = intColl[i];
				intColl[i] += d;
			}
			if (clearData)
				intColl = null;
		}

		public void StronglyTypedEnumInt(Int32 numberIterations) {
			int sum = 0;
			foreach(int d in intColl)
				sum += d;
		}

		ArrayList alInt;
		public void ArrayListInt(Int32 numberIterations) {	
			alInt = new ArrayList();
			for (int i = 0;i < numberIterations;++i) {
				alInt.Add(i);
				int d = (int)alInt[i];
				alInt[i] = (int)alInt[i] + d;
			}
			if (clearData)
				alInt = null;
		}

		public void ArrayListEnumInt(Int32 numberIterations) {
			int sum = 0;
			foreach(int d in alInt)
				sum += d;
		}

		
		StronglyTyped.String.Collection strColl;
		public void StronglyTypedString(Int32 numberIterations) {	
			strColl = new StronglyTyped.String.Collection();
			for (int i = 0;i < numberIterations;++i) {
				strColl.Add("a");
				string d = strColl[i];
			}
			if (clearData)
				strColl = null;
		}

		
		public void StronglyTypedEnumString(Int32 numberIterations) {
			string st;
			foreach(string s in strColl)
				st = s;
		}

		ArrayList alString;
		public void ArrayListString(Int32 numberIterations) {	
			alString = new ArrayList();
			for (int i = 0;i < numberIterations;++i) {
				alString.Add("a");
				string d = (string)alString[i];
			}
			if (clearData)
				strColl = null;
		}

		public void ArrayListEnumString(Int32 numberIterations) {
			string st;
			foreach(string s in alString)
				st = s;
		}
	}
}

