using System;
using Atma;

namespace HelloWorld
{
	class Program : Core
	{
		protected override void Initialize()
		{
		}

		protected override void Render()
		{
			Core.Draw.Rect(aabb2.FromDimensions(.(0, 0), .(100, 100)), .White);
			Core.Draw.Render(Core.Window, Screen.Matrix);
		}

		protected override void Update()
		{
		}

		protected override void Unload()
		{
		}

		public static int Main(String[] args)
		{
			return Core.Run("Hello World!", 400, 300);
		}
	}
}