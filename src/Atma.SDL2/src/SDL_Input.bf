using SDL2;
using System;
using System.Collections;

namespace Atma
{
	public extension Input
	{
		public const int MaxControllers = 64;
		private Dictionary<SDL.Keycode, Keys> _keycodeToKeys = new .() ~ delete _;

		private SDL.SDL_Cursor*[(int)SDL.SDL_SystemCursor.SDL_NUM_SYSTEM_CURSORS] sdlCursors;
		private SDL.SDL_Joystick*[MaxControllers] sdlJoysticks;
		private SDL.SDL_GameController*[MaxControllers] sdlGamepads;

		private bool[MaxControllers][Buttons.Count] _buttons;
		private float[MaxControllers][Axes.Count] _axis;

		private bool[Keys.Count] _keys;
		private bool[MouseButtons.Count] _mouse;


		protected override void Platform_Update() { }

		protected override bool Platform_PollKeyboard(Keys key) => _keys[(int)key];

		protected override bool Platform_PollMouse(MouseButtons button) => _mouse[(int)button];

		protected override bool Platform_PollGamepadButton(int gamepadID, Buttons button) => _buttons[gamepadID][(int)button];

		protected override float Platform_PollGamepadAxis(int gamepadID, Axes axis) => _axis[gamepadID][(int)axis];

		public ~this()
		{
			for (var i < sdlCursors.Count)
				if (sdlCursors[i] != null)
					SDL.FreeCursor(sdlCursors[i]);

			for (var i < sdlJoysticks.Count)
				if (sdlJoysticks[i] != null)
					SDL.JoystickClose(sdlJoysticks[i]);

			for (var i < sdlGamepads.Count)
				if (sdlGamepads[i] != null)
					SDL.GameControllerClose(sdlGamepads[i]);
		}

