namespace Atma
{
	public struct Bezier
	{
		public float2 Start;
		public float2 Control;
		public float2 End;

		public this(float2 start, float2 control, float2 end)
		{
			Start = start;
			Control = control;
			End = end;
		}

		public float2 this[float t]
		{
			get => (Start * (1 - t) * (1 - t)) + (Control * 2f * (1 - t) * t) + (End * t * t);
		}

		public float GetLengthParametric(int resolution)
		{
			float2 last = Start;
			float length = 0;
			for (int i = 1; i <= resolution; i++)
			{
				float2 at = this[i / (float)resolution];
				length += (at - last).Length;
				last = at;
			}

			return length;
		}
	}
}