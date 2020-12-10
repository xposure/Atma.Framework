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
        public static bool[] ToArray(bool4 v) => v.ToArray();
        
        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        [Inline]
        public static void ToString(bool4 v, String stringBuffer) => v.ToString(stringBuffer);
        
        /// <summary>
        /// Returns a string representation of this vector using a provided seperator.
        /// </summary>
        [Inline]
        public static void ToString(bool4 v, String stringBuffer, String sep) => v.ToString(stringBuffer, sep);
        
        /// <summary>
        /// Returns the number of components (4).
        /// </summary>
        [Inline]
        public static int Count(bool4 v) => v.Count;
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        [Inline]
        public static int GetHashCode(bool4 v) => v.GetHashCode();
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool4 Equal(bool4 lhs, bool4 rhs) => bool4.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool4 NotEqual(bool4 lhs, bool4 rhs) => bool4.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Not (!v).
        /// </summary>
        [Inline]
        public static bool4 Not(bool4 v) => bool4.Not(v);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        [Inline]
        public static bool4 And(bool4 lhs, bool4 rhs) => bool4.And(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        [Inline]
        public static bool4 Nand(bool4 lhs, bool4 rhs) => bool4.Nand(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Or (lhs || rhs).
        /// </summary>
        [Inline]
        public static bool4 Or(bool4 lhs, bool4 rhs) => bool4.Or(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        [Inline]
        public static bool4 Nor(bool4 lhs, bool4 rhs) => bool4.Nor(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool4 Xor(bool4 lhs, bool4 rhs) => bool4.Xor(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool4 Xnor(bool4 lhs, bool4 rhs) => bool4.Xnor(lhs, rhs);
        
        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        [Inline]
        public static bool MinElement(bool4 v) => v.MinElement;
        
        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        [Inline]
        public static bool MaxElement(bool4 v) => v.MaxElement;
        
        /// <summary>
        /// Returns true if all component are true.
        /// </summary>
        [Inline]
        public static bool All(bool4 v) => v.All;
        
        /// <summary>
        /// Returns true if any component is true.
        /// </summary>
        [Inline]
        public static bool Any(bool4 v) => v.Any;

    }
}
