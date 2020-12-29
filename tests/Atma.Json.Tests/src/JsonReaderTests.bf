using System;
using System.IO;
namespace Atma.Json.Tests
{
	using internal Atma;

	class JsonReaderTests
	{
		public static void Parse<T>(StringView value, T expected)
			where T : struct
		{
			String Data = scope $"{value}";

			let jr = scope JsonReader();
			Assert.IsTrue(jr.Parse<T>(Data) case .Ok(let val));
			//Assert.EqualTo(jr.LookAhead() case .Ok(let token), token.IsEOF);
			Assert.IsTrue(val === expected);
		}

		public static void Parse<T>(StringView value, T expected)
			where T : class, delete
		{
			String Data = scope $"{value}";

			let jr = scope JsonReader();
			Assert.IsTrue(jr.Parse<T>(Data) case .Ok(let val));
			//Assert.EqualTo(jr.LookAhead() case .Ok(let token), token.IsEOF);
			Assert.IsTrue(val == expected);
			delete val;
		}

		public static void ParseNumber<T>(params StringView[] values)
			where T : var
		{
			for (var value in values)
			{
				Assert.IsTrue(double.Parse(value) case .Ok(let result));
				String Data = scope $"{value}";

				let jr = scope JsonReader();
				Assert.IsTrue(jr.Parse<T>(Data) case .Ok(let r));
				Assert.EqualTo((T)r, result);
				Assert.EqualTo(jr.LookAhead() case .Ok(let val), val.IsEOF);
			}
		}

		[Test]
		public static void ParseNumbers()
		{
			ParseNumber<uint8>("231", " 231", "113", "123 ");
			ParseNumber<int8>("111", " 01", "113", "-12 ");

			ParseNumber<uint16>("2031", " 2231", "5113", "1623 ");
			ParseNumber<int16>("1911", " 041", "11053", "172 ");

			ParseNumber<uint32>("62031", " 242231", "552113", "163223 ");
			ParseNumber<int32>("-19151", " -041231", "1105433", "634172 ");

			ParseNumber<uint64>("62043531", " 24223456331", "552145613", "163226553 ");
			ParseNumber<int64>("191345351", " -04143563231", "1105456433", "6341723422 ");

			//floats have precision issues when comparing float, double
			//ParseNumber<float>("0.620999985", " 0.242321", "0.552777", "0.16332323 ");
			ParseNumber<double>("-191.3", " 0414.554", "1105.76431", "-6341.2332 ");
			ParseNumber<double>("191.3E-10", " -0414.554E+2", "-1105.76431E-5", "6341.2332E8 ");
		}

		[Test]
		public static void ParseBool()
		{
			Parse<bool>("true", true);
			Parse<bool>("false", false);
			Parse<bool>("null", false);
		}

		[Test]
		public static void ParseString()
		{
			Parse<String>("\"Hello World\"", "Hello World");
			Parse<String>("\"Hello\\tWorld\"", "Hello\tWorld");
			Parse<String>("\"Hello\\nWorld\"", "Hello\nWorld");
			Parse<String>("\"Hello\\rWorld\"", "Hello\rWorld");
			Parse<String>("\"Hello\\bWorld\"", "Hello\bWorld");
			Parse<String>("\"Hello\\fWorld\"", "Hello\fWorld");
			Parse<String>("\"Hello\\\"World\"", "Hello\"World");
			Parse<String>("\"Hello\\/World\"", "Hello/World");
			Parse<String>("\"Hello\\\\World\"", "Hello\\World");
		}

		[Test]
		public static void TestStructParse()
		{
			const String Data = "{     \"x\"     :    1    ,    \"y\"    :    2,    \"z\"   :    10.1   ,   \"t\"   :   987841   ,   \"nested\"  :  {   \"c\"  : 444 }    }";

			let jr = scope JsonReader();
			Assert.IsTrue(jr.Parse<TestStruct>(Data) case .Ok(let val));
			Assert.EqualTo(val.x, 1);
			Assert.EqualTo(val.y, 2);
			Assert.EqualTo(val.z, 10.1);
			Assert.EqualTo(val.t, 987841);
			Assert.EqualTo(val.nested.c, 444);
		}

		[Test]
		public static void TestStructWithString()
		{
			const String Data = "{  \"c\" : 10, \"str\": \"hello world\"  }";

			let jr = scope JsonReader();
			Assert.IsTrue(jr.Parse<Test2Struct>(Data) case .Ok(let val));
			Assert.EqualTo(val.c, 10);
			Assert.EqualTo(val.str, "hello world");
			delete val.str;
		}

		[Test]
		public static void TestClass()
		{
			const String Data = "{  \"x\" : 10, \"y\": 20, \"str\": \"hello world\"  }";

			let jr = scope JsonReader();
			Assert.IsTrue(jr.Parse<TestClass>(Data) case .Ok(let val));
			Assert.EqualTo(val.x, 10);
			Assert.EqualTo(val.y, 20);
			Assert.EqualTo(val.str, "hello world");
			delete val;
		}
	}
}
