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
        public static float[] ToArray(qfloat q) => q.ToArray();
        
        /// <summary>
        /// Returns the number of components (4).
        /// </summary>
        [Inline]
        public static int Count(qfloat q) => q.Count;
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        [Inline]
        public static bool Equals(qfloat q, qfloat rhs) => q.Equals(rhs);
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        [Inline]
        public static int GetHashCode(qfloat q) => q.GetHashCode();
        
        /// <summary>
        /// Returns a bool4 from component-wise application of IsInfinity (v.IsInfinity).
        /// </summary>
        [Inline]
        public static bool4 IsInfinity(qfloat v) => qfloat.IsInfinity(v);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of IsFinite (v.IsFinite).
        /// </summary>
        [Inline]
        public static bool4 IsFinite(qfloat v) => qfloat.IsFinite(v);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of IsNaN (v.IsNaN).
        /// </summary>
        [Inline]
        public static bool4 IsNaN(qfloat v) => qfloat.IsNaN(v);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of IsNegativeInfinity (v.IsNegativeInfinity).
        /// </summary>
        [Inline]
        public static bool4 IsNegativeInfinity(qfloat v) => qfloat.IsNegativeInfinity(v);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of IsPositiveInfinity (v.IsPositiveInfinity).
        /// </summary>
        [Inline]
        public static bool4 IsPositiveInfinity(qfloat v) => qfloat.IsPositiveInfinity(v);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool4 Equal(qfloat lhs, qfloat rhs) => qfloat.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool4 NotEqual(qfloat lhs, qfloat rhs) => qfloat.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        [Inline]
        public static bool4 GreaterThan(qfloat lhs, qfloat rhs) => qfloat.GreaterThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        [Inline]
        public static bool4 GreaterThanEqual(qfloat lhs, qfloat rhs) => qfloat.GreaterThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        [Inline]
        public static bool4 LesserThan(qfloat lhs, qfloat rhs) => qfloat.LesserThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        [Inline]
        public static bool4 LesserThanEqual(qfloat lhs, qfloat rhs) => qfloat.LesserThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two quaternions.
        /// </summary>
        [Inline]
        public static float Dot(qfloat lhs, qfloat rhs) => qfloat.Dot(lhs, rhs);
        
        /// <summary>
        /// Returns the euclidean length of this quaternion.
        /// </summary>
        [Inline]
        public static float Length(qfloat q) => q.Length;
        
        /// <summary>
        /// Returns the squared euclidean length of this quaternion.
        /// </summary>
        [Inline]
        public static float LengthSqr(qfloat q) => q.LengthSqr;
        
        /// <summary>
        /// Returns a copy of this quaternion with length one (undefined if this has zero length).
        /// </summary>
        [Inline]
        public static qfloat Normalized(qfloat q) => q.Normalized;
        
        /// <summary>
        /// Returns a copy of this quaternion with length one (returns zero if length is zero).
        /// </summary>
        [Inline]
        public static qfloat NormalizedSafe(qfloat q) => q.NormalizedSafe;
        
        /// <summary>
        /// Returns the represented angle of this quaternion.
        /// </summary>
        [Inline]
        public static double Angle(qfloat q) => q.Angle;
        
        /// <summary>
        /// Returns the represented axis of this quaternion.
        /// </summary>
        [Inline]
        public static float3 Axis(qfloat q) => q.Axis;
        
        /// <summary>
        /// Returns the represented yaw angle of this quaternion.
        /// </summary>
        [Inline]
        public static double Yaw(qfloat q) => q.Yaw;
        
        /// <summary>
        /// Returns the represented pitch angle of this quaternion.
        /// </summary>
        [Inline]
        public static double Pitch(qfloat q) => q.Pitch;
        
        /// <summary>
        /// Returns the represented roll angle of this quaternion.
        /// </summary>
        [Inline]
        public static double Roll(qfloat q) => q.Roll;
        
        /// <summary>
        /// Returns the represented euler angles (pitch, yaw, roll) of this quaternion.
        /// </summary>
        [Inline]
        public static double3 EulerAngles(qfloat q) => q.EulerAngles;
        
        /// <summary>
        /// Rotates this quaternion from an axis and an angle (in radians).
        /// </summary>
        [Inline]
        public static qfloat Rotated(qfloat q, float angle, float3 v) => q.Rotated(angle, v);
        
        /// <summary>
        /// Creates a float3x3 that realizes the rotation of this quaternion
        /// </summary>
        [Inline]
        public static float3x3 ToMat3(qfloat q) => q.ToMat3;
        
        /// <summary>
        /// Creates a float4x4 that realizes the rotation of this quaternion
        /// </summary>
        [Inline]
        public static float4x4 ToMat4(qfloat q) => q.ToMat4;
        
        /// <summary>
        /// Returns the conjugated quaternion
        /// </summary>
        [Inline]
        public static qfloat Conjugate(qfloat q) => q.Conjugate;
        
        /// <summary>
        /// Returns the inverse quaternion
        /// </summary>
        [Inline]
        public static qfloat Inverse(qfloat q) => q.Inverse;
        
        /// <summary>
        /// Returns the cross product between two quaternions.
        /// </summary>
        [Inline]
        public static qfloat Cross(qfloat q1, qfloat q2) => qfloat.Cross(q1, q2);
        
        /// <summary>
        /// Calculates a proper spherical interpolation between two quaternions (only works for normalized quaternions).
        /// </summary>
        [Inline]
        public static qfloat Mix(qfloat x, qfloat y, float a) => qfloat.Mix(x, y, a);
        
        /// <summary>
        /// Calculates a proper spherical interpolation between two quaternions (only works for normalized quaternions).
        /// </summary>
        [Inline]
        public static qfloat SLerp(qfloat x, qfloat y, float a) => qfloat.SLerp(x, y, a);
        
        /// <summary>
        /// Applies squad interpolation of these quaternions
        /// </summary>
        [Inline]
        public static qfloat Squad(qfloat q1, qfloat q2, qfloat s1, qfloat s2, float h) => qfloat.Squad(q1, q2, s1, s2, h);
        
        /// <summary>
        /// Returns a qfloat from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static qfloat Lerp(qfloat min, qfloat max, qfloat a) => qfloat.Lerp(min, max, a);

    }
}
