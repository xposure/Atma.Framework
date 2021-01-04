using System;
using System.Text;
using System.Globalization;
using System.IO;
using System.Collections;
using System.Reflection;

namespace Atma
{
	using internal Atma;
	public enum TokenType : uint32
	{
		case Number;
		case Field;
		case String;
		case ArrayStart;
		case ArrayEnd;
		case ObjectStart;
		case ObjectEnd;
		case Colon;

		case Bool;
		case Null;
	}

	public struct Token
	{
		public uint32 line;
		public uint32 pos;
		public TokenType type;
		public uint32 elements;
		public StringView text;

		public void GetString(String str)
		{
			var t = StringView(text, 1, text.Length - 2);
			for (var i < t.Length)
			{
				if (t[i] == '\\')
				{
					switch (t[i + 1]) {
					case 'n','N': str.Append('\n');
					case 'r','R': str.Append('\r');
					case 't','T': str.Append('\t');
					case 'b','B': str.Append('\b');
					case 'f','F': str.Append('\f');
					case '"': str.Append('"');
					case '/': str.Append('/');
					case '\\': str.Append('\\');
					}
				}
				else
					str.Append(t[i]);
			}
		}
	}
	public class JsonParser
	{
		public uint32 line;
		public uint16 pos;
		public char8 ch => (_bufferPos + _lookAheadPos) >= _buffer.Length ? '\0' : _buffer[_bufferPos + _lookAheadPos];

		public bool IsEOF() => ch == '\0';
		public bool IsField() => ch >= (.)0x20;
		public bool IsAlpha => (ch >= (.)0x41 && ch <= (.)0x5a) || (ch >= (.)0x61 && ch <= (.)0x7a);
		public bool IsUnderscore => ch == (.)0x5f;
		public bool IsCharacter() => ch >= (.)0x20;
		public bool IsString() => ch == (.)0x22;
		public bool IsEscape() => ch == (.)0x5c;
		public bool IsDigit() => ch >= (.)0x30 && ch <= (.)0x39;
		public bool IsOneNine => ch >= (.)0x31 && ch <= (.)0x39;
		public bool IsNegative => ch == (.)0x2d;
		public bool IsPositive => ch == (.)0x2b;
		public bool IsSign() => IsNegative || IsPositive;
		public bool IsColon() => ch == (.)0x3a;
		public bool IsComma() => ch == (.)0x2c;
		public bool IsPeriod => ch == (.)0x2e;
		public bool IsExponent => ch == (.)0x45 || ch == (.)0x65;
		public bool IsObjectStart() => ch == (.)0x7b;
		public bool IsObjectEnd() => ch == (.)0x7d;
		public bool IsArrayStart() => ch == (.)0x5b;
		public bool IsArrayEnd() => ch == (.)0x5d;
		public bool IsSpace => ch == (.)0x20;
		public bool IsCR => ch == (.)0x0d;
		public bool IsLF => ch == (.)0x0a;
		public bool IsTab => ch == (.)0x09;
		public bool IsBackspace => ch == (.)0x08;
		public bool IsFormFeed => ch == (.)0x14;
		public bool IsUnicode => ch == (.)0x75;
		public bool IsForwardSlash => ch == (.)0x2f;
		public bool IsWhiteSpace => IsSpace || IsCR || IsLF || IsTab;

		internal List<Token> _tokens = new .() ~ delete _;
		private StringView _buffer;

		internal List<String> _errors = new .() ~ DeleteContainerAndItems!(_);
		private int _bufferPos = 0;
		private int _lookAheadPos = 0;

		private uint32 _line, _pos;
		private List<int> _tokenDepth = new .() ~ delete _;

		public bool Tokenize(StringView text)
		{
			_buffer = text;
			_pos = 1;
			_line = 1;
			_bufferPos = 0;
			_lookAheadPos = 0;
			_tokenDepth.Clear();
			_tokens.Clear();
			ClearAndDeleteItems(_errors);

			return ParseValue();
		}

		private void AddToken(uint32 line, uint32 pos, TokenType type)
		{
			Token token = ?;
			token.line = line;
			token.pos = pos;
			token.type = type;
			token.elements = 0;
			token.text = .(_buffer, _bufferPos, _lookAheadPos);
			_tokens.Add(token);

			_pos += (.)_lookAheadPos;
			_bufferPos += _lookAheadPos;
			_lookAheadPos = 0;
		}

