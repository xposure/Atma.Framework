using System;
namespace Atma
{
    
    /// <summary>
    /// Temporary vector of type uint with 3 components, used for implementing swizzling for uint3.
    /// </summary>
    public struct swizzle_uint3
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
        
        /// <summary>
        /// z-component
        /// </summary>
        private readonly uint z;

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Returns uint3.xx swizzling.
        /// </summary>
        [Inline]
        public uint2 xx =>  uint2(x, x);
        
        /// <summary>
        /// Returns uint3.rr swizzling (equivalent to uint3.xx).
        /// </summary>
        [Inline]
        public uint2 rr =>  uint2(x, x);
        
        /// <summary>
        /// Returns uint3.xxx swizzling.
        /// </summary>
        [Inline]
        public uint3 xxx =>  uint3(x, x, x);
        
        /// <summary>
        /// Returns uint3.rrr swizzling (equivalent to uint3.xxx).
        /// </summary>
        [Inline]
        public uint3 rrr =>  uint3(x, x, x);
        
        /// <summary>
        /// Returns uint3.xxxx swizzling.
        /// </summary>
        [Inline]
        public uint4 xxxx =>  uint4(x, x, x, x);
        
        /// <summary>
        /// Returns uint3.rrrr swizzling (equivalent to uint3.xxxx).
        /// </summary>
        [Inline]
        public uint4 rrrr =>  uint4(x, x, x, x);
        
        /// <summary>
        /// Returns uint3.xxxy swizzling.
        /// </summary>
        [Inline]
        public uint4 xxxy =>  uint4(x, x, x, y);
        
        /// <summary>
        /// Returns uint3.rrrg swizzling (equivalent to uint3.xxxy).
        /// </summary>
        [Inline]
        public uint4 rrrg =>  uint4(x, x, x, y);
        
        /// <summary>
        /// Returns uint3.xxxz swizzling.
        /// </summary>
        [Inline]
        public uint4 xxxz =>  uint4(x, x, x, z);
        
        /// <summary>
        /// Returns uint3.rrrb swizzling (equivalent to uint3.xxxz).
        /// </summary>
        [Inline]
        public uint4 rrrb =>  uint4(x, x, x, z);
        
        /// <summary>
        /// Returns uint3.xxy swizzling.
        /// </summary>
        [Inline]
        public uint3 xxy =>  uint3(x, x, y);
        
        /// <summary>
        /// Returns uint3.rrg swizzling (equivalent to uint3.xxy).
        /// </summary>
        [Inline]
        public uint3 rrg =>  uint3(x, x, y);
        
        /// <summary>
        /// Returns uint3.xxyx swizzling.
        /// </summary>
        [Inline]
        public uint4 xxyx =>  uint4(x, x, y, x);
        
        /// <summary>
        /// Returns uint3.rrgr swizzling (equivalent to uint3.xxyx).
        /// </summary>
        [Inline]
        public uint4 rrgr =>  uint4(x, x, y, x);
        
        /// <summary>
        /// Returns uint3.xxyy swizzling.
        /// </summary>
        [Inline]
        public uint4 xxyy =>  uint4(x, x, y, y);
        
        /// <summary>
        /// Returns uint3.rrgg swizzling (equivalent to uint3.xxyy).
        /// </summary>
        [Inline]
        public uint4 rrgg =>  uint4(x, x, y, y);
        
        /// <summary>
        /// Returns uint3.xxyz swizzling.
        /// </summary>
        [Inline]
        public uint4 xxyz =>  uint4(x, x, y, z);
        
        /// <summary>
        /// Returns uint3.rrgb swizzling (equivalent to uint3.xxyz).
        /// </summary>
        [Inline]
        public uint4 rrgb =>  uint4(x, x, y, z);
        
        /// <summary>
        /// Returns uint3.xxz swizzling.
        /// </summary>
        [Inline]
        public uint3 xxz =>  uint3(x, x, z);
        
        /// <summary>
        /// Returns uint3.rrb swizzling (equivalent to uint3.xxz).
        /// </summary>
        [Inline]
        public uint3 rrb =>  uint3(x, x, z);
        
        /// <summary>
        /// Returns uint3.xxzx swizzling.
        /// </summary>
        [Inline]
        public uint4 xxzx =>  uint4(x, x, z, x);
        
        /// <summary>
        /// Returns uint3.rrbr swizzling (equivalent to uint3.xxzx).
        /// </summary>
        [Inline]
        public uint4 rrbr =>  uint4(x, x, z, x);
        
        /// <summary>
        /// Returns uint3.xxzy swizzling.
        /// </summary>
        [Inline]
        public uint4 xxzy =>  uint4(x, x, z, y);
        
        /// <summary>
        /// Returns uint3.rrbg swizzling (equivalent to uint3.xxzy).
        /// </summary>
        [Inline]
        public uint4 rrbg =>  uint4(x, x, z, y);
        
        /// <summary>
        /// Returns uint3.xxzz swizzling.
        /// </summary>
        [Inline]
        public uint4 xxzz =>  uint4(x, x, z, z);
        
        /// <summary>
        /// Returns uint3.rrbb swizzling (equivalent to uint3.xxzz).
        /// </summary>
        [Inline]
        public uint4 rrbb =>  uint4(x, x, z, z);
        
        /// <summary>
        /// Returns uint3.xy swizzling.
        /// </summary>
        [Inline]
        public uint2 xy =>  uint2(x, y);
        
        /// <summary>
        /// Returns uint3.rg swizzling (equivalent to uint3.xy).
        /// </summary>
        [Inline]
        public uint2 rg =>  uint2(x, y);
        
