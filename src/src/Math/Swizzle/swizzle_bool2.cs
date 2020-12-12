using System;
namespace Atma
{
    
    /// <summary>
    /// Temporary vector of type bool with 2 components, used for implementing swizzling for bool2.
    /// </summary>
    public struct swizzle_bool2
    {

        //#region Fields
        
        /// <summary>
        /// x-component
        /// </summary>
        private readonly bool x;
        
        /// <summary>
        /// y-component
        /// </summary>
        private readonly bool y;

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Returns bool2.xx swizzling.
        /// </summary>
        [Inline]
        public bool2 xx =>  bool2(x, x);
        
        /// <summary>
        /// Returns bool2.rr swizzling (equivalent to bool2.xx).
        /// </summary>
        [Inline]
        public bool2 rr =>  bool2(x, x);
        
        /// <summary>
        /// Returns bool2.xxx swizzling.
        /// </summary>
        [Inline]
        public bool3 xxx =>  bool3(x, x, x);
        
        /// <summary>
        /// Returns bool2.rrr swizzling (equivalent to bool2.xxx).
        /// </summary>
        [Inline]
        public bool3 rrr =>  bool3(x, x, x);
        
        /// <summary>
        /// Returns bool2.xxxx swizzling.
        /// </summary>
        [Inline]
        public bool4 xxxx =>  bool4(x, x, x, x);
        
        /// <summary>
        /// Returns bool2.rrrr swizzling (equivalent to bool2.xxxx).
        /// </summary>
        [Inline]
        public bool4 rrrr =>  bool4(x, x, x, x);
        
        /// <summary>
        /// Returns bool2.xxxy swizzling.
        /// </summary>
        [Inline]
        public bool4 xxxy =>  bool4(x, x, x, y);
        
        /// <summary>
        /// Returns bool2.rrrg swizzling (equivalent to bool2.xxxy).
        /// </summary>
        [Inline]
        public bool4 rrrg =>  bool4(x, x, x, y);
        
        /// <summary>
        /// Returns bool2.xxy swizzling.
        /// </summary>
        [Inline]
        public bool3 xxy =>  bool3(x, x, y);
        
        /// <summary>
        /// Returns bool2.rrg swizzling (equivalent to bool2.xxy).
        /// </summary>
        [Inline]
        public bool3 rrg =>  bool3(x, x, y);
        
        /// <summary>
        /// Returns bool2.xxyx swizzling.
        /// </summary>
        [Inline]
        public bool4 xxyx =>  bool4(x, x, y, x);
        
        /// <summary>
        /// Returns bool2.rrgr swizzling (equivalent to bool2.xxyx).
        /// </summary>
        [Inline]
        public bool4 rrgr =>  bool4(x, x, y, x);
        
        /// <summary>
        /// Returns bool2.xxyy swizzling.
        /// </summary>
        [Inline]
        public bool4 xxyy =>  bool4(x, x, y, y);
        
        /// <summary>
        /// Returns bool2.rrgg swizzling (equivalent to bool2.xxyy).
        /// </summary>
        [Inline]
        public bool4 rrgg =>  bool4(x, x, y, y);
        
        /// <summary>
        /// Returns bool2.xy swizzling.
        /// </summary>
        [Inline]
        public bool2 xy =>  bool2(x, y);
        
        /// <summary>
        /// Returns bool2.rg swizzling (equivalent to bool2.xy).
        /// </summary>
        [Inline]
        public bool2 rg =>  bool2(x, y);
        
        /// <summary>
        /// Returns bool2.xyx swizzling.
        /// </summary>
        [Inline]
        public bool3 xyx =>  bool3(x, y, x);
        
        /// <summary>
        /// Returns bool2.rgr swizzling (equivalent to bool2.xyx).
        /// </summary>
        [Inline]
        public bool3 rgr =>  bool3(x, y, x);
        
        /// <summary>
        /// Returns bool2.xyxx swizzling.
        /// </summary>
        [Inline]
        public bool4 xyxx =>  bool4(x, y, x, x);
        
        /// <summary>
        /// Returns bool2.rgrr swizzling (equivalent to bool2.xyxx).
        /// </summary>
        [Inline]
        public bool4 rgrr =>  bool4(x, y, x, x);
        
        /// <summary>
        /// Returns bool2.xyxy swizzling.
        /// </summary>
        [Inline]
        public bool4 xyxy =>  bool4(x, y, x, y);
        
        /// <summary>
        /// Returns bool2.rgrg swizzling (equivalent to bool2.xyxy).
        /// </summary>
        [Inline]
        public bool4 rgrg =>  bool4(x, y, x, y);
        
        /// <summary>
        /// Returns bool2.xyy swizzling.
        /// </summary>
        [Inline]
        public bool3 xyy =>  bool3(x, y, y);
        
        /// <summary>
        /// Returns bool2.rgg swizzling (equivalent to bool2.xyy).
        /// </summary>
        [Inline]
        public bool3 rgg =>  bool3(x, y, y);
        
        /// <summary>
        /// Returns bool2.xyyx swizzling.
        /// </summary>
        [Inline]
        public bool4 xyyx =>  bool4(x, y, y, x);
        
        /// <summary>
        /// Returns bool2.rggr swizzling (equivalent to bool2.xyyx).
        /// </summary>
        [Inline]
        public bool4 rggr =>  bool4(x, y, y, x);
        
        /// <summary>
        /// Returns bool2.xyyy swizzling.
        /// </summary>
        [Inline]
        public bool4 xyyy =>  bool4(x, y, y, y);
        
