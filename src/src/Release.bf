using System;
using System.Collections;

public static
{
	/*// Common case for any value type
	public static void Release<T>(ref T value) where T : struct, IDisposable
	{
		// do nothing
		value.Dispose();
	}*/

	// Common case for any value type
	[SkipCall]
	public static void Release<T>(T value) where T : struct
	{
		// do nothing
	}

	public static void Release<T>(T value) where T : struct, IDisposable
	{
		var value;
		value.Dispose();
	}

	// Delete deletable types
	public static void Release<T>(T value) where T : class, delete
	{
		delete value;
	}

	// Delete deletable types
	public static void Release<K, V>((K key, V value) kv) where K : var where V : var
	{
		Release(kv.key);
		Release(kv.value);
	}

	// Delete array items and then the array itself
	public static void Release<T>(T[] value) where T : var
	{
		if (value == null)
			return;
		for (int i = 0; i < value.Count; i++)
			Release(value[i]);
		delete value;
	}

	// Delete fixed array items
	public static void Release<T, U>(T[U] value) where T : var where U : const int
	{
		for (int i = 0; i < U; i++)
			Release(value[i]);
	}

	// Delete list items and then the list itself
	public static void Release<T>(List<T> value) where T : var
	{
		if (value == null)
			return;
		for (int i = 0; i < value.Count; i++)
			Release(value[i]);

		//value.Clear();
		delete value;
	}

	// Delete dictionary keys and values and then the dictionary itself
	public static void Release<K, V>(Dictionary<K, V> value) where K : var, IHashable where V : var
	{
		if (value == null)
			return;
		for (var kv in ref value)
		{
			Release(kv.key);
			Release(*kv.valueRef);
		}
		delete value;
	}
}