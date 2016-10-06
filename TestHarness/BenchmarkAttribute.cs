using System;

namespace DotNetPerformance {
	[AttributeUsage(AttributeTargets.Method)]
	public class BenchmarkAttribute: System.Attribute {
		public BenchmarkAttribute(string motivation) {
			_motivation = motivation;
		}

		public BenchmarkAttribute(string motivation, string testName) {
			_motivation = motivation;
			_name = testName;
		}
	
		private string _motivation;
		public string Motivation{get{return _motivation;}}

		private string _name = String.Empty;
		public string TestName{get{return _name;}}
	}
}
