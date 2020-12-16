using System.Collections;
using System;
namespace Atma
{
	public class Camera : Component
	{
		public enum ResolutionPolicy
		{
			/// <summary>
			/// Default. RenderTarget matches the sceen size
			/// </summary>
			None,

			/// <summary>
			/// The entire application is visible in the specified area without trying to preserve the original aspect
			// ratio. Distortion can occur, and the application may appear stretched or compressed. </summary>
			ExactFit,

			/// <summary>
			/// The entire application fills the specified area, without distortion but possibly with some cropping,
			/// while maintaining the original aspect ratio of the application.
			/// </summary>
			NoBorder,

			/// <summary>
			/// Pixel perfect version of NoBorder. Scaling is limited to integer values.
			/// </summary>
			NoBorderPixelPerfect,

			/// <summary>
			/// The entire application is visible in the specified area without distortion while maintaining the
			// original aspect ratio of the application. Borders can appear on two sides of the application. </summary>
			ShowAll,

			/// <summary>
			/// Pixel perfect version of ShowAll. Scaling is limited to integer values.
			/// </summary>
			ShowAllPixelPerfect,

			/// <summary>
			/// The application takes the height of the design resolution size and modifies the width of the internal
			/// canvas so that it fits the aspect ratio of the device.
			/// no distortion will occur however you must make sure your application works on different
			/// aspect ratios
			/// </summary>
			FixedHeight,

			/// <summary>
			/// Pixel perfect version of FixedHeight. Scaling is limited to integer values.
			/// </summary>
			FixedHeightPixelPerfect,

			/// <summary>
			/// The application takes the width of the design resolution size and modifies the height of the internal
			/// canvas so that it fits the aspect ratio of the device.
			/// no distortion will occur however you must make sure your application works on different
			/// aspect ratios
			/// </summary>
			FixedWidth,

			/// <summary>
			/// Pixel perfect version of FixedWidth. Scaling is limited to integer values.
			/// </summary>
			FixedWidthPixelPerfect,

			/// <summary>
			/// The application takes the width and height that best fits the design resolution with optional cropping
			// inside of the "bleed area" and possible letter/pillar boxing. Works just like ShowAll except with
			// horizontal/vertical bleed (padding). Gives you an area much like the old TitleSafeArea. Example: if
			// design resolution is 1348x900 and bleed is 148x140 the safe area would be 1200x760 (design resolution -
			// bleed). </summary>
			BestFit
		}

		/// <summary>
		/// clear color for the final render of the RenderTarget to the framebuffer
		/// </summary>
		public Color LetterboxColor = Color.Black;

		/// <summary>
		/// if the ResolutionPolicy is pixel perfect this will be set to the scale calculated for it
		/// </summary>
		public int PixelPerfectScale = 1;

		#region SceneResolutionPolicy private fields

		/*/// <summary>
		/// default resolution size used for all scenes
		/// </summary>
		static int2 _defaultDesignResolutionSize;

		/// <summary>
		/// default bleed size for <see cref="SceneResolutionPolicy.BestFit"/> resolution policy
		/// </summary>
		static int2 _defaultDesignBleedSize;

		/// <summary>
		/// default resolution policy used for all scenes
		/// </summary>
		static SceneResolutionPolicy _defaultSceneResolutionPolicy = SceneResolutionPolicy.None;*/

		/// <summary>
		/// resolution policy used by the scene
		/// </summary>
		ResolutionPolicy _resolutionPolicy;

		/// <summary>
		/// design resolution size used by the scene
		/// </summary>
		int2 _designResolutionSize;

		/// <summary>
		/// bleed size for <see cref="SceneResolutionPolicy.BestFit"/> resolution policy
		/// </summary>
		int2 _designBleedSize;

		/// <summary>
		/// this gets setup based on the resolution policy and is used for the final blit of the RenderTarget
		/// </summary>
		rect _finalRenderDestinationRect;

		#endregion

		public readonly RenderPipeline Pipeline;

		private bool _viewMatrixDirty = true;

		private bool IsViewMatrixDirty => _viewMatrixDirty || Entity.WorldPosition != _cachePosition;

