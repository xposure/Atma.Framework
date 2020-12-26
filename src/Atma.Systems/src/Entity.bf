namespace Atma
{
	using System;
	using internal Atma;

	public struct EntityRef
	{
		/*public static readonly Comparison<EntityRef> KeySortDesc = new Comparison<EntityRef>( (x, y) => (int)(y.Key -
		x.Key)); public static readonly Comparison<EntityRef> KeySort = new Comparison<EntityRef>( (x, y) => (int)(x.Key
		- 	y.Key));*/
		private readonly Entity* _entity;
		public uint ID => _entity.ID;
		public uint Key => _entity.Key;
		public bool IsValid => ID > 0;

		public int SpecIndex => _entity.SpecIndex;
		public int ChunkIndex => _entity.ChunkIndex;
		public int Index { get => _entity.Index; internal set => _entity.Index = value; }

		internal this(Entity* ptr)
		{
			_entity = ptr;
		}

		internal void Replace(Entity entity)
		{
			*_entity = entity;
		}

		public override void ToString(String output) => _entity.ToString(output);
	}

	public struct Entity//: IEquatable<Entity>, IEquatable<uint>, IComparable<Entity>, IComparable<uint>
	{
		//public static readonly Comparison<Entity> EntityComparer = new Comparison<Entity>( (x, y) => (int)(x.Key -
		// y.Key)); we have 32 bits to play with here
		public const int SPEC_BITS = 12;
		public const int CHUNK_BITS = 10;
		public const int ENTITY_BITS = 10;

		public const int SPEC_MAX = 1 << SPEC_BITS;
		public const int CHUNK_MAX = 1 << CHUNK_BITS;
		public const int ENTITY_MAX = 1 << ENTITY_BITS;

		public const int SPEC_SHIFT = ENTITY_BITS + CHUNK_BITS;
		public const int CHUNK_SHIFT = CHUNK_BITS;

		public const uint ENTITY_MASK = (1 << ENTITY_BITS) - 1;
		public const uint CHUNK_MASK = ((1 << CHUNK_SHIFT) - 1) << ENTITY_BITS;
		public const uint SPEC_MASK = ((1 << SPEC_SHIFT) - 1) ^ ENTITY_MASK ^ CHUNK_MASK;
		public const uint SPECCHUNK_MASK = SPEC_MASK + CHUNK_MASK;

		public uint ID;
		public uint Key;

		public bool IsValid => ID > 0;
		//public uint Version => ID >> 24;

		public int SpecIndex => (int)(Key >> SPEC_SHIFT);//no need to mask
		public int ChunkIndex => (int)((Key & CHUNK_MASK) >> CHUNK_SHIFT);
		public int Index
		{
			get => (int)(Key & ENTITY_MASK);
			internal set mut
			{
				var index = (uint)(value & ENTITY_MASK);
				Key = (Key & SPECCHUNK_MASK) | index;
			}
		}

		public this(uint id, int specIndex, int chunkIndex, int index)
		{
			Assert.Range(specIndex, 0, SPEC_MAX);
			Assert.Range(chunkIndex, 0, CHUNK_MAX);
			Assert.Range(index, 0, ENTITY_MAX);

			ID = id;//(uint)(id & 0xfffff) | (uint)version << 24;

			Key = (uint)(specIndex << SPEC_SHIFT) +
				(uint)((chunkIndex << CHUNK_SHIFT) & CHUNK_MASK) +
				(uint)(index & ENTITY_MASK);

			// Assert(SpecIndex == specIndex);
			// Assert(ChunkIndex == chunkIndex);
			// Assert(Index == index);
		}

		// public override int GetHashCode() => ID;

		// public bool Equals(Entity2 other) => ID == other.ID;

		// public bool Equals(int other) => ID == other;

		// public static bool operator ==(Entity2 left, Entity2 right) => left.ID == right.ID && left.Key == right.Key;
		// public static bool operator !=(Entity2 left, Entity2 right) => left.ID != right.ID && left.Key == right.Key;
		// public static bool operator ==(Entity2 left, int right) => left.ID == right;
		// public static bool operator !=(Entity2 left, int right) => left.ID != right;
		// public static bool operator ==(int left, Entity2 right) => left == right.ID;
		// public static bool operator !=(int left, Entity2 right) => left != right.ID;

		public override void ToString(String output) => output.Append(scope $"[ Spec: {SpecIndex}, Chunk: {ChunkIndex}, Index: {Index}, ID: {ID} ]");

			/*public bool Equals(Entity other) => this.ID == other.ID && this.Key == other.Key;

			public bool Equals(uint other) => this.ID == other;
			public int CompareTo(Entity other) => (int)(Key - other.Key);

			//We want to sort on entity ID without the versioning bytes
			public int CompareTo(uint other) => (int)((ID & 0x00ffffff) - (other & 0x00ffffff));*/
	}
}

		