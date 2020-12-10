using System;
namespace Atma
{
    
    /// <summary>
    /// A vector of type bool with 3 components.
    /// </summary>
    [Union]
    public struct bool3
    {

        //#region Fields
        
        /// <summary>
        /// component data
        /// </summary>
        public bool[3] values;
        
        /// <summary>
        /// Returns an object that can be used for arbitrary swizzling (e.g. swizzle.zy)
        /// </summary>
        public readonly swizzle_bool3 swizzle;

        //#endregion


        //#region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public this(bool x, bool y, bool z)
        {
            values = .(x,y,z);
        }
        
        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public this(bool v)
        {
            values = .(v,v,v);
        }
        
        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public this(bool2 v)
        {
            values = .(v.x,v.y,false);
        }
        
        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public this(bool2 v, bool z)
        {
            values = .(v.x,v.y,z);
        }
        
        /// <summary>
        /// from-vector constructor
        /// </summary>
        public this(bool3 v)
        {
            values = .(v.x,v.y,v.z);
        }
        
        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public this(bool4 v)
        {
            values = .(v.x,v.y,v.z);
        }
        
        /// <summary>
        /// From-array constructor (superfluous values are ignored, missing values are zero-filled).
        /// </summary>
        public this(bool[] v)
        {
            let c = v.Count;
            values = .((c < 0) ? false : v[0],(c < 1) ? false : v[1],(c < 2) ? false : v[2]);
        }
        
        /// <summary>
        /// From-array constructor with base index (superfluous values are ignored, missing values are zero-filled).
        /// </summary>
        public this(bool[] v, int startIndex)
        {
            let c = v.Count;
            values = .((c + startIndex < 0) ? false : v[0 + startIndex],(c + startIndex < 1) ? false : v[1 + startIndex],(c + startIndex < 2) ? false : v[2 + startIndex]);
        }

        //#endregion


        //#region Explicit Operators
        
        /// <summary>
        /// Explicitly converts this to a int2.
        /// </summary>
        public static explicit operator int2(bool3 v) =>  int2(v.x ? 1 : 0, v.y ? 1 : 0);
        
        /// <summary>
        /// Explicitly converts this to a int3.
        /// </summary>
        public static explicit operator int3(bool3 v) =>  int3(v.x ? 1 : 0, v.y ? 1 : 0, v.z ? 1 : 0);
        
        /// <summary>
        /// Explicitly converts this to a int4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator int4(bool3 v) =>  int4(v.x ? 1 : 0, v.y ? 1 : 0, v.z ? 1 : 0, 0);
        
        /// <summary>
        /// Explicitly converts this to a uint2.
        /// </summary>
        public static explicit operator uint2(bool3 v) =>  uint2(v.x ? 1u : 0u, v.y ? 1u : 0u);
        
        /// <summary>
        /// Explicitly converts this to a uint3.
        /// </summary>
        public static explicit operator uint3(bool3 v) =>  uint3(v.x ? 1u : 0u, v.y ? 1u : 0u, v.z ? 1u : 0u);
        
        /// <summary>
        /// Explicitly converts this to a uint4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator uint4(bool3 v) =>  uint4(v.x ? 1u : 0u, v.y ? 1u : 0u, v.z ? 1u : 0u, 0u);
        
        /// <summary>
        /// Explicitly converts this to a float2.
        /// </summary>
        public static explicit operator float2(bool3 v) =>  float2(v.x ? 1f : 0f, v.y ? 1f : 0f);
        
        /// <summary>
        /// Explicitly converts this to a float3.
        /// </summary>
        public static explicit operator float3(bool3 v) =>  float3(v.x ? 1f : 0f, v.y ? 1f : 0f, v.z ? 1f : 0f);
        
        /// <summary>
        /// Explicitly converts this to a float4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator float4(bool3 v) =>  float4(v.x ? 1f : 0f, v.y ? 1f : 0f, v.z ? 1f : 0f, 0f);
        
        /// <summary>
        /// Explicitly converts this to a double2.
        /// </summary>
        public static explicit operator double2(bool3 v) =>  double2(v.x ? 1.0 : 0.0, v.y ? 1.0 : 0.0);
        
        /// <summary>
        /// Explicitly converts this to a double3.
        /// </summary>
        public static explicit operator double3(bool3 v) =>  double3(v.x ? 1.0 : 0.0, v.y ? 1.0 : 0.0, v.z ? 1.0 : 0.0);
        
        /// <summary>
        /// Explicitly converts this to a double4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator double4(bool3 v) =>  double4(v.x ? 1.0 : 0.0, v.y ? 1.0 : 0.0, v.z ? 1.0 : 0.0, 0.0);
        
        /// <summary>
        /// Explicitly converts this to a long2.
        /// </summary>
        public static explicit operator long2(bool3 v) =>  long2(v.x ? 1 : 0, v.y ? 1 : 0);
        
