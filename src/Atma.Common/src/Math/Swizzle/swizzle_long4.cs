using System;
namespace Atma
{
    
    /// <summary>
    /// Temporary vector of type long with 4 components, used for implementing swizzling for long4.
    /// </summary>
    public struct swizzle_long4
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
        
        /// <summary>
        /// w-component
        /// </summary>
        private readonly long w;

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Returns long4.xx swizzling.
        /// </summary>
        [Inline]
        public long2 xx =>  long2(x, x);
        
        /// <summary>
        /// Returns long4.rr swizzling (equivalent to long4.xx).
        /// </summary>
        [Inline]
        public long2 rr =>  long2(x, x);
        
        /// <summary>
        /// Returns long4.xxx swizzling.
        /// </summary>
        [Inline]
        public long3 xxx =>  long3(x, x, x);
        
        /// <summary>
        /// Returns long4.rrr swizzling (equivalent to long4.xxx).
        /// </summary>
        [Inline]
        public long3 rrr =>  long3(x, x, x);
        
        /// <summary>
        /// Returns long4.xxxx swizzling.
        /// </summary>
        [Inline]
        public long4 xxxx =>  long4(x, x, x, x);
        
        /// <summary>
        /// Returns long4.rrrr swizzling (equivalent to long4.xxxx).
        /// </summary>
        [Inline]
        public long4 rrrr =>  long4(x, x, x, x);
        
        /// <summary>
        /// Returns long4.xxxy swizzling.
        /// </summary>
        [Inline]
        public long4 xxxy =>  long4(x, x, x, y);
        
        /// <summary>
        /// Returns long4.rrrg swizzling (equivalent to long4.xxxy).
        /// </summary>
        [Inline]
        public long4 rrrg =>  long4(x, x, x, y);
        
        /// <summary>
        /// Returns long4.xxxz swizzling.
        /// </summary>
        [Inline]
        public long4 xxxz =>  long4(x, x, x, z);
        
        /// <summary>
        /// Returns long4.rrrb swizzling (equivalent to long4.xxxz).
        /// </summary>
        [Inline]
        public long4 rrrb =>  long4(x, x, x, z);
        
        /// <summary>
        /// Returns long4.xxxw swizzling.
        /// </summary>
        [Inline]
        public long4 xxxw =>  long4(x, x, x, w);
        
        /// <summary>
        /// Returns long4.rrra swizzling (equivalent to long4.xxxw).
        /// </summary>
        [Inline]
        public long4 rrra =>  long4(x, x, x, w);
        
        /// <summary>
        /// Returns long4.xxy swizzling.
        /// </summary>
        [Inline]
        public long3 xxy =>  long3(x, x, y);
        
        /// <summary>
        /// Returns long4.rrg swizzling (equivalent to long4.xxy).
        /// </summary>
        [Inline]
        public long3 rrg =>  long3(x, x, y);
        
        /// <summary>
        /// Returns long4.xxyx swizzling.
        /// </summary>
        [Inline]
        public long4 xxyx =>  long4(x, x, y, x);
        
        /// <summary>
        /// Returns long4.rrgr swizzling (equivalent to long4.xxyx).
        /// </summary>
        [Inline]
        public long4 rrgr =>  long4(x, x, y, x);
        
        /// <summary>
        /// Returns long4.xxyy swizzling.
        /// </summary>
        [Inline]
        public long4 xxyy =>  long4(x, x, y, y);
        
        /// <summary>
        /// Returns long4.rrgg swizzling (equivalent to long4.xxyy).
        /// </summary>
        [Inline]
        public long4 rrgg =>  long4(x, x, y, y);
        
        /// <summary>
        /// Returns long4.xxyz swizzling.
        /// </summary>
        [Inline]
        public long4 xxyz =>  long4(x, x, y, z);
        
        /// <summary>
        /// Returns long4.rrgb swizzling (equivalent to long4.xxyz).
        /// </summary>
        [Inline]
        public long4 rrgb =>  long4(x, x, y, z);
        
        /// <summary>
        /// Returns long4.xxyw swizzling.
        /// </summary>
        [Inline]
        public long4 xxyw =>  long4(x, x, y, w);
        
        /// <summary>
        /// Returns long4.rrga swizzling (equivalent to long4.xxyw).
        /// </summary>
        [Inline]
        public long4 rrga =>  long4(x, x, y, w);
        
        /// <summary>
        /// Returns long4.xxz swizzling.
        /// </summary>
        [Inline]
        public long3 xxz =>  long3(x, x, z);
        
        /// <summary>
        /// Returns long4.rrb swizzling (equivalent to long4.xxz).
        /// </summary>
        [Inline]
        public long3 rrb =>  long3(x, x, z);
        
        /// <summary>
        /// Returns long4.xxzx swizzling.
        /// </summary>
        [Inline]
        public long4 xxzx =>  long4(x, x, z, x);
        
        /// <summary>
        /// Returns long4.rrbr swizzling (equivalent to long4.xxzx).
        /// </summary>
        [Inline]
        public long4 rrbr =>  long4(x, x, z, x);
        
        /// <summary>
        /// Returns long4.xxzy swizzling.
        /// </summary>
        [Inline]
        public long4 xxzy =>  long4(x, x, z, y);
        
        /// <summary>
        /// Returns long4.rrbg swizzling (equivalent to long4.xxzy).
        /// </summary>
        [Inline]
        public long4 rrbg =>  long4(x, x, z, y);
        
        /// <summary>
        /// Returns long4.xxzz swizzling.
        /// </summary>
        [Inline]
        public long4 xxzz =>  long4(x, x, z, z);
        
        /// <summary>
        /// Returns long4.rrbb swizzling (equivalent to long4.xxzz).
        /// </summary>
        [Inline]
        public long4 rrbb =>  long4(x, x, z, z);
        
        /// <summary>
        /// Returns long4.xxzw swizzling.
        /// </summary>
        [Inline]
        public long4 xxzw =>  long4(x, x, z, w);
        
        /// <summary>
        /// Returns long4.rrba swizzling (equivalent to long4.xxzw).
        /// </summary>
        [Inline]
        public long4 rrba =>  long4(x, x, z, w);
        
        /// <summary>
        /// Returns long4.xxw swizzling.
        /// </summary>
        [Inline]
        public long3 xxw =>  long3(x, x, w);
        
        /// <summary>
        /// Returns long4.rra swizzling (equivalent to long4.xxw).
        /// </summary>
        [Inline]
        public long3 rra =>  long3(x, x, w);
        
        /// <summary>
        /// Returns long4.xxwx swizzling.
        /// </summary>
        [Inline]
        public long4 xxwx =>  long4(x, x, w, x);
        
        /// <summary>
        /// Returns long4.rrar swizzling (equivalent to long4.xxwx).
        /// </summary>
        [Inline]
        public long4 rrar =>  long4(x, x, w, x);
        
        /// <summary>
        /// Returns long4.xxwy swizzling.
        /// </summary>
        [Inline]
        public long4 xxwy =>  long4(x, x, w, y);
        
        /// <summary>
        /// Returns long4.rrag swizzling (equivalent to long4.xxwy).
        /// </summary>
        [Inline]
        public long4 rrag =>  long4(x, x, w, y);
        
        /// <summary>
        /// Returns long4.xxwz swizzling.
        /// </summary>
        [Inline]
        public long4 xxwz =>  long4(x, x, w, z);
        
        /// <summary>
        /// Returns long4.rrab swizzling (equivalent to long4.xxwz).
        /// </summary>
        [Inline]
        public long4 rrab =>  long4(x, x, w, z);
        
        /// <summary>
        /// Returns long4.xxww swizzling.
        /// </summary>
        [Inline]
        public long4 xxww =>  long4(x, x, w, w);
        
        /// <summary>
        /// Returns long4.rraa swizzling (equivalent to long4.xxww).
        /// </summary>
        [Inline]
        public long4 rraa =>  long4(x, x, w, w);
        
        /// <summary>
        /// Returns long4.xy swizzling.
        /// </summary>
        [Inline]
        public long2 xy =>  long2(x, y);
        
        /// <summary>
        /// Returns long4.rg swizzling (equivalent to long4.xy).
        /// </summary>
        [Inline]
        public long2 rg =>  long2(x, y);
        
        /// <summary>
        /// Returns long4.xyx swizzling.
        /// </summary>
        [Inline]
        public long3 xyx =>  long3(x, y, x);
        
        /// <summary>
        /// Returns long4.rgr swizzling (equivalent to long4.xyx).
        /// </summary>
        [Inline]
        public long3 rgr =>  long3(x, y, x);
        
        /// <summary>
        /// Returns long4.xyxx swizzling.
        /// </summary>
        [Inline]
        public long4 xyxx =>  long4(x, y, x, x);
        
        /// <summary>
        /// Returns long4.rgrr swizzling (equivalent to long4.xyxx).
        /// </summary>
        [Inline]
        public long4 rgrr =>  long4(x, y, x, x);
        
        /// <summary>
        /// Returns long4.xyxy swizzling.
        /// </summary>
        [Inline]
        public long4 xyxy =>  long4(x, y, x, y);
        
        /// <summary>
        /// Returns long4.rgrg swizzling (equivalent to long4.xyxy).
        /// </summary>
        [Inline]
        public long4 rgrg =>  long4(x, y, x, y);
        
        /// <summary>
        /// Returns long4.xyxz swizzling.
        /// </summary>
        [Inline]
        public long4 xyxz =>  long4(x, y, x, z);
        
        /// <summary>
        /// Returns long4.rgrb swizzling (equivalent to long4.xyxz).
        /// </summary>
        [Inline]
        public long4 rgrb =>  long4(x, y, x, z);
        
        /// <summary>
        /// Returns long4.xyxw swizzling.
        /// </summary>
        [Inline]
        public long4 xyxw =>  long4(x, y, x, w);
        
        /// <summary>
        /// Returns long4.rgra swizzling (equivalent to long4.xyxw).
        /// </summary>
        [Inline]
        public long4 rgra =>  long4(x, y, x, w);
        
        /// <summary>
        /// Returns long4.xyy swizzling.
        /// </summary>
        [Inline]
        public long3 xyy =>  long3(x, y, y);
        
        /// <summary>
        /// Returns long4.rgg swizzling (equivalent to long4.xyy).
        /// </summary>
        [Inline]
        public long3 rgg =>  long3(x, y, y);
        
        /// <summary>
        /// Returns long4.xyyx swizzling.
        /// </summary>
        [Inline]
        public long4 xyyx =>  long4(x, y, y, x);
        
        /// <summary>
        /// Returns long4.rggr swizzling (equivalent to long4.xyyx).
        /// </summary>
        [Inline]
        public long4 rggr =>  long4(x, y, y, x);
        
        /// <summary>
        /// Returns long4.xyyy swizzling.
        /// </summary>
        [Inline]
        public long4 xyyy =>  long4(x, y, y, y);
        
        /// <summary>
        /// Returns long4.rggg swizzling (equivalent to long4.xyyy).
        /// </summary>
        [Inline]
        public long4 rggg =>  long4(x, y, y, y);
        
        /// <summary>
        /// Returns long4.xyyz swizzling.
        /// </summary>
        [Inline]
        public long4 xyyz =>  long4(x, y, y, z);
        
        /// <summary>
        /// Returns long4.rggb swizzling (equivalent to long4.xyyz).
        /// </summary>
        [Inline]
        public long4 rggb =>  long4(x, y, y, z);
        
        /// <summary>
        /// Returns long4.xyyw swizzling.
        /// </summary>
        [Inline]
        public long4 xyyw =>  long4(x, y, y, w);
        
        /// <summary>
        /// Returns long4.rgga swizzling (equivalent to long4.xyyw).
        /// </summary>
        [Inline]
        public long4 rgga =>  long4(x, y, y, w);
        
        /// <summary>
        /// Returns long4.xyz swizzling.
        /// </summary>
        [Inline]
        public long3 xyz =>  long3(x, y, z);
        
        /// <summary>
        /// Returns long4.rgb swizzling (equivalent to long4.xyz).
        /// </summary>
        [Inline]
        public long3 rgb =>  long3(x, y, z);
        
        /// <summary>
        /// Returns long4.xyzx swizzling.
        /// </summary>
        [Inline]
        public long4 xyzx =>  long4(x, y, z, x);
        
        /// <summary>
        /// Returns long4.rgbr swizzling (equivalent to long4.xyzx).
        /// </summary>
        [Inline]
        public long4 rgbr =>  long4(x, y, z, x);
        
        /// <summary>
        /// Returns long4.xyzy swizzling.
        /// </summary>
        [Inline]
        public long4 xyzy =>  long4(x, y, z, y);
        
        /// <summary>
        /// Returns long4.rgbg swizzling (equivalent to long4.xyzy).
        /// </summary>
        [Inline]
        public long4 rgbg =>  long4(x, y, z, y);
        
        /// <summary>
        /// Returns long4.xyzz swizzling.
        /// </summary>
        [Inline]
        public long4 xyzz =>  long4(x, y, z, z);
        
        /// <summary>
        /// Returns long4.rgbb swizzling (equivalent to long4.xyzz).
        /// </summary>
        [Inline]
        public long4 rgbb =>  long4(x, y, z, z);
        
        /// <summary>
        /// Returns long4.xyzw swizzling.
        /// </summary>
        [Inline]
        public long4 xyzw =>  long4(x, y, z, w);
        
        /// <summary>
        /// Returns long4.rgba swizzling (equivalent to long4.xyzw).
        /// </summary>
        [Inline]
        public long4 rgba =>  long4(x, y, z, w);
        
        /// <summary>
        /// Returns long4.xyw swizzling.
        /// </summary>
        [Inline]
        public long3 xyw =>  long3(x, y, w);
        
        /// <summary>
        /// Returns long4.rga swizzling (equivalent to long4.xyw).
        /// </summary>
        [Inline]
        public long3 rga =>  long3(x, y, w);
        
        /// <summary>
        /// Returns long4.xywx swizzling.
        /// </summary>
        [Inline]
        public long4 xywx =>  long4(x, y, w, x);
        
        /// <summary>
        /// Returns long4.rgar swizzling (equivalent to long4.xywx).
        /// </summary>
        [Inline]
        public long4 rgar =>  long4(x, y, w, x);
        
        /// <summary>
        /// Returns long4.xywy swizzling.
        /// </summary>
        [Inline]
        public long4 xywy =>  long4(x, y, w, y);
        
        /// <summary>
        /// Returns long4.rgag swizzling (equivalent to long4.xywy).
        /// </summary>
        [Inline]
        public long4 rgag =>  long4(x, y, w, y);
        
        /// <summary>
        /// Returns long4.xywz swizzling.
        /// </summary>
        [Inline]
        public long4 xywz =>  long4(x, y, w, z);
        
        /// <summary>
        /// Returns long4.rgab swizzling (equivalent to long4.xywz).
        /// </summary>
        [Inline]
        public long4 rgab =>  long4(x, y, w, z);
        
