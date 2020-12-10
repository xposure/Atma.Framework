
using System;

namespace Atma
{
    /// <summary>
    /// Describes a Vertex Attribute for a Shader
    /// </summary>
    public struct VertexAttribute
    {

        /// <summary>
        /// The name of the Attribute
        /// Depending on the Graphics Implementation, this may or may not be respected
        /// </summary>
        public readonly String Name;

        /// <summary>
        /// The Vertex Attribute Type
        /// Depending on the Graphics Implementation, this may or may not be respected
        /// </summary>
        public readonly VertexAttrib Attrib;

        /// <summary>
        /// The Vertex Type of the Attribute
        /// </summary>
        public readonly VertexType Type;

        /// <summary>
        /// The number of Components
        /// </summary>
        public readonly VertexComponents Components;

        /// <summary>
        /// The size of a single Component, in bytes
        /// </summary>
        public readonly int ComponentSize;

        /// <summary>
        /// The size of the entire Attribute, in bytes
        /// </summary>
        public readonly int AttributeSize;

        /// <summary>
        /// Whether the Attribute value should be normalized
        /// </summary>
        public readonly bool Normalized;

        public this(String name, VertexAttrib attrib, VertexType type, VertexComponents components, bool normalized = false)
        {
            Name = name;
            Attrib = attrib;
            Type = type;
            Components = components;
            Normalized = normalized;

            ComponentSize = type.Size;

            AttributeSize = (int)Components * ComponentSize;
        }

    }
}

