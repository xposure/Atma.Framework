using System;
namespace Atma
{
    
    /// <summary>
    /// Temporary vector of type float with 4 components, used for implementing swizzling for float4.
    /// </summary>
    public struct swizzle_float4
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
        
        /// <summary>
        /// w-component
        /// </summary>
        private readonly float w;

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Returns float4.xx swizzling.
        /// </summary>
        [Inline]
        public float2 xx =>  float2(x, x);
        
        /// <summary>
        /// Returns float4.rr swizzling (equivalent to float4.xx).
        /// </summary>
        [Inline]
        public float2 rr =>  float2(x, x);
        
        /// <summary>
        /// Returns float4.xxx swizzling.
        /// </summary>
        [Inline]
        public float3 xxx =>  float3(x, x, x);
        
        /// <summary>
        /// Returns float4.rrr swizzling (equivalent to float4.xxx).
        /// </summary>
        [Inline]
        public float3 rrr =>  float3(x, x, x);
        
        /// <summary>
        /// Returns float4.xxxx swizzling.
        /// </summary>
        [Inline]
        public float4 xxxx =>  float4(x, x, x, x);
        
        /// <summary>
        /// Returns float4.rrrr swizzling (equivalent to float4.xxxx).
        /// </summary>
        [Inline]
        public float4 rrrr =>  float4(x, x, x, x);
        
        /// <summary>
        /// Returns float4.xxxy swizzling.
        /// </summary>
        [Inline]
        public float4 xxxy =>  float4(x, x, x, y);
        
        /// <summary>
        /// Returns float4.rrrg swizzling (equivalent to float4.xxxy).
        /// </summary>
        [Inline]
        public float4 rrrg =>  float4(x, x, x, y);
        
        /// <summary>
        /// Returns float4.xxxz swizzling.
        /// </summary>
        [Inline]
        public float4 xxxz =>  float4(x, x, x, z);
        
        /// <summary>
        /// Returns float4.rrrb swizzling (equivalent to float4.xxxz).
        /// </summary>
        [Inline]
        public float4 rrrb =>  float4(x, x, x, z);
        
        /// <summary>
        /// Returns float4.xxxw swizzling.
        /// </summary>
        [Inline]
        public float4 xxxw =>  float4(x, x, x, w);
        
        /// <summary>
        /// Returns float4.rrra swizzling (equivalent to float4.xxxw).
        /// </summary>
        [Inline]
        public float4 rrra =>  float4(x, x, x, w);
        
        /// <summary>
        /// Returns float4.xxy swizzling.
        /// </summary>
        [Inline]
        public float3 xxy =>  float3(x, x, y);
        
        /// <summary>
        /// Returns float4.rrg swizzling (equivalent to float4.xxy).
        /// </summary>
        [Inline]
        public float3 rrg =>  float3(x, x, y);
        
        /// <summary>
        /// Returns float4.xxyx swizzling.
        /// </summary>
        [Inline]
        public float4 xxyx =>  float4(x, x, y, x);
        
        /// <summary>
        /// Returns float4.rrgr swizzling (equivalent to float4.xxyx).
        /// </summary>
        [Inline]
        public float4 rrgr =>  float4(x, x, y, x);
        
        /// <summary>
        /// Returns float4.xxyy swizzling.
        /// </summary>
        [Inline]
        public float4 xxyy =>  float4(x, x, y, y);
        
        /// <summary>
        /// Returns float4.rrgg swizzling (equivalent to float4.xxyy).
        /// </summary>
        [Inline]
        public float4 rrgg =>  float4(x, x, y, y);
        
        /// <summary>
        /// Returns float4.xxyz swizzling.
        /// </summary>
        [Inline]
        public float4 xxyz =>  float4(x, x, y, z);
        
        /// <summary>
        /// Returns float4.rrgb swizzling (equivalent to float4.xxyz).
        /// </summary>
        [Inline]
        public float4 rrgb =>  float4(x, x, y, z);
        
        /// <summary>
        /// Returns float4.xxyw swizzling.
        /// </summary>
        [Inline]
        public float4 xxyw =>  float4(x, x, y, w);
        
        /// <summary>
        /// Returns float4.rrga swizzling (equivalent to float4.xxyw).
        /// </summary>
        [Inline]
        public float4 rrga =>  float4(x, x, y, w);
        
        /// <summary>
        /// Returns float4.xxz swizzling.
        /// </summary>
        [Inline]
        public float3 xxz =>  float3(x, x, z);
        
        /// <summary>
        /// Returns float4.rrb swizzling (equivalent to float4.xxz).
        /// </summary>
        [Inline]
        public float3 rrb =>  float3(x, x, z);
        
        /// <summary>
        /// Returns float4.xxzx swizzling.
        /// </summary>
        [Inline]
        public float4 xxzx =>  float4(x, x, z, x);
        
        /// <summary>
        /// Returns float4.rrbr swizzling (equivalent to float4.xxzx).
        /// </summary>
        [Inline]
        public float4 rrbr =>  float4(x, x, z, x);
        
        /// <summary>
        /// Returns float4.xxzy swizzling.
        /// </summary>
        [Inline]
        public float4 xxzy =>  float4(x, x, z, y);
        
        /// <summary>
        /// Returns float4.rrbg swizzling (equivalent to float4.xxzy).
        /// </summary>
        [Inline]
        public float4 rrbg =>  float4(x, x, z, y);
        
        /// <summary>
        /// Returns float4.xxzz swizzling.
        /// </summary>
        [Inline]
        public float4 xxzz =>  float4(x, x, z, z);
        
        /// <summary>
        /// Returns float4.rrbb swizzling (equivalent to float4.xxzz).
        /// </summary>
        [Inline]
        public float4 rrbb =>  float4(x, x, z, z);
        
        /// <summary>
        /// Returns float4.xxzw swizzling.
        /// </summary>
        [Inline]
        public float4 xxzw =>  float4(x, x, z, w);
        
        /// <summary>
        /// Returns float4.rrba swizzling (equivalent to float4.xxzw).
        /// </summary>
        [Inline]
        public float4 rrba =>  float4(x, x, z, w);
        
        /// <summary>
        /// Returns float4.xxw swizzling.
        /// </summary>
        [Inline]
        public float3 xxw =>  float3(x, x, w);
        
        /// <summary>
        /// Returns float4.rra swizzling (equivalent to float4.xxw).
        /// </summary>
        [Inline]
        public float3 rra =>  float3(x, x, w);
        
        /// <summary>
        /// Returns float4.xxwx swizzling.
        /// </summary>
        [Inline]
        public float4 xxwx =>  float4(x, x, w, x);
        
        /// <summary>
        /// Returns float4.rrar swizzling (equivalent to float4.xxwx).
        /// </summary>
        [Inline]
        public float4 rrar =>  float4(x, x, w, x);
        
        /// <summary>
        /// Returns float4.xxwy swizzling.
        /// </summary>
        [Inline]
        public float4 xxwy =>  float4(x, x, w, y);
        
        /// <summary>
        /// Returns float4.rrag swizzling (equivalent to float4.xxwy).
        /// </summary>
        [Inline]
        public float4 rrag =>  float4(x, x, w, y);
        
        /// <summary>
        /// Returns float4.xxwz swizzling.
        /// </summary>
        [Inline]
        public float4 xxwz =>  float4(x, x, w, z);
        
        /// <summary>
        /// Returns float4.rrab swizzling (equivalent to float4.xxwz).
        /// </summary>
        [Inline]
        public float4 rrab =>  float4(x, x, w, z);
        
        /// <summary>
        /// Returns float4.xxww swizzling.
        /// </summary>
        [Inline]
        public float4 xxww =>  float4(x, x, w, w);
        
        /// <summary>
        /// Returns float4.rraa swizzling (equivalent to float4.xxww).
        /// </summary>
        [Inline]
        public float4 rraa =>  float4(x, x, w, w);
        
        /// <summary>
        /// Returns float4.xy swizzling.
        /// </summary>
        [Inline]
        public float2 xy =>  float2(x, y);
        
        /// <summary>
        /// Returns float4.rg swizzling (equivalent to float4.xy).
        /// </summary>
        [Inline]
        public float2 rg =>  float2(x, y);
        
        /// <summary>
        /// Returns float4.xyx swizzling.
        /// </summary>
        [Inline]
        public float3 xyx =>  float3(x, y, x);
        
        /// <summary>
        /// Returns float4.rgr swizzling (equivalent to float4.xyx).
        /// </summary>
        [Inline]
        public float3 rgr =>  float3(x, y, x);
        
        /// <summary>
        /// Returns float4.xyxx swizzling.
        /// </summary>
        [Inline]
        public float4 xyxx =>  float4(x, y, x, x);
        
        /// <summary>
        /// Returns float4.rgrr swizzling (equivalent to float4.xyxx).
        /// </summary>
        [Inline]
        public float4 rgrr =>  float4(x, y, x, x);
        
        /// <summary>
        /// Returns float4.xyxy swizzling.
        /// </summary>
        [Inline]
        public float4 xyxy =>  float4(x, y, x, y);
        
        /// <summary>
        /// Returns float4.rgrg swizzling (equivalent to float4.xyxy).
        /// </summary>
        [Inline]
        public float4 rgrg =>  float4(x, y, x, y);
        
        /// <summary>
        /// Returns float4.xyxz swizzling.
        /// </summary>
        [Inline]
        public float4 xyxz =>  float4(x, y, x, z);
        
        /// <summary>
        /// Returns float4.rgrb swizzling (equivalent to float4.xyxz).
        /// </summary>
        [Inline]
        public float4 rgrb =>  float4(x, y, x, z);
        
        /// <summary>
        /// Returns float4.xyxw swizzling.
        /// </summary>
        [Inline]
        public float4 xyxw =>  float4(x, y, x, w);
        
        /// <summary>
        /// Returns float4.rgra swizzling (equivalent to float4.xyxw).
        /// </summary>
        [Inline]
        public float4 rgra =>  float4(x, y, x, w);
        
        /// <summary>
        /// Returns float4.xyy swizzling.
        /// </summary>
        [Inline]
        public float3 xyy =>  float3(x, y, y);
        
        /// <summary>
        /// Returns float4.rgg swizzling (equivalent to float4.xyy).
        /// </summary>
        [Inline]
        public float3 rgg =>  float3(x, y, y);
        
        /// <summary>
        /// Returns float4.xyyx swizzling.
        /// </summary>
        [Inline]
        public float4 xyyx =>  float4(x, y, y, x);
        
        /// <summary>
        /// Returns float4.rggr swizzling (equivalent to float4.xyyx).
        /// </summary>
        [Inline]
        public float4 rggr =>  float4(x, y, y, x);
        
        /// <summary>
        /// Returns float4.xyyy swizzling.
        /// </summary>
        [Inline]
        public float4 xyyy =>  float4(x, y, y, y);
        
        /// <summary>
        /// Returns float4.rggg swizzling (equivalent to float4.xyyy).
        /// </summary>
        [Inline]
        public float4 rggg =>  float4(x, y, y, y);
        
        /// <summary>
        /// Returns float4.xyyz swizzling.
        /// </summary>
        [Inline]
        public float4 xyyz =>  float4(x, y, y, z);
        
        /// <summary>
        /// Returns float4.rggb swizzling (equivalent to float4.xyyz).
        /// </summary>
        [Inline]
        public float4 rggb =>  float4(x, y, y, z);
        
        /// <summary>
        /// Returns float4.xyyw swizzling.
        /// </summary>
        [Inline]
        public float4 xyyw =>  float4(x, y, y, w);
        
        /// <summary>
        /// Returns float4.rgga swizzling (equivalent to float4.xyyw).
        /// </summary>
        [Inline]
        public float4 rgga =>  float4(x, y, y, w);
        
        /// <summary>
        /// Returns float4.xyz swizzling.
        /// </summary>
        [Inline]
        public float3 xyz =>  float3(x, y, z);
        
        /// <summary>
        /// Returns float4.rgb swizzling (equivalent to float4.xyz).
        /// </summary>
        [Inline]
        public float3 rgb =>  float3(x, y, z);
        
        /// <summary>
        /// Returns float4.xyzx swizzling.
        /// </summary>
        [Inline]
        public float4 xyzx =>  float4(x, y, z, x);
        
        /// <summary>
        /// Returns float4.rgbr swizzling (equivalent to float4.xyzx).
        /// </summary>
        [Inline]
        public float4 rgbr =>  float4(x, y, z, x);
        
        /// <summary>
        /// Returns float4.xyzy swizzling.
        /// </summary>
        [Inline]
        public float4 xyzy =>  float4(x, y, z, y);
        
        /// <summary>
        /// Returns float4.rgbg swizzling (equivalent to float4.xyzy).
        /// </summary>
        [Inline]
        public float4 rgbg =>  float4(x, y, z, y);
        
        /// <summary>
        /// Returns float4.xyzz swizzling.
        /// </summary>
        [Inline]
        public float4 xyzz =>  float4(x, y, z, z);
        
        /// <summary>
        /// Returns float4.rgbb swizzling (equivalent to float4.xyzz).
        /// </summary>
        [Inline]
        public float4 rgbb =>  float4(x, y, z, z);
        
        /// <summary>
        /// Returns float4.xyzw swizzling.
        /// </summary>
        [Inline]
        public float4 xyzw =>  float4(x, y, z, w);
        
        /// <summary>
        /// Returns float4.rgba swizzling (equivalent to float4.xyzw).
        /// </summary>
        [Inline]
        public float4 rgba =>  float4(x, y, z, w);
        
        /// <summary>
        /// Returns float4.xyw swizzling.
        /// </summary>
        [Inline]
        public float3 xyw =>  float3(x, y, w);
        
        /// <summary>
        /// Returns float4.rga swizzling (equivalent to float4.xyw).
        /// </summary>
        [Inline]
        public float3 rga =>  float3(x, y, w);
        
        /// <summary>
        /// Returns float4.xywx swizzling.
        /// </summary>
        [Inline]
        public float4 xywx =>  float4(x, y, w, x);
        
        /// <summary>
        /// Returns float4.rgar swizzling (equivalent to float4.xywx).
        /// </summary>
        [Inline]
        public float4 rgar =>  float4(x, y, w, x);
        
        /// <summary>
        /// Returns float4.xywy swizzling.
        /// </summary>
        [Inline]
        public float4 xywy =>  float4(x, y, w, y);
        
        /// <summary>
        /// Returns float4.rgag swizzling (equivalent to float4.xywy).
        /// </summary>
        [Inline]
        public float4 rgag =>  float4(x, y, w, y);
        
        /// <summary>
        /// Returns float4.xywz swizzling.
        /// </summary>
        [Inline]
        public float4 xywz =>  float4(x, y, w, z);
        
        /// <summary>
        /// Returns float4.rgab swizzling (equivalent to float4.xywz).
        /// </summary>
        [Inline]
        public float4 rgab =>  float4(x, y, w, z);
        