		this
		{
			_keycodeToKeys.Add(SDL.Keycode.UNKNOWN, Keys.Invalid);

			_keycodeToKeys.Add(SDL.Keycode.A, Keys.A);
			_keycodeToKeys.Add(SDL.Keycode.B, Keys.B);
			_keycodeToKeys.Add(SDL.Keycode.C, Keys.C);
			_keycodeToKeys.Add(SDL.Keycode.D, Keys.D);
			_keycodeToKeys.Add(SDL.Keycode.E, Keys.E);
			_keycodeToKeys.Add(SDL.Keycode.F, Keys.F);
			_keycodeToKeys.Add(SDL.Keycode.G, Keys.G);
			_keycodeToKeys.Add(SDL.Keycode.H, Keys.H);
			_keycodeToKeys.Add(SDL.Keycode.I, Keys.I);
			_keycodeToKeys.Add(SDL.Keycode.J, Keys.J);
			_keycodeToKeys.Add(SDL.Keycode.K, Keys.K);
			_keycodeToKeys.Add(SDL.Keycode.L, Keys.L);
			_keycodeToKeys.Add(SDL.Keycode.M, Keys.M);
			_keycodeToKeys.Add(SDL.Keycode.N, Keys.N);
			_keycodeToKeys.Add(SDL.Keycode.O, Keys.O);
			_keycodeToKeys.Add(SDL.Keycode.P, Keys.P);
			_keycodeToKeys.Add(SDL.Keycode.Q, Keys.Q);
			_keycodeToKeys.Add(SDL.Keycode.R, Keys.R);
			_keycodeToKeys.Add(SDL.Keycode.S, Keys.S);
			_keycodeToKeys.Add(SDL.Keycode.T, Keys.T);
			_keycodeToKeys.Add(SDL.Keycode.U, Keys.U);
			_keycodeToKeys.Add(SDL.Keycode.V, Keys.V);
			_keycodeToKeys.Add(SDL.Keycode.W, Keys.W);
			_keycodeToKeys.Add(SDL.Keycode.X, Keys.X);
			_keycodeToKeys.Add(SDL.Keycode.Y, Keys.Y);
			_keycodeToKeys.Add(SDL.Keycode.Z, Keys.Z);

			_keycodeToKeys.Add(SDL.Keycode.Num1, Keys.Key1);
			_keycodeToKeys.Add(SDL.Keycode.Num2, Keys.Key2);
			_keycodeToKeys.Add(SDL.Keycode.Num3, Keys.Key3);
			_keycodeToKeys.Add(SDL.Keycode.Num4, Keys.Key4);
			_keycodeToKeys.Add(SDL.Keycode.Num5, Keys.Key5);
			_keycodeToKeys.Add(SDL.Keycode.Num6, Keys.Key6);
			_keycodeToKeys.Add(SDL.Keycode.Num7, Keys.Key7);
			_keycodeToKeys.Add(SDL.Keycode.Num8, Keys.Key8);
			_keycodeToKeys.Add(SDL.Keycode.Num9, Keys.Key9);
			_keycodeToKeys.Add(SDL.Keycode.Num0, Keys.Key0);

			_keycodeToKeys.Add(SDL.Keycode.RETURN, Keys.Return);
			_keycodeToKeys.Add(SDL.Keycode.ESCAPE, Keys.Escape);
			_keycodeToKeys.Add(SDL.Keycode.BACKSPACE, Keys.BackSpace);
			_keycodeToKeys.Add(SDL.Keycode.TAB, Keys.Tab);
			_keycodeToKeys.Add(SDL.Keycode.SPACE, Keys.Space);

			_keycodeToKeys.Add(SDL.Keycode.MINUS, Keys.Minus);
			_keycodeToKeys.Add(SDL.Keycode.Equals, Keys.Equals);
			_keycodeToKeys.Add(SDL.Keycode.Leftbracket, Keys.LeftBracket);
			_keycodeToKeys.Add(SDL.Keycode.Rightbracket, Keys.RightBracket);
			_keycodeToKeys.Add(SDL.Keycode.Backslash, Keys.BackSlash);
			_keycodeToKeys.Add(SDL.Keycode.Semicolon, Keys.Semicolon);
			_keycodeToKeys.Add(SDL.Keycode.COMMA, Keys.Comma);
			_keycodeToKeys.Add(SDL.Keycode.PERIOD, Keys.Period);
			_keycodeToKeys.Add(SDL.Keycode.SLASH, Keys.Slash);

			_keycodeToKeys.Add(SDL.Keycode.CAPSLOCK, Keys.CapsLock);

			_keycodeToKeys.Add(SDL.Keycode.F1, Keys.F1);
			_keycodeToKeys.Add(SDL.Keycode.F2, Keys.F2);
			_keycodeToKeys.Add(SDL.Keycode.F3, Keys.F3);
			_keycodeToKeys.Add(SDL.Keycode.F4, Keys.F4);
			_keycodeToKeys.Add(SDL.Keycode.F5, Keys.F5);
			_keycodeToKeys.Add(SDL.Keycode.F6, Keys.F6);
			_keycodeToKeys.Add(SDL.Keycode.F7, Keys.F7);
			_keycodeToKeys.Add(SDL.Keycode.F8, Keys.F8);
			_keycodeToKeys.Add(SDL.Keycode.F9, Keys.F9);
			_keycodeToKeys.Add(SDL.Keycode.F10, Keys.F10);
			_keycodeToKeys.Add(SDL.Keycode.F11, Keys.F11);
			_keycodeToKeys.Add(SDL.Keycode.F12, Keys.F12);

			_keycodeToKeys.Add(SDL.Keycode.PRINTSCREEN, Keys.PrintScreen);
			_keycodeToKeys.Add(SDL.Keycode.SCROLLLOCK, Keys.ScrollLock);
			_keycodeToKeys.Add(SDL.Keycode.PAUSE, Keys.Pause);
			_keycodeToKeys.Add(SDL.Keycode.INSERT, Keys.Insert);
			_keycodeToKeys.Add(SDL.Keycode.HOME, Keys.Home);
			_keycodeToKeys.Add(SDL.Keycode.PAGEUP, Keys.PageUp);
			_keycodeToKeys.Add(SDL.Keycode.DELETE, Keys.Delete);
			_keycodeToKeys.Add(SDL.Keycode.END, Keys.End);
			_keycodeToKeys.Add(SDL.Keycode.PAGEDOWN, Keys.PageDown);
			_keycodeToKeys.Add(SDL.Keycode.RIGHT, Keys.Right);
			_keycodeToKeys.Add(SDL.Keycode.LEFT, Keys.Left);
			_keycodeToKeys.Add(SDL.Keycode.DOWN, Keys.Down);
			_keycodeToKeys.Add(SDL.Keycode.UP, Keys.Up);

			_keycodeToKeys.Add(SDL.Keycode.KP_DIVIDE, Keys.KpDivide);
			_keycodeToKeys.Add(SDL.Keycode.KPMULTIPLY, Keys.KpMultiply);
			_keycodeToKeys.Add(SDL.Keycode.KPMINUS, Keys.KpMemSubtract);
			_keycodeToKeys.Add(SDL.Keycode.KPPLUS, Keys.KpMemAdd);
			_keycodeToKeys.Add(SDL.Keycode.KPENTER, Keys.KpEnter);
			_keycodeToKeys.Add(SDL.Keycode.KP1, Keys.Kp1);
			_keycodeToKeys.Add(SDL.Keycode.KP2, Keys.Kp2);
			_keycodeToKeys.Add(SDL.Keycode.KP3, Keys.Kp3);
			_keycodeToKeys.Add(SDL.Keycode.KP4, Keys.Kp4);
			_keycodeToKeys.Add(SDL.Keycode.KP5, Keys.Kp5);
			_keycodeToKeys.Add(SDL.Keycode.KP6, Keys.Kp6);
			_keycodeToKeys.Add(SDL.Keycode.KP7, Keys.Kp7);
			_keycodeToKeys.Add(SDL.Keycode.KP8, Keys.Kp8);
			_keycodeToKeys.Add(SDL.Keycode.KP9, Keys.Kp9);
			_keycodeToKeys.Add(SDL.Keycode.KP0, Keys.Kp0);
			_keycodeToKeys.Add(SDL.Keycode.KPPERIOD, Keys.KpDecimal);

			_keycodeToKeys.Add(SDL.Keycode.KPEQUALS, Keys.KpEquals);

			_keycodeToKeys.Add(SDL.Keycode.F13, Keys.F13);
			_keycodeToKeys.Add(SDL.Keycode.F14, Keys.F14);
			_keycodeToKeys.Add(SDL.Keycode.F15, Keys.F15);
			_keycodeToKeys.Add(SDL.Keycode.F16, Keys.F16);
			_keycodeToKeys.Add(SDL.Keycode.F17, Keys.F17);
			_keycodeToKeys.Add(SDL.Keycode.F18, Keys.F18);
			_keycodeToKeys.Add(SDL.Keycode.F19, Keys.F19);
			_keycodeToKeys.Add(SDL.Keycode.F20, Keys.F20);
			_keycodeToKeys.Add(SDL.Keycode.F21, Keys.F21);
			_keycodeToKeys.Add(SDL.Keycode.F22, Keys.F22);
			_keycodeToKeys.Add(SDL.Keycode.F23, Keys.F23);
			_keycodeToKeys.Add(SDL.Keycode.F24, Keys.F24);

			_keycodeToKeys.Add(SDL.Keycode.MENU, Keys.Menu);
			_keycodeToKeys.Add(SDL.Keycode.KP_COMMA, Keys.Comma);

			_keycodeToKeys.Add(SDL.Keycode.LCTRL, Keys.LCtrl);
			_keycodeToKeys.Add(SDL.Keycode.LSHIFT, Keys.LShift);
			_keycodeToKeys.Add(SDL.Keycode.LALT, Keys.LAlt);
			_keycodeToKeys.Add(SDL.Keycode.RCTRL, Keys.RCtrl);
			_keycodeToKeys.Add(SDL.Keycode.RSHIFT, Keys.RShift);

			/*_keycodeToKeys.Add(SDL.Keycode.LGUI, Keys.LeftSuper);
			_keycodeToKeys.Add(SDL.Keycode.RGUI, Keys.RightSuper);*/
		}

