namespace Atma
{
	public struct Wrap<T>
		where T : operator -- T
		where T : operator ++ T
		where T : operator T - T
		where T : operator T + T
		where T : operator T % T
		where bool : operator T < T
	{
		private T _min;
		private T _max;
		private T _value;

		public this(T value, T min, T max)
		{
			_value = value;
			_min = min;
			_max = max;
		}

		public this(T min, T max) : this(default, min, max)
		{
		}

		public this(T max) : this(default, default, max)
		{
		}

		public static implicit operator T(Wrap<T> t) => t._value;

		public static Wrap<T> operator++(Wrap<T> t)
		{
			var x = t._value;
			x++;
			return .(Calc.Wrap(x, t._min, t._max), t._min, t._max);
		}

		public static Wrap<T> operator--(Wrap<T> t)
		{
			var x = t._value;
			x--;
			return .(Calc.Wrap(x, t._min, t._max), t._min, t._max);
		}
	}
}
