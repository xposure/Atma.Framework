using System;
namespace Atma
{
    
    /// <summary>
    /// A matrix of type float with 2 columns and 4 rows.
    /// </summary>
    public struct float2x4 : IEquatable<float2x4>
    {

        //#region Fields
        
        /// <summary>
        /// component data
        /// </summary>
        public float[8] values;

        //#endregion


        //#region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public this(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13)
        {
            values = .(m00,m01,m02,m03,m10,m11,m12,m13);
        }
        
        /// <summary>
        /// Constructs this matrix from a float2x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(float2x2 m)
        {
            values = .(m.m00,m.m01,0f,0f,m.m10,m.m11,0f,0f);
        }
        
        /// <summary>
        /// Constructs this matrix from a float3x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(float3x2 m)
        {
            values = .(m.m00,m.m01,0f,0f,m.m10,m.m11,0f,0f);
        }
        
        /// <summary>
        /// Constructs this matrix from a float4x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(float4x2 m)
        {
            values = .(m.m00,m.m01,0f,0f,m.m10,m.m11,0f,0f);
        }
        
        /// <summary>
        /// Constructs this matrix from a float2x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(float2x3 m)
        {
            values = .(m.m00,m.m01,m.m02,0f,m.m10,m.m11,m.m12,0f);
        }
        
        /// <summary>
        /// Constructs this matrix from a float3x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(float3x3 m)
        {
            values = .(m.m00,m.m01,m.m02,0f,m.m10,m.m11,m.m12,0f);
        }
        
        /// <summary>
        /// Constructs this matrix from a float4x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(float4x3 m)
        {
            values = .(m.m00,m.m01,m.m02,0f,m.m10,m.m11,m.m12,0f);
        }
        
        /// <summary>
        /// Constructs this matrix from a float2x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(float2x4 m)
        {
            values = .(m.m00,m.m01,m.m02,m.m03,m.m10,m.m11,m.m12,m.m13);
        }
        
        /// <summary>
        /// Constructs this matrix from a float3x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(float3x4 m)
        {
            values = .(m.m00,m.m01,m.m02,m.m03,m.m10,m.m11,m.m12,m.m13);
        }
        
