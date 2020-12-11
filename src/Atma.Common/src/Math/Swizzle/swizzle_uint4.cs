using System;
namespace Atma
{
    
    /// <summary>
    /// Temporary vector of type uint with 4 components, used for implementing swizzling for uint4.
    /// </summary>
    public struct swizzle_uint4
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
        
        /// <summary>
        /// w-component
        /// </summary>
        private readonly uint w;

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Returns uint4.xx swizzling.
        /// </summary>
        [Inline]
        public uint2 xx =>  uint2(x, x);
        
        /// <summary>
        /// Returns uint4.rr swizzling (equivalent to uint4.xx).
        /// </summary>
        [Inline]
        public uint2 rr =>  uint2(x, x);
        
        /// <summary>
        /// Returns uint4.xxx swizzling.
        /// </summary>
        [Inline]
        public uint3 xxx =>  uint3(x, x, x);
        
        /// <summary>
        /// Returns uint4.rrr swizzling (equivalent to uint4.xxx).
        /// </summary>
        [Inline]
        public uint3 rrr =>  uint3(x, x, x);
        
        /// <summary>
        /// Returns uint4.xxxx swizzling.
        /// </summary>
        [Inline]
        public uint4 xxxx =>  uint4(x, x, x, x);
        
        /// <summary>
        /// Returns uint4.rrrr swizzling (equivalent to uint4.xxxx).
        /// </summary>
        [Inline]
        public uint4 rrrr =>  uint4(x, x, x, x);
        
        /// <summary>
        /// Returns uint4.xxxy swizzling.
        /// </summary>
        [Inline]
        public uint4 xxxy =>  uint4(x, x, x, y);
        
        /// <summary>
        /// Returns uint4.rrrg swizzling (equivalent to uint4.xxxy).
        /// </summary>
        [Inline]
        public uint4 rrrg =>  uint4(x, x, x, y);
        
        /// <summary>
        /// Returns uint4.xxxz swizzling.
        /// </summary>
        [Inline]
        public uint4 xxxz =>  uint4(x, x, x, z);
        
        /// <summary>
        /// Returns uint4.rrrb swizzling (equivalent to uint4.xxxz).
        /// </summary>
        [Inline]
        public uint4 rrrb =>  uint4(x, x, x, z);
        
        /// <summary>
        /// Returns uint4.xxxw swizzling.
        /// </summary>
        [Inline]
        public uint4 xxxw =>  uint4(x, x, x, w);
        
        /// <summary>
        /// Returns uint4.rrra swizzling (equivalent to uint4.xxxw).
        /// </summary>
        [Inline]
        public uint4 rrra =>  uint4(x, x, x, w);
        
        /// <summary>
        /// Returns uint4.xxy swizzling.
        /// </summary>
        [Inline]
        public uint3 xxy =>  uint3(x, x, y);
        
        /// <summary>
        /// Returns uint4.rrg swizzling (equivalent to uint4.xxy).
        /// </summary>
        [Inline]
        public uint3 rrg =>  uint3(x, x, y);
        
        /// <summary>
        /// Returns uint4.xxyx swizzling.
        /// </summary>
        [Inline]
        public uint4 xxyx =>  uint4(x, x, y, x);
        
        /// <summary>
        /// Returns uint4.rrgr swizzling (equivalent to uint4.xxyx).
        /// </summary>
        [Inline]
        public uint4 rrgr =>  uint4(x, x, y, x);
        
        /// <summary>
        /// Returns uint4.xxyy swizzling.
        /// </summary>
        [Inline]
        public uint4 xxyy =>  uint4(x, x, y, y);
        
        /// <summary>
        /// Returns uint4.rrgg swizzling (equivalent to uint4.xxyy).
        /// </summary>
        [Inline]
        public uint4 rrgg =>  uint4(x, x, y, y);
        
        /// <summary>
        /// Returns uint4.xxyz swizzling.
        /// </summary>
        [Inline]
        public uint4 xxyz =>  uint4(x, x, y, z);
        
        /// <summary>
        /// Returns uint4.rrgb swizzling (equivalent to uint4.xxyz).
        /// </summary>
        [Inline]
        public uint4 rrgb =>  uint4(x, x, y, z);
        
        /// <summary>
        /// Returns uint4.xxyw swizzling.
        /// </summary>
        [Inline]
        public uint4 xxyw =>  uint4(x, x, y, w);
        
        /// <summary>
        /// Returns uint4.rrga swizzling (equivalent to uint4.xxyw).
        /// </summary>
        [Inline]
        public uint4 rrga =>  uint4(x, x, y, w);
        
        /// <summary>
        /// Returns uint4.xxz swizzling.
        /// </summary>
        [Inline]
        public uint3 xxz =>  uint3(x, x, z);
        
        /// <summary>
        /// Returns uint4.rrb swizzling (equivalent to uint4.xxz).
        /// </summary>
        [Inline]
        public uint3 rrb =>  uint3(x, x, z);
        
        /// <summary>
        /// Returns uint4.xxzx swizzling.
        /// </summary>
        [Inline]
        public uint4 xxzx =>  uint4(x, x, z, x);
        
        /// <summary>
        /// Returns uint4.rrbr swizzling (equivalent to uint4.xxzx).
        /// </summary>
        [Inline]
        public uint4 rrbr =>  uint4(x, x, z, x);
        
        /// <summary>
        /// Returns uint4.xxzy swizzling.
        /// </summary>
        [Inline]
        public uint4 xxzy =>  uint4(x, x, z, y);
        
        /// <summary>
        /// Returns uint4.rrbg swizzling (equivalent to uint4.xxzy).
        /// </summary>
        [Inline]
        public uint4 rrbg =>  uint4(x, x, z, y);
        
        /// <summary>
        /// Returns uint4.xxzz swizzling.
        /// </summary>
        [Inline]
        public uint4 xxzz =>  uint4(x, x, z, z);
        
        /// <summary>
        /// Returns uint4.rrbb swizzling (equivalent to uint4.xxzz).
        /// </summary>
        [Inline]
        public uint4 rrbb =>  uint4(x, x, z, z);
        
        /// <summary>
        /// Returns uint4.xxzw swizzling.
        /// </summary>
        [Inline]
        public uint4 xxzw =>  uint4(x, x, z, w);
        
        /// <summary>
        /// Returns uint4.rrba swizzling (equivalent to uint4.xxzw).
        /// </summary>
        [Inline]
        public uint4 rrba =>  uint4(x, x, z, w);
        
        /// <summary>
        /// Returns uint4.xxw swizzling.
        /// </summary>
        [Inline]
        public uint3 xxw =>  uint3(x, x, w);
        
        /// <summary>
        /// Returns uint4.rra swizzling (equivalent to uint4.xxw).
        /// </summary>
        [Inline]
        public uint3 rra =>  uint3(x, x, w);
        
        /// <summary>
        /// Returns uint4.xxwx swizzling.
        /// </summary>
        [Inline]
        public uint4 xxwx =>  uint4(x, x, w, x);
        
        /// <summary>
        /// Returns uint4.rrar swizzling (equivalent to uint4.xxwx).
        /// </summary>
        [Inline]
        public uint4 rrar =>  uint4(x, x, w, x);
        
        /// <summary>
        /// Returns uint4.xxwy swizzling.
        /// </summary>
        [Inline]
        public uint4 xxwy =>  uint4(x, x, w, y);
        
        /// <summary>
        /// Returns uint4.rrag swizzling (equivalent to uint4.xxwy).
        /// </summary>
        [Inline]
        public uint4 rrag =>  uint4(x, x, w, y);
        
        /// <summary>
        /// Returns uint4.xxwz swizzling.
        /// </summary>
        [Inline]
        public uint4 xxwz =>  uint4(x, x, w, z);
        
        /// <summary>
        /// Returns uint4.rrab swizzling (equivalent to uint4.xxwz).
        /// </summary>
        [Inline]
        public uint4 rrab =>  uint4(x, x, w, z);
        
        /// <summary>
        /// Returns uint4.xxww swizzling.
        /// </summary>
        [Inline]
        public uint4 xxww =>  uint4(x, x, w, w);
        
        /// <summary>
        /// Returns uint4.rraa swizzling (equivalent to uint4.xxww).
        /// </summary>
        [Inline]
        public uint4 rraa =>  uint4(x, x, w, w);
        
        /// <summary>
        /// Returns uint4.xy swizzling.
        /// </summary>
        [Inline]
        public uint2 xy =>  uint2(x, y);
        
        /// <summary>
        /// Returns uint4.rg swizzling (equivalent to uint4.xy).
        /// </summary>
        [Inline]
        public uint2 rg =>  uint2(x, y);
        
        /// <summary>
        /// Returns uint4.xyx swizzling.
        /// </summary>
        [Inline]
        public uint3 xyx =>  uint3(x, y, x);
        
        /// <summary>
        /// Returns uint4.rgr swizzling (equivalent to uint4.xyx).
        /// </summary>
        [Inline]
        public uint3 rgr =>  uint3(x, y, x);
        
        /// <summary>
        /// Returns uint4.xyxx swizzling.
        /// </summary>
        [Inline]
        public uint4 xyxx =>  uint4(x, y, x, x);
        
        /// <summary>
        /// Returns uint4.rgrr swizzling (equivalent to uint4.xyxx).
        /// </summary>
        [Inline]
        public uint4 rgrr =>  uint4(x, y, x, x);
        
        /// <summary>
        /// Returns uint4.xyxy swizzling.
        /// </summary>
        [Inline]
        public uint4 xyxy =>  uint4(x, y, x, y);
        
        /// <summary>
        /// Returns uint4.rgrg swizzling (equivalent to uint4.xyxy).
        /// </summary>
        [Inline]
        public uint4 rgrg =>  uint4(x, y, x, y);
        
        /// <summary>
        /// Returns uint4.xyxz swizzling.
        /// </summary>
        [Inline]
        public uint4 xyxz =>  uint4(x, y, x, z);
        
        /// <summary>
        /// Returns uint4.rgrb swizzling (equivalent to uint4.xyxz).
        /// </summary>
        [Inline]
        public uint4 rgrb =>  uint4(x, y, x, z);
        
        /// <summary>
        /// Returns uint4.xyxw swizzling.
        /// </summary>
        [Inline]
        public uint4 xyxw =>  uint4(x, y, x, w);
        
        /// <summary>
        /// Returns uint4.rgra swizzling (equivalent to uint4.xyxw).
        /// </summary>
        [Inline]
        public uint4 rgra =>  uint4(x, y, x, w);
        
        /// <summary>
        /// Returns uint4.xyy swizzling.
        /// </summary>
        [Inline]
        public uint3 xyy =>  uint3(x, y, y);
        
        /// <summary>
        /// Returns uint4.rgg swizzling (equivalent to uint4.xyy).
        /// </summary>
        [Inline]
        public uint3 rgg =>  uint3(x, y, y);
        
        /// <summary>
        /// Returns uint4.xyyx swizzling.
        /// </summary>
        [Inline]
        public uint4 xyyx =>  uint4(x, y, y, x);
        
        /// <summary>
        /// Returns uint4.rggr swizzling (equivalent to uint4.xyyx).
        /// </summary>
        [Inline]
        public uint4 rggr =>  uint4(x, y, y, x);
        
        /// <summary>
        /// Returns uint4.xyyy swizzling.
        /// </summary>
        [Inline]
        public uint4 xyyy =>  uint4(x, y, y, y);
        
        /// <summary>
        /// Returns uint4.rggg swizzling (equivalent to uint4.xyyy).
        /// </summary>
        [Inline]
        public uint4 rggg =>  uint4(x, y, y, y);
        
        /// <summary>
        /// Returns uint4.xyyz swizzling.
        /// </summary>
        [Inline]
        public uint4 xyyz =>  uint4(x, y, y, z);
        
        /// <summary>
        /// Returns uint4.rggb swizzling (equivalent to uint4.xyyz).
        /// </summary>
        [Inline]
        public uint4 rggb =>  uint4(x, y, y, z);
        
        /// <summary>
        /// Returns uint4.xyyw swizzling.
        /// </summary>
        [Inline]
        public uint4 xyyw =>  uint4(x, y, y, w);
        
        /// <summary>
        /// Returns uint4.rgga swizzling (equivalent to uint4.xyyw).
        /// </summary>
        [Inline]
        public uint4 rgga =>  uint4(x, y, y, w);
        
        /// <summary>
        /// Returns uint4.xyz swizzling.
        /// </summary>
        [Inline]
        public uint3 xyz =>  uint3(x, y, z);
        
        /// <summary>
        /// Returns uint4.rgb swizzling (equivalent to uint4.xyz).
        /// </summary>
        [Inline]
        public uint3 rgb =>  uint3(x, y, z);
        
        /// <summary>
        /// Returns uint4.xyzx swizzling.
        /// </summary>
        [Inline]
        public uint4 xyzx =>  uint4(x, y, z, x);
        
        /// <summary>
        /// Returns uint4.rgbr swizzling (equivalent to uint4.xyzx).
        /// </summary>
        [Inline]
        public uint4 rgbr =>  uint4(x, y, z, x);
        
        /// <summary>
        /// Returns uint4.xyzy swizzling.
        /// </summary>
        [Inline]
        public uint4 xyzy =>  uint4(x, y, z, y);
        
        /// <summary>
        /// Returns uint4.rgbg swizzling (equivalent to uint4.xyzy).
        /// </summary>
        [Inline]
        public uint4 rgbg =>  uint4(x, y, z, y);
        
        /// <summary>
        /// Returns uint4.xyzz swizzling.
        /// </summary>
        [Inline]
        public uint4 xyzz =>  uint4(x, y, z, z);
        
        /// <summary>
        /// Returns uint4.rgbb swizzling (equivalent to uint4.xyzz).
        /// </summary>
        [Inline]
        public uint4 rgbb =>  uint4(x, y, z, z);
        
        /// <summary>
        /// Returns uint4.xyzw swizzling.
        /// </summary>
        [Inline]
        public uint4 xyzw =>  uint4(x, y, z, w);
        
        /// <summary>
        /// Returns uint4.rgba swizzling (equivalent to uint4.xyzw).
        /// </summary>
        [Inline]
        public uint4 rgba =>  uint4(x, y, z, w);
        
        /// <summary>
        /// Returns uint4.xyw swizzling.
        /// </summary>
        [Inline]
        public uint3 xyw =>  uint3(x, y, w);
        
        /// <summary>
        /// Returns uint4.rga swizzling (equivalent to uint4.xyw).
        /// </summary>
        [Inline]
        public uint3 rga =>  uint3(x, y, w);
        
        /// <summary>
        /// Returns uint4.xywx swizzling.
        /// </summary>
        [Inline]
        public uint4 xywx =>  uint4(x, y, w, x);
        
        /// <summary>
        /// Returns uint4.rgar swizzling (equivalent to uint4.xywx).
        /// </summary>
        [Inline]
        public uint4 rgar =>  uint4(x, y, w, x);
        
        /// <summary>
        /// Returns uint4.xywy swizzling.
        /// </summary>
        [Inline]
        public uint4 xywy =>  uint4(x, y, w, y);
        
        /// <summary>
        /// Returns uint4.rgag swizzling (equivalent to uint4.xywy).
        /// </summary>
        [Inline]
        public uint4 rgag =>  uint4(x, y, w, y);
        
        /// <summary>
        /// Returns uint4.xywz swizzling.
        /// </summary>
        [Inline]
        public uint4 xywz =>  uint4(x, y, w, z);
        
        /// <summary>
        /// Returns uint4.rgab swizzling (equivalent to uint4.xywz).
        /// </summary>
        [Inline]
        public uint4 rgab =>  uint4(x, y, w, z);
        
