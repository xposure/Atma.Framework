namespace Atma
{
	using System;
	using System.Collections;
	using System.Diagnostics;
	using System.Threading;
		/// <summary>
		/// You can visually find bottle necks, and basic CPU usage by using this class.
		/// 
		/// TimeRuler provide the following features:
		///  * Up to 8 bars (Configurable)
		///  * Change colors for each markers
		///  * Marker logging.
		///  * It won't even generate BeginMark/EndMark method calls when you got rid of the DEBUG constant.
		///  * It supports up to 32 (Configurable) nested BeginMark method calls.
		///  * Multithreaded safe
		///  * Automatically changes display frames based on frame duration.
		///  
		/// How to use:
		/// call timerRuler.startFrame in top of the Game.Update method. Then, surround the code that you want measure
	// by BbginMark and endMark.  timeRuler.beginMark( "Update", Color.Blue ); // process that you want to measure. 
	// timerRuler.endMark( "Update" );  Also, you can specify bar index of marker (default value is 0)  
	// timeRuler.bginMark( 1, "Update", Color.Blue ); </remarks>
	public class TimeRuler
	{
		#region Constants

		/// <summary>
		/// Max bar count.
		/// </summary>
		const int maxBars = 8;

		/// <summary>
		/// Maximum sample number for each bar.
		/// </summary>
		const int maxSamples = 256;

		/// <summary>
		/// Maximum nest calls for each bar.
		/// </summary>
		const int maxNestCall = 32;

		/// <summary>
		/// Maximum display frames.
		/// </summary>
		const int maxSampleFrames = 4;

		/// <summary>
		/// Duration (in frame count) for take snap shot of log.
		/// </summary>
		const int logSnapDuration = 120;

		/// <summary>
		/// Height(in pixels) of bar.
		/// </summary>
		const int barHeight = 8;

		/// <summary>
		/// Padding(in pixels) of bar.
		/// </summary>
		const int barPadding = 2;

		/// <summary>
		/// Delay frame count for auto display frame adjustment.
		/// </summary>
		const int autoAdjustDelay = 30;

		#endregion


		#region Properties and Fields

		/// <summary>
		/// Gets/Set log display or no.
		/// </summary>
		public bool ShowLog = false;

		/// <summary>
		/// Gets/Sets target sample frames.
		/// </summary>
		public int TargetSampleFrames;

		/// <summary>
		/// Gets/Sets timer ruler width.
		/// </summary>
		public int Width;

		public bool Enabled = true;

		//public static TimeRuler Instance;

		/// <summary>
		/// Marker structure.
		/// </summary>
		private struct Marker
		{
			public int MarkerId;
			public float BeginTime;
			public float EndTime;
			public Color Color;
		}


		/// <summary>
		/// Collection of markers.
		/// </summary>
		private struct MarkerCollection
		{
			// Marker collection.
			public Marker[maxSamples] Markers;
			public int MarkCount;

			// Marker nest information.
			public int[maxSamples] MarkerNests;
			public int NestCount;
		}


		/// <summary>
		/// Frame logging information.
		/// </summary>
		private struct FrameLog
		{
			public MarkerCollection[maxBars] Bars;
		}


		/// <summary>
		/// Marker information
		/// </summary>
		private struct MarkerInfo
		{
			// Name of marker.
			public StringView Name;

			// Marker log.
			public MarkerLog[maxBars] Logs;

		}


		/// <summary>
		/// Marker log information.
		/// </summary>
		private struct MarkerLog
		{
			public float SnapMin;
			public float SnapMax;
			public float SnapAvg;
			public float Min;
			public float Max;
			public float Avg;
			public int Samples;
			public Color Color;
			public bool Initialized;
		}

		// Logs for each frames.
		FrameLog[2] logs;

		// Previous frame log.
		FrameLog* prevLog;

		// Current log.
		FrameLog* curLog;

		// Current frame count.
		int frameCount;

		// Stopwatch for measure the time.
		Stopwatch stopwatch = new Stopwatch() ~ delete _;

		// Marker information array.
		List<MarkerInfo> markers = new List<MarkerInfo>() ~ Release(_);

		// Dictionary that maps from marker name to marker id.
		Dictionary<StringView, int> markerNameToIdMap = new Dictionary<StringView, int>() ~ Release(_);

		// Display frame adjust counter.
		int frameAdjust;

		// Current display frame count.
		int sampleFrames;

		// Marker log string.
		//StringBuilder logString = new StringBuilder(512);

		// You want to call StartFrame at beginning of Game.Update method.
		// But Game.Update gets calls multiple time when game runs slow in fixed time step mode.
		// In this case, we should ignore StartFrame call.
		// To do this, we just keep tracking of number of StartFrame calls until Draw gets called.
		int updateCount;


		// TimerRuler draw position.
		//float2 _position;

		#endregion

		Layout layout;

		#region Initialization

		public this()
		{
			// Initialize Parameters.
			sampleFrames = TargetSampleFrames = 1;

			Width = (int)(Screen.Width * 0.8f);

			Core.Emitter.AddObserver<CoreEvents.GraphicsDeviceReset>(new => OnGraphicsDeviceReset);
			OnGraphicsDeviceReset(.());
		}

		void OnGraphicsDeviceReset(CoreEvents.GraphicsDeviceReset ev)
		{
			layout = Layout(rect.FromDimensions(.Zero, Screen.Size), rect.FromDimensions(.Ones * 128, Screen.Size - .Ones * 256));
			//_position = layout.Place(float2(Width, barHeight), 0, 0.01f, Alignment.BottomCenter);
		}

		/*//[Command("timeruler", "Toggles the display of the TimerRuler on/off")]
		static void ToggleTimeRuler()
		{
			Instance.ShowLog = !Instance.ShowLog;
			DebugConsole.Instance.Log("TimeRuler enabled: " + (Instance.ShowLog ? "yes" : "no"));
			DebugConsole.Instance.IsOpen = false;
		}*/

		#endregion


		#region Measuring methods

		/// <summary>
		/// Start new frame.
		/// </summary>
		//[Conditional("DEBUG")]
		public void StartFrame()
		{
			//lock(this)
			{
				// We skip reset frame when this method gets called multiple times.
				var count = Interlocked.Increment(ref updateCount);
				if (Enabled && (1 < count && count < maxSampleFrames))
					return;

				 // Update current frame log.
				prevLog = &logs[frameCount++ & 0x1];
				curLog = &logs[frameCount & 0x1];

				var endFrameTime = (float)stopwatch.Elapsed.TotalMilliseconds;

				 // Update marker and create a log.
				for (var barIdx = 0; barIdx < prevLog.Bars.Count; ++barIdx)
				{
					var prevBar = ref prevLog.Bars[barIdx];
					var nextBar = ref curLog.Bars[barIdx];

					// Re-open marker that didn't get called EndMark in previous frame.
					for (var nest = 0; nest < prevBar.NestCount; ++nest)
					{
						var markerIdx = prevBar.MarkerNests[nest];

						prevBar.Markers[markerIdx].EndTime = endFrameTime;

						nextBar.MarkerNests[nest] = nest;
						nextBar.Markers[nest].MarkerId =
							prevBar.Markers[markerIdx].MarkerId;
						nextBar.Markers[nest].BeginTime = 0;
						nextBar.Markers[nest].EndTime = -1;
						nextBar.Markers[nest].Color = prevBar.Markers[markerIdx].Color;
					}

					// Update marker log.
					for (var markerIdx = 0; markerIdx < prevBar.MarkCount; ++markerIdx)
					{
						var duration = prevBar.Markers[markerIdx].EndTime -
							prevBar.Markers[markerIdx].BeginTime;

						int markerId = prevBar.Markers[markerIdx].MarkerId;
						var m = ref markers[markerId];

						m.Logs[barIdx].Color = prevBar.Markers[markerIdx].Color;

						if (!m.Logs[barIdx].Initialized)
						{
							// First frame process.
							m.Logs[barIdx].Min = duration;
							m.Logs[barIdx].Max = duration;
							m.Logs[barIdx].Avg = duration;

							m.Logs[barIdx].Initialized = true;
						}
						else
						{
							// Process after first frame.
							m.Logs[barIdx].Min = Math.Min(m.Logs[barIdx].Min, duration);
							m.Logs[barIdx].Max = Math.Min(m.Logs[barIdx].Max, duration);
							m.Logs[barIdx].Avg += duration;
							m.Logs[barIdx].Avg *= 0.5f;

							if (m.Logs[barIdx].Samples++ >= logSnapDuration)
							{
								m.Logs[barIdx].SnapMin = m.Logs[barIdx].Min;
								m.Logs[barIdx].SnapMax = m.Logs[barIdx].Max;
								m.Logs[barIdx].SnapAvg = m.Logs[barIdx].Avg;
								m.Logs[barIdx].Samples = 0;
							}
						}
					}

					nextBar.MarkCount = prevBar.NestCount;
					nextBar.NestCount = prevBar.NestCount;
				}

				// Start measuring.
				stopwatch.Reset();
				stopwatch.Start();
			}
		}

		/// <summary>
		/// Start measure time.
		/// </summary>
		/// <param name="markerName">name of marker.</param>
		/// <param name="color">color/param>
		//[Conditional("DEBUG")]
		public void BeginMark(StringView markerName, Color color)
		{
			BeginMark(markerName, color, 0);
		}

		/// <summary>
		/// Start measure time.
		/// </summary>
		/// <param name="barIndex">index of bar</param>
		/// <param name="markerName">name of marker.</param>
		/// <param name="color">color/param>
		//[Conditional("DEBUG")]
		public void BeginMark(StringView markerName, Color color, int barIndex)
		{
			//lock(this)
			{
				if (barIndex < 0 || barIndex >= maxBars)
					Runtime.FatalError("barIndex");

				var bar = ref curLog.Bars[barIndex];

				if (bar.MarkCount >= maxSamples)
				{
					Runtime.FatalError(
						"Exceeded sample count.\n" +
						"Either set larger number to TimeRuler.MaxSmpale or" +
						"lower sample count.");
				}

				if (bar.NestCount >= maxNestCall)
				{
					Runtime.FatalError(
						"Exceeded nest count.\n" +
						"Either set larget number to TimeRuler.MaxNestCall or" +
						"lower nest calls.");
				}

				// Gets registered marker.
				int markerId;
				if (!markerNameToIdMap.TryGetValue(markerName, out markerId))
				{
					// Register this if this marker is not registered.
					markerId = markers.Count;
					markerNameToIdMap.Add(markerName, markerId);
					markers.Add(MarkerInfo() { Name = markerName });
				}

				// Start measuring.
				bar.MarkerNests[bar.NestCount++] = bar.MarkCount;

				// Fill marker parameters.
				bar.Markers[bar.MarkCount].MarkerId = markerId;
				bar.Markers[bar.MarkCount].Color = color;
				bar.Markers[bar.MarkCount].BeginTime = (float)stopwatch.Elapsed.TotalMilliseconds;

				bar.Markers[bar.MarkCount].EndTime = -1;

				bar.MarkCount++;
			}
		}

		/// <summary>
		/// End measuring.
		/// </summary>
		/// <param name="markerName">Name of marker.</param>
		//[Conditional("DEBUG")]
		public void EndMark(StringView markerName)
		{
			EndMark(markerName, 0);
		}

		/// <summary>
		/// End measuring.
		/// </summary>
		/// <param name="barIndex">Index of bar.</param>
		/// <param name="markerName">Name of marker.</param>
		//[Conditional("DEBUG")]
		public void EndMark(StringView markerName, int barIndex)
		{
			//lock(this)
			{
				Contract.Range(barIndex, 0, maxBars);

				var bar = ref curLog.Bars[barIndex];
				if (bar.NestCount <= 0)
					Runtime.FatalError("Call beginMark method before calling endMark method.");

				int markerId;
				if (!markerNameToIdMap.TryGetValue(markerName, out markerId))
					Runtime.FatalError(scope $"Marker '{markerName}' is not registered. Make sure you specifed same name as you used for BeginMark method");

				var markerIdx = bar.MarkerNests[--bar.NestCount];
				if (bar.Markers[markerIdx].MarkerId != markerId)
				{
					Runtime.FatalError(
						"Incorrect call order of beginMark/endMark method." +
						"beginMark(A), beginMark(B), endMark(B), endMark(A)" +
						" But you can't called it like " +
						"beginMark(A), beginMark(B), endMark(A), endMark(B).");
				}

				bar.Markers[markerIdx].EndTime = (float)stopwatch.Elapsed.TotalMilliseconds;
			}
		}

		/// <summary>
		/// Get average time of given bar index and marker name.
		/// </summary>
		/// <param name="barIndex">Index of bar</param>
		/// <param name="markerName">name of marker</param>
		/// <returns>average spending time in ms.</returns>
		public float GetAverageTime(int barIndex, StringView markerName)
		{
			if (barIndex < 0 || barIndex >= maxBars)
				Exceptions.ArgumentOutOfRangeException("barIndex");

			var result = 0f;
			int markerId;
			if (markerNameToIdMap.TryGetValue(markerName, out markerId))
				result = markers[markerId].Logs[barIndex].Avg;

			return result;
		}

		/// <summary>
		/// Reset marker log.
		/// </summary>
		//[Conditional("DEBUG")]
		public void ResetLog()
		{
			//lock(this)
			{
				for (var markerInfo in markers)
				{
					for (var i = 0; i < markerInfo.Logs.Count; ++i)
					{
						markerInfo.Logs[i].Initialized = false;
						markerInfo.Logs[i].SnapMin = 0;
						markerInfo.Logs[i].SnapMax = 0;
						markerInfo.Logs[i].SnapAvg = 0;

						markerInfo.Logs[i].Min = 0;
						markerInfo.Logs[i].Max = 0;
						markerInfo.Logs[i].Avg = 0;

						markerInfo.Logs[i].Samples = 0;
					}
				}
			}
		}

		#endregion


		#region Draw

		//[Conditional("DEBUG")]
		public void Render()
		{
			let position = layout.SafeArea.TopLeft;
			let width = layout.SafeArea.Width;

			// Reset update count.
			Interlocked.Exchange(ref updateCount, 0);

			if (!ShowLog)
				return;

			// Gets Batcher, SpriteFont, and WhiteTexture from Batcher.
			var batcher = Core.Draw;
			var font = Core.DefaultFont;

			// Adjust size and position based of number of bars we should draw.
			var height = 0;
			var maxTime = 0f;
			for (var bar in prevLog.Bars)
			{
				if (bar.MarkCount > 0)
				{
					height += barHeight + barPadding * 2;
					maxTime = Math.Max(maxTime, bar.Markers[bar.MarkCount - 1].EndTime);
				}
			}

			// Auto display frame adjustment.
			// For example, if the entire process of frame doesn't finish in less than 16.6ms
			// then it will adjust display frame duration as 33.3ms.
			const float frameSpan = 1.0f / 60.0f * 1000f;
			var sampleSpan = (float)sampleFrames * frameSpan;

			if (maxTime > sampleSpan)
				frameAdjust = Math.Max(0, frameAdjust) + 1;
			else
				frameAdjust = Math.Min(0, frameAdjust) - 1;

			if (Math.Abs(frameAdjust) > autoAdjustDelay)
			{
				sampleFrames = Math.Min(maxSampleFrames, sampleFrames);
				sampleFrames = Math.Max(TargetSampleFrames, (int)(maxTime / frameSpan) + 1);

				frameAdjust = 0;
			}

			// compute factor that converts from ms to pixel.
			var msToPs = (float)width / sampleSpan;

			// Draw start position.
			var startY = (int)position.y - (height - barHeight);

			// Current y position.
			var y = startY;

			// Draw transparency background.
			var rc = rect((int)position.x, y, width, height);
			batcher.Rect(rc, Color(0, 0, 0, 128));

			// Draw markers for each bars.
			rc.Height = barHeight;
			for (var bar in prevLog.Bars)
			{
				rc.Y = y + barPadding;
				if (bar.MarkCount > 0)
				{
					for (var j = 0; j < bar.MarkCount; ++j)
					{
						var bt = bar.Markers[j].BeginTime;
						var et = bar.Markers[j].EndTime;
						var sx = (int)(position.x + bt * msToPs);
						var ex = (int)(position.x + et * msToPs);
						rc.X = sx;
						rc.Width = Math.Max(ex - sx, 1);

						batcher.Rect(rc, bar.Markers[j].Color);
					}
				}

				y += barHeight + barPadding;
			}

			// Draw grid lines.
			// Each grid represents ms.
			rc = rect((int)position.x, (int)startY, 1, height);
			for (float t = 1.0f; t < sampleSpan; t += 1.0f)
			{
				rc.X = (int)(position.x + t * msToPs);
				batcher.Rect(rc, Color.Gray);
			}

			// Draw frame grid.
			for (var i = 0; i <= sampleFrames; ++i)
			{
				rc.X = (int)(position.x + frameSpan * (float)i * msToPs);
				batcher.Rect(rc, Color.White);
			}

			// Generate log string.
			let logString = scope String();

			y = startY - font.LineSpacing;
			logString.Length = 0;
			for (var markerInfo in markers)
			{
				for (var i = 0; i < maxBars; ++i)
				{
					if (markerInfo.Logs[i].Initialized)
					{
						if (logString.Length > 0)
							logString.Append("\n");

						logString.Append(" Bar ");
						logString.Append(scope $"{i}");
						logString.Append("   [");
						logString.Append(markerInfo.Name);

						logString.Append("] Avg.:  ");
						logString.Append(scope $"{markerInfo.Logs[i].SnapAvg:0.0000}");
						logString.Append(" ms");

						y -= font.LineSpacing;
					}
				}
			}

			// Compute background size and draw it.
			var size = font.MeasureString(logString);
			rc = rect((int)position.x, (int)y, (int)size.x + 25, (int)size.y + 5);
			batcher.Rect(rc, Color(0, 0, 0, 128));

			// Draw log string.
			batcher.Text(font, float2(position.x + 22, y + 3), logString, Color.White);


			// Draw log color boxes.
			y += (int)((float)font.LineSpacing * 0.3f);
			rc = rect((int)position.x + 4, y, 10, 10);
			var rc2 = rect((int)position.x + 5, y + 1, 8, 8);
			for (var markerInfo in markers)
			{
				for (var i = 0; i < maxBars; ++i)
				{
					if (markerInfo.Logs[i].Initialized)
					{
						rc.Y = y;
						rc2.Y = y + 1;
						batcher.Rect(rc, Color.White);
						batcher.Rect(rc2, markerInfo.Logs[i].Color);

						y += font.LineSpacing;
					}
				}
			}

			Core.Draw.Render(Core.Window, Screen.Matrix);
		}

		#endregion

			/// <summary>
			/// Alignment for layout.
			/// </summary>
		//[Flags]
		public enum Alignment
		{
			None = 0,

			// Horizontal layouts
			Left = 1,
			Right = 2,
			HorizontalCenter = 4,

			// Vertical layouts
			Top = 8,
			Bottom = 16,
			VerticalCenter = 32,

			// Combinations
			TopLeft = Top | Left,
			TopRight = Top | Right,
			TopCenter = Top | HorizontalCenter,

			BottomLeft = Bottom | Left,
			BottomRight = Bottom | Right,
			BottomCenter = Bottom | HorizontalCenter,

			CenterLeft = VerticalCenter | Left,
			CenterRight = VerticalCenter | Right,
			Center = VerticalCenter | HorizontalCenter
		}


		/// <summary>
		/// Layout class that supports title safe area.
		/// </summary>
		/// <remarks>
		/// You have to support various resolutions when you develop multi-platform
		/// games. Also, you have to support title safe area for Xbox 360 games.
		/// 
		/// This structure places given rect with specified alignment and margin
		/// based on layout area (client area) with safe area.
		/// 
		/// Margin is percentage of client area size.
		/// 
		/// Example:
		/// 
		/// Place( region, 0.1f, 0.2f, Aligment.TopLeft );
		/// 
		/// Place region at 10% from left side of the client area,
		/// 20% from top of the client area.
		/// 
		/// 
		/// Place( region, 0.3f, 0.4f, Aligment.BottomRight );
		/// 
		/// Place region at 30% from right side of client,
		/// 40% from the bottom of the client area.
		/// 
		/// 
		/// You can individually specify client area and safe area.
		/// So, it is useful when you have split screen game which layout happens based
		/// on client and it takes care of the safe at same time.
		/// 
		/// </remarks>
		public struct Layout
		{
			/// <summary>
			/// Gets/Sets client area.
			/// </summary>
			public rect ClientArea;

			/// <summary>
			/// Gets/Sets safe area.
			/// </summary>
			public rect SafeArea;


			#region Initialization

			/// <summary>
			/// Construct layout object by specify both client area and safe area.
			/// </summary>
			/// <param name="client">Client area</param>
			/// <param name="safeArea">safe area</param>
			public this(rect clientArea, rect safeArea)
			{
				ClientArea = clientArea;
				SafeArea = safeArea;
			}

			/// <summary>
			/// Construct layout object by specify client area.
			/// Safe area becomes same size as client area.
			/// </summary>
			/// <param name="client">Client area</param>
			public this(rect clientArea) : this(clientArea, clientArea)
			{
				ClientArea = rect((int)clientArea.X, (int)clientArea.Y, (int)clientArea.Width, (int)clientArea.Height);
				SafeArea = ClientArea;//TODO
			}

			#endregion


			/*/// <summary>
			/// Layouting specified region
			/// </summary>
			/// <param name="region">placing region</param>
			/// <returns>Placed position</returns>
			public float2 Place(float2 size, float horizontalMargin, float verticalMargine, Alignment alignment)
			{
				var rc = rect(0, 0, (int)size.x, (int)size.y);
				rc = Place(rc, horizontalMargin, verticalMargine, alignment);
				return float2(rc.X, rc.Y);
			}*/


			/// <summary>
			/// Layouting specified region
			/// </summary>
			/// <param name="region">placing rect</param>
			/// <returns>placed rect</returns>
			public rect Place(rect region, float horizontalMargin, float verticalMargine, Alignment alignment)
			{
				var region;
				// Horizontal layout.
				if ((alignment & Alignment.Left) != 0)
				{
					region.X = ClientArea.X + (int)(ClientArea.Width * horizontalMargin);
				}
				else if ((alignment & Alignment.Right) != 0)
				{
					region.X = ClientArea.X +
						(int)(ClientArea.Width * (1.0f - horizontalMargin)) -
						region.Width;
				}
				else if ((alignment & Alignment.HorizontalCenter) != 0)
				{
					region.X = ClientArea.X + (ClientArea.Width - region.Width) / 2 +
						(int)(horizontalMargin * ClientArea.Width);
				}
				else
				{
					// Don't do layout.
				}

				// Vertical layout.
				if ((alignment & Alignment.Top) != 0)
				{
					region.Y = ClientArea.Y + (int)(ClientArea.Height * verticalMargine);
				}
				else if ((alignment & Alignment.Bottom) != 0)
				{
					region.Y = ClientArea.Y +
						(int)(ClientArea.Height * (1.0f - verticalMargine)) -
						region.Height;
				}
				else if ((alignment & Alignment.VerticalCenter) != 0)
				{
					region.Y = ClientArea.Y + (ClientArea.Height - region.Height) / 2 +
						(int)(verticalMargine * ClientArea.Height);
				}
				else
				{
					// Don't do layout.
				}

				// Make sure layout region is in the safe area.
				if (region.Left < SafeArea.Left)
					region.X = SafeArea.Left;

				if (region.Right > SafeArea.Right)
					region.X = SafeArea.Right - region.Width;

				if (region.Top < SafeArea.Top)
					region.Y = SafeArea.Top;

				if (region.Bottom > SafeArea.Bottom)
					region.Y = SafeArea.Bottom - region.Height;

				return region;
			}
		}
	}
}
