namespace Atma
{
	using System;
	using System.Threading;
	using System.Collections;

		// Stores info about the Context
	struct ContextMeta
	{
		public RenderTarget LastRenderTarget;
		public RenderPass? LastRenderState;
		public rect Viewport;
		public bool ForceScissorUpdate;
	}

	public extension GraphicsManager
	{
		/*public this(Window window) : base(window)
		{
			//GL.DepthMask(GL.GL_TRUE);

			/*MaxTextureSize = GL.MaxTextureSize;
			OriginBottomLeft = true;
			ApiVersion = new Version(GL.MajorVersion, GL.MinorVersion);
			DeviceName = GL.GetString(GLEnum.RENDERER);*/
		}*/

		// list of Contexts and their associated Metadata
		private readonly Dictionary<GraphicsContext, ContextMeta> contextMetadata = new .() ~ delete _;
		private ContextMeta _contextMeta = .();

		protected override Shader CreateShaderForBatch2D()
		{
			let source = scope ShaderSource(scope String("""
#version 330
uniform mat4 u_matrix;
layout(location=0) in vec3 a_position;
layout(location=1) in vec2 a_tex;
layout(location=2) in vec4 a_color;
layout(location=3) in vec3 a_type;
//out float v_z;
out vec2 v_tex;
out vec4 v_col;
out vec3 v_type;
void main(void)
{
gl_Position = u_matrix * vec4(a_position.xyz, 1);
//gl_Position.z = a_position.z;
//v_z =  gl_Position.z;
v_tex = a_tex;
v_col = a_color;
v_type = a_type;
}
"""), scope String("""
#version 330
uniform sampler2D u_texture;
in float v_z;
in vec2 v_tex;
in vec4 v_col;
in vec3 v_type;
out vec4 o_color;
void main(void)
{
vec4 color = texture(u_texture, v_tex);
o_color = 
	v_type.x * color * v_col + 
	v_type.y * color.a * v_col + 
	v_type.z * v_col;
	//o_color.xyz = vec3(v_z, v_z, v_z);
	if(o_color.w == 0)
		discard;
}
"""));

			return new Shader(source);
		}

		protected override void ClearInternal(RenderTarget target, Clear flags, Color color, float depth, int stencil)
		{
			if (target is Window)
			{
				_context.MakeActive();
				using (PushFrameBuffer(0))
				{
					GL.BindFramebuffer((.)GLEnum.FRAMEBUFFER, 0);
					Clear(this, _context, target, flags, color, depth, stencil);
				}
			}
			else if (let rt = target as RenderTexture)
			{
				using (_context.Lock.Enter())
				{
					_context.MakeActive();
					rt.Bind(_context);
					Clear(this, _context, target, flags, color, depth, stencil);
				}
			}

			void Clear(GraphicsManager graphics, GraphicsContext context, RenderTarget target, Clear flags, Color color, float depth, int stencil)
			{
				let tl = (int2)(_viewport.Min * target.Size);
				let br = (int2)(_viewport.Max * target.Size);
				//let viewport = rect(tl.x, tl.y, br);
				var viewport = rect(tl, br);

				//reseting the state on clear
				_contextMeta = .();

				// update the viewport
				{
					viewport.Y = target.Height - viewport.Min.y - viewport.Height;

					if (_contextMeta.Viewport != viewport)
					{
						GL.Viewport(viewport.X, viewport.Y, viewport.Width, viewport.Height);
						_contextMeta.Viewport = viewport;
					}
				}

				// we disable the scissor for clearing
				_contextMeta.ForceScissorUpdate = true;
				GL.Enable((.)GLEnum.SCISSOR_TEST);
				GL.Scissor(viewport.X, viewport.Y, viewport.Width, viewport.Height);

				// clear
				var mask = GLEnum.ZERO;

				if (flags.HasFlag(.Color))
				{
					GL.ClearColor(color.R / 255f, color.G / 255f, color.B / 255f, color.A / 255f);
					mask |= GLEnum.COLOR_BUFFER_BIT;
				}

				if (flags.HasFlag(.Depth))
				{
					GL.ClearDepth(depth);
					mask |= GLEnum.DEPTH_BUFFER_BIT;
				}

				if (flags.HasFlag(.Stencil))
				{
					GL.ClearStencil(stencil);
					mask |= GLEnum.STENCIL_BUFFER_BIT;
				}

				GL.Clear((.)mask);
				GL.BindFramebuffer((.)GLEnum.FRAMEBUFFER, 0);
			}
		}

