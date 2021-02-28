using System;
using System.IO;
using System.IO;
using System.Collections;
namespace Atma
{
//https://github.com/aseprite/aseprite/blob/master/docs/ase-file-specs.md

	public class Aseprite
	{
		typealias BYTE = uint8;
		typealias WORD = uint16;
		typealias SHORT = int16;
		typealias DWORD = uint32;
		typealias LONG = int32;
		typealias FIXED = float;

		typealias RGBA = uint8[4];
		typealias Grayscale = uint8[2];
		typealias Indexed = BYTE;

		[CRepr, Packed, Ordered]
		public struct Header
		{
			public enum ColorDepth : WORD
			{
				case Indexed = 8;
				case Grayscale = 16;
				case RGBA = 32;

				public int Bytes => (int)this / 8;
			}

			public enum HeaderFlags : DWORD
			{
				case LayerOpacity = 1;
			}

			public DWORD FileSize;//   File size
			public WORD MagicNumber;//   Magic number (0xA5E0)
			public WORD Frames;//   Frames
			public WORD Width;//   Width in pixels
			public WORD Height;//   Height in pixels
			public ColorDepth ColorDepth;//   Color depth (bits per pixel)
											 //		32 bpp = RGBA
											 //		16 bpp = Grayscale
											 //		8 bpp = Indexed
			public HeaderFlags Flags;//   Flags:
											 //		1 = Layer opacity has valid value
			public WORD Speed;//   Speed (milliseconds between frame, like in FLC files)
											   //		DEPRECATED: You should use the frame duration field
											   //		from each frame header
			private DWORD NOP0;//	Set be 0
			private DWORD NOP1;//	Set be 0
			public BYTE PaletteIndex;//	Palette entry (index) which represent transparent color
											   //		in all non-background layers (only for Indexed sprites).
			private BYTE[3] NOP2;//  Ignore these bytes
			public WORD TotalColors;//  Number of colors (0 means 256 for old sprites)
			public BYTE PixelWidth;//  Pixel width (pixel ratio is "pixel width/pixel height").
											   //		If this or pixel height field is zero, pixel ratio is 1:1
			public BYTE PixelHeight;//  Pixel height
			public SHORT GridX;//  X position of the grid
			public SHORT GridY;//  Y position of the grid
			public WORD GridWidth;//  Grid width (zero if there is no grid, grid size
											//	   is 16x16 on Aseprite by default)
			public WORD GridHeight;//  Grid height (zero if there is no grid)
			private BYTE[84] Reserved;//  For future (set to zero)
		}

		public class Chunk
		{
			public UserData UserData ~ delete _;
		}


		public class UserData
		{
			public enum UserDataFlags : DWORD
			{
				case Text = 1;
				case Color = 2;
			}

			public readonly UserDataFlags Flags;
			private readonly String _text ~ delete _;
			public readonly Color Color;

			public this(AsepriteReader ase)
			{
				ase.Read(&Flags);
				if (Flags.HasFlag(.Text))
				{
					_text = new String();
					ase.Read(_text);
				}

				if (Flags.HasFlag(.Color))
				{
					BYTE r = ?, g = ?, b = ?, a = ?;
					ase.Read(&r);
					ase.Read(&g);
					ase.Read(&b);
					ase.Read(&a);
					Color = .ToPremultiplied(r, g, b, a);
				}
			}

		}

		public class Tags
		{
			public class Tag
			{
				public enum LoopAnimation : BYTE
				{
					Forward,
					Reverse,
					PingPong
				}

				public readonly WORD From, To;
				public readonly LoopAnimation Animation;
				 //public readonly BYTE[3] TagColor;
				public readonly String Name = new String() ~ delete _;

				public this(AsepriteReader ase)
				{
					ase.Read(&From);
					ase.Read(&To);
					ase.Read(&Animation);
					ase.Skip(3);// skip tag color
					ase.Skip(8);//padding
					ase.Skip(1);//extra byte?
					ase.Read(Name);
				}
			}

			public readonly WORD Count;
			private List<Tag> _tags ~ DeleteContainerAndItems!(_);

			public Tag this[int index]
			{
				get => _tags[index];
			}

			public this(AsepriteReader ase)
			{
				ase.Read(&Count);
				ase.Skip(8);
				_tags = new .(Count);

				for (var i < Count)
					_tags.Add(new .(ase));
			}

