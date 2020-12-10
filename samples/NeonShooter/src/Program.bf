//C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\VC\Tools\MSVC\14.27.29110\bin\Hostx64\x64
//C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\VC\Tools\MSVC\14.27.29110\bin\Hostx86\x86
//https://gamedevelopment.tutsplus.com/series/understanding-steering-behaviors--gamedev-12732
using System;
using Atma;
using System.Collections;
using NeonShooter.Scenes;

namespace NeonShooter
{
	static public class Program
	{
		static public int Main(String[] args)
		{
			/*Console.WriteLine(scope $"{AngleDifference2(0.2f, -0.1f)}");
			Console.WriteLine(scope $"{AngleDifference2(0.3f, -0.4f)}, {0.6f}");
			Console.WriteLine(scope $"{AngleDifference2(0.3f, -0.4f)}, {0.6f}");
			Console.WriteLine(scope $"{AngleDifference2(-0.4f, 0.3f)}, {-0.6f}")/*;*/


			let tt = 0.2f;
			for (var i < 10)
			{
				let t = 1f / 10 * i - 0.5f;
				let d = AngleDifference(tt, t);
				let r = tt + d;
				Console.WriteLine(scope $"prev: {tt}, next: {t}, diff: {d}, result: {r}");
			}

			Console.Read();
			return 0;*/
			Core.Run<TestScene>("Test", 1280, 760, .Hidden);
			//Core.Run<InitScene>("Test", 1280, 720, .Hidden);
			/*let game = new GameApp(new SDL_Platform(), "Beef Game", 1280, 720);
			//let game = new TestApp(new SDL_Platform(), "hello world", 1024, 768);
			//let game = new TestApp2(new SDL_Platform(), "hello world", 1440, 1024);
			//let game = new TestApp4(new SDL_Platform(), "hello world", 1024, 768);

			game.Run();

			delete game;*/
			return 0;
		}
	}
}
