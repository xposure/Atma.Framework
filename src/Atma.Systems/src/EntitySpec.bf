using System;
namespace Atma
{
	public class EntitySpec : IEquatable<EntitySpec>
	{
		typealias GroupType = IHashable;
		typealias GroupData = (Type Type, GroupType Data);

		public readonly int ID;
		public readonly Span<ComponentType> ComponentTypes;
		public readonly Span<GroupData> GroupData;
		public readonly int EntitySize;
		public readonly int EntityStride;

		public T GetGroupData<T>()
			where T : var
		{
			let type = typeof(T);

			for (var it in GroupData)
				if (it.Type == type)
					return (T)it.Data;

			return default;
		}

		[AllowAppend]
		public this(int id, Span<ComponentType> componentTypes, Span<GroupType> groups)
		{
			var componentPtr = append ComponentType[componentTypes.Length]*;
			var groupPtr = append GroupData[groups.Length]*;

			GroupData = .(groupPtr, groups.Length);
			for (var i < groups.Length)
				GroupData[i] = (groups[i].GetType(), groups[i]);

			ComponentTypes = .(componentPtr, componentTypes.Length);
			componentTypes.CopyTo(ComponentTypes);

			ID = id;

			let meta = ComponentTypes.EntitySize();
			EntitySize = meta.Size;
			EntityStride = meta.Stride;
		}

		[AllowAppend]
		public this(Span<ComponentType> componentTypes) : this(ComponentType.CalculateId(componentTypes), componentTypes, .(null, 0))
		{
		}

		[AllowAppend]
		internal this(GroupType[] groups, Span<ComponentType> componentTypes) :
			this(ComponentType.CalculateId(componentTypes, groups), componentTypes, .(groups))
		{
		}

		[AllowAppend]
		public this(params ComponentType[] componentTypes)//: this(0, .(componentTypes), .(null, 0))
		{
			var componentPtr = append ComponentType[componentTypes.Count]*;
			var groupPtr = append GroupData[0]*;

			GroupData = .(groupPtr, 0);

			ComponentTypes = .(componentPtr, componentTypes.Count);
			componentTypes.CopyTo(ComponentTypes);

			ID = ComponentType.CalculateId(componentTypes);

			let meta = ComponentTypes.EntitySize();
			EntitySize = meta.Size;
			EntityStride = meta.Stride;
		}

		[AllowAppend]
		public this(GroupType[] groups, params ComponentType[] componentTypes) : this(groups, .(componentTypes))
		{
		}

		public bool Has<T>(out int index)
			where T : IHashable
		{
			let type = typeof(T);
			for (index = 0; index < GroupData.Length; index++)
				if (GroupData[index].Type == type)
					return true;

			index = -1;
			return false;
		}

		public bool Has<T>(T group)
			where T : IHashable
		{
			let type = typeof(T);
			var groupHash = group.GetHashCode();
			for (var i = 0; i < GroupData.Length; i++)
				if (GroupData[i].Type == type)
					return GroupData[i].Data.GetHashCode() == groupHash;

			return false;
		}

		public bool Has<T>()
			where T : struct
		{
			return HasAll(scope ComponentType[](ComponentType<T>.Type));
		}

		public bool HasAll(EntitySpec other) => HasAll(other.ComponentTypes);

		public bool HasAll(Span<ComponentType> componentTypes) => ComponentType.HasAll(ComponentTypes, componentTypes);

		public bool HasAny(EntitySpec other) => HasAny(other.ComponentTypes);

		public bool HasAny(Span<ComponentType> componentTypes) => ComponentType.HasAny(ComponentTypes, componentTypes);

		public bool HasNone(Span<ComponentType> componentTypes) => !ComponentType.HasAny(ComponentTypes, componentTypes);
		public bool HasNone(EntitySpec other) => !HasAny(other.ComponentTypes);

		public bool Has(ComponentType type) => Has(type.ID);

		internal bool Has(int id)
		{
			for (var i = 0; i < ComponentTypes.Length; i++)
				if (ComponentTypes[i].ID == id)
					return true;

			return false;
		}

		public int FindMatches(EntitySpec other, Span<ComponentType> results)
		{
			return ComponentType.FindMatches(ComponentTypes, other.ComponentTypes, results);
		}

		internal int GetComponentIndex(int componentId)
		{
			for (var i = 0; i < ComponentTypes.Length; i++)
				if (ComponentTypes[i].ID == componentId)
					return i;
			return -1;
		}

		public int GetComponentIndex<T>() where T : struct
		{
			return GetComponentIndex(ComponentType<T>.Type.ID);
		}

		public int GetComponentIndex(ComponentType type) => GetComponentIndex(type.ID);

		public bool Equals(EntitySpec other) => this.ID == other.ID;

		public static implicit operator Span<ComponentType>(EntitySpec it) => it.ComponentTypes;


	}
}
