using System;
namespace Atma
{
    
    /// <summary>
    /// Temporary vector of type uint with 2 components, used for implementing swizzling for uint2.
    /// </summary>
    public struct swizzle_uint2
    {

        //#region Fields
        
        /// <summary>
        /// x-component
        /// </summary>
        private readonly uint x;
        
        /// <summary>
        /// y-component
        /// </summary>
        private readonly uint y;

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Returns uint2.xx swizzling.
        /// </summary>
        [Inline]
        public uint2 xx =>  uint2(x, x);
        
        /// <summary>
        /// Returns uint2.rr swizzling (equivalent to uint2.xx).
        /// </summary>
        [Inline]
        public uint2 rr =>  uint2(x, x);
        
        /// <summary>
        /// Returns uint2.xxx swizzling.
        /// </summary>
        [Inline]
        public uint3 xxx =>  uint3(x, x, x);
        
        /// <summary>
        /// Returns uint2.rrr swizzling (equivalent to uint2.xxx).
        /// </summary>
        [Inline]
        public uint3 rrr =>  uint3(x, x, x);
        
        /// <summary>
        /// Returns uint2.xxxx swizzling.
        /// </summary>
        [Inline]
        public uint4 xxxx =>  uint4(x, x, x, x);
        
        /// <summary>
        /// Returns uint2.rrrr swizzling (equivalent to uint2.xxxx).
        /// </summary>
        [Inline]
        public uint4 rrrr =>  uint4(x, x, x, x);
        
        /// <summary>
        /// Returns uint2.xxxy swizzling.
        /// </summary>
        [Inline]
        public uint4 xxxy =>  uint4(x, x, x, y);
        
        /// <summary>
        /// Returns uint2.rrrg swizzling (equivalent to uint2.xxxy).
        /// </summary>
        [Inline]
        public uint4 rrrg =>  uint4(x, x, x, y);
        
        /// <summary>
        /// Returns uint2.xxy swizzling.
        /// </summary>
        [Inline]
        public uint3 xxy =>  uint3(x, x, y);
        
        /// <summary>
        /// Returns uint2.rrg swizzling (equivalent to uint2.xxy).
        /// </summary>
        [Inline]
        public uint3 rrg =>  uint3(x, x, y);
        
        /// <summary>
        /// Returns uint2.xxyx swizzling.
        /// </summary>
        [Inline]
        public uint4 xxyx =>  uint4(x, x, y, x);
        
        /// <summary>
        /// Returns uint2.rrgr swizzling (equivalent to uint2.xxyx).
        /// </summary>
        [Inline]
        public uint4 rrgr =>  uint4(x, x, y, x);
        
        /// <summary>
        /// Returns uint2.xxyy swizzling.
        /// </summary>
        [Inline]
        public uint4 xxyy =>  uint4(x, x, y, y);
        
        /// <summary>
        /// Returns uint2.rrgg swizzling (equivalent to uint2.xxyy).
        /// </summary>
        [Inline]
        public uint4 rrgg =>  uint4(x, x, y, y);
        
        /// <summary>
        /// Returns uint2.xy swizzling.
        /// </summary>
        [Inline]
        public uint2 xy =>  uint2(x, y);
        
        /// <summary>
        /// Returns uint2.rg swizzling (equivalent to uint2.xy).
        /// </summary>
        [Inline]
        public uint2 rg =>  uint2(x, y);
        
        /// <summary>
        /// Returns uint2.xyx swizzling.
        /// </summary>
        [Inline]
        public uint3 xyx =>  uint3(x, y, x);
        
        /// <summary>
        /// Returns uint2.rgr swizzling (equivalent to uint2.xyx).
        /// </summary>
        [Inline]
        public uint3 rgr =>  uint3(x, y, x);
        
        /// <summary>
        /// Returns uint2.xyxx swizzling.
        /// </summary>
        [Inline]
        public uint4 xyxx =>  uint4(x, y, x, x);
        
        /// <summary>
        /// Returns uint2.rgrr swizzling (equivalent to uint2.xyxx).
        /// </summary>
        [Inline]
        public uint4 rgrr =>  uint4(x, y, x, x);
        
        /// <summary>
        /// Returns uint2.xyxy swizzling.
        /// </summary>
        [Inline]
        public uint4 xyxy =>  uint4(x, y, x, y);
        
        /// <summary>
        /// Returns uint2.rgrg swizzling (equivalent to uint2.xyxy).
        /// </summary>
        [Inline]
        public uint4 rgrg =>  uint4(x, y, x, y);
        
        /// <summary>
        /// Returns uint2.xyy swizzling.
        /// </summary>
        [Inline]
        public uint3 xyy =>  uint3(x, y, y);
        
        /// <summary>
        /// Returns uint2.rgg swizzling (equivalent to uint2.xyy).
        /// </summary>
        [Inline]
        public uint3 rgg =>  uint3(x, y, y);
        
        /// <summary>
        /// Returns uint2.xyyx swizzling.
        /// </summary>
        [Inline]
        public uint4 xyyx =>  uint4(x, y, y, x);
        
        /// <summary>
        /// Returns uint2.rggr swizzling (equivalent to uint2.xyyx).
        /// </summary>
        [Inline]
        public uint4 rggr =>  uint4(x, y, y, x);
        
        /// <summary>
        /// Returns uint2.xyyy swizzling.
        /// </summary>
        [Inline]
        public uint4 xyyy =>  uint4(x, y, y, y);
        
