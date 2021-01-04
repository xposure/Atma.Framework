using System;
using System.Collections;
using System.IO;

namespace Atma
{
	/// <summary>
	/// The Packer takes source image data and packs them into large texture pages that can then be used for Atlases
	/// This is useful for sprite fonts, sprite sheets, etc.
	/// </summary>
	public class Packer
	{

		/// <summary>
		/// A single packed Entry
		/// </summary>
		public class Entry
		{
			/// <summary>
			/// The Name of the Entry
			/// </summary>
			public readonly String Name = new .() ~ delete _;

			/// <summary>
			/// The corresponding image page of the Entry
			/// </summary>
			public readonly int Page;

			/// <summary>
			/// The Source Rectangle
			/// </summary>
			public readonly rect Source;

			/// <summary>
			/// The Frame Rectangle. This is the size of the image before it was packed
			/// </summary>
			public readonly rect Frame;

			public this(StringView name, int page, rect source, rect frame)
			{
				Name.Set(name);
				Page = page;
				Source = source;
				Frame = frame;
			}
		}

		/// <summary>
		/// Stores the Packed result of the Packer
		/// </summary>
		public class Output
		{
			public Image Page ~ Release(_);
			public readonly Dictionary<StringView, Entry> Entries = new .() ~ Release(_);

		}

		/// <summary>
		/// The Packed Output
		/// This is null if the Packer has not yet been packed
		/// </summary>
		private Output _packed ~ delete _;

		public Output Packed
		{
			get
			{
				Pack();
				return _packed;
			}
		}

		/// <summary>
		/// Whether the Packer has unpacked source data
		/// </summary>
		public bool HasUnpackedData { get; private set; }

		/// <summary>
		/// Whether to trim transparency from the source images
		/// </summary>
		public bool Trim = true;

		/// <summary>
		/// Maximum Texture Size. If the packed data is too large it will be split into multiple pages
		/// </summary>
		public int MaxSize = 8192;

		/// <summary>
		/// Image Padding
		/// </summary>
		public int Padding = 1;

		/// <summary>
		/// Power of Two
		/// </summary>
		public bool PowerOfTwo = false;

		/// <summary>
		/// This will check each image to see if it's a duplicate of an already packed image. 
		/// It will still add the entry, but not the duplicate image data.
		/// </summary>
		public bool CombineDuplicates = false;

		/// <summary>
		/// The total number of source images
		/// </summary>
		public int SourceImageCount => sources.Count;

		public class Source
		{
			public String Name ~ delete _;
			public rect Packed;
			public rect Frame;
			public Color[] Buffer ~ delete _;
			public Source DuplicateOf;
			public bool Empty => Packed.Width <= 0 || Packed.Height <= 0;

			public this(String name)
			{
				Name = name;
			}
		}

		private readonly List<Source> sources = new List<Source>() ~ DeleteContainerAndItems!(_);
		private readonly Dictionary<int, Source> duplicateLookup = new Dictionary<int, Source>() ~ DeleteDictionaryAndValues!(_);

		public String Name = new .() ~ delete _;
		public this(StringView name)
		{
			Name.Set(name);
		}

		public ~this()
		{
		}

		public void AddImage(StringView name, Image image)
		{
			if (image != null)
				AddPixels(name, image.Width, image.Height, image.Pixels);
		}

		/*public void AddFile(StringView name, StringView path)
		{
			using var stream = File.OpenRead(path);
			AddBitmap(name, new Bitmap(stream));
		}*/

