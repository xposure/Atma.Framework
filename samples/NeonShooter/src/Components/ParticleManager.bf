using System;
using System.Collections;
using NeonShooter.Entities;
using Atma;

namespace NeonShooter.Components
{
	public enum ParticleType { None, Enemy, Bullet, IgnoreGravity }

	public struct ParticleState
	{
		public float2 Velocity;
		public ParticleType Type;
		public float LengthMultiplier;

		public this(float2 velocity, ParticleType type, float lengthMultiplier = 1f)
		{
			Velocity = velocity;
			Type = type;
			LengthMultiplier = lengthMultiplier;
		}

		public static ParticleState GetRandom(float minVel, float maxVel)
		{
			ParticleState state = ?;
			state.Velocity = Calc.Turn(Core.Random.nextFloat()) * Core.Random.nextFloat(minVel, maxVel);
			state.Type = ParticleType.None;
			state.LengthMultiplier = 1;

			return state;
		}

		public static void UpdateParticle(Particle<ParticleState>* particle)
		{
			var vel = particle.State.Velocity;
			let speed = vel.Length;

			// using Vector2.Add() should be slightly faster than doing "x.Position += vel;" because the Vector2s
			// are passed by reference and don't need to be copied. Since we may have to update a very large 
			// number of particles, this method is a good candidate for optimizations.
			particle.Position = particle.Position + vel;
			//float2.Add(ref particle.Position, ref vel, out particle.Position);

			// fade the particle if its PercentLife or speed is low.
			float alpha = Math.Min(1, Math.Min(particle.PercentLife * 2, speed * 1f));
			alpha *= alpha;

			particle.Tint.A = (uint8)(255 * alpha);

			// the length of bullet particles will be less dependent on their speed than other particles
			if (particle.State.Type == ParticleType.Bullet)
				particle.Scale.x = particle.State.LengthMultiplier * Math.Min(Math.Min(1f, 0.1f * speed + 0.1f), alpha);
			else
				particle.Scale.x = particle.State.LengthMultiplier * Math.Min(Math.Min(1f, 0.2f * speed + 0.1f), alpha);

			particle.Orientation = Calc.Turn(vel);

			var pos = particle.Position;
			let width = Screen.Width;
			let height = Screen.Height;

			// collide with the edges of the screen
			if (pos.x < 0)
				vel.x = Math.Abs(vel.x);
			else if (pos.x > width)
				vel.x = -Math.Abs(vel.x);
			if (pos.y < 0)
				vel.y = Math.Abs(vel.y);
			else if (pos.y > height)
				vel.y = -Math.Abs(vel.y);

			if (particle.State.Type != ParticleType.IgnoreGravity)
			{
				let blackholes = scope List<BlackHole>();
				Core.Scene.Entities.FindByType(blackholes);

				for (var blackHole in blackholes)
				{
					var dPos = blackHole.Position - pos;
					float distance = dPos.Length;
					var n = dPos / distance;
					vel += 10000 * n / (distance * distance + 10000);

					// add tangential acceleration for nearby particles
					if (distance < 400)
						vel += 45 * float2(n.y, -n.x) / (distance + 100);
				}
			}

			if (Math.Abs(vel.x) + Math.Abs(vel.y) < 0.00000000001f)// denormalized floats cause significant performance
				// issues
				vel = float2.Zero;
			else if (particle.State.Type == ParticleType.Enemy)
				vel *= 0.94f;
			else
				vel *= 0.96f + Math.Abs(pos.x) % 0.04f;// rand.Next() isn't thread-safe, so use the position for
			// pseudo-randomness

			particle.State.Velocity = vel;
		}
	}

	public struct Particle<T>
		where T : struct
	{
		public Subtexture Texture;
		public float2 Position;
		public float Orientation;

		public float2 Scale = float2.Ones;

		public Color Tint;
		public float Duration;
		public float PercentLife = 1f;
		public T State;
	}


	public class ParticleManager<T> : GraphicsComponent
		where T : struct
	{
		// This delegate will be called for each particle.
		public delegate void UpdateParticle(Particle<T>* particle);

		private UpdateParticle updateParticle ~ delete _;
		//private CircularParticleArray particleList;
		private List<Particle<T>> particleList = new .(1024 * 20) ~ delete _;

		public this(UpdateParticle updateParticlea) : base(true, true)
		{
			this.updateParticle = updateParticlea;
		}

		public void CreateParticle(Subtexture texture, float2 position, Color tint, float duration, float2 scale, T state, float theta)
		{
			var particle = particleList.GrowUnitialized(1);

			// Create the particle
			particle.Texture = texture;
			particle.Position = position;
			particle.Tint = tint;

			particle.Duration = duration;
			particle.PercentLife = 1f;
			particle.Scale = scale;
			particle.Orientation = theta;
			particle.State = state;
		}

		public override void FixedUpdate()
		{
			for (var particle in ref particleList)
			{
				updateParticle(&particle);
				particle.PercentLife -= 1f / particle.Duration;

				if (particle.PercentLife < 0)
					@particle.RemoveFast();
			}
			/*int removalCount = 0;
			for (int i = 0; i < particleList.Count; i++)
			{
				var particle = ref particleList[i];
				updateParticle(&particle);
				particle.PercentLife -= 1f / particle.Duration;

				// sift deleted particles to the end of the list
				Swap!(particleList[i - removalCount], particleList[i])
					;
				// if the particle has expired, delete this particle
				if (particle.PercentLife < 0)
					removalCount++;
			}
			particleList.Count -= removalCount;*/
		}

		public override void Render()
		{
			for (int i = 0; i < particleList.Count; i++)
			{
				var particle = ref particleList[i];

				let origin = float2(particle.Texture.Width / 2, particle.Texture.Height / 2);
				Core.Draw.Image(particle.Texture, particle.Position, particle.Tint.Premultiplied, particle.Orientation, origin, particle.Scale, .None, 0, false);
				//spriteBatch.Draw(particle.Texture, particle.Position, null, particle.Tint, particle.Orientation,
			// origin, particle.Scale, 0, 0);
			}

			//Core.Draw.Text(Core.DefaultFont, float2(100, 100), scope $"Particles: {particleList.Count}", .White);
		}

		public override float Width => Screen.Width;
		public override float Height => Screen.Height;
	}
}
