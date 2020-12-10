using System;
using System.Collections;
using System.IO;

namespace Atma
{
	/// <summary>
	/// A Texture Atlas
	/// </summary>
	public class Atlas2
	{
		private abstract class AssetMap
		{
			public readonly String Name = new .() ~ delete _;
			public readonly String Path = new .() ~ delete _;
			protected Assets _assets;
			protected Atlas2 _atlas;

			public this(Atlas2 atlas, StringView name, StringView path)
			{
				_atlas = atlas;
				_assets = _atlas._assets;
				Path.Set(path);
				Name.Set(name);
			}

			public abstract void Pack(Packer pack);
			public abstract void Finalize(Packer.Output output, Texture texture);
			public abstract void Changed();

			public int GetHashCode() => Path.GetHashCode();
		}

		private class AssetMapImage : AssetMap
		{
			private Texture _texture;
			private int2 size;
			private rect source;

			public this(Atlas2 atlas, StringView name, StringView path) : base(atlas, name, path)
			{
			}

			public override void Pack(Packer pack)
			{
				var image = _assets.LoadImage(Path);
				Assert.IsTrue(image != null);

				size = image.Size;
				pack.AddImage(Name, image);
				Log.Debug($"  Packing Texture [{Name}] @[{size}] -> {Path}");
			}

			public override void Finalize(Packer.Output output, Texture texture)
			{
				let entry = output.Entries[Name];
				_texture = texture;
				source = entry.Source;
				_atlas._subtextures.Add(Name, .(_texture, entry.Source, entry.Frame));
			}

			public override void Changed()
			{
				var image = _assets.LoadImage(Path);
				System.Diagnostics.Debug.Assert(image == null);
				System.Diagnostics.Debug.Assert(image.Size == size);

				_texture.SetData(source, image.Pixels);
			}
		}

		private class AssetMapAseprite : AssetMap
		{
			private struct AsepriteFrame
			{
				public Texture Texture;
				public int Index;
				public int Duration;
				public rect Source;
				public rect Framed;
				public int AnimationIndex;
			}

			public int2 Size;
			public int FrameCount => Frames.Count;

			public readonly List<AsepriteFrame> Frames = new .() ~ delete _;

			public this(Atlas2 atlas, StringView name, StringView path) : base(atlas, name, path)
			{
			}

			public override void Pack(Packer pack)
			{
				let image = _assets.LoadAseprite(Path);
				System.Diagnostics.Debug.Assert(image != null);
				Size = image.Size;

				Log.Debug($"  Packing [{Name}] with {image.Frames.Count} texture frames @{image.Width}x{image.Height}");
				let bitmap = new Image(image.Width, image.Height);
				for (var index < image.Frames.Count)
				{
					let frame = image.Frames[index];
					image.Frame(bitmap, index, index > 0, Color.Transparent);

					if (image.Frames.Count == 1)
						pack.AddPixels(Name, image.Width, image.Height, bitmap.Pixels);
					else
						pack.AddPixels(scope $"{Name}/{frame.Index}", image.Width, image.Height, bitmap.Pixels);

					AsepriteFrame f = ?;
					f.Index = index;
					f.Duration = frame.Duration;
					f.Source = .(0, 0, 0, 0);
					f.Texture = null;
					f.AnimationIndex = 0;
					Frames.Add(f);
				}

				//animations
				if (FrameCount > 1)
				{
					//single animation
					if (image.Tags == null)
					{
						var duration = 0;
						let animationIndex = _atlas._animations.Count;
						Frames[0].AnimationIndex = animationIndex;
						_atlas._animations.Add(new .(""));
						_atlas._animationLookup.Add(Name, _atlas._animations.Back);

						for (var k < FrameCount)
						{
							Frames[k].AnimationIndex = animationIndex;
							duration += Frames[k].Duration;
						}

						Log.Debug($"    Found Animation Frames: 0-{FrameCount}, Duration: {duration}ms ");
					}
					else
					{
						for (var i < image.Tags.Count)
						{
							let tag = image.Tags[i];
							let animationIndex = _atlas._animations.Count;
							var duration = 0;
							_atlas._animations.Add(new .(tag.Name));
							_atlas._animationLookup.Add(_atlas._stringPool.Get(scope $"{Name}/{tag.Name}"), _atlas._animations.Back);

							for (var k = tag.From; k <= tag.To; k++)
							{
								Frames[k].AnimationIndex = animationIndex;
								duration += Frames[k].Duration;
							}

							Log.Debug($"    Found Animation [{tag.Name}] :: Frames: {tag.From}-{tag.To}, Duration: {duration}ms ");
						}
					}
				}

				delete bitmap;
			}

