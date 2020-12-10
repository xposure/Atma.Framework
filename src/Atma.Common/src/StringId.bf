using System;
namespace Atma
{
	public struct StringId : int
	{
		public this(StringView s)
		{
			this = s.GetHashCode();
		}

		public static implicit operator StringId(StringView it) => it.GetHashCode();
		public static implicit operator StringId(String it) => it.GetHashCode();
	}
}
