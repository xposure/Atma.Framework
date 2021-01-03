/*using System;
using System.Text;
using System.Globalization;
using System.IO;
using System.Collections;
using System.Reflection;

namespace Atma
{
	using internal Atma;

	public class JsonSyntax
	{
		public enum TokenType
		{
			case ObjectStart;
			case ObjectEnd;
			case ArrayStart;
			case ArrayEnd;
			case Number;
			case String;
			case Field;
		}

		private uint8 ch = 0;
		public bool IsEOF => ch == 0;
		public bool IsField => ch >= 0x20;
		public bool IsAlpha => (ch >= 0x41 && ch <= 0x5a) || (ch >= 0x61 && ch <= 0x7a);
		public bool IsUnderscore => ch == 0x5f;
		public bool IsCharacter => ch >= 20;
		public bool IsString => ch == 0x22;
		public bool IsEscape => ch == 0x5c;
		public bool IsDigit => ch >= 0x30 && ch <= 0x39;
		public bool IsOneNine =>;

		public bool IsSign => IsNegative || IsPositive;
		public bool IsColon => ch == 0x3a;
		public bool IsComma => ch == 0x2c;

		public bool IsObjectStart => ch == 0x7b;
		public bool IsObjectEnd => ch == 0x7d;
		public bool IsArrayStart => ch == 0x5b;
		public bool IsArrayEnd => ch == 0x5d;

		public bool IsBackspace => ch == 0x08;
		public bool IsFormFeed => ch == 0x14;
		public bool IsUnicode => ch == 0x75;
		public bool IsForwardSlash => ch == 0x2f;

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

		private uint32 line = 1;
		private uint16 pos = 1;
		private int _startPos = 0;
		private int _endPos = 0;
		private StringView _input;

		private bool Digits()
		{
			let e = _endPos;
			while(Digit()){}

			return e != _endPos;
		}

		private bool Digit()
		{
			if (ch == 0x30)
			{
				++_endPos;
				return true;
			}

			return OneNine();
		}

		private bool OneNine()
		{
			if (ch >= 0x31 && ch <= 0x39)
			{
				++_endPos;
				return true;
			}

			return false;
		}

		private bool Fraction()
		{
			if (ch == 0x2e)
			{
				++_endPos;
				if(!Digits())
					Runtime.FatalError("Expected a digit.");
			}

			return false;
		}

		private void Exponent()
		{
			if (ch == 0x45 || ch == 0x65)
			{
				++_endPos;
				Sign();
				if(!Digits())
					Runtime.FatalError("Expected a digit.");
			}
		}

		private bool Sign()
		{
			if (ch == 0x2d || ch == 0x2b)
			{
				++_endPos;
				return true;
			}
			return false;
		}

		private void WS()
		{
			switch (ch) {
			case 0x0d,0x0a,0x09,0x20:
				_endPos = ++_startPos;
			}
		}
	}
}*/