        /// <summary>
        /// Returns uint2.rggg swizzling (equivalent to uint2.xyyy).
        /// </summary>
        [Inline]
        public uint4 rggg =>  uint4(x, y, y, y);
        
        /// <summary>
        /// Returns uint2.yx swizzling.
        /// </summary>
        [Inline]
        public uint2 yx =>  uint2(y, x);
        
        /// <summary>
        /// Returns uint2.gr swizzling (equivalent to uint2.yx).
        /// </summary>
        [Inline]
        public uint2 gr =>  uint2(y, x);
        
        /// <summary>
        /// Returns uint2.yxx swizzling.
        /// </summary>
        [Inline]
        public uint3 yxx =>  uint3(y, x, x);
        
        /// <summary>
        /// Returns uint2.grr swizzling (equivalent to uint2.yxx).
        /// </summary>
        [Inline]
        public uint3 grr =>  uint3(y, x, x);
        
        /// <summary>
        /// Returns uint2.yxxx swizzling.
        /// </summary>
        [Inline]
        public uint4 yxxx =>  uint4(y, x, x, x);
        
        /// <summary>
        /// Returns uint2.grrr swizzling (equivalent to uint2.yxxx).
        /// </summary>
        [Inline]
        public uint4 grrr =>  uint4(y, x, x, x);
        
        /// <summary>
        /// Returns uint2.yxxy swizzling.
        /// </summary>
        [Inline]
        public uint4 yxxy =>  uint4(y, x, x, y);
        
        /// <summary>
        /// Returns uint2.grrg swizzling (equivalent to uint2.yxxy).
        /// </summary>
        [Inline]
        public uint4 grrg =>  uint4(y, x, x, y);
        
        /// <summary>
        /// Returns uint2.yxy swizzling.
        /// </summary>
        [Inline]
        public uint3 yxy =>  uint3(y, x, y);
        
        /// <summary>
        /// Returns uint2.grg swizzling (equivalent to uint2.yxy).
        /// </summary>
        [Inline]
        public uint3 grg =>  uint3(y, x, y);
        
        /// <summary>
        /// Returns uint2.yxyx swizzling.
        /// </summary>
        [Inline]
        public uint4 yxyx =>  uint4(y, x, y, x);
        
        /// <summary>
        /// Returns uint2.grgr swizzling (equivalent to uint2.yxyx).
        /// </summary>
        [Inline]
        public uint4 grgr =>  uint4(y, x, y, x);
        
        /// <summary>
        /// Returns uint2.yxyy swizzling.
        /// </summary>
        [Inline]
        public uint4 yxyy =>  uint4(y, x, y, y);
        
        /// <summary>
        /// Returns uint2.grgg swizzling (equivalent to uint2.yxyy).
        /// </summary>
        [Inline]
        public uint4 grgg =>  uint4(y, x, y, y);
        
        /// <summary>
        /// Returns uint2.yy swizzling.
        /// </summary>
        [Inline]
        public uint2 yy =>  uint2(y, y);
        
        /// <summary>
        /// Returns uint2.gg swizzling (equivalent to uint2.yy).
        /// </summary>
        [Inline]
        public uint2 gg =>  uint2(y, y);
        
        /// <summary>
        /// Returns uint2.yyx swizzling.
        /// </summary>
        [Inline]
        public uint3 yyx =>  uint3(y, y, x);
        
        /// <summary>
        /// Returns uint2.ggr swizzling (equivalent to uint2.yyx).
        /// </summary>
        [Inline]
        public uint3 ggr =>  uint3(y, y, x);
        
        /// <summary>
        /// Returns uint2.yyxx swizzling.
        /// </summary>
        [Inline]
        public uint4 yyxx =>  uint4(y, y, x, x);
        
        /// <summary>
        /// Returns uint2.ggrr swizzling (equivalent to uint2.yyxx).
        /// </summary>
        [Inline]
        public uint4 ggrr =>  uint4(y, y, x, x);
        
        /// <summary>
        /// Returns uint2.yyxy swizzling.
        /// </summary>
        [Inline]
        public uint4 yyxy =>  uint4(y, y, x, y);
        
        /// <summary>
        /// Returns uint2.ggrg swizzling (equivalent to uint2.yyxy).
        /// </summary>
        [Inline]
        public uint4 ggrg =>  uint4(y, y, x, y);
        
        /// <summary>
        /// Returns uint2.yyy swizzling.
        /// </summary>
        [Inline]
        public uint3 yyy =>  uint3(y, y, y);
        
        /// <summary>
        /// Returns uint2.ggg swizzling (equivalent to uint2.yyy).
        /// </summary>
        [Inline]
        public uint3 ggg =>  uint3(y, y, y);
        
        /// <summary>
        /// Returns uint2.yyyx swizzling.
        /// </summary>
        [Inline]
        public uint4 yyyx =>  uint4(y, y, y, x);
        
        /// <summary>
        /// Returns uint2.gggr swizzling (equivalent to uint2.yyyx).
        /// </summary>
        [Inline]
        public uint4 gggr =>  uint4(y, y, y, x);
        
        /// <summary>
        /// Returns uint2.yyyy swizzling.
        /// </summary>
        [Inline]
        public uint4 yyyy =>  uint4(y, y, y, y);
        
        /// <summary>
        /// Returns uint2.gggg swizzling (equivalent to uint2.yyyy).
        /// </summary>
        [Inline]
        public uint4 gggg =>  uint4(y, y, y, y);

        //#endregion

    }
}
