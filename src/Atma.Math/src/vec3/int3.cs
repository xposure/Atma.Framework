using System;
namespace Atma
{
    
    /// <summary>
    /// A vector of type int with 3 components.
    /// </summary>
    [Union]
    public struct int3 : IHashable
    {

        //#region Fields
        
        /// <summary>
        /// component data
        /// </summary>
        public int[3] values;
        
        /// <summary>
        /// Returns an object that can be used for arbitrary swizzling (e.g. swizzle.zy)
        /// </summary>
        public readonly swizzle_int3 swizzle;

        //#endregion


        //#region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public this(int x, int y, int z)
        {
            values = .(x,y,z);
        }
        
        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public this(int v)
        {
            values = .(v,v,v);
        }
        
        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public this(int2 v)
        {
            values = .(v.x,v.y,0);
        }
        
        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public this(int2 v, int z)
        {
            values = .(v.x,v.y,z);
        }
        
        /// <summary>
        /// from-vector constructor
        /// </summary>
        public this(int3 v)
        {
            values = .(v.x,v.y,v.z);
        }
        
        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public this(int4 v)
        {
            values = .(v.x,v.y,v.z);
        }
        
        /// <summary>
        /// From-array constructor (superfluous values are ignored, missing values are zero-filled).
        /// </summary>
        public this(int[] v)
        {
            let c = v.Count;
            values = .((c < 0) ? 0 : v[0],(c < 1) ? 0 : v[1],(c < 2) ? 0 : v[2]);
        }
        
        /// <summary>
        /// From-array constructor with base index (superfluous values are ignored, missing values are zero-filled).
        /// </summary>
        public this(int[] v, int startIndex)
        {
            let c = v.Count;
            values = .((c + startIndex < 0) ? 0 : v[0 + startIndex],(c + startIndex < 1) ? 0 : v[1 + startIndex],(c + startIndex < 2) ? 0 : v[2 + startIndex]);
        }

        //#endregion


        //#region Implicit Operators
        
        /// <summary>
        /// Implicitly converts this to a long3.
        /// </summary>
        public static implicit operator long3(int3 v) =>  long3((long)v.x, (long)v.y, (long)v.z);
        
        /// <summary>
        /// Implicitly converts this to a float3.
        /// </summary>
        public static implicit operator float3(int3 v) =>  float3((float)v.x, (float)v.y, (float)v.z);
        
        /// <summary>
        /// Implicitly converts this to a double3.
        /// </summary>
        public static implicit operator double3(int3 v) =>  double3((double)v.x, (double)v.y, (double)v.z);

        //#endregion


        //#region Explicit Operators
        
        /// <summary>
        /// Explicitly converts this to a int2.
        /// </summary>
        public static explicit operator int2(int3 v) =>  int2((int)v.x, (int)v.y);
        
        /// <summary>
        /// Explicitly converts this to a int4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator int4(int3 v) =>  int4((int)v.x, (int)v.y, (int)v.z, 0);
        
        /// <summary>
        /// Explicitly converts this to a uint2.
        /// </summary>
        public static explicit operator uint2(int3 v) =>  uint2((uint)v.x, (uint)v.y);
        
        /// <summary>
        /// Explicitly converts this to a uint3.
        /// </summary>
        public static explicit operator uint3(int3 v) =>  uint3((uint)v.x, (uint)v.y, (uint)v.z);
        
        /// <summary>
        /// Explicitly converts this to a uint4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator uint4(int3 v) =>  uint4((uint)v.x, (uint)v.y, (uint)v.z, 0u);
        
        /// <summary>
        /// Explicitly converts this to a float2.
        /// </summary>
        public static explicit operator float2(int3 v) =>  float2((float)v.x, (float)v.y);
        
        /// <summary>
        /// Explicitly converts this to a float4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator float4(int3 v) =>  float4((float)v.x, (float)v.y, (float)v.z, 0f);
        
        /// <summary>
        /// Explicitly converts this to a double2.
        /// </summary>
        public static explicit operator double2(int3 v) =>  double2((double)v.x, (double)v.y);
        
        /// <summary>
        /// Explicitly converts this to a double4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator double4(int3 v) =>  double4((double)v.x, (double)v.y, (double)v.z, 0.0);
        
        /// <summary>
        /// Explicitly converts this to a long2.
        /// </summary>
        public static explicit operator long2(int3 v) =>  long2((long)v.x, (long)v.y);
        
        /// <summary>
        /// Explicitly converts this to a long4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator long4(int3 v) =>  long4((long)v.x, (long)v.y, (long)v.z, 0);
        
