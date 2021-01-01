using System;
using System.Text;
using System.Globalization;
using System.IO;
using System.Collections;
using System.Reflection;

namespace Atma
{
	using internal Atma;

	public class JsonReader
	{
		internal struct Token
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


		private const int BUFFER_SIZE = 8;

		private String _lastError = new .() ~ delete _;
		private Stream _stream;
		private LookAheadBuffer<Token> _lookAhead = new .(BUFFER_SIZE) ~ delete _;
		private uint32 line = 1;
		private uint16 pos = 1;
		private int _lookAheadPos = 0;

		/*public this(Stream stream)
		{
			_stream = stream;
		}*/

		public Result<T, StringView> Parse<T>(StringView json, bool throwOnMissing = true)
		{
			//we could probably just push the whole string in to the lookup buffer instead of
			//copying it to a memory stream and then processing it?
			return Parse<T>(scope StringStream(json, .Reference), throwOnMissing);
		}

		public Result<T, StringView> Parse<T>(Stream stream, bool throwOnMissing = true)
		{
			line = 1;
			pos = 1;
			_lastError.Clear();
			_lookAhead.Clear();
			_stream = stream;

			defer { _stream = null; }

			let type = typeof(T);
			T t = default;

			if (ParseObject(type, &t, throwOnMissing))
			{
				if (_lastError.Length == 0 && Expect( () => (LookAhead() case .Ok(let token)) && token.IsEOF))
					return .Ok(t);
			}

			return .Err(_lastError);
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

		typealias ArrayTypeInfo = (Type Type, int32 Stride);
		typealias AddToArray = function void*(Type type);
		private bool ParseArray(Type type, void* target, bool throwOnMissing = true)
		{
			//we should support array[], array[10], and if the method has a .Add(T);

			//TODO: support anything with Add(UnderlyingType)
			//AddToArray addToArray = null;
			ArrayTypeInfo GetFromArrayType(Type type)
			{
				let arrayType = type as ArrayType;
				return (arrayType.UnderlyingType, arrayType.InstanceStride);
			}

			if (Expect( (token) => token.IsArrayStart))
			{
				NextToken();
				ArrayTypeInfo info = default;
				if (type.IsArray) info = GetFromArrayType(type);

				var count = 0;
				let items = scope List<uint8>();
				while (Peek( (token) => !token.IsArrayEnd) case .Ok)
				{
					count++;
					let ptr = items.GrowUnitialized(info.Stride);
					ParseObject(info.Type, ptr, throwOnMissing);

					EatWhiteSpace();
					if (Peek( (token) => !token.IsComma) case .Ok)
						break;
				}

				//look for end array marker
				if (Expect( (token) => token.IsArrayEnd))
				{
					NextToken();

					if (type.IsArray)
					{
					}
					return true;
				}
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

			if (JsonConfig._serializers.TryGetValue(type, let serializer))
				return Expect( () => serializer.Deserialize(this, target));

			//We don't have a custom serializer, so we need to have a serializable attribute
			//so we can get the fields to deserialize and possibly a ctor if its an object
			if (!Expect( () => type.GetCustomAttribute<SerializableAttribute>() case .Ok))
				return false;

			if (type.IsObject)
			{
				Object ptr = null;

				//check if the object is already pointing to something, else create it
				if (*(int*)target == 0)
				{
					let result = type.CreateObject();

					if (result case .Ok(out ptr))
						*(int*)target = (int)Internal.UnsafeCastToPtr(ptr);
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
				Runtime.FatalError("Not supported");
				/*void* ptr = ?;
				if (type.CreateValueDefault() case .Ok(out ptr))
				{
					*(int*)target = (int)ptr;
					if (Expect( () => serializer.Deserialize(this, ptr)))
						return true;
				}

				//we failed parse, clean up our memory
				delete ptr;
				return false;*/
			}

			return ParseFields(type, target, throwOnMissing);
		}


		private bool ParseNull()
		{
			if (LookAhead("null"))
				return true;

			return false;
		}

		public bool ParseBool(out bool result)
		{
			result = false;
			if (LookAhead("true"))
			{
				NextToken();
				result = true;
				return true;
			}
			else if (LookAhead("false") || LookAhead("null"))
			{
				NextToken();
				return true;
			}

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
				let ch = (char8)next.ch;
				switch (ch) {
				case '"': output.Append('"');
				case '\\': output.Append('\\');
				case 'r': output.Append('\r');
				case 'n': output.Append('\n');
				case 't': output.Append('\t');
				case 'b': output.Append('\b');
				case 'f': output.Append('\f');
				case 'u': Runtime.FatalError("Unicode escape is not supported.");
				case '/': output.Append('/');
				default: Runtime.FatalError(scope $"Invalid escape character '{ch}'");
				}

				return true;
			}
			return false;
		}

		internal void NextToken()
		{
			if (_lookAheadPos > 0)
			{
				_lookAhead.PopFront(_lookAheadPos);
				_lookAheadPos = 0;
			}
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
					cmp[0] = (.)_lookAhead[_lookAheadPos++].ch;
					cmp[1] = match[i];
					if (String.[Friend]CompareOrdinalIgnoreCaseHelper(cmp, 1, cmp + 1, 1) != 0)
					{
						_lookAheadPos = 0;
						return false;
					}
				}

				return true;
			}
			_lookAheadPos = 0;
			return false;
		}

		internal Result<Token> LookAhead(bool eatWhiteSpace = true)
		{
			if (eatWhiteSpace)
				EatWhiteSpace();

			if (ReadAhead(_lookAheadPos + 1) case .Err)
				return .Err;

			return .Ok(_lookAhead[_lookAheadPos++]);
		}

		internal Result<Token> Peek<T>(T dlg)
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

		internal bool Expect<T>(T dlg, String expression = Compiler.CallerExpression[0])
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


		internal bool Expect<T>(T dlg, String expression = Compiler.CallerExpression[0])
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


	}
}
