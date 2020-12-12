using System;
using System.IO;

namespace Atma
{
	public extension Assets
	{
		protected static override Image PlatformLoadImage(StringView path)
		{
			return SDLImage.Load(path);
		}
	}
}

namespace Atma
{
	using static SDL2.SDL;

	static class SDLImage
	{
		typealias Color = Atma.Color;

		public static Image Load(StringView path)
		{
			let sr = scope StreamReader();

			if (sr.Open(path) case .Err(let err))
			{
				Log.Error($"Failed to read file [{path}] err: {err}");
				return null;
			}

			let text = scope String();
			if (sr.ReadToEnd(text) case .Err)
			{
				Log.Error($"Failed to read to end of file [{path}]");
				return null;
			}

			let rw = SDL2.SDL.RWFromMem(text.Ptr, (.)text.Length);
			let image = SDL2.SDLImage.Load_RW(rw, 1);

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

			var pixels = new Color[rect.w * rect.h];
			var srcPixels = Span<Color>((Color*)newSurface.pixels, pixels.Count);
			srcPixels.CopyTo(pixels);

			var imageData = new Image(rect.w, rect.h, pixels);

			FreeSurface(image);
			FreeSurface(newSurface);

			return imageData;
		}
	}
}