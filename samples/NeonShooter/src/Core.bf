namespace Atma
{
	public extension Core
	{
		static this()
		{
			Core.Emitter.AddObserver<CoreEvents.Initialize>(new => Initialize);
		}

		static ~this()
		{
			Core.Emitter.RemoveObserver<CoreEvents.Initialize>(scope => Initialize);
		}

		static void Initialize(CoreEvents.Initialize e)
		{
			DefaultFont = Core.Assets.LoadFont(@"fonts/PressStart2P.ttf", 16);
		}
	}
}
