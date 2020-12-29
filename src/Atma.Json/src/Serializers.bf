using System;
namespace Atma
{
	public abstract class JsonSerializer
	{
		public readonly Type Type;
		public abstract bool Deserialize(JsonReader reader, void* target);
	}

	public abstract class JsonSerializer<T> : JsonSerializer
		where T : var
	{
		public this() { Type = typeof(T); }

		public override bool Deserialize(JsonReader reader, void* target)
		{
			return OnDeserialize(reader, (T*)target);
		}

		protected abstract bool OnDeserialize(JsonReader reader, T* target);
	}

	public abstract class JsonStructSerializer<T> : JsonSerializer<T>
	{
		public override bool Deserialize(JsonReader reader, void* target) => OnDeserialize(reader, (T*)target);
	}

	public class JsonNumberSerializer<T> : JsonStructSerializer<T>
		where T : var, struct
	{
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
		protected override bool OnDeserialize(JsonReader reader, String* target)
		{
			if (reader.ParseString(*target))
				return true;

			return false;
		}
	}
}
