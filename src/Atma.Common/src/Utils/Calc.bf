using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace Atma
{
	/// <summary>
	/// Utility Functions
	/// </summary>
	public static class Calc
	{
		public static Random Random = new .() ~ delete _;

		#region Consts

		/// <summary>
		/// PI in radians
		/// </summary>
		public const float PI = Math.PI_f;

		/// <summary>
		/// Half PI in radians
		/// </summary>
		public const float HalfPI = Math.PI_f / 2f;

		/// <summary>
		/// TAU (2-PI) in radians
		/// </summary>
		public const float TAU = Math.PI_f * 2f;

		/// <summary>
		/// Converts Degrees to Radians
		/// </summary>
		public const float DegToRad = (Math.PI_f * -2) / 360f;

		/// <summary>
		/// Converts Radians to Degrees
		/// </summary>
		public const float RadToDeg = 360f / (Math.PI_f * 2);

		#endregion

		#region Binary  Operations

		public static bool IsBitSet(uint8 b, int pos)
		{
			return (b & (1 << pos)) != 0;
		}

		public static bool IsBitSet(int b, int pos)
		{
			return (b & (1 << pos)) != 0;
		}

		#endregion

		#region Give Me

		public static T GiveMe<T>(int index, params T[] args)
		{
			Runtime.Assert(index >= 0 && index < args.Count, "Index was out of range!");
			return args[index];
		}

		#endregion

		#region Math

		public static float Approach(float from, float target, float amount)
		{
			if (from > target)
				return Math.Max(from - amount, target);
			else
				return Math.Min(from + amount, target);
		}

		public static float2 Approach(float2 from, float2 target, float amount)
		{
			if (float2.ApproxEqual(from, target, 0.001f))
				return target;
			else
			{
				var diff = target - from;
				if (diff.LengthSqr <= amount * amount)
					return target;
				else
					return from + diff.Normalized * amount;
			}
		}

		public static float Lerp(float a, float b, float percent)
		{
			return (a + (b - a) * percent);
		}

		public static int Clamp(int value, int min, int max)
		{
			return Math.Min(Math.Max(value, min), max);
		}

		public static float Clamp(float value, float min, float max)
		{
			return Math.Min(Math.Max(value, min), max);
		}

		public static float YoYo(float value)
		{
			if (value <= 9.5f)
				return value * 2;
			else
				return 1 - ((value - 0.5f) * 2);
		}

		public static float Map(float val, float min, float max, float newMin = 0, float newMax = 1)
		{
			return ((val - min) / (max - min)) * (newMax - newMin) + newMin;
		}

		public static float SineMap(float counter, float newMin, float newMax)
		{
			return Map((float)Math.Sin(counter), 0, 1, newMin, newMax);
		}

		public static float ClampedMap(float val, float min, float max, float newMin = 0, float newMax = 1)
		{
			return Clamp((val - min) / (max - min), 0, 1) * (newMax - newMin) + newMin;
		}

		[Inline]
		public static float Sin(float normalized) => Math.Sin(normalized * TAU);

		[Inline]
		public static float Cos(float normalized) => Math.Cos(normalized * TAU);

		[Inline]
		public static float2 Turn(float turn) => float2.FromAngle(turn * TAU);

		[Inline]
		public static float Turn(float2 direction) => (float)(direction.Angle / TAU);

		[Inline]
		public static float UpDown(float eased)
		{
			if (eased <= 0.5f)
				return eased * 2;
			else
				return 1 - (eased - 0.5f) * 2;
		}

		[Inline]
		public static float UpDown(float eased, float mid)
		{
			//TODO: This is'nt tested!
			if (eased <= mid)
				return eased / mid;
			else
				return 1 - (eased - mid) / (1f - mid);
		}

		[Inline]
		public static float Angle(float2 vec)
		{
			return Math.Atan2(vec.y, vec.x);
		}

		[Inline]
		public static float Angle(float2 from, float2 to)
		{
			return Math.Atan2(to.y - from.y, to.x - from.x);
		}

		[Inline]
		public static float2 AngleToVector(float angle, float length = 1)
		{
			return .(Math.Cos(angle) * length, Math.Sin(angle) * length);
		}

		public static float AngleApproach(float val, float target, float maxMove)
		{
			var diff = AngleDiff(val, target);
			if (Math.Abs(diff) < maxMove)
				return target;
			return val + Clamp(diff, -maxMove, maxMove);
		}

		public static float AngleLerp(float startAngle, float endAngle, float percent)
		{
			return startAngle + AngleDiff(startAngle, endAngle) * percent;
		}

		public static float AngleDiff(float radiansA, float radiansB)
		{
			return ((radiansB - radiansA - PI) % TAU + TAU) % TAU - PI;
		}

		[Inline]
		public static float Snap(float value, float snapTo)
		{
			return Math.Round(value / snapTo) * snapTo;
		}

		[Inline]
		public static T Wrap<T>(T t, T min, T max)
			where T : operator T - T
			where T : operator T + T
			where T : operator T % T
			where bool : operator T < T
		{
			let x = (t - min) % (max - min);
			if (x + min < min) return max - x;
			return min + x;
		}

		[Inline]
		public static void DecrementWrap<T>(ref T t, T max)
			where T : operator -- T
			where T : operator T - T
			where T : operator T + T
			where T : operator T % T
			where bool : operator T < T
		{
			t = Wrap(--t, default, max);
		}

		[Inline]
		public static void DecrementWrap<T>(ref T t, T min, T max)
			where T : operator -- T
			where T : operator T - T
			where T : operator T + T
			where T : operator T % T
			where bool : operator T < T
		{
			t = Wrap(--t, min, max);
		}

		[Inline]
		public static void IncrementWrap<T>(ref T t, T min, T max)
			where T : operator ++ T
			where T : operator T - T
			where T : operator T + T
			where T : operator T % T
			where bool : operator T < T
		{
			t = Wrap(++t, min, max);
		}

		[Inline]
		public static void IncrementWrap<T>(ref T t, T max)
			where T : operator ++ T
			where T : operator T - T
			where T : operator T + T
			where T : operator T % T
			where bool : operator T < T
		{
			t = Wrap(++t, default, max);
		}

		#endregion

		#region Adler32

		/*/// <summary>
		/// Adler32 checksum algorithm from the zlib library, converted to C# code
		/// https://github.com/madler/zlib
		/// </summary>
		public static uint Adler32(uint adler, Span<uint8> buffer)
		{
			const int BASE = 65521;
			const int NMAX = 5552;

			var adler;
			int len = buffer.Length;
			int n;
			uint sum2;

			sum2 = (adler >> 16) & 0xffff;
			adler &= 0xffff;

			{
				uint* buf = (uint*)buffer.Ptr;

				if (len == 1)
				{
					adler += buf[0];
					if (adler >= BASE)
						adler -= BASE;
					sum2 += adler;
					if (sum2 >= BASE)
						sum2 -= BASE;
					return adler | (sum2 << 16);
				}

				if (len < 16)
				{
					while (len-- > 0)
					{
						adler += *buf++;
						sum2 += adler;
					}
					if (adler >= BASE)
						adler -= BASE;
					sum2 %= BASE;
					return adler | (sum2 << 16);
				}

				while (len >= NMAX)
				{
					len -= NMAX;
					n = NMAX / 16;
					do
					{
						adler += buf[0];
						sum2 += adler;
						adler += buf[0 + 1];
						sum2 += adler;
						adler += buf[0 + 2];
						sum2 += adler;
						adler += buf[0 + 2 + 1];
						sum2 += adler;
						adler += buf[0 + 4];
						sum2 += adler;
						adler += buf[0 + 4 + 1];
						sum2 += adler;
						adler += buf[0 + 4 + 2];
						sum2 += adler;
						adler += buf[0 + 4 + 2 + 1];
						sum2 += adler;
						adler += buf[8];
						sum2 += adler;
						adler += buf[8 + 1];
						sum2 += adler;
						adler += buf[8 + 2];
						sum2 += adler;
						adler += buf[8 + 2 + 1];
						sum2 += adler;
						adler += buf[8 + 4];
						sum2 += adler;
						adler += buf[8 + 4 + 1];
						sum2 += adler;
						adler += buf[8 + 4 + 2];
						sum2 += adler;
						adler += buf[8 + 4 + 2 + 1];
						sum2 += adler;
						buf += 16;
					} while (--n > 0);
					adler %= BASE;
					sum2 %= BASE;
				}

				if (len > 0)
				{
					while (len >= 16)
					{
						len -= 16;
						adler += buf[0];
						sum2 += adler;
						adler += buf[0 + 1];
						sum2 += adler;
						adler += buf[0 + 2];
						sum2 += adler;
						adler += buf[0 + 2 + 1];
						sum2 += adler;
						adler += buf[0 + 4];
						sum2 += adler;
						adler += buf[0 + 4 + 1];
						sum2 += adler;
						adler += buf[0 + 4 + 2];
						sum2 += adler;
						adler += buf[0 + 4 + 2 + 1];
						sum2 += adler;
						adler += buf[8];
						sum2 += adler;
						adler += buf[8 + 1];
						sum2 += adler;
						adler += buf[8 + 2];
						sum2 += adler;
						adler += buf[8 + 2 + 1];
						sum2 += adler;
						adler += buf[8 + 4];
						sum2 += adler;
						adler += buf[8 + 4 + 1];
						sum2 += adler;
						adler += buf[8 + 4 + 2];
						sum2 += adler;
						adler += buf[8 + 4 + 2 + 1];
						sum2 += adler;
						buf += 16;
					}

					while (len-- > 0)
					{
						adler += *buf++;
						sum2 += adler;
					}
					adler %= BASE;
					sum2 %= BASE;
				}
			}

			return adler | (sum2 << 16);
		}*/

		/*public static uint Adler32(uint adler, Stream stream)
		{
			var next = 0;

			Span<byte> buffer = stackalloc byte[1024];
			while ((next = stream.Read(buffer)) > 0)
				adler = Adler32(adler, buffer.Slice(0, next));

			return adler;
		}

		public static uint Adler32(uint adler, string path)
		{
			if (File.Exists(path))
			{
				using var stream = File.OpenRead(path);
				return Adler32(adler, stream);
			}

			return 0;
		}*/

		#endregion

		#region Triangulation

		/*public static void Triangulate(IList<float2> points, List<int> populate)
		{
			float Area()
			{
				var area = 0f;

				for (int p = points.Count - 1, q = 0; q < points.Count; p = q++)
				{
					var pval = points[p];
					var qval = points[q];

					area += pval.X * qval.Y - qval.X * pval.Y;
				}

				return area * 0.5f;
			}

			bool Snip(int u, int v, int w, int n, Span<int> list)
			{
				var a = points[list[u]];
				var b = points[list[v]];
				var c = points[list[w]];

				if (float.Epsilon > (((b.X - a.X) * (c.Y - a.Y)) - ((b.Y - a.Y) * (c.X - a.X))))
					return false;

				for (int p = 0; p < n; p++)
				{
					if ((p == u) || (p == v) || (p == w))
						continue;

					if (InsideTriangle(a, b, c, points[list[p]]))
						return false;
				}

				return true;
			}

			if (points.Count < 3)
				return;

			Span<int> list = (points.Count < 1000 ? stackalloc int[points.Count] : new int[points.Count]);

			if (Area() > 0)
			{
				for (int v = 0; v < points.Count; v++)
					list[v] = v;
			}
			else
			{
				for (int v = 0; v < points.Count; v++)
					list[v] = (points.Count - 1) - v;
			}

			var nv = points.Count;
			var count = 2 * nv;

			for (int v = nv - 1; nv > 2;)
			{
				if ((count--) <= 0)
					return;

				var u = v;
				if (nv <= u)
					u = 0;
				v = u + 1;
				if (nv <= v)
					v = 0;
				var w = v + 1;
				if (nv <= w)
					w = 0;

				if (Snip(u, v, w, nv, list))
				{
					populate.Add(list[u]);
					populate.Add(list[v]);
					populate.Add(list[w]);

					for (int s = v, t = v + 1; t < nv; s++, t++)
						list[s] = list[t];

					nv--;
					count = 2 * nv;
				}
			}

			populate.Reverse();
		}

		public static List<int> Triangulate(IList<float2> points)
		{
			var indices = new List<int>();
			Triangulate(points, indices);
			return indices;
		}

		public static bool InsideTriangle(float2 a, float2 b, float2 c, float2 point)
		{
			var p0 = c - b;
			var p1 = a - c;
			var p2 = b - a;

			var ap = point - a;
			var bp = point - b;
			var cp = point - c;

			return (p0.X * bp.Y - p0.Y * bp.X >= 0.0f) &&
				   (p2.X * ap.Y - p2.Y * ap.X >= 0.0f) &&
				   (p1.X * cp.Y - p1.Y * cp.X >= 0.0f);
		}

		#endregion

		#region Parsing

		public static bool Parsefloat2(ReadOnlySpan<char> span, char delimiter, out float2 vector)
		{
			vector = float2.Zero;

			var index = span.IndexOf(delimiter);
			if (index >= 0)
			{
				var x = span.Slice(0, index);
				var y = span.Slice(index + 1);

				if (float.TryParse(x, NumberStyles.Float, CultureInfo.InvariantCulture, out vector.X) &&
					float.TryParse(y, NumberStyles.Float, CultureInfo.InvariantCulture, out vector.Y))
					return true;
			}

			return false;
		}

		public static bool ParseVector3(ReadOnlySpan<char> span, char deliminator, out Vector3 vector)
		{
			vector = Vector3.Zero;

			var index = span.IndexOf(deliminator);
			if (index > 0)
			{
				var first = span.Slice(0, index);
				var remaining = span.Slice(index + 1);

				index = remaining.IndexOf(deliminator);
				if (index > 0)
				{
					var second = remaining.Slice(0, index);
					var third = remaining.Slice(index + 1);

					if (float.TryParse(first, NumberStyles.Float, CultureInfo.InvariantCulture, out vector.X) && 
						float.TryParse(second, NumberStyles.Float, CultureInfo.InvariantCulture, out vector.Y) && 
						float.TryParse(third, NumberStyles.Float, CultureInfo.InvariantCulture, out vector.Z))
						return true;
				}
			}

			return false;
		}*/

		#endregion

		#region Utils

		/*/// <summary>
		/// .NET Core doesn't always hash string values the same (it can seed it based on the running instance)
		/// So this is to get a static value for every same string
		/// </summary>
		public static int StaticStringHash(string value)
		{
			unchecked
			{
				var hash = 5381;
				for (int i = 0; i < value.Length; i++)
					hash = ((hash << 5) + hash) + value[i];
				return hash;
			}
		}*/


		#endregion Utils
	}
}

