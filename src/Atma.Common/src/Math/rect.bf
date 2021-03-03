using System;
using System.Collections;

namespace Atma
{
	public struct rect//: IEnumerable<int2>
	{
		public int X;
		public int Y;
		public int Width;
		public int Height;

		public this()
		{
			this = default;
		}

		public this(int x, int y, int2 size) : this(x, y, size.x, size.y)
		{
		}

		public this(int x, int y, int width, int height)
		{
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}
		/*public this(int x, int y, int width, int height)
		{
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}*/

		public this(int2 min, int2 max)
		{
			if (max.x < min.x)
			{
				X = max.x;
				Width = min.x - max.x;
			}
			else
			{
				X = min.x;
				Width = max.x - min.x;
			}

			if (max.y < min.y)
			{
				Y = max.y;
				Height = min.y - max.y;
			} else
			{
				Y = min.y;
				Height = max.y - min.y;
			}
		}

		public int2 TopLeft => .(Left, Top);
		public int2 TopRight => .(Right, Top);
		public int2 BottomLeft => .(Left, Bottom);
		public int2 BottomRight => .(Right, Bottom);

		public int2[4] Corners => int2[4](TopLeft, TopRight, BottomRight, BottomLeft);

		public int Left
		{
			[Inline]
			get
			{
				return X;
			}

			[Inline]
			set mut
			{
				X = value;
			}
		}

		public int Right
		{
			[Inline]
			get
			{
				return X + Width;
			}

			[Inline]
			set mut
			{
				X = value - Width;
			}
		}

		public int Top
		{
			[Inline]
			get
			{
				return Y;
			}

			[Inline]
			set mut
			{
				Y = value;
			}
		}

		public int Bottom
		{
			[Inline]
			get
			{
				return Y + Height;
			}

			[Inline]
			set mut
			{
				Y = value - Height;
			}
		}


		public int2 Min => .(X, Y);
		public int2 Max => .(Right, Bottom);

		public int2 Size => .(Width, Height);
		public int2 Position => .(X, Y);

		public int Area => Size.x * Size.y;

		public int2 Origin => .(X, Y);

		public int2 Center => Position + Size / 2;

		public rect MirrorX(int axis = 0)
		{
			var rect = this;
			rect.X = axis - (X - axis) - Width;
			return rect;
		}

		public rect MirrorY(int axis = 0)
		{
			var rect = this;
			rect.Y = axis - (Y - axis) - Height;
			return rect;
		}

		/// <summary>
		///		Extends the box to encompass the specified point (if needed).
		/// </summary>
		/// <param name="point"></param>
		public void Merge(int2 point) mut
		{
			if (point.x > Right)
				Right = point.x;
			else if (point.x < X)
				X = point.x;

			if (point.y > Bottom)
				Bottom = point.y;
			else if (point.y < Y)
				Y = point.y;
		}

		public rect Inflate(int amount)
		{
			return rect(X - amount, Y - amount, Width + amount * 2, Height + amount * 2);
		}

		public bool Intersects(rect rect)
		{
			return (X + Width) > rect.X && (rect.X + rect.Width) > X && (Y + Height) > rect.Y && (rect.Y + rect.Height) > Y;
		}

		public rect Intersection(rect b2)
		{
			if (Intersection(b2, let intersection))
				return intersection;

			return .(0, 0, 0, 0);
		}

		/// <summary>
		///		Calculate the area of intersection of this box and another
		/// </summary>
		public bool Intersection(rect b2, out rect intersection)
		{
			if (!Intersects(b2))
			{
				intersection = .(int2.Zero, int2.Zero);
				return false;
			}

			int2 intMin = int2.Zero;
			int2 intMax = int2.Zero;

			int2 b2max = b2.Max;
			int2 b2min = b2.Min;

			if (b2max.x > Max.x && Max.x > b2min.x)
				intMax.x = Max.x;
			else
				intMax.x = b2max.x;
			if (b2max.y > Max.y && Max.y > b2min.y)
				intMax.y = Max.y;
			else
				intMax.y = b2max.y;

			if (b2min.x < Min.x && Min.x < b2max.x)
				intMin.x = Min.x;
			else
				intMin.x = b2min.x;
			if (b2min.y < Min.y && Min.y < b2max.y)
				intMin.y = Min.y;
			else
				intMin.y = b2min.y;

			intersection = .(intMin, intMax);
			return true;
		}

		public bool Contains(int2 int2)
		{
			return int2.x >= X && int2.x < X + Width && int2.y >= Y && int2.y < Y + Height;
		}

		public int2 Clamp(int2 position) => int2.Clamp(position, TopLeft, BottomRight);


		public override void ToString(String strBuffer)
		{
			strBuffer.Set("Rect [ ");
			X.ToString(strBuffer);
			strBuffer.Append(", ");
			Y.ToString(strBuffer);
			strBuffer.Append(", ");
			Width.ToString(strBuffer);
			strBuffer.Append(", ");
			Height.ToString(strBuffer);
			strBuffer.Append(" ]");
		}

		[Commutable]
		static public bool operator==(rect a, rect b)
		{
			return a.X == b.X && a.Y == b.Y && a.Width == b.Width && a.Height == b.Height;
		}