		public Source AddPixels(StringView name, int width, int height, Span<Color> pixels)
		{
			HasUnpackedData = true;

			var source = new Source(new String(name));
			int top = 0, left = 0, right = width, bottom = height;

			// trim
			if (Trim)
			{
				int y, x, s;
				TOP:
					for (y = 0; y < height; y++)
					for (x = 0,s = y * width; x < width; x++,s++)
						if (pixels[s].A > 0)
						{
							top = y;
							break TOP;
						}
				LEFT:
					for (x = 0; x < width; x++)
					for (y = top,s = x + y * width; y < height; y++,s += width)
						if (pixels[s].A > 0)
						{
							left = x;
							break LEFT;
						}
				RIGHT:
					for (x = width - 1; x >= left; x--)
					for (y = top,s = x + y * width; y < height; y++,s += width)
						if (pixels[s].A > 0)
						{
							right = x + 1;
							break RIGHT;
						}
				BOTTOM:
					for (y = height - 1; y >= top; y--)
					for (x = left,s = x + y * width; x < right; x++,s++)
						if (pixels[s].A > 0)
						{
							bottom = y + 1;
							break BOTTOM;
						}
			}

			// determine sizes
			// there's a chance this image was empty in which case we have no width / height
			if (left <= right && top <= bottom)
			{
				var isDuplicate = false;

				if (CombineDuplicates)
				{
					var hash = 0;
					for (int x = left; x < right; x++)
						for (int y = top; y < bottom; y++)
							hash = ((hash << 5) + hash) + (int)pixels[x + y * width].ABGR;

					if (duplicateLookup.TryGetValue(hash, let duplicate))
					{
						source.DuplicateOf = duplicate;
						isDuplicate = true;
					}
					else
					{
						duplicateLookup.Add(hash, source);
					}
				}

				source.Packed = rect(0, 0, right - left, bottom - top);
				source.Frame = rect(-left, -top, width, height);

				if (!isDuplicate)
				{
					source.Buffer = new Color[source.Packed.Width * source.Packed.Height];

					// copy our trimmed pixel data to the main buffer
					for (int i = 0; i < source.Packed.Height; i++)
					{
						var run = source.Packed.Width;
						var from = pixels.Slice(left + (top + i) * width, run);
						var to = Span<Color>(source.Buffer, i * run, run);

						from.CopyTo(to);
					}
				}
			}
			else
			{
				source.Packed = rect();
				source.Frame = rect(0, 0, width, height);
			}

			sources.Add(source);
			return source;
		}

		private struct PackingNode
		{
			public bool Used;
			public rect Rect;
			public PackingNode* Right;
			public PackingNode* Down;

			public this(int x, int y, int w, int h)
			{
				Used = false;
				Rect = rect(x, y, w, h);
				Right = null;
				Down = null;
			}
		}

