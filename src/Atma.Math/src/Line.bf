using System.Collections;
using System;
namespace Atma
{
	public struct Line2i
	{
		public int2 Start, End;

		public this(int2 start, int2 end)
		{
			Start = start;
			End = end;
		}

		public bool Intersects(Line2i a, Line2i b, out float2 point)
		{
			// calculate the direction of the lines
			let x1 = a.Start.x;
			let x2 = a.End.x;
			let x3 = b.Start.x;
			let x4 = b.End.x;
			let y1 = a.Start.y;
			let y2 = a.End.y;
			let y3 = b.Start.y;
			let y4 = b.End.y;

			float uA = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));
			float uB = ((x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));

			// if uA and uB are between 0-1, lines are colliding
			if (uA >= 0 && uA <= 1 && uB >= 0 && uB <= 1)
			{
				point = .(x1 + (uA * (x2 - x1)), y1 + (uA * (y2 - y1)));
				return true;
			}
			point = default;
			return false;
		}

		public Enumerator GetEnumerator() => Enumerator(Start, End);

		public struct Enumerator : IEnumerator<int2>
		{
			int ix;// = 0;
			int iy;// = 0;
			int nx;// = 0;
			int ny;// = 0;
			int sign_x;// = 0;
			int sign_y;// = 0;
			int2 p;


			public this(int2 p0, int2 p1)
			{
				let dx = p1.x - p0.x;
				let dy = p1.y - p0.y;
				nx = Math.Abs(dx);
				ny = Math.Abs(dy);
				sign_x = dx > 0 ? 1 : -1;
				sign_y = dy > 0 ? 1 : -1;

				ix = 0;
				iy = 0;
				p = p0;
			}

			public System.Result<int2> GetNext() mut
			{
				if (ix < nx || iy < ny)
				{
					let r = p;
					if ((0.5 + ix) / nx < (0.5 + iy) / ny)
					{
						// next step is horizontal
						p.x += sign_x;
						ix++;
					} else
					{
						// next step is vertical
						p.y += sign_y;
						iy++;
					}

					return .Ok(r);
				}
				else
					return .Err;
			}
		}
	}


	public struct Line2f
	{
		public float2 Start, End;

		public this(float2 start, float2 end)
		{
			Start = start;
			End = end;
		}

		public bool Intersects(Line2f a, Line2f b, out float2 point)
		{
			// calculate the direction of the lines
			let x1 = a.Start.x;
			let x2 = a.End.x;
			let x3 = b.Start.x;
			let x4 = b.End.x;
			let y1 = a.Start.y;
			let y2 = a.End.y;
			let y3 = b.Start.y;
			let y4 = b.End.y;

			float uA = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));
			float uB = ((x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));

			// if uA and uB are between 0-1, lines are colliding
			if (uA >= 0 && uA <= 1 && uB >= 0 && uB <= 1)
			{
				point = .(x1 + (uA * (x2 - x1)), y1 + (uA * (y2 - y1)));
				return true;
			}
			point = default;
			return false;
		}

		public bool Intersects(Line2f a, Line2f b)
		{
			// calculate the direction of the lines
			let x1 = a.Start.x;
			let x2 = a.End.x;
			let x3 = b.Start.x;
			let x4 = b.End.x;
			let y1 = a.Start.y;
			let y2 = a.End.y;
			let y3 = b.Start.y;
			let y4 = b.End.y;

			float uA = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));
			float uB = ((x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));

			// if uA and uB are between 0-1, lines are colliding
			if (uA >= 0 && uA <= 1 && uB >= 0 && uB <= 1)
				return true;

			return false;
		}

		public bool Intersects(aabb2 aabb)
		{
			return
				Intersects(this, .(aabb.TopLeft, aabb.TopRight)) ||
				Intersects(this, .(aabb.TopRight, aabb.BottomRight)) ||
				Intersects(this, .(aabb.BottomRight, aabb.BottomLeft)) ||
				Intersects(this, .(aabb.BottomLeft, aabb.TopLeft));
		}
	}
}
