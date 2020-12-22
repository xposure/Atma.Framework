namespace Atma
{
	typealias Action = delegate void();
	typealias Action<T> = delegate void(T t);
	typealias Action<T0, T1> = delegate void(T0 t0, T1 t1);
	typealias Action<T0, T1, T2> = delegate void(T0 t0, T1 t1, T2 t2);
	typealias Action<T0, T1, T2, T3> = delegate void(T0 t0, T1 t1, T2 t2, T3 t3);
	typealias Action<T0, T1, T2, T3, T4> = delegate void(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4);
	typealias Action<T0, T1, T2, T3, T4, T5> = delegate void(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
	typealias Action<T0, T1, T2, T3, T4, T5, T6> = delegate void(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6);
	typealias Action<T0, T1, T2, T3, T4, T5, T6, T7> = delegate void(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);
	typealias Action<T0, T1, T2, T3, T4, T5, T6, T7, T8> = delegate void(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);
	typealias Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> = delegate void(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9);

	typealias Func<Result> = delegate Result();
	typealias Func<Result, T> = delegate Result(T t);
	typealias Func<Result, T0, T1> = delegate Result(T0 t0, T1 t1);
	typealias Func<Result, T0, T1, T2> = delegate Result(T0 t0, T1 t1, T2 t2);
	typealias Func<Result, T0, T1, T2, T3> = delegate Result(T0 t0, T1 t1, T2 t2, T3 t3);
	typealias Func<Result, T0, T1, T2, T3, T4> = delegate Result(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4);
	typealias Func<Result, T0, T1, T2, T3, T4, T5> = delegate Result(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
	typealias Func<Result, T0, T1, T2, T3, T4, T5, T6> = delegate Result(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6);
	typealias Func<Result, T0, T1, T2, T3, T4, T5, T6, T7> = delegate Result(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);
	typealias Func<Result, T0, T1, T2, T3, T4, T5, T6, T7, T8> = delegate Result(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);
	typealias Func<Result, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> = delegate Result(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9);

	//typealias Func2<Result> = function Result();
	/*typealias Func<Result, T> = delegate Result(T t);
	typealias Func<Result, T0, T1> = delegate Result(T0 t0, T1 t1);
	typealias Func<Result, T0, T1, T2> = delegate Result(T0 t0, T1 t1, T2 t2);
	typealias Func<Result, T0, T1, T2, T3> = delegate Result(T0 t0, T1 t1, T2 t2, T3 t3);
	typealias Func<Result, T0, T1, T2, T3, T4> = delegate Result(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4);
	typealias Func<Result, T0, T1, T2, T3, T4, T5> = delegate Result(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5);
	typealias Func<Result, T0, T1, T2, T3, T4, T5, T6> = delegate Result(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6
t6); typealias Func<Result, T0, T1, T2, T3, T4, T5, T6, T7> = delegate Result(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5,
T6 t6, T7 t7); typealias Func<Result, T0, T1, T2, T3, T4, T5, T6, T7, T8> = delegate Result(T0 t0, T1 t1, T2 t2, T3 t3,
T4 t4, T5 t5, T6 t6, T7 t7, T8 t8); typealias Func<Result, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> = delegate Result(T0
t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9);*/
}

