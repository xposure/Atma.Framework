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
		}

		[Test]
		public static void ReadNullArray()
		{
			{
				var jr = scope JsonReader2();
				Assert.IsTrue(jr.Parse<int[]>("null") case .Ok(let val));
				Assert.IsNull(val);
			}
		}
	}
}
