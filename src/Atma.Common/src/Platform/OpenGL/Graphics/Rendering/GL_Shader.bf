using System;
using System.Collections;
namespace Atma
{
	public extension Shader
	{
		private uint _vertexHandle;
		private uint _fragmentHandle;
		private uint _programHandle;

		private List<String> _strings;
		private Dictionary<VertexFormat, GL_VertexArray> vertexArrays;

		private void BindVertexArray(VertexFormat format)
		{
			if (vertexArrays.TryAdd(format, ?, var ptr))
				*ptr = new GL_VertexArray(this, format);

			let va = *ptr;
			va.Bind();
		}

		protected override void Platform_Init(ShaderSource def, bool logme)
		{
			var isValid = true;

			_strings = new .();
			vertexArrays = new .();

			int32 logLen = 0;
			char8[1024] log;

			_vertexHandle = GL.CreateShader(GL.GL_VERTEX_SHADER);
			{
				int32 len = (int32)def.Vertex.Length;
				char8* data = def.Vertex.CStr();
				GL.ShaderSource(_vertexHandle, 1, &data, &len);
				GL.CompileShader(_vertexHandle);
				GL.GetShaderInfoLog(_vertexHandle, 1024, &logLen, &log);

				if (logLen > 0)
				{
					Log.Error(scope String(&log[0], logLen));
					Log.Error(def.Vertex);
					isValid = false;
				}
				System.Diagnostics.Debug.Assert(logLen == 0, scope String(&log[0], logLen));
			}

			_fragmentHandle = GL.CreateShader(GL.GL_FRAGMENT_SHADER);
			{
				int32 len = (int32)def.Fragment.Length;
				char8* data = def.Fragment.CStr();
				GL.ShaderSource(_fragmentHandle, 1, &data, &len);
				GL.CompileShader(_fragmentHandle);
				GL.GetShaderInfoLog(_fragmentHandle, 1024, &logLen, &log);

				if (logLen > 0)
				{
					Log.Error(scope String(&log[0], logLen));
					Log.Error(def.Fragment);
					isValid = false;
				}
				System.Diagnostics.Debug.Assert(logLen == 0, scope String(&log[0], logLen));
			}

			_programHandle = GL.CreateProgram();

			GL.AttachShader(_programHandle, _vertexHandle);
			GL.AttachShader(_programHandle, _fragmentHandle);

			using (PushShader(_programHandle))
			{
				GL.LinkProgram(_programHandle);

				GL.GetProgramInfoLog(_programHandle, 1024, &logLen, &log);
				if (logLen > 0)
				{
					Log.Error(scope String(&log[0], logLen));
					isValid = false;
				}
				System.Diagnostics.Debug.Assert(logLen == 0);

				int32 count = ?;
				char8[128] buffer = ?;
				GL.GetProgramiv(_programHandle, GL.GL_ACTIVE_ATTRIBUTES, &count);
				for (var i < count)
				{
					buffer = ?;
					int32 length = ?;
					int32 size = ?;
					uint32 type = ?;
					GL.GetActiveAttrib(_programHandle, (uint)i, buffer.Count, &length, &size, &type, &buffer[0]);

					let location = GL.GetAttribLocation(_programHandle, &buffer[0]);

					let name = new String(&buffer[0], length);
					_strings.Add(name);

					//is there a scenario where this is false?
					if (location >= 0)
						_attributes.Add(.(name, (.)location));
				}

				GL.GetProgramiv(_programHandle, GL.GL_ACTIVE_UNIFORMS, &count);
				for (var i < count)
				{
					buffer = ?;
					int32 length = ?;
					int32 size = ?;
					uint32 type = ?;
					GL.GetActiveUniform(_programHandle, (uint)i, buffer.Count, &length, &size, &type, &buffer[0]);

					let location = GL.GetUniformLocation(_programHandle, &buffer[0]);

					let name = new String(&buffer[0], length);
					_strings.Add(name);

					//is there a scenario where this is false?
					if (location >= 0)
					{
						let index = name.IndexOf("[");
						if (size > 1 && index > -1)
							name.RemoveFromEnd(name.Length - index);

						_uniforms.Add(.(name, (.)location, size, ToFrameworkType((.)type)));
					}
				}

				GL.DeleteShader(_vertexHandle);
				GL.DeleteShader(_fragmentHandle);
			}

			if (logme)
			{
				Log.Debug("Compiled program: {0}, success: {1}", _programHandle, isValid);

				if (Attributes.Count > 0)
				{
					Log.Debug("  Attributes:");
					for (var it in Attributes)
					{
						let attrMsg = scope String();
						it.ToString(attrMsg);
						Log.Debug("    {0}", attrMsg);
					}
				}

				if (Uniforms.Count > 0)
				{
					Log.Debug("  Uniforms:");
					for (var it in Uniforms)
					{
						let uniMsg = scope String();
						it.ToString(uniMsg);
						Log.Debug("    {0}", uniMsg);
					}
				}
			}
		}