			/*WORD        Number of tags
				BYTE[8]     For future (set to zero)
				+ For each tag
				  WORD      From frame
				  WORD      To frame
				  BYTE      Loop animation direction
							  0 = Forward
							  1 = Reverse
							  2 = Ping-pong
				  BYTE[8]   For future (set to zero)
				  BYTE[3]   RGB values of the tag color
				  BYTE      Extra byte (zero)
				  STRING    Tag name*/
		}

		public class Frame
		{
			public enum ChunkType : WORD
			{
				case OldPalleteA = 0x0004;//Ignore this chunk if you find the new palette chunk (0x2019) Aseprite
				// v1.1 saves both chunks 0x0004 and 0x2019 just for backward compatibility.
				case OldPalleteB = 0x0011;//Ignore this chunk if you find the new palette chunk (0x2019)
				case Layer = 0x2004;//In the first frame should be a set of layer chunks to determine the entire
				// layers layout:
				case Cel = 0x2005;//This chunk determine where to put a cel in the specified layer/frame.
				case CelExtra = 0x2006;//Adds extra information to the latest read cel.
				case ColorProfile = 0x2007;//Color profile for RGB or grayscale values.
				case Mask = 0x2016;// deprecated
				case Path = 0x2017;//never used
				case Tags = 0x2018;
				case Palette = 0x2019;
				case UserData = 0x2020;//Insert this user data in the last read chunk. E.g. If we've read a layer,
				// this user data belongs to that layer, if we've read a cel, it belongs to that cel, etc.
				case Slice = 0x2022;


			}

			private readonly Aseprite _aseprite;

			public readonly DWORD Length;//       Bytes in this frame
			private readonly WORD MagicNumber;//      Magic number (always 0xF1FA)
			private readonly WORD TotalChunksOld;//       Old field which specifies the number of "chunks"
							//in this frame. If this value is 0xFFFF, we might
							//have more chunks to read in this frame
							//(so we have to use the new field)
			public readonly WORD Duration;//       Frame duration (in milliseconds)
			private readonly DWORD TotalChunksNew;//      New field which specifies the number of "chunks"
							//in this frame (if this is 0, use the old field)

			public DWORD TotalChunks => TotalChunksNew != 0 ? TotalChunksNew : TotalChunksOld;

			public readonly int Index;
			//private List<Palette> _palettes = new .() ~ DeleteContainerAndItems!(_);
			//private List<ColorProfile> _colorProfiles = new .() ~ DeleteContainerAndItems!(_);
			//private List<Layer> _layers = new .() ~ DeleteContainerAndItems!(_);
			private List<Cel> _cels = new .() ~ DeleteContainerAndItems!(_);

			/*private Palette _palette ~ delete _;
			public Palette Palette => _palette;*/

			//public ReadOnlyList<Palette> Palette => .(_palettes);
			//public ReadOnlyList<ColorProfile> ColorProfiles => .(_colorProfiles);
			//public ReadOnlyList<Layer> Layers => .(_layers);
			public ReadOnlyList<Cel> Cels => .(_cels);

			public this(Aseprite aseprite, AsepriteReader ase, int index)
			{
				_aseprite = aseprite;
				Index = index;

				ase.Read(&Length);
				ase.Read(&MagicNumber);
				Runtime.Assert(MagicNumber == 0xF1FA);

				ase.Read(&TotalChunksOld);
				ase.Read(&Duration);
				ase.Skip(2);
				ase.Read(&TotalChunksNew);
			}

