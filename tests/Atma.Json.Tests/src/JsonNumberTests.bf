using System;
namespace Atma.Json.Tests
{
	class JsonNumberTests
	{
		private static void ReadNumber<T, K>(T actual, K expected)
			where K : var
		{
			let jr = scope JsonReader2();
			Assert.IsTrue(jr.Parse<T>(scope $"{expected}") case .Ok(let val));
			Assert.EqualTo((K)val, expected);
		}

		private static void ReadNumber<T>(T expected) => ReadNumber<T, T>(expected, expected);

		[Test]
		public static void ReadNumber()
		{
			for (var i < 1024)
			{
				ReadNumber<uint32>((.)i * 7);
				ReadNumber<int32>((.)i * 7);
				ReadNumber<int32>((.)i * -7);
				ReadNumber<int>((.)i * 7);
				ReadNumber<uint>((.)i * 7);
				ReadNumber<int>((.)i * -7);
			}

			ReadNumber<int>(int.MinValue);
			ReadNumber<int>(int.MaxValue);

			for (var i < 1024)
			{
				ReadNumber<float>(i / 1024);
				ReadNumber<float>(i / -1024);
				ReadNumber<double>(i / 1024);
				ReadNumber<double>(i / -1024);
			}
		}

		private static void WriteNumber<T>(T actual)
		{
			let json = scope String();
			Assert.IsTrue(JsonConverter.Serialize(actual, json));
			Assert.EqualTo(json, scope $"{actual}");
		}

		[Test]
		public static void WriteNumber()
		{
			for (var i < 1024)
			{
				ReadNumber<uint32>((.)i * 7);
				ReadNumber<int32>((.)i * 7);
				ReadNumber<int32>((.)i * -7);
				ReadNumber<int>((.)i * 7);
				ReadNumber<uint>((.)i * 7);
				ReadNumber<int>((.)i * -7);
			}

			ReadNumber<int>(int.MinValue);
			ReadNumber<int>(int.MaxValue);

			for (var i < 1024)
			{
				ReadNumber<float>(i / 1024);
				ReadNumber<float>(i / -1024);
				ReadNumber<double>(i / 1024);
				ReadNumber<double>(i / -1024);
			}
		}

		[Test]
		public static void ReadNullableNumber()
		{
			Assert.IsTrue(JsonConverter.Deserialize<int?>("null") case .Ok(let val));
			Assert.IsFalse(val.HasValue);

			for (var i < 1024)
			{
				ReadNumber<uint32?>((uint32)i * 7);
				ReadNumber<int32?>((int32)i * 7);
				ReadNumber<int32?>((int32)i * -7);
				ReadNumber<int?>((int)i * 7);
				ReadNumber<uint?>((uint)i * 7);
				ReadNumber<int?>((.)i * -7);
			}

			ReadNumber<int?>(int.MinValue);
			ReadNumber<int?>(int.MaxValue);

			for (var i < 1024)
			{
				ReadNumber<float?>((.)i / 1024);
				ReadNumber<float?>((.)i / -1024);
				ReadNumber<double?>(i / 1024);
				ReadNumber<double?>(i / -1024);
			}
		}

		[Test]
		public static void ReadPointerNumber()
		{
			{
				Assert.IsTrue(JsonConverter.Deserialize<int*>("null") case .Ok(let val));
				Assert.IsNull(val);
			}
			{
				Assert.IsTrue(JsonConverter.Deserialize<int*>("1") case .Ok(let val));
				Assert.EqualTo(*val, 1);
				delete val;
			}
		}
	}
}
