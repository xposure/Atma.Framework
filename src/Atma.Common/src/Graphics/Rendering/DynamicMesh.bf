using System;
using System.Collections;
namespace Atma
{
	public class DynamicMesh<T>
	{
		private const int MaxVertices16 = uint16.MaxValue / 6;
		private readonly GraphicsManager _graphics;
		private VertexBuffer _vertexBuffer ~ delete _;
		private IndexBuffer _indexBuffer ~ delete _;
		private VertexFormat _vertexFormat;

		private List<T> _vertices = new .() ~ delete _;
		private List<uint16> _indices16 ~ delete _;
		private List<uint32> _indices32 ~ delete _;

		private IndexElementSize _elementSize = .SixteenBits;

		public int VertexCount => _vertices.Count;
		public int IndexCount
		{
			get
			{
				if (_indexBuffer.ElementSize == .SixteenBits)
					return _indices16.Count;
				else
					return _indices32.Count;
			}
		}

		public this(VertexFormat vertexFormat, int estimatedVertexCount = 1024, int estimatedIndexCount = 1536) : this(GraphicsManager.Current, vertexFormat, estimatedVertexCount, estimatedIndexCount) { }
		public this(GraphicsManager graphics, VertexFormat vertexFormat, int estimatedVertexCount = 1024, int estimatedIndexCount = 1536)
		{
			_graphics = graphics;
			_vertexFormat = vertexFormat;
			_vertexBuffer = new .(graphics, vertexFormat, (.)estimatedVertexCount);

			if (estimatedVertexCount <= MaxVertices16)
			{
				_indexBuffer = new .(graphics, .SixteenBits, (.)estimatedIndexCount);
				_indices16 = new .(estimatedIndexCount);
				_elementSize = .SixteenBits;
			}
			else
			{
				_indexBuffer = new .(graphics, .ThirtyTwoBits, (.)estimatedIndexCount);
				_indices32 = new .(estimatedIndexCount);
				_elementSize = .ThirtyTwoBits;
			}
		}

		public Span<T> Quad()
		{
			let ptr = EnsureCapacity(4, 6);
			if (_elementSize == .SixteenBits)
			{
				let count = (uint16)_vertices.Count;
				var indexPtr = (uint16*)ptr;
				indexPtr[0] = count + 0;
				indexPtr[1] = count + 1;
				indexPtr[2] = count + 2;
				indexPtr[3] = count + 0;
				indexPtr[4] = count + 2;
				indexPtr[5] = count + 3;
			}
			else
			{
				let count = (uint32)_vertices.Count;
				var indexPtr = (uint32*)ptr;
				indexPtr[0] = count + 0;
				indexPtr[1] = count + 1;
				indexPtr[2] = count + 2;
				indexPtr[3] = count + 0;
				indexPtr[4] = count + 2;
				indexPtr[5] = count + 3;
			}

			return .(_vertices.GrowUnitialized(4), 4);
		}

		public Span<T> Tri()
		{
			let ptr = EnsureCapacity(3, 3);

			if (_elementSize == .SixteenBits)
			{
				let count = (uint16)_vertices.Count;
				var indexPtr = (uint16*)ptr;
				indexPtr[0] = count + 0;
				indexPtr[1] = count + 1;
				indexPtr[2] = count + 2;
			}
			else
			{
				let count = (uint32)_vertices.Count;
				var indexPtr = (uint32*)ptr;
				indexPtr[0] = count + 0;
				indexPtr[1] = count + 1;
				indexPtr[2] = count + 2;
			}

			return .(_vertices.GrowUnitialized(3), 3);
		}

		[Inline]
		private void* EnsureCapacity(int vertices, int indices)
		{
			if (_elementSize == .ThirtyTwoBits)
				return _indices32.GrowUnitialized(indices);

			//grow to 32bits if needed, we need to copy all the data over from the 16 bit array
			if (_vertices.Count + vertices > MaxVertices16)
			{
				defer { DeleteAndNullify!(_indices16); }

				_indices32 = new .();
				let dst = _indices32.GrowUnitialized(_indices16.Count + indices);
				let src = _indices16.Ptr;
				for (var i < _indices16.Count)
					dst[i] = src[i];

				_elementSize = .ThirtyTwoBits;

				delete _indexBuffer;
				_indexBuffer = new .(_graphics, .ThirtyTwoBits, (.)_indices32.Count);

				return &_indices32[_indices16.Count];
			}

			return _indices16.GrowUnitialized(indices);
		}

		public void Clear()
		{
			_vertices.Clear();
			if (_elementSize == .SixteenBits)
				_indices16.Clear();
			else
				_indices32.Clear();
		}

		public void Commit()
		{
			if ((uint)_vertices.Count > _vertexBuffer.VertexCount)
			{
				var newSize = _vertexBuffer.VertexCount * 3 / 2;
				while (newSize <= (uint)_vertices.Count)
					newSize = newSize * 3 / 2;

				_vertexBuffer.Resize(newSize);
			}
			_vertexBuffer.Set(Span<T>(_vertices.Ptr, _vertices.Count));

			if (_elementSize == .SixteenBits)
			{
				if ((uint)_indices16.Count > _indexBuffer.ElementCount)
				{
					var newSize = _indexBuffer.ElementCount * 3 / 2;
					while (newSize <= (uint)_indices16.Count)
						newSize = newSize * 3 / 2;

					_indexBuffer.Resize(newSize);
				}
				_indexBuffer.Set(Span<uint16>(_indices16.Ptr, _indices16.Count));
			}
			else
			{
				if ((uint)_indices32.Count > _indexBuffer.ElementCount)
				{
					var newSize = _indexBuffer.ElementCount * 3 / 2;
					while (newSize <= (uint)_indices32.Count)
						newSize = newSize * 3 / 2;

					_indexBuffer.Resize(newSize);
				}
				_indexBuffer.Set(Span<uint32>(_indices32.Ptr, _indices32.Count));
			}
		}

		public void Render(RenderTarget target, Material material)
		{
			Core.Graphics.Render(.(target, _vertexBuffer, _indexBuffer, 0, (.)IndexCount, material));
		}
	}
}
