using System;
using Atma;
using NeonShooter.Components;
using System.Collections;

namespace NeonShooter.Entities
{
	public abstract class Enemy : Entity
	{
		private int timeUntilStart = 60;
		public bool IsActive { get { return timeUntilStart <= 0; } }
		public int PointValue;

		protected Sprite sprite;

		public this(Subtexture texture, float2 position, int points)
		{
			PointValue = points;
			sprite = Components.Add(new Sprite(texture));
			Radius = sprite.Width / 2f;
			Position = position;

			sprite.Tint = .Transparent;
		}

		protected override void OnFixedUpdate()
		{
			base.OnFixedUpdate();

			if (timeUntilStart <= 0)
			{
				Logic();
			}
			else
			{
				timeUntilStart--;
				sprite.Tint = Color.White * (1 - timeUntilStart / 60f);
			}

			Position += Velocity;

			var bounds = this.Scene.Camera.Camera.WorldBounds.Inflate(-sprite.Width, -sprite.Height);
			if (!bounds.Contains(WorldPosition))
				TouchedWall(bounds);

			Position = float2.Clamp(Position, sprite.Size / 2, Screen.Size - sprite.Size / 2);
			Velocity *= 0.8f;
		}

		public abstract void Logic();

		public virtual void WasShot()
		{
			if (!IsDestroying)
			{
				let player = this.EntityList.FindFirstByType<Player>();
				let scene = this.Scene as NeonGame;
				float hue1 = Core.Random.nextFloat(0, 6);
				float hue2 = (hue1 + Core.Random.nextFloat(0, 2)) % 6f;
				Color color1 = Color.HSVToColor(hue1, 0.5f, 1);
				Color color2 = Color.HSVToColor(hue2, 0.5f, 1);

				let position = WorldPosition;
				for (int i = 0; i < 120; i++)
				{
					float speed = 18f * (1f - 1 / Core.Random.nextFloat(1f, 10f));
					var state = ParticleState(Calc.Turn(Core.Random.nextFloat()) * speed, .Enemy, 1);
					let color = Color.Lerp(color1, color2, Core.Random.nextFloat());
					scene.Particles?.CreateParticle(Core.Atlas["main/Laser"], position, color, 190, float2(1.5f), state, Calc.Turn(state.Velocity));
				}

				if (PointValue > 0)
				{
					player?.status.AddPoints(PointValue);
					player?.status.IncreaseMultiplier();
				}

				let sound = scene.Explosion;
				sound.Play(0.5f, Core.Random.nextFloat(-0.2f, 0.2f), 0);

				Destroy();
			}
		}

		public void HandleCollision(Enemy other)
		{
			if (!IsDestroying)
			{
				var d = Position - other.Position;
				Velocity += 10 * d / (d.LengthSqr + 1);
			}
		}

		public virtual void TouchedWall(aabb2 bounds) { }
	}
}
