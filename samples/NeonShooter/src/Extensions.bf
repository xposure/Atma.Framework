using System;
using System.Collections;
namespace Atma
{
	public extension Subtexture
	{
		public enum TileMask
		{
			case None = 0;
			case NW = 1;
			case N = 2;
			case NE = 4;
			case E = 8;
			case SE = 16;
			case S = 32;
			case SW = 64;
			case W = 128;

			case ALL = 0xff;

			public TileMask MirrorX
			{
				get
				{
					var mirror = TileMask.None;
					if (this.HasFlag(.W)) mirror |= .E;
					if (this.HasFlag(.E)) mirror |= .W;
					if (this.HasFlag(.NW)) mirror |= .NE;
					if (this.HasFlag(.NE)) mirror |= .NW;
					if (this.HasFlag(.SW)) mirror |= .SE;
					if (this.HasFlag(.SE)) mirror |= .SW;
					if (this.HasFlag(.N)) mirror |= .N;
					if (this.HasFlag(.S)) mirror |= .S;

					return mirror;
				}
			}

			public TileMask MirrorY
			{
				get
				{
					var mirror = TileMask.None;
					if (this.HasFlag(.W)) mirror |= .W;
					if (this.HasFlag(.E)) mirror |= .E;
					if (this.HasFlag(.NW)) mirror |= .SW;
					if (this.HasFlag(.NE)) mirror |= .SE;
					if (this.HasFlag(.SW)) mirror |= .NW;
					if (this.HasFlag(.SE)) mirror |= .NE;
					if (this.HasFlag(.N)) mirror |= .S;
					if (this.HasFlag(.S)) mirror |= .N;

					return mirror;
				}
			}



			public override void ToString(String strBuffer)
			{
				var first = true;
				for (var i < 8)
				{
					let mask = 1 << i;
					if (((int)this & mask) == mask)
					{
						if (first)
							strBuffer.AppendF("(");

						if (!first)
							strBuffer.Append(",");

						Enum.EnumToString(typeof(TileMask), strBuffer, mask);
						//let m = ((TileMask)(int)mask);
						//m.BaseToString(strBuffer);
						//strBuffer.AppendF("{0}", (TileMask)mask);

						first = false;
					}
				}
				if (!first)
					strBuffer.AppendF(")");
			}

			public void Debug(StringView name)
			{
				let s = scope String();

				s.Append(name);
				s.Append(": ");

				ToString(s);
			}
		}

		private struct AutoTileRule
		{
			public readonly TileMask Flags;
			public readonly Subtexture Texture;

			public this(TileMask flags, Subtexture texture)
			{
				Flags = flags;
				Texture = texture;
			}
		}

		public void Blob(ref Subtexture[256] list)
		{
			let columns = 11;
			let rows = 5;
			let tgrid = scope Subtexture[columns, rows];
			let w = Width / columns;
			let h = Height / rows;

			for (var x < columns)
				for (var y < rows)
					tgrid[x, y] = GetClipSubtexture(.(x * w, y * h, w, h));


			let rules = scope List<AutoTileRule>();

			//rect
			rules.Add(.(.E | .S | .SE, tgrid[0, 0]));
			rules.Add(.(.W | .S | .E | .SW | .SE, tgrid[1, 0]));
			rules.Add(.(.W | .S | .SW, tgrid[2, 0]));

			rules.Add(.(.N | .E | .S | .NE | .SE, tgrid[0, 1]));
			rules.Add(.(.N | .E | .S | .W | .NW | .NE | .SE | .SW, tgrid[1, 1]));
			rules.Add(.(.N | .S | .W | .NW | .SW, tgrid[2, 1]));

			rules.Add(.(.E | .N | .NE, tgrid[0, 2]));
			rules.Add(.(.W | .N | .E | .NW | .NE, tgrid[1, 2]));
			rules.Add(.(.W | .N | .NW, tgrid[2, 2]));

			//line vert
			rules.Add(.(.S, tgrid[3, 0]));
			rules.Add(.(.N | .S, tgrid[3, 1]));
			rules.Add(.(.N, tgrid[3, 2]));

			//line hort
			rules.Add(.(.E, tgrid[0, 3]));
			rules.Add(.(.W | .E, tgrid[1, 3]));
			rules.Add(.(.W, tgrid[2, 3]));

			//none
			rules.Add(.(0, tgrid[3, 3]));


			rules.Add(.(.E | .S, tgrid[4, 0]));
			rules.Add(.(.W | .E | .S | .SW, tgrid[5, 0]));
			rules.Add(.(.W | .E | .S | .SE, tgrid[6, 0]));
			rules.Add(.(.W | .S, tgrid[7, 0]));

			rules.Add(.(.N | .E | .S | .NE, tgrid[4, 1]));
			rules.Add(.(.N | .W | .E | .S | .SW | .NW | .NE, tgrid[5, 1]));
			rules.Add(.(.N | .W | .E | .S | .SE | .NW | .NE, tgrid[6, 1]));
			rules.Add(.(.N | .W | .S | .NW, tgrid[7, 1]));

			rules.Add(.(.N | .E | .S | .SE, tgrid[4, 2]));
			rules.Add(.(.N | .W | .E | .S | .SW | .NW | .SE, tgrid[5, 2]));
			rules.Add(.(.N | .W | .E | .S | .SE | .SW | .NE, tgrid[6, 2]));
			rules.Add(.(.N | .W | .S | .SW, tgrid[7, 2]));

			rules.Add(.(.E | .N, tgrid[4, 3]));
			rules.Add(.(.W | .E | .N | .NW, tgrid[5, 3]));
			rules.Add(.(.W | .E | .N | .NE, tgrid[6, 3]));
			rules.Add(.(.W | .N, tgrid[7, 3]));


			rules.Add(.(.N | .S | .E, tgrid[4, 4]));
			rules.Add(.(.N | .S | .E | .W | .NW | .SW, tgrid[5, 4]));
			rules.Add(.(.N | .S | .E | .W | .NE | .SE, tgrid[6, 4]));
			rules.Add(.(.N | .S | .W, tgrid[7, 4]));



			rules.Add(.(.W | .S | .E, tgrid[8, 0]));
			rules.Add(.(.N | .S | .E | .W | .NW | .SE, tgrid[9, 0]));

			rules.Add(.(.N | .S | .E | .W | .NW | .NE, tgrid[8, 1]));
			rules.Add(.(.N | .S | .E | .W | .SW | .NE, tgrid[9, 1]));

			rules.Add(.(.N | .S | .E | .W | .SW | .SE, tgrid[8, 2]));
			rules.Add(.(.N | .S | .E | .W | .SE, tgrid[9, 2]));
			rules.Add(.(.N | .S | .E | .W | .SW, tgrid[10, 2]));
			rules.Add(.(.N | .S | .E | .W | .NW, tgrid[10, 3]));
			rules.Add(.(.N | .S | .E | .W | .NE, tgrid[9, 3]));
			rules.Add(.(.N | .E | .W, tgrid[8, 3]));

			rules.Add(.(.N | .S | .E | .W, tgrid[8, 4]));


			for (var i < 256)
			{
				var t = this;
				for (var r in rules)
				{
					if (r.Flags == (.)i)
					{
						t = r.Texture;
						break;
					}
				}
				list[i] = t;
				//list.[Friend]_items.Add(.(t));
			}
			//return list;
		}

