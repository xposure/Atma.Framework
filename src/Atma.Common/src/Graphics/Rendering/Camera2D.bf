using System.Collections;
using System;
namespace Atma
{
	public class Camera2D : RenderPipeline
	{
		typealias Resolution = (int2 Size, int PixelScale, rect DrawRect);
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

		#endregion

		public bool RendersLayer(int renderLayer) => true;

		private bool _viewMatrixDirty = true;

		private float4x4 _viewMatrix = float4x4.Identity;
		private float4x4 _inverseViewMatrix = float4x4.Identity;

		private bool _projMatrixDirty = true;
		private float4x4 _projMatrix = float4x4.Identity;
		private float4x4 _inverseProjMatrix = float4x4.Identity;

		private float4x4 _projViewMatrix = float4x4.Identity;
		private float4x4 _inverseProjViewMatrix = float4x4.Identity;

		private float2 _position = float2.Zero;
		private aabb2 _viewport;
		private float _depth = 20f;
		private float2 _dpiScale = .Ones;
		private float _scale = 1;
		private float2 _origin = float2.Zero;
		private Resolution _resolution;

		private float cameraTrauma = 0f;
		private float cameraShake = 20;

		public bool AutoResize = true;
		public bool RenderToWindow = true;
		public int2? TargetSize;
		public int2 MouseOffset = .Zero;

