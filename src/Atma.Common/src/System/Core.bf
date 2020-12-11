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
	public static class Core
	{
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
		public static Scene Scene ~ delete _;
		public static Random Random = new .() ~ delete _;



		public static bool ForceFixedTimestep { get; set; }

		public static bool Throttling { get; set; }

		public static TextureFilter DefaultTextureFilter = .Linear;
		public static TextureWrap DefaultTextureWrap = TextureWrap.Clamp;

		private const int MAXSAMPLES = 100;
		private static int64[MAXSAMPLES] framelist;

		public static uint64 FrameCount;
		public static uint64 UpdateCount;

		public static int FPS;

		static this()
		{
			ForceFixedTimestep = true;
			Throttling = true;
		}

		protected static void FixedUpdate()
		{
			Core.Window.Title = scope $"FPS @{FPS}";

			UpdateCount++;
			Platform_Update();
			Input.Update();
			Emitter.Signal();
			Scene?.FixedUpdate();
		}

		protected static void Render()
		{
			FrameCount++;

			int64 frameSum = 0;
			for (var i < MAXSAMPLES)
				frameSum += framelist[i];

			FPS = (int)(1.0 / (frameSum / MAXSAMPLES / Time.MicroToSeconds));

			Graphics.BeforeFrame();
			Scene?.[Friend]Render();
			Platform_Present();
		}

		public static int Run<T>(StringView title, int width, int height, Window.WindowFlags flags = .ScaleToMonitor)
			where T : Scene
		{
			Window.WindowArgs _windowArgs = ?;
			_windowArgs.Title = scope String(title);
			_windowArgs.Width = width;
			_windowArgs.Height = height;
			_windowArgs.Flags = flags;

			Platform_Initialize(_windowArgs);
			Platform_GetDisplays(Screen._resolutions);
			Input = new .();

			Screen.UpdateMatrix();

			Atlas = new .();
			Draw = new .();
			Scene = new T();

			//TODO: once we handle scene transitions we need to handle init better
			Scene.Initialize();

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
					FixedUpdate();
					Core.Integration.Advance();

					msCounter -= Time.FixedTimestep;
					prevTime += Time.FixedTimestep;
				}

				let t = Time.Integrate(time);
				Core.Integration.Integrate(t);

				Render();
			}

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

