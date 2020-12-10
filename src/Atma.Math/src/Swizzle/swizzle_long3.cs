using System;
namespace Atma
{
    
    /// <summary>
    /// Temporary vector of type long with 3 components, used for implementing swizzling for long3.
    /// </summary>
    public struct swizzle_long3
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
        
        /// <summary>
        /// z-component
        /// </summary>
        private readonly long z;

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Returns long3.xx swizzling.
        /// </summary>
        [Inline]
        public long2 xx =>  long2(x, x);
        
        /// <summary>
        /// Returns long3.rr swizzling (equivalent to long3.xx).
        /// </summary>
        [Inline]
        public long2 rr =>  long2(x, x);
        
        /// <summary>
        /// Returns long3.xxx swizzling.
        /// </summary>
        [Inline]
        public long3 xxx =>  long3(x, x, x);
        
        /// <summary>
        /// Returns long3.rrr swizzling (equivalent to long3.xxx).
        /// </summary>
        [Inline]
        public long3 rrr =>  long3(x, x, x);
        
        /// <summary>
        /// Returns long3.xxxx swizzling.
        /// </summary>
        [Inline]
        public long4 xxxx =>  long4(x, x, x, x);
        
        /// <summary>
        /// Returns long3.rrrr swizzling (equivalent to long3.xxxx).
        /// </summary>
        [Inline]
        public long4 rrrr =>  long4(x, x, x, x);
        
        /// <summary>
        /// Returns long3.xxxy swizzling.
        /// </summary>
        [Inline]
        public long4 xxxy =>  long4(x, x, x, y);
        
        /// <summary>
        /// Returns long3.rrrg swizzling (equivalent to long3.xxxy).
        /// </summary>
        [Inline]
        public long4 rrrg =>  long4(x, x, x, y);
        
        /// <summary>
        /// Returns long3.xxxz swizzling.
        /// </summary>
        [Inline]
        public long4 xxxz =>  long4(x, x, x, z);
        
        /// <summary>
        /// Returns long3.rrrb swizzling (equivalent to long3.xxxz).
        /// </summary>
        [Inline]
        public long4 rrrb =>  long4(x, x, x, z);
        
        /// <summary>
        /// Returns long3.xxy swizzling.
        /// </summary>
        [Inline]
        public long3 xxy =>  long3(x, x, y);
        
        /// <summary>
        /// Returns long3.rrg swizzling (equivalent to long3.xxy).
        /// </summary>
        [Inline]
        public long3 rrg =>  long3(x, x, y);
        
        /// <summary>
        /// Returns long3.xxyx swizzling.
        /// </summary>
        [Inline]
        public long4 xxyx =>  long4(x, x, y, x);
        
        /// <summary>
        /// Returns long3.rrgr swizzling (equivalent to long3.xxyx).
        /// </summary>
        [Inline]
        public long4 rrgr =>  long4(x, x, y, x);
        
        /// <summary>
        /// Returns long3.xxyy swizzling.
        /// </summary>
        [Inline]
        public long4 xxyy =>  long4(x, x, y, y);
        
        /// <summary>
        /// Returns long3.rrgg swizzling (equivalent to long3.xxyy).
        /// </summary>
        [Inline]
        public long4 rrgg =>  long4(x, x, y, y);
        
        /// <summary>
        /// Returns long3.xxyz swizzling.
        /// </summary>
        [Inline]
        public long4 xxyz =>  long4(x, x, y, z);
        
        /// <summary>
        /// Returns long3.rrgb swizzling (equivalent to long3.xxyz).
        /// </summary>
        [Inline]
        public long4 rrgb =>  long4(x, x, y, z);
        
        /// <summary>
        /// Returns long3.xxz swizzling.
        /// </summary>
        [Inline]
        public long3 xxz =>  long3(x, x, z);
        
        /// <summary>
        /// Returns long3.rrb swizzling (equivalent to long3.xxz).
        /// </summary>
        [Inline]
        public long3 rrb =>  long3(x, x, z);
        
        /// <summary>
        /// Returns long3.xxzx swizzling.
        /// </summary>
        [Inline]
        public long4 xxzx =>  long4(x, x, z, x);
        
        /// <summary>
        /// Returns long3.rrbr swizzling (equivalent to long3.xxzx).
        /// </summary>
        [Inline]
        public long4 rrbr =>  long4(x, x, z, x);
        
        /// <summary>
        /// Returns long3.xxzy swizzling.
        /// </summary>
        [Inline]
        public long4 xxzy =>  long4(x, x, z, y);
        
        /// <summary>
        /// Returns long3.rrbg swizzling (equivalent to long3.xxzy).
        /// </summary>
        [Inline]
        public long4 rrbg =>  long4(x, x, z, y);
        
        /// <summary>
        /// Returns long3.xxzz swizzling.
        /// </summary>
        [Inline]
        public long4 xxzz =>  long4(x, x, z, z);
        
        /// <summary>
        /// Returns long3.rrbb swizzling (equivalent to long3.xxzz).
        /// </summary>
        [Inline]
        public long4 rrbb =>  long4(x, x, z, z);
        
        /// <summary>
        /// Returns long3.xy swizzling.
        /// </summary>
        [Inline]
        public long2 xy =>  long2(x, y);
        
        /// <summary>
        /// Returns long3.rg swizzling (equivalent to long3.xy).
        /// </summary>
        [Inline]
        public long2 rg =>  long2(x, y);
        
