using System;
namespace Atma
{
    
    /// <summary>
    /// Temporary vector of type float with 3 components, used for implementing swizzling for float3.
    /// </summary>
    public struct swizzle_float3
    {

        //#region Fields
        
        /// <summary>
        /// x-component
        /// </summary>
        private readonly float x;
        
        /// <summary>
        /// y-component
        /// </summary>
        private readonly float y;
        
        /// <summary>
        /// z-component
        /// </summary>
        private readonly float z;

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Returns float3.xx swizzling.
        /// </summary>
        [Inline]
        public float2 xx =>  float2(x, x);
        
        /// <summary>
        /// Returns float3.rr swizzling (equivalent to float3.xx).
        /// </summary>
        [Inline]
        public float2 rr =>  float2(x, x);
        
        /// <summary>
        /// Returns float3.xxx swizzling.
        /// </summary>
        [Inline]
        public float3 xxx =>  float3(x, x, x);
        
        /// <summary>
        /// Returns float3.rrr swizzling (equivalent to float3.xxx).
        /// </summary>
        [Inline]
        public float3 rrr =>  float3(x, x, x);
        
        /// <summary>
        /// Returns float3.xxxx swizzling.
        /// </summary>
        [Inline]
        public float4 xxxx =>  float4(x, x, x, x);
        
        /// <summary>
        /// Returns float3.rrrr swizzling (equivalent to float3.xxxx).
        /// </summary>
        [Inline]
        public float4 rrrr =>  float4(x, x, x, x);
        
        /// <summary>
        /// Returns float3.xxxy swizzling.
        /// </summary>
        [Inline]
        public float4 xxxy =>  float4(x, x, x, y);
        
        /// <summary>
        /// Returns float3.rrrg swizzling (equivalent to float3.xxxy).
        /// </summary>
        [Inline]
        public float4 rrrg =>  float4(x, x, x, y);
        
        /// <summary>
        /// Returns float3.xxxz swizzling.
        /// </summary>
        [Inline]
        public float4 xxxz =>  float4(x, x, x, z);
        
        /// <summary>
        /// Returns float3.rrrb swizzling (equivalent to float3.xxxz).
        /// </summary>
        [Inline]
        public float4 rrrb =>  float4(x, x, x, z);
        
        /// <summary>
        /// Returns float3.xxy swizzling.
        /// </summary>
        [Inline]
        public float3 xxy =>  float3(x, x, y);
        
        /// <summary>
        /// Returns float3.rrg swizzling (equivalent to float3.xxy).
        /// </summary>
        [Inline]
        public float3 rrg =>  float3(x, x, y);
        
        /// <summary>
        /// Returns float3.xxyx swizzling.
        /// </summary>
        [Inline]
        public float4 xxyx =>  float4(x, x, y, x);
        
        /// <summary>
        /// Returns float3.rrgr swizzling (equivalent to float3.xxyx).
        /// </summary>
        [Inline]
        public float4 rrgr =>  float4(x, x, y, x);
        
        /// <summary>
        /// Returns float3.xxyy swizzling.
        /// </summary>
        [Inline]
        public float4 xxyy =>  float4(x, x, y, y);
        
        /// <summary>
        /// Returns float3.rrgg swizzling (equivalent to float3.xxyy).
        /// </summary>
        [Inline]
        public float4 rrgg =>  float4(x, x, y, y);
        
        /// <summary>
        /// Returns float3.xxyz swizzling.
        /// </summary>
        [Inline]
        public float4 xxyz =>  float4(x, x, y, z);
        
        /// <summary>
        /// Returns float3.rrgb swizzling (equivalent to float3.xxyz).
        /// </summary>
        [Inline]
        public float4 rrgb =>  float4(x, x, y, z);
        
        /// <summary>
        /// Returns float3.xxz swizzling.
        /// </summary>
        [Inline]
        public float3 xxz =>  float3(x, x, z);
        
        /// <summary>
        /// Returns float3.rrb swizzling (equivalent to float3.xxz).
        /// </summary>
        [Inline]
        public float3 rrb =>  float3(x, x, z);
        
        /// <summary>
        /// Returns float3.xxzx swizzling.
        /// </summary>
        [Inline]
        public float4 xxzx =>  float4(x, x, z, x);
        
        /// <summary>
        /// Returns float3.rrbr swizzling (equivalent to float3.xxzx).
        /// </summary>
        [Inline]
        public float4 rrbr =>  float4(x, x, z, x);
        
        /// <summary>
        /// Returns float3.xxzy swizzling.
        /// </summary>
        [Inline]
        public float4 xxzy =>  float4(x, x, z, y);
        
        /// <summary>
        /// Returns float3.rrbg swizzling (equivalent to float3.xxzy).
        /// </summary>
        [Inline]
        public float4 rrbg =>  float4(x, x, z, y);
        
        /// <summary>
        /// Returns float3.xxzz swizzling.
        /// </summary>
        [Inline]
        public float4 xxzz =>  float4(x, x, z, z);
        
        /// <summary>
        /// Returns float3.rrbb swizzling (equivalent to float3.xxzz).
        /// </summary>
        [Inline]
        public float4 rrbb =>  float4(x, x, z, z);
        
        /// <summary>
        /// Returns float3.xy swizzling.
        /// </summary>
        [Inline]
        public float2 xy =>  float2(x, y);
        
