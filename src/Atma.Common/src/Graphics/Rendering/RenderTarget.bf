namespace Atma
{
	/// <summary>
	/// An Object that can be rendered to (ex. a FrameBuffer or a Window)
	/// </summary>
	public abstract class RenderTarget
	{
		/// <summary>
		/// The Width of the Target
		/// </summary>
		public abstract int Width { get; }

		/// <summary>
		/// The Height of the Target
		/// </summary>
		public abstract int Height { get; }

		/// <summary>
		/// Whether the Target can be rendered to.
		/// </summary>
		public bool Renderable { get; protected set; }

		public int2 Size => .(Width, Height);

		public void Resize(int2 size) => Resize(size.x, size.y);

		public abstract void Resize(int width, int height);

		public float4x4 Matrix => .Ortho(0, Width, 0, Height);

	}
}

