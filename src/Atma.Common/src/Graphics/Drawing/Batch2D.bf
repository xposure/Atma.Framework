using System;
using System.Collections;
using System.Diagnostics;

namespace Atma
{
	[Ordered, Packed]
	public struct DrawMode
	{
		public uint8 Multi;
		public uint8 Wash;
		public uint8 Fill;

		public this(uint8 fill, uint8 multi, uint8 wash)
		{
			Fill = fill;
			Multi = multi;
			Wash = wash;
		}

		public readonly static DrawMode Washed = .(0, 0, 255);
		public readonly static DrawMode Multiplied = .(0, 255, 0);
		public readonly static DrawMode Filled = .(255, 0, 0);

		public void ToString(String buffer)
		{
			buffer.AppendF("Fill: {0}, Multi: {1}, Wash: {2}", Fill, Multi, Wash);
		}
	}

	public struct DrawArgs
	{
		public Subtexture texture;
		public float2 position;
		public float2 scale;
		public float2 offset;
		public float rotation;
		public Color tint;
		public float2 skew;
		public DrawMode mode;

		public this(Subtexture texture, float2 position, float2 scale = .Ones, float2 offset = .Zero, float rotation = 0, Color tint = .White, float2 skew = .Zero, DrawMode mode = .Multiplied)
		{
			this.texture = texture;
			this.position = position;
			this.scale = scale;
			this.offset = offset;
			this.rotation = rotation * Math.PI_f * 2;
			this.tint = tint;
			this.skew = skew;
			this.mode = mode;
		}
	}

	/// <summary>
	/// A 2D Sprite Batcher used for drawing images, text, and shapes
	/// </summary>
	public class Batch2D
	{
		public static readonly VertexFormat VertexFormat = new VertexFormat(
			.("a_position", VertexAttrib.Position, VertexType.Float, VertexComponents.Three, false),
			.("a_tex", VertexAttrib.TexCoord0, VertexType.Float, VertexComponents.Two, false),
			.("a_color", VertexAttrib.Color0, VertexType.Byte, VertexComponents.Four, true),
			.("a_type", VertexAttrib.TexCoord1, VertexType.Byte, VertexComponents.Three, true)) ~ delete _;

		[Ordered, Packed]
		public struct Vertex
		{
			public float2 Pos;
			public float Z;
			public float2 Tex;
			public Color Col;
			public DrawMode Fill;
			/*public uint8 Mult;
			public uint8 Wash;
			public uint8 Fill;*/

			public this(float2 position, float z, float2 texcoord, Color color, DrawMode fillStyle)
			{
				Pos = position;
				Z = z;
				Tex = texcoord;
				Col = color;
				Fill = fillStyle;
				/*Mult = (uint8)mult;
				Wash = (uint8)wash;
				Fill = (uint8)fill;*/
			}

			//public VertexFormat Format => VertexFormat;

			public void ToString(String buffer)
			{
				buffer.AppendF("Pos:{0}, Tex:{1}, Col:{2}, Fill: {{ {3} }}", Pos, Tex, Col, Fill);
			}
		}

		/*public struct Quad
		{
			private Vertex* _data;

			public this(Vertex* data)
			{
				_data = data;
			}

			public ref Vertex this[int index]
			{
				get => ref _data[index];
			}

			public ref Quad Washed(bool washed) mut
			{
				for (var i < 4)
				{
					_data[i].Fill = 0;
					_data[i].Mult = washed ? 0 : 255;
					_data[i].Wash = washed ? 255 : 0;
				}

				return ref this;
			}
		}*/

		private static Shader defaultBatchShader ~ delete _;

		public readonly GraphicsManager Graphics;
		public readonly Shader DefaultShader;// ~ delete _;
		public readonly Material DefaultMaterial ~ delete _;
		public readonly DynamicMesh<Vertex> Mesh ~ delete _;
		public readonly Texture DefaultTexture ~ delete _;

		//public float3x2 MatrixStack = float3x2.Identity;
		public rect? Scissor => currentBatch.Scissor;

		public String TextureUniformName = "u_texture";
		public String MatrixUniformName = "u_matrix";

		//private readonly List<float3x2> matrixStack = new .() ~ delete _;
		private RenderPass pass;
		private readonly List<Batch> batches ~ delete _;
		private Batch currentBatch;
		private int currentBatchInsert;
		private bool dirty;

		public int TriangleCount => Mesh.IndexCount / 3;
		public int VertexCount => Mesh.VertexCount;
		public int IndexCount => Mesh.IndexCount;
		public int BatchCount => batches.Count + (currentBatch.Elements > 0 ? 1 : 0);

		public float _depth = 0f;
		private List<float> _depthStack = new .() ~ delete _;

		private struct Batch
		{
			public int Layer;
			public Material Material;
			public BlendMode BlendMode;
			public DepthCompare DepthCompare;
			//public float3x2 Matrix;
			public Texture Texture;
			public rect? Scissor;
			public uint Offset;
			public uint Elements;

			public this(Material material, BlendMode blend, DepthCompare depth, Texture texture, uint offset, uint elements)
			{
				Layer = 0;
				Material = material;
				BlendMode = blend;
				DepthCompare = depth;
				Texture = texture;
				//Matrix = matrix;
				Scissor = null;
				Offset = offset;
				Elements = elements;
			}
		}

		public this() : this(GraphicsManager.Current) { }
		public this(GraphicsManager graphics)
		{
			Graphics = graphics;

			if (defaultBatchShader == null)
			{
				defaultBatchShader = graphics.[Friend]CreateShaderForBatch2D();
			}

			DefaultShader = defaultBatchShader;
			DefaultMaterial = new Material(DefaultShader);

			Mesh = new .(graphics, VertexFormat);

			batches = new List<Batch>();

			DefaultTexture = new .(1, 1);
			DefaultTexture.SetData(scope Color[](Color.White));

			Clear();
		}

		private void Clear()
		{
			currentBatchInsert = 0;
			currentBatch = .(null, BlendMode.Normal, DepthCompare.None, null, 0, 0);
			batches.Clear();
			Mesh.Clear();
		}

		#region Rendering
		public void Render(RenderTarget target) => Render(target, target.Matrix);

		public void Render(RenderTarget target, float4 matrix)
		{
			//var matrix = float4x4.Ortho(0, target.RenderWidth, target.RenderHeight, 0, 0, 20);
			Render(target, matrix);
		}

		public void Render(RenderTarget target, Color clearColor, float4 matrix)
		{
			Graphics.Clear(target, clearColor);
			Render(target, matrix);
		}

		public void Render(RenderTarget target, float4x4 matrix, Color? clearColor = null)
		{
			if (clearColor != null)
				Graphics.Clear(target, clearColor.Value);

			if (dirty)
			{
				Mesh.Commit();
				Mesh.Clear();

				/*Mesh.SetVertices(new ReadOnlyMemory<Vertex>(vertices, 0, vertexCount));
				Mesh.SetIndices(new ReadOnlyMemory<int>(indices, 0, indexCount));*/

				dirty = false;
			}


			pass = .(target, Mesh.[Friend]_vertexBuffer, Mesh.[Friend]_indexBuffer, 0, 0, DefaultMaterial);

			//Debug.Assert(matrixStack.Count <= 0, "Batch.MatrixStack Pushes more than it Pops");

			if (batches.Count > 0 || currentBatch.Elements > 0)
			{
				// render batches
				for (int i = 0; i < batches.Count; i++)
				{
					// remaining elements in the current batch
					if (currentBatchInsert == i && currentBatch.Elements > 0)
						RenderBatch(currentBatch, matrix);

					// render the batch
					RenderBatch(batches[i], matrix);
				}

				// remaining elements in the current batch
				if (currentBatchInsert == batches.Count && currentBatch.Elements > 0)
					RenderBatch(currentBatch, matrix);
			}

			Clear();
		}

