using Atma;
namespace NeonShooter.PostEffects
{
	public class BloomCombineEffect : PostEffect
	{
		private Material _material ~ delete _;
		public readonly MaterialParam<Texture> BloomTexture ~ delete _;
		public readonly MaterialParam<float> BloomIntensity ~ delete _;
		public readonly MaterialParam<float> BaseIntensity ~ delete _;
		public readonly MaterialParam<float> BloomSaturation ~ delete _;
		public readonly MaterialParam<float> BaseSaturation ~ delete _;

		protected override Material ShaderMaterial => _material;

		public this()
		{
			_material = new .(Core.Assets.LoadShader("shaders/bloomcombine"));
			BloomIntensity = new .(_material, "BloomIntensity");
			BaseIntensity = new .(_material, "BaseIntensity");
			BloomSaturation = new .(_material, "BloomSaturation");
			BaseSaturation = new .(_material, "BaseSaturation");
			BloomTexture = new .(_material, "u_bloom");

			BloomIntensity.Value = 1.25f;
			BaseIntensity.Value = 1f;
			BloomSaturation.Value = 1f;
			BaseSaturation.Value = 1f;
		}

		public override void Render(Texture source, RenderTexture destination)
		{
			base.Render(source, destination);
		}

		protected override void OnInspect()
		{
			base.OnInspect();
			BloomIntensity.Inspect(0, 5);
			BaseIntensity.Inspect(0, 5);
			BloomSaturation.Inspect(0, 5);
			BaseSaturation.Inspect(0, 5);
		}
	}
}