			public void ReadChunks(AsepriteReader ase)
			{
				Chunk last = ?;
				for (var c < TotalChunks)
				{
					DWORD size = ?;
					WORD type = ?;
					ase.Read(&size);
					ase.Read(&type);

					let bufferSize = size - sizeof(WORD) - sizeof(DWORD);
					let chunkType = (ChunkType)type;

					switch (chunkType) {
					case .Cel:
						_cels.Add(new Cel(_aseprite, this, ase, bufferSize));
						last = _cels.Back;
					case .Layer:
						_aseprite.[Friend]_layers.Add(new Layer(ase, _aseprite.[Friend]_layers.Count, _aseprite._header.Flags.HasFlag(.LayerOpacity)));
						last = _aseprite.[Friend]_layers.Back;
					case .ColorProfile:
						_aseprite.[Friend]_colorProfile = new ColorProfile(ase);
						last = _aseprite.[Friend]_colorProfile;
					case .Palette:
						Runtime.Assert(_aseprite.[Friend]_palette == null);
						_aseprite.[Friend]_palette = new Palette(ase);
						last = _aseprite.[Friend]_palette;
					case .UserData:
						let userData = new UserData(ase);
						if (last != null)
							last.UserData = userData;
					case .OldPalleteA: fallthrough;
					case .OldPalleteB:
						ase.Skip(bufferSize);
						last = null;
					case .Tags:
						_aseprite._tags = new Tags(ase);
					default:
						ase.Skip(bufferSize);
						last = null;

						Log.Warning(StackStringFormat!("Aseprite chunk type [{0}] is not implemented.", chunkType));
						//Runtime.FatalError(StackStringFormat!("Aseprite chunk type [{0}] is not implemented.",
					// chunkType)); Console.WriteLine();
					}

					/*switch (chunk.Type) {
					case .CelChunk:
					default:
					}*/
				}
			}