		private void RenderBatch(Batch batch, float4x4 matrix)
		{
			pass.Scissor = batch.Scissor;
			pass.BlendMode = batch.BlendMode;
			pass.DepthFunction = batch.DepthCompare;
			pass.CullMode = .None;
			// Render the Mesh
			// Note we apply the texture and matrix based on the current batch
			// If the user set these on the Material themselves, they will be overwritten here

			pass.Material = batch.Material ?? DefaultMaterial;
			pass.Material[TextureUniformName]?.Set(batch.Texture);
			pass.Material[MatrixUniformName]?.Set(matrix);

			pass.IndexStart = batch.Offset * 3;
			pass.IndexCount = batch.Elements * 3;
			//pass.MeshInstanceCount = 0;

			Graphics.Render(pass);
		}

		#endregion

		#region Modify State

		public float Depth => _depth;

		public void PushDepth(float depth)
		{
			_depthStack.Add(_depth);
			_depth = depth;
		}

		public void AddDepth(float depth)
		{
			_depthStack.Add(_depth);
			_depth += depth;
		}

		public void PopDepth()
		{
			_depth = _depthStack.PopBack();
		}

		public void SetMaterial(Material material)
		{
			if (currentBatch.Elements == 0)
			{
				currentBatch.Material = material;
			}
			else if (currentBatch.Material != material)
			{
				batches.Insert(currentBatchInsert, currentBatch);

				currentBatch.Material = material;
				currentBatch.Offset += currentBatch.Elements;
				currentBatch.Elements = 0;
				currentBatchInsert++;
			}
		}

		public void SetBlendMode(BlendMode blendmode)
		{
			if (currentBatch.Elements == 0)
			{
				currentBatch.BlendMode = blendmode;
			}
			else if (currentBatch.BlendMode != blendmode)
			{
				batches.Insert(currentBatchInsert, currentBatch);

				currentBatch.BlendMode = blendmode;
				currentBatch.Offset += currentBatch.Elements;
				currentBatch.Elements = 0;
				currentBatchInsert++;
			}
		}

		public BlendMode GetBlendMode()
		{
			return currentBatch.BlendMode;
		}

		public void SetDepthCompare(DepthCompare depth)
		{
			if (currentBatch.Elements == 0)
			{
				currentBatch.DepthCompare = depth;
			}
			else if (currentBatch.DepthCompare != depth)
			{
				batches.Insert(currentBatchInsert, currentBatch);

				currentBatch.DepthCompare = depth;
				currentBatch.Offset += currentBatch.Elements;
				currentBatch.Elements = 0;
				currentBatchInsert++;
			}
		}

		public DepthCompare GetDepthCompare()
		{
			return currentBatch.DepthCompare;
		}

		public void SetScissor(rect? scissor)
		{
			if (currentBatch.Elements == 0)
			{
				currentBatch.Scissor = scissor;
			}
			else if (currentBatch.Scissor != scissor)
			{
				batches.Insert(currentBatchInsert, currentBatch);

				currentBatch.Scissor = scissor;
				currentBatch.Offset += currentBatch.Elements;
				currentBatch.Elements = 0;
				currentBatchInsert++;
			}
		}

		public void SetTexture(Texture texture)
		{
			if (currentBatch.Texture == null || currentBatch.Elements == 0)
			{
				currentBatch.Texture = texture;
			}
			else if (currentBatch.Texture != texture)
			{
				batches.Insert(currentBatchInsert, currentBatch);

				currentBatch.Texture = texture;
				currentBatch.Offset += currentBatch.Elements;
				currentBatch.Elements = 0;
				currentBatchInsert++;
			}
		}

		public void SetLayer(int layer)
		{
			if (currentBatch.Layer == layer)
				return;

			// insert last batch
			if (currentBatch.Elements > 0)
			{
				batches.Insert(currentBatchInsert, currentBatch);
				currentBatch.Offset += currentBatch.Elements;
				currentBatch.Elements = 0;
			}

			// find the point to insert us
			var insert = 0;
			while (insert < batches.Count && batches[insert].Layer >= layer)
				insert++;

			currentBatch.Layer = layer;
			currentBatchInsert = insert;
		}

		public void SetState(Material material, BlendMode blendmode, DepthCompare depth, rect? scissor)
		{
			SetMaterial(material);
			SetBlendMode(blendmode);
			SetDepthCompare(depth);
			SetScissor(scissor);
		}

		#endregion

		#region Line

		public void Line(float2 from, float2 to, float thickness, Color color)
		{
			var normal = (to - from).Normalized;
			var perp = float2(-normal.y, normal.x) * thickness * 0.5f;
			Quad(from + perp, from - perp, to - perp, to + perp, color);
		}

		#endregion

		#region Quad

		/*public void Quad(Quad2D quad, Color color)
		{
			Quad(quad.A, quad.B, quad.C, quad.D, color);
		}*/

		/*public Quad Quad(Texture texture)
		{
			SetTexture(texture);
			let vertices = PushQuad();
			return .(vertices.Ptr);
		}*/

		[Inline]
		public void Quad(float2 v0, float2 v1, float2 v2, float2 v3, Color color)
		{
			let vertices = PushQuad();

			vertices[0] = Vertex(v0, _depth, float2.Zero, color, .Filled);
			vertices[1] = Vertex(v1, _depth, float2.Zero, color, .Filled);
			vertices[2] = Vertex(v2, _depth, float2.Zero, color, .Filled);
			vertices[3] = Vertex(v3, _depth, float2.Zero, color, .Filled);

			// POS
			/*Transform(ref vertices[0].Pos, v0, MatrixStack);
			Transform(ref vertices[1].Pos, v1, MatrixStack);
			Transform(ref vertices[2].Pos, v2, MatrixStack);
			Transform(ref vertices[3].Pos, v3, MatrixStack);*/

			/*// COL
			vertices[0].Col = color;
			vertices[1].Col = color;
			vertices[2].Col = color;
			vertices[3].Col = color;

			// MULT
			vertices[0].Mult = 0;
			vertices[1].Mult = 0;
			vertices[2].Mult = 0;
			vertices[3].Mult = 0;

			// WASH
			vertices[0].Wash = 0;
			vertices[1].Wash = 0;
			vertices[2].Wash = 0;
			vertices[3].Wash = 0;

			// FILL
			vertices[0].Fill = 255;
			vertices[1].Fill = 255;
			vertices[2].Fill = 255;
			vertices[3].Fill = 255;*/
		}

		[Inline]
		public void Quad(float2 v0, float2 v1, float2 v2, float2 v3, float2 t0, float2 t1, float2 t2, float2 t3, Color color, bool washed = false, float z = 0)
		{
			let vertices = PushQuad();

			let style = washed ? DrawMode.Washed : DrawMode.Multiplied;

			/*var vert = Vertex(float2.Zero, _depth, float2.Zero, color, mult, wash, 0);*/

			vertices[0] = Vertex(v0, z, t0, color, style);
			vertices[1] = Vertex(v1, z, t1, color, style);
			vertices[2] = Vertex(v2, z, t2, color, style);
			vertices[3] = Vertex(v3, z, t3, color, style);

			/*// POS
			Transform(ref vertices[0].Pos, v0, MatrixStack);
			Transform(ref vertices[1].Pos, v1, MatrixStack);
			Transform(ref vertices[2].Pos, v2, MatrixStack);
			Transform(ref vertices[3].Pos, v3, MatrixStack);*/

			/*// TEX
			vertices[vertexCount + 0].Tex = t0;
			vertices[vertexCount + 1].Tex = t1;
			vertices[vertexCount + 2].Tex = t2;
			vertices[vertexCount + 3].Tex = t3;

			if (Graphics.OriginBottomLeft && (currentBatch.Texture?.IsFrameBuffer ?? false))
				VerticalFlip(ref vertices[vertexCount + 0].Tex, ref vertices[vertexCount + 1].Tex, ref
		vertices[vertexCount + 2].Tex, ref vertices[vertexCount + 3].Tex);

			// COL
			vertices[vertexCount + 0].Col = color;
			vertices[vertexCount + 1].Col = color;
			vertices[vertexCount + 2].Col = color;
			vertices[vertexCount + 3].Col = color;

			// MULT
			vertices[vertexCount + 0].Mult = mult;
			vertices[vertexCount + 1].Mult = mult;
			vertices[vertexCount + 2].Mult = mult;
			vertices[vertexCount + 3].Mult = mult;

			// WASH
			vertices[vertexCount + 0].Wash = wash;
			vertices[vertexCount + 1].Wash = wash;
			vertices[vertexCount + 2].Wash = wash;
			vertices[vertexCount + 3].Wash = wash;

			// FILL
			vertices[vertexCount + 0].Fill = 0;
			vertices[vertexCount + 1].Fill = 0;
			vertices[vertexCount + 2].Fill = 0;
			vertices[vertexCount + 3].Fill = 0;*/
		}