        /// <summary>
        /// Explicitly converts this to a long3.
        /// </summary>
        public static explicit operator long3(bool3 v) =>  long3(v.x ? 1 : 0, v.y ? 1 : 0, v.z ? 1 : 0);
        
        /// <summary>
        /// Explicitly converts this to a long4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator long4(bool3 v) =>  long4(v.x ? 1 : 0, v.y ? 1 : 0, v.z ? 1 : 0, 0);
        
        /// <summary>
        /// Explicitly converts this to a bool2.
        /// </summary>
        public static explicit operator bool2(bool3 v) =>  bool2((bool)v.x, (bool)v.y);
        
        /// <summary>
        /// Explicitly converts this to a bool4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator bool4(bool3 v) =>  bool4((bool)v.x, (bool)v.y, (bool)v.z, false);

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
        public bool2 xz
        {
            [Inline]get
            {
                return  bool2(x, z);
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
        public bool2 yz
        {
            [Inline]get
            {
                return  bool2(y, z);
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
        public bool3 xyz
        {
            [Inline]get
            {
                return  bool3(x, y, z);
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
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool2 rb
        {
            [Inline]get
            {
                return  bool2(x, z);
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
        public bool2 gb
        {
            [Inline]get
            {
                return  bool2(y, z);
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
        public bool3 rgb
        {
            [Inline]get
            {
                return  bool3(x, y, z);
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
        /// Gets or sets the specified RGBA component. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool b
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
        public bool MinElement => ((x && y) && z);
        
        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public bool MaxElement => ((x || y) || z);
        
        /// <summary>
        /// Returns true if all component are true.
        /// </summary>
        public bool All => ((x && y) && z);
        
        /// <summary>
        /// Returns true if any component is true.
        /// </summary>
        public bool Any => ((x || y) || z);

        //#endregion


        //#region Static Properties
        
        /// <summary>
        /// Predefined all-zero vector
        /// </summary>
        readonly public static bool3 Zero  =  bool3(false, false, false);
        
        /// <summary>
        /// Predefined all-ones vector
        /// </summary>
        readonly public static bool3 Ones  =  bool3(true, true, true);
        
        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        readonly public static bool3 UnitX  =  bool3(true, false, false);
        
        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        readonly public static bool3 UnitY  =  bool3(false, true, false);
        
        /// <summary>
        /// Predefined unit-Z vector
        /// </summary>
        readonly public static bool3 UnitZ  =  bool3(false, false, true);

        //#endregion


        //#region Operators
        
        /// <summary>
        /// Returns true if this equals rhs component-wise.
        /// </summary>
        public static bool operator==(bool3 lhs, bool3 rhs) => ((lhs.x == rhs.x && lhs.y == rhs.y) && lhs.z == rhs.z);
        
        /// <summary>
        /// Returns true if this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator!=(bool3 lhs, bool3 rhs) => !((lhs.x == rhs.x && lhs.y == rhs.y) && lhs.z == rhs.z);

        //#endregion


        //#region Functions
        
        /// <summary>
        /// Returns an array with all values
        /// </summary>
        public bool[] ToArray() => new .[] ( x, y, z );
        
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
                return ((((x.GetHashCode()) * 2) ^ y.GetHashCode()) * 2) ^ z.GetHashCode();
            }
        }

        //#endregion


        //#region Static Functions
        
        /// <summary>
        /// Returns a bool3 with independent and identically distributed random true/false values (the probability for 'true' can be configured).
        /// </summary>
        public static bool3 Random(Random random, float trueProbability = 0.5f) =>  bool3(random.NextDouble() < trueProbability, random.NextDouble() < trueProbability, random.NextDouble() < trueProbability);

        //#endregion


        //#region Component-Wise Static Functions
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(bool3 lhs, bool3 rhs) => bool3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(bool3 lhs, bool rhs) => bool3(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(bool lhs, bool3 rhs) => bool3(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z);
        
        /// <summary>
        /// Returns a bool from the application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(bool lhs, bool rhs) => bool3(lhs == rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(bool3 lhs, bool3 rhs) => bool3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(bool3 lhs, bool rhs) => bool3(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(bool lhs, bool3 rhs) => bool3(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z);
        
        /// <summary>
        /// Returns a bool from the application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(bool lhs, bool rhs) => bool3(lhs != rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Not (!v).
        /// </summary>
        public static bool3 Not(bool3 v) => bool3(!v.x, !v.y, !v.z);
        
        /// <summary>
        /// Returns a bool from the application of Not (!v).
        /// </summary>
        public static bool3 Not(bool v) => bool3(!v);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool3 And(bool3 lhs, bool3 rhs) => bool3(lhs.x && rhs.x, lhs.y && rhs.y, lhs.z && rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool3 And(bool3 lhs, bool rhs) => bool3(lhs.x && rhs, lhs.y && rhs, lhs.z && rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool3 And(bool lhs, bool3 rhs) => bool3(lhs && rhs.x, lhs && rhs.y, lhs && rhs.z);
        
        /// <summary>
        /// Returns a bool from the application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool3 And(bool lhs, bool rhs) => bool3(lhs && rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool3 Nand(bool3 lhs, bool3 rhs) => bool3(!(lhs.x && rhs.x), !(lhs.y && rhs.y), !(lhs.z && rhs.z));
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool3 Nand(bool3 lhs, bool rhs) => bool3(!(lhs.x && rhs), !(lhs.y && rhs), !(lhs.z && rhs));
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool3 Nand(bool lhs, bool3 rhs) => bool3(!(lhs && rhs.x), !(lhs && rhs.y), !(lhs && rhs.z));
        
        /// <summary>
        /// Returns a bool from the application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool3 Nand(bool lhs, bool rhs) => bool3(!(lhs && rhs));
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Or (lhs || rhs).
        /// </summary>
        public static bool3 Or(bool3 lhs, bool3 rhs) => bool3(lhs.x || rhs.x, lhs.y || rhs.y, lhs.z || rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Or (lhs || rhs).
        /// </summary>
        public static bool3 Or(bool3 lhs, bool rhs) => bool3(lhs.x || rhs, lhs.y || rhs, lhs.z || rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Or (lhs || rhs).
        /// </summary>
        public static bool3 Or(bool lhs, bool3 rhs) => bool3(lhs || rhs.x, lhs || rhs.y, lhs || rhs.z);
        
        /// <summary>
        /// Returns a bool from the application of Or (lhs || rhs).
        /// </summary>
        public static bool3 Or(bool lhs, bool rhs) => bool3(lhs || rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool3 Nor(bool3 lhs, bool3 rhs) => bool3(!(lhs.x || rhs.x), !(lhs.y || rhs.y), !(lhs.z || rhs.z));
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool3 Nor(bool3 lhs, bool rhs) => bool3(!(lhs.x || rhs), !(lhs.y || rhs), !(lhs.z || rhs));
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool3 Nor(bool lhs, bool3 rhs) => bool3(!(lhs || rhs.x), !(lhs || rhs.y), !(lhs || rhs.z));
        
        /// <summary>
        /// Returns a bool from the application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool3 Nor(bool lhs, bool rhs) => bool3(!(lhs || rhs));
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        public static bool3 Xor(bool3 lhs, bool3 rhs) => bool3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        public static bool3 Xor(bool3 lhs, bool rhs) => bool3(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        public static bool3 Xor(bool lhs, bool3 rhs) => bool3(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z);
        
        /// <summary>
        /// Returns a bool from the application of Xor (lhs != rhs).
        /// </summary>
        public static bool3 Xor(bool lhs, bool rhs) => bool3(lhs != rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        public static bool3 Xnor(bool3 lhs, bool3 rhs) => bool3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        public static bool3 Xnor(bool3 lhs, bool rhs) => bool3(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        public static bool3 Xnor(bool lhs, bool3 rhs) => bool3(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z);
        
        /// <summary>
        /// Returns a bool from the application of Xnor (lhs == rhs).
        /// </summary>
        public static bool3 Xnor(bool lhs, bool rhs) => bool3(lhs == rhs);

        //#endregion


        //#region Component-Wise Operator Overloads
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator! (!v).
        /// </summary>
        public static bool3 operator!(bool3 v) => bool3(!v.x, !v.y, !v.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&amp; (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool3 operator&(bool3 lhs, bool3 rhs) => bool3(lhs.x && rhs.x, lhs.y && rhs.y, lhs.z && rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&amp; (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool3 operator&(bool3 lhs, bool rhs) => bool3(lhs.x && rhs, lhs.y && rhs, lhs.z && rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator&amp; (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool3 operator&(bool lhs, bool3 rhs) => bool3(lhs && rhs.x, lhs && rhs.y, lhs && rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator| (lhs || rhs).
        /// </summary>
        public static bool3 operator|(bool3 lhs, bool3 rhs) => bool3(lhs.x || rhs.x, lhs.y || rhs.y, lhs.z || rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator| (lhs || rhs).
        /// </summary>
        public static bool3 operator|(bool3 lhs, bool rhs) => bool3(lhs.x || rhs, lhs.y || rhs, lhs.z || rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of operator| (lhs || rhs).
        /// </summary>
        public static bool3 operator|(bool lhs, bool3 rhs) => bool3(lhs || rhs.x, lhs || rhs.y, lhs || rhs.z);

        //#endregion

    }
}