        /// <summary>
        /// Returns long4.xyww swizzling.
        /// </summary>
        [Inline]
        public long4 xyww =>  long4(x, y, w, w);
        
        /// <summary>
        /// Returns long4.rgaa swizzling (equivalent to long4.xyww).
        /// </summary>
        [Inline]
        public long4 rgaa =>  long4(x, y, w, w);
        
        /// <summary>
        /// Returns long4.xz swizzling.
        /// </summary>
        [Inline]
        public long2 xz =>  long2(x, z);
        
        /// <summary>
        /// Returns long4.rb swizzling (equivalent to long4.xz).
        /// </summary>
        [Inline]
        public long2 rb =>  long2(x, z);
        
        /// <summary>
        /// Returns long4.xzx swizzling.
        /// </summary>
        [Inline]
        public long3 xzx =>  long3(x, z, x);
        
        /// <summary>
        /// Returns long4.rbr swizzling (equivalent to long4.xzx).
        /// </summary>
        [Inline]
        public long3 rbr =>  long3(x, z, x);
        
        /// <summary>
        /// Returns long4.xzxx swizzling.
        /// </summary>
        [Inline]
        public long4 xzxx =>  long4(x, z, x, x);
        
        /// <summary>
        /// Returns long4.rbrr swizzling (equivalent to long4.xzxx).
        /// </summary>
        [Inline]
        public long4 rbrr =>  long4(x, z, x, x);
        
        /// <summary>
        /// Returns long4.xzxy swizzling.
        /// </summary>
        [Inline]
        public long4 xzxy =>  long4(x, z, x, y);
        
        /// <summary>
        /// Returns long4.rbrg swizzling (equivalent to long4.xzxy).
        /// </summary>
        [Inline]
        public long4 rbrg =>  long4(x, z, x, y);
        
        /// <summary>
        /// Returns long4.xzxz swizzling.
        /// </summary>
        [Inline]
        public long4 xzxz =>  long4(x, z, x, z);
        
        /// <summary>
        /// Returns long4.rbrb swizzling (equivalent to long4.xzxz).
        /// </summary>
        [Inline]
        public long4 rbrb =>  long4(x, z, x, z);
        
        /// <summary>
        /// Returns long4.xzxw swizzling.
        /// </summary>
        [Inline]
        public long4 xzxw =>  long4(x, z, x, w);
        
        /// <summary>
        /// Returns long4.rbra swizzling (equivalent to long4.xzxw).
        /// </summary>
        [Inline]
        public long4 rbra =>  long4(x, z, x, w);
        
        /// <summary>
        /// Returns long4.xzy swizzling.
        /// </summary>
        [Inline]
        public long3 xzy =>  long3(x, z, y);
        
        /// <summary>
        /// Returns long4.rbg swizzling (equivalent to long4.xzy).
        /// </summary>
        [Inline]
        public long3 rbg =>  long3(x, z, y);
        
        /// <summary>
        /// Returns long4.xzyx swizzling.
        /// </summary>
        [Inline]
        public long4 xzyx =>  long4(x, z, y, x);
        
        /// <summary>
        /// Returns long4.rbgr swizzling (equivalent to long4.xzyx).
        /// </summary>
        [Inline]
        public long4 rbgr =>  long4(x, z, y, x);
        
        /// <summary>
        /// Returns long4.xzyy swizzling.
        /// </summary>
        [Inline]
        public long4 xzyy =>  long4(x, z, y, y);
        
        /// <summary>
        /// Returns long4.rbgg swizzling (equivalent to long4.xzyy).
        /// </summary>
        [Inline]
        public long4 rbgg =>  long4(x, z, y, y);
        
        /// <summary>
        /// Returns long4.xzyz swizzling.
        /// </summary>
        [Inline]
        public long4 xzyz =>  long4(x, z, y, z);
        
        /// <summary>
        /// Returns long4.rbgb swizzling (equivalent to long4.xzyz).
        /// </summary>
        [Inline]
        public long4 rbgb =>  long4(x, z, y, z);
        
        /// <summary>
        /// Returns long4.xzyw swizzling.
        /// </summary>
        [Inline]
        public long4 xzyw =>  long4(x, z, y, w);
        
        /// <summary>
        /// Returns long4.rbga swizzling (equivalent to long4.xzyw).
        /// </summary>
        [Inline]
        public long4 rbga =>  long4(x, z, y, w);
        
        /// <summary>
        /// Returns long4.xzz swizzling.
        /// </summary>
        [Inline]
        public long3 xzz =>  long3(x, z, z);
        
        /// <summary>
        /// Returns long4.rbb swizzling (equivalent to long4.xzz).
        /// </summary>
        [Inline]
        public long3 rbb =>  long3(x, z, z);
        
        /// <summary>
        /// Returns long4.xzzx swizzling.
        /// </summary>
        [Inline]
        public long4 xzzx =>  long4(x, z, z, x);
        
        /// <summary>
        /// Returns long4.rbbr swizzling (equivalent to long4.xzzx).
        /// </summary>
        [Inline]
        public long4 rbbr =>  long4(x, z, z, x);
        
        /// <summary>
        /// Returns long4.xzzy swizzling.
        /// </summary>
        [Inline]
        public long4 xzzy =>  long4(x, z, z, y);
        
        /// <summary>
        /// Returns long4.rbbg swizzling (equivalent to long4.xzzy).
        /// </summary>
        [Inline]
        public long4 rbbg =>  long4(x, z, z, y);
        
        /// <summary>
        /// Returns long4.xzzz swizzling.
        /// </summary>
        [Inline]
        public long4 xzzz =>  long4(x, z, z, z);
        
        /// <summary>
        /// Returns long4.rbbb swizzling (equivalent to long4.xzzz).
        /// </summary>
        [Inline]
        public long4 rbbb =>  long4(x, z, z, z);
        
        /// <summary>
        /// Returns long4.xzzw swizzling.
        /// </summary>
        [Inline]
        public long4 xzzw =>  long4(x, z, z, w);
        
        /// <summary>
        /// Returns long4.rbba swizzling (equivalent to long4.xzzw).
        /// </summary>
        [Inline]
        public long4 rbba =>  long4(x, z, z, w);
        
        /// <summary>
        /// Returns long4.xzw swizzling.
        /// </summary>
        [Inline]
        public long3 xzw =>  long3(x, z, w);
        
        /// <summary>
        /// Returns long4.rba swizzling (equivalent to long4.xzw).
        /// </summary>
        [Inline]
        public long3 rba =>  long3(x, z, w);
        
        /// <summary>
        /// Returns long4.xzwx swizzling.
        /// </summary>
        [Inline]
        public long4 xzwx =>  long4(x, z, w, x);
        
        /// <summary>
        /// Returns long4.rbar swizzling (equivalent to long4.xzwx).
        /// </summary>
        [Inline]
        public long4 rbar =>  long4(x, z, w, x);
        
        /// <summary>
        /// Returns long4.xzwy swizzling.
        /// </summary>
        [Inline]
        public long4 xzwy =>  long4(x, z, w, y);
        
        /// <summary>
        /// Returns long4.rbag swizzling (equivalent to long4.xzwy).
        /// </summary>
        [Inline]
        public long4 rbag =>  long4(x, z, w, y);
        
        /// <summary>
        /// Returns long4.xzwz swizzling.
        /// </summary>
        [Inline]
        public long4 xzwz =>  long4(x, z, w, z);
        
        /// <summary>
        /// Returns long4.rbab swizzling (equivalent to long4.xzwz).
        /// </summary>
        [Inline]
        public long4 rbab =>  long4(x, z, w, z);
        
        /// <summary>
        /// Returns long4.xzww swizzling.
        /// </summary>
        [Inline]
        public long4 xzww =>  long4(x, z, w, w);
        
        /// <summary>
        /// Returns long4.rbaa swizzling (equivalent to long4.xzww).
        /// </summary>
        [Inline]
        public long4 rbaa =>  long4(x, z, w, w);
        
        /// <summary>
        /// Returns long4.xw swizzling.
        /// </summary>
        [Inline]
        public long2 xw =>  long2(x, w);
        
        /// <summary>
        /// Returns long4.ra swizzling (equivalent to long4.xw).
        /// </summary>
        [Inline]
        public long2 ra =>  long2(x, w);
        
        /// <summary>
        /// Returns long4.xwx swizzling.
        /// </summary>
        [Inline]
        public long3 xwx =>  long3(x, w, x);
        
        /// <summary>
        /// Returns long4.rar swizzling (equivalent to long4.xwx).
        /// </summary>
        [Inline]
        public long3 rar =>  long3(x, w, x);
        
        /// <summary>
        /// Returns long4.xwxx swizzling.
        /// </summary>
        [Inline]
        public long4 xwxx =>  long4(x, w, x, x);
        
        /// <summary>
        /// Returns long4.rarr swizzling (equivalent to long4.xwxx).
        /// </summary>
        [Inline]
        public long4 rarr =>  long4(x, w, x, x);
        
        /// <summary>
        /// Returns long4.xwxy swizzling.
        /// </summary>
        [Inline]
        public long4 xwxy =>  long4(x, w, x, y);
        
        /// <summary>
        /// Returns long4.rarg swizzling (equivalent to long4.xwxy).
        /// </summary>
        [Inline]
        public long4 rarg =>  long4(x, w, x, y);
        
        /// <summary>
        /// Returns long4.xwxz swizzling.
        /// </summary>
        [Inline]
        public long4 xwxz =>  long4(x, w, x, z);
        
        /// <summary>
        /// Returns long4.rarb swizzling (equivalent to long4.xwxz).
        /// </summary>
        [Inline]
        public long4 rarb =>  long4(x, w, x, z);
        
        /// <summary>
        /// Returns long4.xwxw swizzling.
        /// </summary>
        [Inline]
        public long4 xwxw =>  long4(x, w, x, w);
        
        /// <summary>
        /// Returns long4.rara swizzling (equivalent to long4.xwxw).
        /// </summary>
        [Inline]
        public long4 rara =>  long4(x, w, x, w);
        
        /// <summary>
        /// Returns long4.xwy swizzling.
        /// </summary>
        [Inline]
        public long3 xwy =>  long3(x, w, y);
        
        /// <summary>
        /// Returns long4.rag swizzling (equivalent to long4.xwy).
        /// </summary>
        [Inline]
        public long3 rag =>  long3(x, w, y);
        
        /// <summary>
        /// Returns long4.xwyx swizzling.
        /// </summary>
        [Inline]
        public long4 xwyx =>  long4(x, w, y, x);
        
        /// <summary>
        /// Returns long4.ragr swizzling (equivalent to long4.xwyx).
        /// </summary>
        [Inline]
        public long4 ragr =>  long4(x, w, y, x);
        
        /// <summary>
        /// Returns long4.xwyy swizzling.
        /// </summary>
        [Inline]
        public long4 xwyy =>  long4(x, w, y, y);
        
        /// <summary>
        /// Returns long4.ragg swizzling (equivalent to long4.xwyy).
        /// </summary>
        [Inline]
        public long4 ragg =>  long4(x, w, y, y);
        
        /// <summary>
        /// Returns long4.xwyz swizzling.
        /// </summary>
        [Inline]
        public long4 xwyz =>  long4(x, w, y, z);
        
        /// <summary>
        /// Returns long4.ragb swizzling (equivalent to long4.xwyz).
        /// </summary>
        [Inline]
        public long4 ragb =>  long4(x, w, y, z);
        
        /// <summary>
        /// Returns long4.xwyw swizzling.
        /// </summary>
        [Inline]
        public long4 xwyw =>  long4(x, w, y, w);
        
        /// <summary>
        /// Returns long4.raga swizzling (equivalent to long4.xwyw).
        /// </summary>
        [Inline]
        public long4 raga =>  long4(x, w, y, w);
        
        /// <summary>
        /// Returns long4.xwz swizzling.
        /// </summary>
        [Inline]
        public long3 xwz =>  long3(x, w, z);
        
        /// <summary>
        /// Returns long4.rab swizzling (equivalent to long4.xwz).
        /// </summary>
        [Inline]
        public long3 rab =>  long3(x, w, z);
        
        /// <summary>
        /// Returns long4.xwzx swizzling.
        /// </summary>
        [Inline]
        public long4 xwzx =>  long4(x, w, z, x);
        
        /// <summary>
        /// Returns long4.rabr swizzling (equivalent to long4.xwzx).
        /// </summary>
        [Inline]
        public long4 rabr =>  long4(x, w, z, x);
        
        /// <summary>
        /// Returns long4.xwzy swizzling.
        /// </summary>
        [Inline]
        public long4 xwzy =>  long4(x, w, z, y);
        
        /// <summary>
        /// Returns long4.rabg swizzling (equivalent to long4.xwzy).
        /// </summary>
        [Inline]
        public long4 rabg =>  long4(x, w, z, y);
        
        /// <summary>
        /// Returns long4.xwzz swizzling.
        /// </summary>
        [Inline]
        public long4 xwzz =>  long4(x, w, z, z);
        
        /// <summary>
        /// Returns long4.rabb swizzling (equivalent to long4.xwzz).
        /// </summary>
        [Inline]
        public long4 rabb =>  long4(x, w, z, z);
        
        /// <summary>
        /// Returns long4.xwzw swizzling.
        /// </summary>
        [Inline]
        public long4 xwzw =>  long4(x, w, z, w);
        
        /// <summary>
        /// Returns long4.raba swizzling (equivalent to long4.xwzw).
        /// </summary>
        [Inline]
        public long4 raba =>  long4(x, w, z, w);
        
        /// <summary>
        /// Returns long4.xww swizzling.
        /// </summary>
        [Inline]
        public long3 xww =>  long3(x, w, w);
        
        /// <summary>
        /// Returns long4.raa swizzling (equivalent to long4.xww).
        /// </summary>
        [Inline]
        public long3 raa =>  long3(x, w, w);
        
        /// <summary>
        /// Returns long4.xwwx swizzling.
        /// </summary>
        [Inline]
        public long4 xwwx =>  long4(x, w, w, x);
        
        /// <summary>
        /// Returns long4.raar swizzling (equivalent to long4.xwwx).
        /// </summary>
        [Inline]
        public long4 raar =>  long4(x, w, w, x);
        
        /// <summary>
        /// Returns long4.xwwy swizzling.
        /// </summary>
        [Inline]
        public long4 xwwy =>  long4(x, w, w, y);
        
        /// <summary>
        /// Returns long4.raag swizzling (equivalent to long4.xwwy).
        /// </summary>
        [Inline]
        public long4 raag =>  long4(x, w, w, y);
        
        /// <summary>
        /// Returns long4.xwwz swizzling.
        /// </summary>
        [Inline]
        public long4 xwwz =>  long4(x, w, w, z);
        
        /// <summary>
        /// Returns long4.raab swizzling (equivalent to long4.xwwz).
        /// </summary>
        [Inline]
        public long4 raab =>  long4(x, w, w, z);
        
