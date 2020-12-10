using System;
namespace Atma
{
	class GL_VertexArray
	{
		private readonly uint32 ID;
		private readonly Shader shader;
		private readonly VertexFormat format;

		public ~this()
		{
			var id = ID;
			GL.DeleteVertexArrays(1, &id);
		}

		public this(Shader shader, VertexFormat format)
		{
			this.shader = shader;
			this.format = format;

			GL.GenVertexArrays(1, &ID);
			//Log.Debug("gen vertex array: {0}", ID);
			GL.BindVertexArray(ID);

			//using (PushVertexArray(ID))
			{
				for (var attribute in shader.Attributes)
				{
					if (TrySetupAttribPointer(attribute, format, 0))
						continue;

				// nothing is using this so disable it
					GL.DisableVertexAttribArray((.)attribute.Location);
				}
			}
		}

		bool TrySetupAttribPointer(ShaderAttribute attribute, VertexFormat format, uint divisor)
		{
			if (format.TryGetAttribute(attribute.Name, let element, var ptr))
			{
				// this is kind of messy because some attributes can take up multiple slots
				// ex. a marix4x4 actually takes up 4 (size 16)
				for (int i = 0,uint loc = 0; i < (int)element.Components; i += 4,loc++)
				{
					var components = Math.Min((int)element.Components - i, 4);
					var location = (uint)(attribute.Location + loc);

					GL.EnableVertexAttribArray(location);
					GL.VertexAttribPointer(location, components, (.)ConvertVertexType(element.Type), element.Normalized ? 1 : 0, format.Stride, (.)ptr);

					// //GL.VertexAttribDivisor(location, divisor);

					ptr += components * element.ComponentSize;
				}

				return true;
			}

			return false;
		}

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

		public void Bind()
		{
			GL.BindVertexArray(ID);

			for (var attribute in shader.Attributes)
			{
				if (TrySetupAttribPointer(attribute, format, 0))
					continue;

			// nothing is using this so disable it
				GL.DisableVertexAttribArray((.)attribute.Location);
			}
		}
	}
}
