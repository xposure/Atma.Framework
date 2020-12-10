using Atma;
using System;

namespace NeonShooter.PostEffects
{
	public class GaussianBlurEffect : PostEffect
	{
		public enum GaussianBlurDirection
		{
			case Horizontal;
			case Vertical;
		}

		private Material _material ~ delete _;
		private readonly MaterialParam<float> _sampleWeights ~ delete _;
		private readonly MaterialParam<float2> _sampleOffsets ~ delete _;

		protected override Material ShaderMaterial => _material;

		public float BlurAmount = 1;
		public GaussianBlurDirection BlurDirection = .Horizontal;

		public this()
		{
			_material = new .(Core.Assets.LoadShader("shaders/gaussianblur"));

			_sampleWeights = new .(_material, "u_sampleWeights");
			_sampleOffsets = new .(_material, "u_sampleOffsets");
		}

		private void ComputeSamples(double dx, double dy)
		{
			// C O M P U T E   G A U S S I A N
			float ComputeGaussian(float n, float blur)
			{
				float theta = blur;
				return (float)((1.0 / Math.Sqrt(2 * Math.PI_d * theta)) *
					Math.Exp(-(n * n) / (2 * theta * theta)));
			}

			// Look up how many samples our gaussian blur effect supports.
			int sampleCount = _sampleWeights.Length;

			if (sampleCount > -1)
			{
			// Create temporary arrays for computing our filter settings.
				float[] sampleWeights = scope float[sampleCount];
				float2[] sampleOffsets = scope float2[sampleCount];

			// The first sample always has a zero offset.
				sampleWeights[0] = ComputeGaussian(0, BlurAmount);
				sampleOffsets[0] = .Zero;

			// Maintain a sum of all the weighting values.
				float totalWeights = sampleWeights[0];

			// Add pairs of additional sample taps, positioned along a line in both directions from the center.
				for (int i = 0; i < sampleCount / 2; i++)
				{
					// Store weights for the positive and negative taps.
					float weight = ComputeGaussian(i + 1, BlurAmount);

					sampleWeights[i * 2 + 1] = weight;
					sampleWeights[i * 2 + 2] = weight;

					totalWeights += weight * 2;

					// To get the maximum amount of blurring from a limited number of pixel shader samples, we take
					// advantage of the bilinear filtering hardware inside the texture fetch unit. If we position our 
					// texture coordinates exactly halfway between two texels, the filtering unit// will average them
					// for us, giving two samples for the price of one.This allows us to step in units of two texels per
					// sample, rather// than just one at a time.The 1.5 offset kicks things off by positioning us nicely
					// in between two texels.

					double sampleOffset = i * 2 + 1.5f;

					let delta = float2((float)(dx * sampleOffset), (float)(dy * sampleOffset));

					// Store texture coordinate offsets for the positive and negative taps.
					sampleOffsets[i * 2 + 1] = delta;
					sampleOffsets[i * 2 + 2] = -delta;
				}

				// Normalize the list of sample weightings, so they will always sum to one.
				for (int i = 0; i < sampleWeights.Count; i++)
					sampleWeights[i] /= totalWeights;

				_sampleOffsets.CopyFrom(sampleOffsets);
				_sampleWeights.CopyFrom(sampleWeights);
			}
		}

		public override void Render(Texture source, RenderTexture destination)
		{
			ComputeSamples(BlurDirection == .Horizontal ? 1.0 / destination.Width : 0, BlurDirection == .Vertical ? 1.0 / destination.Height : 0);
			base.Render(source, destination);
		}

		protected override void OnInspect()
		{
			base.OnInspect();

			/*ImGui.Checkbox("Down sample", &DownSample);
			ImGui.SliderInt("Passes", &Passes, 1, 4);*/
			//TODO IMGUI ImGui.SliderFloat("Blur", &BlurAmount, 0, Math.PI_f * 2);
		}
	}
}
