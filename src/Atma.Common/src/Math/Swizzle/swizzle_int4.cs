using System;
namespace Atma
{
    
    /// <summary>
    /// Temporary vector of type int with 4 components, used for implementing swizzling for int4.
    /// </summary>
    public struct swizzle_int4
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
        
        /// <summary>
        /// z-component
        /// </summary>
        private readonly int z;
        
        /// <summary>
        /// w-component
        /// </summary>
        private readonly int w;

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Returns int4.xx swizzling.
        /// </summary>
        [Inline]
        public int2 xx =>  int2(x, x);
        
        /// <summary>
        /// Returns int4.rr swizzling (equivalent to int4.xx).
        /// </summary>
        [Inline]
        public int2 rr =>  int2(x, x);
        
        /// <summary>
        /// Returns int4.xxx swizzling.
        /// </summary>
        [Inline]
        public int3 xxx =>  int3(x, x, x);
        
        /// <summary>
        /// Returns int4.rrr swizzling (equivalent to int4.xxx).
        /// </summary>
        [Inline]
        public int3 rrr =>  int3(x, x, x);
        
        /// <summary>
        /// Returns int4.xxxx swizzling.
        /// </summary>
        [Inline]
        public int4 xxxx =>  int4(x, x, x, x);
        
        /// <summary>
        /// Returns int4.rrrr swizzling (equivalent to int4.xxxx).
        /// </summary>
        [Inline]
        public int4 rrrr =>  int4(x, x, x, x);
        
        /// <summary>
        /// Returns int4.xxxy swizzling.
        /// </summary>
        [Inline]
        public int4 xxxy =>  int4(x, x, x, y);
        
        /// <summary>
        /// Returns int4.rrrg swizzling (equivalent to int4.xxxy).
        /// </summary>
        [Inline]
        public int4 rrrg =>  int4(x, x, x, y);
        
        /// <summary>
        /// Returns int4.xxxz swizzling.
        /// </summary>
        [Inline]
        public int4 xxxz =>  int4(x, x, x, z);
        
        /// <summary>
        /// Returns int4.rrrb swizzling (equivalent to int4.xxxz).
        /// </summary>
        [Inline]
        public int4 rrrb =>  int4(x, x, x, z);
        
        /// <summary>
        /// Returns int4.xxxw swizzling.
        /// </summary>
        [Inline]
        public int4 xxxw =>  int4(x, x, x, w);
        
        /// <summary>
        /// Returns int4.rrra swizzling (equivalent to int4.xxxw).
        /// </summary>
        [Inline]
        public int4 rrra =>  int4(x, x, x, w);
        
        /// <summary>
        /// Returns int4.xxy swizzling.
        /// </summary>
        [Inline]
        public int3 xxy =>  int3(x, x, y);
        
        /// <summary>
        /// Returns int4.rrg swizzling (equivalent to int4.xxy).
        /// </summary>
        [Inline]
        public int3 rrg =>  int3(x, x, y);
        
        /// <summary>
        /// Returns int4.xxyx swizzling.
        /// </summary>
        [Inline]
        public int4 xxyx =>  int4(x, x, y, x);
        
        /// <summary>
        /// Returns int4.rrgr swizzling (equivalent to int4.xxyx).
        /// </summary>
        [Inline]
        public int4 rrgr =>  int4(x, x, y, x);
        
        /// <summary>
        /// Returns int4.xxyy swizzling.
        /// </summary>
        [Inline]
        public int4 xxyy =>  int4(x, x, y, y);
        
        /// <summary>
        /// Returns int4.rrgg swizzling (equivalent to int4.xxyy).
        /// </summary>
        [Inline]
        public int4 rrgg =>  int4(x, x, y, y);
        
        /// <summary>
        /// Returns int4.xxyz swizzling.
        /// </summary>
        [Inline]
        public int4 xxyz =>  int4(x, x, y, z);
        
        /// <summary>
        /// Returns int4.rrgb swizzling (equivalent to int4.xxyz).
        /// </summary>
        [Inline]
        public int4 rrgb =>  int4(x, x, y, z);
        
        /// <summary>
        /// Returns int4.xxyw swizzling.
        /// </summary>
        [Inline]
        public int4 xxyw =>  int4(x, x, y, w);
        
        /// <summary>
        /// Returns int4.rrga swizzling (equivalent to int4.xxyw).
        /// </summary>
        [Inline]
        public int4 rrga =>  int4(x, x, y, w);
        
        /// <summary>
        /// Returns int4.xxz swizzling.
        /// </summary>
        [Inline]
        public int3 xxz =>  int3(x, x, z);
        
        /// <summary>
        /// Returns int4.rrb swizzling (equivalent to int4.xxz).
        /// </summary>
        [Inline]
        public int3 rrb =>  int3(x, x, z);
        
        /// <summary>
        /// Returns int4.xxzx swizzling.
        /// </summary>
        [Inline]
        public int4 xxzx =>  int4(x, x, z, x);
        
        /// <summary>
        /// Returns int4.rrbr swizzling (equivalent to int4.xxzx).
        /// </summary>
        [Inline]
        public int4 rrbr =>  int4(x, x, z, x);
        
        /// <summary>
        /// Returns int4.xxzy swizzling.
        /// </summary>
        [Inline]
        public int4 xxzy =>  int4(x, x, z, y);
        
        /// <summary>
        /// Returns int4.rrbg swizzling (equivalent to int4.xxzy).
        /// </summary>
        [Inline]
        public int4 rrbg =>  int4(x, x, z, y);
        
        /// <summary>
        /// Returns int4.xxzz swizzling.
        /// </summary>
        [Inline]
        public int4 xxzz =>  int4(x, x, z, z);
        
        /// <summary>
        /// Returns int4.rrbb swizzling (equivalent to int4.xxzz).
        /// </summary>
        [Inline]
        public int4 rrbb =>  int4(x, x, z, z);
        
        /// <summary>
        /// Returns int4.xxzw swizzling.
        /// </summary>
        [Inline]
        public int4 xxzw =>  int4(x, x, z, w);
        
        /// <summary>
        /// Returns int4.rrba swizzling (equivalent to int4.xxzw).
        /// </summary>
        [Inline]
        public int4 rrba =>  int4(x, x, z, w);
        
        /// <summary>
        /// Returns int4.xxw swizzling.
        /// </summary>
        [Inline]
        public int3 xxw =>  int3(x, x, w);
        
        /// <summary>
        /// Returns int4.rra swizzling (equivalent to int4.xxw).
        /// </summary>
        [Inline]
        public int3 rra =>  int3(x, x, w);
        
        /// <summary>
        /// Returns int4.xxwx swizzling.
        /// </summary>
        [Inline]
        public int4 xxwx =>  int4(x, x, w, x);
        
        /// <summary>
        /// Returns int4.rrar swizzling (equivalent to int4.xxwx).
        /// </summary>
        [Inline]
        public int4 rrar =>  int4(x, x, w, x);
        
        /// <summary>
        /// Returns int4.xxwy swizzling.
        /// </summary>
        [Inline]
        public int4 xxwy =>  int4(x, x, w, y);
        
        /// <summary>
        /// Returns int4.rrag swizzling (equivalent to int4.xxwy).
        /// </summary>
        [Inline]
        public int4 rrag =>  int4(x, x, w, y);
        
        /// <summary>
        /// Returns int4.xxwz swizzling.
        /// </summary>
        [Inline]
        public int4 xxwz =>  int4(x, x, w, z);
        
        /// <summary>
        /// Returns int4.rrab swizzling (equivalent to int4.xxwz).
        /// </summary>
        [Inline]
        public int4 rrab =>  int4(x, x, w, z);
        
        /// <summary>
        /// Returns int4.xxww swizzling.
        /// </summary>
        [Inline]
        public int4 xxww =>  int4(x, x, w, w);
        
        /// <summary>
        /// Returns int4.rraa swizzling (equivalent to int4.xxww).
        /// </summary>
        [Inline]
        public int4 rraa =>  int4(x, x, w, w);
        
        /// <summary>
        /// Returns int4.xy swizzling.
        /// </summary>
        [Inline]
        public int2 xy =>  int2(x, y);
        
        /// <summary>
        /// Returns int4.rg swizzling (equivalent to int4.xy).
        /// </summary>
        [Inline]
        public int2 rg =>  int2(x, y);
        
        /// <summary>
        /// Returns int4.xyx swizzling.
        /// </summary>
        [Inline]
        public int3 xyx =>  int3(x, y, x);
        
        /// <summary>
        /// Returns int4.rgr swizzling (equivalent to int4.xyx).
        /// </summary>
        [Inline]
        public int3 rgr =>  int3(x, y, x);
        
        /// <summary>
        /// Returns int4.xyxx swizzling.
        /// </summary>
        [Inline]
        public int4 xyxx =>  int4(x, y, x, x);
        
        /// <summary>
        /// Returns int4.rgrr swizzling (equivalent to int4.xyxx).
        /// </summary>
        [Inline]
        public int4 rgrr =>  int4(x, y, x, x);
        
        /// <summary>
        /// Returns int4.xyxy swizzling.
        /// </summary>
        [Inline]
        public int4 xyxy =>  int4(x, y, x, y);
        
        /// <summary>
        /// Returns int4.rgrg swizzling (equivalent to int4.xyxy).
        /// </summary>
        [Inline]
        public int4 rgrg =>  int4(x, y, x, y);
        
        /// <summary>
        /// Returns int4.xyxz swizzling.
        /// </summary>
        [Inline]
        public int4 xyxz =>  int4(x, y, x, z);
        
        /// <summary>
        /// Returns int4.rgrb swizzling (equivalent to int4.xyxz).
        /// </summary>
        [Inline]
        public int4 rgrb =>  int4(x, y, x, z);
        
        /// <summary>
        /// Returns int4.xyxw swizzling.
        /// </summary>
        [Inline]
        public int4 xyxw =>  int4(x, y, x, w);
        
        /// <summary>
        /// Returns int4.rgra swizzling (equivalent to int4.xyxw).
        /// </summary>
        [Inline]
        public int4 rgra =>  int4(x, y, x, w);
        
        /// <summary>
        /// Returns int4.xyy swizzling.
        /// </summary>
        [Inline]
        public int3 xyy =>  int3(x, y, y);
        
        /// <summary>
        /// Returns int4.rgg swizzling (equivalent to int4.xyy).
        /// </summary>
        [Inline]
        public int3 rgg =>  int3(x, y, y);
        
        /// <summary>
        /// Returns int4.xyyx swizzling.
        /// </summary>
        [Inline]
        public int4 xyyx =>  int4(x, y, y, x);
        
        /// <summary>
        /// Returns int4.rggr swizzling (equivalent to int4.xyyx).
        /// </summary>
        [Inline]
        public int4 rggr =>  int4(x, y, y, x);
        
        /// <summary>
        /// Returns int4.xyyy swizzling.
        /// </summary>
        [Inline]
        public int4 xyyy =>  int4(x, y, y, y);
        
        /// <summary>
        /// Returns int4.rggg swizzling (equivalent to int4.xyyy).
        /// </summary>
        [Inline]
        public int4 rggg =>  int4(x, y, y, y);
        
        /// <summary>
        /// Returns int4.xyyz swizzling.
        /// </summary>
        [Inline]
        public int4 xyyz =>  int4(x, y, y, z);
        
        /// <summary>
        /// Returns int4.rggb swizzling (equivalent to int4.xyyz).
        /// </summary>
        [Inline]
        public int4 rggb =>  int4(x, y, y, z);
        
        /// <summary>
        /// Returns int4.xyyw swizzling.
        /// </summary>
        [Inline]
        public int4 xyyw =>  int4(x, y, y, w);
        
        /// <summary>
        /// Returns int4.rgga swizzling (equivalent to int4.xyyw).
        /// </summary>
        [Inline]
        public int4 rgga =>  int4(x, y, y, w);
        
        /// <summary>
        /// Returns int4.xyz swizzling.
        /// </summary>
        [Inline]
        public int3 xyz =>  int3(x, y, z);
        
        /// <summary>
        /// Returns int4.rgb swizzling (equivalent to int4.xyz).
        /// </summary>
        [Inline]
        public int3 rgb =>  int3(x, y, z);
        
        /// <summary>
        /// Returns int4.xyzx swizzling.
        /// </summary>
        [Inline]
        public int4 xyzx =>  int4(x, y, z, x);
        
        /// <summary>
        /// Returns int4.rgbr swizzling (equivalent to int4.xyzx).
        /// </summary>
        [Inline]
        public int4 rgbr =>  int4(x, y, z, x);
        
        /// <summary>
        /// Returns int4.xyzy swizzling.
        /// </summary>
        [Inline]
        public int4 xyzy =>  int4(x, y, z, y);
        
        /// <summary>
        /// Returns int4.rgbg swizzling (equivalent to int4.xyzy).
        /// </summary>
        [Inline]
        public int4 rgbg =>  int4(x, y, z, y);
        
        /// <summary>
        /// Returns int4.xyzz swizzling.
        /// </summary>
        [Inline]
        public int4 xyzz =>  int4(x, y, z, z);
        
        /// <summary>
        /// Returns int4.rgbb swizzling (equivalent to int4.xyzz).
        /// </summary>
        [Inline]
        public int4 rgbb =>  int4(x, y, z, z);
        
        /// <summary>
        /// Returns int4.xyzw swizzling.
        /// </summary>
        [Inline]
        public int4 xyzw =>  int4(x, y, z, w);
        
        /// <summary>
        /// Returns int4.rgba swizzling (equivalent to int4.xyzw).
        /// </summary>
        [Inline]
        public int4 rgba =>  int4(x, y, z, w);
        
        /// <summary>
        /// Returns int4.xyw swizzling.
        /// </summary>
        [Inline]
        public int3 xyw =>  int3(x, y, w);
        
        /// <summary>
        /// Returns int4.rga swizzling (equivalent to int4.xyw).
        /// </summary>
        [Inline]
        public int3 rga =>  int3(x, y, w);
        
        /// <summary>
        /// Returns int4.xywx swizzling.
        /// </summary>
        [Inline]
        public int4 xywx =>  int4(x, y, w, x);
        
        /// <summary>
        /// Returns int4.rgar swizzling (equivalent to int4.xywx).
        /// </summary>
        [Inline]
        public int4 rgar =>  int4(x, y, w, x);
        
        /// <summary>
        /// Returns int4.xywy swizzling.
        /// </summary>
        [Inline]
        public int4 xywy =>  int4(x, y, w, y);
        
        /// <summary>
        /// Returns int4.rgag swizzling (equivalent to int4.xywy).
        /// </summary>
        [Inline]
        public int4 rgag =>  int4(x, y, w, y);
        
        /// <summary>
        /// Returns int4.xywz swizzling.
        /// </summary>
        [Inline]
        public int4 xywz =>  int4(x, y, w, z);
        
        /// <summary>
        /// Returns int4.rgab swizzling (equivalent to int4.xywz).
        /// </summary>
        [Inline]
        public int4 rgab =>  int4(x, y, w, z);
        