        /// <summary>
        /// Returns uint4.xyww swizzling.
        /// </summary>
        [Inline]
        public uint4 xyww =>  uint4(x, y, w, w);
        
        /// <summary>
        /// Returns uint4.rgaa swizzling (equivalent to uint4.xyww).
        /// </summary>
        [Inline]
        public uint4 rgaa =>  uint4(x, y, w, w);
        
        /// <summary>
        /// Returns uint4.xz swizzling.
        /// </summary>
        [Inline]
        public uint2 xz =>  uint2(x, z);
        
        /// <summary>
        /// Returns uint4.rb swizzling (equivalent to uint4.xz).
        /// </summary>
        [Inline]
        public uint2 rb =>  uint2(x, z);
        
        /// <summary>
        /// Returns uint4.xzx swizzling.
        /// </summary>
        [Inline]
        public uint3 xzx =>  uint3(x, z, x);
        
        /// <summary>
        /// Returns uint4.rbr swizzling (equivalent to uint4.xzx).
        /// </summary>
        [Inline]
        public uint3 rbr =>  uint3(x, z, x);
        
        /// <summary>
        /// Returns uint4.xzxx swizzling.
        /// </summary>
        [Inline]
        public uint4 xzxx =>  uint4(x, z, x, x);
        
        /// <summary>
        /// Returns uint4.rbrr swizzling (equivalent to uint4.xzxx).
        /// </summary>
        [Inline]
        public uint4 rbrr =>  uint4(x, z, x, x);
        
        /// <summary>
        /// Returns uint4.xzxy swizzling.
        /// </summary>
        [Inline]
        public uint4 xzxy =>  uint4(x, z, x, y);
        
        /// <summary>
        /// Returns uint4.rbrg swizzling (equivalent to uint4.xzxy).
        /// </summary>
        [Inline]
        public uint4 rbrg =>  uint4(x, z, x, y);
        
        /// <summary>
        /// Returns uint4.xzxz swizzling.
        /// </summary>
        [Inline]
        public uint4 xzxz =>  uint4(x, z, x, z);
        
        /// <summary>
        /// Returns uint4.rbrb swizzling (equivalent to uint4.xzxz).
        /// </summary>
        [Inline]
        public uint4 rbrb =>  uint4(x, z, x, z);
        
        /// <summary>
        /// Returns uint4.xzxw swizzling.
        /// </summary>
        [Inline]
        public uint4 xzxw =>  uint4(x, z, x, w);
        
        /// <summary>
        /// Returns uint4.rbra swizzling (equivalent to uint4.xzxw).
        /// </summary>
        [Inline]
        public uint4 rbra =>  uint4(x, z, x, w);
        
        /// <summary>
        /// Returns uint4.xzy swizzling.
        /// </summary>
        [Inline]
        public uint3 xzy =>  uint3(x, z, y);
        
        /// <summary>
        /// Returns uint4.rbg swizzling (equivalent to uint4.xzy).
        /// </summary>
        [Inline]
        public uint3 rbg =>  uint3(x, z, y);
        
        /// <summary>
        /// Returns uint4.xzyx swizzling.
        /// </summary>
        [Inline]
        public uint4 xzyx =>  uint4(x, z, y, x);
        
        /// <summary>
        /// Returns uint4.rbgr swizzling (equivalent to uint4.xzyx).
        /// </summary>
        [Inline]
        public uint4 rbgr =>  uint4(x, z, y, x);
        
        /// <summary>
        /// Returns uint4.xzyy swizzling.
        /// </summary>
        [Inline]
        public uint4 xzyy =>  uint4(x, z, y, y);
        
        /// <summary>
        /// Returns uint4.rbgg swizzling (equivalent to uint4.xzyy).
        /// </summary>
        [Inline]
        public uint4 rbgg =>  uint4(x, z, y, y);
        
        /// <summary>
        /// Returns uint4.xzyz swizzling.
        /// </summary>
        [Inline]
        public uint4 xzyz =>  uint4(x, z, y, z);
        
        /// <summary>
        /// Returns uint4.rbgb swizzling (equivalent to uint4.xzyz).
        /// </summary>
        [Inline]
        public uint4 rbgb =>  uint4(x, z, y, z);
        
        /// <summary>
        /// Returns uint4.xzyw swizzling.
        /// </summary>
        [Inline]
        public uint4 xzyw =>  uint4(x, z, y, w);
        
        /// <summary>
        /// Returns uint4.rbga swizzling (equivalent to uint4.xzyw).
        /// </summary>
        [Inline]
        public uint4 rbga =>  uint4(x, z, y, w);
        
        /// <summary>
        /// Returns uint4.xzz swizzling.
        /// </summary>
        [Inline]
        public uint3 xzz =>  uint3(x, z, z);
        
        /// <summary>
        /// Returns uint4.rbb swizzling (equivalent to uint4.xzz).
        /// </summary>
        [Inline]
        public uint3 rbb =>  uint3(x, z, z);
        
        /// <summary>
        /// Returns uint4.xzzx swizzling.
        /// </summary>
        [Inline]
        public uint4 xzzx =>  uint4(x, z, z, x);
        
        /// <summary>
        /// Returns uint4.rbbr swizzling (equivalent to uint4.xzzx).
        /// </summary>
        [Inline]
        public uint4 rbbr =>  uint4(x, z, z, x);
        
        /// <summary>
        /// Returns uint4.xzzy swizzling.
        /// </summary>
        [Inline]
        public uint4 xzzy =>  uint4(x, z, z, y);
        
        /// <summary>
        /// Returns uint4.rbbg swizzling (equivalent to uint4.xzzy).
        /// </summary>
        [Inline]
        public uint4 rbbg =>  uint4(x, z, z, y);
        
        /// <summary>
        /// Returns uint4.xzzz swizzling.
        /// </summary>
        [Inline]
        public uint4 xzzz =>  uint4(x, z, z, z);
        
        /// <summary>
        /// Returns uint4.rbbb swizzling (equivalent to uint4.xzzz).
        /// </summary>
        [Inline]
        public uint4 rbbb =>  uint4(x, z, z, z);
        
        /// <summary>
        /// Returns uint4.xzzw swizzling.
        /// </summary>
        [Inline]
        public uint4 xzzw =>  uint4(x, z, z, w);
        
        /// <summary>
        /// Returns uint4.rbba swizzling (equivalent to uint4.xzzw).
        /// </summary>
        [Inline]
        public uint4 rbba =>  uint4(x, z, z, w);
        
        /// <summary>
        /// Returns uint4.xzw swizzling.
        /// </summary>
        [Inline]
        public uint3 xzw =>  uint3(x, z, w);
        
        /// <summary>
        /// Returns uint4.rba swizzling (equivalent to uint4.xzw).
        /// </summary>
        [Inline]
        public uint3 rba =>  uint3(x, z, w);
        
        /// <summary>
        /// Returns uint4.xzwx swizzling.
        /// </summary>
        [Inline]
        public uint4 xzwx =>  uint4(x, z, w, x);
        
        /// <summary>
        /// Returns uint4.rbar swizzling (equivalent to uint4.xzwx).
        /// </summary>
        [Inline]
        public uint4 rbar =>  uint4(x, z, w, x);
        
        /// <summary>
        /// Returns uint4.xzwy swizzling.
        /// </summary>
        [Inline]
        public uint4 xzwy =>  uint4(x, z, w, y);
        
        /// <summary>
        /// Returns uint4.rbag swizzling (equivalent to uint4.xzwy).
        /// </summary>
        [Inline]
        public uint4 rbag =>  uint4(x, z, w, y);
        
        /// <summary>
        /// Returns uint4.xzwz swizzling.
        /// </summary>
        [Inline]
        public uint4 xzwz =>  uint4(x, z, w, z);
        
        /// <summary>
        /// Returns uint4.rbab swizzling (equivalent to uint4.xzwz).
        /// </summary>
        [Inline]
        public uint4 rbab =>  uint4(x, z, w, z);
        
        /// <summary>
        /// Returns uint4.xzww swizzling.
        /// </summary>
        [Inline]
        public uint4 xzww =>  uint4(x, z, w, w);
        
        /// <summary>
        /// Returns uint4.rbaa swizzling (equivalent to uint4.xzww).
        /// </summary>
        [Inline]
        public uint4 rbaa =>  uint4(x, z, w, w);
        
        /// <summary>
        /// Returns uint4.xw swizzling.
        /// </summary>
        [Inline]
        public uint2 xw =>  uint2(x, w);
        
        /// <summary>
        /// Returns uint4.ra swizzling (equivalent to uint4.xw).
        /// </summary>
        [Inline]
        public uint2 ra =>  uint2(x, w);
        
        /// <summary>
        /// Returns uint4.xwx swizzling.
        /// </summary>
        [Inline]
        public uint3 xwx =>  uint3(x, w, x);
        
        /// <summary>
        /// Returns uint4.rar swizzling (equivalent to uint4.xwx).
        /// </summary>
        [Inline]
        public uint3 rar =>  uint3(x, w, x);
        
        /// <summary>
        /// Returns uint4.xwxx swizzling.
        /// </summary>
        [Inline]
        public uint4 xwxx =>  uint4(x, w, x, x);
        
        /// <summary>
        /// Returns uint4.rarr swizzling (equivalent to uint4.xwxx).
        /// </summary>
        [Inline]
        public uint4 rarr =>  uint4(x, w, x, x);
        
        /// <summary>
        /// Returns uint4.xwxy swizzling.
        /// </summary>
        [Inline]
        public uint4 xwxy =>  uint4(x, w, x, y);
        
        /// <summary>
        /// Returns uint4.rarg swizzling (equivalent to uint4.xwxy).
        /// </summary>
        [Inline]
        public uint4 rarg =>  uint4(x, w, x, y);
        
        /// <summary>
        /// Returns uint4.xwxz swizzling.
        /// </summary>
        [Inline]
        public uint4 xwxz =>  uint4(x, w, x, z);
        
        /// <summary>
        /// Returns uint4.rarb swizzling (equivalent to uint4.xwxz).
        /// </summary>
        [Inline]
        public uint4 rarb =>  uint4(x, w, x, z);
        
        /// <summary>
        /// Returns uint4.xwxw swizzling.
        /// </summary>
        [Inline]
        public uint4 xwxw =>  uint4(x, w, x, w);
        
        /// <summary>
        /// Returns uint4.rara swizzling (equivalent to uint4.xwxw).
        /// </summary>
        [Inline]
        public uint4 rara =>  uint4(x, w, x, w);
        
        /// <summary>
        /// Returns uint4.xwy swizzling.
        /// </summary>
        [Inline]
        public uint3 xwy =>  uint3(x, w, y);
        
        /// <summary>
        /// Returns uint4.rag swizzling (equivalent to uint4.xwy).
        /// </summary>
        [Inline]
        public uint3 rag =>  uint3(x, w, y);
        
        /// <summary>
        /// Returns uint4.xwyx swizzling.
        /// </summary>
        [Inline]
        public uint4 xwyx =>  uint4(x, w, y, x);
        
        /// <summary>
        /// Returns uint4.ragr swizzling (equivalent to uint4.xwyx).
        /// </summary>
        [Inline]
        public uint4 ragr =>  uint4(x, w, y, x);
        
        /// <summary>
        /// Returns uint4.xwyy swizzling.
        /// </summary>
        [Inline]
        public uint4 xwyy =>  uint4(x, w, y, y);
        
        /// <summary>
        /// Returns uint4.ragg swizzling (equivalent to uint4.xwyy).
        /// </summary>
        [Inline]
        public uint4 ragg =>  uint4(x, w, y, y);
        
        /// <summary>
        /// Returns uint4.xwyz swizzling.
        /// </summary>
        [Inline]
        public uint4 xwyz =>  uint4(x, w, y, z);
        
        /// <summary>
        /// Returns uint4.ragb swizzling (equivalent to uint4.xwyz).
        /// </summary>
        [Inline]
        public uint4 ragb =>  uint4(x, w, y, z);
        
        /// <summary>
        /// Returns uint4.xwyw swizzling.
        /// </summary>
        [Inline]
        public uint4 xwyw =>  uint4(x, w, y, w);
        
        /// <summary>
        /// Returns uint4.raga swizzling (equivalent to uint4.xwyw).
        /// </summary>
        [Inline]
        public uint4 raga =>  uint4(x, w, y, w);
        
        /// <summary>
        /// Returns uint4.xwz swizzling.
        /// </summary>
        [Inline]
        public uint3 xwz =>  uint3(x, w, z);
        
        /// <summary>
        /// Returns uint4.rab swizzling (equivalent to uint4.xwz).
        /// </summary>
        [Inline]
        public uint3 rab =>  uint3(x, w, z);
        
        /// <summary>
        /// Returns uint4.xwzx swizzling.
        /// </summary>
        [Inline]
        public uint4 xwzx =>  uint4(x, w, z, x);
        
        /// <summary>
        /// Returns uint4.rabr swizzling (equivalent to uint4.xwzx).
        /// </summary>
        [Inline]
        public uint4 rabr =>  uint4(x, w, z, x);
        
        /// <summary>
        /// Returns uint4.xwzy swizzling.
        /// </summary>
        [Inline]
        public uint4 xwzy =>  uint4(x, w, z, y);
        
        /// <summary>
        /// Returns uint4.rabg swizzling (equivalent to uint4.xwzy).
        /// </summary>
        [Inline]
        public uint4 rabg =>  uint4(x, w, z, y);
        
        /// <summary>
        /// Returns uint4.xwzz swizzling.
        /// </summary>
        [Inline]
        public uint4 xwzz =>  uint4(x, w, z, z);
        
        /// <summary>
        /// Returns uint4.rabb swizzling (equivalent to uint4.xwzz).
        /// </summary>
        [Inline]
        public uint4 rabb =>  uint4(x, w, z, z);
        
        /// <summary>
        /// Returns uint4.xwzw swizzling.
        /// </summary>
        [Inline]
        public uint4 xwzw =>  uint4(x, w, z, w);
        
        /// <summary>
        /// Returns uint4.raba swizzling (equivalent to uint4.xwzw).
        /// </summary>
        [Inline]
        public uint4 raba =>  uint4(x, w, z, w);
        
        /// <summary>
        /// Returns uint4.xww swizzling.
        /// </summary>
        [Inline]
        public uint3 xww =>  uint3(x, w, w);
        
        /// <summary>
        /// Returns uint4.raa swizzling (equivalent to uint4.xww).
        /// </summary>
        [Inline]
        public uint3 raa =>  uint3(x, w, w);
        
        /// <summary>
        /// Returns uint4.xwwx swizzling.
        /// </summary>
        [Inline]
        public uint4 xwwx =>  uint4(x, w, w, x);
        
        /// <summary>
        /// Returns uint4.raar swizzling (equivalent to uint4.xwwx).
        /// </summary>
        [Inline]
        public uint4 raar =>  uint4(x, w, w, x);
        
        /// <summary>
        /// Returns uint4.xwwy swizzling.
        /// </summary>
        [Inline]
        public uint4 xwwy =>  uint4(x, w, w, y);
        
        /// <summary>
        /// Returns uint4.raag swizzling (equivalent to uint4.xwwy).
        /// </summary>
        [Inline]
        public uint4 raag =>  uint4(x, w, w, y);
        
        /// <summary>
        /// Returns uint4.xwwz swizzling.
        /// </summary>
        [Inline]
        public uint4 xwwz =>  uint4(x, w, w, z);
        
        /// <summary>
        /// Returns uint4.raab swizzling (equivalent to uint4.xwwz).
        /// </summary>
        [Inline]
        public uint4 raab =>  uint4(x, w, w, z);
        
