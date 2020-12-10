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
        public static int[] ToArray(int3 v) => v.ToArray();
        
        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        [Inline]
        public static void ToString(int3 v, String stringBuffer) => v.ToString(stringBuffer);
        
        /// <summary>
        /// Returns a string representation of this vector using a provided seperator.
        /// </summary>
        [Inline]
        public static void ToString(int3 v, String stringBuffer, String sep) => v.ToString(stringBuffer, sep);
        
        /// <summary>
        /// Returns the number of components (3).
        /// </summary>
        [Inline]
        public static int Count(int3 v) => v.Count;
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        [Inline]
        public static int GetHashCode(int3 v) => v.GetHashCode();
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool3 Equal(int3 lhs, int3 rhs) => int3.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool Equal(int lhs, int rhs) => lhs == rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool3 NotEqual(int3 lhs, int3 rhs) => int3.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool NotEqual(int lhs, int rhs) => lhs != rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        [Inline]
        public static bool3 GreaterThan(int3 lhs, int3 rhs) => int3.GreaterThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        [Inline]
        public static bool GreaterThan(int lhs, int rhs) => lhs > rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        [Inline]
        public static bool3 GreaterThanEqual(int3 lhs, int3 rhs) => int3.GreaterThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        [Inline]
        public static bool GreaterThanEqual(int lhs, int rhs) => lhs >= rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        [Inline]
        public static bool3 LesserThan(int3 lhs, int3 rhs) => int3.LesserThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        [Inline]
        public static bool LesserThan(int lhs, int rhs) => lhs < rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        [Inline]
        public static bool3 LesserThanEqual(int3 lhs, int3 rhs) => int3.LesserThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        [Inline]
        public static bool LesserThanEqual(int lhs, int rhs) => lhs <= rhs;
        
        /// <summary>
        /// Returns a int3 from component-wise application of Abs (System.Math.Abs(v)).
        /// </summary>
        [Inline]
        public static int3 Abs(int3 v) => int3.Abs(v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Abs (System.Math.Abs(v)).
        /// </summary>
        [Inline]
        public static int Abs(int v) => System.Math.Abs(v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        [Inline]
        public static int3 HermiteInterpolationOrder3(int3 v) => int3.HermiteInterpolationOrder3(v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        [Inline]
        public static int HermiteInterpolationOrder3(int v) => (3 - 2 * v) * v * v;
        
        /// <summary>
        /// Returns a int3 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        [Inline]
        public static int3 HermiteInterpolationOrder5(int3 v) => int3.HermiteInterpolationOrder5(v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        [Inline]
        public static int HermiteInterpolationOrder5(int v) => ((6 * v - 15) * v + 10) * v * v * v;
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sqr (v * v).
        /// </summary>
        [Inline]
        public static int3 Sqr(int3 v) => int3.Sqr(v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sqr (v * v).
        /// </summary>
        [Inline]
        public static int Sqr(int v) => v * v;
        
        /// <summary>
        /// Returns a int3 from component-wise application of Pow2 (v * v).
        /// </summary>
        [Inline]
        public static int3 Pow2(int3 v) => int3.Pow2(v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Pow2 (v * v).
        /// </summary>
        [Inline]
        public static int Pow2(int v) => v * v;
        
        /// <summary>
        /// Returns a int3 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        [Inline]
        public static int3 Pow3(int3 v) => int3.Pow3(v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        [Inline]
        public static int Pow3(int v) => v * v * v;
        
        /// <summary>
        /// Returns a int3 from component-wise application of Step (v &gt;= 0 ? 1 : 0).
        /// </summary>
        [Inline]
        public static int3 Step(int3 v) => int3.Step(v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Step (v &gt;= 0 ? 1 : 0).
        /// </summary>
        [Inline]
        public static int Step(int v) => v >= 0 ? 1 : 0;
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sqrt ((int)System.Math.Sqrt((double)v)).
        /// </summary>
        [Inline]
        public static int3 Sqrt(int3 v) => int3.Sqrt(v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sqrt ((int)System.Math.Sqrt((double)v)).
        /// </summary>
        [Inline]
        public static int Sqrt(int v) => (int)System.Math.Sqrt((double)v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of InverseSqrt ((int)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        [Inline]
        public static int3 InverseSqrt(int3 v) => int3.InverseSqrt(v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of InverseSqrt ((int)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        [Inline]
        public static int InverseSqrt(int v) => (int)(1.0 / System.Math.Sqrt((double)v));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sign (System.Math.Sign(v)).
        /// </summary>
        [Inline]
        public static int3 Sign(int3 v) => int3.Sign(v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sign (System.Math.Sign(v)).
        /// </summary>
        [Inline]
        public static int Sign(int v) => System.Math.Sign(v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        [Inline]
        public static int3 Max(int3 lhs, int3 rhs) => int3.Max(lhs, rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        [Inline]
        public static int Max(int lhs, int rhs) => System.Math.Max(lhs, rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        [Inline]
        public static int3 Min(int3 lhs, int3 rhs) => int3.Min(lhs, rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        [Inline]
        public static int Min(int lhs, int rhs) => System.Math.Min(lhs, rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Pow ((int)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static int3 Pow(int3 lhs, int3 rhs) => int3.Pow(lhs, rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Pow ((int)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static int Pow(int lhs, int rhs) => (int)System.Math.Pow((double)lhs, (double)rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Log ((int)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static int3 Log(int3 lhs, int3 rhs) => int3.Log(lhs, rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Log ((int)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static int Log(int lhs, int rhs) => (int)System.Math.Log((double)lhs, (double)rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        [Inline]
        public static int3 Clamp(int3 v, int3 min, int3 max) => int3.Clamp(v, min, max);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        [Inline]
        public static int Clamp(int v, int min, int max) => System.Math.Min(System.Math.Max(v, min), max);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static int3 Mix(int3 min, int3 max, int3 a) => int3.Mix(min, max, a);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static int Mix(int min, int max, int a) => min * (1-a) + max * a;
        
        /// <summary>
        /// Returns a int3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static int3 Lerp(int3 min, int3 max, int3 a) => int3.Lerp(min, max, a);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static int Lerp(int min, int max, int a) => min * (1-a) + max * a;
        
        /// <summary>
        /// Returns a int3 from component-wise application of Fma (a * b + c).
        /// </summary>
        [Inline]
        public static int3 Fma(int3 a, int3 b, int3 c) => int3.Fma(a, b, c);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Fma (a * b + c).
        /// </summary>
        [Inline]
        public static int Fma(int a, int b, int c) => a * b + c;
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static int2x3 OuterProduct(int3 c, int2 r) => int3.OuterProduct(c, r);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static int3x3 OuterProduct(int3 c, int3 r) => int3.OuterProduct(c, r);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static int4x3 OuterProduct(int3 c, int4 r) => int3.OuterProduct(c, r);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        [Inline]
        public static int3 Add(int3 lhs, int3 rhs) => int3.Add(lhs, rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        [Inline]
        public static int Add(int lhs, int rhs) => lhs + rhs;
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        [Inline]
        public static int3 Sub(int3 lhs, int3 rhs) => int3.Sub(lhs, rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        [Inline]
        public static int Sub(int lhs, int rhs) => lhs - rhs;
        
        /// <summary>
        /// Returns a int3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        [Inline]
        public static int3 Mul(int3 lhs, int3 rhs) => int3.Mul(lhs, rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        [Inline]
        public static int Mul(int lhs, int rhs) => lhs * rhs;
        
        /// <summary>
        /// Returns a int3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        [Inline]
        public static int3 Div(int3 lhs, int3 rhs) => int3.Div(lhs, rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        [Inline]
        public static int Div(int lhs, int rhs) => lhs / rhs;
        
        /// <summary>
        /// Returns a int3 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        [Inline]
        public static int3 Xor(int3 lhs, int3 rhs) => int3.Xor(lhs, rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        [Inline]
        public static int Xor(int lhs, int rhs) => lhs ^ rhs;
        
        /// <summary>
        /// Returns a int3 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        [Inline]
        public static int3 BitwiseOr(int3 lhs, int3 rhs) => int3.BitwiseOr(lhs, rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        [Inline]
        public static int BitwiseOr(int lhs, int rhs) => lhs | rhs;
        
        /// <summary>
        /// Returns a int3 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        [Inline]
        public static int3 BitwiseAnd(int3 lhs, int3 rhs) => int3.BitwiseAnd(lhs, rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        [Inline]
        public static int BitwiseAnd(int lhs, int rhs) => lhs & rhs;
        
        /// <summary>
        /// Returns a int3 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        [Inline]
        public static int3 LeftShift(int3 lhs, int3 rhs) => int3.LeftShift(lhs, rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        [Inline]
        public static int LeftShift(int lhs, int rhs) => lhs << rhs;
        
        /// <summary>
        /// Returns a int3 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        [Inline]
        public static int3 RightShift(int3 lhs, int3 rhs) => int3.RightShift(lhs, rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        [Inline]
        public static int RightShift(int lhs, int rhs) => lhs >> rhs;
        
        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        [Inline]
        public static int MinElement(int3 v) => v.MinElement;
        
        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        [Inline]
        public static int MaxElement(int3 v) => v.MaxElement;
        
        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        [Inline]
        public static float Length(int3 v) => v.Length;
        
        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        [Inline]
        public static float LengthSqr(int3 v) => v.LengthSqr;
        
        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        [Inline]
        public static int Sum(int3 v) => v.Sum;
        
        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        [Inline]
        public static float Norm(int3 v) => v.Norm;
        
        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        [Inline]
        public static float Norm1(int3 v) => v.Norm1;
        
        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        [Inline]
        public static float Norm2(int3 v) => v.Norm2;
        
        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        [Inline]
        public static float NormMax(int3 v) => v.NormMax;
        
        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        [Inline]
        public static double NormP(int3 v, double p) => v.NormP(p);
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        [Inline]
        public static int Dot(int3 lhs, int3 rhs) => int3.Dot(lhs, rhs);
        
        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        [Inline]
        public static float Distance(int3 lhs, int3 rhs) => int3.Distance(lhs, rhs);
        
        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        [Inline]
        public static float DistanceSqr(int3 lhs, int3 rhs) => int3.DistanceSqr(lhs, rhs);
        
        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        [Inline]
        public static int3 Reflect(int3 I, int3 N) => int3.Reflect(I, N);
        
        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        [Inline]
        public static int3 Refract(int3 I, int3 N, int eta) => int3.Refract(I, N, eta);
        
        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        [Inline]
        public static int3 FaceForward(int3 N, int3 I, int3 Nref) => int3.FaceForward(N, I, Nref);
        
        /// <summary>
        /// Returns the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        [Inline]
        public static int3 Cross(int3 l, int3 r) => int3.Cross(l, r);
        
        /// <summary>
        /// Returns a int3 with independent and identically distributed uniform integer values between 0 (inclusive) and maxValue (exclusive). (A maxValue of 0 is allowed and returns 0.)
        /// </summary>
        [Inline]
        public static int3 Random(Random random, int3 maxValue) => int3.Random(random, maxValue);
        
        /// <summary>
        /// Returns a int3 with independent and identically distributed uniform integer values between 0 (inclusive) and maxValue (exclusive). (A maxValue of 0 is allowed and returns 0.)
        /// </summary>
        [Inline]
        public static int Random(Random random, int maxValue) => (int)random.Next((int)maxValue);
        
        /// <summary>
        /// Returns a int3 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        [Inline]
        public static int3 Random(Random random, int3 minValue, int3 maxValue) => int3.Random(random, minValue, maxValue);
        
        /// <summary>
        /// Returns a int3 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        [Inline]
        public static int Random(Random random, int minValue, int maxValue) => (int)random.Next((int)minValue, (int)maxValue);
        
        /// <summary>
        /// Returns a int3 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        [Inline]
        public static int3 RandomUniform(Random random, int3 minValue, int3 maxValue) => int3.RandomUniform(random, minValue, maxValue);
        
        /// <summary>
        /// Returns a int3 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        [Inline]
        public static int RandomUniform(Random random, int minValue, int maxValue) => (int)random.Next((int)minValue, (int)maxValue);

    }
}
