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
        public static double[,] ToArray(double3x3 m) => m.ToArray();
        
        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        [Inline]
        public static double[] ToArray1D(double3x3 m) => m.ToArray1D();
        
        /// <summary>
        /// Creates a quaternion from the rotational part of this matrix.
        /// </summary>
        [Inline]
        public static qdouble ToQuaternion(double3x3 m) => m.ToQuaternion;

    }
}
