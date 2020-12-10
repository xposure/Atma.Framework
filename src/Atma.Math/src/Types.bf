namespace Atma
{
	typealias long = int64;

	static class IntConsts
	{
		public const int MaxValue = sizeof(int) == 8 ? int64.MaxValue : int32.MaxValue;
		public const int MinValue = sizeof(int) == 8 ? int64.MinValue : int32.MinValue;
	}
}
