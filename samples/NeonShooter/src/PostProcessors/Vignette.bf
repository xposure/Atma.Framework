using Atma;
using NeonShooter.PostEffects;

namespace NeonShooter.PostProcessors
{
	public class Vignette : PostProcessor<VignetteEffect>
	{
		public this()
		{
		}

		protected override void OnProcess(Texture source, RenderTexture destination)
		{
			_effect.Resolution.Value = destination.Size;
			base.OnProcess(source, destination);
		}
	}
}