		protected override void RenderInternal(RenderPass pass)
		{
			_context.MakeActive();
			Draw(this, pass, _context);

			void Draw(GraphicsManager graphics, RenderPass pass, GraphicsContext context)
			{
				RenderPass lastPass;

				// get the previous state
				var updateAll = false;
				if (_contextMeta.LastRenderState == null)
				{
					updateAll = true;
					lastPass = pass;
				}
				else
					lastPass = _contextMeta.LastRenderState.Value;

				_contextMeta.LastRenderState = pass;

				// Bind the Target
				if (updateAll || _contextMeta.LastRenderTarget != pass.Target)
				{
					if (pass.Target is Window)
					{
						GL.BindFramebuffer((.)GLEnum.FRAMEBUFFER, 0);
					}
					else if (let rt = pass.Target as RenderTexture)
					{
						//let renderTexture = rt.Implementation as GL_FrameBuffer;
						rt.Bind(context);
					}

					_contextMeta.LastRenderTarget = pass.Target;
				}

				// Use the Shader
				pass.Material.Shader.Bind(context, pass.Material);

				// Bind the vertex buffer
				pass.VertexBuffer.Bind(context, pass.Material);

				// Bind the index buffer;
				pass.IndexBuffer.Bind(context, pass.Material);

				// Blend Mode
				{
					GL.Enable((.)GLEnum.BLEND);

					if (updateAll ||
						lastPass.BlendMode.ColorOperation != pass.BlendMode.ColorOperation ||
						lastPass.BlendMode.AlphaOperation != pass.BlendMode.AlphaOperation)
					{
						GLEnum colorOp = GetBlendFunc(pass.BlendMode.ColorOperation);
						GLEnum alphaOp = GetBlendFunc(pass.BlendMode.AlphaOperation);

						GL.BlendEquationSeparate((.)colorOp, (.)alphaOp);
					}

					if (updateAll ||
						lastPass.BlendMode.ColorSource != pass.BlendMode.ColorSource ||
						lastPass.BlendMode.ColorDestination != pass.BlendMode.ColorDestination ||
						lastPass.BlendMode.AlphaSource != pass.BlendMode.AlphaSource ||
						lastPass.BlendMode.AlphaDestination != pass.BlendMode.AlphaDestination)
					{
						GLEnum colorSrc = GetBlendFactor(pass.BlendMode.ColorSource);
						GLEnum colorDst = GetBlendFactor(pass.BlendMode.ColorDestination);
						GLEnum alphaSrc = GetBlendFactor(pass.BlendMode.AlphaSource);
						GLEnum alphaDst = GetBlendFactor(pass.BlendMode.AlphaDestination);

						GL.BlendFuncSeparate((.)colorSrc, (.)colorDst, (.)alphaSrc, (.)alphaDst);
					}

					if (updateAll || lastPass.BlendMode.Mask != pass.BlendMode.Mask)
					{
						GL.ColorMask(
							(.)((pass.BlendMode.Mask & BlendMask.Red) != 0 ? GL.GL_TRUE : GL.GL_FALSE),
							(.)((pass.BlendMode.Mask & BlendMask.Green) != 0 ? GL.GL_TRUE : GL.GL_FALSE),
							(.)((pass.BlendMode.Mask & BlendMask.Blue) != 0 ? GL.GL_TRUE : GL.GL_FALSE),
							(.)((pass.BlendMode.Mask & BlendMask.Alpha) != 0 ? GL.GL_TRUE : GL.GL_FALSE));
					}

					if (updateAll || lastPass.BlendMode.Color != pass.BlendMode.Color)
					{
						GL.BlendColor(
							pass.BlendMode.Color.R / 255f,
							pass.BlendMode.Color.G / 255f,
							pass.BlendMode.Color.B / 255f,
							pass.BlendMode.Color.A / 255f);
					}
				}

				// Depth Function
				if (updateAll || lastPass.DepthFunction != pass.DepthFunction)
				{
					if (pass.DepthFunction == DepthCompare.None)
					{
						GL.Disable((.)GLEnum.DEPTH_TEST);
					}
					else
					{
						GL.Enable((.)GLEnum.DEPTH_TEST);

						switch (pass.DepthFunction)
						{
						case DepthCompare.Always:
							GL.DepthFunc((.)GLEnum.ALWAYS);
							break;
						case DepthCompare.Equal:
							GL.DepthFunc((.)GLEnum.EQUAL);
							break;
						case DepthCompare.Greater:
							GL.DepthFunc((.)GLEnum.GREATER);
							break;
						case DepthCompare.GreaterOrEqual:
							GL.DepthFunc((.)GLEnum.GEQUAL);
							break;
						case DepthCompare.Less:
							GL.DepthFunc((.)GLEnum.LESS);
							break;
						case DepthCompare.LessOrEqual:
							GL.DepthFunc((.)GLEnum.LEQUAL);
							break;
						case DepthCompare.Never:
							GL.DepthFunc((.)GLEnum.NEVER);
							break;
						case DepthCompare.NotEqual:
							GL.DepthFunc((.)GLEnum.NOTEQUAL);
							break;

						default:
							Runtime.Assert(false, "Not implemented");
						}
					}
				}

				// Cull Mode
				if (updateAll || lastPass.CullMode != pass.CullMode)
				{
					if (pass.CullMode == CullMode.None)
					{
						GL.Disable((.)GLEnum.CULL_FACE);
					}
					else
					{
						GL.Enable((.)GLEnum.CULL_FACE);

						if (pass.CullMode == CullMode.Back)
							GL.CullFace((.)GLEnum.BACK);
						else if (pass.CullMode == CullMode.Front)
							GL.CullFace((.)GLEnum.FRONT);
						else
							GL.CullFace((.)GLEnum.FRONT_AND_BACK);
					}
				}

				// Viewport
				{
					/*let tl = int2(0, Screen.Height) - (int2)(_viewport.Min * Screen.Size);
					let br = (int2)(_viewport.Max * Screen.Size);
					let viewport = rect(tl, br);*/
					let tl = (int2)(_viewport.Min * pass.Target.Size);
					let br = (int2)(_viewport.Max * pass.Target.Size);
					//let viewport = rect(tl.x, tl.y, br);
					var viewport = rect(tl, br);
					viewport.Y = pass.Target.Height - viewport.Min.y - viewport.Height;

					if (updateAll || _contextMeta.Viewport != viewport)
					{
						GL.Viewport(viewport.X, viewport.Y, viewport.Width, viewport.Height);
						_contextMeta.Viewport = viewport;
					}
				}

				// Scissor
				{
					var scissor = pass.Scissor ?? .(0, 0, pass.Target.Width, pass.Target.Height);
					scissor.Y = pass.Target.Height - scissor.Y - scissor.Height;
					scissor.Width = Math.Max(0, scissor.Width);
					scissor.Height = Math.Max(0, scissor.Height);

					if (updateAll || lastPass.Scissor != scissor || _contextMeta.ForceScissorUpdate)
					{
						if (pass.Scissor == null)
						{
							GL.Disable((.)GLEnum.SCISSOR_TEST);
						}
						else
						{
							GL.Enable((.)GLEnum.SCISSOR_TEST);
							GL.Scissor(scissor.X, scissor.Y, scissor.Width, scissor.Height);
						}

						_contextMeta.ForceScissorUpdate = false;
						lastPass.Scissor = scissor;
					}
				}

				GLEnum indexType = pass.IndexBuffer.ElementSize == .ThirtyTwoBits ? GLEnum.UNSIGNED_INT : GLEnum.UNSIGNED_SHORT;
				int indexSize = pass.IndexBuffer.ElementSize.Stride;

				// Draw the Mesh
				{
					/*if (pass.MeshInstanceCount > 0)
					{
						GL.DrawElementsInstanced((.)GLEnum.TRIANGLES, (int)(pass.MeshIndexCount), indexType, new
					IntPtr(indexSize * pass.MeshIndexStart), (int)pass.MeshInstanceCount);
					}
					else*/
					{
						GL.DrawElements((.)GLEnum.TRIANGLES, (.)(pass.IndexCount), (.)indexType, (void*)(indexSize * (int)pass.IndexStart));
					}

					GL.BindVertexArray(0);
				}
			}
		}

