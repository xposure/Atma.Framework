using System;

namespace Atma
{
	public static
	{
		public static void InsertionSort(this Span<int> span)
		{
			for (var i = 0; i < span.Length - 1; i++)
			{
				for (var j = i + 1; j > 0; j--)
				{
					if (span[j - 1] > span[j])
					{
						var temp = span[j - 1];
						span[j - 1] = span[j];
						span[j] = temp;
					}
				}
			}
		}

		public static void InsertionSort<T>(this Span<T> span)
			where T : struct, IHashable
		{
			for (var i = 0; i < span.Length - 1; i++)
			{
				for (var j = i + 1; j > 0; j--)
				{
					if (span[j - 1].GetHashCode() > span[j].GetHashCode())
					{
						var temp = span[j - 1];
						span[j - 1] = span[j];
						span[j] = temp;
					}
				}
			}
		}

		public static void Sort<T>(this Span<T> span)
			where T : struct
			where int : operator T <=> T
		{
			for (var i = 0; i < span.Length; ++i)
			{
				for (var j = 0; j < span.Length - 1; ++j)
				//TODO: this code doesn't appear correct to me, j shouldn't start at 0?
				{
					if (span[j] <=> span[j + 1] > 0)
					{
						var temp = span[j];
						span[j] = span[j + 1];
						span[j + 1] = temp;
					}
				}
			}
		}

		public static void Sort<T, TComparer>(this Span<T> span, TComparer comparer)
			where T : struct
			where TComparer : Comparison<T>
		{
			for (var i = 0; i < span.Length; ++i)
			{
				//TODO: this code doesn't appear correct to me, j shouldn't start at 0?
				for (var j = 0; j < span.Length - 1; ++j)
				{
					if (comparer(span[j], span[j + 1]) > 0)
					{
						var temp = span[j];
						span[j] = span[j + 1];
						span[j + 1] = temp;
					}
				}
			}
		}

		//public static void Sort<TKey, TValue>(this Span<TKey> keys, Span<TValue> items);

		//public static void Sort<TKey, TValue, TComparer>(this Span<TKey> keys,
		//   Span<TValue> items, TComparer comparer)
		//   where TComparer : IComparer<TKey>;

		//public static void Sort<TKey, TValue>(this Span<TKey> keys,
		//   Span<TValue> items, System.Comparison<TKey> comparison);
	}
}
