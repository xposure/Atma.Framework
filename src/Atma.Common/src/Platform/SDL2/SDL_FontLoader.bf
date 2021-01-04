using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Atma
{
	public extension Assets
	{
		typealias byte = uint8;
		typealias sbyte = int8;
		typealias char = char8;

		private readonly GraphicsManager _graphics;
		public this(GraphicsManager graphics)
		{
			_graphics = graphics;
		}

		protected override static SpriteFont PlatformLoadFont(StringView path, int size)
		{
			let font = SDL2.SDLTTF.OpenFont(path.ToScopeCStr!(), (.)size);
			Runtime.Assert(font != null, "Could not init the font");

			//let glyphBounds = scope List<rect>();
			//let cropping = scope List<rect>();
			let lineSpacing = SDL2.SDLTTF.FontHeight(font);
			//let spacing = 0f;
			//let advance = scope List<float>();
			let defaultCharacter = ' ';

			let characters = scope List<char8>();
			characters.AddRange("abcdefghijklmnopqrstuvwxyz");
			characters.AddRange("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
			characters.AddRange("0123456789");
			characters.AddRange("!@#$%^&*()");
			characters.AddRange(" `~-_=+[{]};:'\",<.>/?\\|");

			//let glyphs = scope List<SDL2.SDL.Surface*>(characters.Count);
			let packer = new Packer(path);
			packer.Trim = false;
			defer delete packer;

			for (var i = 0; i < characters.Count; i++)
			{
				let surface = SDL2.SDLTTF.RenderGlyph_Blended(font, (.)characters[i], .(255, 255, 255, 255));
				let pixels = Span<Color>((Color*)surface.pixels, surface.w * surface.h);

				packer.AddPixels(StringView(&characters[i], 1), surface.w, surface.h, pixels);
				SDL2.SDL.FreeSurface(surface);
			}

			let output = packer.Packed;
			if (output != null)
			{
				let page = output.Page;
				page.Premultiply();

				let texture = new Texture(page.Width, page.Height);
				texture.SetData(page.Pixels);

				let glyphs = scope List<SpriteFont.Glyph>(characters.Count);

				for (var ch in characters)
				{
					SDL2.SDLTTF.GlyphMetrics(font, (.)ch, let minx, let maxx, let miny, let maxy, let adv);
					//let metrics = SDL2.SDLTTF.GlyphMetrics(font, (.)ch, let minx, let maxx, let miny, let maxy, let
					// adv);

					var glyph = SpriteFont.Glyph();
					glyph.Advance = adv;
					glyph.Character = ch;
					let entry = output.Entries[scope String(ch, 1)];

					glyph.Image = Subtexture(texture, entry.Source, entry.Frame);
					glyphs.Add(glyph);
				}
				texture.Filter = .Linear;
				return new SpriteFont(texture, glyphs, defaultCharacter, lineSpacing);
			}


			return null;
		}

	}
}