        /// <summary>
        /// Returns uint4.xwww swizzling.
        /// </summary>
        [Inline]
        public uint4 xwww =>  uint4(x, w, w, w);
        
        /// <summary>
        /// Returns uint4.raaa swizzling (equivalent to uint4.xwww).
        /// </summary>
        [Inline]
        public uint4 raaa =>  uint4(x, w, w, w);
        
        /// <summary>
        /// Returns uint4.yx swizzling.
        /// </summary>
        [Inline]
        public uint2 yx =>  uint2(y, x);
        
        /// <summary>
        /// Returns uint4.gr swizzling (equivalent to uint4.yx).
        /// </summary>
        [Inline]
        public uint2 gr =>  uint2(y, x);
        
        /// <summary>
        /// Returns uint4.yxx swizzling.
        /// </summary>
        [Inline]
        public uint3 yxx =>  uint3(y, x, x);
        
        /// <summary>
        /// Returns uint4.grr swizzling (equivalent to uint4.yxx).
        /// </summary>
        [Inline]
        public uint3 grr =>  uint3(y, x, x);
        
        /// <summary>
        /// Returns uint4.yxxx swizzling.
        /// </summary>
        [Inline]
        public uint4 yxxx =>  uint4(y, x, x, x);
        
        /// <summary>
        /// Returns uint4.grrr swizzling (equivalent to uint4.yxxx).
        /// </summary>
        [Inline]
        public uint4 grrr =>  uint4(y, x, x, x);
        
        /// <summary>
        /// Returns uint4.yxxy swizzling.
        /// </summary>
        [Inline]
        public uint4 yxxy =>  uint4(y, x, x, y);
        
        /// <summary>
        /// Returns uint4.grrg swizzling (equivalent to uint4.yxxy).
        /// </summary>
        [Inline]
        public uint4 grrg =>  uint4(y, x, x, y);
        
        /// <summary>
        /// Returns uint4.yxxz swizzling.
        /// </summary>
        [Inline]
        public uint4 yxxz =>  uint4(y, x, x, z);
        
        /// <summary>
        /// Returns uint4.grrb swizzling (equivalent to uint4.yxxz).
        /// </summary>
        [Inline]
        public uint4 grrb =>  uint4(y, x, x, z);
        
        /// <summary>
        /// Returns uint4.yxxw swizzling.
        /// </summary>
        [Inline]
        public uint4 yxxw =>  uint4(y, x, x, w);
        
        /// <summary>
        /// Returns uint4.grra swizzling (equivalent to uint4.yxxw).
        /// </summary>
        [Inline]
        public uint4 grra =>  uint4(y, x, x, w);
        
        /// <summary>
        /// Returns uint4.yxy swizzling.
        /// </summary>
        [Inline]
        public uint3 yxy =>  uint3(y, x, y);
        
        /// <summary>
        /// Returns uint4.grg swizzling (equivalent to uint4.yxy).
        /// </summary>
        [Inline]
        public uint3 grg =>  uint3(y, x, y);
        
        /// <summary>
        /// Returns uint4.yxyx swizzling.
        /// </summary>
        [Inline]
        public uint4 yxyx =>  uint4(y, x, y, x);
        
        /// <summary>
        /// Returns uint4.grgr swizzling (equivalent to uint4.yxyx).
        /// </summary>
        [Inline]
        public uint4 grgr =>  uint4(y, x, y, x);
        
        /// <summary>
        /// Returns uint4.yxyy swizzling.
        /// </summary>
        [Inline]
        public uint4 yxyy =>  uint4(y, x, y, y);
        
        /// <summary>
        /// Returns uint4.grgg swizzling (equivalent to uint4.yxyy).
        /// </summary>
        [Inline]
        public uint4 grgg =>  uint4(y, x, y, y);
        
        /// <summary>
        /// Returns uint4.yxyz swizzling.
        /// </summary>
        [Inline]
        public uint4 yxyz =>  uint4(y, x, y, z);
        
        /// <summary>
        /// Returns uint4.grgb swizzling (equivalent to uint4.yxyz).
        /// </summary>
        [Inline]
        public uint4 grgb =>  uint4(y, x, y, z);
        
        /// <summary>
        /// Returns uint4.yxyw swizzling.
        /// </summary>
        [Inline]
        public uint4 yxyw =>  uint4(y, x, y, w);
        
        /// <summary>
        /// Returns uint4.grga swizzling (equivalent to uint4.yxyw).
        /// </summary>
        [Inline]
        public uint4 grga =>  uint4(y, x, y, w);
        
        /// <summary>
        /// Returns uint4.yxz swizzling.
        /// </summary>
        [Inline]
        public uint3 yxz =>  uint3(y, x, z);
        
        /// <summary>
        /// Returns uint4.grb swizzling (equivalent to uint4.yxz).
        /// </summary>
        [Inline]
        public uint3 grb =>  uint3(y, x, z);
        
        /// <summary>
        /// Returns uint4.yxzx swizzling.
        /// </summary>
        [Inline]
        public uint4 yxzx =>  uint4(y, x, z, x);
        
        /// <summary>
        /// Returns uint4.grbr swizzling (equivalent to uint4.yxzx).
        /// </summary>
        [Inline]
        public uint4 grbr =>  uint4(y, x, z, x);
        
        /// <summary>
        /// Returns uint4.yxzy swizzling.
        /// </summary>
        [Inline]
        public uint4 yxzy =>  uint4(y, x, z, y);
        
        /// <summary>
        /// Returns uint4.grbg swizzling (equivalent to uint4.yxzy).
        /// </summary>
        [Inline]
        public uint4 grbg =>  uint4(y, x, z, y);
        
        /// <summary>
        /// Returns uint4.yxzz swizzling.
        /// </summary>
        [Inline]
        public uint4 yxzz =>  uint4(y, x, z, z);
        
        /// <summary>
        /// Returns uint4.grbb swizzling (equivalent to uint4.yxzz).
        /// </summary>
        [Inline]
        public uint4 grbb =>  uint4(y, x, z, z);
        
        /// <summary>
        /// Returns uint4.yxzw swizzling.
        /// </summary>
        [Inline]
        public uint4 yxzw =>  uint4(y, x, z, w);
        
        /// <summary>
        /// Returns uint4.grba swizzling (equivalent to uint4.yxzw).
        /// </summary>
        [Inline]
        public uint4 grba =>  uint4(y, x, z, w);
        
        /// <summary>
        /// Returns uint4.yxw swizzling.
        /// </summary>
        [Inline]
        public uint3 yxw =>  uint3(y, x, w);
        
        /// <summary>
        /// Returns uint4.gra swizzling (equivalent to uint4.yxw).
        /// </summary>
        [Inline]
        public uint3 gra =>  uint3(y, x, w);
        
        /// <summary>
        /// Returns uint4.yxwx swizzling.
        /// </summary>
        [Inline]
        public uint4 yxwx =>  uint4(y, x, w, x);
        
        /// <summary>
        /// Returns uint4.grar swizzling (equivalent to uint4.yxwx).
        /// </summary>
        [Inline]
        public uint4 grar =>  uint4(y, x, w, x);
        
        /// <summary>
        /// Returns uint4.yxwy swizzling.
        /// </summary>
        [Inline]
        public uint4 yxwy =>  uint4(y, x, w, y);
        
        /// <summary>
        /// Returns uint4.grag swizzling (equivalent to uint4.yxwy).
        /// </summary>
        [Inline]
        public uint4 grag =>  uint4(y, x, w, y);
        
        /// <summary>
        /// Returns uint4.yxwz swizzling.
        /// </summary>
        [Inline]
        public uint4 yxwz =>  uint4(y, x, w, z);
        
        /// <summary>
        /// Returns uint4.grab swizzling (equivalent to uint4.yxwz).
        /// </summary>
        [Inline]
        public uint4 grab =>  uint4(y, x, w, z);
        
        /// <summary>
        /// Returns uint4.yxww swizzling.
        /// </summary>
        [Inline]
        public uint4 yxww =>  uint4(y, x, w, w);
        
        /// <summary>
        /// Returns uint4.graa swizzling (equivalent to uint4.yxww).
        /// </summary>
        [Inline]
        public uint4 graa =>  uint4(y, x, w, w);
        
        /// <summary>
        /// Returns uint4.yy swizzling.
        /// </summary>
        [Inline]
        public uint2 yy =>  uint2(y, y);
        
        /// <summary>
        /// Returns uint4.gg swizzling (equivalent to uint4.yy).
        /// </summary>
        [Inline]
        public uint2 gg =>  uint2(y, y);
        
        /// <summary>
        /// Returns uint4.yyx swizzling.
        /// </summary>
        [Inline]
        public uint3 yyx =>  uint3(y, y, x);
        
        /// <summary>
        /// Returns uint4.ggr swizzling (equivalent to uint4.yyx).
        /// </summary>
        [Inline]
        public uint3 ggr =>  uint3(y, y, x);
        
        /// <summary>
        /// Returns uint4.yyxx swizzling.
        /// </summary>
        [Inline]
        public uint4 yyxx =>  uint4(y, y, x, x);
        
        /// <summary>
        /// Returns uint4.ggrr swizzling (equivalent to uint4.yyxx).
        /// </summary>
        [Inline]
        public uint4 ggrr =>  uint4(y, y, x, x);
        
        /// <summary>
        /// Returns uint4.yyxy swizzling.
        /// </summary>
        [Inline]
        public uint4 yyxy =>  uint4(y, y, x, y);
        
        /// <summary>
        /// Returns uint4.ggrg swizzling (equivalent to uint4.yyxy).
        /// </summary>
        [Inline]
        public uint4 ggrg =>  uint4(y, y, x, y);
        
        /// <summary>
        /// Returns uint4.yyxz swizzling.
        /// </summary>
        [Inline]
        public uint4 yyxz =>  uint4(y, y, x, z);
        
        /// <summary>
        /// Returns uint4.ggrb swizzling (equivalent to uint4.yyxz).
        /// </summary>
        [Inline]
        public uint4 ggrb =>  uint4(y, y, x, z);
        
        /// <summary>
        /// Returns uint4.yyxw swizzling.
        /// </summary>
        [Inline]
        public uint4 yyxw =>  uint4(y, y, x, w);
        
        /// <summary>
        /// Returns uint4.ggra swizzling (equivalent to uint4.yyxw).
        /// </summary>
        [Inline]
        public uint4 ggra =>  uint4(y, y, x, w);
        
        /// <summary>
        /// Returns uint4.yyy swizzling.
        /// </summary>
        [Inline]
        public uint3 yyy =>  uint3(y, y, y);
        
        /// <summary>
        /// Returns uint4.ggg swizzling (equivalent to uint4.yyy).
        /// </summary>
        [Inline]
        public uint3 ggg =>  uint3(y, y, y);
        
        /// <summary>
        /// Returns uint4.yyyx swizzling.
        /// </summary>
        [Inline]
        public uint4 yyyx =>  uint4(y, y, y, x);
        
        /// <summary>
        /// Returns uint4.gggr swizzling (equivalent to uint4.yyyx).
        /// </summary>
        [Inline]
        public uint4 gggr =>  uint4(y, y, y, x);
        
        /// <summary>
        /// Returns uint4.yyyy swizzling.
        /// </summary>
        [Inline]
        public uint4 yyyy =>  uint4(y, y, y, y);
        
        /// <summary>
        /// Returns uint4.gggg swizzling (equivalent to uint4.yyyy).
        /// </summary>
        [Inline]
        public uint4 gggg =>  uint4(y, y, y, y);
        
        /// <summary>
        /// Returns uint4.yyyz swizzling.
        /// </summary>
        [Inline]
        public uint4 yyyz =>  uint4(y, y, y, z);
        
        /// <summary>
        /// Returns uint4.gggb swizzling (equivalent to uint4.yyyz).
        /// </summary>
        [Inline]
        public uint4 gggb =>  uint4(y, y, y, z);
        
        /// <summary>
        /// Returns uint4.yyyw swizzling.
        /// </summary>
        [Inline]
        public uint4 yyyw =>  uint4(y, y, y, w);
        
        /// <summary>
        /// Returns uint4.ggga swizzling (equivalent to uint4.yyyw).
        /// </summary>
        [Inline]
        public uint4 ggga =>  uint4(y, y, y, w);
        
        /// <summary>
        /// Returns uint4.yyz swizzling.
        /// </summary>
        [Inline]
        public uint3 yyz =>  uint3(y, y, z);
        
        /// <summary>
        /// Returns uint4.ggb swizzling (equivalent to uint4.yyz).
        /// </summary>
        [Inline]
        public uint3 ggb =>  uint3(y, y, z);
        
        /// <summary>
        /// Returns uint4.yyzx swizzling.
        /// </summary>
        [Inline]
        public uint4 yyzx =>  uint4(y, y, z, x);
        
        /// <summary>
        /// Returns uint4.ggbr swizzling (equivalent to uint4.yyzx).
        /// </summary>
        [Inline]
        public uint4 ggbr =>  uint4(y, y, z, x);
        
        /// <summary>
        /// Returns uint4.yyzy swizzling.
        /// </summary>
        [Inline]
        public uint4 yyzy =>  uint4(y, y, z, y);
        
        /// <summary>
        /// Returns uint4.ggbg swizzling (equivalent to uint4.yyzy).
        /// </summary>
        [Inline]
        public uint4 ggbg =>  uint4(y, y, z, y);
        
        /// <summary>
        /// Returns uint4.yyzz swizzling.
        /// </summary>
        [Inline]
        public uint4 yyzz =>  uint4(y, y, z, z);
        
        /// <summary>
        /// Returns uint4.ggbb swizzling (equivalent to uint4.yyzz).
        /// </summary>
        [Inline]
        public uint4 ggbb =>  uint4(y, y, z, z);
        
        /// <summary>
        /// Returns uint4.yyzw swizzling.
        /// </summary>
        [Inline]
        public uint4 yyzw =>  uint4(y, y, z, w);
        
        /// <summary>
        /// Returns uint4.ggba swizzling (equivalent to uint4.yyzw).
        /// </summary>
        [Inline]
        public uint4 ggba =>  uint4(y, y, z, w);
        
        /// <summary>
        /// Returns uint4.yyw swizzling.
        /// </summary>
        [Inline]
        public uint3 yyw =>  uint3(y, y, w);
        
        /// <summary>
        /// Returns uint4.gga swizzling (equivalent to uint4.yyw).
        /// </summary>
        [Inline]
        public uint3 gga =>  uint3(y, y, w);
        
        /// <summary>
        /// Returns uint4.yywx swizzling.
        /// </summary>
        [Inline]
        public uint4 yywx =>  uint4(y, y, w, x);
        
        /// <summary>
        /// Returns uint4.ggar swizzling (equivalent to uint4.yywx).
        /// </summary>
        [Inline]
        public uint4 ggar =>  uint4(y, y, w, x);
        
        /// <summary>
        /// Returns uint4.yywy swizzling.
        /// </summary>
        [Inline]
        public uint4 yywy =>  uint4(y, y, w, y);
        
        /// <summary>
        /// Returns uint4.ggag swizzling (equivalent to uint4.yywy).
        /// </summary>
        [Inline]
        public uint4 ggag =>  uint4(y, y, w, y);
        
        /// <summary>
        /// Returns uint4.yywz swizzling.
        /// </summary>
        [Inline]
        public uint4 yywz =>  uint4(y, y, w, z);
        
        /// <summary>
        /// Returns uint4.ggab swizzling (equivalent to uint4.yywz).
        /// </summary>
        [Inline]
        public uint4 ggab =>  uint4(y, y, w, z);
        
