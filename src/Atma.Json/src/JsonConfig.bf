using System.Collections;
using System;
namespace Atma
{
	public static class JsonConfig
	{
		internal static Dictionary<Type, JsonSerializer> _serializers;

		static ~this()
		{
			for (var it in _serializers)
				delete it.value;

			delete _serializers;
		}

		static this()
		{
			_serializers = new .();

			AddSerializer<int8>();
			AddSerializer<int16>();
			AddSerializer<int32>();
			AddSerializer<int64>();
			AddSerializer<int>();
			AddSerializer<uint8>();
			AddSerializer<uint16>();
			AddSerializer<uint32>();
			AddSerializer<uint64>();
			AddSerializer<uint>();
			AddSerializer<float>();
			AddSerializer<double>();
			AddSerializer<char8>();
			_serializers.Add(typeof(String), new JsonStringSerializer());
			_serializers.Add(typeof(bool), new JsonBoolSerializer());
		}

		public static void AddSerializer<T>()
			where T : var
		{
			_serializers.Add(typeof(T), new JsonNumberSerializer<T>());
		}

	}
}
