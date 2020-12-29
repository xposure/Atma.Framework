using System;
using System.Text;
using System.Globalization;
using System.IO;
using System.Collections;
using System.Reflection;

//need to add bool
//need to add object vs valuetype
namespace Atma
{
	[AttributeUsage(.Struct | .Class, .AlwaysIncludeTarget | .ReflectAttribute, ReflectUser = .All | .DynamicBoxing)]
	public struct SerializableAttribute : Attribute
	{
	}

	[Serializable]
	public struct TestStruct
	{
		public int x;
		public int y;
		public double z;
		public int32 t;
		public Test2Struct nested;
	}

	[Serializable]
	public struct Test2Struct
	{
		public int64 c;
		public String str;
	}

	//[Serializable]
	[Reflect(.All)]
		[AlwaysInclude(AssumeInstantiated = true, IncludeAllMethods = true)]
	public class TestClass
	{
		public int x;
		public int y;

		public String str = new .() ~ delete _;

		public this()
		{
		}

		public this(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public void HelloWorld()
		{
		}
	}

	public abstract class JsonSerializer
	{
		public readonly Type Type;
		public abstract bool Deserialize(JsonReader reader, void* target);
	}

	public abstract class JsonSerializer<T> : JsonSerializer
		where T : var
	{
		public this() { Type = typeof(T); }

		public override bool Deserialize(JsonReader reader, void* target)
		{
			return OnDeserialize(reader, (T*)target);
		}

		protected abstract bool OnDeserialize(JsonReader reader, T* target);
	}

	public abstract class JsonObjectSerializer<T> : JsonSerializer<T>
		where T : class, new, delete
	{
		public this() { Type = typeof(T); }

		public override bool Deserialize(JsonReader reader, void* target)
		{
			bool created = false;
			var ptr = (T*)target;
			if (*ptr == null)
			{
				*ptr = new T();
				created = true;
			}

			if (!OnDeserialize(reader, ptr))
			{
				if (created)
					delete *ptr;
				return false;
			}

			return true;
		}

	}

	public class JsonStructSerializer<T> : JsonSerializer<T>
		where T : var, struct
	{
		protected override bool OnDeserialize(JsonReader reader, T* target)
		{
			if (reader.ParseNumber(let number))
			{
				*target = (T)number;
				return true;
			}
			return false;
		}
	}

	public class JsonStringSerializer : JsonObjectSerializer<String>
	{
		protected override bool OnDeserialize(JsonReader reader, String* target)
		{
			if (reader.ParseString(*target))
				return true;

			return false;
		}
	}

	public class JsonReader
	{
		typealias char = char8;

		private static Dictionary<Type, JsonSerializer> _serializers = new .() ~ DeleteDictionaryAndItems!(_);

		static this()
		{
			AddSerializer<int8>();
			AddSerializer<int16>();
			AddSerializer<int32>();
			AddSerializer<int64>();
			AddSerializer<int>();
			AddSerializer<uint8>();
			AddSerializer<uint16>();
			AddSerializer<uint32>();
			AddSerializer<uint64>();
			AddSerializer<uint>();
			AddSerializer<float>();
			AddSerializer<double>();
			AddSerializer<char8>();
			_serializers.Add(typeof(String), new JsonStringSerializer());
		}

		public static void AddSerializer<T>()
			where T : var
		{
			_serializers.Add(typeof(T), new JsonStructSerializer<T>());
		}


		private struct Token
		{
			public uint32 line;
			public uint16 pos;
			public uint16 ch;

			public bool IsEOF => ch == 0;
			public bool IsField => ch >= 0x20;
			public bool IsAlpha => (ch >= 0x41 && ch <= 0x5a) || (ch >= 0x61 && ch <= 0x7a);
			public bool IsUnderscore => ch == 0x5f;
			public bool IsCharacter => ch >= 20;
			// // && ch <= 0x10ffff;
			public bool IsString => ch == 0x22;
			public bool IsEscape => ch == 0x5c;
			public bool IsDigit => ch >= 0x30 && ch <= 0x39;
			public bool IsOneNine => ch >= 0x31 && ch <= 0x39;
			public bool IsNegative => ch == 0x2d;
			public bool IsPositive => ch == 0x2b;
			public bool IsSign => IsNegative || IsPositive;
			public bool IsColon => ch == 0x3a;
			public bool IsComma => ch == 0x2c;
			public bool IsPeriod => ch == 0x2e;
			public bool IsExponent => ch == 0x45 || ch == 0x65;
			public bool IsObjectStart => ch == 0x7b;
			public bool IsObjectEnd => ch == 0x7d;
			public bool IsArrayStart => ch == 0x5b;
			public bool IsArrayEnd => ch == 0x5d;
			public bool IsSpace => ch == 0x20;
			public bool IsCR => ch == 0x0d;
			public bool IsLF => ch == 0x0a;
			public bool IsTab => ch == 0x09;
			public bool IsBackspace => ch == 0x08;
			public bool IsFormFeed => ch == 0x14;
			public bool IsUnicode => ch == 0x75;
			public bool IsForwardSlash => ch == 0x2f;
			public bool IsWhiteSpace => IsSpace || IsCR || IsLF || IsTab;
		}

