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
			//move the rect to the center of the screen
			var pos = (float2)Screen.Size / 2f;

			//Note: turn is 0-1 instead of 0 to 2pi
			//lets offset the rect in a circle motion
			pos += Calc.Turn(Time.Elapsedf / 4f) * 50;

			Core.Draw.Rect(aabb2.FromDimensions(pos, Screen.Size / 2), .White);
			Core.Draw.Render(Core.Window, Screen.Matrix);
		}

		protected override void Update()
		{
		}

		protected override void FixedUpdate()
		{
		}

		protected override void Unload()
		{
		}

		public static int Main(String[] args)
		{
			let game = scope Program("Hello World", 400, 300);
			return game.Run();
		}

		public this(StringView title, int width, int height, Window.WindowFlags windowFlags = .Hidden) : base(title, width, height, windowFlags)
		{
		}
	}
}