using System;

namespace Atma
{
	[Ordered, Packed, CRepr]
	public struct Color : IHashable
	{
		public static readonly Color CornflowerBlue = 0x6495edff;
		//public static readonly Color CornflowerBlue = 0xed9564ff;
		static public readonly Color White = 0xFFFFFFFF;
		static public readonly Color Black = 0x000000FF;
		static public readonly Color Transparent = 0x00000000;
		static public readonly Color Red = 0xFF0000FF;
		static public readonly Color Green = 0x00FF00FF;
		static public readonly Color Blue = 0x0000FFFF;
		static public readonly Color Cyan = 0x00FFFFFF;
		static public readonly Color Magenta = 0xFF00FFFF;
		static public readonly Color Yellow = 0xFFFF00FF;
		static public readonly Color DarkGray = 0x3F3F3FFF;
		static public readonly Color Gray = 0x7F7F7FFF;
		static public readonly Color LightGray = 0xBFBFBFFF;
		static public readonly Color Brown = 0xA52A2AFF;

		public uint8 R;
		public uint8 G;
		public uint8 B;
		public uint8 A;

		public this(int from) : this((uint)from)
		{
		}

		public this(uint from)
		{
			R = (uint8)((from >> 24) & 0xFF);
			G = (uint8)((from >> 16) & 0xFF);
			B = (uint8)((from >> 8) & 0xFF);
			A = (uint8)(from & 0xFF);
		}

		public this(Color color, float alpha = 1)
		{
			R = color.R;
			G = color.G;
			B = color.B;
			A = (.)(alpha * 255);
		}

		public this(Color color, uint8 alpha = 255)
		{
			R = color.R;
			G = color.G;
			B = color.B;
			A = alpha;
		}

		public this(uint8 red, uint8 green, uint8 blue, uint8 alpha = 255)
		{
			R = red;
			G = green;
			B = blue;
			A = alpha;
		}

		public this(float red, float green, float blue, float alpha = 1f)
		{
			R = (uint8)(red * 255);
			G = (uint8)(green * 255);
			B = (uint8)(blue * 255);
			A = (uint8)(alpha * 255);
		}

		public this()
		{
			R = G = B = A = 0;
		}

		public float Rf
		{
			[Inline]
			get
			{
				return R / 255f;
			}

			[Inline]
			set mut
			{
				R = (uint8)(value * 255);
			}
		}

		public float Gf
		{
			[Inline]
			get
			{
				return G / 255f;
			}

			[Inline]
			set mut
			{
				G = (uint8)(value * 255);
			}
		}

		public float Bf
		{
			[Inline]
			get
			{
				return B / 255f;
			}

			[Inline]
			set mut
			{
				B = (uint8)(value * 255);
			}
		}

		public float Af
		{
			[Inline]
			get
			{
				return A / 255f;
			}

			[Inline]
			set mut
			{
				A = (uint8)(value * 255);
			}
		}

		public override void ToString(String strBuffer)
		{
			strBuffer.Append("RGBA [0x");
			strBuffer.AppendF("{0:X2}", R);
			strBuffer.AppendF("{0:X2}", G);
			strBuffer.AppendF("{0:X2}", B);
			strBuffer.AppendF("{0:X2}", A);
			strBuffer.Append("]");

			/*strBuffer.Set("Color [ ");
			((uint)R).ToString(strBuffer);
			strBuffer.Append(", ");
			((uint)G).ToString(strBuffer);
			strBuffer.Append(", ");
			((uint)B).ToString(strBuffer);
			strBuffer.Append(", ");
			((uint)A).ToString(strBuffer);
			strBuffer.Append(" ]");*/
		}

		public uint32 ABGR => (((uint32)A) << 24) | (((uint32)B) << 16) | (((uint32)B) << 8) | ((uint32)R);

		static public Color Lerp(Color a, Color b, float t)
		{
			return Color(
				Math.Lerp(a.Rf, b.Rf, t),
				Math.Lerp(a.Gf, b.Gf, t),
				Math.Lerp(a.Bf, b.Bf, t),
				Math.Lerp(a.Af, b.Af, t)
				);
		}

