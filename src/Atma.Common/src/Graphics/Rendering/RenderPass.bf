using System;
using System.Collections;
using System.Text;

namespace Atma
{
	public enum IndexElementSize
	{
		/// <summary>
		/// 16-bit short/ushort indices.
		/// </summary>
		case SixteenBits;
		/// <summary>
		/// 32-bit int/uint indices.
		/// </summary>
		case ThirtyTwoBits;

		public int Stride
		{
			get
			{
				switch (this) {
				case .SixteenBits: return sizeof(uint16);
				case .ThirtyTwoBits: return sizeof(uint32);
				}
			}
		}
	}

	/// <summary>
	/// A Structure which describes a single Render Pass / Render Call
	/// </summary>
	public struct RenderPass
	{
		/// <summary>
		/// Render Target
		/// </summary>
		public RenderTarget Target;

		/*/// <summary>
		/// Render Viewport
		/// </summary>
		public rect? Viewport;*/

		/// <summary>
		/// Material to use
		/// </summary>
		public Material Material;

		/// <summary>
		/// VertexBuffer to use
		/// </summary>
		public VertexBuffer VertexBuffer;

		/// <summary>
		/// IndexBuffer to use
		/// </summary>
		public IndexBuffer IndexBuffer;

		/// <summary>
		/// The Index to begin rendering
		/// </summary>
		public uint IndexStart;

		/// <summary>
		/// The total number of Indices to draw 
		/// </summary>
		public uint IndexCount;

		/// <summary>
		/// The Render State Blend Mode
		/// </summary>
		public BlendMode BlendMode;

		/// <summary>
		/// The Render State Culling Mode
		/// </summary>
		public CullMode CullMode;

		/// <summary>
		/// The Render State Depth comparison Function
		/// </summary>
		public DepthCompare DepthFunction;

		/// <summary>
		/// The Render State Scissor Rectangle
		/// </summary>
		public rect? Scissor;

		/// <summary>
		/// Creates a Render Pass based on the given mesh and material
		/// </summary>
		public this(RenderTarget target, VertexBuffer vertexBuffer, IndexBuffer indexBuffer, uint indexStart, uint indexCount, Material material)
		{
			Target = target;
			VertexBuffer = vertexBuffer;
			IndexBuffer = indexBuffer;
			Material = material;
			IndexStart = indexStart;
			IndexCount = indexCount;
			Scissor = null;
			BlendMode = .Normal;
			DepthFunction = DepthCompare.None;
			CullMode = .None;
		}
	}
}