        /// <summary>
        /// Returns float3.rg swizzling (equivalent to float3.xy).
        /// </summary>
        [Inline]
        public float2 rg =>  float2(x, y);
        
        /// <summary>
        /// Returns float3.xyx swizzling.
        /// </summary>
        [Inline]
        public float3 xyx =>  float3(x, y, x);
        
        /// <summary>
        /// Returns float3.rgr swizzling (equivalent to float3.xyx).
        /// </summary>
        [Inline]
        public float3 rgr =>  float3(x, y, x);
        
        /// <summary>
        /// Returns float3.xyxx swizzling.
        /// </summary>
        [Inline]
        public float4 xyxx =>  float4(x, y, x, x);
        
        /// <summary>
        /// Returns float3.rgrr swizzling (equivalent to float3.xyxx).
        /// </summary>
        [Inline]
        public float4 rgrr =>  float4(x, y, x, x);
        
        /// <summary>
        /// Returns float3.xyxy swizzling.
        /// </summary>
        [Inline]
        public float4 xyxy =>  float4(x, y, x, y);
        
        /// <summary>
        /// Returns float3.rgrg swizzling (equivalent to float3.xyxy).
        /// </summary>
        [Inline]
        public float4 rgrg =>  float4(x, y, x, y);
        
        /// <summary>
        /// Returns float3.xyxz swizzling.
        /// </summary>
        [Inline]
        public float4 xyxz =>  float4(x, y, x, z);
        
        /// <summary>
        /// Returns float3.rgrb swizzling (equivalent to float3.xyxz).
        /// </summary>
        [Inline]
        public float4 rgrb =>  float4(x, y, x, z);
        
        /// <summary>
        /// Returns float3.xyy swizzling.
        /// </summary>
        [Inline]
        public float3 xyy =>  float3(x, y, y);
        
        /// <summary>
        /// Returns float3.rgg swizzling (equivalent to float3.xyy).
        /// </summary>
        [Inline]
        public float3 rgg =>  float3(x, y, y);
        
        /// <summary>
        /// Returns float3.xyyx swizzling.
        /// </summary>
        [Inline]
        public float4 xyyx =>  float4(x, y, y, x);
        
        /// <summary>
        /// Returns float3.rggr swizzling (equivalent to float3.xyyx).
        /// </summary>
        [Inline]
        public float4 rggr =>  float4(x, y, y, x);
        
        /// <summary>
        /// Returns float3.xyyy swizzling.
        /// </summary>
        [Inline]
        public float4 xyyy =>  float4(x, y, y, y);
        
        /// <summary>
        /// Returns float3.rggg swizzling (equivalent to float3.xyyy).
        /// </summary>
        [Inline]
        public float4 rggg =>  float4(x, y, y, y);
        
        /// <summary>
        /// Returns float3.xyyz swizzling.
        /// </summary>
        [Inline]
        public float4 xyyz =>  float4(x, y, y, z);
        
        /// <summary>
        /// Returns float3.rggb swizzling (equivalent to float3.xyyz).
        /// </summary>
        [Inline]
        public float4 rggb =>  float4(x, y, y, z);
        
        /// <summary>
        /// Returns float3.xyz swizzling.
        /// </summary>
        [Inline]
        public float3 xyz =>  float3(x, y, z);
        
        /// <summary>
        /// Returns float3.rgb swizzling (equivalent to float3.xyz).
        /// </summary>
        [Inline]
        public float3 rgb =>  float3(x, y, z);
        
        /// <summary>
        /// Returns float3.xyzx swizzling.
        /// </summary>
        [Inline]
        public float4 xyzx =>  float4(x, y, z, x);
        
        /// <summary>
        /// Returns float3.rgbr swizzling (equivalent to float3.xyzx).
        /// </summary>
        [Inline]
        public float4 rgbr =>  float4(x, y, z, x);
        
        /// <summary>
        /// Returns float3.xyzy swizzling.
        /// </summary>
        [Inline]
        public float4 xyzy =>  float4(x, y, z, y);
        
        /// <summary>
        /// Returns float3.rgbg swizzling (equivalent to float3.xyzy).
        /// </summary>
        [Inline]
        public float4 rgbg =>  float4(x, y, z, y);
        
        /// <summary>
        /// Returns float3.xyzz swizzling.
        /// </summary>
        [Inline]
        public float4 xyzz =>  float4(x, y, z, z);
        
        /// <summary>
        /// Returns float3.rgbb swizzling (equivalent to float3.xyzz).
        /// </summary>
        [Inline]
        public float4 rgbb =>  float4(x, y, z, z);
        
        /// <summary>
        /// Returns float3.xz swizzling.
        /// </summary>
        [Inline]
        public float2 xz =>  float2(x, z);
        
        /// <summary>
        /// Returns float3.rb swizzling (equivalent to float3.xz).
        /// </summary>
        [Inline]
        public float2 rb =>  float2(x, z);
        
        /// <summary>
        /// Returns float3.xzx swizzling.
        /// </summary>
        [Inline]
        public float3 xzx =>  float3(x, z, x);
        
        /// <summary>
        /// Returns float3.rbr swizzling (equivalent to float3.xzx).
        /// </summary>
        [Inline]
        public float3 rbr =>  float3(x, z, x);
        
        /// <summary>
        /// Returns float3.xzxx swizzling.
        /// </summary>
        [Inline]
        public float4 xzxx =>  float4(x, z, x, x);
        