        /// <summary>
        /// Returns int4.xyww swizzling.
        /// </summary>
        [Inline]
        public int4 xyww =>  int4(x, y, w, w);
        
        /// <summary>
        /// Returns int4.rgaa swizzling (equivalent to int4.xyww).
        /// </summary>
        [Inline]
        public int4 rgaa =>  int4(x, y, w, w);
        
        /// <summary>
        /// Returns int4.xz swizzling.
        /// </summary>
        [Inline]
        public int2 xz =>  int2(x, z);
        
        /// <summary>
        /// Returns int4.rb swizzling (equivalent to int4.xz).
        /// </summary>
        [Inline]
        public int2 rb =>  int2(x, z);
        
        /// <summary>
        /// Returns int4.xzx swizzling.
        /// </summary>
        [Inline]
        public int3 xzx =>  int3(x, z, x);
        
        /// <summary>
        /// Returns int4.rbr swizzling (equivalent to int4.xzx).
        /// </summary>
        [Inline]
        public int3 rbr =>  int3(x, z, x);
        
        /// <summary>
        /// Returns int4.xzxx swizzling.
        /// </summary>
        [Inline]
        public int4 xzxx =>  int4(x, z, x, x);
        
        /// <summary>
        /// Returns int4.rbrr swizzling (equivalent to int4.xzxx).
        /// </summary>
        [Inline]
        public int4 rbrr =>  int4(x, z, x, x);
        
        /// <summary>
        /// Returns int4.xzxy swizzling.
        /// </summary>
        [Inline]
        public int4 xzxy =>  int4(x, z, x, y);
        
        /// <summary>
        /// Returns int4.rbrg swizzling (equivalent to int4.xzxy).
        /// </summary>
        [Inline]
        public int4 rbrg =>  int4(x, z, x, y);
        
        /// <summary>
        /// Returns int4.xzxz swizzling.
        /// </summary>
        [Inline]
        public int4 xzxz =>  int4(x, z, x, z);
        
        /// <summary>
        /// Returns int4.rbrb swizzling (equivalent to int4.xzxz).
        /// </summary>
        [Inline]
        public int4 rbrb =>  int4(x, z, x, z);
        
        /// <summary>
        /// Returns int4.xzxw swizzling.
        /// </summary>
        [Inline]
        public int4 xzxw =>  int4(x, z, x, w);
        
        /// <summary>
        /// Returns int4.rbra swizzling (equivalent to int4.xzxw).
        /// </summary>
        [Inline]
        public int4 rbra =>  int4(x, z, x, w);
        
        /// <summary>
        /// Returns int4.xzy swizzling.
        /// </summary>
        [Inline]
        public int3 xzy =>  int3(x, z, y);
        
        /// <summary>
        /// Returns int4.rbg swizzling (equivalent to int4.xzy).
        /// </summary>
        [Inline]
        public int3 rbg =>  int3(x, z, y);
        
        /// <summary>
        /// Returns int4.xzyx swizzling.
        /// </summary>
        [Inline]
        public int4 xzyx =>  int4(x, z, y, x);
        
        /// <summary>
        /// Returns int4.rbgr swizzling (equivalent to int4.xzyx).
        /// </summary>
        [Inline]
        public int4 rbgr =>  int4(x, z, y, x);
        
        /// <summary>
        /// Returns int4.xzyy swizzling.
        /// </summary>
        [Inline]
        public int4 xzyy =>  int4(x, z, y, y);
        
        /// <summary>
        /// Returns int4.rbgg swizzling (equivalent to int4.xzyy).
        /// </summary>
        [Inline]
        public int4 rbgg =>  int4(x, z, y, y);
        
        /// <summary>
        /// Returns int4.xzyz swizzling.
        /// </summary>
        [Inline]
        public int4 xzyz =>  int4(x, z, y, z);
        
        /// <summary>
        /// Returns int4.rbgb swizzling (equivalent to int4.xzyz).
        /// </summary>
        [Inline]
        public int4 rbgb =>  int4(x, z, y, z);
        
        /// <summary>
        /// Returns int4.xzyw swizzling.
        /// </summary>
        [Inline]
        public int4 xzyw =>  int4(x, z, y, w);
        
        /// <summary>
        /// Returns int4.rbga swizzling (equivalent to int4.xzyw).
        /// </summary>
        [Inline]
        public int4 rbga =>  int4(x, z, y, w);
        
        /// <summary>
        /// Returns int4.xzz swizzling.
        /// </summary>
        [Inline]
        public int3 xzz =>  int3(x, z, z);
        
        /// <summary>
        /// Returns int4.rbb swizzling (equivalent to int4.xzz).
        /// </summary>
        [Inline]
        public int3 rbb =>  int3(x, z, z);
        
        /// <summary>
        /// Returns int4.xzzx swizzling.
        /// </summary>
        [Inline]
        public int4 xzzx =>  int4(x, z, z, x);
        
        /// <summary>
        /// Returns int4.rbbr swizzling (equivalent to int4.xzzx).
        /// </summary>
        [Inline]
        public int4 rbbr =>  int4(x, z, z, x);
        
        /// <summary>
        /// Returns int4.xzzy swizzling.
        /// </summary>
        [Inline]
        public int4 xzzy =>  int4(x, z, z, y);
        
        /// <summary>
        /// Returns int4.rbbg swizzling (equivalent to int4.xzzy).
        /// </summary>
        [Inline]
        public int4 rbbg =>  int4(x, z, z, y);
        
        /// <summary>
        /// Returns int4.xzzz swizzling.
        /// </summary>
        [Inline]
        public int4 xzzz =>  int4(x, z, z, z);
        
        /// <summary>
        /// Returns int4.rbbb swizzling (equivalent to int4.xzzz).
        /// </summary>
        [Inline]
        public int4 rbbb =>  int4(x, z, z, z);
        
        /// <summary>
        /// Returns int4.xzzw swizzling.
        /// </summary>
        [Inline]
        public int4 xzzw =>  int4(x, z, z, w);
        
        /// <summary>
        /// Returns int4.rbba swizzling (equivalent to int4.xzzw).
        /// </summary>
        [Inline]
        public int4 rbba =>  int4(x, z, z, w);
        
        /// <summary>
        /// Returns int4.xzw swizzling.
        /// </summary>
        [Inline]
        public int3 xzw =>  int3(x, z, w);
        
        /// <summary>
        /// Returns int4.rba swizzling (equivalent to int4.xzw).
        /// </summary>
        [Inline]
        public int3 rba =>  int3(x, z, w);
        
        /// <summary>
        /// Returns int4.xzwx swizzling.
        /// </summary>
        [Inline]
        public int4 xzwx =>  int4(x, z, w, x);
        
        /// <summary>
        /// Returns int4.rbar swizzling (equivalent to int4.xzwx).
        /// </summary>
        [Inline]
        public int4 rbar =>  int4(x, z, w, x);
        
        /// <summary>
        /// Returns int4.xzwy swizzling.
        /// </summary>
        [Inline]
        public int4 xzwy =>  int4(x, z, w, y);
        
        /// <summary>
        /// Returns int4.rbag swizzling (equivalent to int4.xzwy).
        /// </summary>
        [Inline]
        public int4 rbag =>  int4(x, z, w, y);
        
        /// <summary>
        /// Returns int4.xzwz swizzling.
        /// </summary>
        [Inline]
        public int4 xzwz =>  int4(x, z, w, z);
        
        /// <summary>
        /// Returns int4.rbab swizzling (equivalent to int4.xzwz).
        /// </summary>
        [Inline]
        public int4 rbab =>  int4(x, z, w, z);
        
        /// <summary>
        /// Returns int4.xzww swizzling.
        /// </summary>
        [Inline]
        public int4 xzww =>  int4(x, z, w, w);
        
        /// <summary>
        /// Returns int4.rbaa swizzling (equivalent to int4.xzww).
        /// </summary>
        [Inline]
        public int4 rbaa =>  int4(x, z, w, w);
        
        /// <summary>
        /// Returns int4.xw swizzling.
        /// </summary>
        [Inline]
        public int2 xw =>  int2(x, w);
        
        /// <summary>
        /// Returns int4.ra swizzling (equivalent to int4.xw).
        /// </summary>
        [Inline]
        public int2 ra =>  int2(x, w);
        
        /// <summary>
        /// Returns int4.xwx swizzling.
        /// </summary>
        [Inline]
        public int3 xwx =>  int3(x, w, x);
        
        /// <summary>
        /// Returns int4.rar swizzling (equivalent to int4.xwx).
        /// </summary>
        [Inline]
        public int3 rar =>  int3(x, w, x);
        
        /// <summary>
        /// Returns int4.xwxx swizzling.
        /// </summary>
        [Inline]
        public int4 xwxx =>  int4(x, w, x, x);
        
        /// <summary>
        /// Returns int4.rarr swizzling (equivalent to int4.xwxx).
        /// </summary>
        [Inline]
        public int4 rarr =>  int4(x, w, x, x);
        
        /// <summary>
        /// Returns int4.xwxy swizzling.
        /// </summary>
        [Inline]
        public int4 xwxy =>  int4(x, w, x, y);
        
        /// <summary>
        /// Returns int4.rarg swizzling (equivalent to int4.xwxy).
        /// </summary>
        [Inline]
        public int4 rarg =>  int4(x, w, x, y);
        
        /// <summary>
        /// Returns int4.xwxz swizzling.
        /// </summary>
        [Inline]
        public int4 xwxz =>  int4(x, w, x, z);
        
        /// <summary>
        /// Returns int4.rarb swizzling (equivalent to int4.xwxz).
        /// </summary>
        [Inline]
        public int4 rarb =>  int4(x, w, x, z);
        
        /// <summary>
        /// Returns int4.xwxw swizzling.
        /// </summary>
        [Inline]
        public int4 xwxw =>  int4(x, w, x, w);
        
        /// <summary>
        /// Returns int4.rara swizzling (equivalent to int4.xwxw).
        /// </summary>
        [Inline]
        public int4 rara =>  int4(x, w, x, w);
        
        /// <summary>
        /// Returns int4.xwy swizzling.
        /// </summary>
        [Inline]
        public int3 xwy =>  int3(x, w, y);
        
        /// <summary>
        /// Returns int4.rag swizzling (equivalent to int4.xwy).
        /// </summary>
        [Inline]
        public int3 rag =>  int3(x, w, y);
        
        /// <summary>
        /// Returns int4.xwyx swizzling.
        /// </summary>
        [Inline]
        public int4 xwyx =>  int4(x, w, y, x);
        
        /// <summary>
        /// Returns int4.ragr swizzling (equivalent to int4.xwyx).
        /// </summary>
        [Inline]
        public int4 ragr =>  int4(x, w, y, x);
        
        /// <summary>
        /// Returns int4.xwyy swizzling.
        /// </summary>
        [Inline]
        public int4 xwyy =>  int4(x, w, y, y);
        
        /// <summary>
        /// Returns int4.ragg swizzling (equivalent to int4.xwyy).
        /// </summary>
        [Inline]
        public int4 ragg =>  int4(x, w, y, y);
        
        /// <summary>
        /// Returns int4.xwyz swizzling.
        /// </summary>
        [Inline]
        public int4 xwyz =>  int4(x, w, y, z);
        
        /// <summary>
        /// Returns int4.ragb swizzling (equivalent to int4.xwyz).
        /// </summary>
        [Inline]
        public int4 ragb =>  int4(x, w, y, z);
        
        /// <summary>
        /// Returns int4.xwyw swizzling.
        /// </summary>
        [Inline]
        public int4 xwyw =>  int4(x, w, y, w);
        
        /// <summary>
        /// Returns int4.raga swizzling (equivalent to int4.xwyw).
        /// </summary>
        [Inline]
        public int4 raga =>  int4(x, w, y, w);
        
        /// <summary>
        /// Returns int4.xwz swizzling.
        /// </summary>
        [Inline]
        public int3 xwz =>  int3(x, w, z);
        
        /// <summary>
        /// Returns int4.rab swizzling (equivalent to int4.xwz).
        /// </summary>
        [Inline]
        public int3 rab =>  int3(x, w, z);
        
        /// <summary>
        /// Returns int4.xwzx swizzling.
        /// </summary>
        [Inline]
        public int4 xwzx =>  int4(x, w, z, x);
        
        /// <summary>
        /// Returns int4.rabr swizzling (equivalent to int4.xwzx).
        /// </summary>
        [Inline]
        public int4 rabr =>  int4(x, w, z, x);
        
        /// <summary>
        /// Returns int4.xwzy swizzling.
        /// </summary>
        [Inline]
        public int4 xwzy =>  int4(x, w, z, y);
        
        /// <summary>
        /// Returns int4.rabg swizzling (equivalent to int4.xwzy).
        /// </summary>
        [Inline]
        public int4 rabg =>  int4(x, w, z, y);
        
        /// <summary>
        /// Returns int4.xwzz swizzling.
        /// </summary>
        [Inline]
        public int4 xwzz =>  int4(x, w, z, z);
        
        /// <summary>
        /// Returns int4.rabb swizzling (equivalent to int4.xwzz).
        /// </summary>
        [Inline]
        public int4 rabb =>  int4(x, w, z, z);
        
        /// <summary>
        /// Returns int4.xwzw swizzling.
        /// </summary>
        [Inline]
        public int4 xwzw =>  int4(x, w, z, w);
        
        /// <summary>
        /// Returns int4.raba swizzling (equivalent to int4.xwzw).
        /// </summary>
        [Inline]
        public int4 raba =>  int4(x, w, z, w);
        
        /// <summary>
        /// Returns int4.xww swizzling.
        /// </summary>
        [Inline]
        public int3 xww =>  int3(x, w, w);
        
        /// <summary>
        /// Returns int4.raa swizzling (equivalent to int4.xww).
        /// </summary>
        [Inline]
        public int3 raa =>  int3(x, w, w);
        
        /// <summary>
        /// Returns int4.xwwx swizzling.
        /// </summary>
        [Inline]
        public int4 xwwx =>  int4(x, w, w, x);
        
        /// <summary>
        /// Returns int4.raar swizzling (equivalent to int4.xwwx).
        /// </summary>
        [Inline]
        public int4 raar =>  int4(x, w, w, x);
        
        /// <summary>
        /// Returns int4.xwwy swizzling.
        /// </summary>
        [Inline]
        public int4 xwwy =>  int4(x, w, w, y);
        
        /// <summary>
        /// Returns int4.raag swizzling (equivalent to int4.xwwy).
        /// </summary>
        [Inline]
        public int4 raag =>  int4(x, w, w, y);
        
        /// <summary>
        /// Returns int4.xwwz swizzling.
        /// </summary>
        [Inline]
        public int4 xwwz =>  int4(x, w, w, z);
        
        /// <summary>
        /// Returns int4.raab swizzling (equivalent to int4.xwwz).
        /// </summary>
        [Inline]
        public int4 raab =>  int4(x, w, w, z);
        
