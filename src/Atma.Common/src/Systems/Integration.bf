using System.Collections;
using System;
using internal Atma;

namespace Atma
{
	public struct IntegratorList : IDisposable
	{
		private List<Integrator.IntegratorRef> _references = default;

		public void Add<T>(out T* value) mut
			where T : struct, operator T + T, operator T - T, operator T * float
		{
			if (_references == null)
				_references = new .();

			let it = Core.Integration.GetIntegrator<Integrator.IntegratorType<T>>();
			_references.Add(it.Add(out value));
		}

		public void AddTurn(out float* value) mut
		{
			if (_references == null)
				_references = new .();

			let it = Core.Integration.GetIntegrator<Integrator.IntegratorTurn>();
			_references.Add(it.Add(out value));
		}

		public void Dispose() mut
		{
			if (_references != null)
			{
				for (var it in ref _references)
					it.Free();

				delete _references;
				_references = null;
			}
		}

		public void Debug()
		{
			if (_references != null)
			{
				for (var it in ref _references)
					it.Debug();
			}
		}
	}

	public class Integrator
	{
		public struct IntegratorRef
		{
			public readonly IntegratorType Owner;
			public readonly int32 Page;
			public readonly uint8 Index;

			public this(IntegratorType owner, int32 page, uint8 index)
			{
				Owner = owner;
				Page = page;
				Index = index;
			}

			public void Free()
			{
				Owner.Free(Page, Index);
			}

			public void Debug()
			{
				Owner.Debug(Page, Index);
			}
		}

		public abstract class IntegratorType
		{
			public abstract void Advance();
			public abstract void Integrate(float t);
			public abstract void Free(int32 page, uint8 index);

			public abstract void Debug(int32 page, uint8 index);
		}

		public struct Data<T>
			where T : struct
		{
			public T previous;
			public T next;
			public T current;

			public void Debug(uint8 index)
			{
				let type = typeof(T);
				let name = scope String();
				type.GetName(name);
				Log.Debug(scope $"{name}[{index}] previous: {previous}, next: {next}, current: {current}");
			}
		}

		public class IntegratorType<T> : IntegratorType
			where T : struct, operator T + T, operator T - T, operator T * float
		{
			public class Page
			{
				public readonly IntegratorType Owner;
				public readonly int32 PageIndex;

				private SizedList<uint8, const 256> _free;
				private SizedList<uint8, const 256> _new;
				public Data<T>[256] Values;

				public int Available => _free.Count;


				public this(IntegratorType owner, int32 pageIndex)
				{
					Owner = owner;
					PageIndex = pageIndex;
					for (var i < 256)
						_free.Add((.)(255 - i));
				}

				public IntegratorRef Take(out T* value)
				{
					Assert.IsTrue(Available > 0);
					let index = _free.PopBack();
					_new.Add(index);
					value = &Values[index].current;
					return .(Owner, PageIndex, index);
				}

				public void Free(uint8 index)
				{
					Values[index] = default;
					_free.Add((.)index);
				}

				public void Debug(uint8 index)
				{
					Values[index].Debug(index);
				}

				public void AdvanceNew()
				{
					for (var i < _new.Count)
					{
						var it = ref Values[_new[i]];
						it.previous = it.next = it.current;
					}

					_new.Clear();
				}
			}

			protected List<Page> _pages = new .() ~ DeleteContainerAndItems!(_);

			public override void Advance()
			{
				for (var it in _pages)
					it.AdvanceNew();

				for (var it in _pages)
					NextState(ref it.Values);
			}

			protected virtual void NextState(ref Data<T>[256] data)
			{
				for (var it in ref data)
				{
					it.previous = it.next;
					it.next = it.current;
				}
			}

			public override void Integrate(float t)
			{
				for (var it in _pages)
				{
					it.AdvanceNew();

					for (var i < 256)
					{
						var data = ref it.Values[i];
						data.current = data.previous + (data.next - data.previous) * t;
					}
				}
			}

			public IntegratorRef Add(out T* t)
			{
				for (var it in _pages)
					if (it.Available > 0)
						return it.Take(out t);

				_pages.Add(new .(this, (.)_pages.Count));
				return _pages.Back.Take(out t);
			}

			public override void Free(int32 page, uint8 index)
			{
				_pages[page].Free(index);
			}

			public override void Debug(int32 page, uint8 index)
			{
				_pages[page].Debug(index);
			}
		}

		public class IntegratorTurn : IntegratorType<float>
		{
			[Inline]
			public static float AngleDifference(float angle1, float angle2)
			{
				float diff = (angle2 - angle1 + 0.5f) % 1 - 0.5f;
				return diff < -0.5f ? diff + 1f : diff;
			}

			protected override void NextState(ref Data<float>[256] data)
			{
				for (var it in ref data)
				{
					it.previous = it.next;
					it.next = it.previous + AngleDifference(it.previous, it.current);
				}
			}
		}

		private Dictionary<int32, IntegratorType> _integrators = new .() ~ DeleteDictionaryAndItems!(_);

		internal T GetIntegrator<T>()
			where T : IntegratorType
		{
			let typeid = typeof(T).TypeId;
			if (_integrators.TryAdd(typeid, ?, var ptr))
				*ptr = new T();

			return *(T*)ptr;
		}

		internal void Advance()
		{
			for (var it in _integrators.Values)
				it.Advance();
		}

		internal void Integrate(float t)
		{
			for (var it in _integrators.Values)
				it.Integrate(t);
		}
	}
}
