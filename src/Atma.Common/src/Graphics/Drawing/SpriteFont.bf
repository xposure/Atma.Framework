// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

// Original code from SilverSprite Project
using System;
using System.Diagnostics;
using System.Text;
using System.Collections;

namespace Atma
{
	public sealed class SpriteFont
	{
		typealias char = char8;

		private static class Errors
		{
			public const String TextContainsUnresolvableCharacters =
				"Text contains characters that cannot be resolved by this SpriteFont.";
			public const String UnresolvableCharacter =
				"Character cannot be resolved by this SpriteFont.";
		}

		private readonly Glyph[] _glyphs ~ delete _;
		//private readonly CharacterRegion[] _regions ~ delete _;
		//private char? _defaultCharacter;
		private int _defaultGlyphIndex = -1;
		private char[] _characters ~ delete _;

		private readonly Texture _texture ~ delete _;

		/// <summary>
		/// All the glyphs in this SpriteFont.
		/// </summary>
		public ReadOnlySpan<Glyph> Glyphs => .(_glyphs);

		/*class CharComparer: IEqualityComparer<char>
		{
			public bool Equals(char x, char y)
			{
				return x == y;
			}

			public int GetHashCode(char b)
			{
				return int(b);
			}

			static public readonly CharComparer Default = new CharComparer();
		}*/

		public this(Texture texture, List<Glyph> glyphs, char defaultCharacter, int lineSpacing)
		{
			_texture = texture;
			LineSpacing = lineSpacing;

			_defaultGlyphIndex = -1;
			var maxCh = 0;
			for (var i < glyphs.Count)
			{
				if ((int)glyphs[i].Character > maxCh)
					maxCh = (int)glyphs[i].Character;
				if (glyphs[i].Character == defaultCharacter)
					_defaultGlyphIndex = i;
			}

			_glyphs = new Glyph[maxCh + 1];
			if (_defaultGlyphIndex > -1)
				for (var i < _glyphs.Count)
					_glyphs[i] = glyphs[_defaultGlyphIndex];

			for (var i < glyphs.Count)
				_glyphs[(int)glyphs[i].Character] = glyphs[i];
		}

		/*/// <summary>
		/// Initializes a new instance of the <see cref="SpriteFont" /> class.
		/// </summary>
		/// <param name="texture">The font texture.</param>
		/// <param name="glyphBounds">The rects in the font texture containing letters.</param>
		/// <param name="cropping">The cropping rects, which are applied to the corresponding glyphBounds to calculate
		// the bounds of the actual character.</param> <param name="characters">The characters.</param> <param
		// name="lineSpacing">The line spacing (the distance from baseline to baseline) of the font.</param> <param
		// name="spacing">The spacing (tracking) between characters in the font.</param> <param name="kerning">The
		// letters kernings(X - left side bearing, Y - width and Z - right side bearing).</param> <param
		// name="defaultCharacter">The character that will be substituted when a given character is not included in the
		// font.</param>
		public this(
			Texture texture, List<rect> glyphBounds, List<rect> cropping, List<char> characters,
			int lineSpacing, float spacing, List<float3> kerning, char? defaultCharacter)
		{
			_characters = new char[characters.Count];
			characters.CopyTo(_characters);

			//Characters = new ReadOnlyCollection<char>(characters.ToArray());
			_texture = texture;
			LineSpacing = lineSpacing;
			Spacing = spacing;

			_glyphs = new Glyph[characters.Count];
			var regions = scope List<CharacterRegion>();

			for (var i = 0; i < characters.Count; i++)
			{
				_glyphs[i] = .()
					{
						BoundsInTexture = glyphBounds[i],
						Cropping = cropping[i],
						Character = characters[i],

						LeftSideBearing = kerning[i].X,
						Width = kerning[i].Y,
						RightSideBearing = kerning[i].Z,

						WidthIncludingBearings = kerning[i].X + kerning[i].Y + kerning[i].Z
					};

				if (regions.Count == 0 || characters[i] > (regions.Back.End + 1))
				{
					// Start a new region
					regions.Add(.(characters[i], i));
				}
				else if (characters[i] == (regions.Back.End + 1))
				{
					var currentRegion = regions.PopBack();
					// include character in currentRegion
					currentRegion.End++;
					regions.Add(currentRegion);
				}
				else// characters[i] < (regions.Peek().End+1)
				{
					Runtime.Assert(false, "Invalid SpriteFont. Character map must be in ascending order.");
				}
			}

			_regions = new CharacterRegion[regions.Count];
			regions.CopyTo(_regions);
			//_regions = regions.ToArray();
			Array.Reverse(_regions);

			//DefaultCharacter = defaultCharacter;
			_defaultCharacter = defaultCharacter;
		}*/

