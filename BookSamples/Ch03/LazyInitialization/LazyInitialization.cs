using System;

[Flags]
enum PopulatedFields{
	MemberVariable1		= 0x0001,
	MemberVariable2   = 0x0002
}

public class LazyInitialization {
	static void Main(){
		LazyInitialization li = new LazyInitialization();
		string s = li.AlsoPopulatedOnDemand;
		int i = li.PopulatedOnDemand;
	}

	//keeps track of populated fields
	private PopulatedFields _populationTracker;

	//actual field
	private int _populatedOnDemand;
	//method to populate field
	private int FillVariable1(){return 1;}
	//property accessor
	public int PopulatedOnDemand{
		get{
			if ((_populationTracker & PopulatedFields.MemberVariable1) == 0){
				_populatedOnDemand = FillVariable1();
				_populationTracker |= PopulatedFields.MemberVariable1;
			}
			return _populatedOnDemand;
		}
		set{
			_populationTracker |= PopulatedFields.MemberVariable1;
			_populatedOnDemand = value;
		}
	}

	private string _alsoPopulatedOnDemand;
	//read only property
	private string FillVariable2(){return "Populated";}
	public string AlsoPopulatedOnDemand{
		get{
			if ((_populationTracker & PopulatedFields.MemberVariable2) == 0){
				_alsoPopulatedOnDemand = FillVariable2();
				_populationTracker |= PopulatedFields.MemberVariable2;
			}
			return _alsoPopulatedOnDemand;
		}
	}

}
