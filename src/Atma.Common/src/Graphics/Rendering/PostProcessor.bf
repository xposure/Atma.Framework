using System;
using System.Collections;

namespace Atma
{
	public class PostProcessor<T> : PostProcessor
		where T : PostEffect, delete, new
	{
		protected T _effect = new .() ~ delete _;

		protected override void OnProcess(Texture source, RenderTexture destination)
		{
			_effect.Render(source, destination);
		}

		protected override void OnInspect()
		{
			_effect.Inspect();
		}

	}

		/// <summary>
		/// Post Processing step for rendering actions after everthing done.
		/// </summary>
	public abstract class PostProcessor//: Comparison<PostProcessor>
	{
		/// <summary>
		/// Step is Enabled or not.
		/// </summary>
		public bool Enabled = true;

		private Texture _debugInput ~ delete _;
		private Texture _debugOutput ~ delete _;

		private bool _captureInput = Core.DebugRenderEnabled, _captureOutput = Core.DebugRenderEnabled;

		/*/// <summary>
		/// called when the PostProcessor is added to the Scene. Subclasses must base!
		/// </summary>
		/// <param name="scene">Scene.</param>
		public virtual void OnAddedToCamera(Camera camera)
		{
		}*/

		protected internal virtual void PipelineResize(int2 oldSize, int2 newSize) { }
		protected internal virtual void OnAddedToPipeline(RenderPipeline pipeline) { }
		protected internal virtual void OnRemovedFromPipeline(RenderPipeline pipeline) { }

		/// <summary>
		/// this is the meat method here. The source passed in contains the full scene with any previous PostProcessors
		/// rendering. Render it into the destination RenderTarget. The drawFullScreenQuad methods are there to make
		/// the process even easier. The default implementation renders source into destination with effect.
		/// 
		/// Note that destination might have a previous render! If your PostProcessor Effect is discarding you should
		// clear the destination before writing to it! </summary> <param name="source">Source.</param> <param
		// name="destination">Destination.</param>
		public void Process(Texture source, RenderTexture destination)
		{
			OnProcess(source, destination);

			if (_captureInput)
			{
				if (_debugInput == null) _debugInput = new .(destination.Width, destination.Height);
				_debugInput.Resize(source.Width, source.Height);

				let color = new Color[source.Width * source.Height];
				source.GetData(color);
				_debugInput.SetData(color);
				delete color;
			}

			if (_captureOutput)
			{
				if (_debugOutput == null) _debugOutput = new .(destination.Width, destination.Height);
				_debugOutput.Resize(destination.Width, destination.Height);

				let color = new Color[destination.Width * destination.Height];
				destination.ColorAttachment.GetData(color);
				_debugOutput.SetData(color);
				delete color;
			}
		}

		protected abstract void OnProcess(Texture source, RenderTexture destination);
		/// <summary>
		/// called when a scene is ended or this PostProcessor is removed. use this for cleanup.
		/// </summary>
		public virtual void Unload()
		{
		}

		public void Inspect()
		{
			ImGui.PushID(Internal.UnsafeCastToPtr(this));
			let name = scope String();
			let type = this.GetType();
			type.GetName(name);

			if (ImGui.CollapsingHeader(name))
			{
				ImGui.Checkbox("Enabled", &Enabled);
				if (!_captureInput && ImGui.Button("Capture Input"))
					_captureInput = true;
				else if (_debugInput != null)
				{
					ImGui.Text("Input:");
					_debugInput.Inspect();
				}

				if (!_captureOutput && ImGui.Button("Capture Output"))
					_captureOutput = true;
				else if (_debugOutput != null)
				{
					ImGui.Text("Output:");
					_debugOutput.Inspect();
				}

				OnInspect();
			}
			ImGui.PopID();
		}

		//change to public for crash
		protected virtual void OnInspect() { }
	}
}