		private void Pack()
		{
			// Already been packed
			if (!HasUnpackedData)
				return;

			// Reset
			if (_packed != null)
				delete _packed;
			_packed = new Output();
			HasUnpackedData = false;

			// Nothing to pack
			if (sources.Count <= 0)
				return;

			// sort the sources by size
			sources.Sort(scope (a, b) => b.Packed.Width * b.Packed.Height - a.Packed.Width * a.Packed.Height);

			// make sure the largest isn't too large

			if (sources[0].Packed.Width > MaxSize || sources[0].Packed.Height > MaxSize)
				Runtime.Assert(false, "Source image is larger than max atlas size");

			// TODO: why do we sometimes need more than source images * 3?
			// for safety I've just made it 4 ... but it should really only be 3?

			int nodeCount = sources.Count * 4;
			let bufferPtr = new:ScopedAlloc! PackingNode[nodeCount]*;
			let buffer = Span<PackingNode>(bufferPtr, nodeCount);

			var padding = Math.Max(0, Padding);
			//var nodeIndex = 0;
			// using pointer operations here was faster
			let nodes = buffer;
			{
				int packed = 0, page = 0;
				while (packed < sources.Count)
				{
					if (sources[packed].Empty)
					{
						packed++;
						continue;
					}


					var from = packed;
					var nodePtr = &nodes[0];
					//var rootPtr = ref bufferPtr[nodeIndex++];
					//rootPtr = .(0, 0, sources[from].Packed.Width + padding, sources[from].Packed.Height + padding);

					var rootPtr = ResetNode(nodePtr++, 0, 0, sources[from].Packed.Width + padding, sources[from].Packed.Height + padding);
					while (packed < sources.Count)
					{
						if (sources[packed].Empty || sources[packed].DuplicateOf != null)
						{
							packed++;
							continue;
						}

						int w = sources[packed].Packed.Width + padding;
						int h = sources[packed].Packed.Height + padding;
						var node = FindNode(rootPtr, w, h);

						// try to expand
						if (node == null)
						{
							bool canGrowDown = (w <= rootPtr.Rect.Width) && (rootPtr.Rect.Height + h < MaxSize);
							bool canGrowRight = (h <= rootPtr.Rect.Height) && (rootPtr.Rect.Width + w < MaxSize);
							bool shouldGrowRight = canGrowRight && (rootPtr.Rect.Height >= (rootPtr.Rect.Width + w));
							bool shouldGrowDown = canGrowDown && (rootPtr.Rect.Width >= (rootPtr.Rect.Height + h));

							if (canGrowDown || canGrowRight)
							{
								// grow right
								if (shouldGrowRight || (!shouldGrowDown && canGrowRight))
								{
									var next = ResetNode(nodePtr++, 0, 0, rootPtr.Rect.Width + w, rootPtr.Rect.Height);
									next.Used = true;
									next.Down = rootPtr;
									next.Right = node = ResetNode(nodePtr++, rootPtr.Rect.Width, 0, w, rootPtr.Rect.Height);
									rootPtr = next;
								}
								// grow down
								else
								{
									var next = ResetNode(nodePtr++, 0, 0, rootPtr.Rect.Width, rootPtr.Rect.Height + h);
									next.Used = true;
									next.Down = node = ResetNode(nodePtr++, 0, rootPtr.Rect.Height, rootPtr.Rect.Width, h);
									next.Right = rootPtr;
									rootPtr = next;
								}
							}
						}

						// doesn't fit in this page
						if (node == null)
							break;

						// add
						node.Used = true;
						node.Down = ResetNode(nodePtr++, node.Rect.X, node.Rect.Y + h, node.Rect.Width, node.Rect.Height - h);
						node.Right = ResetNode(nodePtr++, node.Rect.X + w, node.Rect.Y, node.Rect.Width - w, h);

						sources[packed].Packed.X = node.Rect.X;
						sources[packed].Packed.Y = node.Rect.Y;


						packed++;
					}

					// get page size
					int pageWidth, pageHeight;
					if (PowerOfTwo)
					{
						pageWidth = 2;
						pageHeight = 2;
						while (pageWidth < rootPtr.Rect.Width)
							pageWidth *= 2;
						while (pageHeight < rootPtr.Rect.Height)
							pageHeight *= 2;
					}
					else
					{
						pageWidth = rootPtr.Rect.Width;
						pageHeight = rootPtr.Rect.Height;
					}

					// create each page
					{
						var bmp = new Image(pageWidth, pageHeight);
						_packed.Page = bmp;

						// create each entry for this page and copy its image data
						for (int i = from; i < packed; i++)
						{
							var source = sources[i];

							// do not pack duplicate entries yet
							if (source.DuplicateOf == null)
							{
								_packed.Entries[source.Name] = new Entry(source.Name, page, source.Packed, source.Frame);

								if (!source.Empty)
									bmp.SetPixels(source.Packed, source.Buffer);
							}
						}
					}

					page++;
				}
			}

			// make sure duplicates have entries
			if (CombineDuplicates)
			{
				for (var source in sources)
				{
					if (source.DuplicateOf != null)
					{
						var entry = _packed.Entries[source.DuplicateOf.Name];
						_packed.Entries[source.Name] = new Entry(source.Name, entry.Page, entry.Source, entry.Frame);
					}
				}
			}

			//return _packed;

			PackingNode* FindNode(PackingNode* root, int w, int h)
			{
				if (root.Used)
				{
					var r = FindNode(root.Right, w, h);
					return (r != null ? r : FindNode(root.Down, w, h));
				}
				else if (w <= root.Rect.Width && h <= root.Rect.Height)
				{
					return root;
				}

				return null;
			}

			PackingNode* ResetNode(PackingNode* node, int x, int y, int w, int h)
			{
				var node;
				node.Used = false;
				node.Rect = rect(x, y, w, h);
				node.Right = null;
				node.Down = null;
				return node;
			}
		}

		/*/// <summary>
		/// Removes all source data and removes the Packed Output
		/// </summary>
		public void Clear()
		{
			sources.Clear();
			duplicateLookup.Clear();
			_packed = new Output();
			HasUnpackedData = false;
		}*/

	}
}

