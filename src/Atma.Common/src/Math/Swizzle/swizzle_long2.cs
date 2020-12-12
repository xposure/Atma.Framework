using System;
namespace Atma
{
    
    /// <summary>
    /// Temporary vector of type long with 2 components, used for implementing swizzling for long2.
    /// </summary>
    public struct swizzle_long2
    {

        //#region Fields
        
        /// <summary>
        /// x-component
        /// </summary>
        private readonly long x;
        
        /// <summary>
        /// y-component
        /// </summary>
        private readonly long y;

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Returns long2.xx swizzling.
        /// </summary>
        [Inline]
        public long2 xx =>  long2(x, x);
        
        /// <summary>
        /// Returns long2.rr swizzling (equivalent to long2.xx).
        /// </summary>
        [Inline]
        public long2 rr =>  long2(x, x);
        
        /// <summary>
        /// Returns long2.xxx swizzling.
        /// </summary>
        [Inline]
        public long3 xxx =>  long3(x, x, x);
        
        /// <summary>
        /// Returns long2.rrr swizzling (equivalent to long2.xxx).
        /// </summary>
        [Inline]
        public long3 rrr =>  long3(x, x, x);
        
        /// <summary>
        /// Returns long2.xxxx swizzling.
        /// </summary>
        [Inline]
        public long4 xxxx =>  long4(x, x, x, x);
        
        /// <summary>
        /// Returns long2.rrrr swizzling (equivalent to long2.xxxx).
        /// </summary>
        [Inline]
        public long4 rrrr =>  long4(x, x, x, x);
        
        /// <summary>
        /// Returns long2.xxxy swizzling.
        /// </summary>
        [Inline]
        public long4 xxxy =>  long4(x, x, x, y);
        
        /// <summary>
        /// Returns long2.rrrg swizzling (equivalent to long2.xxxy).
        /// </summary>
        [Inline]
        public long4 rrrg =>  long4(x, x, x, y);
        
        /// <summary>
        /// Returns long2.xxy swizzling.
        /// </summary>
        [Inline]
        public long3 xxy =>  long3(x, x, y);
        
        /// <summary>
        /// Returns long2.rrg swizzling (equivalent to long2.xxy).
        /// </summary>
        [Inline]
        public long3 rrg =>  long3(x, x, y);
        
        /// <summary>
        /// Returns long2.xxyx swizzling.
        /// </summary>
        [Inline]
        public long4 xxyx =>  long4(x, x, y, x);
        
        /// <summary>
        /// Returns long2.rrgr swizzling (equivalent to long2.xxyx).
        /// </summary>
        [Inline]
        public long4 rrgr =>  long4(x, x, y, x);
        
        /// <summary>
        /// Returns long2.xxyy swizzling.
        /// </summary>
        [Inline]
        public long4 xxyy =>  long4(x, x, y, y);
        
        /// <summary>
        /// Returns long2.rrgg swizzling (equivalent to long2.xxyy).
        /// </summary>
        [Inline]
        public long4 rrgg =>  long4(x, x, y, y);
        
        /// <summary>
        /// Returns long2.xy swizzling.
        /// </summary>
        [Inline]
        public long2 xy =>  long2(x, y);
        
        /// <summary>
        /// Returns long2.rg swizzling (equivalent to long2.xy).
        /// </summary>
        [Inline]
        public long2 rg =>  long2(x, y);
        
        /// <summary>
        /// Returns long2.xyx swizzling.
        /// </summary>
        [Inline]
        public long3 xyx =>  long3(x, y, x);
        
        /// <summary>
        /// Returns long2.rgr swizzling (equivalent to long2.xyx).
        /// </summary>
        [Inline]
        public long3 rgr =>  long3(x, y, x);
        
        /// <summary>
        /// Returns long2.xyxx swizzling.
        /// </summary>
        [Inline]
        public long4 xyxx =>  long4(x, y, x, x);
        
        /// <summary>
        /// Returns long2.rgrr swizzling (equivalent to long2.xyxx).
        /// </summary>
        [Inline]
        public long4 rgrr =>  long4(x, y, x, x);
        
        /// <summary>
        /// Returns long2.xyxy swizzling.
        /// </summary>
        [Inline]
        public long4 xyxy =>  long4(x, y, x, y);
        
        /// <summary>
        /// Returns long2.rgrg swizzling (equivalent to long2.xyxy).
        /// </summary>
        [Inline]
        public long4 rgrg =>  long4(x, y, x, y);
        
        /// <summary>
        /// Returns long2.xyy swizzling.
        /// </summary>
        [Inline]
        public long3 xyy =>  long3(x, y, y);
        
        /// <summary>
        /// Returns long2.rgg swizzling (equivalent to long2.xyy).
        /// </summary>
        [Inline]
        public long3 rgg =>  long3(x, y, y);
        
        /// <summary>
        /// Returns long2.xyyx swizzling.
        /// </summary>
        [Inline]
        public long4 xyyx =>  long4(x, y, y, x);
        
        /// <summary>
        /// Returns long2.rggr swizzling (equivalent to long2.xyyx).
        /// </summary>
        [Inline]
        public long4 rggr =>  long4(x, y, y, x);
        
        /// <summary>
        /// Returns long2.xyyy swizzling.
        /// </summary>
        [Inline]
        public long4 xyyy =>  long4(x, y, y, y);
        
