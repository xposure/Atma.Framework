using System;
using SDL2;

namespace Atma
{
	public extension Window//: Window.Platform
	{
		private SDL.Window* _window ~ SDL.DestroyWindow(_window);
		private String _title = new .() ~ delete _;

		public readonly uint SDLWindowID;

		//private readonly SDL_GraphicsContext glContext ~ delete _;

		private bool isBordered = true;
		private bool isFullscreen = false;
		private bool isResizable = false;
		private bool isVisible = false;
		private bool isVSyncEnabled = true;
		private bool isClosed = false;

		public SDL.Window* SDLWindow => _window;

		//protected override  IGraphicsContext GraphicsContext => glContext;

		protected override int2 PlatformPosition
		{
			get
			{
				SDL.GetWindowPosition(_window, let x, let y);
				return int2(x, y);
			}
			set
			{
				SDL.SetWindowPosition(_window, (.)value.x, (.)value.y);
			}
		}

		protected override int2 PlatformSize
		{
			get
			{
				SDL.GetWindowSize(_window, let w, let h);
				return int2(w, h);
			}
			set
			{
				SDL.SetWindowSize(_window, (.)value.x, (.)value.y);
			}
		}

		protected override int2 PlatformRenderSize
		{
			get
			{
				SDL.GL_GetDrawableSize(_window, let w, let h);
				return int2(w, h);
			}
		}

		protected override float2 PlatformContentScale
		{
			get
			{
				float hidpiRes = 72f;

				if (Environment.OSVersion.Platform == PlatformID.Win32NT)
					hidpiRes = 96;

				var index = SDL.SDL_GetWindowDisplayIndex(_window);
				SDL.GetDisplayDPI((.)index, let ddpi, let hdpi, let vpdi);
				return float2.Ones * (ddpi / hidpiRes);
			}
		}

		protected override bool PlatformOpened => !isClosed;

		protected override StringView PlatformTitle
		{
			get
			{
				_title.Clear();
				_title.Append(SDL.GetWindowTitle(_window));
				return _title;
			}
			set
			{
				_title.Clear();
				_title.Append(value);
				SDL.SetWindowTitle(_window, _title);
			}
		}

		protected override bool PlatformBordered
		{
			get => isBordered;
			set
			{
				if (isBordered != value)
				{
					isBordered = value;
					SDL.SetWindowBordered(_window, isBordered ? SDL.Bool.True : SDL.Bool.False);
				}
			}
		}

		protected override bool PlatformResizable
		{
			get => isResizable;
			set
			{
				if (isResizable != value)
				{
					isResizable = value;
					SDL.SetWindowResizable(_window, isResizable ? SDL.Bool.True : SDL.Bool.False);
				}
			}
		}

		protected override bool PlatformFullscreen
		{
			get => isFullscreen;
			set
			{
				if (isFullscreen != value)
				{
					isFullscreen = value;
					if (isFullscreen)
						SDL.SetWindowFullscreen(_window, (uint)SDL.WindowFlags.FullscreenDesktop);
					else
						SDL.SetWindowFullscreen(_window, (uint)0);
				}
			}
		}

		protected override bool PlatformVisible
		{
			get => isVisible;
			set
			{
				if (isVisible != value)
				{
					isVisible = value;
					if (isVisible)
						SDL.ShowWindow(_window);
					else
						SDL.HideWindow(_window);
				}
			}
		}

		protected override bool PlatformVSync
		{
			get => isVSyncEnabled;
			set => isVSyncEnabled = value;
		}

		protected override bool PlatformFocused
		{
			get => (SDL.GetWindowFlags(_window) & (uint)SDL.WindowFlags.InputFocus) > 0;
		}

		protected override int2 PlatformMouse
		{
			get
			{
				int32 x = ?, y = ?;
				SDL.GetWindowPosition(_window, let winX, let winY);
				SDL.GetGlobalMouseState(&x, &y);
				return .(x - winX, y - winY);
			}
		}

