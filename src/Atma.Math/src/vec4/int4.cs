using System;
namespace Atma
{
    
    /// <summary>
    /// A vector of type int with 4 components.
    /// </summary>
    [Union]
    public struct int4 : IHashable
    {

        //#region Fields
        
        /// <summary>
        /// component data
        /// </summary>
        public int[4] values;
        
        /// <summary>
        /// Returns an object that can be used for arbitrary swizzling (e.g. swizzle.zy)
        /// </summary>
        public readonly swizzle_int4 swizzle;

        //#endregion


        //#region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public this(int x, int y, int z, int w)
        {
            values = .(x,y,z,w);
        }
        
        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public this(int v)
        {
            values = .(v,v,v,v);
        }
        
        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public this(int2 v)
        {
            values = .(v.x,v.y,0,0);
        }
        
        /// <summary>
        /// from-vector-and-value constructor (empty fields are zero/false)
        /// </summary>
        public this(int2 v, int z)
        {
            values = .(v.x,v.y,z,0);
        }
        
        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public this(int2 v, int z, int w)
        {
            values = .(v.x,v.y,z,w);
        }
        
        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public this(int3 v)
        {
            values = .(v.x,v.y,v.z,0);
        }
        
        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public this(int3 v, int w)
        {
            values = .(v.x,v.y,v.z,w);
        }
        
        /// <summary>
        /// from-vector constructor
        /// </summary>
        public this(int4 v)
        {
            values = .(v.x,v.y,v.z,v.w);
        }
        
        /// <summary>
        /// From-array constructor (superfluous values are ignored, missing values are zero-filled).
        /// </summary>
        public this(int[] v)
        {
            let c = v.Count;
            values = .((c < 0) ? 0 : v[0],(c < 1) ? 0 : v[1],(c < 2) ? 0 : v[2],(c < 3) ? 0 : v[3]);
        }
        
        /// <summary>
        /// From-array constructor with base index (superfluous values are ignored, missing values are zero-filled).
        /// </summary>
        public this(int[] v, int startIndex)
        {
            let c = v.Count;
            values = .((c + startIndex < 0) ? 0 : v[0 + startIndex],(c + startIndex < 1) ? 0 : v[1 + startIndex],(c + startIndex < 2) ? 0 : v[2 + startIndex],(c + startIndex < 3) ? 0 : v[3 + startIndex]);
        }

        //#endregion


        //#region Implicit Operators
        
        /// <summary>
        /// Implicitly converts this to a long4.
        /// </summary>
        public static implicit operator long4(int4 v) =>  long4((long)v.x, (long)v.y, (long)v.z, (long)v.w);
        
        /// <summary>
        /// Implicitly converts this to a float4.
        /// </summary>
        public static implicit operator float4(int4 v) =>  float4((float)v.x, (float)v.y, (float)v.z, (float)v.w);
        
        /// <summary>
        /// Implicitly converts this to a double4.
        /// </summary>
        public static implicit operator double4(int4 v) =>  double4((double)v.x, (double)v.y, (double)v.z, (double)v.w);

        //#endregion


        //#region Explicit Operators
        
        /// <summary>
        /// Explicitly converts this to a int2.
        /// </summary>
        public static explicit operator int2(int4 v) =>  int2((int)v.x, (int)v.y);
        
        /// <summary>
        /// Explicitly converts this to a int3.
        /// </summary>
        public static explicit operator int3(int4 v) =>  int3((int)v.x, (int)v.y, (int)v.z);
        
        /// <summary>
        /// Explicitly converts this to a uint2.
        /// </summary>
        public static explicit operator uint2(int4 v) =>  uint2((uint)v.x, (uint)v.y);
        
        /// <summary>
        /// Explicitly converts this to a uint3.
        /// </summary>
        public static explicit operator uint3(int4 v) =>  uint3((uint)v.x, (uint)v.y, (uint)v.z);
        
        /// <summary>
        /// Explicitly converts this to a uint4.
        /// </summary>
        public static explicit operator uint4(int4 v) =>  uint4((uint)v.x, (uint)v.y, (uint)v.z, (uint)v.w);
        
        /// <summary>
        /// Explicitly converts this to a float2.
        /// </summary>
        public static explicit operator float2(int4 v) =>  float2((float)v.x, (float)v.y);
        
        /// <summary>
        /// Explicitly converts this to a float3.
        /// </summary>
        public static explicit operator float3(int4 v) =>  float3((float)v.x, (float)v.y, (float)v.z);
        
        /// <summary>
        /// Explicitly converts this to a double2.
        /// </summary>
        public static explicit operator double2(int4 v) =>  double2((double)v.x, (double)v.y);
        
        /// <summary>
        /// Explicitly converts this to a double3.
        /// </summary>
        public static explicit operator double3(int4 v) =>  double3((double)v.x, (double)v.y, (double)v.z);
        
        /// <summary>
        /// Explicitly converts this to a long2.
        /// </summary>
        public static explicit operator long2(int4 v) =>  long2((long)v.x, (long)v.y);
        
        /// <summary>
        /// Explicitly converts this to a long3.
        /// </summary>
        public static explicit operator long3(int4 v) =>  long3((long)v.x, (long)v.y, (long)v.z);
        
        /// <summary>
        /// Explicitly converts this to a bool2.
        /// </summary>
        public static explicit operator bool2(int4 v) =>  bool2(v.x != 0, v.y != 0);
        
        /// <summary>
        /// Explicitly converts this to a bool3.
        /// </summary>
        public static explicit operator bool3(int4 v) =>  bool3(v.x != 0, v.y != 0, v.z != 0);
        
