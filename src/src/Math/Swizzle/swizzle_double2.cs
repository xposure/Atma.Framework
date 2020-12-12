using System;
namespace Atma
{
    
    /// <summary>
    /// Temporary vector of type double with 2 components, used for implementing swizzling for double2.
    /// </summary>
    public struct swizzle_double2
    {

        //#region Fields
        
        /// <summary>
        /// x-component
        /// </summary>
        private readonly double x;
        
        /// <summary>
        /// y-component
        /// </summary>
        private readonly double y;

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Returns double2.xx swizzling.
        /// </summary>
        [Inline]
        public double2 xx =>  double2(x, x);
        
        /// <summary>
        /// Returns double2.rr swizzling (equivalent to double2.xx).
        /// </summary>
        [Inline]
        public double2 rr =>  double2(x, x);
        
        /// <summary>
        /// Returns double2.xxx swizzling.
        /// </summary>
        [Inline]
        public double3 xxx =>  double3(x, x, x);
        
        /// <summary>
        /// Returns double2.rrr swizzling (equivalent to double2.xxx).
        /// </summary>
        [Inline]
        public double3 rrr =>  double3(x, x, x);
        
        /// <summary>
        /// Returns double2.xxxx swizzling.
        /// </summary>
        [Inline]
        public double4 xxxx =>  double4(x, x, x, x);
        
        /// <summary>
        /// Returns double2.rrrr swizzling (equivalent to double2.xxxx).
        /// </summary>
        [Inline]
        public double4 rrrr =>  double4(x, x, x, x);
        
        /// <summary>
        /// Returns double2.xxxy swizzling.
        /// </summary>
        [Inline]
        public double4 xxxy =>  double4(x, x, x, y);
        
        /// <summary>
        /// Returns double2.rrrg swizzling (equivalent to double2.xxxy).
        /// </summary>
        [Inline]
        public double4 rrrg =>  double4(x, x, x, y);
        
        /// <summary>
        /// Returns double2.xxy swizzling.
        /// </summary>
        [Inline]
        public double3 xxy =>  double3(x, x, y);
        
        /// <summary>
        /// Returns double2.rrg swizzling (equivalent to double2.xxy).
        /// </summary>
        [Inline]
        public double3 rrg =>  double3(x, x, y);
        
        /// <summary>
        /// Returns double2.xxyx swizzling.
        /// </summary>
        [Inline]
        public double4 xxyx =>  double4(x, x, y, x);
        
        /// <summary>
        /// Returns double2.rrgr swizzling (equivalent to double2.xxyx).
        /// </summary>
        [Inline]
        public double4 rrgr =>  double4(x, x, y, x);
        
        /// <summary>
        /// Returns double2.xxyy swizzling.
        /// </summary>
        [Inline]
        public double4 xxyy =>  double4(x, x, y, y);
        
        /// <summary>
        /// Returns double2.rrgg swizzling (equivalent to double2.xxyy).
        /// </summary>
        [Inline]
        public double4 rrgg =>  double4(x, x, y, y);
        
        /// <summary>
        /// Returns double2.xy swizzling.
        /// </summary>
        [Inline]
        public double2 xy =>  double2(x, y);
        
        /// <summary>
        /// Returns double2.rg swizzling (equivalent to double2.xy).
        /// </summary>
        [Inline]
        public double2 rg =>  double2(x, y);
        
        /// <summary>
        /// Returns double2.xyx swizzling.
        /// </summary>
        [Inline]
        public double3 xyx =>  double3(x, y, x);
        
        /// <summary>
        /// Returns double2.rgr swizzling (equivalent to double2.xyx).
        /// </summary>
        [Inline]
        public double3 rgr =>  double3(x, y, x);
        
        /// <summary>
        /// Returns double2.xyxx swizzling.
        /// </summary>
        [Inline]
        public double4 xyxx =>  double4(x, y, x, x);
        
        /// <summary>
        /// Returns double2.rgrr swizzling (equivalent to double2.xyxx).
        /// </summary>
        [Inline]
        public double4 rgrr =>  double4(x, y, x, x);
        
        /// <summary>
        /// Returns double2.xyxy swizzling.
        /// </summary>
        [Inline]
        public double4 xyxy =>  double4(x, y, x, y);
        
        /// <summary>
        /// Returns double2.rgrg swizzling (equivalent to double2.xyxy).
        /// </summary>
        [Inline]
        public double4 rgrg =>  double4(x, y, x, y);
        
        /// <summary>
        /// Returns double2.xyy swizzling.
        /// </summary>
        [Inline]
        public double3 xyy =>  double3(x, y, y);
        
        /// <summary>
        /// Returns double2.rgg swizzling (equivalent to double2.xyy).
        /// </summary>
        [Inline]
        public double3 rgg =>  double3(x, y, y);
        
        /// <summary>
        /// Returns double2.xyyx swizzling.
        /// </summary>
        [Inline]
        public double4 xyyx =>  double4(x, y, y, x);
        
        /// <summary>
        /// Returns double2.rggr swizzling (equivalent to double2.xyyx).
        /// </summary>
        [Inline]
        public double4 rggr =>  double4(x, y, y, x);
        
        /// <summary>
        /// Returns double2.xyyy swizzling.
        /// </summary>
        [Inline]
        public double4 xyyy =>  double4(x, y, y, y);
        
