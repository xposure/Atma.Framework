using System;
namespace Atma
{
	using internal Atma;

	public extension Core
	{
		public static Scene Scene;

		private static Func<Scene> _initialScene ~ delete _;

		protected static override void Update()
		{
			Scene.FixedUpdate();
		}

		protected static override void Render()
		{
			Scene.Render();
		}

		protected static override void Initialize()
		{
			Scene = _initialScene();
			Scene.Initialize();

			DeleteAndNullify!(_initialScene);
		}

		protected static override void Unload()
		{
			delete Scene;
		}

		public static int RunScene<T>(String title, int width, int height, Window.WindowFlags flags = .Hidden)
			where T : Scene
		{
			Window.WindowArgs windowArgs = ?;
			windowArgs.Title = title;
			windowArgs.Width = width;
			windowArgs.Height = height;
			windowArgs.Flags = flags;
			_initialScene = new () => new T();
			Core.Run(windowArgs);

			return 0;
		}
	}
}
