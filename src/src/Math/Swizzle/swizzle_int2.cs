using System;
namespace Atma
{
    
    /// <summary>
    /// Temporary vector of type int with 2 components, used for implementing swizzling for int2.
    /// </summary>
    public struct swizzle_int2
    {

        //#region Fields
        
        /// <summary>
        /// x-component
        /// </summary>
        private readonly int x;
        
        /// <summary>
        /// y-component
        /// </summary>
        private readonly int y;

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Returns int2.xx swizzling.
        /// </summary>
        [Inline]
        public int2 xx =>  int2(x, x);
        
        /// <summary>
        /// Returns int2.rr swizzling (equivalent to int2.xx).
        /// </summary>
        [Inline]
        public int2 rr =>  int2(x, x);
        
        /// <summary>
        /// Returns int2.xxx swizzling.
        /// </summary>
        [Inline]
        public int3 xxx =>  int3(x, x, x);
        
        /// <summary>
        /// Returns int2.rrr swizzling (equivalent to int2.xxx).
        /// </summary>
        [Inline]
        public int3 rrr =>  int3(x, x, x);
        
        /// <summary>
        /// Returns int2.xxxx swizzling.
        /// </summary>
        [Inline]
        public int4 xxxx =>  int4(x, x, x, x);
        
        /// <summary>
        /// Returns int2.rrrr swizzling (equivalent to int2.xxxx).
        /// </summary>
        [Inline]
        public int4 rrrr =>  int4(x, x, x, x);
        
        /// <summary>
        /// Returns int2.xxxy swizzling.
        /// </summary>
        [Inline]
        public int4 xxxy =>  int4(x, x, x, y);
        
        /// <summary>
        /// Returns int2.rrrg swizzling (equivalent to int2.xxxy).
        /// </summary>
        [Inline]
        public int4 rrrg =>  int4(x, x, x, y);
        
        /// <summary>
        /// Returns int2.xxy swizzling.
        /// </summary>
        [Inline]
        public int3 xxy =>  int3(x, x, y);
        
        /// <summary>
        /// Returns int2.rrg swizzling (equivalent to int2.xxy).
        /// </summary>
        [Inline]
        public int3 rrg =>  int3(x, x, y);
        
        /// <summary>
        /// Returns int2.xxyx swizzling.
        /// </summary>
        [Inline]
        public int4 xxyx =>  int4(x, x, y, x);
        
        /// <summary>
        /// Returns int2.rrgr swizzling (equivalent to int2.xxyx).
        /// </summary>
        [Inline]
        public int4 rrgr =>  int4(x, x, y, x);
        
        /// <summary>
        /// Returns int2.xxyy swizzling.
        /// </summary>
        [Inline]
        public int4 xxyy =>  int4(x, x, y, y);
        
        /// <summary>
        /// Returns int2.rrgg swizzling (equivalent to int2.xxyy).
        /// </summary>
        [Inline]
        public int4 rrgg =>  int4(x, x, y, y);
        
        /// <summary>
        /// Returns int2.xy swizzling.
        /// </summary>
        [Inline]
        public int2 xy =>  int2(x, y);
        
        /// <summary>
        /// Returns int2.rg swizzling (equivalent to int2.xy).
        /// </summary>
        [Inline]
        public int2 rg =>  int2(x, y);
        
        /// <summary>
        /// Returns int2.xyx swizzling.
        /// </summary>
        [Inline]
        public int3 xyx =>  int3(x, y, x);
        
        /// <summary>
        /// Returns int2.rgr swizzling (equivalent to int2.xyx).
        /// </summary>
        [Inline]
        public int3 rgr =>  int3(x, y, x);
        
        /// <summary>
        /// Returns int2.xyxx swizzling.
        /// </summary>
        [Inline]
        public int4 xyxx =>  int4(x, y, x, x);
        
        /// <summary>
        /// Returns int2.rgrr swizzling (equivalent to int2.xyxx).
        /// </summary>
        [Inline]
        public int4 rgrr =>  int4(x, y, x, x);
        
        /// <summary>
        /// Returns int2.xyxy swizzling.
        /// </summary>
        [Inline]
        public int4 xyxy =>  int4(x, y, x, y);
        
        /// <summary>
        /// Returns int2.rgrg swizzling (equivalent to int2.xyxy).
        /// </summary>
        [Inline]
        public int4 rgrg =>  int4(x, y, x, y);
        
        /// <summary>
        /// Returns int2.xyy swizzling.
        /// </summary>
        [Inline]
        public int3 xyy =>  int3(x, y, y);
        
        /// <summary>
        /// Returns int2.rgg swizzling (equivalent to int2.xyy).
        /// </summary>
        [Inline]
        public int3 rgg =>  int3(x, y, y);
        
        /// <summary>
        /// Returns int2.xyyx swizzling.
        /// </summary>
        [Inline]
        public int4 xyyx =>  int4(x, y, y, x);
        
        /// <summary>
        /// Returns int2.rggr swizzling (equivalent to int2.xyyx).
        /// </summary>
        [Inline]
        public int4 rggr =>  int4(x, y, y, x);
        
        /// <summary>
        /// Returns int2.xyyy swizzling.
        /// </summary>
        [Inline]
        public int4 xyyy =>  int4(x, y, y, y);
        
