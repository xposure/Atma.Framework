using System;
namespace Atma
{
	public abstract class Renderer
	{
		/// <summary>
		/// if renderTarget is not null this Color will be used to clear the screen
		/// </summary>
		public Color ClearColor = Color.Transparent;

		/// <summary>
		/// flag for this renderer that decides if it should debug render or not. The render method receives a bool
		// (debugRenderEnabled) letting the renderer know if the global debug rendering is on/off. The renderer then
		// uses the local bool to decide if it should debug render or not. </summary>
		public bool ShouldDebugRender = false;

		/// <summary>
		/// if true, the Scene will call the render method AFTER all PostProcessors have finished. This must be set to
		// true BEFORE calling Scene.addRenderer to take effect and the Renderer should NOT have a renderTexture. The
		// main reason for this type of Renderer is so that you can render your UI without post processing on top of the
		// rest of your Scene. The ScreenSpaceRenderer is an example Renderer that sets this to true; </summary>
		public bool WantsToRenderAfterPostProcessors;

		public abstract void Render(RenderPipeline pipeline);

		public void Inspect()
		{
			//TODO: Add IMGUI
		}

		protected virtual void OnInspect()
		{
		}

		protected internal virtual void PipelineResize(int2 oldSize, int2 newSize) { }
		protected internal virtual void OnAddedToPipeline(RenderPipeline pipeline) { }
		protected internal virtual void OnRemovedFromPipeline(RenderPipeline pipeline) { }
	}
}
