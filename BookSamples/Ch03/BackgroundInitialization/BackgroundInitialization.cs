using System;
using System.Threading;

public class BackgroundInitialization {
	static void Main(){
		BackgroundInitialization bi = new BackgroundInitialization();
		int i = bi.PopulatedInBackground;
	}

	private bool _backgroundPopulationDone;
	private ManualResetEvent _populationDoneEvent;

	public BackgroundInitialization(){
		_populationDoneEvent = new ManualResetEvent(false);
		ThreadPool.QueueUserWorkItem(new WaitCallback(BackgroundPopulator));
	}

	//actual field
	private int _populatedInBackground;
	//method to populate field
	private void BackgroundPopulator(object state){Thread.Sleep(5000);PopulatedInBackground = 1;}
	//property accessor
	public int PopulatedInBackground{
		get{
			if (!_backgroundPopulationDone)
				_populationDoneEvent.WaitOne();
			return _populatedInBackground;
		}
		set{
			lock (this){
				_backgroundPopulationDone = true;
				_populatedInBackground = value;
				_populationDoneEvent.Set();
			}
		}
	}
}