			/*public void Apply(BlendMode blend, Image bitmap, uint opacity)
			{
				Runtime.Assert(bitmap.Width == _aseprite._header.Width && bitmap.Width == _aseprite._header.Width,
		"Aseprite width and height didn't match the target bitmap."); //for (var layer in _layers)
				{
					/*let blend = layer.BlendMode;
					if (layer.Flags.HasFlag(.Visible))*/
					{
						//for (var cel in _cels)
						{
							/*if (cel.Layer != layer.Index)
								continue;*/

							let opacity = (uint8)(((int)cel.Opacity * opacity) / 255);
							var pxLen = bitmap.Pixels.Length;

							for (int sx = Math.Max(0, -cel.X),int right = Math.Min(cel.Width,
		(int)_aseprite._header.Width - cel.X); sx < right; sx++)
							{
								int dx = cel.X + sx;
								int dy = (int)cel.Y * _aseprite._header.Width;

								for (int sy = Math.Max(0, -cel.Y),int bottom = Math.Min(cel.Height,
		(int)_aseprite._header.Height - cel.Y); sy < bottom; sy++,dy += _aseprite._header.Width)
								{
									if (dx + dy >= 0 && dx + dy < pxLen)
										blend.Blend(&bitmap.Pixels[dx + dy], cel.Pixels[sx + sy * cel.Width], opacity);
								}
							}
						}
					}
				}
			}*/
		}

		public class ColorProfile : Chunk
		{
			public enum ColorProfileType : WORD
			{
				case None = 0;
				case sRGB = 1;
				case ICC = 2;
			}

			public enum ColorProfileFlags : WORD
			{
				case FixedGamma = 1;
			}

			public class ICC
			{
				public BYTE[] Data ~ delete _;
				public this(AsepriteReader ase)
				{
					DWORD length = ?;
					ase.Read(&length);

					Data = new .[length];
					ase.Read(Data);
				}
			}

			public ColorProfileType Type;
			public ColorProfileFlags Flags;
			public FIXED Gamma;
			public ICC ICC ~ delete _;

			public this(AsepriteReader ase)
			{
				ase.Read(&Type);
				ase.Read(&Flags);
				ase.Read(&Gamma);
				ase.Skip(8);

				if (Type == .ICC)
					ICC = new .(ase);
			}

		}

		public class Palette : Chunk
		{
			/*
			DWORD       New palette size (total number of entries)
			DWORD       First color index to change
			DWORD       Last color index to change
			BYTE[8]     For future (set to zero)
			+ For each palette entry in [from,to] range (to-from+1 entries)
			  WORD      Entry flags:
						  1 = Has name
			  BYTE      Red (0-255)
			  BYTE      Green (0-255)
			  BYTE      Blue (0-255)
			  BYTE      Alpha (0-255)
			  + If has name bit in entry flags
				STRING  Color name
			*/

			public class PaletteEntry
			{
				/*
				WORD      Entry flags:
							1 = Has name
				BYTE      Red (0-255)
				BYTE      Green (0-255)
				BYTE      Blue (0-255)
				BYTE      Alpha (0-255)
				+ If has name bit in entry flags
				  STRING  Color name
				*/

				public enum PaletteEntryFlags : WORD
				{
					case HasName = 1;
				}

				public readonly DWORD Index;
				public readonly PaletteEntryFlags Flags;
				public readonly BYTE Red;
				public readonly BYTE Green;
				public readonly BYTE Blue;
				public readonly BYTE Alpha;
				public readonly String Name = new .() ~ delete _;

				public Color Color => .(Red, Green, Blue, Alpha);

				public this(DWORD index, AsepriteReader ase)
				{
					Index = index;
					ase.Read(&Flags);
					ase.Read(&Red);
					ase.Read(&Green);
					ase.Read(&Blue);
					ase.Read(&Alpha);
					if (Flags.HasFlag(.HasName))
					{
						ase.Read(Name);
					}
				}

			}

			public DWORD Size;
			public DWORD FirstIndex;
			public DWORD LastIndex;

			public List<PaletteEntry> Entries = new .() ~ DeleteContainerAndItems!(_);

			//do I need to offset index by firstindex?
			public Color this[int index] { get => Entries[index].Color; }

			public this(AsepriteReader ase)
			{
				ase.Read(&Size);
				ase.Read(&FirstIndex);
				ase.Read(&LastIndex);
				ase.Skip(8);

				for (var i < Size)
					Entries.Add(new PaletteEntry(FirstIndex + i, ase));
			}
		}

		public class Layer : Chunk
		{
			public enum LayerFlags : WORD
			{
				case Visible = 1;
				case Editable = 2;
				case LockMovement = 3;
				case Background = 8;
				case PreferLinkedCels = 16;
				case LayerGroupCollapsed = 32;
				case ReferenceLayer = 64;
			}

			public enum LayerTypes : WORD
			{
				case Normal = 0;
				case Group = 1;
			}


			public enum BlendMode : WORD
			{
				case Normal = 0;
				case Multiply = 1;
				case Screen = 2;
				case Overlay = 3;
				case Darken = 4;
				case Lighten = 5;
				case ColorDodge = 6;
				case ColorBurn = 7;
				case HardLight = 8;
				case SoftLight = 9;
				case Difference = 10;
				case Exclusion = 11;
				case Hue = 12;
				case Saturation = 13;
				case Color = 14;
				case Luminosity = 15;
				case Addition = 16;
				case Subtract = 17;
				case Divide = 18;

				/*[Inline]
				public void Blend(Color* dest, Color src, uint8 opacity)
				{
					switch (this) {
					case .Normal:
						if (src.A != 0)
						{
							if (dest.A == 0)
							{

								//let c = Atma.Math.Color.ToPremultiplied(src.R, src.G, src.B, (uint8)((int)src.A *
								// opacity / 255));
								*dest = Atma.Math.Color.ToPremultiplied(src.R, src.G, src.B, (uint8)((int)src.A *
				opacity / 255)); //*dest = .(src.R, src.G, src.B, (uint8)((int)src.A * opacity / 255)); /*if(dest.A == 0
				&& src.A != 0 && src.A != 0xff){ System.Diagnostics.Debug.SafeBreak();
								}

								var sa = MUL_UN8(src.A, opacity);
								var ra = dest.A + sa - MUL_UN8(dest.A, sa);

								dest.R = (uint8)(dest.R + ((int)src.R - dest.R) * sa / ra);
								dest.G = (uint8)(dest.G + ((int)src.G - dest.G) * sa / ra);
								dest.B = (uint8)(dest.B + ((int)src.B - dest.B) * sa / ra);
								dest.A = (uint8)ra;*/
							}
							else
							{
								var src;
								var sa = MUL_UN8(src.A, opacity);
								var ra = dest.A + sa - MUL_UN8(dest.A, sa);

								dest.R = (uint8)(dest.R + ((int)src.R - dest.R) * sa / ra);
								dest.G = (uint8)(dest.G + ((int)src.G - dest.G) * sa / ra);
								dest.B = (uint8)(dest.B + ((int)src.B - dest.B) * sa / ra);
								dest.A = (uint8)ra;
							}
						}
					default:
						Runtime.FatalError(StackStringFormat!("Aseprite blend mode [{0}] not supported.", this));
					}
				}*/

				[Inline]
				public Color Blend(Color dest, Color src, uint8 opacity)
				{
					switch (this) {
					case .Normal:
						if (src.A != 0)
						{
							if (dest.A == 0)
							{

								//let c = Atma.Math.Color.ToPremultiplied(src.R, src.G, src.B, (uint8)((int)src.A *
								// opacity / 255));
								return .(src.R, src.G, src.B, (uint8)((int)src.A * opacity / 255));
								//return Atma.Math.Color.ToPremultiplied(src.R, src.G, src.B, (uint8)((int)src.A *
							// opacity / 255)); *dest = .(src.R, src.G, src.B, (uint8)((int)src.A * opacity / 255));
								/*if(dest.A == 0 && src.A != 0 && src.A != 0xff){
									System.Diagnostics.Debug.SafeBreak();
								}

								var sa = MUL_UN8(src.A, opacity);
								var ra = dest.A + sa - MUL_UN8(dest.A, sa);

								dest.R = (uint8)(dest.R + ((int)src.R - dest.R) * sa / ra);
								dest.G = (uint8)(dest.G + ((int)src.G - dest.G) * sa / ra);
								dest.B = (uint8)(dest.B + ((int)src.B - dest.B) * sa / ra);
								dest.A = (uint8)ra;*/
							}
							else
							{
								var sa = MUL_UN8(src.A, opacity);
								var ra = dest.A + sa - MUL_UN8(dest.A, sa);
								var dest;
								dest.R = (uint8)(dest.R + ((int)src.R - dest.R) * sa / ra);
								dest.G = (uint8)(dest.G + ((int)src.G - dest.G) * sa / ra);
								dest.B = (uint8)(dest.B + ((int)src.B - dest.B) * sa / ra);
								dest.A = (uint8)ra;
								return dest;
							}
						}
						else
							return dest;
					default:
						Runtime.FatalError(StackStringFormat!("Aseprite blend mode [{0}] not supported.", this));
					}
				}

				[Inline]
				private static int MUL_UN8(int a, int b)
				{
					var t = (a * b) + 0x80;
					return (((t >> 8) + t) >> 8);
				}
			}

			public readonly int Index;
			public readonly LayerFlags Flags;
			public readonly LayerTypes Type;
			public readonly WORD LayerChildLevel;
			public readonly WORD DefaultWidth;
			public readonly WORD DefaultHeight;
			public readonly BlendMode BlendMode;
			public readonly BYTE Opacity;
			public readonly String Name = new .() ~ delete _;

			private readonly List<Cel> _cels = new .() ~ DeleteContainerAndItems!(_);

			public ReadOnlyList<Cel> Cels => .(_cels);

			public this(AsepriteReader ase, int index, bool opacityEnabled)
			{
				Index = index;
				ase.Read(&Flags);
				ase.Read(&Type);
				ase.Read(&LayerChildLevel);
				ase.Read(&DefaultWidth);
				ase.Read(&DefaultHeight);
				ase.Read(&BlendMode);
				ase.Read(&Opacity);
				ase.Skip(3);
				ase.Read(Name);

				if (!opacityEnabled)
					Opacity = 255;
			}

		}

		public class Cel : Chunk
		{
			public enum CelType : WORD
			{
				case Raw = 0;
				case Linked = 1;
				case Compressed = 2;
			}

			private readonly Aseprite _aseprite;
			private readonly Frame _frame;

			public readonly WORD Layer;
			public readonly SHORT X;
			public readonly SHORT Y;
			public readonly BYTE Opacity;
			public readonly CelType CelType;

			public readonly WORD Width;
			public readonly WORD Height;
			public Color[] Pixels;

			public this(Aseprite aseprite, Frame frame, AsepriteReader ase, int bufferSize)
			{
				_aseprite = aseprite;
				_frame = frame;
				ase.Read(&Layer);
				ase.Read(&X);
				ase.Read(&Y);
				ase.Read(&Opacity);
				ase.Read(&CelType);
				ase.Skip(7);

				if (CelType == .Raw)
				{
					ase.Read(&Width);
					ase.Read(&Height);
					Pixels = new Color[Width * Height];

					if (Width * Height > 0)
					{
						let pixels = new BYTE[Width * Height * (int)_aseprite._header.ColorDepth.Bytes];
						ase.Read(pixels);
						GetPixels(pixels, Pixels, _aseprite._header.ColorDepth, _aseprite.[Friend]_palette);
						delete pixels;
					}
				}
				else if (CelType == .Compressed)
				{
					ase.Read(&Width);
					ase.Read(&Height);

					let w = Math.Max(Width, _aseprite.Width);
					let h = Math.Max(Height, _aseprite.Height);
					Pixels = new Color[w * h];

					if (Width * Height > 0)
					{
						let pixels = new BYTE[w * h * (int)_aseprite._header.ColorDepth.Bytes];
						let zipData = new BYTE[bufferSize - 20];//16 bytes for Cel and 4 bytes for width/height
						var dest = pixels.Count;

						ase.Read(zipData);

						let result = MiniZ.MiniZ.Uncompress(&pixels[0], ref dest, &zipData[0], zipData.Count);
						//let result = MiniZ.MiniZ.Uncompress(&pixels[0], ref dest, &zipData[0], zipData.Count);
						Runtime.Assert(result == .OK);

						GetPixels(pixels, Pixels, _aseprite._header.ColorDepth, _aseprite.[Friend]_palette);
						delete zipData;
						delete pixels;
					}
				}
				else if (CelType == .Linked)
				{
					WORD frameIndex = ?;
					ase.Read(&frameIndex);

					let linkedFrame = _aseprite._frames[frameIndex];
					let cel = linkedFrame.Cels.Back;
					Width = cel.Width;
					Height = cel.Height;
					Pixels = cel.Pixels;
				}
			}

			private void GetPixels(BYTE[] bytes, Color[] pixels, Header.ColorDepth mode, Palette palette)
			{
				int len = pixels.Count;
				if (mode == .RGBA)
				{
					for (int p = 0,int b = 0; p < len; p++,b += 4)
					{
						/*pixels[p].R = (uint8)((int)bytes[b + 0] * bytes[b + 3] / 255);
						pixels[p].G = (uint8)((int)bytes[b + 1] * bytes[b + 3] / 255);
						pixels[p].B = (uint8)((int)bytes[b + 2] * bytes[b + 3] / 255);*/
						pixels[p].R = (uint8)bytes[b + 0];
						pixels[p].G = (uint8)bytes[b + 1];
						pixels[p].B = (uint8)bytes[b + 2];

						pixels[p].A = bytes[b + 3];
					}
				}
				else if (mode == .Grayscale)
				{
					for (int p = 0,int b = 0; p < len; p++,b += 2)
					{
						//pixels[p].R = pixels[p].G = pixels[p].B = (uint8)((int)bytes[b + 0] * bytes[b + 1] / 255);
						pixels[p].R = pixels[p].G = pixels[p].B = bytes[b + 0];
						pixels[p].A = bytes[b + 1];
					}
				}
				else if (mode == .Indexed)
				{
					for (int p = 0; p < len; p++)
						pixels[p] = palette[bytes[p]];
				}
			}

			public void Apply(Layer layer, Image bitmap)
			{
				Runtime.Assert(bitmap.Width == _aseprite._header.Width && bitmap.Width == _aseprite._header.Width, "Aseprite width and height didn't match the target bitmap.");

				let blend = layer.BlendMode;
				let opacity = (uint8)(((int)Opacity * layer.Opacity) / 255);
				var pxLen = bitmap.Pixels.Length;

				for (int sx = Math.Max(0, -X),int right = Math.Min(Width, (int)_aseprite._header.Width - X); sx < right; sx++)
				{
					int dx = X + sx;
					int dy = (int)Y * _aseprite._header.Width;

					for (int sy = Math.Max(0, -Y),int bottom = Math.Min(Height, (int)_aseprite._header.Height - Y); sy < bottom; sy++,dy += _aseprite._header.Width)
						if (dx + dy >= 0 && dx + dy < pxLen)
							bitmap.Pixels[dx + dy] = blend.Blend(bitmap.Pixels[dx + dy], Pixels[sx + sy * Width], opacity);
							//blend.Blend(&bitmap.Pixels[dx + dy], Pixels[sx + sy * Width], opacity);
				}
			}

			/*
			//7D342FFF + 6a9b4e80 = 74673eff but we got (F3673EFF)
			Dirt: RGBA [00000000] -> RGBA [7D342FFF] by RGBA [7D342FFF]
			Grass: RGBA [7D342FFF] -> RGBA [F3673EFF] by RGBA [6A9B4E80]
			*/

			public ~this()
			{
				if (CelType != .Linked)
					delete Pixels;
			}
		}

		private readonly Header _header;
		private List<Layer> _layers = new .() ~ DeleteContainerAndItems!(_);
		private Palette _palette ~ delete _;
		private ColorProfile _colorProfile ~ delete _;

		private Tags _tags ~ delete _;
		public Tags Tags => _tags;

		private String _path = new .() ~ delete _;
		private List<Frame> _frames = new .() ~ DeleteContainerAndItems!(_);
		private String _name = new .() ~ delete _;
		public int Width => _header.Width;
		public int Height => _header.Height;

		public int2 Size => .(Width, Height);

		public StringView Name => _name;

		public ReadOnlyList<Frame> Frames => .(_frames);

		public this(StringView path)
		{
			_path.Set(path);

			var sr = new StreamReader();
			Runtime.Assert(sr.Open(path) == .Ok(?));

			let ase = AsepriteReader(sr);
			ase.Read(&_header);

			for (var f < _header.Frames)
			{
				let frame = new Frame(this, ase, _frames.Count);
				_frames.Add(frame);

				frame.ReadChunks(ase);
			}

			delete sr;
		}

		public void Pack(StringView name, Packer packer)
		{
			//we are only packing the final result, idk if there is benefit to packing each cel?
			let bitmap = new Image(_header.Width, _header.Height);
			for (var index < _frames.Count)
			{
				let frame = _frames[index];
				Frame(bitmap, index, index > 0, Color.Transparent);

				if (_frames.Count == 1)
					packer.AddPixels(name, _header.Width, _header.Height, bitmap.Pixels);
				else
					packer.AddPixels(StackStringFormat!("{0}/{1}", name, frame.Index), _header.Width, _header.Height, bitmap.Pixels);

				bitmap.Clear(.(0, 0, 0, 0));
			}
			delete bitmap;
		}

		public void Frame(Image bitmap, int index, bool clear = false, Color clearColor = Color.Transparent)
		{
			Runtime.Assert(bitmap.Size == this.Size);
			Runtime.Assert(index >= 0 && index < _frames.Count);

			if (clear)
				bitmap.Clear(clearColor);

			let frame = _frames[index];
			for (var cel in frame.Cels)
			{
				let layer = _layers[cel.Layer];
				if (layer.Flags.HasFlag(.Visible))
				{
					cel.Apply(layer, bitmap);
				}
			}
			bitmap.Premultiply();
		}

		public struct AsepriteReader
		{
			private readonly StreamReader _stream;
			public this(StreamReader stream)
			{
				_stream = stream;
			}

			public void Skip(int count)
			{
				var size = count;
				while (size-- > 0)
				{
					let r = _stream.Read();
					switch (r) {
					case .Ok(let val):
					case .Err:
						Runtime.FatalError(StackStringFormat!("Failed to read byte array [{0}] from the Aseprite file.", count));
					}
				}
			}

			public void Read<T>(T* t)
			{
				var addr = (uint8*)t;
				var size = sizeof(T);
				while (size-- > 0)
				{
					let r = _stream.Read();
					switch (r) {
					case .Ok(let val): *addr = (uint8)val;
					case .Err:
						Runtime.FatalError(StackStringFormat!("Failed to read '{0}' from the Aseprite file.", typeof(T)));
					}
					addr++;
				}
			}

			public void Read(BYTE[] data)
			{
				var addr = (uint8*)&data[0];
				var size = data.Count;
				while (size-- > 0)
				{
					let r = _stream.Read();
					switch (r) {
					case .Ok(let val): *addr = (uint8)val;
					case .Err:
						Runtime.FatalError(StackStringFormat!("Failed to read byte array [{0}] from the Aseprite file.", data.Count));
					}
					addr++;
				}
			}

			public void Read(char8[] data)
			{
				var addr = &data[0];
				var size = data.Count;
				while (size-- > 0)
				{
					let r = _stream.Read();
					switch (r) {
					case .Ok(let val): *addr = val;
					case .Err:
						Runtime.FatalError(StackStringFormat!("Failed to read byte array [{0}] from the Aseprite file.", data.Count));
					}
					addr++;
				}
			}

			public void Read(String data)
			{
				WORD length = ?;
				Read(&length);

				var buffer = scope char8[length];
				Read(buffer);

				let view = StringView(&buffer[0], length);
				data.Set(view);
			}
		}

	}
}
