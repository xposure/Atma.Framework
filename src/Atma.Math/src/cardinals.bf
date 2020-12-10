using System;

namespace Atma
{
	public struct Foo
	{
		public float value = 0;
		public static Foo operator+(Foo l, Foo r) => Foo() { value = l.value + r.value };
	}


	public enum Cardinals
	{
		case Right;
		case Down;
		case Left;
		case Up;

		public int X
		{
			get
			{
				switch (this)
				{
				case .Left:
					return -1;
				case .Right:
					return 1;
				case .Up:
				case .Down:
				default:
				}

				return 0;
			}
		}

		public int Y
		{
			get
			{
				switch (this)
				{
				case .Up:
					return -1;
				case .Down:
					return 1;
				case .Left:
				case .Right:
				default:
				}

				return 0;
			}
		}

		public Cardinals Opposite()
		{
			switch (this)
			{
			case .Right:
				return .Left;
			case .Left:
				return .Right;
			case .Up:
				return .Down;
			case .Down:
				return .Up;
			}
		}

		public Cardinals NextClockwise()
		{
			switch (this)
			{
			case .Right:
				return .Down;
			case .Left:
				return .Up;
			case .Up:
				return .Right;
			case .Down:
				return .Left;
			}
		}

		public Cardinals NextCounterClockwise()
		{
			switch (this)
			{
			case .Right:
				return .Up;
			case .Left:
				return .Down;
			case .Up:
				return .Left;
			case .Down:
				return .Right;
			}
		}

		static public implicit operator Cardinals(Facings f)
		{
			if (f == Facings.Right)
				return Cardinals.Right;
			else
				return Cardinals.Left;
		}

		static public implicit operator int2(Cardinals c)
		{
			switch (c)
			{
			case .Right:
				return int2.UnitX;
			case .Left:
				return int2.NegativeUnitX;
			case .Up:
				return int2.UnitY;
			case .Down:
				return int2.NegativeUnitY;
				/*case .Right:
					return int2.Right;
			case .Left:
					return int2.Left;
			case .Up:
					return int2.Up;
			case .Down:
					return int2.Down;*/
			}
		}

		static public Result<Cardinals> Fromint2(int2 p)
		{
			if (p.x > 0 && p.y == 0)
				return .Right;
			else if (p.x < 0 && p.y == 0)
				return .Left;
			else if (p.y < 0 && p.x == 0)
				return .Up;
			else if (p.y > 0 && p.x == 0)
				return .Down;
			else
				return .Err;
		}

		static public Result<Cardinals> Fromfloat2(float2 v)
		{
			if (v.x > 0 && v.y == 0)
				return .Right;
			else if (v.x < 0 && v.y == 0)
				return .Left;
			else if (v.y < 0 && v.x == 0)
				return .Up;
			else if (v.y > 0 && v.x == 0)
				return .Down;
			else
				return .Err;
		}
	}
}