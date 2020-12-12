namespace Atma
{
	//We should eventually write an audio manager to track all the sound effects
	//we are playing
	public class SoundEffect
	{
		public void Play(float x, float y, float z) => PlatformPlay();

		protected extern void PlatformPlay();
	}
}