        /// <summary>
        /// Returns float4.xyww swizzling.
        /// </summary>
        [Inline]
        public float4 xyww =>  float4(x, y, w, w);
        
        /// <summary>
        /// Returns float4.rgaa swizzling (equivalent to float4.xyww).
        /// </summary>
        [Inline]
        public float4 rgaa =>  float4(x, y, w, w);
        
        /// <summary>
        /// Returns float4.xz swizzling.
        /// </summary>
        [Inline]
        public float2 xz =>  float2(x, z);
        
        /// <summary>
        /// Returns float4.rb swizzling (equivalent to float4.xz).
        /// </summary>
        [Inline]
        public float2 rb =>  float2(x, z);
        
        /// <summary>
        /// Returns float4.xzx swizzling.
        /// </summary>
        [Inline]
        public float3 xzx =>  float3(x, z, x);
        
        /// <summary>
        /// Returns float4.rbr swizzling (equivalent to float4.xzx).
        /// </summary>
        [Inline]
        public float3 rbr =>  float3(x, z, x);
        
        /// <summary>
        /// Returns float4.xzxx swizzling.
        /// </summary>
        [Inline]
        public float4 xzxx =>  float4(x, z, x, x);
        
        /// <summary>
        /// Returns float4.rbrr swizzling (equivalent to float4.xzxx).
        /// </summary>
        [Inline]
        public float4 rbrr =>  float4(x, z, x, x);
        
        /// <summary>
        /// Returns float4.xzxy swizzling.
        /// </summary>
        [Inline]
        public float4 xzxy =>  float4(x, z, x, y);
        
        /// <summary>
        /// Returns float4.rbrg swizzling (equivalent to float4.xzxy).
        /// </summary>
        [Inline]
        public float4 rbrg =>  float4(x, z, x, y);
        
        /// <summary>
        /// Returns float4.xzxz swizzling.
        /// </summary>
        [Inline]
        public float4 xzxz =>  float4(x, z, x, z);
        
        /// <summary>
        /// Returns float4.rbrb swizzling (equivalent to float4.xzxz).
        /// </summary>
        [Inline]
        public float4 rbrb =>  float4(x, z, x, z);
        
        /// <summary>
        /// Returns float4.xzxw swizzling.
        /// </summary>
        [Inline]
        public float4 xzxw =>  float4(x, z, x, w);
        
        /// <summary>
        /// Returns float4.rbra swizzling (equivalent to float4.xzxw).
        /// </summary>
        [Inline]
        public float4 rbra =>  float4(x, z, x, w);
        
        /// <summary>
        /// Returns float4.xzy swizzling.
        /// </summary>
        [Inline]
        public float3 xzy =>  float3(x, z, y);
        
        /// <summary>
        /// Returns float4.rbg swizzling (equivalent to float4.xzy).
        /// </summary>
        [Inline]
        public float3 rbg =>  float3(x, z, y);
        
        /// <summary>
        /// Returns float4.xzyx swizzling.
        /// </summary>
        [Inline]
        public float4 xzyx =>  float4(x, z, y, x);
        
        /// <summary>
        /// Returns float4.rbgr swizzling (equivalent to float4.xzyx).
        /// </summary>
        [Inline]
        public float4 rbgr =>  float4(x, z, y, x);
        
        /// <summary>
        /// Returns float4.xzyy swizzling.
        /// </summary>
        [Inline]
        public float4 xzyy =>  float4(x, z, y, y);
        
        /// <summary>
        /// Returns float4.rbgg swizzling (equivalent to float4.xzyy).
        /// </summary>
        [Inline]
        public float4 rbgg =>  float4(x, z, y, y);
        
        /// <summary>
        /// Returns float4.xzyz swizzling.
        /// </summary>
        [Inline]
        public float4 xzyz =>  float4(x, z, y, z);
        
        /// <summary>
        /// Returns float4.rbgb swizzling (equivalent to float4.xzyz).
        /// </summary>
        [Inline]
        public float4 rbgb =>  float4(x, z, y, z);
        
        /// <summary>
        /// Returns float4.xzyw swizzling.
        /// </summary>
        [Inline]
        public float4 xzyw =>  float4(x, z, y, w);
        
        /// <summary>
        /// Returns float4.rbga swizzling (equivalent to float4.xzyw).
        /// </summary>
        [Inline]
        public float4 rbga =>  float4(x, z, y, w);
        
        /// <summary>
        /// Returns float4.xzz swizzling.
        /// </summary>
        [Inline]
        public float3 xzz =>  float3(x, z, z);
        
        /// <summary>
        /// Returns float4.rbb swizzling (equivalent to float4.xzz).
        /// </summary>
        [Inline]
        public float3 rbb =>  float3(x, z, z);
        
        /// <summary>
        /// Returns float4.xzzx swizzling.
        /// </summary>
        [Inline]
        public float4 xzzx =>  float4(x, z, z, x);
        
        /// <summary>
        /// Returns float4.rbbr swizzling (equivalent to float4.xzzx).
        /// </summary>
        [Inline]
        public float4 rbbr =>  float4(x, z, z, x);
        
        /// <summary>
        /// Returns float4.xzzy swizzling.
        /// </summary>
        [Inline]
        public float4 xzzy =>  float4(x, z, z, y);
        
        /// <summary>
        /// Returns float4.rbbg swizzling (equivalent to float4.xzzy).
        /// </summary>
        [Inline]
        public float4 rbbg =>  float4(x, z, z, y);
        
        /// <summary>
        /// Returns float4.xzzz swizzling.
        /// </summary>
        [Inline]
        public float4 xzzz =>  float4(x, z, z, z);
        
        /// <summary>
        /// Returns float4.rbbb swizzling (equivalent to float4.xzzz).
        /// </summary>
        [Inline]
        public float4 rbbb =>  float4(x, z, z, z);
        
        /// <summary>
        /// Returns float4.xzzw swizzling.
        /// </summary>
        [Inline]
        public float4 xzzw =>  float4(x, z, z, w);
        
        /// <summary>
        /// Returns float4.rbba swizzling (equivalent to float4.xzzw).
        /// </summary>
        [Inline]
        public float4 rbba =>  float4(x, z, z, w);
        
        /// <summary>
        /// Returns float4.xzw swizzling.
        /// </summary>
        [Inline]
        public float3 xzw =>  float3(x, z, w);
        
        /// <summary>
        /// Returns float4.rba swizzling (equivalent to float4.xzw).
        /// </summary>
        [Inline]
        public float3 rba =>  float3(x, z, w);
        
        /// <summary>
        /// Returns float4.xzwx swizzling.
        /// </summary>
        [Inline]
        public float4 xzwx =>  float4(x, z, w, x);
        
        /// <summary>
        /// Returns float4.rbar swizzling (equivalent to float4.xzwx).
        /// </summary>
        [Inline]
        public float4 rbar =>  float4(x, z, w, x);
        
        /// <summary>
        /// Returns float4.xzwy swizzling.
        /// </summary>
        [Inline]
        public float4 xzwy =>  float4(x, z, w, y);
        
        /// <summary>
        /// Returns float4.rbag swizzling (equivalent to float4.xzwy).
        /// </summary>
        [Inline]
        public float4 rbag =>  float4(x, z, w, y);
        
        /// <summary>
        /// Returns float4.xzwz swizzling.
        /// </summary>
        [Inline]
        public float4 xzwz =>  float4(x, z, w, z);
        
        /// <summary>
        /// Returns float4.rbab swizzling (equivalent to float4.xzwz).
        /// </summary>
        [Inline]
        public float4 rbab =>  float4(x, z, w, z);
        
        /// <summary>
        /// Returns float4.xzww swizzling.
        /// </summary>
        [Inline]
        public float4 xzww =>  float4(x, z, w, w);
        
        /// <summary>
        /// Returns float4.rbaa swizzling (equivalent to float4.xzww).
        /// </summary>
        [Inline]
        public float4 rbaa =>  float4(x, z, w, w);
        
        /// <summary>
        /// Returns float4.xw swizzling.
        /// </summary>
        [Inline]
        public float2 xw =>  float2(x, w);
        
        /// <summary>
        /// Returns float4.ra swizzling (equivalent to float4.xw).
        /// </summary>
        [Inline]
        public float2 ra =>  float2(x, w);
        
        /// <summary>
        /// Returns float4.xwx swizzling.
        /// </summary>
        [Inline]
        public float3 xwx =>  float3(x, w, x);
        
        /// <summary>
        /// Returns float4.rar swizzling (equivalent to float4.xwx).
        /// </summary>
        [Inline]
        public float3 rar =>  float3(x, w, x);
        
        /// <summary>
        /// Returns float4.xwxx swizzling.
        /// </summary>
        [Inline]
        public float4 xwxx =>  float4(x, w, x, x);
        
        /// <summary>
        /// Returns float4.rarr swizzling (equivalent to float4.xwxx).
        /// </summary>
        [Inline]
        public float4 rarr =>  float4(x, w, x, x);
        
        /// <summary>
        /// Returns float4.xwxy swizzling.
        /// </summary>
        [Inline]
        public float4 xwxy =>  float4(x, w, x, y);
        
        /// <summary>
        /// Returns float4.rarg swizzling (equivalent to float4.xwxy).
        /// </summary>
        [Inline]
        public float4 rarg =>  float4(x, w, x, y);
        
        /// <summary>
        /// Returns float4.xwxz swizzling.
        /// </summary>
        [Inline]
        public float4 xwxz =>  float4(x, w, x, z);
        
        /// <summary>
        /// Returns float4.rarb swizzling (equivalent to float4.xwxz).
        /// </summary>
        [Inline]
        public float4 rarb =>  float4(x, w, x, z);
        
        /// <summary>
        /// Returns float4.xwxw swizzling.
        /// </summary>
        [Inline]
        public float4 xwxw =>  float4(x, w, x, w);
        
        /// <summary>
        /// Returns float4.rara swizzling (equivalent to float4.xwxw).
        /// </summary>
        [Inline]
        public float4 rara =>  float4(x, w, x, w);
        
        /// <summary>
        /// Returns float4.xwy swizzling.
        /// </summary>
        [Inline]
        public float3 xwy =>  float3(x, w, y);
        
        /// <summary>
        /// Returns float4.rag swizzling (equivalent to float4.xwy).
        /// </summary>
        [Inline]
        public float3 rag =>  float3(x, w, y);
        
        /// <summary>
        /// Returns float4.xwyx swizzling.
        /// </summary>
        [Inline]
        public float4 xwyx =>  float4(x, w, y, x);
        
        /// <summary>
        /// Returns float4.ragr swizzling (equivalent to float4.xwyx).
        /// </summary>
        [Inline]
        public float4 ragr =>  float4(x, w, y, x);
        
        /// <summary>
        /// Returns float4.xwyy swizzling.
        /// </summary>
        [Inline]
        public float4 xwyy =>  float4(x, w, y, y);
        
        /// <summary>
        /// Returns float4.ragg swizzling (equivalent to float4.xwyy).
        /// </summary>
        [Inline]
        public float4 ragg =>  float4(x, w, y, y);
        
        /// <summary>
        /// Returns float4.xwyz swizzling.
        /// </summary>
        [Inline]
        public float4 xwyz =>  float4(x, w, y, z);
        
        /// <summary>
        /// Returns float4.ragb swizzling (equivalent to float4.xwyz).
        /// </summary>
        [Inline]
        public float4 ragb =>  float4(x, w, y, z);
        
        /// <summary>
        /// Returns float4.xwyw swizzling.
        /// </summary>
        [Inline]
        public float4 xwyw =>  float4(x, w, y, w);
        
        /// <summary>
        /// Returns float4.raga swizzling (equivalent to float4.xwyw).
        /// </summary>
        [Inline]
        public float4 raga =>  float4(x, w, y, w);
        
        /// <summary>
        /// Returns float4.xwz swizzling.
        /// </summary>
        [Inline]
        public float3 xwz =>  float3(x, w, z);
        
        /// <summary>
        /// Returns float4.rab swizzling (equivalent to float4.xwz).
        /// </summary>
        [Inline]
        public float3 rab =>  float3(x, w, z);
        
        /// <summary>
        /// Returns float4.xwzx swizzling.
        /// </summary>
        [Inline]
        public float4 xwzx =>  float4(x, w, z, x);
        
        /// <summary>
        /// Returns float4.rabr swizzling (equivalent to float4.xwzx).
        /// </summary>
        [Inline]
        public float4 rabr =>  float4(x, w, z, x);
        
        /// <summary>
        /// Returns float4.xwzy swizzling.
        /// </summary>
        [Inline]
        public float4 xwzy =>  float4(x, w, z, y);
        
        /// <summary>
        /// Returns float4.rabg swizzling (equivalent to float4.xwzy).
        /// </summary>
        [Inline]
        public float4 rabg =>  float4(x, w, z, y);
        
        /// <summary>
        /// Returns float4.xwzz swizzling.
        /// </summary>
        [Inline]
        public float4 xwzz =>  float4(x, w, z, z);
        
        /// <summary>
        /// Returns float4.rabb swizzling (equivalent to float4.xwzz).
        /// </summary>
        [Inline]
        public float4 rabb =>  float4(x, w, z, z);
        
        /// <summary>
        /// Returns float4.xwzw swizzling.
        /// </summary>
        [Inline]
        public float4 xwzw =>  float4(x, w, z, w);
        
        /// <summary>
        /// Returns float4.raba swizzling (equivalent to float4.xwzw).
        /// </summary>
        [Inline]
        public float4 raba =>  float4(x, w, z, w);
        
        /// <summary>
        /// Returns float4.xww swizzling.
        /// </summary>
        [Inline]
        public float3 xww =>  float3(x, w, w);
        
        /// <summary>
        /// Returns float4.raa swizzling (equivalent to float4.xww).
        /// </summary>
        [Inline]
        public float3 raa =>  float3(x, w, w);
        
        /// <summary>
        /// Returns float4.xwwx swizzling.
        /// </summary>
        [Inline]
        public float4 xwwx =>  float4(x, w, w, x);
        
        /// <summary>
        /// Returns float4.raar swizzling (equivalent to float4.xwwx).
        /// </summary>
        [Inline]
        public float4 raar =>  float4(x, w, w, x);
        
        /// <summary>
        /// Returns float4.xwwy swizzling.
        /// </summary>
        [Inline]
        public float4 xwwy =>  float4(x, w, w, y);
        
        /// <summary>
        /// Returns float4.raag swizzling (equivalent to float4.xwwy).
        /// </summary>
        [Inline]
        public float4 raag =>  float4(x, w, w, y);
        
        /// <summary>
        /// Returns float4.xwwz swizzling.
        /// </summary>
        [Inline]
        public float4 xwwz =>  float4(x, w, w, z);
        
        /// <summary>
        /// Returns float4.raab swizzling (equivalent to float4.xwwz).
        /// </summary>
        [Inline]
        public float4 raab =>  float4(x, w, w, z);
        
