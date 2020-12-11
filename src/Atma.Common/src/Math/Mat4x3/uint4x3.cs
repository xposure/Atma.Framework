using System;
namespace Atma
{
    
    /// <summary>
    /// A matrix of type uint with 4 columns and 3 rows.
    /// </summary>
    public struct uint4x3 : IEquatable<uint4x3>
    {

        //#region Fields
        
        /// <summary>
        /// component data
        /// </summary>
        public uint[12] values;

        //#endregion


        //#region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public this(uint m00, uint m01, uint m02, uint m10, uint m11, uint m12, uint m20, uint m21, uint m22, uint m30, uint m31, uint m32)
        {
            values = .(m00,m01,m02,m10,m11,m12,m20,m21,m22,m30,m31,m32);
        }
        
        /// <summary>
        /// Constructs this matrix from a uint2x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(uint2x2 m)
        {
            values = .(m.m00,m.m01,0u,m.m10,m.m11,0u,0u,0u,1u,0u,0u,0u);
        }
        
        /// <summary>
        /// Constructs this matrix from a uint3x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(uint3x2 m)
        {
            values = .(m.m00,m.m01,0u,m.m10,m.m11,0u,m.m20,m.m21,1u,0u,0u,0u);
        }
        
        /// <summary>
        /// Constructs this matrix from a uint4x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(uint4x2 m)
        {
            values = .(m.m00,m.m01,0u,m.m10,m.m11,0u,m.m20,m.m21,1u,m.m30,m.m31,0u);
        }
        
        /// <summary>
        /// Constructs this matrix from a uint2x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(uint2x3 m)
        {
            values = .(m.m00,m.m01,m.m02,m.m10,m.m11,m.m12,0u,0u,1u,0u,0u,0u);
        }
        
        /// <summary>
        /// Constructs this matrix from a uint3x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(uint3x3 m)
        {
            values = .(m.m00,m.m01,m.m02,m.m10,m.m11,m.m12,m.m20,m.m21,m.m22,0u,0u,0u);
        }
        
        /// <summary>
        /// Constructs this matrix from a uint4x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(uint4x3 m)
        {
            values = .(m.m00,m.m01,m.m02,m.m10,m.m11,m.m12,m.m20,m.m21,m.m22,m.m30,m.m31,m.m32);
        }
        
        /// <summary>
        /// Constructs this matrix from a uint2x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(uint2x4 m)
        {
            values = .(m.m00,m.m01,m.m02,m.m10,m.m11,m.m12,0u,0u,1u,0u,0u,0u);
        }
        
        /// <summary>
        /// Constructs this matrix from a uint3x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(uint3x4 m)
        {
            values = .(m.m00,m.m01,m.m02,m.m10,m.m11,m.m12,m.m20,m.m21,m.m22,0u,0u,0u);
        }
        
