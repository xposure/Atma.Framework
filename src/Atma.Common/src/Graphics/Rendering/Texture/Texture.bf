using System;
using System.Collections;
using System.Text;
using System.IO;

namespace Atma
{
	//TODO IMGUI
	/*public extension Texture
	{
		using ImGui;

		public void Inspect()
		{
			ImGui.PushID(Internal.UnsafeCastToPtr(this));

			ImGui.Text(scope $"Texture [{ID}] Size: {Size}");
			if (ImGui.IsItemHovered())
			{
				ImGui.BeginTooltip();
				ImGui.Image((.)_id, .(200, 200));
				ImGui.EndTooltip();
			}

			if (ImGui.BeginCombo("Filter", scope $"{filter}"))
			{
				if (ImGui.Selectable("Linear", Filter == .Linear)) Filter = .Linear;
				if (ImGui.Selectable("Nearest", Filter == .Nearest)) Filter = .Nearest;
				ImGui.EndCombo();
			}

			if (ImGui.BeginCombo("WrapX", scope $"{wrapX}"))
			{
				if (ImGui.Selectable("Wrap", wrapX == .Wrap)) WrapX = .Wrap;
				if (ImGui.Selectable("Clamp", wrapX == .Clamp)) WrapX = .Clamp;
				ImGui.EndCombo();
			}

			if (ImGui.BeginCombo("WrapY", scope $"{wrapY}"))
			{
				if (ImGui.Selectable("Wrap", wrapY == .Wrap)) WrapY = .Wrap;
				if (ImGui.Selectable("Clamp", wrapY == .Clamp)) WrapY = .Clamp;
				ImGui.EndCombo();
			}

			ImGui.PopID();
		}
	}*/

  /// <summary>
  /// A 2D Texture used for Rendering
  /// </summary>
	public class Texture//: ITexture//: IDisposable
	{
		/// <summary>
		/// Default Texture Filter used for all Textures
		/// </summary>
		//public static TextureFilter DefaultTextureFilter = TextureFilter.Nearest;

		//public static TextureWrap DefaultTextureWrap = TextureWrap.Clamp;

		protected uint _id;
		public uint ID => _id;

		/// <summary>
		/// The Texture Data Format
		/// </summary>
		public readonly TextureFormat Format;

		/// <summary>
		/// Gets the Width of the Texture
		/// </summary>
		public int Width => width;

		/// <summary>
		/// Gets the Height of the Texture
		/// </summary>
		public int Height => height;

		protected bool _isFrameBuffer = false;

		/// <summary>
		/// Whether the Texture is part of a FrameBuffer
		/// </summary>
		public bool IsFrameBuffer => _isFrameBuffer;

		/// <summary>
		/// The Size of the Texture, in bytes
		/// </summary>
		public int Length => Width * Height * Format.Size;

		public int Count => Width * Height;

		public int2 Size => .(Width, Height);

		/// <summary>
		/// The Texture Filter to be used while drawing
		/// </summary>
		public TextureFilter Filter
		{
			get => filter;
			set => Platform_SetFilter(filter = value);
		}

		/// <summary>
		/// The Horizontal Wrapping mode
		/// </summary>
		public TextureWrap WrapX
		{
			get => wrapX;
			set => Platform_SetWrap(wrapX = value, wrapY);
		}

		/// <summary>
		/// The Vertical Wrapping mode
		/// </summary>
		public TextureWrap WrapY
		{
			get => wrapY;
			set => Platform_SetWrap(wrapX, wrapY = value);
		}

		private readonly GraphicsManager _graphics;
		private TextureFilter filter = Core.DefaultTextureFilter;
		private TextureWrap wrapX = Core.DefaultTextureWrap;
		private TextureWrap wrapY = Core.DefaultTextureWrap;
		private int width, height;



		public this(int width, int height, TextureFormat format = TextureFormat.Color)
		{
			Runtime.Assert(format.IsTextureColorFormat, "Invalid texture format.");
			Runtime.Assert(width > 0 && height > 0, "Width and height must be greater than zero.");

			_graphics = GraphicsManager.Current;

			this.width = width;
			this.height = height;
			this.Format = format;
			//Implementation = graphics.[Friend]CreateTexture(Width, Height, Format);
			Platform_Init();
		}

		public this(Image image) : this(image.Width, image.Height, .Color)
		{
			SetData(image.Pixels);
		}

		public ~this()
		{
			Platform_Destroy();
		}


		/*public this(int width, int height, TextureFormat format = TextureFormat.Color) 
			: this(App.Graphics, width, height, format)
		{
		}

		public this(Bitmap bitmap) 
			: this(App.Graphics, bitmap.Width, bitmap.Height, TextureFormat.Color)
		{
			Implementation.SetData<Color>(bitmap.Pixels);
		}

		public this(String path) 
			: this(new Bitmap(path))
		{
		}

		public this(Stream stream) 
			: this(new Bitmap(stream))
		{
		}*/

