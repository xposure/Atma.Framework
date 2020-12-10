using System;
namespace Atma
{
    
    /// <summary>
    /// A vector of type double with 3 components.
    /// </summary>
    [Union]
    public struct double3 : IHashable
    {

        //#region Fields
        
        /// <summary>
        /// component data
        /// </summary>
        public double[3] values;
        
        /// <summary>
        /// Returns an object that can be used for arbitrary swizzling (e.g. swizzle.zy)
        /// </summary>
        public readonly swizzle_double3 swizzle;

        //#endregion


        //#region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public this(double x, double y, double z)
        {
            values = .(x,y,z);
        }
        
        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public this(double v)
        {
            values = .(v,v,v);
        }
        
        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public this(double2 v)
        {
            values = .(v.x,v.y,0.0);
        }
        
        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public this(double2 v, double z)
        {
            values = .(v.x,v.y,z);
        }
        
        /// <summary>
        /// from-vector constructor
        /// </summary>
        public this(double3 v)
        {
            values = .(v.x,v.y,v.z);
        }
        
        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public this(double4 v)
        {
            values = .(v.x,v.y,v.z);
        }
        
        /// <summary>
        /// From-array constructor (superfluous values are ignored, missing values are zero-filled).
        /// </summary>
        public this(double[] v)
        {
            let c = v.Count;
            values = .((c < 0) ? 0.0 : v[0],(c < 1) ? 0.0 : v[1],(c < 2) ? 0.0 : v[2]);
        }
        
        /// <summary>
        /// From-array constructor with base index (superfluous values are ignored, missing values are zero-filled).
        /// </summary>
        public this(double[] v, int startIndex)
        {
            let c = v.Count;
            values = .((c + startIndex < 0) ? 0.0 : v[0 + startIndex],(c + startIndex < 1) ? 0.0 : v[1 + startIndex],(c + startIndex < 2) ? 0.0 : v[2 + startIndex]);
        }

        //#endregion


        //#region Explicit Operators
        
        /// <summary>
        /// Explicitly converts this to a int2.
        /// </summary>
        public static explicit operator int2(double3 v) =>  int2((int)v.x, (int)v.y);
        
        /// <summary>
        /// Explicitly converts this to a int3.
        /// </summary>
        public static explicit operator int3(double3 v) =>  int3((int)v.x, (int)v.y, (int)v.z);
        
        /// <summary>
        /// Explicitly converts this to a int4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator int4(double3 v) =>  int4((int)v.x, (int)v.y, (int)v.z, 0);
        
        /// <summary>
        /// Explicitly converts this to a uint2.
        /// </summary>
        public static explicit operator uint2(double3 v) =>  uint2((uint)v.x, (uint)v.y);
        
        /// <summary>
        /// Explicitly converts this to a uint3.
        /// </summary>
        public static explicit operator uint3(double3 v) =>  uint3((uint)v.x, (uint)v.y, (uint)v.z);
        
        /// <summary>
        /// Explicitly converts this to a uint4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator uint4(double3 v) =>  uint4((uint)v.x, (uint)v.y, (uint)v.z, 0u);
        
        /// <summary>
        /// Explicitly converts this to a float2.
        /// </summary>
        public static explicit operator float2(double3 v) =>  float2((float)v.x, (float)v.y);
        
        /// <summary>
        /// Explicitly converts this to a float3.
        /// </summary>
        public static explicit operator float3(double3 v) =>  float3((float)v.x, (float)v.y, (float)v.z);
        
        /// <summary>
        /// Explicitly converts this to a float4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator float4(double3 v) =>  float4((float)v.x, (float)v.y, (float)v.z, 0f);
        
        /// <summary>
        /// Explicitly converts this to a double2.
        /// </summary>
        public static explicit operator double2(double3 v) =>  double2((double)v.x, (double)v.y);
        
        /// <summary>
        /// Explicitly converts this to a double4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator double4(double3 v) =>  double4((double)v.x, (double)v.y, (double)v.z, 0.0);
        
        /// <summary>
        /// Explicitly converts this to a long2.
        /// </summary>
        public static explicit operator long2(double3 v) =>  long2((long)v.x, (long)v.y);
        
        /// <summary>
        /// Explicitly converts this to a long3.
        /// </summary>
        public static explicit operator long3(double3 v) =>  long3((long)v.x, (long)v.y, (long)v.z);
        
        /// <summary>
        /// Explicitly converts this to a long4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator long4(double3 v) =>  long4((long)v.x, (long)v.y, (long)v.z, 0);
        
        /// <summary>
        /// Explicitly converts this to a bool2.
        /// </summary>
        public static explicit operator bool2(double3 v) =>  bool2(v.x != 0.0, v.y != 0.0);
        
        /// <summary>
        /// Explicitly converts this to a bool3.
        /// </summary>
        public static explicit operator bool3(double3 v) =>  bool3(v.x != 0.0, v.y != 0.0, v.z != 0.0);
        
        /// <summary>
        /// Explicitly converts this to a bool4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator bool4(double3 v) =>  bool4(v.x != 0.0, v.y != 0.0, v.z != 0.0, false);

        //#endregion


        //#region Properties
        