        /// <summary>
        /// Returns long3.xyx swizzling.
        /// </summary>
        [Inline]
        public long3 xyx =>  long3(x, y, x);
        
        /// <summary>
        /// Returns long3.rgr swizzling (equivalent to long3.xyx).
        /// </summary>
        [Inline]
        public long3 rgr =>  long3(x, y, x);
        
        /// <summary>
        /// Returns long3.xyxx swizzling.
        /// </summary>
        [Inline]
        public long4 xyxx =>  long4(x, y, x, x);
        
        /// <summary>
        /// Returns long3.rgrr swizzling (equivalent to long3.xyxx).
        /// </summary>
        [Inline]
        public long4 rgrr =>  long4(x, y, x, x);
        
        /// <summary>
        /// Returns long3.xyxy swizzling.
        /// </summary>
        [Inline]
        public long4 xyxy =>  long4(x, y, x, y);
        
        /// <summary>
        /// Returns long3.rgrg swizzling (equivalent to long3.xyxy).
        /// </summary>
        [Inline]
        public long4 rgrg =>  long4(x, y, x, y);
        
        /// <summary>
        /// Returns long3.xyxz swizzling.
        /// </summary>
        [Inline]
        public long4 xyxz =>  long4(x, y, x, z);
        
        /// <summary>
        /// Returns long3.rgrb swizzling (equivalent to long3.xyxz).
        /// </summary>
        [Inline]
        public long4 rgrb =>  long4(x, y, x, z);
        
        /// <summary>
        /// Returns long3.xyy swizzling.
        /// </summary>
        [Inline]
        public long3 xyy =>  long3(x, y, y);
        
        /// <summary>
        /// Returns long3.rgg swizzling (equivalent to long3.xyy).
        /// </summary>
        [Inline]
        public long3 rgg =>  long3(x, y, y);
        
        /// <summary>
        /// Returns long3.xyyx swizzling.
        /// </summary>
        [Inline]
        public long4 xyyx =>  long4(x, y, y, x);
        
        /// <summary>
        /// Returns long3.rggr swizzling (equivalent to long3.xyyx).
        /// </summary>
        [Inline]
        public long4 rggr =>  long4(x, y, y, x);
        
        /// <summary>
        /// Returns long3.xyyy swizzling.
        /// </summary>
        [Inline]
        public long4 xyyy =>  long4(x, y, y, y);
        
        /// <summary>
        /// Returns long3.rggg swizzling (equivalent to long3.xyyy).
        /// </summary>
        [Inline]
        public long4 rggg =>  long4(x, y, y, y);
        
        /// <summary>
        /// Returns long3.xyyz swizzling.
        /// </summary>
        [Inline]
        public long4 xyyz =>  long4(x, y, y, z);
        
        /// <summary>
        /// Returns long3.rggb swizzling (equivalent to long3.xyyz).
        /// </summary>
        [Inline]
        public long4 rggb =>  long4(x, y, y, z);
        
        /// <summary>
        /// Returns long3.xyz swizzling.
        /// </summary>
        [Inline]
        public long3 xyz =>  long3(x, y, z);
        
        /// <summary>
        /// Returns long3.rgb swizzling (equivalent to long3.xyz).
        /// </summary>
        [Inline]
        public long3 rgb =>  long3(x, y, z);
        
        /// <summary>
        /// Returns long3.xyzx swizzling.
        /// </summary>
        [Inline]
        public long4 xyzx =>  long4(x, y, z, x);
        
        /// <summary>
        /// Returns long3.rgbr swizzling (equivalent to long3.xyzx).
        /// </summary>
        [Inline]
        public long4 rgbr =>  long4(x, y, z, x);
        
        /// <summary>
        /// Returns long3.xyzy swizzling.
        /// </summary>
        [Inline]
        public long4 xyzy =>  long4(x, y, z, y);
        
        /// <summary>
        /// Returns long3.rgbg swizzling (equivalent to long3.xyzy).
        /// </summary>
        [Inline]
        public long4 rgbg =>  long4(x, y, z, y);
        
        /// <summary>
        /// Returns long3.xyzz swizzling.
        /// </summary>
        [Inline]
        public long4 xyzz =>  long4(x, y, z, z);
        
        /// <summary>
        /// Returns long3.rgbb swizzling (equivalent to long3.xyzz).
        /// </summary>
        [Inline]
        public long4 rgbb =>  long4(x, y, z, z);
        
        /// <summary>
        /// Returns long3.xz swizzling.
        /// </summary>
        [Inline]
        public long2 xz =>  long2(x, z);
        
        /// <summary>
        /// Returns long3.rb swizzling (equivalent to long3.xz).
        /// </summary>
        [Inline]
        public long2 rb =>  long2(x, z);
        
        /// <summary>
        /// Returns long3.xzx swizzling.
        /// </summary>
        [Inline]
        public long3 xzx =>  long3(x, z, x);
        
        /// <summary>
        /// Returns long3.rbr swizzling (equivalent to long3.xzx).
        /// </summary>
        [Inline]
        public long3 rbr =>  long3(x, z, x);
        
        /// <summary>
        /// Returns long3.xzxx swizzling.
        /// </summary>
        [Inline]
        public long4 xzxx =>  long4(x, z, x, x);
        
