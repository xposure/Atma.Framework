using System;
namespace Atma
{
	public static class CoreEvents
	{
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

		public struct GameInitialize
		{
			public override void ToString(String strBuffer)
			{
				strBuffer.Append(scope $"GameInitialize");
			}
		}

		public static GameInitialize GameInitialize() => .();
	}
}
