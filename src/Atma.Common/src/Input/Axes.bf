namespace Atma
{
	public enum Axes : int32
	{
		case Invalid = -1;
		case LeftX;
		case LeftY;
		case RightX;
		case RightY;
		case TriggerLeft;
		case TriggerRight;

		public const int Count = (.)TriggerRight + 1;
	}
}