        /// <summary>
        /// Returns float4.xwww swizzling.
        /// </summary>
        [Inline]
        public float4 xwww =>  float4(x, w, w, w);
        
        /// <summary>
        /// Returns float4.raaa swizzling (equivalent to float4.xwww).
        /// </summary>
        [Inline]
        public float4 raaa =>  float4(x, w, w, w);
        
        /// <summary>
        /// Returns float4.yx swizzling.
        /// </summary>
        [Inline]
        public float2 yx =>  float2(y, x);
        
        /// <summary>
        /// Returns float4.gr swizzling (equivalent to float4.yx).
        /// </summary>
        [Inline]
        public float2 gr =>  float2(y, x);
        
        /// <summary>
        /// Returns float4.yxx swizzling.
        /// </summary>
        [Inline]
        public float3 yxx =>  float3(y, x, x);
        
        /// <summary>
        /// Returns float4.grr swizzling (equivalent to float4.yxx).
        /// </summary>
        [Inline]
        public float3 grr =>  float3(y, x, x);
        
        /// <summary>
        /// Returns float4.yxxx swizzling.
        /// </summary>
        [Inline]
        public float4 yxxx =>  float4(y, x, x, x);
        
        /// <summary>
        /// Returns float4.grrr swizzling (equivalent to float4.yxxx).
        /// </summary>
        [Inline]
        public float4 grrr =>  float4(y, x, x, x);
        
        /// <summary>
        /// Returns float4.yxxy swizzling.
        /// </summary>
        [Inline]
        public float4 yxxy =>  float4(y, x, x, y);
        
        /// <summary>
        /// Returns float4.grrg swizzling (equivalent to float4.yxxy).
        /// </summary>
        [Inline]
        public float4 grrg =>  float4(y, x, x, y);
        
        /// <summary>
        /// Returns float4.yxxz swizzling.
        /// </summary>
        [Inline]
        public float4 yxxz =>  float4(y, x, x, z);
        
        /// <summary>
        /// Returns float4.grrb swizzling (equivalent to float4.yxxz).
        /// </summary>
        [Inline]
        public float4 grrb =>  float4(y, x, x, z);
        
        /// <summary>
        /// Returns float4.yxxw swizzling.
        /// </summary>
        [Inline]
        public float4 yxxw =>  float4(y, x, x, w);
        
        /// <summary>
        /// Returns float4.grra swizzling (equivalent to float4.yxxw).
        /// </summary>
        [Inline]
        public float4 grra =>  float4(y, x, x, w);
        
        /// <summary>
        /// Returns float4.yxy swizzling.
        /// </summary>
        [Inline]
        public float3 yxy =>  float3(y, x, y);
        
        /// <summary>
        /// Returns float4.grg swizzling (equivalent to float4.yxy).
        /// </summary>
        [Inline]
        public float3 grg =>  float3(y, x, y);
        
        /// <summary>
        /// Returns float4.yxyx swizzling.
        /// </summary>
        [Inline]
        public float4 yxyx =>  float4(y, x, y, x);
        
        /// <summary>
        /// Returns float4.grgr swizzling (equivalent to float4.yxyx).
        /// </summary>
        [Inline]
        public float4 grgr =>  float4(y, x, y, x);
        
        /// <summary>
        /// Returns float4.yxyy swizzling.
        /// </summary>
        [Inline]
        public float4 yxyy =>  float4(y, x, y, y);
        
        /// <summary>
        /// Returns float4.grgg swizzling (equivalent to float4.yxyy).
        /// </summary>
        [Inline]
        public float4 grgg =>  float4(y, x, y, y);
        
        /// <summary>
        /// Returns float4.yxyz swizzling.
        /// </summary>
        [Inline]
        public float4 yxyz =>  float4(y, x, y, z);
        
        /// <summary>
        /// Returns float4.grgb swizzling (equivalent to float4.yxyz).
        /// </summary>
        [Inline]
        public float4 grgb =>  float4(y, x, y, z);
        
        /// <summary>
        /// Returns float4.yxyw swizzling.
        /// </summary>
        [Inline]
        public float4 yxyw =>  float4(y, x, y, w);
        
        /// <summary>
        /// Returns float4.grga swizzling (equivalent to float4.yxyw).
        /// </summary>
        [Inline]
        public float4 grga =>  float4(y, x, y, w);
        
        /// <summary>
        /// Returns float4.yxz swizzling.
        /// </summary>
        [Inline]
        public float3 yxz =>  float3(y, x, z);
        
        /// <summary>
        /// Returns float4.grb swizzling (equivalent to float4.yxz).
        /// </summary>
        [Inline]
        public float3 grb =>  float3(y, x, z);
        
        /// <summary>
        /// Returns float4.yxzx swizzling.
        /// </summary>
        [Inline]
        public float4 yxzx =>  float4(y, x, z, x);
        
        /// <summary>
        /// Returns float4.grbr swizzling (equivalent to float4.yxzx).
        /// </summary>
        [Inline]
        public float4 grbr =>  float4(y, x, z, x);
        
        /// <summary>
        /// Returns float4.yxzy swizzling.
        /// </summary>
        [Inline]
        public float4 yxzy =>  float4(y, x, z, y);
        
        /// <summary>
        /// Returns float4.grbg swizzling (equivalent to float4.yxzy).
        /// </summary>
        [Inline]
        public float4 grbg =>  float4(y, x, z, y);
        
        /// <summary>
        /// Returns float4.yxzz swizzling.
        /// </summary>
        [Inline]
        public float4 yxzz =>  float4(y, x, z, z);
        
        /// <summary>
        /// Returns float4.grbb swizzling (equivalent to float4.yxzz).
        /// </summary>
        [Inline]
        public float4 grbb =>  float4(y, x, z, z);
        
        /// <summary>
        /// Returns float4.yxzw swizzling.
        /// </summary>
        [Inline]
        public float4 yxzw =>  float4(y, x, z, w);
        
        /// <summary>
        /// Returns float4.grba swizzling (equivalent to float4.yxzw).
        /// </summary>
        [Inline]
        public float4 grba =>  float4(y, x, z, w);
        
        /// <summary>
        /// Returns float4.yxw swizzling.
        /// </summary>
        [Inline]
        public float3 yxw =>  float3(y, x, w);
        
        /// <summary>
        /// Returns float4.gra swizzling (equivalent to float4.yxw).
        /// </summary>
        [Inline]
        public float3 gra =>  float3(y, x, w);
        
        /// <summary>
        /// Returns float4.yxwx swizzling.
        /// </summary>
        [Inline]
        public float4 yxwx =>  float4(y, x, w, x);
        
        /// <summary>
        /// Returns float4.grar swizzling (equivalent to float4.yxwx).
        /// </summary>
        [Inline]
        public float4 grar =>  float4(y, x, w, x);
        
        /// <summary>
        /// Returns float4.yxwy swizzling.
        /// </summary>
        [Inline]
        public float4 yxwy =>  float4(y, x, w, y);
        
        /// <summary>
        /// Returns float4.grag swizzling (equivalent to float4.yxwy).
        /// </summary>
        [Inline]
        public float4 grag =>  float4(y, x, w, y);
        
        /// <summary>
        /// Returns float4.yxwz swizzling.
        /// </summary>
        [Inline]
        public float4 yxwz =>  float4(y, x, w, z);
        
        /// <summary>
        /// Returns float4.grab swizzling (equivalent to float4.yxwz).
        /// </summary>
        [Inline]
        public float4 grab =>  float4(y, x, w, z);
        
        /// <summary>
        /// Returns float4.yxww swizzling.
        /// </summary>
        [Inline]
        public float4 yxww =>  float4(y, x, w, w);
        
        /// <summary>
        /// Returns float4.graa swizzling (equivalent to float4.yxww).
        /// </summary>
        [Inline]
        public float4 graa =>  float4(y, x, w, w);
        
        /// <summary>
        /// Returns float4.yy swizzling.
        /// </summary>
        [Inline]
        public float2 yy =>  float2(y, y);
        
        /// <summary>
        /// Returns float4.gg swizzling (equivalent to float4.yy).
        /// </summary>
        [Inline]
        public float2 gg =>  float2(y, y);
        
        /// <summary>
        /// Returns float4.yyx swizzling.
        /// </summary>
        [Inline]
        public float3 yyx =>  float3(y, y, x);
        
        /// <summary>
        /// Returns float4.ggr swizzling (equivalent to float4.yyx).
        /// </summary>
        [Inline]
        public float3 ggr =>  float3(y, y, x);
        
        /// <summary>
        /// Returns float4.yyxx swizzling.
        /// </summary>
        [Inline]
        public float4 yyxx =>  float4(y, y, x, x);
        
        /// <summary>
        /// Returns float4.ggrr swizzling (equivalent to float4.yyxx).
        /// </summary>
        [Inline]
        public float4 ggrr =>  float4(y, y, x, x);
        
        /// <summary>
        /// Returns float4.yyxy swizzling.
        /// </summary>
        [Inline]
        public float4 yyxy =>  float4(y, y, x, y);
        
        /// <summary>
        /// Returns float4.ggrg swizzling (equivalent to float4.yyxy).
        /// </summary>
        [Inline]
        public float4 ggrg =>  float4(y, y, x, y);
        
        /// <summary>
        /// Returns float4.yyxz swizzling.
        /// </summary>
        [Inline]
        public float4 yyxz =>  float4(y, y, x, z);
        
        /// <summary>
        /// Returns float4.ggrb swizzling (equivalent to float4.yyxz).
        /// </summary>
        [Inline]
        public float4 ggrb =>  float4(y, y, x, z);
        
        /// <summary>
        /// Returns float4.yyxw swizzling.
        /// </summary>
        [Inline]
        public float4 yyxw =>  float4(y, y, x, w);
        
        /// <summary>
        /// Returns float4.ggra swizzling (equivalent to float4.yyxw).
        /// </summary>
        [Inline]
        public float4 ggra =>  float4(y, y, x, w);
        
        /// <summary>
        /// Returns float4.yyy swizzling.
        /// </summary>
        [Inline]
        public float3 yyy =>  float3(y, y, y);
        
        /// <summary>
        /// Returns float4.ggg swizzling (equivalent to float4.yyy).
        /// </summary>
        [Inline]
        public float3 ggg =>  float3(y, y, y);
        
        /// <summary>
        /// Returns float4.yyyx swizzling.
        /// </summary>
        [Inline]
        public float4 yyyx =>  float4(y, y, y, x);
        
        /// <summary>
        /// Returns float4.gggr swizzling (equivalent to float4.yyyx).
        /// </summary>
        [Inline]
        public float4 gggr =>  float4(y, y, y, x);
        
        /// <summary>
        /// Returns float4.yyyy swizzling.
        /// </summary>
        [Inline]
        public float4 yyyy =>  float4(y, y, y, y);
        
        /// <summary>
        /// Returns float4.gggg swizzling (equivalent to float4.yyyy).
        /// </summary>
        [Inline]
        public float4 gggg =>  float4(y, y, y, y);
        
        /// <summary>
        /// Returns float4.yyyz swizzling.
        /// </summary>
        [Inline]
        public float4 yyyz =>  float4(y, y, y, z);
        
        /// <summary>
        /// Returns float4.gggb swizzling (equivalent to float4.yyyz).
        /// </summary>
        [Inline]
        public float4 gggb =>  float4(y, y, y, z);
        
        /// <summary>
        /// Returns float4.yyyw swizzling.
        /// </summary>
        [Inline]
        public float4 yyyw =>  float4(y, y, y, w);
        
        /// <summary>
        /// Returns float4.ggga swizzling (equivalent to float4.yyyw).
        /// </summary>
        [Inline]
        public float4 ggga =>  float4(y, y, y, w);
        
        /// <summary>
        /// Returns float4.yyz swizzling.
        /// </summary>
        [Inline]
        public float3 yyz =>  float3(y, y, z);
        
        /// <summary>
        /// Returns float4.ggb swizzling (equivalent to float4.yyz).
        /// </summary>
        [Inline]
        public float3 ggb =>  float3(y, y, z);
        
        /// <summary>
        /// Returns float4.yyzx swizzling.
        /// </summary>
        [Inline]
        public float4 yyzx =>  float4(y, y, z, x);
        
        /// <summary>
        /// Returns float4.ggbr swizzling (equivalent to float4.yyzx).
        /// </summary>
        [Inline]
        public float4 ggbr =>  float4(y, y, z, x);
        
        /// <summary>
        /// Returns float4.yyzy swizzling.
        /// </summary>
        [Inline]
        public float4 yyzy =>  float4(y, y, z, y);
        
        /// <summary>
        /// Returns float4.ggbg swizzling (equivalent to float4.yyzy).
        /// </summary>
        [Inline]
        public float4 ggbg =>  float4(y, y, z, y);
        
        /// <summary>
        /// Returns float4.yyzz swizzling.
        /// </summary>
        [Inline]
        public float4 yyzz =>  float4(y, y, z, z);
        
        /// <summary>
        /// Returns float4.ggbb swizzling (equivalent to float4.yyzz).
        /// </summary>
        [Inline]
        public float4 ggbb =>  float4(y, y, z, z);
        
        /// <summary>
        /// Returns float4.yyzw swizzling.
        /// </summary>
        [Inline]
        public float4 yyzw =>  float4(y, y, z, w);
        
        /// <summary>
        /// Returns float4.ggba swizzling (equivalent to float4.yyzw).
        /// </summary>
        [Inline]
        public float4 ggba =>  float4(y, y, z, w);
        
        /// <summary>
        /// Returns float4.yyw swizzling.
        /// </summary>
        [Inline]
        public float3 yyw =>  float3(y, y, w);
        
        /// <summary>
        /// Returns float4.gga swizzling (equivalent to float4.yyw).
        /// </summary>
        [Inline]
        public float3 gga =>  float3(y, y, w);
        
        /// <summary>
        /// Returns float4.yywx swizzling.
        /// </summary>
        [Inline]
        public float4 yywx =>  float4(y, y, w, x);
        
        /// <summary>
        /// Returns float4.ggar swizzling (equivalent to float4.yywx).
        /// </summary>
        [Inline]
        public float4 ggar =>  float4(y, y, w, x);
        
        /// <summary>
        /// Returns float4.yywy swizzling.
        /// </summary>
        [Inline]
        public float4 yywy =>  float4(y, y, w, y);
        
        /// <summary>
        /// Returns float4.ggag swizzling (equivalent to float4.yywy).
        /// </summary>
        [Inline]
        public float4 ggag =>  float4(y, y, w, y);
        
        /// <summary>
        /// Returns float4.yywz swizzling.
        /// </summary>
        [Inline]
        public float4 yywz =>  float4(y, y, w, z);
        
        /// <summary>
        /// Returns float4.ggab swizzling (equivalent to float4.yywz).
        /// </summary>
        [Inline]
        public float4 ggab =>  float4(y, y, w, z);
        
        /// <summary>
        /// Returns float4.yyww swizzling.
        /// </summary>
        [Inline]
        public float4 yyww =>  float4(y, y, w, w);
        
