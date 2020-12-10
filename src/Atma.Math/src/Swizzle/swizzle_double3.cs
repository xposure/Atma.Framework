using System;
namespace Atma
{
    
    /// <summary>
    /// Temporary vector of type double with 3 components, used for implementing swizzling for double3.
    /// </summary>
    public struct swizzle_double3
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
        
        /// <summary>
        /// z-component
        /// </summary>
        private readonly double z;

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Returns double3.xx swizzling.
        /// </summary>
        [Inline]
        public double2 xx =>  double2(x, x);
        
        /// <summary>
        /// Returns double3.rr swizzling (equivalent to double3.xx).
        /// </summary>
        [Inline]
        public double2 rr =>  double2(x, x);
        
        /// <summary>
        /// Returns double3.xxx swizzling.
        /// </summary>
        [Inline]
        public double3 xxx =>  double3(x, x, x);
        
        /// <summary>
        /// Returns double3.rrr swizzling (equivalent to double3.xxx).
        /// </summary>
        [Inline]
        public double3 rrr =>  double3(x, x, x);
        
        /// <summary>
        /// Returns double3.xxxx swizzling.
        /// </summary>
        [Inline]
        public double4 xxxx =>  double4(x, x, x, x);
        
        /// <summary>
        /// Returns double3.rrrr swizzling (equivalent to double3.xxxx).
        /// </summary>
        [Inline]
        public double4 rrrr =>  double4(x, x, x, x);
        
        /// <summary>
        /// Returns double3.xxxy swizzling.
        /// </summary>
        [Inline]
        public double4 xxxy =>  double4(x, x, x, y);
        
        /// <summary>
        /// Returns double3.rrrg swizzling (equivalent to double3.xxxy).
        /// </summary>
        [Inline]
        public double4 rrrg =>  double4(x, x, x, y);
        
        /// <summary>
        /// Returns double3.xxxz swizzling.
        /// </summary>
        [Inline]
        public double4 xxxz =>  double4(x, x, x, z);
        
        /// <summary>
        /// Returns double3.rrrb swizzling (equivalent to double3.xxxz).
        /// </summary>
        [Inline]
        public double4 rrrb =>  double4(x, x, x, z);
        
        /// <summary>
        /// Returns double3.xxy swizzling.
        /// </summary>
        [Inline]
        public double3 xxy =>  double3(x, x, y);
        
        /// <summary>
        /// Returns double3.rrg swizzling (equivalent to double3.xxy).
        /// </summary>
        [Inline]
        public double3 rrg =>  double3(x, x, y);
        
        /// <summary>
        /// Returns double3.xxyx swizzling.
        /// </summary>
        [Inline]
        public double4 xxyx =>  double4(x, x, y, x);
        
        /// <summary>
        /// Returns double3.rrgr swizzling (equivalent to double3.xxyx).
        /// </summary>
        [Inline]
        public double4 rrgr =>  double4(x, x, y, x);
        
        /// <summary>
        /// Returns double3.xxyy swizzling.
        /// </summary>
        [Inline]
        public double4 xxyy =>  double4(x, x, y, y);
        
        /// <summary>
        /// Returns double3.rrgg swizzling (equivalent to double3.xxyy).
        /// </summary>
        [Inline]
        public double4 rrgg =>  double4(x, x, y, y);
        
        /// <summary>
        /// Returns double3.xxyz swizzling.
        /// </summary>
        [Inline]
        public double4 xxyz =>  double4(x, x, y, z);
        
        /// <summary>
        /// Returns double3.rrgb swizzling (equivalent to double3.xxyz).
        /// </summary>
        [Inline]
        public double4 rrgb =>  double4(x, x, y, z);
        
        /// <summary>
        /// Returns double3.xxz swizzling.
        /// </summary>
        [Inline]
        public double3 xxz =>  double3(x, x, z);
        
        /// <summary>
        /// Returns double3.rrb swizzling (equivalent to double3.xxz).
        /// </summary>
        [Inline]
        public double3 rrb =>  double3(x, x, z);
        
        /// <summary>
        /// Returns double3.xxzx swizzling.
        /// </summary>
        [Inline]
        public double4 xxzx =>  double4(x, x, z, x);
        
        /// <summary>
        /// Returns double3.rrbr swizzling (equivalent to double3.xxzx).
        /// </summary>
        [Inline]
        public double4 rrbr =>  double4(x, x, z, x);
        
        /// <summary>
        /// Returns double3.xxzy swizzling.
        /// </summary>
        [Inline]
        public double4 xxzy =>  double4(x, x, z, y);
        
        /// <summary>
        /// Returns double3.rrbg swizzling (equivalent to double3.xxzy).
        /// </summary>
        [Inline]
        public double4 rrbg =>  double4(x, x, z, y);
        
        /// <summary>
        /// Returns double3.xxzz swizzling.
        /// </summary>
        [Inline]
        public double4 xxzz =>  double4(x, x, z, z);
        
        /// <summary>
        /// Returns double3.rrbb swizzling (equivalent to double3.xxzz).
        /// </summary>
        [Inline]
        public double4 rrbb =>  double4(x, x, z, z);
        
        /// <summary>
        /// Returns double3.xy swizzling.
        /// </summary>
        [Inline]
        public double2 xy =>  double2(x, y);
        
