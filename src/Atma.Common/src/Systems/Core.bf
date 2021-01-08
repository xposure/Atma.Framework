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
		private static Core _instance;

		public static bool DebugRenderEnabled = false;
		public static bool UpdateInputInFixedStep = true;

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
		public static FastNoise Noise = new .() ~ delete _;

		public static bool ForceFixedTimestep { get; set; }

		public static bool Throttling { get; set; }

		public static TextureFilter DefaultTextureFilter = .Linear;
		public static TextureWrap DefaultTextureWrap = TextureWrap.Clamp;

		private const uint MAXFRAMECAPTURES = 100;
		private static int64[MAXFRAMECAPTURES] renderFrameList;
		private static int64[MAXFRAMECAPTURES] updateFrameList;

		public static uint64 FrameCount;
		public static uint64 UpdateCount;

		public static int FPS;
		public static int UPS;
		private Window.WindowArgs _windowArgs ~ delete _windowArgs.Title;

		public this(StringView title, int width, int height, Window.WindowFlags windowFlags = .Hidden)
		{
			Contract.IsTrue(_instance == null);
			_instance = this;

			_windowArgs.Title = new String(title);
			_windowArgs.Width = width;
			_windowArgs.Height = height;
			_windowArgs.Flags = windowFlags;
		}

		protected abstract void Update();
		protected abstract void FixedUpdate();
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

			ImGuiImpl.Initialize();

			_instance.Initialize();

			Emitter.EmitNow(CoreEvents.Initialize());
		}

		private static int CalculateFPS(ref int64[MAXFRAMECAPTURES] captures, int64 time, ref uint64 counter){

			captures[counter++ % MAXFRAMECAPTURES] = time;

			let start = captures[counter % MAXFRAMECAPTURES];
			let end =  captures[(counter - 1) % MAXFRAMECAPTURES];
			let totalTime = end - start;
			let frames = Math.Min(MAXFRAMECAPTURES, counter);
			let avgDelta = (totalTime / (.)frames / Time.MicroToSeconds);
			return (int)Math.Floor(1.0 / avgDelta);

			//Core.Window.Title = scope $"FPS @{FPS}";
		}

		private static void InternalUpdate()
		{
			Core.TimeRuler.BeginMark("Update", .Green);
			Time.Step();

			/*if (!Core.UpdateInputInFixedStep)
			{
				Platform_Update();
				Input.Update();
			}*/

			Emitter.Signal();

			Emitter.EmitNow(CoreEvents.UpdateBegin());
			_instance.Update();
			Emitter.EmitNow(CoreEvents.UpdateEnd());
			Core.TimeRuler.EndMark("Update");
		}

		private static void InternalFixedUpdate(int64 time)
		{
			UPS = CalculateFPS(ref updateFrameList, time, ref UpdateCount);

			Core.TimeRuler.BeginMark("FixedUpdate", .Green);
			Time.Step();


			Emitter.Signal();

			Emitter.EmitNow(CoreEvents.FixedUpdateBegin());
			_instance.FixedUpdate();
			Emitter.EmitNow(CoreEvents.FixedUpdateEnd());
			Core.TimeRuler.EndMark("FixedUpdate");
		}

		protected static void InternalRender(int64 time)
		{
			FPS = CalculateFPS(ref renderFrameList, time, ref FrameCount);
			Core.Window.Title = scope $"FPS @{FPS}, UPS @{UPS}";

			Core.TimeRuler.BeginMark("Render", .Red);

			Emitter.EmitNow(CoreEvents.RenderBegin());
			Graphics.BeforeFrame();
			_instance.Render();
			Emitter.EmitNow(CoreEvents.RenderEnd());
			Core.TimeRuler.EndMark("Render");

			Core.TimeRuler.Render();

			Platform_Present();
		}

		public int Run()
		{
			InternalInitialize(_windowArgs);
			/*Core.TimeRuler.Enabled = true;
			Core.TimeRuler.ShowLog = true;*/

			Core.Window.VSync = true;
			int64 prevTime = Internal.GetTickCountMicro() - Time.InverseFixedTimestep;
			while (!IsExiting)
			{
				Core.TimeRuler.StartFrame();
				//TODO: Check if window is focused or on battery and perhaps throttle down
				Assets.CheckForChangedAssets();
				Platform_BeginFrame();

				int64 time = Internal.GetTickCountMicro();

				Platform_Update();
				Input.Update();

				var msCounter = time - prevTime;
				if (msCounter >= Time.InverseFixedTimestep)
				{
					//Make sure everything is at its next state
					Core.Integration.Integrate(1f);

					var steps = Time.MaxSteps;
					while (msCounter >= Time.InverseFixedTimestep)
					{
						//only step X frames and then let time catch up
						//this needs to be handled better and probably should leverage
						//the integration code to catch up at say 1.5x?
						if (steps-- > 0)
						{

							// we are tying update to fixed up until we
							//fix how the time class works
							InternalUpdate();
							//Console.WriteLine(scope $"Fixed {time}");
							InternalFixedUpdate(time);
						}

						msCounter -= Time.InverseFixedTimestep;
						prevTime += Time.InverseFixedTimestep;
					}

					//Snapshot state
					Core.Integration.Advance();
				}

				let integration = msCounter / (float)Time.InverseFixedTimestep;
				//Console.WriteLine(scope $"{integration}");
				Core.Integration.Integrate(integration);

				//Time.Delta = msCounter / (float)Time.MicroToSeconds;
				InternalRender(time);
				//Time.Delta = (.)(Time.InverseFixedTimestep / Time.MicroToSeconds);
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