        /// <summary>
        /// Returns uint3.xyx swizzling.
        /// </summary>
        [Inline]
        public uint3 xyx =>  uint3(x, y, x);
        
        /// <summary>
        /// Returns uint3.rgr swizzling (equivalent to uint3.xyx).
        /// </summary>
        [Inline]
        public uint3 rgr =>  uint3(x, y, x);
        
        /// <summary>
        /// Returns uint3.xyxx swizzling.
        /// </summary>
        [Inline]
        public uint4 xyxx =>  uint4(x, y, x, x);
        
        /// <summary>
        /// Returns uint3.rgrr swizzling (equivalent to uint3.xyxx).
        /// </summary>
        [Inline]
        public uint4 rgrr =>  uint4(x, y, x, x);
        
        /// <summary>
        /// Returns uint3.xyxy swizzling.
        /// </summary>
        [Inline]
        public uint4 xyxy =>  uint4(x, y, x, y);
        
        /// <summary>
        /// Returns uint3.rgrg swizzling (equivalent to uint3.xyxy).
        /// </summary>
        [Inline]
        public uint4 rgrg =>  uint4(x, y, x, y);
        
        /// <summary>
        /// Returns uint3.xyxz swizzling.
        /// </summary>
        [Inline]
        public uint4 xyxz =>  uint4(x, y, x, z);
        
        /// <summary>
        /// Returns uint3.rgrb swizzling (equivalent to uint3.xyxz).
        /// </summary>
        [Inline]
        public uint4 rgrb =>  uint4(x, y, x, z);
        
        /// <summary>
        /// Returns uint3.xyy swizzling.
        /// </summary>
        [Inline]
        public uint3 xyy =>  uint3(x, y, y);
        
        /// <summary>
        /// Returns uint3.rgg swizzling (equivalent to uint3.xyy).
        /// </summary>
        [Inline]
        public uint3 rgg =>  uint3(x, y, y);
        
        /// <summary>
        /// Returns uint3.xyyx swizzling.
        /// </summary>
        [Inline]
        public uint4 xyyx =>  uint4(x, y, y, x);
        
        /// <summary>
        /// Returns uint3.rggr swizzling (equivalent to uint3.xyyx).
        /// </summary>
        [Inline]
        public uint4 rggr =>  uint4(x, y, y, x);
        
        /// <summary>
        /// Returns uint3.xyyy swizzling.
        /// </summary>
        [Inline]
        public uint4 xyyy =>  uint4(x, y, y, y);
        
        /// <summary>
        /// Returns uint3.rggg swizzling (equivalent to uint3.xyyy).
        /// </summary>
        [Inline]
        public uint4 rggg =>  uint4(x, y, y, y);
        
        /// <summary>
        /// Returns uint3.xyyz swizzling.
        /// </summary>
        [Inline]
        public uint4 xyyz =>  uint4(x, y, y, z);
        
        /// <summary>
        /// Returns uint3.rggb swizzling (equivalent to uint3.xyyz).
        /// </summary>
        [Inline]
        public uint4 rggb =>  uint4(x, y, y, z);
        
        /// <summary>
        /// Returns uint3.xyz swizzling.
        /// </summary>
        [Inline]
        public uint3 xyz =>  uint3(x, y, z);
        
        /// <summary>
        /// Returns uint3.rgb swizzling (equivalent to uint3.xyz).
        /// </summary>
        [Inline]
        public uint3 rgb =>  uint3(x, y, z);
        
        /// <summary>
        /// Returns uint3.xyzx swizzling.
        /// </summary>
        [Inline]
        public uint4 xyzx =>  uint4(x, y, z, x);
        
        /// <summary>
        /// Returns uint3.rgbr swizzling (equivalent to uint3.xyzx).
        /// </summary>
        [Inline]
        public uint4 rgbr =>  uint4(x, y, z, x);
        
        /// <summary>
        /// Returns uint3.xyzy swizzling.
        /// </summary>
        [Inline]
        public uint4 xyzy =>  uint4(x, y, z, y);
        
        /// <summary>
        /// Returns uint3.rgbg swizzling (equivalent to uint3.xyzy).
        /// </summary>
        [Inline]
        public uint4 rgbg =>  uint4(x, y, z, y);
        
        /// <summary>
        /// Returns uint3.xyzz swizzling.
        /// </summary>
        [Inline]
        public uint4 xyzz =>  uint4(x, y, z, z);
        
        /// <summary>
        /// Returns uint3.rgbb swizzling (equivalent to uint3.xyzz).
        /// </summary>
        [Inline]
        public uint4 rgbb =>  uint4(x, y, z, z);
        
        /// <summary>
        /// Returns uint3.xz swizzling.
        /// </summary>
        [Inline]
        public uint2 xz =>  uint2(x, z);
        
        /// <summary>
        /// Returns uint3.rb swizzling (equivalent to uint3.xz).
        /// </summary>
        [Inline]
        public uint2 rb =>  uint2(x, z);
        
        /// <summary>
        /// Returns uint3.xzx swizzling.
        /// </summary>
        [Inline]
        public uint3 xzx =>  uint3(x, z, x);
        
        /// <summary>
        /// Returns uint3.rbr swizzling (equivalent to uint3.xzx).
        /// </summary>
        [Inline]
        public uint3 rbr =>  uint3(x, z, x);
        
        /// <summary>
        /// Returns uint3.xzxx swizzling.
        /// </summary>
        [Inline]
        public uint4 xzxx =>  uint4(x, z, x, x);
        