		[Inline]
		public void Quad(float2 v0, float2 v1, float2 v2, float2 v3, Color c0, Color c1, Color c2, Color c3)
		{
			let vertices = PushQuad();

			//var vert = Vertex(float2.Zero, _depth, float2.Zero, Color.White, 0, 0, 255);

			vertices[0] = Vertex(v0, _depth, float2.Zero, c0, .Filled);
			vertices[1] = Vertex(v1, _depth, float2.Zero, c1, .Filled);
			vertices[2] = Vertex(v2, _depth, float2.Zero, c2, .Filled);
			vertices[3] = Vertex(v3, _depth, float2.Zero, c3, .Filled);

			/*vert.Col = c0;
			vertices[0] = vert;

			vert.Col = c1;
			vertices[1] = vert;

			vert.Col = c2;
			vertices[2] = vert;

			vert.Col = c3;
			vertices[3] = vert;*/

			/*// POS
			Transform(ref vertices[0].Pos, v0, MatrixStack);
			Transform(ref vertices[1].Pos, v1, MatrixStack);
			Transform(ref vertices[2].Pos, v2, MatrixStack);
			Transform(ref vertices[3].Pos, v3, MatrixStack);*/

			/*// COL
			vertices[vertexCount + 0].Col = c0;
			vertices[vertexCount + 1].Col = c1;
			vertices[vertexCount + 2].Col = c2;
			vertices[vertexCount + 3].Col = c3;

			// MULT
			vertices[vertexCount + 0].Mult = 0;
			vertices[vertexCount + 1].Mult = 0;
			vertices[vertexCount + 2].Mult = 0;
			vertices[vertexCount + 3].Mult = 0;

			// WASH
			vertices[vertexCount + 0].Wash = 0;
			vertices[vertexCount + 1].Wash = 0;
			vertices[vertexCount + 2].Wash = 0;
			vertices[vertexCount + 3].Wash = 0;

			// FILL
			vertices[vertexCount + 0].Fill = 255;
			vertices[vertexCount + 1].Fill = 255;
			vertices[vertexCount + 2].Fill = 255;
			vertices[vertexCount + 3].Fill = 255;

			vertexCount += 4;*/
		}

		[Inline]
		public void Quad(float2 v0, float2 v1, float2 v2, float2 v3, float2 t0, float2 t1, float2 t2, float2 t3, Color c0, Color c1, Color c2, Color c3, bool washed = false)
		{
			let vertices = PushQuad();

			let style = washed ? DrawMode.Washed : DrawMode.Multiplied;

			vertices[0] = Vertex(v0, _depth, t0, c0, style);
			vertices[1] = Vertex(v1, _depth, t1, c1, style);
			vertices[2] = Vertex(v2, _depth, t2, c2, style);
			vertices[3] = Vertex(v3, _depth, t3, c3, style);

			/*// POS
			Transform(ref vertices[0].Pos, v0, MatrixStack);
			Transform(ref vertices[1].Pos, v1, MatrixStack);
			Transform(ref vertices[2].Pos, v2, MatrixStack);
			Transform(ref vertices[3].Pos, v3, MatrixStack);*/

			/*// TEX
			vertices[vertexCount + 0].Tex = t0;
			vertices[vertexCount + 1].Tex = t1;
			vertices[vertexCount + 2].Tex = t2;
			vertices[vertexCount + 3].Tex = t3;

			if (Graphics.OriginBottomLeft && (currentBatch.Texture?.IsFrameBuffer ?? false))
				VerticalFlip(ref vertices[vertexCount + 0].Tex, ref vertices[vertexCount + 1].Tex, ref
		vertices[vertexCount + 2].Tex, ref vertices[vertexCount + 3].Tex);

			// COL
			vertices[vertexCount + 0].Col = c0;
			vertices[vertexCount + 1].Col = c1;
			vertices[vertexCount + 2].Col = c2;
			vertices[vertexCount + 3].Col = c3;

			// MULT
			vertices[vertexCount + 0].Mult = mult;
			vertices[vertexCount + 1].Mult = mult;
			vertices[vertexCount + 2].Mult = mult;
			vertices[vertexCount + 3].Mult = mult;

			// WASH
			vertices[vertexCount + 0].Wash = wash;
			vertices[vertexCount + 1].Wash = wash;
			vertices[vertexCount + 2].Wash = wash;
			vertices[vertexCount + 3].Wash = wash;

			// FILL
			vertices[vertexCount + 0].Fill = 0;
			vertices[vertexCount + 1].Fill = 0;
			vertices[vertexCount + 2].Fill = 0;
			vertices[vertexCount + 3].Fill = 0;

			vertexCount += 4;*/
		}

		#endregion

		#region Triangle

		[Inline]
		public void Triangle(float2 v0, float2 v1, float2 v2, Color color)
		{
			let vertices = PushTriangle();

			vertices[0] = Vertex(v0, _depth, float2.Zero, color, .Filled);
			vertices[1] = Vertex(v1, _depth, float2.Zero, color, .Filled);
			vertices[2] = Vertex(v2, _depth, float2.Zero, color, .Filled);


			// POS
			/*Transform(ref vertices[0].Pos, v0, MatrixStack);
			Transform(ref vertices[1].Pos, v1, MatrixStack);
			Transform(ref vertices[2].Pos, v2, MatrixStack);*/

			/*// COL
			vertices[vertexCount + 0].Col = color;
			vertices[vertexCount + 1].Col = color;
			vertices[vertexCount + 2].Col = color;

			// MULT
			vertices[vertexCount + 0].Mult = 0;
			vertices[vertexCount + 1].Mult = 0;
			vertices[vertexCount + 2].Mult = 0;
			vertices[vertexCount + 3].Mult = 0;

			// WASH
			vertices[vertexCount + 0].Wash = 0;
			vertices[vertexCount + 1].Wash = 0;
			vertices[vertexCount + 2].Wash = 0;
			vertices[vertexCount + 3].Wash = 0;

			// FILL
			vertices[vertexCount + 0].Fill = 255;
			vertices[vertexCount + 1].Fill = 255;
			vertices[vertexCount + 2].Fill = 255;
			vertices[vertexCount + 3].Fill = 255;

			vertexCount += 3;*/
		}