        /// <summary>
        /// Returns long4.xwww swizzling.
        /// </summary>
        [Inline]
        public long4 xwww =>  long4(x, w, w, w);
        
        /// <summary>
        /// Returns long4.raaa swizzling (equivalent to long4.xwww).
        /// </summary>
        [Inline]
        public long4 raaa =>  long4(x, w, w, w);
        
        /// <summary>
        /// Returns long4.yx swizzling.
        /// </summary>
        [Inline]
        public long2 yx =>  long2(y, x);
        
        /// <summary>
        /// Returns long4.gr swizzling (equivalent to long4.yx).
        /// </summary>
        [Inline]
        public long2 gr =>  long2(y, x);
        
        /// <summary>
        /// Returns long4.yxx swizzling.
        /// </summary>
        [Inline]
        public long3 yxx =>  long3(y, x, x);
        
        /// <summary>
        /// Returns long4.grr swizzling (equivalent to long4.yxx).
        /// </summary>
        [Inline]
        public long3 grr =>  long3(y, x, x);
        
        /// <summary>
        /// Returns long4.yxxx swizzling.
        /// </summary>
        [Inline]
        public long4 yxxx =>  long4(y, x, x, x);
        
        /// <summary>
        /// Returns long4.grrr swizzling (equivalent to long4.yxxx).
        /// </summary>
        [Inline]
        public long4 grrr =>  long4(y, x, x, x);
        
        /// <summary>
        /// Returns long4.yxxy swizzling.
        /// </summary>
        [Inline]
        public long4 yxxy =>  long4(y, x, x, y);
        
        /// <summary>
        /// Returns long4.grrg swizzling (equivalent to long4.yxxy).
        /// </summary>
        [Inline]
        public long4 grrg =>  long4(y, x, x, y);
        
        /// <summary>
        /// Returns long4.yxxz swizzling.
        /// </summary>
        [Inline]
        public long4 yxxz =>  long4(y, x, x, z);
        
        /// <summary>
        /// Returns long4.grrb swizzling (equivalent to long4.yxxz).
        /// </summary>
        [Inline]
        public long4 grrb =>  long4(y, x, x, z);
        
        /// <summary>
        /// Returns long4.yxxw swizzling.
        /// </summary>
        [Inline]
        public long4 yxxw =>  long4(y, x, x, w);
        
        /// <summary>
        /// Returns long4.grra swizzling (equivalent to long4.yxxw).
        /// </summary>
        [Inline]
        public long4 grra =>  long4(y, x, x, w);
        
        /// <summary>
        /// Returns long4.yxy swizzling.
        /// </summary>
        [Inline]
        public long3 yxy =>  long3(y, x, y);
        
        /// <summary>
        /// Returns long4.grg swizzling (equivalent to long4.yxy).
        /// </summary>
        [Inline]
        public long3 grg =>  long3(y, x, y);
        
        /// <summary>
        /// Returns long4.yxyx swizzling.
        /// </summary>
        [Inline]
        public long4 yxyx =>  long4(y, x, y, x);
        
        /// <summary>
        /// Returns long4.grgr swizzling (equivalent to long4.yxyx).
        /// </summary>
        [Inline]
        public long4 grgr =>  long4(y, x, y, x);
        
        /// <summary>
        /// Returns long4.yxyy swizzling.
        /// </summary>
        [Inline]
        public long4 yxyy =>  long4(y, x, y, y);
        
        /// <summary>
        /// Returns long4.grgg swizzling (equivalent to long4.yxyy).
        /// </summary>
        [Inline]
        public long4 grgg =>  long4(y, x, y, y);
        
        /// <summary>
        /// Returns long4.yxyz swizzling.
        /// </summary>
        [Inline]
        public long4 yxyz =>  long4(y, x, y, z);
        
        /// <summary>
        /// Returns long4.grgb swizzling (equivalent to long4.yxyz).
        /// </summary>
        [Inline]
        public long4 grgb =>  long4(y, x, y, z);
        
        /// <summary>
        /// Returns long4.yxyw swizzling.
        /// </summary>
        [Inline]
        public long4 yxyw =>  long4(y, x, y, w);
        
        /// <summary>
        /// Returns long4.grga swizzling (equivalent to long4.yxyw).
        /// </summary>
        [Inline]
        public long4 grga =>  long4(y, x, y, w);
        
        /// <summary>
        /// Returns long4.yxz swizzling.
        /// </summary>
        [Inline]
        public long3 yxz =>  long3(y, x, z);
        
        /// <summary>
        /// Returns long4.grb swizzling (equivalent to long4.yxz).
        /// </summary>
        [Inline]
        public long3 grb =>  long3(y, x, z);
        
        /// <summary>
        /// Returns long4.yxzx swizzling.
        /// </summary>
        [Inline]
        public long4 yxzx =>  long4(y, x, z, x);
        
        /// <summary>
        /// Returns long4.grbr swizzling (equivalent to long4.yxzx).
        /// </summary>
        [Inline]
        public long4 grbr =>  long4(y, x, z, x);
        
        /// <summary>
        /// Returns long4.yxzy swizzling.
        /// </summary>
        [Inline]
        public long4 yxzy =>  long4(y, x, z, y);
        
        /// <summary>
        /// Returns long4.grbg swizzling (equivalent to long4.yxzy).
        /// </summary>
        [Inline]
        public long4 grbg =>  long4(y, x, z, y);
        
        /// <summary>
        /// Returns long4.yxzz swizzling.
        /// </summary>
        [Inline]
        public long4 yxzz =>  long4(y, x, z, z);
        
        /// <summary>
        /// Returns long4.grbb swizzling (equivalent to long4.yxzz).
        /// </summary>
        [Inline]
        public long4 grbb =>  long4(y, x, z, z);
        
        /// <summary>
        /// Returns long4.yxzw swizzling.
        /// </summary>
        [Inline]
        public long4 yxzw =>  long4(y, x, z, w);
        
        /// <summary>
        /// Returns long4.grba swizzling (equivalent to long4.yxzw).
        /// </summary>
        [Inline]
        public long4 grba =>  long4(y, x, z, w);
        
        /// <summary>
        /// Returns long4.yxw swizzling.
        /// </summary>
        [Inline]
        public long3 yxw =>  long3(y, x, w);
        
        /// <summary>
        /// Returns long4.gra swizzling (equivalent to long4.yxw).
        /// </summary>
        [Inline]
        public long3 gra =>  long3(y, x, w);
        
        /// <summary>
        /// Returns long4.yxwx swizzling.
        /// </summary>
        [Inline]
        public long4 yxwx =>  long4(y, x, w, x);
        
        /// <summary>
        /// Returns long4.grar swizzling (equivalent to long4.yxwx).
        /// </summary>
        [Inline]
        public long4 grar =>  long4(y, x, w, x);
        
        /// <summary>
        /// Returns long4.yxwy swizzling.
        /// </summary>
        [Inline]
        public long4 yxwy =>  long4(y, x, w, y);
        
        /// <summary>
        /// Returns long4.grag swizzling (equivalent to long4.yxwy).
        /// </summary>
        [Inline]
        public long4 grag =>  long4(y, x, w, y);
        
        /// <summary>
        /// Returns long4.yxwz swizzling.
        /// </summary>
        [Inline]
        public long4 yxwz =>  long4(y, x, w, z);
        
        /// <summary>
        /// Returns long4.grab swizzling (equivalent to long4.yxwz).
        /// </summary>
        [Inline]
        public long4 grab =>  long4(y, x, w, z);
        
        /// <summary>
        /// Returns long4.yxww swizzling.
        /// </summary>
        [Inline]
        public long4 yxww =>  long4(y, x, w, w);
        
        /// <summary>
        /// Returns long4.graa swizzling (equivalent to long4.yxww).
        /// </summary>
        [Inline]
        public long4 graa =>  long4(y, x, w, w);
        
        /// <summary>
        /// Returns long4.yy swizzling.
        /// </summary>
        [Inline]
        public long2 yy =>  long2(y, y);
        
        /// <summary>
        /// Returns long4.gg swizzling (equivalent to long4.yy).
        /// </summary>
        [Inline]
        public long2 gg =>  long2(y, y);
        
        /// <summary>
        /// Returns long4.yyx swizzling.
        /// </summary>
        [Inline]
        public long3 yyx =>  long3(y, y, x);
        
        /// <summary>
        /// Returns long4.ggr swizzling (equivalent to long4.yyx).
        /// </summary>
        [Inline]
        public long3 ggr =>  long3(y, y, x);
        
        /// <summary>
        /// Returns long4.yyxx swizzling.
        /// </summary>
        [Inline]
        public long4 yyxx =>  long4(y, y, x, x);
        
        /// <summary>
        /// Returns long4.ggrr swizzling (equivalent to long4.yyxx).
        /// </summary>
        [Inline]
        public long4 ggrr =>  long4(y, y, x, x);
        
        /// <summary>
        /// Returns long4.yyxy swizzling.
        /// </summary>
        [Inline]
        public long4 yyxy =>  long4(y, y, x, y);
        
        /// <summary>
        /// Returns long4.ggrg swizzling (equivalent to long4.yyxy).
        /// </summary>
        [Inline]
        public long4 ggrg =>  long4(y, y, x, y);
        
        /// <summary>
        /// Returns long4.yyxz swizzling.
        /// </summary>
        [Inline]
        public long4 yyxz =>  long4(y, y, x, z);
        
        /// <summary>
        /// Returns long4.ggrb swizzling (equivalent to long4.yyxz).
        /// </summary>
        [Inline]
        public long4 ggrb =>  long4(y, y, x, z);
        
        /// <summary>
        /// Returns long4.yyxw swizzling.
        /// </summary>
        [Inline]
        public long4 yyxw =>  long4(y, y, x, w);
        
        /// <summary>
        /// Returns long4.ggra swizzling (equivalent to long4.yyxw).
        /// </summary>
        [Inline]
        public long4 ggra =>  long4(y, y, x, w);
        
        /// <summary>
        /// Returns long4.yyy swizzling.
        /// </summary>
        [Inline]
        public long3 yyy =>  long3(y, y, y);
        
        /// <summary>
        /// Returns long4.ggg swizzling (equivalent to long4.yyy).
        /// </summary>
        [Inline]
        public long3 ggg =>  long3(y, y, y);
        
        /// <summary>
        /// Returns long4.yyyx swizzling.
        /// </summary>
        [Inline]
        public long4 yyyx =>  long4(y, y, y, x);
        
        /// <summary>
        /// Returns long4.gggr swizzling (equivalent to long4.yyyx).
        /// </summary>
        [Inline]
        public long4 gggr =>  long4(y, y, y, x);
        
        /// <summary>
        /// Returns long4.yyyy swizzling.
        /// </summary>
        [Inline]
        public long4 yyyy =>  long4(y, y, y, y);
        
        /// <summary>
        /// Returns long4.gggg swizzling (equivalent to long4.yyyy).
        /// </summary>
        [Inline]
        public long4 gggg =>  long4(y, y, y, y);
        
        /// <summary>
        /// Returns long4.yyyz swizzling.
        /// </summary>
        [Inline]
        public long4 yyyz =>  long4(y, y, y, z);
        
        /// <summary>
        /// Returns long4.gggb swizzling (equivalent to long4.yyyz).
        /// </summary>
        [Inline]
        public long4 gggb =>  long4(y, y, y, z);
        
        /// <summary>
        /// Returns long4.yyyw swizzling.
        /// </summary>
        [Inline]
        public long4 yyyw =>  long4(y, y, y, w);
        
        /// <summary>
        /// Returns long4.ggga swizzling (equivalent to long4.yyyw).
        /// </summary>
        [Inline]
        public long4 ggga =>  long4(y, y, y, w);
        
        /// <summary>
        /// Returns long4.yyz swizzling.
        /// </summary>
        [Inline]
        public long3 yyz =>  long3(y, y, z);
        
        /// <summary>
        /// Returns long4.ggb swizzling (equivalent to long4.yyz).
        /// </summary>
        [Inline]
        public long3 ggb =>  long3(y, y, z);
        
        /// <summary>
        /// Returns long4.yyzx swizzling.
        /// </summary>
        [Inline]
        public long4 yyzx =>  long4(y, y, z, x);
        
        /// <summary>
        /// Returns long4.ggbr swizzling (equivalent to long4.yyzx).
        /// </summary>
        [Inline]
        public long4 ggbr =>  long4(y, y, z, x);
        
        /// <summary>
        /// Returns long4.yyzy swizzling.
        /// </summary>
        [Inline]
        public long4 yyzy =>  long4(y, y, z, y);
        
        /// <summary>
        /// Returns long4.ggbg swizzling (equivalent to long4.yyzy).
        /// </summary>
        [Inline]
        public long4 ggbg =>  long4(y, y, z, y);
        
        /// <summary>
        /// Returns long4.yyzz swizzling.
        /// </summary>
        [Inline]
        public long4 yyzz =>  long4(y, y, z, z);
        
        /// <summary>
        /// Returns long4.ggbb swizzling (equivalent to long4.yyzz).
        /// </summary>
        [Inline]
        public long4 ggbb =>  long4(y, y, z, z);
        
        /// <summary>
        /// Returns long4.yyzw swizzling.
        /// </summary>
        [Inline]
        public long4 yyzw =>  long4(y, y, z, w);
        
        /// <summary>
        /// Returns long4.ggba swizzling (equivalent to long4.yyzw).
        /// </summary>
        [Inline]
        public long4 ggba =>  long4(y, y, z, w);
        
        /// <summary>
        /// Returns long4.yyw swizzling.
        /// </summary>
        [Inline]
        public long3 yyw =>  long3(y, y, w);
        
        /// <summary>
        /// Returns long4.gga swizzling (equivalent to long4.yyw).
        /// </summary>
        [Inline]
        public long3 gga =>  long3(y, y, w);
        
        /// <summary>
        /// Returns long4.yywx swizzling.
        /// </summary>
        [Inline]
        public long4 yywx =>  long4(y, y, w, x);
        
        /// <summary>
        /// Returns long4.ggar swizzling (equivalent to long4.yywx).
        /// </summary>
        [Inline]
        public long4 ggar =>  long4(y, y, w, x);
        
        /// <summary>
        /// Returns long4.yywy swizzling.
        /// </summary>
        [Inline]
        public long4 yywy =>  long4(y, y, w, y);
        
        /// <summary>
        /// Returns long4.ggag swizzling (equivalent to long4.yywy).
        /// </summary>
        [Inline]
        public long4 ggag =>  long4(y, y, w, y);
        
        /// <summary>
        /// Returns long4.yywz swizzling.
        /// </summary>
        [Inline]
        public long4 yywz =>  long4(y, y, w, z);
        
        /// <summary>
        /// Returns long4.ggab swizzling (equivalent to long4.yywz).
        /// </summary>
        [Inline]
        public long4 ggab =>  long4(y, y, w, z);
        
