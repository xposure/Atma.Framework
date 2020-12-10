/*using StbTrueTypeSharp;
using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Atma
{
	/// <summary>
	/// Static preconstructed Charsets
	/// </summary>
	public static class Charsets
	{
		public static readonly String ASCII = Make(32, 126) ~ delete _;

		public static String Make(int from, int to)
		{
			return Make((char8)from, (char8)to);
		}

		public static String Make(char8 from, char8 to)
		{
			let range = new String();
			let count = to - from + 1;
			for (var i = 0; i < count; i++)
				range.Append((char8)(from + i));

			return range;
		}
	}

	/// <summary>
	/// Parses and contains the Data to a single Font
	/// </summary>
	public abstract class Font
	{
		/// <summary>
		/// The Font Family Name
		/// </summary>
		public StringView FamilyName => _familyName;
		private readonly String _familyName = new .() ~ delete _;

		/// <summary>
		/// The Font Style Name
		/// </summary>
		public StringView StyleName => _styleName;
		private readonly String _styleName= new .() ~ delete _;

		/// <summary>
		/// The Font Ascent
		/// </summary>
		public readonly int Ascent;

		/// <summary>
		/// The Font Descent
		/// </summary>
		public readonly int Descent;

		/// <summary>
		/// The Line Gap of the Font. This is the vertical space between lines
		/// </summary>
		public readonly int LineGap;

		/// <summary>
		/// The Height of the Font (Ascent - Descent)
		/// </summary>
		public readonly int Height;

		/// <summary>
		/// The Line Height of the Font (Height + LineGap). This is the total height of a single line, including the
		// line gap </summary>
		public readonly int LineHeight => LineGap + Height;


		/// <summary>
		/// Loads a Font from the byte array. The Font will use this buffer until it is disposed.
		/// </summary>
		private this(byte[] buffer)
		{
			fontBuffer = buffer;
			//fontHandle = GCHandle.Alloc(fontBuffer, GCHandleType.Pinned);
			fontInfo = new StbTrueType.stbtt_fontinfo();

			StbTrueType.stbtt_InitFont(fontInfo, &fontBuffer[0], 0);

			_familyName.Set(GetName(fontInfo, 1));
			_styleName.Set(GetName(fontInfo, 2));

			// properties
			int ascent = ?, descent = ?, linegap = ?;
			StbTrueType.stbtt_GetFontVMetrics(fontInfo, &ascent, &descent, &linegap);
			Ascent = ascent;
			Descent = descent;
			LineGap = linegap;
			Height = Ascent - Descent;
			LineHeight = Height + LineGap;

			StringView GetName(StbTrueType.stbtt_fontinfo fontInfo, int nameID)
			{
				int length = 0;

				sbyte* ptr = StbTrueType.stbtt_GetFontNameString(fontInfo, &length,
					StbTrueType.STBTT_PLATFORM_ID_MICROSOFT,
					StbTrueType.STBTT_MS_EID_UNICODE_BMP,
					StbTrueType.STBTT_MS_LANG_ENGLISH,
					nameID);

				if (length > 0)
					return StringView((char8*)ptr, length );

				return "Unknown";
			}
		}

		/// <summary>
		/// Gets the Scale of the Font for a given Height. This value can then be used to scale proprties of a Font for
		// the given Height </summary>
		public float GetScale(int height)
		{
			return StbTrueType.stbtt_ScaleForPixelHeight(fontInfo, height);
		}

		/// <summary>
		/// Gets the Glyph code for a given Unicode value, if it exists, or 0 otherwise
		/// </summary>
		public int GetGlyph(char unicode)
		{
			if (glyphs.TryAdd(unicode, ?, var glyph))
			{
				*glyph = StbTrueType.stbtt_FindGlyphIndex(fontInfo, (.)unicode);
			}

			return *glyph;
		}
	}
}*/

