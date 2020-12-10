using Atma;
using System.Collections;
using System;
namespace NeonShooter.Components
{
	public class Vehicle : Component
	{
		typealias steerpoint = (float t, float2 p);
		public float MaxSpeed;
		public float MaxForce;

		public float2 Velocity;
		public float2 Acceleration;

		public float Mass;

		private List<steerpoint> _points = new .() ~ delete _;

		public this() : base(true)
		{
			Mass = 1f;
			MaxSpeed = 8;
			MaxForce = 1;
		}

		public override void Inspect()
		{
			base.Inspect();
			//TODO IMGUI
			/*ImGui.SliderFloat2("Velocity", Velocity.values, -10, 10);
			ImGui.SliderFloat2("Accel", Acceleration.values, -10, 10);
			ImGui.SliderFloat("Max Speed", &MaxSpeed, 0, 10);
			ImGui.SliderFloat("Max Force", &MaxForce, 0, 10);
			ImGui.SliderFloat("Mass", &Mass, 1, 20);*/
		}

		public void Seek(float2 target, float t)
		{
			let desired = (target - WorldPosition).NormalizedSafe * MaxSpeed;
			let steer = float2.Truncate(desired - Velocity, MaxForce * t);

			ApplyForce(steer);
			_points.Add((t, target));
		}

		public void Flee(float2 target, float t)
		{
			let desired = (WorldPosition - target).NormalizedSafe * MaxSpeed;
			let steer = float2.Truncate(desired - Velocity, MaxForce * t);

			ApplyForce(steer);
			_points.Add((t, target));
		}

		public void Arrive(float2 target)
		{
			var desired = (target - WorldPosition);//.Normalized * MaxSpeed;
			let d = desired.Length;
			let speed = Calc.ClampedMap(d, 0, 100, 0, MaxSpeed);
			let dir = desired.Normalized;
			desired = dir * speed;

			let steer = (desired - Velocity).Limit(MaxForce);

			ApplyForce(steer);

			/*ApplyForce(steer);
			_points.Add(target);
			_points.Add(WorldPosition + dir * 100);*/
		}

		public static FastNoise _noise = new .() ~ delete _;
		private float id = gRand.nextFloat() * 100000;
		public void Wander(float t)
		{
			let target = WorldPosition + Calc.Turn(_noise.GetSimplex(Time.Elapsedf * 20, id)) * 100;
			var desired = (target - WorldPosition);//.Normalized * MaxSpeed;
			let d = desired.Length;
			let speed = Calc.ClampedMap(d, 0, 100, 0, MaxSpeed);
			let dir = desired.Normalized;
			desired = dir * speed;

			let steer = (desired - Velocity).Limit(MaxForce * t);

			ApplyForce(steer);

			/*ApplyForce(steer);
			_points.Add(target);
			_points.Add(WorldPosition + dir * 100);*/
		}

		public void ApplyForce(float2 force)
		{
			Acceleration += float2.Truncate(force / Mass, MaxSpeed);
		}

		public override void FixedUpdate()
		{
			Velocity += float2.Truncate(Acceleration, MaxSpeed);
			Velocity = Velocity.Limit(MaxSpeed);
			Entity.Position += Velocity;
			Acceleration = .Zero;

			if (Velocity.LengthSqr > 0)
				Entity.Rotation = Calc.Turn(Velocity);
		}

		public override void DebugRender()
		{
			base.DebugRender();
			for (var it in _points)
				Core.Draw.Pixel(it.p, Color.Green.ToAlpha(it.t).Premultiplied, 2f);

			let acc = Acceleration.Limit(MaxSpeed).LengthSqr / (MaxSpeed * MaxSpeed) * 100;
			let force = Velocity.Limit(MaxForce).LengthSqr / (MaxForce * MaxForce) * 100;

			Core.Draw.Line(WorldPosition, WorldPosition + Acceleration.Normalized * acc, 1f, .Green);
			Core.Draw.Line(WorldPosition, WorldPosition + Velocity.Normalized * force, 1f, .Red);
			_points.Clear();
		}
	}
}