        /// <summary>
        /// Returns int4.xwww swizzling.
        /// </summary>
        [Inline]
        public int4 xwww =>  int4(x, w, w, w);
        
        /// <summary>
        /// Returns int4.raaa swizzling (equivalent to int4.xwww).
        /// </summary>
        [Inline]
        public int4 raaa =>  int4(x, w, w, w);
        
        /// <summary>
        /// Returns int4.yx swizzling.
        /// </summary>
        [Inline]
        public int2 yx =>  int2(y, x);
        
        /// <summary>
        /// Returns int4.gr swizzling (equivalent to int4.yx).
        /// </summary>
        [Inline]
        public int2 gr =>  int2(y, x);
        
        /// <summary>
        /// Returns int4.yxx swizzling.
        /// </summary>
        [Inline]
        public int3 yxx =>  int3(y, x, x);
        
        /// <summary>
        /// Returns int4.grr swizzling (equivalent to int4.yxx).
        /// </summary>
        [Inline]
        public int3 grr =>  int3(y, x, x);
        
        /// <summary>
        /// Returns int4.yxxx swizzling.
        /// </summary>
        [Inline]
        public int4 yxxx =>  int4(y, x, x, x);
        
        /// <summary>
        /// Returns int4.grrr swizzling (equivalent to int4.yxxx).
        /// </summary>
        [Inline]
        public int4 grrr =>  int4(y, x, x, x);
        
        /// <summary>
        /// Returns int4.yxxy swizzling.
        /// </summary>
        [Inline]
        public int4 yxxy =>  int4(y, x, x, y);
        
        /// <summary>
        /// Returns int4.grrg swizzling (equivalent to int4.yxxy).
        /// </summary>
        [Inline]
        public int4 grrg =>  int4(y, x, x, y);
        
        /// <summary>
        /// Returns int4.yxxz swizzling.
        /// </summary>
        [Inline]
        public int4 yxxz =>  int4(y, x, x, z);
        
        /// <summary>
        /// Returns int4.grrb swizzling (equivalent to int4.yxxz).
        /// </summary>
        [Inline]
        public int4 grrb =>  int4(y, x, x, z);
        
        /// <summary>
        /// Returns int4.yxxw swizzling.
        /// </summary>
        [Inline]
        public int4 yxxw =>  int4(y, x, x, w);
        
        /// <summary>
        /// Returns int4.grra swizzling (equivalent to int4.yxxw).
        /// </summary>
        [Inline]
        public int4 grra =>  int4(y, x, x, w);
        
        /// <summary>
        /// Returns int4.yxy swizzling.
        /// </summary>
        [Inline]
        public int3 yxy =>  int3(y, x, y);
        
        /// <summary>
        /// Returns int4.grg swizzling (equivalent to int4.yxy).
        /// </summary>
        [Inline]
        public int3 grg =>  int3(y, x, y);
        
        /// <summary>
        /// Returns int4.yxyx swizzling.
        /// </summary>
        [Inline]
        public int4 yxyx =>  int4(y, x, y, x);
        
        /// <summary>
        /// Returns int4.grgr swizzling (equivalent to int4.yxyx).
        /// </summary>
        [Inline]
        public int4 grgr =>  int4(y, x, y, x);
        
        /// <summary>
        /// Returns int4.yxyy swizzling.
        /// </summary>
        [Inline]
        public int4 yxyy =>  int4(y, x, y, y);
        
        /// <summary>
        /// Returns int4.grgg swizzling (equivalent to int4.yxyy).
        /// </summary>
        [Inline]
        public int4 grgg =>  int4(y, x, y, y);
        
        /// <summary>
        /// Returns int4.yxyz swizzling.
        /// </summary>
        [Inline]
        public int4 yxyz =>  int4(y, x, y, z);
        
        /// <summary>
        /// Returns int4.grgb swizzling (equivalent to int4.yxyz).
        /// </summary>
        [Inline]
        public int4 grgb =>  int4(y, x, y, z);
        
        /// <summary>
        /// Returns int4.yxyw swizzling.
        /// </summary>
        [Inline]
        public int4 yxyw =>  int4(y, x, y, w);
        
        /// <summary>
        /// Returns int4.grga swizzling (equivalent to int4.yxyw).
        /// </summary>
        [Inline]
        public int4 grga =>  int4(y, x, y, w);
        
        /// <summary>
        /// Returns int4.yxz swizzling.
        /// </summary>
        [Inline]
        public int3 yxz =>  int3(y, x, z);
        
        /// <summary>
        /// Returns int4.grb swizzling (equivalent to int4.yxz).
        /// </summary>
        [Inline]
        public int3 grb =>  int3(y, x, z);
        
        /// <summary>
        /// Returns int4.yxzx swizzling.
        /// </summary>
        [Inline]
        public int4 yxzx =>  int4(y, x, z, x);
        
        /// <summary>
        /// Returns int4.grbr swizzling (equivalent to int4.yxzx).
        /// </summary>
        [Inline]
        public int4 grbr =>  int4(y, x, z, x);
        
        /// <summary>
        /// Returns int4.yxzy swizzling.
        /// </summary>
        [Inline]
        public int4 yxzy =>  int4(y, x, z, y);
        
        /// <summary>
        /// Returns int4.grbg swizzling (equivalent to int4.yxzy).
        /// </summary>
        [Inline]
        public int4 grbg =>  int4(y, x, z, y);
        
        /// <summary>
        /// Returns int4.yxzz swizzling.
        /// </summary>
        [Inline]
        public int4 yxzz =>  int4(y, x, z, z);
        
        /// <summary>
        /// Returns int4.grbb swizzling (equivalent to int4.yxzz).
        /// </summary>
        [Inline]
        public int4 grbb =>  int4(y, x, z, z);
        
        /// <summary>
        /// Returns int4.yxzw swizzling.
        /// </summary>
        [Inline]
        public int4 yxzw =>  int4(y, x, z, w);
        
        /// <summary>
        /// Returns int4.grba swizzling (equivalent to int4.yxzw).
        /// </summary>
        [Inline]
        public int4 grba =>  int4(y, x, z, w);
        
        /// <summary>
        /// Returns int4.yxw swizzling.
        /// </summary>
        [Inline]
        public int3 yxw =>  int3(y, x, w);
        
        /// <summary>
        /// Returns int4.gra swizzling (equivalent to int4.yxw).
        /// </summary>
        [Inline]
        public int3 gra =>  int3(y, x, w);
        
        /// <summary>
        /// Returns int4.yxwx swizzling.
        /// </summary>
        [Inline]
        public int4 yxwx =>  int4(y, x, w, x);
        
        /// <summary>
        /// Returns int4.grar swizzling (equivalent to int4.yxwx).
        /// </summary>
        [Inline]
        public int4 grar =>  int4(y, x, w, x);
        
        /// <summary>
        /// Returns int4.yxwy swizzling.
        /// </summary>
        [Inline]
        public int4 yxwy =>  int4(y, x, w, y);
        
        /// <summary>
        /// Returns int4.grag swizzling (equivalent to int4.yxwy).
        /// </summary>
        [Inline]
        public int4 grag =>  int4(y, x, w, y);
        
        /// <summary>
        /// Returns int4.yxwz swizzling.
        /// </summary>
        [Inline]
        public int4 yxwz =>  int4(y, x, w, z);
        
        /// <summary>
        /// Returns int4.grab swizzling (equivalent to int4.yxwz).
        /// </summary>
        [Inline]
        public int4 grab =>  int4(y, x, w, z);
        
        /// <summary>
        /// Returns int4.yxww swizzling.
        /// </summary>
        [Inline]
        public int4 yxww =>  int4(y, x, w, w);
        
        /// <summary>
        /// Returns int4.graa swizzling (equivalent to int4.yxww).
        /// </summary>
        [Inline]
        public int4 graa =>  int4(y, x, w, w);
        
        /// <summary>
        /// Returns int4.yy swizzling.
        /// </summary>
        [Inline]
        public int2 yy =>  int2(y, y);
        
        /// <summary>
        /// Returns int4.gg swizzling (equivalent to int4.yy).
        /// </summary>
        [Inline]
        public int2 gg =>  int2(y, y);
        
        /// <summary>
        /// Returns int4.yyx swizzling.
        /// </summary>
        [Inline]
        public int3 yyx =>  int3(y, y, x);
        
        /// <summary>
        /// Returns int4.ggr swizzling (equivalent to int4.yyx).
        /// </summary>
        [Inline]
        public int3 ggr =>  int3(y, y, x);
        
        /// <summary>
        /// Returns int4.yyxx swizzling.
        /// </summary>
        [Inline]
        public int4 yyxx =>  int4(y, y, x, x);
        
        /// <summary>
        /// Returns int4.ggrr swizzling (equivalent to int4.yyxx).
        /// </summary>
        [Inline]
        public int4 ggrr =>  int4(y, y, x, x);
        
        /// <summary>
        /// Returns int4.yyxy swizzling.
        /// </summary>
        [Inline]
        public int4 yyxy =>  int4(y, y, x, y);
        
        /// <summary>
        /// Returns int4.ggrg swizzling (equivalent to int4.yyxy).
        /// </summary>
        [Inline]
        public int4 ggrg =>  int4(y, y, x, y);
        
        /// <summary>
        /// Returns int4.yyxz swizzling.
        /// </summary>
        [Inline]
        public int4 yyxz =>  int4(y, y, x, z);
        
        /// <summary>
        /// Returns int4.ggrb swizzling (equivalent to int4.yyxz).
        /// </summary>
        [Inline]
        public int4 ggrb =>  int4(y, y, x, z);
        
        /// <summary>
        /// Returns int4.yyxw swizzling.
        /// </summary>
        [Inline]
        public int4 yyxw =>  int4(y, y, x, w);
        
        /// <summary>
        /// Returns int4.ggra swizzling (equivalent to int4.yyxw).
        /// </summary>
        [Inline]
        public int4 ggra =>  int4(y, y, x, w);
        
        /// <summary>
        /// Returns int4.yyy swizzling.
        /// </summary>
        [Inline]
        public int3 yyy =>  int3(y, y, y);
        
        /// <summary>
        /// Returns int4.ggg swizzling (equivalent to int4.yyy).
        /// </summary>
        [Inline]
        public int3 ggg =>  int3(y, y, y);
        
        /// <summary>
        /// Returns int4.yyyx swizzling.
        /// </summary>
        [Inline]
        public int4 yyyx =>  int4(y, y, y, x);
        
        /// <summary>
        /// Returns int4.gggr swizzling (equivalent to int4.yyyx).
        /// </summary>
        [Inline]
        public int4 gggr =>  int4(y, y, y, x);
        
        /// <summary>
        /// Returns int4.yyyy swizzling.
        /// </summary>
        [Inline]
        public int4 yyyy =>  int4(y, y, y, y);
        
        /// <summary>
        /// Returns int4.gggg swizzling (equivalent to int4.yyyy).
        /// </summary>
        [Inline]
        public int4 gggg =>  int4(y, y, y, y);
        
        /// <summary>
        /// Returns int4.yyyz swizzling.
        /// </summary>
        [Inline]
        public int4 yyyz =>  int4(y, y, y, z);
        
        /// <summary>
        /// Returns int4.gggb swizzling (equivalent to int4.yyyz).
        /// </summary>
        [Inline]
        public int4 gggb =>  int4(y, y, y, z);
        
        /// <summary>
        /// Returns int4.yyyw swizzling.
        /// </summary>
        [Inline]
        public int4 yyyw =>  int4(y, y, y, w);
        
        /// <summary>
        /// Returns int4.ggga swizzling (equivalent to int4.yyyw).
        /// </summary>
        [Inline]
        public int4 ggga =>  int4(y, y, y, w);
        
        /// <summary>
        /// Returns int4.yyz swizzling.
        /// </summary>
        [Inline]
        public int3 yyz =>  int3(y, y, z);
        
        /// <summary>
        /// Returns int4.ggb swizzling (equivalent to int4.yyz).
        /// </summary>
        [Inline]
        public int3 ggb =>  int3(y, y, z);
        
        /// <summary>
        /// Returns int4.yyzx swizzling.
        /// </summary>
        [Inline]
        public int4 yyzx =>  int4(y, y, z, x);
        
        /// <summary>
        /// Returns int4.ggbr swizzling (equivalent to int4.yyzx).
        /// </summary>
        [Inline]
        public int4 ggbr =>  int4(y, y, z, x);
        
        /// <summary>
        /// Returns int4.yyzy swizzling.
        /// </summary>
        [Inline]
        public int4 yyzy =>  int4(y, y, z, y);
        
        /// <summary>
        /// Returns int4.ggbg swizzling (equivalent to int4.yyzy).
        /// </summary>
        [Inline]
        public int4 ggbg =>  int4(y, y, z, y);
        
        /// <summary>
        /// Returns int4.yyzz swizzling.
        /// </summary>
        [Inline]
        public int4 yyzz =>  int4(y, y, z, z);
        
        /// <summary>
        /// Returns int4.ggbb swizzling (equivalent to int4.yyzz).
        /// </summary>
        [Inline]
        public int4 ggbb =>  int4(y, y, z, z);
        
        /// <summary>
        /// Returns int4.yyzw swizzling.
        /// </summary>
        [Inline]
        public int4 yyzw =>  int4(y, y, z, w);
        
        /// <summary>
        /// Returns int4.ggba swizzling (equivalent to int4.yyzw).
        /// </summary>
        [Inline]
        public int4 ggba =>  int4(y, y, z, w);
        
        /// <summary>
        /// Returns int4.yyw swizzling.
        /// </summary>
        [Inline]
        public int3 yyw =>  int3(y, y, w);
        
        /// <summary>
        /// Returns int4.gga swizzling (equivalent to int4.yyw).
        /// </summary>
        [Inline]
        public int3 gga =>  int3(y, y, w);
        
        /// <summary>
        /// Returns int4.yywx swizzling.
        /// </summary>
        [Inline]
        public int4 yywx =>  int4(y, y, w, x);
        
        /// <summary>
        /// Returns int4.ggar swizzling (equivalent to int4.yywx).
        /// </summary>
        [Inline]
        public int4 ggar =>  int4(y, y, w, x);
        
        /// <summary>
        /// Returns int4.yywy swizzling.
        /// </summary>
        [Inline]
        public int4 yywy =>  int4(y, y, w, y);
        
        /// <summary>
        /// Returns int4.ggag swizzling (equivalent to int4.yywy).
        /// </summary>
        [Inline]
        public int4 ggag =>  int4(y, y, w, y);
        
        /// <summary>
        /// Returns int4.yywz swizzling.
        /// </summary>
        [Inline]
        public int4 yywz =>  int4(y, y, w, z);
        
        /// <summary>
        /// Returns int4.ggab swizzling (equivalent to int4.yywz).
        /// </summary>
        [Inline]
        public int4 ggab =>  int4(y, y, w, z);
        
