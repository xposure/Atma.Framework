namespace Atma
{
	public delegate void Action<T>(T t);
	public delegate void Action<T0, T1>(T0 t0, T1 t1);
	public delegate void Action<T0, T1, T2>(T0 t0, T1 t1, T2 t2);
	public delegate void Action<T0, T1, T2, T3>(T0 t0, T1 t1, T2 t2, T3 t3);
	public delegate void Action<T0, T1, T2, T3, T4>(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4);
	public delegate void Action<T0, T1, T2, T3, T4, T5>(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
	public delegate void Action<T0, T1, T2, T3, T4, T5, T6>(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6);
	public delegate void Action<T0, T1, T2, T3, T4, T5, T6, T7>(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);
	public delegate void Action<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);
	public delegate void Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9);

	public delegate Result Func<Result>();
	public delegate Result Func<T, Result>(T t);
	public delegate Result Func<T0, T1, Result>(T0 t0, T1 t1);
	public delegate Result Func<T0, T1, T2, Result>(T0 t0, T1 t1, T2 t2);
	public delegate Result Func<T0, T1, T2, T3, Result>(T0 t0, T1 t1, T2 t2, T3 t3);
	public delegate Result Func<T0, T1, T2, T3, T4, Result>(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4);
	public delegate Result Func<T0, T1, T2, T3, T4, T5, Result>(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
	public delegate Result Func<T0, T1, T2, T3, T4, T5, T6, Result>(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6);
	public delegate Result Func<T0, T1, T2, T3, T4, T5, T6, T7, Result>(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);
	public delegate Result Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, Result>(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);
	public delegate Result Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, Result>(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9);
}

