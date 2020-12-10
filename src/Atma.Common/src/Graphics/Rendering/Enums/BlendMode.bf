using System;

namespace Atma
{
	/// <summary>
	/// Blend Operations
	/// </summary>
	public enum BlendOperations : uint8
	{
		Add,
		Subtract,
		ReverseSubtract,
		Min,
		Max
	}

	/// <summary>
	/// Blend Factors
	/// </summary>
	public enum BlendFactors : uint8
	{
		Zero,
		One,
		SrcColor,
		OneMinusSrcColor,
		DstColor,
		OneMinusDstColor,
		SrcAlpha,
		OneMinusSrcAlpha,
		DstAlpha,
		OneMinusDstAlpha,
		ConstantColor,
		OneMinusConstantColor,
		ConstantAlpha,
		OneMinusConstantAlpha,
		SrcAlphaSaturate,
		Src1Color,
		OneMinusSrc1Color,
		Src1Alpha,
		OneMinusSrc1Alpha
	}

	public enum BlendMask : uint8
	{
		None = 0,
		Red = 1,
		Green = 2,
		Blue = 4,
		Alpha = 8,
		RGB = Red | Green | Blue,
		RGBA = Red | Green | Blue | Alpha,
	}

	/// <summary>
	/// Blend Mode
	/// </summary>
	public struct BlendMode : IHashable, IEquatable
	{
		public BlendOperations ColorOperation;
		public BlendFactors ColorSource;
		public BlendFactors ColorDestination;
		public BlendOperations AlphaOperation;
		public BlendFactors AlphaSource;
		public BlendFactors AlphaDestination;
		public BlendMask Mask;
		public Color Color;

		public this(BlendOperations operation, BlendFactors source, BlendFactors destination)
		{
			ColorOperation = AlphaOperation = operation;
			ColorSource = AlphaSource = source;
			ColorDestination = AlphaDestination = destination;
			Mask = BlendMask.RGBA;
			Color = .White;
		}

		public this(
			BlendOperations colorOperation, BlendFactors colorSource, BlendFactors colorDestination,
			BlendOperations alphaOperation, BlendFactors alphaSource, BlendFactors alphaDestination,
			BlendMask mask, Color color)
		{
			ColorOperation = colorOperation;
			ColorSource = colorSource;
			ColorDestination = colorDestination;
			AlphaOperation = alphaOperation;
			AlphaSource = alphaSource;
			AlphaDestination = alphaDestination;
			Mask = mask;
			Color = color;
		}

		public static readonly BlendMode Normal = .(BlendOperations.Add, BlendFactors.One, BlendFactors.OneMinusSrcAlpha);
		public static readonly BlendMode Add = .(BlendOperations.Add, BlendFactors.One, BlendFactors.DstAlpha);
		public static readonly BlendMode Subtract = .(BlendOperations.ReverseSubtract, BlendFactors.One, BlendFactors.One);
		public static readonly BlendMode Multiply = .(BlendOperations.Add, BlendFactors.DstColor, BlendFactors.OneMinusSrcAlpha);
		public static readonly BlendMode Screen = .(BlendOperations.Add, BlendFactors.One, BlendFactors.OneMinusSrcColor);

		public static bool operator==(BlendMode a, BlendMode b)
		{
			return
				a.ColorOperation == b.ColorOperation &&
				a.ColorSource == b.ColorSource &&
				a.ColorDestination == b.ColorDestination &&
				a.AlphaOperation == b.AlphaOperation &&
				a.AlphaSource == b.AlphaSource &&
				a.AlphaDestination == b.AlphaDestination &&
				a.Mask == b.Mask &&
				a.Color == b.Color;
		}

		public static bool operator!=(BlendMode a, BlendMode b)
		{
			return !(a == b);
		}

		public int GetHashCode()
		{
			return HashCode.Combine(
				ColorOperation,
				ColorSource,
				ColorDestination,
				AlphaOperation,
				AlphaSource,
				AlphaDestination,
				Mask,
				Color);
		}

		public bool Equals(Object val)
		{
			if (!(val is BlendMode))
				return false;

			return (this == (BlendMode)val);
		}
	}
}

