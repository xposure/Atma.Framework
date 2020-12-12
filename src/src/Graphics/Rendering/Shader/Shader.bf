namespace Atma
{
	using System;
	using System.Collections;

	/// <summary>
	/// A Shader used for Rendering
	/// </summary>
	public class Shader : Assets.IAsset
	{
		private Assets _assets;
		private int _assetKey;

		private Material _material ~ delete _;
		public Material DefaultMaterial
		{
			get
			{
				if (_material == null)
					_material = new .(this);

				return _material;
			}
		}

		public int Version = 0;



		protected readonly GraphicsManager _graphics;

		protected readonly List<ShaderAttribute> _attributes = new .() ~ delete _;
		protected readonly List<ShaderUniform> _uniforms = new .() ~ delete _;

		/// <summary>
		/// Dictionary of all the attributes.
		/// </summary>
		public ReadOnlyList<ShaderAttribute> Attributes => .(_attributes);

		/// <summary>
		/// Tries to get a shader attribute out of the dictionary.
		/// </summary>
		public bool TryGetAttribute(StringView name, out ShaderAttribute attr)
		{
			var list = Attributes;
			for (var i < list.Count)
			{
				attr = list[i];
				if (attr.Name == name)
					return true;
			}
			attr = default;
			return false;
		}

		/// <summary>
		/// Dictionary of all the attributes.
		/// </summary>
		public ReadOnlyList<ShaderUniform> Uniforms => .(_uniforms);

		/// <summary>
		/// List of all Uniforms, by Name
		/// </summary>
		public bool TryGetUniform(StringView name, out ShaderUniform uniform)
		{
			var list = Uniforms;
			for (var i < list.Count)
			{
				uniform = list[i];
				if (uniform.Name == name)
					return true;
			}
			uniform = default;
			return false;
		}

		public this(ShaderSource source, bool log = true)
		{
			_graphics = GraphicsManager.Current;
			Platform_Init(source, log);
		}

		public ~this()
		{
			Platform_Destroy();
			_assets?.Unload(this);
		}

		public void Bind(GraphicsContext context, Material material)
		{
			Platform_Bind(context, material);
		}

		public bool Reload(Atma.Assets.AssetPath[] pathes)
		{
			Version++;
			System.Diagnostics.Debug.Assert(pathes.Count == 2);

			_attributes.Clear();
			_uniforms.Clear();

			Platform_Destroy();

			let vert = scope String();
			let frag = scope String();

			if (pathes[0].ReadAllText(vert) && pathes[1].ReadAllText(frag))
			{
				let source = scope ShaderSource(vert, frag);
				Platform_Init(source, true);
				//DefaultMaterial.[Friend]BuildParamsList();
				return true;
			}

			return false;
		}
	}
}

