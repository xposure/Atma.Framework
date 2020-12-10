namespace Atma
{
	using System;

	public extension IndexBuffer
	{
		private uint32 _indexBuffer;

		protected override void Platform_SetData(void* indices, int count)
		{
			using (PushElementArrayBuffer(_indexBuffer))
			{
				GL.BufferSubData(GL.GL_ELEMENT_ARRAY_BUFFER, 0, ElementSize.Stride * count, indices);
			}
		}

		protected override void Platform_Bind(GraphicsContext context, Material material)
		{
			GL.BindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, _indexBuffer);
		}

		protected override void Platform_Resize(uint elements)
		{
			Platform_Destroy();
			Platform_Init();
		}

		protected override void Platform_Init()
		{
			GL.GenBuffers(1, &_indexBuffer);
			_id = _indexBuffer;

			using (PushElementArrayBuffer(_indexBuffer))
			{
				GL.BufferData(GL.GL_ELEMENT_ARRAY_BUFFER, (.)BufferSize, null, (.)GL.GL_DYNAMIC_DRAW);
			}
		}

		protected override void Platform_Destroy()
		{
			GL.DeleteBuffers(1, &_indexBuffer);
			_id = _indexBuffer = 0;
		}

	}
}