		protected override void Platform_SetMouseCursor(Cursors cursors)
		{
			let index = GetSDLCursorIndex(cursors);

			if (sdlCursors[index] == null)
				sdlCursors[index] = SDL.CreateSystemCursor((SDL.SDL_SystemCursor)index);

			SDL.SetCursor(sdlCursors[index]);
		}

		protected override bool Platform_GetClipboardString(String output)
		{
			if (SDL.HasClipboardText() == SDL.Bool.True)
			{
				output.Append(SDL.GetClipboardText());
				return true;
			}
			return false;
		}

		protected override void Platform_SetClipboardString(String value)
		{
			SDL.SetClipboardText(value);
		}


		private static int GetSDLCursorIndex(Cursors cursors)
		{
			switch (cursors)
			{
			case Cursors.Default: return (int)SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_ARROW;
			case Cursors.Crosshair: return (int)SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_CROSSHAIR;
			case Cursors.Hand: return (int)SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_HAND;
			case Cursors.HorizontalResize: return (int)SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_SIZEWE;
			case Cursors.VerticalResize: return (int)SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_SIZENS;
			case Cursors.IBeam: return (int)SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_IBEAM;
			default:
				Log.Error("Cursor not supported");
				return (int)SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_ARROW;
			}
		}

		private static MouseButtons GetSdlMouseButton(uint8 buttonCode)
		{
			switch (buttonCode)
			{
			case SDL.SDL_BUTTON_LEFT: return MouseButtons.Left;
			case SDL.SDL_BUTTON_RIGHT: return MouseButtons.Right;
			case SDL.SDL_BUTTON_MIDDLE: return MouseButtons.Middle;
			default:
				return MouseButtons.Unknown;
			}
		}