        /// <summary>
        /// Constructs this matrix from a uint4x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(uint4x4 m)
        {
            values = .(m.m00,m.m01,m.m02,m.m10,m.m11,m.m12,m.m20,m.m21,m.m22,m.m30,m.m31,m.m32);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(uint2 c0, uint2 c1)
        {
            values = .(c0.x,c0.y,0u,c1.x,c1.y,0u,0u,0u,1u,0u,0u,0u);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(uint2 c0, uint2 c1, uint2 c2)
        {
            values = .(c0.x,c0.y,0u,c1.x,c1.y,0u,c2.x,c2.y,1u,0u,0u,0u);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(uint2 c0, uint2 c1, uint2 c2, uint2 c3)
        {
            values = .(c0.x,c0.y,0u,c1.x,c1.y,0u,c2.x,c2.y,1u,c3.x,c3.y,0u);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(uint3 c0, uint3 c1)
        {
            values = .(c0.x,c0.y,c0.z,c1.x,c1.y,c1.z,0u,0u,1u,0u,0u,0u);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(uint3 c0, uint3 c1, uint3 c2)
        {
            values = .(c0.x,c0.y,c0.z,c1.x,c1.y,c1.z,c2.x,c2.y,c2.z,0u,0u,0u);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(uint3 c0, uint3 c1, uint3 c2, uint3 c3)
        {
            values = .(c0.x,c0.y,c0.z,c1.x,c1.y,c1.z,c2.x,c2.y,c2.z,c3.x,c3.y,c3.z);
        }

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Column 0, Rows 0
        /// </summary>
        public uint m00
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
        public uint m01
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
        public uint m02
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
        /// Column 1, Rows 0
        /// </summary>
        public uint m10
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
        /// Column 1, Rows 1
        /// </summary>
        public uint m11
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
        /// Column 1, Rows 2
        /// </summary>
        public uint m12
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
        /// Column 2, Rows 0
        /// </summary>
        public uint m20
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
        /// Column 2, Rows 1
        /// </summary>
        public uint m21
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
        /// Column 2, Rows 2
        /// </summary>
        public uint m22
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
        /// Column 3, Rows 0
        /// </summary>
        public uint m30
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
        /// Column 3, Rows 1
        /// </summary>
        public uint m31
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
        /// Column 3, Rows 2
        /// </summary>
        public uint m32
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
        /// Gets or sets the column nr 0
        /// </summary>
        public uint3 Column0
        {
            [Inline]get
            {
                return  uint3(m00, m01, m02);
            }
            [Inline]set mut
            {
                m00 = value.x;
                m01 = value.y;
                m02 = value.z;
            }
        }
        
        /// <summary>
        /// Gets or sets the column nr 1
        /// </summary>
        public uint3 Column1
        {
            [Inline]get
            {
                return  uint3(m10, m11, m12);
            }
            [Inline]set mut
            {
                m10 = value.x;
                m11 = value.y;
                m12 = value.z;
            }
        }
        
        /// <summary>
        /// Gets or sets the column nr 2
        /// </summary>
        public uint3 Column2
        {
            [Inline]get
            {
                return  uint3(m20, m21, m22);
            }
            [Inline]set mut
            {
                m20 = value.x;
                m21 = value.y;
                m22 = value.z;
            }
        }
        
        /// <summary>
        /// Gets or sets the column nr 3
        /// </summary>
        public uint3 Column3
        {
            [Inline]get
            {
                return  uint3(m30, m31, m32);
            }
            [Inline]set mut
            {
                m30 = value.x;
                m31 = value.y;
                m32 = value.z;
            }
        }
        
        /// <summary>
        /// Gets or sets the row nr 0
        /// </summary>
        public uint4 Row0
        {
            [Inline]get
            {
                return  uint4(m00, m10, m20, m30);
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
        public uint4 Row1
        {
            [Inline]get
            {
                return  uint4(m01, m11, m21, m31);
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
        public uint4 Row2
        {
            [Inline]get
            {
                return  uint4(m02, m12, m22, m32);
            }
            [Inline]set mut
            {
                m02 = value.x;
                m12 = value.y;
                m22 = value.z;
                m32 = value.w;
            }
        }

        //#endregion


        //#region Static Properties
        
        /// <summary>
        /// Predefined all-zero matrix
        /// </summary>
        readonly public static uint4x3 Zero  =  uint4x3(0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u, 0u);
        
        /// <summary>
        /// Predefined all-ones matrix
        /// </summary>
        readonly public static uint4x3 Ones  =  uint4x3(1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u, 1u);
        
        /// <summary>
        /// Predefined identity matrix
        /// </summary>
        readonly public static uint4x3 Identity  =  uint4x3(1u, 0u, 0u, 0u, 1u, 0u, 0u, 0u, 1u, 0u, 0u, 0u);
        
        /// <summary>
        /// Predefined all-MaxValue matrix
        /// </summary>
        readonly public static uint4x3 AllMaxValue  =  uint4x3(uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue);
        
        /// <summary>
        /// Predefined diagonal-MaxValue matrix
        /// </summary>
        readonly public static uint4x3 DiagonalMaxValue  =  uint4x3(uint.MaxValue, 0u, 0u, 0u, uint.MaxValue, 0u, 0u, 0u, uint.MaxValue, 0u, 0u, 0u);
        
        /// <summary>
        /// Predefined all-MinValue matrix
        /// </summary>
        readonly public static uint4x3 AllMinValue  =  uint4x3(uint.MinValue, uint.MinValue, uint.MinValue, uint.MinValue, uint.MinValue, uint.MinValue, uint.MinValue, uint.MinValue, uint.MinValue, uint.MinValue, uint.MinValue, uint.MinValue);
        
        /// <summary>
        /// Predefined diagonal-MinValue matrix
        /// </summary>
        readonly public static uint4x3 DiagonalMinValue  =  uint4x3(uint.MinValue, 0u, 0u, 0u, uint.MinValue, 0u, 0u, 0u, uint.MinValue, 0u, 0u, 0u);

        //#endregion


        //#region Functions
        
        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public uint[,] ToArray() => new .[,] ( ( m00, m01, m02 ), ( m10, m11, m12 ), ( m20, m21, m22 ), ( m30, m31, m32 ) );
        
        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public uint[] ToArray1D() => new .[] ( m00, m01, m02, m10, m11, m12, m20, m21, m22, m30, m31, m32 );

        //#endregion

        
        /// <summary>
        /// Returns the number of Fields (4 x 3 = 12).
        /// </summary>
        public int Count => 12;
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public uint this[int fieldIndex]
        {
            [Inline]get
            {
               System.Diagnostics.Debug.Assert(fieldIndex >= 0 && fieldIndex < 12, "fieldIndex was out of range");
               unchecked { return values[fieldIndex]; }
            }
            [Inline]set mut
            {
               System.Diagnostics.Debug.Assert(fieldIndex >= 0 && fieldIndex < 12, "fieldIndex was out of range");
               unchecked { values[fieldIndex] = value; }
            }
        }
        
        /// <summary>
        /// Gets/Sets a specific 2D-indexed component (a bit slower than direct access).
        /// </summary>
        public uint this[int col, int row]
        {
            [Inline]get
            {
                System.Diagnostics.Debug.Assert(col >= 0 && col < 4, "col was out of range");
                System.Diagnostics.Debug.Assert(row >= 0 && row < 3, "row was out of range");
                unchecked { return values[col * 3 + row]; }
            }
            [Inline]set mut
            {
                System.Diagnostics.Debug.Assert(col >= 0 && col < 4, "col was out of range");
                System.Diagnostics.Debug.Assert(row >= 0 && row < 3, "row was out of range");
                unchecked { values[col * 3 + row] = value; }
            }
        }
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public bool Equals(uint4x3 rhs) => ((((m00 == rhs.m00 && m01 == rhs.m01) && m02 == rhs.m02) && ((m10 == rhs.m10 && m11 == rhs.m11) && m12 == rhs.m12)) && (((m20 == rhs.m20 && m21 == rhs.m21) && m22 == rhs.m22) && ((m30 == rhs.m30 && m31 == rhs.m31) && m32 == rhs.m32)));
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(uint4x3 lhs, uint4x3 rhs) => lhs.Equals(rhs);
        
        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(uint4x3 lhs, uint4x3 rhs) => !lhs.Equals(rhs);
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public int GetHashCode()
        {
            unchecked
            {
                return ((((((((((((((((((((((m00.GetHashCode()) * 397) ^ m01.GetHashCode()) * 397) ^ m02.GetHashCode()) * 397) ^ m10.GetHashCode()) * 397) ^ m11.GetHashCode()) * 397) ^ m12.GetHashCode()) * 397) ^ m20.GetHashCode()) * 397) ^ m21.GetHashCode()) * 397) ^ m22.GetHashCode()) * 397) ^ m30.GetHashCode()) * 397) ^ m31.GetHashCode()) * 397) ^ m32.GetHashCode();
            }
        }
        
        /// <summary>
        /// Returns a transposed version of this matrix.
        /// </summary>
        public uint3x4 Transposed => uint3x4(m00, m10, m20, m30, m01, m11, m21, m31, m02, m12, m22, m32);
        
        /// <summary>
        /// Returns the minimal component of this matrix.
        /// </summary>
        public uint MinElement => System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(m00, m01), m02), m10), m11), m12), m20), m21), m22), m30), m31), m32);
        
