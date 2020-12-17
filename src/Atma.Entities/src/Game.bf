using System;
namespace Atma
{
	using internal Atma;

	public class Game : Core
	{
		protected override void Update()
		{
			Scene.InternalUpdate();
		}

		protected override void FixedUpdate()
		{
			Scene.InternalFixedUpdate();
		}

		protected override void Render()
		{
			Scene.Render();
		}

		protected override void Initialize()
		{
			Scene = _initialScene();
			DeleteAndNullify!(_initialScene);
		}

		protected override void Unload()
		{
			delete Scene;
		}

		public this(StringView title, int width, int height, Window.WindowFlags windowFlags) : base(title, width, height, windowFlags)
		{
		}
	}
}