        /// <summary>
        /// x-component
        /// </summary>
        public double x
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
        public double y
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
        public double z
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
        public double2 xy
        {
            [Inline]get
            {
                return  double2(x, y);
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
        public double2 xz
        {
            [Inline]get
            {
                return  double2(x, z);
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
        public double2 yz
        {
            [Inline]get
            {
                return  double2(y, z);
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
        public double3 xyz
        {
            [Inline]get
            {
                return  double3(x, y, z);
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
        public double2 rg
        {
            [Inline]get
            {
                return  double2(x, y);
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
        public double2 rb
        {
            [Inline]get
            {
                return  double2(x, z);
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
        public double2 gb
        {
            [Inline]get
            {
                return  double2(y, z);
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
        public double3 rgb
        {
            [Inline]get
            {
                return  double3(x, y, z);
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
        public double r
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
        public double g
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
        public double b
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
        public double MinElement => System.Math.Min(System.Math.Min(x, y), z);
        
        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public double MaxElement => System.Math.Max(System.Math.Max(x, y), z);
        
        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public double Length => (double)System.Math.Sqrt(((x*x + y*y) + z*z));
        
        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        public double LengthSqr => ((x*x + y*y) + z*z);
        
        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        public double Sum => ((x + y) + z);
        
        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public double Norm => (double)System.Math.Sqrt(((x*x + y*y) + z*z));
        
        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public double Norm1 => ((System.Math.Abs(x) + System.Math.Abs(y)) + System.Math.Abs(z));
        
        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        public double Norm2 => (double)System.Math.Sqrt(((x*x + y*y) + z*z));
        
        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public double NormMax => System.Math.Max(System.Math.Max(System.Math.Abs(x), System.Math.Abs(y)), System.Math.Abs(z));
        
        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        public double3 Normalized => this / (double)Length;
        
        /// <summary>
        /// Returns a copy of this vector with length one (returns zero if length is zero).
        /// </summary>
        public double3 NormalizedSafe => this == Zero ? Zero : this / (double)Length;

        //#endregion


        //#region Static Properties
        
        /// <summary>
        /// Predefined all-zero vector
        /// </summary>
        readonly public static double3 Zero  =  double3(0.0, 0.0, 0.0);
        
        /// <summary>
        /// Predefined all-ones vector
        /// </summary>
        readonly public static double3 Ones  =  double3(1.0, 1.0, 1.0);
        
        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        readonly public static double3 UnitX  =  double3(1.0, 0.0, 0.0);
        
        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        readonly public static double3 NegativeUnitX  =  double3(-1.0, 0.0, 0.0);
        
        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        readonly public static double3 UnitY  =  double3(0.0, 1.0, 0.0);
        
        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        readonly public static double3 NegativeUnitY  =  double3(0.0, -1.0, 0.0);
        
        /// <summary>
        /// Predefined unit-Z vector
        /// </summary>
        readonly public static double3 UnitZ  =  double3(0.0, 0.0, 1.0);
        
        /// <summary>
        /// Predefined unit-Z vector
        /// </summary>
        readonly public static double3 NegativeUnitZ  =  double3(0.0, 0.0, -1.0);
        
        /// <summary>
        /// Predefined all-MaxValue vector
        /// </summary>
        readonly public static double3 MaxValue  =  double3(double.MaxValue, double.MaxValue, double.MaxValue);
        
        /// <summary>
        /// Predefined all-MinValue vector
        /// </summary>
        readonly public static double3 MinValue  =  double3(double.MinValue, double.MinValue, double.MinValue);
        
        /// <summary>
        /// Predefined all-Epsilon vector
        /// </summary>
        readonly public static double3 Epsilon  =  double3(double.Epsilon, double.Epsilon, double.Epsilon);
        
        /// <summary>
        /// Predefined all-NaN vector
        /// </summary>
        readonly public static double3 NaN  =  double3(double.NaN, double.NaN, double.NaN);
        
        /// <summary>
        /// Predefined all-NegativeInfinity vector
        /// </summary>
        readonly public static double3 NegativeInfinity  =  double3(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity);
        
        /// <summary>
        /// Predefined all-PositiveInfinity vector
        /// </summary>
        readonly public static double3 PositiveInfinity  =  double3(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity);

        //#endregion


        //#region Operators
        
        /// <summary>
        /// Returns true if this equals rhs component-wise.
        /// </summary>
        public static bool operator==(double3 lhs, double3 rhs) => ((lhs.x == rhs.x && lhs.y == rhs.y) && lhs.z == rhs.z);
        
        /// <summary>
        /// Returns true if this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator!=(double3 lhs, double3 rhs) => !((lhs.x == rhs.x && lhs.y == rhs.y) && lhs.z == rhs.z);

        //#endregion


        //#region Functions
        
        /// <summary>
        /// Returns an array with all values
        /// </summary>
        public double[] ToArray() => new .[] ( x, y, z );
        
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
        /// Returns true iff distance between lhs and rhs is less than or equal to epsilon
        /// </summary>
        public static bool ApproxEqual(double3 lhs, double3 rhs, double eps = 0.1d) => Distance(lhs, rhs) <= eps;
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static double3x2 OuterProduct(double2 c, double3 r) =>  double3x2(c.x * r.x, c.y * r.x, c.x * r.y, c.y * r.y, c.x * r.z, c.y * r.z);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static double2x3 OuterProduct(double3 c, double2 r) =>  double2x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static double3x3 OuterProduct(double3 c, double3 r) =>  double3x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.x * r.z, c.y * r.z, c.z * r.z);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static double3x4 OuterProduct(double4 c, double3 r) =>  double3x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.w * r.z);
        
        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static double4x3 OuterProduct(double3 c, double4 r) =>  double4x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.x * r.w, c.y * r.w, c.z * r.w);
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static double Dot(double3 lhs, double3 rhs) => ((lhs.x * rhs.x + lhs.y * rhs.y) + lhs.z * rhs.z);
        
        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static double Distance(double3 lhs, double3 rhs) => (lhs - rhs).Length;
        
        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static double DistanceSqr(double3 lhs, double3 rhs) => (lhs - rhs).LengthSqr;
        
        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static double3 Reflect(double3 I, double3 N) => I - 2 * Dot(N, I) * N;
        
        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static double3 Refract(double3 I, double3 N, double eta)
        {
            let dNI = Dot(N, I);
            let k = 1 - eta * eta * (1 - dNI * dNI);
            if (k < 0) return Zero;
            return eta * I - (eta * dNI + (double)System.Math.Sqrt(k)) * N;
        }
        
        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static double3 FaceForward(double3 N, double3 I, double3 Nref) => Dot(Nref, I) < 0 ? N : -N;
        
        /// <summary>
        /// Returns the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        public static double3 Cross(double3 l, double3 r) =>  double3(l.y * r.z - l.z * r.y, l.z * r.x - l.x * r.z, l.x * r.y - l.y * r.x);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed uniform values between 0.0 and 1.0.
        /// </summary>
        public static double3 Random(Random random) =>  double3((double)random.NextDouble(), (double)random.NextDouble(), (double)random.NextDouble());
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed uniform values between -1.0 and 1.0.
        /// </summary>
        public static double3 RandomSigned(Random random) =>  double3((double)(random.NextDouble() * 2.0 - 1.0), (double)(random.NextDouble() * 2.0 - 1.0), (double)(random.NextDouble() * 2.0 - 1.0));
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed values according to a normal distribution (zero mean, unit variance).
        /// </summary>
        public static double3 RandomNormal(Random random) =>  double3((double)(System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))), (double)(System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))), (double)(System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))));

        //#endregion


        //#region Component-Wise Static Functions
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(double3 lhs, double3 rhs) => bool3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(double3 lhs, double rhs) => bool3(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(double lhs, double3 rhs) => bool3(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z);
        
        /// <summary>
        /// Returns a bool from the application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(double lhs, double rhs) => bool3(lhs == rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(double3 lhs, double3 rhs) => bool3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(double3 lhs, double rhs) => bool3(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(double lhs, double3 rhs) => bool3(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z);
        
        /// <summary>
        /// Returns a bool from the application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(double lhs, double rhs) => bool3(lhs != rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(double3 lhs, double3 rhs) => bool3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(double3 lhs, double rhs) => bool3(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(double lhs, double3 rhs) => bool3(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z);
        
        /// <summary>
        /// Returns a bool from the application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(double lhs, double rhs) => bool3(lhs > rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(double3 lhs, double3 rhs) => bool3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(double3 lhs, double rhs) => bool3(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(double lhs, double3 rhs) => bool3(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z);
        
        /// <summary>
        /// Returns a bool from the application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(double lhs, double rhs) => bool3(lhs >= rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(double3 lhs, double3 rhs) => bool3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(double3 lhs, double rhs) => bool3(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(double lhs, double3 rhs) => bool3(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z);
        
        /// <summary>
        /// Returns a bool from the application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(double lhs, double rhs) => bool3(lhs < rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(double3 lhs, double3 rhs) => bool3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(double3 lhs, double rhs) => bool3(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(double lhs, double3 rhs) => bool3(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z);
        
        /// <summary>
        /// Returns a bool from the application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(double lhs, double rhs) => bool3(lhs <= rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of IsInfinity (v.IsInfinity).
        /// </summary>
        public static bool3 IsInfinity(double3 v) => bool3(v.x.IsInfinity, v.y.IsInfinity, v.z.IsInfinity);
        
        /// <summary>
        /// Returns a bool from the application of IsInfinity (v.IsInfinity).
        /// </summary>
        public static bool3 IsInfinity(double v) => bool3(v.IsInfinity);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of IsNaN (v.IsNaN).
        /// </summary>
        public static bool3 IsNaN(double3 v) => bool3(v.x.IsNaN, v.y.IsNaN, v.z.IsNaN);
        
        /// <summary>
        /// Returns a bool from the application of IsNaN (v.IsNaN).
        /// </summary>
        public static bool3 IsNaN(double v) => bool3(v.IsNaN);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of IsNegativeInfinity (v.IsNegativeInfinity).
        /// </summary>
        public static bool3 IsNegativeInfinity(double3 v) => bool3(v.x.IsNegativeInfinity, v.y.IsNegativeInfinity, v.z.IsNegativeInfinity);
        
        /// <summary>
        /// Returns a bool from the application of IsNegativeInfinity (v.IsNegativeInfinity).
        /// </summary>
        public static bool3 IsNegativeInfinity(double v) => bool3(v.IsNegativeInfinity);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of IsPositiveInfinity (v.IsPositiveInfinity).
        /// </summary>
        public static bool3 IsPositiveInfinity(double3 v) => bool3(v.x.IsPositiveInfinity, v.y.IsPositiveInfinity, v.z.IsPositiveInfinity);
        
        /// <summary>
        /// Returns a bool from the application of IsPositiveInfinity (v.IsPositiveInfinity).
        /// </summary>
        public static bool3 IsPositiveInfinity(double v) => bool3(v.IsPositiveInfinity);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Abs (System.Math.Abs(v)).
        /// </summary>
        public static double3 Abs(double3 v) => double3(System.Math.Abs(v.x), System.Math.Abs(v.y), System.Math.Abs(v.z));
        
        /// <summary>
        /// Returns a double from the application of Abs (System.Math.Abs(v)).
        /// </summary>
        public static double3 Abs(double v) => double3(System.Math.Abs(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static double3 HermiteInterpolationOrder3(double3 v) => double3((3 - 2 * v.x) * v.x * v.x, (3 - 2 * v.y) * v.y * v.y, (3 - 2 * v.z) * v.z * v.z);
        
        /// <summary>
        /// Returns a double from the application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static double3 HermiteInterpolationOrder3(double v) => double3((3 - 2 * v) * v * v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static double3 HermiteInterpolationOrder5(double3 v) => double3(((6 * v.x - 15) * v.x + 10) * v.x * v.x * v.x, ((6 * v.y - 15) * v.y + 10) * v.y * v.y * v.y, ((6 * v.z - 15) * v.z + 10) * v.z * v.z * v.z);
        
        /// <summary>
        /// Returns a double from the application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static double3 HermiteInterpolationOrder5(double v) => double3(((6 * v - 15) * v + 10) * v * v * v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Sqr (v * v).
        /// </summary>
        public static double3 Sqr(double3 v) => double3(v.x * v.x, v.y * v.y, v.z * v.z);
        
        /// <summary>
        /// Returns a double from the application of Sqr (v * v).
        /// </summary>
        public static double3 Sqr(double v) => double3(v * v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static double3 Pow2(double3 v) => double3(v.x * v.x, v.y * v.y, v.z * v.z);
        
        /// <summary>
        /// Returns a double from the application of Pow2 (v * v).
        /// </summary>
        public static double3 Pow2(double v) => double3(v * v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static double3 Pow3(double3 v) => double3(v.x * v.x * v.x, v.y * v.y * v.y, v.z * v.z * v.z);
        
        /// <summary>
        /// Returns a double from the application of Pow3 (v * v * v).
        /// </summary>
        public static double3 Pow3(double v) => double3(v * v * v);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Step (v &gt;= 0.0 ? 1.0 : 0.0).
        /// </summary>
        public static double3 Step(double3 v) => double3(v.x >= 0.0 ? 1.0 : 0.0, v.y >= 0.0 ? 1.0 : 0.0, v.z >= 0.0 ? 1.0 : 0.0);
        
        /// <summary>
        /// Returns a double from the application of Step (v &gt;= 0.0 ? 1.0 : 0.0).
        /// </summary>
        public static double3 Step(double v) => double3(v >= 0.0 ? 1.0 : 0.0);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Sqrt ((double)System.Math.Sqrt((double)v)).
        /// </summary>
        public static double3 Sqrt(double3 v) => double3((double)System.Math.Sqrt((double)v.x), (double)System.Math.Sqrt((double)v.y), (double)System.Math.Sqrt((double)v.z));
        
        /// <summary>
        /// Returns a double from the application of Sqrt ((double)System.Math.Sqrt((double)v)).
        /// </summary>
        public static double3 Sqrt(double v) => double3((double)System.Math.Sqrt((double)v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of InverseSqrt ((double)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        public static double3 InverseSqrt(double3 v) => double3((double)(1.0 / System.Math.Sqrt((double)v.x)), (double)(1.0 / System.Math.Sqrt((double)v.y)), (double)(1.0 / System.Math.Sqrt((double)v.z)));
        
        /// <summary>
        /// Returns a double from the application of InverseSqrt ((double)(1.0 / System.Math.Sqrt((double)v))).
        /// </summary>
        public static double3 InverseSqrt(double v) => double3((double)(1.0 / System.Math.Sqrt((double)v)));
        
        /// <summary>
        /// Returns a int3 from component-wise application of Sign (System.Math.Sign(v)).
        /// </summary>
        public static int3 Sign(double3 v) => int3(System.Math.Sign(v.x), System.Math.Sign(v.y), System.Math.Sign(v.z));
        
        /// <summary>
        /// Returns a int from the application of Sign (System.Math.Sign(v)).
        /// </summary>
        public static int3 Sign(double v) => int3(System.Math.Sign(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static double3 Max(double3 lhs, double3 rhs) => double3(System.Math.Max(lhs.x, rhs.x), System.Math.Max(lhs.y, rhs.y), System.Math.Max(lhs.z, rhs.z));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static double3 Max(double3 lhs, double rhs) => double3(System.Math.Max(lhs.x, rhs), System.Math.Max(lhs.y, rhs), System.Math.Max(lhs.z, rhs));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static double3 Max(double lhs, double3 rhs) => double3(System.Math.Max(lhs, rhs.x), System.Math.Max(lhs, rhs.y), System.Math.Max(lhs, rhs.z));
        
        /// <summary>
        /// Returns a double from the application of Max (System.Math.Max(lhs, rhs)).
        /// </summary>
        public static double3 Max(double lhs, double rhs) => double3(System.Math.Max(lhs, rhs));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static double3 Min(double3 lhs, double3 rhs) => double3(System.Math.Min(lhs.x, rhs.x), System.Math.Min(lhs.y, rhs.y), System.Math.Min(lhs.z, rhs.z));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static double3 Min(double3 lhs, double rhs) => double3(System.Math.Min(lhs.x, rhs), System.Math.Min(lhs.y, rhs), System.Math.Min(lhs.z, rhs));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static double3 Min(double lhs, double3 rhs) => double3(System.Math.Min(lhs, rhs.x), System.Math.Min(lhs, rhs.y), System.Math.Min(lhs, rhs.z));
        
        /// <summary>
        /// Returns a double from the application of Min (System.Math.Min(lhs, rhs)).
        /// </summary>
        public static double3 Min(double lhs, double rhs) => double3(System.Math.Min(lhs, rhs));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Pow ((double)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static double3 Pow(double3 lhs, double3 rhs) => double3((double)System.Math.Pow((double)lhs.x, (double)rhs.x), (double)System.Math.Pow((double)lhs.y, (double)rhs.y), (double)System.Math.Pow((double)lhs.z, (double)rhs.z));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Pow ((double)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static double3 Pow(double3 lhs, double rhs) => double3((double)System.Math.Pow((double)lhs.x, (double)rhs), (double)System.Math.Pow((double)lhs.y, (double)rhs), (double)System.Math.Pow((double)lhs.z, (double)rhs));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Pow ((double)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static double3 Pow(double lhs, double3 rhs) => double3((double)System.Math.Pow((double)lhs, (double)rhs.x), (double)System.Math.Pow((double)lhs, (double)rhs.y), (double)System.Math.Pow((double)lhs, (double)rhs.z));
        
        /// <summary>
        /// Returns a double from the application of Pow ((double)System.Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static double3 Pow(double lhs, double rhs) => double3((double)System.Math.Pow((double)lhs, (double)rhs));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Log ((double)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static double3 Log(double3 lhs, double3 rhs) => double3((double)System.Math.Log((double)lhs.x, (double)rhs.x), (double)System.Math.Log((double)lhs.y, (double)rhs.y), (double)System.Math.Log((double)lhs.z, (double)rhs.z));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Log ((double)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static double3 Log(double3 lhs, double rhs) => double3((double)System.Math.Log((double)lhs.x, (double)rhs), (double)System.Math.Log((double)lhs.y, (double)rhs), (double)System.Math.Log((double)lhs.z, (double)rhs));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Log ((double)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static double3 Log(double lhs, double3 rhs) => double3((double)System.Math.Log((double)lhs, (double)rhs.x), (double)System.Math.Log((double)lhs, (double)rhs.y), (double)System.Math.Log((double)lhs, (double)rhs.z));
        
        /// <summary>
        /// Returns a double from the application of Log ((double)System.Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static double3 Log(double lhs, double rhs) => double3((double)System.Math.Log((double)lhs, (double)rhs));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static double3 Clamp(double3 v, double3 min, double3 max) => double3(System.Math.Min(System.Math.Max(v.x, min.x), max.x), System.Math.Min(System.Math.Max(v.y, min.y), max.y), System.Math.Min(System.Math.Max(v.z, min.z), max.z));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static double3 Clamp(double3 v, double3 min, double max) => double3(System.Math.Min(System.Math.Max(v.x, min.x), max), System.Math.Min(System.Math.Max(v.y, min.y), max), System.Math.Min(System.Math.Max(v.z, min.z), max));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static double3 Clamp(double3 v, double min, double3 max) => double3(System.Math.Min(System.Math.Max(v.x, min), max.x), System.Math.Min(System.Math.Max(v.y, min), max.y), System.Math.Min(System.Math.Max(v.z, min), max.z));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static double3 Clamp(double3 v, double min, double max) => double3(System.Math.Min(System.Math.Max(v.x, min), max), System.Math.Min(System.Math.Max(v.y, min), max), System.Math.Min(System.Math.Max(v.z, min), max));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static double3 Clamp(double v, double3 min, double3 max) => double3(System.Math.Min(System.Math.Max(v, min.x), max.x), System.Math.Min(System.Math.Max(v, min.y), max.y), System.Math.Min(System.Math.Max(v, min.z), max.z));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static double3 Clamp(double v, double3 min, double max) => double3(System.Math.Min(System.Math.Max(v, min.x), max), System.Math.Min(System.Math.Max(v, min.y), max), System.Math.Min(System.Math.Max(v, min.z), max));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static double3 Clamp(double v, double min, double3 max) => double3(System.Math.Min(System.Math.Max(v, min), max.x), System.Math.Min(System.Math.Max(v, min), max.y), System.Math.Min(System.Math.Max(v, min), max.z));
        
        /// <summary>
        /// Returns a double from the application of Clamp (System.Math.Min(System.Math.Max(v, min), max)).
        /// </summary>
        public static double3 Clamp(double v, double min, double max) => double3(System.Math.Min(System.Math.Max(v, min), max));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double3 Mix(double3 min, double3 max, double3 a) => double3(min.x * (1-a.x) + max.x * a.x, min.y * (1-a.y) + max.y * a.y, min.z * (1-a.z) + max.z * a.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double3 Mix(double3 min, double3 max, double a) => double3(min.x * (1-a) + max.x * a, min.y * (1-a) + max.y * a, min.z * (1-a) + max.z * a);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double3 Mix(double3 min, double max, double3 a) => double3(min.x * (1-a.x) + max * a.x, min.y * (1-a.y) + max * a.y, min.z * (1-a.z) + max * a.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double3 Mix(double3 min, double max, double a) => double3(min.x * (1-a) + max * a, min.y * (1-a) + max * a, min.z * (1-a) + max * a);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double3 Mix(double min, double3 max, double3 a) => double3(min * (1-a.x) + max.x * a.x, min * (1-a.y) + max.y * a.y, min * (1-a.z) + max.z * a.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double3 Mix(double min, double3 max, double a) => double3(min * (1-a) + max.x * a, min * (1-a) + max.y * a, min * (1-a) + max.z * a);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double3 Mix(double min, double max, double3 a) => double3(min * (1-a.x) + max * a.x, min * (1-a.y) + max * a.y, min * (1-a.z) + max * a.z);
        
        /// <summary>
        /// Returns a double from the application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double3 Mix(double min, double max, double a) => double3(min * (1-a) + max * a);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double3 Lerp(double3 min, double3 max, double3 a) => double3(min.x * (1-a.x) + max.x * a.x, min.y * (1-a.y) + max.y * a.y, min.z * (1-a.z) + max.z * a.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double3 Lerp(double3 min, double3 max, double a) => double3(min.x * (1-a) + max.x * a, min.y * (1-a) + max.y * a, min.z * (1-a) + max.z * a);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double3 Lerp(double3 min, double max, double3 a) => double3(min.x * (1-a.x) + max * a.x, min.y * (1-a.y) + max * a.y, min.z * (1-a.z) + max * a.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double3 Lerp(double3 min, double max, double a) => double3(min.x * (1-a) + max * a, min.y * (1-a) + max * a, min.z * (1-a) + max * a);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double3 Lerp(double min, double3 max, double3 a) => double3(min * (1-a.x) + max.x * a.x, min * (1-a.y) + max.y * a.y, min * (1-a.z) + max.z * a.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double3 Lerp(double min, double3 max, double a) => double3(min * (1-a) + max.x * a, min * (1-a) + max.y * a, min * (1-a) + max.z * a);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double3 Lerp(double min, double max, double3 a) => double3(min * (1-a.x) + max * a.x, min * (1-a.y) + max * a.y, min * (1-a.z) + max * a.z);
        
        /// <summary>
        /// Returns a double from the application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double3 Lerp(double min, double max, double a) => double3(min * (1-a) + max * a);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static double3 Fma(double3 a, double3 b, double3 c) => double3(a.x * b.x + c.x, a.y * b.y + c.y, a.z * b.z + c.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static double3 Fma(double3 a, double3 b, double c) => double3(a.x * b.x + c, a.y * b.y + c, a.z * b.z + c);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static double3 Fma(double3 a, double b, double3 c) => double3(a.x * b + c.x, a.y * b + c.y, a.z * b + c.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static double3 Fma(double3 a, double b, double c) => double3(a.x * b + c, a.y * b + c, a.z * b + c);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static double3 Fma(double a, double3 b, double3 c) => double3(a * b.x + c.x, a * b.y + c.y, a * b.z + c.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static double3 Fma(double a, double3 b, double c) => double3(a * b.x + c, a * b.y + c, a * b.z + c);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static double3 Fma(double a, double b, double3 c) => double3(a * b + c.x, a * b + c.y, a * b + c.z);
        
        /// <summary>
        /// Returns a double from the application of Fma (a * b + c).
        /// </summary>
        public static double3 Fma(double a, double b, double c) => double3(a * b + c);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static double3 Add(double3 lhs, double3 rhs) => double3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static double3 Add(double3 lhs, double rhs) => double3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static double3 Add(double lhs, double3 rhs) => double3(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z);
        
        /// <summary>
        /// Returns a double from the application of Add (lhs + rhs).
        /// </summary>
        public static double3 Add(double lhs, double rhs) => double3(lhs + rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static double3 Sub(double3 lhs, double3 rhs) => double3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static double3 Sub(double3 lhs, double rhs) => double3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static double3 Sub(double lhs, double3 rhs) => double3(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z);
        
        /// <summary>
        /// Returns a double from the application of Sub (lhs - rhs).
        /// </summary>
        public static double3 Sub(double lhs, double rhs) => double3(lhs - rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static double3 Mul(double3 lhs, double3 rhs) => double3(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static double3 Mul(double3 lhs, double rhs) => double3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static double3 Mul(double lhs, double3 rhs) => double3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        
        /// <summary>
        /// Returns a double from the application of Mul (lhs * rhs).
        /// </summary>
        public static double3 Mul(double lhs, double rhs) => double3(lhs * rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static double3 Div(double3 lhs, double3 rhs) => double3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static double3 Div(double3 lhs, double rhs) => double3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static double3 Div(double lhs, double3 rhs) => double3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);
        
        /// <summary>
        /// Returns a double from the application of Div (lhs / rhs).
        /// </summary>
        public static double3 Div(double lhs, double rhs) => double3(lhs / rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        public static double3 Modulo(double3 lhs, double3 rhs) => double3(lhs.x % rhs.x, lhs.y % rhs.y, lhs.z % rhs.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        public static double3 Modulo(double3 lhs, double rhs) => double3(lhs.x % rhs, lhs.y % rhs, lhs.z % rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        public static double3 Modulo(double lhs, double3 rhs) => double3(lhs % rhs.x, lhs % rhs.y, lhs % rhs.z);
        
        /// <summary>
        /// Returns a double from the application of Modulo (lhs % rhs).
        /// </summary>
        public static double3 Modulo(double lhs, double rhs) => double3(lhs % rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of Degrees (Radians-To-Degrees Conversion).
        /// </summary>
        public static double3 Degrees(double3 v) => double3((double)(v.x * 57.295779513082320876798154814105170332405472466564321d), (double)(v.y * 57.295779513082320876798154814105170332405472466564321d), (double)(v.z * 57.295779513082320876798154814105170332405472466564321d));
        
        /// <summary>
        /// Returns a double from the application of Degrees (Radians-To-Degrees Conversion).
        /// </summary>
        public static double3 Degrees(double v) => double3((double)(v * 57.295779513082320876798154814105170332405472466564321d));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Radians (Degrees-To-Radians Conversion).
        /// </summary>
        public static double3 Radians(double3 v) => double3((double)(v.x * 0.0174532925199432957692369076848861271344287188854172d), (double)(v.y * 0.0174532925199432957692369076848861271344287188854172d), (double)(v.z * 0.0174532925199432957692369076848861271344287188854172d));
        
        /// <summary>
        /// Returns a double from the application of Radians (Degrees-To-Radians Conversion).
        /// </summary>
        public static double3 Radians(double v) => double3((double)(v * 0.0174532925199432957692369076848861271344287188854172d));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Acos (System.Math.Acos(v)).
        /// </summary>
        public static double3 Acos(double3 v) => double3(System.Math.Acos(v.x), System.Math.Acos(v.y), System.Math.Acos(v.z));
        
        /// <summary>
        /// Returns a double from the application of Acos (System.Math.Acos(v)).
        /// </summary>
        public static double3 Acos(double v) => double3(System.Math.Acos(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Asin (System.Math.Asin(v)).
        /// </summary>
        public static double3 Asin(double3 v) => double3(System.Math.Asin(v.x), System.Math.Asin(v.y), System.Math.Asin(v.z));
        
        /// <summary>
        /// Returns a double from the application of Asin (System.Math.Asin(v)).
        /// </summary>
        public static double3 Asin(double v) => double3(System.Math.Asin(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Atan (System.Math.Atan(v)).
        /// </summary>
        public static double3 Atan(double3 v) => double3(System.Math.Atan(v.x), System.Math.Atan(v.y), System.Math.Atan(v.z));
        
        /// <summary>
        /// Returns a double from the application of Atan (System.Math.Atan(v)).
        /// </summary>
        public static double3 Atan(double v) => double3(System.Math.Atan(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Cos (System.Math.Cos(v)).
        /// </summary>
        public static double3 Cos(double3 v) => double3(System.Math.Cos(v.x), System.Math.Cos(v.y), System.Math.Cos(v.z));
        
        /// <summary>
        /// Returns a double from the application of Cos (System.Math.Cos(v)).
        /// </summary>
        public static double3 Cos(double v) => double3(System.Math.Cos(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Cosh (System.Math.Cosh(v)).
        /// </summary>
        public static double3 Cosh(double3 v) => double3(System.Math.Cosh(v.x), System.Math.Cosh(v.y), System.Math.Cosh(v.z));
        
        /// <summary>
        /// Returns a double from the application of Cosh (System.Math.Cosh(v)).
        /// </summary>
        public static double3 Cosh(double v) => double3(System.Math.Cosh(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Exp (System.Math.Exp(v)).
        /// </summary>
        public static double3 Exp(double3 v) => double3(System.Math.Exp(v.x), System.Math.Exp(v.y), System.Math.Exp(v.z));
        
        /// <summary>
        /// Returns a double from the application of Exp (System.Math.Exp(v)).
        /// </summary>
        public static double3 Exp(double v) => double3(System.Math.Exp(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Log (System.Math.Log(v)).
        /// </summary>
        public static double3 Log(double3 v) => double3(System.Math.Log(v.x), System.Math.Log(v.y), System.Math.Log(v.z));
        
        /// <summary>
        /// Returns a double from the application of Log (System.Math.Log(v)).
        /// </summary>
        public static double3 Log(double v) => double3(System.Math.Log(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Log2 (System.Math.Log(v, 2)).
        /// </summary>
        public static double3 Log2(double3 v) => double3(System.Math.Log(v.x, 2), System.Math.Log(v.y, 2), System.Math.Log(v.z, 2));
        
        /// <summary>
        /// Returns a double from the application of Log2 (System.Math.Log(v, 2)).
        /// </summary>
        public static double3 Log2(double v) => double3(System.Math.Log(v, 2));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Log10 (System.Math.Log10(v)).
        /// </summary>
        public static double3 Log10(double3 v) => double3(System.Math.Log10(v.x), System.Math.Log10(v.y), System.Math.Log10(v.z));
        
        /// <summary>
        /// Returns a double from the application of Log10 (System.Math.Log10(v)).
        /// </summary>
        public static double3 Log10(double v) => double3(System.Math.Log10(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Floor (System.Math.Floor(v)).
        /// </summary>
        public static double3 Floor(double3 v) => double3(System.Math.Floor(v.x), System.Math.Floor(v.y), System.Math.Floor(v.z));
        
        /// <summary>
        /// Returns a double from the application of Floor (System.Math.Floor(v)).
        /// </summary>
        public static double3 Floor(double v) => double3(System.Math.Floor(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Ceiling (System.Math.Ceiling(v)).
        /// </summary>
        public static double3 Ceiling(double3 v) => double3(System.Math.Ceiling(v.x), System.Math.Ceiling(v.y), System.Math.Ceiling(v.z));
        
        /// <summary>
        /// Returns a double from the application of Ceiling (System.Math.Ceiling(v)).
        /// </summary>
        public static double3 Ceiling(double v) => double3(System.Math.Ceiling(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Round (System.Math.Round(v)).
        /// </summary>
        public static double3 Round(double3 v) => double3(System.Math.Round(v.x), System.Math.Round(v.y), System.Math.Round(v.z));
        
        /// <summary>
        /// Returns a double from the application of Round (System.Math.Round(v)).
        /// </summary>
        public static double3 Round(double v) => double3(System.Math.Round(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Sin (System.Math.Sin(v)).
        /// </summary>
        public static double3 Sin(double3 v) => double3(System.Math.Sin(v.x), System.Math.Sin(v.y), System.Math.Sin(v.z));
        
        /// <summary>
        /// Returns a double from the application of Sin (System.Math.Sin(v)).
        /// </summary>
        public static double3 Sin(double v) => double3(System.Math.Sin(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Sinh (System.Math.Sinh(v)).
        /// </summary>
        public static double3 Sinh(double3 v) => double3(System.Math.Sinh(v.x), System.Math.Sinh(v.y), System.Math.Sinh(v.z));
        
        /// <summary>
        /// Returns a double from the application of Sinh (System.Math.Sinh(v)).
        /// </summary>
        public static double3 Sinh(double v) => double3(System.Math.Sinh(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Tan (System.Math.Tan(v)).
        /// </summary>
        public static double3 Tan(double3 v) => double3(System.Math.Tan(v.x), System.Math.Tan(v.y), System.Math.Tan(v.z));
        
        /// <summary>
        /// Returns a double from the application of Tan (System.Math.Tan(v)).
        /// </summary>
        public static double3 Tan(double v) => double3(System.Math.Tan(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Tanh (System.Math.Tanh(v)).
        /// </summary>
        public static double3 Tanh(double3 v) => double3(System.Math.Tanh(v.x), System.Math.Tanh(v.y), System.Math.Tanh(v.z));
        
        /// <summary>
        /// Returns a double from the application of Tanh (System.Math.Tanh(v)).
        /// </summary>
        public static double3 Tanh(double v) => double3(System.Math.Tanh(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Truncate (System.Math.Truncate(v)).
        /// </summary>
        public static double3 Truncate(double3 v) => double3(System.Math.Truncate(v.x), System.Math.Truncate(v.y), System.Math.Truncate(v.z));
        
        /// <summary>
        /// Returns a double from the application of Truncate (System.Math.Truncate(v)).
        /// </summary>
        public static double3 Truncate(double v) => double3(System.Math.Truncate(v));
        
        /// <summary>
        /// Returns a double3 from component-wise application of Fract ((v - System.Math.Floor(v))).
        /// </summary>
        public static double3 Fract(double3 v) => double3((v.x - System.Math.Floor(v.x)), (v.y - System.Math.Floor(v.y)), (v.z - System.Math.Floor(v.z)));
        
        /// <summary>
        /// Returns a double from the application of Fract ((v - System.Math.Floor(v))).
        /// </summary>
        public static double3 Fract(double v) => double3((v - System.Math.Floor(v)));
        
        /// <summary>
        /// Returns a double3 from component-wise application of TruncateFast ((int64)(v)).
        /// </summary>
        public static double3 TruncateFast(double3 v) => double3((int64)(v.x), (int64)(v.y), (int64)(v.z));
        
        /// <summary>
        /// Returns a double from the application of TruncateFast ((int64)(v)).
        /// </summary>
        public static double3 TruncateFast(double v) => double3((int64)(v));
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed uniform values between 'minValue' and 'maxValue'.
        /// </summary>
        public static double3 Random(Random random, double3 minValue, double3 maxValue) => double3((double)random.NextDouble() * (maxValue.x - minValue.x) + minValue.x, (double)random.NextDouble() * (maxValue.y - minValue.y) + minValue.y, (double)random.NextDouble() * (maxValue.z - minValue.z) + minValue.z);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed uniform values between 'minValue' and 'maxValue'.
        /// </summary>
        public static double3 Random(Random random, double3 minValue, double maxValue) => double3((double)random.NextDouble() * (maxValue - minValue.x) + minValue.x, (double)random.NextDouble() * (maxValue - minValue.y) + minValue.y, (double)random.NextDouble() * (maxValue - minValue.z) + minValue.z);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed uniform values between 'minValue' and 'maxValue'.
        /// </summary>
        public static double3 Random(Random random, double minValue, double3 maxValue) => double3((double)random.NextDouble() * (maxValue.x - minValue) + minValue, (double)random.NextDouble() * (maxValue.y - minValue) + minValue, (double)random.NextDouble() * (maxValue.z - minValue) + minValue);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed uniform values between 'minValue' and 'maxValue'.
        /// </summary>
        public static double3 Random(Random random, double minValue, double maxValue) => double3((double)random.NextDouble() * (maxValue - minValue) + minValue);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed uniform values between 'minValue' and 'maxValue'.
        /// </summary>
        public static double3 RandomUniform(Random random, double3 minValue, double3 maxValue) => double3((double)random.NextDouble() * (maxValue.x - minValue.x) + minValue.x, (double)random.NextDouble() * (maxValue.y - minValue.y) + minValue.y, (double)random.NextDouble() * (maxValue.z - minValue.z) + minValue.z);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed uniform values between 'minValue' and 'maxValue'.
        /// </summary>
        public static double3 RandomUniform(Random random, double3 minValue, double maxValue) => double3((double)random.NextDouble() * (maxValue - minValue.x) + minValue.x, (double)random.NextDouble() * (maxValue - minValue.y) + minValue.y, (double)random.NextDouble() * (maxValue - minValue.z) + minValue.z);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed uniform values between 'minValue' and 'maxValue'.
        /// </summary>
        public static double3 RandomUniform(Random random, double minValue, double3 maxValue) => double3((double)random.NextDouble() * (maxValue.x - minValue) + minValue, (double)random.NextDouble() * (maxValue.y - minValue) + minValue, (double)random.NextDouble() * (maxValue.z - minValue) + minValue);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed uniform values between 'minValue' and 'maxValue'.
        /// </summary>
        public static double3 RandomUniform(Random random, double minValue, double maxValue) => double3((double)random.NextDouble() * (maxValue - minValue) + minValue);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance.
        /// </summary>
        public static double3 RandomNormal(Random random, double3 mean, double3 variance) => double3((double)(System.Math.Sqrt((double)variance.x) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean.x, (double)(System.Math.Sqrt((double)variance.y) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean.y, (double)(System.Math.Sqrt((double)variance.z) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean.z);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance.
        /// </summary>
        public static double3 RandomNormal(Random random, double3 mean, double variance) => double3((double)(System.Math.Sqrt((double)variance) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean.x, (double)(System.Math.Sqrt((double)variance) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean.y, (double)(System.Math.Sqrt((double)variance) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean.z);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance.
        /// </summary>
        public static double3 RandomNormal(Random random, double mean, double3 variance) => double3((double)(System.Math.Sqrt((double)variance.x) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean, (double)(System.Math.Sqrt((double)variance.y) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean, (double)(System.Math.Sqrt((double)variance.z) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance.
        /// </summary>
        public static double3 RandomNormal(Random random, double mean, double variance) => double3((double)(System.Math.Sqrt((double)variance) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance.
        /// </summary>
        public static double3 RandomGaussian(Random random, double3 mean, double3 variance) => double3((double)(System.Math.Sqrt((double)variance.x) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean.x, (double)(System.Math.Sqrt((double)variance.y) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean.y, (double)(System.Math.Sqrt((double)variance.z) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean.z);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance.
        /// </summary>
        public static double3 RandomGaussian(Random random, double3 mean, double variance) => double3((double)(System.Math.Sqrt((double)variance) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean.x, (double)(System.Math.Sqrt((double)variance) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean.y, (double)(System.Math.Sqrt((double)variance) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean.z);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance.
        /// </summary>
        public static double3 RandomGaussian(Random random, double mean, double3 variance) => double3((double)(System.Math.Sqrt((double)variance.x) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean, (double)(System.Math.Sqrt((double)variance.y) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean, (double)(System.Math.Sqrt((double)variance.z) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean);
        
        /// <summary>
        /// Returns a double3 with independent and identically distributed values according to a normal/Gaussian distribution with specified mean and variance.
        /// </summary>
        public static double3 RandomGaussian(Random random, double mean, double variance) => double3((double)(System.Math.Sqrt((double)variance) * System.Math.Cos(2 * System.Math.PI_d * random.NextDouble()) * System.Math.Sqrt(-2.0 * System.Math.Log(random.NextDouble()))) + mean);

        //#endregion


        //#region Component-Wise Operator Overloads
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool3 operator<(double3 lhs, double3 rhs) => bool3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool3 operator<(double3 lhs, double rhs) => bool3(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool3 operator<(double lhs, double3 rhs) => bool3(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool3 operator<=(double3 lhs, double3 rhs) => bool3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool3 operator<=(double3 lhs, double rhs) => bool3(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool3 operator<=(double lhs, double3 rhs) => bool3(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool3 operator>(double3 lhs, double3 rhs) => bool3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool3 operator>(double3 lhs, double rhs) => bool3(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool3 operator>(double lhs, double3 rhs) => bool3(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool3 operator>=(double3 lhs, double3 rhs) => bool3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool3 operator>=(double3 lhs, double rhs) => bool3(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool3 operator>=(double lhs, double3 rhs) => bool3(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static double3 operator+(double3 lhs, double3 rhs) => double3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static double3 operator+(double3 lhs, double rhs) => double3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static double3 operator+(double lhs, double3 rhs) => double3(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static double3 operator-(double3 lhs, double3 rhs) => double3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static double3 operator-(double3 lhs, double rhs) => double3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static double3 operator-(double lhs, double3 rhs) => double3(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static double3 operator*(double3 lhs, double3 rhs) => double3(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static double3 operator*(double3 lhs, double rhs) => double3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static double3 operator*(double lhs, double3 rhs) => double3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static double3 operator/(double3 lhs, double3 rhs) => double3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static double3 operator/(double3 lhs, double rhs) => double3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static double3 operator/(double lhs, double3 rhs) => double3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of operator- (-v).
        /// </summary>
        public static double3 operator-(double3 v) => double3(-v.x, -v.y, -v.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static double3 operator%(double3 lhs, double3 rhs) => double3(lhs.x % rhs.x, lhs.y % rhs.y, lhs.z % rhs.z);
        
        /// <summary>
        /// Returns a double3 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static double3 operator%(double3 lhs, double rhs) => double3(lhs.x % rhs, lhs.y % rhs, lhs.z % rhs);
        
        /// <summary>
        /// Returns a double3 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static double3 operator%(double lhs, double3 rhs) => double3(lhs % rhs.x, lhs % rhs.y, lhs % rhs.z);

        //#endregion

    }
}