        /// <summary>
        /// Returns uint4.yyww swizzling.
        /// </summary>
        [Inline]
        public uint4 yyww =>  uint4(y, y, w, w);
        
        /// <summary>
        /// Returns uint4.ggaa swizzling (equivalent to uint4.yyww).
        /// </summary>
        [Inline]
        public uint4 ggaa =>  uint4(y, y, w, w);
        
        /// <summary>
        /// Returns uint4.yz swizzling.
        /// </summary>
        [Inline]
        public uint2 yz =>  uint2(y, z);
        
        /// <summary>
        /// Returns uint4.gb swizzling (equivalent to uint4.yz).
        /// </summary>
        [Inline]
        public uint2 gb =>  uint2(y, z);
        
        /// <summary>
        /// Returns uint4.yzx swizzling.
        /// </summary>
        [Inline]
        public uint3 yzx =>  uint3(y, z, x);
        
        /// <summary>
        /// Returns uint4.gbr swizzling (equivalent to uint4.yzx).
        /// </summary>
        [Inline]
        public uint3 gbr =>  uint3(y, z, x);
        
        /// <summary>
        /// Returns uint4.yzxx swizzling.
        /// </summary>
        [Inline]
        public uint4 yzxx =>  uint4(y, z, x, x);
        
        /// <summary>
        /// Returns uint4.gbrr swizzling (equivalent to uint4.yzxx).
        /// </summary>
        [Inline]
        public uint4 gbrr =>  uint4(y, z, x, x);
        
        /// <summary>
        /// Returns uint4.yzxy swizzling.
        /// </summary>
        [Inline]
        public uint4 yzxy =>  uint4(y, z, x, y);
        
        /// <summary>
        /// Returns uint4.gbrg swizzling (equivalent to uint4.yzxy).
        /// </summary>
        [Inline]
        public uint4 gbrg =>  uint4(y, z, x, y);
        
        /// <summary>
        /// Returns uint4.yzxz swizzling.
        /// </summary>
        [Inline]
        public uint4 yzxz =>  uint4(y, z, x, z);
        
        /// <summary>
        /// Returns uint4.gbrb swizzling (equivalent to uint4.yzxz).
        /// </summary>
        [Inline]
        public uint4 gbrb =>  uint4(y, z, x, z);
        
        /// <summary>
        /// Returns uint4.yzxw swizzling.
        /// </summary>
        [Inline]
        public uint4 yzxw =>  uint4(y, z, x, w);
        
        /// <summary>
        /// Returns uint4.gbra swizzling (equivalent to uint4.yzxw).
        /// </summary>
        [Inline]
        public uint4 gbra =>  uint4(y, z, x, w);
        
        /// <summary>
        /// Returns uint4.yzy swizzling.
        /// </summary>
        [Inline]
        public uint3 yzy =>  uint3(y, z, y);
        
        /// <summary>
        /// Returns uint4.gbg swizzling (equivalent to uint4.yzy).
        /// </summary>
        [Inline]
        public uint3 gbg =>  uint3(y, z, y);
        
        /// <summary>
        /// Returns uint4.yzyx swizzling.
        /// </summary>
        [Inline]
        public uint4 yzyx =>  uint4(y, z, y, x);
        
        /// <summary>
        /// Returns uint4.gbgr swizzling (equivalent to uint4.yzyx).
        /// </summary>
        [Inline]
        public uint4 gbgr =>  uint4(y, z, y, x);
        
        /// <summary>
        /// Returns uint4.yzyy swizzling.
        /// </summary>
        [Inline]
        public uint4 yzyy =>  uint4(y, z, y, y);
        
        /// <summary>
        /// Returns uint4.gbgg swizzling (equivalent to uint4.yzyy).
        /// </summary>
        [Inline]
        public uint4 gbgg =>  uint4(y, z, y, y);
        
        /// <summary>
        /// Returns uint4.yzyz swizzling.
        /// </summary>
        [Inline]
        public uint4 yzyz =>  uint4(y, z, y, z);
        
        /// <summary>
        /// Returns uint4.gbgb swizzling (equivalent to uint4.yzyz).
        /// </summary>
        [Inline]
        public uint4 gbgb =>  uint4(y, z, y, z);
        
        /// <summary>
        /// Returns uint4.yzyw swizzling.
        /// </summary>
        [Inline]
        public uint4 yzyw =>  uint4(y, z, y, w);
        
        /// <summary>
        /// Returns uint4.gbga swizzling (equivalent to uint4.yzyw).
        /// </summary>
        [Inline]
        public uint4 gbga =>  uint4(y, z, y, w);
        
        /// <summary>
        /// Returns uint4.yzz swizzling.
        /// </summary>
        [Inline]
        public uint3 yzz =>  uint3(y, z, z);
        
        /// <summary>
        /// Returns uint4.gbb swizzling (equivalent to uint4.yzz).
        /// </summary>
        [Inline]
        public uint3 gbb =>  uint3(y, z, z);
        
        /// <summary>
        /// Returns uint4.yzzx swizzling.
        /// </summary>
        [Inline]
        public uint4 yzzx =>  uint4(y, z, z, x);
        
        /// <summary>
        /// Returns uint4.gbbr swizzling (equivalent to uint4.yzzx).
        /// </summary>
        [Inline]
        public uint4 gbbr =>  uint4(y, z, z, x);
        
        /// <summary>
        /// Returns uint4.yzzy swizzling.
        /// </summary>
        [Inline]
        public uint4 yzzy =>  uint4(y, z, z, y);
        
        /// <summary>
        /// Returns uint4.gbbg swizzling (equivalent to uint4.yzzy).
        /// </summary>
        [Inline]
        public uint4 gbbg =>  uint4(y, z, z, y);
        
        /// <summary>
        /// Returns uint4.yzzz swizzling.
        /// </summary>
        [Inline]
        public uint4 yzzz =>  uint4(y, z, z, z);
        
        /// <summary>
        /// Returns uint4.gbbb swizzling (equivalent to uint4.yzzz).
        /// </summary>
        [Inline]
        public uint4 gbbb =>  uint4(y, z, z, z);
        
        /// <summary>
        /// Returns uint4.yzzw swizzling.
        /// </summary>
        [Inline]
        public uint4 yzzw =>  uint4(y, z, z, w);
        
        /// <summary>
        /// Returns uint4.gbba swizzling (equivalent to uint4.yzzw).
        /// </summary>
        [Inline]
        public uint4 gbba =>  uint4(y, z, z, w);
        
        /// <summary>
        /// Returns uint4.yzw swizzling.
        /// </summary>
        [Inline]
        public uint3 yzw =>  uint3(y, z, w);
        
        /// <summary>
        /// Returns uint4.gba swizzling (equivalent to uint4.yzw).
        /// </summary>
        [Inline]
        public uint3 gba =>  uint3(y, z, w);
        
        /// <summary>
        /// Returns uint4.yzwx swizzling.
        /// </summary>
        [Inline]
        public uint4 yzwx =>  uint4(y, z, w, x);
        
        /// <summary>
        /// Returns uint4.gbar swizzling (equivalent to uint4.yzwx).
        /// </summary>
        [Inline]
        public uint4 gbar =>  uint4(y, z, w, x);
        
        /// <summary>
        /// Returns uint4.yzwy swizzling.
        /// </summary>
        [Inline]
        public uint4 yzwy =>  uint4(y, z, w, y);
        
        /// <summary>
        /// Returns uint4.gbag swizzling (equivalent to uint4.yzwy).
        /// </summary>
        [Inline]
        public uint4 gbag =>  uint4(y, z, w, y);
        
        /// <summary>
        /// Returns uint4.yzwz swizzling.
        /// </summary>
        [Inline]
        public uint4 yzwz =>  uint4(y, z, w, z);
        
        /// <summary>
        /// Returns uint4.gbab swizzling (equivalent to uint4.yzwz).
        /// </summary>
        [Inline]
        public uint4 gbab =>  uint4(y, z, w, z);
        
        /// <summary>
        /// Returns uint4.yzww swizzling.
        /// </summary>
        [Inline]
        public uint4 yzww =>  uint4(y, z, w, w);
        
        /// <summary>
        /// Returns uint4.gbaa swizzling (equivalent to uint4.yzww).
        /// </summary>
        [Inline]
        public uint4 gbaa =>  uint4(y, z, w, w);
        
        /// <summary>
        /// Returns uint4.yw swizzling.
        /// </summary>
        [Inline]
        public uint2 yw =>  uint2(y, w);
        
        /// <summary>
        /// Returns uint4.ga swizzling (equivalent to uint4.yw).
        /// </summary>
        [Inline]
        public uint2 ga =>  uint2(y, w);
        
        /// <summary>
        /// Returns uint4.ywx swizzling.
        /// </summary>
        [Inline]
        public uint3 ywx =>  uint3(y, w, x);
        
        /// <summary>
        /// Returns uint4.gar swizzling (equivalent to uint4.ywx).
        /// </summary>
        [Inline]
        public uint3 gar =>  uint3(y, w, x);
        
        /// <summary>
        /// Returns uint4.ywxx swizzling.
        /// </summary>
        [Inline]
        public uint4 ywxx =>  uint4(y, w, x, x);
        
        /// <summary>
        /// Returns uint4.garr swizzling (equivalent to uint4.ywxx).
        /// </summary>
        [Inline]
        public uint4 garr =>  uint4(y, w, x, x);
        
        /// <summary>
        /// Returns uint4.ywxy swizzling.
        /// </summary>
        [Inline]
        public uint4 ywxy =>  uint4(y, w, x, y);
        
        /// <summary>
        /// Returns uint4.garg swizzling (equivalent to uint4.ywxy).
        /// </summary>
        [Inline]
        public uint4 garg =>  uint4(y, w, x, y);
        
        /// <summary>
        /// Returns uint4.ywxz swizzling.
        /// </summary>
        [Inline]
        public uint4 ywxz =>  uint4(y, w, x, z);
        
        /// <summary>
        /// Returns uint4.garb swizzling (equivalent to uint4.ywxz).
        /// </summary>
        [Inline]
        public uint4 garb =>  uint4(y, w, x, z);
        
        /// <summary>
        /// Returns uint4.ywxw swizzling.
        /// </summary>
        [Inline]
        public uint4 ywxw =>  uint4(y, w, x, w);
        
        /// <summary>
        /// Returns uint4.gara swizzling (equivalent to uint4.ywxw).
        /// </summary>
        [Inline]
        public uint4 gara =>  uint4(y, w, x, w);
        
        /// <summary>
        /// Returns uint4.ywy swizzling.
        /// </summary>
        [Inline]
        public uint3 ywy =>  uint3(y, w, y);
        
        /// <summary>
        /// Returns uint4.gag swizzling (equivalent to uint4.ywy).
        /// </summary>
        [Inline]
        public uint3 gag =>  uint3(y, w, y);
        
        /// <summary>
        /// Returns uint4.ywyx swizzling.
        /// </summary>
        [Inline]
        public uint4 ywyx =>  uint4(y, w, y, x);
        
        /// <summary>
        /// Returns uint4.gagr swizzling (equivalent to uint4.ywyx).
        /// </summary>
        [Inline]
        public uint4 gagr =>  uint4(y, w, y, x);
        
        /// <summary>
        /// Returns uint4.ywyy swizzling.
        /// </summary>
        [Inline]
        public uint4 ywyy =>  uint4(y, w, y, y);
        
        /// <summary>
        /// Returns uint4.gagg swizzling (equivalent to uint4.ywyy).
        /// </summary>
        [Inline]
        public uint4 gagg =>  uint4(y, w, y, y);
        
        /// <summary>
        /// Returns uint4.ywyz swizzling.
        /// </summary>
        [Inline]
        public uint4 ywyz =>  uint4(y, w, y, z);
        
        /// <summary>
        /// Returns uint4.gagb swizzling (equivalent to uint4.ywyz).
        /// </summary>
        [Inline]
        public uint4 gagb =>  uint4(y, w, y, z);
        
        /// <summary>
        /// Returns uint4.ywyw swizzling.
        /// </summary>
        [Inline]
        public uint4 ywyw =>  uint4(y, w, y, w);
        
        /// <summary>
        /// Returns uint4.gaga swizzling (equivalent to uint4.ywyw).
        /// </summary>
        [Inline]
        public uint4 gaga =>  uint4(y, w, y, w);
        
        /// <summary>
        /// Returns uint4.ywz swizzling.
        /// </summary>
        [Inline]
        public uint3 ywz =>  uint3(y, w, z);
        
        /// <summary>
        /// Returns uint4.gab swizzling (equivalent to uint4.ywz).
        /// </summary>
        [Inline]
        public uint3 gab =>  uint3(y, w, z);
        
        /// <summary>
        /// Returns uint4.ywzx swizzling.
        /// </summary>
        [Inline]
        public uint4 ywzx =>  uint4(y, w, z, x);
        
        /// <summary>
        /// Returns uint4.gabr swizzling (equivalent to uint4.ywzx).
        /// </summary>
        [Inline]
        public uint4 gabr =>  uint4(y, w, z, x);
        
        /// <summary>
        /// Returns uint4.ywzy swizzling.
        /// </summary>
        [Inline]
        public uint4 ywzy =>  uint4(y, w, z, y);
        
        /// <summary>
        /// Returns uint4.gabg swizzling (equivalent to uint4.ywzy).
        /// </summary>
        [Inline]
        public uint4 gabg =>  uint4(y, w, z, y);
        
        /// <summary>
        /// Returns uint4.ywzz swizzling.
        /// </summary>
        [Inline]
        public uint4 ywzz =>  uint4(y, w, z, z);
        
        /// <summary>
        /// Returns uint4.gabb swizzling (equivalent to uint4.ywzz).
        /// </summary>
        [Inline]
        public uint4 gabb =>  uint4(y, w, z, z);
        
        /// <summary>
        /// Returns uint4.ywzw swizzling.
        /// </summary>
        [Inline]
        public uint4 ywzw =>  uint4(y, w, z, w);
        
        /// <summary>
        /// Returns uint4.gaba swizzling (equivalent to uint4.ywzw).
        /// </summary>
        [Inline]
        public uint4 gaba =>  uint4(y, w, z, w);
        
        /// <summary>
        /// Returns uint4.yww swizzling.
        /// </summary>
        [Inline]
        public uint3 yww =>  uint3(y, w, w);
        
        /// <summary>
        /// Returns uint4.gaa swizzling (equivalent to uint4.yww).
        /// </summary>
        [Inline]
        public uint3 gaa =>  uint3(y, w, w);
        
        /// <summary>
        /// Returns uint4.ywwx swizzling.
        /// </summary>
        [Inline]
        public uint4 ywwx =>  uint4(y, w, w, x);
        
        /// <summary>
        /// Returns uint4.gaar swizzling (equivalent to uint4.ywwx).
        /// </summary>
        [Inline]
        public uint4 gaar =>  uint4(y, w, w, x);
        
        /// <summary>
        /// Returns uint4.ywwy swizzling.
        /// </summary>
        [Inline]
        public uint4 ywwy =>  uint4(y, w, w, y);
        
        /// <summary>
        /// Returns uint4.gaag swizzling (equivalent to uint4.ywwy).
        /// </summary>
        [Inline]
        public uint4 gaag =>  uint4(y, w, w, y);
        
        /// <summary>
        /// Returns uint4.ywwz swizzling.
        /// </summary>
        [Inline]
        public uint4 ywwz =>  uint4(y, w, w, z);
        
        /// <summary>
        /// Returns uint4.gaab swizzling (equivalent to uint4.ywwz).
        /// </summary>
        [Inline]
        public uint4 gaab =>  uint4(y, w, w, z);
        
