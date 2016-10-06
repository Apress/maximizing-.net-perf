using System;

namespace JITInterface {
	class Class1 {
		[STAThread]
		static void Main(string[] args) {
		}
	}

	interface IExpensive{int MethodA(); int MethodB();}

	class JITInterface: IExpensive{
		//normal class stuff
		public int i;
		public virtual int UnrelatedMethod(){return i;}
		//other unrelated methods

		//JIT Interface Implementation
		private JITInterfaceImpl impl;
		private void CheckImpl(){if (impl == null) impl = new JITInterfaceImpl ();}
		public virtual int MethodA(){CheckImpl(); return impl.MethodA();}
		public virtual int MethodB(){CheckImpl(); return impl.MethodB();}
	}

	class JITInterfaceImpl: JITInterface {
		private int a, b, c, d, e, f; //used for IExpensive
		public JITInterfaceImpl (){
			; //initialize member variables
		}
		public override int MethodA() {return 0;} //some calculation involving member variables
		public override int MethodB() {return 0;} //some calculation involving member variables
	}

}
