using System;
namespace Atma
{
	/// <summary>
	/// Renderers are added to a Scene and handle all of the actual calls to RenderableComponent.render and
	// Entity.debugRender. A simple Renderer could just start the Batcher.instanceGraphics.batcher or it could create
	// its own local Batcher instance if it needs it for some kind of custom rendering.  Note that it is a best practice
	// to ensure all Renderers that render to a RenderTarget have lower renderOrders to avoid issues with clearing the
	// back buffer (http://gamedev.stackexchange.com/questions/90396/monogame-setrendertarget-is-wiping-the-backbuffer).
	//  Giving them a negative renderOrder is a good strategy to deal with this. </summary>
	public abstract class Renderer//: IComparable<Renderer>
	{
		public enum RendererType
		{
			case RenderTexture;
			case Scene;
		}

		public static readonly RendererSorter DefaultSort = new .() ~ delete _;

		public class RendererSorter : Comparison<Renderer>
		{
			public int CompareTo(Renderer left, Renderer right) => left.RenderOrder <=> right.RenderOrder;
		}

		/// <summary>
		/// Material used for all renderables, if null it will use the renderables material.
		/// </summary>
		public Material CustomMaterial;

		/*/// <summary>
		/// the Camera this renderer uses for rendering (really its transformMatrix and bounds for culling). This is a
		convenience field and isnt /// required. Renderer subclasses can pick the camera used when calling beginRender. 
		/// </summary> public Camera Camera;*/

		/// <summary>
		/// specifies the order in which the Renderers will be called by the scene
		/// </summary>
		public readonly int RenderOrder = 0;

		/// <summary>
		/// if renderTarget is not null this renderer will render into the RenderTarget instead of to the screen
		/// </summary>
		public RenderTexture RenderTexture ~ delete _;

		/// <summary>
		/// if renderTarget is not null this Color will be used to clear the screen
		/// </summary>
		public Color RenderTargetClearColor = Color.Transparent;

		/// <summary>
		/// flag for this renderer that decides if it should debug render or not. The render method receives a bool
		// (debugRenderEnabled) letting the renderer know if the global debug rendering is on/off. The renderer then
		// uses the local bool to decide if it should debug render or not. </summary>
		public bool ShouldDebugRender = true;

		/// <summary>
		/// if true, the Scene will call SetRenderTarget with the scene RenderTarget. The default implementaiton returns
		// true if the Renderer has a renderTexture </summary> <value><c>true</c> if wants to render to scene render
		// target; otherwise, <c>false</c>.</value>
		public readonly bool HasRenderTexture;// => RenderTexture == null;

		//If true, the render to render to the window.
		public bool RenderToScene;

		/// <summary>
		/// if true, the Scene will call the render method AFTER all PostProcessors have finished. This must be set to
		// true BEFORE calling Scene.addRenderer to take effect and the Renderer should NOT have a renderTexture. The
		// main reason for this type of Renderer is so that you can render your UI without post processing on top of the
		// rest of your Scene. The ScreenSpaceRenderer is an example Renderer that sets this to true; </summary>
		public bool WantsToRenderAfterPostProcessors;

		/// <summary>
		/// holds the current Material of the last rendered Renderable (or the Renderer.material if no changes were
		// made) </summary>
		protected Material _currentMaterial;

		protected this(int renderOrder, bool renderToScene = true, bool renderToTexture = false)//: this(renderOrder,
		// null)
		{
			RenderOrder = renderOrder;
			HasRenderTexture = renderToTexture;
			RenderToScene = renderToScene;
		}

		/*protected this(int renderOrder, Camera camera)
		{
			Camera = camera;
			RenderOrder = renderOrder;
			_batch = new .();
		}*/

		/// <summary>
		/// called when the Renderer is added to the Scene
		/// </summary>
		/// <param name="scene">Scene.</param>
		public virtual void OnAddedToCamera(Camera camera)
		{
			if (HasRenderTexture)
				RenderTexture = new .(camera.Size);
		}

		/// <summary>
		/// called when a scene is ended or this Renderer is removed from the Scene. use this for cleanup.
		/// </summary>
		public virtual void Unload()
		{
		}

		/// <summary>
		/// if a RenderTarget is used this will set it up. The Batcher is also started. The passed in Camera will be
		// used to set the ViewPort (if a ViewportAdapter is present) and for the Batcher transform Matrix. </summary> 
		// <param name="cam">Cam.</param>
		protected virtual void BeginRender()
		{
			_currentMaterial = null;
			if (CustomMaterial != null)
				Core.Draw.SetMaterial(CustomMaterial);
		}

		abstract public void Render(Scene scene, Camera camera);

		/// <summary>
		/// renders the RenderableComponent flushing the Batcher and resetting current material if necessary
		/// </summary>
		/// <param name="renderable">Renderable.</param>
		/// <param name="cam">Cam.</param>
		[Inline]
		protected void UpdateState(Renderable renderable)
		{
			if (CustomMaterial == null)
			{
				//renderable has a material that doesn't match the current material
				if (renderable.Material != null && renderable.Material != _currentMaterial)
				{
					_currentMaterial = renderable.Material;
					Core.Draw.SetMaterial(_currentMaterial);
				}
				//renderable is null and the currentMaterial is not
				else if (renderable.Material == null && _currentMaterial != null)
				{
					_currentMaterial = null;
					Core.Draw.SetMaterial(_currentMaterial);
				}
			}
		}

		/// <summary>
		/// ends the Batcher and clears the RenderTarget if it had a RenderTarget
		/// </summary>
		protected virtual void EndRender(Camera camera)
		{
			//let target = RenderTexture ?? camera.RenderTexture;
			//Core.Draw.Render(Core.Window, camera.ProjectionViewMatrix);
		}

		/// <summary>
		/// default debugRender method just loops through all entities and calls entity.debugRender. Note that you are
		// in the middle of a batch at this point so you may want to call Batcher.End and Batcher.begin to clear out any
		// Materials and items awaiting rendering. </summary> <param name="scene">Scene.</param>
		protected virtual void DebugRender(Scene scene)
		{
			for (var it in scene.Entities)
				if (it.Enabled)
					it.DebugRender();
		}

		/// <summary>
		/// called when the default scene RenderTarget is resized and when adding a Renderer if the scene has already
		// began. default implementation calls through to RenderTexture.onSceneBackBufferSizeChanged so that it can size
		// itself appropriately if necessary. </summary> <param name="newWidth">New width.</param> <param
		// name="newHeight">New height.</param>
		public virtual void OnSceneBackBufferSizeChanged(int newWidth, int newHeight) => RenderTexture?.Resize(newWidth, newHeight);

		public int CompareTo(Renderer other) => RenderOrder.CompareTo<int>(other.RenderOrder);
	}
}
