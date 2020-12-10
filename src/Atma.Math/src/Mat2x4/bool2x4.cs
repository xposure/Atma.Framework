using System;
namespace Atma
{
    
    /// <summary>
    /// A matrix of type bool with 2 columns and 4 rows.
    /// </summary>
    public struct bool2x4 : IEquatable<bool2x4>
    {

        //#region Fields
        
        /// <summary>
        /// component data
        /// </summary>
        public bool[8] values;

        //#endregion


        //#region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public this(bool m00, bool m01, bool m02, bool m03, bool m10, bool m11, bool m12, bool m13)
        {
            values = .(m00,m01,m02,m03,m10,m11,m12,m13);
        }
        
        /// <summary>
        /// Constructs this matrix from a bool2x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool2x2 m)
        {
            values = .(m.m00,m.m01,false,false,m.m10,m.m11,false,false);
        }
        
        /// <summary>
        /// Constructs this matrix from a bool3x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool3x2 m)
        {
            values = .(m.m00,m.m01,false,false,m.m10,m.m11,false,false);
        }
        
        /// <summary>
        /// Constructs this matrix from a bool4x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool4x2 m)
        {
            values = .(m.m00,m.m01,false,false,m.m10,m.m11,false,false);
        }
        
        /// <summary>
        /// Constructs this matrix from a bool2x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool2x3 m)
        {
            values = .(m.m00,m.m01,m.m02,false,m.m10,m.m11,m.m12,false);
        }
        
        /// <summary>
        /// Constructs this matrix from a bool3x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool3x3 m)
        {
            values = .(m.m00,m.m01,m.m02,false,m.m10,m.m11,m.m12,false);
        }
        
        /// <summary>
        /// Constructs this matrix from a bool4x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool4x3 m)
        {
            values = .(m.m00,m.m01,m.m02,false,m.m10,m.m11,m.m12,false);
        }
        
        /// <summary>
        /// Constructs this matrix from a bool2x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool2x4 m)
        {
            values = .(m.m00,m.m01,m.m02,m.m03,m.m10,m.m11,m.m12,m.m13);
        }
        
        /// <summary>
        /// Constructs this matrix from a bool3x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool3x4 m)
        {
            values = .(m.m00,m.m01,m.m02,m.m03,m.m10,m.m11,m.m12,m.m13);
        }
        
        /// <summary>
        /// Constructs this matrix from a bool4x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool4x4 m)
        {
            values = .(m.m00,m.m01,m.m02,m.m03,m.m10,m.m11,m.m12,m.m13);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool2 c0, bool2 c1)
        {
            values = .(c0.x,c0.y,false,false,c1.x,c1.y,false,false);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool3 c0, bool3 c1)
        {
            values = .(c0.x,c0.y,c0.z,false,c1.x,c1.y,c1.z,false);
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public this(bool4 c0, bool4 c1)
        {
            values = .(c0.x,c0.y,c0.z,c0.w,c1.x,c1.y,c1.z,c1.w);
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
        /// Gets or sets the row nr 0
        /// </summary>
        public bool2 Row0
        {
            [Inline]get
            {
                return  bool2(m00, m10);
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
        public bool2 Row1
        {
            [Inline]get
            {
                return  bool2(m01, m11);
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
        public bool2 Row2
        {
            [Inline]get
            {
                return  bool2(m02, m12);
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
        public bool2 Row3
        {
            [Inline]get
            {
                return  bool2(m03, m13);
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
        readonly public static bool2x4 Zero  =  bool2x4(false, false, false, false, false, false, false, false);
        
        /// <summary>
        /// Predefined all-ones matrix
        /// </summary>
        readonly public static bool2x4 Ones  =  bool2x4(true, true, true, true, true, true, true, true);
        
        /// <summary>
        /// Predefined identity matrix
        /// </summary>
        readonly public static bool2x4 Identity  =  bool2x4(true, false, false, false, false, true, false, false);

        //#endregion


        //#region Functions
        
        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public bool[,] ToArray() => new .[,] ( ( m00, m01, m02, m03 ), ( m10, m11, m12, m13 ) );
        
        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public bool[] ToArray1D() => new .[] ( m00, m01, m02, m03, m10, m11, m12, m13 );

        //#endregion

        
        /// <summary>
        /// Returns the number of Fields (2 x 4 = 8).
        /// </summary>
        public int Count => 8;
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public bool this[int fieldIndex]
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
        public bool this[int col, int row]
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
        public bool Equals(bool2x4 rhs) => (((m00 == rhs.m00 && m01 == rhs.m01) && (m02 == rhs.m02 && m03 == rhs.m03)) && ((m10 == rhs.m10 && m11 == rhs.m11) && (m12 == rhs.m12 && m13 == rhs.m13)));
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(bool2x4 lhs, bool2x4 rhs) => lhs.Equals(rhs);
        
        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(bool2x4 lhs, bool2x4 rhs) => !lhs.Equals(rhs);
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public int GetHashCode()
        {
            unchecked
            {
                return ((((((((((((((m00.GetHashCode()) * 2) ^ m01.GetHashCode()) * 2) ^ m02.GetHashCode()) * 2) ^ m03.GetHashCode()) * 2) ^ m10.GetHashCode()) * 2) ^ m11.GetHashCode()) * 2) ^ m12.GetHashCode()) * 2) ^ m13.GetHashCode();
            }
        }
        
        /// <summary>
        /// Returns a transposed version of this matrix.
        /// </summary>
        public bool4x2 Transposed => bool4x2(m00, m10, m01, m11, m02, m12, m03, m13);
        
        /// <summary>
        /// Returns the minimal component of this matrix.
        /// </summary>
        public bool MinElement => (((m00 && m01) && (m02 && m03)) && ((m10 && m11) && (m12 && m13)));
        
        /// <summary>
        /// Returns the maximal component of this matrix.
        /// </summary>
        public bool MaxElement => (((m00 || m01) || (m02 || m03)) || ((m10 || m11) || (m12 || m13)));
        
        /// <summary>
        /// Returns true if all component are true.
        /// </summary>
        public bool All => (((m00 && m01) && (m02 && m03)) && ((m10 && m11) && (m12 && m13)));
        
        /// <summary>
        /// Returns true if any component is true.
        /// </summary>
        public bool Any => (((m00 || m01) || (m02 || m03)) || ((m10 || m11) || (m12 || m13)));
        
        /// <summary>
        /// Executes a component-wise &amp;&amp;. (sorry for different overload but &amp;&amp; cannot be overloaded directly)
        /// </summary>
        public static bool2x4 operator&(bool2x4 lhs, bool2x4 rhs) => bool2x4(lhs.m00 && rhs.m00, lhs.m01 && rhs.m01, lhs.m02 && rhs.m02, lhs.m03 && rhs.m03, lhs.m10 && rhs.m10, lhs.m11 && rhs.m11, lhs.m12 && rhs.m12, lhs.m13 && rhs.m13);
        
        /// <summary>
        /// Executes a component-wise ||. (sorry for different overload but || cannot be overloaded directly)
        /// </summary>
        public static bool2x4 operator|(bool2x4 lhs, bool2x4 rhs) => bool2x4(lhs.m00 || rhs.m00, lhs.m01 || rhs.m01, lhs.m02 || rhs.m02, lhs.m03 || rhs.m03, lhs.m10 || rhs.m10, lhs.m11 || rhs.m11, lhs.m12 || rhs.m12, lhs.m13 || rhs.m13);
    }
}
