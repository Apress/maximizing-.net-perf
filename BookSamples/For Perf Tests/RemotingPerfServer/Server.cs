using System;
using System.Text;
using System.Runtime.Remoting;

namespace RemotingPerfServer
{
	class Server
	{
		[STAThread]
		static void Main(string[] args)
		{
			RemotingConfiguration.Configure("RemotingPerfServer.exe.config");
			Console.WriteLine("RemotingPerfServer started OK.  Press any key to exit.");
			Console.Read();
		}
	}
}
