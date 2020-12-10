namespace Atma
{
	using System;
	using System.Collections;

	public extension RenderTexture
	{
		private uint32 _frameBuffer;

		protected override void Platform_Init(TextureFormat[] attachments)
		{
			for (var i < attachments.Count)
			{
				var attachment = new Texture(width, height, attachments[i]);
				attachment.[Friend]_isFrameBuffer = true;
				_attachments.Add(attachment);
			}

			GL.GenFramebuffers(1, &_frameBuffer);
			_id = _frameBuffer;
		}

		protected override void Platform_Resize(int width, int height)
		{
			for (int i = 0; i < _attachments.Count; i++)
				_attachments[i].Resize(width, height);
		}

		//[AlwaysInclude, LinkName("FrameBuffer_Bind")]
		//protected void FrameBuffer_Bind()
		protected override void Platform_Bind()
		{
			GL.BindFramebuffer((.)GLEnum.FRAMEBUFFER, _frameBuffer);

			// color attachments
			int i = 0;
			for (Texture texture in _attachments)
			{
				if (texture.Format.IsTextureColorFormat)
				{
					GL.FramebufferTexture2D((.)GLEnum.FRAMEBUFFER, (.)(GLEnum.COLOR_ATTACHMENT0 + i), (.)GLEnum.TEXTURE_2D, texture.[Friend]glId, 0);
					i++;
				}
				else
				{
					GL.FramebufferTexture2D((.)GLEnum.FRAMEBUFFER, (.)GLEnum.DEPTH_STENCIL_ATTACHMENT, (.)GLEnum.TEXTURE_2D, texture.[Friend]glId, 0);
				}
			}
		}

		protected override void Platform_Destroy()
		{
			GL.DeleteFramebuffers(1, &_frameBuffer);

			_id = _frameBuffer = 0;
		}
	}
}
