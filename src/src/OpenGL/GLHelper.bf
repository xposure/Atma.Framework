using System;
namespace Atma
{
	public struct PushFrameBuffer : IDisposable
	{
		private int32 _value;
		public this(uint framebuffer)
		{
			_value = default;
			GL.GetIntegerv(GL.GL_FRAMEBUFFER, &_value);
			GL.BindBuffer(GL.GL_FRAMEBUFFER, (.)framebuffer);
		}

		public void Dispose()
		{
			GL.BindBuffer(GL.GL_FRAMEBUFFER, (.)_value);
		}
	}

	public struct PushElementArrayBuffer : IDisposable
	{
		private int32 _value;
		public this(uint arraybuffer)
		{
			_value = default;
			GL.GetIntegerv(GL.GL_ELEMENT_ARRAY_BUFFER, &_value);
			GL.BindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, (.)arraybuffer);
		}

		public void Dispose()
		{
			GL.BindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, (.)_value);
		}
	}

	public struct PushArrayBuffer : IDisposable
	{
		private int32 _value;
		public this(uint arraybuffer)
		{
			_value = default;
			GL.GetIntegerv(GL.GL_ARRAY_BUFFER, &_value);
			GL.BindBuffer(GL.GL_ARRAY_BUFFER, (.)arraybuffer);
		}

		public void Dispose()
		{
			GL.BindBuffer(GL.GL_ARRAY_BUFFER, (.)_value);
		}
	}

	public struct PushVertexArray : IDisposable
	{
		private int32 _value;
		public this(uint vertexArray)
		{
			_value = ?;
			GL.GetIntegerv(GL.GL_VERTEX_ARRAY_BINDING, &_value);
			GL.BindVertexArray((.)vertexArray);
		}

		public void Dispose()
		{
			GL.BindVertexArray((.)_value);
		}
	}

	public struct PushShader : IDisposable
	{
		private int32 _currentShader;
		public this(uint shader)
		{
			_currentShader = default;
			GL.GetIntegerv(GL.GL_CURRENT_PROGRAM, &_currentShader);
			GL.UseProgram(shader);
		}

		public void Dispose()
		{
			GL.UseProgram((.)_currentShader);
		}
	}

	public struct PushTexture : IDisposable
	{
		private int32 last_active_texture;
		private int32 last_texture;
		private int _index;

		public this(uint32 texture, int index)
		{
			this = ?;
			_index = index;
			GL.GetIntegerv(GL.GL_ACTIVE_TEXTURE, &last_active_texture);
			GL.ActiveTexture(GL.GL_TEXTURE0 + (uint)index);

			GL.GetIntegerv(GL.GL_TEXTURE_BINDING_2D, &last_texture);
			GL.BindTexture(GL.GL_TEXTURE_2D, (uint)texture);
		}

		public void Dispose(){
			GL.ActiveTexture(GL.GL_TEXTURE0 + (uint)last_active_texture);
			GL.BindTexture(GL.GL_TEXTURE_2D, (uint)last_texture);
		}
	}



	public static class GLHelper
	{
	}
}