		protected override int2 PlatformScreenMouse
		{
			get
			{
				int32 x = ?, y = ?;
				SDL.GetGlobalMouseState(&x, &y);
				return .(x, y);
			}
		}

		protected override bool PlatformMouseOver
		{
			get => (SDL.GetWindowFlags(_window) & (uint)SDL.WindowFlags.MouseFocus) > 0;
		}

		public this(String title, int width, int height, WindowFlags flags)
		{
			var sdlWindowFlags =
				SDL.WindowFlags.AllowHighDPI |
				SDL.WindowFlags.Hidden |
				SDL.WindowFlags.Resizable;

			//sdlWindowFlags |= .InputGrabbed;

			if (flags.HasFlag(WindowFlags.Fullscreen))
			{
				sdlWindowFlags |= SDL.WindowFlags.FullscreenDesktop;
				isFullscreen = true;
			}

			sdlWindowFlags |= SDL.WindowFlags.OpenGL;

			//if (system.Windows.Count > 0)
			SDL.GL_SetAttribute(SDL.SDL_GLAttr.GL_SHARE_WITH_CURRENT_CONTEXT, SDL.SDL_GLProfile.GL_CONTEXT_PROFILE_CORE);

			// create the window
			_window = SDL.CreateWindow(title, (.)0x2FFF0000, (.)0x2FFF0000, (.)width, (.)height, sdlWindowFlags);
			Runtime.Assert(_window != null, "Failed to create a new Window");
			SDLWindowID = SDL.GetWindowID(_window);

			if (flags.HasFlag(WindowFlags.Transparent))
				SDL.SetWindowOpacity(_window, 0f);

			// scale to monitor for HiDPI displays
			if (flags.HasFlag(WindowFlags.ScaleToMonitor))
			{
				float hidpiRes = 72f;
				if (Environment.OSVersion.Platform == PlatformID.Win32NT)
					hidpiRes = 96;

				var display = SDL.SDL_GetWindowDisplayIndex(_window);
				SDL.GetDisplayDPI((.)display, let ddpi, let hdpi, let vdpi);

				var dpi = (ddpi / hidpiRes);
				if (dpi != 1)
				{
					SDL.GetDesktopDisplayMode((.)display, let mode);
					SDL.SetWindowPosition(_window, (.)(mode.w - width * dpi) / 2, (.)(mode.h - height * dpi) / 2);
					SDL.SetWindowSize(_window, (.)(width * dpi), (.)(height * dpi));
				}
			}

			// show window
			isVisible = false;
			if (!flags.HasFlag(WindowFlags.Hidden))
			{
				isVisible = true;
				SDL.ShowWindow(_window);
			}

			_context = new SDL_GraphicsContext(_window);
		}

		private SDL_GraphicsContext _context;

		protected override GraphicsContext PlatformGraphicsContext => _context;

		protected override void PlatformFocus()
		{
			SDL.RaiseWindow(_window);
		}

		protected override void PlatformPresent()
		{
			//glContext.MakeActive();
			SDL.GL_SetSwapInterval(isVSyncEnabled ? 1 : 0);
			SDL.GL_SwapWindow(_window);
		}

		protected override void PlatformResize(int2 size)
		{
			SDL.SetWindowSize(_window, (.)size.x, (.)size.y);
		}

		protected override void PlatformClose()
		{
			if (!isClosed)
			{
				isClosed = true;

				OnClose.Invoke(this);
				//glContext?.Dispose();
				SDL.DestroyWindow(_window);
			}
		}

		public void PlatformResized()
		{
			OnResize.Invoke(this);
		}

		public void PlatformCloseRequested()
		{
			OnCloseRequested.Invoke(this);
		}

		public void PlatformFocusGained()
		{
			OnFocus.Invoke(this);
		}

		public void PlatformMinimized()
		{
			isVisible = false;
		}

		public void PlatformRestored()
		{
			isVisible = true;
		}
	}
}
