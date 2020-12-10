using System;

namespace Atma
{
	public struct Easer<T>
		where T : operator T * float
		where T : operator T - T
		where T : operator T + T
	{
		private float _scale;
		private double _start;
		private T _current, _goal;
		private Ease.Easing _easing;

		public this(T current, Ease.Easing easing, float scale = 1f) : this(current, current, easing, scale)
		{
		}

		public this(T current, T goal, Ease.Easing easing, float scale = 1f)
		{
			_scale = scale;
			_current = current;
			_goal = goal;
			_start = Time.Elapsed;
			_easing = easing;
		}


		public float Duration => (float)Math.Clamp((Time.Elapsed - _start) * _scale, 0f, 1f);

		public bool IsTweening => Duration < 1f;

		private T Current
		{
			get
			{
				let t = Duration;
				if (t == 1f)
					return _goal;

				let d = _goal - _current;
				return _current + d * _easing.Ease(t);
			}
		}

		public static implicit operator T(Easer<T> it) => it.Current;

		public T this[int i]
		{
			get => _current;
			set mut
			{
				_goal = value;
			}
		}

		public T Goal
		{
			get => _goal;
			set mut
			{
				_current = Current;
				_start = Time.Elapsed;
				_goal = value;
			}
		}
	}





	/*public struct Easer2<T> where T : operator T * float where T : operator T - T where T : operator T + T
	{
		private float _scale;
		private double _start;
		private T _current , _goal;
		private Ease.Easing _easing;

		public this(T current, Ease.Easing easing, float scale = 1f)
		{
			_scale = scale;
			_current = _goal = current;
			_start = 0;
			_easing = easing;
		}

		private T Current
		{
			get
			{
				let t = (float)Math.Clamp((Time.Duration.TotalSeconds - _start) * _scale, 0f, 1f);
				if (t == 1f)
					return _goal;

				let d = _goal - _current;
				return _current + d * _easing.Ease(t);
			}
		}

		/*public static implicit operator T(Easer<T> it) => it.Current;
		public static implicit operator Easer<T>(T t) => it.Goal = it;*/
		public T Goal
		{
			get => _goal;
			set mut
			{
				_current = Current;
				_start = Time.Duration.TotalSeconds;
				_goal = value;
			}
		}

