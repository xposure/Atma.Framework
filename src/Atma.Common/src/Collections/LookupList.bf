using System.Collections;
namespace Atma
{
	typealias LookupList<T> = LookupList<int, T>;

	public class LookupList<Key, Value>
		where bool : operator Key == Key
	{
		private List<Key> _indexLookup;
		private List<Value> _data;

		public int Count => _indexLookup.Count;

		public this(int initialSize = 8)
		{
			_indexLookup = new List<Key>(initialSize);
			_data = new List<Value>(initialSize);
		}

		public IEnumerable<Key> AllKeys => _indexLookup;
		public IEnumerable<Value> AllObjects => _data;

		public Value this[Key id]
		{
			get
			{
				var index = IndexOf(id);
				Assert.GreaterThanEqualTo(index, 0);

				return _data[index];
			}
			set
			{
				var index = IndexOf(id);
				Assert.GreaterThanEqualTo(index, 0);

				_data[index] = value;
			}
		}

		public void Add(Key id, Value t)
		{
			_indexLookup.Add(id);
			_data.Add(t);
		}

		public int IndexOf(Key id)
		{
			for (var i = 0; i < _indexLookup.Count; i++)
				if (_indexLookup[i] == id)
					return i;

			return -1;
		}

		public bool TryGetValue(Key id, out Value t)
		{
			var index = IndexOf(id);
			if (index == -1)
			{
				t = default;
				return false;
			}

			t = _data[index];
			return true;
		}

		public void Remove(Key id)
		{
			var index = IndexOf(id);
			Assert.GreaterThanEqualTo(index, 0);

			_indexLookup.RemoveAt(index);
			_data.RemoveAt(index);
		}

		public void RemoveFast(Key id)
		{
			var index = IndexOf(id);
			Assert.GreaterThanEqualTo(index, 0);

			_indexLookup.RemoveAtFast(index);
			_data.RemoveAtFast(index);
		}
	}
}
