using System;
namespace Atma
{
    
    /// <summary>
    /// A matrix of type double with 4 columns and 4 rows.
    /// </summary>
    public struct double4x4 : IEquatable<double4x4>
    {

        //#region Fields
        
        /// <summary>
        /// component data
        /// </summary>
        public double[16] values;

        //#endregion


        //#region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public this(double m00, double m01, double m02, double m03, double m10, double m11, double m12, double m13, double m20, double m21, double m22, double m23, double m30, double m31, double m32, double m33)
        {
            values = .(m00,m01,m02,m03,m10,m11,m12,m13,m20,m21,m22,m23,m30,m31,m32,m33);
        }
        
        /// <summary>
        /// Constructs this matrix from a double2x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(double2x2 m)
        {
            values = .(m.m00,m.m01,0.0,0.0,m.m10,m.m11,0.0,0.0,0.0,0.0,1.0,0.0,0.0,0.0,0.0,1.0);
        }
        
        /// <summary>
        /// Constructs this matrix from a double3x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(double3x2 m)
        {
            values = .(m.m00,m.m01,0.0,0.0,m.m10,m.m11,0.0,0.0,m.m20,m.m21,1.0,0.0,0.0,0.0,0.0,1.0);
        }
        
        /// <summary>
        /// Constructs this matrix from a double4x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(double4x2 m)
        {
            values = .(m.m00,m.m01,0.0,0.0,m.m10,m.m11,0.0,0.0,m.m20,m.m21,1.0,0.0,m.m30,m.m31,0.0,1.0);
        }
        
        /// <summary>
        /// Constructs this matrix from a double2x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(double2x3 m)
        {
            values = .(m.m00,m.m01,m.m02,0.0,m.m10,m.m11,m.m12,0.0,0.0,0.0,1.0,0.0,0.0,0.0,0.0,1.0);
        }
        
        /// <summary>
        /// Constructs this matrix from a double3x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(double3x3 m)
        {
            values = .(m.m00,m.m01,m.m02,0.0,m.m10,m.m11,m.m12,0.0,m.m20,m.m21,m.m22,0.0,0.0,0.0,0.0,1.0);
        }
        
        /// <summary>
        /// Constructs this matrix from a double4x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(double4x3 m)
        {
            values = .(m.m00,m.m01,m.m02,0.0,m.m10,m.m11,m.m12,0.0,m.m20,m.m21,m.m22,0.0,m.m30,m.m31,m.m32,1.0);
        }
        
        /// <summary>
        /// Constructs this matrix from a double2x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(double2x4 m)
        {
            values = .(m.m00,m.m01,m.m02,m.m03,m.m10,m.m11,m.m12,m.m13,0.0,0.0,1.0,0.0,0.0,0.0,0.0,1.0);
        }
        
        /// <summary>
        /// Constructs this matrix from a double3x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(double3x4 m)
        {
            values = .(m.m00,m.m01,m.m02,m.m03,m.m10,m.m11,m.m12,m.m13,m.m20,m.m21,m.m22,m.m23,0.0,0.0,0.0,1.0);
        }
        
