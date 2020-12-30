using System;
namespace Atma
{
	public class LookAheadBuffer<T>
	{
		private T[] _buffer ~ delete _;

		private int _start;
		private int _end;
		private int _size;
		private int _capacity;

		public this(int capacity)
		{
			_size = 0;
			_start = 0;
			_end = 0;
			_capacity = capacity;
			_buffer = new T[capacity];
		}

		public this(T[] items) : this(items.Count)
		{
			if (items == null)
			{
				if (items.Count > Capacity)
					Runtime.FatalError("Too many items to fit circular buffer");

				items.CopyTo(Span<T>(&_buffer[0], Capacity));
				_size = items.Count;
				_end = _size == Capacity ? 0 : _size;
			}
		}

		public int Capacity => _capacity;

		public bool IsFull
		{
			get
			{
				return Size == Capacity;
			}
		}

		public bool IsEmpty
		{
			get
			{
				return Size == 0;
			}
		}

		public int Size { get { return _size; } }

		public T Front()
		{
			ThrowIfEmpty();
			return _buffer[_start];
		}

		public T Back()
		{
			ThrowIfEmpty();
			return _buffer[(_end != 0 ? _end : Capacity) - 1];
		}

		public T this[int index]
		{
			get
			{
				if (IsEmpty)
					Runtime.FatalError(scope $"Cannot access index {index}. Buffer is empty");

				if (index >= _size)
					Runtime.FatalError(scope $"Cannot access index {index}. Buffer size is {_size}");

				int actualIndex = InternalIndex(index);
				return _buffer[actualIndex];
			}
			set
			{
				if (IsEmpty)
					Runtime.FatalError(scope $"Cannot access index {index}. Buffer is empty");

				if (index >= _size)
					Runtime.FatalError(scope $"Cannot access index {index}. Buffer size is {_size}");

				int actualIndex = InternalIndex(index);
				_buffer[actualIndex] = value;
			}
		}

		private void EnsureCapacity(int size)
		{
			if (_buffer.Count <= size)
			{
				var newCapacity = Capacity;
				while (newCapacity < size)
					newCapacity = newCapacity * 3 / 2;

				var newBuffer = new T[newCapacity];
				for (var i < Size)
					newBuffer[i] = this[i];

				_start = 0;
				_capacity = newCapacity;
				_end = _size;
				//_size = newCapacity;
				//_end = _size == Capacity ? 0 : _size;

				delete _buffer;
				_buffer = newBuffer;
			}
		}

		public void PushBack(T item)
		{
			EnsureCapacity(_size + 1);

			if (IsFull)
				Runtime.FatalError("Internal error, buffer is full.");

			_buffer[_end] = item;
			Increment(ref _end, 1);
			++_size;
		}

		public void PopFront(int count = 1)
		{
			ThrowIfEmpty("Cannot take elements from an empty buffer.");
			//_buffer[_start] = default(T);
			Increment(ref _start, count);
			_size -= count;
		}

		[Inline]
		private void ThrowIfEmpty(String message = "Cannot access an empty buffer.")
		{
			if (IsEmpty)
				Runtime.FatalError(message);
		}

		private void Increment(ref int index, int count)
		{
			//this could be optimized
			let end = (index + count) % Capacity;
			for (var i < count)
			{
				if (++index == Capacity)
				{
					index = 0;
				}
			}

			if (end != index)
				Runtime.FatalError();
		}

		[Inline]
		private int InternalIndex(int index)
		{
			return _start + (index < (Capacity - _start) ? index : index - Capacity);
		}

		public void Clear()
		{
			_start = 0;
			_end = 0;
		}
	}
}