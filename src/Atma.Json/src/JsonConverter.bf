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

	public class JsonBoolConverter : JsonStructConverter<bool>
	{
		protected override void OnWriteJson(JsonWriter writer, bool* target)
		{
			if (*target)
				writer.WriteRaw("true");
			else
				writer.WriteRaw("false");
		}

		protected override bool OnReadJson(JsonReader2 reader, bool* target)
		{
			*target = false;
			if (reader.Current.type == .Number)
			{
				if (reader.Current.text != "0")
					*target = true;
			}
			else if (reader.Current.type == .Bool)
			{
				if (StringView.Compare("true", reader.Current.text, true) == 0)
					*target = true;
			}
			else
				Runtime.FatalError(scope $"Expected true/false or a number for bool.");

			reader.Next();
			return true;
		}
	}

	public abstract class JsonStructConverter<T> : JsonConverter<T>
	{
		public override void WriteJson(JsonWriter writer, Type type, void* target)
		{
			if (type.IsPointer)
			{
				let p = *(T**)target;
				if (p == null)
					writer.WriteRaw("null");
				else
					OnWriteJson(writer, p);
			}
			else if (type.IsNullable)
			{
				let n = (Nullable<T>*)target;
				if (!n.HasValue)
				{
					writer.WriteRaw("null");
				}
				else
				{
					T t = n.Value;
					OnWriteJson(writer, &t);
				}
			}
			else
				OnWriteJson(writer, (T*)target);
		}

		public override bool ReadJson(JsonReader2 reader, Type type, void* target)
		{
			if (type.IsPointer)
			{
				if (reader.Current.type == .Null)
				{
					delete (void*)*(T**)target;
					*(T**)target = null;
					reader.Next();
					return true;
				}
				else
				{
					var p = *(T**)target;
					if (p == null)
					{
						*(T**)target = new T[1]*;
						if (!OnReadJson(reader, *(T**)target))
						{
							delete (void*)*(T**)target;
							return false;
						}

						return true;
					}
					else
					{
						return OnReadJson(reader, *(T**)target);
					}
				}
			}
			else if (type.IsNullable)
			{
				let n = (Nullable<T>*)target;
				if (reader.Current.type == .Null)
				{
					*n = null;
					reader.Next();
					return true;
				}
				else
				{
					T t = ?;
					let result = OnReadJson(reader, &t);
					if (!result)
						return false;
					*n = t;
					return true;
				}
			}
			return OnReadJson(reader, (T*)target);
		}

		public override bool CanConvert(Type type)
		{
			if (type.IsPointer)
			{
				let t = (PointerType)type;
				return base.CanConvert(t.UnderlyingType);
			}
			else if (type.IsValueType)
			{
				if (type.IsNullable)
				{
					let t = (SpecializedGenericType)type;
					return base.CanConvert(t.GetGenericArg(0));
				}

				return base.CanConvert(type);
			}

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
				if (reader.Expect(.ObjectStart, ?))
				{
					for (var i < count)
					{
						if (!reader.Expect(.Field, let fieldName))
							return false;

						var foundField = false;
						for (var it in _fields)
						{
							if (StringView.Compare(it.Name, fieldName.text, true) == 0)
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
							reader.AddError(scope $"Field '{fieldName.text}' not found on type '{_type.GetName(.. scope String())}'");
							return false;
						}
					}

					if (reader.Expect(.ObjectEnd, ?))
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
				return base.CanConvert(type);

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
			public enum ParseType
			{
				Int,
				UInt,
				Float,
				Double,
			}

			private ParseType _parseType;
			public this(ParseType parseType)
			{
				_parseType = parseType;
			}

			protected override void OnWriteJson(JsonWriter writer, T* target)
			{
				let str = scope String();
				(*target).ToString(str);
				writer.WriteRaw(str);
			}

			protected override bool OnReadJson(JsonReader2 reader, T* target)
			{
				if (!reader.Expect(.Number, let token))
					return false;

				switch (_parseType) {
				case .Double:
					if (double.Parse(token.text) case .Ok(let val))
					{
						*target = (T)val;
						return true;
					}
				case .Float:
					if (float.Parse(token.text) case .Ok(let val))
					{
						*target = (T)val;
						return true;
					}
				case .Int:
					if (int64.Parse(token.text) case .Ok(let val))
					{
						*target = (T)val;
						return true;
					}
				case .UInt:
					if (uint64.Parse(token.text) case .Ok(let val))
					{
						*target = (T)val;
						return true;
					}
				}
				return false;
			}
		}

		private static List<JsonConverter> _converters = new .() ~ DeleteContainerAndItems!(_);

		static this()
		{
			_converters.Add(new JsonNumberConverter<uint8>(.UInt));
			_converters.Add(new JsonNumberConverter<uint16>(.UInt));
			_converters.Add(new JsonNumberConverter<uint32>(.UInt));
			_converters.Add(new JsonNumberConverter<uint64>(.UInt));
			_converters.Add(new JsonNumberConverter<uint>(.UInt));

			_converters.Add(new JsonNumberConverter<int8>(.Int));
			_converters.Add(new JsonNumberConverter<int16>(.Int));
			_converters.Add(new JsonNumberConverter<int32>(.Int));
			_converters.Add(new JsonNumberConverter<int64>(.Int));
			_converters.Add(new JsonNumberConverter<int>(.Int));

			_converters.Add(new JsonNumberConverter<float>(.Float));
			_converters.Add(new JsonNumberConverter<double>(.Double));
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
			if (!reader.Expect(.String, let token))
				return false;

			if (*target == null)
				*target = new String(token.text.Length);

			token.GetString(*target);
			return true;
		}
	}
}