		internal bool ParseValue()
		{
			//EatWhiteSpace();
			if (IsArrayStart())
				return ReadArray();
			else if (IsObjectStart())
				return ReadObject();
			else if (IsSign() || IsDigit())
				return ReadNumber();
			else if (IsString())
				return ReadString();

			return ReadBoolOrNull();
		}


		internal bool ReadObject()
		{
			if (!CheckTrue( => IsObjectStart, "Expected {"))
				return false;

			_lookAheadPos++;
			_tokenDepth.Add(_tokens.Count);
			AddToken(_line, _pos, .ObjectStart);
			EatWhiteSpace();

			while (!IsObjectEnd())
			{
				if (!CheckTrue( => IncrementObject, "Expected object to be on the stack."))
					return false;

				if (!CheckTrue( => ReadField, "Expected object field."))
					return false;

				EatWhiteSpace();
				if (!CheckTrue( => IsColon, "Expected :"))
					return false;

				//eat colon
				_bufferPos++;
				_pos++;

				EatWhiteSpace();
				if (!CheckTrue( => ParseValue, "Expected to find a object, number, bool, null."))
					return false;

				EatWhiteSpace();
				if (!IsComma())
					break;

				//eat comma
				_pos++;
				_bufferPos++;
				EatWhiteSpace();
			}

			if (!CheckTrue( => IsObjectEnd, "Expected }"))
				return false;

			_lookAheadPos++;
			AddToken(_line, _pos, .ObjectEnd);
			if (!CheckTrue(scope => CloseObject, "Expected to close object."))
				return false;

			return true;
		}

		internal bool ReadArray()
		{
			if (!CheckTrue( => IsArrayStart, "Expected ["))
				return false;

			_lookAheadPos++;
			_tokenDepth.Add(_tokens.Count);
			AddToken(_line, _pos, .ArrayStart);
			EatWhiteSpace();

			while (!IsArrayEnd())
			{
				if (!CheckTrue( => IncrementArray, "Expected array to be on the stack, but found object."))
					return false;

				if (!CheckTrue( => ParseValue, "Expected to find a object, number, bool, null."))
					return false;

				EatWhiteSpace();
				if (!IsComma())
					break;

				//eat comma
				_pos++;
				_bufferPos++;

				EatWhiteSpace();
			}

			if (!CheckTrue( => IsArrayEnd, "Expected ]"))
				return false;

			_lookAheadPos++;
			AddToken(_line, _pos, .ArrayEnd);
			if (!CheckTrue(scope => CloseArray, "Expected to close array, but found object."))
				return false;

			return true;
		}

		internal bool IncrementArray() => IncrementElement(.ArrayStart);
		internal bool IncrementObject() => IncrementElement(.ObjectStart);
		internal bool IncrementElement(TokenType expectedType)
		{
			if (_tokenDepth.Count == 0)
				return false;

			var token = ref _tokens[_tokenDepth.Back];
			if (token.type != expectedType)
				return false;

			token.elements++;
			return true;
		}

		internal bool CloseArray() => Close(.ArrayStart);
		internal bool CloseObject() => Close(.ObjectStart);

		internal bool Close(TokenType expectedType)
		{
			if (_tokenDepth.Count == 0)
				return false;

			return _tokens[_tokenDepth.PopBack()].type == expectedType;
		}

		internal bool ReadBoolOrNull()
		{
			let tokenLine = _line;
			let tokenPos = _pos;

			if (_bufferPos + 4 <= _buffer.Length)
			{
				let other = StringView(_buffer, _bufferPos, 4);
				if (StringView.Compare(other, "true", true) == 0)
				{
					_lookAheadPos += 4;
					AddToken(tokenLine, tokenPos, .Bool);
					return true;
				}
				else if (StringView.Compare(other, "null", true) == 0)
				{
					_lookAheadPos += 4;
					AddToken(tokenLine, tokenPos, .Null);
					return true;
				}
			}

			if (_bufferPos + 5 <= _buffer.Length)
			{
				let other = StringView(_buffer, _bufferPos, 5);
				if (StringView.Compare(other, "false", true) == 0)
				{
					_lookAheadPos += 5;
					AddToken(tokenLine, tokenPos, .Bool);
					return true;
				}
			}

			return false;
		}