        /// <summary>
        /// Returns long3.rbrr swizzling (equivalent to long3.xzxx).
        /// </summary>
        [Inline]
        public long4 rbrr =>  long4(x, z, x, x);
        
        /// <summary>
        /// Returns long3.xzxy swizzling.
        /// </summary>
        [Inline]
        public long4 xzxy =>  long4(x, z, x, y);
        
        /// <summary>
        /// Returns long3.rbrg swizzling (equivalent to long3.xzxy).
        /// </summary>
        [Inline]
        public long4 rbrg =>  long4(x, z, x, y);
        
        /// <summary>
        /// Returns long3.xzxz swizzling.
        /// </summary>
        [Inline]
        public long4 xzxz =>  long4(x, z, x, z);
        
        /// <summary>
        /// Returns long3.rbrb swizzling (equivalent to long3.xzxz).
        /// </summary>
        [Inline]
        public long4 rbrb =>  long4(x, z, x, z);
        
        /// <summary>
        /// Returns long3.xzy swizzling.
        /// </summary>
        [Inline]
        public long3 xzy =>  long3(x, z, y);
        
        /// <summary>
        /// Returns long3.rbg swizzling (equivalent to long3.xzy).
        /// </summary>
        [Inline]
        public long3 rbg =>  long3(x, z, y);
        
        /// <summary>
        /// Returns long3.xzyx swizzling.
        /// </summary>
        [Inline]
        public long4 xzyx =>  long4(x, z, y, x);
        
        /// <summary>
        /// Returns long3.rbgr swizzling (equivalent to long3.xzyx).
        /// </summary>
        [Inline]
        public long4 rbgr =>  long4(x, z, y, x);
        
        /// <summary>
        /// Returns long3.xzyy swizzling.
        /// </summary>
        [Inline]
        public long4 xzyy =>  long4(x, z, y, y);
        
        /// <summary>
        /// Returns long3.rbgg swizzling (equivalent to long3.xzyy).
        /// </summary>
        [Inline]
        public long4 rbgg =>  long4(x, z, y, y);
        
        /// <summary>
        /// Returns long3.xzyz swizzling.
        /// </summary>
        [Inline]
        public long4 xzyz =>  long4(x, z, y, z);
        
        /// <summary>
        /// Returns long3.rbgb swizzling (equivalent to long3.xzyz).
        /// </summary>
        [Inline]
        public long4 rbgb =>  long4(x, z, y, z);
        
        /// <summary>
        /// Returns long3.xzz swizzling.
        /// </summary>
        [Inline]
        public long3 xzz =>  long3(x, z, z);
        
        /// <summary>
        /// Returns long3.rbb swizzling (equivalent to long3.xzz).
        /// </summary>
        [Inline]
        public long3 rbb =>  long3(x, z, z);
        
        /// <summary>
        /// Returns long3.xzzx swizzling.
        /// </summary>
        [Inline]
        public long4 xzzx =>  long4(x, z, z, x);
        
        /// <summary>
        /// Returns long3.rbbr swizzling (equivalent to long3.xzzx).
        /// </summary>
        [Inline]
        public long4 rbbr =>  long4(x, z, z, x);
        
        /// <summary>
        /// Returns long3.xzzy swizzling.
        /// </summary>
        [Inline]
        public long4 xzzy =>  long4(x, z, z, y);
        
        /// <summary>
        /// Returns long3.rbbg swizzling (equivalent to long3.xzzy).
        /// </summary>
        [Inline]
        public long4 rbbg =>  long4(x, z, z, y);
        
        /// <summary>
        /// Returns long3.xzzz swizzling.
        /// </summary>
        [Inline]
        public long4 xzzz =>  long4(x, z, z, z);
        
        /// <summary>
        /// Returns long3.rbbb swizzling (equivalent to long3.xzzz).
        /// </summary>
        [Inline]
        public long4 rbbb =>  long4(x, z, z, z);
        
        /// <summary>
        /// Returns long3.yx swizzling.
        /// </summary>
        [Inline]
        public long2 yx =>  long2(y, x);
        
        /// <summary>
        /// Returns long3.gr swizzling (equivalent to long3.yx).
        /// </summary>
        [Inline]
        public long2 gr =>  long2(y, x);
        
        /// <summary>
        /// Returns long3.yxx swizzling.
        /// </summary>
        [Inline]
        public long3 yxx =>  long3(y, x, x);
        
        /// <summary>
        /// Returns long3.grr swizzling (equivalent to long3.yxx).
        /// </summary>
        [Inline]
        public long3 grr =>  long3(y, x, x);
        
        /// <summary>
        /// Returns long3.yxxx swizzling.
        /// </summary>
        [Inline]
        public long4 yxxx =>  long4(y, x, x, x);
        
        /// <summary>
        /// Returns long3.grrr swizzling (equivalent to long3.yxxx).
        /// </summary>
        [Inline]
        public long4 grrr =>  long4(y, x, x, x);
        
        /// <summary>
        /// Returns long3.yxxy swizzling.
        /// </summary>
        [Inline]
        public long4 yxxy =>  long4(y, x, x, y);
        
        /// <summary>
        /// Returns long3.grrg swizzling (equivalent to long3.yxxy).
        /// </summary>
        [Inline]
        public long4 grrg =>  long4(y, x, x, y);
        
        /// <summary>
        /// Returns long3.yxxz swizzling.
        /// </summary>
        [Inline]
        public long4 yxxz =>  long4(y, x, x, z);
        
