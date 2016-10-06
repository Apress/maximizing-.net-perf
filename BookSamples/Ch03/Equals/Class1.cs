using System;

namespace Equals
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Derived d1 = new Derived();
			Derived d2 = new Derived(1L);
			if (d1 == d2)
				Console.WriteLine("Equal");
			else
				Console.WriteLine("Not Equal");
			Console.ReadLine();
		}
	}
}
