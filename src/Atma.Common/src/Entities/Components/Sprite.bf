namespace Atma
{
	public class Sprite : GraphicsComponent
	{
		public Subtexture Subtexture;
		public Color Outline = Color.Transparent;

		public this(Subtexture subtexture, bool active = false)
		{
			Subtexture = subtexture;
			CenterOrigin();
		}

		public override void Render()
		{
			if (Subtexture.Texture != null)
				RenderAt(RenderPosition);
		}

		public void RenderOutlineAt(float2 position)
		{
			Core.Draw.Image(.(Subtexture, position, Scale, Origin, TotalRotation, Outline, Skew, .Filled));
			//Subtexture.DrawOutline(position, Origin, Tint, Scale, TotalRotation, Effects, Outline);
		}

		public void RenderAt(float2 position)
		{
			let mode = Washed ? DrawMode.Washed : DrawMode.Multiplied;
			RenderAt(position, mode, Tint);
		}

		public void RenderAt(float2 position, DrawMode mode, Color color)
		{
			if (Outline.A > 0)
				RenderOutlineAt(position);

			Core.Draw.Image(.(Subtexture, position, Scale, Origin, TotalRotation, color.Premultiplied, Skew, mode));
		}

		public override void DebugRender()
		{
			base.DebugRender();

			Core.Draw.Pixel(WorldPosition, .Red);
		}

		public override float Width
		{
			get { return Subtexture.Width; }
		}

		public override float Height
		{
			get { return Subtexture.Height; }
		}
	}
}