        /// <summary>
        /// Returns double3.rg swizzling (equivalent to double3.xy).
        /// </summary>
        [Inline]
        public double2 rg =>  double2(x, y);
        
        /// <summary>
        /// Returns double3.xyx swizzling.
        /// </summary>
        [Inline]
        public double3 xyx =>  double3(x, y, x);
        
        /// <summary>
        /// Returns double3.rgr swizzling (equivalent to double3.xyx).
        /// </summary>
        [Inline]
        public double3 rgr =>  double3(x, y, x);
        
        /// <summary>
        /// Returns double3.xyxx swizzling.
        /// </summary>
        [Inline]
        public double4 xyxx =>  double4(x, y, x, x);
        
        /// <summary>
        /// Returns double3.rgrr swizzling (equivalent to double3.xyxx).
        /// </summary>
        [Inline]
        public double4 rgrr =>  double4(x, y, x, x);
        
        /// <summary>
        /// Returns double3.xyxy swizzling.
        /// </summary>
        [Inline]
        public double4 xyxy =>  double4(x, y, x, y);
        
        /// <summary>
        /// Returns double3.rgrg swizzling (equivalent to double3.xyxy).
        /// </summary>
        [Inline]
        public double4 rgrg =>  double4(x, y, x, y);
        
        /// <summary>
        /// Returns double3.xyxz swizzling.
        /// </summary>
        [Inline]
        public double4 xyxz =>  double4(x, y, x, z);
        
        /// <summary>
        /// Returns double3.rgrb swizzling (equivalent to double3.xyxz).
        /// </summary>
        [Inline]
        public double4 rgrb =>  double4(x, y, x, z);
        
        /// <summary>
        /// Returns double3.xyy swizzling.
        /// </summary>
        [Inline]
        public double3 xyy =>  double3(x, y, y);
        
        /// <summary>
        /// Returns double3.rgg swizzling (equivalent to double3.xyy).
        /// </summary>
        [Inline]
        public double3 rgg =>  double3(x, y, y);
        
        /// <summary>
        /// Returns double3.xyyx swizzling.
        /// </summary>
        [Inline]
        public double4 xyyx =>  double4(x, y, y, x);
        
        /// <summary>
        /// Returns double3.rggr swizzling (equivalent to double3.xyyx).
        /// </summary>
        [Inline]
        public double4 rggr =>  double4(x, y, y, x);
        
        /// <summary>
        /// Returns double3.xyyy swizzling.
        /// </summary>
        [Inline]
        public double4 xyyy =>  double4(x, y, y, y);
        
        /// <summary>
        /// Returns double3.rggg swizzling (equivalent to double3.xyyy).
        /// </summary>
        [Inline]
        public double4 rggg =>  double4(x, y, y, y);
        
        /// <summary>
        /// Returns double3.xyyz swizzling.
        /// </summary>
        [Inline]
        public double4 xyyz =>  double4(x, y, y, z);
        
        /// <summary>
        /// Returns double3.rggb swizzling (equivalent to double3.xyyz).
        /// </summary>
        [Inline]
        public double4 rggb =>  double4(x, y, y, z);
        
        /// <summary>
        /// Returns double3.xyz swizzling.
        /// </summary>
        [Inline]
        public double3 xyz =>  double3(x, y, z);
        
        /// <summary>
        /// Returns double3.rgb swizzling (equivalent to double3.xyz).
        /// </summary>
        [Inline]
        public double3 rgb =>  double3(x, y, z);
        
        /// <summary>
        /// Returns double3.xyzx swizzling.
        /// </summary>
        [Inline]
        public double4 xyzx =>  double4(x, y, z, x);
        
        /// <summary>
        /// Returns double3.rgbr swizzling (equivalent to double3.xyzx).
        /// </summary>
        [Inline]
        public double4 rgbr =>  double4(x, y, z, x);
        
        /// <summary>
        /// Returns double3.xyzy swizzling.
        /// </summary>
        [Inline]
        public double4 xyzy =>  double4(x, y, z, y);
        
        /// <summary>
        /// Returns double3.rgbg swizzling (equivalent to double3.xyzy).
        /// </summary>
        [Inline]
        public double4 rgbg =>  double4(x, y, z, y);
        
        /// <summary>
        /// Returns double3.xyzz swizzling.
        /// </summary>
        [Inline]
        public double4 xyzz =>  double4(x, y, z, z);
        
        /// <summary>
        /// Returns double3.rgbb swizzling (equivalent to double3.xyzz).
        /// </summary>
        [Inline]
        public double4 rgbb =>  double4(x, y, z, z);
        
        /// <summary>
        /// Returns double3.xz swizzling.
        /// </summary>
        [Inline]
        public double2 xz =>  double2(x, z);
        
        /// <summary>
        /// Returns double3.rb swizzling (equivalent to double3.xz).
        /// </summary>
        [Inline]
        public double2 rb =>  double2(x, z);
        
        /// <summary>
        /// Returns double3.xzx swizzling.
        /// </summary>
        [Inline]
        public double3 xzx =>  double3(x, z, x);
        
        /// <summary>
        /// Returns double3.rbr swizzling (equivalent to double3.xzx).
        /// </summary>
        [Inline]
        public double3 rbr =>  double3(x, z, x);
        
        /// <summary>
        /// Returns double3.xzxx swizzling.
        /// </summary>
        [Inline]
        public double4 xzxx =>  double4(x, z, x, x);
        