        /// <summary>
        /// Returns float3.rbrr swizzling (equivalent to float3.xzxx).
        /// </summary>
        [Inline]
        public float4 rbrr =>  float4(x, z, x, x);
        
        /// <summary>
        /// Returns float3.xzxy swizzling.
        /// </summary>
        [Inline]
        public float4 xzxy =>  float4(x, z, x, y);
        
        /// <summary>
        /// Returns float3.rbrg swizzling (equivalent to float3.xzxy).
        /// </summary>
        [Inline]
        public float4 rbrg =>  float4(x, z, x, y);
        
        /// <summary>
        /// Returns float3.xzxz swizzling.
        /// </summary>
        [Inline]
        public float4 xzxz =>  float4(x, z, x, z);
        
        /// <summary>
        /// Returns float3.rbrb swizzling (equivalent to float3.xzxz).
        /// </summary>
        [Inline]
        public float4 rbrb =>  float4(x, z, x, z);
        
        /// <summary>
        /// Returns float3.xzy swizzling.
        /// </summary>
        [Inline]
        public float3 xzy =>  float3(x, z, y);
        
        /// <summary>
        /// Returns float3.rbg swizzling (equivalent to float3.xzy).
        /// </summary>
        [Inline]
        public float3 rbg =>  float3(x, z, y);
        
        /// <summary>
        /// Returns float3.xzyx swizzling.
        /// </summary>
        [Inline]
        public float4 xzyx =>  float4(x, z, y, x);
        
        /// <summary>
        /// Returns float3.rbgr swizzling (equivalent to float3.xzyx).
        /// </summary>
        [Inline]
        public float4 rbgr =>  float4(x, z, y, x);
        
        /// <summary>
        /// Returns float3.xzyy swizzling.
        /// </summary>
        [Inline]
        public float4 xzyy =>  float4(x, z, y, y);
        
        /// <summary>
        /// Returns float3.rbgg swizzling (equivalent to float3.xzyy).
        /// </summary>
        [Inline]
        public float4 rbgg =>  float4(x, z, y, y);
        
        /// <summary>
        /// Returns float3.xzyz swizzling.
        /// </summary>
        [Inline]
        public float4 xzyz =>  float4(x, z, y, z);
        
        /// <summary>
        /// Returns float3.rbgb swizzling (equivalent to float3.xzyz).
        /// </summary>
        [Inline]
        public float4 rbgb =>  float4(x, z, y, z);
        
        /// <summary>
        /// Returns float3.xzz swizzling.
        /// </summary>
        [Inline]
        public float3 xzz =>  float3(x, z, z);
        
        /// <summary>
        /// Returns float3.rbb swizzling (equivalent to float3.xzz).
        /// </summary>
        [Inline]
        public float3 rbb =>  float3(x, z, z);
        
        /// <summary>
        /// Returns float3.xzzx swizzling.
        /// </summary>
        [Inline]
        public float4 xzzx =>  float4(x, z, z, x);
        
        /// <summary>
        /// Returns float3.rbbr swizzling (equivalent to float3.xzzx).
        /// </summary>
        [Inline]
        public float4 rbbr =>  float4(x, z, z, x);
        
        /// <summary>
        /// Returns float3.xzzy swizzling.
        /// </summary>
        [Inline]
        public float4 xzzy =>  float4(x, z, z, y);
        
        /// <summary>
        /// Returns float3.rbbg swizzling (equivalent to float3.xzzy).
        /// </summary>
        [Inline]
        public float4 rbbg =>  float4(x, z, z, y);
        
        /// <summary>
        /// Returns float3.xzzz swizzling.
        /// </summary>
        [Inline]
        public float4 xzzz =>  float4(x, z, z, z);
        
        /// <summary>
        /// Returns float3.rbbb swizzling (equivalent to float3.xzzz).
        /// </summary>
        [Inline]
        public float4 rbbb =>  float4(x, z, z, z);
        
        /// <summary>
        /// Returns float3.yx swizzling.
        /// </summary>
        [Inline]
        public float2 yx =>  float2(y, x);
        
        /// <summary>
        /// Returns float3.gr swizzling (equivalent to float3.yx).
        /// </summary>
        [Inline]
        public float2 gr =>  float2(y, x);
        
        /// <summary>
        /// Returns float3.yxx swizzling.
        /// </summary>
        [Inline]
        public float3 yxx =>  float3(y, x, x);
        
        /// <summary>
        /// Returns float3.grr swizzling (equivalent to float3.yxx).
        /// </summary>
        [Inline]
        public float3 grr =>  float3(y, x, x);
        
        /// <summary>
        /// Returns float3.yxxx swizzling.
        /// </summary>
        [Inline]
        public float4 yxxx =>  float4(y, x, x, x);
        
        /// <summary>
        /// Returns float3.grrr swizzling (equivalent to float3.yxxx).
        /// </summary>
        [Inline]
        public float4 grrr =>  float4(y, x, x, x);
        
        /// <summary>
        /// Returns float3.yxxy swizzling.
        /// </summary>
        [Inline]
        public float4 yxxy =>  float4(y, x, x, y);
        
        /// <summary>
        /// Returns float3.grrg swizzling (equivalent to float3.yxxy).
        /// </summary>
        [Inline]
        public float4 grrg =>  float4(y, x, x, y);
        
