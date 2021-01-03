using System;
namespace Atma.Json.Tests
{
	using internal Atma;
	public class JsonParserTests
	{
		private static void ReadNumber(StringView json)
		{
			let syntax = scope JsonParser(json);
			Assert.IsTrue(syntax.ReadNumber());
			Assert.EqualTo(syntax._tokens.Count, 1);
			Assert.EqualTo(syntax._tokens[0].text, json);
		}

		[Test]
		public static void ReadNumber()
		{
			ReadNumber("-1234.4312E-2");
			ReadNumber("+1234.4312E+2");
			ReadNumber("1234.4312e+2");
			ReadNumber("-1234.4312");
			ReadNumber("+1234.4312");
			ReadNumber("1234.4312");
			ReadNumber("-1234");
			ReadNumber("1234");
			ReadNumber("+1234");
		}

		private static void ReadString(StringView json)
		{
			let s = scope $"\"{json}\"";
			let syntax = scope JsonParser(s);
			Assert.IsTrue(syntax.ReadString());
			Assert.EqualTo(syntax._tokens.Count, 1);
			Assert.EqualTo(syntax._tokens[0].text, s);
		}

		[Test]
		public static void ReadString()
		{
			ReadString("Hello World");
			ReadString("Hello \\n World");
			ReadString("Hello \\\\ World");
			ReadString("Hello \\/ World");
			ReadString("Hello \\t World");
			ReadString("Hello \\r World");
			ReadString("Hello \\\" World");
			ReadString("Hello \\f World");
			ReadString("Hello \\b World");
		}

		private static void ReadField(StringView json)
		{
			{
				let s = scope $"\"{json}\"";
				let syntax = scope JsonParser(s);
				Assert.IsTrue(syntax.ReadField());
				Assert.EqualTo(syntax._tokens.Count, 1);
				Assert.EqualTo(syntax._tokens[0].text, json);
			}
			{
				let syntax = scope JsonParser(json);
				Assert.IsTrue(syntax.ReadField());
				Assert.EqualTo(syntax._tokens.Count, 1);
				Assert.EqualTo(syntax._tokens[0].text, json);
			}
		}

		[Test]
		public static void ReadField()
		{
			ReadField("_HelloWorld");
			ReadField("HelloWorld");
			ReadField("H123");
			ReadField("_H_123_");
		}

		private static void ReadBool(StringView json)
		{
			let syntax = scope JsonParser(json);
			Assert.IsTrue(syntax.ReadBoolOrNull());
			Assert.EqualTo(syntax._tokens.Count, 1);
			Assert.EqualTo(syntax._tokens[0].text, json);
		}

		[Test]
		public static void ReadBool()
		{
			ReadBool("true");
			ReadBool("false");
			ReadBool("False");
			ReadBool("True");
			ReadBool("TRUE");
			ReadBool("FALSE");
			ReadBool("null");
			ReadBool("Null");
			ReadBool("NULL");
		}

		typealias JToken = (JsonParser.TokenType type, StringView text);

		private static void ReadArray(StringView json, int elements)
		{
			let syntax = scope JsonParser(json);
			Assert.IsTrue(syntax.ReadArray());
			Assert.EqualTo(syntax._tokens[0].elements, elements);
		}

		private static void ReadArray(StringView json, params JToken[] tokens)
		{
			let syntax = scope JsonParser(json);
			Assert.IsTrue(syntax.ReadArray());
			Assert.EqualTo(syntax._tokens.Count, tokens.Count);

			for (var i < tokens.Count)
			{
				Assert.EqualTo(syntax._tokens[i].type, tokens[i].type);
				Assert.EqualTo(syntax._tokens[i].text, tokens[i].text);
			}
		}

		[Test]
		public static void ReadArray()
		{
			ReadArray("[1,2,3,4]", 4);
			ReadArray("[]", 0);
			ReadArray("[   ]", 0);
			ReadArray("[ 1  ]", 1);

			ReadArray("[]", (.ArrayStart, "["), (.ArrayEnd, "]"));
			ReadArray("[ ]", (.ArrayStart, "["), (.ArrayEnd, "]"));
			ReadArray("[1,2,3,4]", (.ArrayStart, "["), (.Number, "1"), (.Number, "2"), (.Number, "3"), (.Number, "4"), (.ArrayEnd, "]"));
			ReadArray("[[],true,false,null]", (.ArrayStart, "["), (.ArrayStart, "["), (.ArrayEnd, "]"), (.Bool, "true"), (.Bool, "false"), (.Null, "null"), (.ArrayEnd, "]"));
			ReadArray("[[1],true,false,null]", (.ArrayStart, "["), (.ArrayStart, "["), (.Number, "1"), (.ArrayEnd, "]"), (.Bool, "true"), (.Bool, "false"), (.Null, "null"), (.ArrayEnd, "]"));
			ReadArray("[ [ -1.43E-2 ] , true , false , null, { } ]", (.ArrayStart, "["), (.ArrayStart, "["), (.Number, "-1.43E-2"), (.ArrayEnd, "]"), (.Bool, "true"), (.Bool, "false"), (.Null, "null"), (.ObjectStart, "{"), (.ObjectEnd, "}"), (.ArrayEnd, "]"));
		}

		private static void ReadObject(StringView json, int elements)
		{
			let syntax = scope JsonParser(json);
			Assert.IsTrue(syntax.ReadObject());
			Assert.EqualTo(syntax._tokens[0].elements, elements);
		}

		private static void ReadObject(StringView json, params JToken[] tokens)
		{
			let syntax = scope JsonParser(json);
			Assert.IsTrue(syntax.ReadObject());
			Assert.EqualTo(syntax._tokens.Count, tokens.Count);

			for (var i < tokens.Count)
			{
				Assert.EqualTo(syntax._tokens[i].type, tokens[i].type);
				Assert.EqualTo(syntax._tokens[i].text, tokens[i].text);
			}
		}

		[Test]
		public static void ReadObject()
		{
			ReadObject("{}", 0);
			ReadObject("{  }", 0);
			ReadObject("{ hello: true }", 1);
			ReadObject("{ hello: true, \"test\": 123 }", 2);

			ReadObject("{}", (.ObjectStart, "{"), (.ObjectEnd, "}"));
			ReadObject("{  }", (.ObjectStart, "{"), (.ObjectEnd, "}"));
			ReadObject("{hello:true}", (.ObjectStart, "{"), (.Field, "hello"), (.Bool, "true"), (.ObjectEnd, "}"));
			ReadObject("{hello:true,\"test\":123}", (.ObjectStart, "{"), (.Field, "hello"), (.Bool, "true"), (.Field, "test"), (.Number, "123"), (.ObjectEnd, "}"));
			ReadObject("{ hello : true }", (.ObjectStart, "{"), (.Field, "hello"), (.Bool, "true"), (.ObjectEnd, "}"));
			ReadObject("{ hello : true , \"test\" : 123 }", (.ObjectStart, "{"), (.Field, "hello"), (.Bool, "true"), (.Field, "test"), (.Number, "123"), (.ObjectEnd, "}"));
		}
	}
}
