using System;
using Atma;

namespace HelloWorld
{
	class Program : Scene
	{
		protected internal override void Render()
		{
			base.Render();
		}

		public static int Main(String[] args)
		{
			return Core.RunScene<Program>("Hello World!", 400, 300);
		}
	}
}