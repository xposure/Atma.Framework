using System;
using System.Collections;

namespace Atma
{
	/// <summary>
	/// Random Utilities
	/// </summary>
	public static class Rand
	{
		public static Random Instance = new Random() ~ delete _;
		private static readonly List<Random> _stack = new List<Random>() ~ DeleteContainerAndItems!(_);

		public static void Push(int newSeed)
		{
			_stack.Add(Instance);
			Instance = new Random(newSeed);
		}

		public static void Push(Random random)
		{
			_stack.Add(Instance);
			Instance = random;
		}

		public static void Push()
		{
			_stack.Add(Instance);
			Instance = new Random();
		}

		public static void Pop()
		{
			Instance = _stack.PopBack();
		}

		public static float NextFloat(this Random random)
		{
			return (float)random.NextDouble();
		}

		public static float NextFloat(this Random random, float max)
		{
			return random.NextFloat() * max;
		}

		public static float NextFloat(this Random random, float min, float max)
		{
			return min + random.NextFloat() * (max - min);
		}

		public static double NextDouble(this Random random, double max)
		{
			return random.NextDouble() * max;
		}

		public static double NextDouble(this Random random, double min, double max)
		{
			return min + random.NextDouble() * (max - min);
		}

		/// <summary>
		/// Returns a random integer between min (inclusive) and max (exclusive)
		/// </summary>
		public static int Range(this Random random, int min, int max)
		{
			return min + random.Next(max - min);
		}

		/// <summary>
		/// Returns a random float between min (inclusive) and max (exclusive)
		/// </summary>
		public static float Range(this Random random, float min, float max)
		{
			return min + random.NextFloat(max - min);
		}

		/// <summary>
		/// Returns a random float2, and x- and y-values of which are between min (inclusive) and max (exclusive)
		/// </summary>
		public static float2 Range(this Random random, float2 min, float2 max)
		{
			return min + .(random.NextFloat(max.x - min.x), random.NextFloat(max.y - min.y));
		}

		public static T Choose<T>(this Random random, T a, T b)
		{
			return Calc.GiveMe<T>(random.Next(2), a, b);
		}

		public static T Choose<T>(this Random random, T a, T b, T c)
		{
			return Calc.GiveMe<T>(random.Next(3), a, b, c);
		}

		public static T Choose<T>(this Random random, T a, T b, T c, T d)
		{
			return Calc.GiveMe<T>(random.Next(4), a, b, c, d);
		}

		public static T Choose<T>(this Random random, T a, T b, T c, T d, T e)
		{
			return Calc.GiveMe<T>(random.Next(5), a, b, c, d, e);
		}

		public static T Choose<T>(this Random random, T a, T b, T c, T d, T e, T f)
		{
			return Calc.GiveMe<T>(random.Next(6), a, b, c, d, e, f);
		}

		public static T Choose<T>(this Random random, params T[] choices)
		{
			return choices[random.Next(choices.Count)];
		}

		public static T Choose<T>(this Random random, List<T> choices)
		{
			return choices[random.Next(choices.Count)];
		}

		public static T Choose<T>(this Random random, Span<T> choices)
		{
			return choices[random.Next(choices.Length)];
		}
	}
}

