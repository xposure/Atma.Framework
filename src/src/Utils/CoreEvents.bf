using System;
namespace Atma
{
	public static class CoreEvents
	{
		public struct Initialize
		{
			public override void ToString(String strBuffer)
			{
				strBuffer.Append(scope $"Initialize");
			}
		}

		public static Initialize Initialize() => .();

		public struct Shutdown
		{
			public override void ToString(String strBuffer)
			{
				strBuffer.Append(scope $"Shutdown");
			}
		}

		public static Shutdown Shutdown() => .();

		public struct FrameBegin
		{
			public override void ToString(String strBuffer)
			{
				strBuffer.Append(scope $"FrameBegin");
			}
		}

		public static FrameBegin FrameBegin() => .();

		public struct FrameEnd
		{
			public override void ToString(String strBuffer)
			{
				strBuffer.Append(scope $"FrameEnd");
			}
		}

		public static FrameEnd FrameEnd() => .();

		public struct UpdateBegin
		{
			public override void ToString(String strBuffer)
			{
				strBuffer.Append(scope $"UpdateBegin");
			}
		}

		public static UpdateBegin UpdateBegin() => .();

		public struct UpdateEnd
		{
			public override void ToString(String strBuffer)
			{
				strBuffer.Append(scope $"UpdateEnd");
			}
		}

		public static UpdateEnd UpdateEnd() => .();

		public struct RenderBegin
		{
			public override void ToString(String strBuffer)
			{
				strBuffer.Append(scope $"RenderBegin");
			}
		}

		public static RenderBegin RenderBegin() => .();

		public struct RenderEnd
		{
			public override void ToString(String strBuffer)
			{
				strBuffer.Append(scope $"RenderEnd");
			}
		}

		public static RenderEnd RenderEnd() => .();

		public struct IntegrateBegin
		{
			public override void ToString(String strBuffer)
			{
				strBuffer.Append(scope $"IntegrateBegin");
			}
		}

		public static IntegrateBegin IntegrateBegin() => .();

		public struct IntegrateEnd
		{
			public override void ToString(String strBuffer)
			{
				strBuffer.Append(scope $"IntegrateEnd");
			}
		}

		public static IntegrateEnd IntegrateEnd() => .();

		public struct Present
		{
			public override void ToString(String strBuffer)
			{
				strBuffer.Append(scope $"Present");
			}
		}

		public static Present Present() => .();

		public struct OrientationChanged
		{
			public enum Orientation
			{
				case Vertical;
				case Horizontal;
			}
			public readonly Orientation Orientation;
			public this(Orientation orientation)
			{
				Orientation = orientation;
			}

			public override void ToString(String strBuffer)
			{
				strBuffer.Append(scope $"OrientationChanged [{Orientation}]");
			}
		}

		public static OrientationChanged OrientationChanged(OrientationChanged.Orientation orientation) => .(orientation);

		public struct GraphicsDeviceReset
		{
			public override void ToString(String strBuffer)
			{
				strBuffer.Append("GraphicsDeviceReset");
			}
		}

		public static GraphicsDeviceReset GraphicsDeviceReset() => .();

		public struct WindowResize
		{
			public readonly int Width;
			public readonly int Height;

			public this(int width, int height)
			{
				Width = width;
				Height = height;
			}

			public override void ToString(String strBuffer)
			{
				strBuffer.Append(scope $"WindowResize [ Width: {Width}, Height: {Height} ]");
			}
		}

		public static WindowResize WindowResize(int width, int height) => .(width, height);

		public struct WindowFocus
		{
			public readonly bool Focused;

			public this(bool focused)
			{
				Focused = focused;
			}

			public override void ToString(String strBuffer)
			{
				strBuffer.Append(scope $"WindowFocus [ Focused: {Focused} ]");
			}
		}

		public static WindowFocus WindowFocus(bool focused) => .(focused);

		public struct WindowClose
		{
			public override void ToString(String strBuffer)
			{
				strBuffer.Append(scope $"WindowClose");
			}
		}

		public static WindowClose WindowClose() => .();


		public struct AssetChanged
		{
			public readonly StringView Path;

			public this(StringView path)
			{
				Path = path;
			}

			public override void ToString(String strBuffer)
			{
				strBuffer.Append(scope $"AssetChanged [{Path}]");
			}
		}

		public static AssetChanged AssetChanged(StringView path) => .(path);

	}
}
