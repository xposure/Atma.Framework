
namespace Atma
{
	/// <summary>
	/// Represents the type of Data in a Vertex
	/// </summary>
	public enum VertexType
	{
		case Byte;
		case Short;
		case Int;
		case Float;

		public int Size
		{
			get
			{
				switch (this) {
				case .Byte: return 1;
				case .Short: return 2;
				case .Int: return 4;
				case .Float: return 4;
				}
			}
		}
	}
}

