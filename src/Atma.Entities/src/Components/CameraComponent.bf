using System.Collections;
using System;
namespace Atma
{
	public class Camera2DComponent : Component
	{
		public override bool Track => true;
		private Camera2D _camera;

		public static implicit operator Camera2D(Camera2DComponent it) => it._camera;

		public this(Camera2D camera) : base(false)
		{
			_camera = camera;
		}

		public override void Added(Entity entity)
		{
			base.Added(entity);

			if (_camera.RendererCount == 0)
			{
				_camera.AddRenderer(new SceneRenderer(this.Entity.Scene));
				Log.Debug("Scene has begun with no renderer. A DefaultRenderer was added automatically so that something is visible. ");
			}
		}

		public void Render()
		{
			_camera.Render();
		}

		public override void Inspect()
		{
			let wp = _camera.ScreenToWorld(Core.Input.MousePosition);
			ImGui.Text(scope $"MouseToWorld: {wp}");

			base.Inspect();
		}
	}
}