        /// <summary>
        /// Constructs this matrix from a float4x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(float4x4 m)
        {
            values = .(m.m00,m.m01,m.m02,m.m03,m.m10,m.m11,m.m12,m.m13);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(float2 c0, float2 c1)
        {
            values = .(c0.x,c0.y,0f,0f,c1.x,c1.y,0f,0f);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(float3 c0, float3 c1)
        {
            values = .(c0.x,c0.y,c0.z,0f,c1.x,c1.y,c1.z,0f);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(float4 c0, float4 c1)
        {
            values = .(c0.x,c0.y,c0.z,c0.w,c1.x,c1.y,c1.z,c1.w);
        }

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Column 0, Rows 0
        /// </summary>
        public float m00
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
        public float m01
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
        public float m02
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
        public float m03
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
        public float m10
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
        public float m11
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
        public float m12
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
        public float m13
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
        public float4 Column0
        {
            [Inline]get
            {
                return  float4(m00, m01, m02, m03);
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
        public float4 Column1
        {
            [Inline]get
            {
                return  float4(m10, m11, m12, m13);
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
        /// Gets or sets the row nr 0
        /// </summary>
        public float2 Row0
        {
            [Inline]get
            {
                return  float2(m00, m10);
            }
            [Inline]set mut
            {
                m00 = value.x;
                m10 = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the row nr 1
        /// </summary>
        public float2 Row1
        {
            [Inline]get
            {
                return  float2(m01, m11);
            }
            [Inline]set mut
            {
                m01 = value.x;
                m11 = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the row nr 2
        /// </summary>
        public float2 Row2
        {
            [Inline]get
            {
                return  float2(m02, m12);
            }
            [Inline]set mut
            {
                m02 = value.x;
                m12 = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the row nr 3
        /// </summary>
        public float2 Row3
        {
            [Inline]get
            {
                return  float2(m03, m13);
            }
            [Inline]set mut
            {
                m03 = value.x;
                m13 = value.y;
            }
        }

        //#endregion


        //#region Static Properties
        
        /// <summary>
        /// Predefined all-zero matrix
        /// </summary>
        readonly public static float2x4 Zero  =  float2x4(0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f);
        
        /// <summary>
        /// Predefined all-ones matrix
        /// </summary>
        readonly public static float2x4 Ones  =  float2x4(1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
        
        /// <summary>
        /// Predefined identity matrix
        /// </summary>
        readonly public static float2x4 Identity  =  float2x4(1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f);
        
        /// <summary>
        /// Predefined all-MaxValue matrix
        /// </summary>
        readonly public static float2x4 AllMaxValue  =  float2x4(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);
        
        /// <summary>
        /// Predefined diagonal-MaxValue matrix
        /// </summary>
        readonly public static float2x4 DiagonalMaxValue  =  float2x4(float.MaxValue, 0f, 0f, 0f, 0f, float.MaxValue, 0f, 0f);
        
        /// <summary>
        /// Predefined all-MinValue matrix
        /// </summary>
        readonly public static float2x4 AllMinValue  =  float2x4(float.MinValue, float.MinValue, float.MinValue, float.MinValue, float.MinValue, float.MinValue, float.MinValue, float.MinValue);
        
        /// <summary>
        /// Predefined diagonal-MinValue matrix
        /// </summary>
        readonly public static float2x4 DiagonalMinValue  =  float2x4(float.MinValue, 0f, 0f, 0f, 0f, float.MinValue, 0f, 0f);
        
        /// <summary>
        /// Predefined all-Epsilon matrix
        /// </summary>
        readonly public static float2x4 AllEpsilon  =  float2x4(float.Epsilon, float.Epsilon, float.Epsilon, float.Epsilon, float.Epsilon, float.Epsilon, float.Epsilon, float.Epsilon);
        
        /// <summary>
        /// Predefined diagonal-Epsilon matrix
        /// </summary>
        readonly public static float2x4 DiagonalEpsilon  =  float2x4(float.Epsilon, 0f, 0f, 0f, 0f, float.Epsilon, 0f, 0f);
        
        /// <summary>
        /// Predefined all-NaN matrix
        /// </summary>
        readonly public static float2x4 AllNaN  =  float2x4(float.NaN, float.NaN, float.NaN, float.NaN, float.NaN, float.NaN, float.NaN, float.NaN);
        
        /// <summary>
        /// Predefined diagonal-NaN matrix
        /// </summary>
        readonly public static float2x4 DiagonalNaN  =  float2x4(float.NaN, 0f, 0f, 0f, 0f, float.NaN, 0f, 0f);
        
        /// <summary>
        /// Predefined all-NegativeInfinity matrix
        /// </summary>
        readonly public static float2x4 AllNegativeInfinity  =  float2x4(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
        
        /// <summary>
        /// Predefined diagonal-NegativeInfinity matrix
        /// </summary>
        readonly public static float2x4 DiagonalNegativeInfinity  =  float2x4(float.NegativeInfinity, 0f, 0f, 0f, 0f, float.NegativeInfinity, 0f, 0f);
        
        /// <summary>
        /// Predefined all-PositiveInfinity matrix
        /// </summary>
        readonly public static float2x4 AllPositiveInfinity  =  float2x4(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        
        /// <summary>
        /// Predefined diagonal-PositiveInfinity matrix
        /// </summary>
        readonly public static float2x4 DiagonalPositiveInfinity  =  float2x4(float.PositiveInfinity, 0f, 0f, 0f, 0f, float.PositiveInfinity, 0f, 0f);

        //#endregion


        //#region Functions
        
        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public float[,] ToArray() => new .[,] ( ( m00, m01, m02, m03 ), ( m10, m11, m12, m13 ) );
        
        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public float[] ToArray1D() => new .[] ( m00, m01, m02, m03, m10, m11, m12, m13 );

        //#endregion

        
        /// <summary>
        /// Returns the number of Fields (2 x 4 = 8).
        /// </summary>
        public int Count => 8;
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public float this[int fieldIndex]
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
        public float this[int col, int row]
        {
            [Inline]get
            {
                System.Diagnostics.Debug.Assert(col >= 0 && col < 2, "col was out of range");
                System.Diagnostics.Debug.Assert(row >= 0 && row < 4, "row was out of range");
                unchecked { return values[col * 4 + row]; }
            }
            [Inline]set mut
            {
                System.Diagnostics.Debug.Assert(col >= 0 && col < 2, "col was out of range");
                System.Diagnostics.Debug.Assert(row >= 0 && row < 4, "row was out of range");
                unchecked { values[col * 4 + row] = value; }
            }
        }
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public bool Equals(float2x4 rhs) => (((m00 == rhs.m00 && m01 == rhs.m01) && (m02 == rhs.m02 && m03 == rhs.m03)) && ((m10 == rhs.m10 && m11 == rhs.m11) && (m12 == rhs.m12 && m13 == rhs.m13)));
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(float2x4 lhs, float2x4 rhs) => lhs.Equals(rhs);
        
        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(float2x4 lhs, float2x4 rhs) => !lhs.Equals(rhs);
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public int GetHashCode()
        {
            unchecked
            {
                return ((((((((((((((m00.GetHashCode()) * 397) ^ m01.GetHashCode()) * 397) ^ m02.GetHashCode()) * 397) ^ m03.GetHashCode()) * 397) ^ m10.GetHashCode()) * 397) ^ m11.GetHashCode()) * 397) ^ m12.GetHashCode()) * 397) ^ m13.GetHashCode();
            }
        }
        
        /// <summary>
        /// Returns a transposed version of this matrix.
        /// </summary>
        public float4x2 Transposed => float4x2(m00, m10, m01, m11, m02, m12, m03, m13);
        
        /// <summary>
        /// Returns the minimal component of this matrix.
        /// </summary>
        public float MinElement => System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(System.Math.Min(m00, m01), m02), m03), m10), m11), m12), m13);
        
        /// <summary>
        /// Returns the maximal component of this matrix.
        /// </summary>
        public float MaxElement => System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(m00, m01), m02), m03), m10), m11), m12), m13);
        
        /// <summary>
        /// Returns the euclidean length of this matrix.
        /// </summary>
        public float Length => (float)System.Math.Sqrt((((m00*m00 + m01*m01) + (m02*m02 + m03*m03)) + ((m10*m10 + m11*m11) + (m12*m12 + m13*m13))));
        
        /// <summary>
        /// Returns the squared euclidean length of this matrix.
        /// </summary>
        public float LengthSqr => (((m00*m00 + m01*m01) + (m02*m02 + m03*m03)) + ((m10*m10 + m11*m11) + (m12*m12 + m13*m13)));
        
        /// <summary>
        /// Returns the sum of all fields.
        /// </summary>
        public float Sum => (((m00 + m01) + (m02 + m03)) + ((m10 + m11) + (m12 + m13)));
        
        /// <summary>
        /// Returns the euclidean norm of this matrix.
        /// </summary>
        public float Norm => (float)System.Math.Sqrt((((m00*m00 + m01*m01) + (m02*m02 + m03*m03)) + ((m10*m10 + m11*m11) + (m12*m12 + m13*m13))));
        
        /// <summary>
        /// Returns the one-norm of this matrix.
        /// </summary>
        public float Norm1 => (((System.Math.Abs(m00) + System.Math.Abs(m01)) + (System.Math.Abs(m02) + System.Math.Abs(m03))) + ((System.Math.Abs(m10) + System.Math.Abs(m11)) + (System.Math.Abs(m12) + System.Math.Abs(m13))));
        
        /// <summary>
        /// Returns the two-norm of this matrix.
        /// </summary>
        public float Norm2 => (float)System.Math.Sqrt((((m00*m00 + m01*m01) + (m02*m02 + m03*m03)) + ((m10*m10 + m11*m11) + (m12*m12 + m13*m13))));
        
        /// <summary>
        /// Returns the max-norm of this matrix.
        /// </summary>
        public float NormMax => System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Max(System.Math.Abs(m00), System.Math.Abs(m01)), System.Math.Abs(m02)), System.Math.Abs(m03)), System.Math.Abs(m10)), System.Math.Abs(m11)), System.Math.Abs(m12)), System.Math.Abs(m13));
        
