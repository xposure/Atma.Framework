using System;
namespace Atma
{
    
    /// <summary>
    /// A matrix of type bool with 4 columns and 4 rows.
    /// </summary>
    public struct bool4x4 : IEquatable<bool4x4>
    {

        //#region Fields
        
        /// <summary>
        /// component data
        /// </summary>
        public bool[16] values;

        //#endregion


        //#region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public this(bool m00, bool m01, bool m02, bool m03, bool m10, bool m11, bool m12, bool m13, bool m20, bool m21, bool m22, bool m23, bool m30, bool m31, bool m32, bool m33)
        {
            values = .(m00,m01,m02,m03,m10,m11,m12,m13,m20,m21,m22,m23,m30,m31,m32,m33);
        }
        
        /// <summary>
        /// Constructs this matrix from a bool2x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool2x2 m)
        {
            values = .(m.m00,m.m01,false,false,m.m10,m.m11,false,false,false,false,true,false,false,false,false,true);
        }
        
        /// <summary>
        /// Constructs this matrix from a bool3x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool3x2 m)
        {
            values = .(m.m00,m.m01,false,false,m.m10,m.m11,false,false,m.m20,m.m21,true,false,false,false,false,true);
        }
        
        /// <summary>
        /// Constructs this matrix from a bool4x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool4x2 m)
        {
            values = .(m.m00,m.m01,false,false,m.m10,m.m11,false,false,m.m20,m.m21,true,false,m.m30,m.m31,false,true);
        }
        
        /// <summary>
        /// Constructs this matrix from a bool2x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool2x3 m)
        {
            values = .(m.m00,m.m01,m.m02,false,m.m10,m.m11,m.m12,false,false,false,true,false,false,false,false,true);
        }
        
        /// <summary>
        /// Constructs this matrix from a bool3x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool3x3 m)
        {
            values = .(m.m00,m.m01,m.m02,false,m.m10,m.m11,m.m12,false,m.m20,m.m21,m.m22,false,false,false,false,true);
        }
        
        /// <summary>
        /// Constructs this matrix from a bool4x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool4x3 m)
        {
            values = .(m.m00,m.m01,m.m02,false,m.m10,m.m11,m.m12,false,m.m20,m.m21,m.m22,false,m.m30,m.m31,m.m32,true);
        }
        
        /// <summary>
        /// Constructs this matrix from a bool2x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool2x4 m)
        {
            values = .(m.m00,m.m01,m.m02,m.m03,m.m10,m.m11,m.m12,m.m13,false,false,true,false,false,false,false,true);
        }
        
        /// <summary>
        /// Constructs this matrix from a bool3x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool3x4 m)
        {
            values = .(m.m00,m.m01,m.m02,m.m03,m.m10,m.m11,m.m12,m.m13,m.m20,m.m21,m.m22,m.m23,false,false,false,true);
        }
        
