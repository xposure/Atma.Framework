using System;
using System.Collections;
using System.IO;
using System.Threading;
using System.Diagnostics;
using internal Atma;

namespace Atma
{
	/// <summary>
	/// Core System Module, used for managing Windows and Input
	/// </summary>
	public abstract class Core
	{
		private static Core _instance ~ delete _;

		public static bool DebugRenderEnabled = false;

		public readonly static Emitter Emitter = new .() ~ delete _;
		public readonly static Integrator Integration = new .() ~ delete _;

		public static extern bool IsExiting { get; }

		public static Window Window ~ delete _;
		public static GraphicsManager Graphics ~ delete _;
		public static Assets Assets ~ delete _;
		public static SpriteAtlas Atlas ~ delete _;
		public static Input Input ~ delete _;
		public static Batch2D Draw ~ delete _;
		public static SpriteFont DefaultFont;
		public static TimeRuler TimeRuler ~ delete _;


		public static Random Random = new .() ~ delete _;

		public static bool ForceFixedTimestep { get; set; }

		public static bool Throttling { get; set; }

		public static TextureFilter DefaultTextureFilter = .Linear;
		public static TextureWrap DefaultTextureWrap = TextureWrap.Clamp;

		private const int MAXSAMPLES = 100;
		private static int64[MAXSAMPLES] framelist;

		public static uint64 FrameCount;
		public static uint64 FixedUpdateCount;

		public static int FPS;

		protected static void Integrate(int64 time)
		{
			let t = Time.Integrate(time);
			Core.Integration.Integrate(t);
		}

		protected abstract void Update();
		protected abstract void Render();
		protected abstract void Initialize();
		protected abstract void Unload();

		private static void InternalInitialize(Window.WindowArgs windowArgs)
		{
			let startupDirectory = scope String();
			System.IO.Directory.GetCurrentDirectory(startupDirectory);

			Core.ForceFixedTimestep = true;
			Core.Throttling = true;

			Platform_Initialize(windowArgs);

			Window = new Window();
			Window.[Friend]PlatformInitialize(windowArgs);
			Window.Visible = true;

			Platform_GetDisplays(Screen._resolutions);

			Screen.UpdateMatrix();

			Core.Graphics = new .(Window);

			TimeRuler = new .();
			Input = new .();
			Assets = new .(scope $"{startupDirectory}\\content");
			Atlas = new .();
			Draw = new .();

			_instance.Initialize();

			Emitter.EmitNow(CoreEvents.Initialize());
		}

		private static void InternalFixedUpdate()
		{
			Core.TimeRuler.BeginMark("Update", .Green);
			Time.Step();

			Core.Window.Title = scope $"FPS @{FPS}";

			FixedUpdateCount++;
			Platform_Update();
			Input.Update();
			Emitter.Signal();

			Emitter.EmitNow(CoreEvents.UpdateBegin());
			_instance.Update();
			Emitter.EmitNow(CoreEvents.UpdateEnd());
			Core.TimeRuler.EndMark("Update");
		}

		protected static void InternalRender()
		{
			Core.TimeRuler.BeginMark("Render", .Red);
			FrameCount++;

			int64 frameSum = 0;
			for (var i < MAXSAMPLES)
				frameSum += framelist[i];

			FPS = (int)(1.0 / (frameSum / MAXSAMPLES / Time.MicroToSeconds));

			Emitter.EmitNow(CoreEvents.RenderBegin());
			Graphics.BeforeFrame();
			_instance.Render();
			Emitter.EmitNow(CoreEvents.RenderEnd());
			Core.TimeRuler.EndMark("Render");

			Core.TimeRuler.Render();

			Platform_Present();
		}

		public static int Run(StringView title, int width, int height, Window.WindowFlags windowFlags = .Hidden)
		{
			Window.WindowArgs windowArgs = ?;
			windowArgs.Title = scope String(title);
			windowArgs.Width = width;
			windowArgs.Height = height;
			windowArgs.Flags = windowFlags;

			InternalInitialize(windowArgs);
			/*Core.TimeRuler.Enabled = true;
			Core.TimeRuler.ShowLog = true;*/

			int64 prevTime = Internal.GetTickCountMicro() - Time.FixedTimestep;
			while (!IsExiting)
			{
				Core.TimeRuler.StartFrame();
				//TODO: Check if window is focused or on battery and perhaps throttle down
				Assets.CheckForChangedAssets();
				Platform_BeginFrame();

				int64 time = Internal.GetTickCountMicro();

				framelist[FrameCount % MAXSAMPLES] = Math.Max(time - prevTime, 1);

				var msCounter = (time - prevTime);
				if (msCounter >= Time.FixedTimestep)
				{
					//Make sure everything is at its next state
					Core.Integration.Integrate(1f);

					var steps = Time.MaxSteps;
					while (msCounter >= Time.FixedTimestep)
					{
						//only step X frames and then let time catch up
						//this needs to be handled better and probably should leverage
						//the integration code to catch up at say 1.5x?
						if (steps-- > 0)
							InternalFixedUpdate();

						msCounter -= Time.FixedTimestep;
						prevTime += Time.FixedTimestep;
					}

					//Snapshot state
					Core.Integration.Advance();
				}

				Integrate(time);
				InternalRender();
			}

			Emitter.EmitNow(CoreEvents.Shutdown());
			_instance.Unload();
			Window.[Friend]PlatformDestroy();
			Platform_Destroy();
			Log.Message("Exited");

			return 0;
		}

		/// <summary>
		/// Begins Exiting the Application. This will not exit the application immediately and will finish the current
		// Update. </summary>
		public static void Exit()
		{
			Platform_Exit();
		}
	}
}

