namespace Atma
{
	using System;

	/// <summary>
	/// A Shader Uniform Value
	/// </summary>
	public struct ShaderUniform
	{
		/// <summary>
		/// The Name of the Uniform
		/// </summary>
		public readonly String Name;

		/// <summary>
		/// The Location of the Uniform in the Shader
		/// </summary>
		public readonly int Location;

		/// <summary>
		/// The Array length of the uniform
		/// </summary>
		public readonly int Length;

		/// <summary>
		/// The Type of Uniform
		/// </summary>
		public readonly UniformType Type;

		/// <summary>
		/// The total length of the data for this uniform (typesize * length)
		/// </summary>
		public int Size => Type.Size(Length);

		public this(String name, int location, int length, UniformType type)
		{
			Name = name;
			Location = location;
			Length = length;
			Type = type;
		}

		public override void ToString(String buffer)
		{
			buffer.AppendF("{{ Name: {0}, Location: {1}, Length: {2}, Type: {3}, Size: {4} }}", Name, Location, Length, Type, Size);
		}
	}
}

