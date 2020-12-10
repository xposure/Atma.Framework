using Atma;
namespace NeonShooter.Components
{
	public class PlayerCamera : Component
	{
		public float2 WorldTarget;

		public this() : base(true)
		{
		}

		public override void FixedUpdate()
		{
			let camera = Scene.Camera;
			//let cameraEntity = camera.Entity;

			//cameraEntity.Position = this.Entity.Position;
			WorldTarget = camera.ScreenToWorld(Core.Input.MousePosition);
		}
	}
}
