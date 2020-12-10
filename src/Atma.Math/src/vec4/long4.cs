using System;
namespace Atma
{
    
    /// <summary>
    /// A vector of type long with 4 components.
    /// </summary>
    [Union]
    public struct long4 : IHashable
    {

        //#region Fields
        
        /// <summary>
        /// component data
        /// </summary>
        public long[4] values;
        
        /// <summary>
        /// Returns an object that can be used for arbitrary swizzling (e.g. swizzle.zy)
        /// </summary>
        public readonly swizzle_long4 swizzle;

        //#endregion


        //#region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public this(long x, long y, long z, long w)
        {
            values = .(x,y,z,w);
        }
        
        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public this(long v)
        {
            values = .(v,v,v,v);
        }
        
        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public this(long2 v)
        {
            values = .(v.x,v.y,0,0);
        }
        
        /// <summary>
        /// from-vector-and-value constructor (empty fields are zero/false)
        /// </summary>
        public this(long2 v, long z)
        {
            values = .(v.x,v.y,z,0);
        }
        
        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public this(long2 v, long z, long w)
        {
            values = .(v.x,v.y,z,w);
        }
        
        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public this(long3 v)
        {
            values = .(v.x,v.y,v.z,0);
        }
        
        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public this(long3 v, long w)
        {
            values = .(v.x,v.y,v.z,w);
        }
        
        /// <summary>
        /// from-vector constructor
        /// </summary>
        public this(long4 v)
        {
            values = .(v.x,v.y,v.z,v.w);
        }
        
        /// <summary>
        /// From-array constructor (superfluous values are ignored, missing values are zero-filled).
        /// </summary>
        public this(long[] v)
        {
            let c = v.Count;
            values = .((c < 0) ? 0 : v[0],(c < 1) ? 0 : v[1],(c < 2) ? 0 : v[2],(c < 3) ? 0 : v[3]);
        }
        
        /// <summary>
        /// From-array constructor with base index (superfluous values are ignored, missing values are zero-filled).
        /// </summary>
        public this(long[] v, int startIndex)
        {
            let c = v.Count;
            values = .((c + startIndex < 0) ? 0 : v[0 + startIndex],(c + startIndex < 1) ? 0 : v[1 + startIndex],(c + startIndex < 2) ? 0 : v[2 + startIndex],(c + startIndex < 3) ? 0 : v[3 + startIndex]);
        }

        //#endregion


        //#region Explicit Operators
        
        /// <summary>
        /// Explicitly converts this to a int2.
        /// </summary>
        public static explicit operator int2(long4 v) =>  int2((int)v.x, (int)v.y);
        
        /// <summary>
        /// Explicitly converts this to a int3.
        /// </summary>
        public static explicit operator int3(long4 v) =>  int3((int)v.x, (int)v.y, (int)v.z);
        
        /// <summary>
        /// Explicitly converts this to a int4.
        /// </summary>
        public static explicit operator int4(long4 v) =>  int4((int)v.x, (int)v.y, (int)v.z, (int)v.w);
        
        /// <summary>
        /// Explicitly converts this to a uint2.
        /// </summary>
        public static explicit operator uint2(long4 v) =>  uint2((uint)v.x, (uint)v.y);
        
        /// <summary>
        /// Explicitly converts this to a uint3.
        /// </summary>
        public static explicit operator uint3(long4 v) =>  uint3((uint)v.x, (uint)v.y, (uint)v.z);
        
        /// <summary>
        /// Explicitly converts this to a uint4.
        /// </summary>
        public static explicit operator uint4(long4 v) =>  uint4((uint)v.x, (uint)v.y, (uint)v.z, (uint)v.w);
        
        /// <summary>
        /// Explicitly converts this to a float2.
        /// </summary>
        public static explicit operator float2(long4 v) =>  float2((float)v.x, (float)v.y);
        
        /// <summary>
        /// Explicitly converts this to a float3.
        /// </summary>
        public static explicit operator float3(long4 v) =>  float3((float)v.x, (float)v.y, (float)v.z);
        
        /// <summary>
        /// Explicitly converts this to a float4.
        /// </summary>
        public static explicit operator float4(long4 v) =>  float4((float)v.x, (float)v.y, (float)v.z, (float)v.w);
        
        /// <summary>
        /// Explicitly converts this to a double2.
        /// </summary>
        public static explicit operator double2(long4 v) =>  double2((double)v.x, (double)v.y);
        
        /// <summary>
        /// Explicitly converts this to a double3.
        /// </summary>
        public static explicit operator double3(long4 v) =>  double3((double)v.x, (double)v.y, (double)v.z);
        
        /// <summary>
        /// Explicitly converts this to a double4.
        /// </summary>
        public static explicit operator double4(long4 v) =>  double4((double)v.x, (double)v.y, (double)v.z, (double)v.w);
        
        /// <summary>
        /// Explicitly converts this to a long2.
        /// </summary>
        public static explicit operator long2(long4 v) =>  long2((long)v.x, (long)v.y);
        
        /// <summary>
        /// Explicitly converts this to a long3.
        /// </summary>
        public static explicit operator long3(long4 v) =>  long3((long)v.x, (long)v.y, (long)v.z);
        
        /// <summary>
        /// Explicitly converts this to a bool2.
        /// </summary>
        public static explicit operator bool2(long4 v) =>  bool2(v.x != 0, v.y != 0);
        
        /// <summary>
        /// Explicitly converts this to a bool3.
        /// </summary>
        public static explicit operator bool3(long4 v) =>  bool3(v.x != 0, v.y != 0, v.z != 0);
        
        /// <summary>
        /// Explicitly converts this to a bool4.
        /// </summary>
        public static explicit operator bool4(long4 v) =>  bool4(v.x != 0, v.y != 0, v.z != 0, v.w != 0);

        //#endregion


        //#region Properties
        