        /// <summary>
        /// Returns float4.ggaa swizzling (equivalent to float4.yyww).
        /// </summary>
        [Inline]
        public float4 ggaa =>  float4(y, y, w, w);
        
        /// <summary>
        /// Returns float4.yz swizzling.
        /// </summary>
        [Inline]
        public float2 yz =>  float2(y, z);
        
        /// <summary>
        /// Returns float4.gb swizzling (equivalent to float4.yz).
        /// </summary>
        [Inline]
        public float2 gb =>  float2(y, z);
        
        /// <summary>
        /// Returns float4.yzx swizzling.
        /// </summary>
        [Inline]
        public float3 yzx =>  float3(y, z, x);
        
        /// <summary>
        /// Returns float4.gbr swizzling (equivalent to float4.yzx).
        /// </summary>
        [Inline]
        public float3 gbr =>  float3(y, z, x);
        
        /// <summary>
        /// Returns float4.yzxx swizzling.
        /// </summary>
        [Inline]
        public float4 yzxx =>  float4(y, z, x, x);
        
        /// <summary>
        /// Returns float4.gbrr swizzling (equivalent to float4.yzxx).
        /// </summary>
        [Inline]
        public float4 gbrr =>  float4(y, z, x, x);
        
        /// <summary>
        /// Returns float4.yzxy swizzling.
        /// </summary>
        [Inline]
        public float4 yzxy =>  float4(y, z, x, y);
        
        /// <summary>
        /// Returns float4.gbrg swizzling (equivalent to float4.yzxy).
        /// </summary>
        [Inline]
        public float4 gbrg =>  float4(y, z, x, y);
        
        /// <summary>
        /// Returns float4.yzxz swizzling.
        /// </summary>
        [Inline]
        public float4 yzxz =>  float4(y, z, x, z);
        
        /// <summary>
        /// Returns float4.gbrb swizzling (equivalent to float4.yzxz).
        /// </summary>
        [Inline]
        public float4 gbrb =>  float4(y, z, x, z);
        
        /// <summary>
        /// Returns float4.yzxw swizzling.
        /// </summary>
        [Inline]
        public float4 yzxw =>  float4(y, z, x, w);
        
        /// <summary>
        /// Returns float4.gbra swizzling (equivalent to float4.yzxw).
        /// </summary>
        [Inline]
        public float4 gbra =>  float4(y, z, x, w);
        
        /// <summary>
        /// Returns float4.yzy swizzling.
        /// </summary>
        [Inline]
        public float3 yzy =>  float3(y, z, y);
        
        /// <summary>
        /// Returns float4.gbg swizzling (equivalent to float4.yzy).
        /// </summary>
        [Inline]
        public float3 gbg =>  float3(y, z, y);
        
        /// <summary>
        /// Returns float4.yzyx swizzling.
        /// </summary>
        [Inline]
        public float4 yzyx =>  float4(y, z, y, x);
        
        /// <summary>
        /// Returns float4.gbgr swizzling (equivalent to float4.yzyx).
        /// </summary>
        [Inline]
        public float4 gbgr =>  float4(y, z, y, x);
        
        /// <summary>
        /// Returns float4.yzyy swizzling.
        /// </summary>
        [Inline]
        public float4 yzyy =>  float4(y, z, y, y);
        
        /// <summary>
        /// Returns float4.gbgg swizzling (equivalent to float4.yzyy).
        /// </summary>
        [Inline]
        public float4 gbgg =>  float4(y, z, y, y);
        
        /// <summary>
        /// Returns float4.yzyz swizzling.
        /// </summary>
        [Inline]
        public float4 yzyz =>  float4(y, z, y, z);
        
        /// <summary>
        /// Returns float4.gbgb swizzling (equivalent to float4.yzyz).
        /// </summary>
        [Inline]
        public float4 gbgb =>  float4(y, z, y, z);
        
        /// <summary>
        /// Returns float4.yzyw swizzling.
        /// </summary>
        [Inline]
        public float4 yzyw =>  float4(y, z, y, w);
        
        /// <summary>
        /// Returns float4.gbga swizzling (equivalent to float4.yzyw).
        /// </summary>
        [Inline]
        public float4 gbga =>  float4(y, z, y, w);
        
        /// <summary>
        /// Returns float4.yzz swizzling.
        /// </summary>
        [Inline]
        public float3 yzz =>  float3(y, z, z);
        
        /// <summary>
        /// Returns float4.gbb swizzling (equivalent to float4.yzz).
        /// </summary>
        [Inline]
        public float3 gbb =>  float3(y, z, z);
        
        /// <summary>
        /// Returns float4.yzzx swizzling.
        /// </summary>
        [Inline]
        public float4 yzzx =>  float4(y, z, z, x);
        
        /// <summary>
        /// Returns float4.gbbr swizzling (equivalent to float4.yzzx).
        /// </summary>
        [Inline]
        public float4 gbbr =>  float4(y, z, z, x);
        
        /// <summary>
        /// Returns float4.yzzy swizzling.
        /// </summary>
        [Inline]
        public float4 yzzy =>  float4(y, z, z, y);
        
        /// <summary>
        /// Returns float4.gbbg swizzling (equivalent to float4.yzzy).
        /// </summary>
        [Inline]
        public float4 gbbg =>  float4(y, z, z, y);
        
        /// <summary>
        /// Returns float4.yzzz swizzling.
        /// </summary>
        [Inline]
        public float4 yzzz =>  float4(y, z, z, z);
        
        /// <summary>
        /// Returns float4.gbbb swizzling (equivalent to float4.yzzz).
        /// </summary>
        [Inline]
        public float4 gbbb =>  float4(y, z, z, z);
        
        /// <summary>
        /// Returns float4.yzzw swizzling.
        /// </summary>
        [Inline]
        public float4 yzzw =>  float4(y, z, z, w);
        
        /// <summary>
        /// Returns float4.gbba swizzling (equivalent to float4.yzzw).
        /// </summary>
        [Inline]
        public float4 gbba =>  float4(y, z, z, w);
        
        /// <summary>
        /// Returns float4.yzw swizzling.
        /// </summary>
        [Inline]
        public float3 yzw =>  float3(y, z, w);
        
        /// <summary>
        /// Returns float4.gba swizzling (equivalent to float4.yzw).
        /// </summary>
        [Inline]
        public float3 gba =>  float3(y, z, w);
        
        /// <summary>
        /// Returns float4.yzwx swizzling.
        /// </summary>
        [Inline]
        public float4 yzwx =>  float4(y, z, w, x);
        
        /// <summary>
        /// Returns float4.gbar swizzling (equivalent to float4.yzwx).
        /// </summary>
        [Inline]
        public float4 gbar =>  float4(y, z, w, x);
        
        /// <summary>
        /// Returns float4.yzwy swizzling.
        /// </summary>
        [Inline]
        public float4 yzwy =>  float4(y, z, w, y);
        
        /// <summary>
        /// Returns float4.gbag swizzling (equivalent to float4.yzwy).
        /// </summary>
        [Inline]
        public float4 gbag =>  float4(y, z, w, y);
        
        /// <summary>
        /// Returns float4.yzwz swizzling.
        /// </summary>
        [Inline]
        public float4 yzwz =>  float4(y, z, w, z);
        
        /// <summary>
        /// Returns float4.gbab swizzling (equivalent to float4.yzwz).
        /// </summary>
        [Inline]
        public float4 gbab =>  float4(y, z, w, z);
        
        /// <summary>
        /// Returns float4.yzww swizzling.
        /// </summary>
        [Inline]
        public float4 yzww =>  float4(y, z, w, w);
        
        /// <summary>
        /// Returns float4.gbaa swizzling (equivalent to float4.yzww).
        /// </summary>
        [Inline]
        public float4 gbaa =>  float4(y, z, w, w);
        
        /// <summary>
        /// Returns float4.yw swizzling.
        /// </summary>
        [Inline]
        public float2 yw =>  float2(y, w);
        
        /// <summary>
        /// Returns float4.ga swizzling (equivalent to float4.yw).
        /// </summary>
        [Inline]
        public float2 ga =>  float2(y, w);
        
        /// <summary>
        /// Returns float4.ywx swizzling.
        /// </summary>
        [Inline]
        public float3 ywx =>  float3(y, w, x);
        
        /// <summary>
        /// Returns float4.gar swizzling (equivalent to float4.ywx).
        /// </summary>
        [Inline]
        public float3 gar =>  float3(y, w, x);
        
        /// <summary>
        /// Returns float4.ywxx swizzling.
        /// </summary>
        [Inline]
        public float4 ywxx =>  float4(y, w, x, x);
        
        /// <summary>
        /// Returns float4.garr swizzling (equivalent to float4.ywxx).
        /// </summary>
        [Inline]
        public float4 garr =>  float4(y, w, x, x);
        
        /// <summary>
        /// Returns float4.ywxy swizzling.
        /// </summary>
        [Inline]
        public float4 ywxy =>  float4(y, w, x, y);
        
        /// <summary>
        /// Returns float4.garg swizzling (equivalent to float4.ywxy).
        /// </summary>
        [Inline]
        public float4 garg =>  float4(y, w, x, y);
        
        /// <summary>
        /// Returns float4.ywxz swizzling.
        /// </summary>
        [Inline]
        public float4 ywxz =>  float4(y, w, x, z);
        
        /// <summary>
        /// Returns float4.garb swizzling (equivalent to float4.ywxz).
        /// </summary>
        [Inline]
        public float4 garb =>  float4(y, w, x, z);
        
        /// <summary>
        /// Returns float4.ywxw swizzling.
        /// </summary>
        [Inline]
        public float4 ywxw =>  float4(y, w, x, w);
        
        /// <summary>
        /// Returns float4.gara swizzling (equivalent to float4.ywxw).
        /// </summary>
        [Inline]
        public float4 gara =>  float4(y, w, x, w);
        
        /// <summary>
        /// Returns float4.ywy swizzling.
        /// </summary>
        [Inline]
        public float3 ywy =>  float3(y, w, y);
        
        /// <summary>
        /// Returns float4.gag swizzling (equivalent to float4.ywy).
        /// </summary>
        [Inline]
        public float3 gag =>  float3(y, w, y);
        
        /// <summary>
        /// Returns float4.ywyx swizzling.
        /// </summary>
        [Inline]
        public float4 ywyx =>  float4(y, w, y, x);
        
        /// <summary>
        /// Returns float4.gagr swizzling (equivalent to float4.ywyx).
        /// </summary>
        [Inline]
        public float4 gagr =>  float4(y, w, y, x);
        
        /// <summary>
        /// Returns float4.ywyy swizzling.
        /// </summary>
        [Inline]
        public float4 ywyy =>  float4(y, w, y, y);
        
        /// <summary>
        /// Returns float4.gagg swizzling (equivalent to float4.ywyy).
        /// </summary>
        [Inline]
        public float4 gagg =>  float4(y, w, y, y);
        
        /// <summary>
        /// Returns float4.ywyz swizzling.
        /// </summary>
        [Inline]
        public float4 ywyz =>  float4(y, w, y, z);
        
        /// <summary>
        /// Returns float4.gagb swizzling (equivalent to float4.ywyz).
        /// </summary>
        [Inline]
        public float4 gagb =>  float4(y, w, y, z);
        
        /// <summary>
        /// Returns float4.ywyw swizzling.
        /// </summary>
        [Inline]
        public float4 ywyw =>  float4(y, w, y, w);
        
        /// <summary>
        /// Returns float4.gaga swizzling (equivalent to float4.ywyw).
        /// </summary>
        [Inline]
        public float4 gaga =>  float4(y, w, y, w);
        
        /// <summary>
        /// Returns float4.ywz swizzling.
        /// </summary>
        [Inline]
        public float3 ywz =>  float3(y, w, z);
        
        /// <summary>
        /// Returns float4.gab swizzling (equivalent to float4.ywz).
        /// </summary>
        [Inline]
        public float3 gab =>  float3(y, w, z);
        
        /// <summary>
        /// Returns float4.ywzx swizzling.
        /// </summary>
        [Inline]
        public float4 ywzx =>  float4(y, w, z, x);
        
        /// <summary>
        /// Returns float4.gabr swizzling (equivalent to float4.ywzx).
        /// </summary>
        [Inline]
        public float4 gabr =>  float4(y, w, z, x);
        
        /// <summary>
        /// Returns float4.ywzy swizzling.
        /// </summary>
        [Inline]
        public float4 ywzy =>  float4(y, w, z, y);
        
        /// <summary>
        /// Returns float4.gabg swizzling (equivalent to float4.ywzy).
        /// </summary>
        [Inline]
        public float4 gabg =>  float4(y, w, z, y);
        
        /// <summary>
        /// Returns float4.ywzz swizzling.
        /// </summary>
        [Inline]
        public float4 ywzz =>  float4(y, w, z, z);
        
        /// <summary>
        /// Returns float4.gabb swizzling (equivalent to float4.ywzz).
        /// </summary>
        [Inline]
        public float4 gabb =>  float4(y, w, z, z);
        
        /// <summary>
        /// Returns float4.ywzw swizzling.
        /// </summary>
        [Inline]
        public float4 ywzw =>  float4(y, w, z, w);
        
        /// <summary>
        /// Returns float4.gaba swizzling (equivalent to float4.ywzw).
        /// </summary>
        [Inline]
        public float4 gaba =>  float4(y, w, z, w);
        
        /// <summary>
        /// Returns float4.yww swizzling.
        /// </summary>
        [Inline]
        public float3 yww =>  float3(y, w, w);
        
        /// <summary>
        /// Returns float4.gaa swizzling (equivalent to float4.yww).
        /// </summary>
        [Inline]
        public float3 gaa =>  float3(y, w, w);
        
        /// <summary>
        /// Returns float4.ywwx swizzling.
        /// </summary>
        [Inline]
        public float4 ywwx =>  float4(y, w, w, x);
        
        /// <summary>
        /// Returns float4.gaar swizzling (equivalent to float4.ywwx).
        /// </summary>
        [Inline]
        public float4 gaar =>  float4(y, w, w, x);
        
        /// <summary>
        /// Returns float4.ywwy swizzling.
        /// </summary>
        [Inline]
        public float4 ywwy =>  float4(y, w, w, y);
        
        /// <summary>
        /// Returns float4.gaag swizzling (equivalent to float4.ywwy).
        /// </summary>
        [Inline]
        public float4 gaag =>  float4(y, w, w, y);
        
        /// <summary>
        /// Returns float4.ywwz swizzling.
        /// </summary>
        [Inline]
        public float4 ywwz =>  float4(y, w, w, z);
        
        /// <summary>
        /// Returns float4.gaab swizzling (equivalent to float4.ywwz).
        /// </summary>
        [Inline]
        public float4 gaab =>  float4(y, w, w, z);
        