        /// <summary>
        /// Returns long4.yyww swizzling.
        /// </summary>
        [Inline]
        public long4 yyww =>  long4(y, y, w, w);
        
        /// <summary>
        /// Returns long4.ggaa swizzling (equivalent to long4.yyww).
        /// </summary>
        [Inline]
        public long4 ggaa =>  long4(y, y, w, w);
        
        /// <summary>
        /// Returns long4.yz swizzling.
        /// </summary>
        [Inline]
        public long2 yz =>  long2(y, z);
        
        /// <summary>
        /// Returns long4.gb swizzling (equivalent to long4.yz).
        /// </summary>
        [Inline]
        public long2 gb =>  long2(y, z);
        
        /// <summary>
        /// Returns long4.yzx swizzling.
        /// </summary>
        [Inline]
        public long3 yzx =>  long3(y, z, x);
        
        /// <summary>
        /// Returns long4.gbr swizzling (equivalent to long4.yzx).
        /// </summary>
        [Inline]
        public long3 gbr =>  long3(y, z, x);
        
        /// <summary>
        /// Returns long4.yzxx swizzling.
        /// </summary>
        [Inline]
        public long4 yzxx =>  long4(y, z, x, x);
        
        /// <summary>
        /// Returns long4.gbrr swizzling (equivalent to long4.yzxx).
        /// </summary>
        [Inline]
        public long4 gbrr =>  long4(y, z, x, x);
        
        /// <summary>
        /// Returns long4.yzxy swizzling.
        /// </summary>
        [Inline]
        public long4 yzxy =>  long4(y, z, x, y);
        
        /// <summary>
        /// Returns long4.gbrg swizzling (equivalent to long4.yzxy).
        /// </summary>
        [Inline]
        public long4 gbrg =>  long4(y, z, x, y);
        
        /// <summary>
        /// Returns long4.yzxz swizzling.
        /// </summary>
        [Inline]
        public long4 yzxz =>  long4(y, z, x, z);
        
        /// <summary>
        /// Returns long4.gbrb swizzling (equivalent to long4.yzxz).
        /// </summary>
        [Inline]
        public long4 gbrb =>  long4(y, z, x, z);
        
        /// <summary>
        /// Returns long4.yzxw swizzling.
        /// </summary>
        [Inline]
        public long4 yzxw =>  long4(y, z, x, w);
        
        /// <summary>
        /// Returns long4.gbra swizzling (equivalent to long4.yzxw).
        /// </summary>
        [Inline]
        public long4 gbra =>  long4(y, z, x, w);
        
        /// <summary>
        /// Returns long4.yzy swizzling.
        /// </summary>
        [Inline]
        public long3 yzy =>  long3(y, z, y);
        
        /// <summary>
        /// Returns long4.gbg swizzling (equivalent to long4.yzy).
        /// </summary>
        [Inline]
        public long3 gbg =>  long3(y, z, y);
        
        /// <summary>
        /// Returns long4.yzyx swizzling.
        /// </summary>
        [Inline]
        public long4 yzyx =>  long4(y, z, y, x);
        
        /// <summary>
        /// Returns long4.gbgr swizzling (equivalent to long4.yzyx).
        /// </summary>
        [Inline]
        public long4 gbgr =>  long4(y, z, y, x);
        
        /// <summary>
        /// Returns long4.yzyy swizzling.
        /// </summary>
        [Inline]
        public long4 yzyy =>  long4(y, z, y, y);
        
        /// <summary>
        /// Returns long4.gbgg swizzling (equivalent to long4.yzyy).
        /// </summary>
        [Inline]
        public long4 gbgg =>  long4(y, z, y, y);
        
        /// <summary>
        /// Returns long4.yzyz swizzling.
        /// </summary>
        [Inline]
        public long4 yzyz =>  long4(y, z, y, z);
        
        /// <summary>
        /// Returns long4.gbgb swizzling (equivalent to long4.yzyz).
        /// </summary>
        [Inline]
        public long4 gbgb =>  long4(y, z, y, z);
        
        /// <summary>
        /// Returns long4.yzyw swizzling.
        /// </summary>
        [Inline]
        public long4 yzyw =>  long4(y, z, y, w);
        
        /// <summary>
        /// Returns long4.gbga swizzling (equivalent to long4.yzyw).
        /// </summary>
        [Inline]
        public long4 gbga =>  long4(y, z, y, w);
        
        /// <summary>
        /// Returns long4.yzz swizzling.
        /// </summary>
        [Inline]
        public long3 yzz =>  long3(y, z, z);
        
        /// <summary>
        /// Returns long4.gbb swizzling (equivalent to long4.yzz).
        /// </summary>
        [Inline]
        public long3 gbb =>  long3(y, z, z);
        
        /// <summary>
        /// Returns long4.yzzx swizzling.
        /// </summary>
        [Inline]
        public long4 yzzx =>  long4(y, z, z, x);
        
        /// <summary>
        /// Returns long4.gbbr swizzling (equivalent to long4.yzzx).
        /// </summary>
        [Inline]
        public long4 gbbr =>  long4(y, z, z, x);
        
        /// <summary>
        /// Returns long4.yzzy swizzling.
        /// </summary>
        [Inline]
        public long4 yzzy =>  long4(y, z, z, y);
        
        /// <summary>
        /// Returns long4.gbbg swizzling (equivalent to long4.yzzy).
        /// </summary>
        [Inline]
        public long4 gbbg =>  long4(y, z, z, y);
        
        /// <summary>
        /// Returns long4.yzzz swizzling.
        /// </summary>
        [Inline]
        public long4 yzzz =>  long4(y, z, z, z);
        
        /// <summary>
        /// Returns long4.gbbb swizzling (equivalent to long4.yzzz).
        /// </summary>
        [Inline]
        public long4 gbbb =>  long4(y, z, z, z);
        
        /// <summary>
        /// Returns long4.yzzw swizzling.
        /// </summary>
        [Inline]
        public long4 yzzw =>  long4(y, z, z, w);
        
        /// <summary>
        /// Returns long4.gbba swizzling (equivalent to long4.yzzw).
        /// </summary>
        [Inline]
        public long4 gbba =>  long4(y, z, z, w);
        
        /// <summary>
        /// Returns long4.yzw swizzling.
        /// </summary>
        [Inline]
        public long3 yzw =>  long3(y, z, w);
        
        /// <summary>
        /// Returns long4.gba swizzling (equivalent to long4.yzw).
        /// </summary>
        [Inline]
        public long3 gba =>  long3(y, z, w);
        
        /// <summary>
        /// Returns long4.yzwx swizzling.
        /// </summary>
        [Inline]
        public long4 yzwx =>  long4(y, z, w, x);
        
        /// <summary>
        /// Returns long4.gbar swizzling (equivalent to long4.yzwx).
        /// </summary>
        [Inline]
        public long4 gbar =>  long4(y, z, w, x);
        
        /// <summary>
        /// Returns long4.yzwy swizzling.
        /// </summary>
        [Inline]
        public long4 yzwy =>  long4(y, z, w, y);
        
        /// <summary>
        /// Returns long4.gbag swizzling (equivalent to long4.yzwy).
        /// </summary>
        [Inline]
        public long4 gbag =>  long4(y, z, w, y);
        
        /// <summary>
        /// Returns long4.yzwz swizzling.
        /// </summary>
        [Inline]
        public long4 yzwz =>  long4(y, z, w, z);
        
        /// <summary>
        /// Returns long4.gbab swizzling (equivalent to long4.yzwz).
        /// </summary>
        [Inline]
        public long4 gbab =>  long4(y, z, w, z);
        
        /// <summary>
        /// Returns long4.yzww swizzling.
        /// </summary>
        [Inline]
        public long4 yzww =>  long4(y, z, w, w);
        
        /// <summary>
        /// Returns long4.gbaa swizzling (equivalent to long4.yzww).
        /// </summary>
        [Inline]
        public long4 gbaa =>  long4(y, z, w, w);
        
        /// <summary>
        /// Returns long4.yw swizzling.
        /// </summary>
        [Inline]
        public long2 yw =>  long2(y, w);
        
        /// <summary>
        /// Returns long4.ga swizzling (equivalent to long4.yw).
        /// </summary>
        [Inline]
        public long2 ga =>  long2(y, w);
        
        /// <summary>
        /// Returns long4.ywx swizzling.
        /// </summary>
        [Inline]
        public long3 ywx =>  long3(y, w, x);
        
        /// <summary>
        /// Returns long4.gar swizzling (equivalent to long4.ywx).
        /// </summary>
        [Inline]
        public long3 gar =>  long3(y, w, x);
        
        /// <summary>
        /// Returns long4.ywxx swizzling.
        /// </summary>
        [Inline]
        public long4 ywxx =>  long4(y, w, x, x);
        
        /// <summary>
        /// Returns long4.garr swizzling (equivalent to long4.ywxx).
        /// </summary>
        [Inline]
        public long4 garr =>  long4(y, w, x, x);
        
        /// <summary>
        /// Returns long4.ywxy swizzling.
        /// </summary>
        [Inline]
        public long4 ywxy =>  long4(y, w, x, y);
        
        /// <summary>
        /// Returns long4.garg swizzling (equivalent to long4.ywxy).
        /// </summary>
        [Inline]
        public long4 garg =>  long4(y, w, x, y);
        
        /// <summary>
        /// Returns long4.ywxz swizzling.
        /// </summary>
        [Inline]
        public long4 ywxz =>  long4(y, w, x, z);
        
        /// <summary>
        /// Returns long4.garb swizzling (equivalent to long4.ywxz).
        /// </summary>
        [Inline]
        public long4 garb =>  long4(y, w, x, z);
        
        /// <summary>
        /// Returns long4.ywxw swizzling.
        /// </summary>
        [Inline]
        public long4 ywxw =>  long4(y, w, x, w);
        
        /// <summary>
        /// Returns long4.gara swizzling (equivalent to long4.ywxw).
        /// </summary>
        [Inline]
        public long4 gara =>  long4(y, w, x, w);
        
        /// <summary>
        /// Returns long4.ywy swizzling.
        /// </summary>
        [Inline]
        public long3 ywy =>  long3(y, w, y);
        
        /// <summary>
        /// Returns long4.gag swizzling (equivalent to long4.ywy).
        /// </summary>
        [Inline]
        public long3 gag =>  long3(y, w, y);
        
        /// <summary>
        /// Returns long4.ywyx swizzling.
        /// </summary>
        [Inline]
        public long4 ywyx =>  long4(y, w, y, x);
        
        /// <summary>
        /// Returns long4.gagr swizzling (equivalent to long4.ywyx).
        /// </summary>
        [Inline]
        public long4 gagr =>  long4(y, w, y, x);
        
        /// <summary>
        /// Returns long4.ywyy swizzling.
        /// </summary>
        [Inline]
        public long4 ywyy =>  long4(y, w, y, y);
        
        /// <summary>
        /// Returns long4.gagg swizzling (equivalent to long4.ywyy).
        /// </summary>
        [Inline]
        public long4 gagg =>  long4(y, w, y, y);
        
        /// <summary>
        /// Returns long4.ywyz swizzling.
        /// </summary>
        [Inline]
        public long4 ywyz =>  long4(y, w, y, z);
        
        /// <summary>
        /// Returns long4.gagb swizzling (equivalent to long4.ywyz).
        /// </summary>
        [Inline]
        public long4 gagb =>  long4(y, w, y, z);
        
        /// <summary>
        /// Returns long4.ywyw swizzling.
        /// </summary>
        [Inline]
        public long4 ywyw =>  long4(y, w, y, w);
        
        /// <summary>
        /// Returns long4.gaga swizzling (equivalent to long4.ywyw).
        /// </summary>
        [Inline]
        public long4 gaga =>  long4(y, w, y, w);
        
        /// <summary>
        /// Returns long4.ywz swizzling.
        /// </summary>
        [Inline]
        public long3 ywz =>  long3(y, w, z);
        
        /// <summary>
        /// Returns long4.gab swizzling (equivalent to long4.ywz).
        /// </summary>
        [Inline]
        public long3 gab =>  long3(y, w, z);
        
        /// <summary>
        /// Returns long4.ywzx swizzling.
        /// </summary>
        [Inline]
        public long4 ywzx =>  long4(y, w, z, x);
        
        /// <summary>
        /// Returns long4.gabr swizzling (equivalent to long4.ywzx).
        /// </summary>
        [Inline]
        public long4 gabr =>  long4(y, w, z, x);
        
        /// <summary>
        /// Returns long4.ywzy swizzling.
        /// </summary>
        [Inline]
        public long4 ywzy =>  long4(y, w, z, y);
        
        /// <summary>
        /// Returns long4.gabg swizzling (equivalent to long4.ywzy).
        /// </summary>
        [Inline]
        public long4 gabg =>  long4(y, w, z, y);
        
        /// <summary>
        /// Returns long4.ywzz swizzling.
        /// </summary>
        [Inline]
        public long4 ywzz =>  long4(y, w, z, z);
        
        /// <summary>
        /// Returns long4.gabb swizzling (equivalent to long4.ywzz).
        /// </summary>
        [Inline]
        public long4 gabb =>  long4(y, w, z, z);
        
        /// <summary>
        /// Returns long4.ywzw swizzling.
        /// </summary>
        [Inline]
        public long4 ywzw =>  long4(y, w, z, w);
        
        /// <summary>
        /// Returns long4.gaba swizzling (equivalent to long4.ywzw).
        /// </summary>
        [Inline]
        public long4 gaba =>  long4(y, w, z, w);
        
        /// <summary>
        /// Returns long4.yww swizzling.
        /// </summary>
        [Inline]
        public long3 yww =>  long3(y, w, w);
        
        /// <summary>
        /// Returns long4.gaa swizzling (equivalent to long4.yww).
        /// </summary>
        [Inline]
        public long3 gaa =>  long3(y, w, w);
        
        /// <summary>
        /// Returns long4.ywwx swizzling.
        /// </summary>
        [Inline]
        public long4 ywwx =>  long4(y, w, w, x);
        
        /// <summary>
        /// Returns long4.gaar swizzling (equivalent to long4.ywwx).
        /// </summary>
        [Inline]
        public long4 gaar =>  long4(y, w, w, x);
        
        /// <summary>
        /// Returns long4.ywwy swizzling.
        /// </summary>
        [Inline]
        public long4 ywwy =>  long4(y, w, w, y);
        
        /// <summary>
        /// Returns long4.gaag swizzling (equivalent to long4.ywwy).
        /// </summary>
        [Inline]
        public long4 gaag =>  long4(y, w, w, y);
        
        /// <summary>
        /// Returns long4.ywwz swizzling.
        /// </summary>
        [Inline]
        public long4 ywwz =>  long4(y, w, w, z);
        
        /// <summary>
        /// Returns long4.gaab swizzling (equivalent to long4.ywwz).
        /// </summary>
        [Inline]
        public long4 gaab =>  long4(y, w, w, z);
        
