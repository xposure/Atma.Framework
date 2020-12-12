namespace Atma
{
	using SDL2;
	using System;
	using System.Collections;
	using internal Atma;

	static class WindowOS
	{
		[Import("user32.dll"), CLink, CallingConvention(.Stdcall)]
		public static extern bool SetProcessDPIAware();
	}

	public extension Core
	{
		protected static override bool Platform_OnBattery()
		{
			//TODO: Possibly cache this and use OnInterval?
			let powerState = SDL.GetPowerInfo(?, ?);
			return powerState == .SDL_POWERSTATE_ON_BATTERY;
		}

		private static bool _isExiting = false;
		public static override bool IsExiting => _isExiting;

		protected override static void Platform_Destroy()
		{
		}

		protected static override void Platform_Exit()
		{
			_isExiting = true;
		}

		protected static override void Platform_GetDisplays(List<Display> displays)
		{
			var numDisplays = SDL.SDL_GetNumVideoDisplays();
			for (int i = 0; i < numDisplays; i++)
				displays.Add(GetDisplay(i));
		}

		private static Display GetDisplay(int index)
		{
			let name = SDL.GetDisplayName(index);

			SDL.GetDisplayBounds((.)index, let rect);

			float hidpiRes = 72f;
			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
				hidpiRes = 96;
			SDL.GetDisplayDPI((.)index, let ddpi, ?, ?);

			return .(index, false, scope String(name), .(rect.x, rect.y, rect.w, rect.h), .(float2.Ones * (ddpi / hidpiRes)));
		}

		protected static override void Platform_Initialize(Window.WindowArgs windowArgs)
		{
			//SDL will change our output location so we need to capture prior to init
			let startupDirectory = scope String();
			System.IO.Directory.GetCurrentDirectory(startupDirectory);


			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
				WindowOS.SetProcessDPIAware();

			SDL.Version version;
			SDL.GetVersion(out version);
			Log.Message("Init SDL Version {0}.{1}.{2}", version.major, version.minor, version.patch);

			// init SDL
			if (SDL.Init(.Everything) != 0)
			{
				var error = SDL.GetError();
				Runtime.Assert(false, scope String(error));
			}

			// OpenGL attributes
			SDL.GL_SetAttribute(.GL_CONTEXT_MAJOR_VERSION, 3);
			SDL.GL_SetAttribute(.GL_CONTEXT_MINOR_VERSION, 2);
			SDL.GL_SetAttribute(.GL_CONTEXT_PROFILE_MASK, (.)SDL.SDL_GLProfile.GL_CONTEXT_PROFILE_CORE);
			SDL.GL_SetAttribute(.GL_CONTEXT_FLAGS, (.)SDL.SDL_GLContextFlags.GL_CONTEXT_FORWARD_COMPATIBLE_FLAG);
			SDL.GL_SetAttribute(.GL_DOUBLEBUFFER, 1);
		}

		protected static override void Platform_Update()
		{
			Atma.Input._capsLock = SDL.GetModState() & .Caps > 0;
			Atma.Input._numLock = SDL.GetModState() & .Num > 0;
			Atma.Input._mouseWheel = int2.Zero;
			Atma.Input._mousePosition = (int2)Window.Mouse;

			while (SDL.PollEvent(let e) != 0)
			{
				switch (e.type)
				{
					// Quit
				case .Quit:
					_isExiting = true;
					return;

					// Window Event
				case .WindowEvent:
					{
						// find the window
						switch (e.window.windowEvent)
						{
						case .Resized:
							Window.OnResize.Invoke(Window);
							break;

						case .Close:
							Window.OnCloseRequested.Invoke(Window);
							break;

							// Update visible
						case .Shown: fallthrough;
						case .Restored:
							//sdlWindow.Restored();
							break;
						case .Hidden: fallthrough;
						case .Minimized:
							//sdlWindow.Minimized();
							break;

							// Call onFocus
						case .TAKE_FOCUS: fallthrough;
						case .FocusGained:
							Window.OnFocus.Invoke(Window);
							break;

						default:
						}
					}
					break;

				// Input Events
				case .KeyDown: fallthrough;
				case .KeyUp: fallthrough;
				case .TextEditing: fallthrough;
				case .TextInput: fallthrough;
				case .KeyMapChanged: fallthrough;
				case .MouseButtonDown: fallthrough;
				case .MouseButtonUp: fallthrough;
				case .MouseWheel: fallthrough;
				case .JoyAxisMotion: fallthrough;
				case .JoyBallMotion: fallthrough;
				case .JoyHatMotion: fallthrough;
				case .JoyButtonDown: fallthrough;
				case .JoyButtonUp: fallthrough;
				case .JoyDeviceAdded: fallthrough;
				case .JoyDeviceRemoved: fallthrough;
				case .ControllerAxismotion: fallthrough;
				case .ControllerButtondown: fallthrough;
				case .ControllerButtonup: fallthrough;
				case .ControllerDeviceadded: fallthrough;
				case .ControllerDeviceremoved: fallthrough;
				case .ControllerDeviceremapped:
					Input.ProcessEvent(e);
				default:
				}
				var error = scope String(SDL.GetError());
				if (!String.IsNullOrEmpty(error))
					Log.Error("SDL ERROR[{0}] : {1}", e.type, error);
				SDL.ClearError();
			}
		}

		protected override static void Platform_BeginFrame() { }

		protected static override void Platform_Present()
		{
			GL.BindVertexArray(0);
			GL.BindFramebuffer((.)GLEnum.FRAMEBUFFER, 0);

			Core.Emitter.EmitNow<CoreEvents.Present>(CoreEvents.Present());
			Window.Present();
		}
	}
}