		/// <summary>
		/// Gets the texture that this SpriteFont draws from.
		/// </summary>
		/// <remarks>Can be used to implement custom rendering of a SpriteFont</remarks>
		public Texture Texture { get { return _texture; } }

		/*/// <summary>
		/// Returns a copy of the dictionary containing the glyphs in this SpriteFont.
		/// </summary>
		/// <returns>A new Dictionary containing all of the glyphs inthis SpriteFont</returns>
		/// <remarks>Can be used to calculate character bounds when implementing custom SpriteFont rendering.</remarks>
		public Dictionary<char, Glyph> GetGlyphs()
		{
			var glyphsDictionary = new Dictionary<char, Glyph>(_glyphs.Length, CharComparer.Default);
			foreach(var glyph in _glyphs)
				glyphsDictionary.Add(glyph.Character, glyph);
			return glyphsDictionary;
		}*/

		/// <summary>
		/// Gets a collection of the characters in the font.
		/// </summary>
		public ReadOnlySpan<char> Characters => .(_characters);

		/*/// <summary>
		/// Gets or sets the character that will be substituted when a
		/// given character is not included in the font.
		/// </summary>
		public char? DefaultCharacter
		{
			get { return _defaultCharacter; }
			/*set
			{   
				// Get the default glyph index here once.
				if (value.HasValue)
				{
					if(!TryGetGlyphIndex(value.Value, out _defaultGlyphIndex))
						throw new ArgumentException(Errors.UnresolvableCharacter);
				}
				else
					_defaultGlyphIndex = -1;

				_defaultCharacter = value;
			}*/
		}*/

		/// <summary>
		/// Gets or sets the line spacing (the distance from baseline
		/// to baseline) of the font.
		/// </summary>
		public int LineSpacing { get; set; }

		/*/// <summary>
		/// Gets or sets the spacing (tracking) between characters in
		/// the font.
		/// </summary>
		public float Spacing { get; set; }*/

		/*/// <summary>
		/// Returns the size of a string when rendered in this font.
		/// </summary>
		/// <param name="text">The text to measure.</param>
		/// <returns>The size, in pixels, of 'text' when rendered in
		/// this font.</returns>
		public float2 MeasureString(StringView text)
		{
			var source = new CharacterSource(text);
			float2 size;
			MeasureString(ref source, out size);
			return size;
		}*/

		/// <summary>
		/// Returns the size of a string when rendered in this font.
		/// </summary>
		/// <param name="text">The text to measure.</param>
		/// <returns>The size, in pixels, of 'text' when rendered in
		/// this font.</returns>
		public float2 MeasureString(StringView text)
		{
			MeasureString(text, let size);
			return size;
		}

		/*/// <summary>
		/// Returns the size of the contents of a StringBuilder when
		/// rendered in this font.
		/// </summary>
		/// <param name="text">The text to measure.</param>
		/// <returns>The size, in pixels, of 'text' when rendered in
		/// this font.</returns>
		public float2 MeasureString(StringBuilder text)
		{
			var source = new CharacterSource(text);
			float2 size;
			MeasureString(ref source, out size);
			return size;
		}*/

		void MeasureString(StringView text, out float2 size)
		//void MeasureString(ref CharacterSource text, out float2 size)
		{
			if (text.Length == 0)
			{
				size = float2.Zero;
				return;
			}

			var width = 0.0f;
			var finalLineHeight = (float)LineSpacing;

			var offset = float2.Zero;
			var firstGlyphOfLine = true;


			//fixed (Glyph* pGlyphs = Glyphs)
			//var pGlyphs = &_glyphs[0];
			for (var i = 0; i < text.Length; ++i)
			{
				var c = text[i];

				if (c == '\r')
					continue;

				if (c == '\n')
				{
					finalLineHeight = LineSpacing;

					offset.x = 0;
					offset.y += LineSpacing;
					firstGlyphOfLine = true;
					continue;
				}

				var currentGlyphIndex = GetGlyphIndexOrDefault(c);
				var pCurrentGlyph = _glyphs[currentGlyphIndex];

				/*// The first character on a line might have a negative left side bearing.
				// In this scenario, SpriteBatch/SpriteFont normally offset the text to the right,
				//  so that text does not hang off the left side of its rect.
				if (firstGlyphOfLine)
				{
					offset.X = Math.Max(pCurrentGlyph.LeftSideBearing, 0);
					firstGlyphOfLine = false;
				} else
				{
					offset.X += Spacing + pCurrentGlyph.LeftSideBearing;
				}*/

				offset.x += pCurrentGlyph.Advance;

				if (offset.x > width)
					width = offset.x;

				/*var proposedWidth = offset.X + Math.Max(pCurrentGlyph.RightSideBearing, 0);
				if (proposedWidth > width)
					width = proposedWidth;

				offset.X += pCurrentGlyph.RightSideBearing;

				if (pCurrentGlyph.Cropping.Height > finalLineHeight)
					finalLineHeight = pCurrentGlyph.Cropping.Height;*/
			}

			size = .(width, offset.y + finalLineHeight);
			/*size.X = width;
			size.Y = offset.Y + finalLineHeight;*/
		}

