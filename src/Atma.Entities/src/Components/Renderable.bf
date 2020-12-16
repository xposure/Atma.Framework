using System;
namespace Atma
{
	/// <summary>
	/// interface that when applied to a Component will register it to be rendered by the Scene Renderers. Implement
	// this very carefully! Changing things like layerDepth/renderLayer/material need to update the Scene
	// RenderableComponentList </summary>
	public abstract class Renderable : Component
	{
		public static int Compare(Renderable self, Renderable other)
		{
			var res = other.RenderLayer.CompareTo<int>(self.RenderLayer);
			if (res == 0)
			{
				res = other.LayerDepth.CompareTo(self.LayerDepth);
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

		private RenderableComponentList _renderList;
		private int _renderLayer = 0;
		public int RenderLayer => _renderLayer;

		public this(bool active = false) : base(active)
		{
		}

		/// <summary>
		/// the AABB that wraps this object. Used for camera culling.
		/// </summary>
		/// <value>The bounds.</value>
		public abstract aabb2 Bounds { get; }

		/*/// <summary>
		/// whether this IRenderable should be rendered or not
		/// </summary>
		bool Enabled { get; set; }*/

		/// <summary>
		/// standard Batcher layerdepth. 0 is in front and 1 is in back. Changing this value will trigger a sort of the
		// renderableComponents list on the scene. </summary>
		public float LayerDepth;

		/// <summary>
		/// lower renderLayers are in the front and higher are in the back, just like layerDepth but not clamped to 0-1.
		// Note that this means higher renderLayers are sent to the Batcher first. An important fact when using the
		// stencil buffer. </summary>
		public void SetRenderLayer(int layer)
		{
			_renderList?.UpdateRenderableRenderLayer(this, _renderLayer, layer);
			_renderLayer = layer;
		}

		public override void Added(Entity entity)
		{
			base.Added(entity);
			_renderList = Entity.Scene.RenderableComponents;
			_renderList.Add(this);
		}

		public override void Removed(Entity entity)
		{
			base.Removed(entity);
			_renderList?.Remove(this);
		}

		[Inline]
		public bool ShouldRender(Camera2D camera)
		{
			if (!Visible)
				return false;

			if (camera.RenderLayer != _renderLayer)
				return false;

			if (!camera.WorldBounds.Intersects(Bounds))
				return false;

			return true;
		}

		/// <summary>
		/// used by Renderers to specify how this sprite should be rendered. If non-null, it is automatically disposed
		// of when the Component is removed from the Entity. </summary>
		public Material Material;

		/// <summary>
		/// the visibility of this Renderable. Changes in state end up calling the onBecameVisible/onBecameInvisible
		// methods. </summary> <value><c>true</c> if is visible; otherwise, <c>false</c>.</value>
		public bool Visible = true;

		/// <summary>
		/// called by a Renderer. The Camera can be used for culling and the Batcher instance to draw with.
		/// </summary>
		public abstract void Render();

	}
}
