using System;
using System.Text;
using System.Globalization;
using System.IO;
using System.Collections;
using System.Reflection;

namespace Atma
{
	using internal Atma;

	public class JsonReader2
	{
		private JsonParser _parser = new JsonParser() ~ delete _;

		private int _tokenIndex = 0;
		public Token Current => _parser._tokens[_tokenIndex];

		public List<String>.Enumerator Errors => _parser._errors.GetEnumerator();

		public Result<T> Parse<T>(StringView text)
		{
			if (!_parser.Tokenize(text))
				return .Err;

			T t = default;
			if (!Parse(typeof(T), &t))
				return .Err;

			return .Ok(t);
		}

		public bool Parse(Type type, void* target)
		{
			if (!JsonConfig2.GetConverter(type, let converter))
				Runtime.FatalError(scope $"Could not find a converter for type '{ type.GetName(.. scope String()) }'.");

			return converter.ReadJson(this, type, target);
		}

		public Token Next()
		{
			_tokenIndex++;
			return _parser._tokens[_tokenIndex - 1];
		}

		public bool Peek(TokenType type)
		{
			if (_tokenIndex + 1 < _parser._tokens.Count)
				return _parser._tokens[_tokenIndex + 1].type == type;

			return false;
		}

		public bool Expect(TokenType type, out Token token)
		{
			if (Current.type != type)
			{
				token = default;
				AddError(scope $"Expected token type '{type}' but found '{Current.type}'");
				return false;
			}
			token = Next();
			return true;
		}

		public void AddError(StringView msg)
		{
			_parser.AddError(Current.line, Current.pos, msg);
		}
	}
}
