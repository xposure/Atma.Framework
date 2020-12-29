/*using System;
using System.IO;
namespace Atma.Json
{
	public class JsonWriter
	{
		public Result<bool> Write<T>(Stream stream)
		{
			let type = typeof(T);
			T t = default;

			if (ParseObject(type, &t, throwOnMissing))
			{
				if (_lastError.Length == 0)
					return .Ok(t);
			}

			return .Err(_lastError);
		}
	}
}*/