		/*
						int remainingLength = json.Length - index;
						if (remainingLength >= 4)
						{
							// parse the 32 bit hex into an integer codepoint
							uint codePoint;
							if (!(success = UInt32.TryParse(new string(json, index, 4), NumberStyles.HexNumber,
		CultureInfo.InvariantCulture, out codePoint)))
							{
								return new JsonString(string.Empty);
							}

							// convert the integer codepoint to a unicode char and add to string
							if (0xD800 <= codePoint && codePoint <= 0xDBFF)// if high surrogate
							{
								index += 4;// skip 4 chars
								remainingLength = json.Length - index;
								if (remainingLength >= 6)
								{
									uint lowCodePoint;
									if (new string(json, index, 2) == "\\u" && UInt32.TryParse(new string(json, index +
		2, 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out lowCodePoint))
									{
										if (0xDC00 <= lowCodePoint && lowCodePoint <= 0xDFFF)// if low surrogate
										{
											s.Append((char)codePoint);
											s.Append((char)lowCodePoint);
											index += 6;// skip 6 chars
											continue;
										}
									}
								}
								success = false;// invalid surrogate pair
								return new JsonString(string.Empty);
							}

							// convert the integer codepoint to a unicode char and add to string
							s.Append(Char.ConvertFromUtf32((int)codePoint));
							// skip 4 chars
							index += 4;
						}
						else
						{
							break;
						}
					}
	*/


		private const int BUFFER_SIZE = 1024;

		private String _lastError = new .() ~ delete _;
		private Stream _stream;
		private CircularBuffer<Token> _lookAhead = new .(BUFFER_SIZE) ~ delete _;
		private uint32 line = 1;
		private uint16 pos = 1;
		private int _lookAheadPos = 0;


		public this(Stream stream)
		{
			_stream = stream;
		}

		public Result<T, StringView> Parse<T>(bool throwOnMissing = true)
		{
			let type = typeof(T);
			//T t = default;
			var t = scope T[1]*;

			if (ParseObject(type, &t[0], throwOnMissing))
			{
				if (_lastError.Length == 0)
					return .Ok(t[0]);
			}

			return .Err(_lastError);
		}

		public struct Test
		{
			public Test* test;
		}


		private bool ParseFields(Type type, void* target, bool throwOnMissing = true)
		{
			let fields = scope List<FieldInfo>();
			for (var it in type.GetFields())
				fields.Add(it);

			if (Expect( (token) => token.IsObjectStart))
			{
				NextToken();

				while (Peek( (token) => !token.IsObjectEnd) case .Ok)
				{
					let memberName = scope String();
					if (!Expect( () => ParseString(memberName))) return false;
					NextToken();

					if (!Expect( (token) => token.IsColon)) return false;
					NextToken();

					var foundField = false;
					for (var it in fields)
					{
						if (String.Compare(it.[Friend]mFieldData.mName, memberName, true) == 0)
						{
							//offset ptr to field value
							let ptr = (uint8*)target + it.MemberOffset;
							if (!ParseObject(it.FieldType, ptr, throwOnMissing))
								return false;


							foundField = true;
							//no reason to look at this field again
							//unless we are going to support dupes?
							@it.RemoveFast();
							break;
						}
					}

					if (!foundField && throwOnMissing)
						Runtime.FatalError(scope $"Field {memberName} not found.");

					EatWhiteSpace();
					if (Peek( (token) => !token.IsComma) case .Ok)
						break;

					_lookAheadPos++;
					NextToken();
				}

				if (!Expect( (token) => token.IsObjectEnd)) return false;
				NextToken();
				return true;
			}

			return false;
		}

