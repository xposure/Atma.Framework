using System.Collections;
using System;
namespace Atma
{
	public class StringPool
	{
		private HashSet<String> _pool = new .() ~ DeleteContainerAndItems!(_);

		public String Get(StringView str)
		{
			if (_pool.TryAdd(scope String(str), var ptr))
				*ptr = new String(str);

			return *ptr;
		}
	}
}
