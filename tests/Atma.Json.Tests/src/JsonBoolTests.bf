using System;
namespace Atma.Json.Tests
{
	class JsonBoolTests
	{
		[Test]
		public static void ReadBool()
		{
			{
				Assert.IsTrue(JsonConverter.Deserialize<bool>("true") case .Ok(let val));
				Assert.EqualTo(val, true);
			}
			{
				Assert.IsTrue(JsonConverter.Deserialize<bool>("false") case .Ok(let val));
				Assert.EqualTo(val, false);
			}
		}

		[Test]
		public static void WriteBool()
		{
			{
				let json = scope String();
				Assert.IsTrue(JsonConverter.Serialize<bool>(true, json));
				Assert.EqualTo(json, "true");
			}
			{
				let json = scope String();
				Assert.IsTrue(JsonConverter.Serialize<bool>(false, json));
				Assert.EqualTo(json, "false");
			}
		}

		[Test]
		public static void ReadNullableBool()
		{
			{
				Assert.IsTrue(JsonConverter.Deserialize<bool?>("null") case .Ok(let val));
				Assert.IsFalse(val.HasValue);
			}
			{
				Assert.IsTrue(JsonConverter.Deserialize<bool?>("true") case .Ok(let val));
				Assert.IsTrue(val.HasValue);
				Assert.EqualTo(val.Value, true);
			}
			{
				Assert.IsTrue(JsonConverter.Deserialize<bool?>("false") case .Ok(let val));
				Assert.IsTrue(val.HasValue);
				Assert.EqualTo(val.Value, false);
			}
		}

		[Test]
		public static void WriteNullableBool()
		{
			{
				let json = scope String();
				Assert.IsTrue(JsonConverter.Serialize<bool?>(null, json));
				Assert.EqualTo(json, "null");
			}
			{
				let json = scope String();
				Assert.IsTrue(JsonConverter.Serialize<bool?>(true, json));
				Assert.EqualTo(json, "true");
			}
			{
				let json = scope String();
				Assert.IsTrue(JsonConverter.Serialize<bool?>(false, json));
				Assert.EqualTo(json, "false");
			}
		}

		[Test]
		public static void ReadPointerBool()
		{
			{
				Assert.IsTrue(JsonConverter.Deserialize<bool*>("null") case .Ok(let val));
				Assert.IsNull(val);
			}
			{
				Assert.IsTrue(JsonConverter.Deserialize<bool*>("true") case .Ok(let val));
				Assert.EqualTo(*val, true);
				delete val;
			}
			{
				Assert.IsTrue(JsonConverter.Deserialize<bool*>("false") case .Ok(let val));
				Assert.EqualTo(*val, false);
				delete val;
			}
		}
		
		[Test]
		public static void WritePointerBool()
		{
			{
				let json = scope String();
				Assert.IsTrue(JsonConverter.Serialize<bool*>(null, json));
				Assert.EqualTo(json, "null");
			}
			{
				let json = scope String();
				Assert.IsTrue(JsonConverter.Serialize<bool*>(scope bool[1]* ( true ), json));
				Assert.EqualTo(json, "true");
			}
			{
				let json = scope String();
				Assert.IsTrue(JsonConverter.Serialize<bool*>(scope bool[1]* ( false ), json));
				Assert.EqualTo(json, "false");
			}
		}
	}
}