		public int2 GetTargetSize()
		{
			if (TargetSize.HasValue)
				return TargetSize.Value;
			return Screen.Size;
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

		public this(ResolutionPolicy resolutionPolicy, int2 designSize, int2 bleedSize = .Zero)
			: base()
		{
			_viewport = .(0, 0, 1, 1);
			_dpiScale = .Ones;

			_designResolutionSize = designSize;
			_resolutionPolicy = resolutionPolicy;
			_designBleedSize = .Zero;
			if (_resolutionPolicy == ResolutionPolicy.BestFit)
				_designBleedSize = bleedSize;

			_resolution = CalculateResolution(resolutionPolicy, designSize, GetTargetSize(), bleedSize);
			Initialize(_resolution.Size, .Color);

			Core.Emitter.AddObserver<CoreEvents.UpdateEnd>(new => UpdateEnd);
			Core.Emitter.AddObserver<CoreEvents.GraphicsDeviceReset>(new => GraphicsDeviceReset);
			Core.Emitter.AddObserver<CoreEvents.OrientationChanged>(new => OrientationChanged);
			Core.Emitter.AddObserver<CoreEvents.WindowResize>(new => WindowResize);
		}

		public ~this()
		{
			Core.Emitter.RemoveObserver<CoreEvents.UpdateEnd>(scope => UpdateEnd);
			Core.Emitter.RemoveObserver<CoreEvents.GraphicsDeviceReset>(scope => GraphicsDeviceReset);
			Core.Emitter.RemoveObserver<CoreEvents.OrientationChanged>(scope => OrientationChanged);
			Core.Emitter.RemoveObserver<CoreEvents.WindowResize>(scope => WindowResize);
		}

		void UpdateEnd(CoreEvents.UpdateEnd ev) => cameraTrauma = Math.Max(cameraTrauma -= Time.Delta, 0);
		void GraphicsDeviceReset(CoreEvents.GraphicsDeviceReset ev) => AutoResize();
		void OrientationChanged(CoreEvents.OrientationChanged ev) => AutoResize();
		void WindowResize(CoreEvents.WindowResize ev) => AutoResize();

		public void AddTrauma(float trauma)
		{
			cameraTrauma = Math.Min(cameraTrauma + trauma, 1f);
		}

		public float2 Position
		{
			get => _position;
			set
			{
				_viewMatrixDirty = true;
				_position = value;
			}
		}

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

		public aabb2 WorldBounds;

		private void UpdateMatrix(bool force = false)
		{
			if (_projMatrixDirty || _viewMatrixDirty || force)
			{
				if (_projMatrixDirty || force)
				{
					_projMatrix = float4x4.Ortho(0, _resolution.Size.width, 0, _resolution.Size.height, _depth, 0);
					_inverseProjViewMatrix = _projMatrix.Inverse;

					_projMatrixDirty = false;
				}

				if (_viewMatrixDirty || force)
				{
					let p = (_position * _scale);
					let cameraFront = float3(0, 0, -1);
					let cameraUp = float3(0, 1, 0);
					_viewMatrix = float4x4.LookAt(float3(p, _depth), float3(p, 0) + cameraFront, cameraUp);
					_viewMatrix = _viewMatrix * float4x4.Translate(float3(Size * _origin, 0)) * float4x4.Scale(float3(_dpiScale * _scale, 1));

					_inverseViewMatrix = _viewMatrix.Inverse;
					_viewMatrixDirty = false;
				}

				//TODO: Viewport math will be wrong here
				let tl = (int2)ScreenToWorld(_resolution.DrawRect.TopLeft);
				let br = (int2)ScreenToWorld(_resolution.DrawRect.BottomRight);

				WorldBounds = .(tl, br);

				_projViewMatrix = _projMatrix * _viewMatrix;
				_inverseProjViewMatrix = _projViewMatrix.Inverse;
			}
		}

		public int2 ScreenToWorld(float2 screenPosition)
		{
			let scale = _resolution.Size / (float2)_resolution.DrawRect.Size;
			let pos = ((screenPosition - MouseOffset) - _viewport.TopLeft * GetTargetSize());
			return (int2)(InverseViewMatrix * ((pos - _resolution.DrawRect.TopLeft /*- _position*/) * scale));
		}


		public void Render()
		{
			var position = Position;

			let noiseScale = 1500f;
			let cameraShakeAmount = Math.Min(cameraTrauma, 1f);
			let cameraShakeDistance = float2(Core.Noise.GetSimplex((float)Time.Time / noiseScale, 0, 0), Core.Noise.GetSimplex((float)Time.Time / noiseScale, 0, 5000))
				* cameraShakeAmount * cameraShakeAmount * cameraShake;
			Position = (int2)(Position + cameraShakeDistance);

			UpdateMatrix(true);

			if (RendererCount == 0)
			{
				AddRenderer(new DefaultRenderer(this));
				Log.Warning("Added default renderer");
			}

			this.Execute(ProjectionViewMatrix);

			Position = position;

			if (RenderToWindow)
			{
				Core.Graphics.Clear(Core.Window, LetterboxColor);
				Core.Draw.Image(this, _resolution.DrawRect.ToAABB());
				//Core.Draw.HollowRect(_resolution.DrawRect, 1f, .Red);
				Core.Draw.Render(Core.Window, Screen.Matrix);
			}
		}

		#region Resolution Policy

		public void SetDesignResolution(int2 size, ResolutionPolicy sceneResolutionPolicy, int2 bleed = .Zero) => SetDesignResolution(size.width, size.height, sceneResolutionPolicy, bleed);
		/// <summary>
		/// sets the design size and resolution policy then updates the render textures
		/// </summary>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="sceneResolutionPolicy">Scene resolution policy.</param>
		/// <param name="horizontalBleed">Horizontal bleed size. Used only if resolution policy is set to <see
		// cref="SceneResolutionPolicy.BestFit"/>.</param> <param name="verticalBleed">Horizontal bleed size. Used only
		// if resolution policy is set to <see cref="SceneResolutionPolicy.BestFit"/>.</param>
		public void SetDesignResolution(int width, int height, ResolutionPolicy sceneResolutionPolicy, int2 bleed = .Zero)
		{
			_designResolutionSize = int2(width, height);
			_resolutionPolicy = sceneResolutionPolicy;
			_designBleedSize = .Zero;
			if (_resolutionPolicy == ResolutionPolicy.BestFit)
				_designBleedSize = bleed;

			UpdateResolutionScaler();
		}

		private void AutoResize()
		{
			if (AutoResize)
				UpdateResolutionScaler();
		}

		private void UpdateResolutionScaler()
		{
			let resolution = CalculateResolution(_resolutionPolicy, _designResolutionSize, GetTargetSize(), _designBleedSize);
			if (_resolution.Size != resolution.Size)
			{
				_projMatrixDirty = true;
				_viewMatrixDirty = true;
				Resize(resolution.Size);
				Log.Debug(scope $"Resize camera [{_resolution.Size}] -> {resolution.Size}");
			}

			_resolution = resolution;
		}

		static Resolution CalculateResolution(ResolutionPolicy _resolutionPolicy, int2 designSize, int2 targetSize, int2 _designBleedSize)
		{
			var designSize;// = _designResolutionSize;
			var screenSize = targetSize;// (int2)(Screen.Size * _viewport.Size);
			var screenAspectRatio = (float)screenSize.x / screenSize.y;

			var renderTargetWidth = screenSize.x;
			var renderTargetHeight = screenSize.y;

			var resolutionScaleX = (float)screenSize.x / (float)designSize.x;
			var resolutionScaleY = (float)screenSize.y / (float)designSize.y;

			var rectCalculated = false;

			// calculate the scale used by the PixelPerfect variants
			var pixelScale = 1;
			if (_resolutionPolicy != ResolutionPolicy.None)
			{
				if ((float)designSize.x / (float)designSize.y > screenAspectRatio)
					pixelScale = screenSize.x / designSize.x;
				else
					pixelScale = screenSize.y / designSize.y;

				if (pixelScale == 0)
					pixelScale = 1;
			}

			var renderRect = rect();

			switch (_resolutionPolicy)
			{
			case ResolutionPolicy.None:
				renderRect = .(0, 0, screenSize.width, screenSize.height);
				renderRect.X = renderRect.Y = 0;
				renderRect.Width = screenSize.x;
				renderRect.Height = screenSize.y;
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
				pixelScale = 1;
				if ((float)designSize.x / (float)designSize.y < screenAspectRatio)
				{
					var floatScale = (float)screenSize.x / (float)designSize.x;
					pixelScale = (.)Math.Ceiling(floatScale);
				}
				else
				{
					var floatScale = (float)screenSize.y / (float)designSize.y;
					pixelScale = (.)Math.Ceiling(floatScale);
				}

				if (pixelScale == 0)
					pixelScale = 1;

				renderRect.Width = (.)Math.Ceiling(designSize.x * pixelScale);
				renderRect.Height = (.)Math.Ceiling(designSize.y * pixelScale);
				renderRect.X = (screenSize.x - renderRect.Width) / 2;
				renderRect.Y = (screenSize.y - renderRect.Height) / 2;
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

				renderRect.Width = (.)Math.Ceiling(designSize.x * pixelScale);
				renderRect.Height = (.)Math.Ceiling(designSize.y * pixelScale);
				renderRect.X = (screenSize.x - renderRect.Width) / 2;
				renderRect.Y = (screenSize.y - renderRect.Height) / 2;
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

				renderRect.Width = (.)Math.Ceiling(designSize.x * resolutionScaleX);
				renderRect.Height = (.)Math.Ceiling(designSize.y * pixelScale);
				renderRect.X = (screenSize.x - renderRect.Width) / 2;
				renderRect.Y = (screenSize.y - renderRect.Height) / 2;
				rectCalculated = true;

				renderTargetWidth = (int)(designSize.x * resolutionScaleX / pixelScale);
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

				renderRect.Width = (.)Math.Ceiling(designSize.x * pixelScale);
				renderRect.Height = (.)Math.Ceiling(designSize.y * resolutionScaleY);
				renderRect.X = (screenSize.x - renderRect.Width) / 2;
				renderRect.Y = (screenSize.y - renderRect.Height) / 2;
				rectCalculated = true;

				renderTargetHeight = (int)(designSize.y * resolutionScaleY / pixelScale);

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

				renderRect = aabb2.FromRect((screenSize.x - renderWidth) / 2,
					(screenSize.y - renderHeight) / 2, renderWidth, renderHeight).ToRect();
			}

			return (int2(renderTargetWidth, renderTargetHeight), pixelScale, renderRect);
		}

		#endregion
	}
}
