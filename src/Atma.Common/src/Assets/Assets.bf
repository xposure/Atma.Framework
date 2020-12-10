using System;
using System.Collections;
using System.IO;
using System.Threading;

namespace Atma
{
	public class Assets
	{
		public interface IAsset
		{
			public bool Reload(AssetPath[] pathes);
		}

		public class AssetTracker
		{
			private AssetPath[] _pathes ~ delete _;
			private IAsset _asset;

			public this(IAsset asset, params AssetPath[] pathes)
			{
				_pathes = new .[pathes.Count];
				pathes.CopyTo(_pathes);
				_asset = asset;
			}

			public bool Check()
			{
				if (_asset == null)
					return true;

				var isChanged = false;
				for (var it in ref _pathes)
					isChanged |= it.IsChanged;

				if (isChanged)
				{
					if (!_asset.Reload(_pathes))
						Log.Error($"Failed to reload asset.");
				}

				return isChanged;
			}
		}

		public struct AssetPath
		{
			private readonly String _path;
			private DateTime _lastWrite;
			private double _timer = 0;

			public DateTime LastWrite => _lastWrite;
			public StringView Path => _path;

			public this(String path)
			{
				_path = path;
				_lastWrite = _path == null ? DateTime.Now : System.IO.File.GetLastWriteTime(path);
			}

			public bool ReadAllText(String output)
			{
				return System.IO.File.Exists(_path) && System.IO.File.ReadAllText(_path, output) case .Ok(?);
			}

			public bool IsChanged
			{
				get mut
				{
					if (_path == null)
						return false;

					if (_timer == 0)
					{
						//let filewrite = ;
						if (System.IO.File.GetLastWriteTime(Path) case .Ok(let filewrite))
						{
							if (filewrite != _lastWrite)
								_timer = Time.Elapsed + 0.100;
						}
					}
					else if (_timer < Time.Elapsed)
					{
						_timer = 0;
						_lastWrite = System.IO.File.GetLastWriteTime(Path);
						Log.Debug(StackStringFormat!("Detected asset [{0}] changed.", _path));
						return true;
					}

					return false;
				}
			}
		}

		public class AssetList
		{
			public readonly Type Type;

			public this(Type type)
			{
				Type = type;
			}
		}

		public class AssetList<T> : AssetList
			where T : delete
		{
			public readonly Dictionary<int, T> Assets = new .() ~ Release(_);

			public this() : base(typeof(T)) { }
		}

		private String _contentRoot = new String() ~ delete _;

		public StringView ContentRoot => _contentRoot;

		private List<AssetTracker> _assetTrackers = new .() ~ Release(_);
		private Dictionary<int, AssetList> _assets = new .() ~ Release(_);

		private StringPool _stringPool = new .() ~ delete _;

		private List<AssetPath> _assetWatcher = new .() ~ delete _;

		public Event<delegate void(StringView)> AssetChanged = default ~ AssetChanged.Dispose();

		private int _hotreloadIndex = -1;

		protected static extern SpriteFont PlatformLoadFont(StringView path, int size);
		protected static extern Image PlatformLoadImage(StringView path);

		public this(GraphicsManager graphics, StringView contentRoot)
		{
			_contentRoot.Set(contentRoot);
		}

#if !DEBUG
		[SkipCall]
#endif
		public void CheckForChangedAssets()
		{
			if (_assetWatcher.Count > 0)
			{
				_hotreloadIndex = (_hotreloadIndex + 1) % _assetWatcher.Count;
				var aw = &_assetWatcher[_hotreloadIndex];

				if (aw.IsChanged)
					AssetChanged.Invoke(aw.Path);
			}

			for (var it in _assetTrackers)
				it.Check();
		}

		public Aseprite LoadAseprite(StringView path)
		{
			let filePath = scope String();

			if (!GetContentFile(path, filePath))
				return null;

			filePath.ToLower();
			let key = filePath.GetHashCode();

			let assetList = GetAssetList<Aseprite>();
			if (assetList.Assets.TryAdd(key, ?, var ptr))
			{
				let ext = scope String();
				System.IO.Path.GetExtension(path, ext);
				ext.ToLower();
				switch (ext) {
				case ".aseprite":
					*ptr = new Aseprite(path);
				default:
					Runtime.FatalError(scope $"Invalid extension [{ext}].");
				}
			}

			return *ptr;
		}

		public bool GetContentDirectory(StringView path, String directoryPath)
		{
			if (!System.IO.Path.IsPathRooted(path))
			{
				directoryPath.Append(ContentRoot);
				if (!(path.StartsWith('\\') || path.StartsWith('/')))
					directoryPath.Append(Path.DirectorySeparatorChar);

				directoryPath.Append(path);
			}
			else
				directoryPath.Set(path);

			if (!Directory.Exists(directoryPath))
			{
				Log.Warning("Directory not found {0}", directoryPath);
				return false;
			}
			return true;
		}

		public bool GetContentFile(StringView path, String filePath)
		{
			if (!System.IO.Path.IsPathRooted(path))
			{
				filePath.Append(ContentRoot);
				if (!(path.StartsWith('\\') || path.StartsWith('/')))
					filePath.Append(Path.DirectorySeparatorChar);

				filePath.Append(path);
			}
			else
				filePath.Set(path);

			if (!File.Exists(filePath))
			{
				Log.Warning("File not found {0}", filePath);
				return false;
			}
			return true;
		}

