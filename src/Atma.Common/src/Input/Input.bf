using System;
using System.Collections;
namespace Atma
{
	public class Input
	{
		internal static int2 _mouseWheel = int2.Zero;
		internal static int2 _mousePosition = int2.Zero;
		internal static bool _capsLock = false;
		internal static bool _numLock = false;

		protected extern bool Platform_PollKeyboard(Keys key);

		protected extern bool Platform_PollMouse(MouseButtons button);

		protected extern bool Platform_PollGamepadButton(int gamepadID, Buttons button);

		protected extern float Platform_PollGamepadAxis(int gamepadID, Axes axis);

		protected extern void Platform_SetMouseCursor(Cursors cursors);

		protected extern bool Platform_GetClipboardString(String output);

		protected extern void Platform_SetClipboardString(String value);

		protected extern void Platform_Update();

		public List<VirtualInput> VirtualInputs = new .() ~ DeleteContainerAndItems!(_);

		private bool[Keys.Count] previousKeyboard;
		private float[Keys.Count] lastKeypressTimes;

		public void Update()
		{
			for (let i < previousKeyboard.Count)
			{
				if (!previousKeyboard[i] && Platform_PollKeyboard((Keys)i))
					lastKeypressTimes[i] = (int64)Time.Elapsed;
				previousKeyboard[i] = Platform_PollKeyboard((Keys)i);
			}

			for (var it in VirtualInputs)
				it.Update();
		}

		public bool Ctrl => KeyCheck(Keys.LCtrl) || KeyCheck(Keys.RCtrl);
		public bool Alt => KeyCheck(Keys.LCtrl) || KeyCheck(Keys.RCtrl);
		public bool Shift => KeyCheck(Keys.LCtrl) || KeyCheck(Keys.RCtrl);
		public bool CapsLock => _numLock;
		public bool NumLock => _capsLock;

		public bool KeyCheck(Keys key)
		{
			return Platform_PollKeyboard(key);
		}

		public bool KeyPressed(Keys key)
		{
			return Platform_PollKeyboard(key) && !previousKeyboard[(int)key];
		}

		public bool KeyPressed(Keys key, float repeatDelay, float repeatInterval)
		{
			if (Platform_PollKeyboard(key))
				return !previousKeyboard[(int)key] || Time.OnInterval(repeatInterval, lastKeypressTimes[(int)key] + repeatDelay);
			else
				return false;
		}

		public bool KeyReleased(Keys key)
		{
			return !Platform_PollKeyboard(key) && previousKeyboard[(int)key];
		}

		public void KeystrokesIntoString(String toString, float keyRepeatDelay, float keyRepeatInterval)
		{
			KeystrokesIntoStringUtil(toString, scope (k) => KeyPressed(k, keyRepeatDelay, keyRepeatInterval));
		}

		public void KeystrokesIntoString(String toString)
		{
			KeystrokesIntoStringUtil(toString, scope => KeyPressed);
		}

		private void KeystrokesIntoStringUtil(String toString, delegate bool(Keys) pressed)
		{
			for (let i < (int)Keys.Count)
			{
				let key = (Keys)i;
				if (pressed(key))
				{
					if (key >= .A && key <= .Z)
					{
						char8 c;
						if (Shift || CapsLock)
							c = 'A' + (int)(key - .A);
						else
							c = 'a' + (int)(key - .A);
						toString.Append(c);
					}
					else if (key >= .Key1 && key <= .Key9 && !Shift)
					{
						char8 c = '1' + (int)(key - .Key1);
						toString.Append(c);
					}
					else
					{
						switch (key)
						{
						case .Key1 when Shift:
							toString.Append('!');
						case .Key2 when Shift:
							toString.Append('@');
						case .Key3 when Shift:
							toString.Append('#');
						case .Key4 when Shift:
							toString.Append('$');
						case .Key5 when Shift:
							toString.Append('%');
						case .Key6 when Shift:
							toString.Append('^');
						case .Key7 when Shift:
							toString.Append('&');
						case .Key8 when Shift:
							toString.Append('*');
						case .Key9 when Shift:
							toString.Append('(');
						case .Key0 when Shift:
							toString.Append(')');
						case .Key0:
							toString.Append('0');
						case .Space:
							toString.Append(' ');
						case .Minus when Shift:
							toString.Append('_');
						case .Minus:
							toString.Append('-');
						case .Equals when Shift:
							toString.Append('+');
						case .Equals:
							toString.Append('=');
						case .LeftBracket when Shift:
							toString.Append('{');
						case .LeftBracket:
							toString.Append('[');
						case .RightBracket when Shift:
							toString.Append('}');
						case .RightBracket:
							toString.Append(']');
						case .BackSlash when Shift:
							toString.Append('|');
						case .BackSlash:
							toString.Append('\\');
						case .Semicolon when Shift:
							toString.Append(':');
						case .Semicolon:
							toString.Append(';');
						case .Apostrophe when Shift:
							toString.Append('"');
						case .Apostrophe:
							toString.Append('\'');
						case .Comma when Shift:
							toString.Append('<');
						case .Comma:
							toString.Append(',');
						case .Period when Shift:
							toString.Append('>');
						case .Period:
							toString.Append('.');
						case .Slash when Shift:
							toString.Append('?');
						case .Slash:
							toString.Append('/');
						case .BackSpace:
							if (toString.Length > 0)
								toString.RemoveFromEnd(1);
						default:
						}
					}
				}
			}
		}

		public int2 MousePosition => _mousePosition;

		public int2 MouseWheel => _mouseWheel;

		public bool MouseCheck(MouseButtons button) => Platform_PollMouse(button);

		public bool GamepadButtonCheck(int gamepadID, Buttons button)
		{
			return Platform_PollGamepadButton(gamepadID, button);
		}

		public float GamepadAxisCheck(int gamepadID, Axes axis)
		{
			return Platform_PollGamepadAxis(gamepadID, axis);
		}
	}
}
