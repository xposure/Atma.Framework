namespace Atma
{
	using SDL2;
	using System;

	public extension GraphicsManager
	{
		public static void* SdlGetProcAddress(StringView string)
		{
			return SDL.SDL_GL_GetProcAddress(string.ToScopeCStr!());
		}

		public this
		{
			GL.Init( => SdlGetProcAddress);
		}
	}
}
