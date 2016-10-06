using System;

namespace LoadTest
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class App
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			HiResTimer hrt = new HiResTimer();

			hrt.Start();
			M();
			hrt.Stop();

			Console.WriteLine("{0}", hrt.ElapsedMicroseconds);
			Console.ReadLine();
		}

		static void M(){
			System.Reflection.Assembly.Load("LargeAssembly,Version=1.0.0.0,Culture=Neutral,PublicKeyToken=70f65fbdd69f8509");
		}
	}
}