        /// <summary>
        /// Returns int4.yyww swizzling.
        /// </summary>
        [Inline]
        public int4 yyww =>  int4(y, y, w, w);
        
        /// <summary>
        /// Returns int4.ggaa swizzling (equivalent to int4.yyww).
        /// </summary>
        [Inline]
        public int4 ggaa =>  int4(y, y, w, w);
        
        /// <summary>
        /// Returns int4.yz swizzling.
        /// </summary>
        [Inline]
        public int2 yz =>  int2(y, z);
        
        /// <summary>
        /// Returns int4.gb swizzling (equivalent to int4.yz).
        /// </summary>
        [Inline]
        public int2 gb =>  int2(y, z);
        
        /// <summary>
        /// Returns int4.yzx swizzling.
        /// </summary>
        [Inline]
        public int3 yzx =>  int3(y, z, x);
        
        /// <summary>
        /// Returns int4.gbr swizzling (equivalent to int4.yzx).
        /// </summary>
        [Inline]
        public int3 gbr =>  int3(y, z, x);
        
        /// <summary>
        /// Returns int4.yzxx swizzling.
        /// </summary>
        [Inline]
        public int4 yzxx =>  int4(y, z, x, x);
        
        /// <summary>
        /// Returns int4.gbrr swizzling (equivalent to int4.yzxx).
        /// </summary>
        [Inline]
        public int4 gbrr =>  int4(y, z, x, x);
        
        /// <summary>
        /// Returns int4.yzxy swizzling.
        /// </summary>
        [Inline]
        public int4 yzxy =>  int4(y, z, x, y);
        
        /// <summary>
        /// Returns int4.gbrg swizzling (equivalent to int4.yzxy).
        /// </summary>
        [Inline]
        public int4 gbrg =>  int4(y, z, x, y);
        
        /// <summary>
        /// Returns int4.yzxz swizzling.
        /// </summary>
        [Inline]
        public int4 yzxz =>  int4(y, z, x, z);
        
        /// <summary>
        /// Returns int4.gbrb swizzling (equivalent to int4.yzxz).
        /// </summary>
        [Inline]
        public int4 gbrb =>  int4(y, z, x, z);
        
        /// <summary>
        /// Returns int4.yzxw swizzling.
        /// </summary>
        [Inline]
        public int4 yzxw =>  int4(y, z, x, w);
        
        /// <summary>
        /// Returns int4.gbra swizzling (equivalent to int4.yzxw).
        /// </summary>
        [Inline]
        public int4 gbra =>  int4(y, z, x, w);
        
        /// <summary>
        /// Returns int4.yzy swizzling.
        /// </summary>
        [Inline]
        public int3 yzy =>  int3(y, z, y);
        
        /// <summary>
        /// Returns int4.gbg swizzling (equivalent to int4.yzy).
        /// </summary>
        [Inline]
        public int3 gbg =>  int3(y, z, y);
        
        /// <summary>
        /// Returns int4.yzyx swizzling.
        /// </summary>
        [Inline]
        public int4 yzyx =>  int4(y, z, y, x);
        
        /// <summary>
        /// Returns int4.gbgr swizzling (equivalent to int4.yzyx).
        /// </summary>
        [Inline]
        public int4 gbgr =>  int4(y, z, y, x);
        
        /// <summary>
        /// Returns int4.yzyy swizzling.
        /// </summary>
        [Inline]
        public int4 yzyy =>  int4(y, z, y, y);
        
        /// <summary>
        /// Returns int4.gbgg swizzling (equivalent to int4.yzyy).
        /// </summary>
        [Inline]
        public int4 gbgg =>  int4(y, z, y, y);
        
        /// <summary>
        /// Returns int4.yzyz swizzling.
        /// </summary>
        [Inline]
        public int4 yzyz =>  int4(y, z, y, z);
        
        /// <summary>
        /// Returns int4.gbgb swizzling (equivalent to int4.yzyz).
        /// </summary>
        [Inline]
        public int4 gbgb =>  int4(y, z, y, z);
        
        /// <summary>
        /// Returns int4.yzyw swizzling.
        /// </summary>
        [Inline]
        public int4 yzyw =>  int4(y, z, y, w);
        
        /// <summary>
        /// Returns int4.gbga swizzling (equivalent to int4.yzyw).
        /// </summary>
        [Inline]
        public int4 gbga =>  int4(y, z, y, w);
        
        /// <summary>
        /// Returns int4.yzz swizzling.
        /// </summary>
        [Inline]
        public int3 yzz =>  int3(y, z, z);
        
        /// <summary>
        /// Returns int4.gbb swizzling (equivalent to int4.yzz).
        /// </summary>
        [Inline]
        public int3 gbb =>  int3(y, z, z);
        
        /// <summary>
        /// Returns int4.yzzx swizzling.
        /// </summary>
        [Inline]
        public int4 yzzx =>  int4(y, z, z, x);
        
        /// <summary>
        /// Returns int4.gbbr swizzling (equivalent to int4.yzzx).
        /// </summary>
        [Inline]
        public int4 gbbr =>  int4(y, z, z, x);
        
        /// <summary>
        /// Returns int4.yzzy swizzling.
        /// </summary>
        [Inline]
        public int4 yzzy =>  int4(y, z, z, y);
        
        /// <summary>
        /// Returns int4.gbbg swizzling (equivalent to int4.yzzy).
        /// </summary>
        [Inline]
        public int4 gbbg =>  int4(y, z, z, y);
        
        /// <summary>
        /// Returns int4.yzzz swizzling.
        /// </summary>
        [Inline]
        public int4 yzzz =>  int4(y, z, z, z);
        
        /// <summary>
        /// Returns int4.gbbb swizzling (equivalent to int4.yzzz).
        /// </summary>
        [Inline]
        public int4 gbbb =>  int4(y, z, z, z);
        
        /// <summary>
        /// Returns int4.yzzw swizzling.
        /// </summary>
        [Inline]
        public int4 yzzw =>  int4(y, z, z, w);
        
        /// <summary>
        /// Returns int4.gbba swizzling (equivalent to int4.yzzw).
        /// </summary>
        [Inline]
        public int4 gbba =>  int4(y, z, z, w);
        
        /// <summary>
        /// Returns int4.yzw swizzling.
        /// </summary>
        [Inline]
        public int3 yzw =>  int3(y, z, w);
        
        /// <summary>
        /// Returns int4.gba swizzling (equivalent to int4.yzw).
        /// </summary>
        [Inline]
        public int3 gba =>  int3(y, z, w);
        
        /// <summary>
        /// Returns int4.yzwx swizzling.
        /// </summary>
        [Inline]
        public int4 yzwx =>  int4(y, z, w, x);
        
        /// <summary>
        /// Returns int4.gbar swizzling (equivalent to int4.yzwx).
        /// </summary>
        [Inline]
        public int4 gbar =>  int4(y, z, w, x);
        
        /// <summary>
        /// Returns int4.yzwy swizzling.
        /// </summary>
        [Inline]
        public int4 yzwy =>  int4(y, z, w, y);
        
        /// <summary>
        /// Returns int4.gbag swizzling (equivalent to int4.yzwy).
        /// </summary>
        [Inline]
        public int4 gbag =>  int4(y, z, w, y);
        
        /// <summary>
        /// Returns int4.yzwz swizzling.
        /// </summary>
        [Inline]
        public int4 yzwz =>  int4(y, z, w, z);
        
        /// <summary>
        /// Returns int4.gbab swizzling (equivalent to int4.yzwz).
        /// </summary>
        [Inline]
        public int4 gbab =>  int4(y, z, w, z);
        
        /// <summary>
        /// Returns int4.yzww swizzling.
        /// </summary>
        [Inline]
        public int4 yzww =>  int4(y, z, w, w);
        
        /// <summary>
        /// Returns int4.gbaa swizzling (equivalent to int4.yzww).
        /// </summary>
        [Inline]
        public int4 gbaa =>  int4(y, z, w, w);
        
        /// <summary>
        /// Returns int4.yw swizzling.
        /// </summary>
        [Inline]
        public int2 yw =>  int2(y, w);
        
        /// <summary>
        /// Returns int4.ga swizzling (equivalent to int4.yw).
        /// </summary>
        [Inline]
        public int2 ga =>  int2(y, w);
        
        /// <summary>
        /// Returns int4.ywx swizzling.
        /// </summary>
        [Inline]
        public int3 ywx =>  int3(y, w, x);
        
        /// <summary>
        /// Returns int4.gar swizzling (equivalent to int4.ywx).
        /// </summary>
        [Inline]
        public int3 gar =>  int3(y, w, x);
        
        /// <summary>
        /// Returns int4.ywxx swizzling.
        /// </summary>
        [Inline]
        public int4 ywxx =>  int4(y, w, x, x);
        
        /// <summary>
        /// Returns int4.garr swizzling (equivalent to int4.ywxx).
        /// </summary>
        [Inline]
        public int4 garr =>  int4(y, w, x, x);
        
        /// <summary>
        /// Returns int4.ywxy swizzling.
        /// </summary>
        [Inline]
        public int4 ywxy =>  int4(y, w, x, y);
        
        /// <summary>
        /// Returns int4.garg swizzling (equivalent to int4.ywxy).
        /// </summary>
        [Inline]
        public int4 garg =>  int4(y, w, x, y);
        
        /// <summary>
        /// Returns int4.ywxz swizzling.
        /// </summary>
        [Inline]
        public int4 ywxz =>  int4(y, w, x, z);
        
        /// <summary>
        /// Returns int4.garb swizzling (equivalent to int4.ywxz).
        /// </summary>
        [Inline]
        public int4 garb =>  int4(y, w, x, z);
        
        /// <summary>
        /// Returns int4.ywxw swizzling.
        /// </summary>
        [Inline]
        public int4 ywxw =>  int4(y, w, x, w);
        
        /// <summary>
        /// Returns int4.gara swizzling (equivalent to int4.ywxw).
        /// </summary>
        [Inline]
        public int4 gara =>  int4(y, w, x, w);
        
        /// <summary>
        /// Returns int4.ywy swizzling.
        /// </summary>
        [Inline]
        public int3 ywy =>  int3(y, w, y);
        
        /// <summary>
        /// Returns int4.gag swizzling (equivalent to int4.ywy).
        /// </summary>
        [Inline]
        public int3 gag =>  int3(y, w, y);
        
        /// <summary>
        /// Returns int4.ywyx swizzling.
        /// </summary>
        [Inline]
        public int4 ywyx =>  int4(y, w, y, x);
        
        /// <summary>
        /// Returns int4.gagr swizzling (equivalent to int4.ywyx).
        /// </summary>
        [Inline]
        public int4 gagr =>  int4(y, w, y, x);
        
        /// <summary>
        /// Returns int4.ywyy swizzling.
        /// </summary>
        [Inline]
        public int4 ywyy =>  int4(y, w, y, y);
        
        /// <summary>
        /// Returns int4.gagg swizzling (equivalent to int4.ywyy).
        /// </summary>
        [Inline]
        public int4 gagg =>  int4(y, w, y, y);
        
        /// <summary>
        /// Returns int4.ywyz swizzling.
        /// </summary>
        [Inline]
        public int4 ywyz =>  int4(y, w, y, z);
        
        /// <summary>
        /// Returns int4.gagb swizzling (equivalent to int4.ywyz).
        /// </summary>
        [Inline]
        public int4 gagb =>  int4(y, w, y, z);
        
        /// <summary>
        /// Returns int4.ywyw swizzling.
        /// </summary>
        [Inline]
        public int4 ywyw =>  int4(y, w, y, w);
        
        /// <summary>
        /// Returns int4.gaga swizzling (equivalent to int4.ywyw).
        /// </summary>
        [Inline]
        public int4 gaga =>  int4(y, w, y, w);
        
        /// <summary>
        /// Returns int4.ywz swizzling.
        /// </summary>
        [Inline]
        public int3 ywz =>  int3(y, w, z);
        
        /// <summary>
        /// Returns int4.gab swizzling (equivalent to int4.ywz).
        /// </summary>
        [Inline]
        public int3 gab =>  int3(y, w, z);
        
        /// <summary>
        /// Returns int4.ywzx swizzling.
        /// </summary>
        [Inline]
        public int4 ywzx =>  int4(y, w, z, x);
        
        /// <summary>
        /// Returns int4.gabr swizzling (equivalent to int4.ywzx).
        /// </summary>
        [Inline]
        public int4 gabr =>  int4(y, w, z, x);
        
        /// <summary>
        /// Returns int4.ywzy swizzling.
        /// </summary>
        [Inline]
        public int4 ywzy =>  int4(y, w, z, y);
        
        /// <summary>
        /// Returns int4.gabg swizzling (equivalent to int4.ywzy).
        /// </summary>
        [Inline]
        public int4 gabg =>  int4(y, w, z, y);
        
        /// <summary>
        /// Returns int4.ywzz swizzling.
        /// </summary>
        [Inline]
        public int4 ywzz =>  int4(y, w, z, z);
        
        /// <summary>
        /// Returns int4.gabb swizzling (equivalent to int4.ywzz).
        /// </summary>
        [Inline]
        public int4 gabb =>  int4(y, w, z, z);
        
        /// <summary>
        /// Returns int4.ywzw swizzling.
        /// </summary>
        [Inline]
        public int4 ywzw =>  int4(y, w, z, w);
        
        /// <summary>
        /// Returns int4.gaba swizzling (equivalent to int4.ywzw).
        /// </summary>
        [Inline]
        public int4 gaba =>  int4(y, w, z, w);
        
        /// <summary>
        /// Returns int4.yww swizzling.
        /// </summary>
        [Inline]
        public int3 yww =>  int3(y, w, w);
        
        /// <summary>
        /// Returns int4.gaa swizzling (equivalent to int4.yww).
        /// </summary>
        [Inline]
        public int3 gaa =>  int3(y, w, w);
        
        /// <summary>
        /// Returns int4.ywwx swizzling.
        /// </summary>
        [Inline]
        public int4 ywwx =>  int4(y, w, w, x);
        
        /// <summary>
        /// Returns int4.gaar swizzling (equivalent to int4.ywwx).
        /// </summary>
        [Inline]
        public int4 gaar =>  int4(y, w, w, x);
        
        /// <summary>
        /// Returns int4.ywwy swizzling.
        /// </summary>
        [Inline]
        public int4 ywwy =>  int4(y, w, w, y);
        
        /// <summary>
        /// Returns int4.gaag swizzling (equivalent to int4.ywwy).
        /// </summary>
        [Inline]
        public int4 gaag =>  int4(y, w, w, y);
        
        /// <summary>
        /// Returns int4.ywwz swizzling.
        /// </summary>
        [Inline]
        public int4 ywwz =>  int4(y, w, w, z);
        
        /// <summary>
        /// Returns int4.gaab swizzling (equivalent to int4.ywwz).
        /// </summary>
        [Inline]
        public int4 gaab =>  int4(y, w, w, z);
        
