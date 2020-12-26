using System;

namespace Atma
{
	using System;
	using System.Collections;
	using System.Diagnostics;
	using System.IO;
	using System.Text;

	public static class Exceptions
	{
		public static void ArgumentOutOfRangeException(StringView arg)
		{
			Runtime.FatalError(scope $"Argument [{arg}] was out of range.");
		}
	}

	public static class Contract
	{
		[Inline]
		public static void IsTrue<T>(T actual, int line = Compiler.CallerLineNum, String file = Compiler.CallerFilePath, String expr = Compiler.CallerExpression[0])
			where bool : operator T == bool
		{
			if (!(actual == true))
			{
				Console.WriteLine(scope $"ERROR: <{expr}> expected to be <True> but was <{actual}> at line {line}:1 in {file}");
				System.Diagnostics.Debug.SafeBreak();

				Console.Read();
				Internal.FatalError(scope $"ERROR: <{expr}> expected to be <True> but was <{actual}> at line {line}:1 in {file}");
			}
		}

		[Inline]
		public static void IsFalse<T>(T actual)
			where bool : operator T == bool
		{
			if (!(actual == false))
				Runtime.FatalError(scope $"IsFalse -> Was True");
		}

		[Inline]
		public static void Range<T>(T actual, T inclusiveMin, T exclusiveMax)
			where bool : operator T > T
			where bool : operator T <= T
		{
			if (!(actual >= inclusiveMin) || !(actual < exclusiveMax))
				Runtime.FatalError(scope $"Range -> Expected: {inclusiveMin} to {exclusiveMax}, Actual : {actual}");
		}

		[Inline]
		public static void EqualTo<T, K>(T actual, K expected, int line = Compiler.CallerLineNum, String file = Compiler.CallerFilePath, String expr = Compiler.CallerExpression[0])
			where bool : operator T == K
		{
			if (!(actual == expected))
				Internal.FatalError(scope $"ERROR: <{expr}> expected to be <{expected}> but was <{actual}> at line {line}:1 in {file}");
		}

		[Inline]
		public static void NotEqualTo<T, K>(T actual, K expected)
			where bool : operator T != K
		{
			if (!(actual != expected))
				Runtime.FatalError(scope $"NotEqualTo -> Expected: {expected}, Actual: {actual}");
		}

		[Inline]
		public static void GreaterThan<T, K>(T actual, K expected)
			where bool : operator T > K
		{
			if (!(actual > expected))
				Runtime.FatalError(scope $"GreaterThan -> Expected: {expected}, Actual: {actual}");
		}

		[Inline]
		public static void GreaterThanEqualTo<T, K>(T actual, K expected)
			where bool : operator T >= K
		{
			if (!(actual >= expected))
				Runtime.FatalError(scope $"GreaterThanEqualTo -> Expected: {expected}, Actual: {actual}");
		}

		[Inline]
		public static void LessThan<T, K>(T actual, K expected)
			where bool : operator T < K
		{
			if (!(actual < expected))
				Runtime.FatalError(scope $"LessThan -> Expected: {expected}, Actual: {actual}");
		}

		[Inline]
		public static void LessThanEqualTo<T, K>(T actual, K expected)
			where bool : operator T <= K
		{
			if (!(actual <= expected))
				Runtime.FatalError(scope $"LessThanEqualTo -> Expected: {expected}, Actual: {actual}");
		}
	}


	public static class Assert
	{
		[Inline]
#if DEBUG
		[SkipCall]
#endif
		public static void IsTrue<T>(T actual)
			where bool : operator T == bool
		{
			if (!(actual == true))
				Runtime.FatalError(scope $"IsTrue -> Was False");
		}

		[Inline]
#if DEBUG
		[SkipCall]
#endif
		public static void IsFalse<T>(T actual, StringView msg = default)
			where bool : operator T == bool
		{
			if (!(actual == false))
				Runtime.FatalError(scope $"IsFalse -> Was True\n{msg}");
		}

		[Inline]
#if DEBUG
		[SkipCall]
#endif
		public static void Range<T>(T actual, T inclusiveMin, T exclusiveMax)
			where bool : operator T > T
			where bool : operator T <= T
		{
			if (!(actual >= inclusiveMin) || !(actual < exclusiveMax))
				Runtime.FatalError(scope $"Range -> Expected: {inclusiveMin} to {exclusiveMax}, Actual : {actual}");
		}

		[Inline]
#if DEBUG
		[SkipCall]
#endif
		public static void EqualTo<T, K>(T actual, K expected)
			where bool : operator T == K
		{
			if (!(actual == expected))
				Runtime.FatalError(scope $"EqualTo -> Expected: {expected}, Actual: {actual}");
		}

		[Inline]
#if DEBUG
		[SkipCall]
#endif
		public static void NotEqualTo<T, K>(T actual, K expected)
			where bool : operator T != K
		{
			if (!(actual != expected))
				Runtime.FatalError(scope $"NotEqualTo -> Expected: {expected}, Actual: {actual}");
		}

		[Inline]
#if DEBUG
		[SkipCall]
#endif
		public static void GreaterThan<T, K>(T actual, K expected)
			where bool : operator T > K
		{
			if (!(actual > expected))
				Runtime.FatalError(scope $"GreaterThan -> Expected: {expected}, Actual: {actual}");
		}

		[Inline]
#if DEBUG
		[SkipCall]
#endif
		public static void GreaterThanEqualTo<T, K>(T actual, K expected)
			where bool : operator T >= K
		{
			if (!(actual >= expected))
				Runtime.FatalError(scope $"GreaterThanEqualTo -> Expected: {expected}, Actual: {actual}");
		}

		[Inline]
#if DEBUG
		[SkipCall]
#endif
		public static void LessThan<T, K>(T actual, K expected)
			where bool : operator T < K
		{
			if (!(actual < expected))
				Runtime.FatalError(scope $"LessThan -> Expected: {expected}, Actual: {actual}");
		}

		[Inline]
#if DEBUG
		[SkipCall]
#endif
		public static void LessThanEqualTo<T, K>(T actual, K expected)
			where bool : operator T <= K
		{
			if (!(actual <= expected))
				Runtime.FatalError(scope $"LessThanEqualTo -> Expected: {expected}, Actual: {actual}");
		}
	}
}