		private float4x4 _viewMatrix = float4x4.Identity;
		private float4x4 _inverseViewMatrix = float4x4.Identity;

		private bool _projMatrixDirty = true;
		private float4x4 _projMatrix = float4x4.Identity;
		private float4x4 _inverseProjMatrix = float4x4.Identity;

		private float4x4 _projViewMatrix = float4x4.Identity;
		private float4x4 _inverseProjViewMatrix = float4x4.Identity;

		//private float2 _position = float2.Zero;
		private aabb2 _viewport;
		private float _depth = 20f;
		private float2 _dpiScale = .Ones;
		private float _scale = 1;
		private float2 _origin = float2.Zero;

		private float2 _cachePosition = float2.Zero;

		private int2 _renderSize;

		public int Width => _renderSize.x;
		public int Height => _renderSize.y;

		public int2 Size
		{
			get => _renderSize;
			/*set
			{
				_projMatrixDirty = true;
				_viewMatrixDirty = true;
				_designResolutionSize = value;
				//_viewport = .(_viewport.Left, _viewport.Top, value.x, value.y);
				UpdateResolutionScaler();
			}*/
		}

		public float Depth
		{
			get => _depth;
			set
			{
				_projMatrixDirty = true;
				_viewMatrixDirty = true;
				_depth = value;
			}
		}

		public float WorldDepth => _depth + Entity.Depth;

		public override bool Track => true;

		public this(ResolutionPolicy resolutionPolicy, int2 designSize, int2 bleedSize) : base(false)
		{
			_designResolutionSize = designSize;
			_designBleedSize = bleedSize;
			_resolutionPolicy = resolutionPolicy;

			_viewport = .(0, 0, 1, 1);
			_dpiScale = .Ones;

			UpdateResolutionScaler();

			Pipeline = new .(_renderSize, .Color);
		}

		/*public float2 Position
		{
			get => _position;
			set
			{
				_viewMatrixDirty = true;
				_position = value;
			}
		}*/

		public aabb2 Viewport
		{
			get => _viewport;
			set
			{
				//_projMatrixDirty = true;
				_viewport = value;
				UpdateResolutionScaler();
			}
		}

		public float Scale
		{
			get => _scale;
			set
			{
				_viewMatrixDirty = true;
				_scale = value;
			}
		}

		public float2 Origin
		{
			get => _origin;
			set
			{
				_viewMatrixDirty = true;
				_origin = value;
			}
		}

		public float2 TotalScale => Scale * _dpiScale;

		public float4x4 ViewMatrix => UpdateMatrix(ref _viewMatrix);
		public float4x4 InverseViewMatrix => UpdateMatrix(ref _inverseViewMatrix);
		public float4x4 ProjectionMatrix => UpdateMatrix(ref _projMatrix);
		public float4x4 InverseProjectionMatrix => UpdateMatrix(ref _inverseProjMatrix);
		public float4x4 ProjectionViewMatrix => UpdateMatrix(ref _projViewMatrix);
		public float4x4 InverseProjectionViewMatrix => UpdateMatrix(ref _inverseProjViewMatrix);

		private float4x4 UpdateMatrix(ref float4x4 mat)
		{
			UpdateMatrix();
			return mat;
		}

		public float ScaleY = 1;
		public aabb2 WorldBounds;
		public int RenderLayer = 0;

		public override void Added(Entity entity)
		{
			base.Added(entity);
			if (Pipeline.RendererCount == 0)
			{
				Pipeline.AddRenderer(new SceneRenderer(null));
				Log.Debug("Scene has begun with no renderer. A DefaultRenderer was added automatically so that something is visible.");
			}

			UpdateResolutionScaler();

			Core.Emitter.AddObserver<CoreEvents.GraphicsDeviceReset>(new => OnGraphicsDeviceReset);
			Core.Emitter.AddObserver<CoreEvents.OrientationChanged>(new => OnOrientationChanged);
			Core.Emitter.AddObserver<CoreEvents.WindowResize>(new => OnWindowResize);
		}