        /// <summary>
        /// Returns float4.ywww swizzling.
        /// </summary>
        [Inline]
        public float4 ywww =>  float4(y, w, w, w);
        
        /// <summary>
        /// Returns float4.gaaa swizzling (equivalent to float4.ywww).
        /// </summary>
        [Inline]
        public float4 gaaa =>  float4(y, w, w, w);
        
        /// <summary>
        /// Returns float4.zx swizzling.
        /// </summary>
        [Inline]
        public float2 zx =>  float2(z, x);
        
        /// <summary>
        /// Returns float4.br swizzling (equivalent to float4.zx).
        /// </summary>
        [Inline]
        public float2 br =>  float2(z, x);
        
        /// <summary>
        /// Returns float4.zxx swizzling.
        /// </summary>
        [Inline]
        public float3 zxx =>  float3(z, x, x);
        
        /// <summary>
        /// Returns float4.brr swizzling (equivalent to float4.zxx).
        /// </summary>
        [Inline]
        public float3 brr =>  float3(z, x, x);
        
        /// <summary>
        /// Returns float4.zxxx swizzling.
        /// </summary>
        [Inline]
        public float4 zxxx =>  float4(z, x, x, x);
        
        /// <summary>
        /// Returns float4.brrr swizzling (equivalent to float4.zxxx).
        /// </summary>
        [Inline]
        public float4 brrr =>  float4(z, x, x, x);
        
        /// <summary>
        /// Returns float4.zxxy swizzling.
        /// </summary>
        [Inline]
        public float4 zxxy =>  float4(z, x, x, y);
        
        /// <summary>
        /// Returns float4.brrg swizzling (equivalent to float4.zxxy).
        /// </summary>
        [Inline]
        public float4 brrg =>  float4(z, x, x, y);
        
        /// <summary>
        /// Returns float4.zxxz swizzling.
        /// </summary>
        [Inline]
        public float4 zxxz =>  float4(z, x, x, z);
        
        /// <summary>
        /// Returns float4.brrb swizzling (equivalent to float4.zxxz).
        /// </summary>
        [Inline]
        public float4 brrb =>  float4(z, x, x, z);
        
        /// <summary>
        /// Returns float4.zxxw swizzling.
        /// </summary>
        [Inline]
        public float4 zxxw =>  float4(z, x, x, w);
        
        /// <summary>
        /// Returns float4.brra swizzling (equivalent to float4.zxxw).
        /// </summary>
        [Inline]
        public float4 brra =>  float4(z, x, x, w);
        
        /// <summary>
        /// Returns float4.zxy swizzling.
        /// </summary>
        [Inline]
        public float3 zxy =>  float3(z, x, y);
        
        /// <summary>
        /// Returns float4.brg swizzling (equivalent to float4.zxy).
        /// </summary>
        [Inline]
        public float3 brg =>  float3(z, x, y);
        
        /// <summary>
        /// Returns float4.zxyx swizzling.
        /// </summary>
        [Inline]
        public float4 zxyx =>  float4(z, x, y, x);
        
        /// <summary>
        /// Returns float4.brgr swizzling (equivalent to float4.zxyx).
        /// </summary>
        [Inline]
        public float4 brgr =>  float4(z, x, y, x);
        
        /// <summary>
        /// Returns float4.zxyy swizzling.
        /// </summary>
        [Inline]
        public float4 zxyy =>  float4(z, x, y, y);
        
        /// <summary>
        /// Returns float4.brgg swizzling (equivalent to float4.zxyy).
        /// </summary>
        [Inline]
        public float4 brgg =>  float4(z, x, y, y);
        
        /// <summary>
        /// Returns float4.zxyz swizzling.
        /// </summary>
        [Inline]
        public float4 zxyz =>  float4(z, x, y, z);
        
        /// <summary>
        /// Returns float4.brgb swizzling (equivalent to float4.zxyz).
        /// </summary>
        [Inline]
        public float4 brgb =>  float4(z, x, y, z);
        
        /// <summary>
        /// Returns float4.zxyw swizzling.
        /// </summary>
        [Inline]
        public float4 zxyw =>  float4(z, x, y, w);
        
        /// <summary>
        /// Returns float4.brga swizzling (equivalent to float4.zxyw).
        /// </summary>
        [Inline]
        public float4 brga =>  float4(z, x, y, w);
        
        /// <summary>
        /// Returns float4.zxz swizzling.
        /// </summary>
        [Inline]
        public float3 zxz =>  float3(z, x, z);
        
        /// <summary>
        /// Returns float4.brb swizzling (equivalent to float4.zxz).
        /// </summary>
        [Inline]
        public float3 brb =>  float3(z, x, z);
        
        /// <summary>
        /// Returns float4.zxzx swizzling.
        /// </summary>
        [Inline]
        public float4 zxzx =>  float4(z, x, z, x);
        
        /// <summary>
        /// Returns float4.brbr swizzling (equivalent to float4.zxzx).
        /// </summary>
        [Inline]
        public float4 brbr =>  float4(z, x, z, x);
        
        /// <summary>
        /// Returns float4.zxzy swizzling.
        /// </summary>
        [Inline]
        public float4 zxzy =>  float4(z, x, z, y);
        
        /// <summary>
        /// Returns float4.brbg swizzling (equivalent to float4.zxzy).
        /// </summary>
        [Inline]
        public float4 brbg =>  float4(z, x, z, y);
        
        /// <summary>
        /// Returns float4.zxzz swizzling.
        /// </summary>
        [Inline]
        public float4 zxzz =>  float4(z, x, z, z);
        
        /// <summary>
        /// Returns float4.brbb swizzling (equivalent to float4.zxzz).
        /// </summary>
        [Inline]
        public float4 brbb =>  float4(z, x, z, z);
        
        /// <summary>
        /// Returns float4.zxzw swizzling.
        /// </summary>
        [Inline]
        public float4 zxzw =>  float4(z, x, z, w);
        
        /// <summary>
        /// Returns float4.brba swizzling (equivalent to float4.zxzw).
        /// </summary>
        [Inline]
        public float4 brba =>  float4(z, x, z, w);
        
        /// <summary>
        /// Returns float4.zxw swizzling.
        /// </summary>
        [Inline]
        public float3 zxw =>  float3(z, x, w);
        
        /// <summary>
        /// Returns float4.bra swizzling (equivalent to float4.zxw).
        /// </summary>
        [Inline]
        public float3 bra =>  float3(z, x, w);
        
        /// <summary>
        /// Returns float4.zxwx swizzling.
        /// </summary>
        [Inline]
        public float4 zxwx =>  float4(z, x, w, x);
        
        /// <summary>
        /// Returns float4.brar swizzling (equivalent to float4.zxwx).
        /// </summary>
        [Inline]
        public float4 brar =>  float4(z, x, w, x);
        
        /// <summary>
        /// Returns float4.zxwy swizzling.
        /// </summary>
        [Inline]
        public float4 zxwy =>  float4(z, x, w, y);
        
        /// <summary>
        /// Returns float4.brag swizzling (equivalent to float4.zxwy).
        /// </summary>
        [Inline]
        public float4 brag =>  float4(z, x, w, y);
        
        /// <summary>
        /// Returns float4.zxwz swizzling.
        /// </summary>
        [Inline]
        public float4 zxwz =>  float4(z, x, w, z);
        
        /// <summary>
        /// Returns float4.brab swizzling (equivalent to float4.zxwz).
        /// </summary>
        [Inline]
        public float4 brab =>  float4(z, x, w, z);
        
        /// <summary>
        /// Returns float4.zxww swizzling.
        /// </summary>
        [Inline]
        public float4 zxww =>  float4(z, x, w, w);
        
        /// <summary>
        /// Returns float4.braa swizzling (equivalent to float4.zxww).
        /// </summary>
        [Inline]
        public float4 braa =>  float4(z, x, w, w);
        
        /// <summary>
        /// Returns float4.zy swizzling.
        /// </summary>
        [Inline]
        public float2 zy =>  float2(z, y);
        
        /// <summary>
        /// Returns float4.bg swizzling (equivalent to float4.zy).
        /// </summary>
        [Inline]
        public float2 bg =>  float2(z, y);
        
        /// <summary>
        /// Returns float4.zyx swizzling.
        /// </summary>
        [Inline]
        public float3 zyx =>  float3(z, y, x);
        
        /// <summary>
        /// Returns float4.bgr swizzling (equivalent to float4.zyx).
        /// </summary>
        [Inline]
        public float3 bgr =>  float3(z, y, x);
        
        /// <summary>
        /// Returns float4.zyxx swizzling.
        /// </summary>
        [Inline]
        public float4 zyxx =>  float4(z, y, x, x);
        
        /// <summary>
        /// Returns float4.bgrr swizzling (equivalent to float4.zyxx).
        /// </summary>
        [Inline]
        public float4 bgrr =>  float4(z, y, x, x);
        
        /// <summary>
        /// Returns float4.zyxy swizzling.
        /// </summary>
        [Inline]
        public float4 zyxy =>  float4(z, y, x, y);
        
        /// <summary>
        /// Returns float4.bgrg swizzling (equivalent to float4.zyxy).
        /// </summary>
        [Inline]
        public float4 bgrg =>  float4(z, y, x, y);
        
        /// <summary>
        /// Returns float4.zyxz swizzling.
        /// </summary>
        [Inline]
        public float4 zyxz =>  float4(z, y, x, z);
        
        /// <summary>
        /// Returns float4.bgrb swizzling (equivalent to float4.zyxz).
        /// </summary>
        [Inline]
        public float4 bgrb =>  float4(z, y, x, z);
        
        /// <summary>
        /// Returns float4.zyxw swizzling.
        /// </summary>
        [Inline]
        public float4 zyxw =>  float4(z, y, x, w);
        
        /// <summary>
        /// Returns float4.bgra swizzling (equivalent to float4.zyxw).
        /// </summary>
        [Inline]
        public float4 bgra =>  float4(z, y, x, w);
        
        /// <summary>
        /// Returns float4.zyy swizzling.
        /// </summary>
        [Inline]
        public float3 zyy =>  float3(z, y, y);
        
        /// <summary>
        /// Returns float4.bgg swizzling (equivalent to float4.zyy).
        /// </summary>
        [Inline]
        public float3 bgg =>  float3(z, y, y);
        
        /// <summary>
        /// Returns float4.zyyx swizzling.
        /// </summary>
        [Inline]
        public float4 zyyx =>  float4(z, y, y, x);
        
        /// <summary>
        /// Returns float4.bggr swizzling (equivalent to float4.zyyx).
        /// </summary>
        [Inline]
        public float4 bggr =>  float4(z, y, y, x);
        
        /// <summary>
        /// Returns float4.zyyy swizzling.
        /// </summary>
        [Inline]
        public float4 zyyy =>  float4(z, y, y, y);
        
        /// <summary>
        /// Returns float4.bggg swizzling (equivalent to float4.zyyy).
        /// </summary>
        [Inline]
        public float4 bggg =>  float4(z, y, y, y);
        
        /// <summary>
        /// Returns float4.zyyz swizzling.
        /// </summary>
        [Inline]
        public float4 zyyz =>  float4(z, y, y, z);
        
        /// <summary>
        /// Returns float4.bggb swizzling (equivalent to float4.zyyz).
        /// </summary>
        [Inline]
        public float4 bggb =>  float4(z, y, y, z);
        
        /// <summary>
        /// Returns float4.zyyw swizzling.
        /// </summary>
        [Inline]
        public float4 zyyw =>  float4(z, y, y, w);
        
        /// <summary>
        /// Returns float4.bgga swizzling (equivalent to float4.zyyw).
        /// </summary>
        [Inline]
        public float4 bgga =>  float4(z, y, y, w);
        
        /// <summary>
        /// Returns float4.zyz swizzling.
        /// </summary>
        [Inline]
        public float3 zyz =>  float3(z, y, z);
        
        /// <summary>
        /// Returns float4.bgb swizzling (equivalent to float4.zyz).
        /// </summary>
        [Inline]
        public float3 bgb =>  float3(z, y, z);
        
        /// <summary>
        /// Returns float4.zyzx swizzling.
        /// </summary>
        [Inline]
        public float4 zyzx =>  float4(z, y, z, x);
        
        /// <summary>
        /// Returns float4.bgbr swizzling (equivalent to float4.zyzx).
        /// </summary>
        [Inline]
        public float4 bgbr =>  float4(z, y, z, x);
        
        /// <summary>
        /// Returns float4.zyzy swizzling.
        /// </summary>
        [Inline]
        public float4 zyzy =>  float4(z, y, z, y);
        
        /// <summary>
        /// Returns float4.bgbg swizzling (equivalent to float4.zyzy).
        /// </summary>
        [Inline]
        public float4 bgbg =>  float4(z, y, z, y);
        
        /// <summary>
        /// Returns float4.zyzz swizzling.
        /// </summary>
        [Inline]
        public float4 zyzz =>  float4(z, y, z, z);
        
        /// <summary>
        /// Returns float4.bgbb swizzling (equivalent to float4.zyzz).
        /// </summary>
        [Inline]
        public float4 bgbb =>  float4(z, y, z, z);
        
        /// <summary>
        /// Returns float4.zyzw swizzling.
        /// </summary>
        [Inline]
        public float4 zyzw =>  float4(z, y, z, w);
        
        /// <summary>
        /// Returns float4.bgba swizzling (equivalent to float4.zyzw).
        /// </summary>
        [Inline]
        public float4 bgba =>  float4(z, y, z, w);
        
        /// <summary>
        /// Returns float4.zyw swizzling.
        /// </summary>
        [Inline]
        public float3 zyw =>  float3(z, y, w);
        
        /// <summary>
        /// Returns float4.bga swizzling (equivalent to float4.zyw).
        /// </summary>
        [Inline]
        public float3 bga =>  float3(z, y, w);
        
        /// <summary>
        /// Returns float4.zywx swizzling.
        /// </summary>
        [Inline]
        public float4 zywx =>  float4(z, y, w, x);
        
        /// <summary>
        /// Returns float4.bgar swizzling (equivalent to float4.zywx).
        /// </summary>
        [Inline]
        public float4 bgar =>  float4(z, y, w, x);
        
        /// <summary>
        /// Returns float4.zywy swizzling.
        /// </summary>
        [Inline]
        public float4 zywy =>  float4(z, y, w, y);
        
        /// <summary>
        /// Returns float4.bgag swizzling (equivalent to float4.zywy).
        /// </summary>
        [Inline]
        public float4 bgag =>  float4(z, y, w, y);
        
        /// <summary>
        /// Returns float4.zywz swizzling.
        /// </summary>
        [Inline]
        public float4 zywz =>  float4(z, y, w, z);
        
        /// <summary>
        /// Returns float4.bgab swizzling (equivalent to float4.zywz).
        /// </summary>
        [Inline]
        public float4 bgab =>  float4(z, y, w, z);
        
        /// <summary>
        /// Returns float4.zyww swizzling.
        /// </summary>
        [Inline]
        public float4 zyww =>  float4(z, y, w, w);
        
