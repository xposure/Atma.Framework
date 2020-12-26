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
		public this(EntitySpec spec)
		{
			var componentPtr = append ComponentType[spec.ComponentTypes.Length]*;
			var groupPtr = append GroupData[spec.GroupData.Length]*;

			GroupData = .(groupPtr, spec.GroupData.Length);
			for (var i < spec.GroupData.Length)
				GroupData[i] = spec.GroupData[i];

			ComponentTypes = .(componentPtr, spec.ComponentTypes.Length);
			spec.ComponentTypes.CopyTo(ComponentTypes);

			ID = spec.ID;
			EntitySize = spec.EntitySize;
			EntityStride = spec.EntityStride;
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
		public this(params ComponentType[] componentTypes) : this(0, .(componentTypes), .(null, 0))
		{
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

		public static mixin Scope<T0>(params GroupType[] groups)
			where T0 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type)); }
		public static mixin Scope<T0, T1>(params IHashable[] groups)
			where T0 : struct where T1 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type)); }
		public static mixin Scope<T0, T1, T2>(params IHashable[] groups)
			where T0 : struct where T1 : struct where T2 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type, ComponentType<T2>.Type)); }
		public static mixin Scope<T0, T1, T2, T3>(params IHashable[] groups)
			where T0 : struct where T1 : struct where T2 : struct where T3 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type, ComponentType<T2>.Type, ComponentType<T3>.Type)); }
		public static mixin Scope<T0, T1, T2, T3, T4>(params IHashable[] groups)
			where T0 : struct where T1 : struct where T2 : struct where T3 : struct where T4 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type, ComponentType<T2>.Type, ComponentType<T3>.Type, ComponentType<T4>.Type)); }
		public static mixin Scope<T0, T1, T2, T3, T4, T5>(params IHashable[] groups)
			where T0 : struct where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type, ComponentType<T2>.Type, ComponentType<T3>.Type, ComponentType<T4>.Type, ComponentType<T5>.Type)); }
		public static mixin Scope<T0, T1, T2, T3, T4, T5, T6>(params IHashable[] groups)
			where T0 : struct where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type, ComponentType<T2>.Type, ComponentType<T3>.Type, ComponentType<T4>.Type, ComponentType<T5>.Type, ComponentType<T6>.Type)); }
		public static mixin Scope<T0, T1, T2, T3, T4, T5, T6, T7>(params IHashable[] groups)
			where T0 : struct where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type, ComponentType<T2>.Type, ComponentType<T3>.Type, ComponentType<T4>.Type, ComponentType<T5>.Type, ComponentType<T6>.Type, ComponentType<T7>.Type)); }
		public static mixin Scope<T0, T1, T2, T3, T4, T5, T6, T7, T8>(params IHashable[] groups)
			where T0 : struct where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type, ComponentType<T2>.Type, ComponentType<T3>.Type, ComponentType<T4>.Type, ComponentType<T5>.Type, ComponentType<T6>.Type, ComponentType<T7>.Type, ComponentType<T8>.Type)); }
		public static mixin Scope<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(params IHashable[] groups)
			where T0 : struct where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type, ComponentType<T2>.Type, ComponentType<T3>.Type, ComponentType<T4>.Type, ComponentType<T5>.Type, ComponentType<T6>.Type, ComponentType<T7>.Type, ComponentType<T8>.Type, ComponentType<T9>.Type)); }
		public static mixin Scope<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(params IHashable[] groups)
			where T0 : struct where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type, ComponentType<T2>.Type, ComponentType<T3>.Type, ComponentType<T4>.Type, ComponentType<T5>.Type, ComponentType<T6>.Type, ComponentType<T7>.Type, ComponentType<T8>.Type, ComponentType<T9>.Type, ComponentType<T10>.Type)); }
		public static mixin Scope<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(params IHashable[] groups)
			where T0 : struct where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type, ComponentType<T2>.Type, ComponentType<T3>.Type, ComponentType<T4>.Type, ComponentType<T5>.Type, ComponentType<T6>.Type, ComponentType<T7>.Type, ComponentType<T8>.Type, ComponentType<T9>.Type, ComponentType<T10>.Type, ComponentType<T11>.Type)); }
		public static mixin Scope<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(params IHashable[] groups)
			where T0 : struct where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type, ComponentType<T2>.Type, ComponentType<T3>.Type, ComponentType<T4>.Type, ComponentType<T5>.Type, ComponentType<T6>.Type, ComponentType<T7>.Type, ComponentType<T8>.Type, ComponentType<T9>.Type, ComponentType<T10>.Type, ComponentType<T11>.Type, ComponentType<T12>.Type)); }
		public static mixin Scope<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(params IHashable[] groups)
			where T0 : struct where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct where T13 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type, ComponentType<T2>.Type, ComponentType<T3>.Type, ComponentType<T4>.Type, ComponentType<T5>.Type, ComponentType<T6>.Type, ComponentType<T7>.Type, ComponentType<T8>.Type, ComponentType<T9>.Type, ComponentType<T10>.Type, ComponentType<T11>.Type, ComponentType<T12>.Type, ComponentType<T13>.Type)); }
		public static mixin Scope<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(params IHashable[] groups)
			where T0 : struct where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct where T13 : struct where T14 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type, ComponentType<T2>.Type, ComponentType<T3>.Type, ComponentType<T4>.Type, ComponentType<T5>.Type, ComponentType<T6>.Type, ComponentType<T7>.Type, ComponentType<T8>.Type, ComponentType<T9>.Type, ComponentType<T10>.Type, ComponentType<T11>.Type, ComponentType<T12>.Type, ComponentType<T13>.Type, ComponentType<T14>.Type)); }
		public static mixin Scope<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(params IHashable[] groups)
			where T0 : struct where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct where T13 : struct where T14 : struct where T15 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type, ComponentType<T2>.Type, ComponentType<T3>.Type, ComponentType<T4>.Type, ComponentType<T5>.Type, ComponentType<T6>.Type, ComponentType<T7>.Type, ComponentType<T8>.Type, ComponentType<T9>.Type, ComponentType<T10>.Type, ComponentType<T11>.Type, ComponentType<T12>.Type, ComponentType<T13>.Type, ComponentType<T14>.Type, ComponentType<T15>.Type)); }
		public static mixin Scope<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(params IHashable[] groups)
			where T0 : struct where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct where T13 : struct where T14 : struct where T15 : struct where T16 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type, ComponentType<T2>.Type, ComponentType<T3>.Type, ComponentType<T4>.Type, ComponentType<T5>.Type, ComponentType<T6>.Type, ComponentType<T7>.Type, ComponentType<T8>.Type, ComponentType<T9>.Type, ComponentType<T10>.Type, ComponentType<T11>.Type, ComponentType<T12>.Type, ComponentType<T13>.Type, ComponentType<T14>.Type, ComponentType<T15>.Type, ComponentType<T16>.Type)); }
		public static mixin Scope<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(params IHashable[] groups)
			where T0 : struct where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct where T13 : struct where T14 : struct where T15 : struct where T16 : struct where T17 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type, ComponentType<T2>.Type, ComponentType<T3>.Type, ComponentType<T4>.Type, ComponentType<T5>.Type, ComponentType<T6>.Type, ComponentType<T7>.Type, ComponentType<T8>.Type, ComponentType<T9>.Type, ComponentType<T10>.Type, ComponentType<T11>.Type, ComponentType<T12>.Type, ComponentType<T13>.Type, ComponentType<T14>.Type, ComponentType<T15>.Type, ComponentType<T16>.Type, ComponentType<T17>.Type)); }
		public static mixin Scope<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(params IHashable[] groups)
			where T0 : struct where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct where T13 : struct where T14 : struct where T15 : struct where T16 : struct where T17 : struct where T18 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type, ComponentType<T2>.Type, ComponentType<T3>.Type, ComponentType<T4>.Type, ComponentType<T5>.Type, ComponentType<T6>.Type, ComponentType<T7>.Type, ComponentType<T8>.Type, ComponentType<T9>.Type, ComponentType<T10>.Type, ComponentType<T11>.Type, ComponentType<T12>.Type, ComponentType<T13>.Type, ComponentType<T14>.Type, ComponentType<T15>.Type, ComponentType<T16>.Type, ComponentType<T17>.Type, ComponentType<T18>.Type)); }
		public static mixin Scope<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(params IHashable[] groups)
			where T0 : struct where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct where T13 : struct where T14 : struct where T15 : struct where T16 : struct where T17 : struct where T18 : struct where T19 : struct
			{ scope EntitySpec(groups, scope ComponentType[](ComponentType<T0>.Type, ComponentType<T1>.Type, ComponentType<T2>.Type, ComponentType<T3>.Type, ComponentType<T4>.Type, ComponentType<T5>.Type, ComponentType<T6>.Type, ComponentType<T7>.Type, ComponentType<T8>.Type, ComponentType<T9>.Type, ComponentType<T10>.Type, ComponentType<T11>.Type, ComponentType<T12>.Type, ComponentType<T13>.Type, ComponentType<T14>.Type, ComponentType<T15>.Type, ComponentType<T16>.Type, ComponentType<T17>.Type, ComponentType<T18>.Type, ComponentType<T19>.Type)); }
	}
}
