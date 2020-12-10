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
        public static bool[] ToArray(qbool q) => q.ToArray();
        
        /// <summary>
        /// Returns the number of components (4).
        /// </summary>
        [Inline]
        public static int Count(qbool q) => q.Count;
        
        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        [Inline]
        public static bool Equals(qbool q, qbool rhs) => q.Equals(rhs);
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        [Inline]
        public static int GetHashCode(qbool q) => q.GetHashCode();
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        [Inline]
        public static bool4 Equal(qbool lhs, qbool rhs) => qbool.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        [Inline]
        public static bool4 NotEqual(qbool lhs, qbool rhs) => qbool.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Not (!v).
        /// </summary>
        [Inline]
        public static bool4 Not(qbool v) => qbool.Not(v);
        
        /// <summary>
        /// Returns a qbool from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        [Inline]
        public static qbool And(qbool lhs, qbool rhs) => qbool.And(lhs, rhs);
        
        /// <summary>
        /// Returns a qbool from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        [Inline]
        public static qbool Nand(qbool lhs, qbool rhs) => qbool.Nand(lhs, rhs);
        
        /// <summary>
        /// Returns a qbool from component-wise application of Or (lhs || rhs).
        /// </summary>
        [Inline]
        public static qbool Or(qbool lhs, qbool rhs) => qbool.Or(lhs, rhs);
        
        /// <summary>
        /// Returns a qbool from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        [Inline]
        public static qbool Nor(qbool lhs, qbool rhs) => qbool.Nor(lhs, rhs);
        
        /// <summary>
        /// Returns a qbool from component-wise application of Xor (lhs != rhs).
        /// </summary>
        [Inline]
        public static qbool Xor(qbool lhs, qbool rhs) => qbool.Xor(lhs, rhs);
        
        /// <summary>
        /// Returns a qbool from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        [Inline]
        public static qbool Xnor(qbool lhs, qbool rhs) => qbool.Xnor(lhs, rhs);
        
        /// <summary>
        /// Returns the minimal component of this quaternion.
        /// </summary>
        [Inline]
        public static bool MinElement(qbool q) => q.MinElement;
        
        /// <summary>
        /// Returns the maximal component of this quaternion.
        /// </summary>
        [Inline]
        public static bool MaxElement(qbool q) => q.MaxElement;
        
        /// <summary>
        /// Returns true if all component are true.
        /// </summary>
        [Inline]
        public static bool All(qbool q) => q.All;
        
        /// <summary>
        /// Returns true if any component is true.
        /// </summary>
        [Inline]
        public static bool Any(qbool q) => q.Any;

    }
}
