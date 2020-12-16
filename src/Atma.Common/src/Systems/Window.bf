using System;
using System.Threading;
using internal Atma;

namespace Atma
{
	/// <summary>
	/// A Window.
	/// 
	/// Screen Coordinates may be different on each platform.
	/// For example, on Windows High DPI displays, this is always 1-1 with
	/// the pixel size of the Window. On MacOS Retina displays, this is
	/// usually 1-2 with the pixel size of the Window.
	/// 
	/// The Window is only able to be Rendered to during is OnRender callback. Attempting
	/// to render to the Window outside of that will throw an exception.
	/// </summary>
	public sealed class Window : RenderTarget
	{
		public struct WindowArgs
		{
			public String Title;
			public int Width;
			public int Height;
			public WindowFlags Flags;
		}

		/// <summary>
		/// Window Creation Flags
		/// </summary>
		//[Flags]
		public enum WindowFlags
		{
			/// <summary>
			/// No Flags
			/// </summary>
			None = 0,

			/// <summary>
			/// Hides the Window when it is created
			/// </summary>
			Hidden = 1,

			/// <summary>
			/// Gives the Window a Transparent background
			/// </summary>
			Transparent = 2,

			/// <summary>
			/// Whether the Window should automatically scale to the Monitor
			/// Ex. if a 1280x720 window is created, but the Monitor DPI is 2, this will
			/// create a window at 2560x1440
			/// </summary>
			ScaleToMonitor = 4,

			/// <summary>
			/// Whether the Window BackBuffer should use Multi Sampling. The exact value
			/// of multisampling depends on the platform
			/// </summary>
			MultiSampling = 8,

			/// <summary>
			/// Whether the Window should start fullscreen
			/// </summary>
			Fullscreen = 16
		}



		/*/// <summary>
		/// A pointer to the underlying OS Window
		/// </summary>
		public void* NativePointer => PlatformPointer;*/

		public GraphicsContext GraphicsContext => PlatformGraphicsContext;

		/// <summary>
		/// Position of the Window, in Screen coordinates. Setting the Position will toggle off Fullscreen.
		/// </summary>
		public int2 Position
		{
			get => PlatformPosition;
			set
			{
				if (PlatformFullscreen)
					PlatformFullscreen = false;

				PlatformPosition = value;
			}
		}

		/// <summary>
		/// The size of the Window, in Screen coordinates. Setting the Size will toggle off Fullscreen.
		/// </summary>
		public int2 WindowSize
		{
			get => PlatformSize;
			set
			{
				if (PlatformFullscreen)
					PlatformFullscreen = false;

				PlatformSize = value;
			}
		}

		/// <summary>
		/// The X position of the Window, in Screen coordinates. Setting the Position will toggle off Fullscreen.
		/// </summary>
		public int X
		{
			get => Position.x;
			set => Position = .(value, Y);
		}

		/// <summary>
		/// The X position of the Window, in Screen coordinates. Setting the Position will toggle off Fullscreen.
		/// </summary>
		public int Y
		{
			get => Position.y;
			set => Position = .(X, value);
		}

		/// <summary>
		/// The Width of the Window, in Screen coordinates. Setting the Width will toggle off Fullscreen.
		/// </summary>
		public int WindowWidth
		{
			get => WindowSize.x;
			set => WindowSize = .(value, WindowSize.y);
		}

		/// <summary>
		/// The Height of the Window, in Screen coordinates. Setting the Height will toggle off Fullscreen.
		/// </summary>
		public int WindowHeight
		{
			get => WindowSize.y;
			set => WindowSize = .(WindowSize.x, value);
		}

		/// <summary>
		/// The Window bounds, in Screen coordinates. Setting the Bounds will toggle off Fullscreen.
		/// </summary>
		public rect Bounds
		{
			get
			{
				var position = Position;
				var size = WindowSize;

				return .(position.x, position.y, size.x, size.y);
			}
			set
			{
				WindowSize = value.Size;
				Position = value.Position;
			}
		}

		protected override bool InternalResize(int2 size)
		{
			WindowSize = size;
			return true;
		}

		/// <summary>
		/// The Render Width of the Window, in Pixels
		/// </summary>
		public override int Width => PlatformRenderSize.x;

		/// <summary>
		/// The Render Height of the Window, in Pixels
		/// </summary>
		public override int Height => PlatformRenderSize.y;

		public int2 RenderSize => PlatformRenderSize;

		/// <summary>
		/// The drawable bounds of the Window, in Pixels
		/// </summary>
		public rect RenderBounds => .(0, 0, PlatformRenderSize.x, PlatformRenderSize.y);