        /// <summary>
        /// Returns uint3.rbrr swizzling (equivalent to uint3.xzxx).
        /// </summary>
        [Inline]
        public uint4 rbrr =>  uint4(x, z, x, x);
        
        /// <summary>
        /// Returns uint3.xzxy swizzling.
        /// </summary>
        [Inline]
        public uint4 xzxy =>  uint4(x, z, x, y);
        
        /// <summary>
        /// Returns uint3.rbrg swizzling (equivalent to uint3.xzxy).
        /// </summary>
        [Inline]
        public uint4 rbrg =>  uint4(x, z, x, y);
        
        /// <summary>
        /// Returns uint3.xzxz swizzling.
        /// </summary>
        [Inline]
        public uint4 xzxz =>  uint4(x, z, x, z);
        
        /// <summary>
        /// Returns uint3.rbrb swizzling (equivalent to uint3.xzxz).
        /// </summary>
        [Inline]
        public uint4 rbrb =>  uint4(x, z, x, z);
        
        /// <summary>
        /// Returns uint3.xzy swizzling.
        /// </summary>
        [Inline]
        public uint3 xzy =>  uint3(x, z, y);
        
        /// <summary>
        /// Returns uint3.rbg swizzling (equivalent to uint3.xzy).
        /// </summary>
        [Inline]
        public uint3 rbg =>  uint3(x, z, y);
        
        /// <summary>
        /// Returns uint3.xzyx swizzling.
        /// </summary>
        [Inline]
        public uint4 xzyx =>  uint4(x, z, y, x);
        
        /// <summary>
        /// Returns uint3.rbgr swizzling (equivalent to uint3.xzyx).
        /// </summary>
        [Inline]
        public uint4 rbgr =>  uint4(x, z, y, x);
        
        /// <summary>
        /// Returns uint3.xzyy swizzling.
        /// </summary>
        [Inline]
        public uint4 xzyy =>  uint4(x, z, y, y);
        
        /// <summary>
        /// Returns uint3.rbgg swizzling (equivalent to uint3.xzyy).
        /// </summary>
        [Inline]
        public uint4 rbgg =>  uint4(x, z, y, y);
        
        /// <summary>
        /// Returns uint3.xzyz swizzling.
        /// </summary>
        [Inline]
        public uint4 xzyz =>  uint4(x, z, y, z);
        
        /// <summary>
        /// Returns uint3.rbgb swizzling (equivalent to uint3.xzyz).
        /// </summary>
        [Inline]
        public uint4 rbgb =>  uint4(x, z, y, z);
        
        /// <summary>
        /// Returns uint3.xzz swizzling.
        /// </summary>
        [Inline]
        public uint3 xzz =>  uint3(x, z, z);
        
        /// <summary>
        /// Returns uint3.rbb swizzling (equivalent to uint3.xzz).
        /// </summary>
        [Inline]
        public uint3 rbb =>  uint3(x, z, z);
        
        /// <summary>
        /// Returns uint3.xzzx swizzling.
        /// </summary>
        [Inline]
        public uint4 xzzx =>  uint4(x, z, z, x);
        
        /// <summary>
        /// Returns uint3.rbbr swizzling (equivalent to uint3.xzzx).
        /// </summary>
        [Inline]
        public uint4 rbbr =>  uint4(x, z, z, x);
        
        /// <summary>
        /// Returns uint3.xzzy swizzling.
        /// </summary>
        [Inline]
        public uint4 xzzy =>  uint4(x, z, z, y);
        
        /// <summary>
        /// Returns uint3.rbbg swizzling (equivalent to uint3.xzzy).
        /// </summary>
        [Inline]
        public uint4 rbbg =>  uint4(x, z, z, y);
        
        /// <summary>
        /// Returns uint3.xzzz swizzling.
        /// </summary>
        [Inline]
        public uint4 xzzz =>  uint4(x, z, z, z);
        
        /// <summary>
        /// Returns uint3.rbbb swizzling (equivalent to uint3.xzzz).
        /// </summary>
        [Inline]
        public uint4 rbbb =>  uint4(x, z, z, z);
        
        /// <summary>
        /// Returns uint3.yx swizzling.
        /// </summary>
        [Inline]
        public uint2 yx =>  uint2(y, x);
        
        /// <summary>
        /// Returns uint3.gr swizzling (equivalent to uint3.yx).
        /// </summary>
        [Inline]
        public uint2 gr =>  uint2(y, x);
        
        /// <summary>
        /// Returns uint3.yxx swizzling.
        /// </summary>
        [Inline]
        public uint3 yxx =>  uint3(y, x, x);
        
        /// <summary>
        /// Returns uint3.grr swizzling (equivalent to uint3.yxx).
        /// </summary>
        [Inline]
        public uint3 grr =>  uint3(y, x, x);
        
        /// <summary>
        /// Returns uint3.yxxx swizzling.
        /// </summary>
        [Inline]
        public uint4 yxxx =>  uint4(y, x, x, x);
        
        /// <summary>
        /// Returns uint3.grrr swizzling (equivalent to uint3.yxxx).
        /// </summary>
        [Inline]
        public uint4 grrr =>  uint4(y, x, x, x);
        
        /// <summary>
        /// Returns uint3.yxxy swizzling.
        /// </summary>
        [Inline]
        public uint4 yxxy =>  uint4(y, x, x, y);
        
        /// <summary>
        /// Returns uint3.grrg swizzling (equivalent to uint3.yxxy).
        /// </summary>
        [Inline]
        public uint4 grrg =>  uint4(y, x, x, y);
        
        /// <summary>
        /// Returns uint3.yxxz swizzling.
        /// </summary>
        [Inline]
        public uint4 yxxz =>  uint4(y, x, x, z);
        