			public override void Finalize(Packer.Output output, Texture texture)
			{
				for (var index < FrameCount)
				{
					var frame = ref Frames[index];
					let name = _atlas._stringPool.Get(FrameCount == 1 ? Name : scope $"{Name}/{frame.Index}");
					let entry = output.Entries[name];
					frame.Texture = texture;
					frame.Source = entry.Source;

					let subtexture = Subtexture(frame.Texture, entry.Source, entry.Frame);


					_atlas._subtextures.Add(name, .(frame.Texture, entry.Source, entry.Frame));

					//animations
					if (FrameCount > 1)
					{
						let animation = _atlas._animations[frame.AnimationIndex];
						animation.Add(subtexture, frame.Duration);
					}
				}
			}

			public override void Changed()
			{
				var aseprite = _assets.LoadAseprite(Path);
				if (FrameCount != aseprite.Frames.Count)
					Log.Warning("Aseprite [{0}] changed but had different frame count, expected [{1}] but got [{2}].", Path, FrameCount, aseprite.Frames.Count);
				else if (aseprite.Size != Size)
					Log.Warning("Aseprite [{0}] changed but had different size, expected [{1}] but got [{2}].", Path, Size, aseprite.Size);
				else
				{
					var image = new Image(Size);
					for (var i < FrameCount)
					{
						aseprite.Frame(image, i, i > 0, Color.Transparent);
						Frames[i].Texture.SetData(Frames[i].Source, image.Pixels);
					}
					delete image;
				}
				delete aseprite;
			}
		}

		//public readonly Texture _missingTexture ~ delete _;

		private readonly Assets _assets = Core.Assets;

		private StringPool _stringPool = new .() ~ delete _;

		private struct TexturePage : IDisposable
		{
			public readonly StringId ID;
			public readonly Texture Texture;

			public this(StringId id, Texture texture)
			{
				ID = id;
				Texture = texture;
			}

			public void Dispose()
			{
				delete Texture;
			}
		}

		private readonly Dictionary<String, Subtexture> _subtextures = new .() ~ delete _;
		public readonly ReadOnlyDictionary<String, Subtexture> Subtextures = .(_subtextures);

		private List<Animation> _animations = new .() ~ DeleteContainerAndItems!(_);

		private readonly Dictionary<String, Animation> _animationLookup = new .() ~ delete _;
		public readonly ReadOnlyDictionary<String, Animation> Animations = .(_animationLookup);

		private Dictionary<String, List<String>> _texturesToload = new .() ~ DeleteDictionaryAndItems!(_);
		private List<TexturePage> _textures = new .() ~ Release(_);
		private List<AssetMap> _assetMap = new .() ~ DeleteContainerAndItems!(_);
		private GraphicsManager _graphics;

		/// <summary>
		/// An empty Atlas
		/// </summary>
		public this() { }

		/// <summary>
		/// An Atlas created from an Image Packer, optionally premultiplying the textures
		/// </summary>
		public this(Assets assets)
		{
			Core.Emitter.AddObserver<CoreEvents.AssetChanged>(new => AssetChanged);

			_graphics = Core.Graphics;
		}

		private void AssetChanged(CoreEvents.AssetChanged assetChanged)
		{
			ReloadAsset(assetChanged.Path);
		}

		private void ReloadAsset(StringView path)
		{
			for (var it in _assetMap)
				if (it.Path == path)
					it.Changed();
		}