		public void Resize(int width, int height)
		{
			Runtime.Assert(width > 0 && height > 0, "Width and height must be greater than zero.");

			if (Width != width || Height != height)
			{
				this.width = width;
				this.height = height;

				Platform_Resize(width, height);
			}
		}

		/*/// <summary>
		/// Creates a Bitmap with the Texture Color data
		/// </summary>
		public Bitmap AsBitmap()
		{
			var bitmap = new Bitmap(Width, Height);
			GetData<Color>(new Memory<Color>(bitmap.Pixels));
			return bitmap;
		}*/

		/*/// <summary>
		/// Sets the Texture Color data from the given buffer
		/// </summary>
		public void SetColor(ReadOnlyMemory<Color> buffer) => SetData<Color>(buffer);

		/// <summary>
		/// Writes the Texture Color data to the given buffer
		/// </summary>
		public void GetColor(Memory<Color> buffer) => GetData<Color>(buffer);*/


		/// <summary>
		/// Sets the Texture data from the given buffer
		/// </summary>
		public void SetData<T>(T[] buffer) => SetData<T>(Span<T>(buffer));

		public void SetData<T>(Span<T> buffer)
		{
			Runtime.Assert(sizeof(T) * buffer.Length == Length, "Buffer was not the correct size of the texture");

			Platform_SetData(&buffer[0], 0, 0, Width, Height);
		}

		public void SetData<T>(rect area, Span<T> buffer)
		{
			Runtime.Assert(sizeof(T) == 4, "T should be 4 bytes for ARGB");
			Runtime.Assert(area.X >= 0 && area.Y >= 0 && area.Right <= Width && area.Bottom <= Height, "Area was out of bounds");

			Platform_SetData(&buffer[0], area.X, area.Y, area.Width, area.Height);
		}


		/// <summary>
		/// Writes the Texture data to the given buffer
		/// </summary>
		public void GetData<T>(T[] buffer) => GetData<T>(Span<T>(buffer));

		public void GetData<T>(Span<T> buffer)
		{
			Runtime.Assert(sizeof(T) * buffer.Length == Length, "Buffer was not the correct size of the texture");
			/*if (Marshal.SizeOf<T>() * buffer.Length < Size)
				throw new Exception("Buffer is smaller than the Size of the Texture");*/

			Platform_GetData(&buffer[0]);
			//Implementation.GetData(&buffer[0]);
		}

		public void SavePng(String path)
		{
			Runtime.Assert(false, "Not implemented");
			/*using var stream = File.OpenWrite(path);
			SavePng(stream);*/
		}

		public void SavePng(Stream stream)
		{
			Runtime.Assert(false, "Not implemented");

			/*var color = new Color[Width * Height];

			if (Format == TextureFormat.Color || Format == TextureFormat.DepthStencil)
			{
				GetData<Color>(color);
			}
			else
			{
				// TODO:
				// do this inline with a single buffer

				var buffer = new byte[Size];
				GetData<byte>(buffer);

				if (Format == TextureFormat.Red)
				{
					for (int i = 0; i < buffer.Length; i++)
					{
						color[i].R = buffer[i];
						color[i].A = 255;
					}
				}
				else if (Format == TextureFormat.RG)
				{
					for (int i = 0; i < buffer.Length; i += 2)
					{
						color[i].R = buffer[i + 0];
						color[i].G = buffer[i + 1];
						color[i].A = 255;
					}
				}
				else if (Format == TextureFormat.RGB)
				{
					for (int i = 0; i < buffer.Length; i += 3)
					{
						color[i].R = buffer[i + 0];
						color[i].G = buffer[i + 1];
						color[i].B = buffer[i + 2];
						color[i].A = 255;
					}
				}
				else
				{
					Runtime.Assert(false, "Not implemented");
				}
			}

			// We may need to flip our buffer.
			// This is due to some rendering APIs drawing from the bottom left (OpenGL).
			if (IsFrameBuffer && graphics.OriginBottomLeft)
			{
				for (int y = 0; y < Height / 2; y++)
				{
					var a = y * Width;
					var b = (Height - y - 1) * Width;

					for (int x = 0; x < Width; x++,a++,b++)
					{
						var temp = color[a];
						color[a] = color[b];
						color[b] = temp;
					}
				}
			}

			PNG.Write(stream, Width, Height, color);*/
		}

		public void SaveJpg(String path)
		{
			Runtime.Assert(false, "Not implemented");
		}

		public void SaveJpg(Stream stream)
		{
			Runtime.Assert(false, "Not implemented");
		}


	}
}

