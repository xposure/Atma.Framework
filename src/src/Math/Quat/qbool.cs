using System;
namespace Atma
{
    
    /// <summary>
    /// A quaternion of type bool.
    /// </summary>
    public struct qbool : IEquatable<qbool>
    {

        //#region Fields
        
        /// <summary>
        /// component data
        /// </summary>
        public bool[4] values;

        //#endregion


        //#region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public this(bool x, bool y, bool z, bool w)
        {
            values = .(x,y,z,w);
        }
        
        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public this(bool v)
        {
            values = .(v,v,v,v);
        }
        
        /// <summary>
        /// copy constructor
        /// </summary>
        public this(qbool q)
        {
            values = .(q.x,q.y,q.z,q.w);
        }
        
        /// <summary>
        /// vector-and-scalar constructor (CAUTION: not angle-axis, use FromAngleAxis instead)
        /// </summary>
        public this(bool3 v, bool s)
        {
            values = .(v.x,v.y,v.z,s);
        }

        //#endregion


        //#region Explicit Operators
        
        /// <summary>
        /// Explicitly converts this to a int4.
        /// </summary>
        public static explicit operator int4(qbool v) =>  int4(v.x ? 1 : 0, v.y ? 1 : 0, v.z ? 1 : 0, v.w ? 1 : 0);
        
        /// <summary>
        /// Explicitly converts this to a qint.
        /// </summary>
        public static explicit operator qint(qbool v) =>  qint(v.x ? 1 : 0, v.y ? 1 : 0, v.z ? 1 : 0, v.w ? 1 : 0);
        
        /// <summary>
        /// Explicitly converts this to a uint4.
        /// </summary>
        public static explicit operator uint4(qbool v) =>  uint4(v.x ? 1u : 0u, v.y ? 1u : 0u, v.z ? 1u : 0u, v.w ? 1u : 0u);
        
        /// <summary>
        /// Explicitly converts this to a quint.
        /// </summary>
        public static explicit operator quint(qbool v) =>  quint(v.x ? 1u : 0u, v.y ? 1u : 0u, v.z ? 1u : 0u, v.w ? 1u : 0u);
        
        /// <summary>
        /// Explicitly converts this to a float4.
        /// </summary>
        public static explicit operator float4(qbool v) =>  float4(v.x ? 1f : 0f, v.y ? 1f : 0f, v.z ? 1f : 0f, v.w ? 1f : 0f);
        
        /// <summary>
        /// Explicitly converts this to a qfloat.
        /// </summary>
        public static explicit operator qfloat(qbool v) =>  qfloat(v.x ? 1f : 0f, v.y ? 1f : 0f, v.z ? 1f : 0f, v.w ? 1f : 0f);
        
        /// <summary>
        /// Explicitly converts this to a double4.
        /// </summary>
        public static explicit operator double4(qbool v) =>  double4(v.x ? 1.0 : 0.0, v.y ? 1.0 : 0.0, v.z ? 1.0 : 0.0, v.w ? 1.0 : 0.0);
        
        /// <summary>
        /// Explicitly converts this to a qdouble.
        /// </summary>
        public static explicit operator qdouble(qbool v) =>  qdouble(v.x ? 1.0 : 0.0, v.y ? 1.0 : 0.0, v.z ? 1.0 : 0.0, v.w ? 1.0 : 0.0);
        
        /// <summary>
        /// Explicitly converts this to a long4.
        /// </summary>
        public static explicit operator long4(qbool v) =>  long4(v.x ? 1 : 0, v.y ? 1 : 0, v.z ? 1 : 0, v.w ? 1 : 0);
        
        /// <summary>
        /// Explicitly converts this to a qlong.
        /// </summary>
        public static explicit operator qlong(qbool v) =>  qlong(v.x ? 1 : 0, v.y ? 1 : 0, v.z ? 1 : 0, v.w ? 1 : 0);
        
        /// <summary>
        /// Explicitly converts this to a bool4.
        /// </summary>
        public static explicit operator bool4(qbool v) =>  bool4((bool)v.x, (bool)v.y, (bool)v.z, (bool)v.w);

        //#endregion


        //#region Indexer
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public bool this[int index]
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
        public bool x
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
        public bool y
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
        public bool z
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
        public bool w
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
        /// Returns the number of components (4).
        /// </summary>
        public int Count => 4;
        
        /// <summary>
        /// Returns the minimal component of this quaternion.
        /// </summary>
        public bool MinElement => ((x && y) && (z && w));
        
        /// <summary>
        /// Returns the maximal component of this quaternion.
        /// </summary>
        public bool MaxElement => ((x || y) || (z || w));
        
        /// <summary>
        /// Returns true if all component are true.
        /// </summary>
        public bool All => ((x && y) && (z && w));
        
        /// <summary>
        /// Returns true if any component is true.
        /// </summary>
        public bool Any => ((x || y) || (z || w));

        //#endregion


        //#region Static Properties
        
        /// <summary>
        /// Predefined all-zero quaternion
        /// </summary>
        readonly public static qbool Zero  =  qbool(false, false, false, false);
        