		public void AddDirectory(StringView page, StringView path)
		{
			let contentPath = scope String();
			Core.Assets.GetContentDirectory(path, contentPath);
			for (var it in Directory.EnumerateFiles(contentPath, "*.*"))
				Add(page, it);
		}

		public void Add(StringView page, FileFindEntry file)
		{
			let filePath = scope String();
			file.GetFilePath(filePath);
			Add(page, filePath);
		}

		public void Add(StringView page, StringView file)
		{
			Assert.IsFalse(_isBuilt);

			if (_texturesToload.TryAddAlt(page, var key, var ptr))
			{
				*key = _stringPool.Get(page);
				*ptr = new .();
			}

			let list = *ptr;
			list.Add(_stringPool.Get(file));

			let path = scope String();
			let filename = scope String();
			let fileext = scope String();

			System.IO.Path.GetFileNameWithoutExtension(file, filename);
			System.IO.Path.GetExtension(file, fileext);

			path.Set(file);
			path.RemoveFromEnd(fileext.Length);

			fileext.ToLower();

			let keyName = scope String();
			keyName.AppendF("{0}/{1}", page, filename);

			/*if (_subtextures.TryAddAlt(keyName, var keyPtr, var subPtr))
			{
				*keyPtr = new String(keyName);
				*subPtr = default;
			}

			return subPtr;*/
		}

		private bool _isBuilt = false;

		public void Finalize()
		{
			Assert.IsFalse(_isBuilt);
			_isBuilt = true;

			for (var page in _texturesToload.Keys)
			{
				let packer = scope Packer(page);
				packer.Trim = false;

				let assets = scope List<AssetMap>();
				Log.Debug($"Packing atlas page [{page}]");

				//packer.Padding = 0;
				//packer.Trim = false;
				for (var file in _texturesToload[page])
				{
					let fullPath = scope String();
					_assets.GetContentFile(file, fullPath);

					_assets.TrackAssetPath(fullPath);
					let filename = scope String();
					let fileext = scope String();

					System.IO.Path.GetFileNameWithoutExtension(file, filename);
					System.IO.Path.GetExtension(file, fileext);

					fileext.ToLower();
					switch (fileext) {
					case ".aseprite":
						assets.Add(new AssetMapAseprite(this, scope $"{page}/{filename}", fullPath));
					default:
						assets.Add(new AssetMapImage(this, scope $"{page}/{filename}", fullPath));
					}
				}



				for (var it in assets)
					it.Pack(packer);

				let output = packer.Packed;

				//System.Diagnostics.Debug.Assert(output.Pages.Count == 1);

				let texture = new Texture(output.Page);
				_textures.Add(TexturePage(packer.Name, texture));

				for (var it in assets)
					it.Finalize(output, texture);

				_assetMap.AddRange(assets);


				Log.Debug($" Atlas [{page}] Packed @{texture.Size.x}x{texture.Size.y} with {assets.Count} assets.");
			}
		}

		/// <summary>
		/// Gets or Sets a Subtexture by name
		/// </summary>
		public Subtexture this[StringView name]
		{
			get
			{
				Assert.IsTrue(_isBuilt);

				if (_subtextures.TryGetAlt(name, ?, let subtex))
					return subtex;

				Runtime.FatalError(StackStringFormat!("Missing texture [{0}]", name));
			}
			/*set
			{
				if (Subtextures.TryAddAlt(name, var key, var ptr))
					*key = new String(name);

				*ptr = value;
			}*/
		}

		public Texture GetTexture(StringId name)
		{
			for (var it in _textures)
				if (it.ID == name)
					return it.Texture;

			return null;
		}

		public AnimationPlayer GetAnimationPlayer(StringView name, bool loop = false, bool reverse = false)
		{
			if (_animationLookup.TryGetAlt(name, ?, let anim))
				return .(anim, loop, reverse);

			Runtime.FatalError(StackStringFormat!("Missing animation [{0}]", name));
		}
	}
}

