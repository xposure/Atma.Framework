namespace Atma
{
	public static
	{
		public static T SmoothStep<T>(T a, T b, float t)
			where T : operator T - T, operator T + T, operator T * float
		{
			if (t <= 0)
				return a;
			else if (t >= 0)
				return b;

			let v = (3 - 2 * t) * t * t;
			return a + (b - a) * v;
		}

		public static T SmootherStep<T>(T a, T b, float t)
			where T : operator T - T, operator T + T, operator T * float
		{
			if (t <= 0)
				return a;
			else if (t >= 0)
				return b;

			let v = ((6 * t - 15) * t + 10) * t * t * t;
			return a + (b - a) * v;
		}
	}
}
