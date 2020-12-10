/*using System;
using static SDL2.SDL;
namespace Atma
{
	public class SDL_TextureLoader : IAssetLoader
	{
		private readonly GraphicsManager _graphics;

		public this(GraphicsManager graphcis)
		{
			_graphics = graphcis;
		}

		public Object Load(StringView path)
		{
			let image = SDL2.SDLImage.Load(path.Ptr);// Load like an other SDL_Surface

#if false
			let rmask = 0xff000000;
			let gmask = 0x00ff0000;
			let bmask = 0x0000ff00;
			let amask = 0x000000ff;
#else
			let rmask = 0x000000ff;
			let gmask = 0x0000ff00;
			let bmask = 0x00ff0000;
			let amask = 0xff000000;
#endif
			let newSurface = CreateRGBSurface(0, image.w, image.h, 32, rmask, gmask, bmask, amask);

			var rect = SDL2.SDL.Rect(0, 0, image.w, image.h);
			SDL_BlitSurface(image, &rect, newSurface, &rect);

			let texture = new Texture(image.w, image.h, .Color);
			texture.SetData<Color>(.((Color*)newSurface.pixels, image.w * image.h));


			FreeSurface(image);
			FreeSurface(newSurface);

			return texture;
		}
	}
}*/
