using System;

namespace Atma
{
	public struct Timer
	{
		private int64 _duration;
		private int64 _end;

		public this(float duration)
		{
			_duration = ?;
			_end = ?;
			Reset(duration);
		}

		public float t => 1f - (Remaining / (float)_duration);
		public int64 Remaining => Math.Max(_end - Time.Time, 0);
		public bool Completed => _end > 0 && Remaining == 0;

		public static implicit operator bool(Timer it) => it.Completed;

		public void Reset() mut
		{
			_end = Time.Time + _duration;
		}

		public void Reset(float duration) mut
		{

			_duration = (.)(duration * Time.MicroToSeconds) ;
			_end = Time.Time + _duration;
		}

		public void Clear() mut
		{
			_end = 0;
		}
	}

	public struct Duration
	{
		private int64 _duration;
		private int64 _end;

		public this(float duration)
		{
			_duration = ?;
			_end = ?;
			Reset(duration);
		}

		public float t => 1f - (Math.Max(_end - Time.Time, 0) / (float)_duration);
		public float Remaining => Math.Max(_end - Time.Time, 0);
		public bool Completed => _end > 0 && Remaining > 0;

		public static implicit operator bool(Duration it) => it.Completed;

		public void Reset() mut
		{
			_end = Time.Time + _duration;
		}

		public void Reset(float duration) mut
		{
			_duration = (.)(duration * Time.MicroToSeconds);
			_end = Time.Time + _duration;
		}

		public void Clear() mut
		{
			_end = 0;
		}
	}
}