        /// <summary>
        /// Constructs this matrix from a double4x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(double4x4 m)
        {
            values = .(m.m00,m.m01,m.m02,m.m03,m.m10,m.m11,m.m12,m.m13,m.m20,m.m21,m.m22,m.m23,m.m30,m.m31,m.m32,m.m33);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(double2 c0, double2 c1)
        {
            values = .(c0.x,c0.y,0.0,0.0,c1.x,c1.y,0.0,0.0,0.0,0.0,1.0,0.0,0.0,0.0,0.0,1.0);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(double2 c0, double2 c1, double2 c2)
        {
            values = .(c0.x,c0.y,0.0,0.0,c1.x,c1.y,0.0,0.0,c2.x,c2.y,1.0,0.0,0.0,0.0,0.0,1.0);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(double2 c0, double2 c1, double2 c2, double2 c3)
        {
            values = .(c0.x,c0.y,0.0,0.0,c1.x,c1.y,0.0,0.0,c2.x,c2.y,1.0,0.0,c3.x,c3.y,0.0,1.0);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(double3 c0, double3 c1)
        {
            values = .(c0.x,c0.y,c0.z,0.0,c1.x,c1.y,c1.z,0.0,0.0,0.0,1.0,0.0,0.0,0.0,0.0,1.0);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(double3 c0, double3 c1, double3 c2)
        {
            values = .(c0.x,c0.y,c0.z,0.0,c1.x,c1.y,c1.z,0.0,c2.x,c2.y,c2.z,0.0,0.0,0.0,0.0,1.0);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(double3 c0, double3 c1, double3 c2, double3 c3)
        {
            values = .(c0.x,c0.y,c0.z,0.0,c1.x,c1.y,c1.z,0.0,c2.x,c2.y,c2.z,0.0,c3.x,c3.y,c3.z,1.0);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(double4 c0, double4 c1)
        {
            values = .(c0.x,c0.y,c0.z,c0.w,c1.x,c1.y,c1.z,c1.w,0.0,0.0,1.0,0.0,0.0,0.0,0.0,1.0);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(double4 c0, double4 c1, double4 c2)
        {
            values = .(c0.x,c0.y,c0.z,c0.w,c1.x,c1.y,c1.z,c1.w,c2.x,c2.y,c2.z,c2.w,0.0,0.0,0.0,1.0);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(double4 c0, double4 c1, double4 c2, double4 c3)
        {
            values = .(c0.x,c0.y,c0.z,c0.w,c1.x,c1.y,c1.z,c1.w,c2.x,c2.y,c2.z,c2.w,c3.x,c3.y,c3.z,c3.w);
        }
        
        /// <summary>
        /// Creates a rotation matrix from a qdouble.
        /// </summary>
        public this(qdouble  q)
            : this(q.ToMat4)
        {
        }

        //#endregion


        //#region Explicit Operators
        
        /// <summary>
        /// Creates a rotation matrix from a qdouble.
        /// </summary>
        public static explicit operator double4x4(qdouble  q) => q.ToMat4;

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Column 0, Rows 0
        /// </summary>
        public double m00
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
        /// Column 0, Rows 1
        /// </summary>
        public double m01
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
        /// Column 0, Rows 2
        /// </summary>
        public double m02
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
        /// Column 0, Rows 3
        /// </summary>
        public double m03
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
        /// Column 1, Rows 0
        /// </summary>
        public double m10
        {
            [Inline]get
            {
                return values[4];
            }
            [Inline]set mut
            {
                values[4] = value;
            }
        }
        
        /// <summary>
        /// Column 1, Rows 1
        /// </summary>
        public double m11
        {
            [Inline]get
            {
                return values[5];
            }
            [Inline]set mut
            {
                values[5] = value;
            }
        }
        
        /// <summary>
        /// Column 1, Rows 2
        /// </summary>
        public double m12
        {
            [Inline]get
            {
                return values[6];
            }
            [Inline]set mut
            {
                values[6] = value;
            }
        }
        
        /// <summary>
        /// Column 1, Rows 3
        /// </summary>
        public double m13
        {
            [Inline]get
            {
                return values[7];
            }
            [Inline]set mut
            {
                values[7] = value;
            }
        }
        
        /// <summary>
        /// Column 2, Rows 0
        /// </summary>
        public double m20
        {
            [Inline]get
            {
                return values[8];
            }
            [Inline]set mut
            {
                values[8] = value;
            }
        }
        
        /// <summary>
        /// Column 2, Rows 1
        /// </summary>
        public double m21
        {
            [Inline]get
            {
                return values[9];
            }
            [Inline]set mut
            {
                values[9] = value;
            }
        }
        
        /// <summary>
        /// Column 2, Rows 2
        /// </summary>
        public double m22
        {
            [Inline]get
            {
                return values[10];
            }
            [Inline]set mut
            {
                values[10] = value;
            }
        }
        
        /// <summary>
        /// Column 2, Rows 3
        /// </summary>
        public double m23
        {
            [Inline]get
            {
                return values[11];
            }
            [Inline]set mut
            {
                values[11] = value;
            }
        }
        
        /// <summary>
        /// Column 3, Rows 0
        /// </summary>
        public double m30
        {
            [Inline]get
            {
                return values[12];
            }
            [Inline]set mut
            {
                values[12] = value;
            }
        }
        
        /// <summary>
        /// Column 3, Rows 1
        /// </summary>
        public double m31
        {
            [Inline]get
            {
                return values[13];
            }
            [Inline]set mut
            {
                values[13] = value;
            }
        }
        
        /// <summary>
        /// Column 3, Rows 2
        /// </summary>
        public double m32
        {
            [Inline]get
            {
                return values[14];
            }
            [Inline]set mut
            {
                values[14] = value;
            }
        }
        
        /// <summary>
        /// Column 3, Rows 3
        /// </summary>
        public double m33
        {
            [Inline]get
            {
                return values[15];
            }
            [Inline]set mut
            {
                values[15] = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the column nr 0
        /// </summary>
        public double4 Column0
        {
            [Inline]get
            {
                return  double4(m00, m01, m02, m03);
            }
            [Inline]set mut
            {
                m00 = value.x;
                m01 = value.y;
                m02 = value.z;
                m03 = value.w;
            }
        }
        
        /// <summary>
        /// Gets or sets the column nr 1
        /// </summary>
        public double4 Column1
        {
            [Inline]get
            {
                return  double4(m10, m11, m12, m13);
            }
            [Inline]set mut
            {
                m10 = value.x;
                m11 = value.y;
                m12 = value.z;
                m13 = value.w;
            }
        }
        
        /// <summary>
        /// Gets or sets the column nr 2
        /// </summary>
        public double4 Column2
        {
            [Inline]get
            {
                return  double4(m20, m21, m22, m23);
            }
            [Inline]set mut
            {
                m20 = value.x;
                m21 = value.y;
                m22 = value.z;
                m23 = value.w;
            }
        }
        
        /// <summary>
        /// Gets or sets the column nr 3
        /// </summary>
        public double4 Column3
        {
            [Inline]get
            {
                return  double4(m30, m31, m32, m33);
            }
            [Inline]set mut
            {
                m30 = value.x;
                m31 = value.y;
                m32 = value.z;
                m33 = value.w;
            }
        }
        
        /// <summary>
        /// Gets or sets the row nr 0
        /// </summary>
        public double4 Row0
        {
            [Inline]get
            {
                return  double4(m00, m10, m20, m30);
            }
            [Inline]set mut
            {
                m00 = value.x;
                m10 = value.y;
                m20 = value.z;
                m30 = value.w;
            }
        }
        
        /// <summary>
        /// Gets or sets the row nr 1
        /// </summary>
        public double4 Row1
        {
            [Inline]get
            {
                return  double4(m01, m11, m21, m31);
            }
            [Inline]set mut
            {
                m01 = value.x;
                m11 = value.y;
                m21 = value.z;
                m31 = value.w;
            }
        }
        
        /// <summary>
        /// Gets or sets the row nr 2
        /// </summary>
        public double4 Row2
        {
            [Inline]get
            {
                return  double4(m02, m12, m22, m32);
            }
            [Inline]set mut
            {
                m02 = value.x;
                m12 = value.y;
                m22 = value.z;
                m32 = value.w;
            }
        }
        
        /// <summary>
        /// Gets or sets the row nr 3
        /// </summary>
        public double4 Row3
        {
            [Inline]get
            {
                return  double4(m03, m13, m23, m33);
            }
            [Inline]set mut
            {
                m03 = value.x;
                m13 = value.y;
                m23 = value.z;
                m33 = value.w;
            }
        }
        
        /// <summary>
        /// Creates a quaternion from the rotational part of this matrix.
        /// </summary>
        public qdouble ToQuaternion => qdouble.FromMat4(this);

        //#endregion


        //#region Static Properties
        
        /// <summary>
        /// Predefined all-zero matrix
        /// </summary>
        readonly public static double4x4 Zero  =  double4x4(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
        
        /// <summary>
        /// Predefined all-ones matrix
        /// </summary>
        readonly public static double4x4 Ones  =  double4x4(1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
        
        /// <summary>
        /// Predefined identity matrix
        /// </summary>
        readonly public static double4x4 Identity  =  double4x4(1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
        
        /// <summary>
        /// Predefined all-MaxValue matrix
        /// </summary>
        readonly public static double4x4 AllMaxValue  =  double4x4(double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue);
        
        /// <summary>
        /// Predefined diagonal-MaxValue matrix
        /// </summary>
        readonly public static double4x4 DiagonalMaxValue  =  double4x4(double.MaxValue, 0.0, 0.0, 0.0, 0.0, double.MaxValue, 0.0, 0.0, 0.0, 0.0, double.MaxValue, 0.0, 0.0, 0.0, 0.0, double.MaxValue);
        
        /// <summary>
        /// Predefined all-MinValue matrix
        /// </summary>
        readonly public static double4x4 AllMinValue  =  double4x4(double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue);
        
        /// <summary>
        /// Predefined diagonal-MinValue matrix
        /// </summary>
        readonly public static double4x4 DiagonalMinValue  =  double4x4(double.MinValue, 0.0, 0.0, 0.0, 0.0, double.MinValue, 0.0, 0.0, 0.0, 0.0, double.MinValue, 0.0, 0.0, 0.0, 0.0, double.MinValue);
        
        /// <summary>
        /// Predefined all-Epsilon matrix
        /// </summary>
        readonly public static double4x4 AllEpsilon  =  double4x4(double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon);
        
        /// <summary>
        /// Predefined diagonal-Epsilon matrix
        /// </summary>
        readonly public static double4x4 DiagonalEpsilon  =  double4x4(double.Epsilon, 0.0, 0.0, 0.0, 0.0, double.Epsilon, 0.0, 0.0, 0.0, 0.0, double.Epsilon, 0.0, 0.0, 0.0, 0.0, double.Epsilon);
        
        /// <summary>
        /// Predefined all-NaN matrix
        /// </summary>
        readonly public static double4x4 AllNaN  =  double4x4(double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN);
        
        /// <summary>
        /// Predefined diagonal-NaN matrix
        /// </summary>
        readonly public static double4x4 DiagonalNaN  =  double4x4(double.NaN, 0.0, 0.0, 0.0, 0.0, double.NaN, 0.0, 0.0, 0.0, 0.0, double.NaN, 0.0, 0.0, 0.0, 0.0, double.NaN);
        
        /// <summary>
        /// Predefined all-NegativeInfinity matrix
        /// </summary>
        readonly public static double4x4 AllNegativeInfinity  =  double4x4(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity);
        
        /// <summary>
        /// Predefined diagonal-NegativeInfinity matrix
        /// </summary>
        readonly public static double4x4 DiagonalNegativeInfinity  =  double4x4(double.NegativeInfinity, 0.0, 0.0, 0.0, 0.0, double.NegativeInfinity, 0.0, 0.0, 0.0, 0.0, double.NegativeInfinity, 0.0, 0.0, 0.0, 0.0, double.NegativeInfinity);
        
        /// <summary>
        /// Predefined all-PositiveInfinity matrix
        /// </summary>
        readonly public static double4x4 AllPositiveInfinity  =  double4x4(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity);
        
        /// <summary>
        /// Predefined diagonal-PositiveInfinity matrix
        /// </summary>
        readonly public static double4x4 DiagonalPositiveInfinity  =  double4x4(double.PositiveInfinity, 0.0, 0.0, 0.0, 0.0, double.PositiveInfinity, 0.0, 0.0, 0.0, 0.0, double.PositiveInfinity, 0.0, 0.0, 0.0, 0.0, double.PositiveInfinity);

        //#endregion


        //#region Functions
        
        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public double[,] ToArray() => new .[,] ( ( m00, m01, m02, m03 ), ( m10, m11, m12, m13 ), ( m20, m21, m22, m23 ), ( m30, m31, m32, m33 ) );
        
        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public double[] ToArray1D() => new .[] ( m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33 );

        //#endregion

        
        /// <summary>
        /// Returns the number of Fields (4 x 4 = 16).
        /// </summary>
        public int Count => 16;
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public double this[int fieldIndex]
        {
            [Inline]get
            {
               System.Diagnostics.Debug.Assert(fieldIndex >= 0 && fieldIndex < 16, "fieldIndex was out of range");
               unchecked { return values[fieldIndex]; }
            }
            [Inline]set mut
            {
               System.Diagnostics.Debug.Assert(fieldIndex >= 0 && fieldIndex < 16, "fieldIndex was out of range");
               unchecked { values[fieldIndex] = value; }
            }
        }
        
        /// <summary>
        /// Gets/Sets a specific 2D-indexed component (a bit slower than direct access).
        /// </summary>
        public double this[int col, int row]
        {
            [Inline]get
            {
                System.Diagnostics.Debug.Assert(col >= 0 && col < 4, "col was out of range");
                System.Diagnostics.Debug.Assert(row >= 0 && row < 4, "row was out of range");
                unchecked { return values[col * 4 + row]; }
            }
            [Inline]set mut
            {
                System.Diagnostics.Debug.Assert(col >= 0 && col < 4, "col was out of range");
                System.Diagnostics.Debug.Assert(row >= 0 && row < 4, "row was out of range");
                unchecked { values[col * 4 + row] = value; }
            }
        }
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public bool Equals(double4x4 rhs) => ((((m00 == rhs.m00 && m01 == rhs.m01) && (m02 == rhs.m02 && m03 == rhs.m03)) && ((m10 == rhs.m10 && m11 == rhs.m11) && (m12 == rhs.m12 && m13 == rhs.m13))) && (((m20 == rhs.m20 && m21 == rhs.m21) && (m22 == rhs.m22 && m23 == rhs.m23)) && ((m30 == rhs.m30 && m31 == rhs.m31) && (m32 == rhs.m32 && m33 == rhs.m33))));
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(double4x4 lhs, double4x4 rhs) => lhs.Equals(rhs);
        
        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(double4x4 lhs, double4x4 rhs) => !lhs.Equals(rhs);
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public int GetHashCode()
        {
            unchecked
            {
                return ((((((((((((((((((((((((((((((m00.GetHashCode()) * 397) ^ m01.GetHashCode()) * 397) ^ m02.GetHashCode()) * 397) ^ m03.GetHashCode()) * 397) ^ m10.GetHashCode()) * 397) ^ m11.GetHashCode()) * 397) ^ m12.GetHashCode()) * 397) ^ m13.GetHashCode()) * 397) ^ m20.GetHashCode()) * 397) ^ m21.GetHashCode()) * 397) ^ m22.GetHashCode()) * 397) ^ m23.GetHashCode()) * 397) ^ m30.GetHashCode()) * 397) ^ m31.GetHashCode()) * 397) ^ m32.GetHashCode()) * 397) ^ m33.GetHashCode();
            }
        }
        
        /// <summary>
        /// Returns a transposed version of this matrix.
        /// </summary>
        public double4x4 Transposed => double4x4(m00, m10, m20, m30, m01, m11, m21, m31, m02, m12, m22, m32, m03, m13, m23, m33);
        
        /// <summary>
        /// Returns the minimal component of this matrix.
        /// </summary>
        public double MinElement => System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(m00, m01), m02), m03), m10), m11), m12), m13), m20), m21), m22), m23), m30), m31), m32), m33);
        