        /// <summary>
        /// Returns the maximal component of this matrix.
        /// </summary>
        public uint MaxElement => System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(m00, m01), m02), m10), m11), m12), m20), m21), m22), m30), m31), m32);
        
        /// <summary>
        /// Returns the euclidean length of this matrix.
        /// </summary>
        public float Length => (float)System.Math.Sqrt(((((m00*m00 + m01*m01) + m02*m02) + ((m10*m10 + m11*m11) + m12*m12)) + (((m20*m20 + m21*m21) + m22*m22) + ((m30*m30 + m31*m31) + m32*m32))));
        
        /// <summary>
        /// Returns the squared euclidean length of this matrix.
        /// </summary>
        public float LengthSqr => ((((m00*m00 + m01*m01) + m02*m02) + ((m10*m10 + m11*m11) + m12*m12)) + (((m20*m20 + m21*m21) + m22*m22) + ((m30*m30 + m31*m31) + m32*m32)));
        
        /// <summary>
        /// Returns the sum of all fields.
        /// </summary>
        public uint Sum => ((((m00 + m01) + m02) + ((m10 + m11) + m12)) + (((m20 + m21) + m22) + ((m30 + m31) + m32)));
        
        /// <summary>
        /// Returns the euclidean norm of this matrix.
        /// </summary>
        public float Norm => (float)System.Math.Sqrt(((((m00*m00 + m01*m01) + m02*m02) + ((m10*m10 + m11*m11) + m12*m12)) + (((m20*m20 + m21*m21) + m22*m22) + ((m30*m30 + m31*m31) + m32*m32))));
        
        /// <summary>
        /// Returns the one-norm of this matrix.
        /// </summary>
        public float Norm1 => ((((m00 + m01) + m02) + ((m10 + m11) + m12)) + (((m20 + m21) + m22) + ((m30 + m31) + m32)));
        
        /// <summary>
        /// Returns the two-norm of this matrix.
        /// </summary>
        public float Norm2 => (float)System.Math.Sqrt(((((m00*m00 + m01*m01) + m02*m02) + ((m10*m10 + m11*m11) + m12*m12)) + (((m20*m20 + m21*m21) + m22*m22) + ((m30*m30 + m31*m31) + m32*m32))));
        
        /// <summary>
        /// Returns the max-norm of this matrix.
        /// </summary>
        public uint NormMax => System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(m00, m01), m02), m10), m11), m12), m20), m21), m22), m30), m31), m32);
        
        /// <summary>
        /// Returns the p-norm of this matrix.
        /// </summary>
        public double NormP(double p) => System.Math.Pow(((((System.Math.Pow((double)m00, p) + System.Math.Pow((double)m01, p)) + System.Math.Pow((double)m02, p)) + ((System.Math.Pow((double)m10, p) + System.Math.Pow((double)m11, p)) + System.Math.Pow((double)m12, p))) + (((System.Math.Pow((double)m20, p) + System.Math.Pow((double)m21, p)) + System.Math.Pow((double)m22, p)) + ((System.Math.Pow((double)m30, p) + System.Math.Pow((double)m31, p)) + System.Math.Pow((double)m32, p)))), 1 / p);
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication uint4x3 * uint2x4 -> uint2x3.
        /// </summary>
        public static uint2x3 operator*(uint4x3 lhs, uint2x4 rhs) => uint2x3(((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01) + (lhs.m20 * rhs.m02 + lhs.m30 * rhs.m03)), ((lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01) + (lhs.m21 * rhs.m02 + lhs.m31 * rhs.m03)), ((lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01) + (lhs.m22 * rhs.m02 + lhs.m32 * rhs.m03)), ((lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11) + (lhs.m20 * rhs.m12 + lhs.m30 * rhs.m13)), ((lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11) + (lhs.m21 * rhs.m12 + lhs.m31 * rhs.m13)), ((lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11) + (lhs.m22 * rhs.m12 + lhs.m32 * rhs.m13)));
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication uint4x3 * uint3x4 -> uint3x3.
        /// </summary>
        public static uint3x3 operator*(uint4x3 lhs, uint3x4 rhs) => uint3x3(((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01) + (lhs.m20 * rhs.m02 + lhs.m30 * rhs.m03)), ((lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01) + (lhs.m21 * rhs.m02 + lhs.m31 * rhs.m03)), ((lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01) + (lhs.m22 * rhs.m02 + lhs.m32 * rhs.m03)), ((lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11) + (lhs.m20 * rhs.m12 + lhs.m30 * rhs.m13)), ((lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11) + (lhs.m21 * rhs.m12 + lhs.m31 * rhs.m13)), ((lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11) + (lhs.m22 * rhs.m12 + lhs.m32 * rhs.m13)), ((lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21) + (lhs.m20 * rhs.m22 + lhs.m30 * rhs.m23)), ((lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21) + (lhs.m21 * rhs.m22 + lhs.m31 * rhs.m23)), ((lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21) + (lhs.m22 * rhs.m22 + lhs.m32 * rhs.m23)));
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication uint4x3 * uint4x4 -> uint4x3.
        /// </summary>
        public static uint4x3 operator*(uint4x3 lhs, uint4x4 rhs) => uint4x3(((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01) + (lhs.m20 * rhs.m02 + lhs.m30 * rhs.m03)), ((lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01) + (lhs.m21 * rhs.m02 + lhs.m31 * rhs.m03)), ((lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01) + (lhs.m22 * rhs.m02 + lhs.m32 * rhs.m03)), ((lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11) + (lhs.m20 * rhs.m12 + lhs.m30 * rhs.m13)), ((lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11) + (lhs.m21 * rhs.m12 + lhs.m31 * rhs.m13)), ((lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11) + (lhs.m22 * rhs.m12 + lhs.m32 * rhs.m13)), ((lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21) + (lhs.m20 * rhs.m22 + lhs.m30 * rhs.m23)), ((lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21) + (lhs.m21 * rhs.m22 + lhs.m31 * rhs.m23)), ((lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21) + (lhs.m22 * rhs.m22 + lhs.m32 * rhs.m23)), ((lhs.m00 * rhs.m30 + lhs.m10 * rhs.m31) + (lhs.m20 * rhs.m32 + lhs.m30 * rhs.m33)), ((lhs.m01 * rhs.m30 + lhs.m11 * rhs.m31) + (lhs.m21 * rhs.m32 + lhs.m31 * rhs.m33)), ((lhs.m02 * rhs.m30 + lhs.m12 * rhs.m31) + (lhs.m22 * rhs.m32 + lhs.m32 * rhs.m33)));
        
        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static uint3 operator*(uint4x3 m, uint4 v) => uint3(((m.m00 * v.x + m.m10 * v.y) + (m.m20 * v.z + m.m30 * v.w)), ((m.m01 * v.x + m.m11 * v.y) + (m.m21 * v.z + m.m31 * v.w)), ((m.m02 * v.x + m.m12 * v.y) + (m.m22 * v.z + m.m32 * v.w)));
        
        /// <summary>
        /// Executes a component-wise * (multiply).
        /// </summary>
        public static uint4x3 CompMul(uint4x3 A, uint4x3 B) => uint4x3(A.m00 * B.m00, A.m01 * B.m01, A.m02 * B.m02, A.m10 * B.m10, A.m11 * B.m11, A.m12 * B.m12, A.m20 * B.m20, A.m21 * B.m21, A.m22 * B.m22, A.m30 * B.m30, A.m31 * B.m31, A.m32 * B.m32);
        
        /// <summary>
        /// Executes a component-wise / (divide).
        /// </summary>
        public static uint4x3 CompDiv(uint4x3 A, uint4x3 B) => uint4x3(A.m00 / B.m00, A.m01 / B.m01, A.m02 / B.m02, A.m10 / B.m10, A.m11 / B.m11, A.m12 / B.m12, A.m20 / B.m20, A.m21 / B.m21, A.m22 / B.m22, A.m30 / B.m30, A.m31 / B.m31, A.m32 / B.m32);
        
        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static uint4x3 CompAdd(uint4x3 A, uint4x3 B) => uint4x3(A.m00 + B.m00, A.m01 + B.m01, A.m02 + B.m02, A.m10 + B.m10, A.m11 + B.m11, A.m12 + B.m12, A.m20 + B.m20, A.m21 + B.m21, A.m22 + B.m22, A.m30 + B.m30, A.m31 + B.m31, A.m32 + B.m32);
        
        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static uint4x3 CompSub(uint4x3 A, uint4x3 B) => uint4x3(A.m00 - B.m00, A.m01 - B.m01, A.m02 - B.m02, A.m10 - B.m10, A.m11 - B.m11, A.m12 - B.m12, A.m20 - B.m20, A.m21 - B.m21, A.m22 - B.m22, A.m30 - B.m30, A.m31 - B.m31, A.m32 - B.m32);
        
        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static uint4x3 operator+(uint4x3 lhs, uint4x3 rhs) => uint4x3(lhs.m00 + rhs.m00, lhs.m01 + rhs.m01, lhs.m02 + rhs.m02, lhs.m10 + rhs.m10, lhs.m11 + rhs.m11, lhs.m12 + rhs.m12, lhs.m20 + rhs.m20, lhs.m21 + rhs.m21, lhs.m22 + rhs.m22, lhs.m30 + rhs.m30, lhs.m31 + rhs.m31, lhs.m32 + rhs.m32);
        
        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static uint4x3 operator+(uint4x3 lhs, uint rhs) => uint4x3(lhs.m00 + rhs, lhs.m01 + rhs, lhs.m02 + rhs, lhs.m10 + rhs, lhs.m11 + rhs, lhs.m12 + rhs, lhs.m20 + rhs, lhs.m21 + rhs, lhs.m22 + rhs, lhs.m30 + rhs, lhs.m31 + rhs, lhs.m32 + rhs);
        
        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static uint4x3 operator+(uint lhs, uint4x3 rhs) => uint4x3(lhs + rhs.m00, lhs + rhs.m01, lhs + rhs.m02, lhs + rhs.m10, lhs + rhs.m11, lhs + rhs.m12, lhs + rhs.m20, lhs + rhs.m21, lhs + rhs.m22, lhs + rhs.m30, lhs + rhs.m31, lhs + rhs.m32);
        
        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static uint4x3 operator-(uint4x3 lhs, uint4x3 rhs) => uint4x3(lhs.m00 - rhs.m00, lhs.m01 - rhs.m01, lhs.m02 - rhs.m02, lhs.m10 - rhs.m10, lhs.m11 - rhs.m11, lhs.m12 - rhs.m12, lhs.m20 - rhs.m20, lhs.m21 - rhs.m21, lhs.m22 - rhs.m22, lhs.m30 - rhs.m30, lhs.m31 - rhs.m31, lhs.m32 - rhs.m32);
        
        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static uint4x3 operator-(uint4x3 lhs, uint rhs) => uint4x3(lhs.m00 - rhs, lhs.m01 - rhs, lhs.m02 - rhs, lhs.m10 - rhs, lhs.m11 - rhs, lhs.m12 - rhs, lhs.m20 - rhs, lhs.m21 - rhs, lhs.m22 - rhs, lhs.m30 - rhs, lhs.m31 - rhs, lhs.m32 - rhs);
        
        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static uint4x3 operator-(uint lhs, uint4x3 rhs) => uint4x3(lhs - rhs.m00, lhs - rhs.m01, lhs - rhs.m02, lhs - rhs.m10, lhs - rhs.m11, lhs - rhs.m12, lhs - rhs.m20, lhs - rhs.m21, lhs - rhs.m22, lhs - rhs.m30, lhs - rhs.m31, lhs - rhs.m32);
        
        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static uint4x3 operator/(uint4x3 lhs, uint rhs) => uint4x3(lhs.m00 / rhs, lhs.m01 / rhs, lhs.m02 / rhs, lhs.m10 / rhs, lhs.m11 / rhs, lhs.m12 / rhs, lhs.m20 / rhs, lhs.m21 / rhs, lhs.m22 / rhs, lhs.m30 / rhs, lhs.m31 / rhs, lhs.m32 / rhs);
        
        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static uint4x3 operator/(uint lhs, uint4x3 rhs) => uint4x3(lhs / rhs.m00, lhs / rhs.m01, lhs / rhs.m02, lhs / rhs.m10, lhs / rhs.m11, lhs / rhs.m12, lhs / rhs.m20, lhs / rhs.m21, lhs / rhs.m22, lhs / rhs.m30, lhs / rhs.m31, lhs / rhs.m32);
        
        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static uint4x3 operator*(uint4x3 lhs, uint rhs) => uint4x3(lhs.m00 * rhs, lhs.m01 * rhs, lhs.m02 * rhs, lhs.m10 * rhs, lhs.m11 * rhs, lhs.m12 * rhs, lhs.m20 * rhs, lhs.m21 * rhs, lhs.m22 * rhs, lhs.m30 * rhs, lhs.m31 * rhs, lhs.m32 * rhs);
        
        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static uint4x3 operator*(uint lhs, uint4x3 rhs) => uint4x3(lhs * rhs.m00, lhs * rhs.m01, lhs * rhs.m02, lhs * rhs.m10, lhs * rhs.m11, lhs * rhs.m12, lhs * rhs.m20, lhs * rhs.m21, lhs * rhs.m22, lhs * rhs.m30, lhs * rhs.m31, lhs * rhs.m32);
        
        /// <summary>
        /// Executes a component-wise % (modulo).
        /// </summary>
        public static uint4x3 operator%(uint4x3 lhs, uint4x3 rhs) => uint4x3(lhs.m00 % rhs.m00, lhs.m01 % rhs.m01, lhs.m02 % rhs.m02, lhs.m10 % rhs.m10, lhs.m11 % rhs.m11, lhs.m12 % rhs.m12, lhs.m20 % rhs.m20, lhs.m21 % rhs.m21, lhs.m22 % rhs.m22, lhs.m30 % rhs.m30, lhs.m31 % rhs.m31, lhs.m32 % rhs.m32);
        
        /// <summary>
        /// Executes a component-wise % (modulo) with a scalar.
        /// </summary>
        public static uint4x3 operator%(uint4x3 lhs, uint rhs) => uint4x3(lhs.m00 % rhs, lhs.m01 % rhs, lhs.m02 % rhs, lhs.m10 % rhs, lhs.m11 % rhs, lhs.m12 % rhs, lhs.m20 % rhs, lhs.m21 % rhs, lhs.m22 % rhs, lhs.m30 % rhs, lhs.m31 % rhs, lhs.m32 % rhs);
        
        /// <summary>
        /// Executes a component-wise % (modulo) with a scalar.
        /// </summary>
        public static uint4x3 operator%(uint lhs, uint4x3 rhs) => uint4x3(lhs % rhs.m00, lhs % rhs.m01, lhs % rhs.m02, lhs % rhs.m10, lhs % rhs.m11, lhs % rhs.m12, lhs % rhs.m20, lhs % rhs.m21, lhs % rhs.m22, lhs % rhs.m30, lhs % rhs.m31, lhs % rhs.m32);
        
        /// <summary>
        /// Executes a component-wise ^ (xor).
        /// </summary>
        public static uint4x3 operator^(uint4x3 lhs, uint4x3 rhs) => uint4x3(lhs.m00 ^ rhs.m00, lhs.m01 ^ rhs.m01, lhs.m02 ^ rhs.m02, lhs.m10 ^ rhs.m10, lhs.m11 ^ rhs.m11, lhs.m12 ^ rhs.m12, lhs.m20 ^ rhs.m20, lhs.m21 ^ rhs.m21, lhs.m22 ^ rhs.m22, lhs.m30 ^ rhs.m30, lhs.m31 ^ rhs.m31, lhs.m32 ^ rhs.m32);
        
        /// <summary>
        /// Executes a component-wise ^ (xor) with a scalar.
        /// </summary>
        public static uint4x3 operator^(uint4x3 lhs, uint rhs) => uint4x3(lhs.m00 ^ rhs, lhs.m01 ^ rhs, lhs.m02 ^ rhs, lhs.m10 ^ rhs, lhs.m11 ^ rhs, lhs.m12 ^ rhs, lhs.m20 ^ rhs, lhs.m21 ^ rhs, lhs.m22 ^ rhs, lhs.m30 ^ rhs, lhs.m31 ^ rhs, lhs.m32 ^ rhs);
        
        /// <summary>
        /// Executes a component-wise ^ (xor) with a scalar.
        /// </summary>
        public static uint4x3 operator^(uint lhs, uint4x3 rhs) => uint4x3(lhs ^ rhs.m00, lhs ^ rhs.m01, lhs ^ rhs.m02, lhs ^ rhs.m10, lhs ^ rhs.m11, lhs ^ rhs.m12, lhs ^ rhs.m20, lhs ^ rhs.m21, lhs ^ rhs.m22, lhs ^ rhs.m30, lhs ^ rhs.m31, lhs ^ rhs.m32);
        
        /// <summary>
        /// Executes a component-wise | (bitwise-or).
        /// </summary>
        public static uint4x3 operator|(uint4x3 lhs, uint4x3 rhs) => uint4x3(lhs.m00 | rhs.m00, lhs.m01 | rhs.m01, lhs.m02 | rhs.m02, lhs.m10 | rhs.m10, lhs.m11 | rhs.m11, lhs.m12 | rhs.m12, lhs.m20 | rhs.m20, lhs.m21 | rhs.m21, lhs.m22 | rhs.m22, lhs.m30 | rhs.m30, lhs.m31 | rhs.m31, lhs.m32 | rhs.m32);
        
        /// <summary>
        /// Executes a component-wise | (bitwise-or) with a scalar.
        /// </summary>
        public static uint4x3 operator|(uint4x3 lhs, uint rhs) => uint4x3(lhs.m00 | rhs, lhs.m01 | rhs, lhs.m02 | rhs, lhs.m10 | rhs, lhs.m11 | rhs, lhs.m12 | rhs, lhs.m20 | rhs, lhs.m21 | rhs, lhs.m22 | rhs, lhs.m30 | rhs, lhs.m31 | rhs, lhs.m32 | rhs);
        
        /// <summary>
        /// Executes a component-wise | (bitwise-or) with a scalar.
        /// </summary>
        public static uint4x3 operator|(uint lhs, uint4x3 rhs) => uint4x3(lhs | rhs.m00, lhs | rhs.m01, lhs | rhs.m02, lhs | rhs.m10, lhs | rhs.m11, lhs | rhs.m12, lhs | rhs.m20, lhs | rhs.m21, lhs | rhs.m22, lhs | rhs.m30, lhs | rhs.m31, lhs | rhs.m32);
        
        /// <summary>
        /// Executes a component-wise &amp; (bitwise-and).
        /// </summary>
        public static uint4x3 operator&(uint4x3 lhs, uint4x3 rhs) => uint4x3(lhs.m00 & rhs.m00, lhs.m01 & rhs.m01, lhs.m02 & rhs.m02, lhs.m10 & rhs.m10, lhs.m11 & rhs.m11, lhs.m12 & rhs.m12, lhs.m20 & rhs.m20, lhs.m21 & rhs.m21, lhs.m22 & rhs.m22, lhs.m30 & rhs.m30, lhs.m31 & rhs.m31, lhs.m32 & rhs.m32);
        
        /// <summary>
        /// Executes a component-wise &amp; (bitwise-and) with a scalar.
        /// </summary>
        public static uint4x3 operator&(uint4x3 lhs, uint rhs) => uint4x3(lhs.m00 & rhs, lhs.m01 & rhs, lhs.m02 & rhs, lhs.m10 & rhs, lhs.m11 & rhs, lhs.m12 & rhs, lhs.m20 & rhs, lhs.m21 & rhs, lhs.m22 & rhs, lhs.m30 & rhs, lhs.m31 & rhs, lhs.m32 & rhs);
        
        /// <summary>
        /// Executes a component-wise &amp; (bitwise-and) with a scalar.
        /// </summary>
        public static uint4x3 operator&(uint lhs, uint4x3 rhs) => uint4x3(lhs & rhs.m00, lhs & rhs.m01, lhs & rhs.m02, lhs & rhs.m10, lhs & rhs.m11, lhs & rhs.m12, lhs & rhs.m20, lhs & rhs.m21, lhs & rhs.m22, lhs & rhs.m30, lhs & rhs.m31, lhs & rhs.m32);
        
        /// <summary>
        /// Executes a component-wise left-shift with a scalar.
        /// </summary>
        public static uint4x3 operator<<(uint4x3 lhs, int rhs) => uint4x3(lhs.m00 << rhs, lhs.m01 << rhs, lhs.m02 << rhs, lhs.m10 << rhs, lhs.m11 << rhs, lhs.m12 << rhs, lhs.m20 << rhs, lhs.m21 << rhs, lhs.m22 << rhs, lhs.m30 << rhs, lhs.m31 << rhs, lhs.m32 << rhs);
        
        /// <summary>
        /// Executes a component-wise right-shift with a scalar.
        /// </summary>
        public static uint4x3 operator>>(uint4x3 lhs, int rhs) => uint4x3(lhs.m00 >> rhs, lhs.m01 >> rhs, lhs.m02 >> rhs, lhs.m10 >> rhs, lhs.m11 >> rhs, lhs.m12 >> rhs, lhs.m20 >> rhs, lhs.m21 >> rhs, lhs.m22 >> rhs, lhs.m30 >> rhs, lhs.m31 >> rhs, lhs.m32 >> rhs);
        
        /// <summary>
        /// Executes a component-wise lesser-than comparison.
        /// </summary>
        public static bool4x3 operator<(uint4x3 lhs, uint4x3 rhs) => bool4x3(lhs.m00 < rhs.m00, lhs.m01 < rhs.m01, lhs.m02 < rhs.m02, lhs.m10 < rhs.m10, lhs.m11 < rhs.m11, lhs.m12 < rhs.m12, lhs.m20 < rhs.m20, lhs.m21 < rhs.m21, lhs.m22 < rhs.m22, lhs.m30 < rhs.m30, lhs.m31 < rhs.m31, lhs.m32 < rhs.m32);
        
        /// <summary>
        /// Executes a component-wise lesser-than comparison with a scalar.
        /// </summary>
        public static bool4x3 operator<(uint4x3 lhs, uint rhs) => bool4x3(lhs.m00 < rhs, lhs.m01 < rhs, lhs.m02 < rhs, lhs.m10 < rhs, lhs.m11 < rhs, lhs.m12 < rhs, lhs.m20 < rhs, lhs.m21 < rhs, lhs.m22 < rhs, lhs.m30 < rhs, lhs.m31 < rhs, lhs.m32 < rhs);
        
        /// <summary>
        /// Executes a component-wise lesser-than comparison with a scalar.
        /// </summary>
        public static bool4x3 operator<(uint lhs, uint4x3 rhs) => bool4x3(lhs < rhs.m00, lhs < rhs.m01, lhs < rhs.m02, lhs < rhs.m10, lhs < rhs.m11, lhs < rhs.m12, lhs < rhs.m20, lhs < rhs.m21, lhs < rhs.m22, lhs < rhs.m30, lhs < rhs.m31, lhs < rhs.m32);
        
        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison.
        /// </summary>
        public static bool4x3 operator<=(uint4x3 lhs, uint4x3 rhs) => bool4x3(lhs.m00 <= rhs.m00, lhs.m01 <= rhs.m01, lhs.m02 <= rhs.m02, lhs.m10 <= rhs.m10, lhs.m11 <= rhs.m11, lhs.m12 <= rhs.m12, lhs.m20 <= rhs.m20, lhs.m21 <= rhs.m21, lhs.m22 <= rhs.m22, lhs.m30 <= rhs.m30, lhs.m31 <= rhs.m31, lhs.m32 <= rhs.m32);
        
        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison with a scalar.
        /// </summary>
        public static bool4x3 operator<=(uint4x3 lhs, uint rhs) => bool4x3(lhs.m00 <= rhs, lhs.m01 <= rhs, lhs.m02 <= rhs, lhs.m10 <= rhs, lhs.m11 <= rhs, lhs.m12 <= rhs, lhs.m20 <= rhs, lhs.m21 <= rhs, lhs.m22 <= rhs, lhs.m30 <= rhs, lhs.m31 <= rhs, lhs.m32 <= rhs);
        
        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison with a scalar.
        /// </summary>
        public static bool4x3 operator<=(uint lhs, uint4x3 rhs) => bool4x3(lhs <= rhs.m00, lhs <= rhs.m01, lhs <= rhs.m02, lhs <= rhs.m10, lhs <= rhs.m11, lhs <= rhs.m12, lhs <= rhs.m20, lhs <= rhs.m21, lhs <= rhs.m22, lhs <= rhs.m30, lhs <= rhs.m31, lhs <= rhs.m32);
        
        /// <summary>
        /// Executes a component-wise greater-than comparison.
        /// </summary>
        public static bool4x3 operator>(uint4x3 lhs, uint4x3 rhs) => bool4x3(lhs.m00 > rhs.m00, lhs.m01 > rhs.m01, lhs.m02 > rhs.m02, lhs.m10 > rhs.m10, lhs.m11 > rhs.m11, lhs.m12 > rhs.m12, lhs.m20 > rhs.m20, lhs.m21 > rhs.m21, lhs.m22 > rhs.m22, lhs.m30 > rhs.m30, lhs.m31 > rhs.m31, lhs.m32 > rhs.m32);
        
        /// <summary>
        /// Executes a component-wise greater-than comparison with a scalar.
        /// </summary>
        public static bool4x3 operator>(uint4x3 lhs, uint rhs) => bool4x3(lhs.m00 > rhs, lhs.m01 > rhs, lhs.m02 > rhs, lhs.m10 > rhs, lhs.m11 > rhs, lhs.m12 > rhs, lhs.m20 > rhs, lhs.m21 > rhs, lhs.m22 > rhs, lhs.m30 > rhs, lhs.m31 > rhs, lhs.m32 > rhs);
        
        /// <summary>
        /// Executes a component-wise greater-than comparison with a scalar.
        /// </summary>
        public static bool4x3 operator>(uint lhs, uint4x3 rhs) => bool4x3(lhs > rhs.m00, lhs > rhs.m01, lhs > rhs.m02, lhs > rhs.m10, lhs > rhs.m11, lhs > rhs.m12, lhs > rhs.m20, lhs > rhs.m21, lhs > rhs.m22, lhs > rhs.m30, lhs > rhs.m31, lhs > rhs.m32);
        
        /// <summary>
        /// Executes a component-wise greater-or-equal comparison.
        /// </summary>
        public static bool4x3 operator>=(uint4x3 lhs, uint4x3 rhs) => bool4x3(lhs.m00 >= rhs.m00, lhs.m01 >= rhs.m01, lhs.m02 >= rhs.m02, lhs.m10 >= rhs.m10, lhs.m11 >= rhs.m11, lhs.m12 >= rhs.m12, lhs.m20 >= rhs.m20, lhs.m21 >= rhs.m21, lhs.m22 >= rhs.m22, lhs.m30 >= rhs.m30, lhs.m31 >= rhs.m31, lhs.m32 >= rhs.m32);
        
        /// <summary>
        /// Executes a component-wise greater-or-equal comparison with a scalar.
        /// </summary>
        public static bool4x3 operator>=(uint4x3 lhs, uint rhs) => bool4x3(lhs.m00 >= rhs, lhs.m01 >= rhs, lhs.m02 >= rhs, lhs.m10 >= rhs, lhs.m11 >= rhs, lhs.m12 >= rhs, lhs.m20 >= rhs, lhs.m21 >= rhs, lhs.m22 >= rhs, lhs.m30 >= rhs, lhs.m31 >= rhs, lhs.m32 >= rhs);
        
        /// <summary>
        /// Executes a component-wise greater-or-equal comparison with a scalar.
        /// </summary>
        public static bool4x3 operator>=(uint lhs, uint4x3 rhs) => bool4x3(lhs >= rhs.m00, lhs >= rhs.m01, lhs >= rhs.m02, lhs >= rhs.m10, lhs >= rhs.m11, lhs >= rhs.m12, lhs >= rhs.m20, lhs >= rhs.m21, lhs >= rhs.m22, lhs >= rhs.m30, lhs >= rhs.m31, lhs >= rhs.m32);
    }
}
