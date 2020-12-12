namespace Atma
{
	using SDL2;

	class SDL_GraphicsContext : GraphicsContext
	{
		public readonly SDL.SDL_GLContext context;
		public readonly SDL.Window* window;

		public uint32 LastVertexBuffer = 0;

		public this(SDL.Window* window)
		{
			this.window = window;
			context = SDL.GL_CreateContext(window);
		}

		public ~this()
		{
			SDL.GL_DeleteContext(context);
		}

		protected override void MakeActiveInternal()
		{
			SDL.SDL_GL_MakeCurrent(window, context);
		}
	}
}
