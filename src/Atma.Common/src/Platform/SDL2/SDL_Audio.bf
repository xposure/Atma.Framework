namespace Atma
{
	using System;
	using internal Atma;

	public extension Assets
	{
		protected static override SoundEffect PlatformLoadSoundEffect(StringView path)
		{
			var sound = new SoundEffect();

			sound.audioChunk = SDL2.SDLMixer.LoadWAV(path);
			if (sound.audioChunk == null)
				Log.Warning($"Failed to load sound {path}");

			return sound;
		}

		protected static override Music PlatformLoadMusic(StringView path)
		{
			var music = new Music();

			music.musicChunk = SDL2.SDLMixer.LoadMUS(path.Ptr);
			if (music.musicChunk == null)
				Log.Warning($"Failed to load music {path}");

			return music;
		}
	}

	public extension SoundEffect
	{
		internal SDL2.SDLMixer.Chunk* audioChunk;

		protected override void PlatformPlay()
		{
			SDL2.SDLMixer.PlayChannel(-1, audioChunk, 0);
		}

		public ~this()
		{
			SDL2.SDLMixer.FreeChunk(audioChunk);
		}
	}

	public extension Music
	{
		internal SDL2.SDLMixer.Music* musicChunk;

		protected override void PlatformPlay()
		{
			SDL2.SDLMixer.PlayMusic(musicChunk, int32.MaxValue);
		}

		public ~this()
		{
			SDL2.SDLMixer.FreeMusic(musicChunk);
		}
	}
}
