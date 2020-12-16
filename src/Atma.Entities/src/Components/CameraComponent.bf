using System.Collections;
using System;
namespace Atma
{
	public class Camera2DComponent : Component
	{
		public override bool Track => true;

		public readonly Camera2D Camera ~ delete _;

		public this(Camera2D.ResolutionPolicy resolutionPolicy, int2 designSize, int2 bleedSize) : base(false)
		{
			Camera = new .(resolutionPolicy, designSize, bleedSize);
		}

		public override void Added(Entity entity)
		{
			base.Added(entity);

			if (Camera.RendererCount == 0)
			{
				Camera.AddRenderer(new SceneRenderer(this.Entity.Scene));
				Log.Debug("Scene has begun with no renderer. A DefaultRenderer was added automatically so that something is visible. ");
			}
		}

		public void Render()
		{
			Camera.Render();
		}

		public override void Inspect()
		{
			let wp = this.Camera.ScreenToWorld(Core.Input.MousePosition);
			ImGui.Text(scope $"MouseToWorld: {wp}");

			base.Inspect();
		}
	}
}
