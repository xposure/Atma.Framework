using Atma;
using NeonShooter.Components;
namespace NeonShooter.Entities
{
	public class Bullet : Entity
	{
		private Sprite sprite;

		public this(float2 position, float2 velocity)
		{
			sprite = Components.Add(new Sprite(Core.Atlas["main/Bullet"]));

			Velocity = velocity;
			Rotation = Calc.Turn(Velocity);
			Position = position;
		}

		protected override void OnFixedUpdate()
		{
			base.OnFixedUpdate();

			if (!this.Scene.Camera.WorldBounds.Intersects(WorldPosition))
			{
				let scene = this.Scene as NeonGame;
				let particles = scene.Particles;
				let line = Core.Atlas["main/Laser"];
				let position = WorldPosition;
				for (int i = 0; i < 30; i++)
				{
					let state = ParticleState(Calc.Turn(Core.Random.nextFloat()) * Core.Random.nextFloat(0, 9), .Bullet, 1);
					particles.CreateParticle(line, position, Color.CornflowerBlue, 50, float2(1), state, Calc.Turn(state.Velocity));
				}

				this.Destroy();
			}
			else
			{
				let scene = this.Scene as NeonGame;

				Position += Velocity;

				if (Velocity.LengthSqr > 0)
				{
					scene.Grid.ApplyExplosiveForce(0.5f * Velocity.Length, Position, 80);
					Rotation = Calc.Turn(Velocity.NormalizedSafe);
				}
			}
		}
	}
}