		[Inline]
		public void Triangle(float2 v0, float2 v1, float2 v2, Color c0, Color c1, Color c2)
		{
			let vertices = PushTriangle();

			/*vertices[0] = Vertex(float2.Zero, _depth, float2.Zero, c0, 0, 0, 255);
			vertices[1] = Vertex(float2.Zero, _depth, float2.Zero, c1, 0, 0, 255);
			vertices[2] = Vertex(float2.Zero, _depth, float2.Zero, c2, 0, 0, 255);*/

			vertices[0] = Vertex(v0, _depth, float2.Zero, c0, .Filled);
			vertices[1] = Vertex(v1, _depth, float2.Zero, c1, .Filled);
			vertices[2] = Vertex(v2, _depth, float2.Zero, c2, .Filled);


			/*// POS
			Transform(ref vertices[0].Pos, v0, MatrixStack);
			Transform(ref vertices[1].Pos, v1, MatrixStack);
			Transform(ref vertices[2].Pos, v2, MatrixStack);*/

						/*// COL
			vertices[vertexCount + 0].Col = c0;
			vertices[vertexCount + 1].Col = c1;
			vertices[vertexCount + 2].Col = c2;

						// MULT
			vertices[vertexCount + 0].Mult = 0;
			vertices[vertexCount + 1].Mult = 0;
			vertices[vertexCount + 2].Mult = 0;
			vertices[vertexCount + 3].Mult = 0;

						// WASH
			vertices[vertexCount + 0].Wash = 0;
			vertices[vertexCount + 1].Wash = 0;
			vertices[vertexCount + 2].Wash = 0;
			vertices[vertexCount + 3].Wash = 0;

						// FILL
			vertices[vertexCount + 0].Fill = 255;
			vertices[vertexCount + 1].Fill = 255;
			vertices[vertexCount + 2].Fill = 255;
			vertices[vertexCount + 3].Fill = 255;

			vertexCount += 3;*/
		}

		[Inline]
		public void Triangle(float2 v0, float2 v1, float2 v2, float2 t0, float2 t1, float2 t2, Color c0, Color c1, Color c2)
		{
			let vertices = PushTriangle();

			/*vertices[0] = Vertex(float2.Zero, _depth, float2.Zero, c0, 0, 0, 255);
			vertices[1] = Vertex(float2.Zero, _depth, float2.Zero, c1, 0, 0, 255);
			vertices[2] = Vertex(float2.Zero, _depth, float2.Zero, c2, 0, 0, 255);*/

			vertices[0] = Vertex(v0, _depth, t0, c0, .Multiplied);
			vertices[1] = Vertex(v1, _depth, t1, c1, .Multiplied);
			vertices[2] = Vertex(v2, _depth, t2, c2, .Multiplied);

			/*// POS
			Transform(ref vertices[0].Pos, v0, MatrixStack);
			Transform(ref vertices[1].Pos, v1, MatrixStack);
			Transform(ref vertices[2].Pos, v2, MatrixStack);*/

						/*// COL
			vertices[vertexCount + 0].Col = c0;
			vertices[vertexCount + 1].Col = c1;
			vertices[vertexCount + 2].Col = c2;

						// MULT
			vertices[vertexCount + 0].Mult = 0;
			vertices[vertexCount + 1].Mult = 0;
			vertices[vertexCount + 2].Mult = 0;
			vertices[vertexCount + 3].Mult = 0;

						// WASH
			vertices[vertexCount + 0].Wash = 0;
			vertices[vertexCount + 1].Wash = 0;
			vertices[vertexCount + 2].Wash = 0;
			vertices[vertexCount + 3].Wash = 0;

						// FILL
			vertices[vertexCount + 0].Fill = 255;
			vertices[vertexCount + 1].Fill = 255;
			vertices[vertexCount + 2].Fill = 255;
			vertices[vertexCount + 3].Fill = 255;

			vertexCount += 3;*/
		}


		#endregion

		#region Pixel
		public void Pixel(float2 position, Color color, float t = 1f)
		{
			Rect(aabb2.FromDimensions(position, .Ones * Math.Max(t, 1)), color);
		}
		#endregion Pixel

		#region Rect
		public void TriRect(aabb2 aabb, Color[4] c)
		{
			let p = float2[](aabb.TopLeft,
				aabb.TopRight,
				aabb.BottomRight,
				aabb.BottomLeft);

			let pc = float2((p[0].x + p[2].x) / 2, (p[0].y + p[2].y) / 2);

			let b0 = Color.Lerp(c[0], c[1], 0.5f);
			let b1 = Color.Lerp(c[2], c[3], 0.5f);
			let cc = Color.Lerp(b0, b1, 0.5f);

			for (var i < 4)
				Triangle(p[i], p[(i + 1) % 4], pc, c[i], c[(i + 1) % 4], cc);
		}

		public void Rect(aabb2 rect, Color color)
		{
			Quad(
				float2(rect.x0, rect.y0),
				float2(rect.x1, rect.y0),
				float2(rect.x1, rect.y1),
				float2(rect.x0, rect.y1),
				color);
		}

		public void Rect(rect rect, Color color)
		{
			Quad(
				float2(rect.X, rect.Y),
				float2(rect.X + rect.Width, rect.Y),
				float2(rect.X + rect.Width, rect.Y + rect.Height),
				float2(rect.X, rect.Y + rect.Height),
				color);
		}

		public void Rect(float2 position, float2 size, Color color)
		{
			Quad(
				position,
				position + float2(size.x, 0),
				position + float2(size.x, size.y),
				position + float2(0, size.y),
				color);
		}

		public void Rect(float x, float y, float width, float height, Color color)
		{
			Quad(
				float2(x, y),
				float2(x + width, y),
				float2(x + width, y + height),
				float2(x, y + height), color);
		}

		public void Rect(rect rect, Color c0, Color c1, Color c2, Color c3)
		{
			Quad(
				float2(rect.X, rect.Y),
				float2(rect.X + rect.Width, rect.Y),
				float2(rect.X + rect.Width, rect.Y + rect.Height),
				float2(rect.X, rect.Y + rect.Height),
				c0, c1, c2, c3);
		}

		public void Rect(float2 position, float2 size, Color c0, Color c1, Color c2, Color c3)
		{
			Quad(
				position,
				position + float2(size.x, 0),
				position + float2(size.x, size.y),
				position + float2(0, size.y),
				c0, c1, c2, c3);
		}

		public void Rect(float x, float y, float width, float height, Color c0, Color c1, Color c2, Color c3)
		{
			Quad(
				float2(x, y),
				float2(x + width, y),
				float2(x + width, y + height),
				float2(x, y + height),
				c0, c1, c2, c3);
		}

		#endregion

		#region Rounded Rect