        /// <summary>
        /// Explicitly converts this to a bool2.
        /// </summary>
        public static explicit operator bool2(int3 v) =>  bool2(v.x != 0, v.y != 0);
        
        /// <summary>
        /// Explicitly converts this to a bool3.
        /// </summary>
        public static explicit operator bool3(int3 v) =>  bool3(v.x != 0, v.y != 0, v.z != 0);
        
        /// <summary>
        /// Explicitly converts this to a bool4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator bool4(int3 v) =>  bool4(v.x != 0, v.y != 0, v.z != 0, false);

        //#endregion


        //#region Indexer
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public int this[int index]
        {
            [Inline]get
            {
                System.Diagnostics.Debug.Assert(index >=0 && index < 3, "index out of range");
                unchecked { return values[index]; }
            }
            [Inline]set mut
            {
                System.Diagnostics.Debug.Assert(index >=0 && index < 3, "index out of range");
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
        /// Returns the number of components (3).
        /// </summary>
        public int Count => 3;
        
        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        public int MinElement => System.Math.Min(System.Math.Min(x, y), z);
        
        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public int MaxElement => System.Math.Max(System.Math.Max(x, y), z);
        
        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public float Length => (float)System.Math.Sqrt(((x*x + y*y) + z*z));
        
        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        public float LengthSqr => ((x*x + y*y) + z*z);
        
        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        public int Sum => ((x + y) + z);
        
        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public float Norm => (float)System.Math.Sqrt(((x*x + y*y) + z*z));
        
        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public float Norm1 => ((System.Math.Abs(x) + System.Math.Abs(y)) + System.Math.Abs(z));
        
        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        public float Norm2 => (float)System.Math.Sqrt(((x*x + y*y) + z*z));
        
        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public float NormMax => System.Math.Max(System.Math.Max(System.Math.Abs(x), System.Math.Abs(y)), System.Math.Abs(z));

        //#endregion


        //#region Static Properties
        
        /// <summary>
        /// Predefined all-zero vector
        /// </summary>
        readonly public static int3 Zero  =  int3(0, 0, 0);
        
        /// <summary>
        /// Predefined all-ones vector
        /// </summary>
        readonly public static int3 Ones  =  int3(1, 1, 1);
        
        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        readonly public static int3 UnitX  =  int3(1, 0, 0);
        
        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        readonly public static int3 NegativeUnitX  =  int3(-1, 0, 0);
        
        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        readonly public static int3 UnitY  =  int3(0, 1, 0);
        
        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        readonly public static int3 NegativeUnitY  =  int3(0, -1, 0);
        
        /// <summary>
        /// Predefined unit-Z vector
        /// </summary>
        readonly public static int3 UnitZ  =  int3(0, 0, 1);
        
        /// <summary>
        /// Predefined unit-Z vector
        /// </summary>
        readonly public static int3 NegativeUnitZ  =  int3(0, 0, -1);
        
        /// <summary>
        /// Predefined all-MaxValue vector
        /// </summary>
        readonly public static int3 MaxValue  =  int3(int.MaxValue, int.MaxValue, int.MaxValue);
        
        /// <summary>
        /// Predefined all-MinValue vector
        /// </summary>
        readonly public static int3 MinValue  =  int3(int.MinValue, int.MinValue, int.MinValue);

        //#endregion


        //#region Operators
        
        /// <summary>
        /// Returns true if this equals rhs component-wise.
        /// </summary>
        public static bool operator==(int3 lhs, int3 rhs) => ((lhs.x == rhs.x && lhs.y == rhs.y) && lhs.z == rhs.z);
        
        /// <summary>
        /// Returns true if this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator!=(int3 lhs, int3 rhs) => !((lhs.x == rhs.x && lhs.y == rhs.y) && lhs.z == rhs.z);

        //#endregion


        //#region Functions
        
        /// <summary>
        /// Returns an array with all values
        /// </summary>
        public int[] ToArray() => new .[] ( x, y, z );
        
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
             stringBuffer.Join(sep, _x,_y,_z );
        }
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public int GetHashCode()
        {
            unchecked
            {
                return ((((x.GetHashCode()) * 397) ^ y.GetHashCode()) * 397) ^ z.GetHashCode();
            }
        }
        
        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        public double NormP(double p) => System.Math.Pow(((System.Math.Pow((double)System.Math.Abs(x), p) + System.Math.Pow((double)System.Math.Abs(y), p)) + System.Math.Pow((double)System.Math.Abs(z), p)), 1 / p);

        //#endregion


        //#region Static Functions
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int3x2 OuterProduct(int2 c, int3 r) =>  int3x2(c.x * r.x, c.y * r.x, c.x * r.y, c.y * r.y, c.x * r.z, c.y * r.z);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int2x3 OuterProduct(int3 c, int2 r) =>  int2x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int3x3 OuterProduct(int3 c, int3 r) =>  int3x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.x * r.z, c.y * r.z, c.z * r.z);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int3x4 OuterProduct(int4 c, int3 r) =>  int3x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.w * r.z);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int4x3 OuterProduct(int3 c, int4 r) =>  int4x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.x * r.w, c.y * r.w, c.z * r.w);
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static int Dot(int3 lhs, int3 rhs) => ((lhs.x * rhs.x + lhs.y * rhs.y) + lhs.z * rhs.z);
        
        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static float Distance(int3 lhs, int3 rhs) => (lhs - rhs).Length;
        
        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static float DistanceSqr(int3 lhs, int3 rhs) => (lhs - rhs).LengthSqr;
        
        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static int3 Reflect(int3 I, int3 N) => I - 2 * Dot(N, I) * N;
        
        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static int3 Refract(int3 I, int3 N, int eta)
        {
            let dNI = Dot(N, I);
            let k = 1 - eta * eta * (1 - dNI * dNI);
            if (k < 0) return Zero;
            return eta * I - (eta * dNI + (int)System.Math.Sqrt(k)) * N;
        }
        
        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static int3 FaceForward(int3 N, int3 I, int3 Nref) => Dot(Nref, I) < 0 ? N : -N;
        
        /// <summary>
        /// Returns the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        public static int3 Cross(int3 l, int3 r) =>  int3(l.y * r.z - l.z * r.y, l.z * r.x - l.x * r.z, l.x * r.y - l.y * r.x);
        
        /// <summary>
        /// Returns a int3 with independent and identically distributed uniform integer values between 0 (inclusive) and int.MaxValue (exclusive).
        /// </summary>
        public static int3 Random(Random random) =>  int3((int)random.Next(int64.MaxValue), (int)random.Next(int64.MaxValue), (int)random.Next(int64.MaxValue));

        //#endregion


        //#region Component-Wise Static Functions
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(int3 lhs, int3 rhs) => bool3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(int3 lhs, int rhs) => bool3(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(int lhs, int3 rhs) => bool3(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z);
        
        /// <summary>
        /// Returns a bool from the application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(int lhs, int rhs) => bool3(lhs == rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(int3 lhs, int3 rhs) => bool3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(int3 lhs, int rhs) => bool3(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(int lhs, int3 rhs) => bool3(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z);
        
        /// <summary>
        /// Returns a bool from the application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(int lhs, int rhs) => bool3(lhs != rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(int3 lhs, int3 rhs) => bool3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(int3 lhs, int rhs) => bool3(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(int lhs, int3 rhs) => bool3(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z);
        
        /// <summary>
        /// Returns a bool from the application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(int lhs, int rhs) => bool3(lhs > rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(int3 lhs, int3 rhs) => bool3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(int3 lhs, int rhs) => bool3(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(int lhs, int3 rhs) => bool3(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z);
        
        /// <summary>
        /// Returns a bool from the application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(int lhs, int rhs) => bool3(lhs >= rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(int3 lhs, int3 rhs) => bool3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(int3 lhs, int rhs) => bool3(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(int lhs, int3 rhs) => bool3(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z);
        
        /// <summary>
        /// Returns a bool from the application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(int lhs, int rhs) => bool3(lhs < rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(int3 lhs, int3 rhs) => bool3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(int3 lhs, int rhs) => bool3(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(int lhs, int3 rhs) => bool3(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z);
        
        /// <summary>
        /// Returns a bool from the application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(int lhs, int rhs) => bool3(lhs <= rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Abs (System.Math.Abs(v)).
        /// </summary>
        public static int3 Abs(int3 v) => int3(System.Math.Abs(v.x), System.Math.Abs(v.y), System.Math.Abs(v.z));
        
        /// <summary>
        /// Returns a int from the application of Abs (System.Math.Abs(v)).
        /// </summary>
        public static int3 Abs(int v) => int3(System.Math.Abs(v));
        
        /// <summary>
        /// Returns a int3 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static int3 HermiteInterpolationOrder3(int3 v) => int3((3 - 2 * v.x) * v.x * v.x, (3 - 2 * v.y) * v.y * v.y, (3 - 2 * v.z) * v.z * v.z);
        
        /// <summary>
        /// Returns a int from the application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static int3 HermiteInterpolationOrder3(int v) => int3((3 - 2 * v) * v * v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static int3 HermiteInterpolationOrder5(int3 v) => int3(((6 * v.x - 15) * v.x + 10) * v.x * v.x * v.x, ((6 * v.y - 15) * v.y + 10) * v.y * v.y * v.y, ((6 * v.z - 15) * v.z + 10) * v.z * v.z * v.z);
        
        /// <summary>
        /// Returns a int from the application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static int3 HermiteInterpolationOrder5(int v) => int3(((6 * v - 15) * v + 10) * v * v * v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sqr (v * v).
        /// </summary>
        public static int3 Sqr(int3 v) => int3(v.x * v.x, v.y * v.y, v.z * v.z);
        
        /// <summary>
        /// Returns a int from the application of Sqr (v * v).
        /// </summary>
        public static int3 Sqr(int v) => int3(v * v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static int3 Pow2(int3 v) => int3(v.x * v.x, v.y * v.y, v.z * v.z);
        
        /// <summary>
        /// Returns a int from the application of Pow2 (v * v).
        /// </summary>
        public static int3 Pow2(int v) => int3(v * v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static int3 Pow3(int3 v) => int3(v.x * v.x * v.x, v.y * v.y * v.y, v.z * v.z * v.z);
        
        /// <summary>
        /// Returns a int from the application of Pow3 (v * v * v).
        /// </summary>
        public static int3 Pow3(int v) => int3(v * v * v);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Step (v &gt;= 0 ? 1 : 0).
        /// </summary>
        public static int3 Step(int3 v) => int3(v.x >= 0 ? 1 : 0, v.y >= 0 ? 1 : 0, v.z >= 0 ? 1 : 0);
        
        /// <summary>
        /// Returns a int from the application of Step (v &gt;= 0 ? 1 : 0).
        /// </summary>
        public static int3 Step(int v) => int3(v >= 0 ? 1 : 0);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sqrt ((int)System.Math.Sqrt((double)v)).
        /// </summary>
        public static int3 Sqrt(int3 v) => int3((int)System.Math.Sqrt((double)v.x), (int)System.Math.Sqrt((double)v.y), (int)System.Math.Sqrt((double)v.z));
        
        /// <summary>
        /// Returns a int from the application of Sqrt ((int)System.Math.Sqrt((double)v)).
        /// </summary>
        public static int3 Sqrt(int v) => int3((int)System.Math.Sqrt((double)v));
        
        /// <summary>
        /// Returns a int3 from component-wise application of InverseSqrt ((int)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        public static int3 InverseSqrt(int3 v) => int3((int)(1.0 / System.Math.Sqrt((double)v.x)), (int)(1.0 / System.Math.Sqrt((double)v.y)), (int)(1.0 / System.Math.Sqrt((double)v.z)));
        
        /// <summary>
        /// Returns a int from the application of InverseSqrt ((int)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        public static int3 InverseSqrt(int v) => int3((int)(1.0 / System.Math.Sqrt((double)v)));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sign (System.Math.Sign(v)).
        /// </summary>
        public static int3 Sign(int3 v) => int3(System.Math.Sign(v.x), System.Math.Sign(v.y), System.Math.Sign(v.z));
        
        /// <summary>
        /// Returns a int from the application of Sign (System.Math.Sign(v)).
        /// </summary>
        public static int3 Sign(int v) => int3(System.Math.Sign(v));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static int3 Max(int3 lhs, int3 rhs) => int3(System.Math.Max(lhs.x, rhs.x), System.Math.Max(lhs.y, rhs.y), System.Math.Max(lhs.z, rhs.z));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static int3 Max(int3 lhs, int rhs) => int3(System.Math.Max(lhs.x, rhs), System.Math.Max(lhs.y, rhs), System.Math.Max(lhs.z, rhs));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static int3 Max(int lhs, int3 rhs) => int3(System.Math.Max(lhs, rhs.x), System.Math.Max(lhs, rhs.y), System.Math.Max(lhs, rhs.z));
        
        /// <summary>
        /// Returns a int from the application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static int3 Max(int lhs, int rhs) => int3(System.Math.Max(lhs, rhs));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static int3 Min(int3 lhs, int3 rhs) => int3(System.Math.Min(lhs.x, rhs.x), System.Math.Min(lhs.y, rhs.y), System.Math.Min(lhs.z, rhs.z));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static int3 Min(int3 lhs, int rhs) => int3(System.Math.Min(lhs.x, rhs), System.Math.Min(lhs.y, rhs), System.Math.Min(lhs.z, rhs));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static int3 Min(int lhs, int3 rhs) => int3(System.Math.Min(lhs, rhs.x), System.Math.Min(lhs, rhs.y), System.Math.Min(lhs, rhs.z));
        
        /// <summary>
        /// Returns a int from the application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static int3 Min(int lhs, int rhs) => int3(System.Math.Min(lhs, rhs));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Pow ((int)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int3 Pow(int3 lhs, int3 rhs) => int3((int)System.Math.Pow((double)lhs.x, (double)rhs.x), (int)System.Math.Pow((double)lhs.y, (double)rhs.y), (int)System.Math.Pow((double)lhs.z, (double)rhs.z));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Pow ((int)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int3 Pow(int3 lhs, int rhs) => int3((int)System.Math.Pow((double)lhs.x, (double)rhs), (int)System.Math.Pow((double)lhs.y, (double)rhs), (int)System.Math.Pow((double)lhs.z, (double)rhs));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Pow ((int)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int3 Pow(int lhs, int3 rhs) => int3((int)System.Math.Pow((double)lhs, (double)rhs.x), (int)System.Math.Pow((double)lhs, (double)rhs.y), (int)System.Math.Pow((double)lhs, (double)rhs.z));
        
        /// <summary>
        /// Returns a int from the application of Pow ((int)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int3 Pow(int lhs, int rhs) => int3((int)System.Math.Pow((double)lhs, (double)rhs));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Log ((int)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int3 Log(int3 lhs, int3 rhs) => int3((int)System.Math.Log((double)lhs.x, (double)rhs.x), (int)System.Math.Log((double)lhs.y, (double)rhs.y), (int)System.Math.Log((double)lhs.z, (double)rhs.z));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Log ((int)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int3 Log(int3 lhs, int rhs) => int3((int)System.Math.Log((double)lhs.x, (double)rhs), (int)System.Math.Log((double)lhs.y, (double)rhs), (int)System.Math.Log((double)lhs.z, (double)rhs));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Log ((int)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int3 Log(int lhs, int3 rhs) => int3((int)System.Math.Log((double)lhs, (double)rhs.x), (int)System.Math.Log((double)lhs, (double)rhs.y), (int)System.Math.Log((double)lhs, (double)rhs.z));
        
        /// <summary>
        /// Returns a int from the application of Log ((int)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int3 Log(int lhs, int rhs) => int3((int)System.Math.Log((double)lhs, (double)rhs));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static int3 Clamp(int3 v, int3 min, int3 max) => int3(System.Math.Min(System.Math.Max(v.x, min.x), max.x), System.Math.Min(System.Math.Max(v.y, min.y), max.y), System.Math.Min(System.Math.Max(v.z, min.z), max.z));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static int3 Clamp(int3 v, int3 min, int max) => int3(System.Math.Min(System.Math.Max(v.x, min.x), max), System.Math.Min(System.Math.Max(v.y, min.y), max), System.Math.Min(System.Math.Max(v.z, min.z), max));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static int3 Clamp(int3 v, int min, int3 max) => int3(System.Math.Min(System.Math.Max(v.x, min), max.x), System.Math.Min(System.Math.Max(v.y, min), max.y), System.Math.Min(System.Math.Max(v.z, min), max.z));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static int3 Clamp(int3 v, int min, int max) => int3(System.Math.Min(System.Math.Max(v.x, min), max), System.Math.Min(System.Math.Max(v.y, min), max), System.Math.Min(System.Math.Max(v.z, min), max));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static int3 Clamp(int v, int3 min, int3 max) => int3(System.Math.Min(System.Math.Max(v, min.x), max.x), System.Math.Min(System.Math.Max(v, min.y), max.y), System.Math.Min(System.Math.Max(v, min.z), max.z));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static int3 Clamp(int v, int3 min, int max) => int3(System.Math.Min(System.Math.Max(v, min.x), max), System.Math.Min(System.Math.Max(v, min.y), max), System.Math.Min(System.Math.Max(v, min.z), max));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static int3 Clamp(int v, int min, int3 max) => int3(System.Math.Min(System.Math.Max(v, min), max.x), System.Math.Min(System.Math.Max(v, min), max.y), System.Math.Min(System.Math.Max(v, min), max.z));
        
        /// <summary>
        /// Returns a int from the application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static int3 Clamp(int v, int min, int max) => int3(System.Math.Min(System.Math.Max(v, min), max));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int3 Mix(int3 min, int3 max, int3 a) => int3(min.x * (1-a.x) + max.x * a.x, min.y * (1-a.y) + max.y * a.y, min.z * (1-a.z) + max.z * a.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int3 Mix(int3 min, int3 max, int a) => int3(min.x * (1-a) + max.x * a, min.y * (1-a) + max.y * a, min.z * (1-a) + max.z * a);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int3 Mix(int3 min, int max, int3 a) => int3(min.x * (1-a.x) + max * a.x, min.y * (1-a.y) + max * a.y, min.z * (1-a.z) + max * a.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int3 Mix(int3 min, int max, int a) => int3(min.x * (1-a) + max * a, min.y * (1-a) + max * a, min.z * (1-a) + max * a);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int3 Mix(int min, int3 max, int3 a) => int3(min * (1-a.x) + max.x * a.x, min * (1-a.y) + max.y * a.y, min * (1-a.z) + max.z * a.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int3 Mix(int min, int3 max, int a) => int3(min * (1-a) + max.x * a, min * (1-a) + max.y * a, min * (1-a) + max.z * a);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int3 Mix(int min, int max, int3 a) => int3(min * (1-a.x) + max * a.x, min * (1-a.y) + max * a.y, min * (1-a.z) + max * a.z);
        
        /// <summary>
        /// Returns a int from the application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int3 Mix(int min, int max, int a) => int3(min * (1-a) + max * a);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int3 Lerp(int3 min, int3 max, int3 a) => int3(min.x * (1-a.x) + max.x * a.x, min.y * (1-a.y) + max.y * a.y, min.z * (1-a.z) + max.z * a.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int3 Lerp(int3 min, int3 max, int a) => int3(min.x * (1-a) + max.x * a, min.y * (1-a) + max.y * a, min.z * (1-a) + max.z * a);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int3 Lerp(int3 min, int max, int3 a) => int3(min.x * (1-a.x) + max * a.x, min.y * (1-a.y) + max * a.y, min.z * (1-a.z) + max * a.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int3 Lerp(int3 min, int max, int a) => int3(min.x * (1-a) + max * a, min.y * (1-a) + max * a, min.z * (1-a) + max * a);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int3 Lerp(int min, int3 max, int3 a) => int3(min * (1-a.x) + max.x * a.x, min * (1-a.y) + max.y * a.y, min * (1-a.z) + max.z * a.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int3 Lerp(int min, int3 max, int a) => int3(min * (1-a) + max.x * a, min * (1-a) + max.y * a, min * (1-a) + max.z * a);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int3 Lerp(int min, int max, int3 a) => int3(min * (1-a.x) + max * a.x, min * (1-a.y) + max * a.y, min * (1-a.z) + max * a.z);
        
        /// <summary>
        /// Returns a int from the application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int3 Lerp(int min, int max, int a) => int3(min * (1-a) + max * a);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int3 Fma(int3 a, int3 b, int3 c) => int3(a.x * b.x + c.x, a.y * b.y + c.y, a.z * b.z + c.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int3 Fma(int3 a, int3 b, int c) => int3(a.x * b.x + c, a.y * b.y + c, a.z * b.z + c);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int3 Fma(int3 a, int b, int3 c) => int3(a.x * b + c.x, a.y * b + c.y, a.z * b + c.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int3 Fma(int3 a, int b, int c) => int3(a.x * b + c, a.y * b + c, a.z * b + c);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int3 Fma(int a, int3 b, int3 c) => int3(a * b.x + c.x, a * b.y + c.y, a * b.z + c.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int3 Fma(int a, int3 b, int c) => int3(a * b.x + c, a * b.y + c, a * b.z + c);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int3 Fma(int a, int b, int3 c) => int3(a * b + c.x, a * b + c.y, a * b + c.z);
        
        /// <summary>
        /// Returns a int from the application of Fma (a * b + c).
        /// </summary>
        public static int3 Fma(int a, int b, int c) => int3(a * b + c);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static int3 Add(int3 lhs, int3 rhs) => int3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static int3 Add(int3 lhs, int rhs) => int3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static int3 Add(int lhs, int3 rhs) => int3(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z);
        
        /// <summary>
        /// Returns a int from the application of Add (lhs + rhs).
        /// </summary>
        public static int3 Add(int lhs, int rhs) => int3(lhs + rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static int3 Sub(int3 lhs, int3 rhs) => int3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static int3 Sub(int3 lhs, int rhs) => int3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static int3 Sub(int lhs, int3 rhs) => int3(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z);
        
        /// <summary>
        /// Returns a int from the application of Sub (lhs - rhs).
        /// </summary>
        public static int3 Sub(int lhs, int rhs) => int3(lhs - rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static int3 Mul(int3 lhs, int3 rhs) => int3(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static int3 Mul(int3 lhs, int rhs) => int3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static int3 Mul(int lhs, int3 rhs) => int3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        
        /// <summary>
        /// Returns a int from the application of Mul (lhs * rhs).
        /// </summary>
        public static int3 Mul(int lhs, int rhs) => int3(lhs * rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static int3 Div(int3 lhs, int3 rhs) => int3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static int3 Div(int3 lhs, int rhs) => int3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static int3 Div(int lhs, int3 rhs) => int3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);
        
        /// <summary>
        /// Returns a int from the application of Div (lhs / rhs).
        /// </summary>
        public static int3 Div(int lhs, int rhs) => int3(lhs / rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static int3 Xor(int3 lhs, int3 rhs) => int3(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static int3 Xor(int3 lhs, int rhs) => int3(lhs.x ^ rhs, lhs.y ^ rhs, lhs.z ^ rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static int3 Xor(int lhs, int3 rhs) => int3(lhs ^ rhs.x, lhs ^ rhs.y, lhs ^ rhs.z);
        
        /// <summary>
        /// Returns a int from the application of Xor (lhs ^ rhs).
        /// </summary>
        public static int3 Xor(int lhs, int rhs) => int3(lhs ^ rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int3 BitwiseOr(int3 lhs, int3 rhs) => int3(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int3 BitwiseOr(int3 lhs, int rhs) => int3(lhs.x | rhs, lhs.y | rhs, lhs.z | rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int3 BitwiseOr(int lhs, int3 rhs) => int3(lhs | rhs.x, lhs | rhs.y, lhs | rhs.z);
        
        /// <summary>
        /// Returns a int from the application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int3 BitwiseOr(int lhs, int rhs) => int3(lhs | rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int3 BitwiseAnd(int3 lhs, int3 rhs) => int3(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int3 BitwiseAnd(int3 lhs, int rhs) => int3(lhs.x & rhs, lhs.y & rhs, lhs.z & rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int3 BitwiseAnd(int lhs, int3 rhs) => int3(lhs & rhs.x, lhs & rhs.y, lhs & rhs.z);
        
        /// <summary>
        /// Returns a int from the application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int3 BitwiseAnd(int lhs, int rhs) => int3(lhs & rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int3 LeftShift(int3 lhs, int3 rhs) => int3(lhs.x << rhs.x, lhs.y << rhs.y, lhs.z << rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int3 LeftShift(int3 lhs, int rhs) => int3(lhs.x << rhs, lhs.y << rhs, lhs.z << rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int3 LeftShift(int lhs, int3 rhs) => int3(lhs << rhs.x, lhs << rhs.y, lhs << rhs.z);
        
        /// <summary>
        /// Returns a int from the application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int3 LeftShift(int lhs, int rhs) => int3(lhs << rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int3 RightShift(int3 lhs, int3 rhs) => int3(lhs.x >> rhs.x, lhs.y >> rhs.y, lhs.z >> rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int3 RightShift(int3 lhs, int rhs) => int3(lhs.x >> rhs, lhs.y >> rhs, lhs.z >> rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int3 RightShift(int lhs, int3 rhs) => int3(lhs >> rhs.x, lhs >> rhs.y, lhs >> rhs.z);
        
        /// <summary>
        /// Returns a int from the application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int3 RightShift(int lhs, int rhs) => int3(lhs >> rhs);
        
        /// <summary>
        /// Returns a int3 with independent and identically distributed uniform integer values between 0 (inclusive) and maxValue (exclusive). (A maxValue of 0 is allowed and returns 0.)
        /// </summary>
        public static int3 Random(Random random, int3 maxValue) => int3((int)random.Next((int)maxValue.x), (int)random.Next((int)maxValue.y), (int)random.Next((int)maxValue.z));
        
        /// <summary>
        /// Returns a int3 with independent and identically distributed uniform integer values between 0 (inclusive) and maxValue (exclusive). (A maxValue of 0 is allowed and returns 0.)
        /// </summary>
        public static int3 Random(Random random, int maxValue) => int3((int)random.Next((int)maxValue));
        
        /// <summary>
        /// Returns a int3 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static int3 Random(Random random, int3 minValue, int3 maxValue) => int3((int)random.Next((int)minValue.x, (int)maxValue.x), (int)random.Next((int)minValue.y, (int)maxValue.y), (int)random.Next((int)minValue.z, (int)maxValue.z));
        
        /// <summary>
        /// Returns a int3 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static int3 Random(Random random, int3 minValue, int maxValue) => int3((int)random.Next((int)minValue.x, (int)maxValue), (int)random.Next((int)minValue.y, (int)maxValue), (int)random.Next((int)minValue.z, (int)maxValue));
        
        /// <summary>
        /// Returns a int3 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static int3 Random(Random random, int minValue, int3 maxValue) => int3((int)random.Next((int)minValue, (int)maxValue.x), (int)random.Next((int)minValue, (int)maxValue.y), (int)random.Next((int)minValue, (int)maxValue.z));
        
        /// <summary>
        /// Returns a int3 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static int3 Random(Random random, int minValue, int maxValue) => int3((int)random.Next((int)minValue, (int)maxValue));
        
        /// <summary>
        /// Returns a int3 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static int3 RandomUniform(Random random, int3 minValue, int3 maxValue) => int3((int)random.Next((int)minValue.x, (int)maxValue.x), (int)random.Next((int)minValue.y, (int)maxValue.y), (int)random.Next((int)minValue.z, (int)maxValue.z));
        
        /// <summary>
        /// Returns a int3 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static int3 RandomUniform(Random random, int3 minValue, int maxValue) => int3((int)random.Next((int)minValue.x, (int)maxValue), (int)random.Next((int)minValue.y, (int)maxValue), (int)random.Next((int)minValue.z, (int)maxValue));
        
        /// <summary>
        /// Returns a int3 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static int3 RandomUniform(Random random, int minValue, int3 maxValue) => int3((int)random.Next((int)minValue, (int)maxValue.x), (int)random.Next((int)minValue, (int)maxValue.y), (int)random.Next((int)minValue, (int)maxValue.z));
        
        /// <summary>
        /// Returns a int3 with independent and identically distributed uniform integer values between minValue (inclusive) and maxValue (exclusive). (minValue == maxValue is allowed and returns minValue. Negative values are allowed.)
        /// </summary>
        public static int3 RandomUniform(Random random, int minValue, int maxValue) => int3((int)random.Next((int)minValue, (int)maxValue));

        //#endregion


        //#region Component-Wise Operator Overloads
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool3 operator<(int3 lhs, int3 rhs) => bool3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool3 operator<(int3 lhs, int rhs) => bool3(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool3 operator<(int lhs, int3 rhs) => bool3(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool3 operator<=(int3 lhs, int3 rhs) => bool3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool3 operator<=(int3 lhs, int rhs) => bool3(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool3 operator<=(int lhs, int3 rhs) => bool3(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool3 operator>(int3 lhs, int3 rhs) => bool3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool3 operator>(int3 lhs, int rhs) => bool3(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool3 operator>(int lhs, int3 rhs) => bool3(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool3 operator>=(int3 lhs, int3 rhs) => bool3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool3 operator>=(int3 lhs, int rhs) => bool3(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool3 operator>=(int lhs, int3 rhs) => bool3(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static int3 operator+(int3 lhs, int3 rhs) => int3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static int3 operator+(int3 lhs, int rhs) => int3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static int3 operator+(int lhs, int3 rhs) => int3(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static int3 operator-(int3 lhs, int3 rhs) => int3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static int3 operator-(int3 lhs, int rhs) => int3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static int3 operator-(int lhs, int3 rhs) => int3(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static int3 operator*(int3 lhs, int3 rhs) => int3(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static int3 operator*(int3 lhs, int rhs) => int3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static int3 operator*(int lhs, int3 rhs) => int3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static int3 operator/(int3 lhs, int3 rhs) => int3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static int3 operator/(int3 lhs, int rhs) => int3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static int3 operator/(int lhs, int3 rhs) => int3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator- (-v).
        /// </summary>
        public static int3 operator-(int3 v) => int3(-v.x, -v.y, -v.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator~ (~v).
        /// </summary>
        public static int3 operator~(int3 v) => int3(~v.x, ~v.y, ~v.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static int3 operator^(int3 lhs, int3 rhs) => int3(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static int3 operator^(int3 lhs, int rhs) => int3(lhs.x ^ rhs, lhs.y ^ rhs, lhs.z ^ rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static int3 operator^(int lhs, int3 rhs) => int3(lhs ^ rhs.x, lhs ^ rhs.y, lhs ^ rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static int3 operator|(int3 lhs, int3 rhs) => int3(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static int3 operator|(int3 lhs, int rhs) => int3(lhs.x | rhs, lhs.y | rhs, lhs.z | rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static int3 operator|(int lhs, int3 rhs) => int3(lhs | rhs.x, lhs | rhs.y, lhs | rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static int3 operator&(int3 lhs, int3 rhs) => int3(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static int3 operator&(int3 lhs, int rhs) => int3(lhs.x & rhs, lhs.y & rhs, lhs.z & rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static int3 operator&(int lhs, int3 rhs) => int3(lhs & rhs.x, lhs & rhs.y, lhs & rhs.z);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator&lt;&lt; (lhs &lt;&lt; rhs).
        /// </summary>
        public static int3 operator<<(int3 lhs, int rhs) => int3(lhs.x << rhs, lhs.y << rhs, lhs.z << rhs);
        
        /// <summary>
        /// Returns a int3 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; rhs).
        /// </summary>
        public static int3 operator>>(int3 lhs, int rhs) => int3(lhs.x >> rhs, lhs.y >> rhs, lhs.z >> rhs);

        //#endregion

    }
}
