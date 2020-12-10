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
        public static double[] ToArray(double2 v) => v.ToArray();
        
        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        [Inline]
        public static void ToString(double2 v, String stringBuffer) => v.ToString(stringBuffer);
        
        /// <summary>
        /// Returns a string representation of this vector using a provided seperator.
        /// </summary>
        [Inline]
        public static void ToString(double2 v, String stringBuffer, String sep) => v.ToString(stringBuffer, sep);
        
        /// <summary>
        /// Returns the number of components (2).
        /// </summary>
        [Inline]
        public static int Count(double2 v) => v.Count;
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        [Inline]
        public static int GetHashCode(double2 v) => v.GetHashCode();
        
        /// <summary>
        /// Returns true iff distance between lhs and rhs is less than or equal to epsilon
        /// </summary>
        [Inline]
        public static bool ApproxEqual(double2 lhs, double2 rhs, double eps = 0.1d) => double2.ApproxEqual(lhs, rhs, eps);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool2 Equal(double2 lhs, double2 rhs) => double2.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool2 NotEqual(double2 lhs, double2 rhs) => double2.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        [Inline]
        public static bool2 GreaterThan(double2 lhs, double2 rhs) => double2.GreaterThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        [Inline]
        public static bool2 GreaterThanEqual(double2 lhs, double2 rhs) => double2.GreaterThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        [Inline]
        public static bool2 LesserThan(double2 lhs, double2 rhs) => double2.LesserThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        [Inline]
        public static bool2 LesserThanEqual(double2 lhs, double2 rhs) => double2.LesserThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of IsInfinity (v.IsInfinity).
        /// </summary>
        [Inline]
        public static bool2 IsInfinity(double2 v) => double2.IsInfinity(v);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of IsNaN (v.IsNaN).
        /// </summary>
        [Inline]
        public static bool2 IsNaN(double2 v) => double2.IsNaN(v);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of IsNegativeInfinity (v.IsNegativeInfinity).
        /// </summary>
        [Inline]
        public static bool2 IsNegativeInfinity(double2 v) => double2.IsNegativeInfinity(v);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of IsPositiveInfinity (v.IsPositiveInfinity).
        /// </summary>
        [Inline]
        public static bool2 IsPositiveInfinity(double2 v) => double2.IsPositiveInfinity(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Abs (System.Math.Abs(v)).
        /// </summary>
        [Inline]
        public static double2 Abs(double2 v) => double2.Abs(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        [Inline]
        public static double2 HermiteInterpolationOrder3(double2 v) => double2.HermiteInterpolationOrder3(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        [Inline]
        public static double2 HermiteInterpolationOrder5(double2 v) => double2.HermiteInterpolationOrder5(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Sqr (v * v).
        /// </summary>
        [Inline]
        public static double2 Sqr(double2 v) => double2.Sqr(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Pow2 (v * v).
        /// </summary>
        [Inline]
        public static double2 Pow2(double2 v) => double2.Pow2(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        [Inline]
        public static double2 Pow3(double2 v) => double2.Pow3(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Step (v &gt;= 0.0 ? 1.0 : 0.0).
        /// </summary>
        [Inline]
        public static double2 Step(double2 v) => double2.Step(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Sqrt ((double)System.Math.Sqrt((double)v)).
        /// </summary>
        [Inline]
        public static double2 Sqrt(double2 v) => double2.Sqrt(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of InverseSqrt ((double)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        [Inline]
        public static double2 InverseSqrt(double2 v) => double2.InverseSqrt(v);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Sign (System.Math.Sign(v)).
        /// </summary>
        [Inline]
        public static int2 Sign(double2 v) => double2.Sign(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        [Inline]
        public static double2 Max(double2 lhs, double2 rhs) => double2.Max(lhs, rhs);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        [Inline]
        public static double2 Min(double2 lhs, double2 rhs) => double2.Min(lhs, rhs);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Pow ((double)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static double2 Pow(double2 lhs, double2 rhs) => double2.Pow(lhs, rhs);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Log ((double)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static double2 Log(double2 lhs, double2 rhs) => double2.Log(lhs, rhs);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        [Inline]
        public static double2 Clamp(double2 v, double2 min, double2 max) => double2.Clamp(v, min, max);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static double2 Mix(double2 min, double2 max, double2 a) => double2.Mix(min, max, a);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static double2 Lerp(double2 min, double2 max, double2 a) => double2.Lerp(min, max, a);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Fma (a * b + c).
        /// </summary>
        [Inline]
        public static double2 Fma(double2 a, double2 b, double2 c) => double2.Fma(a, b, c);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static double2x2 OuterProduct(double2 c, double2 r) => double2.OuterProduct(c, r);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static double3x2 OuterProduct(double2 c, double3 r) => double2.OuterProduct(c, r);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static double4x2 OuterProduct(double2 c, double4 r) => double2.OuterProduct(c, r);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Add (lhs + rhs).
        /// </summary>
        [Inline]
        public static double2 Add(double2 lhs, double2 rhs) => double2.Add(lhs, rhs);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        [Inline]
        public static double2 Sub(double2 lhs, double2 rhs) => double2.Sub(lhs, rhs);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        [Inline]
        public static double2 Mul(double2 lhs, double2 rhs) => double2.Mul(lhs, rhs);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Div (lhs / rhs).
        /// </summary>
        [Inline]
        public static double2 Div(double2 lhs, double2 rhs) => double2.Div(lhs, rhs);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        [Inline]
        public static double2 Modulo(double2 lhs, double2 rhs) => double2.Modulo(lhs, rhs);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Degrees (Radians-To-Degrees Conversion).
        /// </summary>
        [Inline]
        public static double2 Degrees(double2 v) => double2.Degrees(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Radians (Degrees-To-Radians Conversion).
        /// </summary>
        [Inline]
        public static double2 Radians(double2 v) => double2.Radians(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Acos (System.Math.Acos(v)).
        /// </summary>
        [Inline]
        public static double2 Acos(double2 v) => double2.Acos(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Asin (System.Math.Asin(v)).
        /// </summary>
        [Inline]
        public static double2 Asin(double2 v) => double2.Asin(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Atan (System.Math.Atan(v)).
        /// </summary>
        [Inline]
        public static double2 Atan(double2 v) => double2.Atan(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Cos (System.Math.Cos(v)).
        /// </summary>
        [Inline]
        public static double2 Cos(double2 v) => double2.Cos(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Cosh (System.Math.Cosh(v)).
        /// </summary>
        [Inline]
        public static double2 Cosh(double2 v) => double2.Cosh(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Exp (System.Math.Exp(v)).
        /// </summary>
        [Inline]
        public static double2 Exp(double2 v) => double2.Exp(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Log (System.Math.Log(v)).
        /// </summary>
        [Inline]
        public static double2 Log(double2 v) => double2.Log(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Log2 (System.Math.Log(v, 2)).
        /// </summary>
        [Inline]
        public static double2 Log2(double2 v) => double2.Log2(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Log10 (System.Math.Log10(v)).
        /// </summary>
        [Inline]
        public static double2 Log10(double2 v) => double2.Log10(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Floor (System.Math.Floor(v)).
        /// </summary>
        [Inline]
        public static double2 Floor(double2 v) => double2.Floor(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Ceiling (System.Math.Ceiling(v)).
        /// </summary>
        [Inline]
        public static double2 Ceiling(double2 v) => double2.Ceiling(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Round (System.Math.Round(v)).
        /// </summary>
        [Inline]
        public static double2 Round(double2 v) => double2.Round(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Sin (System.Math.Sin(v)).
        /// </summary>
        [Inline]
        public static double2 Sin(double2 v) => double2.Sin(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Sinh (System.Math.Sinh(v)).
        /// </summary>
        [Inline]
        public static double2 Sinh(double2 v) => double2.Sinh(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Tan (System.Math.Tan(v)).
        /// </summary>
        [Inline]
        public static double2 Tan(double2 v) => double2.Tan(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Tanh (System.Math.Tanh(v)).
        /// </summary>
        [Inline]
        public static double2 Tanh(double2 v) => double2.Tanh(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Truncate (System.Math.Truncate(v)).
        /// </summary>
        [Inline]
        public static double2 Truncate(double2 v) => double2.Truncate(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Fract ((v - System.Math.Floor(v))).
        /// </summary>
        [Inline]
        public static double2 Fract(double2 v) => double2.Fract(v);
        
        /// <summary>
        /// Returns a double2 from component-wise application of TruncateFast ((int64)(v)).
        /// </summary>
        [Inline]
        public static double2 TruncateFast(double2 v) => double2.TruncateFast(v);
        
        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        [Inline]
        public static double MinElement(double2 v) => v.MinElement;
        
        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        [Inline]
        public static double MaxElement(double2 v) => v.MaxElement;
        
        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        [Inline]
        public static double Length(double2 v) => v.Length;
        
        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        [Inline]
        public static double LengthSqr(double2 v) => v.LengthSqr;
        
        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        [Inline]
        public static double Sum(double2 v) => v.Sum;
        
        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        [Inline]
        public static double Norm(double2 v) => v.Norm;
        
        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        [Inline]
        public static double Norm1(double2 v) => v.Norm1;
        
        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        [Inline]
        public static double Norm2(double2 v) => v.Norm2;
        
        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        [Inline]
        public static double NormMax(double2 v) => v.NormMax;
        
        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        [Inline]
        public static double NormP(double2 v, double p) => v.NormP(p);
        
        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        [Inline]
        public static double2 Normalized(double2 v) => v.Normalized;
        
        /// <summary>
        /// Returns a copy of this vector with length one (returns zero if length is zero).
        /// </summary>
        [Inline]
        public static double2 NormalizedSafe(double2 v) => v.NormalizedSafe;
        
        /// <summary>
        /// Returns the vector angle (atan2(y, x)) in radians.
        /// </summary>
        [Inline]
        public static double Angle(double2 v) => v.Angle;
        
        /// <summary>
        /// Returns a 2D vector that was rotated by a given angle in radians (CAUTION: result is casted and may be truncated).
        /// </summary>
        [Inline]
        public static double2 Rotated(double2 v, double angleInRad) => v.Rotated(angleInRad);
        
        /// <summary>
        /// Returns a perpendicular vector.
        /// </summary>
        [Inline]
        public static double2 Perpendicular(double2 v) => v.Perpendicular;
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        [Inline]
        public static double Dot(double2 lhs, double2 rhs) => double2.Dot(lhs, rhs);
        
        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        [Inline]
        public static double Distance(double2 lhs, double2 rhs) => double2.Distance(lhs, rhs);
        
        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        [Inline]
        public static double DistanceSqr(double2 lhs, double2 rhs) => double2.DistanceSqr(lhs, rhs);
        
        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        [Inline]
        public static double2 Reflect(double2 I, double2 N) => double2.Reflect(I, N);
        
        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        [Inline]
        public static double2 Refract(double2 I, double2 N, double eta) => double2.Refract(I, N, eta);
        
        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        [Inline]
        public static double2 FaceForward(double2 N, double2 I, double2 Nref) => double2.FaceForward(N, I, Nref);
        
        /// <summary>
        /// Returns the length of the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        [Inline]
        public static double Cross(double2 l, double2 r) => double2.Cross(l, r);
        
        /// <summary>
        /// Returns a double2 with independent and identically distributed uniform values between 'minValue' and 'maxValue'.
        /// </summary>
        [Inline]
        public static double2 Random(Random random, double2 minValue, double2 maxValue) => double2.Random(random, minValue, maxValue);
        
        /// <summary>
        /// Returns a double2 with independent and identically distributed uniform values between 'minValue' and 'maxValue'.
        /// </summary>
        [Inline]
        public static double2 RandomUniform(Random random, double2 minValue, double2 maxValue) => double2.RandomUniform(random, minValue, maxValue);
        
        /// <summary>
        /// Returns a double2 with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance.
        /// </summary>
        [Inline]
        public static double2 RandomNormal(Random random, double2 mean, double2 variance) => double2.RandomNormal(random, mean, variance);
        
        /// <summary>
        /// Returns a double2 with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance.
        /// </summary>
        [Inline]
        public static double2 RandomGaussian(Random random, double2 mean, double2 variance) => double2.RandomGaussian(random, mean, variance);

    }
}
