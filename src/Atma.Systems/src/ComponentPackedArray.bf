namespace Atma
{
	using System;
	using internal Atma;

	sealed class ComponentPackedArray
	{
		private ComponentDataArray[] _componentData ~ Release(_);

		public readonly EntitySpec Specification;
		public int Length => Entity.ENTITY_MAX;

		internal this(EntitySpec specification)
		{
			Specification = specification;

			var _componentTypes = Specification.ComponentTypes;
			_componentData = new ComponentDataArray[_componentTypes.Length];
			for (var i = 0; i < _componentTypes.Length; i++)
				_componentData[i] = new ComponentDataArray(_componentTypes[i], Entity.ENTITY_MAX);
		}

		internal ComponentDataArray this[int index] => _componentData[index];

		internal void Copy(int componentIndex, ref void* src, int dstIndex, int length, bool incrementSrc)
		{
			_componentData[componentIndex].Copy(ref src, dstIndex, length, incrementSrc);
		}

		internal void Move(int src, int dst)
		{
			if (src == dst)
				return;

			Assert.Range(src, 0, Length);
			Assert.Range(dst, 0, Length);

			for (var i = 0; i < _componentData.Count; i++)
				_componentData[i].Move(src, dst);
		}

		internal void Reset(int dst)
		{
			Assert.Range(dst, 0, Length);

			for (var i = 0; i < _componentData.Count; i++)
				_componentData[i].Reset(dst);
		}

		internal void Reset<T>(int dst)
			where T : struct
		{
			Assert.Range(dst, 0, Length);
			var index = GetComponentIndex<T>();

			Assert.GreaterThan(index, -1);
			_componentData[index].Reset(dst);
		}

		internal int GetComponentIndex<T>()
			where T : struct
		{
			return Specification.GetComponentIndex(ComponentType<T>.Type);
		}

		internal Span<T> GetComponentData<T>(int index = -1, ComponentType componentType = default)
			where T : struct
		{
			var index;
			var componentType;

			if (index == -1)
				index = GetComponentIndex<T>();

			if (componentType.ID == 0)
				componentType = ComponentType<T>.Type;

			Assert.Range(index, 0, _componentData.Count);

			var componentDataArray = _componentData[index];
			return componentDataArray.AsSpan<T>(componentType);
		}

		internal static void CopyTo(ComponentPackedArray srcArray, int srcComponentIndex, int srcIndex, ComponentPackedArray dstArray, int dstComponentIndex, int dstIndex)
		{
			ComponentDataArray.CopyTo(srcArray._componentData[srcComponentIndex], srcIndex, dstArray._componentData[dstComponentIndex], dstIndex);
		}

		// internal static void CopyTo(ComponentPackedArray srcArray, Span<EntityRef> srcEntities, ComponentPackedArray
	// dstArray, Span<EntityRef> dstEntities) { //SharedComponentArrays(srcArray, dstArray, (src, dst) =>
	// ComponentDataArray.CopyTo(src, srcIndex, dst, dstIndex));

		//     Contract.EqualTo(srcEntities.Length, dstEntities.Length);
		//     if (srcEntities.Length == 0)
		//         return;

		//     var count = srcEntities.Length;

		//     var i0 = 0;
		//     var i1 = 0;

		//     Span<ComponentType> a = srcArray.Specification.ComponentTypes;
		//     Span<ComponentType> b = dstArray.Specification.ComponentTypes;
		//     while (i0 < a.Length && i1 < b.Length)
		//     {
		//         var aType = a[i0];
		//         var bType = b[i1];
		//         if (aType.ID > bType.ID) i1++;
		//         else if (bType.ID > aType.ID) i0++;
		//         else
		//         {
		//             var srcData = srcArray._componentData[i0];
		//             var dstData = dstArray._componentData[i1];
		//             for (var i = 0; i < count; i++)
		//             {

		//             }

		//             shareCallback(srcArray._componentData[i0], dstArray._componentData[i1]);
		//             i0++;
		//             i1++;
		//         }
		//     }
		// }

		// internal delegate void SharedComponentCallback(ComponentDataArray srcArray, ComponentDataArray dstArray);
		// internal static void SharedComponentArrays(ComponentPackedArray srcArray, ComponentPackedArray dstArray,
	// SharedComponentCallback shareCallback) { var i0 = 0; var i1 = 0;

		//     System.Span<ComponentType> a = srcArray.Specification.ComponentTypes;
		//     System.Span<ComponentType> b = dstArray.Specification.ComponentTypes;
		//     while (i0 < a.Length && i1 < b.Length)
		//     {
		//         var aType = a[i0];
		//         var bType = b[i1];
		//         if (aType.ID > bType.ID) i1++;
		//         else if (bType.ID > aType.ID) i0++;
		//         else
		//         {
		//             shareCallback(srcArray._componentData[i0], dstArray._componentData[i1]);
		//             i0++;
		//             i1++;
		//         }
		//     }
		// }
	}
}