        /// <summary>
        /// Explicitly converts this to a bool4.
        /// </summary>
        public static explicit operator bool4(int4 v) =>  bool4(v.x != 0, v.y != 0, v.z != 0, v.w != 0);

        //#endregion


        //#region Indexer
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public int this[int index]
        {
            [Inline]get
            {
                System.Diagnostics.Debug.Assert(index >=0 && index < 4, "index out of range");
                unchecked { return values[index]; }
            }
            [Inline]set mut
            {
                System.Diagnostics.Debug.Assert(index >=0 && index < 4, "index out of range");
                unchecked { values[index] = value;}
            }
        }

        //#endregion


        //#region Properties
        
        /// <summary>
        /// x-component
        /// </summary>
        public int x
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
        public int y
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
        public int z
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
        public int w
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
        public int2 xy
        {
            [Inline]get
            {
                return  int2(x, y);
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
        public int2 xz
        {
            [Inline]get
            {
                return  int2(x, z);
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
        public int2 yz
        {
            [Inline]get
            {
                return  int2(y, z);
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
        public int3 xyz
        {
            [Inline]get
            {
                return  int3(x, y, z);
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
        public int2 xw
        {
            [Inline]get
            {
                return  int2(x, w);
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
        public int2 yw
        {
            [Inline]get
            {
                return  int2(y, w);
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
        public int3 xyw
        {
            [Inline]get
            {
                return  int3(x, y, w);
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
        public int2 zw
        {
            [Inline]get
            {
                return  int2(z, w);
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
        public int3 xzw
        {
            [Inline]get
            {
                return  int3(x, z, w);
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
        public int3 yzw
        {
            [Inline]get
            {
                return  int3(y, z, w);
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
        public int4 xyzw
        {
            [Inline]get
            {
                return  int4(x, y, z, w);
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
        public int2 rg
        {
            [Inline]get
            {
                return  int2(x, y);
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
        public int2 rb
        {
            [Inline]get
            {
                return  int2(x, z);
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
        public int2 gb
        {
            [Inline]get
            {
                return  int2(y, z);
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
        public int3 rgb
        {
            [Inline]get
            {
                return  int3(x, y, z);
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
        public int2 ra
        {
            [Inline]get
            {
                return  int2(x, w);
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
        public int2 ga
        {
            [Inline]get
            {
                return  int2(y, w);
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
        public int3 rga
        {
            [Inline]get
            {
                return  int3(x, y, w);
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
        public int2 ba
        {
            [Inline]get
            {
                return  int2(z, w);
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
        public int3 rba
        {
            [Inline]get
            {
                return  int3(x, z, w);
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
        public int3 gba
        {
            [Inline]get
            {
                return  int3(y, z, w);
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
        public int4 rgba
        {
            [Inline]get
            {
                return  int4(x, y, z, w);
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
        public int r
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
        public int g
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
        public int b
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
        public int a
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
        public int MinElement => System.Math.Min(System.Math.Min(x, y), System.Math.Min(z, w));
        
        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public int MaxElement => System.Math.Max(System.Math.Max(x, y), System.Math.Max(z, w));
        
        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public float Length => (float)System.Math.Sqrt(((x*x + y*y) + (z*z + w*w)));
        
        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        public float LengthSqr => ((x*x + y*y) + (z*z + w*w));
        
        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        public int Sum => ((x + y) + (z + w));
        
        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public float Norm => (float)System.Math.Sqrt(((x*x + y*y) + (z*z + w*w)));
        
        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public float Norm1 => ((System.Math.Abs(x) + System.Math.Abs(y)) + (System.Math.Abs(z) + System.Math.Abs(w)));
        
        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        public float Norm2 => (float)System.Math.Sqrt(((x*x + y*y) + (z*z + w*w)));
        
        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public float NormMax => System.Math.Max(System.Math.Max(System.Math.Abs(x), System.Math.Abs(y)), System.Math.Max(System.Math.Abs(z), System.Math.Abs(w)));

        //#endregion


        //#region Static Properties
        
        /// <summary>
        /// Predefined all-zero vector
        /// </summary>
        readonly public static int4 Zero  =  int4(0, 0, 0, 0);
        
        /// <summary>
        /// Predefined all-ones vector
        /// </summary>
        readonly public static int4 Ones  =  int4(1, 1, 1, 1);
        
        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        readonly public static int4 UnitX  =  int4(1, 0, 0, 0);
        
        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        readonly public static int4 NegativeUnitX  =  int4(-1, 0, 0, 0);
        
        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        readonly public static int4 UnitY  =  int4(0, 1, 0, 0);
        
        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        readonly public static int4 NegativeUnitY  =  int4(0, -1, 0, 0);
        
        /// <summary>
        /// Predefined unit-Z vector
        /// </summary>
        readonly public static int4 UnitZ  =  int4(0, 0, 1, 0);
        
        /// <summary>
        /// Predefined unit-Z vector
        /// </summary>
        readonly public static int4 NegativeUnitZ  =  int4(0, 0, -1, 0);
        
        /// <summary>
        /// Predefined unit-W vector
        /// </summary>
        readonly public static int4 UnitW  =  int4(0, 0, 0, 1);
        
        /// <summary>
        /// Predefined unit-W vector
        /// </summary>
        readonly public static int4 NegativeUnitW  =  int4(0, 0, 0, -1);
        
        /// <summary>
        /// Predefined all-MaxValue vector
        /// </summary>
        readonly public static int4 MaxValue  =  int4(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);
        
        /// <summary>
        /// Predefined all-MinValue vector
        /// </summary>
        readonly public static int4 MinValue  =  int4(int.MinValue, int.MinValue, int.MinValue, int.MinValue);

        //#endregion


        //#region Operators
        
        /// <summary>
        /// Returns true if this equals rhs component-wise.
        /// </summary>
        public static bool operator==(int4 lhs, int4 rhs) => ((lhs.x == rhs.x && lhs.y == rhs.y) && (lhs.z == rhs.z && lhs.w == rhs.w));
        
        /// <summary>
        /// Returns true if this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator!=(int4 lhs, int4 rhs) => !((lhs.x == rhs.x && lhs.y == rhs.y) && (lhs.z == rhs.z && lhs.w == rhs.w));

        //#endregion


        //#region Functions
        
        /// <summary>
        /// Returns an array with all values
        /// </summary>
        public int[] ToArray() => new .[] ( x, y, z, w );
        
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
        public static int4x2 OuterProduct(int2 c, int4 r) =>  int4x2(c.x * r.x, c.y * r.x, c.x * r.y, c.y * r.y, c.x * r.z, c.y * r.z, c.x * r.w, c.y * r.w);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int2x4 OuterProduct(int4 c, int2 r) =>  int2x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int4x3 OuterProduct(int3 c, int4 r) =>  int4x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.x * r.w, c.y * r.w, c.z * r.w);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int3x4 OuterProduct(int4 c, int3 r) =>  int3x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.w * r.z);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int4x4 OuterProduct(int4 c, int4 r) =>  int4x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.w * r.z, c.x * r.w, c.y * r.w, c.z * r.w, c.w * r.w);
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static int Dot(int4 lhs, int4 rhs) => ((lhs.x * rhs.x + lhs.y * rhs.y) + (lhs.z * rhs.z + lhs.w * rhs.w));
        
        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static float Distance(int4 lhs, int4 rhs) => (lhs - rhs).Length;
        
        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static float DistanceSqr(int4 lhs, int4 rhs) => (lhs - rhs).LengthSqr;
        
        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static int4 Reflect(int4 I, int4 N) => I - 2 * Dot(N, I) * N;
        
        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static int4 Refract(int4 I, int4 N, int eta)
        {
            let dNI = Dot(N, I);
            let k = 1 - eta * eta * (1 - dNI * dNI);
            if (k < 0) return Zero;
            return eta * I - (eta * dNI + (int)System.Math.Sqrt(k)) * N;
        }
        
        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static int4 FaceForward(int4 N, int4 I, int4 Nref) => Dot(Nref, I) < 0 ? N : -N;
        
        /// <summary>
        /// Returns a int4 with independent and identically distributed uniform integer values between 0 (inclusive) and int.MaxValue (exclusive).
        /// </summary>
        public static int4 Random(Random random) =>  int4((int)random.Next(int64.MaxValue), (int)random.Next(int64.MaxValue), (int)random.Next(int64.MaxValue), (int)random.Next(int64.MaxValue));

        //#endregion


        //#region Component-Wise Static Functions
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(int4 lhs, int4 rhs) => bool4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(int4 lhs, int rhs) => bool4(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs, lhs.w == rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(int lhs, int4 rhs) => bool4(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z, lhs == rhs.w);
        
        /// <summary>
        /// Returns a bool from the application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(int lhs, int rhs) => bool4(lhs == rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(int4 lhs, int4 rhs) => bool4(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(int4 lhs, int rhs) => bool4(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs, lhs.w != rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(int lhs, int4 rhs) => bool4(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z, lhs != rhs.w);
        
        /// <summary>
        /// Returns a bool from the application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(int lhs, int rhs) => bool4(lhs != rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(int4 lhs, int4 rhs) => bool4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(int4 lhs, int rhs) => bool4(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs, lhs.w > rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(int lhs, int4 rhs) => bool4(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z, lhs > rhs.w);
        
        /// <summary>
        /// Returns a bool from the application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(int lhs, int rhs) => bool4(lhs > rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(int4 lhs, int4 rhs) => bool4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(int4 lhs, int rhs) => bool4(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs, lhs.w >= rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(int lhs, int4 rhs) => bool4(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z, lhs >= rhs.w);
        
        /// <summary>
        /// Returns a bool from the application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(int lhs, int rhs) => bool4(lhs >= rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(int4 lhs, int4 rhs) => bool4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(int4 lhs, int rhs) => bool4(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs, lhs.w < rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(int lhs, int4 rhs) => bool4(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z, lhs < rhs.w);
        
        /// <summary>
        /// Returns a bool from the application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(int lhs, int rhs) => bool4(lhs < rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(int4 lhs, int4 rhs) => bool4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(int4 lhs, int rhs) => bool4(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs, lhs.w <= rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(int lhs, int4 rhs) => bool4(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z, lhs <= rhs.w);
        
        /// <summary>
        /// Returns a bool from the application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(int lhs, int rhs) => bool4(lhs <= rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Abs (System.Math.Abs(v)).
        /// </summary>
        public static int4 Abs(int4 v) => int4(System.Math.Abs(v.x), System.Math.Abs(v.y), System.Math.Abs(v.z), System.Math.Abs(v.w));
        
        /// <summary>
        /// Returns a int from the application of Abs (System.Math.Abs(v)).
        /// </summary>
        public static int4 Abs(int v) => int4(System.Math.Abs(v));
        
        /// <summary>
        /// Returns a int4 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static int4 HermiteInterpolationOrder3(int4 v) => int4((3 - 2 * v.x) * v.x * v.x, (3 - 2 * v.y) * v.y * v.y, (3 - 2 * v.z) * v.z * v.z, (3 - 2 * v.w) * v.w * v.w);
        
        /// <summary>
        /// Returns a int from the application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static int4 HermiteInterpolationOrder3(int v) => int4((3 - 2 * v) * v * v);
        
        /// <summary>
        /// Returns a int4 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static int4 HermiteInterpolationOrder5(int4 v) => int4(((6 * v.x - 15) * v.x + 10) * v.x * v.x * v.x, ((6 * v.y - 15) * v.y + 10) * v.y * v.y * v.y, ((6 * v.z - 15) * v.z + 10) * v.z * v.z * v.z, ((6 * v.w - 15) * v.w + 10) * v.w * v.w * v.w);
        
        /// <summary>
        /// Returns a int from the application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static int4 HermiteInterpolationOrder5(int v) => int4(((6 * v - 15) * v + 10) * v * v * v);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Sqr (v * v).
        /// </summary>
        public static int4 Sqr(int4 v) => int4(v.x * v.x, v.y * v.y, v.z * v.z, v.w * v.w);
        
        /// <summary>
        /// Returns a int from the application of Sqr (v * v).
        /// </summary>
        public static int4 Sqr(int v) => int4(v * v);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static int4 Pow2(int4 v) => int4(v.x * v.x, v.y * v.y, v.z * v.z, v.w * v.w);
        
        /// <summary>
        /// Returns a int from the application of Pow2 (v * v).
        /// </summary>
        public static int4 Pow2(int v) => int4(v * v);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static int4 Pow3(int4 v) => int4(v.x * v.x * v.x, v.y * v.y * v.y, v.z * v.z * v.z, v.w * v.w * v.w);
        
        /// <summary>
        /// Returns a int from the application of Pow3 (v * v * v).
        /// </summary>
        public static int4 Pow3(int v) => int4(v * v * v);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Step (v &gt;= 0 ? 1 : 0).
        /// </summary>
        public static int4 Step(int4 v) => int4(v.x >= 0 ? 1 : 0, v.y >= 0 ? 1 : 0, v.z >= 0 ? 1 : 0, v.w >= 0 ? 1 : 0);
        
        /// <summary>
        /// Returns a int from the application of Step (v &gt;= 0 ? 1 : 0).
        /// </summary>
        public static int4 Step(int v) => int4(v >= 0 ? 1 : 0);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Sqrt ((int)System.Math.Sqrt((double)v)).
        /// </summary>
        public static int4 Sqrt(int4 v) => int4((int)System.Math.Sqrt((double)v.x), (int)System.Math.Sqrt((double)v.y), (int)System.Math.Sqrt((double)v.z), (int)System.Math.Sqrt((double)v.w));
        
        /// <summary>
        /// Returns a int from the application of Sqrt ((int)System.Math.Sqrt((double)v)).
        /// </summary>
        public static int4 Sqrt(int v) => int4((int)System.Math.Sqrt((double)v));
        
        /// <summary>
        /// Returns a int4 from component-wise application of InverseSqrt ((int)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        public static int4 InverseSqrt(int4 v) => int4((int)(1.0 / System.Math.Sqrt((double)v.x)), (int)(1.0 / System.Math.Sqrt((double)v.y)), (int)(1.0 / System.Math.Sqrt((double)v.z)), (int)(1.0 / System.Math.Sqrt((double)v.w)));
        
        /// <summary>
        /// Returns a int from the application of InverseSqrt ((int)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        public static int4 InverseSqrt(int v) => int4((int)(1.0 / System.Math.Sqrt((double)v)));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Sign (System.Math.Sign(v)).
        /// </summary>
        public static int4 Sign(int4 v) => int4(System.Math.Sign(v.x), System.Math.Sign(v.y), System.Math.Sign(v.z), System.Math.Sign(v.w));
        
        /// <summary>
        /// Returns a int from the application of Sign (System.Math.Sign(v)).
        /// </summary>
        public static int4 Sign(int v) => int4(System.Math.Sign(v));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static int4 Max(int4 lhs, int4 rhs) => int4(System.Math.Max(lhs.x, rhs.x), System.Math.Max(lhs.y, rhs.y), System.Math.Max(lhs.z, rhs.z), System.Math.Max(lhs.w, rhs.w));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static int4 Max(int4 lhs, int rhs) => int4(System.Math.Max(lhs.x, rhs), System.Math.Max(lhs.y, rhs), System.Math.Max(lhs.z, rhs), System.Math.Max(lhs.w, rhs));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static int4 Max(int lhs, int4 rhs) => int4(System.Math.Max(lhs, rhs.x), System.Math.Max(lhs, rhs.y), System.Math.Max(lhs, rhs.z), System.Math.Max(lhs, rhs.w));
        
        /// <summary>
        /// Returns a int from the application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static int4 Max(int lhs, int rhs) => int4(System.Math.Max(lhs, rhs));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static int4 Min(int4 lhs, int4 rhs) => int4(System.Math.Min(lhs.x, rhs.x), System.Math.Min(lhs.y, rhs.y), System.Math.Min(lhs.z, rhs.z), System.Math.Min(lhs.w, rhs.w));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static int4 Min(int4 lhs, int rhs) => int4(System.Math.Min(lhs.x, rhs), System.Math.Min(lhs.y, rhs), System.Math.Min(lhs.z, rhs), System.Math.Min(lhs.w, rhs));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static int4 Min(int lhs, int4 rhs) => int4(System.Math.Min(lhs, rhs.x), System.Math.Min(lhs, rhs.y), System.Math.Min(lhs, rhs.z), System.Math.Min(lhs, rhs.w));
        
        /// <summary>
        /// Returns a int from the application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static int4 Min(int lhs, int rhs) => int4(System.Math.Min(lhs, rhs));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Pow ((int)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int4 Pow(int4 lhs, int4 rhs) => int4((int)System.Math.Pow((double)lhs.x, (double)rhs.x), (int)System.Math.Pow((double)lhs.y, (double)rhs.y), (int)System.Math.Pow((double)lhs.z, (double)rhs.z), (int)System.Math.Pow((double)lhs.w, (double)rhs.w));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Pow ((int)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int4 Pow(int4 lhs, int rhs) => int4((int)System.Math.Pow((double)lhs.x, (double)rhs), (int)System.Math.Pow((double)lhs.y, (double)rhs), (int)System.Math.Pow((double)lhs.z, (double)rhs), (int)System.Math.Pow((double)lhs.w, (double)rhs));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Pow ((int)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int4 Pow(int lhs, int4 rhs) => int4((int)System.Math.Pow((double)lhs, (double)rhs.x), (int)System.Math.Pow((double)lhs, (double)rhs.y), (int)System.Math.Pow((double)lhs, (double)rhs.z), (int)System.Math.Pow((double)lhs, (double)rhs.w));
        
        /// <summary>
        /// Returns a int from the application of Pow ((int)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int4 Pow(int lhs, int rhs) => int4((int)System.Math.Pow((double)lhs, (double)rhs));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Log ((int)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int4 Log(int4 lhs, int4 rhs) => int4((int)System.Math.Log((double)lhs.x, (double)rhs.x), (int)System.Math.Log((double)lhs.y, (double)rhs.y), (int)System.Math.Log((double)lhs.z, (double)rhs.z), (int)System.Math.Log((double)lhs.w, (double)rhs.w));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Log ((int)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int4 Log(int4 lhs, int rhs) => int4((int)System.Math.Log((double)lhs.x, (double)rhs), (int)System.Math.Log((double)lhs.y, (double)rhs), (int)System.Math.Log((double)lhs.z, (double)rhs), (int)System.Math.Log((double)lhs.w, (double)rhs));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Log ((int)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int4 Log(int lhs, int4 rhs) => int4((int)System.Math.Log((double)lhs, (double)rhs.x), (int)System.Math.Log((double)lhs, (double)rhs.y), (int)System.Math.Log((double)lhs, (double)rhs.z), (int)System.Math.Log((double)lhs, (double)rhs.w));
        
        /// <summary>
        /// Returns a int from the application of Log ((int)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int4 Log(int lhs, int rhs) => int4((int)System.Math.Log((double)lhs, (double)rhs));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static int4 Clamp(int4 v, int4 min, int4 max) => int4(System.Math.Min(System.Math.Max(v.x, min.x), max.x), System.Math.Min(System.Math.Max(v.y, min.y), max.y), System.Math.Min(System.Math.Max(v.z, min.z), max.z), System.Math.Min(System.Math.Max(v.w, min.w), max.w));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static int4 Clamp(int4 v, int4 min, int max) => int4(System.Math.Min(System.Math.Max(v.x, min.x), max), System.Math.Min(System.Math.Max(v.y, min.y), max), System.Math.Min(System.Math.Max(v.z, min.z), max), System.Math.Min(System.Math.Max(v.w, min.w), max));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static int4 Clamp(int4 v, int min, int4 max) => int4(System.Math.Min(System.Math.Max(v.x, min), max.x), System.Math.Min(System.Math.Max(v.y, min), max.y), System.Math.Min(System.Math.Max(v.z, min), max.z), System.Math.Min(System.Math.Max(v.w, min), max.w));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static int4 Clamp(int4 v, int min, int max) => int4(System.Math.Min(System.Math.Max(v.x, min), max), System.Math.Min(System.Math.Max(v.y, min), max), System.Math.Min(System.Math.Max(v.z, min), max), System.Math.Min(System.Math.Max(v.w, min), max));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static int4 Clamp(int v, int4 min, int4 max) => int4(System.Math.Min(System.Math.Max(v, min.x), max.x), System.Math.Min(System.Math.Max(v, min.y), max.y), System.Math.Min(System.Math.Max(v, min.z), max.z), System.Math.Min(System.Math.Max(v, min.w), max.w));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static int4 Clamp(int v, int4 min, int max) => int4(System.Math.Min(System.Math.Max(v, min.x), max), System.Math.Min(System.Math.Max(v, min.y), max), System.Math.Min(System.Math.Max(v, min.z), max), System.Math.Min(System.Math.Max(v, min.w), max));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static int4 Clamp(int v, int min, int4 max) => int4(System.Math.Min(System.Math.Max(v, min), max.x), System.Math.Min(System.Math.Max(v, min), max.y), System.Math.Min(System.Math.Max(v, min), max.z), System.Math.Min(System.Math.Max(v, min), max.w));
        
        /// <summary>
        /// Returns a int from the application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static int4 Clamp(int v, int min, int max) => int4(System.Math.Min(System.Math.Max(v, min), max));
        
        /// <summary>
        /// Returns a int4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int4 Mix(int4 min, int4 max, int4 a) => int4(min.x * (1-a.x) + max.x * a.x, min.y * (1-a.y) + max.y * a.y, min.z * (1-a.z) + max.z * a.z, min.w * (1-a.w) + max.w * a.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int4 Mix(int4 min, int4 max, int a) => int4(min.x * (1-a) + max.x * a, min.y * (1-a) + max.y * a, min.z * (1-a) + max.z * a, min.w * (1-a) + max.w * a);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int4 Mix(int4 min, int max, int4 a) => int4(min.x * (1-a.x) + max * a.x, min.y * (1-a.y) + max * a.y, min.z * (1-a.z) + max * a.z, min.w * (1-a.w) + max * a.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int4 Mix(int4 min, int max, int a) => int4(min.x * (1-a) + max * a, min.y * (1-a) + max * a, min.z * (1-a) + max * a, min.w * (1-a) + max * a);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int4 Mix(int min, int4 max, int4 a) => int4(min * (1-a.x) + max.x * a.x, min * (1-a.y) + max.y * a.y, min * (1-a.z) + max.z * a.z, min * (1-a.w) + max.w * a.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int4 Mix(int min, int4 max, int a) => int4(min * (1-a) + max.x * a, min * (1-a) + max.y * a, min * (1-a) + max.z * a, min * (1-a) + max.w * a);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int4 Mix(int min, int max, int4 a) => int4(min * (1-a.x) + max * a.x, min * (1-a.y) + max * a.y, min * (1-a.z) + max * a.z, min * (1-a.w) + max * a.w);
        
        /// <summary>
        /// Returns a int from the application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int4 Mix(int min, int max, int a) => int4(min * (1-a) + max * a);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int4 Lerp(int4 min, int4 max, int4 a) => int4(min.x * (1-a.x) + max.x * a.x, min.y * (1-a.y) + max.y * a.y, min.z * (1-a.z) + max.z * a.z, min.w * (1-a.w) + max.w * a.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int4 Lerp(int4 min, int4 max, int a) => int4(min.x * (1-a) + max.x * a, min.y * (1-a) + max.y * a, min.z * (1-a) + max.z * a, min.w * (1-a) + max.w * a);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int4 Lerp(int4 min, int max, int4 a) => int4(min.x * (1-a.x) + max * a.x, min.y * (1-a.y) + max * a.y, min.z * (1-a.z) + max * a.z, min.w * (1-a.w) + max * a.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int4 Lerp(int4 min, int max, int a) => int4(min.x * (1-a) + max * a, min.y * (1-a) + max * a, min.z * (1-a) + max * a, min.w * (1-a) + max * a);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int4 Lerp(int min, int4 max, int4 a) => int4(min * (1-a.x) + max.x * a.x, min * (1-a.y) + max.y * a.y, min * (1-a.z) + max.z * a.z, min * (1-a.w) + max.w * a.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int4 Lerp(int min, int4 max, int a) => int4(min * (1-a) + max.x * a, min * (1-a) + max.y * a, min * (1-a) + max.z * a, min * (1-a) + max.w * a);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int4 Lerp(int min, int max, int4 a) => int4(min * (1-a.x) + max * a.x, min * (1-a.y) + max * a.y, min * (1-a.z) + max * a.z, min * (1-a.w) + max * a.w);
        
        /// <summary>
        /// Returns a int from the application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int4 Lerp(int min, int max, int a) => int4(min * (1-a) + max * a);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int4 Fma(int4 a, int4 b, int4 c) => int4(a.x * b.x + c.x, a.y * b.y + c.y, a.z * b.z + c.z, a.w * b.w + c.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int4 Fma(int4 a, int4 b, int c) => int4(a.x * b.x + c, a.y * b.y + c, a.z * b.z + c, a.w * b.w + c);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int4 Fma(int4 a, int b, int4 c) => int4(a.x * b + c.x, a.y * b + c.y, a.z * b + c.z, a.w * b + c.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int4 Fma(int4 a, int b, int c) => int4(a.x * b + c, a.y * b + c, a.z * b + c, a.w * b + c);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int4 Fma(int a, int4 b, int4 c) => int4(a * b.x + c.x, a * b.y + c.y, a * b.z + c.z, a * b.w + c.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int4 Fma(int a, int4 b, int c) => int4(a * b.x + c, a * b.y + c, a * b.z + c, a * b.w + c);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int4 Fma(int a, int b, int4 c) => int4(a * b + c.x, a * b + c.y, a * b + c.z, a * b + c.w);
        
        /// <summary>
        /// Returns a int from the application of Fma (a * b + c).
        /// </summary>
        public static int4 Fma(int a, int b, int c) => int4(a * b + c);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static int4 Add(int4 lhs, int4 rhs) => int4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static int4 Add(int4 lhs, int rhs) => int4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static int4 Add(int lhs, int4 rhs) => int4(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z, lhs + rhs.w);
        
        /// <summary>
        /// Returns a int from the application of Add (lhs + rhs).
        /// </summary>
        public static int4 Add(int lhs, int rhs) => int4(lhs + rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static int4 Sub(int4 lhs, int4 rhs) => int4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static int4 Sub(int4 lhs, int rhs) => int4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static int4 Sub(int lhs, int4 rhs) => int4(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z, lhs - rhs.w);
        
        /// <summary>
        /// Returns a int from the application of Sub (lhs - rhs).
        /// </summary>
        public static int4 Sub(int lhs, int rhs) => int4(lhs - rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static int4 Mul(int4 lhs, int4 rhs) => int4(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static int4 Mul(int4 lhs, int rhs) => int4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static int4 Mul(int lhs, int4 rhs) => int4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w);
        
        /// <summary>
        /// Returns a int from the application of Mul (lhs * rhs).
        /// </summary>
        public static int4 Mul(int lhs, int rhs) => int4(lhs * rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static int4 Div(int4 lhs, int4 rhs) => int4(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z, lhs.w / rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static int4 Div(int4 lhs, int rhs) => int4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static int4 Div(int lhs, int4 rhs) => int4(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z, lhs / rhs.w);
        
        /// <summary>
        /// Returns a int from the application of Div (lhs / rhs).
        /// </summary>
        public static int4 Div(int lhs, int rhs) => int4(lhs / rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static int4 Xor(int4 lhs, int4 rhs) => int4(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z, lhs.w ^ rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static int4 Xor(int4 lhs, int rhs) => int4(lhs.x ^ rhs, lhs.y ^ rhs, lhs.z ^ rhs, lhs.w ^ rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static int4 Xor(int lhs, int4 rhs) => int4(lhs ^ rhs.x, lhs ^ rhs.y, lhs ^ rhs.z, lhs ^ rhs.w);
        
        /// <summary>
        /// Returns a int from the application of Xor (lhs ^ rhs).
        /// </summary>
        public static int4 Xor(int lhs, int rhs) => int4(lhs ^ rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int4 BitwiseOr(int4 lhs, int4 rhs) => int4(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z, lhs.w | rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int4 BitwiseOr(int4 lhs, int rhs) => int4(lhs.x | rhs, lhs.y | rhs, lhs.z | rhs, lhs.w | rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int4 BitwiseOr(int lhs, int4 rhs) => int4(lhs | rhs.x, lhs | rhs.y, lhs | rhs.z, lhs | rhs.w);
        
        /// <summary>
        /// Returns a int from the application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int4 BitwiseOr(int lhs, int rhs) => int4(lhs | rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int4 BitwiseAnd(int4 lhs, int4 rhs) => int4(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z, lhs.w & rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int4 BitwiseAnd(int4 lhs, int rhs) => int4(lhs.x & rhs, lhs.y & rhs, lhs.z & rhs, lhs.w & rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int4 BitwiseAnd(int lhs, int4 rhs) => int4(lhs & rhs.x, lhs & rhs.y, lhs & rhs.z, lhs & rhs.w);
        
        /// <summary>
        /// Returns a int from the application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int4 BitwiseAnd(int lhs, int rhs) => int4(lhs & rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int4 LeftShift(int4 lhs, int4 rhs) => int4(lhs.x << rhs.x, lhs.y << rhs.y, lhs.z << rhs.z, lhs.w << rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int4 LeftShift(int4 lhs, int rhs) => int4(lhs.x << rhs, lhs.y << rhs, lhs.z << rhs, lhs.w << rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int4 LeftShift(int lhs, int4 rhs) => int4(lhs << rhs.x, lhs << rhs.y, lhs << rhs.z, lhs << rhs.w);
        
        /// <summary>
        /// Returns a int from the application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int4 LeftShift(int lhs, int rhs) => int4(lhs << rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int4 RightShift(int4 lhs, int4 rhs) => int4(lhs.x >> rhs.x, lhs.y >> rhs.y, lhs.z >> rhs.z, lhs.w >> rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int4 RightShift(int4 lhs, int rhs) => int4(lhs.x >> rhs, lhs.y >> rhs, lhs.z >> rhs, lhs.w >> rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int4 RightShift(int lhs, int4 rhs) => int4(lhs >> rhs.x, lhs >> rhs.y, lhs >> rhs.z, lhs >> rhs.w);
        
        /// <summary>
        /// Returns a int from the application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int4 RightShift(int lhs, int rhs) => int4(lhs >> rhs);
        
        /// <summary>
        /// Returns a int4 with independent and identically distributed uniform integer values between 0 (inclusive) and maxValue (exclusive). (A maxValue of 0 is allowed and returns 0.)
        /// </summary>
        public static int4 Random(Random random, int4 maxValue) => int4((int)random.Next((int)maxValue.x), (int)random.Next((int)maxValue.y), (int)random.Next((int)maxValue.z), (int)random.Next((int)maxValue.w));
        
        /// <summary>
        /// Returns a int4 with independent and identically distributed uniform integer values between 0 (inclusive) and maxValue (exclusive). (A maxValue of 0 is allowed and returns 0.)
        /// </summary>
        public static int4 Random(Random random, int maxValue) => int4((int)random.Next((int)maxValue));
        
        /// <summary>
        /// Returns a int4 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static int4 Random(Random random, int4 minValue, int4 maxValue) => int4((int)random.Next((int)minValue.x, (int)maxValue.x), (int)random.Next((int)minValue.y, (int)maxValue.y), (int)random.Next((int)minValue.z, (int)maxValue.z), (int)random.Next((int)minValue.w, (int)maxValue.w));
        
        /// <summary>
        /// Returns a int4 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static int4 Random(Random random, int4 minValue, int maxValue) => int4((int)random.Next((int)minValue.x, (int)maxValue), (int)random.Next((int)minValue.y, (int)maxValue), (int)random.Next((int)minValue.z, (int)maxValue), (int)random.Next((int)minValue.w, (int)maxValue));
        
        /// <summary>
        /// Returns a int4 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static int4 Random(Random random, int minValue, int4 maxValue) => int4((int)random.Next((int)minValue, (int)maxValue.x), (int)random.Next((int)minValue, (int)maxValue.y), (int)random.Next((int)minValue, (int)maxValue.z), (int)random.Next((int)minValue, (int)maxValue.w));
        
        /// <summary>
        /// Returns a int4 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static int4 Random(Random random, int minValue, int maxValue) => int4((int)random.Next((int)minValue, (int)maxValue));
        
        /// <summary>
        /// Returns a int4 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static int4 RandomUniform(Random random, int4 minValue, int4 maxValue) => int4((int)random.Next((int)minValue.x, (int)maxValue.x), (int)random.Next((int)minValue.y, (int)maxValue.y), (int)random.Next((int)minValue.z, (int)maxValue.z), (int)random.Next((int)minValue.w, (int)maxValue.w));
        
        /// <summary>
        /// Returns a int4 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static int4 RandomUniform(Random random, int4 minValue, int maxValue) => int4((int)random.Next((int)minValue.x, (int)maxValue), (int)random.Next((int)minValue.y, (int)maxValue), (int)random.Next((int)minValue.z, (int)maxValue), (int)random.Next((int)minValue.w, (int)maxValue));
        
        /// <summary>
        /// Returns a int4 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static int4 RandomUniform(Random random, int minValue, int4 maxValue) => int4((int)random.Next((int)minValue, (int)maxValue.x), (int)random.Next((int)minValue, (int)maxValue.y), (int)random.Next((int)minValue, (int)maxValue.z), (int)random.Next((int)minValue, (int)maxValue.w));
        
        /// <summary>
        /// Returns a int4 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static int4 RandomUniform(Random random, int minValue, int maxValue) => int4((int)random.Next((int)minValue, (int)maxValue));

        //#endregion


        //#region Component-Wise Operator Overloads
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool4 operator<(int4 lhs, int4 rhs) => bool4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool4 operator<(int4 lhs, int rhs) => bool4(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs, lhs.w < rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool4 operator<(int lhs, int4 rhs) => bool4(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z, lhs < rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool4 operator<=(int4 lhs, int4 rhs) => bool4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool4 operator<=(int4 lhs, int rhs) => bool4(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs, lhs.w <= rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool4 operator<=(int lhs, int4 rhs) => bool4(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z, lhs <= rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool4 operator>(int4 lhs, int4 rhs) => bool4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool4 operator>(int4 lhs, int rhs) => bool4(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs, lhs.w > rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool4 operator>(int lhs, int4 rhs) => bool4(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z, lhs > rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool4 operator>=(int4 lhs, int4 rhs) => bool4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool4 operator>=(int4 lhs, int rhs) => bool4(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs, lhs.w >= rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool4 operator>=(int lhs, int4 rhs) => bool4(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z, lhs >= rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static int4 operator+(int4 lhs, int4 rhs) => int4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static int4 operator+(int4 lhs, int rhs) => int4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static int4 operator+(int lhs, int4 rhs) => int4(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z, lhs + rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static int4 operator-(int4 lhs, int4 rhs) => int4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static int4 operator-(int4 lhs, int rhs) => int4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static int4 operator-(int lhs, int4 rhs) => int4(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z, lhs - rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static int4 operator*(int4 lhs, int4 rhs) => int4(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static int4 operator*(int4 lhs, int rhs) => int4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static int4 operator*(int lhs, int4 rhs) => int4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static int4 operator/(int4 lhs, int4 rhs) => int4(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z, lhs.w / rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static int4 operator/(int4 lhs, int rhs) => int4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static int4 operator/(int lhs, int4 rhs) => int4(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z, lhs / rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator- (-v).
        /// </summary>
        public static int4 operator-(int4 v) => int4(-v.x, -v.y, -v.z, -v.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator~ (~v).
        /// </summary>
        public static int4 operator~(int4 v) => int4(~v.x, ~v.y, ~v.z, ~v.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static int4 operator^(int4 lhs, int4 rhs) => int4(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z, lhs.w ^ rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static int4 operator^(int4 lhs, int rhs) => int4(lhs.x ^ rhs, lhs.y ^ rhs, lhs.z ^ rhs, lhs.w ^ rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static int4 operator^(int lhs, int4 rhs) => int4(lhs ^ rhs.x, lhs ^ rhs.y, lhs ^ rhs.z, lhs ^ rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static int4 operator|(int4 lhs, int4 rhs) => int4(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z, lhs.w | rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static int4 operator|(int4 lhs, int rhs) => int4(lhs.x | rhs, lhs.y | rhs, lhs.z | rhs, lhs.w | rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static int4 operator|(int lhs, int4 rhs) => int4(lhs | rhs.x, lhs | rhs.y, lhs | rhs.z, lhs | rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static int4 operator&(int4 lhs, int4 rhs) => int4(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z, lhs.w & rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static int4 operator&(int4 lhs, int rhs) => int4(lhs.x & rhs, lhs.y & rhs, lhs.z & rhs, lhs.w & rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static int4 operator&(int lhs, int4 rhs) => int4(lhs & rhs.x, lhs & rhs.y, lhs & rhs.z, lhs & rhs.w);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator&lt;&lt; (lhs &lt;&lt; rhs).
        /// </summary>
        public static int4 operator<<(int4 lhs, int rhs) => int4(lhs.x << rhs, lhs.y << rhs, lhs.z << rhs, lhs.w << rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; rhs).
        /// </summary>
        public static int4 operator>>(int4 lhs, int rhs) => int4(lhs.x >> rhs, lhs.y >> rhs, lhs.z >> rhs, lhs.w >> rhs);

        //#endregion

    }
}
