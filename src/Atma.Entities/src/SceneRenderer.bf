using System;
using System.Collections;
namespace Atma
{
	public class SceneRenderer : Renderer
	{
		public BlendMode BlendMode = .Normal;

		private Scene scene;
		protected Material _currentMaterial;
		private Material CustomMaterial;

		private bool _inspecting = false;

		/// <summary>
		/// renders all renderLayers
		/// </summary>
		/// <param name="renderOrder">Render order.</param>
		/// <param name="camera">Camera.</param>
		public this(Scene scene)
		{
			this.scene = scene;
		}

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

		public override void Render(RenderPipeline pipeline)
		{
			for (var cam in scene.Entities.Components<Camera2DComponent>())
			{
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
			}

			if (_inspecting || ShouldDebugRender || Core.DebugRenderEnabled)
			{
				for (var it in scene.Entities)
					if (it.Enabled)
						it.DebugRender();
			}
		}

		protected override void OnInspect()
		{
			base.OnInspect();

			/*if (ImGui.Button("Open Render List"))
				_inspecting = true;*/

			/*if (ImGui.Begin("Render List", _inspecting))
			{
				for (var cam in scene.Entities.Components<Camera2DComponent>())
				{
					for (var i = 0; i < scene.RenderableComponents.Count; i++)
					{
						var renderable = scene.RenderableComponents[i];
						if (renderable.ShouldRender(cam))
						{
							let meta = Types[renderable.GetType()];
							if (ImGui.CollapsingHeader(scope $"{meta.Name} [{renderable.RenderLayer}] "))
								renderable.Inspect();
						}
					}
				}

				ImGui.End();
			}*/
		}
	}
}
