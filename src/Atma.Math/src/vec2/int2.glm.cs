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
        public static int[] ToArray(int2 v) => v.ToArray();
        
        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        [Inline]
        public static void ToString(int2 v, String stringBuffer) => v.ToString(stringBuffer);
        
        /// <summary>
        /// Returns a string representation of this vector using a provided seperator.
        /// </summary>
        [Inline]
        public static void ToString(int2 v, String stringBuffer, String sep) => v.ToString(stringBuffer, sep);
        
        /// <summary>
        /// Returns the number of components (2).
        /// </summary>
        [Inline]
        public static int Count(int2 v) => v.Count;
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        [Inline]
        public static int GetHashCode(int2 v) => v.GetHashCode();
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool2 Equal(int2 lhs, int2 rhs) => int2.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool2 NotEqual(int2 lhs, int2 rhs) => int2.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        [Inline]
        public static bool2 GreaterThan(int2 lhs, int2 rhs) => int2.GreaterThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        [Inline]
        public static bool2 GreaterThanEqual(int2 lhs, int2 rhs) => int2.GreaterThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        [Inline]
        public static bool2 LesserThan(int2 lhs, int2 rhs) => int2.LesserThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        [Inline]
        public static bool2 LesserThanEqual(int2 lhs, int2 rhs) => int2.LesserThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Abs (System.Math.Abs(v)).
        /// </summary>
        [Inline]
        public static int2 Abs(int2 v) => int2.Abs(v);
        
        /// <summary>
        /// Returns a int2 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        [Inline]
        public static int2 HermiteInterpolationOrder3(int2 v) => int2.HermiteInterpolationOrder3(v);
        
        /// <summary>
        /// Returns a int2 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        [Inline]
        public static int2 HermiteInterpolationOrder5(int2 v) => int2.HermiteInterpolationOrder5(v);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Sqr (v * v).
        /// </summary>
        [Inline]
        public static int2 Sqr(int2 v) => int2.Sqr(v);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Pow2 (v * v).
        /// </summary>
        [Inline]
        public static int2 Pow2(int2 v) => int2.Pow2(v);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        [Inline]
        public static int2 Pow3(int2 v) => int2.Pow3(v);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Step (v &gt;= 0 ? 1 : 0).
        /// </summary>
        [Inline]
        public static int2 Step(int2 v) => int2.Step(v);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Sqrt ((int)System.Math.Sqrt((double)v)).
        /// </summary>
        [Inline]
        public static int2 Sqrt(int2 v) => int2.Sqrt(v);
        
        /// <summary>
        /// Returns a int2 from component-wise application of InverseSqrt ((int)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        [Inline]
        public static int2 InverseSqrt(int2 v) => int2.InverseSqrt(v);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Sign (System.Math.Sign(v)).
        /// </summary>
        [Inline]
        public static int2 Sign(int2 v) => int2.Sign(v);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        [Inline]
        public static int2 Max(int2 lhs, int2 rhs) => int2.Max(lhs, rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        [Inline]
        public static int2 Min(int2 lhs, int2 rhs) => int2.Min(lhs, rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Pow ((int)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static int2 Pow(int2 lhs, int2 rhs) => int2.Pow(lhs, rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Log ((int)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static int2 Log(int2 lhs, int2 rhs) => int2.Log(lhs, rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        [Inline]
        public static int2 Clamp(int2 v, int2 min, int2 max) => int2.Clamp(v, min, max);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static int2 Mix(int2 min, int2 max, int2 a) => int2.Mix(min, max, a);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static int2 Lerp(int2 min, int2 max, int2 a) => int2.Lerp(min, max, a);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Fma (a * b + c).
        /// </summary>
        [Inline]
        public static int2 Fma(int2 a, int2 b, int2 c) => int2.Fma(a, b, c);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static int2x2 OuterProduct(int2 c, int2 r) => int2.OuterProduct(c, r);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static int3x2 OuterProduct(int2 c, int3 r) => int2.OuterProduct(c, r);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static int4x2 OuterProduct(int2 c, int4 r) => int2.OuterProduct(c, r);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Add (lhs + rhs).
        /// </summary>
        [Inline]
        public static int2 Add(int2 lhs, int2 rhs) => int2.Add(lhs, rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        [Inline]
        public static int2 Sub(int2 lhs, int2 rhs) => int2.Sub(lhs, rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        [Inline]
        public static int2 Mul(int2 lhs, int2 rhs) => int2.Mul(lhs, rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Div (lhs / rhs).
        /// </summary>
        [Inline]
        public static int2 Div(int2 lhs, int2 rhs) => int2.Div(lhs, rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        [Inline]
        public static int2 Xor(int2 lhs, int2 rhs) => int2.Xor(lhs, rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        [Inline]
        public static int2 BitwiseOr(int2 lhs, int2 rhs) => int2.BitwiseOr(lhs, rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        [Inline]
        public static int2 BitwiseAnd(int2 lhs, int2 rhs) => int2.BitwiseAnd(lhs, rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        [Inline]
        public static int2 LeftShift(int2 lhs, int2 rhs) => int2.LeftShift(lhs, rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        [Inline]
        public static int2 RightShift(int2 lhs, int2 rhs) => int2.RightShift(lhs, rhs);
        
        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        [Inline]
        public static int MinElement(int2 v) => v.MinElement;
        
        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        [Inline]
        public static int MaxElement(int2 v) => v.MaxElement;
        
        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        [Inline]
        public static float Length(int2 v) => v.Length;
        
        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        [Inline]
        public static float LengthSqr(int2 v) => v.LengthSqr;
        
        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        [Inline]
        public static int Sum(int2 v) => v.Sum;
        
        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        [Inline]
        public static float Norm(int2 v) => v.Norm;
        
        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        [Inline]
        public static float Norm1(int2 v) => v.Norm1;
        
        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        [Inline]
        public static float Norm2(int2 v) => v.Norm2;
        
        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        [Inline]
        public static float NormMax(int2 v) => v.NormMax;
        
        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        [Inline]
        public static double NormP(int2 v, double p) => v.NormP(p);
        
        /// <summary>
        /// Returns a perpendicular vector.
        /// </summary>
        [Inline]
        public static int2 Perpendicular(int2 v) => v.Perpendicular;
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        [Inline]
        public static int Dot(int2 lhs, int2 rhs) => int2.Dot(lhs, rhs);
        
        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        [Inline]
        public static float Distance(int2 lhs, int2 rhs) => int2.Distance(lhs, rhs);
        
        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        [Inline]
        public static float DistanceSqr(int2 lhs, int2 rhs) => int2.DistanceSqr(lhs, rhs);
        
        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        [Inline]
        public static int2 Reflect(int2 I, int2 N) => int2.Reflect(I, N);
        
        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        [Inline]
        public static int2 Refract(int2 I, int2 N, int eta) => int2.Refract(I, N, eta);
        
        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        [Inline]
        public static int2 FaceForward(int2 N, int2 I, int2 Nref) => int2.FaceForward(N, I, Nref);
        
        /// <summary>
        /// Returns the length of the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        [Inline]
        public static int Cross(int2 l, int2 r) => int2.Cross(l, r);
        
        /// <summary>
        /// Returns a int2 with independent and identically distributed uniform integer values between 0 (inclusive) and maxValue (exclusive). (A maxValue of 0 is allowed and returns 0.)
        /// </summary>
        [Inline]
        public static int2 Random(Random random, int2 maxValue) => int2.Random(random, maxValue);
        
        /// <summary>
        /// Returns a int2 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        [Inline]
        public static int2 Random(Random random, int2 minValue, int2 maxValue) => int2.Random(random, minValue, maxValue);
        
        /// <summary>
        /// Returns a int2 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        [Inline]
        public static int2 RandomUniform(Random random, int2 minValue, int2 maxValue) => int2.RandomUniform(random, minValue, maxValue);

    }
}