        /// <summary>
        /// Returns uint3.grrb swizzling (equivalent to uint3.yxxz).
        /// </summary>
        [Inline]
        public uint4 grrb =>  uint4(y, x, x, z);
        
        /// <summary>
        /// Returns uint3.yxy swizzling.
        /// </summary>
        [Inline]
        public uint3 yxy =>  uint3(y, x, y);
        
        /// <summary>
        /// Returns uint3.grg swizzling (equivalent to uint3.yxy).
        /// </summary>
        [Inline]
        public uint3 grg =>  uint3(y, x, y);
        
        /// <summary>
        /// Returns uint3.yxyx swizzling.
        /// </summary>
        [Inline]
        public uint4 yxyx =>  uint4(y, x, y, x);
        
        /// <summary>
        /// Returns uint3.grgr swizzling (equivalent to uint3.yxyx).
        /// </summary>
        [Inline]
        public uint4 grgr =>  uint4(y, x, y, x);
        
        /// <summary>
        /// Returns uint3.yxyy swizzling.
        /// </summary>
        [Inline]
        public uint4 yxyy =>  uint4(y, x, y, y);
        
        /// <summary>
        /// Returns uint3.grgg swizzling (equivalent to uint3.yxyy).
        /// </summary>
        [Inline]
        public uint4 grgg =>  uint4(y, x, y, y);
        
        /// <summary>
        /// Returns uint3.yxyz swizzling.
        /// </summary>
        [Inline]
        public uint4 yxyz =>  uint4(y, x, y, z);
        
        /// <summary>
        /// Returns uint3.grgb swizzling (equivalent to uint3.yxyz).
        /// </summary>
        [Inline]
        public uint4 grgb =>  uint4(y, x, y, z);
        
        /// <summary>
        /// Returns uint3.yxz swizzling.
        /// </summary>
        [Inline]
        public uint3 yxz =>  uint3(y, x, z);
        
        /// <summary>
        /// Returns uint3.grb swizzling (equivalent to uint3.yxz).
        /// </summary>
        [Inline]
        public uint3 grb =>  uint3(y, x, z);
        
        /// <summary>
        /// Returns uint3.yxzx swizzling.
        /// </summary>
        [Inline]
        public uint4 yxzx =>  uint4(y, x, z, x);
        
        /// <summary>
        /// Returns uint3.grbr swizzling (equivalent to uint3.yxzx).
        /// </summary>
        [Inline]
        public uint4 grbr =>  uint4(y, x, z, x);
        
        /// <summary>
        /// Returns uint3.yxzy swizzling.
        /// </summary>
        [Inline]
        public uint4 yxzy =>  uint4(y, x, z, y);
        
        /// <summary>
        /// Returns uint3.grbg swizzling (equivalent to uint3.yxzy).
        /// </summary>
        [Inline]
        public uint4 grbg =>  uint4(y, x, z, y);
        
        /// <summary>
        /// Returns uint3.yxzz swizzling.
        /// </summary>
        [Inline]
        public uint4 yxzz =>  uint4(y, x, z, z);
        
        /// <summary>
        /// Returns uint3.grbb swizzling (equivalent to uint3.yxzz).
        /// </summary>
        [Inline]
        public uint4 grbb =>  uint4(y, x, z, z);
        
        /// <summary>
        /// Returns uint3.yy swizzling.
        /// </summary>
        [Inline]
        public uint2 yy =>  uint2(y, y);
        
        /// <summary>
        /// Returns uint3.gg swizzling (equivalent to uint3.yy).
        /// </summary>
        [Inline]
        public uint2 gg =>  uint2(y, y);
        
        /// <summary>
        /// Returns uint3.yyx swizzling.
        /// </summary>
        [Inline]
        public uint3 yyx =>  uint3(y, y, x);
        
        /// <summary>
        /// Returns uint3.ggr swizzling (equivalent to uint3.yyx).
        /// </summary>
        [Inline]
        public uint3 ggr =>  uint3(y, y, x);
        
        /// <summary>
        /// Returns uint3.yyxx swizzling.
        /// </summary>
        [Inline]
        public uint4 yyxx =>  uint4(y, y, x, x);
        
        /// <summary>
        /// Returns uint3.ggrr swizzling (equivalent to uint3.yyxx).
        /// </summary>
        [Inline]
        public uint4 ggrr =>  uint4(y, y, x, x);
        
        /// <summary>
        /// Returns uint3.yyxy swizzling.
        /// </summary>
        [Inline]
        public uint4 yyxy =>  uint4(y, y, x, y);
        
        /// <summary>
        /// Returns uint3.ggrg swizzling (equivalent to uint3.yyxy).
        /// </summary>
        [Inline]
        public uint4 ggrg =>  uint4(y, y, x, y);
        
        /// <summary>
        /// Returns uint3.yyxz swizzling.
        /// </summary>
        [Inline]
        public uint4 yyxz =>  uint4(y, y, x, z);
        
        /// <summary>
        /// Returns uint3.ggrb swizzling (equivalent to uint3.yyxz).
        /// </summary>
        [Inline]
        public uint4 ggrb =>  uint4(y, y, x, z);
        
        /// <summary>
        /// Returns uint3.yyy swizzling.
        /// </summary>
        [Inline]
        public uint3 yyy =>  uint3(y, y, y);
        
        /// <summary>
        /// Returns uint3.ggg swizzling (equivalent to uint3.yyy).
        /// </summary>
        [Inline]
        public uint3 ggg =>  uint3(y, y, y);
        