		public Image LoadImage(StringView path)
		{
			let filePath = scope String();

			if (!GetContentFile(path, filePath))
				return null;

			filePath.ToLower();
			let key = filePath.GetHashCode();
			let assetList = GetAssetList<Image>();
			if (assetList.Assets.TryAdd(key, ?, var ptr))
			{
				let ext = scope String();
				System.IO.Path.GetExtension(filePath, ext);
				ext.ToLower();
				switch (ext) {
				case ".aseprite":
					let ase = scope Aseprite(filePath);
					let image = new Image(ase.Width, ase.Height);
					ase.Frame(image, 0);
					*ptr = image;
				default:
					*ptr = PlatformLoadImage(filePath);
				}
			}

			return *ptr;
		}

		private AssetList<T> GetAssetList<T>()
			where T : delete
		{
			let id = typeof(T).TypeId;
			if (_assets.TryAdd(id, ?, var ptr))
				*ptr = new AssetList<T>();

			return (AssetList<T>)*ptr;
		}

		public Texture LoadTexture(StringView path)
		{
			let filePath = scope String();

			if (!GetContentFile(path, filePath))
				return null;

			filePath.ToLower();
			let key = filePath.GetHashCode();

			let assetList = GetAssetList<Texture>();
			if (assetList.Assets.TryAdd(key, ?, var ptr))
			{
				let ext = scope String();
				System.IO.Path.GetExtension(path, ext);
				ext.ToLower();
				switch (ext) {
				case ".aseprite":
					let ase = scope Aseprite(filePath);
					let image = new Image(ase.Width, ase.Height);
					ase.Frame(image, 0);

					let texture = new Texture(image);
					*ptr = texture;
					//TrackAssetPath(filePath);
					delete image;
				default:
					*ptr = LoadTexture(path);
				}
			}

			return *ptr;
		}

		public Shader LoadShader(StringView path)
		{
			let vert = scope String();
			vert.Set(path);
			vert.Append(".vert");

			let frag = scope String();
			frag.Set(path);
			frag.Append(".frag");
			Log.Debug($"Loading shader [{path}]");
			return LoadShader(vert, frag);
		}

		public Shader LoadShader(StringView vertexPath, StringView fragmentPath)
		{
			let keyString = scope String();
			keyString.Append(vertexPath);
			keyString.Append(fragmentPath);

			let key = keyString.GetHashCode();
			let assetList = GetAssetList<Shader>();
			if (assetList.Assets.TryAdd(key, ?, var ptr))
			{
				let vp = scope $"{ContentRoot}/{vertexPath}";
				let fp = scope $"{ContentRoot}/{fragmentPath}";
				if (!System.IO.File.Exists(vp)) Runtime.FatalError(scope $"Vertex file missing: {vertexPath}");
				if (!System.IO.File.Exists(fp)) Runtime.FatalError(scope $"Fragment file missing: {fragmentPath}");

				let vertex = scope String();
				let frag = scope String();

				if (System.IO.File.ReadAllText(vp, vertex) case .Err(let err)) Runtime.FatalError(scope $"{err}");
				if (System.IO.File.ReadAllText(fp, frag) case .Err(let err)) Runtime.FatalError(scope $"{err}");

				let shaderSource = scope ShaderSource(vertex, frag);
				let shader = new Shader(shaderSource);

				TrackAsset(shader, vp, fp);

				shader.[Friend]_assetKey = key;
				shader.[Friend]_assets = this;


				*ptr = shader;
			}

			return *ptr;
		}

#if !DEBUG
		[SkipCall]
#endif
		public AssetTracker TrackAsset(IAsset asset, params StringView[] pathes)
		{
			let ap = scope AssetPath[pathes.Count];
			for (var i < pathes.Count)
				ap[i] = .(_stringPool.Get(pathes[i]));

			let tracker = new AssetTracker(asset, params ap);
			_assetTrackers.Add(tracker);
			return tracker;
		}

		public AssetPath TrackAssetPath(StringView path)
		{
			for (var it in _assetWatcher)
				if (it.Path == path)
					return default;

			let ap = AssetPath(_stringPool.Get(path));
			_assetWatcher.Add(ap);
			return ap;
		}

		public SpriteFont LoadFont(StringView path, int size)
		{
			let filePath = scope String();

			if (!GetContentFile(path, filePath))
				return null;

			filePath.ToLower();
			let key = filePath.GetHashCode();

			let assetList = GetAssetList<SpriteFont>();
			if (assetList.Assets.TryAdd(key, ?, var ptr))
			{
				let ext = scope String();
				System.IO.Path.GetExtension(path, ext);
				ext.ToLower();
				switch (ext) {
				case ".ttf":
					*ptr = PlatformLoadFont(filePath, size);
				default:
					*ptr = null;
				}
			}

			return *ptr;
		}

		public void Unload(Shader shader)
		{
			let assetList = GetAssetList<Shader>();
			assetList.Assets.Remove(shader.[Friend]_assetKey);
			StopTracking(shader);
		}

		private void StopTracking(IAsset asset)
		{
			let index = _assetTrackers.IndexOf( (tracker) => tracker.[Friend]_asset == asset);
			if (index != -1)
			{
				delete _assetTrackers[index];
				_assetTrackers.RemoveAtFast(index);
			}
		}
	}
}