        /// <summary>
        /// Returns the p-norm of this matrix.
        /// </summary>
        public double NormP(double p) => System.Math.Pow((((System.Math.Pow((double)System.Math.Abs(m00), p) + System.Math.Pow((double)System.Math.Abs(m01), p)) + (System.Math.Pow((double)System.Math.Abs(m02), p) + System.Math.Pow((double)System.Math.Abs(m03), p))) + ((System.Math.Pow((double)System.Math.Abs(m10), p) + System.Math.Pow((double)System.Math.Abs(m11), p)) + (System.Math.Pow((double)System.Math.Abs(m12), p) + System.Math.Pow((double)System.Math.Abs(m13), p)))), 1 / p);
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication float2x4 * float2x2 -> float2x4.
        /// </summary>
        public static float2x4 operator*(float2x4 lhs, float2x2 rhs) => float2x4((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01), (lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01), (lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01), (lhs.m03 * rhs.m00 + lhs.m13 * rhs.m01), (lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11), (lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11), (lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11), (lhs.m03 * rhs.m10 + lhs.m13 * rhs.m11));
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication float2x4 * float3x2 -> float3x4.
        /// </summary>
        public static float3x4 operator*(float2x4 lhs, float3x2 rhs) => float3x4((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01), (lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01), (lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01), (lhs.m03 * rhs.m00 + lhs.m13 * rhs.m01), (lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11), (lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11), (lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11), (lhs.m03 * rhs.m10 + lhs.m13 * rhs.m11), (lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21), (lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21), (lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21), (lhs.m03 * rhs.m20 + lhs.m13 * rhs.m21));
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication float2x4 * float4x2 -> float4x4.
        /// </summary>
        public static float4x4 operator*(float2x4 lhs, float4x2 rhs) => float4x4((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01), (lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01), (lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01), (lhs.m03 * rhs.m00 + lhs.m13 * rhs.m01), (lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11), (lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11), (lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11), (lhs.m03 * rhs.m10 + lhs.m13 * rhs.m11), (lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21), (lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21), (lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21), (lhs.m03 * rhs.m20 + lhs.m13 * rhs.m21), (lhs.m00 * rhs.m30 + lhs.m10 * rhs.m31), (lhs.m01 * rhs.m30 + lhs.m11 * rhs.m31), (lhs.m02 * rhs.m30 + lhs.m12 * rhs.m31), (lhs.m03 * rhs.m30 + lhs.m13 * rhs.m31));
        
        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static float4 operator*(float2x4 m, float2 v) => float4((m.m00 * v.x + m.m10 * v.y), (m.m01 * v.x + m.m11 * v.y), (m.m02 * v.x + m.m12 * v.y), (m.m03 * v.x + m.m13 * v.y));
        
