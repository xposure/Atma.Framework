/*namespace Atma
{
	using System;
	using System.Reflection;
	using System.Threading;
	using System.Collections;
	using internal Atma;

	public struct UnmanagedType
	{
		internal static int UniqueID;

		public readonly int32 ID;
		public readonly int32 Size;

		internal this(Type type, int32 size)
		{
			ID = (.)type.TypeId;// type.FullName.StableHashCode();
			Size = size;
		}
		/*internal this(int32 id, int32 size)
		{
			ID = id;// type.GetHashCode();// type.FullName.StableHashCode();
			Size = size;
		}*/
	}

	public static class UnmanagedType<T>
		where T : struct
	{
		public static readonly UnmanagedType Type;

		static this()
		{
			var size = sizeof(T);
			//var type = UnmanagedType.UniqueID++;
			Type = UnmanagedType(typeof(T), size);
		}
	}

	public struct UnknownType
	{
	}

	public sealed class UnmanagedHelper
	{
		internal static LookupList<Type> _typeLookup = new LookupList<Type>();

		public static Type LookUp(int id)
		{
			if (!_typeLookup.TryGetValue(id, let type))
				return typeof(UnknownType);

			return type;
		}

		private Dictionary<Type, bool> _unmanagedCache = new Dictionary<Type, bool>();
		private Dictionary<Type, UnmanagedType> _cacheTypes = new Dictionary<Type, UnmanagedType>();

		public bool IsUnManaged(Type t)
		{
			var result = false;
			if (_unmanagedCache.ContainsKey(t))
				return _unmanagedCache[t];
			else if (t.IsPrimitive || t.IsPointer || t.IsEnum)
				result = true;
			else if (t.IsGenericType || !t.IsValueType)
				result = false;
			else
				result = t.GetFields(BindingFlags.Public |
					BindingFlags.NonPublic | BindingFlags.Instance)
					.All(x => IsUnManaged(x.FieldType));

			_unmanagedCache.Add(t, result);
			return result;
		}

		public bool GetInfo(Type t, out UnmanagedType unmanagedType)
		{
			unmanagedType = default;
			if (!IsUnManaged(t))
				return false;

			if (!_cacheTypes.TryGetValue(t, out unmanagedType))
			{
				var size = Size.Of(t);
				unmanagedType = new UnmanagedType(t, size);
				_cacheTypes.Add(t, unmanagedType);
				_typeLookup.TryAdd(unmanagedType.ID, t);
			}

			return true;
		}
	}
}*/
