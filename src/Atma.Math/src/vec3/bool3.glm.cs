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
        public static bool[] ToArray(bool3 v) => v.ToArray();
        
        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        [Inline]
        public static void ToString(bool3 v, String stringBuffer) => v.ToString(stringBuffer);
        
        /// <summary>
        /// Returns a string representation of this vector using a provided seperator.
        /// </summary>
        [Inline]
        public static void ToString(bool3 v, String stringBuffer, String sep) => v.ToString(stringBuffer, sep);
        
        /// <summary>
        /// Returns the number of components (3).
        /// </summary>
        [Inline]
        public static int Count(bool3 v) => v.Count;
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        [Inline]
        public static int GetHashCode(bool3 v) => v.GetHashCode();
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool3 Equal(bool3 lhs, bool3 rhs) => bool3.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool Equal(bool lhs, bool rhs) => lhs == rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool3 NotEqual(bool3 lhs, bool3 rhs) => bool3.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool NotEqual(bool lhs, bool rhs) => lhs != rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Not (!v).
        /// </summary>
        [Inline]
        public static bool3 Not(bool3 v) => bool3.Not(v);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Not (!v).
        /// </summary>
        [Inline]
        public static bool Not(bool v) => !v;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        [Inline]
        public static bool3 And(bool3 lhs, bool3 rhs) => bool3.And(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        [Inline]
        public static bool And(bool lhs, bool rhs) => lhs && rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        [Inline]
        public static bool3 Nand(bool3 lhs, bool3 rhs) => bool3.Nand(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        [Inline]
        public static bool Nand(bool lhs, bool rhs) => !(lhs && rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Or (lhs || rhs).
        /// </summary>
        [Inline]
        public static bool3 Or(bool3 lhs, bool3 rhs) => bool3.Or(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Or (lhs || rhs).
        /// </summary>
        [Inline]
        public static bool Or(bool lhs, bool rhs) => lhs || rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        [Inline]
        public static bool3 Nor(bool3 lhs, bool3 rhs) => bool3.Nor(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        [Inline]
        public static bool Nor(bool lhs, bool rhs) => !(lhs || rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool3 Xor(bool3 lhs, bool3 rhs) => bool3.Xor(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool Xor(bool lhs, bool rhs) => lhs != rhs;
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool3 Xnor(bool3 lhs, bool3 rhs) => bool3.Xnor(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool Xnor(bool lhs, bool rhs) => lhs == rhs;
        
        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        [Inline]
        public static bool MinElement(bool3 v) => v.MinElement;
        
        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        [Inline]
        public static bool MaxElement(bool3 v) => v.MaxElement;
        
        /// <summary>
        /// Returns true if all component are true.
        /// </summary>
        [Inline]
        public static bool All(bool3 v) => v.All;
        
        /// <summary>
        /// Returns true if any component is true.
        /// </summary>
        [Inline]
        public static bool Any(bool3 v) => v.Any;

    }
}
