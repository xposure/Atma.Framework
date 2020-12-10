/*using System.Collections;
using System;

namespace Atma
{
	public class ObjectPool<T>
	{
		typealias ObjectPoolItem = (int PoolIndex, T)
		private List<T> _items = new .() ~ Release(_);
		private List<int> _free = new .() ~ Release(_);


	}

	public extension ObjectPool<T>
		where T : class, new
	{
		public int Take()
		{
			if (_free.Count == 0)
			{
				_free.Add(_items.Count);
				_items.Add(new T());
			}

			return _free.PopBack();
		}

		public void Free(int index)
		{
			_free.Add(t);
		}
	}

	public class ObjectPool2<T>
		where T : delete, class, new
	{
		private List<T> _items = new .() ~ DeleteContainerAndItems!(_);
		private List<T> _free = new .() ~ delete _;

		public T Take()
		{
			if (_free.Count == 0)
				_free.Add(new T());
		}

		public T Free()
		{
		}
	}
}*/