		protected override void Platform_Destroy()
		{
			GL.DeleteProgram(_programHandle);
			DeleteContainerAndItems!(_strings);
			DeleteDictionaryAndItems!(vertexArrays);
		}

		private static UniformType ToFrameworkType(GLEnum type)
		{
			switch (type)
			{
			case GLEnum.INT: return UniformType.Int;
			case GLEnum.FLOAT: return UniformType.Float;
			case GLEnum.FLOAT_VEC2: return UniformType.Float2;
			case GLEnum.FLOAT_VEC3: return UniformType.Float3;
			case GLEnum.FLOAT_VEC4: return UniformType.Float4;
			case GLEnum.FLOAT_MAT3x2: return UniformType.Matrix3x2;
			case GLEnum.FLOAT_MAT4: return UniformType.Matrix4x4;
			case GLEnum.SAMPLER_2D: return UniformType.Sampler;
			default:
				Runtime.Assert(false, "Unknown Enum Type");
				return default;
			}
		}

		protected override void Platform_Bind(GraphicsContext context, Material material)
		{
			GL.UseProgram(_programHandle);

			// upload uniform values
			int textureSlot = 0;

			for (int p = 0; p < material.Parameters.Count; p++)
			{
				let parameter = material.Parameters[p];
				let uniform = parameter.Uniform;

				/*if (!(parameter.Uniform is GL_Uniform uniform))
					continue;*/

				// Sampler 2D
				if (uniform.Type == UniformType.Sampler)
				{
					//TODO: FIX ME
					GL.BindSampler(0, 0);// We use combined texture/sampler state. Applications using GL 3.3 may set
					// that

					//Runtime.Assert(false, "Not implemented");
					let n = scope int[uniform.Length];

					let textures = (Texture*)parameter.Ptr;
					for (int i = 0; i < uniform.Length; i++)
					{
						var texture = textures[i];
						var id = texture?.[Friend]glId ?? 0;

						GL.Enable(GL.GL_TEXTURE_2D);
						GL.ActiveTexture((.)(GLEnum.TEXTURE0 + textureSlot));
						GL.BindTexture((.)GLEnum.TEXTURE_2D, id);
						//GL.Uniform1i(textureSlot, 0);

						n[i] = textureSlot;
						textureSlot++;
					}

					GL.Uniform1iv(uniform.Location, uniform.Length, (int32*)&n[0]);
				}
				// Int
				else if (uniform.Type == UniformType.Int)
				{
					GL.Uniform1iv(uniform.Location, uniform.Length, (int32*)parameter.Ptr);
				}
				// Float
				else if (uniform.Type == UniformType.Float)
				{
					GL.Uniform1fv(uniform.Location, uniform.Length, (float*)parameter.Ptr);
				}
				// Float2
				else if (uniform.Type == UniformType.Float2)
				{
					GL.Uniform2fv(uniform.Location, uniform.Length, (float*)parameter.Ptr);
				}
				// Float3
				else if (uniform.Type == UniformType.Float3)
				{
					GL.Uniform3fv(uniform.Location, uniform.Length, (float*)parameter.Ptr);
				}
				// Float4
				else if (uniform.Type == UniformType.Float4)
				{
					GL.Uniform4fv(uniform.Location, uniform.Length, (float*)parameter.Ptr);
				}
				// Matrix3x2
				else if (uniform.Type == UniformType.Matrix3x2)
				{
					//TODO: ShaderParam flag for normalize?
					GL.UniformMatrix3x2fv(uniform.Location, uniform.Length, parameter.Normalize ? 1 : 0, (float*)parameter.Ptr);
				}
				// Matrix4x4
				else if (uniform.Type == UniformType.Matrix4x4)
				{
					//TODO: ShaderParam flag for normalize?
					GL.UniformMatrix4fv(uniform.Location, uniform.Length, parameter.Normalize ? 1 : 0, (float*)parameter.Ptr);
				}
			}
		}
	}
}
