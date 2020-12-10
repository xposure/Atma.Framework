namespace Atma
{
	public struct Flags
	{
		public uint64 Value;

		public void Set(uint64 flags) mut
		{
			Value |= flags;
		}

		public void Clear(uint64 flags) mut
		{
			Value &= (uint64.MaxValue ^ flags);
		}

		public bool Has(uint64 flags) => (Value & flags) == flags;

		public bool Any(uint64 flags) => (Value & flags) != 0;
	}
}
