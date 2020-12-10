using System;
namespace Atma
{
    
    /// <summary>
    /// A vector of type bool with 2 components.
    /// </summary>
    [Union]
    public struct bool2
    {

        //#region Fields
        
        /// <summary>
        /// component data
        /// </summary>
        public bool[2] values;
        
        /// <summary>
        /// Returns an object that can be used for arbitrary swizzling (e.g. swizzle.zy)
        /// </summary>
        public readonly swizzle_bool2 swizzle;

        //#endregion


        //#region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public this(bool x, bool y)
        {
            values = .(x,y);
        }
        
        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public this(bool v)
        {
            values = .(v,v);
        }
        
        /// <summary>
        /// from-vector constructor
        /// </summary>
        public this(bool2 v)
        {
            values = .(v.x,v.y);
        }
        
        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public this(bool3 v)
        {
            values = .(v.x,v.y);
        }
        
        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public this(bool4 v)
        {
            values = .(v.x,v.y);
        }
        
        /// <summary>
        /// From-array constructor (superfluous values are ignored, missing values are zero-filled).
        /// </summary>
        public this(bool[] v)
        {
            let c = v.Count;
            values = .((c < 0) ? false : v[0],(c < 1) ? false : v[1]);
        }
        
        /// <summary>
        /// From-array constructor with base index (superfluous values are ignored, missing values are zero-filled).
        /// </summary>
        public this(bool[] v, int startIndex)
        {
            let c = v.Count;
            values = .((c + startIndex < 0) ? false : v[0 + startIndex],(c + startIndex < 1) ? false : v[1 + startIndex]);
        }

        //#endregion


        //#region Explicit Operators
        
        /// <summary>
        /// Explicitly converts this to a int2.
        /// </summary>
        public static explicit operator int2(bool2 v) =>  int2(v.x ? 1 : 0, v.y ? 1 : 0);
        
        /// <summary>
        /// Explicitly converts this to a int3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator int3(bool2 v) =>  int3(v.x ? 1 : 0, v.y ? 1 : 0, 0);
        
        /// <summary>
        /// Explicitly converts this to a int4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator int4(bool2 v) =>  int4(v.x ? 1 : 0, v.y ? 1 : 0, 0, 0);
        
        /// <summary>
        /// Explicitly converts this to a uint2.
        /// </summary>
        public static explicit operator uint2(bool2 v) =>  uint2(v.x ? 1u : 0u, v.y ? 1u : 0u);
        
        /// <summary>
        /// Explicitly converts this to a uint3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator uint3(bool2 v) =>  uint3(v.x ? 1u : 0u, v.y ? 1u : 0u, 0u);
        
        /// <summary>
        /// Explicitly converts this to a uint4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator uint4(bool2 v) =>  uint4(v.x ? 1u : 0u, v.y ? 1u : 0u, 0u, 0u);
        
        /// <summary>
        /// Explicitly converts this to a float2.
        /// </summary>
        public static explicit operator float2(bool2 v) =>  float2(v.x ? 1f : 0f, v.y ? 1f : 0f);
        
        /// <summary>
        /// Explicitly converts this to a float3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator float3(bool2 v) =>  float3(v.x ? 1f : 0f, v.y ? 1f : 0f, 0f);
        
        /// <summary>
        /// Explicitly converts this to a float4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator float4(bool2 v) =>  float4(v.x ? 1f : 0f, v.y ? 1f : 0f, 0f, 0f);
        
        /// <summary>
        /// Explicitly converts this to a double2.
        /// </summary>
        public static explicit operator double2(bool2 v) =>  double2(v.x ? 1.0 : 0.0, v.y ? 1.0 : 0.0);
        
        /// <summary>
        /// Explicitly converts this to a double3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator double3(bool2 v) =>  double3(v.x ? 1.0 : 0.0, v.y ? 1.0 : 0.0, 0.0);
        
        /// <summary>
        /// Explicitly converts this to a double4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator double4(bool2 v) =>  double4(v.x ? 1.0 : 0.0, v.y ? 1.0 : 0.0, 0.0, 0.0);
        
        /// <summary>
        /// Explicitly converts this to a long2.
        /// </summary>
        public static explicit operator long2(bool2 v) =>  long2(v.x ? 1 : 0, v.y ? 1 : 0);
        
        /// <summary>
        /// Explicitly converts this to a long3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator long3(bool2 v) =>  long3(v.x ? 1 : 0, v.y ? 1 : 0, 0);
        