        /// <summary>
        /// Returns double2.rggg swizzling (equivalent to double2.xyyy).
        /// </summary>
        [Inline]
        public double4 rggg =>  double4(x, y, y, y);
        
        /// <summary>
        /// Returns double2.yx swizzling.
        /// </summary>
        [Inline]
        public double2 yx =>  double2(y, x);
        
        /// <summary>
        /// Returns double2.gr swizzling (equivalent to double2.yx).
        /// </summary>
        [Inline]
        public double2 gr =>  double2(y, x);
        
        /// <summary>
        /// Returns double2.yxx swizzling.
        /// </summary>
        [Inline]
        public double3 yxx =>  double3(y, x, x);
        
        /// <summary>
        /// Returns double2.grr swizzling (equivalent to double2.yxx).
        /// </summary>
        [Inline]
        public double3 grr =>  double3(y, x, x);
        
        /// <summary>
        /// Returns double2.yxxx swizzling.
        /// </summary>
        [Inline]
        public double4 yxxx =>  double4(y, x, x, x);
        
        /// <summary>
        /// Returns double2.grrr swizzling (equivalent to double2.yxxx).
        /// </summary>
        [Inline]
        public double4 grrr =>  double4(y, x, x, x);
        
        /// <summary>
        /// Returns double2.yxxy swizzling.
        /// </summary>
        [Inline]
        public double4 yxxy =>  double4(y, x, x, y);
        
        /// <summary>
        /// Returns double2.grrg swizzling (equivalent to double2.yxxy).
        /// </summary>
        [Inline]
        public double4 grrg =>  double4(y, x, x, y);
        
        /// <summary>
        /// Returns double2.yxy swizzling.
        /// </summary>
        [Inline]
        public double3 yxy =>  double3(y, x, y);
        
        /// <summary>
        /// Returns double2.grg swizzling (equivalent to double2.yxy).
        /// </summary>
        [Inline]
        public double3 grg =>  double3(y, x, y);
        
        /// <summary>
        /// Returns double2.yxyx swizzling.
        /// </summary>
        [Inline]
        public double4 yxyx =>  double4(y, x, y, x);
        
        /// <summary>
        /// Returns double2.grgr swizzling (equivalent to double2.yxyx).
        /// </summary>
        [Inline]
        public double4 grgr =>  double4(y, x, y, x);
        
        /// <summary>
        /// Returns double2.yxyy swizzling.
        /// </summary>
        [Inline]
        public double4 yxyy =>  double4(y, x, y, y);
        
        /// <summary>
        /// Returns double2.grgg swizzling (equivalent to double2.yxyy).
        /// </summary>
        [Inline]
        public double4 grgg =>  double4(y, x, y, y);
        
        /// <summary>
        /// Returns double2.yy swizzling.
        /// </summary>
        [Inline]
        public double2 yy =>  double2(y, y);
        
        /// <summary>
        /// Returns double2.gg swizzling (equivalent to double2.yy).
        /// </summary>
        [Inline]
        public double2 gg =>  double2(y, y);
        
        /// <summary>
        /// Returns double2.yyx swizzling.
        /// </summary>
        [Inline]
        public double3 yyx =>  double3(y, y, x);
        
        /// <summary>
        /// Returns double2.ggr swizzling (equivalent to double2.yyx).
        /// </summary>
        [Inline]
        public double3 ggr =>  double3(y, y, x);
        
        /// <summary>
        /// Returns double2.yyxx swizzling.
        /// </summary>
        [Inline]
        public double4 yyxx =>  double4(y, y, x, x);
        
        /// <summary>
        /// Returns double2.ggrr swizzling (equivalent to double2.yyxx).
        /// </summary>
        [Inline]
        public double4 ggrr =>  double4(y, y, x, x);
        
        /// <summary>
        /// Returns double2.yyxy swizzling.
        /// </summary>
        [Inline]
        public double4 yyxy =>  double4(y, y, x, y);
        
        /// <summary>
        /// Returns double2.ggrg swizzling (equivalent to double2.yyxy).
        /// </summary>
        [Inline]
        public double4 ggrg =>  double4(y, y, x, y);
        
        /// <summary>
        /// Returns double2.yyy swizzling.
        /// </summary>
        [Inline]
        public double3 yyy =>  double3(y, y, y);
        
        /// <summary>
        /// Returns double2.ggg swizzling (equivalent to double2.yyy).
        /// </summary>
        [Inline]
        public double3 ggg =>  double3(y, y, y);
        
        /// <summary>
        /// Returns double2.yyyx swizzling.
        /// </summary>
        [Inline]
        public double4 yyyx =>  double4(y, y, y, x);
        
        /// <summary>
        /// Returns double2.gggr swizzling (equivalent to double2.yyyx).
        /// </summary>
        [Inline]
        public double4 gggr =>  double4(y, y, y, x);
        
        /// <summary>
        /// Returns double2.yyyy swizzling.
        /// </summary>
        [Inline]
        public double4 yyyy =>  double4(y, y, y, y);
        
        /// <summary>
        /// Returns double2.gggg swizzling (equivalent to double2.yyyy).
        /// </summary>
        [Inline]
        public double4 gggg =>  double4(y, y, y, y);

        //#endregion

    }
}