        /// <summary>
        /// Executes a component-wise * (multiply).
        /// </summary>
        public static float2x4 CompMul(float2x4 A, float2x4 B) => float2x4(A.m00 * B.m00, A.m01 * B.m01, A.m02 * B.m02, A.m03 * B.m03, A.m10 * B.m10, A.m11 * B.m11, A.m12 * B.m12, A.m13 * B.m13);
        
        /// <summary>
        /// Executes a component-wise / (divide).
        /// </summary>
        public static float2x4 CompDiv(float2x4 A, float2x4 B) => float2x4(A.m00 / B.m00, A.m01 / B.m01, A.m02 / B.m02, A.m03 / B.m03, A.m10 / B.m10, A.m11 / B.m11, A.m12 / B.m12, A.m13 / B.m13);
        
        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static float2x4 CompAdd(float2x4 A, float2x4 B) => float2x4(A.m00 + B.m00, A.m01 + B.m01, A.m02 + B.m02, A.m03 + B.m03, A.m10 + B.m10, A.m11 + B.m11, A.m12 + B.m12, A.m13 + B.m13);
        
        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static float2x4 CompSub(float2x4 A, float2x4 B) => float2x4(A.m00 - B.m00, A.m01 - B.m01, A.m02 - B.m02, A.m03 - B.m03, A.m10 - B.m10, A.m11 - B.m11, A.m12 - B.m12, A.m13 - B.m13);
        
        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static float2x4 operator+(float2x4 lhs, float2x4 rhs) => float2x4(lhs.m00 + rhs.m00, lhs.m01 + rhs.m01, lhs.m02 + rhs.m02, lhs.m03 + rhs.m03, lhs.m10 + rhs.m10, lhs.m11 + rhs.m11, lhs.m12 + rhs.m12, lhs.m13 + rhs.m13);
        
        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static float2x4 operator+(float2x4 lhs, float rhs) => float2x4(lhs.m00 + rhs, lhs.m01 + rhs, lhs.m02 + rhs, lhs.m03 + rhs, lhs.m10 + rhs, lhs.m11 + rhs, lhs.m12 + rhs, lhs.m13 + rhs);
        
        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static float2x4 operator+(float lhs, float2x4 rhs) => float2x4(lhs + rhs.m00, lhs + rhs.m01, lhs + rhs.m02, lhs + rhs.m03, lhs + rhs.m10, lhs + rhs.m11, lhs + rhs.m12, lhs + rhs.m13);
        
        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static float2x4 operator-(float2x4 lhs, float2x4 rhs) => float2x4(lhs.m00 - rhs.m00, lhs.m01 - rhs.m01, lhs.m02 - rhs.m02, lhs.m03 - rhs.m03, lhs.m10 - rhs.m10, lhs.m11 - rhs.m11, lhs.m12 - rhs.m12, lhs.m13 - rhs.m13);
        
        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static float2x4 operator-(float2x4 lhs, float rhs) => float2x4(lhs.m00 - rhs, lhs.m01 - rhs, lhs.m02 - rhs, lhs.m03 - rhs, lhs.m10 - rhs, lhs.m11 - rhs, lhs.m12 - rhs, lhs.m13 - rhs);
        
        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static float2x4 operator-(float lhs, float2x4 rhs) => float2x4(lhs - rhs.m00, lhs - rhs.m01, lhs - rhs.m02, lhs - rhs.m03, lhs - rhs.m10, lhs - rhs.m11, lhs - rhs.m12, lhs - rhs.m13);
        
        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static float2x4 operator/(float2x4 lhs, float rhs) => float2x4(lhs.m00 / rhs, lhs.m01 / rhs, lhs.m02 / rhs, lhs.m03 / rhs, lhs.m10 / rhs, lhs.m11 / rhs, lhs.m12 / rhs, lhs.m13 / rhs);
        
        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static float2x4 operator/(float lhs, float2x4 rhs) => float2x4(lhs / rhs.m00, lhs / rhs.m01, lhs / rhs.m02, lhs / rhs.m03, lhs / rhs.m10, lhs / rhs.m11, lhs / rhs.m12, lhs / rhs.m13);
        
        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static float2x4 operator*(float2x4 lhs, float rhs) => float2x4(lhs.m00 * rhs, lhs.m01 * rhs, lhs.m02 * rhs, lhs.m03 * rhs, lhs.m10 * rhs, lhs.m11 * rhs, lhs.m12 * rhs, lhs.m13 * rhs);
        
        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static float2x4 operator*(float lhs, float2x4 rhs) => float2x4(lhs * rhs.m00, lhs * rhs.m01, lhs * rhs.m02, lhs * rhs.m03, lhs * rhs.m10, lhs * rhs.m11, lhs * rhs.m12, lhs * rhs.m13);
        
