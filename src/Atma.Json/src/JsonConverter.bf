/*using System;
using System.Collections;
namespace Atma
{
	public abstract class JsonConverter
	{
		public abstract bool CanConvert(Type type);

		public bool CanRead => true;
		public bool CanWrite => true;

		public abstract void WriteJson(JsonWriter writer, Type type, void* target);
		public abstract bool ReadJson(JsonReader writer, Type type, void* target);
	}

	public abstract class JsonConverter<T> : JsonConverter
		where T : var
	{
		private Type _type;

		public this() { _type = typeof(T); }

		public override bool CanConvert(Type type) => type == _type;

		public override void WriteJson(JsonWriter writer, Type type, void* target)
		{
			OnWriteJson(writer, (T*)target);
		}

		public override bool ReadJson(JsonReader reader, Type type, void* target)
		{
			return OnReadJson(reader, (T*)target);
		}

		protected abstract void OnWriteJson(JsonWriter writer, T* target);
		protected abstract bool OnReadJson(JsonReader reader, T* target);
	}

	public abstract class JsonStructConverter<T> : JsonConverter<T>
	{
		public override void WriteJson(JsonWriter writer, Type type, void* target) => OnWriteJson(writer, (T*)target);
		public override bool ReadJson(JsonReader reader, Type type, void* target) => OnReadJson(reader, (T*)target);

		public override bool CanConvert(Type type)
		{
			if (type.IsValueType)
				base.CanConvert(type);

			return false;
		}
	}

	public abstract class JsonObjectFactory : JsonConverter
	{
		public abstract class ObjectConverter
		{
			private Type _type;
			public this(Type type)
			{
				_type = type;
			}

			public void WriteJson(JsonWriter writer, Type type, void* target)
			{
				var ptr = *(int*)target;
				if (ptr == 0)
					writer.WriteRaw("null");
				else
				{

				}	
			}

			public bool ReadJson(JsonReader reader, Type type, void* target)
			{
				bool created = false;
				var ptr = (T*)target;
				if (*ptr == null)
				{
					*ptr = new T();
					created = true;
				}

				if (!OnReadJson(reader, ptr))
				{
					if (created)
					{
						delete *ptr;
						*ptr = null;
					}
					return false;
				}

				return true;
			}

		}

		private static Dictionary<Type, JsonConverter> _converters = new .() ~ DeleteDictionaryAndItems!(_);

		public override bool CanConvert(Type type)
		{
			if (type.GetCustomAttribute<SerializableAttribute>() case .Ok)
			{
				if (_converters.TryGetValue(type, ?))
					return true;
			}
			return false;
		}
	}

	public abstract class JsonObjectConverter<T> : JsonConverter<T>
		where T : class, new, delete
	{
		public override bool CanConvert(Type type)
		{
			if (type.IsObject)
				base.CanConvert(type);

			return false;
		}

		public override void WriteJson(JsonWriter writer, Type type, void* target)
		{
			var ptr = (T*)target;
			if (ptr == null)
				writer.WriteRaw("null");
			else
				OnWriteJson(writer, ptr);
		}

		public override bool ReadJson(JsonReader reader, Type type, void* target)
		{
			bool created = false;
			var ptr = (T*)target;
			if (*ptr == null)
			{
				*ptr = new T();
				created = true;
			}

			if (!OnReadJson(reader, ptr))
			{
				if (created)
				{
					delete *ptr;
					*ptr = null;
				}
				return false;
			}

			return true;
		}
	}

	public class JsonNumberConverter : JsonConverter
	{
		public class JsonNumberConverter<T> : JsonStructConverter<T>
			where T : var, struct
		{
			protected override void OnWriteJson(JsonWriter writer, T* target)
			{
				let str = scope String();
				(*target).ToString(str);
				writer.WriteRaw(str);
			}

			protected override bool OnReadJson(JsonReader reader, T* target)
			{
				if (reader.ParseNumber(let number))
				{
					*target = (T)number;
					return true;
				}
				return false;
			}
		}

		private static List<JsonConverter> _converters = new .() ~ DeleteContainerAndItems!(_);

		static this()
		{
			_converters.Add(new JsonNumberConverter<char8>());

			_converters.Add(new JsonNumberConverter<uint8>());
			_converters.Add(new JsonNumberConverter<uint16>());
			_converters.Add(new JsonNumberConverter<uint32>());
			_converters.Add(new JsonNumberConverter<uint64>());

			_converters.Add(new JsonNumberConverter<int8>());
			_converters.Add(new JsonNumberConverter<int16>());
			_converters.Add(new JsonNumberConverter<int32>());
			_converters.Add(new JsonNumberConverter<int64>());

			_converters.Add(new JsonNumberConverter<int>());
			_converters.Add(new JsonNumberConverter<uint>());

			_converters.Add(new JsonNumberConverter<float>());
			_converters.Add(new JsonNumberConverter<double>());
		}

		public override bool CanConvert(Type type)
		{
			for (var it in _converters)
				if (it.CanConvert(type))
					return true;

			return false;
		}

		public override void WriteJson(JsonWriter writer, Type type, void* target)
		{
			for (var it in _converters)
			{
				if (it.CanConvert(type))
				{
					it.WriteJson(writer, type, target);
					return;
				}
			}
		}

		public override bool ReadJson(JsonReader reader, Type type, void* target)
		{
			for (var it in _converters)
				if (it.CanConvert(type))
					return it.ReadJson(reader, type, target);

			return false;
		}
	}

	public class JsonStringConverter : JsonObjectConverter<String>
	{
		protected override void OnWriteJson(JsonWriter writer, String* target)
		{
			writer.WriteString(*target);
		}

		protected override bool OnReadJson(JsonReader reader, String* target)
		{
			if (reader.ParseString(*target))
				return true;

			return false;
		}
	}
}*/