        /// <summary>
        /// Returns float3.yxxz swizzling.
        /// </summary>
        [Inline]
        public float4 yxxz =>  float4(y, x, x, z);
        
        /// <summary>
        /// Returns float3.grrb swizzling (equivalent to float3.yxxz).
        /// </summary>
        [Inline]
        public float4 grrb =>  float4(y, x, x, z);
        
        /// <summary>
        /// Returns float3.yxy swizzling.
        /// </summary>
        [Inline]
        public float3 yxy =>  float3(y, x, y);
        
        /// <summary>
        /// Returns float3.grg swizzling (equivalent to float3.yxy).
        /// </summary>
        [Inline]
        public float3 grg =>  float3(y, x, y);
        
        /// <summary>
        /// Returns float3.yxyx swizzling.
        /// </summary>
        [Inline]
        public float4 yxyx =>  float4(y, x, y, x);
        
        /// <summary>
        /// Returns float3.grgr swizzling (equivalent to float3.yxyx).
        /// </summary>
        [Inline]
        public float4 grgr =>  float4(y, x, y, x);
        
        /// <summary>
        /// Returns float3.yxyy swizzling.
        /// </summary>
        [Inline]
        public float4 yxyy =>  float4(y, x, y, y);
        
        /// <summary>
        /// Returns float3.grgg swizzling (equivalent to float3.yxyy).
        /// </summary>
        [Inline]
        public float4 grgg =>  float4(y, x, y, y);
        
        /// <summary>
        /// Returns float3.yxyz swizzling.
        /// </summary>
        [Inline]
        public float4 yxyz =>  float4(y, x, y, z);
        
        /// <summary>
        /// Returns float3.grgb swizzling (equivalent to float3.yxyz).
        /// </summary>
        [Inline]
        public float4 grgb =>  float4(y, x, y, z);
        
        /// <summary>
        /// Returns float3.yxz swizzling.
        /// </summary>
        [Inline]
        public float3 yxz =>  float3(y, x, z);
        
        /// <summary>
        /// Returns float3.grb swizzling (equivalent to float3.yxz).
        /// </summary>
        [Inline]
        public float3 grb =>  float3(y, x, z);
        
        /// <summary>
        /// Returns float3.yxzx swizzling.
        /// </summary>
        [Inline]
        public float4 yxzx =>  float4(y, x, z, x);
        
        /// <summary>
        /// Returns float3.grbr swizzling (equivalent to float3.yxzx).
        /// </summary>
        [Inline]
        public float4 grbr =>  float4(y, x, z, x);
        
        /// <summary>
        /// Returns float3.yxzy swizzling.
        /// </summary>
        [Inline]
        public float4 yxzy =>  float4(y, x, z, y);
        
        /// <summary>
        /// Returns float3.grbg swizzling (equivalent to float3.yxzy).
        /// </summary>
        [Inline]
        public float4 grbg =>  float4(y, x, z, y);
        
        /// <summary>
        /// Returns float3.yxzz swizzling.
        /// </summary>
        [Inline]
        public float4 yxzz =>  float4(y, x, z, z);
        
        /// <summary>
        /// Returns float3.grbb swizzling (equivalent to float3.yxzz).
        /// </summary>
        [Inline]
        public float4 grbb =>  float4(y, x, z, z);
        
        /// <summary>
        /// Returns float3.yy swizzling.
        /// </summary>
        [Inline]
        public float2 yy =>  float2(y, y);
        
        /// <summary>
        /// Returns float3.gg swizzling (equivalent to float3.yy).
        /// </summary>
        [Inline]
        public float2 gg =>  float2(y, y);
        
        /// <summary>
        /// Returns float3.yyx swizzling.
        /// </summary>
        [Inline]
        public float3 yyx =>  float3(y, y, x);
        
        /// <summary>
        /// Returns float3.ggr swizzling (equivalent to float3.yyx).
        /// </summary>
        [Inline]
        public float3 ggr =>  float3(y, y, x);
        
        /// <summary>
        /// Returns float3.yyxx swizzling.
        /// </summary>
        [Inline]
        public float4 yyxx =>  float4(y, y, x, x);
        
        /// <summary>
        /// Returns float3.ggrr swizzling (equivalent to float3.yyxx).
        /// </summary>
        [Inline]
        public float4 ggrr =>  float4(y, y, x, x);
        
        /// <summary>
        /// Returns float3.yyxy swizzling.
        /// </summary>
        [Inline]
        public float4 yyxy =>  float4(y, y, x, y);
        
        /// <summary>
        /// Returns float3.ggrg swizzling (equivalent to float3.yyxy).
        /// </summary>
        [Inline]
        public float4 ggrg =>  float4(y, y, x, y);
        
        /// <summary>
        /// Returns float3.yyxz swizzling.
        /// </summary>
        [Inline]
        public float4 yyxz =>  float4(y, y, x, z);
        
        /// <summary>
        /// Returns float3.ggrb swizzling (equivalent to float3.yyxz).
        /// </summary>
        [Inline]
        public float4 ggrb =>  float4(y, y, x, z);
        
        /// <summary>
        /// Returns float3.yyy swizzling.
        /// </summary>
        [Inline]
        public float3 yyy =>  float3(y, y, y);
        
        /// <summary>
        /// Returns float3.ggg swizzling (equivalent to float3.yyy).
        /// </summary>
        [Inline]
        public float3 ggg =>  float3(y, y, y);
        
