using System;
namespace Atma.glm
{
    /// <summary>
    /// Static class that contains static glm functions
    /// </summary>
    static
    {
        
        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        [Inline]
        public static uint[,] ToArray(uint3x2 m) => m.ToArray();
        
        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        [Inline]
        public static uint[] ToArray1D(uint3x2 m) => m.ToArray1D();

    }
}
