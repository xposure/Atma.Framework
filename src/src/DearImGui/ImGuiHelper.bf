namespace Atma
{
	public extension ImGui
	{
		public extension Vec2
		{
			public readonly static Vec2 Zero = .(0, 0);
			public readonly static Vec2 Ones = .(1, 1);
			public readonly static Vec2 OneZero = .(1, 0);
			public readonly static Vec2 ZeroOne = .(0, 1);
			public readonly static Vec2 NOneZero = .(-1, 0);
		}

		public extension Vec4
		{
			public readonly static Vec4 Zero = .(0, 0, 0, 0);
			public readonly static Vec4 Ones = .(1, 1, 1, 1);
		}

		public static void Image(Atma.Subtexture texture, Atma.Color tint = .White)
		{
			let s = texture.Source.Size;
			let t0 = texture.TexCoords[0];
			let t1 = texture.TexCoords[2];

			if (texture.Texture != null)
				Image((.)texture.Texture.ID, .(s.x, s.y), .(t0.x, t0.y), .(t1.x, t1.y));
		}

		public static void ColorEdit3(char8* label, ref Atma.Color color, ColorEditFlags flags = 0)
		{
			float[3] c = .(color.Rf, color.Gf, color.Bf);
			ColorEdit3(label, c, flags);
			color.Rf = c[0];
			color.Gf = c[1];
			color.Bf = c[2];
		}

		public static void ColorEdit4(char8* label, ref Atma.Color color, ColorEditFlags flags = 0)
		{
			float[4] c = .(color.Rf, color.Gf, color.Bf, color.Af);
			ColorEdit4(label, c, flags);
			color.Rf = c[0];
			color.Gf = c[1];
			color.Bf = c[2];
			color.Af = c[3];
		}
	}
}
