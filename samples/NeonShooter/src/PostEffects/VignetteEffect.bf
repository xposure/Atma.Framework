using Atma;
//TODO IMGUI using ImGui;

namespace NeonShooter.PostEffects
{
	public class VignetteEffect : PostEffect
	{
		private Material material ~ delete _;

		protected override Material ShaderMaterial => material;

		public readonly MaterialParam<float> Power ~ delete _;
		public readonly MaterialParam<float> Radius ~ delete _;
		public readonly MaterialParam<float2> Resolution ~ delete _;

		public this()
		{
			material = new .(Core.Assets.LoadShader("shaders/vignette"));
			Power = new .(material, "u_power");
			Radius = new .(material, "u_radius");
			Resolution = new .(material, "u_resolution");

			Power.Value = 25;
			Radius.Value = 0.15f;
		}

		protected override void OnInspect()
		{
			base.OnInspect();
			Power.Inspect(0, 100);
			Radius.Inspect(0, 1);
		}
	}
}
