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
	public class Core
	{
		private static Core _instance;

		public static bool DebugRenderEnabled = false;

		public readonly static Emitter Emitter = new .() ~ delete _;
		public readonly static Integrator Integration = new .() ~ delete _;

		public static extern bool IsExiting { get; }
		public static extern Window Window { get; }
		public static extern GraphicsManager Graphics { get; }
		public static extern Assets Assets { get; }

		public static Atlas2 Atlas ~ delete _;
		public static Input Input ~ delete _;
		public static Batch2D Draw ~ delete _;
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

		protected static extern void Update();
		protected static extern void Render();
		protected static extern void Initialize();
		protected static extern void Unload();

		private static void InternalInitialize()
		{
			Atlas = new .();
			Draw = new .();
			Initialize();
		}

		private static void InternalFixedUpdate()
		{
			Core.Window.Title = scope $"FPS @{FPS}";

			FixedUpdateCount++;
			Platform_Update();
			Input.Update();
			Emitter.Signal();

			Update();
		}

		protected static void InternalRender()
		{
			FrameCount++;

			int64 frameSum = 0;
			for (var i < MAXSAMPLES)
				frameSum += framelist[i];

			FPS = (int)(1.0 / (frameSum / MAXSAMPLES / Time.MicroToSeconds));

			Graphics.BeforeFrame();
			Render();
			Platform_Present();
		}

		public static void Run(Window.WindowArgs _windowArgs)
		{
			Core.ForceFixedTimestep = true;
			Core.Throttling = true;

			Platform_Initialize(_windowArgs);
			Platform_GetDisplays(Screen._resolutions);
			Input = new .();

			Screen.UpdateMatrix();

			Atlas = new .();
			Draw = new .();

			Initialize();

			int64 prevTime = Internal.GetTickCountMicro() - Time.FixedTimestep;

			while (!IsExiting)
			{
				//TODO: Check if window is focused or on battery and perhaps throttle down
				Assets.CheckForChangedAssets();
				Platform_BeginFrame();

				int64 time = Internal.GetTickCountMicro();

				framelist[FrameCount % MAXSAMPLES] = Math.Max(time - prevTime, 1);

				var msCounter = (time - prevTime);
				while (msCounter >= Time.FixedTimestep)
				{
					//Make sure everything is at its next state
					Core.Integration.Integrate(1f);

					Time.Update(prevTime, prevTime + Time.FixedTimestep);
					InternalFixedUpdate();
					Core.Integration.Advance();

					msCounter -= Time.FixedTimestep;
					prevTime += Time.FixedTimestep;
				}

				Integrate(time);
				InternalRender();
			}

			Unload();
			Platform_Destroy();
			Log.Message("Exited");
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

