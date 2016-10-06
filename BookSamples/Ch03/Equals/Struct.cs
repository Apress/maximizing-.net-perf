struct S{
	//member variables
	private int _i;
	private long _j;

	//properties
	public int I{get{return _i;} set {_i = value;}}
	public long J{get{return _j;} set {_j = value;}}

	//overridden version of Equals
	public override bool Equals(object o){
		return o is S && this == (S)o;
	}

	//strongly types Equals overload
	public bool Equals(S s){
		return this == s;
	}

	//equality operator – all equality checks eventually defer here
	public static bool operator ==(S a, S b) {
		return a._i == b._i && a._j == b._j;
	}

	//inequality operator
	public static bool operator !=(S a, S b) {
		return !(a==b);
	}

	//GetHashCode implementation – types overriding Equals must override GetHashCode
	public override int GetHashCode(){
		return _i.GetHashCode() ^ _j.GetHashCode();
	}
}
