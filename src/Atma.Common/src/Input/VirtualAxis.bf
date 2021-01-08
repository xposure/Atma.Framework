using System.Collections;
using System;
namespace Atma
{
	public class VirtualAxis : VirtualInput
	{
		public float Value { get; private set; }
		public int Valuei { get; private set; }
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

		public override void Update()
		{
			base.Update();

			for (var n in nodes)
				n.Update();

			//Value
			let last = Valuei;
			Value = 0;
			for (var n in nodes)
			{
				if (n.Value != 0)
				{
					fromGamepad = n.IsGamepad;
					Value = n.Value;
					break;
				}
			}
			Valuei = Math.Sign(Value);

			//Press
			if (last != Valuei && Valuei != 0)
				lastPress = Time.Time;
			Pressed = Valuei != 0 && lastPress > lastPressClear && (Time.Time - lastPress) <= pressBuffer;

			//Repeat
			if (Valuei != 0 && repeatStart > 0 && (int64)(Time.Time - lastPress) >= repeatStart)
			{
				Repeating = true;

				let a = ((Time.PrevTime - lastPress) / repeatInterval);
				let b = ((Time.Time - lastPress) / repeatInterval);
				if (a != b)
					Pressed = true;
			}
			else
				Repeating = false;

			//Release
			if (last != 0 && Valuei == 0)
				lastRelease = Time.Time;
			Released = Valuei == 0 && lastRelease > lastReleaseClear && (Time.Time - lastRelease) <= releaseBuffer;
		}

		public void ClearPressBuffer()
		{
			lastPressClear = Time.Time;
		}

		public void ClearReleaseBuffer()
		{
			lastReleaseClear = Time.Time;
		}

		// Setup Calls

		public VirtualAxis AddKeys(Keys negativeKey, Keys positiveKey, OverlapBehaviors overlapBehavior = .TakeNewer)
		{
			nodes.Add(new KeyboardKeys(negativeKey, positiveKey, overlapBehavior));
			return this;
		}

		public VirtualAxis AddButtons(int gamepadID, Buttons negativeButton, Buttons positiveButton, OverlapBehaviors overlapBehavior = .TakeNewer)
		{
			nodes.Add(new GamepadButtons(gamepadID, negativeButton, positiveButton, overlapBehavior));
			return this;
		}

		public VirtualAxis AddAxis(int gamepadID, Axes axis, float deadzone)
		{
			nodes.Add(new GamepadAxis(gamepadID, axis, deadzone));
			return this;
		}

		public VirtualAxis PressBuffer(int64 time)
		{
			pressBuffer = time;
			return this;
		}

		public VirtualAxis ReleaseBuffer(int64 time)
		{
			releaseBuffer = time;
			return this;
		}

		public VirtualAxis Repeat(int64 start, int64 interval)
		{
			repeatStart = start;
			repeatInterval = interval;
			return this;
		}

		// Nodes

		private abstract class Node
		{
			public abstract float Value { get; }
			public virtual void Update() { }
			public virtual bool IsGamepad => false;
		}

		private class KeyboardKeys : Node
		{
			public OverlapBehaviors OverlapBehavior;
			public Keys NegativeKey;
			public Keys PositiveKey;

			private float value;
			private bool turned;

			public this(Keys negativeKey, Keys positiveKey, OverlapBehaviors overlapBehavior = .TakeNewer)
			{
				NegativeKey = negativeKey;
				PositiveKey = positiveKey;
				OverlapBehavior = overlapBehavior;
			}

			public override void Update()
			{
				if (Core.Input.KeyCheck(PositiveKey))
				{
				    if (Core.Input.KeyCheck(NegativeKey))
				    {
				        switch (OverlapBehavior)
				        {
				            case OverlapBehaviors.CancelOut:
				                value = 0;
				                break;

				            case OverlapBehaviors.TakeNewer:
				                if (!turned)
				                {
				                    value *= -1;
				                    turned = true;
				                }
				                break;

				            case OverlapBehaviors.TakeOlder:
				                //value stays the same
				                break;
				        }
				    }
				    else
				    {
				        turned = false;
				        value = 1;
				    }
				}
				else if (Core.Input.KeyCheck(NegativeKey))
				{
				    turned = false;
				    value = -1;
				}
				else
				{
				    turned = false;
				    value = 0;
				}
			}

			public override float Value
			{
				get
				{
					return value;
				}
			}
		}

		private class GamepadButtons : Node
		{
			public int GamepadID;
			public OverlapBehaviors OverlapBehavior;
			public Buttons NegativeButton;
			public Buttons PositiveButton;

			private float value;
			private bool turned;

			public override bool IsGamepad => true;


			public this(int gamepadID, Buttons negativeButton, Buttons positiveButton, OverlapBehaviors overlapBehavior = .TakeNewer)
			{
				GamepadID = gamepadID;
				NegativeButton = negativeButton;
				PositiveButton = positiveButton;
				OverlapBehavior = overlapBehavior;
			}

			public override void Update()
			{
				if (Core.Input.GamepadButtonCheck(GamepadID, PositiveButton))
				{
				    if (Core.Input.GamepadButtonCheck(GamepadID, NegativeButton))
				    {
				        switch (OverlapBehavior)
				        {
				            case OverlapBehaviors.CancelOut:
				                value = 0;
				                break;

				            case OverlapBehaviors.TakeNewer:
				                if (!turned)
				                {
				                    value *= -1;
				                    turned = true;
				                }
				                break;

				            case OverlapBehaviors.TakeOlder:
				                //value stays the same
				                break;
				        }
				    }
				    else
				    {
				        turned = false;
				        value = 1;
				    }
				}
				else if (Core.Input.GamepadButtonCheck(GamepadID, NegativeButton))
				{
				    turned = false;
				    value = -1;
				}
				else
				{
				    turned = false;
				    value = 0;
				}
			}

			public override float Value
			{
				get
				{
					return value;
				}
			}
		}

		private class GamepadAxis : Node
		{
			public int GamepadID;
			public Axes Axis;
			public float Deadzone;

			public override bool IsGamepad => true;

			public this(int gamepadID, Axes axis, float deadzone)
			{
				GamepadID = gamepadID;
				Axis = axis;
				Deadzone = deadzone;
			}

			public override float Value
			{
				get
				{
					let val = Core.Input.GamepadAxisCheck(GamepadID, Axis);
					if (Math.Abs(val) < Deadzone)
						return 0;
					else
						return val;
				}
			}
		}

		public static implicit operator float(VirtualAxis self) => self.Value;
	}
}
