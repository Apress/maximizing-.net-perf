using System;
using System.Reflection;
using System.Text.RegularExpressions;

class RegExToAssm {
	static void Main(string[] args) {
		string name = args[0];
		string nameSpace = args[1];
		string assmNameStr = args[2];
		string regExString = args[3];
		RegexOptions options = (RegexOptions)Convert.ToInt32(args[4]);
		
		RegexCompilationInfo info = new RegexCompilationInfo(regExString, options, name, nameSpace, true);
		AssemblyName assmName = new AssemblyName();
		assmName.Name = assmNameStr;

		Regex.CompileToAssembly(new RegexCompilationInfo[]{info}, assmName);

		Console.WriteLine("Regular expression successfully compiled to " + assmNameStr);
	}
}