        /// <summary>
        /// Returns float3.yyyx swizzling.
        /// </summary>
        [Inline]
        public float4 yyyx =>  float4(y, y, y, x);
        
        /// <summary>
        /// Returns float3.gggr swizzling (equivalent to float3.yyyx).
        /// </summary>
        [Inline]
        public float4 gggr =>  float4(y, y, y, x);
        
        /// <summary>
        /// Returns float3.yyyy swizzling.
        /// </summary>
        [Inline]
        public float4 yyyy =>  float4(y, y, y, y);
        
        /// <summary>
        /// Returns float3.gggg swizzling (equivalent to float3.yyyy).
        /// </summary>
        [Inline]
        public float4 gggg =>  float4(y, y, y, y);
        
        /// <summary>
        /// Returns float3.yyyz swizzling.
        /// </summary>
        [Inline]
        public float4 yyyz =>  float4(y, y, y, z);
        
        /// <summary>
        /// Returns float3.gggb swizzling (equivalent to float3.yyyz).
        /// </summary>
        [Inline]
        public float4 gggb =>  float4(y, y, y, z);
        
        /// <summary>
        /// Returns float3.yyz swizzling.
        /// </summary>
        [Inline]
        public float3 yyz =>  float3(y, y, z);
        
        /// <summary>
        /// Returns float3.ggb swizzling (equivalent to float3.yyz).
        /// </summary>
        [Inline]
        public float3 ggb =>  float3(y, y, z);
        
        /// <summary>
        /// Returns float3.yyzx swizzling.
        /// </summary>
        [Inline]
        public float4 yyzx =>  float4(y, y, z, x);
        
        /// <summary>
        /// Returns float3.ggbr swizzling (equivalent to float3.yyzx).
        /// </summary>
        [Inline]
        public float4 ggbr =>  float4(y, y, z, x);
        
        /// <summary>
        /// Returns float3.yyzy swizzling.
        /// </summary>
        [Inline]
        public float4 yyzy =>  float4(y, y, z, y);
        
        /// <summary>
        /// Returns float3.ggbg swizzling (equivalent to float3.yyzy).
        /// </summary>
        [Inline]
        public float4 ggbg =>  float4(y, y, z, y);
        
        /// <summary>
        /// Returns float3.yyzz swizzling.
        /// </summary>
        [Inline]
        public float4 yyzz =>  float4(y, y, z, z);
        
        /// <summary>
        /// Returns float3.ggbb swizzling (equivalent to float3.yyzz).
        /// </summary>
        [Inline]
        public float4 ggbb =>  float4(y, y, z, z);
        
        /// <summary>
        /// Returns float3.yz swizzling.
        /// </summary>
        [Inline]
        public float2 yz =>  float2(y, z);
        
        /// <summary>
        /// Returns float3.gb swizzling (equivalent to float3.yz).
        /// </summary>
        [Inline]
        public float2 gb =>  float2(y, z);
        
        /// <summary>
        /// Returns float3.yzx swizzling.
        /// </summary>
        [Inline]
        public float3 yzx =>  float3(y, z, x);
        
        /// <summary>
        /// Returns float3.gbr swizzling (equivalent to float3.yzx).
        /// </summary>
        [Inline]
        public float3 gbr =>  float3(y, z, x);
        
        /// <summary>
        /// Returns float3.yzxx swizzling.
        /// </summary>
        [Inline]
        public float4 yzxx =>  float4(y, z, x, x);
        
        /// <summary>
        /// Returns float3.gbrr swizzling (equivalent to float3.yzxx).
        /// </summary>
        [Inline]
        public float4 gbrr =>  float4(y, z, x, x);
        
        /// <summary>
        /// Returns float3.yzxy swizzling.
        /// </summary>
        [Inline]
        public float4 yzxy =>  float4(y, z, x, y);
        
        /// <summary>
        /// Returns float3.gbrg swizzling (equivalent to float3.yzxy).
        /// </summary>
        [Inline]
        public float4 gbrg =>  float4(y, z, x, y);
        
        /// <summary>
        /// Returns float3.yzxz swizzling.
        /// </summary>
        [Inline]
        public float4 yzxz =>  float4(y, z, x, z);
        
        /// <summary>
        /// Returns float3.gbrb swizzling (equivalent to float3.yzxz).
        /// </summary>
        [Inline]
        public float4 gbrb =>  float4(y, z, x, z);
        
        /// <summary>
        /// Returns float3.yzy swizzling.
        /// </summary>
        [Inline]
        public float3 yzy =>  float3(y, z, y);
        
        /// <summary>
        /// Returns float3.gbg swizzling (equivalent to float3.yzy).
        /// </summary>
        [Inline]
        public float3 gbg =>  float3(y, z, y);
        
        /// <summary>
        /// Returns float3.yzyx swizzling.
        /// </summary>
        [Inline]
        public float4 yzyx =>  float4(y, z, y, x);
        
        /// <summary>
        /// Returns float3.gbgr swizzling (equivalent to float3.yzyx).
        /// </summary>
        [Inline]
        public float4 gbgr =>  float4(y, z, y, x);
        
        /// <summary>
        /// Returns float3.yzyy swizzling.
        /// </summary>
        [Inline]
        public float4 yzyy =>  float4(y, z, y, y);
        