        /// <summary>
        /// Returns long4.ywww swizzling.
        /// </summary>
        [Inline]
        public long4 ywww =>  long4(y, w, w, w);
        
        /// <summary>
        /// Returns long4.gaaa swizzling (equivalent to long4.ywww).
        /// </summary>
        [Inline]
        public long4 gaaa =>  long4(y, w, w, w);
        
        /// <summary>
        /// Returns long4.zx swizzling.
        /// </summary>
        [Inline]
        public long2 zx =>  long2(z, x);
        
        /// <summary>
        /// Returns long4.br swizzling (equivalent to long4.zx).
        /// </summary>
        [Inline]
        public long2 br =>  long2(z, x);
        
        /// <summary>
        /// Returns long4.zxx swizzling.
        /// </summary>
        [Inline]
        public long3 zxx =>  long3(z, x, x);
        
        /// <summary>
        /// Returns long4.brr swizzling (equivalent to long4.zxx).
        /// </summary>
        [Inline]
        public long3 brr =>  long3(z, x, x);
        
        /// <summary>
        /// Returns long4.zxxx swizzling.
        /// </summary>
        [Inline]
        public long4 zxxx =>  long4(z, x, x, x);
        
        /// <summary>
        /// Returns long4.brrr swizzling (equivalent to long4.zxxx).
        /// </summary>
        [Inline]
        public long4 brrr =>  long4(z, x, x, x);
        
        /// <summary>
        /// Returns long4.zxxy swizzling.
        /// </summary>
        [Inline]
        public long4 zxxy =>  long4(z, x, x, y);
        
        /// <summary>
        /// Returns long4.brrg swizzling (equivalent to long4.zxxy).
        /// </summary>
        [Inline]
        public long4 brrg =>  long4(z, x, x, y);
        
        /// <summary>
        /// Returns long4.zxxz swizzling.
        /// </summary>
        [Inline]
        public long4 zxxz =>  long4(z, x, x, z);
        
        /// <summary>
        /// Returns long4.brrb swizzling (equivalent to long4.zxxz).
        /// </summary>
        [Inline]
        public long4 brrb =>  long4(z, x, x, z);
        
        /// <summary>
        /// Returns long4.zxxw swizzling.
        /// </summary>
        [Inline]
        public long4 zxxw =>  long4(z, x, x, w);
        
        /// <summary>
        /// Returns long4.brra swizzling (equivalent to long4.zxxw).
        /// </summary>
        [Inline]
        public long4 brra =>  long4(z, x, x, w);
        
        /// <summary>
        /// Returns long4.zxy swizzling.
        /// </summary>
        [Inline]
        public long3 zxy =>  long3(z, x, y);
        
        /// <summary>
        /// Returns long4.brg swizzling (equivalent to long4.zxy).
        /// </summary>
        [Inline]
        public long3 brg =>  long3(z, x, y);
        
        /// <summary>
        /// Returns long4.zxyx swizzling.
        /// </summary>
        [Inline]
        public long4 zxyx =>  long4(z, x, y, x);
        
        /// <summary>
        /// Returns long4.brgr swizzling (equivalent to long4.zxyx).
        /// </summary>
        [Inline]
        public long4 brgr =>  long4(z, x, y, x);
        
        /// <summary>
        /// Returns long4.zxyy swizzling.
        /// </summary>
        [Inline]
        public long4 zxyy =>  long4(z, x, y, y);
        
        /// <summary>
        /// Returns long4.brgg swizzling (equivalent to long4.zxyy).
        /// </summary>
        [Inline]
        public long4 brgg =>  long4(z, x, y, y);
        
        /// <summary>
        /// Returns long4.zxyz swizzling.
        /// </summary>
        [Inline]
        public long4 zxyz =>  long4(z, x, y, z);
        
        /// <summary>
        /// Returns long4.brgb swizzling (equivalent to long4.zxyz).
        /// </summary>
        [Inline]
        public long4 brgb =>  long4(z, x, y, z);
        
        /// <summary>
        /// Returns long4.zxyw swizzling.
        /// </summary>
        [Inline]
        public long4 zxyw =>  long4(z, x, y, w);
        
        /// <summary>
        /// Returns long4.brga swizzling (equivalent to long4.zxyw).
        /// </summary>
        [Inline]
        public long4 brga =>  long4(z, x, y, w);
        
        /// <summary>
        /// Returns long4.zxz swizzling.
        /// </summary>
        [Inline]
        public long3 zxz =>  long3(z, x, z);
        
        /// <summary>
        /// Returns long4.brb swizzling (equivalent to long4.zxz).
        /// </summary>
        [Inline]
        public long3 brb =>  long3(z, x, z);
        
        /// <summary>
        /// Returns long4.zxzx swizzling.
        /// </summary>
        [Inline]
        public long4 zxzx =>  long4(z, x, z, x);
        
        /// <summary>
        /// Returns long4.brbr swizzling (equivalent to long4.zxzx).
        /// </summary>
        [Inline]
        public long4 brbr =>  long4(z, x, z, x);
        
        /// <summary>
        /// Returns long4.zxzy swizzling.
        /// </summary>
        [Inline]
        public long4 zxzy =>  long4(z, x, z, y);
        
        /// <summary>
        /// Returns long4.brbg swizzling (equivalent to long4.zxzy).
        /// </summary>
        [Inline]
        public long4 brbg =>  long4(z, x, z, y);
        
        /// <summary>
        /// Returns long4.zxzz swizzling.
        /// </summary>
        [Inline]
        public long4 zxzz =>  long4(z, x, z, z);
        
        /// <summary>
        /// Returns long4.brbb swizzling (equivalent to long4.zxzz).
        /// </summary>
        [Inline]
        public long4 brbb =>  long4(z, x, z, z);
        
        /// <summary>
        /// Returns long4.zxzw swizzling.
        /// </summary>
        [Inline]
        public long4 zxzw =>  long4(z, x, z, w);
        
        /// <summary>
        /// Returns long4.brba swizzling (equivalent to long4.zxzw).
        /// </summary>
        [Inline]
        public long4 brba =>  long4(z, x, z, w);
        
        /// <summary>
        /// Returns long4.zxw swizzling.
        /// </summary>
        [Inline]
        public long3 zxw =>  long3(z, x, w);
        
        /// <summary>
        /// Returns long4.bra swizzling (equivalent to long4.zxw).
        /// </summary>
        [Inline]
        public long3 bra =>  long3(z, x, w);
        
        /// <summary>
        /// Returns long4.zxwx swizzling.
        /// </summary>
        [Inline]
        public long4 zxwx =>  long4(z, x, w, x);
        
        /// <summary>
        /// Returns long4.brar swizzling (equivalent to long4.zxwx).
        /// </summary>
        [Inline]
        public long4 brar =>  long4(z, x, w, x);
        
        /// <summary>
        /// Returns long4.zxwy swizzling.
        /// </summary>
        [Inline]
        public long4 zxwy =>  long4(z, x, w, y);
        
        /// <summary>
        /// Returns long4.brag swizzling (equivalent to long4.zxwy).
        /// </summary>
        [Inline]
        public long4 brag =>  long4(z, x, w, y);
        
        /// <summary>
        /// Returns long4.zxwz swizzling.
        /// </summary>
        [Inline]
        public long4 zxwz =>  long4(z, x, w, z);
        
        /// <summary>
        /// Returns long4.brab swizzling (equivalent to long4.zxwz).
        /// </summary>
        [Inline]
        public long4 brab =>  long4(z, x, w, z);
        
        /// <summary>
        /// Returns long4.zxww swizzling.
        /// </summary>
        [Inline]
        public long4 zxww =>  long4(z, x, w, w);
        
        /// <summary>
        /// Returns long4.braa swizzling (equivalent to long4.zxww).
        /// </summary>
        [Inline]
        public long4 braa =>  long4(z, x, w, w);
        
        /// <summary>
        /// Returns long4.zy swizzling.
        /// </summary>
        [Inline]
        public long2 zy =>  long2(z, y);
        
        /// <summary>
        /// Returns long4.bg swizzling (equivalent to long4.zy).
        /// </summary>
        [Inline]
        public long2 bg =>  long2(z, y);
        
        /// <summary>
        /// Returns long4.zyx swizzling.
        /// </summary>
        [Inline]
        public long3 zyx =>  long3(z, y, x);
        
        /// <summary>
        /// Returns long4.bgr swizzling (equivalent to long4.zyx).
        /// </summary>
        [Inline]
        public long3 bgr =>  long3(z, y, x);
        
        /// <summary>
        /// Returns long4.zyxx swizzling.
        /// </summary>
        [Inline]
        public long4 zyxx =>  long4(z, y, x, x);
        
        /// <summary>
        /// Returns long4.bgrr swizzling (equivalent to long4.zyxx).
        /// </summary>
        [Inline]
        public long4 bgrr =>  long4(z, y, x, x);
        
        /// <summary>
        /// Returns long4.zyxy swizzling.
        /// </summary>
        [Inline]
        public long4 zyxy =>  long4(z, y, x, y);
        
        /// <summary>
        /// Returns long4.bgrg swizzling (equivalent to long4.zyxy).
        /// </summary>
        [Inline]
        public long4 bgrg =>  long4(z, y, x, y);
        
        /// <summary>
        /// Returns long4.zyxz swizzling.
        /// </summary>
        [Inline]
        public long4 zyxz =>  long4(z, y, x, z);
        
        /// <summary>
        /// Returns long4.bgrb swizzling (equivalent to long4.zyxz).
        /// </summary>
        [Inline]
        public long4 bgrb =>  long4(z, y, x, z);
        
        /// <summary>
        /// Returns long4.zyxw swizzling.
        /// </summary>
        [Inline]
        public long4 zyxw =>  long4(z, y, x, w);
        
        /// <summary>
        /// Returns long4.bgra swizzling (equivalent to long4.zyxw).
        /// </summary>
        [Inline]
        public long4 bgra =>  long4(z, y, x, w);
        
        /// <summary>
        /// Returns long4.zyy swizzling.
        /// </summary>
        [Inline]
        public long3 zyy =>  long3(z, y, y);
        
        /// <summary>
        /// Returns long4.bgg swizzling (equivalent to long4.zyy).
        /// </summary>
        [Inline]
        public long3 bgg =>  long3(z, y, y);
        
        /// <summary>
        /// Returns long4.zyyx swizzling.
        /// </summary>
        [Inline]
        public long4 zyyx =>  long4(z, y, y, x);
        
        /// <summary>
        /// Returns long4.bggr swizzling (equivalent to long4.zyyx).
        /// </summary>
        [Inline]
        public long4 bggr =>  long4(z, y, y, x);
        
        /// <summary>
        /// Returns long4.zyyy swizzling.
        /// </summary>
        [Inline]
        public long4 zyyy =>  long4(z, y, y, y);
        
        /// <summary>
        /// Returns long4.bggg swizzling (equivalent to long4.zyyy).
        /// </summary>
        [Inline]
        public long4 bggg =>  long4(z, y, y, y);
        
        /// <summary>
        /// Returns long4.zyyz swizzling.
        /// </summary>
        [Inline]
        public long4 zyyz =>  long4(z, y, y, z);
        
        /// <summary>
        /// Returns long4.bggb swizzling (equivalent to long4.zyyz).
        /// </summary>
        [Inline]
        public long4 bggb =>  long4(z, y, y, z);
        
        /// <summary>
        /// Returns long4.zyyw swizzling.
        /// </summary>
        [Inline]
        public long4 zyyw =>  long4(z, y, y, w);
        
        /// <summary>
        /// Returns long4.bgga swizzling (equivalent to long4.zyyw).
        /// </summary>
        [Inline]
        public long4 bgga =>  long4(z, y, y, w);
        
        /// <summary>
        /// Returns long4.zyz swizzling.
        /// </summary>
        [Inline]
        public long3 zyz =>  long3(z, y, z);
        
        /// <summary>
        /// Returns long4.bgb swizzling (equivalent to long4.zyz).
        /// </summary>
        [Inline]
        public long3 bgb =>  long3(z, y, z);
        
        /// <summary>
        /// Returns long4.zyzx swizzling.
        /// </summary>
        [Inline]
        public long4 zyzx =>  long4(z, y, z, x);
        
        /// <summary>
        /// Returns long4.bgbr swizzling (equivalent to long4.zyzx).
        /// </summary>
        [Inline]
        public long4 bgbr =>  long4(z, y, z, x);
        
        /// <summary>
        /// Returns long4.zyzy swizzling.
        /// </summary>
        [Inline]
        public long4 zyzy =>  long4(z, y, z, y);
        
        /// <summary>
        /// Returns long4.bgbg swizzling (equivalent to long4.zyzy).
        /// </summary>
        [Inline]
        public long4 bgbg =>  long4(z, y, z, y);
        
        /// <summary>
        /// Returns long4.zyzz swizzling.
        /// </summary>
        [Inline]
        public long4 zyzz =>  long4(z, y, z, z);
        
        /// <summary>
        /// Returns long4.bgbb swizzling (equivalent to long4.zyzz).
        /// </summary>
        [Inline]
        public long4 bgbb =>  long4(z, y, z, z);
        
        /// <summary>
        /// Returns long4.zyzw swizzling.
        /// </summary>
        [Inline]
        public long4 zyzw =>  long4(z, y, z, w);
        
        /// <summary>
        /// Returns long4.bgba swizzling (equivalent to long4.zyzw).
        /// </summary>
        [Inline]
        public long4 bgba =>  long4(z, y, z, w);
        
        /// <summary>
        /// Returns long4.zyw swizzling.
        /// </summary>
        [Inline]
        public long3 zyw =>  long3(z, y, w);
        
        /// <summary>
        /// Returns long4.bga swizzling (equivalent to long4.zyw).
        /// </summary>
        [Inline]
        public long3 bga =>  long3(z, y, w);
        
        /// <summary>
        /// Returns long4.zywx swizzling.
        /// </summary>
        [Inline]
        public long4 zywx =>  long4(z, y, w, x);
        
        /// <summary>
        /// Returns long4.bgar swizzling (equivalent to long4.zywx).
        /// </summary>
        [Inline]
        public long4 bgar =>  long4(z, y, w, x);
        
        /// <summary>
        /// Returns long4.zywy swizzling.
        /// </summary>
        [Inline]
        public long4 zywy =>  long4(z, y, w, y);
        
        /// <summary>
        /// Returns long4.bgag swizzling (equivalent to long4.zywy).
        /// </summary>
        [Inline]
        public long4 bgag =>  long4(z, y, w, y);
        
        /// <summary>
        /// Returns long4.zywz swizzling.
        /// </summary>
        [Inline]
        public long4 zywz =>  long4(z, y, w, z);
        
        /// <summary>
        /// Returns long4.bgab swizzling (equivalent to long4.zywz).
        /// </summary>
        [Inline]
        public long4 bgab =>  long4(z, y, w, z);
        
        /// <summary>
        /// Returns long4.zyww swizzling.
        /// </summary>
        [Inline]
        public long4 zyww =>  long4(z, y, w, w);
        
