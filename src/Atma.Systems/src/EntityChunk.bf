namespace Atma
{
	using System;
	using System.Collections;
	using internal Atma;

	public sealed class EntityChunk
	{
		private List<EntityRef> _entityRefs ~ delete _;

		internal ReadOnlySpan<EntityRef> Entities => _entityRefs.Slice();
		internal readonly ComponentPackedArray PackedArray ~ delete _;

		public int Count => _entityRefs.Count;
		public int Free => Entity.ENTITY_MAX - Count;

		public readonly EntitySpec Specification;

		public readonly int SpecIndex;
		public readonly int ChunkIndex;


		internal this(EntitySpec specifcation, int specIndex, int chunkIndex)
		{
			Specification = new EntitySpec(specifcation);
			PackedArray = new ComponentPackedArray(specifcation);
			_entityRefs = new List<EntityRef>(PackedArray.Length);
			SpecIndex = specIndex;
			ChunkIndex = chunkIndex;
		}

		internal void Create(EntityRef entity)
		{
			Create(scope EntityRef[](entity));
		}

		internal int Create(Span<EntityRef> entities)
		{
			var amountToCreate = entities.Length > Free ? Free : entities.Length;
			for (var i = 0; i < amountToCreate; i++)
			{
				var entity = ref entities[i];
				var id = entity.ID;

				entity.Replace(Entity(id, SpecIndex, ChunkIndex, _entityRefs.Count));
				_entityRefs.Add(entity);
			}
			return amountToCreate;
		}

		internal void Delete(EntityRef entity)
		{
			Delete(scope EntityRef[](entity));
		}

		internal void Delete(Span<EntityRef> entities)
		{
			for (var i = 0; i < entities.Length; i++)
			{
				var entity = ref entities[i];
				var index = entity.Index;
				if (_entityRefs.RemoveAtWithSwap(index, true))
				{
					PackedArray.Move(_entityRefs.Count, index);
					_entityRefs[index].Index = index;
				}
			}
		}

		public Span<T> GetComponentData<T>(int index = -1)
			where T : struct
		{
			return PackedArray.GetComponentData<T>(index).Slice(0, _entityRefs.Count);
		}

		internal Span<T> GetComponentData<T>(int index, ComponentType componentType = default)
			where T : struct
		{
			return PackedArray.GetComponentData<T>(index, componentType).Slice(0, _entityRefs.Count);
		}
	}
}