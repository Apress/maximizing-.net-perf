using System;


	public class WeakRef
	{
		public void UseWeakRef(){
			object o1 = new object();
			WeakReference wr = new WeakReference(o1);
			//object referenced by o1 can be collected here
			object o2 = wr.Target; //get reference to object back
			if (o2 != null){//check for collection
				//use o2
			}
		}
	}