		/*public void RoundedRect(float x, float y, float width, float height, float r0, float r1, float r2, float r3,
		Color color)
		{
			RoundedRect(rect((.)x, (.)y, (.)width, (.)height), r0, r1, r2, r3, color);
		}

		public void RoundedRect(float x, float y, float width, float height, float radius, Color color)
		{
			RoundedRect(rect((.)x, (.)y, (.)width, (.)height), radius, radius, radius, radius, color);
		}

		public void RoundedRect(rect rect, float radius, Color color)
		{
			RoundedRect(rect, radius, radius, radius, radius, color);
		}

		public void RoundedRect(rect rect, float r0, float r1, float r2, float r3, Color color)
		{
			// clamp
			var r0, r1, r2, r3;
			r0 = Math.Min(Math.Min(Math.Max(0, r0), rect.Width / 2f), rect.Height / 2f);
			r1 = Math.Min(Math.Min(Math.Max(0, r1), rect.Width / 2f), rect.Height / 2f);
			r2 = Math.Min(Math.Min(Math.Max(0, r2), rect.Width / 2f), rect.Height / 2f);
			r3 = Math.Min(Math.Min(Math.Max(0, r3), rect.Width / 2f), rect.Height / 2f);

			if (r0 <= 0 && r1 <= 0 && r2 <= 0 && r3 <= 0)
			{
				Rect(rect, color);
			}
			else
			{
				// get corners
				var r0_tl = rect.TopLeft;
				var r0_tr = r0_tl + float2(r0, 0);
				var r0_br = r0_tl + float2(r0, r0);
				var r0_bl = r0_tl + float2(0, r0);

				var r1_tl = rect.TopRight + float2(-r1, 0);
				var r1_tr = r1_tl + float2(r1, 0);
				var r1_br = r1_tl + float2(r1, r1);
				var r1_bl = r1_tl + float2(0, r1);

				var r2_tl = rect.BottomRight + float2(-r2, -r2);
				var r2_tr = r2_tl + float2(r2, 0);
				var r2_bl = r2_tl + float2(0, r2);
				var r2_br = r2_tl + float2(r2, r2);

				var r3_tl = rect.BottomLeft + float2(0, -r3);
				var r3_tr = r3_tl + float2(r3, 0);
				var r3_bl = r3_tl + float2(0, r3);
				var r3_br = r3_tl + float2(r3, r3);

				// set tris
				{
					while (indexCount + 30 >= indices.Length)
						Array.Resize(ref indices, indices.Length * 2);

					// top quad
					{
						indices[indexCount + 00] = vertexCount + 00;// r0b
						indices[indexCount + 01] = vertexCount + 03;// r1a
						indices[indexCount + 02] = vertexCount + 05;// r1d

						indices[indexCount + 03] = vertexCount + 00;// r0b
						indices[indexCount + 04] = vertexCount + 05;// r1d
						indices[indexCount + 05] = vertexCount + 01;// r0c
					}

					// left quad
					{
						indices[indexCount + 06] = vertexCount + 02;// r0d
						indices[indexCount + 07] = vertexCount + 01;// r0c
						indices[indexCount + 08] = vertexCount + 10;// r3b

						indices[indexCount + 09] = vertexCount + 02;// r0d
						indices[indexCount + 10] = vertexCount + 10;// r3b
						indices[indexCount + 11] = vertexCount + 09;// r3a
					}

					// right quad
					{
						indices[indexCount + 12] = vertexCount + 05;// r1d
						indices[indexCount + 13] = vertexCount + 04;// r1c
						indices[indexCount + 14] = vertexCount + 07;// r2b

						indices[indexCount + 15] = vertexCount + 05;// r1d
						indices[indexCount + 16] = vertexCount + 07;// r2b
						indices[indexCount + 17] = vertexCount + 06;// r2a
					}

					// bottom quad
					{
						indices[indexCount + 18] = vertexCount + 10;// r3b
						indices[indexCount + 19] = vertexCount + 06;// r2a
						indices[indexCount + 20] = vertexCount + 08;// r2d

						indices[indexCount + 21] = vertexCount + 10;// r3b
						indices[indexCount + 22] = vertexCount + 08;// r2d
						indices[indexCount + 23] = vertexCount + 11;// r3c
					}

					// center quad
					{
						indices[indexCount + 24] = vertexCount + 01;// r0c
						indices[indexCount + 25] = vertexCount + 05;// r1d
						indices[indexCount + 26] = vertexCount + 06;// r2a

						indices[indexCount + 27] = vertexCount + 01;// r0c
						indices[indexCount + 28] = vertexCount + 06;// r2a
						indices[indexCount + 29] = vertexCount + 10;// r3b
					}

					//indexCount += 30;
					currentBatch.Elements += 10;
					dirty = true;
				}

				// set verts
				{
					ExpandVertices(vertexCount + 12);

					Array.Fill(vertices, new Vertex(float2.Zero, float2.Zero, color, 0, 0, 255), vertexCount, 12);

					Transform(ref vertices[vertexCount + 00].Pos, r0_tr, MatrixStack);// 0
					Transform(ref vertices[vertexCount + 01].Pos, r0_br, MatrixStack);// 1
					Transform(ref vertices[vertexCount + 02].Pos, r0_bl, MatrixStack);// 2

					Transform(ref vertices[vertexCount + 03].Pos, r1_tl, MatrixStack);// 3
					Transform(ref vertices[vertexCount + 04].Pos, r1_br, MatrixStack);// 4
					Transform(ref vertices[vertexCount + 05].Pos, r1_bl, MatrixStack);// 5

					Transform(ref vertices[vertexCount + 06].Pos, r2_tl, MatrixStack);// 6
					Transform(ref vertices[vertexCount + 07].Pos, r2_tr, MatrixStack);// 7
					Transform(ref vertices[vertexCount + 08].Pos, r2_bl, MatrixStack);// 8

					Transform(ref vertices[vertexCount + 09].Pos, r3_tl, MatrixStack);// 9
					Transform(ref vertices[vertexCount + 10].Pos, r3_tr, MatrixStack);// 10
					Transform(ref vertices[vertexCount + 11].Pos, r3_br, MatrixStack);// 11

					vertexCount += 12;
				}

				// TODO: replace with hard-coded values
				var left = Calc.Angle(-float2.UnitX);
				var right = Calc.Angle(float2.UnitX);
				var up = Calc.Angle(-float2.UnitY);
				var down = Calc.Angle(float2.UnitY);

				// top-left corner
				if (r0 > 0)
					SemiCircle(r0_br, up, -left, r0, Math.Max(3, (int)(r0 / 4)), color);
				else
					Quad(r0_tl, r0_tr, r0_br, r0_bl, color);

				// top-right corner
				if (r1 > 0)
					SemiCircle(r1_bl, up, right, r1, Math.Max(3, (int)(r1 / 4)), color);
				else
					Quad(r1_tl, r1_tr, r1_br, r1_bl, color);

				// bottom-right corner
				if (r2 > 0)
					SemiCircle(r2_tl, right, down, r2, Math.Max(3, (int)(r2 / 4)), color);
				else
					Quad(r2_tl, r2_tr, r2_br, r2_bl, color);

				// bottom-left corner
				if (r3 > 0)
					SemiCircle(r3_tr, down, left, r3, Math.Max(3, (int)(r3 / 4)), color);
				else
					Quad(r3_tl, r3_tr, r3_br, r3_bl, color);
			}
		}*/

		#endregion

		#region Circle

		public void SemiCircle(float2 center, float startRadians, float endRadians, float radius, int steps, Color color)
		{
			SemiCircle(center, startRadians, endRadians, radius, steps, color, color);
		}

		public void SemiCircle(float2 center, float startRadians, float endRadians, float radius, int steps, Color centerColor, Color edgeColor)
		{
			var last = Calc.AngleToVector(startRadians, radius);

			for (int i = 1; i <= steps; i++)
			{
				var next = Calc.AngleToVector(startRadians + (endRadians - startRadians) * (i / (float)steps), radius);
				Triangle(center + last, center + next, center, edgeColor, edgeColor, centerColor);
				last = next;
			}
		}

		public void Circle(float2 center, float radius, int steps, Color color)
		{
			Circle(center, radius, steps, color, color);
		}

		public void Circle(float2 center, float radius, int steps, Color centerColor, Color edgeColor)
		{
			var last = Calc.AngleToVector(0, radius);

			for (int i = 1; i <= steps; i++)
			{
				var next = Calc.AngleToVector((i / (float)steps) * Calc.TAU, radius);
				Triangle(center + last, center + next, center, edgeColor, edgeColor, centerColor);
				last = next;
			}
		}

		public void HollowCircle(float2 center, float radius, float thickness, int steps, Color color)
		{
			var last = Calc.AngleToVector(0, radius);

			for (int i = 1; i <= steps; i++)
			{
				var next = Calc.AngleToVector((i / (float)steps) * Calc.TAU, radius);
				Line(center + last, center + next, thickness, color);
				last = next;
			}
		}

		#endregion

		#region Hollow Rect

		public void HollowRect(aabb2 rect, float t, Color color)
		{
			if (t > 0)
			{
				var tx = Math.Min(t, rect.Width / 2f);
				var ty = Math.Min(t, rect.Height / 2f);

				Rect(rect.x0, rect.y0, rect.Width, ty, color);
				Rect(rect.x0, rect.y1 - ty, rect.Width, ty, color);
				Rect(rect.x0, rect.y0 + ty, tx, rect.Height - ty * 2, color);
				Rect(rect.x1 - tx, rect.y0 + ty, tx, rect.Height - ty * 2, color);
			}
		}