        /// <summary>
        /// Returns uint3.yyyx swizzling.
        /// </summary>
        [Inline]
        public uint4 yyyx =>  uint4(y, y, y, x);
        
        /// <summary>
        /// Returns uint3.gggr swizzling (equivalent to uint3.yyyx).
        /// </summary>
        [Inline]
        public uint4 gggr =>  uint4(y, y, y, x);
        
        /// <summary>
        /// Returns uint3.yyyy swizzling.
        /// </summary>
        [Inline]
        public uint4 yyyy =>  uint4(y, y, y, y);
        
        /// <summary>
        /// Returns uint3.gggg swizzling (equivalent to uint3.yyyy).
        /// </summary>
        [Inline]
        public uint4 gggg =>  uint4(y, y, y, y);
        
        /// <summary>
        /// Returns uint3.yyyz swizzling.
        /// </summary>
        [Inline]
        public uint4 yyyz =>  uint4(y, y, y, z);
        
        /// <summary>
        /// Returns uint3.gggb swizzling (equivalent to uint3.yyyz).
        /// </summary>
        [Inline]
        public uint4 gggb =>  uint4(y, y, y, z);
        
        /// <summary>
        /// Returns uint3.yyz swizzling.
        /// </summary>
        [Inline]
        public uint3 yyz =>  uint3(y, y, z);
        
        /// <summary>
        /// Returns uint3.ggb swizzling (equivalent to uint3.yyz).
        /// </summary>
        [Inline]
        public uint3 ggb =>  uint3(y, y, z);
        
        /// <summary>
        /// Returns uint3.yyzx swizzling.
        /// </summary>
        [Inline]
        public uint4 yyzx =>  uint4(y, y, z, x);
        
        /// <summary>
        /// Returns uint3.ggbr swizzling (equivalent to uint3.yyzx).
        /// </summary>
        [Inline]
        public uint4 ggbr =>  uint4(y, y, z, x);
        
        /// <summary>
        /// Returns uint3.yyzy swizzling.
        /// </summary>
        [Inline]
        public uint4 yyzy =>  uint4(y, y, z, y);
        
        /// <summary>
        /// Returns uint3.ggbg swizzling (equivalent to uint3.yyzy).
        /// </summary>
        [Inline]
        public uint4 ggbg =>  uint4(y, y, z, y);
        
        /// <summary>
        /// Returns uint3.yyzz swizzling.
        /// </summary>
        [Inline]
        public uint4 yyzz =>  uint4(y, y, z, z);
        
        /// <summary>
        /// Returns uint3.ggbb swizzling (equivalent to uint3.yyzz).
        /// </summary>
        [Inline]
        public uint4 ggbb =>  uint4(y, y, z, z);
        
        /// <summary>
        /// Returns uint3.yz swizzling.
        /// </summary>
        [Inline]
        public uint2 yz =>  uint2(y, z);
        
        /// <summary>
        /// Returns uint3.gb swizzling (equivalent to uint3.yz).
        /// </summary>
        [Inline]
        public uint2 gb =>  uint2(y, z);
        
        /// <summary>
        /// Returns uint3.yzx swizzling.
        /// </summary>
        [Inline]
        public uint3 yzx =>  uint3(y, z, x);
        
        /// <summary>
        /// Returns uint3.gbr swizzling (equivalent to uint3.yzx).
        /// </summary>
        [Inline]
        public uint3 gbr =>  uint3(y, z, x);
        
        /// <summary>
        /// Returns uint3.yzxx swizzling.
        /// </summary>
        [Inline]
        public uint4 yzxx =>  uint4(y, z, x, x);
        
        /// <summary>
        /// Returns uint3.gbrr swizzling (equivalent to uint3.yzxx).
        /// </summary>
        [Inline]
        public uint4 gbrr =>  uint4(y, z, x, x);
        
        /// <summary>
        /// Returns uint3.yzxy swizzling.
        /// </summary>
        [Inline]
        public uint4 yzxy =>  uint4(y, z, x, y);
        
        /// <summary>
        /// Returns uint3.gbrg swizzling (equivalent to uint3.yzxy).
        /// </summary>
        [Inline]
        public uint4 gbrg =>  uint4(y, z, x, y);
        
        /// <summary>
        /// Returns uint3.yzxz swizzling.
        /// </summary>
        [Inline]
        public uint4 yzxz =>  uint4(y, z, x, z);
        
        /// <summary>
        /// Returns uint3.gbrb swizzling (equivalent to uint3.yzxz).
        /// </summary>
        [Inline]
        public uint4 gbrb =>  uint4(y, z, x, z);
        
        /// <summary>
        /// Returns uint3.yzy swizzling.
        /// </summary>
        [Inline]
        public uint3 yzy =>  uint3(y, z, y);
        
        /// <summary>
        /// Returns uint3.gbg swizzling (equivalent to uint3.yzy).
        /// </summary>
        [Inline]
        public uint3 gbg =>  uint3(y, z, y);
        
        /// <summary>
        /// Returns uint3.yzyx swizzling.
        /// </summary>
        [Inline]
        public uint4 yzyx =>  uint4(y, z, y, x);
        
        /// <summary>
        /// Returns uint3.gbgr swizzling (equivalent to uint3.yzyx).
        /// </summary>
        [Inline]
        public uint4 gbgr =>  uint4(y, z, y, x);
        
        /// <summary>
        /// Returns uint3.yzyy swizzling.
        /// </summary>
        [Inline]
        public uint4 yzyy =>  uint4(y, z, y, y);
        
        /// <summary>
        /// Returns uint3.gbgg swizzling (equivalent to uint3.yzyy).
        /// </summary>
        [Inline]
        public uint4 gbgg =>  uint4(y, z, y, y);
        