		public void Edge(ref Subtexture[256] list)
		{
			let columns = 11;
			let rows = 5;
			//let sub = Subtexture(texture);
			let tgrid = scope Subtexture[columns, rows];

			let w = Width / columns;
			let h = Height / rows;

			for (var x < columns)
				for (var y < rows)
					tgrid[x, y] = GetClipSubtexture(.(x * w, y * h, w, h));

			let rules = scope List<AutoTileRule>();

			//rect
			rules.Add(.(.S | .E, tgrid[0, 0]));
			rules.Add(.(.W | .S | .E, tgrid[1, 0]));
			rules.Add(.(.S | .W, tgrid[2, 0]));

			rules.Add(.(.N | .S | .E, tgrid[0, 1]));
			rules.Add(.(.N | .S | .W | .E, tgrid[1, 1]));
			rules.Add(.(.N | .S | .W, tgrid[2, 1]));

			rules.Add(.(.N | .E, tgrid[0, 2]));
			rules.Add(.(.W | .N | .E, tgrid[1, 2]));
			rules.Add(.(.N | .W, tgrid[2, 2]));

			//vert
			rules.Add(.(.S, tgrid[3, 0]));
			rules.Add(.(.S | .N, tgrid[3, 1]));
			rules.Add(.(.N, tgrid[3, 2]));

			//hort
			rules.Add(.(.E, tgrid[0, 3]));
			rules.Add(.(.E | .W, tgrid[1, 3]));
			rules.Add(.(.W, tgrid[2, 3]));


			//corners
			rules.Add(.(.SE, tgrid[4, 0]));
			rules.Add(.(.W | .SE, tgrid[5, 0]));
			rules.Add(.(.E | .SW, tgrid[6, 0]));
			rules.Add(.(.SW, tgrid[7, 0]));

			rules.Add(.(.N | .SE, tgrid[4, 1]));
			rules.Add(.(.N | .W | .SE, tgrid[5, 1]));
			rules.Add(.(.N | .E | .SW, tgrid[6, 1]));
			rules.Add(.(.N | .SW, tgrid[7, 1]));

			rules.Add(.(.S | .NE, tgrid[4, 2]));
			rules.Add(.(.S | .W | .NE, tgrid[5, 2]));
			rules.Add(.(.S | .E | .NW, tgrid[6, 2]));
			rules.Add(.(.S | .NW, tgrid[7, 2]));

			rules.Add(.(.NE, tgrid[4, 3]));
			rules.Add(.(.W | .NE, tgrid[5, 3]));
			rules.Add(.(.E | .NW, tgrid[6, 3]));
			rules.Add(.(.NW, tgrid[7, 3]));

			rules.Add(.(.NE | .SE, tgrid[4, 4]));
			rules.Add(.(.W | .SE | .NE, tgrid[5, 4]));
			rules.Add(.(.E | .SW | .NW, tgrid[6, 4]));
			rules.Add(.(.NW | .SW, tgrid[7, 4]));


			rules.Add(.(.SW | .SE, tgrid[8, 0]));
			rules.Add(.(.SW | .NE, tgrid[9, 0]));

			rules.Add(.(.N | .SW | .SE, tgrid[8, 1]));
			rules.Add(.(.NW | .SE, tgrid[9, 1]));

			rules.Add(.(.NW | .NE | .S, tgrid[8, 2]));
			rules.Add(.(.NW | .NE | .SW, tgrid[9, 2]));
			rules.Add(.(.NW | .NE | .SE, tgrid[10, 2]));

			rules.Add(.(.NW | .NE, tgrid[8, 3]));
			rules.Add(.(.NW | .SW | .SE, tgrid[9, 3]));
			rules.Add(.(.NE | .SE, tgrid[10, 3]));

			rules.Add(.(.NW | .NE | .SE | .SW, tgrid[8, 4]));

			for (var i < 256)
			{
				var t = this;
				for (var r in rules)
				{
					if (r.Flags == (.)i)
					{
						t = r.Texture;
						break;
					}
				}
				list[i] = t;
			}
		}
	}
}