        /// <summary>
        /// Executes a component-wise lesser-than comparison.
        /// </summary>
        public static bool2x4 operator<(float2x4 lhs, float2x4 rhs) => bool2x4(lhs.m00 < rhs.m00, lhs.m01 < rhs.m01, lhs.m02 < rhs.m02, lhs.m03 < rhs.m03, lhs.m10 < rhs.m10, lhs.m11 < rhs.m11, lhs.m12 < rhs.m12, lhs.m13 < rhs.m13);
        
        /// <summary>
        /// Executes a component-wise lesser-than comparison with a scalar.
        /// </summary>
        public static bool2x4 operator<(float2x4 lhs, float rhs) => bool2x4(lhs.m00 < rhs, lhs.m01 < rhs, lhs.m02 < rhs, lhs.m03 < rhs, lhs.m10 < rhs, lhs.m11 < rhs, lhs.m12 < rhs, lhs.m13 < rhs);
        
        /// <summary>
        /// Executes a component-wise lesser-than comparison with a scalar.
        /// </summary>
        public static bool2x4 operator<(float lhs, float2x4 rhs) => bool2x4(lhs < rhs.m00, lhs < rhs.m01, lhs < rhs.m02, lhs < rhs.m03, lhs < rhs.m10, lhs < rhs.m11, lhs < rhs.m12, lhs < rhs.m13);
        
        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison.
        /// </summary>
        public static bool2x4 operator<=(float2x4 lhs, float2x4 rhs) => bool2x4(lhs.m00 <= rhs.m00, lhs.m01 <= rhs.m01, lhs.m02 <= rhs.m02, lhs.m03 <= rhs.m03, lhs.m10 <= rhs.m10, lhs.m11 <= rhs.m11, lhs.m12 <= rhs.m12, lhs.m13 <= rhs.m13);
        
        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison with a scalar.
        /// </summary>
        public static bool2x4 operator<=(float2x4 lhs, float rhs) => bool2x4(lhs.m00 <= rhs, lhs.m01 <= rhs, lhs.m02 <= rhs, lhs.m03 <= rhs, lhs.m10 <= rhs, lhs.m11 <= rhs, lhs.m12 <= rhs, lhs.m13 <= rhs);
        
        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison with a scalar.
        /// </summary>
        public static bool2x4 operator<=(float lhs, float2x4 rhs) => bool2x4(lhs <= rhs.m00, lhs <= rhs.m01, lhs <= rhs.m02, lhs <= rhs.m03, lhs <= rhs.m10, lhs <= rhs.m11, lhs <= rhs.m12, lhs <= rhs.m13);
        
