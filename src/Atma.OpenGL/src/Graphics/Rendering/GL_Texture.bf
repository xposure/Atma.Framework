namespace Atma
{
	using System.Threading;
	using System;

	public extension Texture
	{
		private uint32 glId;
		private GLEnum glInternalFormat;
		private GLEnum glFormat;
		private GLEnum glType;

		protected override void Platform_Destroy()
		{
			GL.DeleteTextures(1, &glId);
			_id = 0;
		}

		protected override void Platform_Init()
		{
			switch (Format) {
			case .Red:
				glInternalFormat = GLEnum.RED;
				glFormat = GLEnum.RED;
				glType = GLEnum.UNSIGNED_BYTE;
			case .RG:
				glInternalFormat = GLEnum.RG;
				glFormat = GLEnum.RG;
				glType = GLEnum.UNSIGNED_BYTE;
			case .RGB:
				glInternalFormat = GLEnum.RGB;
				glFormat = GLEnum.RGB;
				glType = GLEnum.UNSIGNED_BYTE;
			case .Color:
				glInternalFormat = GLEnum.RGBA;
				glFormat = GLEnum.RGBA;
				glType = GLEnum.UNSIGNED_BYTE;
			case .DepthStencil:
				glInternalFormat = GLEnum.DEPTH24_STENCIL8;
				glFormat = GLEnum.DEPTH24_STENCIL8;
				glType = GLEnum.UNSIGNED_INT_24_8;
			case .RGBA16F:
				glInternalFormat = GLEnum.RGBA16F;
				glFormat = GLEnum.RGBA;
				glType = GLEnum.FLOAT;

			}

			Initialize(width, height);
		}

		private void Initialize(int width, int height)
		{
			GL.GenTextures(1, &glId);
			using (PushTexture(glId, 0))
			{
				GL.TexImage2D((.)GLEnum.TEXTURE_2D, 0, (.)glInternalFormat, Width, Height, 0, (.)glFormat, (.)glType, null);
				GL.TexParameteri((.)GLEnum.TEXTURE_2D, (.)GLEnum.TEXTURE_MIN_FILTER, (.)(Filter == TextureFilter.Nearest ? GLEnum.NEAREST : GLEnum.LINEAR));
				GL.TexParameteri((.)GLEnum.TEXTURE_2D, (.)GLEnum.TEXTURE_MAG_FILTER, (.)(Filter == TextureFilter.Nearest ? GLEnum.NEAREST : GLEnum.LINEAR));
				GL.TexParameteri((.)GLEnum.TEXTURE_2D, (.)GLEnum.TEXTURE_WRAP_S, (.)(WrapX == TextureWrap.Clamp ? GLEnum.CLAMP_TO_EDGE : GLEnum.REPEAT));
				GL.TexParameteri((.)GLEnum.TEXTURE_2D, (.)GLEnum.TEXTURE_WRAP_T, (.)(WrapY == TextureWrap.Clamp ? GLEnum.CLAMP_TO_EDGE : GLEnum.REPEAT));
			}
			_id = glId;
		}

		protected override void Platform_Resize(int width, int height)
		{
			Platform_Destroy();
			Initialize(width, height);
		}

		protected override void Platform_SetFilter(TextureFilter filter)
		{
			GLEnum f = (filter == TextureFilter.Nearest ? GLEnum.NEAREST : GLEnum.LINEAR);

			using (PushTexture(glId, 0))
			{
				GL.TexParameteri((.)GLEnum.TEXTURE_2D, (.)GLEnum.TEXTURE_MIN_FILTER, (int)f);
				GL.TexParameteri((.)GLEnum.TEXTURE_2D, (.)GLEnum.TEXTURE_MAG_FILTER, (int)f);
			}
		}

		protected override void Platform_SetWrap(TextureWrap x, TextureWrap y)
		{
			GLEnum s = (x == TextureWrap.Clamp ? GLEnum.CLAMP_TO_EDGE : GLEnum.REPEAT);
			GLEnum t = (y == TextureWrap.Clamp ? GLEnum.CLAMP_TO_EDGE : GLEnum.REPEAT);

			using (PushTexture(glId, 0))
			{
				GL.TexParameteri((.)GLEnum.TEXTURE_2D, (.)GLEnum.TEXTURE_WRAP_S, (int)s);
				GL.TexParameteri((.)GLEnum.TEXTURE_2D, (.)GLEnum.TEXTURE_WRAP_T, (int)t);
			}
		}

		protected override void Platform_SetData(void* buffer, int x, int y, int w, int h)
		{
			using (PushTexture(glId, 0))
			{
				GL.TexSubImage2D((.)GLEnum.TEXTURE_2D, 0, x, y, w, h, (.)glFormat, (.)glType, buffer);
			}
		}

		protected override void Platform_GetData(void* buffer)
		{
			using (PushTexture(glId, 0))
			{
				GL.GetTexImage((.)GLEnum.TEXTURE_2D, 0, (.)glInternalFormat, (.)glType, buffer);
			}
		}
	}
}