using System;
namespace Atma.glm
{
    /// <summary>
    /// Static class that contains static glm functions
    /// </summary>
    static
    {
        
        /// <summary>
        /// Returns an array with all values
        /// </summary>
        [Inline]
        public static int[] ToArray(qint q) => q.ToArray();
        
        /// <summary>
        /// Returns the number of components (4).
        /// </summary>
        [Inline]
        public static int Count(qint q) => q.Count;
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        [Inline]
        public static bool Equals(qint q, qint rhs) => q.Equals(rhs);
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        [Inline]
        public static int GetHashCode(qint q) => q.GetHashCode();
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool4 Equal(qint lhs, qint rhs) => qint.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool4 NotEqual(qint lhs, qint rhs) => qint.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        [Inline]
        public static bool4 GreaterThan(qint lhs, qint rhs) => qint.GreaterThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        [Inline]
        public static bool4 GreaterThanEqual(qint lhs, qint rhs) => qint.GreaterThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        [Inline]
        public static bool4 LesserThan(qint lhs, qint rhs) => qint.LesserThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        [Inline]
        public static bool4 LesserThanEqual(qint lhs, qint rhs) => qint.LesserThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two quaternions.
        /// </summary>
        [Inline]
        public static int Dot(qint lhs, qint rhs) => qint.Dot(lhs, rhs);
        
        /// <summary>
        /// Returns the euclidean length of this quaternion.
        /// </summary>
        [Inline]
        public static float Length(qint q) => q.Length;
        
        /// <summary>
        /// Returns the squared euclidean length of this quaternion.
        /// </summary>
        [Inline]
        public static int LengthSqr(qint q) => q.LengthSqr;
        
        /// <summary>
        /// Returns the conjugated quaternion
        /// </summary>
        [Inline]
        public static qint Conjugate(qint q) => q.Conjugate;
        
        /// <summary>
        /// Returns the inverse quaternion
        /// </summary>
        [Inline]
        public static qint Inverse(qint q) => q.Inverse;
        
        /// <summary>
        /// Returns the cross product between two quaternions.
        /// </summary>
        [Inline]
        public static qint Cross(qint q1, qint q2) => qint.Cross(q1, q2);
        
        /// <summary>
        /// Returns a qint from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static qint Lerp(qint min, qint max, qint a) => qint.Lerp(min, max, a);

    }
}