        /// <summary>
        /// x-component
        /// </summary>
        public long x
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
        public long y
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
        /// z-component
        /// </summary>
        public long z
        {
            [Inline]get
            {
                return values[2];
            }
            [Inline]set mut
            {
                values[2] = value;
            }
        }
        
        /// <summary>
        /// w-component
        /// </summary>
        public long w
        {
            [Inline]get
            {
                return values[3];
            }
            [Inline]set mut
            {
                values[3] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long2 xy
        {
            [Inline]get
            {
                return  long2(x, y);
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
        public long2 xz
        {
            [Inline]get
            {
                return  long2(x, z);
            }
            [Inline]set mut
            {
                x = value.x;
                z = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long2 yz
        {
            [Inline]get
            {
                return  long2(y, z);
            }
            [Inline]set mut
            {
                y = value.x;
                z = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long3 xyz
        {
            [Inline]get
            {
                return  long3(x, y, z);
            }
            [Inline]set mut
            {
                x = value.x;
                y = value.y;
                z = value.z;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long2 xw
        {
            [Inline]get
            {
                return  long2(x, w);
            }
            [Inline]set mut
            {
                x = value.x;
                w = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long2 yw
        {
            [Inline]get
            {
                return  long2(y, w);
            }
            [Inline]set mut
            {
                y = value.x;
                w = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long3 xyw
        {
            [Inline]get
            {
                return  long3(x, y, w);
            }
            [Inline]set mut
            {
                x = value.x;
                y = value.y;
                w = value.z;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long2 zw
        {
            [Inline]get
            {
                return  long2(z, w);
            }
            [Inline]set mut
            {
                z = value.x;
                w = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long3 xzw
        {
            [Inline]get
            {
                return  long3(x, z, w);
            }
            [Inline]set mut
            {
                x = value.x;
                z = value.y;
                w = value.z;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long3 yzw
        {
            [Inline]get
            {
                return  long3(y, z, w);
            }
            [Inline]set mut
            {
                y = value.x;
                z = value.y;
                w = value.z;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long4 xyzw
        {
            [Inline]get
            {
                return  long4(x, y, z, w);
            }
            [Inline]set mut
            {
                x = value.x;
                y = value.y;
                z = value.z;
                w = value.w;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long2 rg
        {
            [Inline]get
            {
                return  long2(x, y);
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
        public long2 rb
        {
            [Inline]get
            {
                return  long2(x, z);
            }
            [Inline]set mut
            {
                x = value.x;
                z = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long2 gb
        {
            [Inline]get
            {
                return  long2(y, z);
            }
            [Inline]set mut
            {
                y = value.x;
                z = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long3 rgb
        {
            [Inline]get
            {
                return  long3(x, y, z);
            }
            [Inline]set mut
            {
                x = value.x;
                y = value.y;
                z = value.z;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long2 ra
        {
            [Inline]get
            {
                return  long2(x, w);
            }
            [Inline]set mut
            {
                x = value.x;
                w = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long2 ga
        {
            [Inline]get
            {
                return  long2(y, w);
            }
            [Inline]set mut
            {
                y = value.x;
                w = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long3 rga
        {
            [Inline]get
            {
                return  long3(x, y, w);
            }
            [Inline]set mut
            {
                x = value.x;
                y = value.y;
                w = value.z;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long2 ba
        {
            [Inline]get
            {
                return  long2(z, w);
            }
            [Inline]set mut
            {
                z = value.x;
                w = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long3 rba
        {
            [Inline]get
            {
                return  long3(x, z, w);
            }
            [Inline]set mut
            {
                x = value.x;
                z = value.y;
                w = value.z;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long3 gba
        {
            [Inline]get
            {
                return  long3(y, z, w);
            }
            [Inline]set mut
            {
                y = value.x;
                z = value.y;
                w = value.z;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long4 rgba
        {
            [Inline]get
            {
                return  long4(x, y, z, w);
            }
            [Inline]set mut
            {
                x = value.x;
                y = value.y;
                z = value.z;
                w = value.w;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified RGBA component. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long r
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
        public long g
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
        /// Gets or sets the specified RGBA component. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long b
        {
            [Inline]get
            {
                return z;
            }
            [Inline]set mut
            {
                z = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified RGBA component. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public long a
        {
            [Inline]get
            {
                return w;
            }
            [Inline]set mut
            {
                w = value;
            }
        }
        
        /// <summary>
        /// Returns the number of components (4).
        /// </summary>
        public int Count => 4;
        
        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        public long MinElement => System.Math.Min(System.Math.Min(x, y), System.Math.Min(z, w));
        
        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public long MaxElement => System.Math.Max(System.Math.Max(x, y), System.Math.Max(z, w));
        
        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public double Length => (double)System.Math.Sqrt(((x*x + y*y) + (z*z + w*w)));
        
        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        public double LengthSqr => ((x*x + y*y) + (z*z + w*w));
        
        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        public long Sum => ((x + y) + (z + w));
        
        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public double Norm => (double)System.Math.Sqrt(((x*x + y*y) + (z*z + w*w)));
        
        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public double Norm1 => ((System.Math.Abs(x) + System.Math.Abs(y)) + (System.Math.Abs(z) + System.Math.Abs(w)));
        
        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        public double Norm2 => (double)System.Math.Sqrt(((x*x + y*y) + (z*z + w*w)));
        
        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public double NormMax => System.Math.Max(System.Math.Max(System.Math.Abs(x), System.Math.Abs(y)), System.Math.Max(System.Math.Abs(z), System.Math.Abs(w)));

        //#endregion


        //#region Static Properties
        
        /// <summary>
        /// Predefined all-zero vector
        /// </summary>
        readonly public static long4 Zero  =  long4(0, 0, 0, 0);
        
        /// <summary>
        /// Predefined all-ones vector
        /// </summary>
        readonly public static long4 Ones  =  long4(1, 1, 1, 1);
        
        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        readonly public static long4 UnitX  =  long4(1, 0, 0, 0);
        
        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        readonly public static long4 NegativeUnitX  =  long4(-1, 0, 0, 0);
        
        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        readonly public static long4 UnitY  =  long4(0, 1, 0, 0);
        
        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        readonly public static long4 NegativeUnitY  =  long4(0, -1, 0, 0);
        
        /// <summary>
        /// Predefined unit-Z vector
        /// </summary>
        readonly public static long4 UnitZ  =  long4(0, 0, 1, 0);
        
        /// <summary>
        /// Predefined unit-Z vector
        /// </summary>
        readonly public static long4 NegativeUnitZ  =  long4(0, 0, -1, 0);
        
        /// <summary>
        /// Predefined unit-W vector
        /// </summary>
        readonly public static long4 UnitW  =  long4(0, 0, 0, 1);
        
        /// <summary>
        /// Predefined unit-W vector
        /// </summary>
        readonly public static long4 NegativeUnitW  =  long4(0, 0, 0, -1);
        
        /// <summary>
        /// Predefined all-MaxValue vector
        /// </summary>
        readonly public static long4 MaxValue  =  long4(long.MaxValue, long.MaxValue, long.MaxValue, long.MaxValue);
        
        /// <summary>
        /// Predefined all-MinValue vector
        /// </summary>
        readonly public static long4 MinValue  =  long4(long.MinValue, long.MinValue, long.MinValue, long.MinValue);

        //#endregion


        //#region Operators
        
        /// <summary>
        /// Returns true if this equals rhs component-wise.
        /// </summary>
        public static bool operator==(long4 lhs, long4 rhs) => ((lhs.x == rhs.x && lhs.y == rhs.y) && (lhs.z == rhs.z && lhs.w == rhs.w));
        
        /// <summary>
        /// Returns true if this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator!=(long4 lhs, long4 rhs) => !((lhs.x == rhs.x && lhs.y == rhs.y) && (lhs.z == rhs.z && lhs.w == rhs.w));

        //#endregion


        //#region Functions
        
        /// <summary>
        /// Returns an array with all values
        /// </summary>
        public long[] ToArray() => new .[] ( x, y, z, w );
        
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
            let _z = scope String(); values[2].ToString(_z);
            let _w = scope String(); values[3].ToString(_w);
             stringBuffer.Join(sep, _x,_y,_z,_w );
        }
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public int GetHashCode()
        {
            unchecked
            {
                return ((((((x.GetHashCode()) * 397) ^ y.GetHashCode()) * 397) ^ z.GetHashCode()) * 397) ^ w.GetHashCode();
            }
        }
        
        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        public double NormP(double p) => System.Math.Pow(((System.Math.Pow((double)System.Math.Abs(x), p) + System.Math.Pow((double)System.Math.Abs(y), p)) + (System.Math.Pow((double)System.Math.Abs(z), p) + System.Math.Pow((double)System.Math.Abs(w), p))), 1 / p);

        //#endregion


        //#region Static Functions
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static long4x2 OuterProduct(long2 c, long4 r) =>  long4x2(c.x * r.x, c.y * r.x, c.x * r.y, c.y * r.y, c.x * r.z, c.y * r.z, c.x * r.w, c.y * r.w);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static long2x4 OuterProduct(long4 c, long2 r) =>  long2x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static long4x3 OuterProduct(long3 c, long4 r) =>  long4x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.x * r.w, c.y * r.w, c.z * r.w);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static long3x4 OuterProduct(long4 c, long3 r) =>  long3x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.w * r.z);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static long4x4 OuterProduct(long4 c, long4 r) =>  long4x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.w * r.z, c.x * r.w, c.y * r.w, c.z * r.w, c.w * r.w);
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static long Dot(long4 lhs, long4 rhs) => ((lhs.x * rhs.x + lhs.y * rhs.y) + (lhs.z * rhs.z + lhs.w * rhs.w));
        
        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static double Distance(long4 lhs, long4 rhs) => (lhs - rhs).Length;
        
        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static double DistanceSqr(long4 lhs, long4 rhs) => (lhs - rhs).LengthSqr;
        
        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static long4 Reflect(long4 I, long4 N) => I - 2 * Dot(N, I) * N;
        
        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static long4 Refract(long4 I, long4 N, long eta)
        {
            let dNI = Dot(N, I);
            let k = 1 - eta * eta * (1 - dNI * dNI);
            if (k < 0) return Zero;
            return eta * I - (eta * dNI + (long)System.Math.Sqrt(k)) * N;
        }
        
        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static long4 FaceForward(long4 N, long4 I, long4 Nref) => Dot(Nref, I) < 0 ? N : -N;
        
        /// <summary>
        /// Returns a long4 with independent and identically distributed uniform integer values between 0 (inclusive) and int.MaxValue (exclusive).
        /// </summary>
        public static long4 Random(Random random) =>  long4((long)random.Next(int64.MaxValue), (long)random.Next(int64.MaxValue), (long)random.Next(int64.MaxValue), (long)random.Next(int64.MaxValue));

        //#endregion


        //#region Component-Wise Static Functions
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(long4 lhs, long4 rhs) => bool4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(long4 lhs, long rhs) => bool4(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs, lhs.w == rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(long lhs, long4 rhs) => bool4(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z, lhs == rhs.w);
        
        /// <summary>
        /// Returns a bool from the application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(long lhs, long rhs) => bool4(lhs == rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(long4 lhs, long4 rhs) => bool4(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(long4 lhs, long rhs) => bool4(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs, lhs.w != rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(long lhs, long4 rhs) => bool4(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z, lhs != rhs.w);
        
        /// <summary>
        /// Returns a bool from the application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(long lhs, long rhs) => bool4(lhs != rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(long4 lhs, long4 rhs) => bool4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(long4 lhs, long rhs) => bool4(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs, lhs.w > rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(long lhs, long4 rhs) => bool4(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z, lhs > rhs.w);
        
        /// <summary>
        /// Returns a bool from the application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(long lhs, long rhs) => bool4(lhs > rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(long4 lhs, long4 rhs) => bool4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(long4 lhs, long rhs) => bool4(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs, lhs.w >= rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(long lhs, long4 rhs) => bool4(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z, lhs >= rhs.w);
        
        /// <summary>
        /// Returns a bool from the application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(long lhs, long rhs) => bool4(lhs >= rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(long4 lhs, long4 rhs) => bool4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(long4 lhs, long rhs) => bool4(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs, lhs.w < rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(long lhs, long4 rhs) => bool4(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z, lhs < rhs.w);
        
        /// <summary>
        /// Returns a bool from the application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(long lhs, long rhs) => bool4(lhs < rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(long4 lhs, long4 rhs) => bool4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(long4 lhs, long rhs) => bool4(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs, lhs.w <= rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(long lhs, long4 rhs) => bool4(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z, lhs <= rhs.w);
        
        /// <summary>
        /// Returns a bool from the application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(long lhs, long rhs) => bool4(lhs <= rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Abs (System.Math.Abs(v)).
        /// </summary>
        public static long4 Abs(long4 v) => long4(System.Math.Abs(v.x), System.Math.Abs(v.y), System.Math.Abs(v.z), System.Math.Abs(v.w));
        
        /// <summary>
        /// Returns a long from the application of Abs (System.Math.Abs(v)).
        /// </summary>
        public static long4 Abs(long v) => long4(System.Math.Abs(v));
        
        /// <summary>
        /// Returns a long4 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static long4 HermiteInterpolationOrder3(long4 v) => long4((3 - 2 * v.x) * v.x * v.x, (3 - 2 * v.y) * v.y * v.y, (3 - 2 * v.z) * v.z * v.z, (3 - 2 * v.w) * v.w * v.w);
        
        /// <summary>
        /// Returns a long from the application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static long4 HermiteInterpolationOrder3(long v) => long4((3 - 2 * v) * v * v);
        
        /// <summary>
        /// Returns a long4 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static long4 HermiteInterpolationOrder5(long4 v) => long4(((6 * v.x - 15) * v.x + 10) * v.x * v.x * v.x, ((6 * v.y - 15) * v.y + 10) * v.y * v.y * v.y, ((6 * v.z - 15) * v.z + 10) * v.z * v.z * v.z, ((6 * v.w - 15) * v.w + 10) * v.w * v.w * v.w);
        
        /// <summary>
        /// Returns a long from the application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static long4 HermiteInterpolationOrder5(long v) => long4(((6 * v - 15) * v + 10) * v * v * v);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Sqr (v * v).
        /// </summary>
        public static long4 Sqr(long4 v) => long4(v.x * v.x, v.y * v.y, v.z * v.z, v.w * v.w);
        
        /// <summary>
        /// Returns a long from the application of Sqr (v * v).
        /// </summary>
        public static long4 Sqr(long v) => long4(v * v);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static long4 Pow2(long4 v) => long4(v.x * v.x, v.y * v.y, v.z * v.z, v.w * v.w);
        
        /// <summary>
        /// Returns a long from the application of Pow2 (v * v).
        /// </summary>
        public static long4 Pow2(long v) => long4(v * v);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static long4 Pow3(long4 v) => long4(v.x * v.x * v.x, v.y * v.y * v.y, v.z * v.z * v.z, v.w * v.w * v.w);
        
        /// <summary>
        /// Returns a long from the application of Pow3 (v * v * v).
        /// </summary>
        public static long4 Pow3(long v) => long4(v * v * v);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Step (v &gt;= 0 ? 1 : 0).
        /// </summary>
        public static long4 Step(long4 v) => long4(v.x >= 0 ? 1 : 0, v.y >= 0 ? 1 : 0, v.z >= 0 ? 1 : 0, v.w >= 0 ? 1 : 0);
        
        /// <summary>
        /// Returns a long from the application of Step (v &gt;= 0 ? 1 : 0).
        /// </summary>
        public static long4 Step(long v) => long4(v >= 0 ? 1 : 0);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Sqrt ((long)System.Math.Sqrt((double)v)).
        /// </summary>
        public static long4 Sqrt(long4 v) => long4((long)System.Math.Sqrt((double)v.x), (long)System.Math.Sqrt((double)v.y), (long)System.Math.Sqrt((double)v.z), (long)System.Math.Sqrt((double)v.w));
        
        /// <summary>
        /// Returns a long from the application of Sqrt ((long)System.Math.Sqrt((double)v)).
        /// </summary>
        public static long4 Sqrt(long v) => long4((long)System.Math.Sqrt((double)v));
        
        /// <summary>
        /// Returns a long4 from component-wise application of InverseSqrt ((long)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        public static long4 InverseSqrt(long4 v) => long4((long)(1.0 / System.Math.Sqrt((double)v.x)), (long)(1.0 / System.Math.Sqrt((double)v.y)), (long)(1.0 / System.Math.Sqrt((double)v.z)), (long)(1.0 / System.Math.Sqrt((double)v.w)));
        
        /// <summary>
        /// Returns a long from the application of InverseSqrt ((long)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        public static long4 InverseSqrt(long v) => long4((long)(1.0 / System.Math.Sqrt((double)v)));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Sign (System.Math.Sign(v)).
        /// </summary>
        public static int4 Sign(long4 v) => int4(System.Math.Sign(v.x), System.Math.Sign(v.y), System.Math.Sign(v.z), System.Math.Sign(v.w));
        
        /// <summary>
        /// Returns a int from the application of Sign (System.Math.Sign(v)).
        /// </summary>
        public static int4 Sign(long v) => int4(System.Math.Sign(v));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static long4 Max(long4 lhs, long4 rhs) => long4(System.Math.Max(lhs.x, rhs.x), System.Math.Max(lhs.y, rhs.y), System.Math.Max(lhs.z, rhs.z), System.Math.Max(lhs.w, rhs.w));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static long4 Max(long4 lhs, long rhs) => long4(System.Math.Max(lhs.x, rhs), System.Math.Max(lhs.y, rhs), System.Math.Max(lhs.z, rhs), System.Math.Max(lhs.w, rhs));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static long4 Max(long lhs, long4 rhs) => long4(System.Math.Max(lhs, rhs.x), System.Math.Max(lhs, rhs.y), System.Math.Max(lhs, rhs.z), System.Math.Max(lhs, rhs.w));
        
        /// <summary>
        /// Returns a long from the application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static long4 Max(long lhs, long rhs) => long4(System.Math.Max(lhs, rhs));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static long4 Min(long4 lhs, long4 rhs) => long4(System.Math.Min(lhs.x, rhs.x), System.Math.Min(lhs.y, rhs.y), System.Math.Min(lhs.z, rhs.z), System.Math.Min(lhs.w, rhs.w));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static long4 Min(long4 lhs, long rhs) => long4(System.Math.Min(lhs.x, rhs), System.Math.Min(lhs.y, rhs), System.Math.Min(lhs.z, rhs), System.Math.Min(lhs.w, rhs));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static long4 Min(long lhs, long4 rhs) => long4(System.Math.Min(lhs, rhs.x), System.Math.Min(lhs, rhs.y), System.Math.Min(lhs, rhs.z), System.Math.Min(lhs, rhs.w));
        
        /// <summary>
        /// Returns a long from the application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static long4 Min(long lhs, long rhs) => long4(System.Math.Min(lhs, rhs));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Pow ((long)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static long4 Pow(long4 lhs, long4 rhs) => long4((long)System.Math.Pow((double)lhs.x, (double)rhs.x), (long)System.Math.Pow((double)lhs.y, (double)rhs.y), (long)System.Math.Pow((double)lhs.z, (double)rhs.z), (long)System.Math.Pow((double)lhs.w, (double)rhs.w));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Pow ((long)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static long4 Pow(long4 lhs, long rhs) => long4((long)System.Math.Pow((double)lhs.x, (double)rhs), (long)System.Math.Pow((double)lhs.y, (double)rhs), (long)System.Math.Pow((double)lhs.z, (double)rhs), (long)System.Math.Pow((double)lhs.w, (double)rhs));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Pow ((long)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static long4 Pow(long lhs, long4 rhs) => long4((long)System.Math.Pow((double)lhs, (double)rhs.x), (long)System.Math.Pow((double)lhs, (double)rhs.y), (long)System.Math.Pow((double)lhs, (double)rhs.z), (long)System.Math.Pow((double)lhs, (double)rhs.w));
        
        /// <summary>
        /// Returns a long from the application of Pow ((long)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static long4 Pow(long lhs, long rhs) => long4((long)System.Math.Pow((double)lhs, (double)rhs));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Log ((long)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static long4 Log(long4 lhs, long4 rhs) => long4((long)System.Math.Log((double)lhs.x, (double)rhs.x), (long)System.Math.Log((double)lhs.y, (double)rhs.y), (long)System.Math.Log((double)lhs.z, (double)rhs.z), (long)System.Math.Log((double)lhs.w, (double)rhs.w));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Log ((long)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static long4 Log(long4 lhs, long rhs) => long4((long)System.Math.Log((double)lhs.x, (double)rhs), (long)System.Math.Log((double)lhs.y, (double)rhs), (long)System.Math.Log((double)lhs.z, (double)rhs), (long)System.Math.Log((double)lhs.w, (double)rhs));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Log ((long)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static long4 Log(long lhs, long4 rhs) => long4((long)System.Math.Log((double)lhs, (double)rhs.x), (long)System.Math.Log((double)lhs, (double)rhs.y), (long)System.Math.Log((double)lhs, (double)rhs.z), (long)System.Math.Log((double)lhs, (double)rhs.w));
        
        /// <summary>
        /// Returns a long from the application of Log ((long)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static long4 Log(long lhs, long rhs) => long4((long)System.Math.Log((double)lhs, (double)rhs));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static long4 Clamp(long4 v, long4 min, long4 max) => long4(System.Math.Min(System.Math.Max(v.x, min.x), max.x), System.Math.Min(System.Math.Max(v.y, min.y), max.y), System.Math.Min(System.Math.Max(v.z, min.z), max.z), System.Math.Min(System.Math.Max(v.w, min.w), max.w));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static long4 Clamp(long4 v, long4 min, long max) => long4(System.Math.Min(System.Math.Max(v.x, min.x), max), System.Math.Min(System.Math.Max(v.y, min.y), max), System.Math.Min(System.Math.Max(v.z, min.z), max), System.Math.Min(System.Math.Max(v.w, min.w), max));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static long4 Clamp(long4 v, long min, long4 max) => long4(System.Math.Min(System.Math.Max(v.x, min), max.x), System.Math.Min(System.Math.Max(v.y, min), max.y), System.Math.Min(System.Math.Max(v.z, min), max.z), System.Math.Min(System.Math.Max(v.w, min), max.w));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static long4 Clamp(long4 v, long min, long max) => long4(System.Math.Min(System.Math.Max(v.x, min), max), System.Math.Min(System.Math.Max(v.y, min), max), System.Math.Min(System.Math.Max(v.z, min), max), System.Math.Min(System.Math.Max(v.w, min), max));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static long4 Clamp(long v, long4 min, long4 max) => long4(System.Math.Min(System.Math.Max(v, min.x), max.x), System.Math.Min(System.Math.Max(v, min.y), max.y), System.Math.Min(System.Math.Max(v, min.z), max.z), System.Math.Min(System.Math.Max(v, min.w), max.w));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static long4 Clamp(long v, long4 min, long max) => long4(System.Math.Min(System.Math.Max(v, min.x), max), System.Math.Min(System.Math.Max(v, min.y), max), System.Math.Min(System.Math.Max(v, min.z), max), System.Math.Min(System.Math.Max(v, min.w), max));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static long4 Clamp(long v, long min, long4 max) => long4(System.Math.Min(System.Math.Max(v, min), max.x), System.Math.Min(System.Math.Max(v, min), max.y), System.Math.Min(System.Math.Max(v, min), max.z), System.Math.Min(System.Math.Max(v, min), max.w));
        
        /// <summary>
        /// Returns a long from the application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static long4 Clamp(long v, long min, long max) => long4(System.Math.Min(System.Math.Max(v, min), max));
        
        /// <summary>
        /// Returns a long4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static long4 Mix(long4 min, long4 max, long4 a) => long4(min.x * (1-a.x) + max.x * a.x, min.y * (1-a.y) + max.y * a.y, min.z * (1-a.z) + max.z * a.z, min.w * (1-a.w) + max.w * a.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static long4 Mix(long4 min, long4 max, long a) => long4(min.x * (1-a) + max.x * a, min.y * (1-a) + max.y * a, min.z * (1-a) + max.z * a, min.w * (1-a) + max.w * a);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static long4 Mix(long4 min, long max, long4 a) => long4(min.x * (1-a.x) + max * a.x, min.y * (1-a.y) + max * a.y, min.z * (1-a.z) + max * a.z, min.w * (1-a.w) + max * a.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static long4 Mix(long4 min, long max, long a) => long4(min.x * (1-a) + max * a, min.y * (1-a) + max * a, min.z * (1-a) + max * a, min.w * (1-a) + max * a);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static long4 Mix(long min, long4 max, long4 a) => long4(min * (1-a.x) + max.x * a.x, min * (1-a.y) + max.y * a.y, min * (1-a.z) + max.z * a.z, min * (1-a.w) + max.w * a.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static long4 Mix(long min, long4 max, long a) => long4(min * (1-a) + max.x * a, min * (1-a) + max.y * a, min * (1-a) + max.z * a, min * (1-a) + max.w * a);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static long4 Mix(long min, long max, long4 a) => long4(min * (1-a.x) + max * a.x, min * (1-a.y) + max * a.y, min * (1-a.z) + max * a.z, min * (1-a.w) + max * a.w);
        
        /// <summary>
        /// Returns a long from the application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static long4 Mix(long min, long max, long a) => long4(min * (1-a) + max * a);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static long4 Lerp(long4 min, long4 max, long4 a) => long4(min.x * (1-a.x) + max.x * a.x, min.y * (1-a.y) + max.y * a.y, min.z * (1-a.z) + max.z * a.z, min.w * (1-a.w) + max.w * a.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static long4 Lerp(long4 min, long4 max, long a) => long4(min.x * (1-a) + max.x * a, min.y * (1-a) + max.y * a, min.z * (1-a) + max.z * a, min.w * (1-a) + max.w * a);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static long4 Lerp(long4 min, long max, long4 a) => long4(min.x * (1-a.x) + max * a.x, min.y * (1-a.y) + max * a.y, min.z * (1-a.z) + max * a.z, min.w * (1-a.w) + max * a.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static long4 Lerp(long4 min, long max, long a) => long4(min.x * (1-a) + max * a, min.y * (1-a) + max * a, min.z * (1-a) + max * a, min.w * (1-a) + max * a);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static long4 Lerp(long min, long4 max, long4 a) => long4(min * (1-a.x) + max.x * a.x, min * (1-a.y) + max.y * a.y, min * (1-a.z) + max.z * a.z, min * (1-a.w) + max.w * a.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static long4 Lerp(long min, long4 max, long a) => long4(min * (1-a) + max.x * a, min * (1-a) + max.y * a, min * (1-a) + max.z * a, min * (1-a) + max.w * a);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static long4 Lerp(long min, long max, long4 a) => long4(min * (1-a.x) + max * a.x, min * (1-a.y) + max * a.y, min * (1-a.z) + max * a.z, min * (1-a.w) + max * a.w);
        
        /// <summary>
        /// Returns a long from the application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static long4 Lerp(long min, long max, long a) => long4(min * (1-a) + max * a);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static long4 Fma(long4 a, long4 b, long4 c) => long4(a.x * b.x + c.x, a.y * b.y + c.y, a.z * b.z + c.z, a.w * b.w + c.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static long4 Fma(long4 a, long4 b, long c) => long4(a.x * b.x + c, a.y * b.y + c, a.z * b.z + c, a.w * b.w + c);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static long4 Fma(long4 a, long b, long4 c) => long4(a.x * b + c.x, a.y * b + c.y, a.z * b + c.z, a.w * b + c.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static long4 Fma(long4 a, long b, long c) => long4(a.x * b + c, a.y * b + c, a.z * b + c, a.w * b + c);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static long4 Fma(long a, long4 b, long4 c) => long4(a * b.x + c.x, a * b.y + c.y, a * b.z + c.z, a * b.w + c.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static long4 Fma(long a, long4 b, long c) => long4(a * b.x + c, a * b.y + c, a * b.z + c, a * b.w + c);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static long4 Fma(long a, long b, long4 c) => long4(a * b + c.x, a * b + c.y, a * b + c.z, a * b + c.w);
        
        /// <summary>
        /// Returns a long from the application of Fma (a * b + c).
        /// </summary>
        public static long4 Fma(long a, long b, long c) => long4(a * b + c);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static long4 Add(long4 lhs, long4 rhs) => long4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static long4 Add(long4 lhs, long rhs) => long4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static long4 Add(long lhs, long4 rhs) => long4(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z, lhs + rhs.w);
        
        /// <summary>
        /// Returns a long from the application of Add (lhs + rhs).
        /// </summary>
        public static long4 Add(long lhs, long rhs) => long4(lhs + rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static long4 Sub(long4 lhs, long4 rhs) => long4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static long4 Sub(long4 lhs, long rhs) => long4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static long4 Sub(long lhs, long4 rhs) => long4(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z, lhs - rhs.w);
        
        /// <summary>
        /// Returns a long from the application of Sub (lhs - rhs).
        /// </summary>
        public static long4 Sub(long lhs, long rhs) => long4(lhs - rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static long4 Mul(long4 lhs, long4 rhs) => long4(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static long4 Mul(long4 lhs, long rhs) => long4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static long4 Mul(long lhs, long4 rhs) => long4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w);
        
        /// <summary>
        /// Returns a long from the application of Mul (lhs * rhs).
        /// </summary>
        public static long4 Mul(long lhs, long rhs) => long4(lhs * rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static long4 Div(long4 lhs, long4 rhs) => long4(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z, lhs.w / rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static long4 Div(long4 lhs, long rhs) => long4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static long4 Div(long lhs, long4 rhs) => long4(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z, lhs / rhs.w);
        
        /// <summary>
        /// Returns a long from the application of Div (lhs / rhs).
        /// </summary>
        public static long4 Div(long lhs, long rhs) => long4(lhs / rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static long4 Xor(long4 lhs, long4 rhs) => long4(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z, lhs.w ^ rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static long4 Xor(long4 lhs, long rhs) => long4(lhs.x ^ rhs, lhs.y ^ rhs, lhs.z ^ rhs, lhs.w ^ rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static long4 Xor(long lhs, long4 rhs) => long4(lhs ^ rhs.x, lhs ^ rhs.y, lhs ^ rhs.z, lhs ^ rhs.w);
        
        /// <summary>
        /// Returns a long from the application of Xor (lhs ^ rhs).
        /// </summary>
        public static long4 Xor(long lhs, long rhs) => long4(lhs ^ rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static long4 BitwiseOr(long4 lhs, long4 rhs) => long4(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z, lhs.w | rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static long4 BitwiseOr(long4 lhs, long rhs) => long4(lhs.x | rhs, lhs.y | rhs, lhs.z | rhs, lhs.w | rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static long4 BitwiseOr(long lhs, long4 rhs) => long4(lhs | rhs.x, lhs | rhs.y, lhs | rhs.z, lhs | rhs.w);
        
        /// <summary>
        /// Returns a long from the application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static long4 BitwiseOr(long lhs, long rhs) => long4(lhs | rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static long4 BitwiseAnd(long4 lhs, long4 rhs) => long4(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z, lhs.w & rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static long4 BitwiseAnd(long4 lhs, long rhs) => long4(lhs.x & rhs, lhs.y & rhs, lhs.z & rhs, lhs.w & rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static long4 BitwiseAnd(long lhs, long4 rhs) => long4(lhs & rhs.x, lhs & rhs.y, lhs & rhs.z, lhs & rhs.w);
        
        /// <summary>
        /// Returns a long from the application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static long4 BitwiseAnd(long lhs, long rhs) => long4(lhs & rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static long4 LeftShift(long4 lhs, int4 rhs) => long4(lhs.x << rhs.x, lhs.y << rhs.y, lhs.z << rhs.z, lhs.w << rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static long4 LeftShift(long4 lhs, int rhs) => long4(lhs.x << rhs, lhs.y << rhs, lhs.z << rhs, lhs.w << rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static long4 LeftShift(long lhs, int4 rhs) => long4(lhs << rhs.x, lhs << rhs.y, lhs << rhs.z, lhs << rhs.w);
        
        /// <summary>
        /// Returns a long from the application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static long4 LeftShift(long lhs, int rhs) => long4(lhs << rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static long4 RightShift(long4 lhs, int4 rhs) => long4(lhs.x >> rhs.x, lhs.y >> rhs.y, lhs.z >> rhs.z, lhs.w >> rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static long4 RightShift(long4 lhs, int rhs) => long4(lhs.x >> rhs, lhs.y >> rhs, lhs.z >> rhs, lhs.w >> rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static long4 RightShift(long lhs, int4 rhs) => long4(lhs >> rhs.x, lhs >> rhs.y, lhs >> rhs.z, lhs >> rhs.w);
        
        /// <summary>
        /// Returns a long from the application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static long4 RightShift(long lhs, int rhs) => long4(lhs >> rhs);
        
        /// <summary>
        /// Returns a long4 with independent and identically distributed uniform integer values between 0 (inclusive) and maxValue (exclusive). (A maxValue of 0 is allowed and returns 0.)
        /// </summary>
        public static long4 Random(Random random, long4 maxValue) => long4((long)random.Next((int)maxValue.x), (long)random.Next((int)maxValue.y), (long)random.Next((int)maxValue.z), (long)random.Next((int)maxValue.w));
        
        /// <summary>
        /// Returns a long4 with independent and identically distributed uniform integer values between 0 (inclusive) and maxValue (exclusive). (A maxValue of 0 is allowed and returns 0.)
        /// </summary>
        public static long4 Random(Random random, long maxValue) => long4((long)random.Next((int)maxValue));
        
        /// <summary>
        /// Returns a long4 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static long4 Random(Random random, long4 minValue, long4 maxValue) => long4((long)random.Next((int)minValue.x, (int)maxValue.x), (long)random.Next((int)minValue.y, (int)maxValue.y), (long)random.Next((int)minValue.z, (int)maxValue.z), (long)random.Next((int)minValue.w, (int)maxValue.w));
        
        /// <summary>
        /// Returns a long4 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static long4 Random(Random random, long4 minValue, long maxValue) => long4((long)random.Next((int)minValue.x, (int)maxValue), (long)random.Next((int)minValue.y, (int)maxValue), (long)random.Next((int)minValue.z, (int)maxValue), (long)random.Next((int)minValue.w, (int)maxValue));
        
        /// <summary>
        /// Returns a long4 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static long4 Random(Random random, long minValue, long4 maxValue) => long4((long)random.Next((int)minValue, (int)maxValue.x), (long)random.Next((int)minValue, (int)maxValue.y), (long)random.Next((int)minValue, (int)maxValue.z), (long)random.Next((int)minValue, (int)maxValue.w));
        
        /// <summary>
        /// Returns a long4 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static long4 Random(Random random, long minValue, long maxValue) => long4((long)random.Next((int)minValue, (int)maxValue));
        
        /// <summary>
        /// Returns a long4 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static long4 RandomUniform(Random random, long4 minValue, long4 maxValue) => long4((long)random.Next((int)minValue.x, (int)maxValue.x), (long)random.Next((int)minValue.y, (int)maxValue.y), (long)random.Next((int)minValue.z, (int)maxValue.z), (long)random.Next((int)minValue.w, (int)maxValue.w));
        
        /// <summary>
        /// Returns a long4 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static long4 RandomUniform(Random random, long4 minValue, long maxValue) => long4((long)random.Next((int)minValue.x, (int)maxValue), (long)random.Next((int)minValue.y, (int)maxValue), (long)random.Next((int)minValue.z, (int)maxValue), (long)random.Next((int)minValue.w, (int)maxValue));
        
        /// <summary>
        /// Returns a long4 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static long4 RandomUniform(Random random, long minValue, long4 maxValue) => long4((long)random.Next((int)minValue, (int)maxValue.x), (long)random.Next((int)minValue, (int)maxValue.y), (long)random.Next((int)minValue, (int)maxValue.z), (long)random.Next((int)minValue, (int)maxValue.w));
        
        /// <summary>
        /// Returns a long4 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static long4 RandomUniform(Random random, long minValue, long maxValue) => long4((long)random.Next((int)minValue, (int)maxValue));

        //#endregion


        //#region Component-Wise Operator Overloads
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool4 operator<(long4 lhs, long4 rhs) => bool4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool4 operator<(long4 lhs, long rhs) => bool4(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs, lhs.w < rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool4 operator<(long lhs, long4 rhs) => bool4(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z, lhs < rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool4 operator<=(long4 lhs, long4 rhs) => bool4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool4 operator<=(long4 lhs, long rhs) => bool4(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs, lhs.w <= rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool4 operator<=(long lhs, long4 rhs) => bool4(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z, lhs <= rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool4 operator>(long4 lhs, long4 rhs) => bool4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool4 operator>(long4 lhs, long rhs) => bool4(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs, lhs.w > rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool4 operator>(long lhs, long4 rhs) => bool4(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z, lhs > rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool4 operator>=(long4 lhs, long4 rhs) => bool4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool4 operator>=(long4 lhs, long rhs) => bool4(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs, lhs.w >= rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool4 operator>=(long lhs, long4 rhs) => bool4(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z, lhs >= rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static long4 operator+(long4 lhs, long4 rhs) => long4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static long4 operator+(long4 lhs, long rhs) => long4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static long4 operator+(long lhs, long4 rhs) => long4(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z, lhs + rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static long4 operator-(long4 lhs, long4 rhs) => long4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static long4 operator-(long4 lhs, long rhs) => long4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static long4 operator-(long lhs, long4 rhs) => long4(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z, lhs - rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static long4 operator*(long4 lhs, long4 rhs) => long4(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static long4 operator*(long4 lhs, long rhs) => long4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static long4 operator*(long lhs, long4 rhs) => long4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static long4 operator/(long4 lhs, long4 rhs) => long4(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z, lhs.w / rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static long4 operator/(long4 lhs, long rhs) => long4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static long4 operator/(long lhs, long4 rhs) => long4(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z, lhs / rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator- (-v).
        /// </summary>
        public static long4 operator-(long4 v) => long4(-v.x, -v.y, -v.z, -v.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator~ (~v).
        /// </summary>
        public static long4 operator~(long4 v) => long4(~v.x, ~v.y, ~v.z, ~v.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static long4 operator^(long4 lhs, long4 rhs) => long4(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z, lhs.w ^ rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static long4 operator^(long4 lhs, long rhs) => long4(lhs.x ^ rhs, lhs.y ^ rhs, lhs.z ^ rhs, lhs.w ^ rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static long4 operator^(long lhs, long4 rhs) => long4(lhs ^ rhs.x, lhs ^ rhs.y, lhs ^ rhs.z, lhs ^ rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static long4 operator|(long4 lhs, long4 rhs) => long4(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z, lhs.w | rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static long4 operator|(long4 lhs, long rhs) => long4(lhs.x | rhs, lhs.y | rhs, lhs.z | rhs, lhs.w | rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static long4 operator|(long lhs, long4 rhs) => long4(lhs | rhs.x, lhs | rhs.y, lhs | rhs.z, lhs | rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static long4 operator&(long4 lhs, long4 rhs) => long4(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z, lhs.w & rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static long4 operator&(long4 lhs, long rhs) => long4(lhs.x & rhs, lhs.y & rhs, lhs.z & rhs, lhs.w & rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static long4 operator&(long lhs, long4 rhs) => long4(lhs & rhs.x, lhs & rhs.y, lhs & rhs.z, lhs & rhs.w);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator&lt;&lt; (lhs &lt;&lt; rhs).
        /// </summary>
        public static long4 operator<<(long4 lhs, int rhs) => long4(lhs.x << rhs, lhs.y << rhs, lhs.z << rhs, lhs.w << rhs);
        
        /// <summary>
        /// Returns a long4 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; rhs).
        /// </summary>
        public static long4 operator>>(long4 lhs, int rhs) => long4(lhs.x >> rhs, lhs.y >> rhs, lhs.z >> rhs, lhs.w >> rhs);

        //#endregion

    }
}