        /// <summary>
        /// Returns float3.gbgg swizzling (equivalent to float3.yzyy).
        /// </summary>
        [Inline]
        public float4 gbgg =>  float4(y, z, y, y);
        
        /// <summary>
        /// Returns float3.yzyz swizzling.
        /// </summary>
        [Inline]
        public float4 yzyz =>  float4(y, z, y, z);
        
        /// <summary>
        /// Returns float3.gbgb swizzling (equivalent to float3.yzyz).
        /// </summary>
        [Inline]
        public float4 gbgb =>  float4(y, z, y, z);
        
        /// <summary>
        /// Returns float3.yzz swizzling.
        /// </summary>
        [Inline]
        public float3 yzz =>  float3(y, z, z);
        
        /// <summary>
        /// Returns float3.gbb swizzling (equivalent to float3.yzz).
        /// </summary>
        [Inline]
        public float3 gbb =>  float3(y, z, z);
        
        /// <summary>
        /// Returns float3.yzzx swizzling.
        /// </summary>
        [Inline]
        public float4 yzzx =>  float4(y, z, z, x);
        
        /// <summary>
        /// Returns float3.gbbr swizzling (equivalent to float3.yzzx).
        /// </summary>
        [Inline]
        public float4 gbbr =>  float4(y, z, z, x);
        
        /// <summary>
        /// Returns float3.yzzy swizzling.
        /// </summary>
        [Inline]
        public float4 yzzy =>  float4(y, z, z, y);
        
        /// <summary>
        /// Returns float3.gbbg swizzling (equivalent to float3.yzzy).
        /// </summary>
        [Inline]
        public float4 gbbg =>  float4(y, z, z, y);
        
        /// <summary>
        /// Returns float3.yzzz swizzling.
        /// </summary>
        [Inline]
        public float4 yzzz =>  float4(y, z, z, z);
        
        /// <summary>
        /// Returns float3.gbbb swizzling (equivalent to float3.yzzz).
        /// </summary>
        [Inline]
        public float4 gbbb =>  float4(y, z, z, z);
        
        /// <summary>
        /// Returns float3.zx swizzling.
        /// </summary>
        [Inline]
        public float2 zx =>  float2(z, x);
        
        /// <summary>
        /// Returns float3.br swizzling (equivalent to float3.zx).
        /// </summary>
        [Inline]
        public float2 br =>  float2(z, x);
        
        /// <summary>
        /// Returns float3.zxx swizzling.
        /// </summary>
        [Inline]
        public float3 zxx =>  float3(z, x, x);
        
        /// <summary>
        /// Returns float3.brr swizzling (equivalent to float3.zxx).
        /// </summary>
        [Inline]
        public float3 brr =>  float3(z, x, x);
        
        /// <summary>
        /// Returns float3.zxxx swizzling.
        /// </summary>
        [Inline]
        public float4 zxxx =>  float4(z, x, x, x);
        
        /// <summary>
        /// Returns float3.brrr swizzling (equivalent to float3.zxxx).
        /// </summary>
        [Inline]
        public float4 brrr =>  float4(z, x, x, x);
        
        /// <summary>
        /// Returns float3.zxxy swizzling.
        /// </summary>
        [Inline]
        public float4 zxxy =>  float4(z, x, x, y);
        
        /// <summary>
        /// Returns float3.brrg swizzling (equivalent to float3.zxxy).
        /// </summary>
        [Inline]
        public float4 brrg =>  float4(z, x, x, y);
        
        /// <summary>
        /// Returns float3.zxxz swizzling.
        /// </summary>
        [Inline]
        public float4 zxxz =>  float4(z, x, x, z);
        
        /// <summary>
        /// Returns float3.brrb swizzling (equivalent to float3.zxxz).
        /// </summary>
        [Inline]
        public float4 brrb =>  float4(z, x, x, z);
        
        /// <summary>
        /// Returns float3.zxy swizzling.
        /// </summary>
        [Inline]
        public float3 zxy =>  float3(z, x, y);
        
        /// <summary>
        /// Returns float3.brg swizzling (equivalent to float3.zxy).
        /// </summary>
        [Inline]
        public float3 brg =>  float3(z, x, y);
        
        /// <summary>
        /// Returns float3.zxyx swizzling.
        /// </summary>
        [Inline]
        public float4 zxyx =>  float4(z, x, y, x);
        
        /// <summary>
        /// Returns float3.brgr swizzling (equivalent to float3.zxyx).
        /// </summary>
        [Inline]
        public float4 brgr =>  float4(z, x, y, x);
        
        /// <summary>
        /// Returns float3.zxyy swizzling.
        /// </summary>
        [Inline]
        public float4 zxyy =>  float4(z, x, y, y);
        
        /// <summary>
        /// Returns float3.brgg swizzling (equivalent to float3.zxyy).
        /// </summary>
        [Inline]
        public float4 brgg =>  float4(z, x, y, y);
        
        /// <summary>
        /// Returns float3.zxyz swizzling.
        /// </summary>
        [Inline]
        public float4 zxyz =>  float4(z, x, y, z);
        
        /// <summary>
        /// Returns float3.brgb swizzling (equivalent to float3.zxyz).
        /// </summary>
        [Inline]
        public float4 brgb =>  float4(z, x, y, z);
        
        /// <summary>
        /// Returns float3.zxz swizzling.
        /// </summary>
        [Inline]
        public float3 zxz =>  float3(z, x, z);
        
