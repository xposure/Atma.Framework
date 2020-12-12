using Atma;
using NeonShooter.PostEffects;
using System;
namespace NeonShooter.PostProcessors
{
	public class Bloom : PostProcessor
	{
		public struct BloomSettings
		{
			public StringView Name;// Name of a preset bloom setting, for display to the user.

			// Controls how bright a pixel needs to be before it will bloom. Zero makes everything bloom equally, while
			// higher values select only brighter colors. Somewhere between 0.25 and 0.5 is good.
			public float BloomThreshold;

			// Controls how much blurring is applied to the bloom image. The typical range is from 1 up to 10 or so.
			public float BlurAmount;

			// Controls the amount of the bloom and base images that will be mixed into the final scene. Range 0 to 1.
			public float BloomIntensity;
			public float BaseIntensity;

			// Independently control the color saturation of the bloom and base images. Zero is totally desaturated, 1.0
			// leaves saturation unchanged, while higher values increase the saturation level.
			public float BloomSaturation;
			public float BaseSaturation;


			// CONSTRUCT BLOOM SETTING DESCRIPTOR
			public this(StringView name, float bloomThreshold, float blurAmount,
				float bloomIntensity, float baseIntensity,
				float bloomSaturation, float baseSaturation)
			{
				Name = name;
				BloomThreshold = bloomThreshold;
				BlurAmount = blurAmount;
				BloomIntensity = bloomIntensity;
				BaseIntensity = baseIntensity;
				BloomSaturation = bloomSaturation;
				BaseSaturation = baseSaturation;
			}

			// TABLE OF BLOOM SETTING PRESETS
			public static BloomSettings[?] Preset = BloomSettings[]
				(//                Name           Thresh  Blur Bloom  Base  BloomSat BaseSat
				BloomSettings("Default", 0.25f, 4, 2f, 1, 1.5f, 1),
				BloomSettings("Default", 0.25f, 4, 1.25f, 1, 1, 1),
				BloomSettings("Soft", 0, 3, 1, 1, 1, 1),
				BloomSettings("Desaturated", 0.5f, 8, 2, 1, 0, 1),
				BloomSettings("Saturated", 0.25f, 4, 2, 1, 2, 0),
				BloomSettings("Blurry", 0, 2, 1, 0.1f, 1, 1),
				BloomSettings("Subtle", 0.5f, 2, 1, 1, 1, 1)
				);
		}

		public BloomSettings Settings = BloomSettings.Preset[0];

		private BloomExtractEffect _extract ~ delete _;
		private GaussianBlurEffect _gaussian ~ delete _;
		private BloomCombineEffect _combine ~ delete _;
		private RenderTexture _bloomTexture ~ delete _;

		//public bool EnableGaussianBlur = true;

		public this()
		{
			_bloomTexture = new RenderTexture(Screen.Width, Screen.Height, .Color);
			_extract = new .();
			_gaussian = new .();

			_combine = new .();
		}

		protected override void OnProcess(Texture source, RenderTexture destination, Camera camera)
		{
			_bloomTexture.Resize(destination.Size);

			_gaussian.BlurAmount = Settings.BlurAmount;
			_extract.BloomThreshold.Value = Settings.BloomThreshold;
			_combine.BloomIntensity.Value = Settings.BloomIntensity;
			_combine.BaseIntensity.Value = Settings.BaseIntensity;
			_combine.BloomSaturation.Value = Settings.BloomSaturation;
			_combine.BaseSaturation.Value = Settings.BaseSaturation;

			_extract.Render(source, _bloomTexture);

			//if (EnableGaussianBlur)
			{
				_gaussian.BlurDirection = .Horizontal;
				_gaussian.Render(_bloomTexture, _bloomTexture);
				_gaussian.BlurDirection = .Vertical;
				_gaussian.Render(_bloomTexture, _bloomTexture);
			}

			_combine.BloomTexture.Value = _bloomTexture;
			_combine.Render(source, destination);
		}

		protected override void OnInspect()
		{
			_extract.Inspect();
			_gaussian.Inspect();
			_combine.Inspect();

			_bloomTexture.Inspect();

			Settings.BlurAmount = _gaussian.BlurAmount;
			Settings.BloomThreshold = _extract.BloomThreshold.Value;
			Settings.BloomIntensity = _combine.BloomIntensity.Value;
			Settings.BaseIntensity = _combine.BaseIntensity.Value;
			Settings.BloomSaturation = _combine.BloomSaturation.Value;
			Settings.BaseSaturation = _combine.BaseSaturation.Value;
		}
	}
}