        /// <summary>
        /// Returns int4.ywww swizzling.
        /// </summary>
        [Inline]
        public int4 ywww =>  int4(y, w, w, w);
        
        /// <summary>
        /// Returns int4.gaaa swizzling (equivalent to int4.ywww).
        /// </summary>
        [Inline]
        public int4 gaaa =>  int4(y, w, w, w);
        
        /// <summary>
        /// Returns int4.zx swizzling.
        /// </summary>
        [Inline]
        public int2 zx =>  int2(z, x);
        
        /// <summary>
        /// Returns int4.br swizzling (equivalent to int4.zx).
        /// </summary>
        [Inline]
        public int2 br =>  int2(z, x);
        
        /// <summary>
        /// Returns int4.zxx swizzling.
        /// </summary>
        [Inline]
        public int3 zxx =>  int3(z, x, x);
        
        /// <summary>
        /// Returns int4.brr swizzling (equivalent to int4.zxx).
        /// </summary>
        [Inline]
        public int3 brr =>  int3(z, x, x);
        
        /// <summary>
        /// Returns int4.zxxx swizzling.
        /// </summary>
        [Inline]
        public int4 zxxx =>  int4(z, x, x, x);
        
        /// <summary>
        /// Returns int4.brrr swizzling (equivalent to int4.zxxx).
        /// </summary>
        [Inline]
        public int4 brrr =>  int4(z, x, x, x);
        
        /// <summary>
        /// Returns int4.zxxy swizzling.
        /// </summary>
        [Inline]
        public int4 zxxy =>  int4(z, x, x, y);
        
        /// <summary>
        /// Returns int4.brrg swizzling (equivalent to int4.zxxy).
        /// </summary>
        [Inline]
        public int4 brrg =>  int4(z, x, x, y);
        
        /// <summary>
        /// Returns int4.zxxz swizzling.
        /// </summary>
        [Inline]
        public int4 zxxz =>  int4(z, x, x, z);
        
        /// <summary>
        /// Returns int4.brrb swizzling (equivalent to int4.zxxz).
        /// </summary>
        [Inline]
        public int4 brrb =>  int4(z, x, x, z);
        
        /// <summary>
        /// Returns int4.zxxw swizzling.
        /// </summary>
        [Inline]
        public int4 zxxw =>  int4(z, x, x, w);
        
        /// <summary>
        /// Returns int4.brra swizzling (equivalent to int4.zxxw).
        /// </summary>
        [Inline]
        public int4 brra =>  int4(z, x, x, w);
        
        /// <summary>
        /// Returns int4.zxy swizzling.
        /// </summary>
        [Inline]
        public int3 zxy =>  int3(z, x, y);
        
        /// <summary>
        /// Returns int4.brg swizzling (equivalent to int4.zxy).
        /// </summary>
        [Inline]
        public int3 brg =>  int3(z, x, y);
        
        /// <summary>
        /// Returns int4.zxyx swizzling.
        /// </summary>
        [Inline]
        public int4 zxyx =>  int4(z, x, y, x);
        
        /// <summary>
        /// Returns int4.brgr swizzling (equivalent to int4.zxyx).
        /// </summary>
        [Inline]
        public int4 brgr =>  int4(z, x, y, x);
        
        /// <summary>
        /// Returns int4.zxyy swizzling.
        /// </summary>
        [Inline]
        public int4 zxyy =>  int4(z, x, y, y);
        
        /// <summary>
        /// Returns int4.brgg swizzling (equivalent to int4.zxyy).
        /// </summary>
        [Inline]
        public int4 brgg =>  int4(z, x, y, y);
        
        /// <summary>
        /// Returns int4.zxyz swizzling.
        /// </summary>
        [Inline]
        public int4 zxyz =>  int4(z, x, y, z);
        
        /// <summary>
        /// Returns int4.brgb swizzling (equivalent to int4.zxyz).
        /// </summary>
        [Inline]
        public int4 brgb =>  int4(z, x, y, z);
        
        /// <summary>
        /// Returns int4.zxyw swizzling.
        /// </summary>
        [Inline]
        public int4 zxyw =>  int4(z, x, y, w);
        
        /// <summary>
        /// Returns int4.brga swizzling (equivalent to int4.zxyw).
        /// </summary>
        [Inline]
        public int4 brga =>  int4(z, x, y, w);
        
        /// <summary>
        /// Returns int4.zxz swizzling.
        /// </summary>
        [Inline]
        public int3 zxz =>  int3(z, x, z);
        
        /// <summary>
        /// Returns int4.brb swizzling (equivalent to int4.zxz).
        /// </summary>
        [Inline]
        public int3 brb =>  int3(z, x, z);
        
        /// <summary>
        /// Returns int4.zxzx swizzling.
        /// </summary>
        [Inline]
        public int4 zxzx =>  int4(z, x, z, x);
        
        /// <summary>
        /// Returns int4.brbr swizzling (equivalent to int4.zxzx).
        /// </summary>
        [Inline]
        public int4 brbr =>  int4(z, x, z, x);
        
        /// <summary>
        /// Returns int4.zxzy swizzling.
        /// </summary>
        [Inline]
        public int4 zxzy =>  int4(z, x, z, y);
        
        /// <summary>
        /// Returns int4.brbg swizzling (equivalent to int4.zxzy).
        /// </summary>
        [Inline]
        public int4 brbg =>  int4(z, x, z, y);
        
        /// <summary>
        /// Returns int4.zxzz swizzling.
        /// </summary>
        [Inline]
        public int4 zxzz =>  int4(z, x, z, z);
        
        /// <summary>
        /// Returns int4.brbb swizzling (equivalent to int4.zxzz).
        /// </summary>
        [Inline]
        public int4 brbb =>  int4(z, x, z, z);
        
        /// <summary>
        /// Returns int4.zxzw swizzling.
        /// </summary>
        [Inline]
        public int4 zxzw =>  int4(z, x, z, w);
        
        /// <summary>
        /// Returns int4.brba swizzling (equivalent to int4.zxzw).
        /// </summary>
        [Inline]
        public int4 brba =>  int4(z, x, z, w);
        
        /// <summary>
        /// Returns int4.zxw swizzling.
        /// </summary>
        [Inline]
        public int3 zxw =>  int3(z, x, w);
        
        /// <summary>
        /// Returns int4.bra swizzling (equivalent to int4.zxw).
        /// </summary>
        [Inline]
        public int3 bra =>  int3(z, x, w);
        
        /// <summary>
        /// Returns int4.zxwx swizzling.
        /// </summary>
        [Inline]
        public int4 zxwx =>  int4(z, x, w, x);
        
        /// <summary>
        /// Returns int4.brar swizzling (equivalent to int4.zxwx).
        /// </summary>
        [Inline]
        public int4 brar =>  int4(z, x, w, x);
        
        /// <summary>
        /// Returns int4.zxwy swizzling.
        /// </summary>
        [Inline]
        public int4 zxwy =>  int4(z, x, w, y);
        
        /// <summary>
        /// Returns int4.brag swizzling (equivalent to int4.zxwy).
        /// </summary>
        [Inline]
        public int4 brag =>  int4(z, x, w, y);
        
        /// <summary>
        /// Returns int4.zxwz swizzling.
        /// </summary>
        [Inline]
        public int4 zxwz =>  int4(z, x, w, z);
        
        /// <summary>
        /// Returns int4.brab swizzling (equivalent to int4.zxwz).
        /// </summary>
        [Inline]
        public int4 brab =>  int4(z, x, w, z);
        
        /// <summary>
        /// Returns int4.zxww swizzling.
        /// </summary>
        [Inline]
        public int4 zxww =>  int4(z, x, w, w);
        
        /// <summary>
        /// Returns int4.braa swizzling (equivalent to int4.zxww).
        /// </summary>
        [Inline]
        public int4 braa =>  int4(z, x, w, w);
        
        /// <summary>
        /// Returns int4.zy swizzling.
        /// </summary>
        [Inline]
        public int2 zy =>  int2(z, y);
        
        /// <summary>
        /// Returns int4.bg swizzling (equivalent to int4.zy).
        /// </summary>
        [Inline]
        public int2 bg =>  int2(z, y);
        
        /// <summary>
        /// Returns int4.zyx swizzling.
        /// </summary>
        [Inline]
        public int3 zyx =>  int3(z, y, x);
        
        /// <summary>
        /// Returns int4.bgr swizzling (equivalent to int4.zyx).
        /// </summary>
        [Inline]
        public int3 bgr =>  int3(z, y, x);
        
        /// <summary>
        /// Returns int4.zyxx swizzling.
        /// </summary>
        [Inline]
        public int4 zyxx =>  int4(z, y, x, x);
        
        /// <summary>
        /// Returns int4.bgrr swizzling (equivalent to int4.zyxx).
        /// </summary>
        [Inline]
        public int4 bgrr =>  int4(z, y, x, x);
        
        /// <summary>
        /// Returns int4.zyxy swizzling.
        /// </summary>
        [Inline]
        public int4 zyxy =>  int4(z, y, x, y);
        
        /// <summary>
        /// Returns int4.bgrg swizzling (equivalent to int4.zyxy).
        /// </summary>
        [Inline]
        public int4 bgrg =>  int4(z, y, x, y);
        
        /// <summary>
        /// Returns int4.zyxz swizzling.
        /// </summary>
        [Inline]
        public int4 zyxz =>  int4(z, y, x, z);
        
        /// <summary>
        /// Returns int4.bgrb swizzling (equivalent to int4.zyxz).
        /// </summary>
        [Inline]
        public int4 bgrb =>  int4(z, y, x, z);
        
        /// <summary>
        /// Returns int4.zyxw swizzling.
        /// </summary>
        [Inline]
        public int4 zyxw =>  int4(z, y, x, w);
        
        /// <summary>
        /// Returns int4.bgra swizzling (equivalent to int4.zyxw).
        /// </summary>
        [Inline]
        public int4 bgra =>  int4(z, y, x, w);
        
        /// <summary>
        /// Returns int4.zyy swizzling.
        /// </summary>
        [Inline]
        public int3 zyy =>  int3(z, y, y);
        
        /// <summary>
        /// Returns int4.bgg swizzling (equivalent to int4.zyy).
        /// </summary>
        [Inline]
        public int3 bgg =>  int3(z, y, y);
        
        /// <summary>
        /// Returns int4.zyyx swizzling.
        /// </summary>
        [Inline]
        public int4 zyyx =>  int4(z, y, y, x);
        
        /// <summary>
        /// Returns int4.bggr swizzling (equivalent to int4.zyyx).
        /// </summary>
        [Inline]
        public int4 bggr =>  int4(z, y, y, x);
        
        /// <summary>
        /// Returns int4.zyyy swizzling.
        /// </summary>
        [Inline]
        public int4 zyyy =>  int4(z, y, y, y);
        
        /// <summary>
        /// Returns int4.bggg swizzling (equivalent to int4.zyyy).
        /// </summary>
        [Inline]
        public int4 bggg =>  int4(z, y, y, y);
        
        /// <summary>
        /// Returns int4.zyyz swizzling.
        /// </summary>
        [Inline]
        public int4 zyyz =>  int4(z, y, y, z);
        
        /// <summary>
        /// Returns int4.bggb swizzling (equivalent to int4.zyyz).
        /// </summary>
        [Inline]
        public int4 bggb =>  int4(z, y, y, z);
        
        /// <summary>
        /// Returns int4.zyyw swizzling.
        /// </summary>
        [Inline]
        public int4 zyyw =>  int4(z, y, y, w);
        
        /// <summary>
        /// Returns int4.bgga swizzling (equivalent to int4.zyyw).
        /// </summary>
        [Inline]
        public int4 bgga =>  int4(z, y, y, w);
        
        /// <summary>
        /// Returns int4.zyz swizzling.
        /// </summary>
        [Inline]
        public int3 zyz =>  int3(z, y, z);
        
        /// <summary>
        /// Returns int4.bgb swizzling (equivalent to int4.zyz).
        /// </summary>
        [Inline]
        public int3 bgb =>  int3(z, y, z);
        
        /// <summary>
        /// Returns int4.zyzx swizzling.
        /// </summary>
        [Inline]
        public int4 zyzx =>  int4(z, y, z, x);
        
        /// <summary>
        /// Returns int4.bgbr swizzling (equivalent to int4.zyzx).
        /// </summary>
        [Inline]
        public int4 bgbr =>  int4(z, y, z, x);
        
        /// <summary>
        /// Returns int4.zyzy swizzling.
        /// </summary>
        [Inline]
        public int4 zyzy =>  int4(z, y, z, y);
        
        /// <summary>
        /// Returns int4.bgbg swizzling (equivalent to int4.zyzy).
        /// </summary>
        [Inline]
        public int4 bgbg =>  int4(z, y, z, y);
        
        /// <summary>
        /// Returns int4.zyzz swizzling.
        /// </summary>
        [Inline]
        public int4 zyzz =>  int4(z, y, z, z);
        
        /// <summary>
        /// Returns int4.bgbb swizzling (equivalent to int4.zyzz).
        /// </summary>
        [Inline]
        public int4 bgbb =>  int4(z, y, z, z);
        
        /// <summary>
        /// Returns int4.zyzw swizzling.
        /// </summary>
        [Inline]
        public int4 zyzw =>  int4(z, y, z, w);
        
        /// <summary>
        /// Returns int4.bgba swizzling (equivalent to int4.zyzw).
        /// </summary>
        [Inline]
        public int4 bgba =>  int4(z, y, z, w);
        
        /// <summary>
        /// Returns int4.zyw swizzling.
        /// </summary>
        [Inline]
        public int3 zyw =>  int3(z, y, w);
        
        /// <summary>
        /// Returns int4.bga swizzling (equivalent to int4.zyw).
        /// </summary>
        [Inline]
        public int3 bga =>  int3(z, y, w);
        
        /// <summary>
        /// Returns int4.zywx swizzling.
        /// </summary>
        [Inline]
        public int4 zywx =>  int4(z, y, w, x);
        
        /// <summary>
        /// Returns int4.bgar swizzling (equivalent to int4.zywx).
        /// </summary>
        [Inline]
        public int4 bgar =>  int4(z, y, w, x);
        
        /// <summary>
        /// Returns int4.zywy swizzling.
        /// </summary>
        [Inline]
        public int4 zywy =>  int4(z, y, w, y);
        
        /// <summary>
        /// Returns int4.bgag swizzling (equivalent to int4.zywy).
        /// </summary>
        [Inline]
        public int4 bgag =>  int4(z, y, w, y);
        
        /// <summary>
        /// Returns int4.zywz swizzling.
        /// </summary>
        [Inline]
        public int4 zywz =>  int4(z, y, w, z);
        
        /// <summary>
        /// Returns int4.bgab swizzling (equivalent to int4.zywz).
        /// </summary>
        [Inline]
        public int4 bgab =>  int4(z, y, w, z);
        
