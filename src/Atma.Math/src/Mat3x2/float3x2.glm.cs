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
        public static float[,] ToArray(float3x2 m) => m.ToArray();
        
        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        [Inline]
        public static float[] ToArray1D(float3x2 m) => m.ToArray1D();

    }
}
