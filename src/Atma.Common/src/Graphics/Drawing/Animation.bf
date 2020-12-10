using System.Collections;
using System;
namespace Atma
{
	public struct AnimationPlayer
	{
		public enum AnimationState
		{
			Stop,
			Completed,
			Forward,
			Backward
		}

		private AnimationState _state = .Stop;
		public bool IsPlaying => _state == .Forward || _state == .Backward;
		public bool IsStopped => !IsPlaying;

		private float _currentDuration;
		public float CurrentDuration => _currentDuration;

		public readonly Animation Animation;
		public readonly bool Loop;
		public readonly bool Reverse;

		public float t => CurrentDuration / Duration;
		public float Duration => Animation.Duration;
		public Subtexture Subtexture => Animation.GetTexture(_currentDuration);

		public this(Animation animation, bool loop = false, bool reverse = false)
		{
			Animation = animation;
			Loop = loop;
			Reverse = reverse;
			_currentDuration = 0;
		}

		public void Update(float dt) mut
		{
			if (IsStopped)
				return;

			_currentDuration += dt * 1000;
			if (t >= 1f)
			{
				if (Reverse)
				{
					if (_state == .Forward)
					{
						_currentDuration = 1f - _currentDuration;
						_state = .Backward;
					}
					else if (_state == .Backward)
					{
						if (Loop)
						{
							_currentDuration = 1f - _currentDuration;
							_state = .Forward;
						}
					}
				} else if (Loop)
				{
					_currentDuration = 1f - _currentDuration;
				}
			}
		}

		public void Reset() mut
		{
			_state = .Stop;
			_currentDuration = 0;
		}

		public void Restart() mut
		{
			_state = .Forward;
			_currentDuration = 0;
		}

		public void Stop() mut
		{
			_state = .Stop;
		}
	}

	public class Animation
	{
		public struct AnimationFrame
		{
			public readonly Subtexture Texture;
			public readonly float Duration;

			public this(Subtexture texture, float duration)
			{
				Texture = texture;
				Duration = duration;
			}
		}

		private List<AnimationFrame> _frames = new .() ~ delete _;
		public float Duration;

		public readonly String Name = new .() ~ delete _;

		public this(StringView name)
		{
			Name.Set(name);
		}

		public void Add(Subtexture texture, float duration)
		{
			_frames.Add(.(texture, duration));
			Duration += duration;
		}

		public Subtexture GetTexture(float duration)
		{
			//small optimization?
			if (duration >= Duration)
				return _frames.Back.Texture;

			var duration;
			for (var i < _frames.Count)
			{
				let frameDuration = _frames[i].Duration;
				if (duration <= frameDuration)
					return _frames[i].Texture;

				duration -= frameDuration;
			}

			return _frames.Back.Texture;
		}
	}
}
