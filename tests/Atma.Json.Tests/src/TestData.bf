using System;
namespace Atma
{
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
	public struct Test2Struct
	{
		public int64 c;
		public String str;
	}


	[Serializable]
		[Reflect(.All)]
		[AlwaysInclude(AssumeInstantiated = true, IncludeAllMethods = true)]
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
}
