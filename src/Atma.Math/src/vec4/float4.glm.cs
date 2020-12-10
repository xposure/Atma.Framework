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
        public static float[] ToArray(float4 v) => v.ToArray();
        
        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        [Inline]
        public static void ToString(float4 v, String stringBuffer) => v.ToString(stringBuffer);
        
        /// <summary>
        /// Returns a string representation of this vector using a provided seperator.
        /// </summary>
        [Inline]
        public static void ToString(float4 v, String stringBuffer, String sep) => v.ToString(stringBuffer, sep);
        
        /// <summary>
        /// Returns the number of components (4).
        /// </summary>
        [Inline]
        public static int Count(float4 v) => v.Count;
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        [Inline]
        public static int GetHashCode(float4 v) => v.GetHashCode();
        
        /// <summary>
        /// Returns true iff distance between lhs and rhs is less than or equal to epsilon
        /// </summary>
        [Inline]
        public static bool ApproxEqual(float4 lhs, float4 rhs, float eps = 0.1f) => float4.ApproxEqual(lhs, rhs, eps);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool4 Equal(float4 lhs, float4 rhs) => float4.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool4 NotEqual(float4 lhs, float4 rhs) => float4.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        [Inline]
        public static bool4 GreaterThan(float4 lhs, float4 rhs) => float4.GreaterThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        [Inline]
        public static bool4 GreaterThanEqual(float4 lhs, float4 rhs) => float4.GreaterThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        [Inline]
        public static bool4 LesserThan(float4 lhs, float4 rhs) => float4.LesserThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        [Inline]
        public static bool4 LesserThanEqual(float4 lhs, float4 rhs) => float4.LesserThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of IsInfinity (v.IsInfinity).
        /// </summary>
        [Inline]
        public static bool4 IsInfinity(float4 v) => float4.IsInfinity(v);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of IsFinite (v.IsFinite).
        /// </summary>
        [Inline]
        public static bool4 IsFinite(float4 v) => float4.IsFinite(v);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of IsNaN (v.IsNaN).
        /// </summary>
        [Inline]
        public static bool4 IsNaN(float4 v) => float4.IsNaN(v);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of IsNegativeInfinity (v.IsNegativeInfinity).
        /// </summary>
        [Inline]
        public static bool4 IsNegativeInfinity(float4 v) => float4.IsNegativeInfinity(v);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of IsPositiveInfinity (v.IsPositiveInfinity).
        /// </summary>
        [Inline]
        public static bool4 IsPositiveInfinity(float4 v) => float4.IsPositiveInfinity(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Abs (System.Math.Abs(v)).
        /// </summary>
        [Inline]
        public static float4 Abs(float4 v) => float4.Abs(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        [Inline]
        public static float4 HermiteInterpolationOrder3(float4 v) => float4.HermiteInterpolationOrder3(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        [Inline]
        public static float4 HermiteInterpolationOrder5(float4 v) => float4.HermiteInterpolationOrder5(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Sqr (v * v).
        /// </summary>
        [Inline]
        public static float4 Sqr(float4 v) => float4.Sqr(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Pow2 (v * v).
        /// </summary>
        [Inline]
        public static float4 Pow2(float4 v) => float4.Pow2(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        [Inline]
        public static float4 Pow3(float4 v) => float4.Pow3(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Step (v &gt;= 0f ? 1f : 0f).
        /// </summary>
        [Inline]
        public static float4 Step(float4 v) => float4.Step(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Sqrt ((float)System.Math.Sqrt((double)v)).
        /// </summary>
        [Inline]
        public static float4 Sqrt(float4 v) => float4.Sqrt(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of InverseSqrt ((float)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        [Inline]
        public static float4 InverseSqrt(float4 v) => float4.InverseSqrt(v);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Sign (System.Math.Sign(v)).
        /// </summary>
        [Inline]
        public static int4 Sign(float4 v) => float4.Sign(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        [Inline]
        public static float4 Max(float4 lhs, float4 rhs) => float4.Max(lhs, rhs);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        [Inline]
        public static float4 Min(float4 lhs, float4 rhs) => float4.Min(lhs, rhs);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Pow ((float)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static float4 Pow(float4 lhs, float4 rhs) => float4.Pow(lhs, rhs);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Log ((float)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static float4 Log(float4 lhs, float4 rhs) => float4.Log(lhs, rhs);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        [Inline]
        public static float4 Clamp(float4 v, float4 min, float4 max) => float4.Clamp(v, min, max);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static float4 Mix(float4 min, float4 max, float4 a) => float4.Mix(min, max, a);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static float4 Lerp(float4 min, float4 max, float4 a) => float4.Lerp(min, max, a);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Fma (a * b + c).
        /// </summary>
        [Inline]
        public static float4 Fma(float4 a, float4 b, float4 c) => float4.Fma(a, b, c);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static float2x4 OuterProduct(float4 c, float2 r) => float4.OuterProduct(c, r);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static float3x4 OuterProduct(float4 c, float3 r) => float4.OuterProduct(c, r);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static float4x4 OuterProduct(float4 c, float4 r) => float4.OuterProduct(c, r);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Add (lhs + rhs).
        /// </summary>
        [Inline]
        public static float4 Add(float4 lhs, float4 rhs) => float4.Add(lhs, rhs);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        [Inline]
        public static float4 Sub(float4 lhs, float4 rhs) => float4.Sub(lhs, rhs);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        [Inline]
        public static float4 Mul(float4 lhs, float4 rhs) => float4.Mul(lhs, rhs);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Div (lhs / rhs).
        /// </summary>
        [Inline]
        public static float4 Div(float4 lhs, float4 rhs) => float4.Div(lhs, rhs);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        [Inline]
        public static float4 Modulo(float4 lhs, float4 rhs) => float4.Modulo(lhs, rhs);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Degrees (Radians-To-Degrees Conversion).
        /// </summary>
        [Inline]
        public static float4 Degrees(float4 v) => float4.Degrees(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Radians (Degrees-To-Radians Conversion).
        /// </summary>
        [Inline]
        public static float4 Radians(float4 v) => float4.Radians(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Acos (System.Math.Acos(v)).
        /// </summary>
        [Inline]
        public static float4 Acos(float4 v) => float4.Acos(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Asin (System.Math.Asin(v)).
        /// </summary>
        [Inline]
        public static float4 Asin(float4 v) => float4.Asin(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Atan (System.Math.Atan(v)).
        /// </summary>
        [Inline]
        public static float4 Atan(float4 v) => float4.Atan(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Cos (System.Math.Cos(v)).
        /// </summary>
        [Inline]
        public static float4 Cos(float4 v) => float4.Cos(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Cosh (System.Math.Cosh(v)).
        /// </summary>
        [Inline]
        public static float4 Cosh(float4 v) => float4.Cosh(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Exp (System.Math.Exp(v)).
        /// </summary>
        [Inline]
        public static float4 Exp(float4 v) => float4.Exp(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Log (System.Math.Log(v)).
        /// </summary>
        [Inline]
        public static float4 Log(float4 v) => float4.Log(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Log2 (System.Math.Log(v, 2)).
        /// </summary>
        [Inline]
        public static float4 Log2(float4 v) => float4.Log2(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Log10 (System.Math.Log10(v)).
        /// </summary>
        [Inline]
        public static float4 Log10(float4 v) => float4.Log10(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Floor (System.Math.Floor(v)).
        /// </summary>
        [Inline]
        public static float4 Floor(float4 v) => float4.Floor(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Ceiling (System.Math.Ceiling(v)).
        /// </summary>
        [Inline]
        public static float4 Ceiling(float4 v) => float4.Ceiling(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Round (System.Math.Round(v)).
        /// </summary>
        [Inline]
        public static float4 Round(float4 v) => float4.Round(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Sin (System.Math.Sin(v)).
        /// </summary>
        [Inline]
        public static float4 Sin(float4 v) => float4.Sin(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Sinh (System.Math.Sinh(v)).
        /// </summary>
        [Inline]
        public static float4 Sinh(float4 v) => float4.Sinh(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Tan (System.Math.Tan(v)).
        /// </summary>
        [Inline]
        public static float4 Tan(float4 v) => float4.Tan(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Tanh (System.Math.Tanh(v)).
        /// </summary>
        [Inline]
        public static float4 Tanh(float4 v) => float4.Tanh(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Truncate (System.Math.Truncate(v)).
        /// </summary>
        [Inline]
        public static float4 Truncate(float4 v) => float4.Truncate(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Fract ((v - System.Math.Floor(v))).
        /// </summary>
        [Inline]
        public static float4 Fract(float4 v) => float4.Fract(v);
        
        /// <summary>
        /// Returns a float4 from component-wise application of TruncateFast ((int64)(v)).
        /// </summary>
        [Inline]
        public static float4 TruncateFast(float4 v) => float4.TruncateFast(v);
        
        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        [Inline]
        public static float MinElement(float4 v) => v.MinElement;
        
        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        [Inline]
        public static float MaxElement(float4 v) => v.MaxElement;
        
        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        [Inline]
        public static float Length(float4 v) => v.Length;
        
        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        [Inline]
        public static float LengthSqr(float4 v) => v.LengthSqr;
        
        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        [Inline]
        public static float Sum(float4 v) => v.Sum;
        
        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        [Inline]
        public static float Norm(float4 v) => v.Norm;
        
        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        [Inline]
        public static float Norm1(float4 v) => v.Norm1;
        
        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        [Inline]
        public static float Norm2(float4 v) => v.Norm2;
        
        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        [Inline]
        public static float NormMax(float4 v) => v.NormMax;
        
        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        [Inline]
        public static double NormP(float4 v, double p) => v.NormP(p);
        
        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        [Inline]
        public static float4 Normalized(float4 v) => v.Normalized;
        
        /// <summary>
        /// Returns a copy of this vector with length one (returns zero if length is zero).
        /// </summary>
        [Inline]
        public static float4 NormalizedSafe(float4 v) => v.NormalizedSafe;
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        [Inline]
        public static float Dot(float4 lhs, float4 rhs) => float4.Dot(lhs, rhs);
        
        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        [Inline]
        public static float Distance(float4 lhs, float4 rhs) => float4.Distance(lhs, rhs);
        
        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        [Inline]
        public static float DistanceSqr(float4 lhs, float4 rhs) => float4.DistanceSqr(lhs, rhs);
        
        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        [Inline]
        public static float4 Reflect(float4 I, float4 N) => float4.Reflect(I, N);
        
        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        [Inline]
        public static float4 Refract(float4 I, float4 N, float eta) => float4.Refract(I, N, eta);
        
        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        [Inline]
        public static float4 FaceForward(float4 N, float4 I, float4 Nref) => float4.FaceForward(N, I, Nref);
        
        /// <summary>
        /// Returns a float4 with independent and identically distributed uniform values between 'minValue' and 'maxValue'.
        /// </summary>
        [Inline]
        public static float4 Random(Random random, float4 minValue, float4 maxValue) => float4.Random(random, minValue, maxValue);
        
        /// <summary>
        /// Returns a float4 with independent and identically distributed uniform values between 'minValue' and 'maxValue'.
        /// </summary>
        [Inline]
        public static float4 RandomUniform(Random random, float4 minValue, float4 maxValue) => float4.RandomUniform(random, minValue, maxValue);
        
        /// <summary>
        /// Returns a float4 with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance.
        /// </summary>
        [Inline]
        public static float4 RandomNormal(Random random, float4 mean, float4 variance) => float4.RandomNormal(random, mean, variance);
        
        /// <summary>
        /// Returns a float4 with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance.
        /// </summary>
        [Inline]
        public static float4 RandomGaussian(Random random, float4 mean, float4 variance) => float4.RandomGaussian(random, mean, variance);

    }
}
