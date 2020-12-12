using System;
namespace Atma
{
    
    /// <summary>
    /// A vector of type uint with 2 components.
    /// </summary>
    [Union]
    public struct uint2 : IHashable
    {

        //#region Fields
        
        /// <summary>
        /// component data
        /// </summary>
        public uint[2] values;
        
        /// <summary>
        /// Returns an object that can be used for arbitrary swizzling (e.g. swizzle.zy)
        /// </summary>
        public readonly swizzle_uint2 swizzle;

        //#endregion


        //#region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public this(uint x, uint y)
        {
            values = .(x,y);
        }
        
        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public this(uint v)
        {
            values = .(v,v);
        }
        
        /// <summary>
        /// from-vector constructor
        /// </summary>
        public this(uint2 v)
        {
            values = .(v.x,v.y);
        }
        
        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public this(uint3 v)
        {
            values = .(v.x,v.y);
        }
        
        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public this(uint4 v)
        {
            values = .(v.x,v.y);
        }
        
        /// <summary>
        /// From-array constructor (superfluous values are ignored, missing values are zero-filled).
        /// </summary>
        public this(uint[] v)
        {
            let c = v.Count;
            values = .((c < 0) ? 0u : v[0],(c < 1) ? 0u : v[1]);
        }
        
        /// <summary>
        /// From-array constructor with base index (superfluous values are ignored, missing values are zero-filled).
        /// </summary>
        public this(uint[] v, int startIndex)
        {
            let c = v.Count;
            values = .((c + startIndex < 0) ? 0u : v[0 + startIndex],(c + startIndex < 1) ? 0u : v[1 + startIndex]);
        }

        //#endregion


        //#region Implicit Operators
        
        /// <summary>
        /// Implicitly converts this to a long2.
        /// </summary>
        public static implicit operator long2(uint2 v) =>  long2((long)v.x, (long)v.y);
        
        /// <summary>
        /// Implicitly converts this to a float2.
        /// </summary>
        public static implicit operator float2(uint2 v) =>  float2((float)v.x, (float)v.y);
        
        /// <summary>
        /// Implicitly converts this to a double2.
        /// </summary>
        public static implicit operator double2(uint2 v) =>  double2((double)v.x, (double)v.y);

        //#endregion


        //#region Explicit Operators
        
        /// <summary>
        /// Explicitly converts this to a int2.
        /// </summary>
        public static explicit operator int2(uint2 v) =>  int2((int)v.x, (int)v.y);
        
        /// <summary>
        /// Explicitly converts this to a int3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator int3(uint2 v) =>  int3((int)v.x, (int)v.y, 0);
        
        /// <summary>
        /// Explicitly converts this to a int4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator int4(uint2 v) =>  int4((int)v.x, (int)v.y, 0, 0);
        
        /// <summary>
        /// Explicitly converts this to a uint3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator uint3(uint2 v) =>  uint3((uint)v.x, (uint)v.y, 0u);
        
        /// <summary>
        /// Explicitly converts this to a uint4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator uint4(uint2 v) =>  uint4((uint)v.x, (uint)v.y, 0u, 0u);
        
        /// <summary>
        /// Explicitly converts this to a float3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator float3(uint2 v) =>  float3((float)v.x, (float)v.y, 0f);
        
        /// <summary>
        /// Explicitly converts this to a float4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator float4(uint2 v) =>  float4((float)v.x, (float)v.y, 0f, 0f);
        
        /// <summary>
        /// Explicitly converts this to a double3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator double3(uint2 v) =>  double3((double)v.x, (double)v.y, 0.0);
        
        /// <summary>
        /// Explicitly converts this to a double4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator double4(uint2 v) =>  double4((double)v.x, (double)v.y, 0.0, 0.0);
        
        /// <summary>
        /// Explicitly converts this to a long3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator long3(uint2 v) =>  long3((long)v.x, (long)v.y, 0);
        
        /// <summary>
        /// Explicitly converts this to a long4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator long4(uint2 v) =>  long4((long)v.x, (long)v.y, 0, 0);
        
        /// <summary>
        /// Explicitly converts this to a bool2.
        /// </summary>
        public static explicit operator bool2(uint2 v) =>  bool2(v.x != 0u, v.y != 0u);
        
        /// <summary>
        /// Explicitly converts this to a bool3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator bool3(uint2 v) =>  bool3(v.x != 0u, v.y != 0u, false);
        
        /// <summary>
        /// Explicitly converts this to a bool4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator bool4(uint2 v) =>  bool4(v.x != 0u, v.y != 0u, false, false);

        //#endregion


