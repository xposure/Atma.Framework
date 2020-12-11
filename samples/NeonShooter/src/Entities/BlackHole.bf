using Atma;
using System;
using System.Collections;
using NeonShooter.Components;
namespace NeonShooter.Entities
{
	public class BlackHole : Enemy
	{
		private int hitpoints = 10;
		private float sprayAngle = 0;

		public this(float2 position) : base(Core.Atlas["main/BlackHole"], position, 10)
		{
		}

		public override void WasShot()
		{
			hitpoints--;
			if (hitpoints <= 0)
				this.Destroy();
			else
			{
				let hue = (float)((3 * Time.Elapsedf) % 6);
				let color = Color.HSVToColor(hue, 0.25f, 1);
				const int numParticles = 150;
				float startOffset = Core.Random.nextFloat(0, 1f / numParticles);

				let scene = this.Scene as NeonGame;
				let particles = scene.Particles;
				let line = Core.Atlas["main/Laser"];

				for (int i = 0; i < numParticles; i++)
				{
					let sprayVel = Calc.Turn(i / (float)numParticles + startOffset) * Core.Random.nextFloat(8, 16);
					let pos = Position + 2f * sprayVel;
					var state = ParticleState(sprayVel, .IgnoreGravity, 1);

					particles.CreateParticle(line, pos, color, 90, float2(1.5f), state, Calc.Turn(state.Velocity));
				}
			}
		}

		public void Kill()
		{
			hitpoints = 0;
			WasShot();
		}

		private void GetNearbyEntities(List<Entity> entities, float2 position, float radius)
		{
			this.EntityList.Filter(entities, (x) => (x.Position - position).LengthSqr < radius * radius);
		}

		public override void Logic()
		{
			sprite.Scale = float2.Ones + 0.1f * Math.Sin(10 * Time.Elapsedf);

			let entities = scope List<Entity>();
			GetNearbyEntities(entities, WorldPosition, 250);

			for (var entity in entities)
			{
				if (entity is Enemy && !(entity as Enemy).IsActive)
					continue;

				// bullets are repelled by black holes and everything else is attracted
				if (entity is Bullet)
					entity.Velocity += (entity.Position - Position).Limit(0.3f);
				else
				{
					var dPos = Position - entity.Position;
					var length = dPos.Length;

					entity.Velocity += dPos.Limit(Math.Lerp(2, 0, length / 250f));
				}
			}


			let scene = this.Scene as NeonGame;
			let particles = scene.Particles;
			let line = Core.Atlas["main/Laser"];

			// The black holes spray some orbiting particles. The spray toggles on and off every quarter second.
			if ((int)(Time.Elapsed / 0.250) % 2 == 0)
			{
				let sprayVel = Calc.Turn(sprayAngle) * Core.Random.nextFloat(12, 15);
				let color = Color.HSVToColor(5, 0.5f, 0.8f);// light purple
				let pos = Position + 2f * float2(sprayVel.y, -sprayVel.x) + Calc.Turn(Core.Random.nextFloat()) * Core.Random.nextFloat(4, 8);
				var state = ParticleState(sprayVel, .Enemy, 1);

				particles.CreateParticle(line, pos, color, 190, float2(1.5f), state, Calc.Turn(sprayVel));
			}

			// rotate the spray direction
			sprayAngle -= 0.0125f;

			scene.Grid.ApplyImplosiveForce((float)Math.Sin(sprayAngle / 2) * 10 + 20, Position, 200);
		}
	}
}
