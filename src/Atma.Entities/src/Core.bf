using System;
namespace Atma
{
	using internal Atma;

	public extension Core
	{
		public static Scene Scene;

		internal static Func<Scene> _initialScene ~ delete _;

		public static int RunScene<T>(String title, int width, int height, Window.WindowFlags flags = .Hidden)
			where T : Scene
		{
			_initialScene = new () => new T();
			Core.Run(title, width, height, flags);

			return 0;
		}
	}

	public class Game : Core
	{
		protected override void Update()
		{
			Scene.FixedUpdate();
		}

		protected override void Render()
		{
			Scene.Render();
		}

		protected override void Initialize()
		{
			Scene = _initialScene();
			Scene.Initialize();

			DeleteAndNullify!(_initialScene);
		}

		protected override void Unload()
		{
			delete Scene;
		}
	}
}