        /// <summary>
        /// Returns int4.zyww swizzling.
        /// </summary>
        [Inline]
        public int4 zyww =>  int4(z, y, w, w);
        
        /// <summary>
        /// Returns int4.bgaa swizzling (equivalent to int4.zyww).
        /// </summary>
        [Inline]
        public int4 bgaa =>  int4(z, y, w, w);
        
        /// <summary>
        /// Returns int4.zz swizzling.
        /// </summary>
        [Inline]
        public int2 zz =>  int2(z, z);
        
        /// <summary>
        /// Returns int4.bb swizzling (equivalent to int4.zz).
        /// </summary>
        [Inline]
        public int2 bb =>  int2(z, z);
        
        /// <summary>
        /// Returns int4.zzx swizzling.
        /// </summary>
        [Inline]
        public int3 zzx =>  int3(z, z, x);
        
        /// <summary>
        /// Returns int4.bbr swizzling (equivalent to int4.zzx).
        /// </summary>
        [Inline]
        public int3 bbr =>  int3(z, z, x);
        
        /// <summary>
        /// Returns int4.zzxx swizzling.
        /// </summary>
        [Inline]
        public int4 zzxx =>  int4(z, z, x, x);
        
        /// <summary>
        /// Returns int4.bbrr swizzling (equivalent to int4.zzxx).
        /// </summary>
        [Inline]
        public int4 bbrr =>  int4(z, z, x, x);
        
        /// <summary>
        /// Returns int4.zzxy swizzling.
        /// </summary>
        [Inline]
        public int4 zzxy =>  int4(z, z, x, y);
        
        /// <summary>
        /// Returns int4.bbrg swizzling (equivalent to int4.zzxy).
        /// </summary>
        [Inline]
        public int4 bbrg =>  int4(z, z, x, y);
        
        /// <summary>
        /// Returns int4.zzxz swizzling.
        /// </summary>
        [Inline]
        public int4 zzxz =>  int4(z, z, x, z);
        
        /// <summary>
        /// Returns int4.bbrb swizzling (equivalent to int4.zzxz).
        /// </summary>
        [Inline]
        public int4 bbrb =>  int4(z, z, x, z);
        
        /// <summary>
        /// Returns int4.zzxw swizzling.
        /// </summary>
        [Inline]
        public int4 zzxw =>  int4(z, z, x, w);
        
        /// <summary>
        /// Returns int4.bbra swizzling (equivalent to int4.zzxw).
        /// </summary>
        [Inline]
        public int4 bbra =>  int4(z, z, x, w);
        
        /// <summary>
        /// Returns int4.zzy swizzling.
        /// </summary>
        [Inline]
        public int3 zzy =>  int3(z, z, y);
        
        /// <summary>
        /// Returns int4.bbg swizzling (equivalent to int4.zzy).
        /// </summary>
        [Inline]
        public int3 bbg =>  int3(z, z, y);
        
        /// <summary>
        /// Returns int4.zzyx swizzling.
        /// </summary>
        [Inline]
        public int4 zzyx =>  int4(z, z, y, x);
        
        /// <summary>
        /// Returns int4.bbgr swizzling (equivalent to int4.zzyx).
        /// </summary>
        [Inline]
        public int4 bbgr =>  int4(z, z, y, x);
        
        /// <summary>
        /// Returns int4.zzyy swizzling.
        /// </summary>
        [Inline]
        public int4 zzyy =>  int4(z, z, y, y);
        
        /// <summary>
        /// Returns int4.bbgg swizzling (equivalent to int4.zzyy).
        /// </summary>
        [Inline]
        public int4 bbgg =>  int4(z, z, y, y);
        
        /// <summary>
        /// Returns int4.zzyz swizzling.
        /// </summary>
        [Inline]
        public int4 zzyz =>  int4(z, z, y, z);
        
        /// <summary>
        /// Returns int4.bbgb swizzling (equivalent to int4.zzyz).
        /// </summary>
        [Inline]
        public int4 bbgb =>  int4(z, z, y, z);
        
        /// <summary>
        /// Returns int4.zzyw swizzling.
        /// </summary>
        [Inline]
        public int4 zzyw =>  int4(z, z, y, w);
        
        /// <summary>
        /// Returns int4.bbga swizzling (equivalent to int4.zzyw).
        /// </summary>
        [Inline]
        public int4 bbga =>  int4(z, z, y, w);
        
        /// <summary>
        /// Returns int4.zzz swizzling.
        /// </summary>
        [Inline]
        public int3 zzz =>  int3(z, z, z);
        
        /// <summary>
        /// Returns int4.bbb swizzling (equivalent to int4.zzz).
        /// </summary>
        [Inline]
        public int3 bbb =>  int3(z, z, z);
        
        /// <summary>
        /// Returns int4.zzzx swizzling.
        /// </summary>
        [Inline]
        public int4 zzzx =>  int4(z, z, z, x);
        
        /// <summary>
        /// Returns int4.bbbr swizzling (equivalent to int4.zzzx).
        /// </summary>
        [Inline]
        public int4 bbbr =>  int4(z, z, z, x);
        
        /// <summary>
        /// Returns int4.zzzy swizzling.
        /// </summary>
        [Inline]
        public int4 zzzy =>  int4(z, z, z, y);
        
        /// <summary>
        /// Returns int4.bbbg swizzling (equivalent to int4.zzzy).
        /// </summary>
        [Inline]
        public int4 bbbg =>  int4(z, z, z, y);
        
        /// <summary>
        /// Returns int4.zzzz swizzling.
        /// </summary>
        [Inline]
        public int4 zzzz =>  int4(z, z, z, z);
        
        /// <summary>
        /// Returns int4.bbbb swizzling (equivalent to int4.zzzz).
        /// </summary>
        [Inline]
        public int4 bbbb =>  int4(z, z, z, z);
        
        /// <summary>
        /// Returns int4.zzzw swizzling.
        /// </summary>
        [Inline]
        public int4 zzzw =>  int4(z, z, z, w);
        
        /// <summary>
        /// Returns int4.bbba swizzling (equivalent to int4.zzzw).
        /// </summary>
        [Inline]
        public int4 bbba =>  int4(z, z, z, w);
        
        /// <summary>
        /// Returns int4.zzw swizzling.
        /// </summary>
        [Inline]
        public int3 zzw =>  int3(z, z, w);
        
        /// <summary>
        /// Returns int4.bba swizzling (equivalent to int4.zzw).
        /// </summary>
        [Inline]
        public int3 bba =>  int3(z, z, w);
        
        /// <summary>
        /// Returns int4.zzwx swizzling.
        /// </summary>
        [Inline]
        public int4 zzwx =>  int4(z, z, w, x);
        
        /// <summary>
        /// Returns int4.bbar swizzling (equivalent to int4.zzwx).
        /// </summary>
        [Inline]
        public int4 bbar =>  int4(z, z, w, x);
        
        /// <summary>
        /// Returns int4.zzwy swizzling.
        /// </summary>
        [Inline]
        public int4 zzwy =>  int4(z, z, w, y);
        
        /// <summary>
        /// Returns int4.bbag swizzling (equivalent to int4.zzwy).
        /// </summary>
        [Inline]
        public int4 bbag =>  int4(z, z, w, y);
        
        /// <summary>
        /// Returns int4.zzwz swizzling.
        /// </summary>
        [Inline]
        public int4 zzwz =>  int4(z, z, w, z);
        
        /// <summary>
        /// Returns int4.bbab swizzling (equivalent to int4.zzwz).
        /// </summary>
        [Inline]
        public int4 bbab =>  int4(z, z, w, z);
        
        /// <summary>
        /// Returns int4.zzww swizzling.
        /// </summary>
        [Inline]
        public int4 zzww =>  int4(z, z, w, w);
        
        /// <summary>
        /// Returns int4.bbaa swizzling (equivalent to int4.zzww).
        /// </summary>
        [Inline]
        public int4 bbaa =>  int4(z, z, w, w);
        
        /// <summary>
        /// Returns int4.zw swizzling.
        /// </summary>
        [Inline]
        public int2 zw =>  int2(z, w);
        
        /// <summary>
        /// Returns int4.ba swizzling (equivalent to int4.zw).
        /// </summary>
        [Inline]
        public int2 ba =>  int2(z, w);
        
        /// <summary>
        /// Returns int4.zwx swizzling.
        /// </summary>
        [Inline]
        public int3 zwx =>  int3(z, w, x);
        
        /// <summary>
        /// Returns int4.bar swizzling (equivalent to int4.zwx).
        /// </summary>
        [Inline]
        public int3 bar =>  int3(z, w, x);
        
        /// <summary>
        /// Returns int4.zwxx swizzling.
        /// </summary>
        [Inline]
        public int4 zwxx =>  int4(z, w, x, x);
        
        /// <summary>
        /// Returns int4.barr swizzling (equivalent to int4.zwxx).
        /// </summary>
        [Inline]
        public int4 barr =>  int4(z, w, x, x);
        
        /// <summary>
        /// Returns int4.zwxy swizzling.
        /// </summary>
        [Inline]
        public int4 zwxy =>  int4(z, w, x, y);
        
        /// <summary>
        /// Returns int4.barg swizzling (equivalent to int4.zwxy).
        /// </summary>
        [Inline]
        public int4 barg =>  int4(z, w, x, y);
        
        /// <summary>
        /// Returns int4.zwxz swizzling.
        /// </summary>
        [Inline]
        public int4 zwxz =>  int4(z, w, x, z);
        
        /// <summary>
        /// Returns int4.barb swizzling (equivalent to int4.zwxz).
        /// </summary>
        [Inline]
        public int4 barb =>  int4(z, w, x, z);
        
        /// <summary>
        /// Returns int4.zwxw swizzling.
        /// </summary>
        [Inline]
        public int4 zwxw =>  int4(z, w, x, w);
        
        /// <summary>
        /// Returns int4.bara swizzling (equivalent to int4.zwxw).
        /// </summary>
        [Inline]
        public int4 bara =>  int4(z, w, x, w);
        
        /// <summary>
        /// Returns int4.zwy swizzling.
        /// </summary>
        [Inline]
        public int3 zwy =>  int3(z, w, y);
        
        /// <summary>
        /// Returns int4.bag swizzling (equivalent to int4.zwy).
        /// </summary>
        [Inline]
        public int3 bag =>  int3(z, w, y);
        
        /// <summary>
        /// Returns int4.zwyx swizzling.
        /// </summary>
        [Inline]
        public int4 zwyx =>  int4(z, w, y, x);
        
        /// <summary>
        /// Returns int4.bagr swizzling (equivalent to int4.zwyx).
        /// </summary>
        [Inline]
        public int4 bagr =>  int4(z, w, y, x);
        
        /// <summary>
        /// Returns int4.zwyy swizzling.
        /// </summary>
        [Inline]
        public int4 zwyy =>  int4(z, w, y, y);
        
        /// <summary>
        /// Returns int4.bagg swizzling (equivalent to int4.zwyy).
        /// </summary>
        [Inline]
        public int4 bagg =>  int4(z, w, y, y);
        
        /// <summary>
        /// Returns int4.zwyz swizzling.
        /// </summary>
        [Inline]
        public int4 zwyz =>  int4(z, w, y, z);
        
        /// <summary>
        /// Returns int4.bagb swizzling (equivalent to int4.zwyz).
        /// </summary>
        [Inline]
        public int4 bagb =>  int4(z, w, y, z);
        
        /// <summary>
        /// Returns int4.zwyw swizzling.
        /// </summary>
        [Inline]
        public int4 zwyw =>  int4(z, w, y, w);
        
        /// <summary>
        /// Returns int4.baga swizzling (equivalent to int4.zwyw).
        /// </summary>
        [Inline]
        public int4 baga =>  int4(z, w, y, w);
        
        /// <summary>
        /// Returns int4.zwz swizzling.
        /// </summary>
        [Inline]
        public int3 zwz =>  int3(z, w, z);
        
        /// <summary>
        /// Returns int4.bab swizzling (equivalent to int4.zwz).
        /// </summary>
        [Inline]
        public int3 bab =>  int3(z, w, z);
        
        /// <summary>
        /// Returns int4.zwzx swizzling.
        /// </summary>
        [Inline]
        public int4 zwzx =>  int4(z, w, z, x);
        
        /// <summary>
        /// Returns int4.babr swizzling (equivalent to int4.zwzx).
        /// </summary>
        [Inline]
        public int4 babr =>  int4(z, w, z, x);
        
        /// <summary>
        /// Returns int4.zwzy swizzling.
        /// </summary>
        [Inline]
        public int4 zwzy =>  int4(z, w, z, y);
        
        /// <summary>
        /// Returns int4.babg swizzling (equivalent to int4.zwzy).
        /// </summary>
        [Inline]
        public int4 babg =>  int4(z, w, z, y);
        
        /// <summary>
        /// Returns int4.zwzz swizzling.
        /// </summary>
        [Inline]
        public int4 zwzz =>  int4(z, w, z, z);
        
        /// <summary>
        /// Returns int4.babb swizzling (equivalent to int4.zwzz).
        /// </summary>
        [Inline]
        public int4 babb =>  int4(z, w, z, z);
        
        /// <summary>
        /// Returns int4.zwzw swizzling.
        /// </summary>
        [Inline]
        public int4 zwzw =>  int4(z, w, z, w);
        
        /// <summary>
        /// Returns int4.baba swizzling (equivalent to int4.zwzw).
        /// </summary>
        [Inline]
        public int4 baba =>  int4(z, w, z, w);
        
        /// <summary>
        /// Returns int4.zww swizzling.
        /// </summary>
        [Inline]
        public int3 zww =>  int3(z, w, w);
        
        /// <summary>
        /// Returns int4.baa swizzling (equivalent to int4.zww).
        /// </summary>
        [Inline]
        public int3 baa =>  int3(z, w, w);
        
        /// <summary>
        /// Returns int4.zwwx swizzling.
        /// </summary>
        [Inline]
        public int4 zwwx =>  int4(z, w, w, x);
        
        /// <summary>
        /// Returns int4.baar swizzling (equivalent to int4.zwwx).
        /// </summary>
        [Inline]
        public int4 baar =>  int4(z, w, w, x);
        
        /// <summary>
        /// Returns int4.zwwy swizzling.
        /// </summary>
        [Inline]
        public int4 zwwy =>  int4(z, w, w, y);
        
        /// <summary>
        /// Returns int4.baag swizzling (equivalent to int4.zwwy).
        /// </summary>
        [Inline]
        public int4 baag =>  int4(z, w, w, y);
        
        /// <summary>
        /// Returns int4.zwwz swizzling.
        /// </summary>
        [Inline]
        public int4 zwwz =>  int4(z, w, w, z);
        
        /// <summary>
        /// Returns int4.baab swizzling (equivalent to int4.zwwz).
        /// </summary>
        [Inline]
        public int4 baab =>  int4(z, w, w, z);
        
        /// <summary>
        /// Returns int4.zwww swizzling.
        /// </summary>
        [Inline]
        public int4 zwww =>  int4(z, w, w, w);
        