        /// <summary>
        /// Returns long3.grrb swizzling (equivalent to long3.yxxz).
        /// </summary>
        [Inline]
        public long4 grrb =>  long4(y, x, x, z);
        
        /// <summary>
        /// Returns long3.yxy swizzling.
        /// </summary>
        [Inline]
        public long3 yxy =>  long3(y, x, y);
        
        /// <summary>
        /// Returns long3.grg swizzling (equivalent to long3.yxy).
        /// </summary>
        [Inline]
        public long3 grg =>  long3(y, x, y);
        
        /// <summary>
        /// Returns long3.yxyx swizzling.
        /// </summary>
        [Inline]
        public long4 yxyx =>  long4(y, x, y, x);
        
        /// <summary>
        /// Returns long3.grgr swizzling (equivalent to long3.yxyx).
        /// </summary>
        [Inline]
        public long4 grgr =>  long4(y, x, y, x);
        
        /// <summary>
        /// Returns long3.yxyy swizzling.
        /// </summary>
        [Inline]
        public long4 yxyy =>  long4(y, x, y, y);
        
        /// <summary>
        /// Returns long3.grgg swizzling (equivalent to long3.yxyy).
        /// </summary>
        [Inline]
        public long4 grgg =>  long4(y, x, y, y);
        
        /// <summary>
        /// Returns long3.yxyz swizzling.
        /// </summary>
        [Inline]
        public long4 yxyz =>  long4(y, x, y, z);
        
        /// <summary>
        /// Returns long3.grgb swizzling (equivalent to long3.yxyz).
        /// </summary>
        [Inline]
        public long4 grgb =>  long4(y, x, y, z);
        
        /// <summary>
        /// Returns long3.yxz swizzling.
        /// </summary>
        [Inline]
        public long3 yxz =>  long3(y, x, z);
        
        /// <summary>
        /// Returns long3.grb swizzling (equivalent to long3.yxz).
        /// </summary>
        [Inline]
        public long3 grb =>  long3(y, x, z);
        
        /// <summary>
        /// Returns long3.yxzx swizzling.
        /// </summary>
        [Inline]
        public long4 yxzx =>  long4(y, x, z, x);
        
        /// <summary>
        /// Returns long3.grbr swizzling (equivalent to long3.yxzx).
        /// </summary>
        [Inline]
        public long4 grbr =>  long4(y, x, z, x);
        
        /// <summary>
        /// Returns long3.yxzy swizzling.
        /// </summary>
        [Inline]
        public long4 yxzy =>  long4(y, x, z, y);
        
        /// <summary>
        /// Returns long3.grbg swizzling (equivalent to long3.yxzy).
        /// </summary>
        [Inline]
        public long4 grbg =>  long4(y, x, z, y);
        
        /// <summary>
        /// Returns long3.yxzz swizzling.
        /// </summary>
        [Inline]
        public long4 yxzz =>  long4(y, x, z, z);
        
        /// <summary>
        /// Returns long3.grbb swizzling (equivalent to long3.yxzz).
        /// </summary>
        [Inline]
        public long4 grbb =>  long4(y, x, z, z);
        
        /// <summary>
        /// Returns long3.yy swizzling.
        /// </summary>
        [Inline]
        public long2 yy =>  long2(y, y);
        
        /// <summary>
        /// Returns long3.gg swizzling (equivalent to long3.yy).
        /// </summary>
        [Inline]
        public long2 gg =>  long2(y, y);
        
        /// <summary>
        /// Returns long3.yyx swizzling.
        /// </summary>
        [Inline]
        public long3 yyx =>  long3(y, y, x);
        
        /// <summary>
        /// Returns long3.ggr swizzling (equivalent to long3.yyx).
        /// </summary>
        [Inline]
        public long3 ggr =>  long3(y, y, x);
        
        /// <summary>
        /// Returns long3.yyxx swizzling.
        /// </summary>
        [Inline]
        public long4 yyxx =>  long4(y, y, x, x);
        
        /// <summary>
        /// Returns long3.ggrr swizzling (equivalent to long3.yyxx).
        /// </summary>
        [Inline]
        public long4 ggrr =>  long4(y, y, x, x);
        
        /// <summary>
        /// Returns long3.yyxy swizzling.
        /// </summary>
        [Inline]
        public long4 yyxy =>  long4(y, y, x, y);
        
        /// <summary>
        /// Returns long3.ggrg swizzling (equivalent to long3.yyxy).
        /// </summary>
        [Inline]
        public long4 ggrg =>  long4(y, y, x, y);
        
        /// <summary>
        /// Returns long3.yyxz swizzling.
        /// </summary>
        [Inline]
        public long4 yyxz =>  long4(y, y, x, z);
        
        /// <summary>
        /// Returns long3.ggrb swizzling (equivalent to long3.yyxz).
        /// </summary>
        [Inline]
        public long4 ggrb =>  long4(y, y, x, z);
        
        /// <summary>
        /// Returns long3.yyy swizzling.
        /// </summary>
        [Inline]
        public long3 yyy =>  long3(y, y, y);
        
        /// <summary>
        /// Returns long3.ggg swizzling (equivalent to long3.yyy).
        /// </summary>
        [Inline]
        public long3 ggg =>  long3(y, y, y);
        
