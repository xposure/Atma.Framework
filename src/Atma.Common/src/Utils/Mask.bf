using System;

namespace Atma
{
	/// <summary>
	/// A Struct for managing Masks
	/// </summary>
	public struct Mask : uint64
	{
		public const uint64 All = 0xFFFFFFFFFFFFFFFF;
		public const uint64 None = 0;
		//public const uint64 Default = (1 << 0);

		public this(uint64 value)
		{
			this = value;
		}

		[Inline]
		public void Set(uint64 mask, bool state) mut
		{
			if (state)
				Add(mask);
			else
				Remove(mask);
		}

		[Inline]
		public void Set(Mask mask, bool state) mut
		{
			if (state)
				Add(mask);
			else
				Remove(mask);
		}

		[Inline]
		public void Add(Mask mask) mut
		{
			this |= mask;
		}

		
		[Inline]
		public void Add(uint64 mask) mut
		{
			this |= mask;
		}

		[Inline]
		public void Remove(Mask mask) mut
		{
			this &= ~mask;
		}

		[Inline]
		public void Remove(uint64 mask) mut
		{
			this &= ~mask;
		}
		
		[Inline]
		public bool Has(uint64 mask)
		{
			return (this & mask) > 0;
		}

		[Inline]
		public bool Has(Mask mask)
		{
			return (this & mask) > 0;
		}

		[Inline]
		public static Mask Make(int index)
		{
			System.Diagnostics.Debug.Assert(index >= 0 && index < 64);

			return (((uint64)1 << index));
		}

		/*[Inline]
		public static Mask operator|(Mask a, Mask b) => (a | b);

		[Inline]
		public static Mask operator&(Mask a, Mask b) => (a & b);*/

		/*public static implicit operator uint64(Mask mask) => mask;
		public static implicit operator Mask(uint64 val) => (val);*/

	}
}

