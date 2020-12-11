namespace NeonShooter
{
	using System;
	using Atma;
	using System.Collections;

	public static class Program
	{
		static public int Main(String[] args)
		{
			return Core.RunScene<NeonGame>("NeonShooter", 1280, 760);
		}
	}
}
