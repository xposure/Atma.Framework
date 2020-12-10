using Atma;
using System.Collections;
using System;
namespace NeonShooter.Components
{
	public class GridComponent : GraphicsComponent
	{
		private struct PointMass
		{
			public float3 Position;
			public float3 Velocity = default;
			public float InverseMass;

			private float3 acceleration = default;
			private float damping = 0.98f;

			public this(float3 position, float invMass)
			{
				Position = position;
				InverseMass = invMass;
			}

			public void ApplyForce(float3 force) mut
			{
				acceleration += force * InverseMass;
			}

			public void IncreaseDamping(float factor) mut
			{
				damping *= factor;
			}

			public void Update() mut
			{
				Velocity += acceleration;
				Position += Velocity;
				acceleration = float3.Zero;
				if (Velocity.LengthSqr < 0.001f * 0.001f)
					Velocity = float3.Zero;

				Velocity *= damping;
				damping = 0.98f;
			}
		}

		struct Spring
		{
			public PointMass* End1;
			public PointMass* End2;
			public float TargetLength;
			public float Stiffness;
			public float Damping;

			public this(PointMass* end1, PointMass* end2, float stiffness, float damping)
			{
				End1 = end1;
				End2 = end2;
				Stiffness = stiffness;
				Damping = damping;
				TargetLength = float3.Distance(end1.Position, end2.Position) * 0.95f;
			}

			public void Update() mut
			{
				var x = End1.Position - End2.Position;

				float length = x.Length;
				// these springs can only pull, not push
				if (length <= TargetLength)
					return;

				x = (x / length) * (length - TargetLength);
				var dv = End2.Velocity - End1.Velocity;
				var force = Stiffness * x - dv * Damping;

				End1.ApplyForce(-force);
				End2.ApplyForce(force);
			}
		}

		int numColumns, numRows;
		List<Spring> springs = new .() ~ delete _;
		PointMass[,] points ~ delete _;
		PointMass[,] fixedPoints ~ delete _;
		float2 screenSize;

		public this(rect size, float2 spacing) : base(true, true)
		{
			//var springList = scope List<Spring>();

			numColumns = (int)(size.Width / spacing.x) + 1;
			numRows = (int)(size.Height / spacing.y) + 1;
			points = new PointMass[numColumns, numRows];

			// these fixed points will be used to anchor the grid to fixed positions on the screen
			fixedPoints = new PointMass[numColumns, numRows];

			// create the point masses
			int column = 0, row = 0;
			for (float y = size.Top; y <= size.Bottom; y += spacing.y)
			{
				for (float x = size.Left; x <= size.Right; x += spacing.x)
				{
					points[column, row] = PointMass(float3(x, y, 0), 1);
					fixedPoints[column, row] = PointMass(float3(x, y, 0), 0);
					column++;
				}
				row++;
				column = 0;
			}

			// link the point masses with springs
			for (int y = 0; y < numRows; y++)
				for (int x = 0; x < numColumns; x++)
				{
					if (x == 0 || y == 0 || x == numColumns - 1 || y == numRows - 1)// anchor the border of the grid
						springs.Add(Spring(&fixedPoints[x, y], &points[x, y], 0.1f, 0.1f));
					else if (x % 3 == 0 && y % 3 == 0)// loosely anchor 1/9th of the point masses
						springs.Add(Spring(&fixedPoints[x, y], &points[x, y], 0.002f, 0.02f));

					const float stiffness = 0.28f;
					const float damping = 0.06f;

					if (x > 0)
						springs.Add(Spring(&points[x - 1, y], &points[x, y], stiffness, damping));
					if (y > 0)
						springs.Add(Spring(&points[x, y - 1], &points[x, y], stiffness, damping));
				}
		}

		public void ApplyDirectedForce(float2 force, float2 position, float radius)
		{
			ApplyDirectedForce(float3(force, 0), float3(position, 0), radius);
		}

		public void ApplyDirectedForce(float3 force, float3 position, float radius)
		{
			for (var mass in ref points)
				if (float3.DistanceSqr(position, mass.Position) < radius * radius)
					mass.ApplyForce(10 * force / (10 + float3.Distance(position, mass.Position)));
		}

		public void ApplyImplosiveForce(float force, float2 position, float radius)
		{
			ApplyImplosiveForce(force, float3(position, 0), radius);
		}

		public void ApplyImplosiveForce(float force, float3 position, float radius)
		{
			for (var mass in ref points)
			{
				float dist2 = float3.DistanceSqr(position, mass.Position);
				if (dist2 < radius * radius)
				{
					mass.ApplyForce(10 * force * (position - mass.Position) / (100 + dist2));
					mass.IncreaseDamping(0.6f);
				}
			}
		}

		public void ApplyExplosiveForce(float force, float2 position, float radius)
		{
			ApplyExplosiveForce(force, float3(position, 0), radius);
		}

