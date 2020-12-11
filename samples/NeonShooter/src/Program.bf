namespace NeonShooter
{
	using System;
	using Atma;

	static public class Program
	{
		static public int Main(String[] args)
		{
			return Core.Run<NeonGame>("Test", 1280, 760, .Hidden);
		}
	}
}
