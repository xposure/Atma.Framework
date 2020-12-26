namespace Atma
{
	using System;
	using System.Collections;
	using internal Atma;

	public sealed class EntityArrayList : IEnumerable<EntityChunkList>
	{
		private LookupList<List<EntityChunkList>> _specMapping = new LookupList<List<EntityChunkList>>();
		private LookupList<EntitySpec> _knownSpecs = new LookupList<EntitySpec>();
		private List<EntityChunkList> _entityArrays = new List<EntityChunkList>();
		public ReadOnlySpan<EntityChunkList> EntityArrays => .(_entityArrays.Ptr, _entityArrays.Count);

		public int Count => _entityArrays.Count;

		public this()
		{
		}

		internal int GetOrCreateSpec(EntitySpec spec)
		{
			var specIndex = _knownSpecs.IndexOf(spec.ID);
			if (specIndex == -1)
			{
				//we are limited to this many unique specs per EM
				specIndex = _knownSpecs.Count;
				Assert.LessThan(specIndex, Entity.SPEC_MAX);
				_knownSpecs.Add(spec.ID, spec);

				var array = new EntityChunkList(spec, specIndex);
				_entityArrays.Add(array);
				for (var i = 0; i < spec.ComponentTypes.Length; i++)
				{
					if (!_specMapping.TryGetValue(spec.ComponentTypes[i].ID, var lists))
					{
						lists = new List<EntityChunkList>();
						_specMapping.Add(spec.ComponentTypes[i].ID, lists);
					}

					lists.Add(array);
				}
			}
			return specIndex;
		}

		internal int EntityCount(ComponentType type)
		{
			if (!_specMapping.TryGetValue(type.ID, let lists))
				return -1;

			var count = 0;
			for (var i = 0; i < lists.Count; i++)
				count += lists[i].EntityCount;

			return count;
		}

		internal int EntityCount()
		{
			var count = 0;
			for (var i = 0; i < _entityArrays.Count; i++)
				count += _entityArrays[i].EntityCount;

			return count;
		}

		public int EntityCount<T>() where T : struct { return EntityCount(ComponentType<T>.Type); }

		internal List<EntityChunkList> FindSmallest(EntitySpec spec) => FindSmallest(spec.ComponentTypes);
		internal List<EntityChunkList> FindSmallest(Span<ComponentType> componentTypes)
		{
			List<EntityChunkList> current = null;// = _specMapping[componentTypes[0].ID];
			var count = -1;//EntityCount(componentTypes[0]);

			for (var i = 0; i < componentTypes.Length; i++)
			{
				var nextCount = EntityCount(componentTypes[i]);
				if (nextCount > count)
					current = _specMapping[componentTypes[i].ID];
			}

			return current;
		}

		/*public IEnumerable<EntityChunkList> Filter(EntitySpec contains, EntitySpec exclude = default)
		{
			var smallest = FindSmallest(contains);
			if (smallest != null)
			{
				for (var i = 0; i < smallest.Count; i++)
				{
					var array = smallest[i];
					if (array.Specification.HasAll(contains.ComponentTypes)
						&& (exclude.ID == 0 || array.Specification.HasNone(exclude)))
						yield return array;
				}
			}
		}*/

		internal int GetOrCreateSpec(Span<ComponentType> componentTypes)
		{
			var specId = ComponentType.CalculateId(componentTypes);
			var specIndex = _knownSpecs.IndexOf(specId);
			if (specIndex == -1)
				return GetOrCreateSpec(new EntitySpec(specId, componentTypes, .(null, 0)));

			return specIndex;
		}

		public EntityChunkList this[int index]
		{
			get
			{
				return _entityArrays[index];
			}
		}

		public EntityChunkList this[EntitySpec spec]
		{
			get
			{
				var index = GetOrCreateSpec(spec);
				return _entityArrays[index];
			}
		}
		public EntityChunkList this[Span<ComponentType> componentTypes]
		{
			get
			{
				var index = GetOrCreateSpec(componentTypes);
				return _entityArrays[index];
			}
		}


		public List<EntityChunkList>.Enumerator GetEnumerator() => _entityArrays.GetEnumerator();

	}

	public static class EntityArrayListExtensions
	{
		public static void Filter(this EntityArrayList it, Span<ComponentType> componentTypes, Action<EntityChunkList> result) => it.Filter(componentTypes, Span<ComponentType>.Empty, result);
		public static void Filter(this EntityArrayList it, Span<ComponentType> componentTypes, Span<ComponentType> excludedComponents, Action<EntityChunkList> result)
		{
			var smallest = it.FindSmallest(componentTypes);
			if (smallest != null)
			{
				for (var i = 0; i < smallest.Count; i++)
				{
					var array = smallest[i];
					if (array.Specification.HasAll(componentTypes)
						&& (excludedComponents.IsEmpty || array.Specification.HasNone(excludedComponents)))
						result(array);
				}
			}
		}
	}
}