using System;
using System.Collections;

namespace Atma
{
	/// <summary>
	/// A Texture Atlas
	/// </summary>
	public class Atlas
	{
		/// <summary>
		/// List of all the Texture Pages of the Atlas
		/// Generally speaking it's ideal to have a single Page per atlas, but that's not always possible.
		/// </summary>
		public readonly List<Texture> Pages = new List<Texture>() ~ DeleteContainerAndItems!(_);

		/// <summary>
		/// A Dictionary of all the Subtextures in this Atlas.
		/// </summary>
		public readonly Dictionary<String, Subtexture> Subtextures = new Dictionary<String, Subtexture>() ~ DeleteDictionaryAndKeys!(_);

		/// <summary>
		/// An empty Atlas
		/// </summary>
		public this() { }

		/// <summary>
		/// An Atlas created from an Image Packer, optionally premultiplying the textures
		/// </summary>
		public this(Packer packer, bool premultiply = false)
		{
			let output = packer.Packed;
			if (output != null)
			{
				let image = output.Page;
				if (premultiply)
					image.Premultiply();

				Pages.Add(new Texture(image));

				for (var entry in output.Entries.Values)
				{
					let texture = Pages[entry.Page];

					let subtexture = Subtexture(texture, entry.Source, entry.Frame);

					Subtextures.Add(new String(entry.Name), subtexture);
				}
			}
		}

		/// <summary>
		/// Gets or Sets a Subtexture by name
		/// </summary>
		public Subtexture this[String name]
		{
			get
			{
				if (Subtextures.TryGetValue(name, let subtex))
					return subtex;

				System.Diagnostics.Debug.Assert(false, "Missing sub texture.");
				return default;
			}
			set
			{
//                if (value != null)
				Subtextures[name] = value;
			}
		}

	}
}

