
using System;
namespace Atma
{
    /// <summary>
    /// Describes a Vertex Format for a Shader
    /// This tells the Shader what Attributes, and in what order, are to be expected
    /// </summary>
    public class VertexFormat
    {

        /// <summary>
        /// The list of Attributes
        /// </summary>
        public readonly VertexAttribute[] Attributes ~ delete _;

        /// <summary>
        /// The stride of each Vertex (all the Attributes combined)
        /// </summary>
        public readonly int Stride;

        public this(params VertexAttribute[] attributes)
        {
			Attributes = new VertexAttribute[attributes.Count];
			attributes.CopyTo(Attributes);

            Stride = 0;
            for (var i < Attributes.Count)
                Stride += Attributes[i].AttributeSize;
        }

        /// <summary>
        /// Attempts to find an attribute by name, and returns its relative pointer (offset)
        /// </summary>
        public bool TryGetAttribute(String name, out VertexAttribute element, out int pointer)
        {
            pointer = 0;
			for (var i < Attributes.Count)
            {
                if (Attributes[i].Name == name)
                {
                    element = Attributes[i];
                    return true;
                }
                pointer += Attributes[i].AttributeSize;
            }

            element = default;
            return false;
        }

    }
}

