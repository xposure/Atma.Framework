namespace Atma
{
	using System;

	/// <summary>
	/// A Shader Attribute
	/// </summary>
	public struct ShaderAttribute
	{
		/// <summary>
		/// The name of the Attribute
		/// </summary>
		public readonly String Name;

		/// <summary>
		/// The Location of the Attribute in the Shader
		/// </summary>
		public readonly uint Location;

		public this(String name, uint location)
		{
			Name = name;
			Location = location;
		}

		public override void ToString(String buffer)
		{
			buffer.AppendF("{{ Name: {0}, Location: {1} }}", Name, Location);
		}
	}
}
