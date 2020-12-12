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
        public static long[] ToArray(qlong q) => q.ToArray();
        
        /// <summary>
        /// Returns the number of components (4).
        /// </summary>
        [Inline]
        public static int Count(qlong q) => q.Count;
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        [Inline]
        public static bool Equals(qlong q, qlong rhs) => q.Equals(rhs);
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        [Inline]
        public static int GetHashCode(qlong q) => q.GetHashCode();
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool4 Equal(qlong lhs, qlong rhs) => qlong.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool4 NotEqual(qlong lhs, qlong rhs) => qlong.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        [Inline]
        public static bool4 GreaterThan(qlong lhs, qlong rhs) => qlong.GreaterThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        [Inline]
        public static bool4 GreaterThanEqual(qlong lhs, qlong rhs) => qlong.GreaterThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        [Inline]
        public static bool4 LesserThan(qlong lhs, qlong rhs) => qlong.LesserThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        [Inline]
        public static bool4 LesserThanEqual(qlong lhs, qlong rhs) => qlong.LesserThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two quaternions.
        /// </summary>
        [Inline]
        public static long Dot(qlong lhs, qlong rhs) => qlong.Dot(lhs, rhs);
        
        /// <summary>
        /// Returns the euclidean length of this quaternion.
        /// </summary>
        [Inline]
        public static double Length(qlong q) => q.Length;
        
        /// <summary>
        /// Returns the squared euclidean length of this quaternion.
        /// </summary>
        [Inline]
        public static long LengthSqr(qlong q) => q.LengthSqr;
        
        /// <summary>
        /// Returns the conjugated quaternion
        /// </summary>
        [Inline]
        public static qlong Conjugate(qlong q) => q.Conjugate;
        
        /// <summary>
        /// Returns the inverse quaternion
        /// </summary>
        [Inline]
        public static qlong Inverse(qlong q) => q.Inverse;
        
        /// <summary>
        /// Returns the cross product between two quaternions.
        /// </summary>
        [Inline]
        public static qlong Cross(qlong q1, qlong q2) => qlong.Cross(q1, q2);
        
        /// <summary>
        /// Returns a qlong from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static qlong Lerp(qlong min, qlong max, qlong a) => qlong.Lerp(min, max, a);

    }
}