        /// <summary>
        /// Returns long3.yyyx swizzling.
        /// </summary>
        [Inline]
        public long4 yyyx =>  long4(y, y, y, x);
        
        /// <summary>
        /// Returns long3.gggr swizzling (equivalent to long3.yyyx).
        /// </summary>
        [Inline]
        public long4 gggr =>  long4(y, y, y, x);
        
        /// <summary>
        /// Returns long3.yyyy swizzling.
        /// </summary>
        [Inline]
        public long4 yyyy =>  long4(y, y, y, y);
        
        /// <summary>
        /// Returns long3.gggg swizzling (equivalent to long3.yyyy).
        /// </summary>
        [Inline]
        public long4 gggg =>  long4(y, y, y, y);
        
        /// <summary>
        /// Returns long3.yyyz swizzling.
        /// </summary>
        [Inline]
        public long4 yyyz =>  long4(y, y, y, z);
        
        /// <summary>
        /// Returns long3.gggb swizzling (equivalent to long3.yyyz).
        /// </summary>
        [Inline]
        public long4 gggb =>  long4(y, y, y, z);
        
        /// <summary>
        /// Returns long3.yyz swizzling.
        /// </summary>
        [Inline]
        public long3 yyz =>  long3(y, y, z);
        
        /// <summary>
        /// Returns long3.ggb swizzling (equivalent to long3.yyz).
        /// </summary>
        [Inline]
        public long3 ggb =>  long3(y, y, z);
        
        /// <summary>
        /// Returns long3.yyzx swizzling.
        /// </summary>
        [Inline]
        public long4 yyzx =>  long4(y, y, z, x);
        
        /// <summary>
        /// Returns long3.ggbr swizzling (equivalent to long3.yyzx).
        /// </summary>
        [Inline]
        public long4 ggbr =>  long4(y, y, z, x);
        
        /// <summary>
        /// Returns long3.yyzy swizzling.
        /// </summary>
        [Inline]
        public long4 yyzy =>  long4(y, y, z, y);
        
        /// <summary>
        /// Returns long3.ggbg swizzling (equivalent to long3.yyzy).
        /// </summary>
        [Inline]
        public long4 ggbg =>  long4(y, y, z, y);
        
        /// <summary>
        /// Returns long3.yyzz swizzling.
        /// </summary>
        [Inline]
        public long4 yyzz =>  long4(y, y, z, z);
        
        /// <summary>
        /// Returns long3.ggbb swizzling (equivalent to long3.yyzz).
        /// </summary>
        [Inline]
        public long4 ggbb =>  long4(y, y, z, z);
        
        /// <summary>
        /// Returns long3.yz swizzling.
        /// </summary>
        [Inline]
        public long2 yz =>  long2(y, z);
        
        /// <summary>
        /// Returns long3.gb swizzling (equivalent to long3.yz).
        /// </summary>
        [Inline]
        public long2 gb =>  long2(y, z);
        
        /// <summary>
        /// Returns long3.yzx swizzling.
        /// </summary>
        [Inline]
        public long3 yzx =>  long3(y, z, x);
        
        /// <summary>
        /// Returns long3.gbr swizzling (equivalent to long3.yzx).
        /// </summary>
        [Inline]
        public long3 gbr =>  long3(y, z, x);
        
        /// <summary>
        /// Returns long3.yzxx swizzling.
        /// </summary>
        [Inline]
        public long4 yzxx =>  long4(y, z, x, x);
        
        /// <summary>
        /// Returns long3.gbrr swizzling (equivalent to long3.yzxx).
        /// </summary>
        [Inline]
        public long4 gbrr =>  long4(y, z, x, x);
        
        /// <summary>
        /// Returns long3.yzxy swizzling.
        /// </summary>
        [Inline]
        public long4 yzxy =>  long4(y, z, x, y);
        
        /// <summary>
        /// Returns long3.gbrg swizzling (equivalent to long3.yzxy).
        /// </summary>
        [Inline]
        public long4 gbrg =>  long4(y, z, x, y);
        
        /// <summary>
        /// Returns long3.yzxz swizzling.
        /// </summary>
        [Inline]
        public long4 yzxz =>  long4(y, z, x, z);
        
        /// <summary>
        /// Returns long3.gbrb swizzling (equivalent to long3.yzxz).
        /// </summary>
        [Inline]
        public long4 gbrb =>  long4(y, z, x, z);
        
        /// <summary>
        /// Returns long3.yzy swizzling.
        /// </summary>
        [Inline]
        public long3 yzy =>  long3(y, z, y);
        
        /// <summary>
        /// Returns long3.gbg swizzling (equivalent to long3.yzy).
        /// </summary>
        [Inline]
        public long3 gbg =>  long3(y, z, y);
        
        /// <summary>
        /// Returns long3.yzyx swizzling.
        /// </summary>
        [Inline]
        public long4 yzyx =>  long4(y, z, y, x);
        
        /// <summary>
        /// Returns long3.gbgr swizzling (equivalent to long3.yzyx).
        /// </summary>
        [Inline]
        public long4 gbgr =>  long4(y, z, y, x);
        
        /// <summary>
        /// Returns long3.yzyy swizzling.
        /// </summary>
        [Inline]
        public long4 yzyy =>  long4(y, z, y, y);
        
        /// <summary>
        /// Returns long3.gbgg swizzling (equivalent to long3.yzyy).
        /// </summary>
        [Inline]
        public long4 gbgg =>  long4(y, z, y, y);
        
