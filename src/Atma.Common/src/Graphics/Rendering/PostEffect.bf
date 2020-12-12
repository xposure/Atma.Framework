using System;

namespace Atma
{
	/// <summary>
	/// Reusable post effects
	/// </summary>
	public abstract class PostEffect
	{
		protected abstract Material ShaderMaterial { get; }
		private Texture _debugInput ~ delete _;
		private Texture _debugOutput ~ delete _;
		private bool _captureInput = Core.DebugRenderEnabled, _captureOutput = Core.DebugRenderEnabled;

		public virtual void Render(Texture source, RenderTexture destination)
		{
			Render(source, destination, ShaderMaterial);
		}

		protected void Render(Texture texture, RenderTexture renderTarget, Material material)
		{
			Core.Draw.SetMaterial(material);
			Core.Draw.ImageScaled(texture, .FromRect(.Zero, renderTarget.Size), .White);
			Core.Draw.Render(renderTarget, renderTarget.Matrix);

			if (_captureInput)
			{
				if (_debugInput == null) _debugInput = new .(renderTarget.Width, renderTarget.Height);
				_debugInput.Resize(texture.Width, texture.Height);

				let color = new Color[texture.Width * texture.Height];
				texture.GetData(color);
				_debugInput.SetData(color);
				delete color;
			}

			if (_captureOutput)
			{
				if (_debugOutput == null) _debugOutput = new .(renderTarget.Width, renderTarget.Height);
				_debugOutput.Resize(renderTarget.Width, renderTarget.Height);

				let color = new Color[renderTarget.Width * renderTarget.Height];
				renderTarget.ColorAttachment.GetData(color);
				_debugOutput.SetData(color);
				delete color;
			}
		}

		public static implicit operator Material(Self it) => it.ShaderMaterial;
	}
}
