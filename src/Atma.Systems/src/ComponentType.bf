/*namespace Atma
{
	using System;
	using internal Atma;

	[StaticInitPriority(2000)]
	public struct ComponentType : IHashable// IEquatable<ComponentType>
	{
		internal static LookupList<Type> _typeLookup = new LookupList<Type>();

		internal static Type LookUp(ComponentType type) => LookUp(type.ID);
		internal static Type LookUp(int id)
		{
			if (!_typeLookup.TryGetValue(id, let type))
				return UnmanagedHelper.LookUp(id);

			return type;
		}

		public readonly int ID;
		public readonly int Size;
		public readonly int Stride;

		internal this(int id, int size, int stride)
		{
			ID = id;
			Size = size;
			Stride = stride;
		}

		/*internal this(int id, int size)
		{
			ID = id;
			Size = size;
		}*/

		public int GetHashCode()
		{
			return ID;
		}

		public static int operator<=>(ComponentType lhs, ComponentType rhs) => lhs.ID <=> rhs.ID;

		public static bool operator==(ComponentType a, ComponentType b) => a.ID == b.ID;

		public static bool operator!=(ComponentType a, ComponentType b) => (a.ID != b.ID);

		public override void ToString(String strBuffer)
		{
			strBuffer.Append(scope $"Name: {LookUp(ID)}, ID: {ID}, Size: {Size}");
		}

		public static int FindMatches(Span<ComponentType> a, Span<ComponentType> b, Span<ComponentType> results)
		{
			//we need to defensively copy the arrays
			Span<ComponentType> left = scope ComponentType[a.Length];
			for (var i = 0; i < a.Length; i++)
				left[i] = a[i];

			left.InsertionSort();

			Span<ComponentType> right = scope ComponentType[b.Length];
			for (var i = 0; i < b.Length; i++)
				right[i] = b[i];
			right.InsertionSort();

			var i0 = 0;
			var i1 = 0;
			var index = 0;

			while (i0 < left.Length && i1 < right.Length)
			{
				var aType = left[i0];
				var bType = right[i1];
				if (aType.ID > bType.ID) i1++;
				else if (bType.ID > aType.ID) i0++;
				else
				{
					results[index++] = left[i0];
					//yield return aType;
					i0++;
					i1++;
				}
			}
			return index;
		}

		public static bool HasAll(Span<ComponentType> components, Span<ComponentType> match/*, bool debug = false*/)
		{
			//all the debug code is left over for future need
			//there was an issue where Entity type was always list in the array
			//when running without the debugger attached, talk about a fun thing to
			//debug.......
			//oh and it only happened when I had my sample PlayerSystem enabled

			//var entity = typeof(Entity).GetHashCode();
			Span<int> left = scope int[components.Length];
			for (var i = 0; i < components.Length; i++)
				left[i] = components[i].ID;
			left.InsertionSort();

			Span<int> right = scope int[match.Length];
			for (var i = 0; i < match.Length; i++)
				right[i] = match[i].ID;
			right.InsertionSort();

			var i0 = 0;
			var i1 = 0;

			while (i0 < left.Length && i1 < right.Length)
			{
				var aType = left[i0];
				var bType = right[i1];
				// if (aType.ID == entity)
				// {
				//     throw new Exception("You can not create an spec with Entity, this is assumed.");
				//     //i0++;
				//     //if (debug) Console.WriteLine($"aType was entity ...
				// {aType.ClrType.Name}:{bType.ClrType.Name}"); } else if (bType.ID == entity) { i1++; //if (debug)
				// Console.WriteLine($"bType was entity ... {aType.ClrType.Name}:{bType.ClrType.Name}"); } else
				if (aType > bType)
				{
					//if (debug) Console.WriteLine($"aType was > bType, exiting ...
					// {aType.ClrType.Name}:{bType.ClrType.Name}");
					return false;// i1++;
				}
				else if (bType > aType)
				{
					//if (debug) Console.WriteLine($"bType was > aType, advancing ...
					// {aType.ClrType.Name}:{bType.ClrType.Name}");
					i0++;
				}
				else
				{
					i0++;
					i1++;
					//if (debug) Console.WriteLine($"aType == bType ... {aType.ClrType.Name}:{bType.ClrType.Name}");
				}
			}

			// //entity should never be in aType, but if its the last element of bType
			// //we need to check and advance i1 pointer to move past it since its assumed
			// //to always exist
			// if (i1 < match.Length && match[i1].ID == entity)
			//     i1++;

			//if(debug) Console.WriteLine($"bSeek {i1}, len: {b.Length}");

			return i1 == match.Length;
		}


		public static bool HasAny(Span<ComponentType> components, Span<ComponentType> match)
		{
			Span<int> left = scope int[components.Length];
			for (var i = 0; i < components.Length; i++)
				left[i] = components[i].ID;
			left.InsertionSort();

			Span<int> right = scope int[match.Length];
			for (var i = 0; i < match.Length; i++)
				right[i] = match[i].ID;
			right.InsertionSort();

			var i0 = 0;
			var i1 = 0;

			while (i0 < left.Length && i1 < right.Length)
			{
				var aType = left[i0];
				var bType = right[i1];
				if (aType > bType) i1++;
				else if (bType > aType) i0++;
				else
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Calculates the ID of a given componentType
		/// </summary>
		/// <param name="types"></param>
		/// <returns></returns>
		public static int CalculateId(Span<ComponentType> types, IEntitySpecGroup[] groups = null)
		{
			Assert.GreaterThan(types.Length, 0);

			var count = types.Length;
			if (groups != null) count += groups.Length * 2;

			Span<int> hashIds = scope int[count];
			for (var i = 0; i < types.Length; i++)
				hashIds[i] = types[i].ID;

			if (groups != null)
			{
				for (var i = 0; i < groups.Length; i++)
				{
					hashIds[types.Length + i * 2] = groups[i].GetHashCode();
					hashIds[types.Length + i * 2 + 1] = groups[i].GetType().GetHashCode();
				}
			}

			hashIds.InsertionSort();

			var hashCode = scope HashCode();
			for (var i = 0; i < hashIds.Length; i++)
				hashCode.Add(hashIds[i]);

			return hashCode.ToHashCode();
		}
	}

	/*public delegate void CopyAndMoveNext(ref void* src, ref void* dst);
	public delegate void Copy(void* src, void* dst);
	public delegate void Reset(void* dst);

	public class ComponentTypeHelper
	{
		private static LookupList<ComponentTypeHelper> _helpers = new LookupList<ComponentTypeHelper>();

		public static ComponentTypeHelper Get(ComponentType componentType)
		{
			if (!_helpers.TryGetValue(componentType.ID, var componentHelper))
				return null;

			return componentHelper;
		}

		public readonly ComponentType ComponentType;
		public readonly Copy Copy;
		public readonly CopyAndMoveNext CopyAndMoveNext;
		public readonly Reset Reset;
		internal this(ComponentType componentType, Copy copy, CopyAndMoveNext copyAndMoveNext, Reset reset)
		{
			ComponentType = componentType;
			Copy = copy;
			CopyAndMoveNext = copyAndMoveNext;
			Reset = reset;
			_helpers.Add(componentType.ID, this);
		}
	}*/

	public static class ComponentType<T>
		where T : struct
	{
		public readonly static ComponentType Type;
		//public readonly static ComponentTypeHelper Helper;

		static this()
		{
			let type = typeof(T);
			Type = ComponentType((.)type.TypeId, type.Size, type.Stride);
			/*var unmanagedType = UnmanagedType<T>.Type;
			Type = new ComponentType(unmanagedType.ID, unmanagedType.Size);

			CopyAndMoveNext copyAndMoveNext = (ref void* src, ref void* dst) =>
			{
				T* srcT = (T*)src;
				T* dstT = (T*)dst;
				*dstT++ = *srcT++;
				src = srcT;
				dst = dstT;
			};
			Copy copy = (void *src, void* dst) => *(T*)dst = *(T*)src;
			Reset reset = (void* dst) => *(T*)dst = default;
			Helper = new ComponentTypeHelper(Type, copy, copyAndMoveNext, reset);

			ComponentType._typeLookup.Add(Type.ID, typeof(T));*/
		}
	}
}*/
