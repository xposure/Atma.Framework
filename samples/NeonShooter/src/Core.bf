namespace Atma
{
	public extension Core
	{
		public static SpriteFont DefaultFont;

		//These don't work currently https://github.com/beefytech/Beef/issues/705
		static this
		{
			//works with specifying the type
			Core.Emitter.AddObserver<CoreEvents.GameInitialize>(new => GameInit);
		}

		static ~this()
		{
			//compiler can't determine type (should be CoreEvents.GameInitialize)
			Core.Emitter.RemoveObserver<CoreEvents.GameInitialize>(scope => GameInit);
		}

		static void GameInit(CoreEvents.GameInitialize e)
		{
			DefaultFont = Core.Assets.LoadFont(@"fonts/PressStart2P.ttf", 16);
		}
	}
}
