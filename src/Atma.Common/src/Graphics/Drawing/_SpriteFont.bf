/*using System;
using System.Collections;
using System.IO;
using Atma.Math;

namespace Atma
{
	/// <summary>
	/// Sprite Font is a Font rendered to a Texture at a given size, which is useful for drawing Text with sprite
	// batchers </summary>
	public class SpriteFont
	{
		/// <summary>
		/// A single Sprite Font Character
		/// </summary>
		public struct Character : IDisposable
		{
			/// <summary>
			/// The Unicode Value
			/// </summary>
			public char8 Unicode;

			/// <summary>
			/// The rendered Character Image
			/// </summary>
			public Subtexture Image;

			/// <summary>
			/// The Offset to draw the Character at
			/// </summary>
			public float2 Offset;

			/// <summary>
			/// The Amount to Advance the rendering by, horizontally
			/// </summary>
			public float Advance;

			/// <summary>
			/// The Kerning value for following Characters
			/// </summary>
			public Dictionary<char8, float> Kerning = new Dictionary<char8, float>();

			public this(char8 unicode, Subtexture image, float2 offset, float advance)
			{
				Unicode = unicode;
				Image = image;
				Offset = offset;
				Advance = advance;
			}

			public void Dispose()
			{
				delete Kerning;
			}
		}

		/// <summary>
		/// A list of all the Characters in the Sprite Font
		/// </summary>
		public readonly Dictionary<char8, Character> Charset = new Dictionary<char8, Character>() ~ delete _;

		/// <summary>
		/// The Font Family Name
		/// </summary>
		public StringView FamilyName => _familyName;
		private String _familyName = new .() ~ delete _;
		/// <summary>
		/// The Font Style Name
		/// </summary>
		public StringView StyleName => _styleName;
		private String _styleName = new .() ~ delete _;

		/// <summary>
		/// The Size of the Sprite Font
		/// </summary>
		public int Size;

		/// <summary>
		/// The Font Ascent
		/// </summary>
		public float Ascent;

		/// <summary>
		/// The Font Descent
		/// </summary>
		public float Descent;

		/// <summary>
		/// The Line Gap of the Font. This is the vertical space between lines
		/// </summary>
		public float LineGap;

		/// <summary>
		/// The Height of the Font (Ascent - Descent)
		/// </summary>
		public float Height;

		/// <summary>
		/// The Line Height of the Font (Height + LineGap). This is the total height of a single line, including the
		// line gap </summary>
		public float LineHeight;

		public this(StringView familyName, StringView styleName)
		{
			_familyName.Set(familyName);
			_styleName.Set(styleName);
		}

		public this(StringView fontFile, int size, StringView charset, TextureFilter filter = TextureFilter.Linear)
			: this(FontSize(Font(fontFile), size, charset), filter)
		{
		}

		public this(Stream stream, int size, StringView charset, TextureFilter filter = TextureFilter.Linear)
			: this(FontSize(Font(stream), size, charset), filter)
		{
		}

		public this(Font font, int size, StringView charset, TextureFilter filter = TextureFilter.Linear)
			: this(FontSize(font, size, charset), filter)
		{
		}

		public this(FontSize fontSize, TextureFilter filter = TextureFilter.Linear)
		{
			FamilyName = fontSize.Font.FamilyName;
			StyleName = fontSize.Font.StyleName;
			Size = fontSize.Size;
			Ascent = fontSize.Ascent;
			Descent = fontSize.Descent;
			LineGap = fontSize.LineGap;
			Height = fontSize.Height;
			LineHeight = fontSize.LineHeight;

			var packer = new Packer();
			{
				var bufferSize = (fontSize.Size * 2) * (fontSize.Size * 2);
				var buffer = (bufferSize <= 16384 ? stackalloc Color[bufferSize] : new Color[bufferSize]);

				foreach (var ch in fontSize.Charset.Values)
				{
					var name = ch.Unicode.ToString();

					// pack bmp
					if (fontSize.Render(ch.Unicode, buffer, out int w, out))
					packer.AddPixels(name, w, h, buffer);

					// create character
					var sprChar = new Character(ch.Unicode, new Subtexture(), new float2(ch.OffsetX, ch.OffsetY), ch.Advance);
					Charset.Add(ch.Unicode, sprChar);

					// get all kerning
					foreach (var ch2 in fontSize.Charset.Values)
					{
						var kerning = fontSize.GetKerning(ch.Unicode, ch2.Unicode);
						if (Math.Abs(kerning) > 0.000001f)
							sprChar.Kerning[ch2.Unicode] = kerning;
					}
				}

				packer.Pack();
			}

			// link textures
			var output = packer.Pack();
			if (output != null)
			{
				for (int i = 0; i < output.Pages.Count; i++)
				{
					var texture = new Texture(output.Pages[i]);
					texture.Filter = filter;

					foreach (var entry in output.Entries.Values)
					{
						if (entry.Page != i)
							continue;

						if (Charset.TryGetValue(entry.Name[0], out var character))
						character.Image.Reset(texture, entry.Source, entry.Frame);
					}
				}
			}
		}

		/// <summary>
		/// Measures the Width of the given text
		/// </summary>
		public float WidthOf(StringView text)
		{
			var width = 0f;
			var line = 0f;

			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == '\n')
				{
					if (line > width)
						width = line;
					line = 0;
					continue;
				}

				if (!Charset.TryGetValue(text[i], let ch))
					continue;

				line += ch.Advance;
			}

			return Math.Max(width, line);
		}

		public float HeightOf(StringView text)
		{
			if (text.Length <= 0)
				return 0;

			var height = Height;

			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == '\n')
					height += LineHeight;
			}

			return height;
		}

		public float2 SizeOf(StringView text)
		{
			return .(WidthOf(text), HeightOf(text));
		}
	}
}*/