		public override void Removed(Entity entity)
		{
			base.Removed(entity);
			Core.Emitter.RemoveObserver<CoreEvents.GraphicsDeviceReset>(scope => OnGraphicsDeviceReset);
			Core.Emitter.RemoveObserver<CoreEvents.OrientationChanged>(scope => OnOrientationChanged);
			Core.Emitter.AddObserver<CoreEvents.WindowResize>(new => OnWindowResize);
		}

		void OnGraphicsDeviceReset(CoreEvents.GraphicsDeviceReset ev) => UpdateResolutionScaler();
		void OnOrientationChanged(CoreEvents.OrientationChanged ev) => UpdateResolutionScaler();
		void OnWindowResize(CoreEvents.WindowResize ev) => UpdateResolutionScaler();

		private void UpdateMatrix(bool force = false)
		{
			if (_projMatrixDirty || IsViewMatrixDirty || force)
			{
				if (_projMatrixDirty || force)
				{
					_projMatrix = float4x4.Ortho(0, _renderSize.x, 0, _renderSize.y, _depth, 0);
					_inverseProjViewMatrix = _projMatrix.Inverse;

					_projMatrixDirty = false;
				}

				if (IsViewMatrixDirty || force)
				{
					let p = (WorldPosition * _scale);
					let cameraFront = float3(0, 0, -1);
					let cameraUp = float3(0, 1, 0);
					_viewMatrix = float4x4.LookAt(float3(p, _depth), float3(p, 0) + cameraFront, cameraUp);
					_viewMatrix = _viewMatrix * float4x4.Translate(float3(_renderSize * _origin, 0)) * float4x4.Scale(float3(_dpiScale * _scale, 1));

					_inverseViewMatrix = _viewMatrix.Inverse;
					_cachePosition = Entity.WorldPosition;
					_viewMatrixDirty = false;
				}

				let tl = (int2)ScreenToWorld(Screen.Size * Viewport.Min / (Screen.Size / Size));
				let s = (int2)ScreenToWorld(Screen.Size * Viewport.Max / (Screen.Size / Size));

				WorldBounds = .FromRect(tl, s - tl);

				_projViewMatrix = _projMatrix * _viewMatrix;
				_inverseProjViewMatrix = _projViewMatrix.Inverse;
			}
		}

		public int2 ScreenToWorld(float2 screenPosition)
		{
			let scale = _finalRenderDestinationRect.Size / (float2)Pipeline.Size;
			let pos = ((screenPosition) - _viewport.TopLeft * Screen.Size);
			return (int2)(InverseViewMatrix * ((pos - _finalRenderDestinationRect.TopLeft - WorldPosition) / scale));
		}

		public void Render(Scene scene)
		{
			UpdateMatrix(true);

			let result = Pipeline.Render(ProjectionViewMatrix);

			Core.Graphics.Clear(Core.Window, LetterboxColor);
			Core.Draw.Image(result, _finalRenderDestinationRect.ToAABB());
			Core.Draw.HollowRect(_finalRenderDestinationRect, 1f, .Red);
			Core.Draw.Render(Core.Window, Screen.Matrix);
		}

		#region Resolution Policy

		/// <summary>
		/// sets the design size and resolution policy then updates the render textures
		/// </summary>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="sceneResolutionPolicy">Scene resolution policy.</param>
		/// <param name="horizontalBleed">Horizontal bleed size. Used only if resolution policy is set to <see
		// cref="SceneResolutionPolicy.BestFit"/>.</param> <param name="verticalBleed">Horizontal bleed size. Used only
		// if resolution policy is set to <see cref="SceneResolutionPolicy.BestFit"/>.</param>
		public void SetDesignResolution(int width, int height, ResolutionPolicy sceneResolutionPolicy,
			int horizontalBleed = 0, int verticalBleed = 0)
		{
			_designResolutionSize = int2(width, height);
			_resolutionPolicy = sceneResolutionPolicy;
			if (_resolutionPolicy == ResolutionPolicy.BestFit)
				_designBleedSize = int2(horizontalBleed, verticalBleed);
			UpdateResolutionScaler();
		}