		private bool ParseObject(Type type, void* target, bool throwOnMissing = true)
		{
			//for now we will just skip parsing
			//later we need to determine what to do with valuetype vs object
			if (LookAhead("null"))
			{
				//do nothing
				return true;
			}

			if (_serializers.TryGetValue(type, let serializer))
			{
				if (LookAhead("null"))
				{
					//do nothing
					return true;
				}

				return Expect( () => serializer.Deserialize(this, target));

				/*if (type.IsObject)
				{
					if (LookAhead("null"))
					{
						//do nothing
						return true;
					}

					//if we have a serializer it is responsible for creating the memory
					return Expect( () => serializer.Deserialize(this, target));
				}
				else if (type.IsPointer)
				{
					void* ptr = ?;
					//check if the object is already pointing to something, else create it
					if (*(int*)target == 0 && type.CreateValue() case .Ok(out ptr))
						*(int*)target = (int)ptr;

					if (Expect( () => serializer.Deserialize(this, ptr)))
						return true;

					//we failed parse, clean up our memory
					delete ptr;
				}
				else
					return Expect( () => serializer.Deserialize(this, target));

				return false;*/
			}

			if (type.IsObject)
			{
				Object ptr = ?;

				//check if the object is already pointing to something, else create it
				if (*(int*)target == 0)
				{
					let result = type.CreateObject();

					if (result case .Ok(let newObj))
						*(int*)target = (int)Internal.UnsafeCastToPtr(newObj);
					else
						return false;
				}

				if (ParseFields(type, *(void**)target, throwOnMissing))
					return true;

				//we failed parse, clean up our memory
				delete ptr;
				return false;
			}
			else if (type.IsPointer)
			{
				void* ptr = ?;
				if (type.CreateValueDefault() case .Ok(out ptr))
				{
					*(int*)target = (int)ptr;
					if (Expect( () => serializer.Deserialize(this, ptr)))
						return true;
				}

				//we failed parse, clean up our memory
				delete ptr;
				return false;
			}

			return ParseFields(type, target, throwOnMissing);
		}


		private bool ParseNull()
		{
			if (LookAhead("null"))
				return true;

			return false;
		}

		private bool ParseBool(out bool result)
		{
			result = false;
			if (LookAhead("true"))
			{
				result = true;
				return true;
			}
			else if (LookAhead("false"))
				return true;

			return false;
		}

		public bool ParseNumber(out double number)
		{
			_lookAheadPos = 0;
			number = 0;
			let output = scope String();
			if (ParseInteger(output))
			{
				if (Peek( (token) => token.IsPeriod) case .Ok(let fraction))
				{
					_lookAheadPos++;
					output.Append('.');
					if (!ParseFraction(output))
						return false;
				}

				if (double.Parse(output) case .Ok(out number))
				{
					NextToken();
					return true;
				}
			}
			return false;
		}

		private bool ParseFraction(String output)
		{
			var valid = false;
			while (Peek( (token) => token.IsDigit) case .Ok(let next))
			{
				_lookAheadPos++;
				output.Append((.)next.ch);
				valid = true;
			}

			if (Peek( (token) => token.IsExponent) case .Ok(?))
			{
				_lookAheadPos++;
				output.Append('E');

				if (!ParseInteger(output))
					return false;
			}

			return valid;
		}

		private bool ParseInteger(String output)
		{
			if (LookAhead(true) case .Ok(let start))
			{
				var valid = false;
				if (start.IsSign)
					output.Append((.)start.ch);
				else if (start.IsDigit)
				{
					output.Append((.)start.ch);
					valid = true;
				}
				else
					return false;

				while (Peek( (token) => token.IsDigit) case .Ok(let next))
				{
					_lookAheadPos++;
					output.Append((.)next.ch);
					valid = true;
				}

				return valid;
			}
			return false;
		}

		public bool ParseString(String output)
		{
			_lookAheadPos = 0;
			if ((LookAhead(true) case .Ok(let stringStart)) && stringStart.IsString)
			{
				while (true)
				{
					if (LookAhead(false) case .Ok(let next))
					{
						if (next.IsString)
						{
							//we are done
							NextToken();
							return true;
						}
						else if (next.IsEscape)
						{
							if (!ParseEscape(output))
								return false;
						}
						else if (next.IsEOF || !next.IsCharacter)
							return false;
						else
							output.Append((.)next.ch);
					}
					else
						return false;
				}
			}
			return false;
		}