        /// <summary>
        /// Returns double3.rbrr swizzling (equivalent to double3.xzxx).
        /// </summary>
        [Inline]
        public double4 rbrr =>  double4(x, z, x, x);
        
        /// <summary>
        /// Returns double3.xzxy swizzling.
        /// </summary>
        [Inline]
        public double4 xzxy =>  double4(x, z, x, y);
        
        /// <summary>
        /// Returns double3.rbrg swizzling (equivalent to double3.xzxy).
        /// </summary>
        [Inline]
        public double4 rbrg =>  double4(x, z, x, y);
        
        /// <summary>
        /// Returns double3.xzxz swizzling.
        /// </summary>
        [Inline]
        public double4 xzxz =>  double4(x, z, x, z);
        
        /// <summary>
        /// Returns double3.rbrb swizzling (equivalent to double3.xzxz).
        /// </summary>
        [Inline]
        public double4 rbrb =>  double4(x, z, x, z);
        
        /// <summary>
        /// Returns double3.xzy swizzling.
        /// </summary>
        [Inline]
        public double3 xzy =>  double3(x, z, y);
        
        /// <summary>
        /// Returns double3.rbg swizzling (equivalent to double3.xzy).
        /// </summary>
        [Inline]
        public double3 rbg =>  double3(x, z, y);
        
        /// <summary>
        /// Returns double3.xzyx swizzling.
        /// </summary>
        [Inline]
        public double4 xzyx =>  double4(x, z, y, x);
        
        /// <summary>
        /// Returns double3.rbgr swizzling (equivalent to double3.xzyx).
        /// </summary>
        [Inline]
        public double4 rbgr =>  double4(x, z, y, x);
        
        /// <summary>
        /// Returns double3.xzyy swizzling.
        /// </summary>
        [Inline]
        public double4 xzyy =>  double4(x, z, y, y);
        
        /// <summary>
        /// Returns double3.rbgg swizzling (equivalent to double3.xzyy).
        /// </summary>
        [Inline]
        public double4 rbgg =>  double4(x, z, y, y);
        
        /// <summary>
        /// Returns double3.xzyz swizzling.
        /// </summary>
        [Inline]
        public double4 xzyz =>  double4(x, z, y, z);
        
        /// <summary>
        /// Returns double3.rbgb swizzling (equivalent to double3.xzyz).
        /// </summary>
        [Inline]
        public double4 rbgb =>  double4(x, z, y, z);
        
        /// <summary>
        /// Returns double3.xzz swizzling.
        /// </summary>
        [Inline]
        public double3 xzz =>  double3(x, z, z);
        
        /// <summary>
        /// Returns double3.rbb swizzling (equivalent to double3.xzz).
        /// </summary>
        [Inline]
        public double3 rbb =>  double3(x, z, z);
        
        /// <summary>
        /// Returns double3.xzzx swizzling.
        /// </summary>
        [Inline]
        public double4 xzzx =>  double4(x, z, z, x);
        
        /// <summary>
        /// Returns double3.rbbr swizzling (equivalent to double3.xzzx).
        /// </summary>
        [Inline]
        public double4 rbbr =>  double4(x, z, z, x);
        
        /// <summary>
        /// Returns double3.xzzy swizzling.
        /// </summary>
        [Inline]
        public double4 xzzy =>  double4(x, z, z, y);
        
        /// <summary>
        /// Returns double3.rbbg swizzling (equivalent to double3.xzzy).
        /// </summary>
        [Inline]
        public double4 rbbg =>  double4(x, z, z, y);
        
        /// <summary>
        /// Returns double3.xzzz swizzling.
        /// </summary>
        [Inline]
        public double4 xzzz =>  double4(x, z, z, z);
        
        /// <summary>
        /// Returns double3.rbbb swizzling (equivalent to double3.xzzz).
        /// </summary>
        [Inline]
        public double4 rbbb =>  double4(x, z, z, z);
        
        /// <summary>
        /// Returns double3.yx swizzling.
        /// </summary>
        [Inline]
        public double2 yx =>  double2(y, x);
        
        /// <summary>
        /// Returns double3.gr swizzling (equivalent to double3.yx).
        /// </summary>
        [Inline]
        public double2 gr =>  double2(y, x);
        
        /// <summary>
        /// Returns double3.yxx swizzling.
        /// </summary>
        [Inline]
        public double3 yxx =>  double3(y, x, x);
        
        /// <summary>
        /// Returns double3.grr swizzling (equivalent to double3.yxx).
        /// </summary>
        [Inline]
        public double3 grr =>  double3(y, x, x);
        
        /// <summary>
        /// Returns double3.yxxx swizzling.
        /// </summary>
        [Inline]
        public double4 yxxx =>  double4(y, x, x, x);
        
        /// <summary>
        /// Returns double3.grrr swizzling (equivalent to double3.yxxx).
        /// </summary>
        [Inline]
        public double4 grrr =>  double4(y, x, x, x);
        
        /// <summary>
        /// Returns double3.yxxy swizzling.
        /// </summary>
        [Inline]
        public double4 yxxy =>  double4(y, x, x, y);
        
        /// <summary>
        /// Returns double3.grrg swizzling (equivalent to double3.yxxy).
        /// </summary>
        [Inline]
        public double4 grrg =>  double4(y, x, x, y);
        
