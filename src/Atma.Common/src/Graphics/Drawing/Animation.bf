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
		public Subtexture Subtexture => Animation.GetTexture(FrameIndex);
		public int FrameIndex => Animation.GetFrameIndex(_currentDuration);

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

			if (_state == .Forward)
			{
				_currentDuration += dt * 1000;
				if (_currentDuration >= Animation.Duration)
				{
					if (Loop)
					{
						_currentDuration -= Animation.Duration;
					} else
					{
						_state = .Stop;
						_currentDuration = Animation.Duration;
					}
				}
			}
			else if (_state == .Backward)
			{
				_currentDuration -= dt * 1000;
				if (_currentDuration <= 0)
				{
					if (Loop)
					{
						_currentDuration += Animation.Duration;
					} else
					{
						_state = .Stop;
						_currentDuration = 0;
					}
				}
			}
			/*if (t >= 1f)
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
				else
					_state = .Stop;
			}*/
		}

		public void Reset() mut
		{
			_state = .Stop;
			_currentDuration = 0;
		}

		public void Restart(AnimationState state = .Forward) mut
		{
			if (state == .Backward)
			{
				_state = .Backward;
				_currentDuration = Animation.Duration;
			} else
			{
				_state = .Forward;
				_currentDuration = 0;
			}
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

		public int GetFrameIndex(float duration)
		{
			//small optimization?
			var duration;
			for (var i < _frames.Count)
			{
				let frameDuration = _frames[i].Duration;
				if (duration <= frameDuration)
					return i;

				duration -= frameDuration;
			}

			return _frames.Count - 1;
		}

		public Subtexture GetTexture(int frameIndex)
		{
			return _frames[frameIndex].Texture;
		}
	}
}