        /// <summary>
        /// Explicitly converts this to a long4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator long4(bool2 v) =>  long4(v.x ? 1 : 0, v.y ? 1 : 0, 0, 0);
        
        /// <summary>
        /// Explicitly converts this to a bool3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator bool3(bool2 v) =>  bool3((bool)v.x, (bool)v.y, false);
        
        /// <summary>
        /// Explicitly converts this to a bool4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator bool4(bool2 v) =>  bool4((bool)v.x, (bool)v.y, false, false);

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
        /// 0-component
        /// </summary>
        public bool width
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
        /// 1-component
        /// </summary>
        public bool height
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
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool2 xy
        {
            [Inline]get
            {
                return  bool2(x, y);
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
        public bool2 rg
        {
            [Inline]get
            {
                return  bool2(x, y);
            }
            [Inline]set mut
            {
                x = value.x;
                y = value.y;
            }
        }
        
        /// <summary>
        /// Gets or sets the specified RGBA component. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool r
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
        public bool g
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
        /// Returns the number of components (2).
        /// </summary>
        public int Count => 2;
        
        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        public bool MinElement => (x && y);
        
        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public bool MaxElement => (x || y);
        
        /// <summary>
        /// Returns true if all component are true.
        /// </summary>
        public bool All => (x && y);
        
        /// <summary>
        /// Returns true if any component is true.
        /// </summary>
        public bool Any => (x || y);

        //#endregion


        //#region Static Properties
        
        /// <summary>
        /// Predefined all-zero vector
        /// </summary>
        readonly public static bool2 Zero  =  bool2(false, false);
        
        /// <summary>
        /// Predefined all-ones vector
        /// </summary>
        readonly public static bool2 Ones  =  bool2(true, true);
        
        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        readonly public static bool2 UnitX  =  bool2(true, false);
        
        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        readonly public static bool2 UnitY  =  bool2(false, true);

        //#endregion


        //#region Operators
        
        /// <summary>
        /// Returns true if this equals rhs component-wise.
        /// </summary>
        public static bool operator==(bool2 lhs, bool2 rhs) => (lhs.x == rhs.x && lhs.y == rhs.y);
        
        /// <summary>
        /// Returns true if this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator!=(bool2 lhs, bool2 rhs) => !(lhs.x == rhs.x && lhs.y == rhs.y);

        //#endregion


        //#region Functions
        
        /// <summary>
        /// Returns an array with all values
        /// </summary>
        public bool[] ToArray() => new .[] ( x, y );
        
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
             stringBuffer.Join(sep, _x,_y );
        }
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public int GetHashCode()
        {
            unchecked
            {
                return ((x.GetHashCode()) * 2) ^ y.GetHashCode();
            }
        }

        //#endregion


        //#region Static Functions
        
        /// <summary>
        /// Returns a bool2 with independent and identically distributed random true/false values (the probability for 'true' can be configured).
        /// </summary>
        public static bool2 Random(Random random, float trueProbability = 0.5f) =>  bool2(random.NextDouble() < trueProbability, random.NextDouble() < trueProbability);

        //#endregion


        //#region Component-Wise Static Functions
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(bool2 lhs, bool2 rhs) => bool2(lhs.x == rhs.x, lhs.y == rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(bool2 lhs, bool rhs) => bool2(lhs.x == rhs, lhs.y == rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(bool lhs, bool2 rhs) => bool2(lhs == rhs.x, lhs == rhs.y);
        
        /// <summary>
        /// Returns a bool from the application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(bool lhs, bool rhs) => bool2(lhs == rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(bool2 lhs, bool2 rhs) => bool2(lhs.x != rhs.x, lhs.y != rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(bool2 lhs, bool rhs) => bool2(lhs.x != rhs, lhs.y != rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(bool lhs, bool2 rhs) => bool2(lhs != rhs.x, lhs != rhs.y);
        
        /// <summary>
        /// Returns a bool from the application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(bool lhs, bool rhs) => bool2(lhs != rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Not (!v).
        /// </summary>
        public static bool2 Not(bool2 v) => bool2(!v.x, !v.y);
        
        /// <summary>
        /// Returns a bool from the application of Not (!v).
        /// </summary>
        public static bool2 Not(bool v) => bool2(!v);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool2 And(bool2 lhs, bool2 rhs) => bool2(lhs.x && rhs.x, lhs.y && rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool2 And(bool2 lhs, bool rhs) => bool2(lhs.x && rhs, lhs.y && rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool2 And(bool lhs, bool2 rhs) => bool2(lhs && rhs.x, lhs && rhs.y);
        
        /// <summary>
        /// Returns a bool from the application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool2 And(bool lhs, bool rhs) => bool2(lhs && rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool2 Nand(bool2 lhs, bool2 rhs) => bool2(!(lhs.x && rhs.x), !(lhs.y && rhs.y));
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool2 Nand(bool2 lhs, bool rhs) => bool2(!(lhs.x && rhs), !(lhs.y && rhs));
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool2 Nand(bool lhs, bool2 rhs) => bool2(!(lhs && rhs.x), !(lhs && rhs.y));
        
        /// <summary>
        /// Returns a bool from the application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool2 Nand(bool lhs, bool rhs) => bool2(!(lhs && rhs));
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Or (lhs || rhs).
        /// </summary>
        public static bool2 Or(bool2 lhs, bool2 rhs) => bool2(lhs.x || rhs.x, lhs.y || rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Or (lhs || rhs).
        /// </summary>
        public static bool2 Or(bool2 lhs, bool rhs) => bool2(lhs.x || rhs, lhs.y || rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Or (lhs || rhs).
        /// </summary>
        public static bool2 Or(bool lhs, bool2 rhs) => bool2(lhs || rhs.x, lhs || rhs.y);
        
        /// <summary>
        /// Returns a bool from the application of Or (lhs || rhs).
        /// </summary>
        public static bool2 Or(bool lhs, bool rhs) => bool2(lhs || rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool2 Nor(bool2 lhs, bool2 rhs) => bool2(!(lhs.x || rhs.x), !(lhs.y || rhs.y));
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool2 Nor(bool2 lhs, bool rhs) => bool2(!(lhs.x || rhs), !(lhs.y || rhs));
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool2 Nor(bool lhs, bool2 rhs) => bool2(!(lhs || rhs.x), !(lhs || rhs.y));
        
        /// <summary>
        /// Returns a bool from the application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool2 Nor(bool lhs, bool rhs) => bool2(!(lhs || rhs));
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        public static bool2 Xor(bool2 lhs, bool2 rhs) => bool2(lhs.x != rhs.x, lhs.y != rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        public static bool2 Xor(bool2 lhs, bool rhs) => bool2(lhs.x != rhs, lhs.y != rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        public static bool2 Xor(bool lhs, bool2 rhs) => bool2(lhs != rhs.x, lhs != rhs.y);
        
        /// <summary>
        /// Returns a bool from the application of Xor (lhs != rhs).
        /// </summary>
        public static bool2 Xor(bool lhs, bool rhs) => bool2(lhs != rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        public static bool2 Xnor(bool2 lhs, bool2 rhs) => bool2(lhs.x == rhs.x, lhs.y == rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        public static bool2 Xnor(bool2 lhs, bool rhs) => bool2(lhs.x == rhs, lhs.y == rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        public static bool2 Xnor(bool lhs, bool2 rhs) => bool2(lhs == rhs.x, lhs == rhs.y);
        
        /// <summary>
        /// Returns a bool from the application of Xnor (lhs == rhs).
        /// </summary>
        public static bool2 Xnor(bool lhs, bool rhs) => bool2(lhs == rhs);

        //#endregion


        //#region Component-Wise Operator Overloads
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator! (!v).
        /// </summary>
        public static bool2 operator!(bool2 v) => bool2(!v.x, !v.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator&amp; (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool2 operator&(bool2 lhs, bool2 rhs) => bool2(lhs.x && rhs.x, lhs.y && rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator&amp; (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool2 operator&(bool2 lhs, bool rhs) => bool2(lhs.x && rhs, lhs.y && rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator&amp; (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool2 operator&(bool lhs, bool2 rhs) => bool2(lhs && rhs.x, lhs && rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator| (lhs || rhs).
        /// </summary>
        public static bool2 operator|(bool2 lhs, bool2 rhs) => bool2(lhs.x || rhs.x, lhs.y || rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator| (lhs || rhs).
        /// </summary>
        public static bool2 operator|(bool2 lhs, bool rhs) => bool2(lhs.x || rhs, lhs.y || rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of operator| (lhs || rhs).
        /// </summary>
        public static bool2 operator|(bool lhs, bool2 rhs) => bool2(lhs || rhs.x, lhs || rhs.y);

        //#endregion

    }
}