        /// <summary>
        /// Returns double3.yxxz swizzling.
        /// </summary>
        [Inline]
        public double4 yxxz =>  double4(y, x, x, z);
        
        /// <summary>
        /// Returns double3.grrb swizzling (equivalent to double3.yxxz).
        /// </summary>
        [Inline]
        public double4 grrb =>  double4(y, x, x, z);
        
        /// <summary>
        /// Returns double3.yxy swizzling.
        /// </summary>
        [Inline]
        public double3 yxy =>  double3(y, x, y);
        
        /// <summary>
        /// Returns double3.grg swizzling (equivalent to double3.yxy).
        /// </summary>
        [Inline]
        public double3 grg =>  double3(y, x, y);
        
        /// <summary>
        /// Returns double3.yxyx swizzling.
        /// </summary>
        [Inline]
        public double4 yxyx =>  double4(y, x, y, x);
        
        /// <summary>
        /// Returns double3.grgr swizzling (equivalent to double3.yxyx).
        /// </summary>
        [Inline]
        public double4 grgr =>  double4(y, x, y, x);
        
        /// <summary>
        /// Returns double3.yxyy swizzling.
        /// </summary>
        [Inline]
        public double4 yxyy =>  double4(y, x, y, y);
        
        /// <summary>
        /// Returns double3.grgg swizzling (equivalent to double3.yxyy).
        /// </summary>
        [Inline]
        public double4 grgg =>  double4(y, x, y, y);
        
        /// <summary>
        /// Returns double3.yxyz swizzling.
        /// </summary>
        [Inline]
        public double4 yxyz =>  double4(y, x, y, z);
        
        /// <summary>
        /// Returns double3.grgb swizzling (equivalent to double3.yxyz).
        /// </summary>
        [Inline]
        public double4 grgb =>  double4(y, x, y, z);
        
        /// <summary>
        /// Returns double3.yxz swizzling.
        /// </summary>
        [Inline]
        public double3 yxz =>  double3(y, x, z);
        
        /// <summary>
        /// Returns double3.grb swizzling (equivalent to double3.yxz).
        /// </summary>
        [Inline]
        public double3 grb =>  double3(y, x, z);
        
        /// <summary>
        /// Returns double3.yxzx swizzling.
        /// </summary>
        [Inline]
        public double4 yxzx =>  double4(y, x, z, x);
        
        /// <summary>
        /// Returns double3.grbr swizzling (equivalent to double3.yxzx).
        /// </summary>
        [Inline]
        public double4 grbr =>  double4(y, x, z, x);
        
        /// <summary>
        /// Returns double3.yxzy swizzling.
        /// </summary>
        [Inline]
        public double4 yxzy =>  double4(y, x, z, y);
        
        /// <summary>
        /// Returns double3.grbg swizzling (equivalent to double3.yxzy).
        /// </summary>
        [Inline]
        public double4 grbg =>  double4(y, x, z, y);
        
        /// <summary>
        /// Returns double3.yxzz swizzling.
        /// </summary>
        [Inline]
        public double4 yxzz =>  double4(y, x, z, z);
        
        /// <summary>
        /// Returns double3.grbb swizzling (equivalent to double3.yxzz).
        /// </summary>
        [Inline]
        public double4 grbb =>  double4(y, x, z, z);
        
        /// <summary>
        /// Returns double3.yy swizzling.
        /// </summary>
        [Inline]
        public double2 yy =>  double2(y, y);
        
        /// <summary>
        /// Returns double3.gg swizzling (equivalent to double3.yy).
        /// </summary>
        [Inline]
        public double2 gg =>  double2(y, y);
        
        /// <summary>
        /// Returns double3.yyx swizzling.
        /// </summary>
        [Inline]
        public double3 yyx =>  double3(y, y, x);
        
        /// <summary>
        /// Returns double3.ggr swizzling (equivalent to double3.yyx).
        /// </summary>
        [Inline]
        public double3 ggr =>  double3(y, y, x);
        
        /// <summary>
        /// Returns double3.yyxx swizzling.
        /// </summary>
        [Inline]
        public double4 yyxx =>  double4(y, y, x, x);
        
        /// <summary>
        /// Returns double3.ggrr swizzling (equivalent to double3.yyxx).
        /// </summary>
        [Inline]
        public double4 ggrr =>  double4(y, y, x, x);
        
        /// <summary>
        /// Returns double3.yyxy swizzling.
        /// </summary>
        [Inline]
        public double4 yyxy =>  double4(y, y, x, y);
        
        /// <summary>
        /// Returns double3.ggrg swizzling (equivalent to double3.yyxy).
        /// </summary>
        [Inline]
        public double4 ggrg =>  double4(y, y, x, y);
        
        /// <summary>
        /// Returns double3.yyxz swizzling.
        /// </summary>
        [Inline]
        public double4 yyxz =>  double4(y, y, x, z);
        
        /// <summary>
        /// Returns double3.ggrb swizzling (equivalent to double3.yyxz).
        /// </summary>
        [Inline]
        public double4 ggrb =>  double4(y, y, x, z);
        
        /// <summary>
        /// Returns double3.yyy swizzling.
        /// </summary>
        [Inline]
        public double3 yyy =>  double3(y, y, y);
        
        /// <summary>
        /// Returns double3.ggg swizzling (equivalent to double3.yyy).
        /// </summary>
        [Inline]
        public double3 ggg =>  double3(y, y, y);
        
