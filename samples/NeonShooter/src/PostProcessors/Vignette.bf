using Atma;
using NeonShooter.PostEffects;

namespace NeonShooter.PostProcessors
{
	public class Vignette : PostProcessor<VignetteEffect>
	{
		public this()
		{
		}

		protected override void OnProcess(Texture source, RenderTexture destination, Camera camera)
		{
			_effect.Resolution.Value = camera.Size;
			base.OnProcess(source, destination, camera);
		}
	}
}