        /// <summary>
        /// Returns float4.bgaa swizzling (equivalent to float4.zyww).
        /// </summary>
        [Inline]
        public float4 bgaa =>  float4(z, y, w, w);
        
        /// <summary>
        /// Returns float4.zz swizzling.
        /// </summary>
        [Inline]
        public float2 zz =>  float2(z, z);
        
        /// <summary>
        /// Returns float4.bb swizzling (equivalent to float4.zz).
        /// </summary>
        [Inline]
        public float2 bb =>  float2(z, z);
        
        /// <summary>
        /// Returns float4.zzx swizzling.
        /// </summary>
        [Inline]
        public float3 zzx =>  float3(z, z, x);
        
        /// <summary>
        /// Returns float4.bbr swizzling (equivalent to float4.zzx).
        /// </summary>
        [Inline]
        public float3 bbr =>  float3(z, z, x);
        
        /// <summary>
        /// Returns float4.zzxx swizzling.
        /// </summary>
        [Inline]
        public float4 zzxx =>  float4(z, z, x, x);
        
        /// <summary>
        /// Returns float4.bbrr swizzling (equivalent to float4.zzxx).
        /// </summary>
        [Inline]
        public float4 bbrr =>  float4(z, z, x, x);
        
        /// <summary>
        /// Returns float4.zzxy swizzling.
        /// </summary>
        [Inline]
        public float4 zzxy =>  float4(z, z, x, y);
        
        /// <summary>
        /// Returns float4.bbrg swizzling (equivalent to float4.zzxy).
        /// </summary>
        [Inline]
        public float4 bbrg =>  float4(z, z, x, y);
        
        /// <summary>
        /// Returns float4.zzxz swizzling.
        /// </summary>
        [Inline]
        public float4 zzxz =>  float4(z, z, x, z);
        
        /// <summary>
        /// Returns float4.bbrb swizzling (equivalent to float4.zzxz).
        /// </summary>
        [Inline]
        public float4 bbrb =>  float4(z, z, x, z);
        
        /// <summary>
        /// Returns float4.zzxw swizzling.
        /// </summary>
        [Inline]
        public float4 zzxw =>  float4(z, z, x, w);
        
        /// <summary>
        /// Returns float4.bbra swizzling (equivalent to float4.zzxw).
        /// </summary>
        [Inline]
        public float4 bbra =>  float4(z, z, x, w);
        
        /// <summary>
        /// Returns float4.zzy swizzling.
        /// </summary>
        [Inline]
        public float3 zzy =>  float3(z, z, y);
        
        /// <summary>
        /// Returns float4.bbg swizzling (equivalent to float4.zzy).
        /// </summary>
        [Inline]
        public float3 bbg =>  float3(z, z, y);
        
        /// <summary>
        /// Returns float4.zzyx swizzling.
        /// </summary>
        [Inline]
        public float4 zzyx =>  float4(z, z, y, x);
        
        /// <summary>
        /// Returns float4.bbgr swizzling (equivalent to float4.zzyx).
        /// </summary>
        [Inline]
        public float4 bbgr =>  float4(z, z, y, x);
        
        /// <summary>
        /// Returns float4.zzyy swizzling.
        /// </summary>
        [Inline]
        public float4 zzyy =>  float4(z, z, y, y);
        
        /// <summary>
        /// Returns float4.bbgg swizzling (equivalent to float4.zzyy).
        /// </summary>
        [Inline]
        public float4 bbgg =>  float4(z, z, y, y);
        
        /// <summary>
        /// Returns float4.zzyz swizzling.
        /// </summary>
        [Inline]
        public float4 zzyz =>  float4(z, z, y, z);
        
        /// <summary>
        /// Returns float4.bbgb swizzling (equivalent to float4.zzyz).
        /// </summary>
        [Inline]
        public float4 bbgb =>  float4(z, z, y, z);
        
        /// <summary>
        /// Returns float4.zzyw swizzling.
        /// </summary>
        [Inline]
        public float4 zzyw =>  float4(z, z, y, w);
        
        /// <summary>
        /// Returns float4.bbga swizzling (equivalent to float4.zzyw).
        /// </summary>
        [Inline]
        public float4 bbga =>  float4(z, z, y, w);
        
        /// <summary>
        /// Returns float4.zzz swizzling.
        /// </summary>
        [Inline]
        public float3 zzz =>  float3(z, z, z);
        
        /// <summary>
        /// Returns float4.bbb swizzling (equivalent to float4.zzz).
        /// </summary>
        [Inline]
        public float3 bbb =>  float3(z, z, z);
        
        /// <summary>
        /// Returns float4.zzzx swizzling.
        /// </summary>
        [Inline]
        public float4 zzzx =>  float4(z, z, z, x);
        
        /// <summary>
        /// Returns float4.bbbr swizzling (equivalent to float4.zzzx).
        /// </summary>
        [Inline]
        public float4 bbbr =>  float4(z, z, z, x);
        
        /// <summary>
        /// Returns float4.zzzy swizzling.
        /// </summary>
        [Inline]
        public float4 zzzy =>  float4(z, z, z, y);
        
        /// <summary>
        /// Returns float4.bbbg swizzling (equivalent to float4.zzzy).
        /// </summary>
        [Inline]
        public float4 bbbg =>  float4(z, z, z, y);
        
        /// <summary>
        /// Returns float4.zzzz swizzling.
        /// </summary>
        [Inline]
        public float4 zzzz =>  float4(z, z, z, z);
        
        /// <summary>
        /// Returns float4.bbbb swizzling (equivalent to float4.zzzz).
        /// </summary>
        [Inline]
        public float4 bbbb =>  float4(z, z, z, z);
        
        /// <summary>
        /// Returns float4.zzzw swizzling.
        /// </summary>
        [Inline]
        public float4 zzzw =>  float4(z, z, z, w);
        
        /// <summary>
        /// Returns float4.bbba swizzling (equivalent to float4.zzzw).
        /// </summary>
        [Inline]
        public float4 bbba =>  float4(z, z, z, w);
        
        /// <summary>
        /// Returns float4.zzw swizzling.
        /// </summary>
        [Inline]
        public float3 zzw =>  float3(z, z, w);
        
        /// <summary>
        /// Returns float4.bba swizzling (equivalent to float4.zzw).
        /// </summary>
        [Inline]
        public float3 bba =>  float3(z, z, w);
        
        /// <summary>
        /// Returns float4.zzwx swizzling.
        /// </summary>
        [Inline]
        public float4 zzwx =>  float4(z, z, w, x);
        
        /// <summary>
        /// Returns float4.bbar swizzling (equivalent to float4.zzwx).
        /// </summary>
        [Inline]
        public float4 bbar =>  float4(z, z, w, x);
        
        /// <summary>
        /// Returns float4.zzwy swizzling.
        /// </summary>
        [Inline]
        public float4 zzwy =>  float4(z, z, w, y);
        
        /// <summary>
        /// Returns float4.bbag swizzling (equivalent to float4.zzwy).
        /// </summary>
        [Inline]
        public float4 bbag =>  float4(z, z, w, y);
        
        /// <summary>
        /// Returns float4.zzwz swizzling.
        /// </summary>
        [Inline]
        public float4 zzwz =>  float4(z, z, w, z);
        
        /// <summary>
        /// Returns float4.bbab swizzling (equivalent to float4.zzwz).
        /// </summary>
        [Inline]
        public float4 bbab =>  float4(z, z, w, z);
        
        /// <summary>
        /// Returns float4.zzww swizzling.
        /// </summary>
        [Inline]
        public float4 zzww =>  float4(z, z, w, w);
        
        /// <summary>
        /// Returns float4.bbaa swizzling (equivalent to float4.zzww).
        /// </summary>
        [Inline]
        public float4 bbaa =>  float4(z, z, w, w);
        
        /// <summary>
        /// Returns float4.zw swizzling.
        /// </summary>
        [Inline]
        public float2 zw =>  float2(z, w);
        
        /// <summary>
        /// Returns float4.ba swizzling (equivalent to float4.zw).
        /// </summary>
        [Inline]
        public float2 ba =>  float2(z, w);
        
        /// <summary>
        /// Returns float4.zwx swizzling.
        /// </summary>
        [Inline]
        public float3 zwx =>  float3(z, w, x);
        
        /// <summary>
        /// Returns float4.bar swizzling (equivalent to float4.zwx).
        /// </summary>
        [Inline]
        public float3 bar =>  float3(z, w, x);
        
        /// <summary>
        /// Returns float4.zwxx swizzling.
        /// </summary>
        [Inline]
        public float4 zwxx =>  float4(z, w, x, x);
        
        /// <summary>
        /// Returns float4.barr swizzling (equivalent to float4.zwxx).
        /// </summary>
        [Inline]
        public float4 barr =>  float4(z, w, x, x);
        
        /// <summary>
        /// Returns float4.zwxy swizzling.
        /// </summary>
        [Inline]
        public float4 zwxy =>  float4(z, w, x, y);
        
        /// <summary>
        /// Returns float4.barg swizzling (equivalent to float4.zwxy).
        /// </summary>
        [Inline]
        public float4 barg =>  float4(z, w, x, y);
        
        /// <summary>
        /// Returns float4.zwxz swizzling.
        /// </summary>
        [Inline]
        public float4 zwxz =>  float4(z, w, x, z);
        
        /// <summary>
        /// Returns float4.barb swizzling (equivalent to float4.zwxz).
        /// </summary>
        [Inline]
        public float4 barb =>  float4(z, w, x, z);
        
        /// <summary>
        /// Returns float4.zwxw swizzling.
        /// </summary>
        [Inline]
        public float4 zwxw =>  float4(z, w, x, w);
        
        /// <summary>
        /// Returns float4.bara swizzling (equivalent to float4.zwxw).
        /// </summary>
        [Inline]
        public float4 bara =>  float4(z, w, x, w);
        
        /// <summary>
        /// Returns float4.zwy swizzling.
        /// </summary>
        [Inline]
        public float3 zwy =>  float3(z, w, y);
        
        /// <summary>
        /// Returns float4.bag swizzling (equivalent to float4.zwy).
        /// </summary>
        [Inline]
        public float3 bag =>  float3(z, w, y);
        
        /// <summary>
        /// Returns float4.zwyx swizzling.
        /// </summary>
        [Inline]
        public float4 zwyx =>  float4(z, w, y, x);
        
        /// <summary>
        /// Returns float4.bagr swizzling (equivalent to float4.zwyx).
        /// </summary>
        [Inline]
        public float4 bagr =>  float4(z, w, y, x);
        
        /// <summary>
        /// Returns float4.zwyy swizzling.
        /// </summary>
        [Inline]
        public float4 zwyy =>  float4(z, w, y, y);
        
        /// <summary>
        /// Returns float4.bagg swizzling (equivalent to float4.zwyy).
        /// </summary>
        [Inline]
        public float4 bagg =>  float4(z, w, y, y);
        
        /// <summary>
        /// Returns float4.zwyz swizzling.
        /// </summary>
        [Inline]
        public float4 zwyz =>  float4(z, w, y, z);
        
        /// <summary>
        /// Returns float4.bagb swizzling (equivalent to float4.zwyz).
        /// </summary>
        [Inline]
        public float4 bagb =>  float4(z, w, y, z);
        
        /// <summary>
        /// Returns float4.zwyw swizzling.
        /// </summary>
        [Inline]
        public float4 zwyw =>  float4(z, w, y, w);
        
        /// <summary>
        /// Returns float4.baga swizzling (equivalent to float4.zwyw).
        /// </summary>
        [Inline]
        public float4 baga =>  float4(z, w, y, w);
        
        /// <summary>
        /// Returns float4.zwz swizzling.
        /// </summary>
        [Inline]
        public float3 zwz =>  float3(z, w, z);
        
        /// <summary>
        /// Returns float4.bab swizzling (equivalent to float4.zwz).
        /// </summary>
        [Inline]
        public float3 bab =>  float3(z, w, z);
        
        /// <summary>
        /// Returns float4.zwzx swizzling.
        /// </summary>
        [Inline]
        public float4 zwzx =>  float4(z, w, z, x);
        
        /// <summary>
        /// Returns float4.babr swizzling (equivalent to float4.zwzx).
        /// </summary>
        [Inline]
        public float4 babr =>  float4(z, w, z, x);
        
        /// <summary>
        /// Returns float4.zwzy swizzling.
        /// </summary>
        [Inline]
        public float4 zwzy =>  float4(z, w, z, y);
        
        /// <summary>
        /// Returns float4.babg swizzling (equivalent to float4.zwzy).
        /// </summary>
        [Inline]
        public float4 babg =>  float4(z, w, z, y);
        
        /// <summary>
        /// Returns float4.zwzz swizzling.
        /// </summary>
        [Inline]
        public float4 zwzz =>  float4(z, w, z, z);
        
        /// <summary>
        /// Returns float4.babb swizzling (equivalent to float4.zwzz).
        /// </summary>
        [Inline]
        public float4 babb =>  float4(z, w, z, z);
        
        /// <summary>
        /// Returns float4.zwzw swizzling.
        /// </summary>
        [Inline]
        public float4 zwzw =>  float4(z, w, z, w);
        
        /// <summary>
        /// Returns float4.baba swizzling (equivalent to float4.zwzw).
        /// </summary>
        [Inline]
        public float4 baba =>  float4(z, w, z, w);
        
        /// <summary>
        /// Returns float4.zww swizzling.
        /// </summary>
        [Inline]
        public float3 zww =>  float3(z, w, w);
        
        /// <summary>
        /// Returns float4.baa swizzling (equivalent to float4.zww).
        /// </summary>
        [Inline]
        public float3 baa =>  float3(z, w, w);
        
        /// <summary>
        /// Returns float4.zwwx swizzling.
        /// </summary>
        [Inline]
        public float4 zwwx =>  float4(z, w, w, x);
        
        /// <summary>
        /// Returns float4.baar swizzling (equivalent to float4.zwwx).
        /// </summary>
        [Inline]
        public float4 baar =>  float4(z, w, w, x);
        
        /// <summary>
        /// Returns float4.zwwy swizzling.
        /// </summary>
        [Inline]
        public float4 zwwy =>  float4(z, w, w, y);
        
        /// <summary>
        /// Returns float4.baag swizzling (equivalent to float4.zwwy).
        /// </summary>
        [Inline]
        public float4 baag =>  float4(z, w, w, y);
        
        /// <summary>
        /// Returns float4.zwwz swizzling.
        /// </summary>
        [Inline]
        public float4 zwwz =>  float4(z, w, w, z);
        
        /// <summary>
        /// Returns float4.baab swizzling (equivalent to float4.zwwz).
        /// </summary>
        [Inline]
        public float4 baab =>  float4(z, w, w, z);
        
        /// <summary>
        /// Returns float4.zwww swizzling.
        /// </summary>
        [Inline]
        public float4 zwww =>  float4(z, w, w, w);
        
