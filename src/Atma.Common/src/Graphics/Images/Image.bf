using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Atma
{
	public class Image
	{
		private Color[] _pixels ~ delete _;
		private int _width, _height;

		public int Width => _width;
		public int Height => _height;

		public int2 Size => .(Width, Height);

		public int Count => _width * _height;

		public int BufferSize => sizeof(Color) * Count;

		public Span<Color> Pixels => _pixels;

		public Color* PixelsPtr => &_pixels[0];

		public this(int2 size) : this(size.x, size.y)
		{
		}

		public this(int width, int height, Color color) : this(width, height)
		{
			for (var it in ref _pixels)
				it = color;
		}
		public this(int width, int height)
		{
			_width = width;
			_height = height;
			_pixels = new Color[width * height];
		}


		public this(int width, int height, Color[] pixels)
		{
			_width = width;
			_height = height;
			_pixels = pixels;
		}

		public ref Color this[int index]
		{
			get
			{
				System.Diagnostics.Debug.Assert(index >= 0 && index < Count, "index was out of range");
				return ref _pixels[index];
			}
		}

		public ref Color this[int x, int y]
		{
			get
			{
				System.Diagnostics.Debug.Assert(x >= 0 && x < Width, "x was out of range");
				System.Diagnostics.Debug.Assert(y >= 0 && y < Height, "y was out of range");
				return ref _pixels[y * Width + x];
			}
		}

		public void SetPixels(rect area, Color[] data)
		{
			for (var y < area.Height)
				for (var x < area.Width)
					this[x + area.X, y + area.Y] = data[y * area.Width + x];
		}


		public void Premultiply()
		{
			for (var i < _pixels.Count)
				_pixels[i].Premultiply();
		}

		public void Clear(Color clearColor)
		{
			for (var y < _height)
				for (var x < _width)
					_pixels[y * _width + x] = clearColor;
		}
	}
}

