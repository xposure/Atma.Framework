using System;
namespace Atma
{
	[AttributeUsage(.Struct | .Class, .AlwaysIncludeTarget | .ReflectAttribute, ReflectUser = .All, AlwaysIncludeUser = .IncludeAllMethods | .AssumeInstantiated)]
	public struct SerializableAttribute : Attribute
	{
	}

	public abstract class JsonSerializer
	{
		public readonly Type Type;
		public abstract void Serialize(JsonWriter writer, void* target);
		public abstract bool Deserialize(JsonReader reader, void* target);
	}

	public abstract class JsonSerializer<T> : JsonSerializer
		where T : var
	{
		public this() { Type = typeof(T); }

		public override void Serialize(JsonWriter writer, void* target)
		{
			OnSerialize(writer, (T*)target);
		}

		public override bool Deserialize(JsonReader reader, void* target)
		{
			return OnDeserialize(reader, (T*)target);
		}

		protected abstract void OnSerialize(JsonWriter writer, T* target);
		protected abstract bool OnDeserialize(JsonReader reader, T* target);
	}

	public abstract class JsonStructSerializer<T> : JsonSerializer<T>
	{
		public override void Serialize(JsonWriter writer, void* target) => OnSerialize(writer, (T*)target);
		public override bool Deserialize(JsonReader reader, void* target) => OnDeserialize(reader, (T*)target);
	}

	/*public class JsonArraySerializer<T> : JsonSerializer<T>
	{
		public override void Serialize(JsonWriter writer, void* target)
		{

		}

		public override bool Deserialize(JsonReader reader, void* target)
		{

			return default;
		}
	}*/

	public class JsonNumberSerializer<T> : JsonStructSerializer<T>
		where T : var, struct
	{
		protected override void OnSerialize(JsonWriter writer, T* target)
		{
			let str = scope String();
			(*target).ToString(str);
			writer.WriteRaw(str);
		}

		protected override bool OnDeserialize(JsonReader reader, T* target)
		{
			if (reader.ParseNumber(let number))
			{
				*target = (T)number;
				return true;
			}
			return false;
		}
	}

	public class JsonBoolSerializer : JsonStructSerializer<bool>
	{
		protected override void OnSerialize(JsonWriter writer, bool* target)
		{
			if (*target == true)
				writer.WriteRaw("true");
			else
				writer.WriteRaw("false");
		}

		protected override bool OnDeserialize(JsonReader reader, bool* target)
		{
			if (reader.ParseBool(let result))
			{
				*target = result;
				return true;
			}
			return false;
		}
	}

	public abstract class JsonObjectSerializer<T> : JsonSerializer<T>
		where T : class, new, delete
	{
		public this() { Type = typeof(T); }

		public override void Serialize(JsonWriter writer, void* target)
		{
			var ptr = (T*)target;
			if (ptr == null)
				writer.WriteRaw("null");
			else
				OnSerialize(writer, ptr);
		}

		public override bool Deserialize(JsonReader reader, void* target)
		{
			bool created = false;
			var ptr = (T*)target;
			if (*ptr == null)
			{
				*ptr = new T();
				created = true;
			}

			if (!OnDeserialize(reader, ptr))
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

	public class JsonStringSerializer : JsonObjectSerializer<String>
	{
		protected override void OnSerialize(JsonWriter writer, String* target)
		{
			writer.WriteString(*target);
		}

		protected override bool OnDeserialize(JsonReader reader, String* target)
		{
			if (reader.ParseString(*target))
				return true;

			return false;
		}
	}
}
