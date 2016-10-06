using System;
using System.Reflection;

class App {
	static void Main(string[] args) {
		AppDomain appDomain = AppDomain.CreateDomain("WorkerDomain");
		Type remoteWorkerType = typeof(RemoteAssemblyWorker);
		RemoteAssemblyWorker remoteWorker = (RemoteAssemblyWorker)
			(appDomain.CreateInstance(remoteWorkerType.Assembly.FullName, remoteWorkerType.FullName).Unwrap());
		remoteWorker.DoStuff();
		AppDomain.Unload(appDomain);
		Console.ReadLine();
	}
}

public class RemoteAssemblyWorker: MarshalByRefObject {
	public void DoStuff(){
		Assembly dynamicallyLoadedAssembly = Assembly.Load("ClassLibrary1");
		dynamicallyLoadedAssembly.CreateInstance("ClassLibrary1.Class1");
	}
}