        /// <summary>
        /// Returns uint4.ywww swizzling.
        /// </summary>
        [Inline]
        public uint4 ywww =>  uint4(y, w, w, w);
        
        /// <summary>
        /// Returns uint4.gaaa swizzling (equivalent to uint4.ywww).
        /// </summary>
        [Inline]
        public uint4 gaaa =>  uint4(y, w, w, w);
        
        /// <summary>
        /// Returns uint4.zx swizzling.
        /// </summary>
        [Inline]
        public uint2 zx =>  uint2(z, x);
        
        /// <summary>
        /// Returns uint4.br swizzling (equivalent to uint4.zx).
        /// </summary>
        [Inline]
        public uint2 br =>  uint2(z, x);
        
        /// <summary>
        /// Returns uint4.zxx swizzling.
        /// </summary>
        [Inline]
        public uint3 zxx =>  uint3(z, x, x);
        
        /// <summary>
        /// Returns uint4.brr swizzling (equivalent to uint4.zxx).
        /// </summary>
        [Inline]
        public uint3 brr =>  uint3(z, x, x);
        
        /// <summary>
        /// Returns uint4.zxxx swizzling.
        /// </summary>
        [Inline]
        public uint4 zxxx =>  uint4(z, x, x, x);
        
        /// <summary>
        /// Returns uint4.brrr swizzling (equivalent to uint4.zxxx).
        /// </summary>
        [Inline]
        public uint4 brrr =>  uint4(z, x, x, x);
        
        /// <summary>
        /// Returns uint4.zxxy swizzling.
        /// </summary>
        [Inline]
        public uint4 zxxy =>  uint4(z, x, x, y);
        
        /// <summary>
        /// Returns uint4.brrg swizzling (equivalent to uint4.zxxy).
        /// </summary>
        [Inline]
        public uint4 brrg =>  uint4(z, x, x, y);
        
        /// <summary>
        /// Returns uint4.zxxz swizzling.
        /// </summary>
        [Inline]
        public uint4 zxxz =>  uint4(z, x, x, z);
        
        /// <summary>
        /// Returns uint4.brrb swizzling (equivalent to uint4.zxxz).
        /// </summary>
        [Inline]
        public uint4 brrb =>  uint4(z, x, x, z);
        
        /// <summary>
        /// Returns uint4.zxxw swizzling.
        /// </summary>
        [Inline]
        public uint4 zxxw =>  uint4(z, x, x, w);
        
        /// <summary>
        /// Returns uint4.brra swizzling (equivalent to uint4.zxxw).
        /// </summary>
        [Inline]
        public uint4 brra =>  uint4(z, x, x, w);
        
        /// <summary>
        /// Returns uint4.zxy swizzling.
        /// </summary>
        [Inline]
        public uint3 zxy =>  uint3(z, x, y);
        
        /// <summary>
        /// Returns uint4.brg swizzling (equivalent to uint4.zxy).
        /// </summary>
        [Inline]
        public uint3 brg =>  uint3(z, x, y);
        
        /// <summary>
        /// Returns uint4.zxyx swizzling.
        /// </summary>
        [Inline]
        public uint4 zxyx =>  uint4(z, x, y, x);
        
        /// <summary>
        /// Returns uint4.brgr swizzling (equivalent to uint4.zxyx).
        /// </summary>
        [Inline]
        public uint4 brgr =>  uint4(z, x, y, x);
        
        /// <summary>
        /// Returns uint4.zxyy swizzling.
        /// </summary>
        [Inline]
        public uint4 zxyy =>  uint4(z, x, y, y);
        
        /// <summary>
        /// Returns uint4.brgg swizzling (equivalent to uint4.zxyy).
        /// </summary>
        [Inline]
        public uint4 brgg =>  uint4(z, x, y, y);
        
        /// <summary>
        /// Returns uint4.zxyz swizzling.
        /// </summary>
        [Inline]
        public uint4 zxyz =>  uint4(z, x, y, z);
        
        /// <summary>
        /// Returns uint4.brgb swizzling (equivalent to uint4.zxyz).
        /// </summary>
        [Inline]
        public uint4 brgb =>  uint4(z, x, y, z);
        
        /// <summary>
        /// Returns uint4.zxyw swizzling.
        /// </summary>
        [Inline]
        public uint4 zxyw =>  uint4(z, x, y, w);
        
        /// <summary>
        /// Returns uint4.brga swizzling (equivalent to uint4.zxyw).
        /// </summary>
        [Inline]
        public uint4 brga =>  uint4(z, x, y, w);
        
        /// <summary>
        /// Returns uint4.zxz swizzling.
        /// </summary>
        [Inline]
        public uint3 zxz =>  uint3(z, x, z);
        
        /// <summary>
        /// Returns uint4.brb swizzling (equivalent to uint4.zxz).
        /// </summary>
        [Inline]
        public uint3 brb =>  uint3(z, x, z);
        
        /// <summary>
        /// Returns uint4.zxzx swizzling.
        /// </summary>
        [Inline]
        public uint4 zxzx =>  uint4(z, x, z, x);
        
        /// <summary>
        /// Returns uint4.brbr swizzling (equivalent to uint4.zxzx).
        /// </summary>
        [Inline]
        public uint4 brbr =>  uint4(z, x, z, x);
        
        /// <summary>
        /// Returns uint4.zxzy swizzling.
        /// </summary>
        [Inline]
        public uint4 zxzy =>  uint4(z, x, z, y);
        
        /// <summary>
        /// Returns uint4.brbg swizzling (equivalent to uint4.zxzy).
        /// </summary>
        [Inline]
        public uint4 brbg =>  uint4(z, x, z, y);
        
        /// <summary>
        /// Returns uint4.zxzz swizzling.
        /// </summary>
        [Inline]
        public uint4 zxzz =>  uint4(z, x, z, z);
        
        /// <summary>
        /// Returns uint4.brbb swizzling (equivalent to uint4.zxzz).
        /// </summary>
        [Inline]
        public uint4 brbb =>  uint4(z, x, z, z);
        
        /// <summary>
        /// Returns uint4.zxzw swizzling.
        /// </summary>
        [Inline]
        public uint4 zxzw =>  uint4(z, x, z, w);
        
        /// <summary>
        /// Returns uint4.brba swizzling (equivalent to uint4.zxzw).
        /// </summary>
        [Inline]
        public uint4 brba =>  uint4(z, x, z, w);
        
        /// <summary>
        /// Returns uint4.zxw swizzling.
        /// </summary>
        [Inline]
        public uint3 zxw =>  uint3(z, x, w);
        
        /// <summary>
        /// Returns uint4.bra swizzling (equivalent to uint4.zxw).
        /// </summary>
        [Inline]
        public uint3 bra =>  uint3(z, x, w);
        
        /// <summary>
        /// Returns uint4.zxwx swizzling.
        /// </summary>
        [Inline]
        public uint4 zxwx =>  uint4(z, x, w, x);
        
        /// <summary>
        /// Returns uint4.brar swizzling (equivalent to uint4.zxwx).
        /// </summary>
        [Inline]
        public uint4 brar =>  uint4(z, x, w, x);
        
        /// <summary>
        /// Returns uint4.zxwy swizzling.
        /// </summary>
        [Inline]
        public uint4 zxwy =>  uint4(z, x, w, y);
        
        /// <summary>
        /// Returns uint4.brag swizzling (equivalent to uint4.zxwy).
        /// </summary>
        [Inline]
        public uint4 brag =>  uint4(z, x, w, y);
        
        /// <summary>
        /// Returns uint4.zxwz swizzling.
        /// </summary>
        [Inline]
        public uint4 zxwz =>  uint4(z, x, w, z);
        
        /// <summary>
        /// Returns uint4.brab swizzling (equivalent to uint4.zxwz).
        /// </summary>
        [Inline]
        public uint4 brab =>  uint4(z, x, w, z);
        
        /// <summary>
        /// Returns uint4.zxww swizzling.
        /// </summary>
        [Inline]
        public uint4 zxww =>  uint4(z, x, w, w);
        
        /// <summary>
        /// Returns uint4.braa swizzling (equivalent to uint4.zxww).
        /// </summary>
        [Inline]
        public uint4 braa =>  uint4(z, x, w, w);
        
        /// <summary>
        /// Returns uint4.zy swizzling.
        /// </summary>
        [Inline]
        public uint2 zy =>  uint2(z, y);
        
        /// <summary>
        /// Returns uint4.bg swizzling (equivalent to uint4.zy).
        /// </summary>
        [Inline]
        public uint2 bg =>  uint2(z, y);
        
        /// <summary>
        /// Returns uint4.zyx swizzling.
        /// </summary>
        [Inline]
        public uint3 zyx =>  uint3(z, y, x);
        
        /// <summary>
        /// Returns uint4.bgr swizzling (equivalent to uint4.zyx).
        /// </summary>
        [Inline]
        public uint3 bgr =>  uint3(z, y, x);
        
        /// <summary>
        /// Returns uint4.zyxx swizzling.
        /// </summary>
        [Inline]
        public uint4 zyxx =>  uint4(z, y, x, x);
        
        /// <summary>
        /// Returns uint4.bgrr swizzling (equivalent to uint4.zyxx).
        /// </summary>
        [Inline]
        public uint4 bgrr =>  uint4(z, y, x, x);
        
        /// <summary>
        /// Returns uint4.zyxy swizzling.
        /// </summary>
        [Inline]
        public uint4 zyxy =>  uint4(z, y, x, y);
        
        /// <summary>
        /// Returns uint4.bgrg swizzling (equivalent to uint4.zyxy).
        /// </summary>
        [Inline]
        public uint4 bgrg =>  uint4(z, y, x, y);
        
        /// <summary>
        /// Returns uint4.zyxz swizzling.
        /// </summary>
        [Inline]
        public uint4 zyxz =>  uint4(z, y, x, z);
        
        /// <summary>
        /// Returns uint4.bgrb swizzling (equivalent to uint4.zyxz).
        /// </summary>
        [Inline]
        public uint4 bgrb =>  uint4(z, y, x, z);
        
        /// <summary>
        /// Returns uint4.zyxw swizzling.
        /// </summary>
        [Inline]
        public uint4 zyxw =>  uint4(z, y, x, w);
        
        /// <summary>
        /// Returns uint4.bgra swizzling (equivalent to uint4.zyxw).
        /// </summary>
        [Inline]
        public uint4 bgra =>  uint4(z, y, x, w);
        
        /// <summary>
        /// Returns uint4.zyy swizzling.
        /// </summary>
        [Inline]
        public uint3 zyy =>  uint3(z, y, y);
        
        /// <summary>
        /// Returns uint4.bgg swizzling (equivalent to uint4.zyy).
        /// </summary>
        [Inline]
        public uint3 bgg =>  uint3(z, y, y);
        
        /// <summary>
        /// Returns uint4.zyyx swizzling.
        /// </summary>
        [Inline]
        public uint4 zyyx =>  uint4(z, y, y, x);
        
        /// <summary>
        /// Returns uint4.bggr swizzling (equivalent to uint4.zyyx).
        /// </summary>
        [Inline]
        public uint4 bggr =>  uint4(z, y, y, x);
        
        /// <summary>
        /// Returns uint4.zyyy swizzling.
        /// </summary>
        [Inline]
        public uint4 zyyy =>  uint4(z, y, y, y);
        
        /// <summary>
        /// Returns uint4.bggg swizzling (equivalent to uint4.zyyy).
        /// </summary>
        [Inline]
        public uint4 bggg =>  uint4(z, y, y, y);
        
        /// <summary>
        /// Returns uint4.zyyz swizzling.
        /// </summary>
        [Inline]
        public uint4 zyyz =>  uint4(z, y, y, z);
        
        /// <summary>
        /// Returns uint4.bggb swizzling (equivalent to uint4.zyyz).
        /// </summary>
        [Inline]
        public uint4 bggb =>  uint4(z, y, y, z);
        
        /// <summary>
        /// Returns uint4.zyyw swizzling.
        /// </summary>
        [Inline]
        public uint4 zyyw =>  uint4(z, y, y, w);
        
        /// <summary>
        /// Returns uint4.bgga swizzling (equivalent to uint4.zyyw).
        /// </summary>
        [Inline]
        public uint4 bgga =>  uint4(z, y, y, w);
        
        /// <summary>
        /// Returns uint4.zyz swizzling.
        /// </summary>
        [Inline]
        public uint3 zyz =>  uint3(z, y, z);
        
        /// <summary>
        /// Returns uint4.bgb swizzling (equivalent to uint4.zyz).
        /// </summary>
        [Inline]
        public uint3 bgb =>  uint3(z, y, z);
        
        /// <summary>
        /// Returns uint4.zyzx swizzling.
        /// </summary>
        [Inline]
        public uint4 zyzx =>  uint4(z, y, z, x);
        
        /// <summary>
        /// Returns uint4.bgbr swizzling (equivalent to uint4.zyzx).
        /// </summary>
        [Inline]
        public uint4 bgbr =>  uint4(z, y, z, x);
        
        /// <summary>
        /// Returns uint4.zyzy swizzling.
        /// </summary>
        [Inline]
        public uint4 zyzy =>  uint4(z, y, z, y);
        
        /// <summary>
        /// Returns uint4.bgbg swizzling (equivalent to uint4.zyzy).
        /// </summary>
        [Inline]
        public uint4 bgbg =>  uint4(z, y, z, y);
        
        /// <summary>
        /// Returns uint4.zyzz swizzling.
        /// </summary>
        [Inline]
        public uint4 zyzz =>  uint4(z, y, z, z);
        
        /// <summary>
        /// Returns uint4.bgbb swizzling (equivalent to uint4.zyzz).
        /// </summary>
        [Inline]
        public uint4 bgbb =>  uint4(z, y, z, z);
        
        /// <summary>
        /// Returns uint4.zyzw swizzling.
        /// </summary>
        [Inline]
        public uint4 zyzw =>  uint4(z, y, z, w);
        
        /// <summary>
        /// Returns uint4.bgba swizzling (equivalent to uint4.zyzw).
        /// </summary>
        [Inline]
        public uint4 bgba =>  uint4(z, y, z, w);
        
        /// <summary>
        /// Returns uint4.zyw swizzling.
        /// </summary>
        [Inline]
        public uint3 zyw =>  uint3(z, y, w);
        
        /// <summary>
        /// Returns uint4.bga swizzling (equivalent to uint4.zyw).
        /// </summary>
        [Inline]
        public uint3 bga =>  uint3(z, y, w);
        
        /// <summary>
        /// Returns uint4.zywx swizzling.
        /// </summary>
        [Inline]
        public uint4 zywx =>  uint4(z, y, w, x);
        
        /// <summary>
        /// Returns uint4.bgar swizzling (equivalent to uint4.zywx).
        /// </summary>
        [Inline]
        public uint4 bgar =>  uint4(z, y, w, x);
        
        /// <summary>
        /// Returns uint4.zywy swizzling.
        /// </summary>
        [Inline]
        public uint4 zywy =>  uint4(z, y, w, y);
        
        /// <summary>
        /// Returns uint4.bgag swizzling (equivalent to uint4.zywy).
        /// </summary>
        [Inline]
        public uint4 bgag =>  uint4(z, y, w, y);
        
        /// <summary>
        /// Returns uint4.zywz swizzling.
        /// </summary>
        [Inline]
        public uint4 zywz =>  uint4(z, y, w, z);
        
        /// <summary>
        /// Returns uint4.bgab swizzling (equivalent to uint4.zywz).
        /// </summary>
        [Inline]
        public uint4 bgab =>  uint4(z, y, w, z);
        
        /// <summary>
        /// Returns uint4.zyww swizzling.
        /// </summary>
        [Inline]
        public uint4 zyww =>  uint4(z, y, w, w);
        
