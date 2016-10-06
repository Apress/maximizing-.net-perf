using System;
using System.Text.RegularExpressions;

class UseRegExFromAssm {
	static void Main(string[] args) {
		string seachString = args[0];

		DotNetPerformance.RegExEng regExEng = new DotNetPerformance.RegExEng();
		foreach(Match m in regExEng.Matches(seachString))
			Console.Write(m.Value);
		Console.WriteLine();
		Console.WriteLine("Press Enter to exit");
		Console.ReadLine();
	}
}

