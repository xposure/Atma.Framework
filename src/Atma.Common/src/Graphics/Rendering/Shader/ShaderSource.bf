using System;
namespace Atma
{
	public class ShaderSource
	{
		public String Vertex = new .() ~ delete _;
		public String Fragment = new .() ~ delete _;
		//public String Geometry;

		//Copies the string source data to local variables
		public this(StringView vertexSource, StringView fragmentSource/*, String? geomSource = null*/)
		{
			Vertex.Set(vertexSource);
			Fragment.Set(fragmentSource);
		}
	}
}