        /// <summary>
        /// Returns float4.baaa swizzling (equivalent to float4.zwww).
        /// </summary>
        [Inline]
        public float4 baaa =>  float4(z, w, w, w);
        
        /// <summary>
        /// Returns float4.wx swizzling.
        /// </summary>
        [Inline]
        public float2 wx =>  float2(w, x);
        
        /// <summary>
        /// Returns float4.ar swizzling (equivalent to float4.wx).
        /// </summary>
        [Inline]
        public float2 ar =>  float2(w, x);
        
        /// <summary>
        /// Returns float4.wxx swizzling.
        /// </summary>
        [Inline]
        public float3 wxx =>  float3(w, x, x);
        
        /// <summary>
        /// Returns float4.arr swizzling (equivalent to float4.wxx).
        /// </summary>
        [Inline]
        public float3 arr =>  float3(w, x, x);
        
        /// <summary>
        /// Returns float4.wxxx swizzling.
        /// </summary>
        [Inline]
        public float4 wxxx =>  float4(w, x, x, x);
        
        /// <summary>
        /// Returns float4.arrr swizzling (equivalent to float4.wxxx).
        /// </summary>
        [Inline]
        public float4 arrr =>  float4(w, x, x, x);
        
        /// <summary>
        /// Returns float4.wxxy swizzling.
        /// </summary>
        [Inline]
        public float4 wxxy =>  float4(w, x, x, y);
        
        /// <summary>
        /// Returns float4.arrg swizzling (equivalent to float4.wxxy).
        /// </summary>
        [Inline]
        public float4 arrg =>  float4(w, x, x, y);
        
        /// <summary>
        /// Returns float4.wxxz swizzling.
        /// </summary>
        [Inline]
        public float4 wxxz =>  float4(w, x, x, z);
        
        /// <summary>
        /// Returns float4.arrb swizzling (equivalent to float4.wxxz).
        /// </summary>
        [Inline]
        public float4 arrb =>  float4(w, x, x, z);
        
        /// <summary>
        /// Returns float4.wxxw swizzling.
        /// </summary>
        [Inline]
        public float4 wxxw =>  float4(w, x, x, w);
        
        /// <summary>
        /// Returns float4.arra swizzling (equivalent to float4.wxxw).
        /// </summary>
        [Inline]
        public float4 arra =>  float4(w, x, x, w);
        
        /// <summary>
        /// Returns float4.wxy swizzling.
        /// </summary>
        [Inline]
        public float3 wxy =>  float3(w, x, y);
        
        /// <summary>
        /// Returns float4.arg swizzling (equivalent to float4.wxy).
        /// </summary>
        [Inline]
        public float3 arg =>  float3(w, x, y);
        
        /// <summary>
        /// Returns float4.wxyx swizzling.
        /// </summary>
        [Inline]
        public float4 wxyx =>  float4(w, x, y, x);
        
        /// <summary>
        /// Returns float4.argr swizzling (equivalent to float4.wxyx).
        /// </summary>
        [Inline]
        public float4 argr =>  float4(w, x, y, x);
        
        /// <summary>
        /// Returns float4.wxyy swizzling.
        /// </summary>
        [Inline]
        public float4 wxyy =>  float4(w, x, y, y);
        
        /// <summary>
        /// Returns float4.argg swizzling (equivalent to float4.wxyy).
        /// </summary>
        [Inline]
        public float4 argg =>  float4(w, x, y, y);
        
        /// <summary>
        /// Returns float4.wxyz swizzling.
        /// </summary>
        [Inline]
        public float4 wxyz =>  float4(w, x, y, z);
        
        /// <summary>
        /// Returns float4.argb swizzling (equivalent to float4.wxyz).
        /// </summary>
        [Inline]
        public float4 argb =>  float4(w, x, y, z);
        
        /// <summary>
        /// Returns float4.wxyw swizzling.
        /// </summary>
        [Inline]
        public float4 wxyw =>  float4(w, x, y, w);
        
        /// <summary>
        /// Returns float4.arga swizzling (equivalent to float4.wxyw).
        /// </summary>
        [Inline]
        public float4 arga =>  float4(w, x, y, w);
        
        /// <summary>
        /// Returns float4.wxz swizzling.
        /// </summary>
        [Inline]
        public float3 wxz =>  float3(w, x, z);
        
        /// <summary>
        /// Returns float4.arb swizzling (equivalent to float4.wxz).
        /// </summary>
        [Inline]
        public float3 arb =>  float3(w, x, z);
        
        /// <summary>
        /// Returns float4.wxzx swizzling.
        /// </summary>
        [Inline]
        public float4 wxzx =>  float4(w, x, z, x);
        
        /// <summary>
        /// Returns float4.arbr swizzling (equivalent to float4.wxzx).
        /// </summary>
        [Inline]
        public float4 arbr =>  float4(w, x, z, x);
        
        /// <summary>
        /// Returns float4.wxzy swizzling.
        /// </summary>
        [Inline]
        public float4 wxzy =>  float4(w, x, z, y);
        
        /// <summary>
        /// Returns float4.arbg swizzling (equivalent to float4.wxzy).
        /// </summary>
        [Inline]
        public float4 arbg =>  float4(w, x, z, y);
        
        /// <summary>
        /// Returns float4.wxzz swizzling.
        /// </summary>
        [Inline]
        public float4 wxzz =>  float4(w, x, z, z);
        
        /// <summary>
        /// Returns float4.arbb swizzling (equivalent to float4.wxzz).
        /// </summary>
        [Inline]
        public float4 arbb =>  float4(w, x, z, z);
        
        /// <summary>
        /// Returns float4.wxzw swizzling.
        /// </summary>
        [Inline]
        public float4 wxzw =>  float4(w, x, z, w);
        
        /// <summary>
        /// Returns float4.arba swizzling (equivalent to float4.wxzw).
        /// </summary>
        [Inline]
        public float4 arba =>  float4(w, x, z, w);
        
        /// <summary>
        /// Returns float4.wxw swizzling.
        /// </summary>
        [Inline]
        public float3 wxw =>  float3(w, x, w);
        
        /// <summary>
        /// Returns float4.ara swizzling (equivalent to float4.wxw).
        /// </summary>
        [Inline]
        public float3 ara =>  float3(w, x, w);
        
        /// <summary>
        /// Returns float4.wxwx swizzling.
        /// </summary>
        [Inline]
        public float4 wxwx =>  float4(w, x, w, x);
        
        /// <summary>
        /// Returns float4.arar swizzling (equivalent to float4.wxwx).
        /// </summary>
        [Inline]
        public float4 arar =>  float4(w, x, w, x);
        
        /// <summary>
        /// Returns float4.wxwy swizzling.
        /// </summary>
        [Inline]
        public float4 wxwy =>  float4(w, x, w, y);
        
        /// <summary>
        /// Returns float4.arag swizzling (equivalent to float4.wxwy).
        /// </summary>
        [Inline]
        public float4 arag =>  float4(w, x, w, y);
        
        /// <summary>
        /// Returns float4.wxwz swizzling.
        /// </summary>
        [Inline]
        public float4 wxwz =>  float4(w, x, w, z);
        
        /// <summary>
        /// Returns float4.arab swizzling (equivalent to float4.wxwz).
        /// </summary>
        [Inline]
        public float4 arab =>  float4(w, x, w, z);
        
        /// <summary>
        /// Returns float4.wxww swizzling.
        /// </summary>
        [Inline]
        public float4 wxww =>  float4(w, x, w, w);
        
        /// <summary>
        /// Returns float4.araa swizzling (equivalent to float4.wxww).
        /// </summary>
        [Inline]
        public float4 araa =>  float4(w, x, w, w);
        
        /// <summary>
        /// Returns float4.wy swizzling.
        /// </summary>
        [Inline]
        public float2 wy =>  float2(w, y);
        
        /// <summary>
        /// Returns float4.ag swizzling (equivalent to float4.wy).
        /// </summary>
        [Inline]
        public float2 ag =>  float2(w, y);
        
        /// <summary>
        /// Returns float4.wyx swizzling.
        /// </summary>
        [Inline]
        public float3 wyx =>  float3(w, y, x);
        
        /// <summary>
        /// Returns float4.agr swizzling (equivalent to float4.wyx).
        /// </summary>
        [Inline]
        public float3 agr =>  float3(w, y, x);
        
        /// <summary>
        /// Returns float4.wyxx swizzling.
        /// </summary>
        [Inline]
        public float4 wyxx =>  float4(w, y, x, x);
        
        /// <summary>
        /// Returns float4.agrr swizzling (equivalent to float4.wyxx).
        /// </summary>
        [Inline]
        public float4 agrr =>  float4(w, y, x, x);
        
        /// <summary>
        /// Returns float4.wyxy swizzling.
        /// </summary>
        [Inline]
        public float4 wyxy =>  float4(w, y, x, y);
        
        /// <summary>
        /// Returns float4.agrg swizzling (equivalent to float4.wyxy).
        /// </summary>
        [Inline]
        public float4 agrg =>  float4(w, y, x, y);
        
        /// <summary>
        /// Returns float4.wyxz swizzling.
        /// </summary>
        [Inline]
        public float4 wyxz =>  float4(w, y, x, z);
        
        /// <summary>
        /// Returns float4.agrb swizzling (equivalent to float4.wyxz).
        /// </summary>
        [Inline]
        public float4 agrb =>  float4(w, y, x, z);
        
        /// <summary>
        /// Returns float4.wyxw swizzling.
        /// </summary>
        [Inline]
        public float4 wyxw =>  float4(w, y, x, w);
        
        /// <summary>
        /// Returns float4.agra swizzling (equivalent to float4.wyxw).
        /// </summary>
        [Inline]
        public float4 agra =>  float4(w, y, x, w);
        
        /// <summary>
        /// Returns float4.wyy swizzling.
        /// </summary>
        [Inline]
        public float3 wyy =>  float3(w, y, y);
        
        /// <summary>
        /// Returns float4.agg swizzling (equivalent to float4.wyy).
        /// </summary>
        [Inline]
        public float3 agg =>  float3(w, y, y);
        
        /// <summary>
        /// Returns float4.wyyx swizzling.
        /// </summary>
        [Inline]
        public float4 wyyx =>  float4(w, y, y, x);
        
        /// <summary>
        /// Returns float4.aggr swizzling (equivalent to float4.wyyx).
        /// </summary>
        [Inline]
        public float4 aggr =>  float4(w, y, y, x);
        
        /// <summary>
        /// Returns float4.wyyy swizzling.
        /// </summary>
        [Inline]
        public float4 wyyy =>  float4(w, y, y, y);
        
        /// <summary>
        /// Returns float4.aggg swizzling (equivalent to float4.wyyy).
        /// </summary>
        [Inline]
        public float4 aggg =>  float4(w, y, y, y);
        
        /// <summary>
        /// Returns float4.wyyz swizzling.
        /// </summary>
        [Inline]
        public float4 wyyz =>  float4(w, y, y, z);
        
        /// <summary>
        /// Returns float4.aggb swizzling (equivalent to float4.wyyz).
        /// </summary>
        [Inline]
        public float4 aggb =>  float4(w, y, y, z);
        
        /// <summary>
        /// Returns float4.wyyw swizzling.
        /// </summary>
        [Inline]
        public float4 wyyw =>  float4(w, y, y, w);
        
        /// <summary>
        /// Returns float4.agga swizzling (equivalent to float4.wyyw).
        /// </summary>
        [Inline]
        public float4 agga =>  float4(w, y, y, w);
        
        /// <summary>
        /// Returns float4.wyz swizzling.
        /// </summary>
        [Inline]
        public float3 wyz =>  float3(w, y, z);
        
        /// <summary>
        /// Returns float4.agb swizzling (equivalent to float4.wyz).
        /// </summary>
        [Inline]
        public float3 agb =>  float3(w, y, z);
        
        /// <summary>
        /// Returns float4.wyzx swizzling.
        /// </summary>
        [Inline]
        public float4 wyzx =>  float4(w, y, z, x);
        
        /// <summary>
        /// Returns float4.agbr swizzling (equivalent to float4.wyzx).
        /// </summary>
        [Inline]
        public float4 agbr =>  float4(w, y, z, x);
        
        /// <summary>
        /// Returns float4.wyzy swizzling.
        /// </summary>
        [Inline]
        public float4 wyzy =>  float4(w, y, z, y);
        
        /// <summary>
        /// Returns float4.agbg swizzling (equivalent to float4.wyzy).
        /// </summary>
        [Inline]
        public float4 agbg =>  float4(w, y, z, y);
        
        /// <summary>
        /// Returns float4.wyzz swizzling.
        /// </summary>
        [Inline]
        public float4 wyzz =>  float4(w, y, z, z);
        
        /// <summary>
        /// Returns float4.agbb swizzling (equivalent to float4.wyzz).
        /// </summary>
        [Inline]
        public float4 agbb =>  float4(w, y, z, z);
        
        /// <summary>
        /// Returns float4.wyzw swizzling.
        /// </summary>
        [Inline]
        public float4 wyzw =>  float4(w, y, z, w);
        
        /// <summary>
        /// Returns float4.agba swizzling (equivalent to float4.wyzw).
        /// </summary>
        [Inline]
        public float4 agba =>  float4(w, y, z, w);
        
        /// <summary>
        /// Returns float4.wyw swizzling.
        /// </summary>
        [Inline]
        public float3 wyw =>  float3(w, y, w);
        
        /// <summary>
        /// Returns float4.aga swizzling (equivalent to float4.wyw).
        /// </summary>
        [Inline]
        public float3 aga =>  float3(w, y, w);
        
        /// <summary>
        /// Returns float4.wywx swizzling.
        /// </summary>
        [Inline]
        public float4 wywx =>  float4(w, y, w, x);
        
        /// <summary>
        /// Returns float4.agar swizzling (equivalent to float4.wywx).
        /// </summary>
        [Inline]
        public float4 agar =>  float4(w, y, w, x);
        
        /// <summary>
        /// Returns float4.wywy swizzling.
        /// </summary>
        [Inline]
        public float4 wywy =>  float4(w, y, w, y);
        
        /// <summary>
        /// Returns float4.agag swizzling (equivalent to float4.wywy).
        /// </summary>
        [Inline]
        public float4 agag =>  float4(w, y, w, y);
        
        /// <summary>
        /// Returns float4.wywz swizzling.
        /// </summary>
        [Inline]
        public float4 wywz =>  float4(w, y, w, z);
        
        /// <summary>
        /// Returns float4.agab swizzling (equivalent to float4.wywz).
        /// </summary>
        [Inline]
        public float4 agab =>  float4(w, y, w, z);
        
        /// <summary>
        /// Returns float4.wyww swizzling.
        /// </summary>
        [Inline]
        public float4 wyww =>  float4(w, y, w, w);
        
        /// <summary>
        /// Returns float4.agaa swizzling (equivalent to float4.wyww).
        /// </summary>
        [Inline]
        public float4 agaa =>  float4(w, y, w, w);
        