        /// <summary>
        /// Returns double3.yyyx swizzling.
        /// </summary>
        [Inline]
        public double4 yyyx =>  double4(y, y, y, x);
        
        /// <summary>
        /// Returns double3.gggr swizzling (equivalent to double3.yyyx).
        /// </summary>
        [Inline]
        public double4 gggr =>  double4(y, y, y, x);
        
        /// <summary>
        /// Returns double3.yyyy swizzling.
        /// </summary>
        [Inline]
        public double4 yyyy =>  double4(y, y, y, y);
        
        /// <summary>
        /// Returns double3.gggg swizzling (equivalent to double3.yyyy).
        /// </summary>
        [Inline]
        public double4 gggg =>  double4(y, y, y, y);
        
        /// <summary>
        /// Returns double3.yyyz swizzling.
        /// </summary>
        [Inline]
        public double4 yyyz =>  double4(y, y, y, z);
        
        /// <summary>
        /// Returns double3.gggb swizzling (equivalent to double3.yyyz).
        /// </summary>
        [Inline]
        public double4 gggb =>  double4(y, y, y, z);
        
        /// <summary>
        /// Returns double3.yyz swizzling.
        /// </summary>
        [Inline]
        public double3 yyz =>  double3(y, y, z);
        
        /// <summary>
        /// Returns double3.ggb swizzling (equivalent to double3.yyz).
        /// </summary>
        [Inline]
        public double3 ggb =>  double3(y, y, z);
        
        /// <summary>
        /// Returns double3.yyzx swizzling.
        /// </summary>
        [Inline]
        public double4 yyzx =>  double4(y, y, z, x);
        
        /// <summary>
        /// Returns double3.ggbr swizzling (equivalent to double3.yyzx).
        /// </summary>
        [Inline]
        public double4 ggbr =>  double4(y, y, z, x);
        
        /// <summary>
        /// Returns double3.yyzy swizzling.
        /// </summary>
        [Inline]
        public double4 yyzy =>  double4(y, y, z, y);
        
        /// <summary>
        /// Returns double3.ggbg swizzling (equivalent to double3.yyzy).
        /// </summary>
        [Inline]
        public double4 ggbg =>  double4(y, y, z, y);
        
        /// <summary>
        /// Returns double3.yyzz swizzling.
        /// </summary>
        [Inline]
        public double4 yyzz =>  double4(y, y, z, z);
        
        /// <summary>
        /// Returns double3.ggbb swizzling (equivalent to double3.yyzz).
        /// </summary>
        [Inline]
        public double4 ggbb =>  double4(y, y, z, z);
        
        /// <summary>
        /// Returns double3.yz swizzling.
        /// </summary>
        [Inline]
        public double2 yz =>  double2(y, z);
        
        /// <summary>
        /// Returns double3.gb swizzling (equivalent to double3.yz).
        /// </summary>
        [Inline]
        public double2 gb =>  double2(y, z);
        
        /// <summary>
        /// Returns double3.yzx swizzling.
        /// </summary>
        [Inline]
        public double3 yzx =>  double3(y, z, x);
        
        /// <summary>
        /// Returns double3.gbr swizzling (equivalent to double3.yzx).
        /// </summary>
        [Inline]
        public double3 gbr =>  double3(y, z, x);
        
        /// <summary>
        /// Returns double3.yzxx swizzling.
        /// </summary>
        [Inline]
        public double4 yzxx =>  double4(y, z, x, x);
        
        /// <summary>
        /// Returns double3.gbrr swizzling (equivalent to double3.yzxx).
        /// </summary>
        [Inline]
        public double4 gbrr =>  double4(y, z, x, x);
        
        /// <summary>
        /// Returns double3.yzxy swizzling.
        /// </summary>
        [Inline]
        public double4 yzxy =>  double4(y, z, x, y);
        
        /// <summary>
        /// Returns double3.gbrg swizzling (equivalent to double3.yzxy).
        /// </summary>
        [Inline]
        public double4 gbrg =>  double4(y, z, x, y);
        
        /// <summary>
        /// Returns double3.yzxz swizzling.
        /// </summary>
        [Inline]
        public double4 yzxz =>  double4(y, z, x, z);
        
        /// <summary>
        /// Returns double3.gbrb swizzling (equivalent to double3.yzxz).
        /// </summary>
        [Inline]
        public double4 gbrb =>  double4(y, z, x, z);
        
        /// <summary>
        /// Returns double3.yzy swizzling.
        /// </summary>
        [Inline]
        public double3 yzy =>  double3(y, z, y);
        
        /// <summary>
        /// Returns double3.gbg swizzling (equivalent to double3.yzy).
        /// </summary>
        [Inline]
        public double3 gbg =>  double3(y, z, y);
        
        /// <summary>
        /// Returns double3.yzyx swizzling.
        /// </summary>
        [Inline]
        public double4 yzyx =>  double4(y, z, y, x);
        
        /// <summary>
        /// Returns double3.gbgr swizzling (equivalent to double3.yzyx).
        /// </summary>
        [Inline]
        public double4 gbgr =>  double4(y, z, y, x);
        
        /// <summary>
        /// Returns double3.yzyy swizzling.
        /// </summary>
        [Inline]
        public double4 yzyy =>  double4(y, z, y, y);
        
        /// <summary>
        /// Returns double3.gbgg swizzling (equivalent to double3.yzyy).
        /// </summary>
        [Inline]
        public double4 gbgg =>  double4(y, z, y, y);
        
