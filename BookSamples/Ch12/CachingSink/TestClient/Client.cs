using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Services;
using System.Threading;
using Service; // from service.dll

namespace Client
{

	class Client
	{
		private delegate int DelMeth(int a, int b);

		static void Main(string[] args)
		{
			String filename = "client.exe.config";
			RemotingConfiguration.Configure(filename);

			Console.WriteLine("q to exit, number, number to call mathod, ,a at the end for async. call, Enter to call remote object");
			
			string s;
			try{
				while ((s = Console.ReadLine()) != "q"){
					RemoteObject obj = new RemoteObject();
					int res;
					string[] arr = s.Split(new char[]{','});
					if (arr.Length < 2)
						continue;
					int a = Convert.ToInt32(arr[0]);
					int b = Convert.ToInt32(arr[1]);
					if (s.IndexOf('a') != -1){
						DelMeth meth = new DelMeth(obj.AddNumbers);
						IAsyncResult ar = meth.BeginInvoke(a, b, null, null);
						res = meth.EndInvoke(ar);
					}
					else
						res = obj.AddNumbers(a, b);
					Console.WriteLine("Got result: {0}",res);
				}
			}
			catch(Exception ex){
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
				Console.ReadLine();
			}
		}	
	}
}

