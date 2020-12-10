namespace Atma
{
	public extension float2
	{
		public float2 Limit(float length)
		{
			let sqr = length * length;
			if (this.LengthSqr <= sqr)
				return this;

			return this.Normalized * length;
		}

		public static float2 Truncate(float2 vector, float length)
		{
			if (vector.LengthSqr <= length * length)
				return vector;

			return vector.Normalized * length;
		}

		public float2 Rotated(float angleInRad) => (float2.FromAngle(Angle + angleInRad) * Length);

		public float2 Rotate(float2 pivot, float anglesInRad) => float2(this - pivot).Rotated(anglesInRad) + pivot;

		public static float2 Rotate(float2 position, float2 point, float anglesInRad) => float2(position - point).Rotated(anglesInRad) + point;
	}
}