        /// <summary>
        /// Returns double3.yzyz swizzling.
        /// </summary>
        [Inline]
        public double4 yzyz =>  double4(y, z, y, z);
        
        /// <summary>
        /// Returns double3.gbgb swizzling (equivalent to double3.yzyz).
        /// </summary>
        [Inline]
        public double4 gbgb =>  double4(y, z, y, z);
        
        /// <summary>
        /// Returns double3.yzz swizzling.
        /// </summary>
        [Inline]
        public double3 yzz =>  double3(y, z, z);
        
        /// <summary>
        /// Returns double3.gbb swizzling (equivalent to double3.yzz).
        /// </summary>
        [Inline]
        public double3 gbb =>  double3(y, z, z);
        
        /// <summary>
        /// Returns double3.yzzx swizzling.
        /// </summary>
        [Inline]
        public double4 yzzx =>  double4(y, z, z, x);
        
        /// <summary>
        /// Returns double3.gbbr swizzling (equivalent to double3.yzzx).
        /// </summary>
        [Inline]
        public double4 gbbr =>  double4(y, z, z, x);
        
        /// <summary>
        /// Returns double3.yzzy swizzling.
        /// </summary>
        [Inline]
        public double4 yzzy =>  double4(y, z, z, y);
        
        /// <summary>
        /// Returns double3.gbbg swizzling (equivalent to double3.yzzy).
        /// </summary>
        [Inline]
        public double4 gbbg =>  double4(y, z, z, y);
        
        /// <summary>
        /// Returns double3.yzzz swizzling.
        /// </summary>
        [Inline]
        public double4 yzzz =>  double4(y, z, z, z);
        
        /// <summary>
        /// Returns double3.gbbb swizzling (equivalent to double3.yzzz).
        /// </summary>
        [Inline]
        public double4 gbbb =>  double4(y, z, z, z);
        
        /// <summary>
        /// Returns double3.zx swizzling.
        /// </summary>
        [Inline]
        public double2 zx =>  double2(z, x);
        
        /// <summary>
        /// Returns double3.br swizzling (equivalent to double3.zx).
        /// </summary>
        [Inline]
        public double2 br =>  double2(z, x);
        
        /// <summary>
        /// Returns double3.zxx swizzling.
        /// </summary>
        [Inline]
        public double3 zxx =>  double3(z, x, x);
        
        /// <summary>
        /// Returns double3.brr swizzling (equivalent to double3.zxx).
        /// </summary>
        [Inline]
        public double3 brr =>  double3(z, x, x);
        
        /// <summary>
        /// Returns double3.zxxx swizzling.
        /// </summary>
        [Inline]
        public double4 zxxx =>  double4(z, x, x, x);
        
        /// <summary>
        /// Returns double3.brrr swizzling (equivalent to double3.zxxx).
        /// </summary>
        [Inline]
        public double4 brrr =>  double4(z, x, x, x);
        
        /// <summary>
        /// Returns double3.zxxy swizzling.
        /// </summary>
        [Inline]
        public double4 zxxy =>  double4(z, x, x, y);
        
        /// <summary>
        /// Returns double3.brrg swizzling (equivalent to double3.zxxy).
        /// </summary>
        [Inline]
        public double4 brrg =>  double4(z, x, x, y);
        
        /// <summary>
        /// Returns double3.zxxz swizzling.
        /// </summary>
        [Inline]
        public double4 zxxz =>  double4(z, x, x, z);
        
        /// <summary>
        /// Returns double3.brrb swizzling (equivalent to double3.zxxz).
        /// </summary>
        [Inline]
        public double4 brrb =>  double4(z, x, x, z);
        
        /// <summary>
        /// Returns double3.zxy swizzling.
        /// </summary>
        [Inline]
        public double3 zxy =>  double3(z, x, y);
        
        /// <summary>
        /// Returns double3.brg swizzling (equivalent to double3.zxy).
        /// </summary>
        [Inline]
        public double3 brg =>  double3(z, x, y);
        
        /// <summary>
        /// Returns double3.zxyx swizzling.
        /// </summary>
        [Inline]
        public double4 zxyx =>  double4(z, x, y, x);
        
        /// <summary>
        /// Returns double3.brgr swizzling (equivalent to double3.zxyx).
        /// </summary>
        [Inline]
        public double4 brgr =>  double4(z, x, y, x);
        
        /// <summary>
        /// Returns double3.zxyy swizzling.
        /// </summary>
        [Inline]
        public double4 zxyy =>  double4(z, x, y, y);
        
        /// <summary>
        /// Returns double3.brgg swizzling (equivalent to double3.zxyy).
        /// </summary>
        [Inline]
        public double4 brgg =>  double4(z, x, y, y);
        
        /// <summary>
        /// Returns double3.zxyz swizzling.
        /// </summary>
        [Inline]
        public double4 zxyz =>  double4(z, x, y, z);
        
        /// <summary>
        /// Returns double3.brgb swizzling (equivalent to double3.zxyz).
        /// </summary>
        [Inline]
        public double4 brgb =>  double4(z, x, y, z);
        
        /// <summary>
        /// Returns double3.zxz swizzling.
        /// </summary>
        [Inline]
        public double3 zxz =>  double3(z, x, z);
        
