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
        public static double[] ToArray(double3 v) => v.ToArray();
        
        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        [Inline]
        public static void ToString(double3 v, String stringBuffer) => v.ToString(stringBuffer);
        
        /// <summary>
        /// Returns a string representation of this vector using a provided seperator.
        /// </summary>
        [Inline]
        public static void ToString(double3 v, String stringBuffer, String sep) => v.ToString(stringBuffer, sep);
        
        /// <summary>
        /// Returns the number of components (3).
        /// </summary>
        [Inline]
        public static int Count(double3 v) => v.Count;
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        [Inline]
        public static int GetHashCode(double3 v) => v.GetHashCode();
        
        /// <summary>
        /// Returns true iff distance between lhs and rhs is less than or equal to epsilon
        /// </summary>
        [Inline]
        public static bool ApproxEqual(double3 lhs, double3 rhs, double eps = 0.1d) => double3.ApproxEqual(lhs, rhs, eps);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool3 Equal(double3 lhs, double3 rhs) => double3.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool Equal(double lhs, double rhs) => lhs == rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool3 NotEqual(double3 lhs, double3 rhs) => double3.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool NotEqual(double lhs, double rhs) => lhs != rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        [Inline]
        public static bool3 GreaterThan(double3 lhs, double3 rhs) => double3.GreaterThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        [Inline]
        public static bool GreaterThan(double lhs, double rhs) => lhs > rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        [Inline]
        public static bool3 GreaterThanEqual(double3 lhs, double3 rhs) => double3.GreaterThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        [Inline]
        public static bool GreaterThanEqual(double lhs, double rhs) => lhs >= rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        [Inline]
        public static bool3 LesserThan(double3 lhs, double3 rhs) => double3.LesserThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        [Inline]
        public static bool LesserThan(double lhs, double rhs) => lhs < rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        [Inline]
        public static bool3 LesserThanEqual(double3 lhs, double3 rhs) => double3.LesserThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        [Inline]
        public static bool LesserThanEqual(double lhs, double rhs) => lhs <= rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of IsInfinity (v.IsInfinity).
        /// </summary>
        [Inline]
        public static bool3 IsInfinity(double3 v) => double3.IsInfinity(v);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of IsInfinity (v.IsInfinity).
        /// </summary>
        [Inline]
        public static bool IsInfinity(double v) => v.IsInfinity;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of IsNaN (v.IsNaN).
        /// </summary>
        [Inline]
        public static bool3 IsNaN(double3 v) => double3.IsNaN(v);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of IsNaN (v.IsNaN).
        /// </summary>
        [Inline]
        public static bool IsNaN(double v) => v.IsNaN;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of IsNegativeInfinity (v.IsNegativeInfinity).
        /// </summary>
        [Inline]
        public static bool3 IsNegativeInfinity(double3 v) => double3.IsNegativeInfinity(v);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of IsNegativeInfinity (v.IsNegativeInfinity).
        /// </summary>
        [Inline]
        public static bool IsNegativeInfinity(double v) => v.IsNegativeInfinity;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of IsPositiveInfinity (v.IsPositiveInfinity).
        /// </summary>
        [Inline]
        public static bool3 IsPositiveInfinity(double3 v) => double3.IsPositiveInfinity(v);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of IsPositiveInfinity (v.IsPositiveInfinity).
        /// </summary>
        [Inline]
        public static bool IsPositiveInfinity(double v) => v.IsPositiveInfinity;
        
        /// <summary>
        /// Returns a double3 from component-wise application of Abs (System.Math.Abs(v)).
        /// </summary>
        [Inline]
        public static double3 Abs(double3 v) => double3.Abs(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Abs (System.Math.Abs(v)).
        /// </summary>
        [Inline]
        public static double Abs(double v) => System.Math.Abs(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        [Inline]
        public static double3 HermiteInterpolationOrder3(double3 v) => double3.HermiteInterpolationOrder3(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        [Inline]
        public static double HermiteInterpolationOrder3(double v) => (3 - 2 * v) * v * v;
        
        /// <summary>
        /// Returns a double3 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        [Inline]
        public static double3 HermiteInterpolationOrder5(double3 v) => double3.HermiteInterpolationOrder5(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        [Inline]
        public static double HermiteInterpolationOrder5(double v) => ((6 * v - 15) * v + 10) * v * v * v;
        
        /// <summary>
        /// Returns a double3 from component-wise application of Sqr (v * v).
        /// </summary>
        [Inline]
        public static double3 Sqr(double3 v) => double3.Sqr(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Sqr (v * v).
        /// </summary>
        [Inline]
        public static double Sqr(double v) => v * v;
        
        /// <summary>
        /// Returns a double3 from component-wise application of Pow2 (v * v).
        /// </summary>
        [Inline]
        public static double3 Pow2(double3 v) => double3.Pow2(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Pow2 (v * v).
        /// </summary>
        [Inline]
        public static double Pow2(double v) => v * v;
        
        /// <summary>
        /// Returns a double3 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        [Inline]
        public static double3 Pow3(double3 v) => double3.Pow3(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        [Inline]
        public static double Pow3(double v) => v * v * v;
        
        /// <summary>
        /// Returns a double3 from component-wise application of Step (v &gt;= 0.0 ? 1.0 : 0.0).
        /// </summary>
        [Inline]
        public static double3 Step(double3 v) => double3.Step(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Step (v &gt;= 0.0 ? 1.0 : 0.0).
        /// </summary>
        [Inline]
        public static double Step(double v) => v >= 0.0 ? 1.0 : 0.0;
        
        /// <summary>
        /// Returns a double3 from component-wise application of Sqrt ((double)System.Math.Sqrt((double)v)).
        /// </summary>
        [Inline]
        public static double3 Sqrt(double3 v) => double3.Sqrt(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Sqrt ((double)System.Math.Sqrt((double)v)).
        /// </summary>
        [Inline]
        public static double Sqrt(double v) => (double)System.Math.Sqrt((double)v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of InverseSqrt ((double)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        [Inline]
        public static double3 InverseSqrt(double3 v) => double3.InverseSqrt(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of InverseSqrt ((double)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        [Inline]
        public static double InverseSqrt(double v) => (double)(1.0 / System.Math.Sqrt((double)v));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sign (System.Math.Sign(v)).
        /// </summary>
        [Inline]
        public static int3 Sign(double3 v) => double3.Sign(v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sign (System.Math.Sign(v)).
        /// </summary>
        [Inline]
        public static int Sign(double v) => System.Math.Sign(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        [Inline]
        public static double3 Max(double3 lhs, double3 rhs) => double3.Max(lhs, rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        [Inline]
        public static double Max(double lhs, double rhs) => System.Math.Max(lhs, rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        [Inline]
        public static double3 Min(double3 lhs, double3 rhs) => double3.Min(lhs, rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        [Inline]
        public static double Min(double lhs, double rhs) => System.Math.Min(lhs, rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Pow ((double)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static double3 Pow(double3 lhs, double3 rhs) => double3.Pow(lhs, rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Pow ((double)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static double Pow(double lhs, double rhs) => (double)System.Math.Pow((double)lhs, (double)rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Log ((double)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static double3 Log(double3 lhs, double3 rhs) => double3.Log(lhs, rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Log ((double)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        [Inline]
        public static double Log(double lhs, double rhs) => (double)System.Math.Log((double)lhs, (double)rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        [Inline]
        public static double3 Clamp(double3 v, double3 min, double3 max) => double3.Clamp(v, min, max);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        [Inline]
        public static double Clamp(double v, double min, double max) => System.Math.Min(System.Math.Max(v, min), max);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static double3 Mix(double3 min, double3 max, double3 a) => double3.Mix(min, max, a);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static double Mix(double min, double max, double a) => min * (1-a) + max * a;
        
        /// <summary>
        /// Returns a double3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static double3 Lerp(double3 min, double3 max, double3 a) => double3.Lerp(min, max, a);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        [Inline]
        public static double Lerp(double min, double max, double a) => min * (1-a) + max * a;
        
        /// <summary>
        /// Returns a double3 from component-wise application of Fma (a * b + c).
        /// </summary>
        [Inline]
        public static double3 Fma(double3 a, double3 b, double3 c) => double3.Fma(a, b, c);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Fma (a * b + c).
        /// </summary>
        [Inline]
        public static double Fma(double a, double b, double c) => a * b + c;
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static double2x3 OuterProduct(double3 c, double2 r) => double3.OuterProduct(c, r);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static double3x3 OuterProduct(double3 c, double3 r) => double3.OuterProduct(c, r);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        [Inline]
        public static double4x3 OuterProduct(double3 c, double4 r) => double3.OuterProduct(c, r);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        [Inline]
        public static double3 Add(double3 lhs, double3 rhs) => double3.Add(lhs, rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        [Inline]
        public static double Add(double lhs, double rhs) => lhs + rhs;
        
        /// <summary>
        /// Returns a double3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        [Inline]
        public static double3 Sub(double3 lhs, double3 rhs) => double3.Sub(lhs, rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        [Inline]
        public static double Sub(double lhs, double rhs) => lhs - rhs;
        
        /// <summary>
        /// Returns a double3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        [Inline]
        public static double3 Mul(double3 lhs, double3 rhs) => double3.Mul(lhs, rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        [Inline]
        public static double Mul(double lhs, double rhs) => lhs * rhs;
        
        /// <summary>
        /// Returns a double3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        [Inline]
        public static double3 Div(double3 lhs, double3 rhs) => double3.Div(lhs, rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        [Inline]
        public static double Div(double lhs, double rhs) => lhs / rhs;
        
        /// <summary>
        /// Returns a double3 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        [Inline]
        public static double3 Modulo(double3 lhs, double3 rhs) => double3.Modulo(lhs, rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        [Inline]
        public static double Modulo(double lhs, double rhs) => lhs % rhs;
        
        /// <summary>
        /// Returns a double3 from component-wise application of Degrees (Radians-To-Degrees Conversion).
        /// </summary>
        [Inline]
        public static double3 Degrees(double3 v) => double3.Degrees(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Degrees (Radians-To-Degrees Conversion).
        /// </summary>
        [Inline]
        public static double Degrees(double v) => (double)(v * 57.295779513082320876798154814105170332405472466564321d);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Radians (Degrees-To-Radians Conversion).
        /// </summary>
        [Inline]
        public static double3 Radians(double3 v) => double3.Radians(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Radians (Degrees-To-Radians Conversion).
        /// </summary>
        [Inline]
        public static double Radians(double v) => (double)(v * 0.0174532925199432957692369076848861271344287188854172d);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Acos (System.Math.Acos(v)).
        /// </summary>
        [Inline]
        public static double3 Acos(double3 v) => double3.Acos(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Acos (System.Math.Acos(v)).
        /// </summary>
        [Inline]
        public static double Acos(double v) => System.Math.Acos(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Asin (System.Math.Asin(v)).
        /// </summary>
        [Inline]
        public static double3 Asin(double3 v) => double3.Asin(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Asin (System.Math.Asin(v)).
        /// </summary>
        [Inline]
        public static double Asin(double v) => System.Math.Asin(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Atan (System.Math.Atan(v)).
        /// </summary>
        [Inline]
        public static double3 Atan(double3 v) => double3.Atan(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Atan (System.Math.Atan(v)).
        /// </summary>
        [Inline]
        public static double Atan(double v) => System.Math.Atan(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Cos (System.Math.Cos(v)).
        /// </summary>
        [Inline]
        public static double3 Cos(double3 v) => double3.Cos(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Cos (System.Math.Cos(v)).
        /// </summary>
        [Inline]
        public static double Cos(double v) => System.Math.Cos(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Cosh (System.Math.Cosh(v)).
        /// </summary>
        [Inline]
        public static double3 Cosh(double3 v) => double3.Cosh(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Cosh (System.Math.Cosh(v)).
        /// </summary>
        [Inline]
        public static double Cosh(double v) => System.Math.Cosh(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Exp (System.Math.Exp(v)).
        /// </summary>
        [Inline]
        public static double3 Exp(double3 v) => double3.Exp(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Exp (System.Math.Exp(v)).
        /// </summary>
        [Inline]
        public static double Exp(double v) => System.Math.Exp(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Log (System.Math.Log(v)).
        /// </summary>
        [Inline]
        public static double3 Log(double3 v) => double3.Log(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Log (System.Math.Log(v)).
        /// </summary>
        [Inline]
        public static double Log(double v) => System.Math.Log(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Log2 (System.Math.Log(v, 2)).
        /// </summary>
        [Inline]
        public static double3 Log2(double3 v) => double3.Log2(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Log2 (System.Math.Log(v, 2)).
        /// </summary>
        [Inline]
        public static double Log2(double v) => System.Math.Log(v, 2);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Log10 (System.Math.Log10(v)).
        /// </summary>
        [Inline]
        public static double3 Log10(double3 v) => double3.Log10(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Log10 (System.Math.Log10(v)).
        /// </summary>
        [Inline]
        public static double Log10(double v) => System.Math.Log10(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Floor (System.Math.Floor(v)).
        /// </summary>
        [Inline]
        public static double3 Floor(double3 v) => double3.Floor(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Floor (System.Math.Floor(v)).
        /// </summary>
        [Inline]
        public static double Floor(double v) => System.Math.Floor(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Ceiling (System.Math.Ceiling(v)).
        /// </summary>
        [Inline]
        public static double3 Ceiling(double3 v) => double3.Ceiling(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Ceiling (System.Math.Ceiling(v)).
        /// </summary>
        [Inline]
        public static double Ceiling(double v) => System.Math.Ceiling(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Round (System.Math.Round(v)).
        /// </summary>
        [Inline]
        public static double3 Round(double3 v) => double3.Round(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Round (System.Math.Round(v)).
        /// </summary>
        [Inline]
        public static double Round(double v) => System.Math.Round(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Sin (System.Math.Sin(v)).
        /// </summary>
        [Inline]
        public static double3 Sin(double3 v) => double3.Sin(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Sin (System.Math.Sin(v)).
        /// </summary>
        [Inline]
        public static double Sin(double v) => System.Math.Sin(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Sinh (System.Math.Sinh(v)).
        /// </summary>
        [Inline]
        public static double3 Sinh(double3 v) => double3.Sinh(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Sinh (System.Math.Sinh(v)).
        /// </summary>
        [Inline]
        public static double Sinh(double v) => System.Math.Sinh(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Tan (System.Math.Tan(v)).
        /// </summary>
        [Inline]
        public static double3 Tan(double3 v) => double3.Tan(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Tan (System.Math.Tan(v)).
        /// </summary>
        [Inline]
        public static double Tan(double v) => System.Math.Tan(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Tanh (System.Math.Tanh(v)).
        /// </summary>
        [Inline]
        public static double3 Tanh(double3 v) => double3.Tanh(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Tanh (System.Math.Tanh(v)).
        /// </summary>
        [Inline]
        public static double Tanh(double v) => System.Math.Tanh(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Truncate (System.Math.Truncate(v)).
        /// </summary>
        [Inline]
        public static double3 Truncate(double3 v) => double3.Truncate(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Truncate (System.Math.Truncate(v)).
        /// </summary>
        [Inline]
        public static double Truncate(double v) => System.Math.Truncate(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Fract ((v - System.Math.Floor(v))).
        /// </summary>
        [Inline]
        public static double3 Fract(double3 v) => double3.Fract(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Fract ((v - System.Math.Floor(v))).
        /// </summary>
        [Inline]
        public static double Fract(double v) => (v - System.Math.Floor(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of TruncateFast ((int64)(v)).
        /// </summary>
        [Inline]
        public static double3 TruncateFast(double3 v) => double3.TruncateFast(v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of TruncateFast ((int64)(v)).
        /// </summary>
        [Inline]
        public static double TruncateFast(double v) => (int64)(v);
        
        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        [Inline]
        public static double MinElement(double3 v) => v.MinElement;
        
        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        [Inline]
        public static double MaxElement(double3 v) => v.MaxElement;
        
        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        [Inline]
        public static double Length(double3 v) => v.Length;
        
        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        [Inline]
        public static double LengthSqr(double3 v) => v.LengthSqr;
        
        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        [Inline]
        public static double Sum(double3 v) => v.Sum;
        
        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        [Inline]
        public static double Norm(double3 v) => v.Norm;
        
        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        [Inline]
        public static double Norm1(double3 v) => v.Norm1;
        
        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        [Inline]
        public static double Norm2(double3 v) => v.Norm2;
        
        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        [Inline]
        public static double NormMax(double3 v) => v.NormMax;
        
        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        [Inline]
        public static double NormP(double3 v, double p) => v.NormP(p);
        
        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        [Inline]
        public static double3 Normalized(double3 v) => v.Normalized;
        
        /// <summary>
        /// Returns a copy of this vector with length one (returns zero if length is zero).
        /// </summary>
        [Inline]
        public static double3 NormalizedSafe(double3 v) => v.NormalizedSafe;
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        [Inline]
        public static double Dot(double3 lhs, double3 rhs) => double3.Dot(lhs, rhs);
        
        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        [Inline]
        public static double Distance(double3 lhs, double3 rhs) => double3.Distance(lhs, rhs);
        
        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        [Inline]
        public static double DistanceSqr(double3 lhs, double3 rhs) => double3.DistanceSqr(lhs, rhs);
        
        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        [Inline]
        public static double3 Reflect(double3 I, double3 N) => double3.Reflect(I, N);
        
        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        [Inline]
        public static double3 Refract(double3 I, double3 N, double eta) => double3.Refract(I, N, eta);
        
        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        [Inline]
        public static double3 FaceForward(double3 N, double3 I, double3 Nref) => double3.FaceForward(N, I, Nref);
        
        /// <summary>
        /// Returns the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        [Inline]
        public static double3 Cross(double3 l, double3 r) => double3.Cross(l, r);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed uniform values between 'minValue' and 'maxValue'.
        /// </summary>
        [Inline]
        public static double3 Random(Random random, double3 minValue, double3 maxValue) => double3.Random(random, minValue, maxValue);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed uniform values between 'minValue' and 'maxValue'.
        /// </summary>
        [Inline]
        public static double Random(Random random, double minValue, double maxValue) => (double)random.NextDouble() * (maxValue - minValue) + minValue;
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed uniform values between 'minValue' and 'maxValue'.
        /// </summary>
        [Inline]
        public static double3 RandomUniform(Random random, double3 minValue, double3 maxValue) => double3.RandomUniform(random, minValue, maxValue);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed uniform values between 'minValue' and 'maxValue'.
        /// </summary>
        [Inline]
        public static double RandomUniform(Random random, double minValue, double maxValue) => (double)random.NextDouble() * (maxValue - minValue) + minValue;
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance.
        /// </summary>
        [Inline]
        public static double3 RandomNormal(Random random, double3 mean, double3 variance) => double3.RandomNormal(random, mean, variance);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance.
        /// </summary>
        [Inline]
        public static double RandomNormal(Random random, double mean, double variance) => (double)(System.Math.Sqrt((double)variance) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean;
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance.
        /// </summary>
        [Inline]
        public static double3 RandomGaussian(Random random, double3 mean, double3 variance) => double3.RandomGaussian(random, mean, variance);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance.
        /// </summary>
        [Inline]
        public static double RandomGaussian(Random random, double mean, double variance) => (double)(System.Math.Sqrt((double)variance) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean;

    }
}
