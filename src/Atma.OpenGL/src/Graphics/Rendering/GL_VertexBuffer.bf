namespace Atma
{
	using System;
	using System.Collections;

	public extension VertexBuffer
	{
		protected override void Platform_SetData(void* vertices, int count)
		{
			using (PushArrayBuffer(_vertexBuffer))
			{
				GL.BufferSubData(GL.GL_ARRAY_BUFFER, 0, Format.Stride * count, vertices);
			}
		}

		protected override void Platform_Bind(GraphicsContext context, Material material)
		{
			GL.BindBuffer(GL.GL_ARRAY_BUFFER, _vertexBuffer);
			material.Shader.[Friend]BindVertexArray(Format);
		}

		protected override void Platform_Resize(uint elements)
		{
			Platform_Destroy();
			Platform_Init();
		}

		protected override void Platform_Init()
		{
			GL.GenBuffers(1, &_vertexBuffer);
			_id = _vertexBuffer;

			using (PushArrayBuffer(_vertexBuffer))
			{
				GL.BufferData((.)GL.GL_ARRAY_BUFFER, (.)BufferSize, null, (.)GL.GL_DYNAMIC_DRAW);
			}
		}

		protected override void Platform_Destroy()
		{
			GL.DeleteBuffers(1, &_vertexBuffer);
			_id = _vertexBuffer = 0;
		}

		private uint32 _vertexBuffer;

		private static GLEnum ConvertVertexType(VertexType value)
		{
			switch (value)
			{
			case VertexType.Byte: return GLEnum.UNSIGNED_BYTE;
			case VertexType.Short: return GLEnum.SHORT;
			case VertexType.Int: return GLEnum.INT;
			case VertexType.Float: return GLEnum.FLOAT;
			default:
				Runtime.Assert(false, "Not implemented");
			}

			return default;
		}
	}
}
