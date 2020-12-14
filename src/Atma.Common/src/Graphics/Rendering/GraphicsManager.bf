using System;
using System.Threading;

namespace Atma
{
	public struct GraphicsMetrics
	{
		public int DrawCalls;
		public int Triangles;
	}

	/// <summary>
	/// The Core Graphics Module, used for Rendering
	/// </summary>
	public class GraphicsManager//: AppModule
	{
		protected aabb2 _viewport = .(0, 0, 1, 1);

		private GraphicsMetrics _metrics = default;
		public GraphicsMetrics Metrics => _metrics;

		protected readonly Window _window;

		protected GraphicsContext _context ~ delete _;

		public Color ClearColor = .CornflowerBlue;

		/// <summary>
		/// The Application Main Thread ID
		/// </summary>
		public readonly int MainThreadId = Thread.CurrentThread.Id;

		private static GraphicsManager _current;
		public static GraphicsManager Current
		{
			get
			{
				//System.Diagnostics.Debug.Assert(_current != null);
				return _current;
			}
		}

		protected this()
		{
			if (_current == null)
				_current = this;
		}

		public void BeforeFrame()
		{
			_metrics = default;
			_viewport = .(0, 0, 1, 1);
			Clear(Core.Window, .All, ClearColor, 0, 0);
		}

		public aabb2 Viewport
		{
			get => _viewport;
			set => _viewport = value;
		}

		/// <summary>
		/// Clears the Color of the Target
		/// </summary>
		public void Clear(RenderTarget target, Color color) =>
			Clear(target, .Color, color, 0, 0);

		/// <summary>
		/// Clears the Target
		/// </summary>
		public void Clear(RenderTarget target, Color color, float depth, int stencil) =>
			Clear(target, .All, color, depth, stencil);

		/// <summary>
		/// Clears the Target
		/// </summary>
		public void Clear(RenderTarget target, Clear flags, Color color, float depth, int stencil)
		{
			if (!target.Renderable)
				Runtime.Assert(false, "Render Target cannot currently be drawn to");

			ClearInternal(target, flags, color, depth, stencil);
		}


		/// <summary>
		/// Draws the data from the Render pass to the Render Target.
		/// This will fail if the Target is not Drawable.
		/// </summary>
		public void Render(RenderPass pass)
		{
			Runtime.Assert(pass.Target.Renderable, "Render Target cannot currently be drawn to");
			Runtime.Assert((pass.Target is RenderTexture) || (pass.Target is Window), "RenderTarget must be a Render Texture or a Window");
			Runtime.Assert(pass.VertexBuffer != null, "VertexBuffer cannot be null when drawing");
			Runtime.Assert(pass.IndexBuffer != null, "IndexBuffer cannot be null when drawing");
			Runtime.Assert(pass.Material != null, "Material cannot be null when drawing");

			/*if (pass.Mesh.InstanceCount > 0 && (pass.Mesh.InstanceFormat == null || (pass.Mesh.InstanceCount <
			pass.Mesh.InstanceCount))) Runtime.Assert(false, "Trying to draw more Instances than exist in the Mesh");*/

			if (pass.IndexBuffer.ElementCount < pass.IndexStart + pass.IndexCount)
				Runtime.Assert(false, "Trying to draw more Indices than exist in the Mesh");

			_metrics.DrawCalls++;
			_metrics.Triangles += (int)pass.IndexCount / 3;
			RenderInternal(pass);
		}


		public this(Window window) : this()
		{
			_window = window;
			_context = window.GraphicsContext;
		}

		/// <summary>
		/// Gets the Shader Source for the Batch2D
		/// </summary>

	}
}