        /// <summary>
        /// Returns uint4.bgaa swizzling (equivalent to uint4.zyww).
        /// </summary>
        [Inline]
        public uint4 bgaa =>  uint4(z, y, w, w);
        
        /// <summary>
        /// Returns uint4.zz swizzling.
        /// </summary>
        [Inline]
        public uint2 zz =>  uint2(z, z);
        
        /// <summary>
        /// Returns uint4.bb swizzling (equivalent to uint4.zz).
        /// </summary>
        [Inline]
        public uint2 bb =>  uint2(z, z);
        
        /// <summary>
        /// Returns uint4.zzx swizzling.
        /// </summary>
        [Inline]
        public uint3 zzx =>  uint3(z, z, x);
        
        /// <summary>
        /// Returns uint4.bbr swizzling (equivalent to uint4.zzx).
        /// </summary>
        [Inline]
        public uint3 bbr =>  uint3(z, z, x);
        
        /// <summary>
        /// Returns uint4.zzxx swizzling.
        /// </summary>
        [Inline]
        public uint4 zzxx =>  uint4(z, z, x, x);
        
        /// <summary>
        /// Returns uint4.bbrr swizzling (equivalent to uint4.zzxx).
        /// </summary>
        [Inline]
        public uint4 bbrr =>  uint4(z, z, x, x);
        
        /// <summary>
        /// Returns uint4.zzxy swizzling.
        /// </summary>
        [Inline]
        public uint4 zzxy =>  uint4(z, z, x, y);
        
        /// <summary>
        /// Returns uint4.bbrg swizzling (equivalent to uint4.zzxy).
        /// </summary>
        [Inline]
        public uint4 bbrg =>  uint4(z, z, x, y);
        
        /// <summary>
        /// Returns uint4.zzxz swizzling.
        /// </summary>
        [Inline]
        public uint4 zzxz =>  uint4(z, z, x, z);
        
        /// <summary>
        /// Returns uint4.bbrb swizzling (equivalent to uint4.zzxz).
        /// </summary>
        [Inline]
        public uint4 bbrb =>  uint4(z, z, x, z);
        
        /// <summary>
        /// Returns uint4.zzxw swizzling.
        /// </summary>
        [Inline]
        public uint4 zzxw =>  uint4(z, z, x, w);
        
        /// <summary>
        /// Returns uint4.bbra swizzling (equivalent to uint4.zzxw).
        /// </summary>
        [Inline]
        public uint4 bbra =>  uint4(z, z, x, w);
        
        /// <summary>
        /// Returns uint4.zzy swizzling.
        /// </summary>
        [Inline]
        public uint3 zzy =>  uint3(z, z, y);
        
        /// <summary>
        /// Returns uint4.bbg swizzling (equivalent to uint4.zzy).
        /// </summary>
        [Inline]
        public uint3 bbg =>  uint3(z, z, y);
        
        /// <summary>
        /// Returns uint4.zzyx swizzling.
        /// </summary>
        [Inline]
        public uint4 zzyx =>  uint4(z, z, y, x);
        
        /// <summary>
        /// Returns uint4.bbgr swizzling (equivalent to uint4.zzyx).
        /// </summary>
        [Inline]
        public uint4 bbgr =>  uint4(z, z, y, x);
        
        /// <summary>
        /// Returns uint4.zzyy swizzling.
        /// </summary>
        [Inline]
        public uint4 zzyy =>  uint4(z, z, y, y);
        
        /// <summary>
        /// Returns uint4.bbgg swizzling (equivalent to uint4.zzyy).
        /// </summary>
        [Inline]
        public uint4 bbgg =>  uint4(z, z, y, y);
        
        /// <summary>
        /// Returns uint4.zzyz swizzling.
        /// </summary>
        [Inline]
        public uint4 zzyz =>  uint4(z, z, y, z);
        
        /// <summary>
        /// Returns uint4.bbgb swizzling (equivalent to uint4.zzyz).
        /// </summary>
        [Inline]
        public uint4 bbgb =>  uint4(z, z, y, z);
        
        /// <summary>
        /// Returns uint4.zzyw swizzling.
        /// </summary>
        [Inline]
        public uint4 zzyw =>  uint4(z, z, y, w);
        
        /// <summary>
        /// Returns uint4.bbga swizzling (equivalent to uint4.zzyw).
        /// </summary>
        [Inline]
        public uint4 bbga =>  uint4(z, z, y, w);
        
        /// <summary>
        /// Returns uint4.zzz swizzling.
        /// </summary>
        [Inline]
        public uint3 zzz =>  uint3(z, z, z);
        
        /// <summary>
        /// Returns uint4.bbb swizzling (equivalent to uint4.zzz).
        /// </summary>
        [Inline]
        public uint3 bbb =>  uint3(z, z, z);
        
        /// <summary>
        /// Returns uint4.zzzx swizzling.
        /// </summary>
        [Inline]
        public uint4 zzzx =>  uint4(z, z, z, x);
        
        /// <summary>
        /// Returns uint4.bbbr swizzling (equivalent to uint4.zzzx).
        /// </summary>
        [Inline]
        public uint4 bbbr =>  uint4(z, z, z, x);
        
        /// <summary>
        /// Returns uint4.zzzy swizzling.
        /// </summary>
        [Inline]
        public uint4 zzzy =>  uint4(z, z, z, y);
        
        /// <summary>
        /// Returns uint4.bbbg swizzling (equivalent to uint4.zzzy).
        /// </summary>
        [Inline]
        public uint4 bbbg =>  uint4(z, z, z, y);
        
        /// <summary>
        /// Returns uint4.zzzz swizzling.
        /// </summary>
        [Inline]
        public uint4 zzzz =>  uint4(z, z, z, z);
        
        /// <summary>
        /// Returns uint4.bbbb swizzling (equivalent to uint4.zzzz).
        /// </summary>
        [Inline]
        public uint4 bbbb =>  uint4(z, z, z, z);
        
        /// <summary>
        /// Returns uint4.zzzw swizzling.
        /// </summary>
        [Inline]
        public uint4 zzzw =>  uint4(z, z, z, w);
        
        /// <summary>
        /// Returns uint4.bbba swizzling (equivalent to uint4.zzzw).
        /// </summary>
        [Inline]
        public uint4 bbba =>  uint4(z, z, z, w);
        
        /// <summary>
        /// Returns uint4.zzw swizzling.
        /// </summary>
        [Inline]
        public uint3 zzw =>  uint3(z, z, w);
        
        /// <summary>
        /// Returns uint4.bba swizzling (equivalent to uint4.zzw).
        /// </summary>
        [Inline]
        public uint3 bba =>  uint3(z, z, w);
        
        /// <summary>
        /// Returns uint4.zzwx swizzling.
        /// </summary>
        [Inline]
        public uint4 zzwx =>  uint4(z, z, w, x);
        
        /// <summary>
        /// Returns uint4.bbar swizzling (equivalent to uint4.zzwx).
        /// </summary>
        [Inline]
        public uint4 bbar =>  uint4(z, z, w, x);
        
        /// <summary>
        /// Returns uint4.zzwy swizzling.
        /// </summary>
        [Inline]
        public uint4 zzwy =>  uint4(z, z, w, y);
        
        /// <summary>
        /// Returns uint4.bbag swizzling (equivalent to uint4.zzwy).
        /// </summary>
        [Inline]
        public uint4 bbag =>  uint4(z, z, w, y);
        
        /// <summary>
        /// Returns uint4.zzwz swizzling.
        /// </summary>
        [Inline]
        public uint4 zzwz =>  uint4(z, z, w, z);
        
        /// <summary>
        /// Returns uint4.bbab swizzling (equivalent to uint4.zzwz).
        /// </summary>
        [Inline]
        public uint4 bbab =>  uint4(z, z, w, z);
        
        /// <summary>
        /// Returns uint4.zzww swizzling.
        /// </summary>
        [Inline]
        public uint4 zzww =>  uint4(z, z, w, w);
        
        /// <summary>
        /// Returns uint4.bbaa swizzling (equivalent to uint4.zzww).
        /// </summary>
        [Inline]
        public uint4 bbaa =>  uint4(z, z, w, w);
        
        /// <summary>
        /// Returns uint4.zw swizzling.
        /// </summary>
        [Inline]
        public uint2 zw =>  uint2(z, w);
        
        /// <summary>
        /// Returns uint4.ba swizzling (equivalent to uint4.zw).
        /// </summary>
        [Inline]
        public uint2 ba =>  uint2(z, w);
        
        /// <summary>
        /// Returns uint4.zwx swizzling.
        /// </summary>
        [Inline]
        public uint3 zwx =>  uint3(z, w, x);
        
        /// <summary>
        /// Returns uint4.bar swizzling (equivalent to uint4.zwx).
        /// </summary>
        [Inline]
        public uint3 bar =>  uint3(z, w, x);
        
        /// <summary>
        /// Returns uint4.zwxx swizzling.
        /// </summary>
        [Inline]
        public uint4 zwxx =>  uint4(z, w, x, x);
        
        /// <summary>
        /// Returns uint4.barr swizzling (equivalent to uint4.zwxx).
        /// </summary>
        [Inline]
        public uint4 barr =>  uint4(z, w, x, x);
        
        /// <summary>
        /// Returns uint4.zwxy swizzling.
        /// </summary>
        [Inline]
        public uint4 zwxy =>  uint4(z, w, x, y);
        
        /// <summary>
        /// Returns uint4.barg swizzling (equivalent to uint4.zwxy).
        /// </summary>
        [Inline]
        public uint4 barg =>  uint4(z, w, x, y);
        
        /// <summary>
        /// Returns uint4.zwxz swizzling.
        /// </summary>
        [Inline]
        public uint4 zwxz =>  uint4(z, w, x, z);
        
        /// <summary>
        /// Returns uint4.barb swizzling (equivalent to uint4.zwxz).
        /// </summary>
        [Inline]
        public uint4 barb =>  uint4(z, w, x, z);
        
        /// <summary>
        /// Returns uint4.zwxw swizzling.
        /// </summary>
        [Inline]
        public uint4 zwxw =>  uint4(z, w, x, w);
        
        /// <summary>
        /// Returns uint4.bara swizzling (equivalent to uint4.zwxw).
        /// </summary>
        [Inline]
        public uint4 bara =>  uint4(z, w, x, w);
        
        /// <summary>
        /// Returns uint4.zwy swizzling.
        /// </summary>
        [Inline]
        public uint3 zwy =>  uint3(z, w, y);
        
        /// <summary>
        /// Returns uint4.bag swizzling (equivalent to uint4.zwy).
        /// </summary>
        [Inline]
        public uint3 bag =>  uint3(z, w, y);
        
        /// <summary>
        /// Returns uint4.zwyx swizzling.
        /// </summary>
        [Inline]
        public uint4 zwyx =>  uint4(z, w, y, x);
        
        /// <summary>
        /// Returns uint4.bagr swizzling (equivalent to uint4.zwyx).
        /// </summary>
        [Inline]
        public uint4 bagr =>  uint4(z, w, y, x);
        
        /// <summary>
        /// Returns uint4.zwyy swizzling.
        /// </summary>
        [Inline]
        public uint4 zwyy =>  uint4(z, w, y, y);
        
        /// <summary>
        /// Returns uint4.bagg swizzling (equivalent to uint4.zwyy).
        /// </summary>
        [Inline]
        public uint4 bagg =>  uint4(z, w, y, y);
        
        /// <summary>
        /// Returns uint4.zwyz swizzling.
        /// </summary>
        [Inline]
        public uint4 zwyz =>  uint4(z, w, y, z);
        
        /// <summary>
        /// Returns uint4.bagb swizzling (equivalent to uint4.zwyz).
        /// </summary>
        [Inline]
        public uint4 bagb =>  uint4(z, w, y, z);
        
        /// <summary>
        /// Returns uint4.zwyw swizzling.
        /// </summary>
        [Inline]
        public uint4 zwyw =>  uint4(z, w, y, w);
        
        /// <summary>
        /// Returns uint4.baga swizzling (equivalent to uint4.zwyw).
        /// </summary>
        [Inline]
        public uint4 baga =>  uint4(z, w, y, w);
        
        /// <summary>
        /// Returns uint4.zwz swizzling.
        /// </summary>
        [Inline]
        public uint3 zwz =>  uint3(z, w, z);
        
        /// <summary>
        /// Returns uint4.bab swizzling (equivalent to uint4.zwz).
        /// </summary>
        [Inline]
        public uint3 bab =>  uint3(z, w, z);
        
        /// <summary>
        /// Returns uint4.zwzx swizzling.
        /// </summary>
        [Inline]
        public uint4 zwzx =>  uint4(z, w, z, x);
        
        /// <summary>
        /// Returns uint4.babr swizzling (equivalent to uint4.zwzx).
        /// </summary>
        [Inline]
        public uint4 babr =>  uint4(z, w, z, x);
        
        /// <summary>
        /// Returns uint4.zwzy swizzling.
        /// </summary>
        [Inline]
        public uint4 zwzy =>  uint4(z, w, z, y);
        
        /// <summary>
        /// Returns uint4.babg swizzling (equivalent to uint4.zwzy).
        /// </summary>
        [Inline]
        public uint4 babg =>  uint4(z, w, z, y);
        
        /// <summary>
        /// Returns uint4.zwzz swizzling.
        /// </summary>
        [Inline]
        public uint4 zwzz =>  uint4(z, w, z, z);
        
        /// <summary>
        /// Returns uint4.babb swizzling (equivalent to uint4.zwzz).
        /// </summary>
        [Inline]
        public uint4 babb =>  uint4(z, w, z, z);
        
        /// <summary>
        /// Returns uint4.zwzw swizzling.
        /// </summary>
        [Inline]
        public uint4 zwzw =>  uint4(z, w, z, w);
        
        /// <summary>
        /// Returns uint4.baba swizzling (equivalent to uint4.zwzw).
        /// </summary>
        [Inline]
        public uint4 baba =>  uint4(z, w, z, w);
        
        /// <summary>
        /// Returns uint4.zww swizzling.
        /// </summary>
        [Inline]
        public uint3 zww =>  uint3(z, w, w);
        
        /// <summary>
        /// Returns uint4.baa swizzling (equivalent to uint4.zww).
        /// </summary>
        [Inline]
        public uint3 baa =>  uint3(z, w, w);
        
        /// <summary>
        /// Returns uint4.zwwx swizzling.
        /// </summary>
        [Inline]
        public uint4 zwwx =>  uint4(z, w, w, x);
        
        /// <summary>
        /// Returns uint4.baar swizzling (equivalent to uint4.zwwx).
        /// </summary>
        [Inline]
        public uint4 baar =>  uint4(z, w, w, x);
        
        /// <summary>
        /// Returns uint4.zwwy swizzling.
        /// </summary>
        [Inline]
        public uint4 zwwy =>  uint4(z, w, w, y);
        
        /// <summary>
        /// Returns uint4.baag swizzling (equivalent to uint4.zwwy).
        /// </summary>
        [Inline]
        public uint4 baag =>  uint4(z, w, w, y);
        
        /// <summary>
        /// Returns uint4.zwwz swizzling.
        /// </summary>
        [Inline]
        public uint4 zwwz =>  uint4(z, w, w, z);
        
        /// <summary>
        /// Returns uint4.baab swizzling (equivalent to uint4.zwwz).
        /// </summary>
        [Inline]
        public uint4 baab =>  uint4(z, w, w, z);
        
        /// <summary>
        /// Returns uint4.zwww swizzling.
        /// </summary>
        [Inline]
        public uint4 zwww =>  uint4(z, w, w, w);
        
