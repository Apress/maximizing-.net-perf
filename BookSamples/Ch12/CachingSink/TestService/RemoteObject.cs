using System;
using System.Threading;


namespace Service 
{

	public class RemoteObject: MarshalByRefObject
	{
				
		public int AddNumbers(int a, int b) 
		{
			Console.WriteLine("SomeSAO.doSomething called");
			Console.WriteLine("SomeSAO.doSomething returning");
			Console.WriteLine("Added {0} and {1}", a, b);
			return a + b;
		}
	}
}