        /// <summary>
        /// Returns int4.baaa swizzling (equivalent to int4.zwww).
        /// </summary>
        [Inline]
        public int4 baaa =>  int4(z, w, w, w);
        
        /// <summary>
        /// Returns int4.wx swizzling.
        /// </summary>
        [Inline]
        public int2 wx =>  int2(w, x);
        
        /// <summary>
        /// Returns int4.ar swizzling (equivalent to int4.wx).
        /// </summary>
        [Inline]
        public int2 ar =>  int2(w, x);
        
        /// <summary>
        /// Returns int4.wxx swizzling.
        /// </summary>
        [Inline]
        public int3 wxx =>  int3(w, x, x);
        
        /// <summary>
        /// Returns int4.arr swizzling (equivalent to int4.wxx).
        /// </summary>
        [Inline]
        public int3 arr =>  int3(w, x, x);
        
        /// <summary>
        /// Returns int4.wxxx swizzling.
        /// </summary>
        [Inline]
        public int4 wxxx =>  int4(w, x, x, x);
        
        /// <summary>
        /// Returns int4.arrr swizzling (equivalent to int4.wxxx).
        /// </summary>
        [Inline]
        public int4 arrr =>  int4(w, x, x, x);
        
        /// <summary>
        /// Returns int4.wxxy swizzling.
        /// </summary>
        [Inline]
        public int4 wxxy =>  int4(w, x, x, y);
        
        /// <summary>
        /// Returns int4.arrg swizzling (equivalent to int4.wxxy).
        /// </summary>
        [Inline]
        public int4 arrg =>  int4(w, x, x, y);
        
        /// <summary>
        /// Returns int4.wxxz swizzling.
        /// </summary>
        [Inline]
        public int4 wxxz =>  int4(w, x, x, z);
        
        /// <summary>
        /// Returns int4.arrb swizzling (equivalent to int4.wxxz).
        /// </summary>
        [Inline]
        public int4 arrb =>  int4(w, x, x, z);
        
        /// <summary>
        /// Returns int4.wxxw swizzling.
        /// </summary>
        [Inline]
        public int4 wxxw =>  int4(w, x, x, w);
        
        /// <summary>
        /// Returns int4.arra swizzling (equivalent to int4.wxxw).
        /// </summary>
        [Inline]
        public int4 arra =>  int4(w, x, x, w);
        
        /// <summary>
        /// Returns int4.wxy swizzling.
        /// </summary>
        [Inline]
        public int3 wxy =>  int3(w, x, y);
        
        /// <summary>
        /// Returns int4.arg swizzling (equivalent to int4.wxy).
        /// </summary>
        [Inline]
        public int3 arg =>  int3(w, x, y);
        
        /// <summary>
        /// Returns int4.wxyx swizzling.
        /// </summary>
        [Inline]
        public int4 wxyx =>  int4(w, x, y, x);
        
        /// <summary>
        /// Returns int4.argr swizzling (equivalent to int4.wxyx).
        /// </summary>
        [Inline]
        public int4 argr =>  int4(w, x, y, x);
        
        /// <summary>
        /// Returns int4.wxyy swizzling.
        /// </summary>
        [Inline]
        public int4 wxyy =>  int4(w, x, y, y);
        
        /// <summary>
        /// Returns int4.argg swizzling (equivalent to int4.wxyy).
        /// </summary>
        [Inline]
        public int4 argg =>  int4(w, x, y, y);
        
        /// <summary>
        /// Returns int4.wxyz swizzling.
        /// </summary>
        [Inline]
        public int4 wxyz =>  int4(w, x, y, z);
        
        /// <summary>
        /// Returns int4.argb swizzling (equivalent to int4.wxyz).
        /// </summary>
        [Inline]
        public int4 argb =>  int4(w, x, y, z);
        
        /// <summary>
        /// Returns int4.wxyw swizzling.
        /// </summary>
        [Inline]
        public int4 wxyw =>  int4(w, x, y, w);
        
        /// <summary>
        /// Returns int4.arga swizzling (equivalent to int4.wxyw).
        /// </summary>
        [Inline]
        public int4 arga =>  int4(w, x, y, w);
        
        /// <summary>
        /// Returns int4.wxz swizzling.
        /// </summary>
        [Inline]
        public int3 wxz =>  int3(w, x, z);
        
        /// <summary>
        /// Returns int4.arb swizzling (equivalent to int4.wxz).
        /// </summary>
        [Inline]
        public int3 arb =>  int3(w, x, z);
        
        /// <summary>
        /// Returns int4.wxzx swizzling.
        /// </summary>
        [Inline]
        public int4 wxzx =>  int4(w, x, z, x);
        
        /// <summary>
        /// Returns int4.arbr swizzling (equivalent to int4.wxzx).
        /// </summary>
        [Inline]
        public int4 arbr =>  int4(w, x, z, x);
        
        /// <summary>
        /// Returns int4.wxzy swizzling.
        /// </summary>
        [Inline]
        public int4 wxzy =>  int4(w, x, z, y);
        
        /// <summary>
        /// Returns int4.arbg swizzling (equivalent to int4.wxzy).
        /// </summary>
        [Inline]
        public int4 arbg =>  int4(w, x, z, y);
        
        /// <summary>
        /// Returns int4.wxzz swizzling.
        /// </summary>
        [Inline]
        public int4 wxzz =>  int4(w, x, z, z);
        
        /// <summary>
        /// Returns int4.arbb swizzling (equivalent to int4.wxzz).
        /// </summary>
        [Inline]
        public int4 arbb =>  int4(w, x, z, z);
        
        /// <summary>
        /// Returns int4.wxzw swizzling.
        /// </summary>
        [Inline]
        public int4 wxzw =>  int4(w, x, z, w);
        
        /// <summary>
        /// Returns int4.arba swizzling (equivalent to int4.wxzw).
        /// </summary>
        [Inline]
        public int4 arba =>  int4(w, x, z, w);
        
        /// <summary>
        /// Returns int4.wxw swizzling.
        /// </summary>
        [Inline]
        public int3 wxw =>  int3(w, x, w);
        
        /// <summary>
        /// Returns int4.ara swizzling (equivalent to int4.wxw).
        /// </summary>
        [Inline]
        public int3 ara =>  int3(w, x, w);
        
        /// <summary>
        /// Returns int4.wxwx swizzling.
        /// </summary>
        [Inline]
        public int4 wxwx =>  int4(w, x, w, x);
        
        /// <summary>
        /// Returns int4.arar swizzling (equivalent to int4.wxwx).
        /// </summary>
        [Inline]
        public int4 arar =>  int4(w, x, w, x);
        
        /// <summary>
        /// Returns int4.wxwy swizzling.
        /// </summary>
        [Inline]
        public int4 wxwy =>  int4(w, x, w, y);
        
        /// <summary>
        /// Returns int4.arag swizzling (equivalent to int4.wxwy).
        /// </summary>
        [Inline]
        public int4 arag =>  int4(w, x, w, y);
        
        /// <summary>
        /// Returns int4.wxwz swizzling.
        /// </summary>
        [Inline]
        public int4 wxwz =>  int4(w, x, w, z);
        
        /// <summary>
        /// Returns int4.arab swizzling (equivalent to int4.wxwz).
        /// </summary>
        [Inline]
        public int4 arab =>  int4(w, x, w, z);
        
        /// <summary>
        /// Returns int4.wxww swizzling.
        /// </summary>
        [Inline]
        public int4 wxww =>  int4(w, x, w, w);
        
        /// <summary>
        /// Returns int4.araa swizzling (equivalent to int4.wxww).
        /// </summary>
        [Inline]
        public int4 araa =>  int4(w, x, w, w);
        
        /// <summary>
        /// Returns int4.wy swizzling.
        /// </summary>
        [Inline]
        public int2 wy =>  int2(w, y);
        
        /// <summary>
        /// Returns int4.ag swizzling (equivalent to int4.wy).
        /// </summary>
        [Inline]
        public int2 ag =>  int2(w, y);
        
        /// <summary>
        /// Returns int4.wyx swizzling.
        /// </summary>
        [Inline]
        public int3 wyx =>  int3(w, y, x);
        
        /// <summary>
        /// Returns int4.agr swizzling (equivalent to int4.wyx).
        /// </summary>
        [Inline]
        public int3 agr =>  int3(w, y, x);
        
        /// <summary>
        /// Returns int4.wyxx swizzling.
        /// </summary>
        [Inline]
        public int4 wyxx =>  int4(w, y, x, x);
        
        /// <summary>
        /// Returns int4.agrr swizzling (equivalent to int4.wyxx).
        /// </summary>
        [Inline]
        public int4 agrr =>  int4(w, y, x, x);
        
        /// <summary>
        /// Returns int4.wyxy swizzling.
        /// </summary>
        [Inline]
        public int4 wyxy =>  int4(w, y, x, y);
        
        /// <summary>
        /// Returns int4.agrg swizzling (equivalent to int4.wyxy).
        /// </summary>
        [Inline]
        public int4 agrg =>  int4(w, y, x, y);
        
        /// <summary>
        /// Returns int4.wyxz swizzling.
        /// </summary>
        [Inline]
        public int4 wyxz =>  int4(w, y, x, z);
        
        /// <summary>
        /// Returns int4.agrb swizzling (equivalent to int4.wyxz).
        /// </summary>
        [Inline]
        public int4 agrb =>  int4(w, y, x, z);
        
        /// <summary>
        /// Returns int4.wyxw swizzling.
        /// </summary>
        [Inline]
        public int4 wyxw =>  int4(w, y, x, w);
        
        /// <summary>
        /// Returns int4.agra swizzling (equivalent to int4.wyxw).
        /// </summary>
        [Inline]
        public int4 agra =>  int4(w, y, x, w);
        
        /// <summary>
        /// Returns int4.wyy swizzling.
        /// </summary>
        [Inline]
        public int3 wyy =>  int3(w, y, y);
        
        /// <summary>
        /// Returns int4.agg swizzling (equivalent to int4.wyy).
        /// </summary>
        [Inline]
        public int3 agg =>  int3(w, y, y);
        
        /// <summary>
        /// Returns int4.wyyx swizzling.
        /// </summary>
        [Inline]
        public int4 wyyx =>  int4(w, y, y, x);
        
        /// <summary>
        /// Returns int4.aggr swizzling (equivalent to int4.wyyx).
        /// </summary>
        [Inline]
        public int4 aggr =>  int4(w, y, y, x);
        
        /// <summary>
        /// Returns int4.wyyy swizzling.
        /// </summary>
        [Inline]
        public int4 wyyy =>  int4(w, y, y, y);
        
        /// <summary>
        /// Returns int4.aggg swizzling (equivalent to int4.wyyy).
        /// </summary>
        [Inline]
        public int4 aggg =>  int4(w, y, y, y);
        
        /// <summary>
        /// Returns int4.wyyz swizzling.
        /// </summary>
        [Inline]
        public int4 wyyz =>  int4(w, y, y, z);
        
        /// <summary>
        /// Returns int4.aggb swizzling (equivalent to int4.wyyz).
        /// </summary>
        [Inline]
        public int4 aggb =>  int4(w, y, y, z);
        
        /// <summary>
        /// Returns int4.wyyw swizzling.
        /// </summary>
        [Inline]
        public int4 wyyw =>  int4(w, y, y, w);
        
        /// <summary>
        /// Returns int4.agga swizzling (equivalent to int4.wyyw).
        /// </summary>
        [Inline]
        public int4 agga =>  int4(w, y, y, w);
        
        /// <summary>
        /// Returns int4.wyz swizzling.
        /// </summary>
        [Inline]
        public int3 wyz =>  int3(w, y, z);
        
        /// <summary>
        /// Returns int4.agb swizzling (equivalent to int4.wyz).
        /// </summary>
        [Inline]
        public int3 agb =>  int3(w, y, z);
        
        /// <summary>
        /// Returns int4.wyzx swizzling.
        /// </summary>
        [Inline]
        public int4 wyzx =>  int4(w, y, z, x);
        
        /// <summary>
        /// Returns int4.agbr swizzling (equivalent to int4.wyzx).
        /// </summary>
        [Inline]
        public int4 agbr =>  int4(w, y, z, x);
        
        /// <summary>
        /// Returns int4.wyzy swizzling.
        /// </summary>
        [Inline]
        public int4 wyzy =>  int4(w, y, z, y);
        
        /// <summary>
        /// Returns int4.agbg swizzling (equivalent to int4.wyzy).
        /// </summary>
        [Inline]
        public int4 agbg =>  int4(w, y, z, y);
        
        /// <summary>
        /// Returns int4.wyzz swizzling.
        /// </summary>
        [Inline]
        public int4 wyzz =>  int4(w, y, z, z);
        
        /// <summary>
        /// Returns int4.agbb swizzling (equivalent to int4.wyzz).
        /// </summary>
        [Inline]
        public int4 agbb =>  int4(w, y, z, z);
        
        /// <summary>
        /// Returns int4.wyzw swizzling.
        /// </summary>
        [Inline]
        public int4 wyzw =>  int4(w, y, z, w);
        
        /// <summary>
        /// Returns int4.agba swizzling (equivalent to int4.wyzw).
        /// </summary>
        [Inline]
        public int4 agba =>  int4(w, y, z, w);
        
        /// <summary>
        /// Returns int4.wyw swizzling.
        /// </summary>
        [Inline]
        public int3 wyw =>  int3(w, y, w);
        
        /// <summary>
        /// Returns int4.aga swizzling (equivalent to int4.wyw).
        /// </summary>
        [Inline]
        public int3 aga =>  int3(w, y, w);
        
        /// <summary>
        /// Returns int4.wywx swizzling.
        /// </summary>
        [Inline]
        public int4 wywx =>  int4(w, y, w, x);
        
        /// <summary>
        /// Returns int4.agar swizzling (equivalent to int4.wywx).
        /// </summary>
        [Inline]
        public int4 agar =>  int4(w, y, w, x);
        
        /// <summary>
        /// Returns int4.wywy swizzling.
        /// </summary>
        [Inline]
        public int4 wywy =>  int4(w, y, w, y);
        
        /// <summary>
        /// Returns int4.agag swizzling (equivalent to int4.wywy).
        /// </summary>
        [Inline]
        public int4 agag =>  int4(w, y, w, y);
        
        /// <summary>
        /// Returns int4.wywz swizzling.
        /// </summary>
        [Inline]
        public int4 wywz =>  int4(w, y, w, z);
        
        /// <summary>
        /// Returns int4.agab swizzling (equivalent to int4.wywz).
        /// </summary>
        [Inline]
        public int4 agab =>  int4(w, y, w, z);
        
        /// <summary>
        /// Returns int4.wyww swizzling.
        /// </summary>
        [Inline]
        public int4 wyww =>  int4(w, y, w, w);
        
        /// <summary>
        /// Returns int4.agaa swizzling (equivalent to int4.wyww).
        /// </summary>
        [Inline]
        public int4 agaa =>  int4(w, y, w, w);
        