        /// <summary>
        /// Returns long4.bgaa swizzling (equivalent to long4.zyww).
        /// </summary>
        [Inline]
        public long4 bgaa =>  long4(z, y, w, w);
        
        /// <summary>
        /// Returns long4.zz swizzling.
        /// </summary>
        [Inline]
        public long2 zz =>  long2(z, z);
        
        /// <summary>
        /// Returns long4.bb swizzling (equivalent to long4.zz).
        /// </summary>
        [Inline]
        public long2 bb =>  long2(z, z);
        
        /// <summary>
        /// Returns long4.zzx swizzling.
        /// </summary>
        [Inline]
        public long3 zzx =>  long3(z, z, x);
        
        /// <summary>
        /// Returns long4.bbr swizzling (equivalent to long4.zzx).
        /// </summary>
        [Inline]
        public long3 bbr =>  long3(z, z, x);
        
        /// <summary>
        /// Returns long4.zzxx swizzling.
        /// </summary>
        [Inline]
        public long4 zzxx =>  long4(z, z, x, x);
        
        /// <summary>
        /// Returns long4.bbrr swizzling (equivalent to long4.zzxx).
        /// </summary>
        [Inline]
        public long4 bbrr =>  long4(z, z, x, x);
        
        /// <summary>
        /// Returns long4.zzxy swizzling.
        /// </summary>
        [Inline]
        public long4 zzxy =>  long4(z, z, x, y);
        
        /// <summary>
        /// Returns long4.bbrg swizzling (equivalent to long4.zzxy).
        /// </summary>
        [Inline]
        public long4 bbrg =>  long4(z, z, x, y);
        
        /// <summary>
        /// Returns long4.zzxz swizzling.
        /// </summary>
        [Inline]
        public long4 zzxz =>  long4(z, z, x, z);
        
        /// <summary>
        /// Returns long4.bbrb swizzling (equivalent to long4.zzxz).
        /// </summary>
        [Inline]
        public long4 bbrb =>  long4(z, z, x, z);
        
        /// <summary>
        /// Returns long4.zzxw swizzling.
        /// </summary>
        [Inline]
        public long4 zzxw =>  long4(z, z, x, w);
        
        /// <summary>
        /// Returns long4.bbra swizzling (equivalent to long4.zzxw).
        /// </summary>
        [Inline]
        public long4 bbra =>  long4(z, z, x, w);
        
        /// <summary>
        /// Returns long4.zzy swizzling.
        /// </summary>
        [Inline]
        public long3 zzy =>  long3(z, z, y);
        
        /// <summary>
        /// Returns long4.bbg swizzling (equivalent to long4.zzy).
        /// </summary>
        [Inline]
        public long3 bbg =>  long3(z, z, y);
        
        /// <summary>
        /// Returns long4.zzyx swizzling.
        /// </summary>
        [Inline]
        public long4 zzyx =>  long4(z, z, y, x);
        
        /// <summary>
        /// Returns long4.bbgr swizzling (equivalent to long4.zzyx).
        /// </summary>
        [Inline]
        public long4 bbgr =>  long4(z, z, y, x);
        
        /// <summary>
        /// Returns long4.zzyy swizzling.
        /// </summary>
        [Inline]
        public long4 zzyy =>  long4(z, z, y, y);
        
        /// <summary>
        /// Returns long4.bbgg swizzling (equivalent to long4.zzyy).
        /// </summary>
        [Inline]
        public long4 bbgg =>  long4(z, z, y, y);
        
        /// <summary>
        /// Returns long4.zzyz swizzling.
        /// </summary>
        [Inline]
        public long4 zzyz =>  long4(z, z, y, z);
        
        /// <summary>
        /// Returns long4.bbgb swizzling (equivalent to long4.zzyz).
        /// </summary>
        [Inline]
        public long4 bbgb =>  long4(z, z, y, z);
        
        /// <summary>
        /// Returns long4.zzyw swizzling.
        /// </summary>
        [Inline]
        public long4 zzyw =>  long4(z, z, y, w);
        
        /// <summary>
        /// Returns long4.bbga swizzling (equivalent to long4.zzyw).
        /// </summary>
        [Inline]
        public long4 bbga =>  long4(z, z, y, w);
        
        /// <summary>
        /// Returns long4.zzz swizzling.
        /// </summary>
        [Inline]
        public long3 zzz =>  long3(z, z, z);
        
        /// <summary>
        /// Returns long4.bbb swizzling (equivalent to long4.zzz).
        /// </summary>
        [Inline]
        public long3 bbb =>  long3(z, z, z);
        
        /// <summary>
        /// Returns long4.zzzx swizzling.
        /// </summary>
        [Inline]
        public long4 zzzx =>  long4(z, z, z, x);
        
        /// <summary>
        /// Returns long4.bbbr swizzling (equivalent to long4.zzzx).
        /// </summary>
        [Inline]
        public long4 bbbr =>  long4(z, z, z, x);
        
        /// <summary>
        /// Returns long4.zzzy swizzling.
        /// </summary>
        [Inline]
        public long4 zzzy =>  long4(z, z, z, y);
        
        /// <summary>
        /// Returns long4.bbbg swizzling (equivalent to long4.zzzy).
        /// </summary>
        [Inline]
        public long4 bbbg =>  long4(z, z, z, y);
        
        /// <summary>
        /// Returns long4.zzzz swizzling.
        /// </summary>
        [Inline]
        public long4 zzzz =>  long4(z, z, z, z);
        
        /// <summary>
        /// Returns long4.bbbb swizzling (equivalent to long4.zzzz).
        /// </summary>
        [Inline]
        public long4 bbbb =>  long4(z, z, z, z);
        
        /// <summary>
        /// Returns long4.zzzw swizzling.
        /// </summary>
        [Inline]
        public long4 zzzw =>  long4(z, z, z, w);
        
        /// <summary>
        /// Returns long4.bbba swizzling (equivalent to long4.zzzw).
        /// </summary>
        [Inline]
        public long4 bbba =>  long4(z, z, z, w);
        
        /// <summary>
        /// Returns long4.zzw swizzling.
        /// </summary>
        [Inline]
        public long3 zzw =>  long3(z, z, w);
        
        /// <summary>
        /// Returns long4.bba swizzling (equivalent to long4.zzw).
        /// </summary>
        [Inline]
        public long3 bba =>  long3(z, z, w);
        
        /// <summary>
        /// Returns long4.zzwx swizzling.
        /// </summary>
        [Inline]
        public long4 zzwx =>  long4(z, z, w, x);
        
        /// <summary>
        /// Returns long4.bbar swizzling (equivalent to long4.zzwx).
        /// </summary>
        [Inline]
        public long4 bbar =>  long4(z, z, w, x);
        
        /// <summary>
        /// Returns long4.zzwy swizzling.
        /// </summary>
        [Inline]
        public long4 zzwy =>  long4(z, z, w, y);
        
        /// <summary>
        /// Returns long4.bbag swizzling (equivalent to long4.zzwy).
        /// </summary>
        [Inline]
        public long4 bbag =>  long4(z, z, w, y);
        
        /// <summary>
        /// Returns long4.zzwz swizzling.
        /// </summary>
        [Inline]
        public long4 zzwz =>  long4(z, z, w, z);
        
        /// <summary>
        /// Returns long4.bbab swizzling (equivalent to long4.zzwz).
        /// </summary>
        [Inline]
        public long4 bbab =>  long4(z, z, w, z);
        
        /// <summary>
        /// Returns long4.zzww swizzling.
        /// </summary>
        [Inline]
        public long4 zzww =>  long4(z, z, w, w);
        
        /// <summary>
        /// Returns long4.bbaa swizzling (equivalent to long4.zzww).
        /// </summary>
        [Inline]
        public long4 bbaa =>  long4(z, z, w, w);
        
        /// <summary>
        /// Returns long4.zw swizzling.
        /// </summary>
        [Inline]
        public long2 zw =>  long2(z, w);
        
        /// <summary>
        /// Returns long4.ba swizzling (equivalent to long4.zw).
        /// </summary>
        [Inline]
        public long2 ba =>  long2(z, w);
        
        /// <summary>
        /// Returns long4.zwx swizzling.
        /// </summary>
        [Inline]
        public long3 zwx =>  long3(z, w, x);
        
        /// <summary>
        /// Returns long4.bar swizzling (equivalent to long4.zwx).
        /// </summary>
        [Inline]
        public long3 bar =>  long3(z, w, x);
        
        /// <summary>
        /// Returns long4.zwxx swizzling.
        /// </summary>
        [Inline]
        public long4 zwxx =>  long4(z, w, x, x);
        
        /// <summary>
        /// Returns long4.barr swizzling (equivalent to long4.zwxx).
        /// </summary>
        [Inline]
        public long4 barr =>  long4(z, w, x, x);
        
        /// <summary>
        /// Returns long4.zwxy swizzling.
        /// </summary>
        [Inline]
        public long4 zwxy =>  long4(z, w, x, y);
        
        /// <summary>
        /// Returns long4.barg swizzling (equivalent to long4.zwxy).
        /// </summary>
        [Inline]
        public long4 barg =>  long4(z, w, x, y);
        
        /// <summary>
        /// Returns long4.zwxz swizzling.
        /// </summary>
        [Inline]
        public long4 zwxz =>  long4(z, w, x, z);
        
        /// <summary>
        /// Returns long4.barb swizzling (equivalent to long4.zwxz).
        /// </summary>
        [Inline]
        public long4 barb =>  long4(z, w, x, z);
        
        /// <summary>
        /// Returns long4.zwxw swizzling.
        /// </summary>
        [Inline]
        public long4 zwxw =>  long4(z, w, x, w);
        
        /// <summary>
        /// Returns long4.bara swizzling (equivalent to long4.zwxw).
        /// </summary>
        [Inline]
        public long4 bara =>  long4(z, w, x, w);
        
        /// <summary>
        /// Returns long4.zwy swizzling.
        /// </summary>
        [Inline]
        public long3 zwy =>  long3(z, w, y);
        
        /// <summary>
        /// Returns long4.bag swizzling (equivalent to long4.zwy).
        /// </summary>
        [Inline]
        public long3 bag =>  long3(z, w, y);
        
        /// <summary>
        /// Returns long4.zwyx swizzling.
        /// </summary>
        [Inline]
        public long4 zwyx =>  long4(z, w, y, x);
        
        /// <summary>
        /// Returns long4.bagr swizzling (equivalent to long4.zwyx).
        /// </summary>
        [Inline]
        public long4 bagr =>  long4(z, w, y, x);
        
        /// <summary>
        /// Returns long4.zwyy swizzling.
        /// </summary>
        [Inline]
        public long4 zwyy =>  long4(z, w, y, y);
        
        /// <summary>
        /// Returns long4.bagg swizzling (equivalent to long4.zwyy).
        /// </summary>
        [Inline]
        public long4 bagg =>  long4(z, w, y, y);
        
        /// <summary>
        /// Returns long4.zwyz swizzling.
        /// </summary>
        [Inline]
        public long4 zwyz =>  long4(z, w, y, z);
        
        /// <summary>
        /// Returns long4.bagb swizzling (equivalent to long4.zwyz).
        /// </summary>
        [Inline]
        public long4 bagb =>  long4(z, w, y, z);
        
        /// <summary>
        /// Returns long4.zwyw swizzling.
        /// </summary>
        [Inline]
        public long4 zwyw =>  long4(z, w, y, w);
        
        /// <summary>
        /// Returns long4.baga swizzling (equivalent to long4.zwyw).
        /// </summary>
        [Inline]
        public long4 baga =>  long4(z, w, y, w);
        
        /// <summary>
        /// Returns long4.zwz swizzling.
        /// </summary>
        [Inline]
        public long3 zwz =>  long3(z, w, z);
        
        /// <summary>
        /// Returns long4.bab swizzling (equivalent to long4.zwz).
        /// </summary>
        [Inline]
        public long3 bab =>  long3(z, w, z);
        
        /// <summary>
        /// Returns long4.zwzx swizzling.
        /// </summary>
        [Inline]
        public long4 zwzx =>  long4(z, w, z, x);
        
        /// <summary>
        /// Returns long4.babr swizzling (equivalent to long4.zwzx).
        /// </summary>
        [Inline]
        public long4 babr =>  long4(z, w, z, x);
        
        /// <summary>
        /// Returns long4.zwzy swizzling.
        /// </summary>
        [Inline]
        public long4 zwzy =>  long4(z, w, z, y);
        
        /// <summary>
        /// Returns long4.babg swizzling (equivalent to long4.zwzy).
        /// </summary>
        [Inline]
        public long4 babg =>  long4(z, w, z, y);
        
        /// <summary>
        /// Returns long4.zwzz swizzling.
        /// </summary>
        [Inline]
        public long4 zwzz =>  long4(z, w, z, z);
        
        /// <summary>
        /// Returns long4.babb swizzling (equivalent to long4.zwzz).
        /// </summary>
        [Inline]
        public long4 babb =>  long4(z, w, z, z);
        
        /// <summary>
        /// Returns long4.zwzw swizzling.
        /// </summary>
        [Inline]
        public long4 zwzw =>  long4(z, w, z, w);
        
        /// <summary>
        /// Returns long4.baba swizzling (equivalent to long4.zwzw).
        /// </summary>
        [Inline]
        public long4 baba =>  long4(z, w, z, w);
        
        /// <summary>
        /// Returns long4.zww swizzling.
        /// </summary>
        [Inline]
        public long3 zww =>  long3(z, w, w);
        
        /// <summary>
        /// Returns long4.baa swizzling (equivalent to long4.zww).
        /// </summary>
        [Inline]
        public long3 baa =>  long3(z, w, w);
        
        /// <summary>
        /// Returns long4.zwwx swizzling.
        /// </summary>
        [Inline]
        public long4 zwwx =>  long4(z, w, w, x);
        
        /// <summary>
        /// Returns long4.baar swizzling (equivalent to long4.zwwx).
        /// </summary>
        [Inline]
        public long4 baar =>  long4(z, w, w, x);
        
        /// <summary>
        /// Returns long4.zwwy swizzling.
        /// </summary>
        [Inline]
        public long4 zwwy =>  long4(z, w, w, y);
        
        /// <summary>
        /// Returns long4.baag swizzling (equivalent to long4.zwwy).
        /// </summary>
        [Inline]
        public long4 baag =>  long4(z, w, w, y);
        
        /// <summary>
        /// Returns long4.zwwz swizzling.
        /// </summary>
        [Inline]
        public long4 zwwz =>  long4(z, w, w, z);
        
        /// <summary>
        /// Returns long4.baab swizzling (equivalent to long4.zwwz).
        /// </summary>
        [Inline]
        public long4 baab =>  long4(z, w, w, z);
        
        /// <summary>
        /// Returns long4.zwww swizzling.
        /// </summary>
        [Inline]
        public long4 zwww =>  long4(z, w, w, w);
        