		internal void ProcessEvent(SDL.Event e)
		{
			if (e.type == SDL.EventType.MouseButtonDown)
			{
				let button = GetSdlMouseButton(e.button.button);
				_mouse[(int)button] = true;
			}
			else if (e.type == SDL.EventType.MouseButtonUp)
			{
				let button = GetSdlMouseButton(e.button.button);
				_mouse[(int)button] = false;
			}
			else if (e.type == SDL.EventType.MouseWheel)
			{
				_mouseWheel = int2(e.wheel.x, e.wheel.y);
				//Log.Debug("_mouseWheel = {0}", _mouseWheel);
				//OnMouseWheel(e.wheel.x, e.wheel.y);
			}
			/*// joystick
			else if (e.type == SDL.EventType.JoyDeviceAdded)
			{
				var index = e.jdevice.which;

				if (SDL.IsGameController(index) == SDL.Bool.False)
				{
					var ptr = sdlJoysticks[index] = SDL.JoystickOpen(index);
					var name = SDL.JoystickName(ptr);
					var buttonCount = SDL.JoystickNumButtons(ptr);
					var axisCount = SDL.JoystickNumAxes(ptr);

					OnJoystickConnect((uint)index, scope String(name), (.)buttonCount, (.)axisCount, false);
				}
			}
			else if (e.type == SDL.EventType.JoyDeviceRemoved)
			{
				var index = e.jdevice.which;

				if (SDL.IsGameController(index) == SDL.Bool.False)
				{
					OnJoystickDisconnect((uint)index);

					var ptr = sdlJoysticks[index];
					sdlJoysticks[index] = null;
					SDL.JoystickClose(ptr);
				}
			}
			else if (e.type == SDL.EventType.JoyButtonDown)
			{
				var index = e.jbutton.which;
				if (SDL.IsGameController(index) == SDL.Bool.False)
					OnJoystickButtonDown((uint)index, e.jbutton.button);
			}
			else if (e.type == SDL.EventType.JoyButtonUp)
			{
				var index = e.jbutton.which;
				if (SDL.IsGameController(index) == SDL.Bool.False)
					OnJoystickButtonUp((uint)index, e.jbutton.button);
			}
			else if (e.type == SDL.EventType.JoyAxisMotion)
			{
				var index = e.jaxis.which;
				if (SDL.IsGameController(index) == SDL.Bool.False)
				{
					var value = Math.Max(-1f, Math.Min(1f, (float)e.jaxis.axisValue / int16.MaxValue));
					OnJoystickAxis((uint)index, e.jaxis.axis, value);
				}
			}*/
			// controller
			else if (e.type == SDL.EventType.ControllerDeviceadded)
			{
				var index = e.cdevice.which;
				var ptr = sdlGamepads[index] = SDL.GameControllerOpen(index);
				var name = SDL.GameControllerName(ptr);
				if (index < MaxControllers)
				{
					Log.Debug($"Controller [{name}] :: connected -> index: {index}");
				}
				//OnJoystickConnect((uint)index, scope String(name), 15, 6, true);
			}
			else if (e.type == SDL.EventType.ControllerDeviceremoved)
			{
				var index = e.cdevice.which;
				if (index < MaxControllers)
				{
					Log.Debug($"Controller [{index}] : disconnected ");
					//_controllers[index].[Friend]Disconnect();
				}
				//OnJoystickDisconnect((uint)index);

				var ptr = sdlGamepads[index];
				sdlGamepads[index] = null;
				SDL.GameControllerClose(ptr);
			}
			else if (e.type == SDL.EventType.ControllerButtondown)
			{
				var index = e.cbutton.which;
				var button = GamepadButtonToEnum(e.cbutton.button);

				if (index < MaxControllers && button != .Invalid)
				{
					_buttons[index][(int)button] = true;
					//Log.Debug($"Controller [{index}] :: down -> {button}");
				}

				//OnGamepadButtonDown((uint)index, button);
			}
			else if (e.type == SDL.EventType.ControllerButtonup)
			{
				var index = e.cbutton.which;
				var button = GamepadButtonToEnum(e.cbutton.button);

				if (index < MaxControllers && button != .Invalid)
				{
					_buttons[index][(int)button] = false;
					//Log.Debug($"Controller [{index}] :: up -> {button}");
				}

				//OnGamepadButtonUp((uint)index, button);
			}
			else if (e.type == SDL.EventType.ControllerAxismotion)
			{
				var index = e.caxis.which;
				var axis = GamepadAxisToEnum(e.caxis.axis);
				var value = Math.Max(-1f, Math.Min(1f, e.caxis.axisValue / (float)int16.MaxValue));

				if (index < MaxControllers && axis != .Invalid)
				{
					_axis[index][(int)axis] = value;
					//Log.Debug($"Controller [{index}] -> {axis} [{value}]");
				}

				//OnGamepadAxis((uint)index, axis, value);
			}
			// keys
			else if (e.type == SDL.EventType.KeyDown || e.type == SDL.EventType.KeyUp)
			{
				if (e.key.isRepeat == 0)
				{
					var keycode = e.key.keysym.sym;
					if (!_keycodeToKeys.TryGetValue(keycode, var key))
						key = Keys.Invalid;

					if (key != .Invalid)
						_keys[(int)key] = e.type == SDL.EventType.KeyDown;
				}
			}
			/*// text
			else if (e.type == SDL.EventType.TextInput)
			{
				int index = 0;
				while (e.text.text[index] != 0)
					OnText((char8)(e.text.text[index++]));
			}*/
		}