        //#region Indexer
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public uint this[int index]
        {
            [Inline]get
            {
                System.Diagnostics.Debug.Assert(index >=0 && index < 2, "index out of range");
                unchecked { return values[index]; }
            }
            [Inline]set mut
            {
                System.Diagnostics.Debug.Assert(index >=0 && index < 2, "index out of range");
                unchecked { values[index] = value;}
            }
        }

        //#endregion


        //#region Properties
        
        /// <summary>
        /// x-component
        /// </summary>
        public uint x
        {
            [Inline]get
            {
                return values[0];
            }
            [Inline]set mut
            {
                values[0] = value;
            }
        }
        
        /// <summary>
        /// y-component
        /// </summary>
        public uint y
        {
            [Inline]get
            {
                return values[1];
            }
            [Inline]set mut
            {
                values[1] = value;
            }
        }
        
        /// <summary>
        /// 0-component
        /// </summary>
        public uint width
        {
            [Inline]get
            {
                return values[0];
            }
            [Inline]set mut
            {
                values[0] = value;
            }
        }
        
        /// <summary>
        /// 1-component
        /// </summary>
        public uint height
        {
            [Inline]get
            {
                return values[1];
            }
            [Inline]set mut
            {
                values[1] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public uint2 xy
        {
            [Inline]get
            {
                return  uint2(x, y);
            }
            [Inline]set mut
            {
                x = value.x;
                y = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public uint2 rg
        {
            [Inline]get
            {
                return  uint2(x, y);
            }
            [Inline]set mut
            {
                x = value.x;
                y = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified RGBA component. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public uint r
        {
            [Inline]get
            {
                return x;
            }
            [Inline]set mut
            {
                x = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified RGBA component. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public uint g
        {
            [Inline]get
            {
                return y;
            }
            [Inline]set mut
            {
                y = value;
            }
        }
        
        /// <summary>
        /// Returns the number of components (2).
        /// </summary>
        public int Count => 2;
        
        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        public uint MinElement => System.Math.Min(x, y);
        
        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public uint MaxElement => System.Math.Max(x, y);
        
        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public float Length => (float)System.Math.Sqrt((x*x + y*y));
        
        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        public float LengthSqr => (x*x + y*y);
        
        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        public uint Sum => (x + y);
        
        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public float Norm => (float)System.Math.Sqrt((x*x + y*y));
        
        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public float Norm1 => (x + y);
        
        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        public float Norm2 => (float)System.Math.Sqrt((x*x + y*y));
        
        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public float NormMax => System.Math.Max(x, y);

        //#endregion


        //#region Static Properties
        
        /// <summary>
        /// Predefined all-zero vector
        /// </summary>
        readonly public static uint2 Zero  =  uint2(0u, 0u);
        
        /// <summary>
        /// Predefined all-ones vector
        /// </summary>
        readonly public static uint2 Ones  =  uint2(1u, 1u);
        
        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        readonly public static uint2 UnitX  =  uint2(1u, 0u);
        
        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        readonly public static uint2 UnitY  =  uint2(0u, 1u);
        
        /// <summary>
        /// Predefined all-MaxValue vector
        /// </summary>
        readonly public static uint2 MaxValue  =  uint2(uint.MaxValue, uint.MaxValue);
        
        /// <summary>
        /// Predefined all-MinValue vector
        /// </summary>
        readonly public static uint2 MinValue  =  uint2(uint.MinValue, uint.MinValue);

        //#endregion


        //#region Operators
        
        /// <summary>
        /// Returns true if this equals rhs component-wise.
        /// </summary>
        public static bool operator==(uint2 lhs, uint2 rhs) => (lhs.x == rhs.x && lhs.y == rhs.y);
        
        /// <summary>
        /// Returns true if this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator!=(uint2 lhs, uint2 rhs) => !(lhs.x == rhs.x && lhs.y == rhs.y);

        //#endregion


        //#region Functions
        
        /// <summary>
        /// Returns an array with all values
        /// </summary>
        public uint[] ToArray() => new .[] ( x, y );
        
        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public override void ToString(String stringBuffer) => ToString(stringBuffer, ", ");
        
        /// <summary>
        /// Returns a string representation of this vector using a provided seperator.
        /// </summary>
        public void ToString(String stringBuffer, String sep)
        {
            let _x = scope String(); values[0].ToString(_x);
            let _y = scope String(); values[1].ToString(_y);
             stringBuffer.Join(sep, _x,_y );
        }
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public int GetHashCode()
        {
            unchecked
            {
                return ((x.GetHashCode()) * 397) ^ y.GetHashCode();
            }
        }
        
        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        public double NormP(double p) => System.Math.Pow((System.Math.Pow((double)x, p) + System.Math.Pow((double)y, p)), 1 / p);

        //#endregion


        //#region Static Functions
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint2x2 OuterProduct(uint2 c, uint2 r) =>  uint2x2(c.x * r.x, c.y * r.x, c.x * r.y, c.y * r.y);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint2x3 OuterProduct(uint3 c, uint2 r) =>  uint2x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint3x2 OuterProduct(uint2 c, uint3 r) =>  uint3x2(c.x * r.x, c.y * r.x, c.x * r.y, c.y * r.y, c.x * r.z, c.y * r.z);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint2x4 OuterProduct(uint4 c, uint2 r) =>  uint2x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint4x2 OuterProduct(uint2 c, uint4 r) =>  uint4x2(c.x * r.x, c.y * r.x, c.x * r.y, c.y * r.y, c.x * r.z, c.y * r.z, c.x * r.w, c.y * r.w);
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static uint Dot(uint2 lhs, uint2 rhs) => (lhs.x * rhs.x + lhs.y * rhs.y);
        
        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static float Distance(uint2 lhs, uint2 rhs) => (lhs - rhs).Length;
        
        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static float DistanceSqr(uint2 lhs, uint2 rhs) => (lhs - rhs).LengthSqr;
        
        /// <summary>
        /// Returns the length of the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        public static uint Cross(uint2 l, uint2 r) => l.x * r.y - l.y * r.x;
        
        /// <summary>
        /// Returns a uint2 with independent and identically distributed uniform integer values between 0 (inclusive) and int.MaxValue (exclusive).
        /// </summary>
        public static uint2 Random(Random random) =>  uint2((uint)random.Next(int64.MaxValue), (uint)random.Next(int64.MaxValue));

        //#endregion


        //#region Component-Wise Static Functions
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(uint2 lhs, uint2 rhs) => bool2(lhs.x == rhs.x, lhs.y == rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(uint2 lhs, uint rhs) => bool2(lhs.x == rhs, lhs.y == rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(uint lhs, uint2 rhs) => bool2(lhs == rhs.x, lhs == rhs.y);
        
        /// <summary>
        /// Returns a bool from the application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(uint lhs, uint rhs) => bool2(lhs == rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(uint2 lhs, uint2 rhs) => bool2(lhs.x != rhs.x, lhs.y != rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(uint2 lhs, uint rhs) => bool2(lhs.x != rhs, lhs.y != rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(uint lhs, uint2 rhs) => bool2(lhs != rhs.x, lhs != rhs.y);
        
        /// <summary>
        /// Returns a bool from the application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(uint lhs, uint rhs) => bool2(lhs != rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(uint2 lhs, uint2 rhs) => bool2(lhs.x > rhs.x, lhs.y > rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(uint2 lhs, uint rhs) => bool2(lhs.x > rhs, lhs.y > rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(uint lhs, uint2 rhs) => bool2(lhs > rhs.x, lhs > rhs.y);
        
        /// <summary>
        /// Returns a bool from the application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(uint lhs, uint rhs) => bool2(lhs > rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(uint2 lhs, uint2 rhs) => bool2(lhs.x >= rhs.x, lhs.y >= rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(uint2 lhs, uint rhs) => bool2(lhs.x >= rhs, lhs.y >= rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(uint lhs, uint2 rhs) => bool2(lhs >= rhs.x, lhs >= rhs.y);
        
        /// <summary>
        /// Returns a bool from the application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(uint lhs, uint rhs) => bool2(lhs >= rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(uint2 lhs, uint2 rhs) => bool2(lhs.x < rhs.x, lhs.y < rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(uint2 lhs, uint rhs) => bool2(lhs.x < rhs, lhs.y < rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(uint lhs, uint2 rhs) => bool2(lhs < rhs.x, lhs < rhs.y);
        
        /// <summary>
        /// Returns a bool from the application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(uint lhs, uint rhs) => bool2(lhs < rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(uint2 lhs, uint2 rhs) => bool2(lhs.x <= rhs.x, lhs.y <= rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(uint2 lhs, uint rhs) => bool2(lhs.x <= rhs, lhs.y <= rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(uint lhs, uint2 rhs) => bool2(lhs <= rhs.x, lhs <= rhs.y);
        
        /// <summary>
        /// Returns a bool from the application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(uint lhs, uint rhs) => bool2(lhs <= rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Abs (v).
        /// </summary>
        public static uint2 Abs(uint2 v) => uint2(v.x, v.y);
        
        /// <summary>
        /// Returns a uint from the application of Abs (v).
        /// </summary>
        public static uint2 Abs(uint v) => uint2(v);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static uint2 HermiteInterpolationOrder3(uint2 v) => uint2((3 - 2 * v.x) * v.x * v.x, (3 - 2 * v.y) * v.y * v.y);
        
        /// <summary>
        /// Returns a uint from the application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static uint2 HermiteInterpolationOrder3(uint v) => uint2((3 - 2 * v) * v * v);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static uint2 HermiteInterpolationOrder5(uint2 v) => uint2(((6 * v.x - 15) * v.x + 10) * v.x * v.x * v.x, ((6 * v.y - 15) * v.y + 10) * v.y * v.y * v.y);
        
        /// <summary>
        /// Returns a uint from the application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static uint2 HermiteInterpolationOrder5(uint v) => uint2(((6 * v - 15) * v + 10) * v * v * v);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Sqr (v * v).
        /// </summary>
        public static uint2 Sqr(uint2 v) => uint2(v.x * v.x, v.y * v.y);
        
        /// <summary>
        /// Returns a uint from the application of Sqr (v * v).
        /// </summary>
        public static uint2 Sqr(uint v) => uint2(v * v);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static uint2 Pow2(uint2 v) => uint2(v.x * v.x, v.y * v.y);
        
        /// <summary>
        /// Returns a uint from the application of Pow2 (v * v).
        /// </summary>
        public static uint2 Pow2(uint v) => uint2(v * v);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static uint2 Pow3(uint2 v) => uint2(v.x * v.x * v.x, v.y * v.y * v.y);
        
        /// <summary>
        /// Returns a uint from the application of Pow3 (v * v * v).
        /// </summary>
        public static uint2 Pow3(uint v) => uint2(v * v * v);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Step (v &gt;= 0u ? 1u : 0u).
        /// </summary>
        public static uint2 Step(uint2 v) => uint2(v.x >= 0u ? 1u : 0u, v.y >= 0u ? 1u : 0u);
        
        /// <summary>
        /// Returns a uint from the application of Step (v &gt;= 0u ? 1u : 0u).
        /// </summary>
        public static uint2 Step(uint v) => uint2(v >= 0u ? 1u : 0u);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Sqrt ((uint)System.Math.Sqrt((double)v)).
        /// </summary>
        public static uint2 Sqrt(uint2 v) => uint2((uint)System.Math.Sqrt((double)v.x), (uint)System.Math.Sqrt((double)v.y));
        
        /// <summary>
        /// Returns a uint from the application of Sqrt ((uint)System.Math.Sqrt((double)v)).
        /// </summary>
        public static uint2 Sqrt(uint v) => uint2((uint)System.Math.Sqrt((double)v));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of InverseSqrt ((uint)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        public static uint2 InverseSqrt(uint2 v) => uint2((uint)(1.0 / System.Math.Sqrt((double)v.x)), (uint)(1.0 / System.Math.Sqrt((double)v.y)));
        
        /// <summary>
        /// Returns a uint from the application of InverseSqrt ((uint)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        public static uint2 InverseSqrt(uint v) => uint2((uint)(1.0 / System.Math.Sqrt((double)v)));
        
        /// <summary>
        /// Returns a int2 from component-wise application of Sign (System.Math.Sign(v)).
        /// </summary>
        public static int2 Sign(uint2 v) => int2(System.Math.Sign(v.x), System.Math.Sign(v.y));
        
        /// <summary>
        /// Returns a int from the application of Sign (System.Math.Sign(v)).
        /// </summary>
        public static int2 Sign(uint v) => int2(System.Math.Sign(v));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static uint2 Max(uint2 lhs, uint2 rhs) => uint2(System.Math.Max(lhs.x, rhs.x), System.Math.Max(lhs.y, rhs.y));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static uint2 Max(uint2 lhs, uint rhs) => uint2(System.Math.Max(lhs.x, rhs), System.Math.Max(lhs.y, rhs));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static uint2 Max(uint lhs, uint2 rhs) => uint2(System.Math.Max(lhs, rhs.x), System.Math.Max(lhs, rhs.y));
        
        /// <summary>
        /// Returns a uint from the application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static uint2 Max(uint lhs, uint rhs) => uint2(System.Math.Max(lhs, rhs));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static uint2 Min(uint2 lhs, uint2 rhs) => uint2(System.Math.Min(lhs.x, rhs.x), System.Math.Min(lhs.y, rhs.y));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static uint2 Min(uint2 lhs, uint rhs) => uint2(System.Math.Min(lhs.x, rhs), System.Math.Min(lhs.y, rhs));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static uint2 Min(uint lhs, uint2 rhs) => uint2(System.Math.Min(lhs, rhs.x), System.Math.Min(lhs, rhs.y));
        
        /// <summary>
        /// Returns a uint from the application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static uint2 Min(uint lhs, uint rhs) => uint2(System.Math.Min(lhs, rhs));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Pow ((uint)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static uint2 Pow(uint2 lhs, uint2 rhs) => uint2((uint)System.Math.Pow((double)lhs.x, (double)rhs.x), (uint)System.Math.Pow((double)lhs.y, (double)rhs.y));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Pow ((uint)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static uint2 Pow(uint2 lhs, uint rhs) => uint2((uint)System.Math.Pow((double)lhs.x, (double)rhs), (uint)System.Math.Pow((double)lhs.y, (double)rhs));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Pow ((uint)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static uint2 Pow(uint lhs, uint2 rhs) => uint2((uint)System.Math.Pow((double)lhs, (double)rhs.x), (uint)System.Math.Pow((double)lhs, (double)rhs.y));
        
        /// <summary>
        /// Returns a uint from the application of Pow ((uint)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static uint2 Pow(uint lhs, uint rhs) => uint2((uint)System.Math.Pow((double)lhs, (double)rhs));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Log ((uint)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static uint2 Log(uint2 lhs, uint2 rhs) => uint2((uint)System.Math.Log((double)lhs.x, (double)rhs.x), (uint)System.Math.Log((double)lhs.y, (double)rhs.y));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Log ((uint)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static uint2 Log(uint2 lhs, uint rhs) => uint2((uint)System.Math.Log((double)lhs.x, (double)rhs), (uint)System.Math.Log((double)lhs.y, (double)rhs));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Log ((uint)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static uint2 Log(uint lhs, uint2 rhs) => uint2((uint)System.Math.Log((double)lhs, (double)rhs.x), (uint)System.Math.Log((double)lhs, (double)rhs.y));
        
        /// <summary>
        /// Returns a uint from the application of Log ((uint)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static uint2 Log(uint lhs, uint rhs) => uint2((uint)System.Math.Log((double)lhs, (double)rhs));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static uint2 Clamp(uint2 v, uint2 min, uint2 max) => uint2(System.Math.Min(System.Math.Max(v.x, min.x), max.x), System.Math.Min(System.Math.Max(v.y, min.y), max.y));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static uint2 Clamp(uint2 v, uint2 min, uint max) => uint2(System.Math.Min(System.Math.Max(v.x, min.x), max), System.Math.Min(System.Math.Max(v.y, min.y), max));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static uint2 Clamp(uint2 v, uint min, uint2 max) => uint2(System.Math.Min(System.Math.Max(v.x, min), max.x), System.Math.Min(System.Math.Max(v.y, min), max.y));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static uint2 Clamp(uint2 v, uint min, uint max) => uint2(System.Math.Min(System.Math.Max(v.x, min), max), System.Math.Min(System.Math.Max(v.y, min), max));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static uint2 Clamp(uint v, uint2 min, uint2 max) => uint2(System.Math.Min(System.Math.Max(v, min.x), max.x), System.Math.Min(System.Math.Max(v, min.y), max.y));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static uint2 Clamp(uint v, uint2 min, uint max) => uint2(System.Math.Min(System.Math.Max(v, min.x), max), System.Math.Min(System.Math.Max(v, min.y), max));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static uint2 Clamp(uint v, uint min, uint2 max) => uint2(System.Math.Min(System.Math.Max(v, min), max.x), System.Math.Min(System.Math.Max(v, min), max.y));
        
        /// <summary>
        /// Returns a uint from the application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static uint2 Clamp(uint v, uint min, uint max) => uint2(System.Math.Min(System.Math.Max(v, min), max));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Mix(uint2 min, uint2 max, uint2 a) => uint2(min.x * (1-a.x) + max.x * a.x, min.y * (1-a.y) + max.y * a.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Mix(uint2 min, uint2 max, uint a) => uint2(min.x * (1-a) + max.x * a, min.y * (1-a) + max.y * a);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Mix(uint2 min, uint max, uint2 a) => uint2(min.x * (1-a.x) + max * a.x, min.y * (1-a.y) + max * a.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Mix(uint2 min, uint max, uint a) => uint2(min.x * (1-a) + max * a, min.y * (1-a) + max * a);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Mix(uint min, uint2 max, uint2 a) => uint2(min * (1-a.x) + max.x * a.x, min * (1-a.y) + max.y * a.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Mix(uint min, uint2 max, uint a) => uint2(min * (1-a) + max.x * a, min * (1-a) + max.y * a);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Mix(uint min, uint max, uint2 a) => uint2(min * (1-a.x) + max * a.x, min * (1-a.y) + max * a.y);
        
        /// <summary>
        /// Returns a uint from the application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Mix(uint min, uint max, uint a) => uint2(min * (1-a) + max * a);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Lerp(uint2 min, uint2 max, uint2 a) => uint2(min.x * (1-a.x) + max.x * a.x, min.y * (1-a.y) + max.y * a.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Lerp(uint2 min, uint2 max, uint a) => uint2(min.x * (1-a) + max.x * a, min.y * (1-a) + max.y * a);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Lerp(uint2 min, uint max, uint2 a) => uint2(min.x * (1-a.x) + max * a.x, min.y * (1-a.y) + max * a.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Lerp(uint2 min, uint max, uint a) => uint2(min.x * (1-a) + max * a, min.y * (1-a) + max * a);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Lerp(uint min, uint2 max, uint2 a) => uint2(min * (1-a.x) + max.x * a.x, min * (1-a.y) + max.y * a.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Lerp(uint min, uint2 max, uint a) => uint2(min * (1-a) + max.x * a, min * (1-a) + max.y * a);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Lerp(uint min, uint max, uint2 a) => uint2(min * (1-a.x) + max * a.x, min * (1-a.y) + max * a.y);
        
        /// <summary>
        /// Returns a uint from the application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Lerp(uint min, uint max, uint a) => uint2(min * (1-a) + max * a);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint2 Fma(uint2 a, uint2 b, uint2 c) => uint2(a.x * b.x + c.x, a.y * b.y + c.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint2 Fma(uint2 a, uint2 b, uint c) => uint2(a.x * b.x + c, a.y * b.y + c);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint2 Fma(uint2 a, uint b, uint2 c) => uint2(a.x * b + c.x, a.y * b + c.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint2 Fma(uint2 a, uint b, uint c) => uint2(a.x * b + c, a.y * b + c);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint2 Fma(uint a, uint2 b, uint2 c) => uint2(a * b.x + c.x, a * b.y + c.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint2 Fma(uint a, uint2 b, uint c) => uint2(a * b.x + c, a * b.y + c);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint2 Fma(uint a, uint b, uint2 c) => uint2(a * b + c.x, a * b + c.y);
        
        /// <summary>
        /// Returns a uint from the application of Fma (a * b + c).
        /// </summary>
        public static uint2 Fma(uint a, uint b, uint c) => uint2(a * b + c);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static uint2 Add(uint2 lhs, uint2 rhs) => uint2(lhs.x + rhs.x, lhs.y + rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static uint2 Add(uint2 lhs, uint rhs) => uint2(lhs.x + rhs, lhs.y + rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static uint2 Add(uint lhs, uint2 rhs) => uint2(lhs + rhs.x, lhs + rhs.y);
        
        /// <summary>
        /// Returns a uint from the application of Add (lhs + rhs).
        /// </summary>
        public static uint2 Add(uint lhs, uint rhs) => uint2(lhs + rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static uint2 Sub(uint2 lhs, uint2 rhs) => uint2(lhs.x - rhs.x, lhs.y - rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static uint2 Sub(uint2 lhs, uint rhs) => uint2(lhs.x - rhs, lhs.y - rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static uint2 Sub(uint lhs, uint2 rhs) => uint2(lhs - rhs.x, lhs - rhs.y);
        
        /// <summary>
        /// Returns a uint from the application of Sub (lhs - rhs).
        /// </summary>
        public static uint2 Sub(uint lhs, uint rhs) => uint2(lhs - rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static uint2 Mul(uint2 lhs, uint2 rhs) => uint2(lhs.x * rhs.x, lhs.y * rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static uint2 Mul(uint2 lhs, uint rhs) => uint2(lhs.x * rhs, lhs.y * rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static uint2 Mul(uint lhs, uint2 rhs) => uint2(lhs * rhs.x, lhs * rhs.y);
        
        /// <summary>
        /// Returns a uint from the application of Mul (lhs * rhs).
        /// </summary>
        public static uint2 Mul(uint lhs, uint rhs) => uint2(lhs * rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static uint2 Div(uint2 lhs, uint2 rhs) => uint2(lhs.x / rhs.x, lhs.y / rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static uint2 Div(uint2 lhs, uint rhs) => uint2(lhs.x / rhs, lhs.y / rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static uint2 Div(uint lhs, uint2 rhs) => uint2(lhs / rhs.x, lhs / rhs.y);
        
        /// <summary>
        /// Returns a uint from the application of Div (lhs / rhs).
        /// </summary>
        public static uint2 Div(uint lhs, uint rhs) => uint2(lhs / rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static uint2 Xor(uint2 lhs, uint2 rhs) => uint2(lhs.x ^ rhs.x, lhs.y ^ rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static uint2 Xor(uint2 lhs, uint rhs) => uint2(lhs.x ^ rhs, lhs.y ^ rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static uint2 Xor(uint lhs, uint2 rhs) => uint2(lhs ^ rhs.x, lhs ^ rhs.y);
        
        /// <summary>
        /// Returns a uint from the application of Xor (lhs ^ rhs).
        /// </summary>
        public static uint2 Xor(uint lhs, uint rhs) => uint2(lhs ^ rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static uint2 BitwiseOr(uint2 lhs, uint2 rhs) => uint2(lhs.x | rhs.x, lhs.y | rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static uint2 BitwiseOr(uint2 lhs, uint rhs) => uint2(lhs.x | rhs, lhs.y | rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static uint2 BitwiseOr(uint lhs, uint2 rhs) => uint2(lhs | rhs.x, lhs | rhs.y);
        
        /// <summary>
        /// Returns a uint from the application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static uint2 BitwiseOr(uint lhs, uint rhs) => uint2(lhs | rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static uint2 BitwiseAnd(uint2 lhs, uint2 rhs) => uint2(lhs.x & rhs.x, lhs.y & rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static uint2 BitwiseAnd(uint2 lhs, uint rhs) => uint2(lhs.x & rhs, lhs.y & rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static uint2 BitwiseAnd(uint lhs, uint2 rhs) => uint2(lhs & rhs.x, lhs & rhs.y);
        
        /// <summary>
        /// Returns a uint from the application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static uint2 BitwiseAnd(uint lhs, uint rhs) => uint2(lhs & rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint2 LeftShift(uint2 lhs, int2 rhs) => uint2(lhs.x << rhs.x, lhs.y << rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint2 LeftShift(uint2 lhs, int rhs) => uint2(lhs.x << rhs, lhs.y << rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint2 LeftShift(uint lhs, int2 rhs) => uint2(lhs << rhs.x, lhs << rhs.y);
        
        /// <summary>
        /// Returns a uint from the application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint2 LeftShift(uint lhs, int rhs) => uint2(lhs << rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint2 RightShift(uint2 lhs, int2 rhs) => uint2(lhs.x >> rhs.x, lhs.y >> rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint2 RightShift(uint2 lhs, int rhs) => uint2(lhs.x >> rhs, lhs.y >> rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint2 RightShift(uint lhs, int2 rhs) => uint2(lhs >> rhs.x, lhs >> rhs.y);
        
        /// <summary>
        /// Returns a uint from the application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint2 RightShift(uint lhs, int rhs) => uint2(lhs >> rhs);
        
        /// <summary>
        /// Returns a uint2 with independent and identically distributed uniform integer values between 0 (inclusive) and maxValue (exclusive). (A maxValue of 0 is allowed and returns 0.)
        /// </summary>
        public static uint2 Random(Random random, uint2 maxValue) => uint2((uint)random.Next((int)maxValue.x), (uint)random.Next((int)maxValue.y));
        
        /// <summary>
        /// Returns a uint2 with independent and identically distributed uniform integer values between 0 (inclusive) and maxValue (exclusive). (A maxValue of 0 is allowed and returns 0.)
        /// </summary>
        public static uint2 Random(Random random, uint maxValue) => uint2((uint)random.Next((int)maxValue));
        
        /// <summary>
        /// Returns a uint2 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static uint2 Random(Random random, uint2 minValue, uint2 maxValue) => uint2((uint)random.Next((int)minValue.x, (int)maxValue.x), (uint)random.Next((int)minValue.y, (int)maxValue.y));
        
        /// <summary>
        /// Returns a uint2 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static uint2 Random(Random random, uint2 minValue, uint maxValue) => uint2((uint)random.Next((int)minValue.x, (int)maxValue), (uint)random.Next((int)minValue.y, (int)maxValue));
        
        /// <summary>
        /// Returns a uint2 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static uint2 Random(Random random, uint minValue, uint2 maxValue) => uint2((uint)random.Next((int)minValue, (int)maxValue.x), (uint)random.Next((int)minValue, (int)maxValue.y));
        
        /// <summary>
        /// Returns a uint2 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static uint2 Random(Random random, uint minValue, uint maxValue) => uint2((uint)random.Next((int)minValue, (int)maxValue));
        
        /// <summary>
        /// Returns a uint2 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static uint2 RandomUniform(Random random, uint2 minValue, uint2 maxValue) => uint2((uint)random.Next((int)minValue.x, (int)maxValue.x), (uint)random.Next((int)minValue.y, (int)maxValue.y));
        
        /// <summary>
        /// Returns a uint2 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static uint2 RandomUniform(Random random, uint2 minValue, uint maxValue) => uint2((uint)random.Next((int)minValue.x, (int)maxValue), (uint)random.Next((int)minValue.y, (int)maxValue));
        
        /// <summary>
        /// Returns a uint2 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static uint2 RandomUniform(Random random, uint minValue, uint2 maxValue) => uint2((uint)random.Next((int)minValue, (int)maxValue.x), (uint)random.Next((int)minValue, (int)maxValue.y));
        
        /// <summary>
        /// Returns a uint2 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static uint2 RandomUniform(Random random, uint minValue, uint maxValue) => uint2((uint)random.Next((int)minValue, (int)maxValue));

        //#endregion


        //#region Component-Wise Operator Overloads
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool2 operator<(uint2 lhs, uint2 rhs) => bool2(lhs.x < rhs.x, lhs.y < rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool2 operator<(uint2 lhs, uint rhs) => bool2(lhs.x < rhs, lhs.y < rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool2 operator<(uint lhs, uint2 rhs) => bool2(lhs < rhs.x, lhs < rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool2 operator<=(uint2 lhs, uint2 rhs) => bool2(lhs.x <= rhs.x, lhs.y <= rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool2 operator<=(uint2 lhs, uint rhs) => bool2(lhs.x <= rhs, lhs.y <= rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool2 operator<=(uint lhs, uint2 rhs) => bool2(lhs <= rhs.x, lhs <= rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool2 operator>(uint2 lhs, uint2 rhs) => bool2(lhs.x > rhs.x, lhs.y > rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool2 operator>(uint2 lhs, uint rhs) => bool2(lhs.x > rhs, lhs.y > rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool2 operator>(uint lhs, uint2 rhs) => bool2(lhs > rhs.x, lhs > rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool2 operator>=(uint2 lhs, uint2 rhs) => bool2(lhs.x >= rhs.x, lhs.y >= rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool2 operator>=(uint2 lhs, uint rhs) => bool2(lhs.x >= rhs, lhs.y >= rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool2 operator>=(uint lhs, uint2 rhs) => bool2(lhs >= rhs.x, lhs >= rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static uint2 operator+(uint2 lhs, uint2 rhs) => uint2(lhs.x + rhs.x, lhs.y + rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static uint2 operator+(uint2 lhs, uint rhs) => uint2(lhs.x + rhs, lhs.y + rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static uint2 operator+(uint lhs, uint2 rhs) => uint2(lhs + rhs.x, lhs + rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static uint2 operator-(uint2 lhs, uint2 rhs) => uint2(lhs.x - rhs.x, lhs.y - rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static uint2 operator-(uint2 lhs, uint rhs) => uint2(lhs.x - rhs, lhs.y - rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static uint2 operator-(uint lhs, uint2 rhs) => uint2(lhs - rhs.x, lhs - rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static uint2 operator*(uint2 lhs, uint2 rhs) => uint2(lhs.x * rhs.x, lhs.y * rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static uint2 operator*(uint2 lhs, uint rhs) => uint2(lhs.x * rhs, lhs.y * rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static uint2 operator*(uint lhs, uint2 rhs) => uint2(lhs * rhs.x, lhs * rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static uint2 operator/(uint2 lhs, uint2 rhs) => uint2(lhs.x / rhs.x, lhs.y / rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static uint2 operator/(uint2 lhs, uint rhs) => uint2(lhs.x / rhs, lhs.y / rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static uint2 operator/(uint lhs, uint2 rhs) => uint2(lhs / rhs.x, lhs / rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator~ (~v).
        /// </summary>
        public static uint2 operator~(uint2 v) => uint2(~v.x, ~v.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static uint2 operator^(uint2 lhs, uint2 rhs) => uint2(lhs.x ^ rhs.x, lhs.y ^ rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static uint2 operator^(uint2 lhs, uint rhs) => uint2(lhs.x ^ rhs, lhs.y ^ rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static uint2 operator^(uint lhs, uint2 rhs) => uint2(lhs ^ rhs.x, lhs ^ rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static uint2 operator|(uint2 lhs, uint2 rhs) => uint2(lhs.x | rhs.x, lhs.y | rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static uint2 operator|(uint2 lhs, uint rhs) => uint2(lhs.x | rhs, lhs.y | rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static uint2 operator|(uint lhs, uint2 rhs) => uint2(lhs | rhs.x, lhs | rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static uint2 operator&(uint2 lhs, uint2 rhs) => uint2(lhs.x & rhs.x, lhs.y & rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static uint2 operator&(uint2 lhs, uint rhs) => uint2(lhs.x & rhs, lhs.y & rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static uint2 operator&(uint lhs, uint2 rhs) => uint2(lhs & rhs.x, lhs & rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator&lt;&lt; (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint2 operator<<(uint2 lhs, int rhs) => uint2(lhs.x << rhs, lhs.y << rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint2 operator>>(uint2 lhs, int rhs) => uint2(lhs.x >> rhs, lhs.y >> rhs);

        //#endregion

    }
}
