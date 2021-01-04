using System;
using System.Collections;
using System.Reflection;
namespace Atma
{
	public abstract class JsonConverter
	{
		public abstract bool CanConvert(Type type);

		public bool CanRead => true;
		public bool CanWrite => true;

		public abstract void WriteJson(JsonWriter writer, Type type, void* target);
		public abstract bool ReadJson(JsonReader2 reader, Type type, void* target);
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

		public override bool ReadJson(JsonReader2 reader, Type type, void* target)
		{
			return OnReadJson(reader, (T*)target);
		}

		protected abstract void OnWriteJson(JsonWriter writer, T* target);
		protected abstract bool OnReadJson(JsonReader2 reader, T* target);
	}

	public abstract class JsonStructConverter<T> : JsonConverter<T>
	{
		public override void WriteJson(JsonWriter writer, Type type, void* target) => OnWriteJson(writer, (T*)target);
		public override bool ReadJson(JsonReader2 reader, Type type, void* target) => OnReadJson(reader, (T*)target);

		public override bool CanConvert(Type type)
		{
			if (type.IsValueType)
				return base.CanConvert(type);

			return false;
		}
	}

	public abstract class JsonObjectFactory : JsonConverter
	{
		public class ObjectConverter : JsonConverter
		{
			private Type _type;
			private List<FieldInfo> _fields = new .() ~ delete _;
			public this(Type type)
			{
				_type = type;
				for (var it in _type.GetFields())
					_fields.Add(it);
			}

			public override bool CanConvert(Type type) => _type == type;

			public override void WriteJson(JsonWriter writer, Type type, void* target)
			{
				var ptr = *(int*)target;
				if (ptr == 0)
					writer.WriteRaw("null");
				else
				{
					writer.WriteObjectStart();

					for (var it in _fields)
						writer.WriteField(it.FieldType, it.Name, (uint8*)target + it.MemberOffset);

					writer.WriteObjectEnd();
				}
			}

			public override bool ReadJson(JsonReader2 reader, Type type, void* target)
			{
				Object obj = Internal.UnsafeCastToObject(target);
				var shouldDelete = obj == null;
				void cleanUp()
				{
					if (shouldDelete)
					{
						delete obj;
						*(int*)target = 0;
					}
				}
				defer cleanUp();

				if (obj == null)
				{
					if (type.CreateObject() case .Ok(out obj))
					{
						let ptr = Internal.UnsafeCastToPtr(obj);
						*(int*)target = *(int*)ptr;
					}
					else
						Runtime.FatalError(scope $"Failed CreateObject for type '{type.GetName( .. scope String())}'");
				}


				let count = reader.Current.elements;
				if (reader.Expect(.ObjectStart))
				{
					for (var i < count)
					{
						if (!reader.Expect(.Field))
							return false;

						var foundField = false;
						for (var it in _fields)
						{
							if (StringView.Compare(it.Name, reader.Current.text, true) == 0)
							{
								foundField = true;
								reader.Next();

									//offset ptr to field value
								let ptr = (uint8*)target + it.MemberOffset;
								if (!reader.Parse(it.FieldType, ptr))
									return false;

								break;
							}
						}

						if (!foundField)
						{
							reader.AddError(scope $"Field '{reader.Current.text}' not found on type '{_type.GetName(.. scope String())}'");
							return false;
						}
					}

					if (reader.Expect(.ObjectEnd))
					{
						shouldDelete = false;
						return true;
					}
				}

				return true;
			}

		}

		private static Dictionary<Type, JsonConverter> _converters = new .() ~ DeleteDictionaryAndValues!(_);

		public override bool CanConvert(Type type)
		{
			if (type.GetCustomAttribute<SerializableAttribute>() case .Ok)
			{
				if (!_converters.TryAdd(type, ?, var ptr))
					*ptr = new ObjectConverter(type);

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

		public override bool ReadJson(JsonReader2 reader, Type type, void* target)
		{
			if (reader.Current.type == .Null)
			{
				if (*(int*)target != 0)
				{
					delete target;
					*(int*)target = 0;
				}

				return true;
			}

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

			protected override bool OnReadJson(JsonReader2 reader, T* target)
			{
				if (!reader.Expect(.Number))
					return false;

				let prev = reader.Next();
				if (double.Parse(prev.text) case .Ok(let val))
				{
					*target = (T)val;
					return true;
				}
				return false;
			}
		}

		private static List<JsonConverter> _converters = new .() ~ DeleteContainerAndItems!(_);

		static this()
		{
			_converters.Add(new JsonNumberConverter<uint8>());
			_converters.Add(new JsonNumberConverter<uint16>());
			_converters.Add(new JsonNumberConverter<uint32>());
			_converters.Add(new JsonNumberConverter<uint64>());
			_converters.Add(new JsonNumberConverter<uint>());

			_converters.Add(new JsonNumberConverter<int8>());
			_converters.Add(new JsonNumberConverter<int16>());
			_converters.Add(new JsonNumberConverter<int32>());
			_converters.Add(new JsonNumberConverter<int64>());
			_converters.Add(new JsonNumberConverter<int>());


			_converters.Add(new JsonNumberConverter<char8>());
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

		public override bool ReadJson(JsonReader2 reader, Type type, void* target)
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

		protected override bool OnReadJson(JsonReader2 reader, String* target)
		{
			if (!reader.Expect(.String))
				return false;

			if (*target == null)
				*target = new String(reader.Current.text.Length);

			reader.Current.GetString(*target);
			return true;
		}
	}
}