		/// <summary>
		/// The scale of the Render size compared to the Window size
		/// On Windows and Linux this is always 1.
		/// On MacOS Retina displays this is 2.
		/// </summary>
		public float2 RenderScale => .(PlatformRenderSize.x / (float)WindowWidth, PlatformRenderSize.y / (float)WindowHeight);

		/// <summary>
		/// The Content Scale of the Window
		/// On High DPI displays this may be larger than 1
		/// Use this to appropriately scale UI
		/// </summary>
		public float2 ContentScale => PlatformContentScale;

		/// <summary>
		/// A callback when the Window is resized by the user
		/// </summary>
		public Event<Action<Window>> OnResize ~ _.Dispose();

		/// <summary>
		/// A callback when the Window is focused
		/// </summary>
		public Event<Action<Window>> OnFocus ~ _.Dispose();

		/// <summary>
		/// A callback when the Window is about to close
		/// </summary>
		public Event<Action<Window>> OnClose ~ _.Dispose();

		/// <summary>
		/// A callback when the Window has been requested to be closed (ex. by pressing the Close menu button).
		/// By default this calls Window.Close()
		/// </summary>
		public Event<Action<Window>> OnCloseRequested ~ _.Dispose();

		/// <summary>
		/// Gets or Sets the Title of this Window
		/// </summary>
		public StringView Title
		{
			get => PlatformTitle;
			set => PlatformTitle = value;
		}

		/// <summary>
		/// Gets if the Window is currently Open
		/// </summary>
		public bool Opened => PlatformOpened;

		/*/// <summary>
		/// Gets or Sets whether the Window has a Border
		/// </summary>
		public bool Bordered
		{
			get => PlatformBordered;
			set => PlatformBordered = value;
		}*/

		/// <summary>
		/// Gets or Sets whether the Window is resizable by the user
		/// </summary>
		public bool Resizable
		{
			get => PlatformResizable;
			set => PlatformResizable = value;
		}

		/// <summary>
		/// Gets or Sets whether the Window is in Fullscreen Mode
		/// </summary>
		public bool Fullscreen
		{
			get => PlatformFullscreen;
			set => PlatformFullscreen = value;
		}

		/// <summary>
		/// Gets or Sets whether the Window is Visible to the user
		/// </summary>
		public bool Visible
		{
			get => PlatformVisible;
			set => PlatformVisible = value;
		}

		/// <summary>
		/// Gets or Sets whether the Window synchronizes the vertical redraw
		/// </summary>
		public bool VSync
		{
			get => PlatformVSync;
			set => PlatformVSync = value;
		}

		/// <summary>
		/// Whether this is the currently focused Window
		/// </summary>
		public bool Focused => PlatformFocused;

		/// <summary>
		/// The Mouse position relative to the top-left of the Window, in Screen coordinates
		/// </summary>
		public float2 Mouse => PlatformMouse;

		/// <summary>
		/// The position of the Mouse in pixels, relative to the top-left of the Window
		/// </summary>
		public float2 RenderMouse => PlatformMouse * RenderScale;

		/// <summary>
		/// The position of the mouse relative to the top-left of the Screen, in Screen coordinates
		/// </summary>
		public float2 ScreenMouse => PlatformScreenMouse;

		/// <summary>
		/// Whether the mouse is currently over this Window
		/// </summary>
		public bool MouseOver => PlatformMouseOver;

		/*public this(String title, int width, int height, WindowFlags flags = WindowFlags.ScaleToMonitor) :
		this(App.System, title, width, height, flags)
		{
		}*/

		this
		{
			Renderable = true;
			OnResize.Add(new (window) =>
				{
					Screen.UpdateMatrix();
					Core.Emitter.Emit(CoreEvents.WindowResize(window.WindowWidth, window.WindowHeight));
				});
			OnFocus.Add(new (window) => Core.Emitter.Emit(CoreEvents.WindowFocus(window.Focused)));
			OnClose.Add(new (window) => Core.Emitter.Emit(CoreEvents.WindowClose()));
		}

		/*public this()
		{
			//TODO: This is not being called
			Renderable = true;
			Runtime.FatalError("Ctor is now being called so you can remove the renderable code in sdl extension
		window"); //system.[Friend]windows.Add(this);

			// create implementation object
			/*PlatformOnFocus = new () => OnFocus?.Invoke(this);
			PlatformOnClose = new () => OnClose?.Invoke(this);
			PlatformOnCloseRequested = new () => OnCloseRequested?.Invoke(this);*/

			// default close request to... close the window!
			//OnCloseRequested = new (window) => window.Close();
		}*/

		public void Focus()
		{
			PlatformFocus();
		}

		/// <summary>
		/// Presents the drawn contents of the Window
		/// </summary>
		public void Present()
		{
			PlatformPresent();
		}

		/// <summary>
		/// Closes the Window
		/// </summary>
		public void Close()
		{
			PlatformClose();
		}

	}
}

