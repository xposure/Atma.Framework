using System;
using System.IO;
using System.Collections;
using System.Reflection;
namespace Atma
{
	using internal Atma;

	public class JsonWriter
	{
		private struct JsonWriterOptions
		{
			public bool PrettyPrint = false;
		}

		private Stream _stream;
		private JsonWriterOptions _options;
		private int _depth = 0;
		private int _count = 0;
		private List<int> _elements = new .() ~ delete _;

		public int Write<T>(Stream stream, T t, JsonWriterOptions options = default)
		{
			_stream = stream;
			_depth = 0;
			_options = options;
			_elements.Clear();
#unwarn
			WriteObject(typeof(T), &t);
			return _count;
		}

		public void WriteRaw(char8 msg)
		{
			_stream.Write(msg);
			_count++;
		}

		public void WriteRaw(StringView msg)
		{
			_stream.Write(msg);
			_count += msg.Length;
		}

		private void WriteTabs()
		{
			WriteRaw("\n");
			WriteRaw(scope String('\t', _depth));
		}

		public void WriteArrayStart()
		{
			_elements.Add(0);
			WriteRaw("[");
		}

		public void WriteArrayEnd()
		{
			_elements.PopBack();
			WriteRaw("]");
		}

		public void WriteObjectStart()
		{
			_elements.Add(0);
			WriteRaw("{");
			if (_options.PrettyPrint)
			{
				WriteTabs();
				_depth++;
			}
		}

		public void WriteComma()
		{
			var element = ref _elements.Back;
			if (element > 0)
			{
				WriteRaw(',');
				if (_options.PrettyPrint)
					WriteTabs();
			}

			element++;
		}

		public void WriteObjectEnd()
		{
			_elements.PopBack();
			if (_options.PrettyPrint)
			{
				_depth--;
				WriteTabs();
			}
			WriteRaw("}");
		}

		public void WriteString(StringView text)
		{
			WriteRaw("\"");
			for (var it in text)
			{
				switch (it) {
				case '\"': WriteRaw("\\\"");
				case '\n': WriteRaw("\\n");
				case '\r': WriteRaw("\\r");
				case '\\': WriteRaw("\\");
				case '\b': WriteRaw("\\b");
				case '\f': WriteRaw("\\f");
				case '\t': WriteRaw("\\t");
				default:
					WriteRaw(it);
				}
			}
			WriteRaw("\"");
		}

		public void WriteObject(Type type, void* target)
		{
			//if we have a custom serializer, we use it
			if (JsonConfig._serializers.TryGetValue(type, let serializer))
			{
				serializer.Serialize(this, target);
			}
			else
			{
				if (type.IsObject || type.IsValueType)
				{
					WriteFields(type, target);
				}
				else if (type.IsPointer)
				{
					WriteFields(type, *(void**)target);
				}
				/*else if (type.IsValueType)
				{
					let ptr = (uint8*)target;
					WriteArrayStart();
					for (var i < type.Size)
					{
						WriteComma();
						WriteRaw(scope $"{ptr[i]}");
					}
					WriteArrayEnd();
				}*/
				else
					Runtime.FatalError("Not supported.");
			}
		}

		private void WriteFields(Type type, void* target)
		{
			let fields = scope List<FieldInfo>();
			for (var it in type.GetFields())
				fields.Add(it);

			WriteObjectStart();
			for (var it in fields)
			{
				WriteComma();
				WriteString(it.Name);
				WriteRaw(':');

				let ptr = (uint8*)target + it.MemberOffset;
				if (it.FieldType.IsObject || it.FieldType.IsPointer)
					WriteObject(it.FieldType, *(void**)ptr);
				else if (it.FieldType.IsValueType)
					WriteObject(it.FieldType, ptr);
				else
					Runtime.FatalError("Not supported");
			}
			WriteObjectEnd();
		}
	}
}
