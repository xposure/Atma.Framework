using System;
using Atma;

namespace Atma
{
	public static class ImGuiImpl
	{
		// dear imgui: Platform Binding for SDL2
		// This needs to be used along with a Renderer (e.g. DirectX11, OpenGL3, Vulkan..)
		// (Info: SDL2 is a cross-platform general purpose library for handling windows, inputs, graphics context
		// creation, etc.) (Requires: SDL 2.0. Prefer SDL 2.0.4+ for full feature support.)

		// Implemented features:
		//  [X] Platform: Mouse cursor shape and visibility. Disable with 'io.ConfigFlags |=
		// ImGuiConfigFlags_NoMouseCursorChange'. [X] Platform: Clipboard support. [X] Platform: Keyboard arrays indexed
		// using SDL_SCANCODE_* codes, e.g. ImGui::IsKeyPressed(SDL_SCANCODE_SPACE). [X] Platform: Gamepad support.
		// Enabled with 'io.ConfigFlags |= ImGuiConfigFlags_NavEnableGamepad'. Missing features: [ ] Platform: SDL2
		// handling of IME under Windows appears to be broken and it explicitly disable the regular Windows IME. You can
		// restore Windows IME by compiling SDL with SDL_DISABLE_WINDOWS_IME.

		// You can copy and use unmodified imgui_impl_* files in your project. See main.cpp for an example of using
		// this. If you are new to dear imgui, read examples/README.txt and read the documentation at the top of
		// imgui.cpp. https://github.com/ocornut/imgui

		// CHANGELOG
		// (minor and older changes stripped away, please see git history for details)
		//  2020-02-20: Inputs: Fixed mapping for ImGuiKey_KeyPadEnter (using SDL_SCANCODE_KP_ENTER instead of
		// SDL_SCANCODE_RETURN2). 2019-12-17: Inputs: On Wayland, use SDL_GetMouseState (because there is no global
		// mouse state). 2019-12-05: Inputs: Added support for ImGuiMouseCursor_NotAllowed mouse cursor. 2019-07-21:
		// Inputs: Added mapping for ImGuiKey_KeyPadEnter. 2019-04-23: Inputs: Added support for SDL_GameController (if
		// ImGuiConfigFlags_NavEnableGamepad is set by user application). 2019-03-12: Misc: Preserve
		// DisplayFramebufferScale when main window is minimized. 2018-12-21: Inputs: Workaround for Android/iOS which
		// don't seem to handle focus related calls. 2018-11-30: Misc: Setting up io.BackendPlatformName so it can be
		// displayed in the About Window. 2018-11-14: Changed the signature of ImGui_ImplSDL2_ProcessEvent() to take a
		// 'const SDL_Event*'. 2018-08-01: Inputs: Workaround for Emscripten which doesn't seem to handle focus related
		// calls. 2018-06-29: Inputs: Added support for the ImGuiMouseCursor_Hand cursor. 2018-06-08: Misc: Extracted
		// imgui_impl_sdl.cpp/.h away from the old combined SDL2+OpenGL/Vulkan examples. 2018-06-08: Misc:
		// ImGui_ImplSDL2_InitForOpenGL() now takes a SDL_GLContext parameter. 2018-05-09: Misc: Fixed clipboard paste
		// memory leak (we didn't call SDL_FreeMemory on the data returned by SDL_GetClipboardText). 2018-03-20: Misc:
		// Setup io.BackendFlags ImGuiBackendFlags_HasMouseCursors flag + honor ImGuiConfigFlags_NoMouseCursorChange
		// flag. 2018-02-16: Inputs: Added support for mouse cursors, honoring ImGui::GetMouseCursor() value. 
		// 2018-02-06: Misc: Removed call to ImGui::Shutdown() which is not available from 1.60 WIP, user needs to call
		// CreateContext/DestroyContext themselves. 2018-02-06: Inputs: Added mapping for ImGuiKey_Space. 2018-02-05:
		// Misc: Using SDL_GetPerformanceCounter() instead of SDL_GetTicks() to be able to handle very high framerate
		// (1000+ FPS). 2018-02-05: Inputs: Keyboard mapping is using scancodes everywhere instead of a confusing
		// mixture of keycodes and scancodes. 2018-01-20: Inputs: Added Horizontal Mouse Wheel support. 2018-01-19:
		// Inputs: When available (SDL 2.0.4+) using SDL_CaptureMouse() to retrieve coordinates outside of client area
		// when dragging. Otherwise (SDL 2.0.3 and before) testing for SDL_WINDOW_INPUT_FOCUS instead of
		// SDL_WINDOW_MOUSE_FOCUS. 2018-01-18: Inputs: Added mapping for ImGuiKey_Insert. 2017-08-25: Inputs: MousePos
		// set to -FLT_MAX,-FLT_MAX when mouse is unavailable/missing (instead of -1,-1). 2016-10-15: Misc: Added a
		// void* user_data parameter to Clipboard function handlers.


//#define SDL_HAS_CAPTURE_AND_GLOBAL_MOUSE    SDL_VERSION_ATLEAST(2,0,4)
//#define SDL_HAS_VULKAN                      SDL_VERSION_ATLEAST(2,0,6)

