namespace Atma
{
	using System;
	using System.Collections;
	using internal Atma;

	public sealed class EntityPool
	{
		public const int ENTITIES_BITS = 12;//4096
		public const int ENTITIES_PER_POOL = 1 << ENTITIES_BITS;
		public const int ENTITIES_MASK = ENTITIES_PER_POOL - 1;

		private List<List<Entity>> _entityMap ~ Release(_);

		private List<uint> _freeIds ~ Release(_);

		private int _free;
		private int _capacity;
		private uint _version;

		public int Capacity => _capacity;

		public int Count => _capacity - _free;

		public int Free => _free;

		public this()
		{
			_freeIds = new List<uint>(ENTITIES_PER_POOL);
			_entityMap = new List<List<Entity>>();
			//AddPage();
			//Take();
		}

		//TODO: this should be readonly to make sure versioning isn't lost?
		public ref Entity this[uint entity]
		{
			get
			{
				GetLocation(entity, let page, let index, let version);

				Assert.EqualTo(page[index].ID >> 24, version);
				return ref page[index];
			}
		}

		internal EntityRef GetRef(uint entity) => EntityRef(GetPointer(entity));

		internal Entity* GetPointer(uint entity)
		{
			//TODO should we be checking versions?
#unwarn
			var version = entity >> 24;
			var id = (int)(entity & 0xffffff);

			var index = id & ENTITIES_MASK;
			var page = id >> ENTITIES_BITS;

			Assert.Range(page, 0, _entityMap.Count);
			Assert.Range(index, 0, _entityMap[page].Count);

			var list = _entityMap[page];
			return list.Ptr + index;
		}

		public bool IsValid(uint entity)
		{
			GetLocation(entity, let page, let index, let version);
			return page[index].ID != 0 && page[index].ID == entity;
		}

		private void GetLocation(uint entity, out List<Entity> page, out int index, out uint version)
		{
			version = entity >> 24;
			var id = (int)(entity & 0xffffff);

			index = id & ENTITIES_MASK;
			var pageIndex = id >> ENTITIES_BITS;

			Assert.Range(pageIndex, 0, _entityMap.Count);
			page = _entityMap[pageIndex];

			Assert.Range(index, 0, page.Count);
		}

		private void AddPage()
		{
			var arr = new List<Entity>(ENTITIES_PER_POOL);

			_freeIds.EnsureCapacity(ENTITIES_PER_POOL, false);
			var newMax = (uint)_entityMap.Count * (uint)ENTITIES_PER_POOL + (uint)ENTITIES_PER_POOL;
			for (uint i = 0; i < ENTITIES_PER_POOL; i++)
				_freeIds.Push(newMax - i - 1);
			_free += ENTITIES_PER_POOL;
			_capacity += ENTITIES_PER_POOL;
			_entityMap.Add(arr);
		}

		public void Return(uint id)
		{
			var e = ref this[id];
			Assert.GreaterThan(e.ID, (uint)0);
			Assert.EqualTo(e.ID, id);

			e = Entity(0, 0, 0, 0);
			_freeIds.Push(id & 0xffffff);
			_free++;
		}

		public void Return(Span<EntityRef> entities)
		{
			for (var i = 0; i < entities.Length; i++)
				Return(entities[i].ID);
		}

		//TODO: I don't really see a need for this method since everything else is now using refs
		public uint Take() => TakeNext().ID;

		internal Entity* TakeNext()
		{
			if (_freeIds.Count == 0)
				AddPage();

			_free--;

			var id = _freeIds.PopBack();
			Assert.LessThanEqualTo(id, (uint)0xffffff);

			var index = (int)(id & ENTITIES_MASK);
			var page = (int)(id >> ENTITIES_BITS);

			var version = _version++;
			id |= version << 24;

			var list = _entityMap[page];
			var addr = list.Ptr + index;
			addr.ID = id;
			return addr;
		}

		public EntityRef TakeRef() => EntityRef(TakeNext());

		internal void Take(Span<EntityRef> array)
		{
			for (var i = 0; i < array.Length; i++)
				array[i] = EntityRef(TakeNext());
		}

	}
}