        /// <summary>
        /// Returns long3.yzyz swizzling.
        /// </summary>
        [Inline]
        public long4 yzyz =>  long4(y, z, y, z);
        
        /// <summary>
        /// Returns long3.gbgb swizzling (equivalent to long3.yzyz).
        /// </summary>
        [Inline]
        public long4 gbgb =>  long4(y, z, y, z);
        
        /// <summary>
        /// Returns long3.yzz swizzling.
        /// </summary>
        [Inline]
        public long3 yzz =>  long3(y, z, z);
        
        /// <summary>
        /// Returns long3.gbb swizzling (equivalent to long3.yzz).
        /// </summary>
        [Inline]
        public long3 gbb =>  long3(y, z, z);
        
        /// <summary>
        /// Returns long3.yzzx swizzling.
        /// </summary>
        [Inline]
        public long4 yzzx =>  long4(y, z, z, x);
        
        /// <summary>
        /// Returns long3.gbbr swizzling (equivalent to long3.yzzx).
        /// </summary>
        [Inline]
        public long4 gbbr =>  long4(y, z, z, x);
        
        /// <summary>
        /// Returns long3.yzzy swizzling.
        /// </summary>
        [Inline]
        public long4 yzzy =>  long4(y, z, z, y);
        
        /// <summary>
        /// Returns long3.gbbg swizzling (equivalent to long3.yzzy).
        /// </summary>
        [Inline]
        public long4 gbbg =>  long4(y, z, z, y);
        
        /// <summary>
        /// Returns long3.yzzz swizzling.
        /// </summary>
        [Inline]
        public long4 yzzz =>  long4(y, z, z, z);
        
        /// <summary>
        /// Returns long3.gbbb swizzling (equivalent to long3.yzzz).
        /// </summary>
        [Inline]
        public long4 gbbb =>  long4(y, z, z, z);
        
        /// <summary>
        /// Returns long3.zx swizzling.
        /// </summary>
        [Inline]
        public long2 zx =>  long2(z, x);
        
        /// <summary>
        /// Returns long3.br swizzling (equivalent to long3.zx).
        /// </summary>
        [Inline]
        public long2 br =>  long2(z, x);
        
        /// <summary>
        /// Returns long3.zxx swizzling.
        /// </summary>
        [Inline]
        public long3 zxx =>  long3(z, x, x);
        
        /// <summary>
        /// Returns long3.brr swizzling (equivalent to long3.zxx).
        /// </summary>
        [Inline]
        public long3 brr =>  long3(z, x, x);
        
        /// <summary>
        /// Returns long3.zxxx swizzling.
        /// </summary>
        [Inline]
        public long4 zxxx =>  long4(z, x, x, x);
        
        /// <summary>
        /// Returns long3.brrr swizzling (equivalent to long3.zxxx).
        /// </summary>
        [Inline]
        public long4 brrr =>  long4(z, x, x, x);
        
        /// <summary>
        /// Returns long3.zxxy swizzling.
        /// </summary>
        [Inline]
        public long4 zxxy =>  long4(z, x, x, y);
        
        /// <summary>
        /// Returns long3.brrg swizzling (equivalent to long3.zxxy).
        /// </summary>
        [Inline]
        public long4 brrg =>  long4(z, x, x, y);
        
        /// <summary>
        /// Returns long3.zxxz swizzling.
        /// </summary>
        [Inline]
        public long4 zxxz =>  long4(z, x, x, z);
        
        /// <summary>
        /// Returns long3.brrb swizzling (equivalent to long3.zxxz).
        /// </summary>
        [Inline]
        public long4 brrb =>  long4(z, x, x, z);
        
        /// <summary>
        /// Returns long3.zxy swizzling.
        /// </summary>
        [Inline]
        public long3 zxy =>  long3(z, x, y);
        
        /// <summary>
        /// Returns long3.brg swizzling (equivalent to long3.zxy).
        /// </summary>
        [Inline]
        public long3 brg =>  long3(z, x, y);
        
        /// <summary>
        /// Returns long3.zxyx swizzling.
        /// </summary>
        [Inline]
        public long4 zxyx =>  long4(z, x, y, x);
        
        /// <summary>
        /// Returns long3.brgr swizzling (equivalent to long3.zxyx).
        /// </summary>
        [Inline]
        public long4 brgr =>  long4(z, x, y, x);
        
        /// <summary>
        /// Returns long3.zxyy swizzling.
        /// </summary>
        [Inline]
        public long4 zxyy =>  long4(z, x, y, y);
        
        /// <summary>
        /// Returns long3.brgg swizzling (equivalent to long3.zxyy).
        /// </summary>
        [Inline]
        public long4 brgg =>  long4(z, x, y, y);
        
        /// <summary>
        /// Returns long3.zxyz swizzling.
        /// </summary>
        [Inline]
        public long4 zxyz =>  long4(z, x, y, z);
        
        /// <summary>
        /// Returns long3.brgb swizzling (equivalent to long3.zxyz).
        /// </summary>
        [Inline]
        public long4 brgb =>  long4(z, x, y, z);
        
        /// <summary>
        /// Returns long3.zxz swizzling.
        /// </summary>
        [Inline]
        public long3 zxz =>  long3(z, x, z);
        