        /// <summary>
        /// Returns float3.brb swizzling (equivalent to float3.zxz).
        /// </summary>
        [Inline]
        public float3 brb =>  float3(z, x, z);
        
        /// <summary>
        /// Returns float3.zxzx swizzling.
        /// </summary>
        [Inline]
        public float4 zxzx =>  float4(z, x, z, x);
        
        /// <summary>
        /// Returns float3.brbr swizzling (equivalent to float3.zxzx).
        /// </summary>
        [Inline]
        public float4 brbr =>  float4(z, x, z, x);
        
        /// <summary>
        /// Returns float3.zxzy swizzling.
        /// </summary>
        [Inline]
        public float4 zxzy =>  float4(z, x, z, y);
        
        /// <summary>
        /// Returns float3.brbg swizzling (equivalent to float3.zxzy).
        /// </summary>
        [Inline]
        public float4 brbg =>  float4(z, x, z, y);
        
        /// <summary>
        /// Returns float3.zxzz swizzling.
        /// </summary>
        [Inline]
        public float4 zxzz =>  float4(z, x, z, z);
        
        /// <summary>
        /// Returns float3.brbb swizzling (equivalent to float3.zxzz).
        /// </summary>
        [Inline]
        public float4 brbb =>  float4(z, x, z, z);
        
        /// <summary>
        /// Returns float3.zy swizzling.
        /// </summary>
        [Inline]
        public float2 zy =>  float2(z, y);
        
        /// <summary>
        /// Returns float3.bg swizzling (equivalent to float3.zy).
        /// </summary>
        [Inline]
        public float2 bg =>  float2(z, y);
        
        /// <summary>
        /// Returns float3.zyx swizzling.
        /// </summary>
        [Inline]
        public float3 zyx =>  float3(z, y, x);
        
        /// <summary>
        /// Returns float3.bgr swizzling (equivalent to float3.zyx).
        /// </summary>
        [Inline]
        public float3 bgr =>  float3(z, y, x);
        
        /// <summary>
        /// Returns float3.zyxx swizzling.
        /// </summary>
        [Inline]
        public float4 zyxx =>  float4(z, y, x, x);
        
        /// <summary>
        /// Returns float3.bgrr swizzling (equivalent to float3.zyxx).
        /// </summary>
        [Inline]
        public float4 bgrr =>  float4(z, y, x, x);
        
        /// <summary>
        /// Returns float3.zyxy swizzling.
        /// </summary>
        [Inline]
        public float4 zyxy =>  float4(z, y, x, y);
        
        /// <summary>
        /// Returns float3.bgrg swizzling (equivalent to float3.zyxy).
        /// </summary>
        [Inline]
        public float4 bgrg =>  float4(z, y, x, y);
        
        /// <summary>
        /// Returns float3.zyxz swizzling.
        /// </summary>
        [Inline]
        public float4 zyxz =>  float4(z, y, x, z);
        
        /// <summary>
        /// Returns float3.bgrb swizzling (equivalent to float3.zyxz).
        /// </summary>
        [Inline]
        public float4 bgrb =>  float4(z, y, x, z);
        
        /// <summary>
        /// Returns float3.zyy swizzling.
        /// </summary>
        [Inline]
        public float3 zyy =>  float3(z, y, y);
        
        /// <summary>
        /// Returns float3.bgg swizzling (equivalent to float3.zyy).
        /// </summary>
        [Inline]
        public float3 bgg =>  float3(z, y, y);
        
        /// <summary>
        /// Returns float3.zyyx swizzling.
        /// </summary>
        [Inline]
        public float4 zyyx =>  float4(z, y, y, x);
        
        /// <summary>
        /// Returns float3.bggr swizzling (equivalent to float3.zyyx).
        /// </summary>
        [Inline]
        public float4 bggr =>  float4(z, y, y, x);
        
        /// <summary>
        /// Returns float3.zyyy swizzling.
        /// </summary>
        [Inline]
        public float4 zyyy =>  float4(z, y, y, y);
        
        /// <summary>
        /// Returns float3.bggg swizzling (equivalent to float3.zyyy).
        /// </summary>
        [Inline]
        public float4 bggg =>  float4(z, y, y, y);
        
        /// <summary>
        /// Returns float3.zyyz swizzling.
        /// </summary>
        [Inline]
        public float4 zyyz =>  float4(z, y, y, z);
        
        /// <summary>
        /// Returns float3.bggb swizzling (equivalent to float3.zyyz).
        /// </summary>
        [Inline]
        public float4 bggb =>  float4(z, y, y, z);
        
        /// <summary>
        /// Returns float3.zyz swizzling.
        /// </summary>
        [Inline]
        public float3 zyz =>  float3(z, y, z);
        
        /// <summary>
        /// Returns float3.bgb swizzling (equivalent to float3.zyz).
        /// </summary>
        [Inline]
        public float3 bgb =>  float3(z, y, z);
        
        /// <summary>
        /// Returns float3.zyzx swizzling.
        /// </summary>
        [Inline]
        public float4 zyzx =>  float4(z, y, z, x);
        
        /// <summary>
        /// Returns float3.bgbr swizzling (equivalent to float3.zyzx).
        /// </summary>
        [Inline]
        public float4 bgbr =>  float4(z, y, z, x);
        
        /// <summary>
        /// Returns float3.zyzy swizzling.
        /// </summary>
        [Inline]
        public float4 zyzy =>  float4(z, y, z, y);
        
