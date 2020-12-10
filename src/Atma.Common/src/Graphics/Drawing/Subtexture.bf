using System;

namespace Atma
{

	/// <summary>
	/// A Subtexture, representing a aabb2angular segment of a Texture
	/// </summary>
	public struct Subtexture
	{
		/// <summary>
		/// The Texture coordinates. These are set automatically based on the Source 
		/// </summary>
		public float2[4] TexCoords;

		/// <summary>
		/// The draw coordinates. These are set automatically based on the Source and Frame 
		/// </summary>
		public float2[4] DrawCoords;


		/// <summary>
		/// The Texture this Subtexture is... a subtexture of
		/// </summary>
		public Texture Texture
		{
			get => texture;
			/*set
			{
				if (texture != value)
				{
					texture = value;
					UpdateCoords();
				}
			}*/
		}

		/// <summary>
		/// The source aabb2angle to sample from the Texture
		/// </summary>
		public rect Source
		{
			get => source;
			/*set
			{
				source = value;
				UpdateCoords();
			}*/
		}

		/// <summary>
		/// The frame of the Subtexture. This is useful if you trim transparency and want to store the original size of
		// the image For example, if the original image was (64, 64), but the trimmed version is (32, 48), the Frame may
		// be (-16, -8, 64, 64) </summary>
		public rect Frame
		{
			get => frame;
			/*set
			{
				frame = value;
				UpdateCoords();
			}*/
		}

		/// <summary>
		/// The Draw Width of the Subtexture
		/// </summary>
		public int Width => frame.Width;

		/// <summary>
		/// The Draw Height of the Subtexture
		/// </summary>
		public int Height => frame.Height;

		public int2 FrameSize => .(Width, Height);

		public int2 Center => FrameSize / 2;


		private Texture texture;
		private rect frame;
		private rect source;

		public float2 TextureMin => (texture?.Size ?? int2.Zero) * TexCoords[0];
		public float2 TextureMax => (texture?.Size ?? int2.Zero) * TexCoords[2];
		public aabb2 TextureArea => .(TexCoords[0], TexCoords[2]);

		public this(Texture texture)
			: this(texture, .(0, 0, texture.Width, texture.Height))
		{
		}

		/*public this(Texture texture, aabb2 source)
			: this(texture, source, aabb2(0, 0, source.Width, source.Height))
		{
		}*/

		public this(Texture texture, rect source) : this(texture, source, .(0, 0, source.Width, source.Height))
		{
		}

		public this(Texture texture, rect source, rect frame)
		{
			this.texture = texture;
			this.source = source;
			this.frame = frame;

			DrawCoords = ?;
			TexCoords = ?;

			DrawCoords[0].x = -frame.X;
			DrawCoords[0].y = -frame.Y;
			DrawCoords[1].x = -frame.X + source.Width;
			DrawCoords[1].y = -frame.Y;
			DrawCoords[2].x = -frame.X + source.Width;
			DrawCoords[2].y = -frame.Y + source.Height;
			DrawCoords[3].x = -frame.X;
			DrawCoords[3].y = -frame.Y + source.Height;

			if (texture != null)
			{
				var tx0 = (float)source.X / texture.Width;
				var ty0 = (float)source.Y / texture.Height;
				var tx1 = (float)source.Right / texture.Width;
				var ty1 = (float)source.Bottom / texture.Height;

				TexCoords[0].x = tx0;
				TexCoords[0].y = ty0;
				TexCoords[1].x = tx1;
				TexCoords[1].y = ty0;
				TexCoords[2].x = tx1;
				TexCoords[2].y = ty1;
				TexCoords[3].x = tx0;
				TexCoords[3].y = ty1;
			}
			else
				TexCoords = default;
		}

		/*public void Reset(Texture texture, aabb2 source, aabb2 frame)
		{
			this.texture = texture;
			this.source = source;
			this.frame = frame;

			UpdateCoords();
		}*/

		public Subtexture this[int x, int y, int size] => GetClipSubtexture(.(x * size, y * size, size, size));

		public (rect Source, rect Frame) GetClip(rect clip)
		{
			var clip;
			(rect Source, rect Frame) result;

			clip = clip.Offset(Frame.Min);

			let localSource = rect(0, 0, source.Width, source.Height);
			let source = localSource.Intersection(clip) + Source.Min;
			result.Source = source;

			let fx = Math.Min(0, clip.X);
			let fy = Math.Min(0, clip.Y);
			let fw = clip.Width;
			let fh = clip.Height;


			result.Frame = rect(fx, fy, fw, fh);


			return result;
		}

		public (rect Source, rect Frame) GetClip(int x, int y, int w, int h)
		{
			return GetClip(rect(x, y, w, h));
		}

		public Subtexture GetClipSubtexture(rect clip, int2 offset = int2.Zero)
		{
			var (source, frame) = GetClip(clip);
			return Subtexture(texture, source, frame.Offset(offset));
		}

		public override void ToString(System.String strBuffer)
		{
			strBuffer.AppendF("{{ Frame: {0}, Source: {1} }}", frame, source);
		}
	}
}

