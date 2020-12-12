using System;
using Atma;

namespace HelloWorld
{
	class Program : Scene
	{
		public override void Initialize()
		{
			base.Initialize();
			this.Camera.Origin = .(0.5f, 0.5f);
		} protected internal override void Render()
		{
			Core.Draw.Rect(aabb2.FromDimensions(.(0, 0), .(100, 100)), .White);

			base.Render();
		}

		public static int Main(String[] args)
		{
			return Core.RunScene<Program>("Hello World!", 400, 300);
		}
	}
}