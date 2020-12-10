namespace Atma
{
	public extension Entity
	{
		public float2 Velocity;
		public float Radius = 8;

		public static bool IsColliding(Entity a, Entity b)
		{
			if (a == b) return false;
			float radius = a.Radius + b.Radius;
			return (a.WorldPosition - b.WorldPosition).LengthSqr < radius * radius;
		}
	}
}
