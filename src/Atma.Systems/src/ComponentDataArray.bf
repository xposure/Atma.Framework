namespace Atma
{
	using System;
	using internal Atma;



	sealed class ComponentDataArray//: UnmanagedDispose
	{
		public readonly int ElementSize;
		public readonly int ElementStride;

		public readonly int Length;

		private readonly ComponentType _componentType;
		private readonly ComponentTypeHelper _componentHelper;

		[Inline]
		internal uint8* Memory => ((uint8*)Internal.UnsafeCastToPtr(this) + typeof(Self).InstanceSize);

			[AllowAppend]
		internal this(ComponentType componentType, int length)
		{
			#unwarn
			let memoryPtr = append uint8[componentType.Stride * length]*;

			ElementSize = componentType.Size;
			ElementStride = componentType.Stride;
			Length = length;

			_componentType = componentType;
			_componentHelper = ComponentTypeHelper.Get(componentType);
		}

		public Span<T> AsSpan<T>(int start = 0, int length = -1)
			where T : struct
		{
			var componentType = ComponentType<T>.Type;
			Contract.EqualTo(componentType.ID, _componentType.ID);
			return AsSpan<T>(componentType, start, length);
		}

		internal Span<T> AsSpan<T>(ComponentType componentType, int start = 0, int length = -1)
			where T : struct
		{
			var length;
			if (length == -1)
				length = Length;

			Assert.Range(start, 0, Length);
			Assert.Range(start + length - 1, start, Length);
			Contract.EqualTo(componentType.ID, _componentType.ID);
			var src = (T*)Memory;
			return .(src + start, length);
		}


		internal void Reset(int index)
		{
			Assert.Range(index, 0, Length);

			var addr = Memory;
			var dst = addr + index * ElementStride;

			_componentHelper.Reset(dst);
		}

		internal void Move(int srcIndex, int dstIndex)
		{
			if (srcIndex == dstIndex)
				return;

			Assert.Range(srcIndex, 0, Length);
			Assert.Range(dstIndex, 0, Length);

			var addr = Memory;
			var src = addr + srcIndex * ElementStride;
			var dst = addr + dstIndex * ElementStride;

			_componentHelper.Copy(src, dst);

#if DEBUG
			_componentHelper.Reset(src);
#endif
		}

		internal void Copy(ref void* ptr, int dstIndex, int length, bool incrementSrc)
		{
			var length;
			Assert.Range(dstIndex, 0, Length - length + 1);
			var addr = Memory;
			var dst = (void*)(addr + dstIndex * ElementStride);

			if (!incrementSrc)
			{
				while (length-- > 0)
				{
					var savePtr = ptr;
					_componentHelper.CopyAndMoveNext(ref savePtr, ref dst);
				}
			}
			else
			{
				while (length-- > 0)
					_componentHelper.CopyAndMoveNext(ref ptr, ref dst);
			}
		}

		internal void Copy(void* ptr, int dstIndex)
		{
			Assert.Range(dstIndex, 0, Length);
			var addr = Memory;
			var dst = addr + dstIndex * ElementStride;

			_componentHelper.Copy(ptr, dst);
		}

		internal static void CopyTo(ComponentDataArray srcArray, int srcIndex, ComponentDataArray dstArray, int dstIndex)
		{
			Assert.EqualTo(srcArray._componentType.ID, dstArray._componentType.ID);
			Assert.Range(srcIndex, 0, srcArray.Length);
			Assert.Range(dstIndex, 0, dstArray.Length);

			var srcAddr = srcArray.Memory;
			var dstAddr = dstArray.Memory;
			var src = srcAddr + srcIndex * srcArray.ElementStride;
			var dst = dstAddr + dstIndex * srcArray.ElementStride;

			srcArray._componentHelper.Copy(src, dst);

#if DEBUG
			srcArray._componentHelper.Reset(src);
#endif
		}
	}
}