        /// <summary>
        /// Returns long3.brb swizzling (equivalent to long3.zxz).
        /// </summary>
        [Inline]
        public long3 brb =>  long3(z, x, z);
        
        /// <summary>
        /// Returns long3.zxzx swizzling.
        /// </summary>
        [Inline]
        public long4 zxzx =>  long4(z, x, z, x);
        
        /// <summary>
        /// Returns long3.brbr swizzling (equivalent to long3.zxzx).
        /// </summary>
        [Inline]
        public long4 brbr =>  long4(z, x, z, x);
        
        /// <summary>
        /// Returns long3.zxzy swizzling.
        /// </summary>
        [Inline]
        public long4 zxzy =>  long4(z, x, z, y);
        
        /// <summary>
        /// Returns long3.brbg swizzling (equivalent to long3.zxzy).
        /// </summary>
        [Inline]
        public long4 brbg =>  long4(z, x, z, y);
        
        /// <summary>
        /// Returns long3.zxzz swizzling.
        /// </summary>
        [Inline]
        public long4 zxzz =>  long4(z, x, z, z);
        
        /// <summary>
        /// Returns long3.brbb swizzling (equivalent to long3.zxzz).
        /// </summary>
        [Inline]
        public long4 brbb =>  long4(z, x, z, z);
        
        /// <summary>
        /// Returns long3.zy swizzling.
        /// </summary>
        [Inline]
        public long2 zy =>  long2(z, y);
        
        /// <summary>
        /// Returns long3.bg swizzling (equivalent to long3.zy).
        /// </summary>
        [Inline]
        public long2 bg =>  long2(z, y);
        
        /// <summary>
        /// Returns long3.zyx swizzling.
        /// </summary>
        [Inline]
        public long3 zyx =>  long3(z, y, x);
        
        /// <summary>
        /// Returns long3.bgr swizzling (equivalent to long3.zyx).
        /// </summary>
        [Inline]
        public long3 bgr =>  long3(z, y, x);
        
        /// <summary>
        /// Returns long3.zyxx swizzling.
        /// </summary>
        [Inline]
        public long4 zyxx =>  long4(z, y, x, x);
        
        /// <summary>
        /// Returns long3.bgrr swizzling (equivalent to long3.zyxx).
        /// </summary>
        [Inline]
        public long4 bgrr =>  long4(z, y, x, x);
        
        /// <summary>
        /// Returns long3.zyxy swizzling.
        /// </summary>
        [Inline]
        public long4 zyxy =>  long4(z, y, x, y);
        
        /// <summary>
        /// Returns long3.bgrg swizzling (equivalent to long3.zyxy).
        /// </summary>
        [Inline]
        public long4 bgrg =>  long4(z, y, x, y);
        
        /// <summary>
        /// Returns long3.zyxz swizzling.
        /// </summary>
        [Inline]
        public long4 zyxz =>  long4(z, y, x, z);
        
        /// <summary>
        /// Returns long3.bgrb swizzling (equivalent to long3.zyxz).
        /// </summary>
        [Inline]
        public long4 bgrb =>  long4(z, y, x, z);
        
        /// <summary>
        /// Returns long3.zyy swizzling.
        /// </summary>
        [Inline]
        public long3 zyy =>  long3(z, y, y);
        
        /// <summary>
        /// Returns long3.bgg swizzling (equivalent to long3.zyy).
        /// </summary>
        [Inline]
        public long3 bgg =>  long3(z, y, y);
        
        /// <summary>
        /// Returns long3.zyyx swizzling.
        /// </summary>
        [Inline]
        public long4 zyyx =>  long4(z, y, y, x);
        
        /// <summary>
        /// Returns long3.bggr swizzling (equivalent to long3.zyyx).
        /// </summary>
        [Inline]
        public long4 bggr =>  long4(z, y, y, x);
        
        /// <summary>
        /// Returns long3.zyyy swizzling.
        /// </summary>
        [Inline]
        public long4 zyyy =>  long4(z, y, y, y);
        
        /// <summary>
        /// Returns long3.bggg swizzling (equivalent to long3.zyyy).
        /// </summary>
        [Inline]
        public long4 bggg =>  long4(z, y, y, y);
        
        /// <summary>
        /// Returns long3.zyyz swizzling.
        /// </summary>
        [Inline]
        public long4 zyyz =>  long4(z, y, y, z);
        
        /// <summary>
        /// Returns long3.bggb swizzling (equivalent to long3.zyyz).
        /// </summary>
        [Inline]
        public long4 bggb =>  long4(z, y, y, z);
        
        /// <summary>
        /// Returns long3.zyz swizzling.
        /// </summary>
        [Inline]
        public long3 zyz =>  long3(z, y, z);
        
        /// <summary>
        /// Returns long3.bgb swizzling (equivalent to long3.zyz).
        /// </summary>
        [Inline]
        public long3 bgb =>  long3(z, y, z);
        
        /// <summary>
        /// Returns long3.zyzx swizzling.
        /// </summary>
        [Inline]
        public long4 zyzx =>  long4(z, y, z, x);
        
        /// <summary>
        /// Returns long3.bgbr swizzling (equivalent to long3.zyzx).
        /// </summary>
        [Inline]
        public long4 bgbr =>  long4(z, y, z, x);
        
        /// <summary>
        /// Returns long3.zyzy swizzling.
        /// </summary>
        [Inline]
        public long4 zyzy =>  long4(z, y, z, y);
        