		internal bool ReadField()
		{
			let tokenLine = _line;
			let tokenPos = _pos;

			var isString = IsString();

			if (isString)
			{
				_pos++;
				_bufferPos++;
			}

			bool IsFieldCharacterStart() => ch == '_' || ch.IsLetter;
			bool IsFieldCharacter() => ch == '_' || ch.IsLetterOrDigit;

			if (!CheckTrue( => IsFieldCharacterStart, "Expected a field character (_, a-z)."))
				return false;

			_lookAheadPos++;

			while (!IsWhiteSpace && !IsString() && !IsEOF() && !IsColon())
			{
				if (!CheckTrue( => IsFieldCharacter, scope $"Unexpected character in field '{ch}'"))
					return false;

				_lookAheadPos++;
			}

			if (isString)
			{
				if (!CheckFalse( => IsEOF, "Unexpected end of buffer"))
					return false;

				if (!CheckTrue( => IsString, "Expected \""))
					return false;

				AddToken(tokenLine, tokenPos, .Field);

				//eat "
				_bufferPos++;
				pos++;
				return true;
			}

			AddToken(tokenLine, tokenPos, .Field);
			return true;
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
										if (new string(json, index, 2) == "\\u" && UInt32.TryParse(new string(json,
		index + 2, 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out lowCodePoint))
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

		internal bool ReadString()
		{
			let tokenLine = _line;
			let tokenPos = _pos;

			if (!CheckTrue( => IsString, "Expected string start (\")"))
				return false;

			_lookAheadPos++;
			while (!IsString())
			{
				if (!CheckFalse( => IsEOF, "Unexpected end of buffer"))
					return false;

				if (IsEscape())
				{
					//do escape
					_lookAheadPos++;
					switch (ch) {
					case '"','\\','r','n','t','b','f','/':
					case 'u':
						AddError(scope $"Unicode escape is not supported.");
						return false;
					default:
						if (!CheckFalse( => IsEOF, "Unexpected end of buffer"))
							return false;

						AddError(scope $"Unexpected character '{ch}'");
						return false;
					}
				}

				if (!CheckTrue( => IsCharacter, "Expected a character."))
					return false;

				_lookAheadPos++;
			}


			if (IsString())
			{
				_lookAheadPos++;
				AddToken(tokenLine, tokenPos, .String);
				return true;
			}

			return false;
		}

		internal bool ReadNumber()
		{
			var tokenLine = _line;
			var tokenPos = _pos;

			if (!ParseInteger())
				return false;

			if (IsPeriod)
			{
				_lookAheadPos++;
				if (!ParseFraction())
					return false;
			}

			AddToken(tokenLine, tokenPos, .Number);
			return true;
		}

		internal bool ParseFraction()
		{
			if (!CheckTrue( => IsDigit, "Expected a digit (0-9)"))
				return false;

			_lookAheadPos++;
			while (IsDigit())
				_lookAheadPos++;

			if (IsExponent)
			{
				_lookAheadPos++;

				if (!ParseInteger())
					return false;
			}

			return true;
		}

		internal bool ParseInteger()
		{
			if (IsSign())
				_lookAheadPos++;

			if (CheckTrue( => IsDigit, "Expected digit (0-9)"))
			{
				_lookAheadPos++;

				while (IsDigit())
					_lookAheadPos++;

				return true;
			}

			return false;
		}

		private void EatWhiteSpace()
		{
			while (IsWhiteSpace)
			{
				if (IsLF)
				{
					line++;
					pos = 1;
				}
				else
				{
					pos++;
				}
				_bufferPos++;
			}
		}

		private bool Peek<T>(T dlg)
			where T : delegate bool()
		{
			_lookAheadPos++;
			defer { _lookAheadPos--; }
			return dlg();
		}


		private bool CheckTrue<T>(T dlg, StringView error)
			where T : delegate bool()
		{
			var l = line;
			var p = pos;
			if (!dlg())
			{
				AddError(l, p, error);
				return false;
			}
			return true;
		}

		private bool CheckFalse<T>(T dlg, StringView error)
			where T : delegate bool()
		{
			var l = line;
			var p = pos;
			if (dlg())
			{
				AddError(l, p, error);
				return false;
			}
			return true;
		}

		internal void AddError(int line, int pos, StringView error)
		{
			_errors.Add(scope $"[{line}, {pos + _lookAheadPos}] {error}");
		}

		internal void AddError(StringView error)
		{
			_errors.Add(scope $"[{line}, {pos + _lookAheadPos}] {error}");
		}

	}
}