        /// <summary>
        /// Predefined all-ones quaternion
        /// </summary>
        readonly public static qbool Ones  =  qbool(true, true, true, true);
        
        /// <summary>
        /// Predefined identity quaternion
        /// </summary>
        readonly public static qbool Identity  =  qbool(false, false, false, true);
        
        /// <summary>
        /// Predefined unit-X quaternion
        /// </summary>
        readonly public static qbool UnitX  =  qbool(true, false, false, false);
        
        /// <summary>
        /// Predefined unit-Y quaternion
        /// </summary>
        readonly public static qbool UnitY  =  qbool(false, true, false, false);
        
        /// <summary>
        /// Predefined unit-Z quaternion
        /// </summary>
        readonly public static qbool UnitZ  =  qbool(false, false, true, false);
        
        /// <summary>
        /// Predefined unit-W quaternion
        /// </summary>
        readonly public static qbool UnitW  =  qbool(false, false, false, true);

        //#endregion


        //#region Operators
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator==(qbool lhs, qbool rhs) => lhs.Equals(rhs);
        
        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator!=(qbool lhs, qbool rhs) => !lhs.Equals(rhs);

        //#endregion


        //#region Functions
        
        /// <summary>
        /// Returns an array with all values
        /// </summary>
        public bool[] ToArray() => new .[] ( x, y, z, w );
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public bool Equals(qbool rhs) => ((x == rhs.x && y == rhs.y) && (z == rhs.z && w == rhs.w));
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public int GetHashCode()
        {
            unchecked
            {
                return ((((((x.GetHashCode()) * 2) ^ y.GetHashCode()) * 2) ^ z.GetHashCode()) * 2) ^ w.GetHashCode();
            }
        }

        //#endregion


