namespace Atma
{
	using System;

	/// <summary>
	/// Texture Format
	/// </summary>
	public enum TextureFormat
	{
		/*/// <summary>
		/// No Texture Format
		/// </summary>
		case None;*/

		/// <summary>
		/// Single 8-bit component stored in the Red channel
		/// </summary>
		case Red;

		/// <summary>
		/// Two 8-bit components stored in the Red, Green channels
		/// </summary>
		case RG;

		/// <summary>
		/// Three 8-bit components stored in the Red, Green, Blue channels
		/// </summary>
		case RGB;

		/// <summary>
		/// Three 16-bit components stored in the Red, Green, Blue, Alpha channels
		/// </summary>
		case RGBA16F;

		/// <summary>
		/// ARGB uint32 Color
		/// </summary>
		case Color;

		/// <summary>
		/// Depth 24-bit Stencil 8-bit
		/// </summary>
		case DepthStencil;

		public int ElementSize
		{
			get
			{
				switch (this) {
				case .RGBA16F: return sizeof(float);
				case .Color: return sizeof(char8);
				case .Red: return sizeof(char8);
				case .RG: return sizeof(char8);
				case .RGB: return sizeof(char8);
				case .DepthStencil: return sizeof(float);
				/*case .None:
					Runtime.FatalError("Invalid Texture Format");*/
				}
			}
		}


		public int ElementCount
		{
			get
			{
				switch (this) {
				case .RGBA16F: return 4;
				case .Color: return 4;
				case .Red: return 1;
				case .RG: return 2;
				case .RGB: return 3;
				case .DepthStencil: return 1;
				/*case .None:
					Runtime.FatalError("Invalid Texture Format");*/
				}
			}
		}

		public int Size => ElementSize * ElementCount

		public bool IsTextureColorFormat
		{
			get => this != .DepthStencil;
		}

		public bool IsDepthStencilFormat
		{
			get => this == .DepthStencil;
		}
	}
}

