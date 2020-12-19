using System;
namespace Atma
{
	public interface IRenderable
	{
		public void Render();

		//public int RenderLayer { get; }
		public int RenderLayer { get; }
		public float Depth { get; }
		public Material Material { get; }
		public void Inspect();
	}

	public interface IRenderableComponent : IRenderable
	{
		public bool Visible { get; }
		public aabb2 LocalBounds { get; }
	}

	/// <summary>
	/// interface that when applied to a Component will register it to be rendered by the Scene Renderers. Implement
	// this very carefully! Changing things like layerDepth/renderLayer/material need to update the Scene
	// RenderableComponentList </summary>
	public abstract class Renderable : Component, IRenderableComponent
	{
		public static int Compare(IRenderable self, IRenderable other)
		{
			var res = self.RenderLayer <=> other.RenderLayer;
			if (res == 0)
			{
				res = self.Depth <=> other.Depth;
				if (res == 0)
				{
					// both null or equal
					if (ReferenceEquals(self.Material, other.Material))
						return 0;

					if (other.Material == null)
						return -1;

					return 1;
				}
			}

			return res;
		}

		public this(bool active = false) : base(active)
		{
		}

		private bool _visible;
		public bool Visible
		{
			get => _visible == true;
			set => _visible = value;
		}

		public abstract aabb2 LocalBounds { get; }
		public aabb2 WorldBounds
		{
			get
			{
				var bounds = LocalBounds;
				bounds.Center = Entity.WorldPosition;
				return bounds;
			}
		}

		private int _renderLayer = 0;
		public int RenderLayer => _renderLayer + Entity.RenderLayer;
		public void SetRenderLayer(int layer) => _renderLayer = layer;


		private float _depth = 0;
		public float Depth => _depth + Entity.Depth;
		public void SetDepth(float depth) => _depth = depth;

		/// <summary>
		/// used by Renderers to specify how this sprite should be rendered. If non-null, it is automatically disposed
		// of when the Component is removed from the Entity. </summary>
		public Material Material { get; set; }


		/// <summary>
		/// called by a Renderer. The Camera can be used for culling and the Batcher instance to draw with.
		/// </summary>
		public abstract void Render();
	}
}