		void UpdateResolutionScaler()
		{
			var designSize = _designResolutionSize;
			var screenSize = (int2)(Screen.Size * _viewport.Size);
			var screenAspectRatio = (float)screenSize.x / screenSize.y;

			var renderTargetWidth = screenSize.x;
			var renderTargetHeight = screenSize.y;

			var resolutionScaleX = (float)screenSize.x / (float)designSize.x;
			var resolutionScaleY = (float)screenSize.y / (float)designSize.y;

			var rectCalculated = false;

			// calculate the scale used by the PixelPerfect variants
			PixelPerfectScale = 1;
			if (_resolutionPolicy != ResolutionPolicy.None)
			{
				if ((float)designSize.x / (float)designSize.y > screenAspectRatio)
					PixelPerfectScale = screenSize.x / designSize.x;
				else
					PixelPerfectScale = screenSize.y / designSize.y;

				if (PixelPerfectScale == 0)
					PixelPerfectScale = 1;
			}

			switch (_resolutionPolicy)
			{
			case ResolutionPolicy.None:
				_finalRenderDestinationRect.X = _finalRenderDestinationRect.Y = 0;
				_finalRenderDestinationRect.Width = screenSize.x;
				_finalRenderDestinationRect.Height = screenSize.y;
				rectCalculated = true;
				break;
			case ResolutionPolicy.ExactFit:
					// exact design size render texture
				renderTargetWidth = designSize.x;
				renderTargetHeight = designSize.y;
				break;
			case ResolutionPolicy.NoBorder:
					// exact design size render texture
				renderTargetWidth = designSize.x;
				renderTargetHeight = designSize.y;

				resolutionScaleX = resolutionScaleY = Math.Max(resolutionScaleX, resolutionScaleY);
				break;
			case ResolutionPolicy.NoBorderPixelPerfect:
					// exact design size render texture
				renderTargetWidth = designSize.x;
				renderTargetHeight = designSize.y;

					// we are going to do some cropping so we need to use floats for the scale then round up
				PixelPerfectScale = 1;
				if ((float)designSize.x / (float)designSize.y < screenAspectRatio)
				{
					var floatScale = (float)screenSize.x / (float)designSize.x;
					PixelPerfectScale = (.)Math.Ceiling(floatScale);
				}
				else
				{
					var floatScale = (float)screenSize.y / (float)designSize.y;
					PixelPerfectScale = (.)Math.Ceiling(floatScale);
				}

				if (PixelPerfectScale == 0)
					PixelPerfectScale = 1;

				_finalRenderDestinationRect.Width = (.)Math.Ceiling(designSize.x * PixelPerfectScale);
				_finalRenderDestinationRect.Height = (.)Math.Ceiling(designSize.y * PixelPerfectScale);
				_finalRenderDestinationRect.X = (screenSize.x - _finalRenderDestinationRect.Width) / 2;
				_finalRenderDestinationRect.Y = (screenSize.y - _finalRenderDestinationRect.Height) / 2;
				rectCalculated = true;

				break;
			case ResolutionPolicy.ShowAll:
				resolutionScaleX = resolutionScaleY = Math.Min(resolutionScaleX, resolutionScaleY);

				renderTargetWidth = designSize.x;
				renderTargetHeight = designSize.y;
				break;
			case ResolutionPolicy.ShowAllPixelPerfect:
					// exact design size render texture
				renderTargetWidth = designSize.x;
				renderTargetHeight = designSize.y;

				_finalRenderDestinationRect.Width = (.)Math.Ceiling(designSize.x * PixelPerfectScale);
				_finalRenderDestinationRect.Height = (.)Math.Ceiling(designSize.y * PixelPerfectScale);
				_finalRenderDestinationRect.X = (screenSize.x - _finalRenderDestinationRect.Width) / 2;
				_finalRenderDestinationRect.Y = (screenSize.y - _finalRenderDestinationRect.Height) / 2;
				rectCalculated = true;

				break;
			case ResolutionPolicy.FixedHeight:
				resolutionScaleX = resolutionScaleY;
				designSize.x = (.)Math.Ceiling(screenSize.x / resolutionScaleX);

					// exact design size render texture for height but not width
				renderTargetWidth = designSize.x;
				renderTargetHeight = designSize.y;
				break;
			case ResolutionPolicy.FixedHeightPixelPerfect:
					// start with exact design size render texture height. the width may change
				renderTargetHeight = designSize.y;

				_finalRenderDestinationRect.Width = (.)Math.Ceiling(designSize.x * resolutionScaleX);
				_finalRenderDestinationRect.Height = (.)Math.Ceiling(designSize.y * PixelPerfectScale);
				_finalRenderDestinationRect.X = (screenSize.x - _finalRenderDestinationRect.Width) / 2;
				_finalRenderDestinationRect.Y = (screenSize.y - _finalRenderDestinationRect.Height) / 2;
				rectCalculated = true;

				renderTargetWidth = (int)(designSize.x * resolutionScaleX / PixelPerfectScale);
				break;
			case ResolutionPolicy.FixedWidth:
				resolutionScaleY = resolutionScaleX;
				designSize.y = (.)Math.Ceiling(screenSize.y / resolutionScaleY);

					// exact design size render texture for width but not height
				renderTargetWidth = designSize.x;
				renderTargetHeight = designSize.y;
				break;
			case ResolutionPolicy.FixedWidthPixelPerfect:
					// start with exact design size render texture width. the height may change
				renderTargetWidth = designSize.x;

				_finalRenderDestinationRect.Width = (.)Math.Ceiling(designSize.x * PixelPerfectScale);
				_finalRenderDestinationRect.Height = (.)Math.Ceiling(designSize.y * resolutionScaleY);
				_finalRenderDestinationRect.X = (screenSize.x - _finalRenderDestinationRect.Width) / 2;
				_finalRenderDestinationRect.Y = (screenSize.y - _finalRenderDestinationRect.Height) / 2;
				rectCalculated = true;

				renderTargetHeight = (int)(designSize.y * resolutionScaleY / PixelPerfectScale);

				break;
			case ResolutionPolicy.BestFit:
				var safeScaleX = (float)screenSize.x / (designSize.x - _designBleedSize.x);
				var safeScaleY = (float)screenSize.y / (designSize.y - _designBleedSize.y);

				var resolutionScale = Math.Max(resolutionScaleX, resolutionScaleY);
				var safeScale = Math.Min(safeScaleX, safeScaleY);

				resolutionScaleX = resolutionScaleY = Math.Min(resolutionScale, safeScale);

				renderTargetWidth = designSize.x;
				renderTargetHeight = designSize.y;

				break;
			}

			// if we didnt already calculate a rect (None and all pixel perfect variants calculate it themselves)
			// calculate it now
			if (!rectCalculated)
			{
				// calculate the display rect of the RenderTarget
				var renderWidth = designSize.x * resolutionScaleX;
				var renderHeight = designSize.y * resolutionScaleY;

				_finalRenderDestinationRect = aabb2.FromRect((screenSize.x - renderWidth) / 2,
					(screenSize.y - renderHeight) / 2, renderWidth, renderHeight).ToRect();

				/*_finalRenderDestinationRect = RectangleExt.FromFloats((screenSize.X - renderWidth) / 2,
					(screenSize.Y - renderHeight) / 2, renderWidth, renderHeight);*/
			}


			// set some values in the Input class to translate mouse position to our scaled resolution
			//TODO: var scaleX = renderTargetWidth / (float)_finalRenderDestinationRect.Width;
			//TODO: var scaleY = renderTargetHeight / (float)_finalRenderDestinationRect.Height;

			//TODO: Input._resolutionScale = float2(scaleX, scaleY);
			//TODO: Input._resolutionOffset = _finalRenderDestinationRect.Location;

			let newRenderSize = int2(renderTargetWidth, renderTargetHeight);
			if (_renderSize != newRenderSize)
			{
				Pipeline?.Resize(newRenderSize);

				_projMatrixDirty = true;
				_viewMatrixDirty = true;
				Log.Debug(scope $"Resize camera [{_renderSize}] -> {newRenderSize}");
				_renderSize = newRenderSize;
			}
		}

		#endregion

		public override void Inspect()
		{
			base.Inspect();

			let wp = this.ScreenToWorld(Core.Input.MousePosition);
			//_renderTarget.Inspect();
			ImGui.Text(scope $"MouseToWorld: {wp}");

			Pipeline.Inspect();
		}
	}
}