        /// <summary>
        /// Constructs this matrix from a bool4x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool4x4 m)
        {
            values = .(m.m00,m.m01,m.m02,m.m03,m.m10,m.m11,m.m12,m.m13,m.m20,m.m21,m.m22,m.m23,m.m30,m.m31,m.m32,m.m33);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool2 c0, bool2 c1)
        {
            values = .(c0.x,c0.y,false,false,c1.x,c1.y,false,false,false,false,true,false,false,false,false,true);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool2 c0, bool2 c1, bool2 c2)
        {
            values = .(c0.x,c0.y,false,false,c1.x,c1.y,false,false,c2.x,c2.y,true,false,false,false,false,true);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool2 c0, bool2 c1, bool2 c2, bool2 c3)
        {
            values = .(c0.x,c0.y,false,false,c1.x,c1.y,false,false,c2.x,c2.y,true,false,c3.x,c3.y,false,true);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool3 c0, bool3 c1)
        {
            values = .(c0.x,c0.y,c0.z,false,c1.x,c1.y,c1.z,false,false,false,true,false,false,false,false,true);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool3 c0, bool3 c1, bool3 c2)
        {
            values = .(c0.x,c0.y,c0.z,false,c1.x,c1.y,c1.z,false,c2.x,c2.y,c2.z,false,false,false,false,true);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool3 c0, bool3 c1, bool3 c2, bool3 c3)
        {
            values = .(c0.x,c0.y,c0.z,false,c1.x,c1.y,c1.z,false,c2.x,c2.y,c2.z,false,c3.x,c3.y,c3.z,true);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool4 c0, bool4 c1)
        {
            values = .(c0.x,c0.y,c0.z,c0.w,c1.x,c1.y,c1.z,c1.w,false,false,true,false,false,false,false,true);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool4 c0, bool4 c1, bool4 c2)
        {
            values = .(c0.x,c0.y,c0.z,c0.w,c1.x,c1.y,c1.z,c1.w,c2.x,c2.y,c2.z,c2.w,false,false,false,true);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool4 c0, bool4 c1, bool4 c2, bool4 c3)
        {
            values = .(c0.x,c0.y,c0.z,c0.w,c1.x,c1.y,c1.z,c1.w,c2.x,c2.y,c2.z,c2.w,c3.x,c3.y,c3.z,c3.w);
        }

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Column 0, Rows 0
        /// </summary>
        public bool m00
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
        public bool m01
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
        public bool m02
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
        public bool m03
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
        public bool m10
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
        public bool m11
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
        public bool m12
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
        public bool m13
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
        public bool m20
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
        public bool m21
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
        public bool m22
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
        public bool m23
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
        public bool m30
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
        public bool m31
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
        public bool m32
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
        public bool m33
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
        public bool4 Column0
        {
            [Inline]get
            {
                return  bool4(m00, m01, m02, m03);
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
        public bool4 Column1
        {
            [Inline]get
            {
                return  bool4(m10, m11, m12, m13);
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
        public bool4 Column2
        {
            [Inline]get
            {
                return  bool4(m20, m21, m22, m23);
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
        public bool4 Column3
        {
            [Inline]get
            {
                return  bool4(m30, m31, m32, m33);
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
        public bool4 Row0
        {
            [Inline]get
            {
                return  bool4(m00, m10, m20, m30);
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
        public bool4 Row1
        {
            [Inline]get
            {
                return  bool4(m01, m11, m21, m31);
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
        public bool4 Row2
        {
            [Inline]get
            {
                return  bool4(m02, m12, m22, m32);
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
        public bool4 Row3
        {
            [Inline]get
            {
                return  bool4(m03, m13, m23, m33);
            }
            [Inline]set mut
            {
                m03 = value.x;
                m13 = value.y;
                m23 = value.z;
                m33 = value.w;
            }
        }

        //#endregion


        //#region Static Properties
        
        /// <summary>
        /// Predefined all-zero matrix
        /// </summary>
        readonly public static bool4x4 Zero  =  bool4x4(false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false);
        
        /// <summary>
        /// Predefined all-ones matrix
        /// </summary>
        readonly public static bool4x4 Ones  =  bool4x4(true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true);
        
        /// <summary>
        /// Predefined identity matrix
        /// </summary>
        readonly public static bool4x4 Identity  =  bool4x4(true, false, false, false, false, true, false, false, false, false, true, false, false, false, false, true);

        //#endregion


        //#region Functions
        
        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public bool[,] ToArray() => new .[,] ( ( m00, m01, m02, m03 ), ( m10, m11, m12, m13 ), ( m20, m21, m22, m23 ), ( m30, m31, m32, m33 ) );
        
        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public bool[] ToArray1D() => new .[] ( m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33 );

        //#endregion

        
        /// <summary>
        /// Returns the number of Fields (4 x 4 = 16).
        /// </summary>
        public int Count => 16;
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public bool this[int fieldIndex]
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
        public bool this[int col, int row]
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
        public bool Equals(bool4x4 rhs) => ((((m00 == rhs.m00 && m01 == rhs.m01) && (m02 == rhs.m02 && m03 == rhs.m03)) && ((m10 == rhs.m10 && m11 == rhs.m11) && (m12 == rhs.m12 && m13 == rhs.m13))) && (((m20 == rhs.m20 && m21 == rhs.m21) && (m22 == rhs.m22 && m23 == rhs.m23)) && ((m30 == rhs.m30 && m31 == rhs.m31) && (m32 == rhs.m32 && m33 == rhs.m33))));
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(bool4x4 lhs, bool4x4 rhs) => lhs.Equals(rhs);
        
        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(bool4x4 lhs, bool4x4 rhs) => !lhs.Equals(rhs);
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public int GetHashCode()
        {
            unchecked
            {
                return ((((((((((((((((((((((((((((((m00.GetHashCode()) * 2) ^ m01.GetHashCode()) * 2) ^ m02.GetHashCode()) * 2) ^ m03.GetHashCode()) * 2) ^ m10.GetHashCode()) * 2) ^ m11.GetHashCode()) * 2) ^ m12.GetHashCode()) * 2) ^ m13.GetHashCode()) * 2) ^ m20.GetHashCode()) * 2) ^ m21.GetHashCode()) * 2) ^ m22.GetHashCode()) * 2) ^ m23.GetHashCode()) * 2) ^ m30.GetHashCode()) * 2) ^ m31.GetHashCode()) * 2) ^ m32.GetHashCode()) * 2) ^ m33.GetHashCode();
            }
        }
        
        /// <summary>
        /// Returns a transposed version of this matrix.
        /// </summary>
        public bool4x4 Transposed => bool4x4(m00, m10, m20, m30, m01, m11, m21, m31, m02, m12, m22, m32, m03, m13, m23, m33);
        
        /// <summary>
        /// Returns the minimal component of this matrix.
        /// </summary>
        public bool MinElement => ((((m00 && m01) && (m02 && m03)) && ((m10 && m11) && (m12 && m13))) && (((m20 && m21) && (m22 && m23)) && ((m30 && m31) && (m32 && m33))));
        
        /// <summary>
        /// Returns the maximal component of this matrix.
        /// </summary>
        public bool MaxElement => ((((m00 || m01) || (m02 || m03)) || ((m10 || m11) || (m12 || m13))) || (((m20 || m21) || (m22 || m23)) || ((m30 || m31) || (m32 || m33))));
        
        /// <summary>
        /// Returns true if all component are true.
        /// </summary>
        public bool All => ((((m00 && m01) && (m02 && m03)) && ((m10 && m11) && (m12 && m13))) && (((m20 && m21) && (m22 && m23)) && ((m30 && m31) && (m32 && m33))));
        
        /// <summary>
        /// Returns true if any component is true.
        /// </summary>
        public bool Any => ((((m00 || m01) || (m02 || m03)) || ((m10 || m11) || (m12 || m13))) || (((m20 || m21) || (m22 || m23)) || ((m30 || m31) || (m32 || m33))));
        
        /// <summary>
        /// Executes a component-wise &amp;&amp;. (sorry for different overload but &amp;&amp; cannot be overloaded directly)
        /// </summary>
        public static bool4x4 operator&(bool4x4 lhs, bool4x4 rhs) => bool4x4(lhs.m00 && rhs.m00, lhs.m01 && rhs.m01, lhs.m02 && rhs.m02, lhs.m03 && rhs.m03, lhs.m10 && rhs.m10, lhs.m11 && rhs.m11, lhs.m12 && rhs.m12, lhs.m13 && rhs.m13, lhs.m20 && rhs.m20, lhs.m21 && rhs.m21, lhs.m22 && rhs.m22, lhs.m23 && rhs.m23, lhs.m30 && rhs.m30, lhs.m31 && rhs.m31, lhs.m32 && rhs.m32, lhs.m33 && rhs.m33);
        
        /// <summary>
        /// Executes a component-wise ||. (sorry for different overload but || cannot be overloaded directly)
        /// </summary>
        public static bool4x4 operator|(bool4x4 lhs, bool4x4 rhs) => bool4x4(lhs.m00 || rhs.m00, lhs.m01 || rhs.m01, lhs.m02 || rhs.m02, lhs.m03 || rhs.m03, lhs.m10 || rhs.m10, lhs.m11 || rhs.m11, lhs.m12 || rhs.m12, lhs.m13 || rhs.m13, lhs.m20 || rhs.m20, lhs.m21 || rhs.m21, lhs.m22 || rhs.m22, lhs.m23 || rhs.m23, lhs.m30 || rhs.m30, lhs.m31 || rhs.m31, lhs.m32 || rhs.m32, lhs.m33 || rhs.m33);
    }
}