		public void HollowRect(rect rect, float t, Color color)
		{
			if (t > 0)
			{
				var tx = Math.Min(t, rect.Width / 2f);
				var ty = Math.Min(t, rect.Height / 2f);

				Rect(rect.X, rect.Y, rect.Width, ty, color);
				Rect(rect.X, rect.Bottom - ty, rect.Width, ty, color);
				Rect(rect.X, rect.Y + ty, tx, rect.Height - ty * 2, color);
				Rect(rect.Right - tx, rect.Y + ty, tx, rect.Height - ty * 2, color);
			}
		}

		#endregion

		#region GMX?
		public void Image(DrawArgs args, float2 offset = .Zero)
		{
			SetTexture(args.texture.Texture);

			var xx = args.position.x - offset.x;
			var yy = args.position.y - offset.y;
			var xscale = args.scale.x;
			var yscale = args.scale.y;
			var cosAngle = 1f;
			var sinAngle = 0f;
			var hskew = args.skew.x;
			var vskew = args.skew.y;

			// Calculate common operations
			var sprWidth = args.texture.Width;
			var sprHeight = args.texture.Height;
			var sprXOrig = args.offset.x;
			var sprYOrig = args.offset.y;

			if (args.rotation != 0)
			{
				cosAngle = Math.Cos(args.rotation);
				sinAngle = Math.Sin(args.rotation);
			}

			float tempX, tempY;

			var vertices = PushQuad();

			// Top-left corner

			tempX = (-sprXOrig + (sprYOrig / sprHeight) * hskew) * xscale;
			tempY = (-sprYOrig + (sprXOrig / sprWidth) * -vskew) * yscale;
			vertices[0] = .(.(xx + tempX * cosAngle - tempY * sinAngle, yy + tempX * sinAngle + tempY * cosAngle), 0, args.texture.TexCoords[0], args.tint, args.mode);
			//draw_vertex_texture_color(xx + tempX * cosAngle - tempY * sinAngle, yy + tempX * sinAngle + tempY *
			// cosAngle, 0, 0, tint);

			// Top-right corner
			tempX = (sprWidth + (sprYOrig / sprHeight) * hskew - sprXOrig) * xscale;
			tempY = (-sprYOrig + (1 - sprXOrig / sprWidth) * vskew) * yscale;
			vertices[1] = .(.(xx + tempX * cosAngle - tempY * sinAngle, yy + tempX * sinAngle + tempY * cosAngle), 0, args.texture.TexCoords[1], args.tint, args.mode);
			//draw_vertex_texture_color(xx + tempX * cosAngle - tempY * sinAngle, yy + tempX * sinAngle + tempY *
			// cosAngle, 1, 0, tint);

			// Bottom-right corner
			tempX = (sprWidth - sprXOrig + (1 - sprYOrig / sprHeight) * -hskew) * xscale;
			tempY = (sprHeight - sprYOrig + (1 - sprXOrig / sprWidth) * vskew) * yscale;
			vertices[2] = .(.(xx + tempX * cosAngle - tempY * sinAngle, yy + tempX * sinAngle + tempY * cosAngle), 0, args.texture.TexCoords[2], args.tint, args.mode);
			//draw_vertex_texture_color(xx + tempX * cosAngle - tempY * sinAngle, yy + tempX * sinAngle + tempY *
			// cosAngle, 0, 1, tint);

			// Bottom-left corner
			tempX = (-sprXOrig + (1 - sprYOrig / sprHeight) * -hskew) * xscale;
			tempY = (sprHeight - sprYOrig + (sprXOrig / sprWidth) * -vskew) * yscale;
			vertices[3] = .(.(xx + tempX * cosAngle - tempY * sinAngle, yy + tempX * sinAngle + tempY * cosAngle), 0, args.texture.TexCoords[3], args.tint, args.mode);
			//draw_vertex_texture_color(xx + tempX * cosAngle - tempY * sinAngle, yy + tempX * sinAngle + tempY *
		// cosAngle, 1, 1, tint);
		}
		#endregion

		#region Image
		public void ImageScaled(Texture texture, aabb2 dst, Color col, bool washed = false)
		{
			SetTexture(texture);
			Quad(dst.TopLeft, dst.TopRight, dst.BottomRight, dst.BottomLeft, .(0, 0), .(1, 0), .(1, 1), .(0, 1), col, col, col, col, washed);
		}

		public void Image(Texture texture,
			float2 pos0, float2 pos1, float2 pos2, float2 pos3,
			float2 uv0, float2 uv1, float2 uv2, float2 uv3,
			Color col0, Color col1, Color col2, Color col3, bool washed = false)
		{
			SetTexture(texture);
			Quad(pos0, pos1, pos2, pos3, uv0, uv1, uv2, uv3, col0, col1, col2, col3, washed);
		}

		public void Image(Texture texture,
			float2 pos0, float2 pos1, float2 pos2, float2 pos3,
			float2 uv0, float2 uv1, float2 uv2, float2 uv3,
			Color color, bool washed)
		{
			SetTexture(texture);
			Quad(pos0, pos1, pos2, pos3, uv0, uv1, uv2, uv3, color, washed);
		}

		public void Image(Subtexture subtex, float2 position, Color color, float2 origin, float2 scale, SpriteEffects effects, float depth, bool washed)
		{
			SetTexture(subtex.Texture);

			var position;
			position = position - origin * scale;

			if (effects == .None)
			{
				Quad(position + subtex.DrawCoords[0] * scale, position + subtex.DrawCoords[1] * scale, position + subtex.DrawCoords[2] * scale,
					position + subtex.DrawCoords[3] * scale, subtex.TexCoords[0], subtex.TexCoords[1], subtex.TexCoords[2],
					subtex.TexCoords[3], color, washed, depth);
			}
			else
			{
				float2[4] coords = ?;
				effects.Apply(ref coords, subtex.TexCoords[0], subtex.TexCoords[1], subtex.TexCoords[2], subtex.TexCoords[3]);

				Quad(position + subtex.DrawCoords[0] * scale, position + subtex.DrawCoords[1] * scale, position + subtex.DrawCoords[2] * scale,
					position + subtex.DrawCoords[3] * scale, coords[0], coords[1], coords[2],
					coords[3], color, washed, depth);
			}
		}

		public void Image(Subtexture subtex, float2 position, Color color, float rotation, float2 origin, float scale, SpriteEffects effects, float depth, bool washed = false)
		{
			Image(subtex, position, color, rotation, origin, float2(scale), effects, depth, washed);
		}

		public void Image(Subtexture subtex, float2 position, Color color, float rotation, float2 origin, float2 scale, SpriteEffects effects, float depth, bool washed = false)
		{
			if (rotation == 0)
				Image(subtex, position, color, origin, scale, effects, depth, washed);
			else
			{
				var position;
				var rotation;
				rotation *= Math.PI_f * 2;
				position = position + subtex.DrawCoords[0] * scale - origin * scale;

				SetTexture(subtex.Texture);
				let pivot = position + origin * scale;
				let pos0 = float2.Rotate(position, pivot, rotation);
				let pos1 = float2.Rotate(position + subtex.DrawCoords[1] * scale, pivot, rotation);
				let pos2 = float2.Rotate(position + subtex.DrawCoords[2] * scale, pivot, rotation);
				let pos3 = float2.Rotate(position + subtex.DrawCoords[3] * scale, pivot, rotation);

				if (effects == .None)
				{
					Quad(pos0, pos1, pos2, pos3, subtex.TexCoords[0], subtex.TexCoords[1], subtex.TexCoords[2], subtex.TexCoords[3], color, washed, depth);
				}
				else
				{
					float2[4] coords = ?;
					effects.Apply(ref coords, subtex.TexCoords[0], subtex.TexCoords[1], subtex.TexCoords[2], subtex.TexCoords[3]);
					Quad(pos0, pos1, pos2, pos3, coords[0], coords[1], coords[2], coords[3], color, washed, depth);
				}
			}
		}