        /// <summary>
        /// Returns int4.wz swizzling.
        /// </summary>
        [Inline]
        public int2 wz =>  int2(w, z);
        
        /// <summary>
        /// Returns int4.ab swizzling (equivalent to int4.wz).
        /// </summary>
        [Inline]
        public int2 ab =>  int2(w, z);
        
        /// <summary>
        /// Returns int4.wzx swizzling.
        /// </summary>
        [Inline]
        public int3 wzx =>  int3(w, z, x);
        
        /// <summary>
        /// Returns int4.abr swizzling (equivalent to int4.wzx).
        /// </summary>
        [Inline]
        public int3 abr =>  int3(w, z, x);
        
        /// <summary>
        /// Returns int4.wzxx swizzling.
        /// </summary>
        [Inline]
        public int4 wzxx =>  int4(w, z, x, x);
        
        /// <summary>
        /// Returns int4.abrr swizzling (equivalent to int4.wzxx).
        /// </summary>
        [Inline]
        public int4 abrr =>  int4(w, z, x, x);
        
        /// <summary>
        /// Returns int4.wzxy swizzling.
        /// </summary>
        [Inline]
        public int4 wzxy =>  int4(w, z, x, y);
        
        /// <summary>
        /// Returns int4.abrg swizzling (equivalent to int4.wzxy).
        /// </summary>
        [Inline]
        public int4 abrg =>  int4(w, z, x, y);
        
        /// <summary>
        /// Returns int4.wzxz swizzling.
        /// </summary>
        [Inline]
        public int4 wzxz =>  int4(w, z, x, z);
        
        /// <summary>
        /// Returns int4.abrb swizzling (equivalent to int4.wzxz).
        /// </summary>
        [Inline]
        public int4 abrb =>  int4(w, z, x, z);
        
        /// <summary>
        /// Returns int4.wzxw swizzling.
        /// </summary>
        [Inline]
        public int4 wzxw =>  int4(w, z, x, w);
        
        /// <summary>
        /// Returns int4.abra swizzling (equivalent to int4.wzxw).
        /// </summary>
        [Inline]
        public int4 abra =>  int4(w, z, x, w);
        
        /// <summary>
        /// Returns int4.wzy swizzling.
        /// </summary>
        [Inline]
        public int3 wzy =>  int3(w, z, y);
        
        /// <summary>
        /// Returns int4.abg swizzling (equivalent to int4.wzy).
        /// </summary>
        [Inline]
        public int3 abg =>  int3(w, z, y);
        
        /// <summary>
        /// Returns int4.wzyx swizzling.
        /// </summary>
        [Inline]
        public int4 wzyx =>  int4(w, z, y, x);
        
        /// <summary>
        /// Returns int4.abgr swizzling (equivalent to int4.wzyx).
        /// </summary>
        [Inline]
        public int4 abgr =>  int4(w, z, y, x);
        
        /// <summary>
        /// Returns int4.wzyy swizzling.
        /// </summary>
        [Inline]
        public int4 wzyy =>  int4(w, z, y, y);
        
        /// <summary>
        /// Returns int4.abgg swizzling (equivalent to int4.wzyy).
        /// </summary>
        [Inline]
        public int4 abgg =>  int4(w, z, y, y);
        
        /// <summary>
        /// Returns int4.wzyz swizzling.
        /// </summary>
        [Inline]
        public int4 wzyz =>  int4(w, z, y, z);
        
        /// <summary>
        /// Returns int4.abgb swizzling (equivalent to int4.wzyz).
        /// </summary>
        [Inline]
        public int4 abgb =>  int4(w, z, y, z);
        
        /// <summary>
        /// Returns int4.wzyw swizzling.
        /// </summary>
        [Inline]
        public int4 wzyw =>  int4(w, z, y, w);
        
        /// <summary>
        /// Returns int4.abga swizzling (equivalent to int4.wzyw).
        /// </summary>
        [Inline]
        public int4 abga =>  int4(w, z, y, w);
        
        /// <summary>
        /// Returns int4.wzz swizzling.
        /// </summary>
        [Inline]
        public int3 wzz =>  int3(w, z, z);
        
        /// <summary>
        /// Returns int4.abb swizzling (equivalent to int4.wzz).
        /// </summary>
        [Inline]
        public int3 abb =>  int3(w, z, z);
        
        /// <summary>
        /// Returns int4.wzzx swizzling.
        /// </summary>
        [Inline]
        public int4 wzzx =>  int4(w, z, z, x);
        
        /// <summary>
        /// Returns int4.abbr swizzling (equivalent to int4.wzzx).
        /// </summary>
        [Inline]
        public int4 abbr =>  int4(w, z, z, x);
        
        /// <summary>
        /// Returns int4.wzzy swizzling.
        /// </summary>
        [Inline]
        public int4 wzzy =>  int4(w, z, z, y);
        
        /// <summary>
        /// Returns int4.abbg swizzling (equivalent to int4.wzzy).
        /// </summary>
        [Inline]
        public int4 abbg =>  int4(w, z, z, y);
        
        /// <summary>
        /// Returns int4.wzzz swizzling.
        /// </summary>
        [Inline]
        public int4 wzzz =>  int4(w, z, z, z);
        
        /// <summary>
        /// Returns int4.abbb swizzling (equivalent to int4.wzzz).
        /// </summary>
        [Inline]
        public int4 abbb =>  int4(w, z, z, z);
        
        /// <summary>
        /// Returns int4.wzzw swizzling.
        /// </summary>
        [Inline]
        public int4 wzzw =>  int4(w, z, z, w);
        
        /// <summary>
        /// Returns int4.abba swizzling (equivalent to int4.wzzw).
        /// </summary>
        [Inline]
        public int4 abba =>  int4(w, z, z, w);
        
        /// <summary>
        /// Returns int4.wzw swizzling.
        /// </summary>
        [Inline]
        public int3 wzw =>  int3(w, z, w);
        
        /// <summary>
        /// Returns int4.aba swizzling (equivalent to int4.wzw).
        /// </summary>
        [Inline]
        public int3 aba =>  int3(w, z, w);
        
        /// <summary>
        /// Returns int4.wzwx swizzling.
        /// </summary>
        [Inline]
        public int4 wzwx =>  int4(w, z, w, x);
        
        /// <summary>
        /// Returns int4.abar swizzling (equivalent to int4.wzwx).
        /// </summary>
        [Inline]
        public int4 abar =>  int4(w, z, w, x);
        
        /// <summary>
        /// Returns int4.wzwy swizzling.
        /// </summary>
        [Inline]
        public int4 wzwy =>  int4(w, z, w, y);
        
        /// <summary>
        /// Returns int4.abag swizzling (equivalent to int4.wzwy).
        /// </summary>
        [Inline]
        public int4 abag =>  int4(w, z, w, y);
        
        /// <summary>
        /// Returns int4.wzwz swizzling.
        /// </summary>
        [Inline]
        public int4 wzwz =>  int4(w, z, w, z);
        
        /// <summary>
        /// Returns int4.abab swizzling (equivalent to int4.wzwz).
        /// </summary>
        [Inline]
        public int4 abab =>  int4(w, z, w, z);
        
        /// <summary>
        /// Returns int4.wzww swizzling.
        /// </summary>
        [Inline]
        public int4 wzww =>  int4(w, z, w, w);
        
        /// <summary>
        /// Returns int4.abaa swizzling (equivalent to int4.wzww).
        /// </summary>
        [Inline]
        public int4 abaa =>  int4(w, z, w, w);
        
        /// <summary>
        /// Returns int4.ww swizzling.
        /// </summary>
        [Inline]
        public int2 ww =>  int2(w, w);
        
        /// <summary>
        /// Returns int4.aa swizzling (equivalent to int4.ww).
        /// </summary>
        [Inline]
        public int2 aa =>  int2(w, w);
        
        /// <summary>
        /// Returns int4.wwx swizzling.
        /// </summary>
        [Inline]
        public int3 wwx =>  int3(w, w, x);
        
        /// <summary>
        /// Returns int4.aar swizzling (equivalent to int4.wwx).
        /// </summary>
        [Inline]
        public int3 aar =>  int3(w, w, x);
        
        /// <summary>
        /// Returns int4.wwxx swizzling.
        /// </summary>
        [Inline]
        public int4 wwxx =>  int4(w, w, x, x);
        
        /// <summary>
        /// Returns int4.aarr swizzling (equivalent to int4.wwxx).
        /// </summary>
        [Inline]
        public int4 aarr =>  int4(w, w, x, x);
        
        /// <summary>
        /// Returns int4.wwxy swizzling.
        /// </summary>
        [Inline]
        public int4 wwxy =>  int4(w, w, x, y);
        
        /// <summary>
        /// Returns int4.aarg swizzling (equivalent to int4.wwxy).
        /// </summary>
        [Inline]
        public int4 aarg =>  int4(w, w, x, y);
        
        /// <summary>
        /// Returns int4.wwxz swizzling.
        /// </summary>
        [Inline]
        public int4 wwxz =>  int4(w, w, x, z);
        
        /// <summary>
        /// Returns int4.aarb swizzling (equivalent to int4.wwxz).
        /// </summary>
        [Inline]
        public int4 aarb =>  int4(w, w, x, z);
        
        /// <summary>
        /// Returns int4.wwxw swizzling.
        /// </summary>
        [Inline]
        public int4 wwxw =>  int4(w, w, x, w);
        
        /// <summary>
        /// Returns int4.aara swizzling (equivalent to int4.wwxw).
        /// </summary>
        [Inline]
        public int4 aara =>  int4(w, w, x, w);
        
        /// <summary>
        /// Returns int4.wwy swizzling.
        /// </summary>
        [Inline]
        public int3 wwy =>  int3(w, w, y);
        
        /// <summary>
        /// Returns int4.aag swizzling (equivalent to int4.wwy).
        /// </summary>
        [Inline]
        public int3 aag =>  int3(w, w, y);
        
        /// <summary>
        /// Returns int4.wwyx swizzling.
        /// </summary>
        [Inline]
        public int4 wwyx =>  int4(w, w, y, x);
        
        /// <summary>
        /// Returns int4.aagr swizzling (equivalent to int4.wwyx).
        /// </summary>
        [Inline]
        public int4 aagr =>  int4(w, w, y, x);
        
        /// <summary>
        /// Returns int4.wwyy swizzling.
        /// </summary>
        [Inline]
        public int4 wwyy =>  int4(w, w, y, y);
        
        /// <summary>
        /// Returns int4.aagg swizzling (equivalent to int4.wwyy).
        /// </summary>
        [Inline]
        public int4 aagg =>  int4(w, w, y, y);
        
        /// <summary>
        /// Returns int4.wwyz swizzling.
        /// </summary>
        [Inline]
        public int4 wwyz =>  int4(w, w, y, z);
        
        /// <summary>
        /// Returns int4.aagb swizzling (equivalent to int4.wwyz).
        /// </summary>
        [Inline]
        public int4 aagb =>  int4(w, w, y, z);
        
        /// <summary>
        /// Returns int4.wwyw swizzling.
        /// </summary>
        [Inline]
        public int4 wwyw =>  int4(w, w, y, w);
        
        /// <summary>
        /// Returns int4.aaga swizzling (equivalent to int4.wwyw).
        /// </summary>
        [Inline]
        public int4 aaga =>  int4(w, w, y, w);
        
        /// <summary>
        /// Returns int4.wwz swizzling.
        /// </summary>
        [Inline]
        public int3 wwz =>  int3(w, w, z);
        
        /// <summary>
        /// Returns int4.aab swizzling (equivalent to int4.wwz).
        /// </summary>
        [Inline]
        public int3 aab =>  int3(w, w, z);
        
        /// <summary>
        /// Returns int4.wwzx swizzling.
        /// </summary>
        [Inline]
        public int4 wwzx =>  int4(w, w, z, x);
        
        /// <summary>
        /// Returns int4.aabr swizzling (equivalent to int4.wwzx).
        /// </summary>
        [Inline]
        public int4 aabr =>  int4(w, w, z, x);
        
        /// <summary>
        /// Returns int4.wwzy swizzling.
        /// </summary>
        [Inline]
        public int4 wwzy =>  int4(w, w, z, y);
        
        /// <summary>
        /// Returns int4.aabg swizzling (equivalent to int4.wwzy).
        /// </summary>
        [Inline]
        public int4 aabg =>  int4(w, w, z, y);
        
        /// <summary>
        /// Returns int4.wwzz swizzling.
        /// </summary>
        [Inline]
        public int4 wwzz =>  int4(w, w, z, z);
        
        /// <summary>
        /// Returns int4.aabb swizzling (equivalent to int4.wwzz).
        /// </summary>
        [Inline]
        public int4 aabb =>  int4(w, w, z, z);
        
        /// <summary>
        /// Returns int4.wwzw swizzling.
        /// </summary>
        [Inline]
        public int4 wwzw =>  int4(w, w, z, w);
        
        /// <summary>
        /// Returns int4.aaba swizzling (equivalent to int4.wwzw).
        /// </summary>
        [Inline]
        public int4 aaba =>  int4(w, w, z, w);
        
        /// <summary>
        /// Returns int4.www swizzling.
        /// </summary>
        [Inline]
        public int3 www =>  int3(w, w, w);
        
        /// <summary>
        /// Returns int4.aaa swizzling (equivalent to int4.www).
        /// </summary>
        [Inline]
        public int3 aaa =>  int3(w, w, w);
        
        /// <summary>
        /// Returns int4.wwwx swizzling.
        /// </summary>
        [Inline]
        public int4 wwwx =>  int4(w, w, w, x);
        
        /// <summary>
        /// Returns int4.aaar swizzling (equivalent to int4.wwwx).
        /// </summary>
        [Inline]
        public int4 aaar =>  int4(w, w, w, x);
        
        /// <summary>
        /// Returns int4.wwwy swizzling.
        /// </summary>
        [Inline]
        public int4 wwwy =>  int4(w, w, w, y);
        
        /// <summary>
        /// Returns int4.aaag swizzling (equivalent to int4.wwwy).
        /// </summary>
        [Inline]
        public int4 aaag =>  int4(w, w, w, y);
        
        /// <summary>
        /// Returns int4.wwwz swizzling.
        /// </summary>
        [Inline]
        public int4 wwwz =>  int4(w, w, w, z);
        
        /// <summary>
        /// Returns int4.aaab swizzling (equivalent to int4.wwwz).
        /// </summary>
        [Inline]
        public int4 aaab =>  int4(w, w, w, z);
        
        /// <summary>
        /// Returns int4.wwww swizzling.
        /// </summary>
        [Inline]
        public int4 wwww =>  int4(w, w, w, w);
        
        /// <summary>
        /// Returns int4.aaaa swizzling (equivalent to int4.wwww).
        /// </summary>
        [Inline]
        public int4 aaaa =>  int4(w, w, w, w);

        //#endregion

    }
}
