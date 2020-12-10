//TODO IMGUI
/*using System;
using ImGui;
using SDL2;

namespace ImGui
{
	public static class ImGuiImplSDL
	{
		// dear imgui: Platform Binding for SDL2
		// This needs to be used along with a Renderer (e.g. DirectX11, OpenGL3, Vulkan..)
		// (Info: SDL2 is a cross-platform general purpose library for handling windows, inputs, graphics context creation, etc.)
		// (Requires: SDL 2.0. Prefer SDL 2.0.4+ for full feature support.)

		// Implemented features:
		//  [X] Platform: Mouse cursor shape and visibility. Disable with 'io.ConfigFlags |= ImGuiConfigFlags_NoMouseCursorChange'.
		//  [X] Platform: Clipboard support.
		//  [X] Platform: Keyboard arrays indexed using SDL_SCANCODE_* codes, e.g. ImGui::IsKeyPressed(SDL_SCANCODE_SPACE).
		//  [X] Platform: Gamepad support. Enabled with 'io.ConfigFlags |= ImGuiConfigFlags_NavEnableGamepad'.
		// Missing features:
		//  [ ] Platform: SDL2 handling of IME under Windows appears to be broken and it explicitly disable the regular Windows IME. You can restore Windows IME by compiling SDL with SDL_DISABLE_WINDOWS_IME.

		// You can copy and use unmodified imgui_impl_* files in your project. See main.cpp for an example of using this.
		// If you are new to dear imgui, read examples/README.txt and read the documentation at the top of imgui.cpp.
		// https://github.com/ocornut/imgui

		// CHANGELOG
		// (minor and older changes stripped away, please see git history for details)
		//  2020-02-20: Inputs: Fixed mapping for ImGuiKey_KeyPadEnter (using SDL_SCANCODE_KP_ENTER instead of SDL_SCANCODE_RETURN2).
		//  2019-12-17: Inputs: On Wayland, use SDL_GetMouseState (because there is no global mouse state).
		//  2019-12-05: Inputs: Added support for ImGuiMouseCursor_NotAllowed mouse cursor.
		//  2019-07-21: Inputs: Added mapping for ImGuiKey_KeyPadEnter.
		//  2019-04-23: Inputs: Added support for SDL_GameController (if ImGuiConfigFlags_NavEnableGamepad is set by user application).
		//  2019-03-12: Misc: Preserve DisplayFramebufferScale when main window is minimized.
		//  2018-12-21: Inputs: Workaround for Android/iOS which don't seem to handle focus related calls.
		//  2018-11-30: Misc: Setting up io.BackendPlatformName so it can be displayed in the About Window.
		//  2018-11-14: Changed the signature of ImGui_ImplSDL2_ProcessEvent() to take a 'const SDL_Event*'.
		//  2018-08-01: Inputs: Workaround for Emscripten which doesn't seem to handle focus related calls.
		//  2018-06-29: Inputs: Added support for the ImGuiMouseCursor_Hand cursor.
		//  2018-06-08: Misc: Extracted imgui_impl_sdl.cpp/.h away from the old combined SDL2+OpenGL/Vulkan examples.
		//  2018-06-08: Misc: ImGui_ImplSDL2_InitForOpenGL() now takes a SDL_GLContext parameter.
		//  2018-05-09: Misc: Fixed clipboard paste memory leak (we didn't call SDL_FreeMemory on the data returned by SDL_GetClipboardText).
		//  2018-03-20: Misc: Setup io.BackendFlags ImGuiBackendFlags_HasMouseCursors flag + honor ImGuiConfigFlags_NoMouseCursorChange flag.
		//  2018-02-16: Inputs: Added support for mouse cursors, honoring ImGui::GetMouseCursor() value.
		//  2018-02-06: Misc: Removed call to ImGui::Shutdown() which is not available from 1.60 WIP, user needs to call CreateContext/DestroyContext themselves.
		//  2018-02-06: Inputs: Added mapping for ImGuiKey_Space.
		//  2018-02-05: Misc: Using SDL_GetPerformanceCounter() instead of SDL_GetTicks() to be able to handle very high framerate (1000+ FPS).
		//  2018-02-05: Inputs: Keyboard mapping is using scancodes everywhere instead of a confusing mixture of keycodes and scancodes.
		//  2018-01-20: Inputs: Added Horizontal Mouse Wheel support.
		//  2018-01-19: Inputs: When available (SDL 2.0.4+) using SDL_CaptureMouse() to retrieve coordinates outside of client area when dragging. Otherwise (SDL 2.0.3 and before) testing for SDL_WINDOW_INPUT_FOCUS instead of SDL_WINDOW_MOUSE_FOCUS.
		//  2018-01-18: Inputs: Added mapping for ImGuiKey_Insert.
		//  2017-08-25: Inputs: MousePos set to -FLT_MAX,-FLT_MAX when mouse is unavailable/missing (instead of -1,-1).
		//  2016-10-15: Misc: Added a void* user_data parameter to Clipboard function handlers.


//#define SDL_HAS_CAPTURE_AND_GLOBAL_MOUSE    SDL_VERSION_ATLEAST(2,0,4)
//#define SDL_HAS_VULKAN                      SDL_VERSION_ATLEAST(2,0,6)

		// Data
		private static SDL.Window*  g_Window = null;
		private static uint64       g_Time = 0;
		private static bool[3]      g_MousePressed = .( false, false, false );
		//private static SDL.SDL_Cursor*[(.)ImGui.MouseCursor.COUNT] g_MouseCursors = .(null,); // There is a compiler bug in Beef currently and this isn't working.
		private static SDL.SDL_Cursor*[] g_MouseCursors = null;
		private static char8*       g_ClipboardTextData = null;
		private static bool         g_MouseCanUseGlobalState = true;

		private static char8* ImGui_ImplSDL2_GetClipboardText(void* unused)
		{
			if (g_ClipboardTextData != null)
				SDL.free(g_ClipboardTextData);
			g_ClipboardTextData = SDL.GetClipboardText();
			return g_ClipboardTextData;
		}

		static void ImGui_ImplSDL2_SetClipboardText(void* unused, char8* text)
		{
			SDL.SetClipboardText(text);
		}

		// You can read the io.WantCaptureMouse, io.WantCaptureKeyboard flags to tell if dear imgui wants to use your inputs.
		// - When io.WantCaptureMouse is true, do not dispatch mouse input data to your main application.
		// - When io.WantCaptureKeyboard is true, do not dispatch keyboard input data to your main application.
		// Generally you may always pass all inputs to dear imgui, and hide them from your application based on those two flags.
		// If you have multiple SDL events and some of them are not meant to be used by dear imgui, you may need to filter events based on their windowID field.
		public static bool ProcessEvent(SDL.Event* event)
		{
			ref ImGui.IO io = ref ImGui.GetIO();
			switch (event.type)
			{
			case SDL.EventType.MouseWheel:
				{
					if (event.wheel.x > 0) io.MouseWheelH += 1;
					if (event.wheel.x < 0) io.MouseWheelH -= 1;
					if (event.wheel.y > 0) io.MouseWheel += 1;
					if (event.wheel.y < 0) io.MouseWheel -= 1;
					return true;
				}
			case SDL.EventType.MouseButtonDown:
				{
					if (event.button.button == SDL.SDL_BUTTON_LEFT) g_MousePressed[0] = true;
					if (event.button.button == SDL.SDL_BUTTON_RIGHT) g_MousePressed[1] = true;
					if (event.button.button == SDL.SDL_BUTTON_MIDDLE) g_MousePressed[2] = true;
					return true;
				}
			case SDL.EventType.TextInput:
				{
					io.AddInputCharactersUTF8((.)&event.text.text[0]);
					return true;
				}
			case SDL.EventType.KeyDown:
				fallthrough;
			case SDL.EventType.KeyUp:
				{
					int key = (.)event.key.keysym.scancode;
					ImGui.ASSERT!(key >= 0 && key < io.KeysDown.Count);
					io.KeysDown[key] = (event.type == SDL.EventType.KeyDown);
					io.KeyShift = ((SDL.GetModState() & SDL.KeyMod.SHIFT) != 0);
					io.KeyCtrl = ((SDL.GetModState() & SDL.KeyMod.CTRL) != 0);
					io.KeyAlt = ((SDL.GetModState() & SDL.KeyMod.ALT) != 0);
#if BF_PLATFORM_WINDOWS
					io.KeySuper = false;
#else
					io.KeySuper = ((SDL_GetModState() & KMOD_GUI) != 0);
#endif
					return true;
				}
			default:
				return false;
			}
		}

		public static bool Init(SDL.Window* window)
		{
			g_Window = window;

			// Setup back-end capabilities flags
			ref ImGui.IO io = ref ImGui.GetIO();
			io.BackendFlags |= ImGui.BackendFlags.HasMouseCursors;       // We can honor GetMouseCursor() values (optional)
			io.BackendFlags |= ImGui.BackendFlags.HasSetMousePos;        // We can honor io.WantSetMousePos requests (optional, rarely used)
			io.BackendPlatformName = "imgui_impl_sdl";

			// Keyboard mapping. ImGui will use those indices to peek into the io.KeysDown[] array.
			io.KeyMap[(int)ImGui.Key.Tab] = (.)SDL.Scancode.Tab;
			io.KeyMap[(int)ImGui.Key.LeftArrow] = (.)SDL.Scancode.Left;
			io.KeyMap[(int)ImGui.Key.RightArrow] = (.)SDL.Scancode.Right;
			io.KeyMap[(int)ImGui.Key.UpArrow] = (.)SDL.Scancode.Up;
			io.KeyMap[(int)ImGui.Key.DownArrow] = (.)SDL.Scancode.Down;
			io.KeyMap[(int)ImGui.Key.PageUp] = (.)SDL.Scancode.Pageup;
			io.KeyMap[(int)ImGui.Key.PageDown] = (.)SDL.Scancode.PageDown;
			io.KeyMap[(int)ImGui.Key.Home] = (.)SDL.Scancode.Home;
			io.KeyMap[(int)ImGui.Key.End] = (.)SDL.Scancode.End;
			io.KeyMap[(int)ImGui.Key.Insert] = (.)SDL.Scancode.Insert;
			io.KeyMap[(int)ImGui.Key.Delete] = (.)SDL.Scancode.Delete;
			io.KeyMap[(int)ImGui.Key.Backspace] = (.)SDL.Scancode.BackSpace;
			io.KeyMap[(int)ImGui.Key.Space] = (.)SDL.Scancode.Space;
			io.KeyMap[(int)ImGui.Key.Enter] = (.)SDL.Scancode.Return;
			io.KeyMap[(int)ImGui.Key.Escape] = (.)SDL.Scancode.Escape;
			io.KeyMap[(int)ImGui.Key.KeyPadEnter] = (.)SDL.Scancode.KpEnter;
			io.KeyMap[(int)ImGui.Key.A] = (.)SDL.Scancode.A;
			io.KeyMap[(int)ImGui.Key.C] = (.)SDL.Scancode.C;
			io.KeyMap[(int)ImGui.Key.V] = (.)SDL.Scancode.V;
			io.KeyMap[(int)ImGui.Key.X] = (.)SDL.Scancode.X;
			io.KeyMap[(int)ImGui.Key.Y] = (.)SDL.Scancode.Y;
			io.KeyMap[(int)ImGui.Key.Z] = (.)SDL.Scancode.Z;

			io.SetClipboardTextFn = => ImGui_ImplSDL2_SetClipboardText;
			io.GetClipboardTextFn = => ImGui_ImplSDL2_GetClipboardText;
			io.ClipboardUserData = null;

			// Load mouse cursors
			g_MouseCursors = new SDL.SDL_Cursor*[(.)ImGui.MouseCursor.COUNT];
			g_MouseCursors[(int)ImGui.MouseCursor.Arrow] = SDL.CreateSystemCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_ARROW);
			g_MouseCursors[(int)ImGui.MouseCursor.TextInput] = SDL.CreateSystemCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_IBEAM);
			g_MouseCursors[(int)ImGui.MouseCursor.ResizeAll] = SDL.CreateSystemCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_SIZEALL);
			g_MouseCursors[(int)ImGui.MouseCursor.ResizeNS] = SDL.CreateSystemCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_SIZENS);
			g_MouseCursors[(int)ImGui.MouseCursor.ResizeEW] = SDL.CreateSystemCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_SIZEWE);
			g_MouseCursors[(int)ImGui.MouseCursor.ResizeNESW] = SDL.CreateSystemCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_SIZENESW);
			g_MouseCursors[(int)ImGui.MouseCursor.ResizeNWSE] = SDL.CreateSystemCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_SIZENWSE);
			g_MouseCursors[(int)ImGui.MouseCursor.Hand] = SDL.CreateSystemCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_HAND);
			g_MouseCursors[(int)ImGui.MouseCursor.NotAllowed] = SDL.CreateSystemCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_NO);

			// Check and store if we are on Wayland
			g_MouseCanUseGlobalState = scope String(SDL.GetCurrentVideoDriver()) != "wayland";

#if BF_PLATFORM_WINDOWS
			SDL.SDL_SysWMinfo wmInfo = ?;
			SDL.VERSION(out wmInfo.version);
			SDL.GetWindowWMInfo(window, ref wmInfo);
			//io.ImeWindowHandle = wmInfo.info.win.window;
#else
			(void)window;
#endif

			return true;
		}

		public static void Shutdown()
		{
			g_Window = null;

			// Destroy last known clipboard data
			if (g_ClipboardTextData != null)
				SDL.free(g_ClipboardTextData);
			g_ClipboardTextData = null;

			// Destroy SDL mouse cursors
			for (ImGui.MouseCursor cursor_n = 0; cursor_n < ImGui.MouseCursor.COUNT; cursor_n++)
				SDL.FreeCursor(g_MouseCursors[(int)cursor_n]);
			delete g_MouseCursors;
			//g_MouseCursors = default;
		}

		private static void UpdateMousePosAndButtons()
		{
			ref ImGui.IO io = ref ImGui.GetIO();

			// Set OS mouse position if requested (rarely used, only when ImGuiConfigFlags_NavEnableSetMousePos is enabled by user)
			if (io.WantSetMousePos)
				SDL.WarpMouseInWindow(g_Window, (.)io.MousePos.x, (.)io.MousePos.y);
			else
				io.MousePos = ImGui.Vec2(-Float.MaxValue, -Float.MaxValue);

			int32 mx = ?, my = ?;
			uint32 mouse_buttons = SDL.GetMouseState(&mx, &my);
			io.MouseDown[0] = g_MousePressed[0] || (mouse_buttons & SDL.BUTTON(SDL.SDL_BUTTON_LEFT)) != 0;  // If a mouse press event came, always pass it as "mouse held this frame", so we don't miss click-release events that are shorter than 1 frame.
			io.MouseDown[1] = g_MousePressed[1] || (mouse_buttons & SDL.BUTTON(SDL.SDL_BUTTON_RIGHT)) != 0;
			io.MouseDown[2] = g_MousePressed[2] || (mouse_buttons & SDL.BUTTON(SDL.SDL_BUTTON_MIDDLE)) != 0;
			g_MousePressed[0] = g_MousePressed[1] = g_MousePressed[2] = false;

#if SDL_HAS_CAPTURE_AND_GLOBAL_MOUSE && !defined(__EMSCRIPTEN__) && !defined(__ANDROID__) && !(defined(__APPLE__) && TARGET_OS_IOS)
			SDL.Window* focused_window = SDL.GetKeyboardFocus();
			if (g_Window == focused_window)
			{
				if (g_MouseCanUseGlobalState)
				{
					// SDL_GetMouseState() gives mouse position seemingly based on the last window entered/focused(?)
					// The creation of a new windows at runtime and SDL_CaptureMouse both seems to severely mess up with that, so we retrieve that position globally.
					// Won't use this workaround when on Wayland, as there is no global mouse position.
					int32 wx, wy;
					SDL.GetWindowPosition(focused_window, out wx, out wy);
					SDL.GetGlobalMouseState(&mx, &my);
					mx -= wx;
					my -= wy;
				}
				io.MousePos = ImGui.Vec2((float)mx, (float)my);
			}

			// SDL_CaptureMouse() let the OS know e.g. that our imgui drag outside the SDL window boundaries shouldn't e.g. trigger the OS window resize cursor.
			// The function is only supported from SDL 2.0.4 (released Jan 2016)
			bool any_mouse_button_down = ImGui.IsAnyMouseDown();
			SDL.CaptureMouse(any_mouse_button_down);
#else
			if (((SDL.WindowFlags)SDL.GetWindowFlags(g_Window) & SDL.WindowFlags.InputFocus) != 0)
				io.MousePos = ImGui.Vec2((float)mx, (float)my);
#endif
		}

		private static void UpdateMouseCursor()
		{
			ref ImGui.IO io = ref ImGui.GetIO();
			if (io.ConfigFlags.HasFlag(ImGui.ConfigFlags.NoMouseCursorChange))
				return;

			ImGui.MouseCursor imgui_cursor = ImGui.GetMouseCursor();
			if (io.MouseDrawCursor || imgui_cursor == ImGui.MouseCursor.None)
			{
				// Hide OS mouse cursor if imgui is drawing it or if it wants no cursor
				SDL.ShowCursor(0);
			}
			else
			{
				// Show OS mouse cursor
				SDL.SetCursor(g_MouseCursors[(int)imgui_cursor] != null ? g_MouseCursors[(int)imgui_cursor] : g_MouseCursors[(int)ImGui.MouseCursor.Arrow]);
				SDL.ShowCursor(1);
			}
		}

		private static void UpdateGamepads()
		{
			ref ImGui.IO io = ref ImGui.GetIO();
			io.NavInputs = default;
			if (!io.ConfigFlags.HasFlag(ImGui.ConfigFlags.NavEnableGamepad))
				return;

			// Get gamepad
			SDL.SDL_GameController* game_controller = SDL.GameControllerOpen(0);
			if (game_controller == null)
			{
				io.BackendFlags &= ~ImGui.BackendFlags.HasGamepad;
				return;
			}

			// Update gamepad inputs
			mixin MAP_BUTTON(ImGui.NavInput NAV_NO, SDL.SDL_GameControllerButton BUTTON_NO)
			{
				io.NavInputs[(int)NAV_NO] = (SDL.GameControllerGetButton(game_controller, BUTTON_NO) != 0) ? 1.0f : 0.0f;
			}

			mixin MAP_ANALOG(ImGui.NavInput NAV_NO, SDL.SDL_GameControllerAxis AXIS_NO, float V0, float V1)
			{
				float vn = (float)(SDL.GameControllerGetAxis(game_controller, AXIS_NO) - V0) / (float)(V1 - V0);
				if (vn > 1.0f) vn = 1.0f;
				if (vn > 0.0f && io.NavInputs[(int)NAV_NO] < vn) io.NavInputs[(int)NAV_NO] = vn;
			}
			const int thumb_dead_zone = 8000;           // SDL_gamecontroller.h suggests using this value.
			MAP_BUTTON!(ImGui.NavInput.Activate,      SDL.SDL_GameControllerButton.A);               // Cross / A
			MAP_BUTTON!(ImGui.NavInput.Cancel,        SDL.SDL_GameControllerButton.B);               // Circle / B
			MAP_BUTTON!(ImGui.NavInput.Menu,          SDL.SDL_GameControllerButton.X);               // Square / X
			MAP_BUTTON!(ImGui.NavInput.Input,         SDL.SDL_GameControllerButton.Y);               // Triangle / Y
			MAP_BUTTON!(ImGui.NavInput.DpadLeft,      SDL.SDL_GameControllerButton.DpadLeft);       // D-Pad Left
			MAP_BUTTON!(ImGui.NavInput.DpadRight,     SDL.SDL_GameControllerButton.DpadRight);      // D-Pad Right
			MAP_BUTTON!(ImGui.NavInput.DpadUp,        SDL.SDL_GameControllerButton.DpadUp);         // D-Pad Up
			MAP_BUTTON!(ImGui.NavInput.DpadDown,      SDL.SDL_GameControllerButton.DpadDown);       // D-Pad Down
			MAP_BUTTON!(ImGui.NavInput.FocusPrev,     SDL.SDL_GameControllerButton.LeftShoulder);    // L1 / LB
			MAP_BUTTON!(ImGui.NavInput.FocusNext,     SDL.SDL_GameControllerButton.RightShoulder);   // R1 / RB
			MAP_BUTTON!(ImGui.NavInput.TweakSlow,     SDL.SDL_GameControllerButton.LeftShoulder);    // L1 / LB
			MAP_BUTTON!(ImGui.NavInput.TweakFast,     SDL.SDL_GameControllerButton.RightShoulder);   // R1 / RB
			MAP_ANALOG!(ImGui.NavInput.LStickLeft,    SDL.SDL_GameControllerAxis.LeftX, -thumb_dead_zone, -32768);
			MAP_ANALOG!(ImGui.NavInput.LStickRight,   SDL.SDL_GameControllerAxis.LeftX,  thumb_dead_zone,  32767);
			MAP_ANALOG!(ImGui.NavInput.LStickUp,      SDL.SDL_GameControllerAxis.LeftY, -thumb_dead_zone, -32767);
			MAP_ANALOG!(ImGui.NavInput.LStickDown,    SDL.SDL_GameControllerAxis.LeftY,  thumb_dead_zone,  32767);

			io.BackendFlags |= ImGui.BackendFlags.HasGamepad;
		}

		public static void NewFrame(SDL.Window* window)
		{
			ref ImGui.IO io = ref ImGui.GetIO();
			ImGui.ASSERT!(io.Fonts.IsBuilt(), "Font atlas not built! It is generally built by the renderer back-end. Missing call to renderer _NewFrame() function? e.g. ImGui_ImplOpenGL3_NewFrame().");

			// Setup display size (every frame to accommodate for window resizing)
			int32 w, h;
			int32 display_w, display_h;
			SDL.GetWindowSize(window, out w, out h);
			SDL.GL_GetDrawableSize(window, out display_w, out display_h);
			io.DisplaySize = ImGui.Vec2((float)w, (float)h);
			if (w > 0 && h > 0)
				io.DisplayFramebufferScale = ImGui.Vec2((float)display_w / w, (float)display_h / h);

			// Setup time step (we don't use SDL_GetTicks() because it is using millisecond resolution)
			uint64 frequency = SDL.GetPerformanceFrequency();
			uint64 current_time = SDL.GetPerformanceCounter();
			io.DeltaTime = g_Time > 0 ? (float)((double)(current_time - g_Time) / frequency) : (float)(1.0f / 60.0f);
			g_Time = current_time;

			UpdateMousePosAndButtons();
			UpdateMouseCursor();

			// Update game controllers (if enabled and available)
			UpdateGamepads();
		}

	}
}*/