        /// <summary>
        /// Returns double3.brb swizzling (equivalent to double3.zxz).
        /// </summary>
        [Inline]
        public double3 brb =>  double3(z, x, z);
        
        /// <summary>
        /// Returns double3.zxzx swizzling.
        /// </summary>
        [Inline]
        public double4 zxzx =>  double4(z, x, z, x);
        
        /// <summary>
        /// Returns double3.brbr swizzling (equivalent to double3.zxzx).
        /// </summary>
        [Inline]
        public double4 brbr =>  double4(z, x, z, x);
        
        /// <summary>
        /// Returns double3.zxzy swizzling.
        /// </summary>
        [Inline]
        public double4 zxzy =>  double4(z, x, z, y);
        
        /// <summary>
        /// Returns double3.brbg swizzling (equivalent to double3.zxzy).
        /// </summary>
        [Inline]
        public double4 brbg =>  double4(z, x, z, y);
        
        /// <summary>
        /// Returns double3.zxzz swizzling.
        /// </summary>
        [Inline]
        public double4 zxzz =>  double4(z, x, z, z);
        
        /// <summary>
        /// Returns double3.brbb swizzling (equivalent to double3.zxzz).
        /// </summary>
        [Inline]
        public double4 brbb =>  double4(z, x, z, z);
        
        /// <summary>
        /// Returns double3.zy swizzling.
        /// </summary>
        [Inline]
        public double2 zy =>  double2(z, y);
        
        /// <summary>
        /// Returns double3.bg swizzling (equivalent to double3.zy).
        /// </summary>
        [Inline]
        public double2 bg =>  double2(z, y);
        
        /// <summary>
        /// Returns double3.zyx swizzling.
        /// </summary>
        [Inline]
        public double3 zyx =>  double3(z, y, x);
        
        /// <summary>
        /// Returns double3.bgr swizzling (equivalent to double3.zyx).
        /// </summary>
        [Inline]
        public double3 bgr =>  double3(z, y, x);
        
        /// <summary>
        /// Returns double3.zyxx swizzling.
        /// </summary>
        [Inline]
        public double4 zyxx =>  double4(z, y, x, x);
        
        /// <summary>
        /// Returns double3.bgrr swizzling (equivalent to double3.zyxx).
        /// </summary>
        [Inline]
        public double4 bgrr =>  double4(z, y, x, x);
        
        /// <summary>
        /// Returns double3.zyxy swizzling.
        /// </summary>
        [Inline]
        public double4 zyxy =>  double4(z, y, x, y);
        
        /// <summary>
        /// Returns double3.bgrg swizzling (equivalent to double3.zyxy).
        /// </summary>
        [Inline]
        public double4 bgrg =>  double4(z, y, x, y);
        
        /// <summary>
        /// Returns double3.zyxz swizzling.
        /// </summary>
        [Inline]
        public double4 zyxz =>  double4(z, y, x, z);
        
        /// <summary>
        /// Returns double3.bgrb swizzling (equivalent to double3.zyxz).
        /// </summary>
        [Inline]
        public double4 bgrb =>  double4(z, y, x, z);
        
        /// <summary>
        /// Returns double3.zyy swizzling.
        /// </summary>
        [Inline]
        public double3 zyy =>  double3(z, y, y);
        
        /// <summary>
        /// Returns double3.bgg swizzling (equivalent to double3.zyy).
        /// </summary>
        [Inline]
        public double3 bgg =>  double3(z, y, y);
        
        /// <summary>
        /// Returns double3.zyyx swizzling.
        /// </summary>
        [Inline]
        public double4 zyyx =>  double4(z, y, y, x);
        
        /// <summary>
        /// Returns double3.bggr swizzling (equivalent to double3.zyyx).
        /// </summary>
        [Inline]
        public double4 bggr =>  double4(z, y, y, x);
        
        /// <summary>
        /// Returns double3.zyyy swizzling.
        /// </summary>
        [Inline]
        public double4 zyyy =>  double4(z, y, y, y);
        
        /// <summary>
        /// Returns double3.bggg swizzling (equivalent to double3.zyyy).
        /// </summary>
        [Inline]
        public double4 bggg =>  double4(z, y, y, y);
        
        /// <summary>
        /// Returns double3.zyyz swizzling.
        /// </summary>
        [Inline]
        public double4 zyyz =>  double4(z, y, y, z);
        
        /// <summary>
        /// Returns double3.bggb swizzling (equivalent to double3.zyyz).
        /// </summary>
        [Inline]
        public double4 bggb =>  double4(z, y, y, z);
        
        /// <summary>
        /// Returns double3.zyz swizzling.
        /// </summary>
        [Inline]
        public double3 zyz =>  double3(z, y, z);
        
        /// <summary>
        /// Returns double3.bgb swizzling (equivalent to double3.zyz).
        /// </summary>
        [Inline]
        public double3 bgb =>  double3(z, y, z);
        
        /// <summary>
        /// Returns double3.zyzx swizzling.
        /// </summary>
        [Inline]
        public double4 zyzx =>  double4(z, y, z, x);
        
        /// <summary>
        /// Returns double3.bgbr swizzling (equivalent to double3.zyzx).
        /// </summary>
        [Inline]
        public double4 bgbr =>  double4(z, y, z, x);
        
        /// <summary>
        /// Returns double3.zyzy swizzling.
        /// </summary>
        [Inline]
        public double4 zyzy =>  double4(z, y, z, y);
        
