using System;
using System.Text;

namespace Atma
{
	public struct axis
	{
		public float2 normal;
		public float2 unit;
		public float2 edge;

		public readonly static axis Zero = .(float2.Zero, float2.Zero, float2.Zero);

		public this()
		{
			this = default;
		}

		public this(float2 n, float2 u, float2 e)
		{
			this.normal = n;
			this.unit = u;
			this.edge = e;
		}

		public override void ToString(String output)
		{
			output.AppendF("N:{0}, U:{1}, E:{2}", normal, unit, edge);
		}
	}
}