		public void ApplyExplosiveForce(float force, float3 position, float radius)
		{
			for (var mass in ref points)
			{
				float dist2 = float3.DistanceSqr(position, mass.Position);
				if (dist2 < radius * radius)
				{
					mass.ApplyForce(100 * force * (mass.Position - position) / (10000 + dist2));
					mass.IncreaseDamping(0.6f);
				}
			}
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();

			for (var spring in ref springs)
				spring.Update();

			for (var mass in ref points)
				mass.Update();
		}

		public override void Render()
		{
			screenSize = Screen.Size;

			int width = numColumns;
			int height = numRows;
			Color color = Color(30, 30, 139, 85);// dark blue

			Core.Draw.SetTexture(Core.Draw.DefaultTexture);
			for (int y = 1; y < height; y++)
			{
				for (int x = 1; x < width; x++)
				{
					float2 left = float2.Zero, up = float2.Zero;
					float2 p = ToVec2(points[x, y].Position);
					if (x > 1)
					{
						left = ToVec2(points[x - 1, y].Position);
						float thickness = (y % 3 == 1) ? 3f : 1f;

						// use Catmull-Rom interpolation to help smooth bends in the grid
						int clampedX = Math.Min(x + 1, width - 1);
						float2 mid = CatmullRom(ToVec2(points[x - 2, y].Position), left, p, ToVec2(points[clampedX, y].Position), 0.5f);

						// If the grid is very straight here, draw a single straight line. Otherwise, draw lines to our
						// new interpolated midpoint
						if (float2.DistanceSqr(mid, (left + p) / 2) > 1)
						{
							Core.Draw.Line(left, mid, thickness, color);
							Core.Draw.Line(mid, p, thickness, color);

							/*spriteBatch.DrawLine(left, mid, color, thickness);
							spriteBatch.DrawLine(mid, p, color, thickness);*/
						}
						else
							Core.Draw.Line(left, p, thickness, color);
							//spriteBatch.DrawLine(left, p, color, thickness);
					}
					if (y > 1)
					{
						up = ToVec2(points[x, y - 1].Position);
						float thickness = (x % 3 == 1) ? 3f : 1f;
						int clampedY = Math.Min(y + 1, height - 1);
						float2 mid = CatmullRom(ToVec2(points[x, y - 2].Position), up, p, ToVec2(points[x, clampedY].Position), 0.5f);

						if (float2.DistanceSqr(mid, (up + p) / 2) > 1)
						{
							Core.Draw.Line(up, mid, thickness, color);
							Core.Draw.Line(mid, p, thickness, color);
							/*spriteBatch.DrawLine(up, mid, color, thickness);
							spriteBatch.DrawLine(mid, p, color, thickness);*/
						}
						else
							Core.Draw.Line(up, p, thickness, color);
							//spriteBatch.DrawLine(up, p, color, thickness);
					}

					// Add interpolated lines halfway between our point masses. This makes the grid look
					// denser without the cost of simulating more springs and point masses.
					if (x > 1 && y > 1)
					{
						float2 upLeft = ToVec2(points[x - 1, y - 1].Position);
						Core.Draw.Line(0.5f * (upLeft + up), 0.5f * (left + p), 1f, color);
						Core.Draw.Line(0.5f * (upLeft + left), 0.5f * (up + p), 1f, color);
						//spriteBatch.DrawLine(0.5f * (upLeft + up), 0.5f * (left + p), color, 1f);// vertical line
						//spriteBatch.DrawLine(0.5f * (upLeft + left), 0.5f * (up + p), color, 1f);// horizontal line
					}
				}
			}
		}

		public float2 ToVec2(float3 v)
		{
			// do a perspective projection
			let screenSize = (float2)Screen.Size / 2f;
			float factor = (v.z + 2000) / 2000;
			return (float2(v.x, v.y) - screenSize) * factor + screenSize;
		}

		public static float2 CatmullRom(float2 value1, float2 value2, float2 value3, float2 value4, float amount)
		{
			return .(CatmullRom(value1.x, value2.x, value3.x, value4.x, amount),
				CatmullRom(value1.y, value2.y, value3.y, value4.y, amount));
		}

		public static float CatmullRom(float value1, float value2, float value3, float value4, float amount)
		{
			// http://stephencarmody.wikispaces.com/Catmull-Rom+splines
			
			//value1 *= ((-amount + 2.0f) * amount - 1) * amount * 0.5f;
			//value2 *= (((3.0f * amount - 5.0f) * amount) * amount + 2.0f) * 0.5f;
			//value3 *= ((-3.0f * amount + 4.0f) * amount + 1.0f) * amount * 0.5f;
			//value4 *= ((amount - 1.0f) * amount * amount) * 0.5f;
			//
			//return value1 + value2 + value3 + value4;
			
			// http://www.mvps.org/directx/articles/catmull/

			float amountSq = amount * amount;
			float amountCube = amountSq * amount;

			// value1..4 = P0..3
			// amount = t
			return ((2.0f * value2 +
				(-value1 + value3) * amount +
				(2.0f * value1 - 5.0f * value2 + 4.0f * value3 - value4) * amountSq +
				(3.0f * value2 - 3.0f * value3 - value1 + value4) * amountCube) * 0.5f);
		}

		public override float Width => Screen.Width;
		public override float Height => Screen.Height;
	}
}