		private bool ParseEscape(String output)
		{
			if (LookAhead(false) case .Ok(let next))
			{
				if (next.IsString) output.Append('\"');
				else if (next.IsEscape) output.Append('\\');
				else if (next.IsCR) output.Append('\r');
				else if (next.IsLF) output.Append('\n');
				else if (next.IsTab) output.Append('\t');
				else if (next.IsBackspace) output.Append('\b');
				else if (next.IsFormFeed) output.Append('\f');
				else if (next.IsUnicode) Runtime.FatalError("Unicode escape is not supported.");
				else if (next.IsForwardSlash) output.Append('/');
				else return false;

				return true;
			}
			return false;
		}

		private void NextToken()
		{
			_lookAhead.PopFront(_lookAheadPos);
			_lookAheadPos = 0;
		}

		private Result<int> ReadAhead(int count)
		{
			if (_lookAhead.Size > count || CheckEOF())
				return .Ok(0);

			var data = scope uint8[BUFFER_SIZE]*;
			var span = Span<uint8>(data, BUFFER_SIZE);
			var readAhead = 0;

			while (_lookAhead.Size < count)
			{
				if (_stream.TryRead(span) case .Ok(let read))
				{
					if (read == 0)
						AppendEOF();

					readAhead += read;

					Token token = ?;
					for (var i < read)
					{
						token.ch = span[i];
						token.line = line;
						token.pos = pos;

						if (token.IsLF)
						{
							line++;
							pos = 1;
						}
						else
						{
							pos++;
						}

						//if (!token.IsWhiteSpace) //we can't eat whitespace in strings
						_lookAhead.PushBack(token);
					}
				}
				else
				{
					return .Err;
				}
			}

			//no more data to read ahead
			if (_lookAhead.Size < count)
				return .Err;

			return .Ok(readAhead);

			bool CheckEOF() => _lookAhead.Size > 0 && _lookAhead.Back().IsEOF;
			void AppendEOF() => _lookAhead.PushBack(Token() { line = line, pos = pos, ch = 0 });
		}

		private void EatWhiteSpace()
		{
			while (Peek( (token) => token.IsWhiteSpace) case .Ok(let val))
				_lookAheadPos++;
		}

		private bool LookAhead(StringView match)
		{
			_lookAheadPos = 0;
			if (ReadAhead(match.Length) case .Ok(?))
			{
				var cmp = scope char8[2]*;
				for (var i < match.Length)
				{
					cmp[0] = (.)_lookAhead[i].ch;
					cmp[1] = match[i];
					if (String.[Friend]CompareOrdinalIgnoreCaseHelper(cmp, 1, cmp + 1, 1) != 0)
						return false;
				}

				return true;
			}
			return false;
		}

		private Result<Token> LookAhead(bool eatWhiteSpace = true)
		{
			if (eatWhiteSpace)
				EatWhiteSpace();

			if (ReadAhead(_lookAheadPos + 1) case .Err)
				return .Err;

			return .Ok(_lookAhead[_lookAheadPos++]);
		}

		private Result<Token> Peek<T>(T dlg)
			where T : delegate bool(Token t)
		{
			return Peek<T>(0, dlg);
		}

		private Result<Token> Peek<T>(int count, T dlg)
			where T : delegate bool(Token t)
		{
			if (Peek(count) case .Ok(let val))
				if (dlg(val))
					return .Ok(val);

			return .Err;
		}

		private Result<Token> Peek(int count)
		{
			if (ReadAhead(_lookAheadPos + count + 1) case .Err)
				return .Err;

			return .Ok(_lookAhead[_lookAheadPos + count]);
		}

		private bool Expect<T>(T dlg, String expression = Compiler.CallerExpression[0])
			where T : delegate bool()
		{
			if (Peek(0) case .Ok(let val))
			{
				if (!dlg())
					_lastError.Set(scope $"[{val.line}:{val.pos}] Expected: {expression}");

				return _lastError.Length == 0;
			}

			return false;
		}


		private bool Expect<T>(T dlg, String expression = Compiler.CallerExpression[0])
			where T : delegate bool(Token t)
		{
			let next = LookAhead();
			if (next case .Err)
			{
				_lastError.Set(scope $"[{line}:{pos}] Internal error: {expression}");
			}
			else if (next case .Ok(let val))
			{
				if (!dlg(val))
					_lastError.Set(scope $"[{val.line}:{val.pos}] Expected: {expression}");
			}

			return _lastError.Length == 0;
		}

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