		private static Buttons GamepadButtonToEnum(uint8 buttonCode)
		{
			let button = (SDL.SDL_GameControllerButton)buttonCode;
			switch (button)
			{
			case SDL.SDL_GameControllerButton.A: return Buttons.A;
			case SDL.SDL_GameControllerButton.B: return Buttons.B;
			case SDL.SDL_GameControllerButton.X: return Buttons.X;
			case SDL.SDL_GameControllerButton.Y: return Buttons.Y;
			case SDL.SDL_GameControllerButton.Back: return Buttons.Back;
			case SDL.SDL_GameControllerButton.Guide: return Buttons.Guide;
			case SDL.SDL_GameControllerButton.Start: return Buttons.Start;
			case SDL.SDL_GameControllerButton.LeftStick: return Buttons.LeftStick;
			case SDL.SDL_GameControllerButton.RightStick: return Buttons.RightStick;
			case SDL.SDL_GameControllerButton.LeftShoulder: return Buttons.LeftShoulder;
			case SDL.SDL_GameControllerButton.RightShoulder: return Buttons.RightShoulder;
			case SDL.SDL_GameControllerButton.DpadUp: return Buttons.DpadUp;
			case SDL.SDL_GameControllerButton.DpadDown: return Buttons.DpadDown;
			case SDL.SDL_GameControllerButton.DpadLeft: return Buttons.DpadLeft;
			case SDL.SDL_GameControllerButton.DpadRight: return Buttons.DpadRight;
			default:
				return Buttons.Invalid;
			}
		}

		private static Axes GamepadAxisToEnum(uint8 axesCode)
		{
			let axes = (SDL.SDL_GameControllerAxis)axesCode;
			switch (axes)
			{
			case SDL.SDL_GameControllerAxis.LeftX: return Axes.LeftX;
			case SDL.SDL_GameControllerAxis.LeftY: return Axes.LeftY;
			case SDL.SDL_GameControllerAxis.RightX: return Axes.RightX;
			case SDL.SDL_GameControllerAxis.RightY: return Axes.RightY;
			case SDL.SDL_GameControllerAxis.TriggerLeft: return Axes.TriggerLeft;
			case SDL.SDL_GameControllerAxis.TriggerRight: return Axes.TriggerRight;
			default:
				return Axes.Invalid;
			}
		}
	}
}
