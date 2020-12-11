using System;
using System.Collections;

namespace Atma
{
	public class PostProcessor<T> : PostProcessor
		where T : PostEffect, delete, new
	{
		protected T _effect = new .() ~ delete _;

		protected override void OnProcess(Texture source, RenderTexture destination, Camera camera)
		{
			_effect.Render(source, destination);
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

		/// <summary>
		/// called when the PostProcessor is added to the Scene. Subclasses must base!
		/// </summary>
		/// <param name="scene">Scene.</param>
		public virtual void OnAddedToCamera(Camera camera)
		{
		}

		/// <summary>
		/// called when the default scene RenderTarget is resized. If a PostProcessor is added to a scene before it
		// begins this method will be called before the scene first renders. If the scene already started this will be
		// called after onAddedToScene making it an ideal place to create any RenderTextures a PostProcessor might
		// require. </summary> <param name="newWidth">New width.</param> <param name="newHeight">New height.</param>
		public virtual void OnSceneBackBufferSizeChanged(int newWidth, int newHeight)
		{
		}

		/// <summary>
		/// this is the meat method here. The source passed in contains the full scene with any previous PostProcessors
		/// rendering. Render it into the destination RenderTarget. The drawFullScreenQuad methods are there to make
		/// the process even easier. The default implementation renders source into destination with effect.
		/// 
		/// Note that destination might have a previous render! If your PostProcessor Effect is discarding you should
		// clear the destination before writing to it! </summary> <param name="source">Source.</param> <param
		// name="destination">Destination.</param>
		public void Process(Texture source, RenderTexture destination, Camera camera)
		{
			OnProcess(source, destination, camera);

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

		protected abstract void OnProcess(Texture source, RenderTexture destination, Camera camera);
		/// <summary>
		/// called when a scene is ended or this PostProcessor is removed. use this for cleanup.
		/// </summary>
		public virtual void Unload()
		{
		}




		protected virtual void OnInspect()
		{
		}
	}
}
