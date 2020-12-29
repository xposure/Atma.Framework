using System;
using System.IO;
namespace Atma.Json.Tests
{
	using internal Atma;

	class JsonReaderTests
	{
		[Test]
		public static void TestParseString()
		{
			const String Data = "Hello World";
			let ms = scope MemoryStream();
			ms.Write(scope $" \"{Data}\" ");
			ms.Position = 0;

			let jr = scope JsonReader(ms);
			let s = scope String();
			Assert.IsTrue(jr.ParseString(s));
			Assert.EqualTo(s, Data);
			Assert.EqualTo(jr.LookAhead() case .Ok(let val), val.IsEOF);
		}

		[Test]
		public static void TestParseInteger()
		{
			const double result = 0123456789;
			const String Data = " 0123456789 ";

			let ms = scope MemoryStream();
			ms.Write(scope $"{Data}");
			ms.Position = 0;

			let jr = scope JsonReader(ms);
			Assert.IsTrue(jr.ParseNumber(let r));
			Assert.EqualTo(r, result);
			Assert.EqualTo(jr.LookAhead() case .Ok(let val), val.IsEOF);
		}

		[Test]
		public static void TestParseNegativeInteger()
		{
			const double result = -0123456789;
			const String Data = " -0123456789 ";

			let ms = scope MemoryStream();
			ms.Write(scope $"{Data}");
			ms.Position = 0;

			let jr = scope JsonReader(ms);
			Assert.IsTrue(jr.ParseNumber(let r));
			Assert.EqualTo(r, result);
			Assert.EqualTo(jr.LookAhead() case .Ok(let val), val.IsEOF);
		}

		[Test]
		public static void TestParseFraction()
		{
			const double result = 0123456789.1234;
			const String Data = " 0123456789.1234 ";

			let ms = scope MemoryStream();
			ms.Write(scope $"{Data}");
			ms.Position = 0;

			let jr = scope JsonReader(ms);
			Assert.IsTrue(jr.ParseNumber(let r));
			Assert.EqualTo(r, result);
			Assert.EqualTo(jr.LookAhead() case .Ok(let val), val.IsEOF);
		}

		[Test]
		public static void TestParseNegativeFraction()
		{
			const double result = -0123456789.1234;
			const String Data = " -0123456789.1234 ";

			let ms = scope MemoryStream();
			ms.Write(scope $"{Data}");
			ms.Position = 0;

			let jr = scope JsonReader(ms);
			Assert.IsTrue(jr.ParseNumber(let r));
			Assert.EqualTo(r, result);
			Assert.EqualTo(jr.LookAhead() case .Ok(let val), val.IsEOF);
		}

		[Test]
		public static void TestParseExponent()
		{
			const double result = 0.1234E+2;
			const String Data = " 0.1234E+2 ";

			let ms = scope MemoryStream();
			ms.Write(scope $"{Data}");
			ms.Position = 0;

			let jr = scope JsonReader(ms);
			Assert.IsTrue(jr.ParseNumber(let r));
			Assert.EqualTo(r, result);
			Assert.EqualTo(jr.LookAhead() case .Ok(let val), val.IsEOF);
		}

		[Test]
		public static void TestParseNegativeExponent()
		{
			const double result = 0.1234E-2;
			const String Data = " 0.1234E-2 ";

			let ms = scope MemoryStream();
			ms.Write(scope $"{Data}");
			ms.Position = 0;

			let jr = scope JsonReader(ms);
			Assert.IsTrue(jr.ParseNumber(let r));
			Assert.EqualTo(r, result);
			Assert.EqualTo(jr.LookAhead() case .Ok(let val), val.IsEOF);
		}

		[Test]
		public static void TestParseStringFail()
		{
			const String Data = "Hello World";
			let ms = scope MemoryStream();
			ms.Write(scope $"{Data}");
			ms.Position = 0;

			let jr = scope JsonReader(ms);
			let s = scope String();
			Assert.IsFalse(jr.ParseString(s));
		}



		[Test]
		public static void TestStructParse()
		{
			const String Data = "{     \"x\"     :    1    ,    \"y\"    :    2,    \"z\"   :    10.1   ,   \"t\"   :   987841   ,   \"nested\"  :  {   \"c\"  : 444 }    }";
			let ms = scope MemoryStream();
			ms.Write(scope $"{Data}");
			ms.Position = 0;

			let jr = scope JsonReader(ms);
			Assert.IsTrue(jr.Parse<TestStruct>(false) case .Ok(let val));
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
			let ms = scope MemoryStream();
			ms.Write(scope $"{Data}");
			ms.Position = 0;

			let jr = scope JsonReader(ms);
			Assert.IsTrue(jr.Parse<Test2Struct>(false) case .Ok(let val));
			Assert.EqualTo(val.c, 10);
			Assert.EqualTo(val.str, "hello world");
			delete val.str;
		}

		[Test]
		public static void TestClass()
		{
			const String Data = "{  \"x\" : 10, \"y\": 20, \"str\": \"hello world\"  }";
			let ms = scope MemoryStream();
			ms.Write(scope $"{Data}");
			ms.Position = 0;

			let jr = scope JsonReader(ms);
			Assert.IsTrue(jr.Parse<TestClass>(false) case .Ok(let val));
			Assert.EqualTo(val.x, 10);
			Assert.EqualTo(val.y, 20);
			Assert.EqualTo(val.str, "hello world");
			delete val;
		}
	}
}