        /// <summary>
        /// Returns uint3.yzyz swizzling.
        /// </summary>
        [Inline]
        public uint4 yzyz =>  uint4(y, z, y, z);
        
        /// <summary>
        /// Returns uint3.gbgb swizzling (equivalent to uint3.yzyz).
        /// </summary>
        [Inline]
        public uint4 gbgb =>  uint4(y, z, y, z);
        
        /// <summary>
        /// Returns uint3.yzz swizzling.
        /// </summary>
        [Inline]
        public uint3 yzz =>  uint3(y, z, z);
        
        /// <summary>
        /// Returns uint3.gbb swizzling (equivalent to uint3.yzz).
        /// </summary>
        [Inline]
        public uint3 gbb =>  uint3(y, z, z);
        
        /// <summary>
        /// Returns uint3.yzzx swizzling.
        /// </summary>
        [Inline]
        public uint4 yzzx =>  uint4(y, z, z, x);
        
        /// <summary>
        /// Returns uint3.gbbr swizzling (equivalent to uint3.yzzx).
        /// </summary>
        [Inline]
        public uint4 gbbr =>  uint4(y, z, z, x);
        
        /// <summary>
        /// Returns uint3.yzzy swizzling.
        /// </summary>
        [Inline]
        public uint4 yzzy =>  uint4(y, z, z, y);
        
        /// <summary>
        /// Returns uint3.gbbg swizzling (equivalent to uint3.yzzy).
        /// </summary>
        [Inline]
        public uint4 gbbg =>  uint4(y, z, z, y);
        
        /// <summary>
        /// Returns uint3.yzzz swizzling.
        /// </summary>
        [Inline]
        public uint4 yzzz =>  uint4(y, z, z, z);
        
        /// <summary>
        /// Returns uint3.gbbb swizzling (equivalent to uint3.yzzz).
        /// </summary>
        [Inline]
        public uint4 gbbb =>  uint4(y, z, z, z);
        
        /// <summary>
        /// Returns uint3.zx swizzling.
        /// </summary>
        [Inline]
        public uint2 zx =>  uint2(z, x);
        
        /// <summary>
        /// Returns uint3.br swizzling (equivalent to uint3.zx).
        /// </summary>
        [Inline]
        public uint2 br =>  uint2(z, x);
        
        /// <summary>
        /// Returns uint3.zxx swizzling.
        /// </summary>
        [Inline]
        public uint3 zxx =>  uint3(z, x, x);
        
        /// <summary>
        /// Returns uint3.brr swizzling (equivalent to uint3.zxx).
        /// </summary>
        [Inline]
        public uint3 brr =>  uint3(z, x, x);
        
        /// <summary>
        /// Returns uint3.zxxx swizzling.
        /// </summary>
        [Inline]
        public uint4 zxxx =>  uint4(z, x, x, x);
        
        /// <summary>
        /// Returns uint3.brrr swizzling (equivalent to uint3.zxxx).
        /// </summary>
        [Inline]
        public uint4 brrr =>  uint4(z, x, x, x);
        
        /// <summary>
        /// Returns uint3.zxxy swizzling.
        /// </summary>
        [Inline]
        public uint4 zxxy =>  uint4(z, x, x, y);
        
        /// <summary>
        /// Returns uint3.brrg swizzling (equivalent to uint3.zxxy).
        /// </summary>
        [Inline]
        public uint4 brrg =>  uint4(z, x, x, y);
        
        /// <summary>
        /// Returns uint3.zxxz swizzling.
        /// </summary>
        [Inline]
        public uint4 zxxz =>  uint4(z, x, x, z);
        
        /// <summary>
        /// Returns uint3.brrb swizzling (equivalent to uint3.zxxz).
        /// </summary>
        [Inline]
        public uint4 brrb =>  uint4(z, x, x, z);
        
        /// <summary>
        /// Returns uint3.zxy swizzling.
        /// </summary>
        [Inline]
        public uint3 zxy =>  uint3(z, x, y);
        
        /// <summary>
        /// Returns uint3.brg swizzling (equivalent to uint3.zxy).
        /// </summary>
        [Inline]
        public uint3 brg =>  uint3(z, x, y);
        
        /// <summary>
        /// Returns uint3.zxyx swizzling.
        /// </summary>
        [Inline]
        public uint4 zxyx =>  uint4(z, x, y, x);
        
        /// <summary>
        /// Returns uint3.brgr swizzling (equivalent to uint3.zxyx).
        /// </summary>
        [Inline]
        public uint4 brgr =>  uint4(z, x, y, x);
        
        /// <summary>
        /// Returns uint3.zxyy swizzling.
        /// </summary>
        [Inline]
        public uint4 zxyy =>  uint4(z, x, y, y);
        
        /// <summary>
        /// Returns uint3.brgg swizzling (equivalent to uint3.zxyy).
        /// </summary>
        [Inline]
        public uint4 brgg =>  uint4(z, x, y, y);
        
        /// <summary>
        /// Returns uint3.zxyz swizzling.
        /// </summary>
        [Inline]
        public uint4 zxyz =>  uint4(z, x, y, z);
        
        /// <summary>
        /// Returns uint3.brgb swizzling (equivalent to uint3.zxyz).
        /// </summary>
        [Inline]
        public uint4 brgb =>  uint4(z, x, y, z);
        
        /// <summary>
        /// Returns uint3.zxz swizzling.
        /// </summary>
        [Inline]
        public uint3 zxz =>  uint3(z, x, z);
        
