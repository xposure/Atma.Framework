namespace Atma
{
	using System;

	public class IndexBuffer
	{
		protected extern void Platform_SetData(void* indices, int count);

		protected extern void Platform_Bind(GraphicsContext context, Material material);

		protected extern void Platform_Resize(uint elements);

		protected extern void Platform_Init();

		protected extern void Platform_Destroy();

		private GraphicsManager _graphics;

		protected uint _id;
		public uint ID => _id;

		public readonly IndexElementSize ElementSize;

		private uint _elementCount;
		public uint ElementCount => _elementCount;

		public uint BufferSize => (uint)ElementSize.Stride * ElementCount;

		public this(IndexElementSize indexSize, uint elementCount):this(GraphicsManager.Current, indexSize, elementCount){}
		public this(GraphicsManager graphics, IndexElementSize indexSize, uint elementCount)
		{
			_graphics = GraphicsManager.Current;

			ElementSize = indexSize;
			_elementCount = elementCount;
			Platform_Init();
		}

		public ~this()
		{
			Platform_Destroy();
		}

		public void Resize(uint elements)
		{
			Log.Debug("IndexBuffer resize: {0} -> {1}", _elementCount, elements);
			_elementCount = elements;
			Platform_Resize(elements);
		}

		public void Set<T>(T[] indices)
		{
			Set(Span<T>(indices));
		}

		public void Set<T>(Span<T> indices)
		{
			Runtime.Assert((uint)indices.Length <= ElementCount);
			Platform_SetData(&indices[0], indices.Length);
		}

		public void Bind(GraphicsContext context, Material material)
		{
			Platform_Bind(context, material);
		}
	}
}
