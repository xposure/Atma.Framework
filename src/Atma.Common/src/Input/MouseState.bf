using System;
using System.Collections;

namespace Atma
{
	/// <summary>
	/// Stores a Mouse State
	/// </summary>
	public struct MouseState
	{
		private readonly bool[MouseButtons.Count] _buttons;
		public readonly int2 WheelValue;
		public readonly int2 Position;

		public this()
		{
			this = default;
		}

		public this(int2 position, int2 wheelValue, bool[MouseButtons.Count] buttons)
		{
			Position = position;
			WheelValue = wheelValue;
			_buttons = buttons;
		}

		public bool IsDown(MouseButtons button) => _buttons[(int)button];
	}


	/*/// <summary>
	/// Stores a Mouse State
	/// </summary>
	public struct Mouse
	{
		public const int MaxButtons = 5;

		private bool[MaxButtons] pressed;
		private bool[MaxButtons] down;
		private bool[MaxButtons] released;
		private int64[MaxButtons] timestamp;
		private float2 wheelValue;

		public bool Pressed(MouseButtons button) => pressed[(int)button];
		public bool Down(MouseButtons button) => down[(int)button];
		public bool Released(MouseButtons button) => released[(int)button];

		public int64 Timestamp(MouseButtons button)
		{
			return timestamp[(int)button];
		}

		public bool Repeated(MouseButtons button, float delay, float interval)
		{
			if (Pressed(button))
				return true;

			var time = timestamp[(int)button] / (float)TimeSpan.TicksPerSecond;

			return Down(button) && (Time.Duration.TotalSeconds - time) > delay && Time.OnInterval(interval, time);
		}



		public bool LeftPressed => pressed[(int)MouseButtons.Left];
		public bool LeftDown => down[(int)MouseButtons.Left];
		public bool LeftReleased => released[(int)MouseButtons.Left];

		public bool RightPressed => pressed[(int)MouseButtons.Right];
		public bool RightDown => down[(int)MouseButtons.Right];
		public bool RightReleased => released[(int)MouseButtons.Right];

		public bool MiddlePressed => pressed[(int)MouseButtons.Middle];
		public bool MiddleDown => down[(int)MouseButtons.Middle];
		public bool MiddleReleased => released[(int)MouseButtons.Middle];

		public float2 Wheel => wheelValue;

		/*private void Copy(Mouse other) mut
		{
			pressed = other.pressed;
			down = other.down;
			released = other.released;
			timestamp = other.timestamp;

			wheelValue = other.wheelValue;
		}

		private void Step() mut
		{
			pressed = default;
			released = default;

			wheelValue = float2.Zero;
		}*/

	}*/
}

