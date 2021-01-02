using System;
using System.Collections;
namespace Atma
{
	[Serializable]
	public struct vec2<T>
	{
		public T x, y;
	}

	[Serializable]
	public struct TestStruct
	{
		public int x;
		public int y;
		public double z;
		public int32 t;
		public Test2Struct nested;
	}

	[Serializable]
	public struct TestArray
	{
		public int[] data;
	}

	[Serializable]
	public struct TestFixedArray
	{
		public int[2] data;
	}

	[Serializable]
	public struct Test2Struct
	{
		public int64 c;
		public String str;
	}


	[Serializable]
	public class TestClass
	{
		public int x;
		public int y;

		public String str = new .() ~ delete _;

		public this()
		{
		}

		public this(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public void HelloWorld()
		{
		}
	}
	
	[Serializable]
	public class ArrayTest
	{
		public int[] data ~ delete _;

		public this(params int[] args)
		{
			data = new int[args.Count];
			for (var i < args.Count)
				data[i] = args[i];
		}

		public static bool operator==(ArrayTest l, ArrayTest r)
		{
			if (l.data.Count != r.data.Count)
				return false;

			for (var i < l.data.Count)
				if (l.data[i] != r.data[i])
					return false;

			return true;
		}
	}

	[Serializable]
	public class SizedArrayTest
	{
		public int[5] data;

		public this(params int[] args)
		{
			for (var i < args.Count)
				data[i] = args[i];
		}

		public static bool operator==(SizedArrayTest l, SizedArrayTest r)
		{
			if (l.data.Count != r.data.Count)
				return false;

			for (var i < l.data.Count)
				if (l.data[i] != r.data[i])
					return false;

			return true;
		}
	}

	
	[Serializable]
	public class TargetWithAdd<T>
	{
		public List<T> data ~ delete _;

		public this(params T[] args)
		{
			data = new .();

			for (var i < args.Count)
				data.Add(args[i]);
		}

		public static bool operator==(TargetWithAdd<T> l, TargetWithAdd<T> r)
		{
			if (l.data.Count != r.data.Count)
				return false;

			for (var i < l.data.Count)
				if (l.data[i] != r.data[i])
					return false;

			return true;
		}
	}
}