        /// <summary>
        /// Returns long2.rggg swizzling (equivalent to long2.xyyy).
        /// </summary>
        [Inline]
        public long4 rggg =>  long4(x, y, y, y);
        
        /// <summary>
        /// Returns long2.yx swizzling.
        /// </summary>
        [Inline]
        public long2 yx =>  long2(y, x);
        
        /// <summary>
        /// Returns long2.gr swizzling (equivalent to long2.yx).
        /// </summary>
        [Inline]
        public long2 gr =>  long2(y, x);
        
        /// <summary>
        /// Returns long2.yxx swizzling.
        /// </summary>
        [Inline]
        public long3 yxx =>  long3(y, x, x);
        
        /// <summary>
        /// Returns long2.grr swizzling (equivalent to long2.yxx).
        /// </summary>
        [Inline]
        public long3 grr =>  long3(y, x, x);
        
        /// <summary>
        /// Returns long2.yxxx swizzling.
        /// </summary>
        [Inline]
        public long4 yxxx =>  long4(y, x, x, x);
        
        /// <summary>
        /// Returns long2.grrr swizzling (equivalent to long2.yxxx).
        /// </summary>
        [Inline]
        public long4 grrr =>  long4(y, x, x, x);
        
        /// <summary>
        /// Returns long2.yxxy swizzling.
        /// </summary>
        [Inline]
        public long4 yxxy =>  long4(y, x, x, y);
        
        /// <summary>
        /// Returns long2.grrg swizzling (equivalent to long2.yxxy).
        /// </summary>
        [Inline]
        public long4 grrg =>  long4(y, x, x, y);
        
        /// <summary>
        /// Returns long2.yxy swizzling.
        /// </summary>
        [Inline]
        public long3 yxy =>  long3(y, x, y);
        
        /// <summary>
        /// Returns long2.grg swizzling (equivalent to long2.yxy).
        /// </summary>
        [Inline]
        public long3 grg =>  long3(y, x, y);
        
        /// <summary>
        /// Returns long2.yxyx swizzling.
        /// </summary>
        [Inline]
        public long4 yxyx =>  long4(y, x, y, x);
        
        /// <summary>
        /// Returns long2.grgr swizzling (equivalent to long2.yxyx).
        /// </summary>
        [Inline]
        public long4 grgr =>  long4(y, x, y, x);
        
        /// <summary>
        /// Returns long2.yxyy swizzling.
        /// </summary>
        [Inline]
        public long4 yxyy =>  long4(y, x, y, y);
        
        /// <summary>
        /// Returns long2.grgg swizzling (equivalent to long2.yxyy).
        /// </summary>
        [Inline]
        public long4 grgg =>  long4(y, x, y, y);
        
        /// <summary>
        /// Returns long2.yy swizzling.
        /// </summary>
        [Inline]
        public long2 yy =>  long2(y, y);
        
        /// <summary>
        /// Returns long2.gg swizzling (equivalent to long2.yy).
        /// </summary>
        [Inline]
        public long2 gg =>  long2(y, y);
        
        /// <summary>
        /// Returns long2.yyx swizzling.
        /// </summary>
        [Inline]
        public long3 yyx =>  long3(y, y, x);
        
        /// <summary>
        /// Returns long2.ggr swizzling (equivalent to long2.yyx).
        /// </summary>
        [Inline]
        public long3 ggr =>  long3(y, y, x);
        
        /// <summary>
        /// Returns long2.yyxx swizzling.
        /// </summary>
        [Inline]
        public long4 yyxx =>  long4(y, y, x, x);
        
        /// <summary>
        /// Returns long2.ggrr swizzling (equivalent to long2.yyxx).
        /// </summary>
        [Inline]
        public long4 ggrr =>  long4(y, y, x, x);
        
        /// <summary>
        /// Returns long2.yyxy swizzling.
        /// </summary>
        [Inline]
        public long4 yyxy =>  long4(y, y, x, y);
        
        /// <summary>
        /// Returns long2.ggrg swizzling (equivalent to long2.yyxy).
        /// </summary>
        [Inline]
        public long4 ggrg =>  long4(y, y, x, y);
        
        /// <summary>
        /// Returns long2.yyy swizzling.
        /// </summary>
        [Inline]
        public long3 yyy =>  long3(y, y, y);
        
        /// <summary>
        /// Returns long2.ggg swizzling (equivalent to long2.yyy).
        /// </summary>
        [Inline]
        public long3 ggg =>  long3(y, y, y);
        
        /// <summary>
        /// Returns long2.yyyx swizzling.
        /// </summary>
        [Inline]
        public long4 yyyx =>  long4(y, y, y, x);
        
        /// <summary>
        /// Returns long2.gggr swizzling (equivalent to long2.yyyx).
        /// </summary>
        [Inline]
        public long4 gggr =>  long4(y, y, y, x);
        
        /// <summary>
        /// Returns long2.yyyy swizzling.
        /// </summary>
        [Inline]
        public long4 yyyy =>  long4(y, y, y, y);
        
        /// <summary>
        /// Returns long2.gggg swizzling (equivalent to long2.yyyy).
        /// </summary>
        [Inline]
        public long4 gggg =>  long4(y, y, y, y);

        //#endregion

    }
}