        /// <summary>
        /// Returns uint4.baaa swizzling (equivalent to uint4.zwww).
        /// </summary>
        [Inline]
        public uint4 baaa =>  uint4(z, w, w, w);
        
        /// <summary>
        /// Returns uint4.wx swizzling.
        /// </summary>
        [Inline]
        public uint2 wx =>  uint2(w, x);
        
        /// <summary>
        /// Returns uint4.ar swizzling (equivalent to uint4.wx).
        /// </summary>
        [Inline]
        public uint2 ar =>  uint2(w, x);
        
        /// <summary>
        /// Returns uint4.wxx swizzling.
        /// </summary>
        [Inline]
        public uint3 wxx =>  uint3(w, x, x);
        
        /// <summary>
        /// Returns uint4.arr swizzling (equivalent to uint4.wxx).
        /// </summary>
        [Inline]
        public uint3 arr =>  uint3(w, x, x);
        
        /// <summary>
        /// Returns uint4.wxxx swizzling.
        /// </summary>
        [Inline]
        public uint4 wxxx =>  uint4(w, x, x, x);
        
        /// <summary>
        /// Returns uint4.arrr swizzling (equivalent to uint4.wxxx).
        /// </summary>
        [Inline]
        public uint4 arrr =>  uint4(w, x, x, x);
        
        /// <summary>
        /// Returns uint4.wxxy swizzling.
        /// </summary>
        [Inline]
        public uint4 wxxy =>  uint4(w, x, x, y);
        
        /// <summary>
        /// Returns uint4.arrg swizzling (equivalent to uint4.wxxy).
        /// </summary>
        [Inline]
        public uint4 arrg =>  uint4(w, x, x, y);
        
        /// <summary>
        /// Returns uint4.wxxz swizzling.
        /// </summary>
        [Inline]
        public uint4 wxxz =>  uint4(w, x, x, z);
        
        /// <summary>
        /// Returns uint4.arrb swizzling (equivalent to uint4.wxxz).
        /// </summary>
        [Inline]
        public uint4 arrb =>  uint4(w, x, x, z);
        
        /// <summary>
        /// Returns uint4.wxxw swizzling.
        /// </summary>
        [Inline]
        public uint4 wxxw =>  uint4(w, x, x, w);
        
        /// <summary>
        /// Returns uint4.arra swizzling (equivalent to uint4.wxxw).
        /// </summary>
        [Inline]
        public uint4 arra =>  uint4(w, x, x, w);
        
        /// <summary>
        /// Returns uint4.wxy swizzling.
        /// </summary>
        [Inline]
        public uint3 wxy =>  uint3(w, x, y);
        
        /// <summary>
        /// Returns uint4.arg swizzling (equivalent to uint4.wxy).
        /// </summary>
        [Inline]
        public uint3 arg =>  uint3(w, x, y);
        
        /// <summary>
        /// Returns uint4.wxyx swizzling.
        /// </summary>
        [Inline]
        public uint4 wxyx =>  uint4(w, x, y, x);
        
        /// <summary>
        /// Returns uint4.argr swizzling (equivalent to uint4.wxyx).
        /// </summary>
        [Inline]
        public uint4 argr =>  uint4(w, x, y, x);
        
        /// <summary>
        /// Returns uint4.wxyy swizzling.
        /// </summary>
        [Inline]
        public uint4 wxyy =>  uint4(w, x, y, y);
        
        /// <summary>
        /// Returns uint4.argg swizzling (equivalent to uint4.wxyy).
        /// </summary>
        [Inline]
        public uint4 argg =>  uint4(w, x, y, y);
        
        /// <summary>
        /// Returns uint4.wxyz swizzling.
        /// </summary>
        [Inline]
        public uint4 wxyz =>  uint4(w, x, y, z);
        
        /// <summary>
        /// Returns uint4.argb swizzling (equivalent to uint4.wxyz).
        /// </summary>
        [Inline]
        public uint4 argb =>  uint4(w, x, y, z);
        
        /// <summary>
        /// Returns uint4.wxyw swizzling.
        /// </summary>
        [Inline]
        public uint4 wxyw =>  uint4(w, x, y, w);
        
        /// <summary>
        /// Returns uint4.arga swizzling (equivalent to uint4.wxyw).
        /// </summary>
        [Inline]
        public uint4 arga =>  uint4(w, x, y, w);
        
        /// <summary>
        /// Returns uint4.wxz swizzling.
        /// </summary>
        [Inline]
        public uint3 wxz =>  uint3(w, x, z);
        
        /// <summary>
        /// Returns uint4.arb swizzling (equivalent to uint4.wxz).
        /// </summary>
        [Inline]
        public uint3 arb =>  uint3(w, x, z);
        
        /// <summary>
        /// Returns uint4.wxzx swizzling.
        /// </summary>
        [Inline]
        public uint4 wxzx =>  uint4(w, x, z, x);
        
        /// <summary>
        /// Returns uint4.arbr swizzling (equivalent to uint4.wxzx).
        /// </summary>
        [Inline]
        public uint4 arbr =>  uint4(w, x, z, x);
        
        /// <summary>
        /// Returns uint4.wxzy swizzling.
        /// </summary>
        [Inline]
        public uint4 wxzy =>  uint4(w, x, z, y);
        
        /// <summary>
        /// Returns uint4.arbg swizzling (equivalent to uint4.wxzy).
        /// </summary>
        [Inline]
        public uint4 arbg =>  uint4(w, x, z, y);
        
        /// <summary>
        /// Returns uint4.wxzz swizzling.
        /// </summary>
        [Inline]
        public uint4 wxzz =>  uint4(w, x, z, z);
        
        /// <summary>
        /// Returns uint4.arbb swizzling (equivalent to uint4.wxzz).
        /// </summary>
        [Inline]
        public uint4 arbb =>  uint4(w, x, z, z);
        
        /// <summary>
        /// Returns uint4.wxzw swizzling.
        /// </summary>
        [Inline]
        public uint4 wxzw =>  uint4(w, x, z, w);
        
        /// <summary>
        /// Returns uint4.arba swizzling (equivalent to uint4.wxzw).
        /// </summary>
        [Inline]
        public uint4 arba =>  uint4(w, x, z, w);
        
        /// <summary>
        /// Returns uint4.wxw swizzling.
        /// </summary>
        [Inline]
        public uint3 wxw =>  uint3(w, x, w);
        
        /// <summary>
        /// Returns uint4.ara swizzling (equivalent to uint4.wxw).
        /// </summary>
        [Inline]
        public uint3 ara =>  uint3(w, x, w);
        
        /// <summary>
        /// Returns uint4.wxwx swizzling.
        /// </summary>
        [Inline]
        public uint4 wxwx =>  uint4(w, x, w, x);
        
        /// <summary>
        /// Returns uint4.arar swizzling (equivalent to uint4.wxwx).
        /// </summary>
        [Inline]
        public uint4 arar =>  uint4(w, x, w, x);
        
        /// <summary>
        /// Returns uint4.wxwy swizzling.
        /// </summary>
        [Inline]
        public uint4 wxwy =>  uint4(w, x, w, y);
        
        /// <summary>
        /// Returns uint4.arag swizzling (equivalent to uint4.wxwy).
        /// </summary>
        [Inline]
        public uint4 arag =>  uint4(w, x, w, y);
        
        /// <summary>
        /// Returns uint4.wxwz swizzling.
        /// </summary>
        [Inline]
        public uint4 wxwz =>  uint4(w, x, w, z);
        
        /// <summary>
        /// Returns uint4.arab swizzling (equivalent to uint4.wxwz).
        /// </summary>
        [Inline]
        public uint4 arab =>  uint4(w, x, w, z);
        
        /// <summary>
        /// Returns uint4.wxww swizzling.
        /// </summary>
        [Inline]
        public uint4 wxww =>  uint4(w, x, w, w);
        
        /// <summary>
        /// Returns uint4.araa swizzling (equivalent to uint4.wxww).
        /// </summary>
        [Inline]
        public uint4 araa =>  uint4(w, x, w, w);
        
        /// <summary>
        /// Returns uint4.wy swizzling.
        /// </summary>
        [Inline]
        public uint2 wy =>  uint2(w, y);
        
        /// <summary>
        /// Returns uint4.ag swizzling (equivalent to uint4.wy).
        /// </summary>
        [Inline]
        public uint2 ag =>  uint2(w, y);
        
        /// <summary>
        /// Returns uint4.wyx swizzling.
        /// </summary>
        [Inline]
        public uint3 wyx =>  uint3(w, y, x);
        
        /// <summary>
        /// Returns uint4.agr swizzling (equivalent to uint4.wyx).
        /// </summary>
        [Inline]
        public uint3 agr =>  uint3(w, y, x);
        
        /// <summary>
        /// Returns uint4.wyxx swizzling.
        /// </summary>
        [Inline]
        public uint4 wyxx =>  uint4(w, y, x, x);
        
        /// <summary>
        /// Returns uint4.agrr swizzling (equivalent to uint4.wyxx).
        /// </summary>
        [Inline]
        public uint4 agrr =>  uint4(w, y, x, x);
        
        /// <summary>
        /// Returns uint4.wyxy swizzling.
        /// </summary>
        [Inline]
        public uint4 wyxy =>  uint4(w, y, x, y);
        
        /// <summary>
        /// Returns uint4.agrg swizzling (equivalent to uint4.wyxy).
        /// </summary>
        [Inline]
        public uint4 agrg =>  uint4(w, y, x, y);
        
        /// <summary>
        /// Returns uint4.wyxz swizzling.
        /// </summary>
        [Inline]
        public uint4 wyxz =>  uint4(w, y, x, z);
        
        /// <summary>
        /// Returns uint4.agrb swizzling (equivalent to uint4.wyxz).
        /// </summary>
        [Inline]
        public uint4 agrb =>  uint4(w, y, x, z);
        
        /// <summary>
        /// Returns uint4.wyxw swizzling.
        /// </summary>
        [Inline]
        public uint4 wyxw =>  uint4(w, y, x, w);
        
        /// <summary>
        /// Returns uint4.agra swizzling (equivalent to uint4.wyxw).
        /// </summary>
        [Inline]
        public uint4 agra =>  uint4(w, y, x, w);
        
        /// <summary>
        /// Returns uint4.wyy swizzling.
        /// </summary>
        [Inline]
        public uint3 wyy =>  uint3(w, y, y);
        
        /// <summary>
        /// Returns uint4.agg swizzling (equivalent to uint4.wyy).
        /// </summary>
        [Inline]
        public uint3 agg =>  uint3(w, y, y);
        
        /// <summary>
        /// Returns uint4.wyyx swizzling.
        /// </summary>
        [Inline]
        public uint4 wyyx =>  uint4(w, y, y, x);
        
        /// <summary>
        /// Returns uint4.aggr swizzling (equivalent to uint4.wyyx).
        /// </summary>
        [Inline]
        public uint4 aggr =>  uint4(w, y, y, x);
        
        /// <summary>
        /// Returns uint4.wyyy swizzling.
        /// </summary>
        [Inline]
        public uint4 wyyy =>  uint4(w, y, y, y);
        
        /// <summary>
        /// Returns uint4.aggg swizzling (equivalent to uint4.wyyy).
        /// </summary>
        [Inline]
        public uint4 aggg =>  uint4(w, y, y, y);
        
        /// <summary>
        /// Returns uint4.wyyz swizzling.
        /// </summary>
        [Inline]
        public uint4 wyyz =>  uint4(w, y, y, z);
        
        /// <summary>
        /// Returns uint4.aggb swizzling (equivalent to uint4.wyyz).
        /// </summary>
        [Inline]
        public uint4 aggb =>  uint4(w, y, y, z);
        
        /// <summary>
        /// Returns uint4.wyyw swizzling.
        /// </summary>
        [Inline]
        public uint4 wyyw =>  uint4(w, y, y, w);
        
        /// <summary>
        /// Returns uint4.agga swizzling (equivalent to uint4.wyyw).
        /// </summary>
        [Inline]
        public uint4 agga =>  uint4(w, y, y, w);
        
        /// <summary>
        /// Returns uint4.wyz swizzling.
        /// </summary>
        [Inline]
        public uint3 wyz =>  uint3(w, y, z);
        
        /// <summary>
        /// Returns uint4.agb swizzling (equivalent to uint4.wyz).
        /// </summary>
        [Inline]
        public uint3 agb =>  uint3(w, y, z);
        
        /// <summary>
        /// Returns uint4.wyzx swizzling.
        /// </summary>
        [Inline]
        public uint4 wyzx =>  uint4(w, y, z, x);
        
        /// <summary>
        /// Returns uint4.agbr swizzling (equivalent to uint4.wyzx).
        /// </summary>
        [Inline]
        public uint4 agbr =>  uint4(w, y, z, x);
        
        /// <summary>
        /// Returns uint4.wyzy swizzling.
        /// </summary>
        [Inline]
        public uint4 wyzy =>  uint4(w, y, z, y);
        
        /// <summary>
        /// Returns uint4.agbg swizzling (equivalent to uint4.wyzy).
        /// </summary>
        [Inline]
        public uint4 agbg =>  uint4(w, y, z, y);
        
        /// <summary>
        /// Returns uint4.wyzz swizzling.
        /// </summary>
        [Inline]
        public uint4 wyzz =>  uint4(w, y, z, z);
        
        /// <summary>
        /// Returns uint4.agbb swizzling (equivalent to uint4.wyzz).
        /// </summary>
        [Inline]
        public uint4 agbb =>  uint4(w, y, z, z);
        
        /// <summary>
        /// Returns uint4.wyzw swizzling.
        /// </summary>
        [Inline]
        public uint4 wyzw =>  uint4(w, y, z, w);
        
        /// <summary>
        /// Returns uint4.agba swizzling (equivalent to uint4.wyzw).
        /// </summary>
        [Inline]
        public uint4 agba =>  uint4(w, y, z, w);
        
        /// <summary>
        /// Returns uint4.wyw swizzling.
        /// </summary>
        [Inline]
        public uint3 wyw =>  uint3(w, y, w);
        
        /// <summary>
        /// Returns uint4.aga swizzling (equivalent to uint4.wyw).
        /// </summary>
        [Inline]
        public uint3 aga =>  uint3(w, y, w);
        
        /// <summary>
        /// Returns uint4.wywx swizzling.
        /// </summary>
        [Inline]
        public uint4 wywx =>  uint4(w, y, w, x);
        
        /// <summary>
        /// Returns uint4.agar swizzling (equivalent to uint4.wywx).
        /// </summary>
        [Inline]
        public uint4 agar =>  uint4(w, y, w, x);
        
        /// <summary>
        /// Returns uint4.wywy swizzling.
        /// </summary>
        [Inline]
        public uint4 wywy =>  uint4(w, y, w, y);
        
        /// <summary>
        /// Returns uint4.agag swizzling (equivalent to uint4.wywy).
        /// </summary>
        [Inline]
        public uint4 agag =>  uint4(w, y, w, y);
        
        /// <summary>
        /// Returns uint4.wywz swizzling.
        /// </summary>
        [Inline]
        public uint4 wywz =>  uint4(w, y, w, z);
        
        /// <summary>
        /// Returns uint4.agab swizzling (equivalent to uint4.wywz).
        /// </summary>
        [Inline]
        public uint4 agab =>  uint4(w, y, w, z);
        
        /// <summary>
        /// Returns uint4.wyww swizzling.
        /// </summary>
        [Inline]
        public uint4 wyww =>  uint4(w, y, w, w);
        
        /// <summary>
        /// Returns uint4.agaa swizzling (equivalent to uint4.wyww).
        /// </summary>
        [Inline]
        public uint4 agaa =>  uint4(w, y, w, w);
        
