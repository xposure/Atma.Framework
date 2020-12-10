using Atma;
using System;

namespace NeonShooter.Entities
{
	public class Wanderer : Enemy
	{
		private float direction;
		private int state = 0;

		public this(float2 position) : base(Core.Atlas["main/Wanderer"], position, 5)
		{
			direction = gRand.nextFloat(0, 1);
		}

		public override void Logic()
		{
			if (state == 0)
				direction += gRand.nextFloat(-0.01f, 0.01f);

			Velocity += Calc.Turn(direction).Limit(0.4f);
			Rotation -= 0.05f;

			if (state++ > 6)
				state = 0;
		}

		public override void TouchedWall(aabb2 bounds)
		{
			var vdir = Calc.Turn(direction);

			// if the enemy is outside the bounds, make it move away from the edge
			if (WorldPosition.x < bounds.x0)
				vdir.x = Math.Abs(vdir.x);
			else if (WorldPosition.x > bounds.x1)
				vdir.x = -Math.Abs(vdir.x);

			if (WorldPosition.y < bounds.y0)
				vdir.y = Math.Abs(vdir.y);
			else if (WorldPosition.y > bounds.y1)
				vdir.y = -Math.Abs(vdir.y);

			direction = Calc.Turn(vdir);
		}
	}
}
