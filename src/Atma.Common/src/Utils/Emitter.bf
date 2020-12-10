using System.Collections;
using System;
using System.Reflection;
namespace Atma
{
	public class Emitter
	{
		public abstract class AbstractObserverList
		{
			public abstract void Emit(void* ptr);
		}

		public class ObserverList<K> : AbstractObserverList
		{
			public delegate void Observer(K k);
			public readonly List<Observer> Observers = new .() ~ DeleteContainerAndItems!(_);

			public override void Emit(void* ptr)
			{
				for (var it in Observers)
					it(*(K*)ptr);
			}

			public int IndexOf(Observer o)
			{
				for (var i < Observers.Count)
					if (Delegate.Equals(o, Observers[i]))
						return i;

				return -1;
			}
		}

		private Dictionary<Type, AbstractObserverList> _observers = new .() ~ DeleteDictionaryAndItems!(_);

		private List<char8> _data = new .() ~ delete _;

		public void AddObserver<K>(ObserverList<K>.Observer o)
			where K : struct
		{
			if (_observers.TryAdd(typeof(K), ?, var ptr))
				*ptr = new ObserverList<K>();

			let list = *(ObserverList<K>*)ptr;
			list.Observers.Add(o);
		}

		public void RemoveObserver<K>(ObserverList<K>.Observer o)
			where K : struct
		{
			if (!_observers.TryGetValue(typeof(K), var ptr))
				return;

			let list = (ObserverList<K>)ptr;
			let index = list.IndexOf(o);
			Assert.IsFalse(index == -1);

			delete list.Observers[index];
			list.Observers.RemoveAt(index);
		}

		public void Signal()
		{
			var buffer = _data.Ptr;
			let endBuffer = buffer + _data.Count;

			while (buffer < endBuffer)
			{
				let typeId = *((TypeId*)buffer);
				let type = Type.[Friend]GetType(typeId);
				buffer += sizeof(int32);

				if (_observers.TryGetValue(type, var list))
					list.Emit((void*)buffer);

				buffer += type.Stride;
			}
			_data.Clear();
		}

		public void Emit<K>(K k)
			where K : struct
		{
			Log.Debug(scope $"Emit :: {k}");

			let type = typeof(K);
			if (!_observers.TryGetValue(type, var ptr))
				return;

			let size = type.Stride + sizeof(int32);
			let addr = (TypeId*)_data.GrowUnitialized(size);
			*addr = type.TypeId;

			let payload = (K*)(addr + 1);
			*payload = k;
		}

		public void EmitNow<K>(K k)
			where K : struct
		{
			Log.Debug(scope $"EmitNow :: {k}");

			let type = typeof(K);
			if (!_observers.TryGetValue(type, var list))
				return;

			var k;
			list.Emit((void*)&k);
		}
	}
}