        /// <summary>
        /// Returns int2.rggg swizzling (equivalent to int2.xyyy).
        /// </summary>
        [Inline]
        public int4 rggg =>  int4(x, y, y, y);
        
        /// <summary>
        /// Returns int2.yx swizzling.
        /// </summary>
        [Inline]
        public int2 yx =>  int2(y, x);
        
        /// <summary>
        /// Returns int2.gr swizzling (equivalent to int2.yx).
        /// </summary>
        [Inline]
        public int2 gr =>  int2(y, x);
        
        /// <summary>
        /// Returns int2.yxx swizzling.
        /// </summary>
        [Inline]
        public int3 yxx =>  int3(y, x, x);
        
        /// <summary>
        /// Returns int2.grr swizzling (equivalent to int2.yxx).
        /// </summary>
        [Inline]
        public int3 grr =>  int3(y, x, x);
        
        /// <summary>
        /// Returns int2.yxxx swizzling.
        /// </summary>
        [Inline]
        public int4 yxxx =>  int4(y, x, x, x);
        
        /// <summary>
        /// Returns int2.grrr swizzling (equivalent to int2.yxxx).
        /// </summary>
        [Inline]
        public int4 grrr =>  int4(y, x, x, x);
        
        /// <summary>
        /// Returns int2.yxxy swizzling.
        /// </summary>
        [Inline]
        public int4 yxxy =>  int4(y, x, x, y);
        
        /// <summary>
        /// Returns int2.grrg swizzling (equivalent to int2.yxxy).
        /// </summary>
        [Inline]
        public int4 grrg =>  int4(y, x, x, y);
        
        /// <summary>
        /// Returns int2.yxy swizzling.
        /// </summary>
        [Inline]
        public int3 yxy =>  int3(y, x, y);
        
        /// <summary>
        /// Returns int2.grg swizzling (equivalent to int2.yxy).
        /// </summary>
        [Inline]
        public int3 grg =>  int3(y, x, y);
        
        /// <summary>
        /// Returns int2.yxyx swizzling.
        /// </summary>
        [Inline]
        public int4 yxyx =>  int4(y, x, y, x);
        
        /// <summary>
        /// Returns int2.grgr swizzling (equivalent to int2.yxyx).
        /// </summary>
        [Inline]
        public int4 grgr =>  int4(y, x, y, x);
        
        /// <summary>
        /// Returns int2.yxyy swizzling.
        /// </summary>
        [Inline]
        public int4 yxyy =>  int4(y, x, y, y);
        
        /// <summary>
        /// Returns int2.grgg swizzling (equivalent to int2.yxyy).
        /// </summary>
        [Inline]
        public int4 grgg =>  int4(y, x, y, y);
        
        /// <summary>
        /// Returns int2.yy swizzling.
        /// </summary>
        [Inline]
        public int2 yy =>  int2(y, y);
        
        /// <summary>
        /// Returns int2.gg swizzling (equivalent to int2.yy).
        /// </summary>
        [Inline]
        public int2 gg =>  int2(y, y);
        
        /// <summary>
        /// Returns int2.yyx swizzling.
        /// </summary>
        [Inline]
        public int3 yyx =>  int3(y, y, x);
        
        /// <summary>
        /// Returns int2.ggr swizzling (equivalent to int2.yyx).
        /// </summary>
        [Inline]
        public int3 ggr =>  int3(y, y, x);
        
        /// <summary>
        /// Returns int2.yyxx swizzling.
        /// </summary>
        [Inline]
        public int4 yyxx =>  int4(y, y, x, x);
        
        /// <summary>
        /// Returns int2.ggrr swizzling (equivalent to int2.yyxx).
        /// </summary>
        [Inline]
        public int4 ggrr =>  int4(y, y, x, x);
        
        /// <summary>
        /// Returns int2.yyxy swizzling.
        /// </summary>
        [Inline]
        public int4 yyxy =>  int4(y, y, x, y);
        
        /// <summary>
        /// Returns int2.ggrg swizzling (equivalent to int2.yyxy).
        /// </summary>
        [Inline]
        public int4 ggrg =>  int4(y, y, x, y);
        
        /// <summary>
        /// Returns int2.yyy swizzling.
        /// </summary>
        [Inline]
        public int3 yyy =>  int3(y, y, y);
        
        /// <summary>
        /// Returns int2.ggg swizzling (equivalent to int2.yyy).
        /// </summary>
        [Inline]
        public int3 ggg =>  int3(y, y, y);
        
        /// <summary>
        /// Returns int2.yyyx swizzling.
        /// </summary>
        [Inline]
        public int4 yyyx =>  int4(y, y, y, x);
        
        /// <summary>
        /// Returns int2.gggr swizzling (equivalent to int2.yyyx).
        /// </summary>
        [Inline]
        public int4 gggr =>  int4(y, y, y, x);
        
        /// <summary>
        /// Returns int2.yyyy swizzling.
        /// </summary>
        [Inline]
        public int4 yyyy =>  int4(y, y, y, y);
        
        /// <summary>
        /// Returns int2.gggg swizzling (equivalent to int2.yyyy).
        /// </summary>
        [Inline]
        public int4 gggg =>  int4(y, y, y, y);

        //#endregion

    }
}
