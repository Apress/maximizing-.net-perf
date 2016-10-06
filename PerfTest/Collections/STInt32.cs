using System;
using System.Collections;
using T = System.Int32;

namespace StronglyTyped.Int32{
	[Serializable]
	public class Collection : IList, ICollection, IEnumerable, ICloneable {
		//members
		private T[] _data;
		private int _size;
		internal int _version;
		private static int _defaultCapacity = 16;

		//constructors
		public Collection() {
			_data = new T[_defaultCapacity];
		}

		public Collection(Collection x) {
			_data = new T[x.Count * 2];
			AddRange(x);
		}

		public Collection(T[] x) {
			_data = new T[x.Length * 2];
			AddRange(x);
		}

		//properties
		public T this[int index] {
			get {	
				if (index >= _size)
					throw new ArgumentOutOfRangeException("index");
				return _data[index];
			}
			set {
				if (index >= _size)
					throw new ArgumentOutOfRangeException("index");
				++_version;
				_data[index] = value;
			}
		}

		object IList.this[int index] {
			get {	
				if (index >= _size)
					throw new ArgumentOutOfRangeException("index");
				return _data[index];
			}
			set {
				if (index >= _size)
					throw new ArgumentOutOfRangeException("index");
				++_version;
				_data[index] = (T)value;
			}
		}

		bool IList.IsFixedSize{
			get{	return false;}
		}

		bool IList.IsReadOnly{
			get{	return false;}
		}

		
		public int Count{
			get{	return _size;}
		}

		bool ICollection.IsSynchronized{
			get{	return _data.IsSynchronized;}
		}

		object ICollection.SyncRoot{
			get{	return _data.SyncRoot;}
		}

		// Methods
		private void EnsureCapacity(int capacity){
			int currentCapacity = _data != null? _data.Length: 0;
			if (currentCapacity >= capacity)
				return;
			if (currentCapacity == 0)
				SetCapacity(_defaultCapacity);
			else
				SetCapacity(currentCapacity * 2);
		}

		public void SetCapacity(int capacity){
			int currentCapacity = _data != null? _data.Length: 0;
			if (currentCapacity == capacity)
				return;
			if (currentCapacity > capacity)
				throw new ArgumentOutOfRangeException("value", "ArgumentOutOfRange_SmallCapacity");
			T[] temp = new T[capacity];
			if (_data != null)
				System.Array.Copy(_data, 0, temp, 0, currentCapacity);
			_data = temp;
		}

		public void Clear(){
			_size = 0;
			_data = null;
			++_version;
		}

		int IList.Add(object val){
			return Add((T)val);
		}

		public int Add(T x) {
			EnsureCapacity(_size + 1);
			++_version;
			_data[_size] = x;
			return _size++;
		}

		public void AddRange(T[] x) {
			for (int i=0; i < x.Length; ++i)
				Add(x[i]);
		}

		public void AddRange(Collection x) {
			for (int i=0; i < x.Count; ++i)
				Add(x[i]);
		}

		bool IList.Contains(object x) {return Contains((T)x);}
		public bool Contains(T x) {
			for(int cnt = 0; cnt < _size; ++cnt){
				if (_data[cnt] == x)
					return true;
			}
			return false;
		}

		public void CopyTo(T[] array, int index) {
			System.Array.Copy(_data, 0, array, 0, _size);
		}

		int IList.IndexOf(object x) {return IndexOf((T)x);}
		public int IndexOf(T x) {
			for(int cnt = 0; cnt < _size; ++cnt){
				if (_data[cnt] == x)
					return cnt;
			}
			return -1;
		}

		void IList.Insert(int index, object x) {Insert(index, (T)x);}
		public void Insert(int index, T x) {
			if (index > _size)
				throw new ArgumentOutOfRangeException("index");
			++_version;
			if (index == _size){
				this.Add(x);
				return;
			}
			T[] tail = new T[_size-index];
			Array.Copy(_data, index, tail, 0, _size-index);
			_data[index] = x;
			Array.Copy(tail, 0, _data, index + 1,  _size-index);
			++_size;
		}

		void IList.Remove(object x) {Remove((T)x);}
		public void Remove(T x) {
			for(int cnt = 0; cnt < _size; ++cnt){
				if (_data[cnt] == x){
					IList il = (IList)this;
					il.RemoveAt(cnt);
					return;
				}
			}
		}

		void IList.RemoveAt(int index){
			if (index > _size)
				throw new ArgumentOutOfRangeException("index");
			++_version;
			T[] tail = new T[_size-index];
			Array.Copy(_data, index+1, tail, 0, _size-index-1);
			Array.Copy(tail, 0, _data, index,  _size-index-1);
			--_size;
			return;
		}

		void ICollection.CopyTo(Array array, int index){
			Array.Copy(_data, 0, array, index, _size);
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return new Enumerator(this);
		}

		public Enumerator GetEnumerator() {
			return new Enumerator(this);
		}

		object ICloneable.Clone(){
			Collection c = new Collection();
			c._size = this._size;
			c._data = (T[])_data.Clone();
			return c;
		}
	}

	public class Enumerator : IEnumerator {
		private Collection temp;
		private T curr;
		private int cursor;
		private int _version;

		public Enumerator(Collection col) {
			temp = col;
			cursor = -1;
			_version = col._version;
		}

		public void Reset() { cursor = -1; curr = (T)0; }

		public T Current {
			get {
				return curr;
			}
		}

		object IEnumerator.Current {
			get {
				return Current; 
			}
		}

		public bool MoveNext() {
			if (_version != temp._version)
				throw new System.InvalidOperationException("Underlying collection has changed.");
			++cursor; 
			if (cursor < temp.Count) {
				curr = temp[cursor];
				return true;
			}
			else
				return false;
		}
	}
}
