public class Base{
	private int _i = 0;
	public int I{
		get{return _i;}
	}
	private float _j = 0;
	public float J{
		get{return _j;}
	}

	//strongly types Equals overload
	public bool Equals(Base b){
		return this == b;
	}

	//equality operator – all equality checks eventually defer here
	public static bool operator ==(Base a, Base b) {
		if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
			return false;

		return a._i == b._i && a._j == b._j;
	}

	//inequality operator
	public static bool operator !=(Base a, Base b) {
		return !(a==b);
	}

	public override bool Equals(object o){
		return (o != null && o.GetType() == this.GetType()
			&& this == (Base)o);
	}

	public override int GetHashCode(){
		return _i.GetHashCode() ^ _j.GetHashCode();
	}
}

public class Derived: Base{
	public Derived(){
		_extraData = 0L;
	}
	public Derived(long ed){
		_extraData = ed;
	}

	public long _extraData;
	public long ExtraData{
		get{return _extraData;}
	}

	public override bool Equals(object o){
		return base.Equals(o) && _extraData ==  ((Derived)o)._extraData;
	}

	public bool Equals(Derived d){
		return this == d;
	}

	public override int GetHashCode(){
		return base.GetHashCode() ^ _extraData.GetHashCode();
	}

	public static bool operator ==(Derived a, Derived b) {
		if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
			return false;

		return (Base)a == (Base)b && a._extraData == b._extraData;
	}

	public static bool operator !=(Derived a, Derived b) {
		return !(a==b);
	}
}
