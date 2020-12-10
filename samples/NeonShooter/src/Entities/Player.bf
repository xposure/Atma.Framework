using Atma;
using NeonShooter.Components;
using Atma;
using System;
using NeonShooter.Scenes;
namespace NeonShooter.Entities
{
	public class Player : Entity
	{
		public class PlayerInput
		{
			private VirtualAxis _moveX = new .() ~ delete _;
			private VirtualAxis _moveY = new .() ~ delete _;
			private VirtualAxis _aimX = new .() ~ delete _;
			private VirtualAxis _aimY = new .() ~ delete _;
			private VirtualButton _bomb = new .() ~ delete _;
			//private VirtualButton _fire = new .() ~ delete _;

			public const float DeadZone = 0.20f;

			private bool gamePad = false;

			public this()
			{
				_moveX.AddAxis(0, .LeftX, DeadZone);
				_moveX.AddKeys(.A, .D, .CancelOut);
				_moveY.AddAxis(0, .LeftY, DeadZone);
				_moveY.AddKeys(.W, .S, .CancelOut);

				_aimX.AddAxis(0, .RightX, DeadZone);
				_aimY.AddAxis(0, .RightY, DeadZone);

				_bomb.AddButton(0, .A);
				_bomb.AddKey(.Space);
			}

			public void Update(float2 worldPosition)
			{
				gamePad |= _moveX.FromGamepad || _moveY.FromGamepad || _aimX.FromGamepad || _aimY.FromGamepad || _bomb.FromGamepad;

				Move = .(_moveX.Value, _moveY.Value);
				Bomb = _bomb.Check;

				if (Move.LengthSqr > 0 && !_moveX.FromGamepad && !_moveY.FromGamepad)
					gamePad = false;

				if (gamePad)
				{
					Aim = float2(_aimX.Value, _aimY.Value).NormalizedSafe;
					if (Aim.LengthSqr > 0)
						Fire = true;
				}
				else
				{
					Fire = Core.Input.MouseCheck(.Left);
					Aim = (Screen.Mouse - worldPosition).NormalizedSafe;
				}
			}

			public float2 Move;
			public float2 Aim;
			public bool Bomb;
			public bool Fire;

		}

		const int cooldownFrames = 6;
		private int cooldownRemaining = 0;

		private int framesUntilRespawn = 0;

		private Sprite sprite;
		private PlayerInput input = new .() ~ Release(_);
		public PlayerStatus status;

		private bool dead = false;
		public bool IsDead => dead;

		//public bool IsDead => framesUntilRespawn > 0;

		public this() : base("Player")
		{
			sprite = Components.Add(new Sprite(Core.Atlas["main/Player"]));
			status = Components.Add(new PlayerStatus());
		}

		protected override void OnFixedUpdate()
		{
			sprite.Visible = !dead;

			if (dead)
			{
				framesUntilRespawn--;
				if (framesUntilRespawn <= 0)
				{
					if (status.IsGameOver)
						status.Reset();

					dead = false;
					Position = Screen.Size / 2;

					let scene = this.Scene as TestScene;
					scene.Grid.ApplyImplosiveForce(1000, float3(WorldPosition, 0), 50);
				}

				return;
			}

			input.Update(WorldPosition);

			var aim = input.Aim;
			if (aim.LengthSqr > 0 && cooldownRemaining <= 0)
			{
				if (input.Fire)
				{
					cooldownRemaining = cooldownFrames;

					let randomSpread = gRand.nextFloat(-0.004f, 0.004f) + gRand.nextFloat(-0.004f, 0.004f);
					let aimDir = Calc.Turn(Calc.Turn(aim) + randomSpread);
					let vel = aimDir * 11;

					AddRoot(new Bullet(WorldPosition + aim.Perpendicular * 8 + aim * 25, vel));
					AddRoot(new Bullet(WorldPosition + aim.Perpendicular * -8 + aim * 25, vel));
				}
			}

			if (cooldownRemaining > 0)
				cooldownRemaining--;

			const float speed = 8;
			Velocity = speed * input.Move;
			Position += Velocity;
			Position = float2.Clamp(Position, sprite.Size / 2, Screen.Size - sprite.Size / 2);

			if (Velocity.LengthSqr > 0)
				Rotation = Calc.Turn(Velocity);

			MakeExhaustFire();
			Velocity = .Zero;

			base.OnFixedUpdate();
		}

