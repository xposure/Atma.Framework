using System.Collections;
namespace Atma
{
	public static
	{
		/*public static K Min<T, K, F>(this List<T> items, Func<T, K> dlg)
			where bool : operator K < K
		{
			var enumerator = items.GetEnumerator();

			if (!enumerator.MoveNext())
				return default;

			var t = dlg(enumerator.Current);
			while (enumerator.MoveNext())
			{
				let r = dlg(enumerator.Current);
				if (r < t)
					t = r;
			}

			return t;
		}*/

		/*public static T Min<T>(this List<T> items)
			where bool : operator T < T
		{
			var first = true;
			T current = default;
			for (var it in items)
			{
				if (first)
				{
					current = it;
					first = false;
				}
				else if (it < current)
				{
					current = it;
				}
			}

			return current;
		}*/


		//public void ForEach<K>(K dlg) where K : delegate void(T item)

		public static K Max<T, K, F>(this List<T> items, F dlg)
			where bool : operator K > K
			where F : delegate K(T item)
		{
			var first = true;
			K current = default;
			for (var it in items)
			{
				let r = dlg(it);

				if (first)
				{
					current = r;
					first = false;
				}
				else if (r > current)
				{
					current = r;
				}
			}

			return current;
		}

		/*public static T Max<T>(this List<T> items)
			where bool : operator T > T
		{
			var first = true;
			T current = default;
			for (var it in items)
			{
				if (first)
				{
					current = it;
					first = false;
				}
				else if (it > current)
				{
					current = it;
				}
			}

			return current;
		}*/

		/*public static mixin Max(var items)
		{
			var current = items[0];
			for(var i = 1; i < items.Count;i++)
			{
				if (items[i] > current)
				{
					current = items[i];
				}
			}

			return current;
		}*/
	}
}