		// Data
		//SDL private static SDL.Window* g_Window = null;
		//private static uint64 g_Time = 0;
		private static bool[3] g_MousePressed = .(false, false, false);
		public static Cursors[Cursors.COUNT] g_MouseCursors;
		//private static SDL.SDL_Cursor*[(.)ImGui.MouseCursor.COUNT] g_MouseCursors = .(null,); // There is a compiler
		// bug in Beef currently and this isn't working.
		//SDL private static SDL.SDL_Cursor*[] g_MouseCursors = null;
		private static bool g_MouseCanUseGlobalState = true;

		private static ImGui.Context* _imgui;

		private static String g_clipboard = new .() ~ delete _;

		private static char8* ImGui_Impl_GetClipboardText(void* unused)
		{
			Core.Input.GetClipboardString(g_clipboard);
			g_clipboard.Append('\0');
			return g_clipboard.Ptr;
		}

		static void ImGui_Impl_SetClipboardText(void* unused, char8* text)
		{
			g_clipboard.Set(StringView(text));
			Core.Input.SetClipboardString(g_clipboard);
		}

		// You can read the io.WantCaptureMouse, io.WantCaptureKeyboard flags to tell if dear imgui wants to use your
		// inputs. - When io.WantCaptureMouse is true, do not dispatch mouse input data to your main application. - When
		// io.WantCaptureKeyboard is true, do not dispatch keyboard input data to your main application. Generally you
		// may always pass all inputs to dear imgui, and hide them from your application based on those two flags. If
		// you have multiple SDL events and some of them are not meant to be used by dear imgui, you may need to filter
		// events based on their windowID field.
		public static void Update()
		{
			ref ImGui.IO io = ref ImGui.GetIO();

			let input = Core.Input;
			g_MousePressed[0] = input.MouseCheck(.Left);
			g_MousePressed[1] = input.MouseCheck(.Right);
			g_MousePressed[2] = input.MouseCheck(.Middle);

			if (input.MouseWheel.x > 0)
				io.MouseWheelH += 1;
			if (input.MouseWheel.x < 0)
				io.MouseWheelH -= 1;
			if (input.MouseWheel.y > 0)
				io.MouseWheel += 1;
			if (input.MouseWheel.y < 0)
				io.MouseWheel -= 1;

			io.KeyShift = input.Shift;
			io.KeyAlt = input.Alt;
			io.KeyCtrl = input.Ctrl;
			io.KeySuper = false;

			let keyCount = Math.Min(io.KeysDown.Count, Keys.Count);
			for (var i < keyCount)
				io.KeysDown[i] = input.KeyCheck((.)i);


			//textinput
			//io.AddInputCharactersUTF8((.)&event.text.text[0]);
		}

