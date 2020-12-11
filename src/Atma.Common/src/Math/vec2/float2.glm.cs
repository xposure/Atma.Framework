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
        public static float[] ToArray(float2 v) => v.ToArray();
        
        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        [Inline]
        public static void ToString(float2 v, String stringBuffer) => v.ToString(stringBuffer);
        
        /// <summary>
        /// Returns a string representation of this vector using a provided seperator.
        /// </summary>
        [Inline]
        public static void ToString(float2 v, String stringBuffer, String sep) => v.ToString(stringBuffer, sep);
        
        /// <summary>
        /// Returns the number of components (2).
        /// </summary>
        [Inline]
        public static int Count(float2 v) => v.Count;
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        [Inline]
        public static int GetHashCode(float2 v) => v.GetHashCode();
        
        /// <summary>
        /// Returns true iff distance between lhs and rhs is less than or equal to epsilon
        /// </summary>
        [Inline]
        public static bool ApproxEqual(float2 lhs, float2 rhs, float eps = 0.1f) => float2.ApproxEqual(lhs, rhs, eps);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool2 Equal(float2 lhs, float2 rhs) => float2.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool2 NotEqual(float2 lhs, float2 rhs) => float2.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        [Inline]
        public static bool2 GreaterThan(float2 lhs, float2 rhs) => float2.GreaterThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        [Inline]
        public static bool2 GreaterThanEqual(float2 lhs, float2 rhs) => float2.GreaterThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        [Inline]
        public static bool2 LesserThan(float2 lhs, float2 rhs) => float2.LesserThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        [Inline]
        public static bool2 LesserThanEqual(float2 lhs, float2 rhs) => float2.LesserThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of IsInfinity (v.IsInfinity).
        /// </summary>
        [Inline]
        public static bool2 IsInfinity(float2 v) => float2.IsInfinity(v);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of IsFinite (v.IsFinite).
        /// </summary>
        [Inline]
        public static bool2 IsFinite(float2 v) => float2.IsFinite(v);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of IsNaN (v.IsNaN).
        /// </summary>
        [Inline]
        public static bool2 IsNaN(float2 v) => float2.IsNaN(v);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of IsNegativeInfinity (v.IsNegativeInfinity).
        /// </summary>
        [Inline]
        public static bool2 IsNegativeInfinity(float2 v) => float2.IsNegativeInfinity(v);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of IsPositiveInfinity (v.IsPositiveInfinity).
        /// </summary>
        [Inline]
        public static bool2 IsPositiveInfinity(float2 v) => float2.IsPositiveInfinity(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Abs (System.Math.Abs(v)).
        /// </summary>
        [Inline]
        public static float2 Abs(float2 v) => float2.Abs(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        [Inline]
        public static float2 HermiteInterpolationOrder3(float2 v) => float2.HermiteInterpolationOrder3(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        [Inline]
        public static float2 HermiteInterpolationOrder5(float2 v) => float2.HermiteInterpolationOrder5(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Sqr (v * v).
        /// </summary>
        [Inline]
        public static float2 Sqr(float2 v) => float2.Sqr(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Pow2 (v * v).
        /// </summary>
        [Inline]
        public static float2 Pow2(float2 v) => float2.Pow2(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        [Inline]
        public static float2 Pow3(float2 v) => float2.Pow3(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Step (v &gt;= 0f ? 1f : 0f).
        /// </summary>
        [Inline]
        public static float2 Step(float2 v) => float2.Step(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Sqrt ((float)System.Math.Sqrt((double)v)).
        /// </summary>
        [Inline]
        public static float2 Sqrt(float2 v) => float2.Sqrt(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of InverseSqrt ((float)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        [Inline]
        public static float2 InverseSqrt(float2 v) => float2.InverseSqrt(v);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Sign (System.Math.Sign(v)).
        /// </summary>
        [Inline]
        public static int2 Sign(float2 v) => float2.Sign(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        [Inline]
        public static float2 Max(float2 lhs, float2 rhs) => float2.Max(lhs, rhs);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        [Inline]
        public static float2 Min(float2 lhs, float2 rhs) => float2.Min(lhs, rhs);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Pow ((float)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static float2 Pow(float2 lhs, float2 rhs) => float2.Pow(lhs, rhs);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Log ((float)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static float2 Log(float2 lhs, float2 rhs) => float2.Log(lhs, rhs);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        [Inline]
        public static float2 Clamp(float2 v, float2 min, float2 max) => float2.Clamp(v, min, max);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static float2 Mix(float2 min, float2 max, float2 a) => float2.Mix(min, max, a);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static float2 Lerp(float2 min, float2 max, float2 a) => float2.Lerp(min, max, a);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Fma (a * b + c).
        /// </summary>
        [Inline]
        public static float2 Fma(float2 a, float2 b, float2 c) => float2.Fma(a, b, c);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static float2x2 OuterProduct(float2 c, float2 r) => float2.OuterProduct(c, r);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static float3x2 OuterProduct(float2 c, float3 r) => float2.OuterProduct(c, r);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static float4x2 OuterProduct(float2 c, float4 r) => float2.OuterProduct(c, r);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Add (lhs + rhs).
        /// </summary>
        [Inline]
        public static float2 Add(float2 lhs, float2 rhs) => float2.Add(lhs, rhs);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        [Inline]
        public static float2 Sub(float2 lhs, float2 rhs) => float2.Sub(lhs, rhs);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        [Inline]
        public static float2 Mul(float2 lhs, float2 rhs) => float2.Mul(lhs, rhs);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Div (lhs / rhs).
        /// </summary>
        [Inline]
        public static float2 Div(float2 lhs, float2 rhs) => float2.Div(lhs, rhs);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        [Inline]
        public static float2 Modulo(float2 lhs, float2 rhs) => float2.Modulo(lhs, rhs);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Degrees (Radians-To-Degrees Conversion).
        /// </summary>
        [Inline]
        public static float2 Degrees(float2 v) => float2.Degrees(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Radians (Degrees-To-Radians Conversion).
        /// </summary>
        [Inline]
        public static float2 Radians(float2 v) => float2.Radians(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Acos (System.Math.Acos(v)).
        /// </summary>
        [Inline]
        public static float2 Acos(float2 v) => float2.Acos(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Asin (System.Math.Asin(v)).
        /// </summary>
        [Inline]
        public static float2 Asin(float2 v) => float2.Asin(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Atan (System.Math.Atan(v)).
        /// </summary>
        [Inline]
        public static float2 Atan(float2 v) => float2.Atan(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Cos (System.Math.Cos(v)).
        /// </summary>
        [Inline]
        public static float2 Cos(float2 v) => float2.Cos(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Cosh (System.Math.Cosh(v)).
        /// </summary>
        [Inline]
        public static float2 Cosh(float2 v) => float2.Cosh(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Exp (System.Math.Exp(v)).
        /// </summary>
        [Inline]
        public static float2 Exp(float2 v) => float2.Exp(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Log (System.Math.Log(v)).
        /// </summary>
        [Inline]
        public static float2 Log(float2 v) => float2.Log(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Log2 (System.Math.Log(v, 2)).
        /// </summary>
        [Inline]
        public static float2 Log2(float2 v) => float2.Log2(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Log10 (System.Math.Log10(v)).
        /// </summary>
        [Inline]
        public static float2 Log10(float2 v) => float2.Log10(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Floor (System.Math.Floor(v)).
        /// </summary>
        [Inline]
        public static float2 Floor(float2 v) => float2.Floor(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Ceiling (System.Math.Ceiling(v)).
        /// </summary>
        [Inline]
        public static float2 Ceiling(float2 v) => float2.Ceiling(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Round (System.Math.Round(v)).
        /// </summary>
        [Inline]
        public static float2 Round(float2 v) => float2.Round(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Sin (System.Math.Sin(v)).
        /// </summary>
        [Inline]
        public static float2 Sin(float2 v) => float2.Sin(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Sinh (System.Math.Sinh(v)).
        /// </summary>
        [Inline]
        public static float2 Sinh(float2 v) => float2.Sinh(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Tan (System.Math.Tan(v)).
        /// </summary>
        [Inline]
        public static float2 Tan(float2 v) => float2.Tan(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Tanh (System.Math.Tanh(v)).
        /// </summary>
        [Inline]
        public static float2 Tanh(float2 v) => float2.Tanh(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Truncate (System.Math.Truncate(v)).
        /// </summary>
        [Inline]
        public static float2 Truncate(float2 v) => float2.Truncate(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of Fract ((v - System.Math.Floor(v))).
        /// </summary>
        [Inline]
        public static float2 Fract(float2 v) => float2.Fract(v);
        
        /// <summary>
        /// Returns a float2 from component-wise application of TruncateFast ((int64)(v)).
        /// </summary>
        [Inline]
        public static float2 TruncateFast(float2 v) => float2.TruncateFast(v);
        
        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        [Inline]
        public static float MinElement(float2 v) => v.MinElement;
        
        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        [Inline]
        public static float MaxElement(float2 v) => v.MaxElement;
        
        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        [Inline]
        public static float Length(float2 v) => v.Length;
        
        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        [Inline]
        public static float LengthSqr(float2 v) => v.LengthSqr;
        
        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        [Inline]
        public static float Sum(float2 v) => v.Sum;
        
        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        [Inline]
        public static float Norm(float2 v) => v.Norm;
        
        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        [Inline]
        public static float Norm1(float2 v) => v.Norm1;
        
        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        [Inline]
        public static float Norm2(float2 v) => v.Norm2;
        
        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        [Inline]
        public static float NormMax(float2 v) => v.NormMax;
        
        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        [Inline]
        public static double NormP(float2 v, double p) => v.NormP(p);
        
        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        [Inline]
        public static float2 Normalized(float2 v) => v.Normalized;
        
        /// <summary>
        /// Returns a copy of this vector with length one (returns zero if length is zero).
        /// </summary>
        [Inline]
        public static float2 NormalizedSafe(float2 v) => v.NormalizedSafe;
        
        /// <summary>
        /// Returns the vector angle (atan2(y, x)) in radians.
        /// </summary>
        [Inline]
        public static double Angle(float2 v) => v.Angle;
        
        /// <summary>
        /// Returns a 2D vector that was rotated by a given angle in radians (CAUTION: result is casted and may be truncated).
        /// </summary>
        [Inline]
        public static float2 Rotated(float2 v, double angleInRad) => v.Rotated(angleInRad);
        
        /// <summary>
        /// Returns a perpendicular vector.
        /// </summary>
        [Inline]
        public static float2 Perpendicular(float2 v) => v.Perpendicular;
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        [Inline]
        public static float Dot(float2 lhs, float2 rhs) => float2.Dot(lhs, rhs);
        
        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        [Inline]
        public static float Distance(float2 lhs, float2 rhs) => float2.Distance(lhs, rhs);
        
        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        [Inline]
        public static float DistanceSqr(float2 lhs, float2 rhs) => float2.DistanceSqr(lhs, rhs);
        
        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        [Inline]
        public static float2 Reflect(float2 I, float2 N) => float2.Reflect(I, N);
        
        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        [Inline]
        public static float2 Refract(float2 I, float2 N, float eta) => float2.Refract(I, N, eta);
        
        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        [Inline]
        public static float2 FaceForward(float2 N, float2 I, float2 Nref) => float2.FaceForward(N, I, Nref);
        
        /// <summary>
        /// Returns the length of the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        [Inline]
        public static float Cross(float2 l, float2 r) => float2.Cross(l, r);
        
        /// <summary>
        /// Returns a float2 with independent and identically distributed uniform values between 'minValue' and 'maxValue'.
        /// </summary>
        [Inline]
        public static float2 Random(Random random, float2 minValue, float2 maxValue) => float2.Random(random, minValue, maxValue);
        
        /// <summary>
        /// Returns a float2 with independent and identically distributed uniform values between 'minValue' and 'maxValue'.
        /// </summary>
        [Inline]
        public static float2 RandomUniform(Random random, float2 minValue, float2 maxValue) => float2.RandomUniform(random, minValue, maxValue);
        
        /// <summary>
        /// Returns a float2 with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance.
        /// </summary>
        [Inline]
        public static float2 RandomNormal(Random random, float2 mean, float2 variance) => float2.RandomNormal(random, mean, variance);
        
        /// <summary>
        /// Returns a float2 with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance.
        /// </summary>
        [Inline]
        public static float2 RandomGaussian(Random random, float2 mean, float2 variance) => float2.RandomGaussian(random, mean, variance);

    }
}