		static public implicit operator Color(uint32 from)
		{
			return Color(
				(uint8)((from >> 24) & 0xFF),
				(uint8)((from >> 16) & 0xFF),
				(uint8)((from >> 8) & 0xFF),
				(uint8)(from & 0xFF)
				);
		}

		static public implicit operator uint32(Color from)
		{
			return (((uint32)from.R) << 24) | (((uint32)from.G) << 16) | (((uint32)from.B) << 8) | ((uint32)from.A);
		}

		static public implicit operator float4(Color from) => .(from.Rf, from.Gf, from.Bf, from.Af);
		static public implicit operator Color(float4 from) => .(from.x, from.y, from.z, from.w);

		static public Color operator/(Color a, Color b)
		{
			return Lerp(a, b, 0.5f);
		}

		static public Color operator*(Color color, float b)
		{
			return .((uint8)(color.R * b), (uint8)(color.G * b), (uint8)(color.B * b), (uint8)(color.A * b));
		}

		static public Color operator+(Color color, Color b)
		{
			return .((uint8)(color.R + color.R), (uint8)(color.G + color.G), (uint8)(color.B + color.B), (uint8)(color.A + color.A));
		}

		static public Color operator-(Color color, Color b)
		{
			return .((uint8)(color.R - color.R), (uint8)(color.G - color.G), (uint8)(color.B - color.B), (uint8)(color.A - color.A));
		}

		/*static public Color operator*(Color color, float b)
		{
			return .((uint8)(color.R * b), (uint8)(color.G * b), (uint8)(color.B * b), color.A);
		}

		static public Color operator*(Color dest, Color src)
		{
			if (src.A != 0)
			{
				if (dest.A == 0)
				{
					return ToPremultiplied(src.R, src.G, src.B, src.A);
				}
				else
				{
					var sa = MUL_UN8(src.A, 255);
					var ra = dest.A + sa - MUL_UN8(dest.A, sa);

					return .((uint8)(dest.R + ((int)src.R - dest.R) * sa / ra),
						(uint8)(dest.G + ((int)src.G - dest.G) * sa / ra),
						(uint8)(dest.B + ((int)src.B - dest.B) * sa / ra),
						(uint8)ra);
				}
			}
			return .Transparent;
		}

		[Inline]
		private static int MUL_UN8(int a, int b)
		{
			var t = (a * b) + 0x80;
			return (((t >> 8) + t) >> 8);
		}*/

		public int GetHashCode()
		{
			return (uint32)this;
		}

		public void Premultiply() mut
		{
			R = (uint8)((int)R * A / 255);
			G = (uint8)((int)G * A / 255);
			B = (uint8)((int)B * A / 255);
		}

		public Color Premultiplied
		{
			get
			{
				return .((uint8)((int)R * A / 255),
					(uint8)((int)G * A / 255),
					(uint8)((int)B * A / 255), A);
			}
		}

		public Color ToAlpha(uint8 alpha)
		{
			return .(this, alpha);
		}

		public Color ToAlpha(float alpha)
		{
			return .(this, alpha);
		}


		public static Color ToPremultiplied(uint8 R, uint8 G, uint8 B, uint8 A)
		{
			return .((uint8)((int)R * A / 255),
				(uint8)((int)G * A / 255),
				(uint8)((int)B * A / 255),
				A);
		}


		public static Color HSVToColor(float h, float s, float v)
		{
			if (h == 0 && s == 0)
				return Color(v, v, v);

			float c = s * v;
			float x = c * (1 - Math.Abs(h % 2 - 1));
			float m = v - c;

			if (h < 1) return Color(c + m, x + m, m);
			else if (h < 2) return Color(x + m, c + m, m);
			else if (h < 3) return Color(m, c + m, x + m);
			else if (h < 4) return Color(m, x + m, c + m);
			else if (h < 5) return Color(x + m, m, c + m);
			else return Color(c + m, m, x + m);
		}
	}
}
