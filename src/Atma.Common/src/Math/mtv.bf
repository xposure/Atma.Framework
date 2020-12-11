using System;
using System.Text;

namespace Atma
{
	public struct mtv
	{
		public double overlap;
		public axis smallest;

		public bool intersects { get { return overlap != 0; } }

		public readonly static mtv Zero = .(axis.Zero, 0);

		public this(axis smallest, double overlap)
		{
			this.smallest = smallest;
			this.overlap = overlap;
		}

		public override void ToString(String output)
		{
			output.AppendF("O: {0}, A:{{{1}}}", overlap, smallest);
		}
	}
}