        /// <summary>
        /// Returns long3.bgbg swizzling (equivalent to long3.zyzy).
        /// </summary>
        [Inline]
        public long4 bgbg =>  long4(z, y, z, y);
        
        /// <summary>
        /// Returns long3.zyzz swizzling.
        /// </summary>
        [Inline]
        public long4 zyzz =>  long4(z, y, z, z);
        
        /// <summary>
        /// Returns long3.bgbb swizzling (equivalent to long3.zyzz).
        /// </summary>
        [Inline]
        public long4 bgbb =>  long4(z, y, z, z);
        
        /// <summary>
        /// Returns long3.zz swizzling.
        /// </summary>
        [Inline]
        public long2 zz =>  long2(z, z);
        
        /// <summary>
        /// Returns long3.bb swizzling (equivalent to long3.zz).
        /// </summary>
        [Inline]
        public long2 bb =>  long2(z, z);
        
        /// <summary>
        /// Returns long3.zzx swizzling.
        /// </summary>
        [Inline]
        public long3 zzx =>  long3(z, z, x);
        
        /// <summary>
        /// Returns long3.bbr swizzling (equivalent to long3.zzx).
        /// </summary>
        [Inline]
        public long3 bbr =>  long3(z, z, x);
        
        /// <summary>
        /// Returns long3.zzxx swizzling.
        /// </summary>
        [Inline]
        public long4 zzxx =>  long4(z, z, x, x);
        
        /// <summary>
        /// Returns long3.bbrr swizzling (equivalent to long3.zzxx).
        /// </summary>
        [Inline]
        public long4 bbrr =>  long4(z, z, x, x);
        
        /// <summary>
        /// Returns long3.zzxy swizzling.
        /// </summary>
        [Inline]
        public long4 zzxy =>  long4(z, z, x, y);
        
        /// <summary>
        /// Returns long3.bbrg swizzling (equivalent to long3.zzxy).
        /// </summary>
        [Inline]
        public long4 bbrg =>  long4(z, z, x, y);
        
        /// <summary>
        /// Returns long3.zzxz swizzling.
        /// </summary>
        [Inline]
        public long4 zzxz =>  long4(z, z, x, z);
        
        /// <summary>
        /// Returns long3.bbrb swizzling (equivalent to long3.zzxz).
        /// </summary>
        [Inline]
        public long4 bbrb =>  long4(z, z, x, z);
        
        /// <summary>
        /// Returns long3.zzy swizzling.
        /// </summary>
        [Inline]
        public long3 zzy =>  long3(z, z, y);
        
        /// <summary>
        /// Returns long3.bbg swizzling (equivalent to long3.zzy).
        /// </summary>
        [Inline]
        public long3 bbg =>  long3(z, z, y);
        
        /// <summary>
        /// Returns long3.zzyx swizzling.
        /// </summary>
        [Inline]
        public long4 zzyx =>  long4(z, z, y, x);
        
        /// <summary>
        /// Returns long3.bbgr swizzling (equivalent to long3.zzyx).
        /// </summary>
        [Inline]
        public long4 bbgr =>  long4(z, z, y, x);
        
        /// <summary>
        /// Returns long3.zzyy swizzling.
        /// </summary>
        [Inline]
        public long4 zzyy =>  long4(z, z, y, y);
        
        /// <summary>
        /// Returns long3.bbgg swizzling (equivalent to long3.zzyy).
        /// </summary>
        [Inline]
        public long4 bbgg =>  long4(z, z, y, y);
        
        /// <summary>
        /// Returns long3.zzyz swizzling.
        /// </summary>
        [Inline]
        public long4 zzyz =>  long4(z, z, y, z);
        
        /// <summary>
        /// Returns long3.bbgb swizzling (equivalent to long3.zzyz).
        /// </summary>
        [Inline]
        public long4 bbgb =>  long4(z, z, y, z);
        
        /// <summary>
        /// Returns long3.zzz swizzling.
        /// </summary>
        [Inline]
        public long3 zzz =>  long3(z, z, z);
        
        /// <summary>
        /// Returns long3.bbb swizzling (equivalent to long3.zzz).
        /// </summary>
        [Inline]
        public long3 bbb =>  long3(z, z, z);
        
        /// <summary>
        /// Returns long3.zzzx swizzling.
        /// </summary>
        [Inline]
        public long4 zzzx =>  long4(z, z, z, x);
        
        /// <summary>
        /// Returns long3.bbbr swizzling (equivalent to long3.zzzx).
        /// </summary>
        [Inline]
        public long4 bbbr =>  long4(z, z, z, x);
        
        /// <summary>
        /// Returns long3.zzzy swizzling.
        /// </summary>
        [Inline]
        public long4 zzzy =>  long4(z, z, z, y);
        
        /// <summary>
        /// Returns long3.bbbg swizzling (equivalent to long3.zzzy).
        /// </summary>
        [Inline]
        public long4 bbbg =>  long4(z, z, z, y);
        
        /// <summary>
        /// Returns long3.zzzz swizzling.
        /// </summary>
        [Inline]
        public long4 zzzz =>  long4(z, z, z, z);
        
        /// <summary>
        /// Returns long3.bbbb swizzling (equivalent to long3.zzzz).
        /// </summary>
        [Inline]
        public long4 bbbb =>  long4(z, z, z, z);

        //#endregion

    }
}