        /// <summary>
        /// Returns long4.baaa swizzling (equivalent to long4.zwww).
        /// </summary>
        [Inline]
        public long4 baaa =>  long4(z, w, w, w);
        
        /// <summary>
        /// Returns long4.wx swizzling.
        /// </summary>
        [Inline]
        public long2 wx =>  long2(w, x);
        
        /// <summary>
        /// Returns long4.ar swizzling (equivalent to long4.wx).
        /// </summary>
        [Inline]
        public long2 ar =>  long2(w, x);
        
        /// <summary>
        /// Returns long4.wxx swizzling.
        /// </summary>
        [Inline]
        public long3 wxx =>  long3(w, x, x);
        
        /// <summary>
        /// Returns long4.arr swizzling (equivalent to long4.wxx).
        /// </summary>
        [Inline]
        public long3 arr =>  long3(w, x, x);
        
        /// <summary>
        /// Returns long4.wxxx swizzling.
        /// </summary>
        [Inline]
        public long4 wxxx =>  long4(w, x, x, x);
        
        /// <summary>
        /// Returns long4.arrr swizzling (equivalent to long4.wxxx).
        /// </summary>
        [Inline]
        public long4 arrr =>  long4(w, x, x, x);
        
        /// <summary>
        /// Returns long4.wxxy swizzling.
        /// </summary>
        [Inline]
        public long4 wxxy =>  long4(w, x, x, y);
        
        /// <summary>
        /// Returns long4.arrg swizzling (equivalent to long4.wxxy).
        /// </summary>
        [Inline]
        public long4 arrg =>  long4(w, x, x, y);
        
        /// <summary>
        /// Returns long4.wxxz swizzling.
        /// </summary>
        [Inline]
        public long4 wxxz =>  long4(w, x, x, z);
        
        /// <summary>
        /// Returns long4.arrb swizzling (equivalent to long4.wxxz).
        /// </summary>
        [Inline]
        public long4 arrb =>  long4(w, x, x, z);
        
        /// <summary>
        /// Returns long4.wxxw swizzling.
        /// </summary>
        [Inline]
        public long4 wxxw =>  long4(w, x, x, w);
        
        /// <summary>
        /// Returns long4.arra swizzling (equivalent to long4.wxxw).
        /// </summary>
        [Inline]
        public long4 arra =>  long4(w, x, x, w);
        
        /// <summary>
        /// Returns long4.wxy swizzling.
        /// </summary>
        [Inline]
        public long3 wxy =>  long3(w, x, y);
        
        /// <summary>
        /// Returns long4.arg swizzling (equivalent to long4.wxy).
        /// </summary>
        [Inline]
        public long3 arg =>  long3(w, x, y);
        
        /// <summary>
        /// Returns long4.wxyx swizzling.
        /// </summary>
        [Inline]
        public long4 wxyx =>  long4(w, x, y, x);
        
        /// <summary>
        /// Returns long4.argr swizzling (equivalent to long4.wxyx).
        /// </summary>
        [Inline]
        public long4 argr =>  long4(w, x, y, x);
        
        /// <summary>
        /// Returns long4.wxyy swizzling.
        /// </summary>
        [Inline]
        public long4 wxyy =>  long4(w, x, y, y);
        
        /// <summary>
        /// Returns long4.argg swizzling (equivalent to long4.wxyy).
        /// </summary>
        [Inline]
        public long4 argg =>  long4(w, x, y, y);
        
        /// <summary>
        /// Returns long4.wxyz swizzling.
        /// </summary>
        [Inline]
        public long4 wxyz =>  long4(w, x, y, z);
        
        /// <summary>
        /// Returns long4.argb swizzling (equivalent to long4.wxyz).
        /// </summary>
        [Inline]
        public long4 argb =>  long4(w, x, y, z);
        
        /// <summary>
        /// Returns long4.wxyw swizzling.
        /// </summary>
        [Inline]
        public long4 wxyw =>  long4(w, x, y, w);
        
        /// <summary>
        /// Returns long4.arga swizzling (equivalent to long4.wxyw).
        /// </summary>
        [Inline]
        public long4 arga =>  long4(w, x, y, w);
        
        /// <summary>
        /// Returns long4.wxz swizzling.
        /// </summary>
        [Inline]
        public long3 wxz =>  long3(w, x, z);
        
        /// <summary>
        /// Returns long4.arb swizzling (equivalent to long4.wxz).
        /// </summary>
        [Inline]
        public long3 arb =>  long3(w, x, z);
        
        /// <summary>
        /// Returns long4.wxzx swizzling.
        /// </summary>
        [Inline]
        public long4 wxzx =>  long4(w, x, z, x);
        
        /// <summary>
        /// Returns long4.arbr swizzling (equivalent to long4.wxzx).
        /// </summary>
        [Inline]
        public long4 arbr =>  long4(w, x, z, x);
        
        /// <summary>
        /// Returns long4.wxzy swizzling.
        /// </summary>
        [Inline]
        public long4 wxzy =>  long4(w, x, z, y);
        
        /// <summary>
        /// Returns long4.arbg swizzling (equivalent to long4.wxzy).
        /// </summary>
        [Inline]
        public long4 arbg =>  long4(w, x, z, y);
        
        /// <summary>
        /// Returns long4.wxzz swizzling.
        /// </summary>
        [Inline]
        public long4 wxzz =>  long4(w, x, z, z);
        
        /// <summary>
        /// Returns long4.arbb swizzling (equivalent to long4.wxzz).
        /// </summary>
        [Inline]
        public long4 arbb =>  long4(w, x, z, z);
        
        /// <summary>
        /// Returns long4.wxzw swizzling.
        /// </summary>
        [Inline]
        public long4 wxzw =>  long4(w, x, z, w);
        
        /// <summary>
        /// Returns long4.arba swizzling (equivalent to long4.wxzw).
        /// </summary>
        [Inline]
        public long4 arba =>  long4(w, x, z, w);
        
        /// <summary>
        /// Returns long4.wxw swizzling.
        /// </summary>
        [Inline]
        public long3 wxw =>  long3(w, x, w);
        
        /// <summary>
        /// Returns long4.ara swizzling (equivalent to long4.wxw).
        /// </summary>
        [Inline]
        public long3 ara =>  long3(w, x, w);
        
        /// <summary>
        /// Returns long4.wxwx swizzling.
        /// </summary>
        [Inline]
        public long4 wxwx =>  long4(w, x, w, x);
        
        /// <summary>
        /// Returns long4.arar swizzling (equivalent to long4.wxwx).
        /// </summary>
        [Inline]
        public long4 arar =>  long4(w, x, w, x);
        
        /// <summary>
        /// Returns long4.wxwy swizzling.
        /// </summary>
        [Inline]
        public long4 wxwy =>  long4(w, x, w, y);
        
        /// <summary>
        /// Returns long4.arag swizzling (equivalent to long4.wxwy).
        /// </summary>
        [Inline]
        public long4 arag =>  long4(w, x, w, y);
        
        /// <summary>
        /// Returns long4.wxwz swizzling.
        /// </summary>
        [Inline]
        public long4 wxwz =>  long4(w, x, w, z);
        
        /// <summary>
        /// Returns long4.arab swizzling (equivalent to long4.wxwz).
        /// </summary>
        [Inline]
        public long4 arab =>  long4(w, x, w, z);
        
        /// <summary>
        /// Returns long4.wxww swizzling.
        /// </summary>
        [Inline]
        public long4 wxww =>  long4(w, x, w, w);
        
        /// <summary>
        /// Returns long4.araa swizzling (equivalent to long4.wxww).
        /// </summary>
        [Inline]
        public long4 araa =>  long4(w, x, w, w);
        
        /// <summary>
        /// Returns long4.wy swizzling.
        /// </summary>
        [Inline]
        public long2 wy =>  long2(w, y);
        
        /// <summary>
        /// Returns long4.ag swizzling (equivalent to long4.wy).
        /// </summary>
        [Inline]
        public long2 ag =>  long2(w, y);
        
        /// <summary>
        /// Returns long4.wyx swizzling.
        /// </summary>
        [Inline]
        public long3 wyx =>  long3(w, y, x);
        
        /// <summary>
        /// Returns long4.agr swizzling (equivalent to long4.wyx).
        /// </summary>
        [Inline]
        public long3 agr =>  long3(w, y, x);
        
        /// <summary>
        /// Returns long4.wyxx swizzling.
        /// </summary>
        [Inline]
        public long4 wyxx =>  long4(w, y, x, x);
        
        /// <summary>
        /// Returns long4.agrr swizzling (equivalent to long4.wyxx).
        /// </summary>
        [Inline]
        public long4 agrr =>  long4(w, y, x, x);
        
        /// <summary>
        /// Returns long4.wyxy swizzling.
        /// </summary>
        [Inline]
        public long4 wyxy =>  long4(w, y, x, y);
        
        /// <summary>
        /// Returns long4.agrg swizzling (equivalent to long4.wyxy).
        /// </summary>
        [Inline]
        public long4 agrg =>  long4(w, y, x, y);
        
        /// <summary>
        /// Returns long4.wyxz swizzling.
        /// </summary>
        [Inline]
        public long4 wyxz =>  long4(w, y, x, z);
        
        /// <summary>
        /// Returns long4.agrb swizzling (equivalent to long4.wyxz).
        /// </summary>
        [Inline]
        public long4 agrb =>  long4(w, y, x, z);
        
        /// <summary>
        /// Returns long4.wyxw swizzling.
        /// </summary>
        [Inline]
        public long4 wyxw =>  long4(w, y, x, w);
        
        /// <summary>
        /// Returns long4.agra swizzling (equivalent to long4.wyxw).
        /// </summary>
        [Inline]
        public long4 agra =>  long4(w, y, x, w);
        
        /// <summary>
        /// Returns long4.wyy swizzling.
        /// </summary>
        [Inline]
        public long3 wyy =>  long3(w, y, y);
        
        /// <summary>
        /// Returns long4.agg swizzling (equivalent to long4.wyy).
        /// </summary>
        [Inline]
        public long3 agg =>  long3(w, y, y);
        
        /// <summary>
        /// Returns long4.wyyx swizzling.
        /// </summary>
        [Inline]
        public long4 wyyx =>  long4(w, y, y, x);
        
        /// <summary>
        /// Returns long4.aggr swizzling (equivalent to long4.wyyx).
        /// </summary>
        [Inline]
        public long4 aggr =>  long4(w, y, y, x);
        
        /// <summary>
        /// Returns long4.wyyy swizzling.
        /// </summary>
        [Inline]
        public long4 wyyy =>  long4(w, y, y, y);
        
        /// <summary>
        /// Returns long4.aggg swizzling (equivalent to long4.wyyy).
        /// </summary>
        [Inline]
        public long4 aggg =>  long4(w, y, y, y);
        
        /// <summary>
        /// Returns long4.wyyz swizzling.
        /// </summary>
        [Inline]
        public long4 wyyz =>  long4(w, y, y, z);
        
        /// <summary>
        /// Returns long4.aggb swizzling (equivalent to long4.wyyz).
        /// </summary>
        [Inline]
        public long4 aggb =>  long4(w, y, y, z);
        
        /// <summary>
        /// Returns long4.wyyw swizzling.
        /// </summary>
        [Inline]
        public long4 wyyw =>  long4(w, y, y, w);
        
        /// <summary>
        /// Returns long4.agga swizzling (equivalent to long4.wyyw).
        /// </summary>
        [Inline]
        public long4 agga =>  long4(w, y, y, w);
        
        /// <summary>
        /// Returns long4.wyz swizzling.
        /// </summary>
        [Inline]
        public long3 wyz =>  long3(w, y, z);
        
        /// <summary>
        /// Returns long4.agb swizzling (equivalent to long4.wyz).
        /// </summary>
        [Inline]
        public long3 agb =>  long3(w, y, z);
        
        /// <summary>
        /// Returns long4.wyzx swizzling.
        /// </summary>
        [Inline]
        public long4 wyzx =>  long4(w, y, z, x);
        
        /// <summary>
        /// Returns long4.agbr swizzling (equivalent to long4.wyzx).
        /// </summary>
        [Inline]
        public long4 agbr =>  long4(w, y, z, x);
        
        /// <summary>
        /// Returns long4.wyzy swizzling.
        /// </summary>
        [Inline]
        public long4 wyzy =>  long4(w, y, z, y);
        
        /// <summary>
        /// Returns long4.agbg swizzling (equivalent to long4.wyzy).
        /// </summary>
        [Inline]
        public long4 agbg =>  long4(w, y, z, y);
        
        /// <summary>
        /// Returns long4.wyzz swizzling.
        /// </summary>
        [Inline]
        public long4 wyzz =>  long4(w, y, z, z);
        
        /// <summary>
        /// Returns long4.agbb swizzling (equivalent to long4.wyzz).
        /// </summary>
        [Inline]
        public long4 agbb =>  long4(w, y, z, z);
        
        /// <summary>
        /// Returns long4.wyzw swizzling.
        /// </summary>
        [Inline]
        public long4 wyzw =>  long4(w, y, z, w);
        
        /// <summary>
        /// Returns long4.agba swizzling (equivalent to long4.wyzw).
        /// </summary>
        [Inline]
        public long4 agba =>  long4(w, y, z, w);
        
        /// <summary>
        /// Returns long4.wyw swizzling.
        /// </summary>
        [Inline]
        public long3 wyw =>  long3(w, y, w);
        
        /// <summary>
        /// Returns long4.aga swizzling (equivalent to long4.wyw).
        /// </summary>
        [Inline]
        public long3 aga =>  long3(w, y, w);
        
        /// <summary>
        /// Returns long4.wywx swizzling.
        /// </summary>
        [Inline]
        public long4 wywx =>  long4(w, y, w, x);
        
        /// <summary>
        /// Returns long4.agar swizzling (equivalent to long4.wywx).
        /// </summary>
        [Inline]
        public long4 agar =>  long4(w, y, w, x);
        
        /// <summary>
        /// Returns long4.wywy swizzling.
        /// </summary>
        [Inline]
        public long4 wywy =>  long4(w, y, w, y);
        
        /// <summary>
        /// Returns long4.agag swizzling (equivalent to long4.wywy).
        /// </summary>
        [Inline]
        public long4 agag =>  long4(w, y, w, y);
        
        /// <summary>
        /// Returns long4.wywz swizzling.
        /// </summary>
        [Inline]
        public long4 wywz =>  long4(w, y, w, z);
        
        /// <summary>
        /// Returns long4.agab swizzling (equivalent to long4.wywz).
        /// </summary>
        [Inline]
        public long4 agab =>  long4(w, y, w, z);
        
        /// <summary>
        /// Returns long4.wyww swizzling.
        /// </summary>
        [Inline]
        public long4 wyww =>  long4(w, y, w, w);
        
        /// <summary>
        /// Returns long4.agaa swizzling (equivalent to long4.wyww).
        /// </summary>
        [Inline]
        public long4 agaa =>  long4(w, y, w, w);
        