        /// <summary>
        /// Returns float3.bgbg swizzling (equivalent to float3.zyzy).
        /// </summary>
        [Inline]
        public float4 bgbg =>  float4(z, y, z, y);
        
        /// <summary>
        /// Returns float3.zyzz swizzling.
        /// </summary>
        [Inline]
        public float4 zyzz =>  float4(z, y, z, z);
        
        /// <summary>
        /// Returns float3.bgbb swizzling (equivalent to float3.zyzz).
        /// </summary>
        [Inline]
        public float4 bgbb =>  float4(z, y, z, z);
        
        /// <summary>
        /// Returns float3.zz swizzling.
        /// </summary>
        [Inline]
        public float2 zz =>  float2(z, z);
        
        /// <summary>
        /// Returns float3.bb swizzling (equivalent to float3.zz).
        /// </summary>
        [Inline]
        public float2 bb =>  float2(z, z);
        
        /// <summary>
        /// Returns float3.zzx swizzling.
        /// </summary>
        [Inline]
        public float3 zzx =>  float3(z, z, x);
        
        /// <summary>
        /// Returns float3.bbr swizzling (equivalent to float3.zzx).
        /// </summary>
        [Inline]
        public float3 bbr =>  float3(z, z, x);
        
        /// <summary>
        /// Returns float3.zzxx swizzling.
        /// </summary>
        [Inline]
        public float4 zzxx =>  float4(z, z, x, x);
        
        /// <summary>
        /// Returns float3.bbrr swizzling (equivalent to float3.zzxx).
        /// </summary>
        [Inline]
        public float4 bbrr =>  float4(z, z, x, x);
        
        /// <summary>
        /// Returns float3.zzxy swizzling.
        /// </summary>
        [Inline]
        public float4 zzxy =>  float4(z, z, x, y);
        
        /// <summary>
        /// Returns float3.bbrg swizzling (equivalent to float3.zzxy).
        /// </summary>
        [Inline]
        public float4 bbrg =>  float4(z, z, x, y);
        
        /// <summary>
        /// Returns float3.zzxz swizzling.
        /// </summary>
        [Inline]
        public float4 zzxz =>  float4(z, z, x, z);
        
        /// <summary>
        /// Returns float3.bbrb swizzling (equivalent to float3.zzxz).
        /// </summary>
        [Inline]
        public float4 bbrb =>  float4(z, z, x, z);
        
        /// <summary>
        /// Returns float3.zzy swizzling.
        /// </summary>
        [Inline]
        public float3 zzy =>  float3(z, z, y);
        
        /// <summary>
        /// Returns float3.bbg swizzling (equivalent to float3.zzy).
        /// </summary>
        [Inline]
        public float3 bbg =>  float3(z, z, y);
        
        /// <summary>
        /// Returns float3.zzyx swizzling.
        /// </summary>
        [Inline]
        public float4 zzyx =>  float4(z, z, y, x);
        
        /// <summary>
        /// Returns float3.bbgr swizzling (equivalent to float3.zzyx).
        /// </summary>
        [Inline]
        public float4 bbgr =>  float4(z, z, y, x);
        
        /// <summary>
        /// Returns float3.zzyy swizzling.
        /// </summary>
        [Inline]
        public float4 zzyy =>  float4(z, z, y, y);
        
        /// <summary>
        /// Returns float3.bbgg swizzling (equivalent to float3.zzyy).
        /// </summary>
        [Inline]
        public float4 bbgg =>  float4(z, z, y, y);
        
        /// <summary>
        /// Returns float3.zzyz swizzling.
        /// </summary>
        [Inline]
        public float4 zzyz =>  float4(z, z, y, z);
        
        /// <summary>
        /// Returns float3.bbgb swizzling (equivalent to float3.zzyz).
        /// </summary>
        [Inline]
        public float4 bbgb =>  float4(z, z, y, z);
        
        /// <summary>
        /// Returns float3.zzz swizzling.
        /// </summary>
        [Inline]
        public float3 zzz =>  float3(z, z, z);
        
        /// <summary>
        /// Returns float3.bbb swizzling (equivalent to float3.zzz).
        /// </summary>
        [Inline]
        public float3 bbb =>  float3(z, z, z);
        
        /// <summary>
        /// Returns float3.zzzx swizzling.
        /// </summary>
        [Inline]
        public float4 zzzx =>  float4(z, z, z, x);
        
        /// <summary>
        /// Returns float3.bbbr swizzling (equivalent to float3.zzzx).
        /// </summary>
        [Inline]
        public float4 bbbr =>  float4(z, z, z, x);
        
        /// <summary>
        /// Returns float3.zzzy swizzling.
        /// </summary>
        [Inline]
        public float4 zzzy =>  float4(z, z, z, y);
        
        /// <summary>
        /// Returns float3.bbbg swizzling (equivalent to float3.zzzy).
        /// </summary>
        [Inline]
        public float4 bbbg =>  float4(z, z, z, y);
        
        /// <summary>
        /// Returns float3.zzzz swizzling.
        /// </summary>
        [Inline]
        public float4 zzzz =>  float4(z, z, z, z);
        
        /// <summary>
        /// Returns float3.bbbb swizzling (equivalent to float3.zzzz).
        /// </summary>
        [Inline]
        public float4 bbbb =>  float4(z, z, z, z);

        //#endregion

    }
}
