namespace Atma
{
	using System;

	/// <summary>
	/// A Wrapper around a specific Monitor
	/// </summary>
	public struct Display
	{
		public readonly int Index;

		/// <summary>
		/// Whether this Monitor is the Primary Monitor
		/// </summary>
		public readonly bool IsPrimary;

		/// <summary>
		/// The name of the Monitor
		/// </summary>
		public readonly StringView Name;// = new .() ~ delete _;

		/// <summary>
		/// The bounds of the Monitor, in Screen Coordinates
		/// </summary>
		public readonly rect Bounds;

		/// <summary>
		/// The Content Scale of the Monitor
		/// </summary>
		public readonly float2 Scale;

		public this(int index, bool isPrimary, StringView name, rect bounds, float2 scale)
		{
			Index = index;
			IsPrimary = isPrimary;
			Name = name;
			Bounds = bounds;
			Scale = scale;
		}
	}
}