		public T this
		{
			get => Current;
			set mut
		}
	}*/

	public static class Ease
	{
		public enum Easing
		{
			case Linear;
			case SmoothStep;
			case SmootherStep;
			case SineIn;
			case SineOut;
			case SineInOut;
			case QuadIn;
			case QuadOut;
			case QuadInOut;
			case CubeIn;
			case CubeOut;
			case CubeInOut;
			case QuintIn;
			case QuintOut;
			case QuintInOut;
			case ExpoIn;
			case ExpoOut;
			case ExpoInOut;
			case BackIn;
			case BackOut;
			case BackInOut;
			case BigBackIn;
			case BigBackOut;
			case BigBackInOut;
			case ElasticIn;
			case ElasticOut;
			case ElasticInOut;
			case BounceIn;
			case BounceOut;
			case BounceInOut;

			public float Ease(float t)
			{
				switch (this) {
				case .Linear: return Linear(t);
				case .SmoothStep: return SmoothStep(t);
				case .SmootherStep: return SmootherStep(t);
				case .SineIn: return SineIn(t);
				case .SineOut: return SineOut(t);
				case .SineInOut: return SineInOut(t);
				case .QuadIn: return QuadIn(t);
				case .QuadOut: return QuadOut(t);
				case .QuadInOut: return QuadInOut(t);
				case .CubeIn: return CubeIn(t);
				case .CubeOut: return CubeOut(t);
				case .CubeInOut: return CubeInOut(t);
				case .QuintIn: return QuintIn(t);
				case .QuintOut: return QuintOut(t);
				case .QuintInOut: return QuintInOut(t);
				case .ExpoIn: return ExpoIn(t);
				case .ExpoOut: return ExpoOut(t);
				case .ExpoInOut: return ExpoInOut(t);
				case .BackIn: return BackIn(t);
				case .BackOut: return BackOut(t);
				case .BackInOut: return BackInOut(t);
				case .BigBackIn: return BigBackIn(t);
				case .BigBackOut: return BigBackOut(t);
				case .BigBackInOut: return BigBackInOut(t);
				case .ElasticIn: return ElasticIn(t);
				case .ElasticOut: return ElasticOut(t);
				case .ElasticInOut: return ElasticInOut(t);
				case .BounceIn: return BounceIn(t);
				case .BounceOut: return BounceOut(t);
				case .BounceInOut: return BounceInOut(t);
				}
			}
		}

		public static float Linear(float t) => t;

		public static float SineIn(float t) => -(float)Math.Cos(Math.PI_d / 2 * t) + 1;
		public static float SineOut(float t) => (float)Math.Sin(Math.PI_d / 2 * t);
		public static float SineInOut(float t) => -(float)Math.Cos(Math.PI_d / 2 * t) + 1f;

		public static float QuadIn(float t) => t * t;
		public static float QuadOut(float t) => Invert( => QuadIn, t);
		public static float QuadInOut(float t) => Follow( => QuadIn, => QuadOut, t);

		public static float SmoothStep(float t) => (3 - 2 * t) * t * t;
		public static float SmootherStep(float t) => ((6 * t - 15) * t + 10) * t * t * t;
		public static float CubeIn(float t) => t * t * t;
		public static float CubeOut(float t) => Invert( (t) => t * t * t, t);

		public static float CubeInOut(float t) => Follow( => CubeIn, => CubeOut, t);

		public static float QuintIn(float t) => t * t * t * t * t;
		public static float QuintOut(float t) => Invert( => QuintIn, t);

		public static float QuintInOut(float t) => Follow( => QuintIn, => QuintOut, t);

		public static float ExpoIn(float t) => (float)Math.Pow(2, 10 * (t - 1));
		public static float ExpoOut(float t) => Invert( => ExpoIn, t);

		public static float ExpoInOut(float t) => Follow( => ExpoIn, => ExpoOut, t);

		public static float BackIn(float t) => t * t * (2.70158f * t - 1.70158f);
		public static float BackOut(float t) => Invert( => BackIn, t);

		public static float BackInOut(float t) => Follow( => BackIn, => BackOut, t);

		public static float BigBackIn(float t) => t * t * (4f * t - 3f);
		public static float BigBackOut(float t) => Invert( => BigBackIn, t);
		public static float BigBackInOut(float t) => Follow( => BigBackIn, => BigBackOut, t);

		public static float ElasticIn(float t)
		{
			var ts = t * t;
			var tc = ts * t;
			return (33 * tc * ts + -59 * ts * ts + 32 * tc + -5 * ts);
		}

		public static float ElasticOut(float t)
		{
			var ts = t * t;
			var tc = ts * t;
			return (33 * tc * ts + -106 * ts * ts + 126 * tc + -67 * ts + 15 * t);
		}

		public static float ElasticInOut(float t) => Follow( => ElasticIn, => ElasticOut, t);

		public const float B1 = 1f / 2.75f;
		public const float B2 = 2f / 2.75f;
		public const float B3 = 1.5f / 2.75f;
		public const float B4 = 2.5f / 2.75f;
		public const float B5 = 2.25f / 2.75f;
		public const float B6 = 2.625f / 2.75f;

		public static float BounceIn(float t)
		{
			var t;
			t = 1 - t;
			if (t < B1)
				return 1 - 7.5625f * t * t;
			if (t < B2)
				return 1 - (7.5625f * (t - B3) * (t - B3) + 0.75f);
			if (t < B4)
				return 1 - (7.5625f * (t - B5) * (t - B5) + 0.9375f);
			return 1 - (7.5625f * (t - B6) * (t - B6) + 0.984375f);
		}

		public static float BounceOut(float t)
		{
			if (t < B1)
				return 7.5625f * t * t;
			if (t < B2)
				return 7.5625f * (t - B3) * (t - B3) + 0.75f;
			if (t < B4)
				return 7.5625f * (t - B5) * (t - B5) + 0.9375f;
			return 7.5625f * (t - B6) * (t - B6) + 0.984375f;
		}

		public static float BounceInOut(float t)
		{
			var t;
			if (t < 0.5f)
			{
				t = 1 - t * 2;
				if (t < B1)
					return (1 - 7.5625f * t * t) / 2;
				if (t < B2)
					return (1 - (7.5625f * (t - B3) * (t - B3) + 0.75f)) / 2;
				if (t < B4)
					return (1 - (7.5625f * (t - B5) * (t - B5) + 0.9375f)) / 2;
				return (1 - (7.5625f * (t - B6) * (t - B6) + 0.984375f)) / 2;
			}
			t = t * 2 - 1;
			if (t < B1)
				return (7.5625f * t * t) / 2 + 0.5f;
			if (t < B2)
				return (7.5625f * (t - B3) * (t - B3) + 0.75f) / 2 + 0.5f;
			if (t < B4)
				return (7.5625f * (t - B5) * (t - B5) + 0.9375f) / 2 + 0.5f;
			return (7.5625f * (t - B6) * (t - B6) + 0.984375f) / 2 + 0.5f;
		}


		[Inline]
		public static float Invert<T>(T easer, float t) where T : delegate float(float)
		{
			return 1f - easer(1f - t);
		}



		[Inline]
		public static float Follow<T>(T first, T second, float t) where T : delegate float(float)
		{
			return (t <= 0.5f) ? first(t * 2) / 2 : second(t * 2 - 1) / 2 + 0.5f;
		}


		[Inline]
		public static float UpDown(float eased)
		{
			if (eased <= 0.5f)
				return eased * 2;
			else
				return 1 - (eased - 0.5f) * 2;
		}
	}
}

