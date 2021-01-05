using System.Collections;
using System;
namespace Atma
{
	public static class JsonConfig2
	{
		internal static List<JsonConverter> _converters = new .() ~ DeleteContainerAndItems!(_);

		static this()
		{
			//_converters.Add(new JsonBoolConverter());
			_converters.Add(new JsonArrayConverter());
			_converters.Add(new JsonNumberConverter());
			_converters.Add(new JsonStringConverter());
			_converters.Add(new JsonBoolConverter());
		}

		public static bool GetConverter(Type type, out JsonConverter converter)
		{
			for (var it in _converters)
				if (it.CanConvert(type))
				{
					converter = it;
					return true;
				}

			converter = null;
			return false;
		}
	}


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