		private static void UpdateBegin(CoreEvents.UpdateBegin ev)
		{
			//We need to make a choice if ImGui should create its draw commands during update or during render.
			//Since this is for debugging, I feel that most of the time you would want to
			//do draw commands inside update and new during rendering
			//this has a side effect that you need to have a decent FrameRate set
			//additionally the input is polled on update and not during rendering + integration
			//so it makes even more sense to do this during update to keep input synced and not lost
			ImGuiImplOpenGL3.NewFrame();
			ImGuiImpl.NewFrame();
			ImGui.NewFrame();

			Update();
		}

		private static void UpdateEnd(CoreEvents.UpdateEnd ev)
		{
			ImGui.Render();
		}

		private static void Shutdown(CoreEvents.Shutdown ev)
		{
			ImGuiImplOpenGL3.Shutdown();
			ImGui.DestroyContext();
		}

		private static void Present(CoreEvents.Present ev)
		{
			let drawData = &ImGui.GetDrawData();
			ImGuiImplOpenGL3.RenderDrawData(drawData);
		}

		static ~this()
		{
			/*Core.Emitter.RemoveObserver<CoreEvents.UpdateBegin>(scope => UpdateBegin);
			Core.Emitter.RemoveObserver<CoreEvents.UpdateEnd>(scope => UpdateEnd);
			Core.Emitter.RemoveObserver<CoreEvents.Shutdown>(scope => Shutdown);*/
		}

		public static bool Initialize()
		{
			Core.Emitter.AddObserver<CoreEvents.UpdateBegin>(new => UpdateBegin);
			Core.Emitter.AddObserver<CoreEvents.UpdateEnd>(new => UpdateEnd);
			Core.Emitter.AddObserver<CoreEvents.Present>(new => Present);
			Core.Emitter.AddObserver<CoreEvents.Shutdown>(new => Shutdown);

			_imgui = &ImGui.CreateContext();
			ImGuiImplOpenGL3.Init();

			// Setup back-end capabilities flags
			ref ImGui.IO io = ref ImGui.GetIO();
			io.BackendFlags |= ImGui.BackendFlags.HasMouseCursors;// We can honor GetMouseCursor() values (optional)
			io.BackendFlags |= ImGui.BackendFlags.HasSetMousePos;// We can honor io.WantSetMousePos requests (optional,
			// rarely used)
			io.BackendPlatformName = "imgui_impl_sdl";

			// Keyboard mapping. ImGui will use those indices to peek into the io.KeysDown[] array.
			io.KeyMap[(int)ImGui.Key.Tab] = (.)Keys.Tab;
			io.KeyMap[(int)ImGui.Key.LeftArrow] = (.)Keys.Left;
			io.KeyMap[(int)ImGui.Key.RightArrow] = (.)Keys.Right;
			io.KeyMap[(int)ImGui.Key.UpArrow] = (.)Keys.Up;
			io.KeyMap[(int)ImGui.Key.DownArrow] = (.)Keys.Down;
			io.KeyMap[(int)ImGui.Key.PageUp] = (.)Keys.PageUp;
			io.KeyMap[(int)ImGui.Key.PageDown] = (.)Keys.PageDown;
			io.KeyMap[(int)ImGui.Key.Home] = (.)Keys.Home;
			io.KeyMap[(int)ImGui.Key.End] = (.)Keys.End;
			io.KeyMap[(int)ImGui.Key.Insert] = (.)Keys.Insert;
			io.KeyMap[(int)ImGui.Key.Delete] = (.)Keys.Delete;
			io.KeyMap[(int)ImGui.Key.Backspace] = (.)Keys.BackSpace;
			io.KeyMap[(int)ImGui.Key.Space] = (.)Keys.Space;
			io.KeyMap[(int)ImGui.Key.Enter] = (.)Keys.Return;
			io.KeyMap[(int)ImGui.Key.Escape] = (.)Keys.Escape;
			io.KeyMap[(int)ImGui.Key.KeyPadEnter] = (.)Keys.KpEnter;
			io.KeyMap[(int)ImGui.Key.A] = (.)Keys.A;
			io.KeyMap[(int)ImGui.Key.C] = (.)Keys.C;
			io.KeyMap[(int)ImGui.Key.V] = (.)Keys.V;
			io.KeyMap[(int)ImGui.Key.X] = (.)Keys.X;
			io.KeyMap[(int)ImGui.Key.Y] = (.)Keys.Y;
			io.KeyMap[(int)ImGui.Key.Z] = (.)Keys.Z;

			io.SetClipboardTextFn = => ImGui_Impl_SetClipboardText;
			io.GetClipboardTextFn = => ImGui_Impl_GetClipboardText;
			io.ClipboardUserData = null;

			// Load mouse cursors
			g_MouseCursors[(int)ImGui.MouseCursor.Arrow] = .Arrow;
			g_MouseCursors[(int)ImGui.MouseCursor.TextInput] = .TextInput;
			g_MouseCursors[(int)ImGui.MouseCursor.ResizeAll] = .ResizeAll;
			g_MouseCursors[(int)ImGui.MouseCursor.ResizeNS] = .ResizeNS;
			g_MouseCursors[(int)ImGui.MouseCursor.ResizeEW] = .ResizeEW;
			g_MouseCursors[(int)ImGui.MouseCursor.ResizeNESW] = .ResizeNESW;
			g_MouseCursors[(int)ImGui.MouseCursor.ResizeNWSE] = .ResizeNWSE;
			g_MouseCursors[(int)ImGui.MouseCursor.Hand] = .Hand;
			g_MouseCursors[(int)ImGui.MouseCursor.NotAllowed] = .NotAllowed;

			// Check and store if we are on Wayland
			//TODO ?? g_MouseCanUseGlobalState = scope String(SDL.GetCurrentVideoDriver()) != "wayland";

			return true;
		}

