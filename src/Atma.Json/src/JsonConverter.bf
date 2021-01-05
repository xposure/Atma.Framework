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

		public static bool Serialize<T>(T t, String json)
		{
			var writer = scope JsonWriter();
#unwarn
			writer.Write<T>(json, t);
			return true;
		}

		public static Result<T> Deserialize<T>(StringView json)
		{
			var reader = scope JsonReader2();
			return reader.Parse<T>(json);
		}
	}

	public abstract class JsonConverter<T> : JsonConverter
		where T : var
	{
		private Type _type;

		public this() { _type = typeof(T); }

		public override bool CanConvert(Type type) => type == _type;

		public override void WriteJson(JsonWriter writer, Type type, void* target)
		{
			OnWriteJson(writer, type, (T*)target);
		}

		public override bool ReadJson(JsonReader2 reader, Type type, void* target)
		{
			return OnReadJson(reader, type, (T*)target);
		}

		protected abstract void OnWriteJson(JsonWriter writer, Type type, T* target);
		protected abstract bool OnReadJson(JsonReader2 reader, Type type, T* target);
	}

	public class JsonBoolConverter : JsonStructConverter<bool>
	{
		protected override void OnWriteJson(JsonWriter writer, Type type, bool* target)
		{
			if (*target)
				writer.WriteRaw("true");
			else
				writer.WriteRaw("false");
		}

		protected override bool OnReadJson(JsonReader2 reader, Type type, bool* target)
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

	public class JsonStructFactory : JsonStructConverter<void>
	{
		public override bool CanConvert(Type type)
		{
			let realType = this.[Friend]GetRealType(type);
			if (realType == null)
				return false;

			if (realType.GetCustomAttribute<SerializableAttribute>() case .Ok)
				return true;

			return false;
		}

		protected override void OnWriteJson(JsonWriter writer, Type type, void* target)
		{
			writer.WriteFields(type, target);
		}

		protected override bool OnReadJson(JsonReader2 reader, Type type, void* target)
		{
			return reader.ReadFields(type, target);
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
					OnWriteJson(writer, type, p);
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
					OnWriteJson(writer, type, &t);
				}
			}
			else
				OnWriteJson(writer, type, (T*)target);
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
						if (!OnReadJson(reader, type, *(T**)target))
						{
							delete (void*)*(T**)target;
							return false;
						}

						return true;
					}
					else
					{
						return OnReadJson(reader, type, *(T**)target);
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
					let result = OnReadJson(reader, type, &t);
					if (!result)
						return false;
					*n = t;
					return true;
				}
			}
			return OnReadJson(reader, type, (T*)target);
		}

		public override bool CanConvert(Type type)
		{
			let realType = GetRealType(type);
			if (realType == null)
				return false;

			return base.CanConvert(realType);
		}

		private Type GetRealType(Type type)
		{
			if (type.IsPointer)
			{
				let t = (PointerType)type;
				return t.UnderlyingType;
			}
			else if (type.IsValueType)
			{
				if (type.IsNullable)
				{
					let t = (SpecializedGenericType)type;
					return t.GetGenericArg(0);
				}

				return type;
			}
			return null;
		}
	}

	public class JsonArrayConverter : JsonConverter
	{
		public override bool CanConvert(Type type)
		{
			if (type.IsArray)
				return true;

			return false;
		}

		public override void WriteJson(JsonWriter writer, Type type, void* target)
		{
			var obj = Internal.UnsafeCastToObject(*(void**)target);
			if (obj == null)
			{
				writer.WriteRaw("null");
			}
			else
			{
				let arrayType = (ArrayType)type;
				let genericType = arrayType.GetGenericArg(0);
				let array = (Array)obj;
				var ptr = ((uint8*)Internal.UnsafeCastToPtr(obj) + type.InstanceSize - genericType.Size);
				writer.WriteArrayStart();
				for (var i < array.Count)
				{
					writer.WriteComma();
					writer.WriteValue(genericType, ptr);
					ptr += genericType.InstanceStride;
				}
				writer.WriteArrayEnd();
			}
		}

		public override bool ReadJson(JsonReader2 reader, Type type, void* target)
		{
			Array array = ?;

			let arrayType = (ArrayType)type;
			let genericType = arrayType.GetGenericArg(0);
			var obj = Internal.UnsafeCastToObject(*(void**)target);

			if (reader.Current.type == .Null)
			{
				if (obj != null)
					deleteObject();

				return true;
			}
			if (!reader.Expect(.ArrayStart, let token))
				return false;


			var shouldDelete = obj == null;

			if (obj == null)
			{
				if (arrayType.CreateObject((.)token.elements) case .Ok(out obj))
					array = (Array)obj;
				else
					return false;
				*(int*)target = (int)Internal.UnsafeCastToPtr(obj);
			}
			else
			{
				array = (Array)obj;
				if (array.Count < token.elements)
					Runtime.FatalError(scope $"Array was sized @{array.Count} but we needed {token.elements}");
			}

			var ptr = ((uint8*)Internal.UnsafeCastToPtr(obj) + type.InstanceSize - genericType.Size);
			for (var i < token.elements)
			{
				reader.Parse(genericType, ptr);
				ptr += genericType.InstanceStride;
			}

			if (reader.Expect(.ArrayEnd, ?))
				return true;

			if (shouldDelete)
				deleteObject();

			return false;

			void deleteObject()
			{
				delete obj;
				*(int*)target = 0;
			}
		}
	}

	public abstract class JsonObjectFactory : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, Type type, void* target)
		{
			var ptr = *(int*)target;
			if (ptr == 0)
				writer.WriteRaw("null");
			else
				writer.WriteFields(type, *(void**)target);
		}

		public override bool ReadJson(JsonReader2 reader, Type type, void* target)
		{
			//Should we support class pointers which are basically a double pointer?

			Object obj = Internal.UnsafeCastToObject(target);
			var shouldDelete = obj == null;
			void cleanUp()
			{
				if (shouldDelete)
				{
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

			if (reader.ReadFields(type, Internal.UnsafeCastToPtr(obj)))
				return true;

			if (shouldDelete)
			{
				delete obj;
				*(int*)target = 0;
			}
			return false;
			/*let count = reader.Current.elements;
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
						reader.AddError(scope $"Field '{fieldName.text}' not found on type '{_type.GetName(.. scope
		String())}'"); return false;
					}
				}

				if (reader.Expect(.ObjectEnd, ?))
				{
					shouldDelete = false;
					return true;
				}
			}

			return true;*/
		}

		public override bool CanConvert(Type type)
		{
			if (type.IsObject && type.GetCustomAttribute<SerializableAttribute>() case .Ok)
				return true;
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
			var ptr = *(T*)target;
			if (ptr == null)
				writer.WriteRaw("null");
			else
				OnWriteJson(writer, type,(T*)target);
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
				reader.Next();
				return true;
			}

			bool created = false;
			var ptr = (T*)target;
			if (*ptr == null)
			{
				*ptr = new T();
				created = true;
			}

			if (OnReadJson(reader, type, ptr))
				return true;

			if (created)
			{
				delete *ptr;
				*ptr = null;
			}
			return false;
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

			protected override void OnWriteJson(JsonWriter writer, Type type, T* target)
			{
				let str = scope String();
				(*target).ToString(str);
				writer.WriteRaw(str);
			}

			protected override bool OnReadJson(JsonReader2 reader, Type type, T* target)
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
		protected override void OnWriteJson(JsonWriter writer, Type type, String* target)
		{
			writer.WriteString(*target);
		}

		protected override bool OnReadJson(JsonReader2 reader, Type type, String* target)
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
