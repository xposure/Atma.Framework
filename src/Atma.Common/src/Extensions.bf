using System.IO;
using System.Collections;
using System;
using Atma;

//namespace Atma
//{
public static
{
	public static int CompareTo<T>(this T self, T other)
		where int : operator T <=> T
	{
		return self <=> other;
	}

	public static int nextInt(this Random r, int max) => r.Next(max);
	public static float2 nextFloat2(this Random r, float min, float max) => .(r.nextFloat(min, max), r.nextFloat(min, max));
	public static float2 nextFloat2(this Random r) => .(r.nextFloat(), r.nextFloat());
	public static float nextFloat(this Random r) => (float)r.NextDouble();
	public static float nextFloat(this Random r, float min, float max, bool allowNegative = false)
	{
		let d = max - min;
		if (allowNegative)
		{
			var f = r.NextDouble() * (d * 2);

			if (f < d)
				return -(float)(f + min);

			return (float)(f - d + min);
		}

		return (float)(r.NextDouble() * d + min);
	}

	//Random renferences https://stackoverflow.com/questions/218060/random-gaussian-variables
	//Random extensions taken from https://bitbucket.org/Superbest/superbest-random/src/master/


	public static float nextGaussianf(this Random r, double mu = 0, double sigma = 1) => (float)r.nextGaussian(mu, sigma);


	/// <summary>
	///   Generates normally distributed numbers. Each operation makes two Gaussians for the price of one, and
	// apparently they can be cached or something for better performance, but who cares. </summary> <param
	// name="r"></param> <param name = "mu">Mean of the distribution</param> <param name = "sigma">Standard
	// deviation</param> <returns></returns>
	public static double nextGaussian(this Random r, double mu = 0, double sigma = 1)
	{
		var u1 = r.NextDouble();
		var u2 = r.NextDouble();

		var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) *
			Math.Sin(2.0 * Math.PI_d * u2);

		var rand_normal = mu + sigma * rand_std_normal;

		return rand_normal;
	}

	/// <summary>
	///   Generates values from a triangular distribution.
	/// </summary>
	/// <remarks>
	/// See http://en.wikipedia.org/wiki/Triangular_distribution for a description of the triangular probability
	// distribution and the algorithm for generating one. </remarks> <param name="r"></param> <param name =
	// "a">Minimum</param> <param name = "b">Maximum</param> <param name = "c">Mode (most frequent value)</param> 
	// <returns></returns>
	public static double NextTriangular(this Random r, double a, double b, double c)
	{
		var u = r.NextDouble();

		return u < (c - a) / (b - a)
			? a + Math.Sqrt(u * (b - a) * (c - a))
			: b - Math.Sqrt((1 - u) * (b - a) * (b - c));
	}

	/// <summary>
	///   Equally likely to return true or false. Uses <see cref="Random.Next()"/>.
	/// </summary>
	/// <returns></returns>
	public static bool NextBoolean(this Random r)
	{
		return r.Next(2) > 0;
	}

	/// <summary>
	///   Shuffles a list in O(n) time by using the Fisher-Yates/Knuth algorithm.
	/// </summary>
	/// <param name="r"></param>
	/// <param name = "list"></param>
	public static void Shuffle<T>(this Random r, Span<T> list)
	{
		for (var i = 0; i < list.Length; i++)
		{
			var j = r.Next(0, i + 1);

			var temp = list[j];
			list[j] = list[i];
			list[i] = temp;
		}
	}

	public static bool Any<T, K>(this List<T> self, K dlg) where K : delegate bool(T t)
	{
		for (var it in ref self)
			if (dlg(it))
				return true;

		return false;
	}

	public static int IndexOf<T, K>(this List<T> self, K dlg) where K : delegate bool(T t)
	{
		for (var i < self.Count)
			if (dlg(self[i]))
				return i;

		return -1;
	}

	public static void RemoveFast<T, K>(this List<T> self, K dlg) where K : delegate bool(T t)
	{
		for (var it in self)
			if (dlg(it))
				@it.RemoveFast();
	}

	public static bool RemoveFast<T>(this List<T> self, T item)
	{
		var index = self.IndexOf(item);
		if (index >= 0)
		{
			self.RemoveAtFast(index);
			return true;
		}
		return false;
	}

	public static int Push<T>(this List<T> self, T item)
	{
		var index = self.Count;
		self.Add(item);
		return index;
	}

	public static uint8 ReadByte(this Stream stream)
	{
		let data = scope uint8[1];
		if (stream.TryRead(.(data)) == .Err)
			return default;

		return data[0];
	}

	public static void AppendLine(this String it)
	{
		it.Append(System.Environment.NewLine);
	}
}
//}