		private static void UpdateMousePosAndButtons()
		{
			ref ImGui.IO io = ref ImGui.GetIO();
			let input = Core.Input;

			// Set OS mouse position if requested (rarely used, only when ImGuiConfigFlags_NavEnableSetMousePos is
			// enabled by user)
			if (io.WantSetMousePos)
				Assert.IsFalse(io.WantSetMousePos, "We currently do not support setting the mouse position.");
				//SDL.WarpMouseInWindow(g_Window, (.)io.MousePos.x, (.)io.MousePos.y);
			else
				io.MousePos = ImGui.Vec2(-Float.MaxValue, -Float.MaxValue);

			let mousePos = Core.Input.MousePosition;
			int32 mx = (.)mousePos.x, my = (.)mousePos.y;

			io.MouseDown[0] = g_MousePressed[0] || input.MouseCheck(.Left);
			io.MouseDown[1] = g_MousePressed[1] || input.MouseCheck(.Right);
			io.MouseDown[2] = g_MousePressed[2] || input.MouseCheck(.Middle);

			/*io.MouseDown[0] = g_MousePressed[0] || (mouse_buttons & SDL.BUTTON(SDL.SDL_BUTTON_LEFT)) != 0;// If a
			mouse // press event came, always pass it as "mouse held this frame", so we don't miss click-release events
			that // are shorter than 1 frame. io.MouseDown[1] = g_MousePressed[1] || (mouse_buttons &
			SDL.BUTTON(SDL.SDL_BUTTON_RIGHT)) != 0; io.MouseDown[2] = g_MousePressed[2] || (mouse_buttons &
			SDL.BUTTON(SDL.SDL_BUTTON_MIDDLE)) != 0;*/
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
			/*if (((SDL.WindowFlags)SDL.GetWindowFlags(g_Window) & SDL.WindowFlags.InputFocus) != 0)*/
			if (Core.Window.Focused)
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
				Core.Input.SetMouseCursor(.Hidden);
			}
			else
			{
				Core.Input.SetMouseCursor(g_MouseCursors[(int)imgui_cursor]);
			}
		}