		private static GLEnum GetBlendFunc(BlendOperations operation)
		{
			switch (operation)
			{
			case .Add: return GLEnum.FUNC_ADD;
			case .Subtract: return GLEnum.FUNC_SUBTRACT;
			case .ReverseSubtract: return GLEnum.FUNC_REVERSE_SUBTRACT;
			case .Min: return GLEnum.MIN;
			case .Max: return GLEnum.MAX;
			default:
				Runtime.Assert(false, "Unsupported Blend Operation");
			}
			return default;
		}

		private static GLEnum GetBlendFactor(BlendFactors factor)
		{
			switch (factor)
			{
			case .Zero: return GLEnum.ZERO;
			case .One: return GLEnum.ONE;
			case .SrcColor: return GLEnum.SRC_COLOR;
			case .OneMinusSrcColor: return GLEnum.ONE_MINUS_SRC_COLOR;
			case .DstColor: return GLEnum.DST_COLOR;
			case .OneMinusDstColor: return GLEnum.ONE_MINUS_DST_COLOR;
			case .SrcAlpha: return GLEnum.SRC_ALPHA;
			case .OneMinusSrcAlpha: return GLEnum.ONE_MINUS_SRC_ALPHA;
			case .DstAlpha: return GLEnum.DST_ALPHA;
			case .OneMinusDstAlpha: return GLEnum.ONE_MINUS_DST_ALPHA;
			case .ConstantColor: return GLEnum.CONSTANT_COLOR;
			case .OneMinusConstantColor: return GLEnum.ONE_MINUS_CONSTANT_COLOR;
			case .ConstantAlpha: return GLEnum.CONSTANT_ALPHA;
			case .OneMinusConstantAlpha: return GLEnum.ONE_MINUS_CONSTANT_ALPHA;
			case .SrcAlphaSaturate: return GLEnum.SRC_ALPHA_SATURATE;
			case .Src1Color: return GLEnum.SRC1_COLOR;
			case .OneMinusSrc1Color: return GLEnum.ONE_MINUS_SRC1_COLOR;
			case .Src1Alpha: return GLEnum.SRC1_ALPHA;
			case .OneMinusSrc1Alpha: return GLEnum.ONE_MINUS_SRC1_ALPHA;
			default:
				Runtime.Assert(false, "Unsupported Blend Factor");
			}
			return default;
		}
	}
}
