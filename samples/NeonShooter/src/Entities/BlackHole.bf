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
		private float strength = 1;

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
			this.EntityList.Filter(entities, (x) => (x is Bullet || x is Enemy || x is Player) && (x.WorldPosition - position).LengthSqr < radius * radius);
		}

		public override void Logic()
		{
			sprite.Scale = float2.Ones * strength + 0.1f * Math.Sin(10 * Time.Elapsedf) * strength;

			let scene = this.Scene as NeonGame;

			let entities = scope List<Entity>();
			let distance = 500 * strength;

			GetNearbyEntities(entities, WorldPosition, distance);

			if ((scene.player.WorldPosition - WorldPosition).LengthSqr < strength * strength)
				entities.Add(scene.player);

			for (var entity in entities)
			{
				if (entity is BlackHole)
					continue;

				if (let enemy = entity as Enemy && !enemy.IsActive)
					continue;

				// bullets are repelled by black holes and everything else is attracted
				if (entity is Bullet)
					entity.Velocity += (entity.Position - Position).Limit(0.3f);
				else
				{
					var dPos = WorldPosition - entity.WorldPosition;
					var length = dPos.Length;

					//we move the player directly due to input controls;
					if (entity is Player)
						entity.Position += dPos.Limit(Math.Lerp(3 * strength, 0, length / distance));
					else
						entity.Velocity += dPos.Limit(Math.Lerp(2, 0, length / distance));
				}
			}

			let particles = scene.Particles;
			let line = Core.Atlas["main/Laser"];

			// The black holes spray some orbiting particles. The spray toggles on and off every quarter second.
			if ((int)(Time.Elapsed / 0.250) % 2 == 0)
			{
				let sprayVel = Calc.Turn(sprayAngle) * Core.Random.nextFloat(12, 15) * (strength / 2f + 0.5f);
				let color = Color.HSVToColor(5, 0.5f, 0.8f);// light purple
				let pos = Position + 2f * float2(sprayVel.y, -sprayVel.x) + Calc.Turn(Core.Random.nextFloat()) * Core.Random.nextFloat(4, 8);
				var state = ParticleState(sprayVel, .Enemy, 1);

				particles.CreateParticle(line, pos, color, 190 * strength, float2(1.5f), state, Calc.Turn(sprayVel));
			}

			if (Time.OnInterval(1f))
			{
				strength += 0.05f;
			}

			// rotate the spray direction
			sprayAngle -= 0.0125f * strength;

			scene.Grid.ApplyImplosiveForce((float)Math.Sin(sprayAngle / 2) * 10 + 20, Position, 200 * strength);
		}
	}
}