        /// <summary>
        /// Returns float4.wz swizzling.
        /// </summary>
        [Inline]
        public float2 wz =>  float2(w, z);
        
        /// <summary>
        /// Returns float4.ab swizzling (equivalent to float4.wz).
        /// </summary>
        [Inline]
        public float2 ab =>  float2(w, z);
        
        /// <summary>
        /// Returns float4.wzx swizzling.
        /// </summary>
        [Inline]
        public float3 wzx =>  float3(w, z, x);
        
        /// <summary>
        /// Returns float4.abr swizzling (equivalent to float4.wzx).
        /// </summary>
        [Inline]
        public float3 abr =>  float3(w, z, x);
        
        /// <summary>
        /// Returns float4.wzxx swizzling.
        /// </summary>
        [Inline]
        public float4 wzxx =>  float4(w, z, x, x);
        
        /// <summary>
        /// Returns float4.abrr swizzling (equivalent to float4.wzxx).
        /// </summary>
        [Inline]
        public float4 abrr =>  float4(w, z, x, x);
        
        /// <summary>
        /// Returns float4.wzxy swizzling.
        /// </summary>
        [Inline]
        public float4 wzxy =>  float4(w, z, x, y);
        
        /// <summary>
        /// Returns float4.abrg swizzling (equivalent to float4.wzxy).
        /// </summary>
        [Inline]
        public float4 abrg =>  float4(w, z, x, y);
        
        /// <summary>
        /// Returns float4.wzxz swizzling.
        /// </summary>
        [Inline]
        public float4 wzxz =>  float4(w, z, x, z);
        
        /// <summary>
        /// Returns float4.abrb swizzling (equivalent to float4.wzxz).
        /// </summary>
        [Inline]
        public float4 abrb =>  float4(w, z, x, z);
        
        /// <summary>
        /// Returns float4.wzxw swizzling.
        /// </summary>
        [Inline]
        public float4 wzxw =>  float4(w, z, x, w);
        
        /// <summary>
        /// Returns float4.abra swizzling (equivalent to float4.wzxw).
        /// </summary>
        [Inline]
        public float4 abra =>  float4(w, z, x, w);
        
        /// <summary>
        /// Returns float4.wzy swizzling.
        /// </summary>
        [Inline]
        public float3 wzy =>  float3(w, z, y);
        
        /// <summary>
        /// Returns float4.abg swizzling (equivalent to float4.wzy).
        /// </summary>
        [Inline]
        public float3 abg =>  float3(w, z, y);
        
        /// <summary>
        /// Returns float4.wzyx swizzling.
        /// </summary>
        [Inline]
        public float4 wzyx =>  float4(w, z, y, x);
        
        /// <summary>
        /// Returns float4.abgr swizzling (equivalent to float4.wzyx).
        /// </summary>
        [Inline]
        public float4 abgr =>  float4(w, z, y, x);
        
        /// <summary>
        /// Returns float4.wzyy swizzling.
        /// </summary>
        [Inline]
        public float4 wzyy =>  float4(w, z, y, y);
        
        /// <summary>
        /// Returns float4.abgg swizzling (equivalent to float4.wzyy).
        /// </summary>
        [Inline]
        public float4 abgg =>  float4(w, z, y, y);
        
        /// <summary>
        /// Returns float4.wzyz swizzling.
        /// </summary>
        [Inline]
        public float4 wzyz =>  float4(w, z, y, z);
        
        /// <summary>
        /// Returns float4.abgb swizzling (equivalent to float4.wzyz).
        /// </summary>
        [Inline]
        public float4 abgb =>  float4(w, z, y, z);
        
        /// <summary>
        /// Returns float4.wzyw swizzling.
        /// </summary>
        [Inline]
        public float4 wzyw =>  float4(w, z, y, w);
        
        /// <summary>
        /// Returns float4.abga swizzling (equivalent to float4.wzyw).
        /// </summary>
        [Inline]
        public float4 abga =>  float4(w, z, y, w);
        
        /// <summary>
        /// Returns float4.wzz swizzling.
        /// </summary>
        [Inline]
        public float3 wzz =>  float3(w, z, z);
        
        /// <summary>
        /// Returns float4.abb swizzling (equivalent to float4.wzz).
        /// </summary>
        [Inline]
        public float3 abb =>  float3(w, z, z);
        
        /// <summary>
        /// Returns float4.wzzx swizzling.
        /// </summary>
        [Inline]
        public float4 wzzx =>  float4(w, z, z, x);
        
        /// <summary>
        /// Returns float4.abbr swizzling (equivalent to float4.wzzx).
        /// </summary>
        [Inline]
        public float4 abbr =>  float4(w, z, z, x);
        
        /// <summary>
        /// Returns float4.wzzy swizzling.
        /// </summary>
        [Inline]
        public float4 wzzy =>  float4(w, z, z, y);
        
        /// <summary>
        /// Returns float4.abbg swizzling (equivalent to float4.wzzy).
        /// </summary>
        [Inline]
        public float4 abbg =>  float4(w, z, z, y);
        
        /// <summary>
        /// Returns float4.wzzz swizzling.
        /// </summary>
        [Inline]
        public float4 wzzz =>  float4(w, z, z, z);
        
        /// <summary>
        /// Returns float4.abbb swizzling (equivalent to float4.wzzz).
        /// </summary>
        [Inline]
        public float4 abbb =>  float4(w, z, z, z);
        
        /// <summary>
        /// Returns float4.wzzw swizzling.
        /// </summary>
        [Inline]
        public float4 wzzw =>  float4(w, z, z, w);
        
        /// <summary>
        /// Returns float4.abba swizzling (equivalent to float4.wzzw).
        /// </summary>
        [Inline]
        public float4 abba =>  float4(w, z, z, w);
        
        /// <summary>
        /// Returns float4.wzw swizzling.
        /// </summary>
        [Inline]
        public float3 wzw =>  float3(w, z, w);
        
        /// <summary>
        /// Returns float4.aba swizzling (equivalent to float4.wzw).
        /// </summary>
        [Inline]
        public float3 aba =>  float3(w, z, w);
        
        /// <summary>
        /// Returns float4.wzwx swizzling.
        /// </summary>
        [Inline]
        public float4 wzwx =>  float4(w, z, w, x);
        
        /// <summary>
        /// Returns float4.abar swizzling (equivalent to float4.wzwx).
        /// </summary>
        [Inline]
        public float4 abar =>  float4(w, z, w, x);
        
        /// <summary>
        /// Returns float4.wzwy swizzling.
        /// </summary>
        [Inline]
        public float4 wzwy =>  float4(w, z, w, y);
        
        /// <summary>
        /// Returns float4.abag swizzling (equivalent to float4.wzwy).
        /// </summary>
        [Inline]
        public float4 abag =>  float4(w, z, w, y);
        
        /// <summary>
        /// Returns float4.wzwz swizzling.
        /// </summary>
        [Inline]
        public float4 wzwz =>  float4(w, z, w, z);
        
        /// <summary>
        /// Returns float4.abab swizzling (equivalent to float4.wzwz).
        /// </summary>
        [Inline]
        public float4 abab =>  float4(w, z, w, z);
        
        /// <summary>
        /// Returns float4.wzww swizzling.
        /// </summary>
        [Inline]
        public float4 wzww =>  float4(w, z, w, w);
        
        /// <summary>
        /// Returns float4.abaa swizzling (equivalent to float4.wzww).
        /// </summary>
        [Inline]
        public float4 abaa =>  float4(w, z, w, w);
        
        /// <summary>
        /// Returns float4.ww swizzling.
        /// </summary>
        [Inline]
        public float2 ww =>  float2(w, w);
        
        /// <summary>
        /// Returns float4.aa swizzling (equivalent to float4.ww).
        /// </summary>
        [Inline]
        public float2 aa =>  float2(w, w);
        
        /// <summary>
        /// Returns float4.wwx swizzling.
        /// </summary>
        [Inline]
        public float3 wwx =>  float3(w, w, x);
        
        /// <summary>
        /// Returns float4.aar swizzling (equivalent to float4.wwx).
        /// </summary>
        [Inline]
        public float3 aar =>  float3(w, w, x);
        
        /// <summary>
        /// Returns float4.wwxx swizzling.
        /// </summary>
        [Inline]
        public float4 wwxx =>  float4(w, w, x, x);
        
        /// <summary>
        /// Returns float4.aarr swizzling (equivalent to float4.wwxx).
        /// </summary>
        [Inline]
        public float4 aarr =>  float4(w, w, x, x);
        
        /// <summary>
        /// Returns float4.wwxy swizzling.
        /// </summary>
        [Inline]
        public float4 wwxy =>  float4(w, w, x, y);
        
        /// <summary>
        /// Returns float4.aarg swizzling (equivalent to float4.wwxy).
        /// </summary>
        [Inline]
        public float4 aarg =>  float4(w, w, x, y);
        
        /// <summary>
        /// Returns float4.wwxz swizzling.
        /// </summary>
        [Inline]
        public float4 wwxz =>  float4(w, w, x, z);
        
        /// <summary>
        /// Returns float4.aarb swizzling (equivalent to float4.wwxz).
        /// </summary>
        [Inline]
        public float4 aarb =>  float4(w, w, x, z);
        
        /// <summary>
        /// Returns float4.wwxw swizzling.
        /// </summary>
        [Inline]
        public float4 wwxw =>  float4(w, w, x, w);
        
        /// <summary>
        /// Returns float4.aara swizzling (equivalent to float4.wwxw).
        /// </summary>
        [Inline]
        public float4 aara =>  float4(w, w, x, w);
        
        /// <summary>
        /// Returns float4.wwy swizzling.
        /// </summary>
        [Inline]
        public float3 wwy =>  float3(w, w, y);
        
        /// <summary>
        /// Returns float4.aag swizzling (equivalent to float4.wwy).
        /// </summary>
        [Inline]
        public float3 aag =>  float3(w, w, y);
        
        /// <summary>
        /// Returns float4.wwyx swizzling.
        /// </summary>
        [Inline]
        public float4 wwyx =>  float4(w, w, y, x);
        
        /// <summary>
        /// Returns float4.aagr swizzling (equivalent to float4.wwyx).
        /// </summary>
        [Inline]
        public float4 aagr =>  float4(w, w, y, x);
        
        /// <summary>
        /// Returns float4.wwyy swizzling.
        /// </summary>
        [Inline]
        public float4 wwyy =>  float4(w, w, y, y);
        
        /// <summary>
        /// Returns float4.aagg swizzling (equivalent to float4.wwyy).
        /// </summary>
        [Inline]
        public float4 aagg =>  float4(w, w, y, y);
        
        /// <summary>
        /// Returns float4.wwyz swizzling.
        /// </summary>
        [Inline]
        public float4 wwyz =>  float4(w, w, y, z);
        
        /// <summary>
        /// Returns float4.aagb swizzling (equivalent to float4.wwyz).
        /// </summary>
        [Inline]
        public float4 aagb =>  float4(w, w, y, z);
        
        /// <summary>
        /// Returns float4.wwyw swizzling.
        /// </summary>
        [Inline]
        public float4 wwyw =>  float4(w, w, y, w);
        
        /// <summary>
        /// Returns float4.aaga swizzling (equivalent to float4.wwyw).
        /// </summary>
        [Inline]
        public float4 aaga =>  float4(w, w, y, w);
        
        /// <summary>
        /// Returns float4.wwz swizzling.
        /// </summary>
        [Inline]
        public float3 wwz =>  float3(w, w, z);
        
        /// <summary>
        /// Returns float4.aab swizzling (equivalent to float4.wwz).
        /// </summary>
        [Inline]
        public float3 aab =>  float3(w, w, z);
        
        /// <summary>
        /// Returns float4.wwzx swizzling.
        /// </summary>
        [Inline]
        public float4 wwzx =>  float4(w, w, z, x);
        
        /// <summary>
        /// Returns float4.aabr swizzling (equivalent to float4.wwzx).
        /// </summary>
        [Inline]
        public float4 aabr =>  float4(w, w, z, x);
        
        /// <summary>
        /// Returns float4.wwzy swizzling.
        /// </summary>
        [Inline]
        public float4 wwzy =>  float4(w, w, z, y);
        
        /// <summary>
        /// Returns float4.aabg swizzling (equivalent to float4.wwzy).
        /// </summary>
        [Inline]
        public float4 aabg =>  float4(w, w, z, y);
        
        /// <summary>
        /// Returns float4.wwzz swizzling.
        /// </summary>
        [Inline]
        public float4 wwzz =>  float4(w, w, z, z);
        
        /// <summary>
        /// Returns float4.aabb swizzling (equivalent to float4.wwzz).
        /// </summary>
        [Inline]
        public float4 aabb =>  float4(w, w, z, z);
        
        /// <summary>
        /// Returns float4.wwzw swizzling.
        /// </summary>
        [Inline]
        public float4 wwzw =>  float4(w, w, z, w);
        
        /// <summary>
        /// Returns float4.aaba swizzling (equivalent to float4.wwzw).
        /// </summary>
        [Inline]
        public float4 aaba =>  float4(w, w, z, w);
        
        /// <summary>
        /// Returns float4.www swizzling.
        /// </summary>
        [Inline]
        public float3 www =>  float3(w, w, w);
        
        /// <summary>
        /// Returns float4.aaa swizzling (equivalent to float4.www).
        /// </summary>
        [Inline]
        public float3 aaa =>  float3(w, w, w);
        
        /// <summary>
        /// Returns float4.wwwx swizzling.
        /// </summary>
        [Inline]
        public float4 wwwx =>  float4(w, w, w, x);
        
        /// <summary>
        /// Returns float4.aaar swizzling (equivalent to float4.wwwx).
        /// </summary>
        [Inline]
        public float4 aaar =>  float4(w, w, w, x);
        
        /// <summary>
        /// Returns float4.wwwy swizzling.
        /// </summary>
        [Inline]
        public float4 wwwy =>  float4(w, w, w, y);
        
        /// <summary>
        /// Returns float4.aaag swizzling (equivalent to float4.wwwy).
        /// </summary>
        [Inline]
        public float4 aaag =>  float4(w, w, w, y);
        
        /// <summary>
        /// Returns float4.wwwz swizzling.
        /// </summary>
        [Inline]
        public float4 wwwz =>  float4(w, w, w, z);
        
        /// <summary>
        /// Returns float4.aaab swizzling (equivalent to float4.wwwz).
        /// </summary>
        [Inline]
        public float4 aaab =>  float4(w, w, w, z);
        
        /// <summary>
        /// Returns float4.wwww swizzling.
        /// </summary>
        [Inline]
        public float4 wwww =>  float4(w, w, w, w);
        
        /// <summary>
        /// Returns float4.aaaa swizzling (equivalent to float4.wwww).
        /// </summary>
        [Inline]
        public float4 aaaa =>  float4(w, w, w, w);

        //#endregion

    }
}
