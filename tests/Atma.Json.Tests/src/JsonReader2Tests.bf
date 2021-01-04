using System;
namespace Atma.Json.Tests
{
	public class JsonReader2Tests
	{
		private static void ParseNumber<T>(T expected)
		{
			let jr = scope JsonReader2();
			Assert.IsTrue(jr.Parse<T>(scope $"{expected}") case .Ok(let val));
			Assert.EqualTo(val, expected);
		}

		[Test]
		public static void Test()
		{
			let jr = scope JsonReader2();
			Assert.IsTrue(jr.Parse<T>(scope $"{expected}") case .Ok(let val));
			Assert.EqualTo(val, expected);
		}
	}
}