		/*bool TryGetGlyphIndex(char c, out int index)
		{
			//fixed (CharacterRegion* pRegions = _regions)
			var pRegions = &_regions[0];
			{
				// Get region Index
				int regionIdx = -1;
				var l = 0;
				var r = _regions.Count - 1;
				while (l <= r)
				{
					var m = (l + r) >> 1;
					Debug.Assert(m >= 0 && m < _regions.Count, "Index was outside the bounds of the array.");
					if (pRegions[m].End < c)
					{
						l = m + 1;
					}
					else if (pRegions[m].Start > c)
					{
						r = m - 1;
					}
					else
					{
						regionIdx = m;
						break;
					}
				}

				if (regionIdx == -1)
				{
					index = -1;
					return false;
				}

				index = pRegions[regionIdx].StartIndex + (c - pRegions[regionIdx].Start);
			}

			return true;
		}
		*/

		[Inline]
		public int GetGlyphIndexOrDefault(char c)
		{
			var currentGlyphIndex = (int)c;//GetGlyphIndexOrDefault(c);
			if (currentGlyphIndex < 0 || currentGlyphIndex >= _glyphs.Count)
				currentGlyphIndex = _defaultGlyphIndex;

			Debug.Assert(currentGlyphIndex >= 0 && currentGlyphIndex < _glyphs.Count, "currentGlyphIndex was outside the bounds of the array.");
			return currentGlyphIndex;
		}

		/*struct CharacterSource 
		{
			private readonly String _string;
			private readonly StringBuilder _builder;

			public CharacterSource(string s)
			{
				_string = s;
				_builder = null;
				Length = s.Length;
			}

			public CharacterSource(StringBuilder builder)
			{
				_builder = builder;
				_string = null;
				Length = _builder.Length;
			}

			public readonly int Length;
			public char this [int index] 
			{
				get 
				{
					if (_string != null)
						return _string[index];
					return _builder[index];
				}
			}
		}*/

		/// <summary>
		/// Struct that defines the spacing, Kerning, and bounds of a character.
		/// </summary>
		/// <remarks>Provides the data necessary to implement custom SpriteFont rendering.</remarks>
		public struct Glyph
		{
			/// <summary>
			/// The char associated with this glyph.
			/// </summary>
			public char Character;

			public Subtexture Image;
			/*/// <summary>
			/// rect in the font texture where this letter exists.
			/// </summary>
			public rect BoundsInTexture;
			/// <summary>
			/// Cropping applied to the BoundsInTexture to calculate the bounds of the actual character.
			/// </summary>
			public rect Cropping;*/
			/*/// <summary>
			/// The amount of space between the left side ofthe character and its first pixel in the X dimention.
			/// </summary>
			public float LeftSideBearing;
			/// <summary>
			/// The amount of space between the right side of the character and its last pixel in the X dimention.
			/// </summary>
			public float RightSideBearing;
			/// <summary>*/
			/// Width of the character before kerning is applied. 
			/// </summary>
			public float Advance;
			/*/// <summary>
			/// Width of the character before kerning is applied. 
			/// </summary>
			public float WidthIncludingBearings;*/

			public static readonly Glyph Empty = default;

			public override void ToString(String buffer)
			{
				//buffer.AppendF("CharacterIndex={0}, Glyph={1}, Cropping={2}, Kerning={3},{4},{5}", Character,
				// BoundsInTexture, Cropping, LeftSideBearing, Width, RightSideBearing);
				buffer.AppendF("CharacterIndex={0}, Advance={1}, Image: {2}", Character, Advance, Image);
			}
		}

		/*private struct CharacterRegion
		{
			public char Start;
			public char End;
			public int StartIndex;

			public this(char start, int startIndex)
			{
				this.Start = start;                
				this.End = start;
				this.StartIndex = startIndex;
			}
		}*/
	}
}