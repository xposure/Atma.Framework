namespace Atma
{
	public struct SizedList<T, SIZE>
		where SIZE : const int
		where T : struct
	{
		private int _count = 0;
		private T[SIZE] _data;

		public int Size => SIZE;

		public int Count => _count;

		public ref T this[int index]
		{
			get mut
			{
				Assert.IsTrue(index >= 0 && index < SIZE);
				return ref _data[index];
			}
		}

		public void Add(T value) mut
		{
			Assert.IsTrue(_count < SIZE);
			_data[_count++] = value;
		}

		public T PopBack() mut
		{
			Assert.IsTrue(_count > 0);
			return _data[--_count];
		}

		public void Clear() mut
		{
			_count = 0;
		}
	}
}