        /// <summary>
        /// Returns long4.wz swizzling.
        /// </summary>
        [Inline]
        public long2 wz =>  long2(w, z);
        
        /// <summary>
        /// Returns long4.ab swizzling (equivalent to long4.wz).
        /// </summary>
        [Inline]
        public long2 ab =>  long2(w, z);
        
        /// <summary>
        /// Returns long4.wzx swizzling.
        /// </summary>
        [Inline]
        public long3 wzx =>  long3(w, z, x);
        
        /// <summary>
        /// Returns long4.abr swizzling (equivalent to long4.wzx).
        /// </summary>
        [Inline]
        public long3 abr =>  long3(w, z, x);
        
        /// <summary>
        /// Returns long4.wzxx swizzling.
        /// </summary>
        [Inline]
        public long4 wzxx =>  long4(w, z, x, x);
        
        /// <summary>
        /// Returns long4.abrr swizzling (equivalent to long4.wzxx).
        /// </summary>
        [Inline]
        public long4 abrr =>  long4(w, z, x, x);
        
        /// <summary>
        /// Returns long4.wzxy swizzling.
        /// </summary>
        [Inline]
        public long4 wzxy =>  long4(w, z, x, y);
        
        /// <summary>
        /// Returns long4.abrg swizzling (equivalent to long4.wzxy).
        /// </summary>
        [Inline]
        public long4 abrg =>  long4(w, z, x, y);
        
        /// <summary>
        /// Returns long4.wzxz swizzling.
        /// </summary>
        [Inline]
        public long4 wzxz =>  long4(w, z, x, z);
        
        /// <summary>
        /// Returns long4.abrb swizzling (equivalent to long4.wzxz).
        /// </summary>
        [Inline]
        public long4 abrb =>  long4(w, z, x, z);
        
        /// <summary>
        /// Returns long4.wzxw swizzling.
        /// </summary>
        [Inline]
        public long4 wzxw =>  long4(w, z, x, w);
        
        /// <summary>
        /// Returns long4.abra swizzling (equivalent to long4.wzxw).
        /// </summary>
        [Inline]
        public long4 abra =>  long4(w, z, x, w);
        
        /// <summary>
        /// Returns long4.wzy swizzling.
        /// </summary>
        [Inline]
        public long3 wzy =>  long3(w, z, y);
        
        /// <summary>
        /// Returns long4.abg swizzling (equivalent to long4.wzy).
        /// </summary>
        [Inline]
        public long3 abg =>  long3(w, z, y);
        
        /// <summary>
        /// Returns long4.wzyx swizzling.
        /// </summary>
        [Inline]
        public long4 wzyx =>  long4(w, z, y, x);
        
        /// <summary>
        /// Returns long4.abgr swizzling (equivalent to long4.wzyx).
        /// </summary>
        [Inline]
        public long4 abgr =>  long4(w, z, y, x);
        
        /// <summary>
        /// Returns long4.wzyy swizzling.
        /// </summary>
        [Inline]
        public long4 wzyy =>  long4(w, z, y, y);
        
        /// <summary>
        /// Returns long4.abgg swizzling (equivalent to long4.wzyy).
        /// </summary>
        [Inline]
        public long4 abgg =>  long4(w, z, y, y);
        
        /// <summary>
        /// Returns long4.wzyz swizzling.
        /// </summary>
        [Inline]
        public long4 wzyz =>  long4(w, z, y, z);
        
        /// <summary>
        /// Returns long4.abgb swizzling (equivalent to long4.wzyz).
        /// </summary>
        [Inline]
        public long4 abgb =>  long4(w, z, y, z);
        
        /// <summary>
        /// Returns long4.wzyw swizzling.
        /// </summary>
        [Inline]
        public long4 wzyw =>  long4(w, z, y, w);
        
        /// <summary>
        /// Returns long4.abga swizzling (equivalent to long4.wzyw).
        /// </summary>
        [Inline]
        public long4 abga =>  long4(w, z, y, w);
        
        /// <summary>
        /// Returns long4.wzz swizzling.
        /// </summary>
        [Inline]
        public long3 wzz =>  long3(w, z, z);
        
        /// <summary>
        /// Returns long4.abb swizzling (equivalent to long4.wzz).
        /// </summary>
        [Inline]
        public long3 abb =>  long3(w, z, z);
        
        /// <summary>
        /// Returns long4.wzzx swizzling.
        /// </summary>
        [Inline]
        public long4 wzzx =>  long4(w, z, z, x);
        
        /// <summary>
        /// Returns long4.abbr swizzling (equivalent to long4.wzzx).
        /// </summary>
        [Inline]
        public long4 abbr =>  long4(w, z, z, x);
        
        /// <summary>
        /// Returns long4.wzzy swizzling.
        /// </summary>
        [Inline]
        public long4 wzzy =>  long4(w, z, z, y);
        
        /// <summary>
        /// Returns long4.abbg swizzling (equivalent to long4.wzzy).
        /// </summary>
        [Inline]
        public long4 abbg =>  long4(w, z, z, y);
        
        /// <summary>
        /// Returns long4.wzzz swizzling.
        /// </summary>
        [Inline]
        public long4 wzzz =>  long4(w, z, z, z);
        
        /// <summary>
        /// Returns long4.abbb swizzling (equivalent to long4.wzzz).
        /// </summary>
        [Inline]
        public long4 abbb =>  long4(w, z, z, z);
        
        /// <summary>
        /// Returns long4.wzzw swizzling.
        /// </summary>
        [Inline]
        public long4 wzzw =>  long4(w, z, z, w);
        
        /// <summary>
        /// Returns long4.abba swizzling (equivalent to long4.wzzw).
        /// </summary>
        [Inline]
        public long4 abba =>  long4(w, z, z, w);
        
        /// <summary>
        /// Returns long4.wzw swizzling.
        /// </summary>
        [Inline]
        public long3 wzw =>  long3(w, z, w);
        
        /// <summary>
        /// Returns long4.aba swizzling (equivalent to long4.wzw).
        /// </summary>
        [Inline]
        public long3 aba =>  long3(w, z, w);
        
        /// <summary>
        /// Returns long4.wzwx swizzling.
        /// </summary>
        [Inline]
        public long4 wzwx =>  long4(w, z, w, x);
        
        /// <summary>
        /// Returns long4.abar swizzling (equivalent to long4.wzwx).
        /// </summary>
        [Inline]
        public long4 abar =>  long4(w, z, w, x);
        
        /// <summary>
        /// Returns long4.wzwy swizzling.
        /// </summary>
        [Inline]
        public long4 wzwy =>  long4(w, z, w, y);
        
        /// <summary>
        /// Returns long4.abag swizzling (equivalent to long4.wzwy).
        /// </summary>
        [Inline]
        public long4 abag =>  long4(w, z, w, y);
        
        /// <summary>
        /// Returns long4.wzwz swizzling.
        /// </summary>
        [Inline]
        public long4 wzwz =>  long4(w, z, w, z);
        
        /// <summary>
        /// Returns long4.abab swizzling (equivalent to long4.wzwz).
        /// </summary>
        [Inline]
        public long4 abab =>  long4(w, z, w, z);
        
        /// <summary>
        /// Returns long4.wzww swizzling.
        /// </summary>
        [Inline]
        public long4 wzww =>  long4(w, z, w, w);
        
        /// <summary>
        /// Returns long4.abaa swizzling (equivalent to long4.wzww).
        /// </summary>
        [Inline]
        public long4 abaa =>  long4(w, z, w, w);
        
        /// <summary>
        /// Returns long4.ww swizzling.
        /// </summary>
        [Inline]
        public long2 ww =>  long2(w, w);
        
        /// <summary>
        /// Returns long4.aa swizzling (equivalent to long4.ww).
        /// </summary>
        [Inline]
        public long2 aa =>  long2(w, w);
        
        /// <summary>
        /// Returns long4.wwx swizzling.
        /// </summary>
        [Inline]
        public long3 wwx =>  long3(w, w, x);
        
        /// <summary>
        /// Returns long4.aar swizzling (equivalent to long4.wwx).
        /// </summary>
        [Inline]
        public long3 aar =>  long3(w, w, x);
        
        /// <summary>
        /// Returns long4.wwxx swizzling.
        /// </summary>
        [Inline]
        public long4 wwxx =>  long4(w, w, x, x);
        
        /// <summary>
        /// Returns long4.aarr swizzling (equivalent to long4.wwxx).
        /// </summary>
        [Inline]
        public long4 aarr =>  long4(w, w, x, x);
        
        /// <summary>
        /// Returns long4.wwxy swizzling.
        /// </summary>
        [Inline]
        public long4 wwxy =>  long4(w, w, x, y);
        
        /// <summary>
        /// Returns long4.aarg swizzling (equivalent to long4.wwxy).
        /// </summary>
        [Inline]
        public long4 aarg =>  long4(w, w, x, y);
        
        /// <summary>
        /// Returns long4.wwxz swizzling.
        /// </summary>
        [Inline]
        public long4 wwxz =>  long4(w, w, x, z);
        
        /// <summary>
        /// Returns long4.aarb swizzling (equivalent to long4.wwxz).
        /// </summary>
        [Inline]
        public long4 aarb =>  long4(w, w, x, z);
        
        /// <summary>
        /// Returns long4.wwxw swizzling.
        /// </summary>
        [Inline]
        public long4 wwxw =>  long4(w, w, x, w);
        
        /// <summary>
        /// Returns long4.aara swizzling (equivalent to long4.wwxw).
        /// </summary>
        [Inline]
        public long4 aara =>  long4(w, w, x, w);
        
        /// <summary>
        /// Returns long4.wwy swizzling.
        /// </summary>
        [Inline]
        public long3 wwy =>  long3(w, w, y);
        
        /// <summary>
        /// Returns long4.aag swizzling (equivalent to long4.wwy).
        /// </summary>
        [Inline]
        public long3 aag =>  long3(w, w, y);
        
        /// <summary>
        /// Returns long4.wwyx swizzling.
        /// </summary>
        [Inline]
        public long4 wwyx =>  long4(w, w, y, x);
        
        /// <summary>
        /// Returns long4.aagr swizzling (equivalent to long4.wwyx).
        /// </summary>
        [Inline]
        public long4 aagr =>  long4(w, w, y, x);
        
        /// <summary>
        /// Returns long4.wwyy swizzling.
        /// </summary>
        [Inline]
        public long4 wwyy =>  long4(w, w, y, y);
        
        /// <summary>
        /// Returns long4.aagg swizzling (equivalent to long4.wwyy).
        /// </summary>
        [Inline]
        public long4 aagg =>  long4(w, w, y, y);
        
        /// <summary>
        /// Returns long4.wwyz swizzling.
        /// </summary>
        [Inline]
        public long4 wwyz =>  long4(w, w, y, z);
        
        /// <summary>
        /// Returns long4.aagb swizzling (equivalent to long4.wwyz).
        /// </summary>
        [Inline]
        public long4 aagb =>  long4(w, w, y, z);
        
        /// <summary>
        /// Returns long4.wwyw swizzling.
        /// </summary>
        [Inline]
        public long4 wwyw =>  long4(w, w, y, w);
        
        /// <summary>
        /// Returns long4.aaga swizzling (equivalent to long4.wwyw).
        /// </summary>
        [Inline]
        public long4 aaga =>  long4(w, w, y, w);
        
        /// <summary>
        /// Returns long4.wwz swizzling.
        /// </summary>
        [Inline]
        public long3 wwz =>  long3(w, w, z);
        
        /// <summary>
        /// Returns long4.aab swizzling (equivalent to long4.wwz).
        /// </summary>
        [Inline]
        public long3 aab =>  long3(w, w, z);
        
        /// <summary>
        /// Returns long4.wwzx swizzling.
        /// </summary>
        [Inline]
        public long4 wwzx =>  long4(w, w, z, x);
        
        /// <summary>
        /// Returns long4.aabr swizzling (equivalent to long4.wwzx).
        /// </summary>
        [Inline]
        public long4 aabr =>  long4(w, w, z, x);
        
        /// <summary>
        /// Returns long4.wwzy swizzling.
        /// </summary>
        [Inline]
        public long4 wwzy =>  long4(w, w, z, y);
        
        /// <summary>
        /// Returns long4.aabg swizzling (equivalent to long4.wwzy).
        /// </summary>
        [Inline]
        public long4 aabg =>  long4(w, w, z, y);
        
        /// <summary>
        /// Returns long4.wwzz swizzling.
        /// </summary>
        [Inline]
        public long4 wwzz =>  long4(w, w, z, z);
        
        /// <summary>
        /// Returns long4.aabb swizzling (equivalent to long4.wwzz).
        /// </summary>
        [Inline]
        public long4 aabb =>  long4(w, w, z, z);
        
        /// <summary>
        /// Returns long4.wwzw swizzling.
        /// </summary>
        [Inline]
        public long4 wwzw =>  long4(w, w, z, w);
        
        /// <summary>
        /// Returns long4.aaba swizzling (equivalent to long4.wwzw).
        /// </summary>
        [Inline]
        public long4 aaba =>  long4(w, w, z, w);
        
        /// <summary>
        /// Returns long4.www swizzling.
        /// </summary>
        [Inline]
        public long3 www =>  long3(w, w, w);
        
        /// <summary>
        /// Returns long4.aaa swizzling (equivalent to long4.www).
        /// </summary>
        [Inline]
        public long3 aaa =>  long3(w, w, w);
        
        /// <summary>
        /// Returns long4.wwwx swizzling.
        /// </summary>
        [Inline]
        public long4 wwwx =>  long4(w, w, w, x);
        
        /// <summary>
        /// Returns long4.aaar swizzling (equivalent to long4.wwwx).
        /// </summary>
        [Inline]
        public long4 aaar =>  long4(w, w, w, x);
        
        /// <summary>
        /// Returns long4.wwwy swizzling.
        /// </summary>
        [Inline]
        public long4 wwwy =>  long4(w, w, w, y);
        
        /// <summary>
        /// Returns long4.aaag swizzling (equivalent to long4.wwwy).
        /// </summary>
        [Inline]
        public long4 aaag =>  long4(w, w, w, y);
        
        /// <summary>
        /// Returns long4.wwwz swizzling.
        /// </summary>
        [Inline]
        public long4 wwwz =>  long4(w, w, w, z);
        
        /// <summary>
        /// Returns long4.aaab swizzling (equivalent to long4.wwwz).
        /// </summary>
        [Inline]
        public long4 aaab =>  long4(w, w, w, z);
        
        /// <summary>
        /// Returns long4.wwww swizzling.
        /// </summary>
        [Inline]
        public long4 wwww =>  long4(w, w, w, w);
        
        /// <summary>
        /// Returns long4.aaaa swizzling (equivalent to long4.wwww).
        /// </summary>
        [Inline]
        public long4 aaaa =>  long4(w, w, w, w);

        //#endregion

    }
}