		private void MakeExhaustFire()
		{
			if (Velocity.LengthSqr > 0.1f)
			{
				let line = Core.Atlas["main/Laser"];
				let glow = Core.Atlas["main/Glow"];
				let scene = this.Scene as TestScene;
				let particles = scene.Particles;

				// set up some variables
				Rotation = Calc.Turn(Velocity);

				double t = Time.Elapsedf;
				// The primary velocity of the particles is 3 pixels/frame in the direction opposite to which the ship
				// is travelling.
				float2 baseVel = -Velocity.Limit(3);
				// Calculate the sideways velocity for the two side streams. The direction is perpendicular to the
				// ship's velocity and the magnitude varies sinusoidally.
				float2 perpVel = float2(baseVel.y, -baseVel.x) * (0.6f * (float)Math.Sin(t * 10));
				Color sideColor = Color(200, 38, 9);// deep red
				Color midColor = Color(255, 187, 30);// orange-yellow

				float2 pos = WorldPosition + this.Backward * 25;// Position + float2.Transform(new float2(-25, 0),
				// rot);// position of the ship's exhaust pipe.
				const float alpha = 0.7f;

				// middle particle stream
				float2 velMid = baseVel + Calc.Turn(Core.Random.nextFloat());// rand.Nextfloat2(0, 1);
				particles.CreateParticle(line, pos, Color.White * alpha, 60f, float2(0.5f, 1),
					ParticleState(velMid, ParticleType.Enemy), Calc.Turn(velMid));
				particles.CreateParticle(glow, pos, midColor * alpha, 60f, float2(0.5f, 1),
					ParticleState(velMid, ParticleType.Enemy), Calc.Turn(velMid));

				// side particle streams
				float2 vel1 = baseVel + perpVel + Calc.Turn(Core.Random.nextFloat()) * Core.Random.nextFloat(0, 0.3f);//
				float2 vel2 = baseVel - perpVel + Calc.Turn(Core.Random.nextFloat()) * Core.Random.nextFloat(0, 0.3f);//
				particles.CreateParticle(line, pos, Color.White * alpha, 60f, float2(0.5f, 1),
					ParticleState(vel1, ParticleType.Enemy), Calc.Turn(vel1));
				particles.CreateParticle(line, pos, Color.White * alpha, 60f, float2(0.5f, 1),
					ParticleState(vel2, ParticleType.Enemy), Calc.Turn(vel2));

				particles.CreateParticle(glow, pos, sideColor * alpha, 60f, float2(0.5f, 1),
					ParticleState(vel1, ParticleType.Enemy), Calc.Turn(vel1));
				particles.CreateParticle(glow, pos, sideColor * alpha, 60f, float2(0.5f, 1),
					ParticleState(vel2, ParticleType.Enemy), Calc.Turn(vel2));
			}
		}

		public override void DebugRender()
		{
			base.DebugRender();
		}

		public void Kill()
		{
			if (!dead)
			{
				dead = true;
				status.RemoveLife();
				framesUntilRespawn = status.IsGameOver ? 300 : 120;

				Color explosionColor = Color(0.8f, 0.8f, 0.4f);// yellow

				let scene = this.Scene as TestScene;
				let particles = scene.Particles;
				let line = Core.Atlas["main/Laser"];

				for (int i = 0; i < 1200; i++)
				{
					float speed = 18f * (1f - 1 / Core.Random.nextFloat(1f, 10f));
					Color color = Color.Lerp(Color.White, explosionColor, Core.Random.nextFloat());
					var state = ParticleState(Calc.Turn(Core.Random.nextFloat()) * speed, .None, 1);

					particles.CreateParticle(line, WorldPosition, color, 190, float2(1.5f), state, Calc.Turn(state.Velocity));
				}
				scene.Grid.ApplyDirectedForce(float3(0, 0, 5000), float3(Position, 0), 50);
			}
		}
	}
}