        /// <summary>
        /// Returns uint3.brb swizzling (equivalent to uint3.zxz).
        /// </summary>
        [Inline]
        public uint3 brb =>  uint3(z, x, z);
        
        /// <summary>
        /// Returns uint3.zxzx swizzling.
        /// </summary>
        [Inline]
        public uint4 zxzx =>  uint4(z, x, z, x);
        
        /// <summary>
        /// Returns uint3.brbr swizzling (equivalent to uint3.zxzx).
        /// </summary>
        [Inline]
        public uint4 brbr =>  uint4(z, x, z, x);
        
        /// <summary>
        /// Returns uint3.zxzy swizzling.
        /// </summary>
        [Inline]
        public uint4 zxzy =>  uint4(z, x, z, y);
        
        /// <summary>
        /// Returns uint3.brbg swizzling (equivalent to uint3.zxzy).
        /// </summary>
        [Inline]
        public uint4 brbg =>  uint4(z, x, z, y);
        
        /// <summary>
        /// Returns uint3.zxzz swizzling.
        /// </summary>
        [Inline]
        public uint4 zxzz =>  uint4(z, x, z, z);
        
        /// <summary>
        /// Returns uint3.brbb swizzling (equivalent to uint3.zxzz).
        /// </summary>
        [Inline]
        public uint4 brbb =>  uint4(z, x, z, z);
        
        /// <summary>
        /// Returns uint3.zy swizzling.
        /// </summary>
        [Inline]
        public uint2 zy =>  uint2(z, y);
        
        /// <summary>
        /// Returns uint3.bg swizzling (equivalent to uint3.zy).
        /// </summary>
        [Inline]
        public uint2 bg =>  uint2(z, y);
        
        /// <summary>
        /// Returns uint3.zyx swizzling.
        /// </summary>
        [Inline]
        public uint3 zyx =>  uint3(z, y, x);
        
        /// <summary>
        /// Returns uint3.bgr swizzling (equivalent to uint3.zyx).
        /// </summary>
        [Inline]
        public uint3 bgr =>  uint3(z, y, x);
        
        /// <summary>
        /// Returns uint3.zyxx swizzling.
        /// </summary>
        [Inline]
        public uint4 zyxx =>  uint4(z, y, x, x);
        
        /// <summary>
        /// Returns uint3.bgrr swizzling (equivalent to uint3.zyxx).
        /// </summary>
        [Inline]
        public uint4 bgrr =>  uint4(z, y, x, x);
        
        /// <summary>
        /// Returns uint3.zyxy swizzling.
        /// </summary>
        [Inline]
        public uint4 zyxy =>  uint4(z, y, x, y);
        
        /// <summary>
        /// Returns uint3.bgrg swizzling (equivalent to uint3.zyxy).
        /// </summary>
        [Inline]
        public uint4 bgrg =>  uint4(z, y, x, y);
        
        /// <summary>
        /// Returns uint3.zyxz swizzling.
        /// </summary>
        [Inline]
        public uint4 zyxz =>  uint4(z, y, x, z);
        
        /// <summary>
        /// Returns uint3.bgrb swizzling (equivalent to uint3.zyxz).
        /// </summary>
        [Inline]
        public uint4 bgrb =>  uint4(z, y, x, z);
        
        /// <summary>
        /// Returns uint3.zyy swizzling.
        /// </summary>
        [Inline]
        public uint3 zyy =>  uint3(z, y, y);
        
        /// <summary>
        /// Returns uint3.bgg swizzling (equivalent to uint3.zyy).
        /// </summary>
        [Inline]
        public uint3 bgg =>  uint3(z, y, y);
        
        /// <summary>
        /// Returns uint3.zyyx swizzling.
        /// </summary>
        [Inline]
        public uint4 zyyx =>  uint4(z, y, y, x);
        
        /// <summary>
        /// Returns uint3.bggr swizzling (equivalent to uint3.zyyx).
        /// </summary>
        [Inline]
        public uint4 bggr =>  uint4(z, y, y, x);
        
        /// <summary>
        /// Returns uint3.zyyy swizzling.
        /// </summary>
        [Inline]
        public uint4 zyyy =>  uint4(z, y, y, y);
        
        /// <summary>
        /// Returns uint3.bggg swizzling (equivalent to uint3.zyyy).
        /// </summary>
        [Inline]
        public uint4 bggg =>  uint4(z, y, y, y);
        
        /// <summary>
        /// Returns uint3.zyyz swizzling.
        /// </summary>
        [Inline]
        public uint4 zyyz =>  uint4(z, y, y, z);
        
        /// <summary>
        /// Returns uint3.bggb swizzling (equivalent to uint3.zyyz).
        /// </summary>
        [Inline]
        public uint4 bggb =>  uint4(z, y, y, z);
        
        /// <summary>
        /// Returns uint3.zyz swizzling.
        /// </summary>
        [Inline]
        public uint3 zyz =>  uint3(z, y, z);
        
        /// <summary>
        /// Returns uint3.bgb swizzling (equivalent to uint3.zyz).
        /// </summary>
        [Inline]
        public uint3 bgb =>  uint3(z, y, z);
        
        /// <summary>
        /// Returns uint3.zyzx swizzling.
        /// </summary>
        [Inline]
        public uint4 zyzx =>  uint4(z, y, z, x);
        
        /// <summary>
        /// Returns uint3.bgbr swizzling (equivalent to uint3.zyzx).
        /// </summary>
        [Inline]
        public uint4 bgbr =>  uint4(z, y, z, x);
        
        /// <summary>
        /// Returns uint3.zyzy swizzling.
        /// </summary>
        [Inline]
        public uint4 zyzy =>  uint4(z, y, z, y);
        
