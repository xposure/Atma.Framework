using System.Collections;
namespace Atma
{
	public class VirtualButton : VirtualInput
	{
		public bool Check { get; private set; }
		public bool Pressed { get; private set; }
		public bool Released { get; private set; }
		public bool Repeating { get; private set; }

		private List<Node> nodes;
		private int64 pressBuffer;
		private int64 releaseBuffer;
		private int64 repeatStart;
		private int64 repeatInterval;

		private int64 lastPress;
		private int64 lastRelease;
		private int64 lastPressClear;
		private int64 lastReleaseClear;

		public this()
		{
			nodes = new List<Node>();
		}

		public ~this()
		{
			for (var n in nodes)
				delete n;
			delete nodes;
		}

		override public void Update()
		{
			base.Update();

			//Check
			let last = Check;
			Check = false;
			for (var n in nodes)
			{
				if (n.Check)
				{
					Check = true;
					fromGamepad = n.IsGamepad;
					break;
				}
			}

			//Press
			if (!last && Check)
				lastPress = Time.RawTime;
			Pressed = Check && lastPress > lastPressClear && (Time.RawTime - lastPress) <= pressBuffer;

			//Repeat
			if (Check && repeatStart > 0 && (Time.RawTime - lastPress) >= repeatStart)
			{
				Repeating = true;

				let a = (Time.RawPrevTime - lastPress) / repeatInterval;
				let b = (Time.RawTime - lastPress) / repeatInterval;
				if (a != b)
					Pressed = true;
			}
			else
				Repeating = false;

			//Release
			if (last && !Check)
				lastRelease = Time.RawTime;

			let check0 = !Check;
			let check1 = lastRelease > lastReleaseClear;
			let check2 = (Time.RawTime - lastRelease) <= releaseBuffer;

			Released = check0 && check1 && check2;
		}

		public void ClearPressBuffer()
		{
			lastPressClear = Time.RawTime;
		}

		public void ClearReleaseBuffer()
		{
			lastReleaseClear = Time.RawTime;
		}

		// Setup Calls

		public VirtualButton AddKey(Keys key)
		{
			nodes.Add(new KeyboardKey(key));
			return this;
		}

		public VirtualButton AddButton(int gamepadID, Buttons button)
		{
			nodes.Add(new GamepadButton(gamepadID, button));
			return this;
		}

		public VirtualButton AddMouseButton(MouseButtons mouseButton)
		{
			nodes.Add(new MouseButton(mouseButton));
			return this;
		}

		public VirtualButton AddAxis(int gamepadID, Axes axis, float threshold, ThresholdConditions condition = .GreaterThan)
		{
			nodes.Add(new GamepadAxis(gamepadID, axis, threshold, condition));
			return this;
		}

		public VirtualButton PressBuffer(int64 time)
		{
			pressBuffer = time;
			return this;
		}

		public VirtualButton ReleaseBuffer(int64 time)
		{
			releaseBuffer = time;
			return this;
		}

		public VirtualButton Repeat(int64 start, int64 interval)
		{
			repeatStart = start;
			repeatInterval = interval;
			return this;
		}

		// Nodes
		private abstract class Node
		{
			public abstract bool Check { get; }
			public virtual bool IsGamepad => false;
		}

		private class MouseButton : Node
		{
			public MouseButtons MouseButton;

			public this(MouseButtons mouseButton)
			{
				MouseButton = mouseButton;
			}

			override public bool Check
			{
				get
				{
					return Core.Input.MouseCheck(MouseButton);
				}
			}
		}

		private class KeyboardKey : Node
		{
			public Keys Key;

			public this(Keys key)
			{
				Key = key;
			}

			override public bool Check
			{
				get
				{
					return Core.Input.KeyCheck(Key);
				}
			}
		}

		private class GamepadButton : Node
		{
			public int GamepadID;
			public Buttons Button;

			public override bool IsGamepad => true;

			public this(int gamepadID, Buttons button)
			{
				GamepadID = gamepadID;
				Button = button;
			}

			override public bool Check
			{
				get
				{
					return Core.Input.GamepadButtonCheck(GamepadID, Button);
				}
			}
		}

		private class GamepadAxis : Node
		{
			public int GamepadID;
			public Axes Axis;
			public float Threshold;
			public ThresholdConditions Condition;

			public override bool IsGamepad => true;

			public this(int gamepadID, Axes axis, float threshold, ThresholdConditions condition = .GreaterThan)
			{
				GamepadID = gamepadID;
				Axis = axis;
				Threshold = threshold;
				Condition = condition;
			}

			override public bool Check
			{
				get
				{
					if (Condition == .GreaterThan)
						return Core.Input.GamepadAxisCheck(GamepadID, Axis) >= Threshold;
					else
						return Core.Input.GamepadAxisCheck(GamepadID, Axis) <= Threshold;
				}
			}
		}
	}
}
