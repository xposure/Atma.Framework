using System;
namespace Atma
{
	using internal Atma;

	public extension Core
	{
		public static Scene Scene;

		internal static Func<Scene> _initialScene ~ delete _;

		public static int RunInitialScene<InitialScene>(StringView title, int width, int height, Window.WindowFlags flags = .Hidden)
			where InitialScene : Scene
		{
			_initialScene = new () => new InitialScene();
			return scope Game(title, width, height, flags).Run();
		}
	}
}