		static public rect operator+(rect a, int2 b)
		{
			return rect(a.X + b.x, a.Y + b.y, a.Width, a.Height);
		}

		static public rect operator-(rect a, int2 b)
		{
			return rect(a.X - b.x, a.Y - b.y, a.Width, a.Height);
		}

		static public rect operator/(rect a, int b)
		{
			return rect(a.X / b, a.Y / b, a.Width / b, a.Height / b);
		}

		static public rect operator/(rect a, int2 b)
		{
			return rect(a.X / b.x, a.Y / b.y, a.Width / b.x, a.Height / b.y);
		}

		static public rect operator*(rect a, int b)
		{
			return rect(a.X * b, a.Y * b, a.Width * b, a.Height * b);
		}

		static public rect operator*(rect a, int2 b)
		{
			return rect(a.X * b.x, a.Y * b.y, a.Width * b.x, a.Height * b.y);
		}

		public struct boundary : IEnumerable<int2>
		{
			public readonly rect Area;
			public readonly bool IncludeCorners;
			public this(rect area, bool includeCorners)
			{
				Area = area;
				IncludeCorners = includeCorners;
			}

			public Enumerator GetEnumerator() => .(Area, IncludeCorners);

			public struct Enumerator : IEnumerator<int2>
			{
				private enum state
				{
					Start,
					North,
					East,
					South,
					West,
					Done
				}
				private int minX, minY, maxX, maxY;
				private int x, y;
				private state _state;
				private bool _includeCorners;

				public this(rect area, bool includeCorners)
				{
					minX = area.X;
					minY = area.Y;
					maxX = area.Right;
					maxY = area.Bottom;

					x = minX;
					y = minY;
					_state = .North;
					_includeCorners = includeCorners;
				}

				public bool MoveNext() mut
				{
					switch (_state) {
					case .Start:
						_state = .North;
						if (!_includeCorners)
							x++;

					case .North:
						x++;
						if (x == maxX)
						{
							_state = .East;
							if (!_includeCorners)
								y++;
						}

					case .East:
						y++;
						if (y == maxY)
						{
							_state = .South;
							if (!_includeCorners)
								x--;
						}
					case .South:
						x--;
						if (x == minX)
						{
							_state = .West;
							if (!_includeCorners)
								y--;
						}
					case .West:
						y--;
						if (y == minY)
						{
							_state = .Done;

							if (!_includeCorners)
								return false;
						}
					case .Done:
						return false;
					}

					return true;
				}

				public Result<int2> GetNext() mut
				{
					if (!MoveNext())
						return .Err;
					return .Ok(.(x, y));
				}

				public void Reset() mut
				{
					x = minX - 2;
					y = minY - 1;
				}
			}
		}

		public boundary boundary => .(this, true);

		public boundary outter => .(this.Inflate(1), true);

		public Enumerator GetEnumerator() => .(this);

		public struct Enumerator : IEnumerator<int2>
		{
			private int minX, minY, maxX, maxY;
			private int x, y;

			public this(rect area)
			{
				minX = area.X;
				minY = area.Y;
				maxX = minX + area.Width;
				maxY = minY + area.Height;

				x = minX - 1;
				y = minY;
			}

			public bool MoveNext() mut
			{
				x++;
				if (x == maxX)
				{
					x = minX;
					y++;

					if (y == maxY)
						return false;
				}

				return true;
			}

			public Result<int2> GetNext() mut
			{
				if (!MoveNext())
					return .Err;
				return .Ok(.(x, y));
			}

			public void Reset() mut
			{
				x = minX - 2;
				y = minY - 1;
			}
		}

		public rect Offset(int2 offset) => .(offset.x + X, offset.y + Y, Width, Height);

		public static rect FromXY(int x, int y, int size) => FromDimensions(.(x, y) * size, size, size);
		public static rect FromXY(int x, int y, int2 size) => FromDimensions(.(x, y) * size, size);
		public static rect FromXY(int2 p, int size) => FromDimensions(p * size, .(size));
		public static rect FromXY(int2 p, int2 size) => FromDimensions(p * size, size);

		public static rect FromDimensions(int2 p, int2 size) => .(p.x, p.y, size.x, size.y);
		public static rect FromDimensions(int2 p, int w, int h) => .(p.x, p.y, w, h);
		public static rect FromCenter(int2 p, int extents) => .(p - extents, p + extents + int2.Ones);
		public static rect FromCenter(int2 p, int2 extents) => .(p - extents, p + extents + int2.Ones);


		public List<rect> ToAlignedGrid(int2 gridSize, List<rect> rects)
		{
			let sx = Left / gridSize.width;
			let ex = Right / gridSize.width + 1;
			let sy = Top / gridSize.height;
			let ey = Bottom / gridSize.height + 1;

			for (var y = sy; y <= ey; y++)
				for (var x = sx; x <= ex; x++)
					if (Intersection(rect(x * gridSize.width, y * gridSize.height, gridSize), let rect))
						rects.Add(rect);

			return rects;
		}

		public aabb2 ToAABB()
		{
			return .(Min, Max);
		}
	}
}
