using System;
namespace Atma
{
    
    /// <summary>
    /// A matrix of type long with 4 columns and 2 rows.
    /// </summary>
    public struct long4x2 : IEquatable<long4x2>
    {

        //#region Fields
        
        /// <summary>
        /// component data
        /// </summary>
        public long[8] values;

        //#endregion


        //#region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public this(long m00, long m01, long m10, long m11, long m20, long m21, long m30, long m31)
        {
            values = .(m00,m01,m10,m11,m20,m21,m30,m31);
        }
        
        /// <summary>
        /// Constructs this matrix from a long2x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(long2x2 m)
        {
            values = .(m.m00,m.m01,m.m10,m.m11,0,0,0,0);
        }
        
        /// <summary>
        /// Constructs this matrix from a long3x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(long3x2 m)
        {
            values = .(m.m00,m.m01,m.m10,m.m11,m.m20,m.m21,0,0);
        }
        
        /// <summary>
        /// Constructs this matrix from a long4x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(long4x2 m)
        {
            values = .(m.m00,m.m01,m.m10,m.m11,m.m20,m.m21,m.m30,m.m31);
        }
        
        /// <summary>
        /// Constructs this matrix from a long2x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(long2x3 m)
        {
            values = .(m.m00,m.m01,m.m10,m.m11,0,0,0,0);
        }
        
        /// <summary>
        /// Constructs this matrix from a long3x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(long3x3 m)
        {
            values = .(m.m00,m.m01,m.m10,m.m11,m.m20,m.m21,0,0);
        }
        
        /// <summary>
        /// Constructs this matrix from a long4x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(long4x3 m)
        {
            values = .(m.m00,m.m01,m.m10,m.m11,m.m20,m.m21,m.m30,m.m31);
        }
        
        /// <summary>
        /// Constructs this matrix from a long2x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(long2x4 m)
        {
            values = .(m.m00,m.m01,m.m10,m.m11,0,0,0,0);
        }
        
        /// <summary>
        /// Constructs this matrix from a long3x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(long3x4 m)
        {
            values = .(m.m00,m.m01,m.m10,m.m11,m.m20,m.m21,0,0);
        }
        
