using System;
using System.Collections;
using System.Text;

namespace Atma
{


	/// <summary>
	/// A 2D buffer that can be drawn to
	/// </summary>
	public class RenderTexture : RenderTarget
	{


		/// <summary>
		/// Render Target Width
		/// </summary>
		public override int Width => width;

		/// <summary>
		/// Render Target Height
		/// </summary>
		public override int Height => height;

		private int width;
		private int height;

		protected uint _id;
		public uint ID => _id;

		protected List<Texture> _attachments = new .() ~ DeleteContainerAndItems!(_);

		public Texture GetAttachment(TextureFormat format)
		{
			for (var it in _attachments)
				if (it.Format == format)
					return it;
			return null;
		}

		public Texture ColorAttachment => GetAttachment(.Color);
		public Texture RGBA16F => GetAttachment(.RGBA16F);
		public Texture DepthAttachment => GetAttachment(.DepthStencil);

		public static implicit operator Texture(RenderTexture buffer) => buffer.ColorAttachment;

		public this(int2 size) : this(size.x, size.y) { }
		public this(int width, int height)
			: this(width, height, TextureFormat.Color)
		{
		}

		public this(int width, int height, params TextureFormat[] attachments)
		{
			Initialize(.(width, height), params attachments);
		}

		protected this()
		{
			//used to init later
		}

		protected void Initialize(int2 size, params TextureFormat[] attachments)
		{
			this.width = size.width;
			this.height = size.height;

			Runtime.Assert(width > 0 && height > 0, "FrameBuffer must have a size larger than 0");
			Renderable = true;
			Platform_Init(attachments);
		}

		public ~this()
		{
			Platform_Destroy();
		}

		protected override bool InternalResize(int2 size)
		{
			Runtime.Assert(size.width > 0 && size.height > 0, "FrameBuffer must have a size larger than 0");

			if (this.width != width || this.height != height)
			{
				this.width = width;
				this.height = height;

				Platform_Resize(width, height);
				return true;
			}

			return false;
		}

		public void Bind(GraphicsContext ctx)
		{
			Platform_Bind();
		}

		public aabb2 Bounds => aabb2.FromRect(0, 0, width, height);

		public void Inpsect()
		{
			OnInspect();
		}

		protected virtual void OnInspect() { }
	}
}