        /// <summary>
        /// Returns uint4.wz swizzling.
        /// </summary>
        [Inline]
        public uint2 wz =>  uint2(w, z);
        
        /// <summary>
        /// Returns uint4.ab swizzling (equivalent to uint4.wz).
        /// </summary>
        [Inline]
        public uint2 ab =>  uint2(w, z);
        
        /// <summary>
        /// Returns uint4.wzx swizzling.
        /// </summary>
        [Inline]
        public uint3 wzx =>  uint3(w, z, x);
        
        /// <summary>
        /// Returns uint4.abr swizzling (equivalent to uint4.wzx).
        /// </summary>
        [Inline]
        public uint3 abr =>  uint3(w, z, x);
        
        /// <summary>
        /// Returns uint4.wzxx swizzling.
        /// </summary>
        [Inline]
        public uint4 wzxx =>  uint4(w, z, x, x);
        
        /// <summary>
        /// Returns uint4.abrr swizzling (equivalent to uint4.wzxx).
        /// </summary>
        [Inline]
        public uint4 abrr =>  uint4(w, z, x, x);
        
        /// <summary>
        /// Returns uint4.wzxy swizzling.
        /// </summary>
        [Inline]
        public uint4 wzxy =>  uint4(w, z, x, y);
        
        /// <summary>
        /// Returns uint4.abrg swizzling (equivalent to uint4.wzxy).
        /// </summary>
        [Inline]
        public uint4 abrg =>  uint4(w, z, x, y);
        
        /// <summary>
        /// Returns uint4.wzxz swizzling.
        /// </summary>
        [Inline]
        public uint4 wzxz =>  uint4(w, z, x, z);
        
        /// <summary>
        /// Returns uint4.abrb swizzling (equivalent to uint4.wzxz).
        /// </summary>
        [Inline]
        public uint4 abrb =>  uint4(w, z, x, z);
        
        /// <summary>
        /// Returns uint4.wzxw swizzling.
        /// </summary>
        [Inline]
        public uint4 wzxw =>  uint4(w, z, x, w);
        
        /// <summary>
        /// Returns uint4.abra swizzling (equivalent to uint4.wzxw).
        /// </summary>
        [Inline]
        public uint4 abra =>  uint4(w, z, x, w);
        
        /// <summary>
        /// Returns uint4.wzy swizzling.
        /// </summary>
        [Inline]
        public uint3 wzy =>  uint3(w, z, y);
        
        /// <summary>
        /// Returns uint4.abg swizzling (equivalent to uint4.wzy).
        /// </summary>
        [Inline]
        public uint3 abg =>  uint3(w, z, y);
        
        /// <summary>
        /// Returns uint4.wzyx swizzling.
        /// </summary>
        [Inline]
        public uint4 wzyx =>  uint4(w, z, y, x);
        
        /// <summary>
        /// Returns uint4.abgr swizzling (equivalent to uint4.wzyx).
        /// </summary>
        [Inline]
        public uint4 abgr =>  uint4(w, z, y, x);
        
        /// <summary>
        /// Returns uint4.wzyy swizzling.
        /// </summary>
        [Inline]
        public uint4 wzyy =>  uint4(w, z, y, y);
        
        /// <summary>
        /// Returns uint4.abgg swizzling (equivalent to uint4.wzyy).
        /// </summary>
        [Inline]
        public uint4 abgg =>  uint4(w, z, y, y);
        
        /// <summary>
        /// Returns uint4.wzyz swizzling.
        /// </summary>
        [Inline]
        public uint4 wzyz =>  uint4(w, z, y, z);
        
        /// <summary>
        /// Returns uint4.abgb swizzling (equivalent to uint4.wzyz).
        /// </summary>
        [Inline]
        public uint4 abgb =>  uint4(w, z, y, z);
        
        /// <summary>
        /// Returns uint4.wzyw swizzling.
        /// </summary>
        [Inline]
        public uint4 wzyw =>  uint4(w, z, y, w);
        
        /// <summary>
        /// Returns uint4.abga swizzling (equivalent to uint4.wzyw).
        /// </summary>
        [Inline]
        public uint4 abga =>  uint4(w, z, y, w);
        
        /// <summary>
        /// Returns uint4.wzz swizzling.
        /// </summary>
        [Inline]
        public uint3 wzz =>  uint3(w, z, z);
        
        /// <summary>
        /// Returns uint4.abb swizzling (equivalent to uint4.wzz).
        /// </summary>
        [Inline]
        public uint3 abb =>  uint3(w, z, z);
        
        /// <summary>
        /// Returns uint4.wzzx swizzling.
        /// </summary>
        [Inline]
        public uint4 wzzx =>  uint4(w, z, z, x);
        
        /// <summary>
        /// Returns uint4.abbr swizzling (equivalent to uint4.wzzx).
        /// </summary>
        [Inline]
        public uint4 abbr =>  uint4(w, z, z, x);
        
        /// <summary>
        /// Returns uint4.wzzy swizzling.
        /// </summary>
        [Inline]
        public uint4 wzzy =>  uint4(w, z, z, y);
        
        /// <summary>
        /// Returns uint4.abbg swizzling (equivalent to uint4.wzzy).
        /// </summary>
        [Inline]
        public uint4 abbg =>  uint4(w, z, z, y);
        
        /// <summary>
        /// Returns uint4.wzzz swizzling.
        /// </summary>
        [Inline]
        public uint4 wzzz =>  uint4(w, z, z, z);
        
        /// <summary>
        /// Returns uint4.abbb swizzling (equivalent to uint4.wzzz).
        /// </summary>
        [Inline]
        public uint4 abbb =>  uint4(w, z, z, z);
        
        /// <summary>
        /// Returns uint4.wzzw swizzling.
        /// </summary>
        [Inline]
        public uint4 wzzw =>  uint4(w, z, z, w);
        
        /// <summary>
        /// Returns uint4.abba swizzling (equivalent to uint4.wzzw).
        /// </summary>
        [Inline]
        public uint4 abba =>  uint4(w, z, z, w);
        
        /// <summary>
        /// Returns uint4.wzw swizzling.
        /// </summary>
        [Inline]
        public uint3 wzw =>  uint3(w, z, w);
        
        /// <summary>
        /// Returns uint4.aba swizzling (equivalent to uint4.wzw).
        /// </summary>
        [Inline]
        public uint3 aba =>  uint3(w, z, w);
        
        /// <summary>
        /// Returns uint4.wzwx swizzling.
        /// </summary>
        [Inline]
        public uint4 wzwx =>  uint4(w, z, w, x);
        
        /// <summary>
        /// Returns uint4.abar swizzling (equivalent to uint4.wzwx).
        /// </summary>
        [Inline]
        public uint4 abar =>  uint4(w, z, w, x);
        
        /// <summary>
        /// Returns uint4.wzwy swizzling.
        /// </summary>
        [Inline]
        public uint4 wzwy =>  uint4(w, z, w, y);
        
        /// <summary>
        /// Returns uint4.abag swizzling (equivalent to uint4.wzwy).
        /// </summary>
        [Inline]
        public uint4 abag =>  uint4(w, z, w, y);
        
        /// <summary>
        /// Returns uint4.wzwz swizzling.
        /// </summary>
        [Inline]
        public uint4 wzwz =>  uint4(w, z, w, z);
        
        /// <summary>
        /// Returns uint4.abab swizzling (equivalent to uint4.wzwz).
        /// </summary>
        [Inline]
        public uint4 abab =>  uint4(w, z, w, z);
        
        /// <summary>
        /// Returns uint4.wzww swizzling.
        /// </summary>
        [Inline]
        public uint4 wzww =>  uint4(w, z, w, w);
        
        /// <summary>
        /// Returns uint4.abaa swizzling (equivalent to uint4.wzww).
        /// </summary>
        [Inline]
        public uint4 abaa =>  uint4(w, z, w, w);
        
        /// <summary>
        /// Returns uint4.ww swizzling.
        /// </summary>
        [Inline]
        public uint2 ww =>  uint2(w, w);
        
        /// <summary>
        /// Returns uint4.aa swizzling (equivalent to uint4.ww).
        /// </summary>
        [Inline]
        public uint2 aa =>  uint2(w, w);
        
        /// <summary>
        /// Returns uint4.wwx swizzling.
        /// </summary>
        [Inline]
        public uint3 wwx =>  uint3(w, w, x);
        
        /// <summary>
        /// Returns uint4.aar swizzling (equivalent to uint4.wwx).
        /// </summary>
        [Inline]
        public uint3 aar =>  uint3(w, w, x);
        
        /// <summary>
        /// Returns uint4.wwxx swizzling.
        /// </summary>
        [Inline]
        public uint4 wwxx =>  uint4(w, w, x, x);
        
        /// <summary>
        /// Returns uint4.aarr swizzling (equivalent to uint4.wwxx).
        /// </summary>
        [Inline]
        public uint4 aarr =>  uint4(w, w, x, x);
        
        /// <summary>
        /// Returns uint4.wwxy swizzling.
        /// </summary>
        [Inline]
        public uint4 wwxy =>  uint4(w, w, x, y);
        
        /// <summary>
        /// Returns uint4.aarg swizzling (equivalent to uint4.wwxy).
        /// </summary>
        [Inline]
        public uint4 aarg =>  uint4(w, w, x, y);
        
        /// <summary>
        /// Returns uint4.wwxz swizzling.
        /// </summary>
        [Inline]
        public uint4 wwxz =>  uint4(w, w, x, z);
        
        /// <summary>
        /// Returns uint4.aarb swizzling (equivalent to uint4.wwxz).
        /// </summary>
        [Inline]
        public uint4 aarb =>  uint4(w, w, x, z);
        
        /// <summary>
        /// Returns uint4.wwxw swizzling.
        /// </summary>
        [Inline]
        public uint4 wwxw =>  uint4(w, w, x, w);
        
        /// <summary>
        /// Returns uint4.aara swizzling (equivalent to uint4.wwxw).
        /// </summary>
        [Inline]
        public uint4 aara =>  uint4(w, w, x, w);
        
        /// <summary>
        /// Returns uint4.wwy swizzling.
        /// </summary>
        [Inline]
        public uint3 wwy =>  uint3(w, w, y);
        
        /// <summary>
        /// Returns uint4.aag swizzling (equivalent to uint4.wwy).
        /// </summary>
        [Inline]
        public uint3 aag =>  uint3(w, w, y);
        
        /// <summary>
        /// Returns uint4.wwyx swizzling.
        /// </summary>
        [Inline]
        public uint4 wwyx =>  uint4(w, w, y, x);
        
        /// <summary>
        /// Returns uint4.aagr swizzling (equivalent to uint4.wwyx).
        /// </summary>
        [Inline]
        public uint4 aagr =>  uint4(w, w, y, x);
        
        /// <summary>
        /// Returns uint4.wwyy swizzling.
        /// </summary>
        [Inline]
        public uint4 wwyy =>  uint4(w, w, y, y);
        
        /// <summary>
        /// Returns uint4.aagg swizzling (equivalent to uint4.wwyy).
        /// </summary>
        [Inline]
        public uint4 aagg =>  uint4(w, w, y, y);
        
        /// <summary>
        /// Returns uint4.wwyz swizzling.
        /// </summary>
        [Inline]
        public uint4 wwyz =>  uint4(w, w, y, z);
        
        /// <summary>
        /// Returns uint4.aagb swizzling (equivalent to uint4.wwyz).
        /// </summary>
        [Inline]
        public uint4 aagb =>  uint4(w, w, y, z);
        
        /// <summary>
        /// Returns uint4.wwyw swizzling.
        /// </summary>
        [Inline]
        public uint4 wwyw =>  uint4(w, w, y, w);
        
        /// <summary>
        /// Returns uint4.aaga swizzling (equivalent to uint4.wwyw).
        /// </summary>
        [Inline]
        public uint4 aaga =>  uint4(w, w, y, w);
        
        /// <summary>
        /// Returns uint4.wwz swizzling.
        /// </summary>
        [Inline]
        public uint3 wwz =>  uint3(w, w, z);
        
        /// <summary>
        /// Returns uint4.aab swizzling (equivalent to uint4.wwz).
        /// </summary>
        [Inline]
        public uint3 aab =>  uint3(w, w, z);
        
        /// <summary>
        /// Returns uint4.wwzx swizzling.
        /// </summary>
        [Inline]
        public uint4 wwzx =>  uint4(w, w, z, x);
        
        /// <summary>
        /// Returns uint4.aabr swizzling (equivalent to uint4.wwzx).
        /// </summary>
        [Inline]
        public uint4 aabr =>  uint4(w, w, z, x);
        
        /// <summary>
        /// Returns uint4.wwzy swizzling.
        /// </summary>
        [Inline]
        public uint4 wwzy =>  uint4(w, w, z, y);
        
        /// <summary>
        /// Returns uint4.aabg swizzling (equivalent to uint4.wwzy).
        /// </summary>
        [Inline]
        public uint4 aabg =>  uint4(w, w, z, y);
        
        /// <summary>
        /// Returns uint4.wwzz swizzling.
        /// </summary>
        [Inline]
        public uint4 wwzz =>  uint4(w, w, z, z);
        
        /// <summary>
        /// Returns uint4.aabb swizzling (equivalent to uint4.wwzz).
        /// </summary>
        [Inline]
        public uint4 aabb =>  uint4(w, w, z, z);
        
        /// <summary>
        /// Returns uint4.wwzw swizzling.
        /// </summary>
        [Inline]
        public uint4 wwzw =>  uint4(w, w, z, w);
        
        /// <summary>
        /// Returns uint4.aaba swizzling (equivalent to uint4.wwzw).
        /// </summary>
        [Inline]
        public uint4 aaba =>  uint4(w, w, z, w);
        
        /// <summary>
        /// Returns uint4.www swizzling.
        /// </summary>
        [Inline]
        public uint3 www =>  uint3(w, w, w);
        
        /// <summary>
        /// Returns uint4.aaa swizzling (equivalent to uint4.www).
        /// </summary>
        [Inline]
        public uint3 aaa =>  uint3(w, w, w);
        
        /// <summary>
        /// Returns uint4.wwwx swizzling.
        /// </summary>
        [Inline]
        public uint4 wwwx =>  uint4(w, w, w, x);
        
        /// <summary>
        /// Returns uint4.aaar swizzling (equivalent to uint4.wwwx).
        /// </summary>
        [Inline]
        public uint4 aaar =>  uint4(w, w, w, x);
        
        /// <summary>
        /// Returns uint4.wwwy swizzling.
        /// </summary>
        [Inline]
        public uint4 wwwy =>  uint4(w, w, w, y);
        
        /// <summary>
        /// Returns uint4.aaag swizzling (equivalent to uint4.wwwy).
        /// </summary>
        [Inline]
        public uint4 aaag =>  uint4(w, w, w, y);
        
        /// <summary>
        /// Returns uint4.wwwz swizzling.
        /// </summary>
        [Inline]
        public uint4 wwwz =>  uint4(w, w, w, z);
        
        /// <summary>
        /// Returns uint4.aaab swizzling (equivalent to uint4.wwwz).
        /// </summary>
        [Inline]
        public uint4 aaab =>  uint4(w, w, w, z);
        
        /// <summary>
        /// Returns uint4.wwww swizzling.
        /// </summary>
        [Inline]
        public uint4 wwww =>  uint4(w, w, w, w);
        
        /// <summary>
        /// Returns uint4.aaaa swizzling (equivalent to uint4.wwww).
        /// </summary>
        [Inline]
        public uint4 aaaa =>  uint4(w, w, w, w);

        //#endregion

    }
}
