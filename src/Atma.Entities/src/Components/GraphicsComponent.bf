using System;
namespace Atma
{
	public abstract class GraphicsComponent : Renderable
	{
		private float* _spriteRotation;
		public ref float SpriteRotation => ref *_spriteRotation;

		public float2 Offset = float2.Zero;
		public float2 Origin = float2.Zero;;
		public float2 Scale = float2.Ones;
		public float2 Skew = float2.Zero;
		public Color Tint = Color.White;
		public bool Washed = false;
		public bool FlipX = false;
		public bool FlipY = false;
		public bool UseParentRotation = true;
		public bool RoundRenderPosition = false;

		public this(bool visible = true, bool active = false) : base(active)
		{
			Visible = visible;
			Integrations.AddTurn(out _spriteRotation);
		}

		public float2 Center => Origin * Scale;

		public float2 Size => .(Width, Height);

		public override aabb2 Bounds => aabb2.FromRect(WorldPosition - Center, Size * Scale);

		protected float TotalRotation => (SpriteRotation + (UseParentRotation ? WorldRotation : 0));

		public void SetOrigin(float x, float y)
		{
			Origin.x = x;
			Origin.y = y;
		}

		public void CenterOrigin()
		{
			Origin.x = Width / 2f;
			Origin.y = Height / 2f;
		}

		public void JustifyOrigin(float2 at)
		{
			Origin.x = Width * at.x;
			Origin.y = Height * at.y;
		}

		public GraphicsComponent JustifyOrigin(float x, float y)
		{
			Origin.x = Width * x;
			Origin.y = Height * y;
			return this;
		}

		public abstract float Width { get; }
		public abstract float Height { get; }

		public float X
		{
			get { return Offset.x; }
			set { Offset.x = value; }
		}

		public float Y
		{
			get { return Offset.y; }
			set { Offset.y = value; }
		}

		public float2 RenderPosition
		{
			get
			{
				if (RoundRenderPosition)
					return (int2)(Offset + WorldPosition);

				return Offset + WorldPosition;
			}
		}

		public override void DebugRender()
		{
			base.DebugRender();

			let bounds = Bounds;

			if (TotalRotation == 0)
			{
				Core.Draw.HollowRect(bounds, 1f, Tint);
			}
			else
			{
				bounds.Rotate(WorldPosition, TotalRotation, let points);
				for (var i < points.Count)
					Core.Draw.Line(points[i], points[(i + 1) % 4], 1, Tint);
			}

			Core.Draw.Rect(aabb2.FromRect(WorldPosition, int2.Ones), Color.Red);
		}
	}
}