static
{
	/*[Inline]
	public static void ForXY<T>(int width, int height, T dlg) where T : delegate void(int x, int y)
	{
		for (int x < width)
			for (int y < height)
				dlg(x, y);
	}*/


	public static bool ReferenceEquals<T>(T left, T right)
		where T : class
	{
		if (left == null && right == null)
			return true;
		else if (left == null || right == null)
			return false;

		return left == right;
	}

	public static mixin Dispose(var container)
	{
		if (container != null)
		{
			for (var value in container)
			{
				value.Dispose();
			}
		}
	}

	public static mixin DeleteContainerItems(var container)
	{
		for (var value in container)
			delete value;
	}

	public static mixin DeleteAndDispose(var container)
	{
		if (container != null)
		{
			for (var value in container)
			{
				value.Dispose();
			}
			delete container;
		}
	}

	public static mixin DeleteDictionaryAndItems(var container)
	{
		if (container != null)
		{
			for (var value in container)
			{
				delete value.value;
			}
			delete container;
		}
	}
}


namespace System
{
	/*public extension Nullable<T>
		where bool : operator bool == bool
	{
		public static implicit operator T(Nullable<T> t)
		{
			if (!t.HasValue)
				return default;

			return t.Value;
		}
	}*/

	/*public extension Nullable<T> where bool : operator implicit T
	{
		public static implicit operator bool(Nullable<T> t)
		{
			return t.mValue;
		}
	}*/



	public extension String
	{
		public static explicit operator Span<char8>(String it) => Span<char8>(it.Ptr, it.Length);

	}


	public extension TimeSpan
	{
		public static TimeSpan FromTicks(int64 ticks) => TimeSpan(ticks);
		public static TimeSpan FromMilliseconds(int ms) => TimeSpan((int64)(ms * TimeSpan.TicksPerMillisecond));
		public static TimeSpan FromSeconds(float seconds) => TimeSpan((int64)(seconds * TimeSpan.TicksPerSecond));
		public static TimeSpan FromSeconds(double seconds) => TimeSpan((int64)(seconds * TimeSpan.TicksPerSecond));

		public static TimeSpan operator+(TimeSpan lhs, TimeSpan rhs) => TimeSpan(lhs.Ticks + rhs.Ticks);
		public static TimeSpan operator-(TimeSpan lhs, TimeSpan rhs) => TimeSpan(lhs.Ticks - rhs.Ticks);

	}
}

namespace System.Collections
{
	public extension List<T>
	{
		public void ForEach<K>(K dlg) where K : delegate void(T item)
		{
			for (var it in this)
				dlg(it);
		}

		/*public static implicit operator ReadOnlyList<T>(List<T> it) => .(it);
		public static implicit operator ReadOnlySpan<T>(List<T> it) => .(it.Ptr, it.Count);*/
	}


	public struct ReadOnlySpan<T>
	{
		private T* _ptr;
		private int _length;

		public int Length => _length;

		public T this[int index]
		{
			get
			{
				Runtime.Assert(index >= 0 && index < _length);
				return _ptr[index];
			}
		}

		public this(T* ptr, int length)
		{
			_ptr = ptr;
			_length = length;
		}

		public this(T[] data) : this(&data[0], data.Count)
		{
		}

		public this(T[] data, int count) : this(&data[0], count)
		{
		}

	}

	public struct ReadOnlyList<T> : IEnumerable<T>
	{
		private readonly List<T> _list;

		public T Back => _list[_list.Count - 1];

		public int Count => _list.Count;

		public this(List<T> list)
		{
			_list = list;
		}

		public T this[int index]
		{
			get => _list[index];
		}

		public List<T>.Enumerator GetEnumerator() => _list.GetEnumerator();
	}

	public struct ReadOnlyDictionary<T, K> : IEnumerable<(T key, K value)>
		where T : IHashable
	{
		private readonly Dictionary<T, K> _dict;

		public int Count => _dict.Count;

		public this(Dictionary<T, K> dict)
		{
			_dict = dict;
		}

		public K this[T key]
		{
			get => _dict[key];
		}

		public Dictionary<T, K>.Enumerator GetEnumerator() => _dict.GetEnumerator();

		public System.Collections.Dictionary<T, K>.ValueEnumerator Keys => _dict.Values;
		public System.Collections.Dictionary<T, K>.ValueEnumerator Values => _dict.Values;
	}
}