        /// <summary>
        /// Returns uint3.bgbg swizzling (equivalent to uint3.zyzy).
        /// </summary>
        [Inline]
        public uint4 bgbg =>  uint4(z, y, z, y);
        
        /// <summary>
        /// Returns uint3.zyzz swizzling.
        /// </summary>
        [Inline]
        public uint4 zyzz =>  uint4(z, y, z, z);
        
        /// <summary>
        /// Returns uint3.bgbb swizzling (equivalent to uint3.zyzz).
        /// </summary>
        [Inline]
        public uint4 bgbb =>  uint4(z, y, z, z);
        
        /// <summary>
        /// Returns uint3.zz swizzling.
        /// </summary>
        [Inline]
        public uint2 zz =>  uint2(z, z);
        
        /// <summary>
        /// Returns uint3.bb swizzling (equivalent to uint3.zz).
        /// </summary>
        [Inline]
        public uint2 bb =>  uint2(z, z);
        
        /// <summary>
        /// Returns uint3.zzx swizzling.
        /// </summary>
        [Inline]
        public uint3 zzx =>  uint3(z, z, x);
        
        /// <summary>
        /// Returns uint3.bbr swizzling (equivalent to uint3.zzx).
        /// </summary>
        [Inline]
        public uint3 bbr =>  uint3(z, z, x);
        
        /// <summary>
        /// Returns uint3.zzxx swizzling.
        /// </summary>
        [Inline]
        public uint4 zzxx =>  uint4(z, z, x, x);
        
        /// <summary>
        /// Returns uint3.bbrr swizzling (equivalent to uint3.zzxx).
        /// </summary>
        [Inline]
        public uint4 bbrr =>  uint4(z, z, x, x);
        
        /// <summary>
        /// Returns uint3.zzxy swizzling.
        /// </summary>
        [Inline]
        public uint4 zzxy =>  uint4(z, z, x, y);
        
        /// <summary>
        /// Returns uint3.bbrg swizzling (equivalent to uint3.zzxy).
        /// </summary>
        [Inline]
        public uint4 bbrg =>  uint4(z, z, x, y);
        
        /// <summary>
        /// Returns uint3.zzxz swizzling.
        /// </summary>
        [Inline]
        public uint4 zzxz =>  uint4(z, z, x, z);
        
        /// <summary>
        /// Returns uint3.bbrb swizzling (equivalent to uint3.zzxz).
        /// </summary>
        [Inline]
        public uint4 bbrb =>  uint4(z, z, x, z);
        
        /// <summary>
        /// Returns uint3.zzy swizzling.
        /// </summary>
        [Inline]
        public uint3 zzy =>  uint3(z, z, y);
        
        /// <summary>
        /// Returns uint3.bbg swizzling (equivalent to uint3.zzy).
        /// </summary>
        [Inline]
        public uint3 bbg =>  uint3(z, z, y);
        
        /// <summary>
        /// Returns uint3.zzyx swizzling.
        /// </summary>
        [Inline]
        public uint4 zzyx =>  uint4(z, z, y, x);
        
        /// <summary>
        /// Returns uint3.bbgr swizzling (equivalent to uint3.zzyx).
        /// </summary>
        [Inline]
        public uint4 bbgr =>  uint4(z, z, y, x);
        
        /// <summary>
        /// Returns uint3.zzyy swizzling.
        /// </summary>
        [Inline]
        public uint4 zzyy =>  uint4(z, z, y, y);
        
        /// <summary>
        /// Returns uint3.bbgg swizzling (equivalent to uint3.zzyy).
        /// </summary>
        [Inline]
        public uint4 bbgg =>  uint4(z, z, y, y);
        
        /// <summary>
        /// Returns uint3.zzyz swizzling.
        /// </summary>
        [Inline]
        public uint4 zzyz =>  uint4(z, z, y, z);
        
        /// <summary>
        /// Returns uint3.bbgb swizzling (equivalent to uint3.zzyz).
        /// </summary>
        [Inline]
        public uint4 bbgb =>  uint4(z, z, y, z);
        
        /// <summary>
        /// Returns uint3.zzz swizzling.
        /// </summary>
        [Inline]
        public uint3 zzz =>  uint3(z, z, z);
        
        /// <summary>
        /// Returns uint3.bbb swizzling (equivalent to uint3.zzz).
        /// </summary>
        [Inline]
        public uint3 bbb =>  uint3(z, z, z);
        
        /// <summary>
        /// Returns uint3.zzzx swizzling.
        /// </summary>
        [Inline]
        public uint4 zzzx =>  uint4(z, z, z, x);
        
        /// <summary>
        /// Returns uint3.bbbr swizzling (equivalent to uint3.zzzx).
        /// </summary>
        [Inline]
        public uint4 bbbr =>  uint4(z, z, z, x);
        
        /// <summary>
        /// Returns uint3.zzzy swizzling.
        /// </summary>
        [Inline]
        public uint4 zzzy =>  uint4(z, z, z, y);
        
        /// <summary>
        /// Returns uint3.bbbg swizzling (equivalent to uint3.zzzy).
        /// </summary>
        [Inline]
        public uint4 bbbg =>  uint4(z, z, z, y);
        
        /// <summary>
        /// Returns uint3.zzzz swizzling.
        /// </summary>
        [Inline]
        public uint4 zzzz =>  uint4(z, z, z, z);
        
        /// <summary>
        /// Returns uint3.bbbb swizzling (equivalent to uint3.zzzz).
        /// </summary>
        [Inline]
        public uint4 bbbb =>  uint4(z, z, z, z);

        //#endregion

    }
}
