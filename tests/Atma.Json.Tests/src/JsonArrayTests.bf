using System;
namespace Atma.Json.Tests
{
	class JsonArrayTests
	{
		[Test]
		public static void ReadArray()
		{
			{
				var jr = scope JsonReader2();
				Assert.IsTrue(jr.Parse<int[]>("[]") case .Ok(let val));
				Assert.EqualTo(val.Count, 0);
				delete val;
			}
			{
				var jr = scope JsonReader2();
				Assert.IsTrue(jr.Parse<int[]>("[0,1,2]") case .Ok(let val));
				Assert.EqualTo(val.Count, 3);
				for(var i < val.Count)
					Assert.EqualTo(val[i], i);
				delete val;
			}
			{
				var jr = scope JsonReader2();
				Assert.IsTrue(jr.Parse<int[]>("null") case .Ok(let val));
				Assert.IsNull(val);
			}
		}

		[Test]
		public static void WriteArray()
		{
			{
				let json = scope String();
				Assert.IsTrue(JsonConverter.Serialize(scope int[] (1, 2, 3), json));
				Assert.EqualTo(json, "[1,2,3]");
			}
			{
				let json = scope String();
				Assert.IsTrue(JsonConverter.Serialize(scope int[] (), json));
				Assert.EqualTo(json, "[]");
			}
			{
				let json = scope String();
				Assert.IsTrue(JsonConverter.Serialize<int[]>(null, json));
				Assert.EqualTo(json, "null");
			}
		}
	}
}