        /// <summary>
        /// Constructs this matrix from a long4x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(long4x4 m)
        {
            values = .(m.m00,m.m01,m.m10,m.m11,m.m20,m.m21,m.m30,m.m31);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(long2 c0, long2 c1)
        {
            values = .(c0.x,c0.y,c1.x,c1.y,0,0,0,0);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(long2 c0, long2 c1, long2 c2)
        {
            values = .(c0.x,c0.y,c1.x,c1.y,c2.x,c2.y,0,0);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(long2 c0, long2 c1, long2 c2, long2 c3)
        {
            values = .(c0.x,c0.y,c1.x,c1.y,c2.x,c2.y,c3.x,c3.y);
        }

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Column 0, Rows 0
        /// </summary>
        public long m00
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
        public long m01
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
        /// Column 1, Rows 0
        /// </summary>
        public long m10
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
        /// Column 1, Rows 1
        /// </summary>
        public long m11
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
        /// Column 2, Rows 0
        /// </summary>
        public long m20
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
        /// Column 2, Rows 1
        /// </summary>
        public long m21
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
        /// Column 3, Rows 0
        /// </summary>
        public long m30
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
        /// Column 3, Rows 1
        /// </summary>
        public long m31
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
        /// Gets or sets the column nr 0
        /// </summary>
        public long2 Column0
        {
            [Inline]get
            {
                return  long2(m00, m01);
            }
            [Inline]set mut
            {
                m00 = value.x;
                m01 = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the column nr 1
        /// </summary>
        public long2 Column1
        {
            [Inline]get
            {
                return  long2(m10, m11);
            }
            [Inline]set mut
            {
                m10 = value.x;
                m11 = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the column nr 2
        /// </summary>
        public long2 Column2
        {
            [Inline]get
            {
                return  long2(m20, m21);
            }
            [Inline]set mut
            {
                m20 = value.x;
                m21 = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the column nr 3
        /// </summary>
        public long2 Column3
        {
            [Inline]get
            {
                return  long2(m30, m31);
            }
            [Inline]set mut
            {
                m30 = value.x;
                m31 = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the row nr 0
        /// </summary>
        public long4 Row0
        {
            [Inline]get
            {
                return  long4(m00, m10, m20, m30);
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
        public long4 Row1
        {
            [Inline]get
            {
                return  long4(m01, m11, m21, m31);
            }
            [Inline]set mut
            {
                m01 = value.x;
                m11 = value.y;
                m21 = value.z;
                m31 = value.w;
            }
        }

        //#endregion


        //#region Static Properties
        
        /// <summary>
        /// Predefined all-zero matrix
        /// </summary>
        readonly public static long4x2 Zero  =  long4x2(0, 0, 0, 0, 0, 0, 0, 0);
        
        /// <summary>
        /// Predefined all-ones matrix
        /// </summary>
        readonly public static long4x2 Ones  =  long4x2(1, 1, 1, 1, 1, 1, 1, 1);
        
        /// <summary>
        /// Predefined identity matrix
        /// </summary>
        readonly public static long4x2 Identity  =  long4x2(1, 0, 0, 1, 0, 0, 0, 0);
        
        /// <summary>
        /// Predefined all-MaxValue matrix
        /// </summary>
        readonly public static long4x2 AllMaxValue  =  long4x2(long.MaxValue, long.MaxValue, long.MaxValue, long.MaxValue, long.MaxValue, long.MaxValue, long.MaxValue, long.MaxValue);
        
        /// <summary>
        /// Predefined diagonal-MaxValue matrix
        /// </summary>
        readonly public static long4x2 DiagonalMaxValue  =  long4x2(long.MaxValue, 0, 0, long.MaxValue, 0, 0, 0, 0);
        
        /// <summary>
        /// Predefined all-MinValue matrix
        /// </summary>
        readonly public static long4x2 AllMinValue  =  long4x2(long.MinValue, long.MinValue, long.MinValue, long.MinValue, long.MinValue, long.MinValue, long.MinValue, long.MinValue);
        
        /// <summary>
        /// Predefined diagonal-MinValue matrix
        /// </summary>
        readonly public static long4x2 DiagonalMinValue  =  long4x2(long.MinValue, 0, 0, long.MinValue, 0, 0, 0, 0);

        //#endregion


        //#region Functions
        
        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public long[,] ToArray() => new .[,] ( ( m00, m01 ), ( m10, m11 ), ( m20, m21 ), ( m30, m31 ) );
        
        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public long[] ToArray1D() => new .[] ( m00, m01, m10, m11, m20, m21, m30, m31 );

        //#endregion

        
        /// <summary>
        /// Returns the number of Fields (4 x 2 = 8).
        /// </summary>
        public int Count => 8;
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public long this[int fieldIndex]
        {
            [Inline]get
            {
               System.Diagnostics.Debug.Assert(fieldIndex >= 0 && fieldIndex < 8, "fieldIndex was out of range");
               unchecked { return values[fieldIndex]; }
            }
            [Inline]set mut
            {
               System.Diagnostics.Debug.Assert(fieldIndex >= 0 && fieldIndex < 8, "fieldIndex was out of range");
               unchecked { values[fieldIndex] = value; }
            }
        }
        
        /// <summary>
        /// Gets/Sets a specific 2D-indexed component (a bit slower than direct access).
        /// </summary>
        public long this[int col, int row]
        {
            [Inline]get
            {
                System.Diagnostics.Debug.Assert(col >= 0 && col < 4, "col was out of range");
                System.Diagnostics.Debug.Assert(row >= 0 && row < 2, "row was out of range");
                unchecked { return values[col * 2 + row]; }
            }
            [Inline]set mut
            {
                System.Diagnostics.Debug.Assert(col >= 0 && col < 4, "col was out of range");
                System.Diagnostics.Debug.Assert(row >= 0 && row < 2, "row was out of range");
                unchecked { values[col * 2 + row] = value; }
            }
        }
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public bool Equals(long4x2 rhs) => (((m00 == rhs.m00 && m01 == rhs.m01) && (m10 == rhs.m10 && m11 == rhs.m11)) && ((m20 == rhs.m20 && m21 == rhs.m21) && (m30 == rhs.m30 && m31 == rhs.m31)));
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(long4x2 lhs, long4x2 rhs) => lhs.Equals(rhs);
        
        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(long4x2 lhs, long4x2 rhs) => !lhs.Equals(rhs);
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public int GetHashCode()
        {
            unchecked
            {
                return ((((((((((((((m00.GetHashCode()) * 397) ^ m01.GetHashCode()) * 397) ^ m10.GetHashCode()) * 397) ^ m11.GetHashCode()) * 397) ^ m20.GetHashCode()) * 397) ^ m21.GetHashCode()) * 397) ^ m30.GetHashCode()) * 397) ^ m31.GetHashCode();
            }
        }
        
        /// <summary>
        /// Returns a transposed version of this matrix.
        /// </summary>
        public long2x4 Transposed => long2x4(m00, m10, m20, m30, m01, m11, m21, m31);
        
        /// <summary>
        /// Returns the minimal component of this matrix.
        /// </summary>
        public long MinElement => System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(m00, m01), m10), m11), m20), m21), m30), m31);
        
        /// <summary>
        /// Returns the maximal component of this matrix.
        /// </summary>
        public long MaxElement => System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(m00, m01), m10), m11), m20), m21), m30), m31);
        
        /// <summary>
        /// Returns the euclidean length of this matrix.
        /// </summary>
        public double Length => (double)System.Math.Sqrt((((m00*m00 + m01*m01) + (m10*m10 + m11*m11)) + ((m20*m20 + m21*m21) + (m30*m30 + m31*m31))));
        
        /// <summary>
        /// Returns the squared euclidean length of this matrix.
        /// </summary>
        public double LengthSqr => (((m00*m00 + m01*m01) + (m10*m10 + m11*m11)) + ((m20*m20 + m21*m21) + (m30*m30 + m31*m31)));
        
        /// <summary>
        /// Returns the sum of all fields.
        /// </summary>
        public long Sum => (((m00 + m01) + (m10 + m11)) + ((m20 + m21) + (m30 + m31)));
        
        /// <summary>
        /// Returns the euclidean norm of this matrix.
        /// </summary>
        public double Norm => (double)System.Math.Sqrt((((m00*m00 + m01*m01) + (m10*m10 + m11*m11)) + ((m20*m20 + m21*m21) + (m30*m30 + m31*m31))));
        
        /// <summary>
        /// Returns the one-norm of this matrix.
        /// </summary>
        public double Norm1 => (((System.Math.Abs(m00) + System.Math.Abs(m01)) + (System.Math.Abs(m10) + System.Math.Abs(m11))) + ((System.Math.Abs(m20) + System.Math.Abs(m21)) + (System.Math.Abs(m30) + System.Math.Abs(m31))));
        
        /// <summary>
        /// Returns the two-norm of this matrix.
        /// </summary>
        public double Norm2 => (double)System.Math.Sqrt((((m00*m00 + m01*m01) + (m10*m10 + m11*m11)) + ((m20*m20 + m21*m21) + (m30*m30 + m31*m31))));
        
        /// <summary>
        /// Returns the max-norm of this matrix.
        /// </summary>
        public long NormMax => System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Abs(m00), System.Math.Abs(m01)), System.Math.Abs(m10)), System.Math.Abs(m11)), System.Math.Abs(m20)), System.Math.Abs(m21)), System.Math.Abs(m30)), System.Math.Abs(m31));
        
        /// <summary>
        /// Returns the p-norm of this matrix.
        /// </summary>
        public double NormP(double p) => System.Math.Pow((((System.Math.Pow((double)System.Math.Abs(m00), p) + System.Math.Pow((double)System.Math.Abs(m01), p)) + (System.Math.Pow((double)System.Math.Abs(m10), p) + System.Math.Pow((double)System.Math.Abs(m11), p))) + ((System.Math.Pow((double)System.Math.Abs(m20), p) + System.Math.Pow((double)System.Math.Abs(m21), p)) + (System.Math.Pow((double)System.Math.Abs(m30), p) + System.Math.Pow((double)System.Math.Abs(m31), p)))), 1 / p);
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication long4x2 * long2x4 -> long2x2.
        /// </summary>
        public static long2x2 operator*(long4x2 lhs, long2x4 rhs) => long2x2(((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01) + (lhs.m20 * rhs.m02 + lhs.m30 * rhs.m03)), ((lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01) + (lhs.m21 * rhs.m02 + lhs.m31 * rhs.m03)), ((lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11) + (lhs.m20 * rhs.m12 + lhs.m30 * rhs.m13)), ((lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11) + (lhs.m21 * rhs.m12 + lhs.m31 * rhs.m13)));
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication long4x2 * long3x4 -> long3x2.
        /// </summary>
        public static long3x2 operator*(long4x2 lhs, long3x4 rhs) => long3x2(((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01) + (lhs.m20 * rhs.m02 + lhs.m30 * rhs.m03)), ((lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01) + (lhs.m21 * rhs.m02 + lhs.m31 * rhs.m03)), ((lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11) + (lhs.m20 * rhs.m12 + lhs.m30 * rhs.m13)), ((lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11) + (lhs.m21 * rhs.m12 + lhs.m31 * rhs.m13)), ((lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21) + (lhs.m20 * rhs.m22 + lhs.m30 * rhs.m23)), ((lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21) + (lhs.m21 * rhs.m22 + lhs.m31 * rhs.m23)));
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication long4x2 * long4x4 -> long4x2.
        /// </summary>
        public static long4x2 operator*(long4x2 lhs, long4x4 rhs) => long4x2(((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01) + (lhs.m20 * rhs.m02 + lhs.m30 * rhs.m03)), ((lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01) + (lhs.m21 * rhs.m02 + lhs.m31 * rhs.m03)), ((lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11) + (lhs.m20 * rhs.m12 + lhs.m30 * rhs.m13)), ((lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11) + (lhs.m21 * rhs.m12 + lhs.m31 * rhs.m13)), ((lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21) + (lhs.m20 * rhs.m22 + lhs.m30 * rhs.m23)), ((lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21) + (lhs.m21 * rhs.m22 + lhs.m31 * rhs.m23)), ((lhs.m00 * rhs.m30 + lhs.m10 * rhs.m31) + (lhs.m20 * rhs.m32 + lhs.m30 * rhs.m33)), ((lhs.m01 * rhs.m30 + lhs.m11 * rhs.m31) + (lhs.m21 * rhs.m32 + lhs.m31 * rhs.m33)));
        
        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static long2 operator*(long4x2 m, long4 v) => long2(((m.m00 * v.x + m.m10 * v.y) + (m.m20 * v.z + m.m30 * v.w)), ((m.m01 * v.x + m.m11 * v.y) + (m.m21 * v.z + m.m31 * v.w)));
        
        /// <summary>
        /// Executes a component-wise * (multiply).
        /// </summary>
        public static long4x2 CompMul(long4x2 A, long4x2 B) => long4x2(A.m00 * B.m00, A.m01 * B.m01, A.m10 * B.m10, A.m11 * B.m11, A.m20 * B.m20, A.m21 * B.m21, A.m30 * B.m30, A.m31 * B.m31);
        
        /// <summary>
        /// Executes a component-wise / (divide).
        /// </summary>
        public static long4x2 CompDiv(long4x2 A, long4x2 B) => long4x2(A.m00 / B.m00, A.m01 / B.m01, A.m10 / B.m10, A.m11 / B.m11, A.m20 / B.m20, A.m21 / B.m21, A.m30 / B.m30, A.m31 / B.m31);
        
        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static long4x2 CompAdd(long4x2 A, long4x2 B) => long4x2(A.m00 + B.m00, A.m01 + B.m01, A.m10 + B.m10, A.m11 + B.m11, A.m20 + B.m20, A.m21 + B.m21, A.m30 + B.m30, A.m31 + B.m31);
        
        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static long4x2 CompSub(long4x2 A, long4x2 B) => long4x2(A.m00 - B.m00, A.m01 - B.m01, A.m10 - B.m10, A.m11 - B.m11, A.m20 - B.m20, A.m21 - B.m21, A.m30 - B.m30, A.m31 - B.m31);
        
        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static long4x2 operator+(long4x2 lhs, long4x2 rhs) => long4x2(lhs.m00 + rhs.m00, lhs.m01 + rhs.m01, lhs.m10 + rhs.m10, lhs.m11 + rhs.m11, lhs.m20 + rhs.m20, lhs.m21 + rhs.m21, lhs.m30 + rhs.m30, lhs.m31 + rhs.m31);
        
        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static long4x2 operator+(long4x2 lhs, long rhs) => long4x2(lhs.m00 + rhs, lhs.m01 + rhs, lhs.m10 + rhs, lhs.m11 + rhs, lhs.m20 + rhs, lhs.m21 + rhs, lhs.m30 + rhs, lhs.m31 + rhs);
        
        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static long4x2 operator+(long lhs, long4x2 rhs) => long4x2(lhs + rhs.m00, lhs + rhs.m01, lhs + rhs.m10, lhs + rhs.m11, lhs + rhs.m20, lhs + rhs.m21, lhs + rhs.m30, lhs + rhs.m31);
        
        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static long4x2 operator-(long4x2 lhs, long4x2 rhs) => long4x2(lhs.m00 - rhs.m00, lhs.m01 - rhs.m01, lhs.m10 - rhs.m10, lhs.m11 - rhs.m11, lhs.m20 - rhs.m20, lhs.m21 - rhs.m21, lhs.m30 - rhs.m30, lhs.m31 - rhs.m31);
        
        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static long4x2 operator-(long4x2 lhs, long rhs) => long4x2(lhs.m00 - rhs, lhs.m01 - rhs, lhs.m10 - rhs, lhs.m11 - rhs, lhs.m20 - rhs, lhs.m21 - rhs, lhs.m30 - rhs, lhs.m31 - rhs);
        
        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static long4x2 operator-(long lhs, long4x2 rhs) => long4x2(lhs - rhs.m00, lhs - rhs.m01, lhs - rhs.m10, lhs - rhs.m11, lhs - rhs.m20, lhs - rhs.m21, lhs - rhs.m30, lhs - rhs.m31);
        
        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static long4x2 operator/(long4x2 lhs, long rhs) => long4x2(lhs.m00 / rhs, lhs.m01 / rhs, lhs.m10 / rhs, lhs.m11 / rhs, lhs.m20 / rhs, lhs.m21 / rhs, lhs.m30 / rhs, lhs.m31 / rhs);
        
        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static long4x2 operator/(long lhs, long4x2 rhs) => long4x2(lhs / rhs.m00, lhs / rhs.m01, lhs / rhs.m10, lhs / rhs.m11, lhs / rhs.m20, lhs / rhs.m21, lhs / rhs.m30, lhs / rhs.m31);
        
        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static long4x2 operator*(long4x2 lhs, long rhs) => long4x2(lhs.m00 * rhs, lhs.m01 * rhs, lhs.m10 * rhs, lhs.m11 * rhs, lhs.m20 * rhs, lhs.m21 * rhs, lhs.m30 * rhs, lhs.m31 * rhs);
        
        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static long4x2 operator*(long lhs, long4x2 rhs) => long4x2(lhs * rhs.m00, lhs * rhs.m01, lhs * rhs.m10, lhs * rhs.m11, lhs * rhs.m20, lhs * rhs.m21, lhs * rhs.m30, lhs * rhs.m31);
        
        /// <summary>
        /// Executes a component-wise % (modulo).
        /// </summary>
        public static long4x2 operator%(long4x2 lhs, long4x2 rhs) => long4x2(lhs.m00 % rhs.m00, lhs.m01 % rhs.m01, lhs.m10 % rhs.m10, lhs.m11 % rhs.m11, lhs.m20 % rhs.m20, lhs.m21 % rhs.m21, lhs.m30 % rhs.m30, lhs.m31 % rhs.m31);
        
        /// <summary>
        /// Executes a component-wise % (modulo) with a scalar.
        /// </summary>
        public static long4x2 operator%(long4x2 lhs, long rhs) => long4x2(lhs.m00 % rhs, lhs.m01 % rhs, lhs.m10 % rhs, lhs.m11 % rhs, lhs.m20 % rhs, lhs.m21 % rhs, lhs.m30 % rhs, lhs.m31 % rhs);
        
        /// <summary>
        /// Executes a component-wise % (modulo) with a scalar.
        /// </summary>
        public static long4x2 operator%(long lhs, long4x2 rhs) => long4x2(lhs % rhs.m00, lhs % rhs.m01, lhs % rhs.m10, lhs % rhs.m11, lhs % rhs.m20, lhs % rhs.m21, lhs % rhs.m30, lhs % rhs.m31);
        
        /// <summary>
        /// Executes a component-wise ^ (xor).
        /// </summary>
        public static long4x2 operator^(long4x2 lhs, long4x2 rhs) => long4x2(lhs.m00 ^ rhs.m00, lhs.m01 ^ rhs.m01, lhs.m10 ^ rhs.m10, lhs.m11 ^ rhs.m11, lhs.m20 ^ rhs.m20, lhs.m21 ^ rhs.m21, lhs.m30 ^ rhs.m30, lhs.m31 ^ rhs.m31);
        
        /// <summary>
        /// Executes a component-wise ^ (xor) with a scalar.
        /// </summary>
        public static long4x2 operator^(long4x2 lhs, long rhs) => long4x2(lhs.m00 ^ rhs, lhs.m01 ^ rhs, lhs.m10 ^ rhs, lhs.m11 ^ rhs, lhs.m20 ^ rhs, lhs.m21 ^ rhs, lhs.m30 ^ rhs, lhs.m31 ^ rhs);
        
        /// <summary>
        /// Executes a component-wise ^ (xor) with a scalar.
        /// </summary>
        public static long4x2 operator^(long lhs, long4x2 rhs) => long4x2(lhs ^ rhs.m00, lhs ^ rhs.m01, lhs ^ rhs.m10, lhs ^ rhs.m11, lhs ^ rhs.m20, lhs ^ rhs.m21, lhs ^ rhs.m30, lhs ^ rhs.m31);
        
        /// <summary>
        /// Executes a component-wise | (bitwise-or).
        /// </summary>
        public static long4x2 operator|(long4x2 lhs, long4x2 rhs) => long4x2(lhs.m00 | rhs.m00, lhs.m01 | rhs.m01, lhs.m10 | rhs.m10, lhs.m11 | rhs.m11, lhs.m20 | rhs.m20, lhs.m21 | rhs.m21, lhs.m30 | rhs.m30, lhs.m31 | rhs.m31);
        
        /// <summary>
        /// Executes a component-wise | (bitwise-or) with a scalar.
        /// </summary>
        public static long4x2 operator|(long4x2 lhs, long rhs) => long4x2(lhs.m00 | rhs, lhs.m01 | rhs, lhs.m10 | rhs, lhs.m11 | rhs, lhs.m20 | rhs, lhs.m21 | rhs, lhs.m30 | rhs, lhs.m31 | rhs);
        
        /// <summary>
        /// Executes a component-wise | (bitwise-or) with a scalar.
        /// </summary>
        public static long4x2 operator|(long lhs, long4x2 rhs) => long4x2(lhs | rhs.m00, lhs | rhs.m01, lhs | rhs.m10, lhs | rhs.m11, lhs | rhs.m20, lhs | rhs.m21, lhs | rhs.m30, lhs | rhs.m31);
        
        /// <summary>
        /// Executes a component-wise &amp; (bitwise-and).
        /// </summary>
        public static long4x2 operator&(long4x2 lhs, long4x2 rhs) => long4x2(lhs.m00 & rhs.m00, lhs.m01 & rhs.m01, lhs.m10 & rhs.m10, lhs.m11 & rhs.m11, lhs.m20 & rhs.m20, lhs.m21 & rhs.m21, lhs.m30 & rhs.m30, lhs.m31 & rhs.m31);
        
        /// <summary>
        /// Executes a component-wise &amp; (bitwise-and) with a scalar.
        /// </summary>
        public static long4x2 operator&(long4x2 lhs, long rhs) => long4x2(lhs.m00 & rhs, lhs.m01 & rhs, lhs.m10 & rhs, lhs.m11 & rhs, lhs.m20 & rhs, lhs.m21 & rhs, lhs.m30 & rhs, lhs.m31 & rhs);
        
        /// <summary>
        /// Executes a component-wise &amp; (bitwise-and) with a scalar.
        /// </summary>
        public static long4x2 operator&(long lhs, long4x2 rhs) => long4x2(lhs & rhs.m00, lhs & rhs.m01, lhs & rhs.m10, lhs & rhs.m11, lhs & rhs.m20, lhs & rhs.m21, lhs & rhs.m30, lhs & rhs.m31);
        
        /// <summary>
        /// Executes a component-wise left-shift with a scalar.
        /// </summary>
        public static long4x2 operator<<(long4x2 lhs, int rhs) => long4x2(lhs.m00 << rhs, lhs.m01 << rhs, lhs.m10 << rhs, lhs.m11 << rhs, lhs.m20 << rhs, lhs.m21 << rhs, lhs.m30 << rhs, lhs.m31 << rhs);
        
        /// <summary>
        /// Executes a component-wise right-shift with a scalar.
        /// </summary>
        public static long4x2 operator>>(long4x2 lhs, int rhs) => long4x2(lhs.m00 >> rhs, lhs.m01 >> rhs, lhs.m10 >> rhs, lhs.m11 >> rhs, lhs.m20 >> rhs, lhs.m21 >> rhs, lhs.m30 >> rhs, lhs.m31 >> rhs);
        
        /// <summary>
        /// Executes a component-wise lesser-than comparison.
        /// </summary>
        public static bool4x2 operator<(long4x2 lhs, long4x2 rhs) => bool4x2(lhs.m00 < rhs.m00, lhs.m01 < rhs.m01, lhs.m10 < rhs.m10, lhs.m11 < rhs.m11, lhs.m20 < rhs.m20, lhs.m21 < rhs.m21, lhs.m30 < rhs.m30, lhs.m31 < rhs.m31);
        
        /// <summary>
        /// Executes a component-wise lesser-than comparison with a scalar.
        /// </summary>
        public static bool4x2 operator<(long4x2 lhs, long rhs) => bool4x2(lhs.m00 < rhs, lhs.m01 < rhs, lhs.m10 < rhs, lhs.m11 < rhs, lhs.m20 < rhs, lhs.m21 < rhs, lhs.m30 < rhs, lhs.m31 < rhs);
        
        /// <summary>
        /// Executes a component-wise lesser-than comparison with a scalar.
        /// </summary>
        public static bool4x2 operator<(long lhs, long4x2 rhs) => bool4x2(lhs < rhs.m00, lhs < rhs.m01, lhs < rhs.m10, lhs < rhs.m11, lhs < rhs.m20, lhs < rhs.m21, lhs < rhs.m30, lhs < rhs.m31);
        
        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison.
        /// </summary>
        public static bool4x2 operator<=(long4x2 lhs, long4x2 rhs) => bool4x2(lhs.m00 <= rhs.m00, lhs.m01 <= rhs.m01, lhs.m10 <= rhs.m10, lhs.m11 <= rhs.m11, lhs.m20 <= rhs.m20, lhs.m21 <= rhs.m21, lhs.m30 <= rhs.m30, lhs.m31 <= rhs.m31);
        
        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison with a scalar.
        /// </summary>
        public static bool4x2 operator<=(long4x2 lhs, long rhs) => bool4x2(lhs.m00 <= rhs, lhs.m01 <= rhs, lhs.m10 <= rhs, lhs.m11 <= rhs, lhs.m20 <= rhs, lhs.m21 <= rhs, lhs.m30 <= rhs, lhs.m31 <= rhs);
        
        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison with a scalar.
        /// </summary>
        public static bool4x2 operator<=(long lhs, long4x2 rhs) => bool4x2(lhs <= rhs.m00, lhs <= rhs.m01, lhs <= rhs.m10, lhs <= rhs.m11, lhs <= rhs.m20, lhs <= rhs.m21, lhs <= rhs.m30, lhs <= rhs.m31);
        
        /// <summary>
        /// Executes a component-wise greater-than comparison.
        /// </summary>
        public static bool4x2 operator>(long4x2 lhs, long4x2 rhs) => bool4x2(lhs.m00 > rhs.m00, lhs.m01 > rhs.m01, lhs.m10 > rhs.m10, lhs.m11 > rhs.m11, lhs.m20 > rhs.m20, lhs.m21 > rhs.m21, lhs.m30 > rhs.m30, lhs.m31 > rhs.m31);
        
        /// <summary>
        /// Executes a component-wise greater-than comparison with a scalar.
        /// </summary>
        public static bool4x2 operator>(long4x2 lhs, long rhs) => bool4x2(lhs.m00 > rhs, lhs.m01 > rhs, lhs.m10 > rhs, lhs.m11 > rhs, lhs.m20 > rhs, lhs.m21 > rhs, lhs.m30 > rhs, lhs.m31 > rhs);
        
        /// <summary>
        /// Executes a component-wise greater-than comparison with a scalar.
        /// </summary>
        public static bool4x2 operator>(long lhs, long4x2 rhs) => bool4x2(lhs > rhs.m00, lhs > rhs.m01, lhs > rhs.m10, lhs > rhs.m11, lhs > rhs.m20, lhs > rhs.m21, lhs > rhs.m30, lhs > rhs.m31);
        
        /// <summary>
        /// Executes a component-wise greater-or-equal comparison.
        /// </summary>
        public static bool4x2 operator>=(long4x2 lhs, long4x2 rhs) => bool4x2(lhs.m00 >= rhs.m00, lhs.m01 >= rhs.m01, lhs.m10 >= rhs.m10, lhs.m11 >= rhs.m11, lhs.m20 >= rhs.m20, lhs.m21 >= rhs.m21, lhs.m30 >= rhs.m30, lhs.m31 >= rhs.m31);
        
        /// <summary>
        /// Executes a component-wise greater-or-equal comparison with a scalar.
        /// </summary>
        public static bool4x2 operator>=(long4x2 lhs, long rhs) => bool4x2(lhs.m00 >= rhs, lhs.m01 >= rhs, lhs.m10 >= rhs, lhs.m11 >= rhs, lhs.m20 >= rhs, lhs.m21 >= rhs, lhs.m30 >= rhs, lhs.m31 >= rhs);
        
        /// <summary>
        /// Executes a component-wise greater-or-equal comparison with a scalar.
        /// </summary>
        public static bool4x2 operator>=(long lhs, long4x2 rhs) => bool4x2(lhs >= rhs.m00, lhs >= rhs.m01, lhs >= rhs.m10, lhs >= rhs.m11, lhs >= rhs.m20, lhs >= rhs.m21, lhs >= rhs.m30, lhs >= rhs.m31);
    }
}
