namespace Atma
{
	//As far as I know SDL2 only supports a single music file being played
	//we need to eventually write an audio manager to track this sort of think
	//and fade things in and out
	public class Music
	{
		public void Play() => PlatformPlay();

		protected extern void PlatformPlay();
	}
}
