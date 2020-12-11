namespace Atma
{
	using System;

	public class VertexBuffer
	{
		protected readonly GraphicsManager _graphics;

		protected uint _id;
		public uint ID => _id;

		private uint _vertexCount;
		public uint VertexCount => _vertexCount;
		public uint BufferSize => (uint)Format.Stride * VertexCount;
		public readonly VertexFormat Format;

		public this(VertexFormat format, uint vertexCount) : this(Core.Graphics, format, vertexCount) { }
		public this(GraphicsManager graphics, VertexFormat format, uint vertexCount)
		{
			_graphics = GraphicsManager.Current;
			_vertexCount = vertexCount;

			Format = format;
			Platform_Init();
		}

		public ~this()
		{
			Platform_Destroy();
		}

		public void Resize(uint elements)
		{
			Log.Debug("VertexBuffer resize: {0} -> {1}", _vertexCount, elements);

			_vertexCount = elements;
			Platform_Resize(elements);
		}

		public void Set<T>(T[] vertices)
		{
			Set(Span<T>(vertices));
		}

		public void Set<T>(Span<T> vertices)
		{
			Runtime.Assert((uint)vertices.Length <= VertexCount);
			Platform_SetData(&vertices[0], vertices.Length);
		}

		public void Bind(GraphicsContext context, Material material)
		{
			Platform_Bind(context, material);
		}
	}
}