		private static void UpdateGamepads(int gamepadId)
		{
			ref ImGui.IO io = ref ImGui.GetIO();
			io.NavInputs = default;
			if (!io.ConfigFlags.HasFlag(ImGui.ConfigFlags.NavEnableGamepad))
				return;

			// Get gamepad
			if (!Core.Input.HasGamepad(gamepadId))
			{
				io.BackendFlags &= ~ImGui.BackendFlags.HasGamepad;
				return;
			}

			// Update gamepad inputs
			mixin MAP_BUTTON(ImGui.NavInput NAV_NO, Buttons BUTTON_NO)
			{
				io.NavInputs[(int)NAV_NO] = Core.Input.GamepadButtonCheck(gamepadId, BUTTON_NO) ? 1.0f : 0.0f;
			}

			mixin MAP_ANALOG(ImGui.NavInput NAV_NO, Axes AXIS_NO, float V0, float V1)
			{
				float vn = (float)(Core.Input.GamepadAxisCheck(gamepadId, AXIS_NO) - V0) / (float)(V1 - V0);
				if (vn > 1.0f) vn = 1.0f;
				if (vn > 0.0f && io.NavInputs[(int)NAV_NO] < vn) io.NavInputs[(int)NAV_NO] = vn;
			}
			const int thumb_dead_zone = 8000;// SDL_gamecontroller.h suggests using this value.
			MAP_BUTTON!(ImGui.NavInput.Activate, Buttons.A);// Cross / A
			MAP_BUTTON!(ImGui.NavInput.Cancel, Buttons.B);// Circle / B
			MAP_BUTTON!(ImGui.NavInput.Menu, Buttons.X);// Square / X
			MAP_BUTTON!(ImGui.NavInput.Input, Buttons.Y);// Triangle / Y
			MAP_BUTTON!(ImGui.NavInput.DpadLeft, Buttons.DpadLeft);// D-Pad Left
			MAP_BUTTON!(ImGui.NavInput.DpadRight, Buttons.DpadRight);// D-Pad Right
			MAP_BUTTON!(ImGui.NavInput.DpadUp, Buttons.DpadUp);// D-Pad Up
			MAP_BUTTON!(ImGui.NavInput.DpadDown, Buttons.DpadDown);// D-Pad Down
			MAP_BUTTON!(ImGui.NavInput.FocusPrev, Buttons.LeftShoulder);// L1 / LB
			MAP_BUTTON!(ImGui.NavInput.FocusNext, Buttons.RightShoulder);// R1 / RB
			MAP_BUTTON!(ImGui.NavInput.TweakSlow, Buttons.LeftShoulder);// L1 / LB
			MAP_BUTTON!(ImGui.NavInput.TweakFast, Buttons.RightShoulder);// R1 / RB
			MAP_ANALOG!(ImGui.NavInput.LStickLeft, Axes.LeftX, -thumb_dead_zone, -32768);
			MAP_ANALOG!(ImGui.NavInput.LStickRight, Axes.LeftX, thumb_dead_zone, 32767);
			MAP_ANALOG!(ImGui.NavInput.LStickUp, Axes.LeftY, -thumb_dead_zone, -32767);
			MAP_ANALOG!(ImGui.NavInput.LStickDown, Axes.LeftY, thumb_dead_zone, 32767);

			io.BackendFlags |= ImGui.BackendFlags.HasGamepad;
		}

		public static void NewFrame()
		{
			ref ImGui.IO io = ref ImGui.GetIO();
			ImGui.ASSERT!(io.Fonts.IsBuilt(), "Font atlas not built! It is generally built by the renderer back-end. Missing call to renderer _NewFrame() function? e.g. ImGui_ImplOpenGL3_NewFrame().");

			// Setup display size (every frame to accommodate for window resizing)
			int32 w, h;
			int32 display_w, display_h;
			let renderSize = Core.Window.RenderSize;
			display_w = (.)renderSize.width;
			display_h = (.)renderSize.height;

			let windowSize = Core.Window.WindowSize;
			w = (.)windowSize.width;
			h = (.)windowSize.height;

			io.DisplaySize = ImGui.Vec2((float)w, (float)h);
			if (w > 0 && h > 0)
				io.DisplayFramebufferScale = ImGui.Vec2((float)display_w / w, (float)display_h / h);

			// Setup time step (we don't use SDL_GetTicks() because it is using millisecond resolution)
			io.DeltaTime = Time.Delta;

			UpdateMousePosAndButtons();
			UpdateMouseCursor();

			// Update game controllers (if enabled and available)
			UpdateGamepads(0);
		}

	}
}
