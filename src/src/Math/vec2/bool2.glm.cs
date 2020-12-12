using System;
namespace Atma.glm
{
    /// <summary>
    /// Static class that contains static glm functions
    /// </summary>
    static
    {
        
        /// <summary>
        /// Returns an array with all values
        /// </summary>
        [Inline]
        public static bool[] ToArray(bool2 v) => v.ToArray();
        
        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        [Inline]
        public static void ToString(bool2 v, String stringBuffer) => v.ToString(stringBuffer);
        
        /// <summary>
        /// Returns a string representation of this vector using a provided seperator.
        /// </summary>
        [Inline]
        public static void ToString(bool2 v, String stringBuffer, String sep) => v.ToString(stringBuffer, sep);
        
        /// <summary>
        /// Returns the number of components (2).
        /// </summary>
        [Inline]
        public static int Count(bool2 v) => v.Count;
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        [Inline]
        public static int GetHashCode(bool2 v) => v.GetHashCode();
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool2 Equal(bool2 lhs, bool2 rhs) => bool2.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool2 NotEqual(bool2 lhs, bool2 rhs) => bool2.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Not (!v).
        /// </summary>
        [Inline]
        public static bool2 Not(bool2 v) => bool2.Not(v);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        [Inline]
        public static bool2 And(bool2 lhs, bool2 rhs) => bool2.And(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        [Inline]
        public static bool2 Nand(bool2 lhs, bool2 rhs) => bool2.Nand(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Or (lhs || rhs).
        /// </summary>
        [Inline]
        public static bool2 Or(bool2 lhs, bool2 rhs) => bool2.Or(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        [Inline]
        public static bool2 Nor(bool2 lhs, bool2 rhs) => bool2.Nor(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool2 Xor(bool2 lhs, bool2 rhs) => bool2.Xor(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool2 Xnor(bool2 lhs, bool2 rhs) => bool2.Xnor(lhs, rhs);
        
        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        [Inline]
        public static bool MinElement(bool2 v) => v.MinElement;
        
        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        [Inline]
        public static bool MaxElement(bool2 v) => v.MaxElement;
        
        /// <summary>
        /// Returns true if all component are true.
        /// </summary>
        [Inline]
        public static bool All(bool2 v) => v.All;
        
        /// <summary>
        /// Returns true if any component is true.
        /// </summary>
        [Inline]
        public static bool Any(bool2 v) => v.Any;

    }
}
