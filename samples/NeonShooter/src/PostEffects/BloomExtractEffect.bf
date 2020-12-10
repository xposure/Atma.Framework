using Atma;

namespace NeonShooter.PostEffects
{
	public class BloomExtractEffect : PostEffect
	{
		private Material _material ~ delete _;
		public readonly MaterialParam<float> BloomThreshold ~ delete _;

		protected override Material ShaderMaterial => _material;

		public this()
		{
			_material = new .(Core.Assets.LoadShader("shaders/bloomextract"));
			BloomThreshold = new .(_material, "u_bloomThreshold");

			BloomThreshold.Value = 0.5f;
		}

		protected override void OnInspect()
		{
			base.OnInspect();
			BloomThreshold.Inspect(0, 1);
		}
	}
}
