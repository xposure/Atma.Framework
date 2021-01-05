using System;
namespace Atma.Json.Tests
{
	class JsonStringTests
	{
		[Test]
		public static void ParseString()
		{
			var jr = scope JsonReader2();
			Assert.IsTrue(jr.Parse<String>("\"hello world\"") case .Ok(let val));
			Assert.EqualTo(val, "hello world");
			delete val;
		}

		[Test]
		public static void ParseNullString()
		{
			var jr = scope JsonReader2();
			Assert.IsTrue(jr.Parse<String>("null") case .Ok(let val));
			Assert.IsNull(val);
		}
	}
}