        /// <summary>
        /// Returns double3.bgbg swizzling (equivalent to double3.zyzy).
        /// </summary>
        [Inline]
        public double4 bgbg =>  double4(z, y, z, y);
        
        /// <summary>
        /// Returns double3.zyzz swizzling.
        /// </summary>
        [Inline]
        public double4 zyzz =>  double4(z, y, z, z);
        
        /// <summary>
        /// Returns double3.bgbb swizzling (equivalent to double3.zyzz).
        /// </summary>
        [Inline]
        public double4 bgbb =>  double4(z, y, z, z);
        
        /// <summary>
        /// Returns double3.zz swizzling.
        /// </summary>
        [Inline]
        public double2 zz =>  double2(z, z);
        
        /// <summary>
        /// Returns double3.bb swizzling (equivalent to double3.zz).
        /// </summary>
        [Inline]
        public double2 bb =>  double2(z, z);
        
        /// <summary>
        /// Returns double3.zzx swizzling.
        /// </summary>
        [Inline]
        public double3 zzx =>  double3(z, z, x);
        
        /// <summary>
        /// Returns double3.bbr swizzling (equivalent to double3.zzx).
        /// </summary>
        [Inline]
        public double3 bbr =>  double3(z, z, x);
        
        /// <summary>
        /// Returns double3.zzxx swizzling.
        /// </summary>
        [Inline]
        public double4 zzxx =>  double4(z, z, x, x);
        
        /// <summary>
        /// Returns double3.bbrr swizzling (equivalent to double3.zzxx).
        /// </summary>
        [Inline]
        public double4 bbrr =>  double4(z, z, x, x);
        
        /// <summary>
        /// Returns double3.zzxy swizzling.
        /// </summary>
        [Inline]
        public double4 zzxy =>  double4(z, z, x, y);
        
        /// <summary>
        /// Returns double3.bbrg swizzling (equivalent to double3.zzxy).
        /// </summary>
        [Inline]
        public double4 bbrg =>  double4(z, z, x, y);
        
        /// <summary>
        /// Returns double3.zzxz swizzling.
        /// </summary>
        [Inline]
        public double4 zzxz =>  double4(z, z, x, z);
        
        /// <summary>
        /// Returns double3.bbrb swizzling (equivalent to double3.zzxz).
        /// </summary>
        [Inline]
        public double4 bbrb =>  double4(z, z, x, z);
        
        /// <summary>
        /// Returns double3.zzy swizzling.
        /// </summary>
        [Inline]
        public double3 zzy =>  double3(z, z, y);
        
        /// <summary>
        /// Returns double3.bbg swizzling (equivalent to double3.zzy).
        /// </summary>
        [Inline]
        public double3 bbg =>  double3(z, z, y);
        
        /// <summary>
        /// Returns double3.zzyx swizzling.
        /// </summary>
        [Inline]
        public double4 zzyx =>  double4(z, z, y, x);
        
        /// <summary>
        /// Returns double3.bbgr swizzling (equivalent to double3.zzyx).
        /// </summary>
        [Inline]
        public double4 bbgr =>  double4(z, z, y, x);
        
        /// <summary>
        /// Returns double3.zzyy swizzling.
        /// </summary>
        [Inline]
        public double4 zzyy =>  double4(z, z, y, y);
        
        /// <summary>
        /// Returns double3.bbgg swizzling (equivalent to double3.zzyy).
        /// </summary>
        [Inline]
        public double4 bbgg =>  double4(z, z, y, y);
        
        /// <summary>
        /// Returns double3.zzyz swizzling.
        /// </summary>
        [Inline]
        public double4 zzyz =>  double4(z, z, y, z);
        
        /// <summary>
        /// Returns double3.bbgb swizzling (equivalent to double3.zzyz).
        /// </summary>
        [Inline]
        public double4 bbgb =>  double4(z, z, y, z);
        
        /// <summary>
        /// Returns double3.zzz swizzling.
        /// </summary>
        [Inline]
        public double3 zzz =>  double3(z, z, z);
        
        /// <summary>
        /// Returns double3.bbb swizzling (equivalent to double3.zzz).
        /// </summary>
        [Inline]
        public double3 bbb =>  double3(z, z, z);
        
        /// <summary>
        /// Returns double3.zzzx swizzling.
        /// </summary>
        [Inline]
        public double4 zzzx =>  double4(z, z, z, x);
        
        /// <summary>
        /// Returns double3.bbbr swizzling (equivalent to double3.zzzx).
        /// </summary>
        [Inline]
        public double4 bbbr =>  double4(z, z, z, x);
        
        /// <summary>
        /// Returns double3.zzzy swizzling.
        /// </summary>
        [Inline]
        public double4 zzzy =>  double4(z, z, z, y);
        
        /// <summary>
        /// Returns double3.bbbg swizzling (equivalent to double3.zzzy).
        /// </summary>
        [Inline]
        public double4 bbbg =>  double4(z, z, z, y);
        
        /// <summary>
        /// Returns double3.zzzz swizzling.
        /// </summary>
        [Inline]
        public double4 zzzz =>  double4(z, z, z, z);
        
        /// <summary>
        /// Returns double3.bbbb swizzling (equivalent to double3.zzzz).
        /// </summary>
        [Inline]
        public double4 bbbb =>  double4(z, z, z, z);

        //#endregion

    }
}
