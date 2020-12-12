namespace Atma
{
	using System;

	public enum UniformType
	{
		case Unknown;
		case Int;
		case Float;
		case Float2;
		case Float3;
		case Float4;
		case Matrix3x2;
		case Matrix4x4;
		case Sampler;

		public bool IsFloat
		{
			get
			{
				switch (this) {
				case Float: fallthrough;
				case Float2: fallthrough;
				case Float3: fallthrough;
				case Float4: fallthrough;
				case Matrix3x2: fallthrough;
				case Matrix4x4: return true;
				default:
				}
				return false;
			}
		}

		public int Elements
		{
			get
			{
				switch (this) {
				case Int: return 1;
				case Float: return 1;
				case Float2: return 2;
				case Float3: return 3;
				case Float4: return 4;
				case Matrix3x2: return 3 * 2;
				case Matrix4x4: return 4 * 4;
				default:
					Runtime.Assert(false, "Unsupported type");
				}

				return 0;
			}
		}

		public int Size(int length = 1)
		{
			switch (this) {
			case Int: return sizeof(int32) * length;
			case Float: return sizeof(float) * length;
			case Float2: return sizeof(float) * 2 * length;
			case Float3: return sizeof(float) * 3 * length;
			case Float4: return sizeof(float) * 4 * length;
			case Matrix3x2: return sizeof(float) * 3 * 2 * length;
			case Matrix4x4: return sizeof(float) * 4 * 4 * length;
			case Sampler: return 0;
			default:
				Runtime.Assert(false, "Unsupported type");
			}
			return 0;
		}
	}
}

