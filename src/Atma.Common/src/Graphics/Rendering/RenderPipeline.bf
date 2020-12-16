using System.Collections;
using System;

namespace Atma
{
	using internal Atma;

	public class RenderPipeline : RenderTexture
	{
		/// <summary>
		/// clear color that is used in preRender to clear the screen
		/// </summary>
		public Color ClearColor = Color.CornflowerBlue;

		/// Clear flags like depth, stencil, color, etc.
		public Clear ClearFlags = .All;

		/// Stencil value to clear to
		public int ClearStencil = 0;

		/// Depth value to clear to
		public float ClearDepth = 0f;

		RenderTexture _postTarget ~ delete _;

		internal List<Renderer> _renderers = new .() ~ DeleteContainerAndItems!(_);
		internal readonly List<Renderer> _afterPostProcessorRenderers = new .() ~ DeleteContainerAndItems!(_);
		internal readonly List<PostProcessor> _postProcessors = new .() ~ DeleteContainerAndItems!(_);

		public this(int2 size, params TextureFormat[] attachments) : base(size.width, size.height, params attachments)
		{
		}

		protected this() : base()
		{
			//used to init after ctor
		}

		protected override bool InternalResize(int2 size)
		{
			let oldSize = this.Size;
			let newSize = size;

			if (!base.InternalResize(newSize))
				return false;

			for (var it in _renderers)
				it.PipelineResize(oldSize, newSize);

			for (var it in _afterPostProcessorRenderers)
				it.PipelineResize(oldSize, newSize);

			for (var it in _postProcessors)
				it.PipelineResize(oldSize, newSize);

			return true;
		}

		#region Renderer/PostProcessor Management

		/// <summary>
		/// adds a Renderer to the scene
		/// </summary>
		/// <returns>The renderer.</returns>
		/// <param name="renderer">Renderer.</param>
		public T AddRenderer<T>(T renderer) where T : Renderer
		{
			if (renderer.WantsToRenderAfterPostProcessors)
				_afterPostProcessorRenderers.Add(renderer);
			else
				_renderers.Add(renderer);


			renderer.OnAddedToPipeline(this);
			return renderer;
		}

		public RenderTexture Execute(float4x4 matrix)
		{
			Contract.GreaterThan(_renderers.Count, 0);

			Core.Graphics.Clear(this, ClearFlags, ClearColor, ClearDepth, ClearStencil);
			for (var i < _renderers.Count)
				_renderers[i].Render(this);

			Core.Draw.Render(this, matrix);

			var src = (RenderTexture)this;
			var dst = _postTarget;
			for (var i < _postProcessors.Count)
			{
				let post = _postProcessors[i];
				if (post.Enabled)
				{
					Core.Graphics.Clear(dst, .All, .Transparent, ClearDepth, ClearStencil);
					post.Process(src, dst);
					Swap!(src, dst);
				}
			}

			return src;
		}

		/// <summary>
		/// gets the first Renderer of Type T
		/// </summary>
		/// <returns>The renderer.</returns>
		public T GetRenderer<T>() where T : Renderer
		{
			for (var i = 0; i < _renderers.Count; i++)
			{
				if (_renderers.Ptr[i] is T)
					return _renderers[i] as T;
			}

			for (var i = 0; i < _afterPostProcessorRenderers.Count; i++)
			{
				if (_afterPostProcessorRenderers.Ptr[i] is T)
					return _afterPostProcessorRenderers.Ptr[i] as T;
			}

			return null;
		}

		/*/// <summary>
		/// removes the Renderer from the scene
		/// </summary>
		/// <param name="renderer">Renderer.</param>
		public void RemoveRenderer(Renderer renderer)
		{
			Assert.IsTrue(_renderers.Contains(renderer) || _afterPostProcessorRenderers.Contains(renderer));

			if (renderer.WantsToRenderAfterPostProcessors)
				_afterPostProcessorRenderers.Remove(renderer);
			else
				_renderers.Remove(renderer);
		}*/

		/// <summary>
		/// adds a PostProcessor to the scene. Sets the scene field and calls PostProcessor.onAddedToScene so that
		// PostProcessors can load resources using the scenes ContentManager. </summary> <param
		// name="postProcessor">Post processor.</param>
		public T AddPostProcessor<T>(T postProcessor) where T : PostProcessor
		{
			_postProcessors.Add(postProcessor);

			if (_postTarget == null)
				_postTarget = new .(this.Size);

			return postProcessor;
		}

		/// <summary>
		/// gets the first PostProcessor of Type T
		/// </summary>
		/// <returns>The post processor.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public T GetPostProcessor<T>() where T : PostProcessor
		{
			for (var i = 0; i < _postProcessors.Count; i++)
			{
				if (_postProcessors.Ptr[i] is T)
					return _postProcessors[i] as T;
			}

			return null;
		}

		/// <summary>
		/// removes a PostProcessor. Note that unload is not called when removing so if you no longer need the
		// PostProcessor be sure to call unload to free resources. </summary> <param name="postProcessor">Step.</param>
		public void RemovePostProcessor(PostProcessor postProcessor)
		{
			Assert.IsTrue(_postProcessors.Contains(postProcessor));

			_postProcessors.Remove(postProcessor);
			postProcessor.Unload();
		}

		#endregion

		protected override void OnInspect()
		{
			base.Inspect();

			for (var it in _renderers)
				it.Inspect();

			for (var it in _postProcessors)
				it.Inspect();

			for (var it in _afterPostProcessorRenderers)
				it.Inspect();
		}

		public int RendererCount => _renderers.Count + _afterPostProcessorRenderers.Count;
	}
}
