using Atma;
namespace NeonShooter.Components
{
	public class RectComponent : GraphicsComponent
	{
		public this()
		{
			CenterOrigin();
		}
		public override void Render()
		{
			const int size = 10;
			let w = Screen.Width / (float)size;
			let h = Screen.Height;

			for (var i < size)
			{
				let iw = w * i;
				Core.Draw.Rect(aabb2.FromRect(iw, 0, w, h).Offset(-Center), Color.Lerp(Color.Black, Color.White, i / (float)size));
			}
		}

		public override float Width => Screen.Width;

		public override float Height => Screen.Height;
	}
}