        /// <summary>
        /// Returns the maximal component of this matrix.
        /// </summary>
        public double MaxElement => System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(m00, m01), m02), m03), m10), m11), m12), m13), m20), m21), m22), m23), m30), m31), m32), m33);
        
        /// <summary>
        /// Returns the euclidean length of this matrix.
        /// </summary>
        public double Length => (double)System.Math.Sqrt(((((m00*m00 + m01*m01) + (m02*m02 + m03*m03)) + ((m10*m10 + m11*m11) + (m12*m12 + m13*m13))) + (((m20*m20 + m21*m21) + (m22*m22 + m23*m23)) + ((m30*m30 + m31*m31) + (m32*m32 + m33*m33)))));
        
        /// <summary>
        /// Returns the squared euclidean length of this matrix.
        /// </summary>
        public double LengthSqr => ((((m00*m00 + m01*m01) + (m02*m02 + m03*m03)) + ((m10*m10 + m11*m11) + (m12*m12 + m13*m13))) + (((m20*m20 + m21*m21) + (m22*m22 + m23*m23)) + ((m30*m30 + m31*m31) + (m32*m32 + m33*m33))));
        
        /// <summary>
        /// Returns the sum of all fields.
        /// </summary>
        public double Sum => ((((m00 + m01) + (m02 + m03)) + ((m10 + m11) + (m12 + m13))) + (((m20 + m21) + (m22 + m23)) + ((m30 + m31) + (m32 + m33))));
        
        /// <summary>
        /// Returns the euclidean norm of this matrix.
        /// </summary>
        public double Norm => (double)System.Math.Sqrt(((((m00*m00 + m01*m01) + (m02*m02 + m03*m03)) + ((m10*m10 + m11*m11) + (m12*m12 + m13*m13))) + (((m20*m20 + m21*m21) + (m22*m22 + m23*m23)) + ((m30*m30 + m31*m31) + (m32*m32 + m33*m33)))));
        
        /// <summary>
        /// Returns the one-norm of this matrix.
        /// </summary>
        public double Norm1 => ((((System.Math.Abs(m00) + System.Math.Abs(m01)) + (System.Math.Abs(m02) + System.Math.Abs(m03))) + ((System.Math.Abs(m10) + System.Math.Abs(m11)) + (System.Math.Abs(m12) + System.Math.Abs(m13)))) + (((System.Math.Abs(m20) + System.Math.Abs(m21)) + (System.Math.Abs(m22) + System.Math.Abs(m23))) + ((System.Math.Abs(m30) + System.Math.Abs(m31)) + (System.Math.Abs(m32) + System.Math.Abs(m33)))));
        
        /// <summary>
        /// Returns the two-norm of this matrix.
        /// </summary>
        public double Norm2 => (double)System.Math.Sqrt(((((m00*m00 + m01*m01) + (m02*m02 + m03*m03)) + ((m10*m10 + m11*m11) + (m12*m12 + m13*m13))) + (((m20*m20 + m21*m21) + (m22*m22 + m23*m23)) + ((m30*m30 + m31*m31) + (m32*m32 + m33*m33)))));
        
        /// <summary>
        /// Returns the max-norm of this matrix.
        /// </summary>
        public double NormMax => System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Abs(m00), System.Math.Abs(m01)), System.Math.Abs(m02)), System.Math.Abs(m03)), System.Math.Abs(m10)), System.Math.Abs(m11)), System.Math.Abs(m12)), System.Math.Abs(m13)), System.Math.Abs(m20)), System.Math.Abs(m21)), System.Math.Abs(m22)), System.Math.Abs(m23)), System.Math.Abs(m30)), System.Math.Abs(m31)), System.Math.Abs(m32)), System.Math.Abs(m33));
        
        /// <summary>
        /// Returns the p-norm of this matrix.
        /// </summary>
        public double NormP(double p) => System.Math.Pow(((((System.Math.Pow((double)System.Math.Abs(m00), p) + System.Math.Pow((double)System.Math.Abs(m01), p)) + (System.Math.Pow((double)System.Math.Abs(m02), p) + System.Math.Pow((double)System.Math.Abs(m03), p))) + ((System.Math.Pow((double)System.Math.Abs(m10), p) + System.Math.Pow((double)System.Math.Abs(m11), p)) + (System.Math.Pow((double)System.Math.Abs(m12), p) + System.Math.Pow((double)System.Math.Abs(m13), p)))) + (((System.Math.Pow((double)System.Math.Abs(m20), p) + System.Math.Pow((double)System.Math.Abs(m21), p)) + (System.Math.Pow((double)System.Math.Abs(m22), p) + System.Math.Pow((double)System.Math.Abs(m23), p))) + ((System.Math.Pow((double)System.Math.Abs(m30), p) + System.Math.Pow((double)System.Math.Abs(m31), p)) + (System.Math.Pow((double)System.Math.Abs(m32), p) + System.Math.Pow((double)System.Math.Abs(m33), p))))), 1 / p);
        
        /// <summary>
        /// Returns determinant of this matrix.
        /// </summary>
        public double Determinant => m00 * (m11 * (m22 * m33 - m32 * m23) - m21 * (m12 * m33 - m32 * m13) + m31 * (m12 * m23 - m22 * m13)) - m10 * (m01 * (m22 * m33 - m32 * m23) - m21 * (m02 * m33 - m32 * m03) + m31 * (m02 * m23 - m22 * m03)) + m20 * (m01 * (m12 * m33 - m32 * m13) - m11 * (m02 * m33 - m32 * m03) + m31 * (m02 * m13 - m12 * m03)) - m30 * (m01 * (m12 * m23 - m22 * m13) - m11 * (m02 * m23 - m22 * m03) + m21 * (m02 * m13 - m12 * m03));
        
        /// <summary>
        /// Returns the adjunct of this matrix.
        /// </summary>
        public double4x4 Adjugate => double4x4(m11 * (m22 * m33 - m32 * m23) - m21 * (m12 * m33 - m32 * m13) + m31 * (m12 * m23 - m22 * m13), -m01 * (m22 * m33 - m32 * m23) + m21 * (m02 * m33 - m32 * m03) - m31 * (m02 * m23 - m22 * m03), m01 * (m12 * m33 - m32 * m13) - m11 * (m02 * m33 - m32 * m03) + m31 * (m02 * m13 - m12 * m03), -m01 * (m12 * m23 - m22 * m13) + m11 * (m02 * m23 - m22 * m03) - m21 * (m02 * m13 - m12 * m03), -m10 * (m22 * m33 - m32 * m23) + m20 * (m12 * m33 - m32 * m13) - m30 * (m12 * m23 - m22 * m13), m00 * (m22 * m33 - m32 * m23) - m20 * (m02 * m33 - m32 * m03) + m30 * (m02 * m23 - m22 * m03), -m00 * (m12 * m33 - m32 * m13) + m10 * (m02 * m33 - m32 * m03) - m30 * (m02 * m13 - m12 * m03), m00 * (m12 * m23 - m22 * m13) - m10 * (m02 * m23 - m22 * m03) + m20 * (m02 * m13 - m12 * m03), m10 * (m21 * m33 - m31 * m23) - m20 * (m11 * m33 - m31 * m13) + m30 * (m11 * m23 - m21 * m13), -m00 * (m21 * m33 - m31 * m23) + m20 * (m01 * m33 - m31 * m03) - m30 * (m01 * m23 - m21 * m03), m00 * (m11 * m33 - m31 * m13) - m10 * (m01 * m33 - m31 * m03) + m30 * (m01 * m13 - m11 * m03), -m00 * (m11 * m23 - m21 * m13) + m10 * (m01 * m23 - m21 * m03) - m20 * (m01 * m13 - m11 * m03), -m10 * (m21 * m32 - m31 * m22) + m20 * (m11 * m32 - m31 * m12) - m30 * (m11 * m22 - m21 * m12), m00 * (m21 * m32 - m31 * m22) - m20 * (m01 * m32 - m31 * m02) + m30 * (m01 * m22 - m21 * m02), -m00 * (m11 * m32 - m31 * m12) + m10 * (m01 * m32 - m31 * m02) - m30 * (m01 * m12 - m11 * m02), m00 * (m11 * m22 - m21 * m12) - m10 * (m01 * m22 - m21 * m02) + m20 * (m01 * m12 - m11 * m02));
        
        /// <summary>
        /// Returns the inverse of this matrix (use with caution).
        /// </summary>
        public double4x4 Inverse => Adjugate / Determinant;
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication double4x4 * double2x4 -> double2x4.
        /// </summary>
        public static double2x4 operator*(double4x4 lhs, double2x4 rhs) => double2x4(((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01) + (lhs.m20 * rhs.m02 + lhs.m30 * rhs.m03)), ((lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01) + (lhs.m21 * rhs.m02 + lhs.m31 * rhs.m03)), ((lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01) + (lhs.m22 * rhs.m02 + lhs.m32 * rhs.m03)), ((lhs.m03 * rhs.m00 + lhs.m13 * rhs.m01) + (lhs.m23 * rhs.m02 + lhs.m33 * rhs.m03)), ((lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11) + (lhs.m20 * rhs.m12 + lhs.m30 * rhs.m13)), ((lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11) + (lhs.m21 * rhs.m12 + lhs.m31 * rhs.m13)), ((lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11) + (lhs.m22 * rhs.m12 + lhs.m32 * rhs.m13)), ((lhs.m03 * rhs.m10 + lhs.m13 * rhs.m11) + (lhs.m23 * rhs.m12 + lhs.m33 * rhs.m13)));
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication double4x4 * double3x4 -> double3x4.
        /// </summary>
        public static double3x4 operator*(double4x4 lhs, double3x4 rhs) => double3x4(((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01) + (lhs.m20 * rhs.m02 + lhs.m30 * rhs.m03)), ((lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01) + (lhs.m21 * rhs.m02 + lhs.m31 * rhs.m03)), ((lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01) + (lhs.m22 * rhs.m02 + lhs.m32 * rhs.m03)), ((lhs.m03 * rhs.m00 + lhs.m13 * rhs.m01) + (lhs.m23 * rhs.m02 + lhs.m33 * rhs.m03)), ((lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11) + (lhs.m20 * rhs.m12 + lhs.m30 * rhs.m13)), ((lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11) + (lhs.m21 * rhs.m12 + lhs.m31 * rhs.m13)), ((lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11) + (lhs.m22 * rhs.m12 + lhs.m32 * rhs.m13)), ((lhs.m03 * rhs.m10 + lhs.m13 * rhs.m11) + (lhs.m23 * rhs.m12 + lhs.m33 * rhs.m13)), ((lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21) + (lhs.m20 * rhs.m22 + lhs.m30 * rhs.m23)), ((lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21) + (lhs.m21 * rhs.m22 + lhs.m31 * rhs.m23)), ((lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21) + (lhs.m22 * rhs.m22 + lhs.m32 * rhs.m23)), ((lhs.m03 * rhs.m20 + lhs.m13 * rhs.m21) + (lhs.m23 * rhs.m22 + lhs.m33 * rhs.m23)));
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication double4x4 * double4x4 -> double4x4.
        /// </summary>
        public static double4x4 operator*(double4x4 lhs, double4x4 rhs) => double4x4(((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01) + (lhs.m20 * rhs.m02 + lhs.m30 * rhs.m03)), ((lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01) + (lhs.m21 * rhs.m02 + lhs.m31 * rhs.m03)), ((lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01) + (lhs.m22 * rhs.m02 + lhs.m32 * rhs.m03)), ((lhs.m03 * rhs.m00 + lhs.m13 * rhs.m01) + (lhs.m23 * rhs.m02 + lhs.m33 * rhs.m03)), ((lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11) + (lhs.m20 * rhs.m12 + lhs.m30 * rhs.m13)), ((lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11) + (lhs.m21 * rhs.m12 + lhs.m31 * rhs.m13)), ((lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11) + (lhs.m22 * rhs.m12 + lhs.m32 * rhs.m13)), ((lhs.m03 * rhs.m10 + lhs.m13 * rhs.m11) + (lhs.m23 * rhs.m12 + lhs.m33 * rhs.m13)), ((lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21) + (lhs.m20 * rhs.m22 + lhs.m30 * rhs.m23)), ((lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21) + (lhs.m21 * rhs.m22 + lhs.m31 * rhs.m23)), ((lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21) + (lhs.m22 * rhs.m22 + lhs.m32 * rhs.m23)), ((lhs.m03 * rhs.m20 + lhs.m13 * rhs.m21) + (lhs.m23 * rhs.m22 + lhs.m33 * rhs.m23)), ((lhs.m00 * rhs.m30 + lhs.m10 * rhs.m31) + (lhs.m20 * rhs.m32 + lhs.m30 * rhs.m33)), ((lhs.m01 * rhs.m30 + lhs.m11 * rhs.m31) + (lhs.m21 * rhs.m32 + lhs.m31 * rhs.m33)), ((lhs.m02 * rhs.m30 + lhs.m12 * rhs.m31) + (lhs.m22 * rhs.m32 + lhs.m32 * rhs.m33)), ((lhs.m03 * rhs.m30 + lhs.m13 * rhs.m31) + (lhs.m23 * rhs.m32 + lhs.m33 * rhs.m33)));
        
        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static double2 operator*(double4x4 m, double2 v) => double2(((m.m00 * v.x + m.m10 * v.y) + m.m30), ((m.m01 * v.x + m.m11 * v.y) + m.m31));
        
        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static double3 operator*(double4x4 m, double3 v) => double3(((m.m00 * v.x + m.m10 * v.y) + (m.m20 * v.z + m.m30)), ((m.m01 * v.x + m.m11 * v.y) + (m.m21 * v.z + m.m31)), ((m.m02 * v.x + m.m12 * v.y) + (m.m22 * v.z + m.m32)));
        
        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static double4 operator*(double4x4 m, double4 v) => double4(((m.m00 * v.x + m.m10 * v.y) + (m.m20 * v.z + m.m30 * v.w)), ((m.m01 * v.x + m.m11 * v.y) + (m.m21 * v.z + m.m31 * v.w)), ((m.m02 * v.x + m.m12 * v.y) + (m.m22 * v.z + m.m32 * v.w)), ((m.m03 * v.x + m.m13 * v.y) + (m.m23 * v.z + m.m33 * v.w)));
        
        /// <summary>
        /// Executes a matrix-matrix-divison A / B == A * B^-1 (use with caution).
        /// </summary>
        public static double4x4 operator/(double4x4 A, double4x4 B) => A * B.Inverse;
        
        /// <summary>
        /// Executes a component-wise * (multiply).
        /// </summary>
        public static double4x4 CompMul(double4x4 A, double4x4 B) => double4x4(A.m00 * B.m00, A.m01 * B.m01, A.m02 * B.m02, A.m03 * B.m03, A.m10 * B.m10, A.m11 * B.m11, A.m12 * B.m12, A.m13 * B.m13, A.m20 * B.m20, A.m21 * B.m21, A.m22 * B.m22, A.m23 * B.m23, A.m30 * B.m30, A.m31 * B.m31, A.m32 * B.m32, A.m33 * B.m33);
        
        /// <summary>
        /// Executes a component-wise / (divide).
        /// </summary>
        public static double4x4 CompDiv(double4x4 A, double4x4 B) => double4x4(A.m00 / B.m00, A.m01 / B.m01, A.m02 / B.m02, A.m03 / B.m03, A.m10 / B.m10, A.m11 / B.m11, A.m12 / B.m12, A.m13 / B.m13, A.m20 / B.m20, A.m21 / B.m21, A.m22 / B.m22, A.m23 / B.m23, A.m30 / B.m30, A.m31 / B.m31, A.m32 / B.m32, A.m33 / B.m33);
        
        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static double4x4 CompAdd(double4x4 A, double4x4 B) => double4x4(A.m00 + B.m00, A.m01 + B.m01, A.m02 + B.m02, A.m03 + B.m03, A.m10 + B.m10, A.m11 + B.m11, A.m12 + B.m12, A.m13 + B.m13, A.m20 + B.m20, A.m21 + B.m21, A.m22 + B.m22, A.m23 + B.m23, A.m30 + B.m30, A.m31 + B.m31, A.m32 + B.m32, A.m33 + B.m33);
        
        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static double4x4 CompSub(double4x4 A, double4x4 B) => double4x4(A.m00 - B.m00, A.m01 - B.m01, A.m02 - B.m02, A.m03 - B.m03, A.m10 - B.m10, A.m11 - B.m11, A.m12 - B.m12, A.m13 - B.m13, A.m20 - B.m20, A.m21 - B.m21, A.m22 - B.m22, A.m23 - B.m23, A.m30 - B.m30, A.m31 - B.m31, A.m32 - B.m32, A.m33 - B.m33);
        
        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static double4x4 operator+(double4x4 lhs, double4x4 rhs) => double4x4(lhs.m00 + rhs.m00, lhs.m01 + rhs.m01, lhs.m02 + rhs.m02, lhs.m03 + rhs.m03, lhs.m10 + rhs.m10, lhs.m11 + rhs.m11, lhs.m12 + rhs.m12, lhs.m13 + rhs.m13, lhs.m20 + rhs.m20, lhs.m21 + rhs.m21, lhs.m22 + rhs.m22, lhs.m23 + rhs.m23, lhs.m30 + rhs.m30, lhs.m31 + rhs.m31, lhs.m32 + rhs.m32, lhs.m33 + rhs.m33);
        
        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static double4x4 operator+(double4x4 lhs, double rhs) => double4x4(lhs.m00 + rhs, lhs.m01 + rhs, lhs.m02 + rhs, lhs.m03 + rhs, lhs.m10 + rhs, lhs.m11 + rhs, lhs.m12 + rhs, lhs.m13 + rhs, lhs.m20 + rhs, lhs.m21 + rhs, lhs.m22 + rhs, lhs.m23 + rhs, lhs.m30 + rhs, lhs.m31 + rhs, lhs.m32 + rhs, lhs.m33 + rhs);
        
        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static double4x4 operator+(double lhs, double4x4 rhs) => double4x4(lhs + rhs.m00, lhs + rhs.m01, lhs + rhs.m02, lhs + rhs.m03, lhs + rhs.m10, lhs + rhs.m11, lhs + rhs.m12, lhs + rhs.m13, lhs + rhs.m20, lhs + rhs.m21, lhs + rhs.m22, lhs + rhs.m23, lhs + rhs.m30, lhs + rhs.m31, lhs + rhs.m32, lhs + rhs.m33);
        
        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static double4x4 operator-(double4x4 lhs, double4x4 rhs) => double4x4(lhs.m00 - rhs.m00, lhs.m01 - rhs.m01, lhs.m02 - rhs.m02, lhs.m03 - rhs.m03, lhs.m10 - rhs.m10, lhs.m11 - rhs.m11, lhs.m12 - rhs.m12, lhs.m13 - rhs.m13, lhs.m20 - rhs.m20, lhs.m21 - rhs.m21, lhs.m22 - rhs.m22, lhs.m23 - rhs.m23, lhs.m30 - rhs.m30, lhs.m31 - rhs.m31, lhs.m32 - rhs.m32, lhs.m33 - rhs.m33);
        
        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static double4x4 operator-(double4x4 lhs, double rhs) => double4x4(lhs.m00 - rhs, lhs.m01 - rhs, lhs.m02 - rhs, lhs.m03 - rhs, lhs.m10 - rhs, lhs.m11 - rhs, lhs.m12 - rhs, lhs.m13 - rhs, lhs.m20 - rhs, lhs.m21 - rhs, lhs.m22 - rhs, lhs.m23 - rhs, lhs.m30 - rhs, lhs.m31 - rhs, lhs.m32 - rhs, lhs.m33 - rhs);
        
        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static double4x4 operator-(double lhs, double4x4 rhs) => double4x4(lhs - rhs.m00, lhs - rhs.m01, lhs - rhs.m02, lhs - rhs.m03, lhs - rhs.m10, lhs - rhs.m11, lhs - rhs.m12, lhs - rhs.m13, lhs - rhs.m20, lhs - rhs.m21, lhs - rhs.m22, lhs - rhs.m23, lhs - rhs.m30, lhs - rhs.m31, lhs - rhs.m32, lhs - rhs.m33);
        
        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static double4x4 operator/(double4x4 lhs, double rhs) => double4x4(lhs.m00 / rhs, lhs.m01 / rhs, lhs.m02 / rhs, lhs.m03 / rhs, lhs.m10 / rhs, lhs.m11 / rhs, lhs.m12 / rhs, lhs.m13 / rhs, lhs.m20 / rhs, lhs.m21 / rhs, lhs.m22 / rhs, lhs.m23 / rhs, lhs.m30 / rhs, lhs.m31 / rhs, lhs.m32 / rhs, lhs.m33 / rhs);
        
        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static double4x4 operator/(double lhs, double4x4 rhs) => double4x4(lhs / rhs.m00, lhs / rhs.m01, lhs / rhs.m02, lhs / rhs.m03, lhs / rhs.m10, lhs / rhs.m11, lhs / rhs.m12, lhs / rhs.m13, lhs / rhs.m20, lhs / rhs.m21, lhs / rhs.m22, lhs / rhs.m23, lhs / rhs.m30, lhs / rhs.m31, lhs / rhs.m32, lhs / rhs.m33);
        
        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static double4x4 operator*(double4x4 lhs, double rhs) => double4x4(lhs.m00 * rhs, lhs.m01 * rhs, lhs.m02 * rhs, lhs.m03 * rhs, lhs.m10 * rhs, lhs.m11 * rhs, lhs.m12 * rhs, lhs.m13 * rhs, lhs.m20 * rhs, lhs.m21 * rhs, lhs.m22 * rhs, lhs.m23 * rhs, lhs.m30 * rhs, lhs.m31 * rhs, lhs.m32 * rhs, lhs.m33 * rhs);
        
        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static double4x4 operator*(double lhs, double4x4 rhs) => double4x4(lhs * rhs.m00, lhs * rhs.m01, lhs * rhs.m02, lhs * rhs.m03, lhs * rhs.m10, lhs * rhs.m11, lhs * rhs.m12, lhs * rhs.m13, lhs * rhs.m20, lhs * rhs.m21, lhs * rhs.m22, lhs * rhs.m23, lhs * rhs.m30, lhs * rhs.m31, lhs * rhs.m32, lhs * rhs.m33);
        
        /// <summary>
        /// Executes a component-wise lesser-than comparison.
        /// </summary>
        public static bool4x4 operator<(double4x4 lhs, double4x4 rhs) => bool4x4(lhs.m00 < rhs.m00, lhs.m01 < rhs.m01, lhs.m02 < rhs.m02, lhs.m03 < rhs.m03, lhs.m10 < rhs.m10, lhs.m11 < rhs.m11, lhs.m12 < rhs.m12, lhs.m13 < rhs.m13, lhs.m20 < rhs.m20, lhs.m21 < rhs.m21, lhs.m22 < rhs.m22, lhs.m23 < rhs.m23, lhs.m30 < rhs.m30, lhs.m31 < rhs.m31, lhs.m32 < rhs.m32, lhs.m33 < rhs.m33);
        
        /// <summary>
        /// Executes a component-wise lesser-than comparison with a scalar.
        /// </summary>
        public static bool4x4 operator<(double4x4 lhs, double rhs) => bool4x4(lhs.m00 < rhs, lhs.m01 < rhs, lhs.m02 < rhs, lhs.m03 < rhs, lhs.m10 < rhs, lhs.m11 < rhs, lhs.m12 < rhs, lhs.m13 < rhs, lhs.m20 < rhs, lhs.m21 < rhs, lhs.m22 < rhs, lhs.m23 < rhs, lhs.m30 < rhs, lhs.m31 < rhs, lhs.m32 < rhs, lhs.m33 < rhs);
        
        /// <summary>
        /// Executes a component-wise lesser-than comparison with a scalar.
        /// </summary>
        public static bool4x4 operator<(double lhs, double4x4 rhs) => bool4x4(lhs < rhs.m00, lhs < rhs.m01, lhs < rhs.m02, lhs < rhs.m03, lhs < rhs.m10, lhs < rhs.m11, lhs < rhs.m12, lhs < rhs.m13, lhs < rhs.m20, lhs < rhs.m21, lhs < rhs.m22, lhs < rhs.m23, lhs < rhs.m30, lhs < rhs.m31, lhs < rhs.m32, lhs < rhs.m33);
        
        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison.
        /// </summary>
        public static bool4x4 operator<=(double4x4 lhs, double4x4 rhs) => bool4x4(lhs.m00 <= rhs.m00, lhs.m01 <= rhs.m01, lhs.m02 <= rhs.m02, lhs.m03 <= rhs.m03, lhs.m10 <= rhs.m10, lhs.m11 <= rhs.m11, lhs.m12 <= rhs.m12, lhs.m13 <= rhs.m13, lhs.m20 <= rhs.m20, lhs.m21 <= rhs.m21, lhs.m22 <= rhs.m22, lhs.m23 <= rhs.m23, lhs.m30 <= rhs.m30, lhs.m31 <= rhs.m31, lhs.m32 <= rhs.m32, lhs.m33 <= rhs.m33);
        
        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison with a scalar.
        /// </summary>
        public static bool4x4 operator<=(double4x4 lhs, double rhs) => bool4x4(lhs.m00 <= rhs, lhs.m01 <= rhs, lhs.m02 <= rhs, lhs.m03 <= rhs, lhs.m10 <= rhs, lhs.m11 <= rhs, lhs.m12 <= rhs, lhs.m13 <= rhs, lhs.m20 <= rhs, lhs.m21 <= rhs, lhs.m22 <= rhs, lhs.m23 <= rhs, lhs.m30 <= rhs, lhs.m31 <= rhs, lhs.m32 <= rhs, lhs.m33 <= rhs);
        
        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison with a scalar.
        /// </summary>
        public static bool4x4 operator<=(double lhs, double4x4 rhs) => bool4x4(lhs <= rhs.m00, lhs <= rhs.m01, lhs <= rhs.m02, lhs <= rhs.m03, lhs <= rhs.m10, lhs <= rhs.m11, lhs <= rhs.m12, lhs <= rhs.m13, lhs <= rhs.m20, lhs <= rhs.m21, lhs <= rhs.m22, lhs <= rhs.m23, lhs <= rhs.m30, lhs <= rhs.m31, lhs <= rhs.m32, lhs <= rhs.m33);
        
        /// <summary>
        /// Executes a component-wise greater-than comparison.
        /// </summary>
        public static bool4x4 operator>(double4x4 lhs, double4x4 rhs) => bool4x4(lhs.m00 > rhs.m00, lhs.m01 > rhs.m01, lhs.m02 > rhs.m02, lhs.m03 > rhs.m03, lhs.m10 > rhs.m10, lhs.m11 > rhs.m11, lhs.m12 > rhs.m12, lhs.m13 > rhs.m13, lhs.m20 > rhs.m20, lhs.m21 > rhs.m21, lhs.m22 > rhs.m22, lhs.m23 > rhs.m23, lhs.m30 > rhs.m30, lhs.m31 > rhs.m31, lhs.m32 > rhs.m32, lhs.m33 > rhs.m33);
        
        /// <summary>
        /// Executes a component-wise greater-than comparison with a scalar.
        /// </summary>
        public static bool4x4 operator>(double4x4 lhs, double rhs) => bool4x4(lhs.m00 > rhs, lhs.m01 > rhs, lhs.m02 > rhs, lhs.m03 > rhs, lhs.m10 > rhs, lhs.m11 > rhs, lhs.m12 > rhs, lhs.m13 > rhs, lhs.m20 > rhs, lhs.m21 > rhs, lhs.m22 > rhs, lhs.m23 > rhs, lhs.m30 > rhs, lhs.m31 > rhs, lhs.m32 > rhs, lhs.m33 > rhs);
        
        /// <summary>
        /// Executes a component-wise greater-than comparison with a scalar.
        /// </summary>
        public static bool4x4 operator>(double lhs, double4x4 rhs) => bool4x4(lhs > rhs.m00, lhs > rhs.m01, lhs > rhs.m02, lhs > rhs.m03, lhs > rhs.m10, lhs > rhs.m11, lhs > rhs.m12, lhs > rhs.m13, lhs > rhs.m20, lhs > rhs.m21, lhs > rhs.m22, lhs > rhs.m23, lhs > rhs.m30, lhs > rhs.m31, lhs > rhs.m32, lhs > rhs.m33);
        
        /// <summary>
        /// Executes a component-wise greater-or-equal comparison.
        /// </summary>
        public static bool4x4 operator>=(double4x4 lhs, double4x4 rhs) => bool4x4(lhs.m00 >= rhs.m00, lhs.m01 >= rhs.m01, lhs.m02 >= rhs.m02, lhs.m03 >= rhs.m03, lhs.m10 >= rhs.m10, lhs.m11 >= rhs.m11, lhs.m12 >= rhs.m12, lhs.m13 >= rhs.m13, lhs.m20 >= rhs.m20, lhs.m21 >= rhs.m21, lhs.m22 >= rhs.m22, lhs.m23 >= rhs.m23, lhs.m30 >= rhs.m30, lhs.m31 >= rhs.m31, lhs.m32 >= rhs.m32, lhs.m33 >= rhs.m33);
        
        /// <summary>
        /// Executes a component-wise greater-or-equal comparison with a scalar.
        /// </summary>
        public static bool4x4 operator>=(double4x4 lhs, double rhs) => bool4x4(lhs.m00 >= rhs, lhs.m01 >= rhs, lhs.m02 >= rhs, lhs.m03 >= rhs, lhs.m10 >= rhs, lhs.m11 >= rhs, lhs.m12 >= rhs, lhs.m13 >= rhs, lhs.m20 >= rhs, lhs.m21 >= rhs, lhs.m22 >= rhs, lhs.m23 >= rhs, lhs.m30 >= rhs, lhs.m31 >= rhs, lhs.m32 >= rhs, lhs.m33 >= rhs);
        
        /// <summary>
        /// Executes a component-wise greater-or-equal comparison with a scalar.
        /// </summary>
        public static bool4x4 operator>=(double lhs, double4x4 rhs) => bool4x4(lhs >= rhs.m00, lhs >= rhs.m01, lhs >= rhs.m02, lhs >= rhs.m03, lhs >= rhs.m10, lhs >= rhs.m11, lhs >= rhs.m12, lhs >= rhs.m13, lhs >= rhs.m20, lhs >= rhs.m21, lhs >= rhs.m22, lhs >= rhs.m23, lhs >= rhs.m30, lhs >= rhs.m31, lhs >= rhs.m32, lhs >= rhs.m33);
        
        /// <summary>
        /// Creates a frustrum projection matrix.
        /// </summary>
        public static double4x4 Frustum(double left, double right, double bottom, double top, double nearVal, double farVal)
        {
            var m = Identity;
            m.m00 = (2 * nearVal) / (right - left);
            m.m11 = (2 * nearVal) / (top - bottom);
            m.m20 = (right + left) / (right - left);
            m.m21 = (top + bottom) / (top - bottom);
            m.m22 = -(farVal + nearVal) / (farVal - nearVal);
            m.m23 = -1;
            m.m32 = -(2 * farVal * nearVal) / (farVal - nearVal);
            return m;
        }
        
        /// <summary>
        /// Creates a matrix for a symmetric perspective-view frustum with far plane at infinite.
        /// </summary>
        public static double4x4 InfinitePerspective(double fovy, double aspect, double zNear)
        {
            var range = System.Math.Tan((double)fovy / 2.0) * (double)zNear;
            var l = -range * (double)aspect;
            var r = range * (double)aspect;
            var b = -range;
            var t = range;
            var m = Identity;
            m.m00 = (double)( ((2.0)*(double)zNear)/(r - l) );
            m.m11 = (double)( ((2.0)*(double)zNear)/(t - b) );
            m.m22 = (double)( - (1.0) );
            m.m23 = (double)( - (1.0) );
            m.m32 = (double)( - (2.0)*(double)zNear );
            return m;
        }
        
        /// <summary>
        /// Build a look at view matrix.
        /// </summary>
        public static double4x4 LookAt(double3 eye, double3 center, double3 up)
        {
            var f = (center - eye).Normalized;
            var s = double3.Cross(f, up).Normalized;
            var u = double3.Cross(s, f);
            var m = Identity;
            m.m00 = s.x;
            m.m10 = s.y;
            m.m20 = s.z;
            m.m01 = u.x;
            m.m11 = u.y;
            m.m21 = u.z;
            m.m02 = -f.x;
            m.m12 = -f.y;
            m.m22 = -f.z;
            m.m30 = -double3.Dot(s, eye);
            m.m31 = -double3.Dot(u, eye);
            m.m32 = double3.Dot(f, eye);
            return m;
        }
        
        /// <summary>
        /// Creates a matrix for an orthographic parallel viewing volume.
        /// </summary>
        public static double4x4 Ortho(double left, double right, double bottom, double top, double zNear, double zFar)
        {
            var m = Identity;
            m.m00 = 2/(right - left);
            m.m11 = 2/(top - bottom);
            m.m22 = - 2/(zFar - zNear);
            m.m30 = - (right + left)/(right - left);
            m.m31 = - (top + bottom)/(top - bottom);
            m.m32 = - (zFar + zNear)/(zFar - zNear);
            return m;
        }
        
        /// <summary>
        /// Creates a matrix for projecting two-dimensional coordinates onto the screen.
        /// </summary>
        public static double4x4 Ortho(double left, double right, double bottom, double top)
        {
            var m = Identity;
            m.m00 = 2/(right - left);
            m.m11 = 2/(top - bottom);
            m.m22 = - 1;
            m.m30 = - (right + left)/(right - left);
            m.m31 = - (top + bottom)/(top - bottom);
            return m;
        }
        
        /// <summary>
        /// Creates a perspective transformation matrix.
        /// </summary>
        public static double4x4 Perspective(double fovy, double aspect, double zNear, double zFar)
        {
            var tanHalfFovy = System.Math.Tan((double)fovy / 2.0);
            var m = Zero;
            m.m00 = (double)( 1 / ((double)aspect * tanHalfFovy) );
            m.m11 = (double)( 1 / (tanHalfFovy) );
            m.m22 = (double)( -(zFar + zNear) / (zFar - zNear) );
            m.m23 = (double)( -1 );
            m.m32 = (double)( -(2 * zFar * zNear) / (zFar - zNear) );
            return m;
        }
        
        /// <summary>
        /// Builds a perspective projection matrix based on a field of view.
        /// </summary>
        public static double4x4 PerspectiveFov(double fov, double width, double height, double zNear, double zFar)
        {
            System.Diagnostics.Debug.Assert(width > 0, "width");
            System.Diagnostics.Debug.Assert(height > 0, "height");
            System.Diagnostics.Debug.Assert(fov > 0, "fov");
            var h = System.Math.Cos((double)fov / 2.0) / System.Math.Sin((double)fov / 2.0);
            var w = h * (double)(height / width);
            var m = Zero;
            m.m00 = (double)w;
            m.m11 = (double)h;
            m.m22 = - (zFar + zNear)/(zFar - zNear);
            m.m23 = - 1;
            m.m32 = - (2*zFar*zNear)/(zFar - zNear);
            return m;
        }
        
        /// <summary>
        /// Map the specified object coordinates (obj.x, obj.y, obj.z) into window coordinates.
        /// </summary>
        public static double3 Project(double3 obj, double4x4 model, double4x4 proj, double4 viewport)
        {
            var tmp = proj * (model *  double4(obj, 1));
            tmp /= tmp.w;
            tmp = tmp * 0.5d + 0.5d;
            tmp.x = tmp.x * viewport.z + viewport.x;
            tmp.y = tmp.y * viewport.w + viewport.y;
            return tmp.xyz;
        }
        
        /// <summary>
        /// Map the specified window coordinates (win.x, win.y, win.z) into object coordinates.
        /// </summary>
        public static double3 UnProject(double3 win, double4x4 model, double4x4 proj, double4 viewport)
        {
            var tmp =  double4(win, 1);
            tmp.x = (tmp.x - viewport.x) / viewport.z;
            tmp.y = (tmp.y - viewport.y) / viewport.w;
            tmp = tmp * 2 - 1;
        
            var unp = proj.Inverse * tmp;
            unp /= unp.w;
            var obj = model.Inverse * unp;
            return (double3)obj / obj.w;
        }
        
        /// <summary>
        /// Map the specified window coordinates (win.x, win.y, win.z) into object coordinates (faster but less precise).
        /// </summary>
        public static double3 UnProjectFaster(double3 win, double4x4 model, double4x4 proj, double4 viewport)
        {
            var tmp =  double4(win, 1);
            tmp.x = (tmp.x - viewport.x) / viewport.z;
            tmp.y = (tmp.y - viewport.y) / viewport.w;
            tmp = tmp * 2 - 1;
        
            var obj = (proj * model).Inverse * tmp;
            return (double3)obj / obj.w;
        }
        
        /// <summary>
        /// Builds a rotation 4 * 4 matrix created from an axis vector and an angle in radians.
        /// </summary>
        public static double4x4 Rotate(double angle, double3 v)
        {
            var c = (double)System.Math.Cos((double)angle);
            var s = (double)System.Math.Sin((double)angle);
        
            var axis = v.Normalized;
            var temp = (1 - c) * axis;
        
            var m = Identity;
            m.m00 = c + temp.x * axis.x;
            m.m01 = 0 + temp.x * axis.y + s * axis.z;
            m.m02 = 0 + temp.x * axis.z - s * axis.y;
        
            m.m10 = 0 + temp.y * axis.x - s * axis.z;
            m.m11 = c + temp.y * axis.y;
            m.m12 = 0 + temp.y * axis.z + s * axis.x;
        
            m.m20 = 0 + temp.z * axis.x + s * axis.y;
            m.m21 = 0 + temp.z * axis.y - s * axis.x;
            m.m22 = c + temp.z * axis.z;
            return m;
        }
        
        /// <summary>
        /// Builds a rotation matrix around UnitX and an angle in radians.
        /// </summary>
        public static double4x4 RotateX(double angle)
        {
            return Rotate(angle, double3.UnitX);
        }
        
        /// <summary>
        /// Builds a rotation matrix around UnitY and an angle in radians.
        /// </summary>
        public static double4x4 RotateY(double angle)
        {
            return Rotate(angle, double3.UnitY);
        }
        
        /// <summary>
        /// Builds a rotation matrix around UnitZ and an angle in radians.
        /// </summary>
        public static double4x4 RotateZ(double angle)
        {
            return Rotate(angle, double3.UnitZ);
        }
        
        /// <summary>
        /// Builds a scale matrix by components x, y, z.
        /// </summary>
        public static double4x4 Scale(double x, double y, double z)
        {
            var m = Identity;
            m.m00 = x;
            m.m11 = y;
            m.m22 = z;
            return m;
        }
        
        /// <summary>
        /// Builds a scale matrix by vector v.
        /// </summary>
        public static double4x4 Scale(double3 v) => Scale(v.x, v.y, v.z);
        
        /// <summary>
        /// Builds a scale matrix by uniform scaling s.
        /// </summary>
        public static double4x4 Scale(double s) => Scale(s, s, s);
        
        /// <summary>
        /// Builds a translation matrix by components x, y, z.
        /// </summary>
        public static double4x4 Translate(double x, double y, double z)
        {
            var m = Identity;
            m.m30 = x;
            m.m31 = y;
            m.m32 = z;
            return m;
        }
        
        /// <summary>
        /// Builds a translation matrix by vector v.
        /// </summary>
        public static double4x4 Translate(double3 v) => Translate(v.x, v.y, v.z);
    }
}