		public void Image(Texture texture, rect dst, Color color, bool washed = false)
		{
			SetTexture(texture);
			Quad(
				float2(dst.Left, dst.Top),
				float2(dst.Right, dst.Top),
				float2(dst.Right, dst.Bottom),
				float2(dst.Left, dst.Bottom),
				float2(0, 0),
				float2.UnitX,
				float2(1, 1),
				float2.UnitY,
				color, washed);
		}

		public void Image(Texture texture, Color color, bool washed = false)
		{
			SetTexture(texture);
			Quad(
				float2(0, 0),
				float2(texture.Width, 0),
				float2(texture.Width, texture.Height),
				float2(0, texture.Height),
				float2(0, 0),
				float2.UnitX,
				float2(1, 1),
				float2.UnitY,
				color, washed);
		}

		public void Image(Texture texture, aabb2 rect, Color color = Color.White, bool washed = false)
		{
			SetTexture(texture);
			Quad(
				rect.TopLeft,
				rect.TopRight,
				rect.BottomRight,
				rect.BottomLeft,
				float2.Zero,
				float2.UnitX,
				float2.Ones,
				float2.UnitY,
				color, washed);
		}

		public void Image(Texture texture, aabb2 rect, SpriteEffects effects, Color color = Color.White, bool washed = false)
		{
			float2[4] coords = ?;
			effects.Apply(ref coords, float2.Zero, float2.UnitX, float2.Ones, float2.UnitY);

			SetTexture(texture);
			Quad(
				rect.TopLeft,
				rect.TopRight,
				rect.BottomRight,
				rect.BottomLeft,
				coords[0],
				coords[1],
				coords[2],
				coords[3],
				color, washed);
		}

		public void Image(Texture texture, float2 position, Color color, bool washed = false)
		{
			SetTexture(texture);
			Quad(
				position,
				position + float2(texture.Width, 0),
				position + float2(texture.Width, texture.Height),
				position + float2(0, texture.Height),
				float2(0, 0),
				float2.UnitX,
				float2(1, 1),
				float2.UnitY,
				color, washed);
		}

		public void Image(Texture texture, float2 position, float2 scale, float2 origin, float rotation, Color color, bool washed = false)
		{
			Runtime.Assert(false, "Not implemented");
			/*var was = MatrixStack;

			MatrixStack = Transform2D.CreateMatrix(position, origin, scale, rotation) * MatrixStack;

			SetTexture(texture);
			Quad(
				float2(0, 0),
				float2(texture.Width, 0),
				float2(texture.Width, texture.Height),
				float2(0, texture.Height),
				float2(0, 0),
				float2.UnitX,
				float2(1, 1),
				float2.UnitY,
				color, washed);

			MatrixStack = was;*/
		}

		public void Image(Texture texture, rect clip, float2 position, Color color, bool washed = false)
		{
			var tx0 = clip.X / texture.Width;
			var ty0 = clip.Y / texture.Height;
			var tx1 = clip.Right / texture.Width;
			var ty1 = clip.Bottom / texture.Height;

			SetTexture(texture);
			Quad(
				position,
				position + float2(clip.Width, 0),
				position + float2(clip.Width, clip.Height),
				position + float2(0, clip.Height),
				float2(tx0, ty0),
				float2(tx1, ty0),
				float2(tx1, ty1),
				float2(tx0, ty1), color, washed);
		}

		public void Image(Texture texture, rect clip, float2 position, float2 scale, float2 origin, float rotation, Color color, bool washed = false)
		{
			Runtime.Assert(false, "Not implemented");

			/*var was = MatrixStack;

			MatrixStack = Transform2D.CreateMatrix(position, origin, scale, rotation) * MatrixStack;

			var tx0 = clip.X / texture.Width;
			var ty0 = clip.Y / texture.Height;
			var tx1 = clip.Right / texture.Width;
			var ty1 = clip.Bottom / texture.Height;

			SetTexture(texture);
			Quad(
				float2(0, 0),
				float2(clip.Width, 0),
				float2(clip.Width, clip.Height),
				float2(0, clip.Height),
				float2(tx0, ty0),
				float2(tx1, ty0),
				float2(tx1, ty1),
				float2(tx0, ty1),
				color, washed);

			MatrixStack = was;*/
		}

		public void Image(Subtexture subtex, float2 position, bool washed = false)
		{
			SetTexture(subtex.Texture);
			Quad(position + subtex.DrawCoords[0], position + subtex.DrawCoords[1], position + subtex.DrawCoords[2],
				position + subtex.DrawCoords[3], subtex.TexCoords[0], subtex.TexCoords[1], subtex.TexCoords[2],
				subtex.TexCoords[3], .White, washed);
		}

		public void Image(Subtexture subtex, Color color, bool washed = false)
		{
			SetTexture(subtex.Texture);
			Quad(
				subtex.DrawCoords[0], subtex.DrawCoords[1], subtex.DrawCoords[2], subtex.DrawCoords[3],
				subtex.TexCoords[0], subtex.TexCoords[1], subtex.TexCoords[2], subtex.TexCoords[3],
				color, washed);
		}

		public void Image(Subtexture subtex, float2 position, float2 scale, Color color = Color.White, bool washed = false, SpriteEffects effects = .None)
		{
			SetTexture(subtex.Texture);
			Quad(position + subtex.DrawCoords[0] * scale, position + subtex.DrawCoords[1] * scale, position + subtex.DrawCoords[2] * scale,
				position + subtex.DrawCoords[3] * scale, subtex.TexCoords[0], subtex.TexCoords[1], subtex.TexCoords[2],
				subtex.TexCoords[3], color, washed);
		}

		public void Image(Subtexture subtex, float2 position, Color color, bool washed = false, SpriteEffects effects = .None)
		{
			SetTexture(subtex.Texture);
			if (effects == .None)
			{
				Quad(position + subtex.DrawCoords[0], position + subtex.DrawCoords[1], position + subtex.DrawCoords[2],
					position + subtex.DrawCoords[3], subtex.TexCoords[0], subtex.TexCoords[1], subtex.TexCoords[2],
					subtex.TexCoords[3], color, washed);
			}
			else
			{
				float2[4] coords = ?;
				effects.Apply(ref coords, subtex.TexCoords[0], subtex.TexCoords[1], subtex.TexCoords[2], subtex.TexCoords[3]);

				Quad(position + subtex.DrawCoords[0], position + subtex.DrawCoords[1], position + subtex.DrawCoords[2],
					position + subtex.DrawCoords[3], coords[0], coords[1], coords[2],
					coords[3], color, washed);
			}
		}

		public void Image(Subtexture subtex, float2 position, Color c0, Color c1, Color c2, Color c3, bool washed = false, SpriteEffects effects = .None)
		{
			SetTexture(subtex.Texture);
			if (effects == .None)
			{
				Quad(position + subtex.DrawCoords[0], position + subtex.DrawCoords[1], position + subtex.DrawCoords[2],
					position + subtex.DrawCoords[3], subtex.TexCoords[0], subtex.TexCoords[1], subtex.TexCoords[2],
					subtex.TexCoords[3], c0, c1, c2, c3, washed);
			}
			else
			{
				float2[4] coords = ?;
				effects.Apply(ref coords, subtex.TexCoords[0], subtex.TexCoords[1], subtex.TexCoords[2], subtex.TexCoords[3]);

				Quad(position + subtex.DrawCoords[0], position + subtex.DrawCoords[1], position + subtex.DrawCoords[2],
					position + subtex.DrawCoords[3], coords[0], coords[1], coords[2],
					coords[3], c0, c1, c2, c3, washed);
			}
		}