        //#region Component-Wise Static Functions
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(qbool lhs, qbool rhs) => bool4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(qbool lhs, bool rhs) => bool4(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs, lhs.w == rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(bool lhs, qbool rhs) => bool4(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z, lhs == rhs.w);
        
        /// <summary>
        /// Returns a bool from the application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(bool lhs, bool rhs) => bool4(lhs == rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(qbool lhs, qbool rhs) => bool4(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(qbool lhs, bool rhs) => bool4(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs, lhs.w != rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(bool lhs, qbool rhs) => bool4(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z, lhs != rhs.w);
        
        /// <summary>
        /// Returns a bool from the application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(bool lhs, bool rhs) => bool4(lhs != rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Not (!v).
        /// </summary>
        public static bool4 Not(qbool v) => bool4(!v.x, !v.y, !v.z, !v.w);
        
        /// <summary>
        /// Returns a bool from the application of Not (!v).
        /// </summary>
        public static bool4 Not(bool v) => bool4(!v);
        
        /// <summary>
        /// Returns a qbool from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static qbool And(qbool lhs, qbool rhs) => qbool(lhs.x && rhs.x, lhs.y && rhs.y, lhs.z && rhs.z, lhs.w && rhs.w);
        
        /// <summary>
        /// Returns a qbool from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static qbool And(qbool lhs, bool rhs) => qbool(lhs.x && rhs, lhs.y && rhs, lhs.z && rhs, lhs.w && rhs);
        
        /// <summary>
        /// Returns a qbool from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static qbool And(bool lhs, qbool rhs) => qbool(lhs && rhs.x, lhs && rhs.y, lhs && rhs.z, lhs && rhs.w);
        
        /// <summary>
        /// Returns a qbool from the application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static qbool And(bool lhs, bool rhs) => qbool(lhs && rhs);
        
        /// <summary>
        /// Returns a qbool from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static qbool Nand(qbool lhs, qbool rhs) => qbool(!(lhs.x && rhs.x), !(lhs.y && rhs.y), !(lhs.z && rhs.z), !(lhs.w && rhs.w));
        
        /// <summary>
        /// Returns a qbool from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static qbool Nand(qbool lhs, bool rhs) => qbool(!(lhs.x && rhs), !(lhs.y && rhs), !(lhs.z && rhs), !(lhs.w && rhs));
        
        /// <summary>
        /// Returns a qbool from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static qbool Nand(bool lhs, qbool rhs) => qbool(!(lhs && rhs.x), !(lhs && rhs.y), !(lhs && rhs.z), !(lhs && rhs.w));
        
        /// <summary>
        /// Returns a qbool from the application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static qbool Nand(bool lhs, bool rhs) => qbool(!(lhs && rhs));
        
        /// <summary>
        /// Returns a qbool from component-wise application of Or (lhs || rhs).
        /// </summary>
        public static qbool Or(qbool lhs, qbool rhs) => qbool(lhs.x || rhs.x, lhs.y || rhs.y, lhs.z || rhs.z, lhs.w || rhs.w);
        
        /// <summary>
        /// Returns a qbool from component-wise application of Or (lhs || rhs).
        /// </summary>
        public static qbool Or(qbool lhs, bool rhs) => qbool(lhs.x || rhs, lhs.y || rhs, lhs.z || rhs, lhs.w || rhs);
        
        /// <summary>
        /// Returns a qbool from component-wise application of Or (lhs || rhs).
        /// </summary>
        public static qbool Or(bool lhs, qbool rhs) => qbool(lhs || rhs.x, lhs || rhs.y, lhs || rhs.z, lhs || rhs.w);
        
        /// <summary>
        /// Returns a qbool from the application of Or (lhs || rhs).
        /// </summary>
        public static qbool Or(bool lhs, bool rhs) => qbool(lhs || rhs);
        
        /// <summary>
        /// Returns a qbool from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        public static qbool Nor(qbool lhs, qbool rhs) => qbool(!(lhs.x || rhs.x), !(lhs.y || rhs.y), !(lhs.z || rhs.z), !(lhs.w || rhs.w));
        
        /// <summary>
        /// Returns a qbool from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        public static qbool Nor(qbool lhs, bool rhs) => qbool(!(lhs.x || rhs), !(lhs.y || rhs), !(lhs.z || rhs), !(lhs.w || rhs));
        
        /// <summary>
        /// Returns a qbool from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        public static qbool Nor(bool lhs, qbool rhs) => qbool(!(lhs || rhs.x), !(lhs || rhs.y), !(lhs || rhs.z), !(lhs || rhs.w));
        
        /// <summary>
        /// Returns a qbool from the application of Nor (!(lhs || rhs)).
        /// </summary>
        public static qbool Nor(bool lhs, bool rhs) => qbool(!(lhs || rhs));
        
        /// <summary>
        /// Returns a qbool from component-wise application of Xor (lhs != rhs).
        /// </summary>
        public static qbool Xor(qbool lhs, qbool rhs) => qbool(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w);
        
        /// <summary>
        /// Returns a qbool from component-wise application of Xor (lhs != rhs).
        /// </summary>
        public static qbool Xor(qbool lhs, bool rhs) => qbool(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs, lhs.w != rhs);
        
        /// <summary>
        /// Returns a qbool from component-wise application of Xor (lhs != rhs).
        /// </summary>
        public static qbool Xor(bool lhs, qbool rhs) => qbool(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z, lhs != rhs.w);
        
        /// <summary>
        /// Returns a qbool from the application of Xor (lhs != rhs).
        /// </summary>
        public static qbool Xor(bool lhs, bool rhs) => qbool(lhs != rhs);
        
        /// <summary>
        /// Returns a qbool from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        public static qbool Xnor(qbool lhs, qbool rhs) => qbool(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);
        
        /// <summary>
        /// Returns a qbool from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        public static qbool Xnor(qbool lhs, bool rhs) => qbool(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs, lhs.w == rhs);
        
        /// <summary>
        /// Returns a qbool from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        public static qbool Xnor(bool lhs, qbool rhs) => qbool(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z, lhs == rhs.w);
        
        /// <summary>
        /// Returns a qbool from the application of Xnor (lhs == rhs).
        /// </summary>
        public static qbool Xnor(bool lhs, bool rhs) => qbool(lhs == rhs);

        //#endregion


        //#region Component-Wise Operator Overloads
        
        /// <summary>
        /// Returns a qbool from component-wise application of operator! (!v).
        /// </summary>
        public static qbool operator!(qbool v) => qbool(!v.x, !v.y, !v.z, !v.w);
        
        /// <summary>
        /// Returns a qbool from component-wise application of operator&amp; (lhs &amp;&amp; rhs).
        /// </summary>
        public static qbool operator&(qbool lhs, qbool rhs) => qbool(lhs.x && rhs.x, lhs.y && rhs.y, lhs.z && rhs.z, lhs.w && rhs.w);
        
        /// <summary>
        /// Returns a qbool from component-wise application of operator&amp; (lhs &amp;&amp; rhs).
        /// </summary>
        public static qbool operator&(qbool lhs, bool rhs) => qbool(lhs.x && rhs, lhs.y && rhs, lhs.z && rhs, lhs.w && rhs);
        
        /// <summary>
        /// Returns a qbool from component-wise application of operator&amp; (lhs &amp;&amp; rhs).
        /// </summary>
        public static qbool operator&(bool lhs, qbool rhs) => qbool(lhs && rhs.x, lhs && rhs.y, lhs && rhs.z, lhs && rhs.w);
        
        /// <summary>
        /// Returns a qbool from component-wise application of operator| (lhs || rhs).
        /// </summary>
        public static qbool operator|(qbool lhs, qbool rhs) => qbool(lhs.x || rhs.x, lhs.y || rhs.y, lhs.z || rhs.z, lhs.w || rhs.w);
        
        /// <summary>
        /// Returns a qbool from component-wise application of operator| (lhs || rhs).
        /// </summary>
        public static qbool operator|(qbool lhs, bool rhs) => qbool(lhs.x || rhs, lhs.y || rhs, lhs.z || rhs, lhs.w || rhs);
        
        /// <summary>
        /// Returns a qbool from component-wise application of operator| (lhs || rhs).
        /// </summary>
        public static qbool operator|(bool lhs, qbool rhs) => qbool(lhs || rhs.x, lhs || rhs.y, lhs || rhs.z, lhs || rhs.w);

        //#endregion

    }
}
