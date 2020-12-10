namespace Atma
{
	public class DefaultRenderer : Renderer
	{
		public BlendMode BlendMode = .Normal;
		/// <summary>
		/// renders all renderLayers
		/// </summary>
		/// <param name="renderOrder">Render order.</param>
		/// <param name="camera">Camera.</param>
		public this(int renderOrder = 0) : base(renderOrder)
		{
		}

		public override void Render(Scene scene, Camera cam)
		{
			BeginRender();
			Core.Draw.SetBlendMode(BlendMode);

			for (var i = 0; i < scene.RenderableComponents.Count; i++)
			{
				var renderable = scene.RenderableComponents[i];

				if (renderable.ShouldRender(cam))
				{
					UpdateState(renderable);
					renderable.Render();
				}
			}

			if (ShouldDebugRender && Core.DebugRenderEnabled)
				DebugRender(scene);

			EndRender(cam);
		}
	}
}
