using System;
namespace Atma.Json.Tests
{
	public class JsonReader2Tests
	{
		private static void ParseNumber<T, K>(T actual, K expected)
			where K : var
		{
			let jr = scope JsonReader2();
			Assert.IsTrue(jr.Parse<T>(scope $"{expected}") case .Ok(let val));
			Assert.EqualTo((K)val, expected);
		}

		private static void ParseNumber<T>(T expected) => ParseNumber<T, T>(expected, expected);

		[Test]
		public static void ParseNumber()
		{
			for (var i < 1024)
			{
				ParseNumber<uint32>((.)i * 7);
				ParseNumber<int32>((.)i * 7);
				ParseNumber<int32>((.)i * -7);
				ParseNumber<int>((.)i * 7);
				ParseNumber<uint>((.)i * 7);
				ParseNumber<int>((.)i * -7);
			}

			ParseNumber<int>(int.MinValue);
			ParseNumber<int>(int.MaxValue);

			for (var i < 1024)
			{
				ParseNumber<float>(i / 1024);
				ParseNumber<float>(i / -1024);
				ParseNumber<double>(i / 1024);
				ParseNumber<double>(i / -1024);
			}
		}

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

		[Test]
		public static void ParseBool()
		{
			{
				var jr = scope JsonReader2();
				Assert.IsTrue(jr.Parse<bool>("true") case .Ok(let val));
				Assert.EqualTo(val, true);
			}
			{
				var jr = scope JsonReader2();
				Assert.IsTrue(jr.Parse<bool>("false") case .Ok(let val));
				Assert.EqualTo(val, false);
			}
			{
				var jr = scope JsonReader2();
				Assert.IsTrue(jr.Parse<bool?>("null") case .Ok(let val));
				Assert.IsFalse(val.HasValue);
			}
			{
				var jr = scope JsonReader2();
				Assert.IsTrue(jr.Parse<bool?>("true") case .Ok(let val));
				Assert.IsTrue(val.HasValue);
				Assert.EqualTo(val.Value, true);
			}
			{
				var jr = scope JsonReader2();
				Assert.IsTrue(jr.Parse<bool?>("false") case .Ok(let val));
				Assert.IsTrue(val.HasValue);
				Assert.EqualTo(val.Value, false);
			}
			{
				var jr = scope JsonReader2();
				Assert.IsTrue(jr.Parse<bool*>("null") case .Ok(let val));
				Assert.IsNull(val);
			}
			{
				var jr = scope JsonReader2();
				Assert.IsTrue(jr.Parse<bool*>("true") case .Ok(let val));
				Assert.EqualTo(*val, true);
				delete val;
			}
			{
				var jr = scope JsonReader2();
				Assert.IsTrue(jr.Parse<bool*>("false") case .Ok(let val));
				Assert.EqualTo(*val, false);
				delete val;
			}
		}
	}
}