        /// <summary>
        /// Returns bool2.rggg swizzling (equivalent to bool2.xyyy).
        /// </summary>
        [Inline]
        public bool4 rggg =>  bool4(x, y, y, y);
        
        /// <summary>
        /// Returns bool2.yx swizzling.
        /// </summary>
        [Inline]
        public bool2 yx =>  bool2(y, x);
        
        /// <summary>
        /// Returns bool2.gr swizzling (equivalent to bool2.yx).
        /// </summary>
        [Inline]
        public bool2 gr =>  bool2(y, x);
        
        /// <summary>
        /// Returns bool2.yxx swizzling.
        /// </summary>
        [Inline]
        public bool3 yxx =>  bool3(y, x, x);
        
        /// <summary>
        /// Returns bool2.grr swizzling (equivalent to bool2.yxx).
        /// </summary>
        [Inline]
        public bool3 grr =>  bool3(y, x, x);
        
        /// <summary>
        /// Returns bool2.yxxx swizzling.
        /// </summary>
        [Inline]
        public bool4 yxxx =>  bool4(y, x, x, x);
        
        /// <summary>
        /// Returns bool2.grrr swizzling (equivalent to bool2.yxxx).
        /// </summary>
        [Inline]
        public bool4 grrr =>  bool4(y, x, x, x);
        
        /// <summary>
        /// Returns bool2.yxxy swizzling.
        /// </summary>
        [Inline]
        public bool4 yxxy =>  bool4(y, x, x, y);
        
        /// <summary>
        /// Returns bool2.grrg swizzling (equivalent to bool2.yxxy).
        /// </summary>
        [Inline]
        public bool4 grrg =>  bool4(y, x, x, y);
        
        /// <summary>
        /// Returns bool2.yxy swizzling.
        /// </summary>
        [Inline]
        public bool3 yxy =>  bool3(y, x, y);
        
        /// <summary>
        /// Returns bool2.grg swizzling (equivalent to bool2.yxy).
        /// </summary>
        [Inline]
        public bool3 grg =>  bool3(y, x, y);
        
        /// <summary>
        /// Returns bool2.yxyx swizzling.
        /// </summary>
        [Inline]
        public bool4 yxyx =>  bool4(y, x, y, x);
        
        /// <summary>
        /// Returns bool2.grgr swizzling (equivalent to bool2.yxyx).
        /// </summary>
        [Inline]
        public bool4 grgr =>  bool4(y, x, y, x);
        
        /// <summary>
        /// Returns bool2.yxyy swizzling.
        /// </summary>
        [Inline]
        public bool4 yxyy =>  bool4(y, x, y, y);
        
        /// <summary>
        /// Returns bool2.grgg swizzling (equivalent to bool2.yxyy).
        /// </summary>
        [Inline]
        public bool4 grgg =>  bool4(y, x, y, y);
        
        /// <summary>
        /// Returns bool2.yy swizzling.
        /// </summary>
        [Inline]
        public bool2 yy =>  bool2(y, y);
        
        /// <summary>
        /// Returns bool2.gg swizzling (equivalent to bool2.yy).
        /// </summary>
        [Inline]
        public bool2 gg =>  bool2(y, y);
        
        /// <summary>
        /// Returns bool2.yyx swizzling.
        /// </summary>
        [Inline]
        public bool3 yyx =>  bool3(y, y, x);
        
        /// <summary>
        /// Returns bool2.ggr swizzling (equivalent to bool2.yyx).
        /// </summary>
        [Inline]
        public bool3 ggr =>  bool3(y, y, x);
        
        /// <summary>
        /// Returns bool2.yyxx swizzling.
        /// </summary>
        [Inline]
        public bool4 yyxx =>  bool4(y, y, x, x);
        
        /// <summary>
        /// Returns bool2.ggrr swizzling (equivalent to bool2.yyxx).
        /// </summary>
        [Inline]
        public bool4 ggrr =>  bool4(y, y, x, x);
        
        /// <summary>
        /// Returns bool2.yyxy swizzling.
        /// </summary>
        [Inline]
        public bool4 yyxy =>  bool4(y, y, x, y);
        
        /// <summary>
        /// Returns bool2.ggrg swizzling (equivalent to bool2.yyxy).
        /// </summary>
        [Inline]
        public bool4 ggrg =>  bool4(y, y, x, y);
        
        /// <summary>
        /// Returns bool2.yyy swizzling.
        /// </summary>
        [Inline]
        public bool3 yyy =>  bool3(y, y, y);
        
        /// <summary>
        /// Returns bool2.ggg swizzling (equivalent to bool2.yyy).
        /// </summary>
        [Inline]
        public bool3 ggg =>  bool3(y, y, y);
        
        /// <summary>
        /// Returns bool2.yyyx swizzling.
        /// </summary>
        [Inline]
        public bool4 yyyx =>  bool4(y, y, y, x);
        
        /// <summary>
        /// Returns bool2.gggr swizzling (equivalent to bool2.yyyx).
        /// </summary>
        [Inline]
        public bool4 gggr =>  bool4(y, y, y, x);
        
        /// <summary>
        /// Returns bool2.yyyy swizzling.
        /// </summary>
        [Inline]
        public bool4 yyyy =>  bool4(y, y, y, y);
        
        /// <summary>
        /// Returns bool2.gggg swizzling (equivalent to bool2.yyyy).
        /// </summary>
        [Inline]
        public bool4 gggg =>  bool4(y, y, y, y);

        //#endregion

    }
}