        /// <summary>
        /// Executes a component-wise greater-than comparison.
        /// </summary>
        public static bool2x4 operator>(float2x4 lhs, float2x4 rhs) => bool2x4(lhs.m00 > rhs.m00, lhs.m01 > rhs.m01, lhs.m02 > rhs.m02, lhs.m03 > rhs.m03, lhs.m10 > rhs.m10, lhs.m11 > rhs.m11, lhs.m12 > rhs.m12, lhs.m13 > rhs.m13);
        
        /// <summary>
        /// Executes a component-wise greater-than comparison with a scalar.
        /// </summary>
        public static bool2x4 operator>(float2x4 lhs, float rhs) => bool2x4(lhs.m00 > rhs, lhs.m01 > rhs, lhs.m02 > rhs, lhs.m03 > rhs, lhs.m10 > rhs, lhs.m11 > rhs, lhs.m12 > rhs, lhs.m13 > rhs);
        
        /// <summary>
        /// Executes a component-wise greater-than comparison with a scalar.
        /// </summary>
        public static bool2x4 operator>(float lhs, float2x4 rhs) => bool2x4(lhs > rhs.m00, lhs > rhs.m01, lhs > rhs.m02, lhs > rhs.m03, lhs > rhs.m10, lhs > rhs.m11, lhs > rhs.m12, lhs > rhs.m13);
        
        /// <summary>
        /// Executes a component-wise greater-or-equal comparison.
        /// </summary>
        public static bool2x4 operator>=(float2x4 lhs, float2x4 rhs) => bool2x4(lhs.m00 >= rhs.m00, lhs.m01 >= rhs.m01, lhs.m02 >= rhs.m02, lhs.m03 >= rhs.m03, lhs.m10 >= rhs.m10, lhs.m11 >= rhs.m11, lhs.m12 >= rhs.m12, lhs.m13 >= rhs.m13);
        
        /// <summary>
        /// Executes a component-wise greater-or-equal comparison with a scalar.
        /// </summary>
        public static bool2x4 operator>=(float2x4 lhs, float rhs) => bool2x4(lhs.m00 >= rhs, lhs.m01 >= rhs, lhs.m02 >= rhs, lhs.m03 >= rhs, lhs.m10 >= rhs, lhs.m11 >= rhs, lhs.m12 >= rhs, lhs.m13 >= rhs);
        
        /// <summary>
        /// Executes a component-wise greater-or-equal comparison with a scalar.
        /// </summary>
        public static bool2x4 operator>=(float lhs, float2x4 rhs) => bool2x4(lhs >= rhs.m00, lhs >= rhs.m01, lhs >= rhs.m02, lhs >= rhs.m03, lhs >= rhs.m10, lhs >= rhs.m11, lhs >= rhs.m12, lhs >= rhs.m13);
    }
}
