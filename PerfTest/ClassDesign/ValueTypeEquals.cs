using System;
using DotNetPerformance;
using System.Runtime.InteropServices;

namespace PerfTest.ClassDesign {

	[StructLayout(LayoutKind.Explicit)]
	struct UnionDefault {
		[FieldOffset(0)] 
		public int i;
		[FieldOffset(0)] 
		public float j;
	}

	struct NormalDefault {
		public int i;
		public float j;
	}

	struct StructWithRef {
		public string s;
	}

	[StructLayout(LayoutKind.Explicit)]
	struct UnionOverride {
		[FieldOffset(0)] 
		public int i;
		[FieldOffset(0)] 
		public float j;
		public override bool Equals(object o) {
			if (o == null) return false;
			if (o.GetType() != typeof(UnionOverride)) return false;
			UnionOverride uo = (UnionOverride)o;
			return (i == uo.i && j == uo.j);
		}
		public bool Equals(UnionOverride uo) {
			return (i == uo.i);
		}
		public override int GetHashCode(){return i;}
	}
	struct S {
		private int _i;
		public int i{get{return _i;} set {_i = value;}}
		private float _j;
		public float j{get{return _j;} set {_j = value;}}

		public override bool Equals(object o){
			return o is S && this == (S)o;
		}
		public bool Equals(S s){
			return this == s;
		}
		public static bool operator ==(S a, S b) {
			return a._i == b._i && a._j == b._j;
		}
		public static bool operator !=(S a, S b) {
			return !(a==b);
		}
		public override int GetHashCode(){
			return i.GetHashCode() ^ j.GetHashCode();
		}
	}

	public class Base {
		private int _i;
		public int i{get{return _i;} set {_i = value;}
		}
		private float _j;
		public float j{get{return _j;} set {_j = value;}
		}

		public override bool Equals(object o) {
			return (o != null && o.GetType() == GetType()
				&& this == (Base)o);
		}
		public bool Equals(Base b) {
			return this == b;
		}
		public static bool operator ==(Base a, Base b) {
			return a._i == b._i && a._j == b._j;
		}
		public static bool operator !=(Base a, Base b) {
			return !(a==b);
		}
		public override int GetHashCode() {
			return i.GetHashCode() ^ j.GetHashCode();
		}
	}

	public class Derived: Base {
		private long _extraData;
		public long extraData{get{return _extraData;} set {_extraData = value;}
		}
		public override bool Equals(object o) {
			return base.Equals(o) && _extraData == ((Derived)o)._extraData;
		}
		public bool Equals(Derived d) {
			return this == d;
		}
		public static bool operator ==(Derived a, Derived b) {
			return ((Base)a == (Base)b) && a._extraData == b._extraData;
		}
		public static bool operator !=(Derived a, Derived b) {
			return !(a==b);
		}
		public override int GetHashCode() {
			return base.GetHashCode() ^ _extraData.GetHashCode();
		}
	}

	public class ValueTypeEquals {
		[Benchmark("Compares inherited ValueType.Equals method with user-defined override for value types that can and can't be compared with a bitwise comparison.")]
		public static TestResultGrp RunTest() {	
			const int numberIterations = 1000000;
			const int numberTestRuns = 5;
			TestRunner tr = new TestRunner(numberIterations, numberTestRuns);
			TestRunner.TestCase testCases = null;
			testCases += new TestRunner.TestCase(ValueTypeEquals.UnionDefaultEquals);
			testCases += new TestRunner.TestCase(ValueTypeEquals.NoStructLayoutDefaultEquals);
			testCases += new TestRunner.TestCase(ValueTypeEquals.UnionOverrideEquals);
			testCases += new TestRunner.TestCase(ValueTypeEquals.PrototypicalStructObjectEquals);
			testCases += new TestRunner.TestCase(ValueTypeEquals.PrototypicalStructCorrectTypeEquals);
			testCases += new TestRunner.TestCase(ValueTypeEquals.UnionOverrideEqualsCorrectType);
			testCases += new TestRunner.TestCase(ValueTypeEquals.StructWithRefTypeDefault);

			return tr.RunTests(testCases);
		}

		public static void StructWithRefTypeDefault(Int32 numberIterations) {	
			StructWithRef a = new StructWithRef();
			a.s = "abc";
			StructWithRef b = new StructWithRef();
			b.s = "ABC".ToLower();
			for (int i = 0;i < numberIterations;++i) {
				bool c = (a.Equals(b));
			}
		}

		public static void UnionDefaultEquals(Int32 numberIterations) {	
			UnionDefault a = new UnionDefault();
			a.i = 3;
			UnionDefault b = new UnionDefault();
			b.i = 4;
			for (int i = 0;i < numberIterations;++i) {
				bool c = (a.Equals(b));
			}
		}

		public static void NoStructLayoutDefaultEquals(Int32 numberIterations) {	
			NormalDefault a = new NormalDefault();
			a.i = 3; a.j = 3;
			NormalDefault b = new NormalDefault();
			b.i = 4; b.j = 3;
			for (int i = 0;i < numberIterations;++i) {
				bool c = (a.Equals(b));
			}
		}

		public static void UnionOverrideEquals(Int32 numberIterations) {	
			UnionOverride a = new UnionOverride();
			a.i = 3;
			UnionOverride b = new UnionOverride();
			b.i = 4;
			for (int i = 0;i < numberIterations;++i) {
				bool c = (a.Equals((object)b));
			}
		}

		public static void PrototypicalStructObjectEquals(Int32 numberIterations) {	
			S a = new S();
			a.i = 3;
			S b = new S();
			b.i = 4;
			for (int i = 0;i < numberIterations;++i) {
				bool c = (a.Equals((object)b));
			}
		}

		public static void PrototypicalStructCorrectTypeEquals(Int32 numberIterations) {	
			S a = new S();
			a.i = 3;
			S b = new S();
			b.i = 4;
			for (int i = 0;i < numberIterations;++i) {
				bool c = (a.Equals(b));
			}
		}

		public static void UnionOverrideEqualsCorrectType(Int32 numberIterations) {	
			UnionOverride a = new UnionOverride();
			a.i = 3;
			UnionOverride b = new UnionOverride();
			b.i = 4;
			for (int i = 0;i < numberIterations;++i) {
				bool c = (a.Equals(b));
			}
		}
	}
}
