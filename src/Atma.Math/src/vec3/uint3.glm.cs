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
        public static uint[] ToArray(uint3 v) => v.ToArray();
        
        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        [Inline]
        public static void ToString(uint3 v, String stringBuffer) => v.ToString(stringBuffer);
        
        /// <summary>
        /// Returns a string representation of this vector using a provided seperator.
        /// </summary>
        [Inline]
        public static void ToString(uint3 v, String stringBuffer, String sep) => v.ToString(stringBuffer, sep);
        
        /// <summary>
        /// Returns the number of components (3).
        /// </summary>
        [Inline]
        public static int Count(uint3 v) => v.Count;
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        [Inline]
        public static int GetHashCode(uint3 v) => v.GetHashCode();
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool3 Equal(uint3 lhs, uint3 rhs) => uint3.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool Equal(uint lhs, uint rhs) => lhs == rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool3 NotEqual(uint3 lhs, uint3 rhs) => uint3.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool NotEqual(uint lhs, uint rhs) => lhs != rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        [Inline]
        public static bool3 GreaterThan(uint3 lhs, uint3 rhs) => uint3.GreaterThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        [Inline]
        public static bool GreaterThan(uint lhs, uint rhs) => lhs > rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        [Inline]
        public static bool3 GreaterThanEqual(uint3 lhs, uint3 rhs) => uint3.GreaterThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        [Inline]
        public static bool GreaterThanEqual(uint lhs, uint rhs) => lhs >= rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        [Inline]
        public static bool3 LesserThan(uint3 lhs, uint3 rhs) => uint3.LesserThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        [Inline]
        public static bool LesserThan(uint lhs, uint rhs) => lhs < rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        [Inline]
        public static bool3 LesserThanEqual(uint3 lhs, uint3 rhs) => uint3.LesserThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        [Inline]
        public static bool LesserThanEqual(uint lhs, uint rhs) => lhs <= rhs;
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Abs (v).
        /// </summary>
        [Inline]
        public static uint3 Abs(uint3 v) => uint3.Abs(v);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Abs (v).
        /// </summary>
        [Inline]
        public static uint Abs(uint v) => v;
        
        /// <summary>
        /// Returns a uint3 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        [Inline]
        public static uint3 HermiteInterpolationOrder3(uint3 v) => uint3.HermiteInterpolationOrder3(v);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        [Inline]
        public static uint HermiteInterpolationOrder3(uint v) => (3 - 2 * v) * v * v;
        
        /// <summary>
        /// Returns a uint3 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        [Inline]
        public static uint3 HermiteInterpolationOrder5(uint3 v) => uint3.HermiteInterpolationOrder5(v);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        [Inline]
        public static uint HermiteInterpolationOrder5(uint v) => ((6 * v - 15) * v + 10) * v * v * v;
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Sqr (v * v).
        /// </summary>
        [Inline]
        public static uint3 Sqr(uint3 v) => uint3.Sqr(v);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Sqr (v * v).
        /// </summary>
        [Inline]
        public static uint Sqr(uint v) => v * v;
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Pow2 (v * v).
        /// </summary>
        [Inline]
        public static uint3 Pow2(uint3 v) => uint3.Pow2(v);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Pow2 (v * v).
        /// </summary>
        [Inline]
        public static uint Pow2(uint v) => v * v;
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        [Inline]
        public static uint3 Pow3(uint3 v) => uint3.Pow3(v);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        [Inline]
        public static uint Pow3(uint v) => v * v * v;
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Step (v &gt;= 0u ? 1u : 0u).
        /// </summary>
        [Inline]
        public static uint3 Step(uint3 v) => uint3.Step(v);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Step (v &gt;= 0u ? 1u : 0u).
        /// </summary>
        [Inline]
        public static uint Step(uint v) => v >= 0u ? 1u : 0u;
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Sqrt ((uint)System.Math.Sqrt((double)v)).
        /// </summary>
        [Inline]
        public static uint3 Sqrt(uint3 v) => uint3.Sqrt(v);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Sqrt ((uint)System.Math.Sqrt((double)v)).
        /// </summary>
        [Inline]
        public static uint Sqrt(uint v) => (uint)System.Math.Sqrt((double)v);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of InverseSqrt ((uint)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        [Inline]
        public static uint3 InverseSqrt(uint3 v) => uint3.InverseSqrt(v);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of InverseSqrt ((uint)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        [Inline]
        public static uint InverseSqrt(uint v) => (uint)(1.0 / System.Math.Sqrt((double)v));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sign (System.Math.Sign(v)).
        /// </summary>
        [Inline]
        public static int3 Sign(uint3 v) => uint3.Sign(v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sign (System.Math.Sign(v)).
        /// </summary>
        [Inline]
        public static int Sign(uint v) => System.Math.Sign(v);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        [Inline]
        public static uint3 Max(uint3 lhs, uint3 rhs) => uint3.Max(lhs, rhs);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        [Inline]
        public static uint Max(uint lhs, uint rhs) => System.Math.Max(lhs, rhs);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        [Inline]
        public static uint3 Min(uint3 lhs, uint3 rhs) => uint3.Min(lhs, rhs);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        [Inline]
        public static uint Min(uint lhs, uint rhs) => System.Math.Min(lhs, rhs);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Pow ((uint)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static uint3 Pow(uint3 lhs, uint3 rhs) => uint3.Pow(lhs, rhs);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Pow ((uint)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static uint Pow(uint lhs, uint rhs) => (uint)System.Math.Pow((double)lhs, (double)rhs);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Log ((uint)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static uint3 Log(uint3 lhs, uint3 rhs) => uint3.Log(lhs, rhs);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Log ((uint)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static uint Log(uint lhs, uint rhs) => (uint)System.Math.Log((double)lhs, (double)rhs);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        [Inline]
        public static uint3 Clamp(uint3 v, uint3 min, uint3 max) => uint3.Clamp(v, min, max);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        [Inline]
        public static uint Clamp(uint v, uint min, uint max) => System.Math.Min(System.Math.Max(v, min), max);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static uint3 Mix(uint3 min, uint3 max, uint3 a) => uint3.Mix(min, max, a);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static uint Mix(uint min, uint max, uint a) => min * (1-a) + max * a;
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static uint3 Lerp(uint3 min, uint3 max, uint3 a) => uint3.Lerp(min, max, a);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static uint Lerp(uint min, uint max, uint a) => min * (1-a) + max * a;
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Fma (a * b + c).
        /// </summary>
        [Inline]
        public static uint3 Fma(uint3 a, uint3 b, uint3 c) => uint3.Fma(a, b, c);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Fma (a * b + c).
        /// </summary>
        [Inline]
        public static uint Fma(uint a, uint b, uint c) => a * b + c;
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static uint2x3 OuterProduct(uint3 c, uint2 r) => uint3.OuterProduct(c, r);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static uint3x3 OuterProduct(uint3 c, uint3 r) => uint3.OuterProduct(c, r);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static uint4x3 OuterProduct(uint3 c, uint4 r) => uint3.OuterProduct(c, r);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        [Inline]
        public static uint3 Add(uint3 lhs, uint3 rhs) => uint3.Add(lhs, rhs);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        [Inline]
        public static uint Add(uint lhs, uint rhs) => lhs + rhs;
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        [Inline]
        public static uint3 Sub(uint3 lhs, uint3 rhs) => uint3.Sub(lhs, rhs);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        [Inline]
        public static uint Sub(uint lhs, uint rhs) => lhs - rhs;
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        [Inline]
        public static uint3 Mul(uint3 lhs, uint3 rhs) => uint3.Mul(lhs, rhs);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        [Inline]
        public static uint Mul(uint lhs, uint rhs) => lhs * rhs;
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        [Inline]
        public static uint3 Div(uint3 lhs, uint3 rhs) => uint3.Div(lhs, rhs);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        [Inline]
        public static uint Div(uint lhs, uint rhs) => lhs / rhs;
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        [Inline]
        public static uint3 Xor(uint3 lhs, uint3 rhs) => uint3.Xor(lhs, rhs);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        [Inline]
        public static uint Xor(uint lhs, uint rhs) => lhs ^ rhs;
        
        /// <summary>
        /// Returns a uint3 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        [Inline]
        public static uint3 BitwiseOr(uint3 lhs, uint3 rhs) => uint3.BitwiseOr(lhs, rhs);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        [Inline]
        public static uint BitwiseOr(uint lhs, uint rhs) => lhs | rhs;
        
        /// <summary>
        /// Returns a uint3 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        [Inline]
        public static uint3 BitwiseAnd(uint3 lhs, uint3 rhs) => uint3.BitwiseAnd(lhs, rhs);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        [Inline]
        public static uint BitwiseAnd(uint lhs, uint rhs) => lhs & rhs;
        
        /// <summary>
        /// Returns a uint3 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        [Inline]
        public static uint3 LeftShift(uint3 lhs, int3 rhs) => uint3.LeftShift(lhs, rhs);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        [Inline]
        public static uint LeftShift(uint lhs, int rhs) => lhs << rhs;
        
        /// <summary>
        /// Returns a uint3 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        [Inline]
        public static uint3 RightShift(uint3 lhs, int3 rhs) => uint3.RightShift(lhs, rhs);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        [Inline]
        public static uint RightShift(uint lhs, int rhs) => lhs >> rhs;
        
        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        [Inline]
        public static uint MinElement(uint3 v) => v.MinElement;
        
        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        [Inline]
        public static uint MaxElement(uint3 v) => v.MaxElement;
        
        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        [Inline]
        public static float Length(uint3 v) => v.Length;
        
        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        [Inline]
        public static float LengthSqr(uint3 v) => v.LengthSqr;
        
        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        [Inline]
        public static uint Sum(uint3 v) => v.Sum;
        
        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        [Inline]
        public static float Norm(uint3 v) => v.Norm;
        
        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        [Inline]
        public static float Norm1(uint3 v) => v.Norm1;
        
        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        [Inline]
        public static float Norm2(uint3 v) => v.Norm2;
        
        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        [Inline]
        public static float NormMax(uint3 v) => v.NormMax;
        
        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        [Inline]
        public static double NormP(uint3 v, double p) => v.NormP(p);
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        [Inline]
        public static uint Dot(uint3 lhs, uint3 rhs) => uint3.Dot(lhs, rhs);
        
        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        [Inline]
        public static float Distance(uint3 lhs, uint3 rhs) => uint3.Distance(lhs, rhs);
        
        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        [Inline]
        public static float DistanceSqr(uint3 lhs, uint3 rhs) => uint3.DistanceSqr(lhs, rhs);
        
        /// <summary>
        /// Returns the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        [Inline]
        public static uint3 Cross(uint3 l, uint3 r) => uint3.Cross(l, r);
        
        /// <summary>
        /// Returns a uint3 with independent and identically distributed uniform integer values between 0 (inclusive) and maxValue (exclusive). (A maxValue of 0 is allowed and returns 0.)
        /// </summary>
        [Inline]
        public static uint3 Random(Random random, uint3 maxValue) => uint3.Random(random, maxValue);
        
        /// <summary>
        /// Returns a uint3 with independent and identically distributed uniform integer values between 0 (inclusive) and maxValue (exclusive). (A maxValue of 0 is allowed and returns 0.)
        /// </summary>
        [Inline]
        public static uint Random(Random random, uint maxValue) => (uint)random.Next((int)maxValue);
        
        /// <summary>
        /// Returns a uint3 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        [Inline]
        public static uint3 Random(Random random, uint3 minValue, uint3 maxValue) => uint3.Random(random, minValue, maxValue);
        
        /// <summary>
        /// Returns a uint3 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        [Inline]
        public static uint Random(Random random, uint minValue, uint maxValue) => (uint)random.Next((int)minValue, (int)maxValue);
        
        /// <summary>
        /// Returns a uint3 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        [Inline]
        public static uint3 RandomUniform(Random random, uint3 minValue, uint3 maxValue) => uint3.RandomUniform(random, minValue, maxValue);
        
        /// <summary>
        /// Returns a uint3 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        [Inline]
        public static uint RandomUniform(Random random, uint minValue, uint maxValue) => (uint)random.Next((int)minValue, (int)maxValue);

    }
}
