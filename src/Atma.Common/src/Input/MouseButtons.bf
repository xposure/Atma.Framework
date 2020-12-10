namespace Atma
{
	/// <summary>
	/// Mouse Buttons
	/// </summary>
	public enum MouseButtons : int32
	{
		case None = 0;
		case Unknown = 1;
		case Left = 2;
		case Middle = 3;
		case Right = 4;

		public const int Count = (.)Right + 1;
	}
}