		public void TriImage(Subtexture subtex, float2 position, Color[4] c)
		{
			SetTexture(subtex.Texture);
			let p = float2[](position + subtex.DrawCoords[0],
				position + subtex.DrawCoords[1],
				position + subtex.DrawCoords[2],
				position + subtex.DrawCoords[3]);

			let pc = float2((p[0].x + p[2].x) / 2, (p[0].y + p[2].y) / 2);

			let b0 = Color.Lerp(c[0], c[1], 0.5f);
			let b1 = Color.Lerp(c[2], c[3], 0.5f);
			let cc = Color.Lerp(b0, b1, 0.5f);

			let t = ref subtex.TexCoords;
			let tc = float2((t[0].x + t[2].x) / 2, (t[0].y + t[2].y) / 2);

			for (var i < 4)
				Triangle(p[i], p[(i + 1) % 4], pc, t[i], t[(i + 1) % 4], tc, c[i], c[(i + 1) % 4], cc);
		}

		/*
		public void Image(Subtexture subtex, float2 position, float2 scale, float2 origin , float rotation , Color color
		, bool washed = false)
		{
			var was = MatrixStack;

			MatrixStack = Transform2D.CreateMatrix(position, origin, scale, rotation) * MatrixStack;

			SetTexture(subtex.Texture);
			Quad(
				subtex.DrawCoords[0], subtex.DrawCoords[1], subtex.DrawCoords[2], subtex.DrawCoords[3],
				subtex.TexCoords[0], subtex.TexCoords[1], subtex.TexCoords[2], subtex.TexCoords[3],
				color, washed);

			MatrixStack = was;
		}

		public void Image(Subtexture subtex, rect clip, float2 position, float2 scale, float2 origin , float rotation
		,Color color , bool washed = false)
		{
			var (source, frame) = subtex.GetClip(clip);
			var tex = subtex.Texture;
			var was = MatrixStack;

			MatrixStack = Transform2D.CreateMatrix(position, origin, scale, rotation) * MatrixStack;

			var px0 = -frame.X;
			var py0 = -frame.Y;
			var px1 = -frame.X + source.Width;
			var py1 = -frame.Y + source.Height;

			var tx0 = 0f;
			var ty0 = 0f;
			var tx1 = 0f;
			var ty1 = 0f;

			if (tex != null)
			{
				tx0 = source.Left / tex.Width;
				ty0 = source.Top / tex.Height;
				tx1 = source.Right / tex.Width;
				ty1 = source.Bottom / tex.Height;
			}

			SetTexture(subtex.Texture);
			Quad(
				float2(px0, py0), float2(px1, py0), float2(px1, py1), float2(px0, py1),
				float2(tx0, ty0), float2(tx1, ty0), float2(tx1, ty1), float2(tx0, ty1),
				color, washed);

			MatrixStack = was;
		}*/

		#endregion

		#region Text

		/*public void Text(SpriteFont font, StringView text, Color color)
		{
			Text(font, text.AsSpan(), color);
		}*/
		public void Text(SpriteFont font, float2 p, StringView text, Color color, float2 scale = float2.Ones, float2 origin = float2.Zero)
		{
			var position = float2.Zero;

			//var position = float2(0, 0);
			//var position = float2(0, font.Ascent);
			var origin;
			if (origin != float2.Zero)
			{
				origin *= -font.MeasureString(text) * scale;
			}
			origin += p;

			for (int i = 0; i < text.Length; i++)
			{
				let ch = text[i];
				if (ch == '\n')
				{
					position.x = 0;
					position.y += font.LineSpacing * scale.y;
					continue;
				}

				let glyphIndex = font.GetGlyphIndexOrDefault(ch);
				let glyph = font.Glyphs[glyphIndex];

				/*if (!font.Charset.TryGetValue(text[i], out var ch))
				continue;*/
				//if (ch.Image != null)
				{
					var at = position;
					//var at = position + glyph.LeftSideBearing;

					/*if (i < text.Length - 1 && text[i + 1] != '\n')
					{
						if (glyph.Kerning.TryGetValue(text[i + 1], let kerning))
						at.X += kerning;
					}*/



					Image(glyph.Image, (int2)(at + origin), scale, color, true);
				}

				position.x += glyph.Advance * scale.x;
				//position.X += glyph.WidthIncludingBearings;
			}
		}

		/*public void Text(SpriteFont font, StringView text, float2 position, Color color)
		{
			PushMatrix(position);
			Text(font, text.AsSpan(), color);
			PopMatrix();
		}

		public void Text(SpriteFont font, ReadOnlySpan<char> text, float2 position, Color color)
		{
			PushMatrix(position);
			Text(font, text, color);
			PopMatrix();
		}

		public void Text(SpriteFont font, string text, float2 position, float2 scale, float2 origin, float rotation,
			Color color)
		{
			PushMatrix(position, scale, origin, rotation);
			Text(font, text.AsSpan(), color);
			PopMatrix();
		}

		public void Text(SpriteFont font, ReadOnlySpan<char> text, float2 position, float2 scale, float2 origin, float
			rotation, Color color)
		{
			PushMatrix(position, scale, origin, rotation);
			Text(font, text, color);
			PopMatrix();
		}*/

		#endregion

		#region Copy Arrays

		/*/// <summary>
		/// Copies the contents of a Vertex and Index array to this Batcher
		/// </summary>
		public void CopyArray(ReadOnlySpan<Vertex> vertexBuffer, ReadOnlySpan<int> indexBuffer)
		{
			// copy vertices over
			ExpandVertices(vertexCount + vertexBuffer.Length);
			vertexBuffer.CopyTo(vertices.AsSpan().Slice(vertexCount));

			// copy indices over
			while (indexCount + indexBuffer.Length >= indices.Length)
				Array.Resize(ref indices, indices.Length * 2);
			for (int i = 0,n = indexCount; i < indexBuffer.Length; i++,n++)
				indices[n] = vertexCount + indexBuffer[i];

			// increment
			vertexCount += vertexBuffer.Length;
			indexCount += indexBuffer.Length;
			currentBatch.Elements += (uint)(vertexBuffer.Length / 3);
			dirty = true;
		}*/

		#endregion

		#region Misc.

		public void CheckeredPattern(rect bounds, float cellWidth, float cellHeight, Color a, Color b)
		{
			var odd = false;

			for (float y = bounds.Top; y < bounds.Bottom; y += cellHeight)
			{
				var cells = 0;
				for (float x = bounds.Left; x < bounds.Right; x += cellWidth)
				{
					var color = (odd ? a : b);
					if (color.A > 0)
						Rect(x, y, Math.Min(bounds.Right - x, cellWidth), Math.Min(bounds.Bottom - y, cellHeight), color);

					odd = !odd;
					cells++;
				}

				if (cells % 2 == 0)
					odd = !odd;
			}
		}

		#endregion

		#region Internal Utils

		[Inline]
		private Span<Vertex> PushTriangle()
		{
			currentBatch.Elements++;
			dirty = true;
			return Mesh.Tri();
		}

		[Inline]
		private Span<Vertex> PushQuad()
		{
			currentBatch.Elements += 2;
			dirty = true;
			return Mesh.Quad();
		}

		/*[Inline]
		private void Transform(ref float2 to, float2 position, float3x2 matrix)
		{
			to.X = (position.X * matrix.m00) + (position.Y * matrix.m10) + matrix.m20;
			to.Y = (position.X * matrix.m01) + (position.Y * matrix.m11) + matrix.m21;
		}*/

		[Inline]
		private void VerticalFlip(ref float2 uv0, ref float2 uv1, ref float2 uv2, ref float2 uv3)
		{
			uv0.y = 1 - uv0.y;
			uv1.y = 1 - uv1.y;
			uv2.y = 1 - uv2.y;
			uv3.y = 1 - uv3.y;
		}

		#endregion
	}
}

