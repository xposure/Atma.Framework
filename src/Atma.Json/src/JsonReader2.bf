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
		private Token Current => _parser._tokens[_tokenIndex];

		public List<String>.Enumerator Errors => _parser._errors.GetEnumerator();

		public Result<T> Parse<T>(StringView text)
		{
			if(!_parser.Tokenize(text))
				return .Err;

			T t = default;
			return .Err;
			/*if(!Parse(typeof(T), &t))
				return .Err;

			return .Ok(t);*/
		}

		
	}
}
