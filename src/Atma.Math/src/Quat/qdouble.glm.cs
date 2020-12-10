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
        public static double[] ToArray(qdouble q) => q.ToArray();
        
        /// <summary>
        /// Returns the number of components (4).
        /// </summary>
        [Inline]
        public static int Count(qdouble q) => q.Count;
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        [Inline]
        public static bool Equals(qdouble q, qdouble rhs) => q.Equals(rhs);
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        [Inline]
        public static int GetHashCode(qdouble q) => q.GetHashCode();
        
        /// <summary>
        /// Returns a bool4 from component-wise application of IsInfinity (v.IsInfinity).
        /// </summary>
        [Inline]
        public static bool4 IsInfinity(qdouble v) => qdouble.IsInfinity(v);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of IsNaN (v.IsNaN).
        /// </summary>
        [Inline]
        public static bool4 IsNaN(qdouble v) => qdouble.IsNaN(v);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of IsNegativeInfinity (v.IsNegativeInfinity).
        /// </summary>
        [Inline]
        public static bool4 IsNegativeInfinity(qdouble v) => qdouble.IsNegativeInfinity(v);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of IsPositiveInfinity (v.IsPositiveInfinity).
        /// </summary>
        [Inline]
        public static bool4 IsPositiveInfinity(qdouble v) => qdouble.IsPositiveInfinity(v);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool4 Equal(qdouble lhs, qdouble rhs) => qdouble.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool4 NotEqual(qdouble lhs, qdouble rhs) => qdouble.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        [Inline]
        public static bool4 GreaterThan(qdouble lhs, qdouble rhs) => qdouble.GreaterThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        [Inline]
        public static bool4 GreaterThanEqual(qdouble lhs, qdouble rhs) => qdouble.GreaterThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        [Inline]
        public static bool4 LesserThan(qdouble lhs, qdouble rhs) => qdouble.LesserThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        [Inline]
        public static bool4 LesserThanEqual(qdouble lhs, qdouble rhs) => qdouble.LesserThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two quaternions.
        /// </summary>
        [Inline]
        public static double Dot(qdouble lhs, qdouble rhs) => qdouble.Dot(lhs, rhs);
        
        /// <summary>
        /// Returns the euclidean length of this quaternion.
        /// </summary>
        [Inline]
        public static double Length(qdouble q) => q.Length;
        
        /// <summary>
        /// Returns the squared euclidean length of this quaternion.
        /// </summary>
        [Inline]
        public static double LengthSqr(qdouble q) => q.LengthSqr;
        
        /// <summary>
        /// Returns a copy of this quaternion with length one (undefined if this has zero length).
        /// </summary>
        [Inline]
        public static qdouble Normalized(qdouble q) => q.Normalized;
        
        /// <summary>
        /// Returns a copy of this quaternion with length one (returns zero if length is zero).
        /// </summary>
        [Inline]
        public static qdouble NormalizedSafe(qdouble q) => q.NormalizedSafe;
        
        /// <summary>
        /// Returns the represented angle of this quaternion.
        /// </summary>
        [Inline]
        public static double Angle(qdouble q) => q.Angle;
        
        /// <summary>
        /// Returns the represented axis of this quaternion.
        /// </summary>
        [Inline]
        public static double3 Axis(qdouble q) => q.Axis;
        
        /// <summary>
        /// Returns the represented yaw angle of this quaternion.
        /// </summary>
        [Inline]
        public static double Yaw(qdouble q) => q.Yaw;
        
        /// <summary>
        /// Returns the represented pitch angle of this quaternion.
        /// </summary>
        [Inline]
        public static double Pitch(qdouble q) => q.Pitch;
        
        /// <summary>
        /// Returns the represented roll angle of this quaternion.
        /// </summary>
        [Inline]
        public static double Roll(qdouble q) => q.Roll;
        
        /// <summary>
        /// Returns the represented euler angles (pitch, yaw, roll) of this quaternion.
        /// </summary>
        [Inline]
        public static double3 EulerAngles(qdouble q) => q.EulerAngles;
        
        /// <summary>
        /// Rotates this quaternion from an axis and an angle (in radians).
        /// </summary>
        [Inline]
        public static qdouble Rotated(qdouble q, double angle, double3 v) => q.Rotated(angle, v);
        
        /// <summary>
        /// Creates a double3x3 that realizes the rotation of this quaternion
        /// </summary>
        [Inline]
        public static double3x3 ToMat3(qdouble q) => q.ToMat3;
        
        /// <summary>
        /// Creates a double4x4 that realizes the rotation of this quaternion
        /// </summary>
        [Inline]
        public static double4x4 ToMat4(qdouble q) => q.ToMat4;
        
        /// <summary>
        /// Returns the conjugated quaternion
        /// </summary>
        [Inline]
        public static qdouble Conjugate(qdouble q) => q.Conjugate;
        
        /// <summary>
        /// Returns the inverse quaternion
        /// </summary>
        [Inline]
        public static qdouble Inverse(qdouble q) => q.Inverse;
        
        /// <summary>
        /// Returns the cross product between two quaternions.
        /// </summary>
        [Inline]
        public static qdouble Cross(qdouble q1, qdouble q2) => qdouble.Cross(q1, q2);
        
        /// <summary>
        /// Calculates a proper spherical interpolation between two quaternions (only works for normalized quaternions).
        /// </summary>
        [Inline]
        public static qdouble Mix(qdouble x, qdouble y, double a) => qdouble.Mix(x, y, a);
        
        /// <summary>
        /// Calculates a proper spherical interpolation between two quaternions (only works for normalized quaternions).
        /// </summary>
        [Inline]
        public static qdouble SLerp(qdouble x, qdouble y, double a) => qdouble.SLerp(x, y, a);
        
        /// <summary>
        /// Applies squad interpolation of these quaternions
        /// </summary>
        [Inline]
        public static qdouble Squad(qdouble q1, qdouble q2, qdouble s1, qdouble s2, double h) => qdouble.Squad(q1, q2, s1, s2, h);
        
        /// <summary>
        /// Returns a qdouble from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static qdouble Lerp(qdouble min, qdouble max, qdouble a) => qdouble.Lerp(min, max, a);

    }
}
