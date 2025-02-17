using System;

namespace Atma
{
 /// <summary>
		/// Time values
		/// </summary>
	public static class Time
	{
		/*public static uint64 FrameCounter = 0;

		/// <summary>
		/// The Target Framerate of a Fixed Timestep update
		/// </summary>
		public static int FixedStepTarget = 60;

		//public static int LostFocusFixedStepTarget = 30;

		/// <summary>
		/// The Maximum elapsed time a fixed update can take before skipping update calls
		/// </summary>
		public static TimeSpan FixedMaxElapsedTime = TimeSpan.FromMilliseconds(500);

		public static TimeSpan PreviousElapsed;

		/// <summary>
		/// The time since the start of the Application
		/// </summary>
		public static TimeSpan Elapsed;

		/// <summary>
		/// The total fixed-update duration since the start of the Application
		/// </summary>
		public static TimeSpan FixedDuration;

		/// <summary>
		/// Multiplies the Delta Time per frame by the scale value
		/// </summary>
		public static float DeltaScale = 1.0f;

		/// <summary>
		/// The Delta Time from the last frame. Fixed or Variable depending on the current Update method.
		/// Note that outside of Update Methods, this will return the last Variable Delta Time
		/// </summary>
		public static float Delta;

		/// <summary>
		/// The Delta Time from the last frame, not scaled by DeltaScale. Fixed or Variable depending on the current
		// Update method. Note that outside of Update Methods, this will return the last Raw Variable Delta Time 
		// </summary>
		public static float RawDelta;

		/// <summary>
		/// The last Fixed Delta Time.
		/// </summary>
		public static float FixedDelta;

		/// <summary>
		/// The last Fixed Delta Time, not scaled by DeltaScale
		/// </summary>
		public static float RawFixedDelta;

		/// <summary>
		/// The last Variable Delta Time.
		/// </summary>
		public static float VariableDelta;

		/// <summary>
		/// The last Variable Delta Time, not scaled by DeltaScale
		/// </summary>
		public static float RawVariableDelta;

		/// <summary>
		/// A rough estimate of the current Frames Per Second
		/// </summary>
		public static int FPS;*/



		/// <summary>
		/// Returns true when the elapsed time passes a given interval based on the delta time
		/// </summary>
		public static bool OnInterval(double time, double delta, double interval, double offset)
		{
			return Math.Floor((time - offset - delta) / interval) < Math.Floor((time - offset) / interval);
		}

		/// <summary>
		/// Returns true when the elapsed time passes a given interval based on the delta time
		/// </summary>
		public static bool OnInterval(double delta, double interval, double offset)
		{
			return OnInterval(Elapsed, delta, interval, offset);
		}

		/// <summary>
		/// Returns true when the elapsed time passes a given interval based on the delta time
		/// </summary>
		public static bool OnInterval(double interval, double offset = 0.0)
		{
			return OnInterval(Elapsed, Delta, interval, offset);
		}

		/// <summary>
		/// Returns true when the elapsed time is between the given interval. Ex: an interval of 0.1 will be false for
		// 0.1 seconds, then true for 0.1 seconds, and then repeat. </summary>
		public static bool BetweenInterval(double time, double interval, double offset)
		{
			return (time - offset) % (interval * 2) >= interval;
		}

		/// <summary>
		/// Returns true when the elapsed time is between the given interval. Ex: an interval of 0.1 will be false for
		// 0.1 seconds, then true for 0.1 seconds, and then repeat. </summary>
		public static bool BetweenInterval(double interval, double offset = 0.0)
		{
			return BetweenInterval(Elapsed, interval, offset);
		}

		public const double MicroToSeconds = 1000000.0;

		public static int64 RawPrevTime, RawTime, RawSceneTime;
		public static int64 PrevTime, Time, SceneTime;

		/*public static float TargetDelta => TargetMilliseconds / 1000f;

		public static int64 TargetMilliseconds = 1666;*/
		public static int TargetFPS = 60;

		public static int64 FixedTimestep => (.)((1.0 / TargetFPS * MicroToSeconds) * TimeScale);
		public static int64 RawFixedTimestep => (.)(1.0 / TargetFPS * MicroToSeconds);
		public static int64 InverseFixedTimestep => (.)((1.0 / TargetFPS * MicroToSeconds)  / TimeScale);
		public static int64 MaxSteps => 3;

		/// <summary>
		/// total time the game has been running
		/// </summary>
		public static double Elapsed;
		public static float Elapsedf;

		public static double PreviousElapsed;
		public static float PreviousElapsedf;

		public static double RawElapsed;
		public static float RawElapsedf;

		public static double RawPreviousElapsed;
		public static float RawPreviousElapsedf;

		/// <summary>
		/// delta time from the previous frame to the current, scaled by timeScale
		/// </summary>
		public static float Delta;
		public static float RawDelta;
		public static float AltDelta;

		/// <summary>
		/// total time since the Scene was loaded
		/// </summary>
		public static double TimeSinceSceneLoad;
		public static double RawTimeSinceSceneLoad;

		/// <summary>
		/// time scale of deltaTime
		/// </summary>
		public static float TimeScale = 1f;

		/// <summary>
		/// time scale of altDeltaTime
		/// </summary>
		public static float AltTimeScale = 1f;

		/// <summary>
		/// total number of frames that have passed
		/// </summary>

		static this()
		{
			SetTargetFramerate(60);
		}

		public static void SetTargetFramerate(int fps)
		{
			TargetFPS = fps;
		}

		//internal static float Integrate(int64 time) => (time % FixedTimestep) / (float)FixedTimestep;

		internal static void Step()
		{
			PrevTime = Time;
			Time += FixedTimestep;

			RawPrevTime = RawTime;
			RawTime += RawFixedTimestep;

			let dt = (Time - PrevTime) / MicroToSeconds;
			let rawdt = (RawTime - RawPrevTime) / MicroToSeconds;

			Delta = (.)(rawdt * TimeScale) ;
			AltDelta = (.)(rawdt * AltTimeScale);
			RawDelta = (.)rawdt;

			Elapsed = Time / MicroToSeconds;
			Elapsedf = (float)(Time / MicroToSeconds);
			PreviousElapsed = PrevTime / MicroToSeconds;
			PreviousElapsedf = (float)(PrevTime / MicroToSeconds);

			RawElapsed = RawTime / MicroToSeconds;
			RawElapsedf = (float)(RawTime / MicroToSeconds);
			RawPreviousElapsed = RawPrevTime / MicroToSeconds;
			RawPreviousElapsedf = (float)(RawPrevTime / MicroToSeconds);
		}

		internal static void SceneChanged()
		{
			SceneTime = Time;
			RawSceneTime = RawTime;
		}


		/// <summary>
		/// Allows to check in intervals. Should only be used with interval values above deltaTime,
		/// otherwise it will always return true.
		/// </summary>
		[Inline]
		public static bool CheckEvery(float interval)
		{
			// we subtract deltaTime since timeSinceSceneLoad already includes this update ticks deltaTime
			return (int)(TimeSinceSceneLoad / interval) > (int)((TimeSinceSceneLoad - Delta) / interval);
		}

		/// <summary>
		/// Allows to check in intervals. Should only be used with interval values above deltaTime,
		/// otherwise it will always return true.
		/// </summary>
		[Inline]
		public static bool CheckEvery(double interval)
		{
			// we subtract deltaTime since timeSinceSceneLoad already includes this update ticks deltaTime
			return (int)(TimeSinceSceneLoad / interval) > (int)((TimeSinceSceneLoad - Delta) / interval);
		}

	}
}

