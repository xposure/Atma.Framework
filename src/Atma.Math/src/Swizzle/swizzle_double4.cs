using System;
namespace Atma
{
    
    /// <summary>
    /// Temporary vector of type double with 4 components, used for implementing swizzling for double4.
    /// </summary>
    public struct swizzle_double4
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
        
        /// <summary>
        /// w-component
        /// </summary>
        private readonly double w;

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Returns double4.xx swizzling.
        /// </summary>
        [Inline]
        public double2 xx =>  double2(x, x);
        
        /// <summary>
        /// Returns double4.rr swizzling (equivalent to double4.xx).
        /// </summary>
        [Inline]
        public double2 rr =>  double2(x, x);
        
        /// <summary>
        /// Returns double4.xxx swizzling.
        /// </summary>
        [Inline]
        public double3 xxx =>  double3(x, x, x);
        
        /// <summary>
        /// Returns double4.rrr swizzling (equivalent to double4.xxx).
        /// </summary>
        [Inline]
        public double3 rrr =>  double3(x, x, x);
        
        /// <summary>
        /// Returns double4.xxxx swizzling.
        /// </summary>
        [Inline]
        public double4 xxxx =>  double4(x, x, x, x);
        
        /// <summary>
        /// Returns double4.rrrr swizzling (equivalent to double4.xxxx).
        /// </summary>
        [Inline]
        public double4 rrrr =>  double4(x, x, x, x);
        
        /// <summary>
        /// Returns double4.xxxy swizzling.
        /// </summary>
        [Inline]
        public double4 xxxy =>  double4(x, x, x, y);
        
        /// <summary>
        /// Returns double4.rrrg swizzling (equivalent to double4.xxxy).
        /// </summary>
        [Inline]
        public double4 rrrg =>  double4(x, x, x, y);
        
        /// <summary>
        /// Returns double4.xxxz swizzling.
        /// </summary>
        [Inline]
        public double4 xxxz =>  double4(x, x, x, z);
        
        /// <summary>
        /// Returns double4.rrrb swizzling (equivalent to double4.xxxz).
        /// </summary>
        [Inline]
        public double4 rrrb =>  double4(x, x, x, z);
        
        /// <summary>
        /// Returns double4.xxxw swizzling.
        /// </summary>
        [Inline]
        public double4 xxxw =>  double4(x, x, x, w);
        
        /// <summary>
        /// Returns double4.rrra swizzling (equivalent to double4.xxxw).
        /// </summary>
        [Inline]
        public double4 rrra =>  double4(x, x, x, w);
        
        /// <summary>
        /// Returns double4.xxy swizzling.
        /// </summary>
        [Inline]
        public double3 xxy =>  double3(x, x, y);
        
        /// <summary>
        /// Returns double4.rrg swizzling (equivalent to double4.xxy).
        /// </summary>
        [Inline]
        public double3 rrg =>  double3(x, x, y);
        
        /// <summary>
        /// Returns double4.xxyx swizzling.
        /// </summary>
        [Inline]
        public double4 xxyx =>  double4(x, x, y, x);
        
        /// <summary>
        /// Returns double4.rrgr swizzling (equivalent to double4.xxyx).
        /// </summary>
        [Inline]
        public double4 rrgr =>  double4(x, x, y, x);
        
        /// <summary>
        /// Returns double4.xxyy swizzling.
        /// </summary>
        [Inline]
        public double4 xxyy =>  double4(x, x, y, y);
        
        /// <summary>
        /// Returns double4.rrgg swizzling (equivalent to double4.xxyy).
        /// </summary>
        [Inline]
        public double4 rrgg =>  double4(x, x, y, y);
        
        /// <summary>
        /// Returns double4.xxyz swizzling.
        /// </summary>
        [Inline]
        public double4 xxyz =>  double4(x, x, y, z);
        
        /// <summary>
        /// Returns double4.rrgb swizzling (equivalent to double4.xxyz).
        /// </summary>
        [Inline]
        public double4 rrgb =>  double4(x, x, y, z);
        
        /// <summary>
        /// Returns double4.xxyw swizzling.
        /// </summary>
        [Inline]
        public double4 xxyw =>  double4(x, x, y, w);
        
        /// <summary>
        /// Returns double4.rrga swizzling (equivalent to double4.xxyw).
        /// </summary>
        [Inline]
        public double4 rrga =>  double4(x, x, y, w);
        
        /// <summary>
        /// Returns double4.xxz swizzling.
        /// </summary>
        [Inline]
        public double3 xxz =>  double3(x, x, z);
        
        /// <summary>
        /// Returns double4.rrb swizzling (equivalent to double4.xxz).
        /// </summary>
        [Inline]
        public double3 rrb =>  double3(x, x, z);
        
        /// <summary>
        /// Returns double4.xxzx swizzling.
        /// </summary>
        [Inline]
        public double4 xxzx =>  double4(x, x, z, x);
        
        /// <summary>
        /// Returns double4.rrbr swizzling (equivalent to double4.xxzx).
        /// </summary>
        [Inline]
        public double4 rrbr =>  double4(x, x, z, x);
        
        /// <summary>
        /// Returns double4.xxzy swizzling.
        /// </summary>
        [Inline]
        public double4 xxzy =>  double4(x, x, z, y);
        
        /// <summary>
        /// Returns double4.rrbg swizzling (equivalent to double4.xxzy).
        /// </summary>
        [Inline]
        public double4 rrbg =>  double4(x, x, z, y);
        
        /// <summary>
        /// Returns double4.xxzz swizzling.
        /// </summary>
        [Inline]
        public double4 xxzz =>  double4(x, x, z, z);
        
        /// <summary>
        /// Returns double4.rrbb swizzling (equivalent to double4.xxzz).
        /// </summary>
        [Inline]
        public double4 rrbb =>  double4(x, x, z, z);
        
        /// <summary>
        /// Returns double4.xxzw swizzling.
        /// </summary>
        [Inline]
        public double4 xxzw =>  double4(x, x, z, w);
        
        /// <summary>
        /// Returns double4.rrba swizzling (equivalent to double4.xxzw).
        /// </summary>
        [Inline]
        public double4 rrba =>  double4(x, x, z, w);
        
        /// <summary>
        /// Returns double4.xxw swizzling.
        /// </summary>
        [Inline]
        public double3 xxw =>  double3(x, x, w);
        
        /// <summary>
        /// Returns double4.rra swizzling (equivalent to double4.xxw).
        /// </summary>
        [Inline]
        public double3 rra =>  double3(x, x, w);
        
        /// <summary>
        /// Returns double4.xxwx swizzling.
        /// </summary>
        [Inline]
        public double4 xxwx =>  double4(x, x, w, x);
        
        /// <summary>
        /// Returns double4.rrar swizzling (equivalent to double4.xxwx).
        /// </summary>
        [Inline]
        public double4 rrar =>  double4(x, x, w, x);
        
        /// <summary>
        /// Returns double4.xxwy swizzling.
        /// </summary>
        [Inline]
        public double4 xxwy =>  double4(x, x, w, y);
        
        /// <summary>
        /// Returns double4.rrag swizzling (equivalent to double4.xxwy).
        /// </summary>
        [Inline]
        public double4 rrag =>  double4(x, x, w, y);
        
        /// <summary>
        /// Returns double4.xxwz swizzling.
        /// </summary>
        [Inline]
        public double4 xxwz =>  double4(x, x, w, z);
        
        /// <summary>
        /// Returns double4.rrab swizzling (equivalent to double4.xxwz).
        /// </summary>
        [Inline]
        public double4 rrab =>  double4(x, x, w, z);
        
        /// <summary>
        /// Returns double4.xxww swizzling.
        /// </summary>
        [Inline]
        public double4 xxww =>  double4(x, x, w, w);
        
        /// <summary>
        /// Returns double4.rraa swizzling (equivalent to double4.xxww).
        /// </summary>
        [Inline]
        public double4 rraa =>  double4(x, x, w, w);
        
        /// <summary>
        /// Returns double4.xy swizzling.
        /// </summary>
        [Inline]
        public double2 xy =>  double2(x, y);
        
        /// <summary>
        /// Returns double4.rg swizzling (equivalent to double4.xy).
        /// </summary>
        [Inline]
        public double2 rg =>  double2(x, y);
        
        /// <summary>
        /// Returns double4.xyx swizzling.
        /// </summary>
        [Inline]
        public double3 xyx =>  double3(x, y, x);
        
        /// <summary>
        /// Returns double4.rgr swizzling (equivalent to double4.xyx).
        /// </summary>
        [Inline]
        public double3 rgr =>  double3(x, y, x);
        
        /// <summary>
        /// Returns double4.xyxx swizzling.
        /// </summary>
        [Inline]
        public double4 xyxx =>  double4(x, y, x, x);
        
        /// <summary>
        /// Returns double4.rgrr swizzling (equivalent to double4.xyxx).
        /// </summary>
        [Inline]
        public double4 rgrr =>  double4(x, y, x, x);
        
        /// <summary>
        /// Returns double4.xyxy swizzling.
        /// </summary>
        [Inline]
        public double4 xyxy =>  double4(x, y, x, y);
        
        /// <summary>
        /// Returns double4.rgrg swizzling (equivalent to double4.xyxy).
        /// </summary>
        [Inline]
        public double4 rgrg =>  double4(x, y, x, y);
        
        /// <summary>
        /// Returns double4.xyxz swizzling.
        /// </summary>
        [Inline]
        public double4 xyxz =>  double4(x, y, x, z);
        
        /// <summary>
        /// Returns double4.rgrb swizzling (equivalent to double4.xyxz).
        /// </summary>
        [Inline]
        public double4 rgrb =>  double4(x, y, x, z);
        
        /// <summary>
        /// Returns double4.xyxw swizzling.
        /// </summary>
        [Inline]
        public double4 xyxw =>  double4(x, y, x, w);
        
        /// <summary>
        /// Returns double4.rgra swizzling (equivalent to double4.xyxw).
        /// </summary>
        [Inline]
        public double4 rgra =>  double4(x, y, x, w);
        
        /// <summary>
        /// Returns double4.xyy swizzling.
        /// </summary>
        [Inline]
        public double3 xyy =>  double3(x, y, y);
        
        /// <summary>
        /// Returns double4.rgg swizzling (equivalent to double4.xyy).
        /// </summary>
        [Inline]
        public double3 rgg =>  double3(x, y, y);
        
        /// <summary>
        /// Returns double4.xyyx swizzling.
        /// </summary>
        [Inline]
        public double4 xyyx =>  double4(x, y, y, x);
        
        /// <summary>
        /// Returns double4.rggr swizzling (equivalent to double4.xyyx).
        /// </summary>
        [Inline]
        public double4 rggr =>  double4(x, y, y, x);
        
        /// <summary>
        /// Returns double4.xyyy swizzling.
        /// </summary>
        [Inline]
        public double4 xyyy =>  double4(x, y, y, y);
        
        /// <summary>
        /// Returns double4.rggg swizzling (equivalent to double4.xyyy).
        /// </summary>
        [Inline]
        public double4 rggg =>  double4(x, y, y, y);
        
        /// <summary>
        /// Returns double4.xyyz swizzling.
        /// </summary>
        [Inline]
        public double4 xyyz =>  double4(x, y, y, z);
        
        /// <summary>
        /// Returns double4.rggb swizzling (equivalent to double4.xyyz).
        /// </summary>
        [Inline]
        public double4 rggb =>  double4(x, y, y, z);
        
        /// <summary>
        /// Returns double4.xyyw swizzling.
        /// </summary>
        [Inline]
        public double4 xyyw =>  double4(x, y, y, w);
        
        /// <summary>
        /// Returns double4.rgga swizzling (equivalent to double4.xyyw).
        /// </summary>
        [Inline]
        public double4 rgga =>  double4(x, y, y, w);
        
        /// <summary>
        /// Returns double4.xyz swizzling.
        /// </summary>
        [Inline]
        public double3 xyz =>  double3(x, y, z);
        
        /// <summary>
        /// Returns double4.rgb swizzling (equivalent to double4.xyz).
        /// </summary>
        [Inline]
        public double3 rgb =>  double3(x, y, z);
        
        /// <summary>
        /// Returns double4.xyzx swizzling.
        /// </summary>
        [Inline]
        public double4 xyzx =>  double4(x, y, z, x);
        
        /// <summary>
        /// Returns double4.rgbr swizzling (equivalent to double4.xyzx).
        /// </summary>
        [Inline]
        public double4 rgbr =>  double4(x, y, z, x);
        
        /// <summary>
        /// Returns double4.xyzy swizzling.
        /// </summary>
        [Inline]
        public double4 xyzy =>  double4(x, y, z, y);
        
        /// <summary>
        /// Returns double4.rgbg swizzling (equivalent to double4.xyzy).
        /// </summary>
        [Inline]
        public double4 rgbg =>  double4(x, y, z, y);
        
        /// <summary>
        /// Returns double4.xyzz swizzling.
        /// </summary>
        [Inline]
        public double4 xyzz =>  double4(x, y, z, z);
        
        /// <summary>
        /// Returns double4.rgbb swizzling (equivalent to double4.xyzz).
        /// </summary>
        [Inline]
        public double4 rgbb =>  double4(x, y, z, z);
        
        /// <summary>
        /// Returns double4.xyzw swizzling.
        /// </summary>
        [Inline]
        public double4 xyzw =>  double4(x, y, z, w);
        
        /// <summary>
        /// Returns double4.rgba swizzling (equivalent to double4.xyzw).
        /// </summary>
        [Inline]
        public double4 rgba =>  double4(x, y, z, w);
        
        /// <summary>
        /// Returns double4.xyw swizzling.
        /// </summary>
        [Inline]
        public double3 xyw =>  double3(x, y, w);
        
        /// <summary>
        /// Returns double4.rga swizzling (equivalent to double4.xyw).
        /// </summary>
        [Inline]
        public double3 rga =>  double3(x, y, w);
        
        /// <summary>
        /// Returns double4.xywx swizzling.
        /// </summary>
        [Inline]
        public double4 xywx =>  double4(x, y, w, x);
        
        /// <summary>
        /// Returns double4.rgar swizzling (equivalent to double4.xywx).
        /// </summary>
        [Inline]
        public double4 rgar =>  double4(x, y, w, x);
        
        /// <summary>
        /// Returns double4.xywy swizzling.
        /// </summary>
        [Inline]
        public double4 xywy =>  double4(x, y, w, y);
        
        /// <summary>
        /// Returns double4.rgag swizzling (equivalent to double4.xywy).
        /// </summary>
        [Inline]
        public double4 rgag =>  double4(x, y, w, y);
        
        /// <summary>
        /// Returns double4.xywz swizzling.
        /// </summary>
        [Inline]
        public double4 xywz =>  double4(x, y, w, z);
        
        /// <summary>
        /// Returns double4.rgab swizzling (equivalent to double4.xywz).
        /// </summary>
        [Inline]
        public double4 rgab =>  double4(x, y, w, z);
        
        /// <summary>
        /// Returns double4.xyww swizzling.
        /// </summary>
        [Inline]
        public double4 xyww =>  double4(x, y, w, w);
        
        /// <summary>
        /// Returns double4.rgaa swizzling (equivalent to double4.xyww).
        /// </summary>
        [Inline]
        public double4 rgaa =>  double4(x, y, w, w);
        
        /// <summary>
        /// Returns double4.xz swizzling.
        /// </summary>
        [Inline]
        public double2 xz =>  double2(x, z);
        
        /// <summary>
        /// Returns double4.rb swizzling (equivalent to double4.xz).
        /// </summary>
        [Inline]
        public double2 rb =>  double2(x, z);
        
        /// <summary>
        /// Returns double4.xzx swizzling.
        /// </summary>
        [Inline]
        public double3 xzx =>  double3(x, z, x);
        
        /// <summary>
        /// Returns double4.rbr swizzling (equivalent to double4.xzx).
        /// </summary>
        [Inline]
        public double3 rbr =>  double3(x, z, x);
        
        /// <summary>
        /// Returns double4.xzxx swizzling.
        /// </summary>
        [Inline]
        public double4 xzxx =>  double4(x, z, x, x);
        
        /// <summary>
        /// Returns double4.rbrr swizzling (equivalent to double4.xzxx).
        /// </summary>
        [Inline]
        public double4 rbrr =>  double4(x, z, x, x);
        
        /// <summary>
        /// Returns double4.xzxy swizzling.
        /// </summary>
        [Inline]
        public double4 xzxy =>  double4(x, z, x, y);
        
        /// <summary>
        /// Returns double4.rbrg swizzling (equivalent to double4.xzxy).
        /// </summary>
        [Inline]
        public double4 rbrg =>  double4(x, z, x, y);
        
        /// <summary>
        /// Returns double4.xzxz swizzling.
        /// </summary>
        [Inline]
        public double4 xzxz =>  double4(x, z, x, z);
        
        /// <summary>
        /// Returns double4.rbrb swizzling (equivalent to double4.xzxz).
        /// </summary>
        [Inline]
        public double4 rbrb =>  double4(x, z, x, z);
        
        /// <summary>
        /// Returns double4.xzxw swizzling.
        /// </summary>
        [Inline]
        public double4 xzxw =>  double4(x, z, x, w);
        
        /// <summary>
        /// Returns double4.rbra swizzling (equivalent to double4.xzxw).
        /// </summary>
        [Inline]
        public double4 rbra =>  double4(x, z, x, w);
        
        /// <summary>
        /// Returns double4.xzy swizzling.
        /// </summary>
        [Inline]
        public double3 xzy =>  double3(x, z, y);
        
        /// <summary>
        /// Returns double4.rbg swizzling (equivalent to double4.xzy).
        /// </summary>
        [Inline]
        public double3 rbg =>  double3(x, z, y);
        
        /// <summary>
        /// Returns double4.xzyx swizzling.
        /// </summary>
        [Inline]
        public double4 xzyx =>  double4(x, z, y, x);
        
        /// <summary>
        /// Returns double4.rbgr swizzling (equivalent to double4.xzyx).
        /// </summary>
        [Inline]
        public double4 rbgr =>  double4(x, z, y, x);
        
        /// <summary>
        /// Returns double4.xzyy swizzling.
        /// </summary>
        [Inline]
        public double4 xzyy =>  double4(x, z, y, y);
        
        /// <summary>
        /// Returns double4.rbgg swizzling (equivalent to double4.xzyy).
        /// </summary>
        [Inline]
        public double4 rbgg =>  double4(x, z, y, y);
        
        /// <summary>
        /// Returns double4.xzyz swizzling.
        /// </summary>
        [Inline]
        public double4 xzyz =>  double4(x, z, y, z);
        
        /// <summary>
        /// Returns double4.rbgb swizzling (equivalent to double4.xzyz).
        /// </summary>
        [Inline]
        public double4 rbgb =>  double4(x, z, y, z);
        
        /// <summary>
        /// Returns double4.xzyw swizzling.
        /// </summary>
        [Inline]
        public double4 xzyw =>  double4(x, z, y, w);
        
        /// <summary>
        /// Returns double4.rbga swizzling (equivalent to double4.xzyw).
        /// </summary>
        [Inline]
        public double4 rbga =>  double4(x, z, y, w);
        
        /// <summary>
        /// Returns double4.xzz swizzling.
        /// </summary>
        [Inline]
        public double3 xzz =>  double3(x, z, z);
        
        /// <summary>
        /// Returns double4.rbb swizzling (equivalent to double4.xzz).
        /// </summary>
        [Inline]
        public double3 rbb =>  double3(x, z, z);
        
        /// <summary>
        /// Returns double4.xzzx swizzling.
        /// </summary>
        [Inline]
        public double4 xzzx =>  double4(x, z, z, x);
        
        /// <summary>
        /// Returns double4.rbbr swizzling (equivalent to double4.xzzx).
        /// </summary>
        [Inline]
        public double4 rbbr =>  double4(x, z, z, x);
        
        /// <summary>
        /// Returns double4.xzzy swizzling.
        /// </summary>
        [Inline]
        public double4 xzzy =>  double4(x, z, z, y);
        
        /// <summary>
        /// Returns double4.rbbg swizzling (equivalent to double4.xzzy).
        /// </summary>
        [Inline]
        public double4 rbbg =>  double4(x, z, z, y);
        
        /// <summary>
        /// Returns double4.xzzz swizzling.
        /// </summary>
        [Inline]
        public double4 xzzz =>  double4(x, z, z, z);
        
        /// <summary>
        /// Returns double4.rbbb swizzling (equivalent to double4.xzzz).
        /// </summary>
        [Inline]
        public double4 rbbb =>  double4(x, z, z, z);
        
        /// <summary>
        /// Returns double4.xzzw swizzling.
        /// </summary>
        [Inline]
        public double4 xzzw =>  double4(x, z, z, w);
        
        /// <summary>
        /// Returns double4.rbba swizzling (equivalent to double4.xzzw).
        /// </summary>
        [Inline]
        public double4 rbba =>  double4(x, z, z, w);
        
        /// <summary>
        /// Returns double4.xzw swizzling.
        /// </summary>
        [Inline]
        public double3 xzw =>  double3(x, z, w);
        
        /// <summary>
        /// Returns double4.rba swizzling (equivalent to double4.xzw).
        /// </summary>
        [Inline]
        public double3 rba =>  double3(x, z, w);
        
        /// <summary>
        /// Returns double4.xzwx swizzling.
        /// </summary>
        [Inline]
        public double4 xzwx =>  double4(x, z, w, x);
        
        /// <summary>
        /// Returns double4.rbar swizzling (equivalent to double4.xzwx).
        /// </summary>
        [Inline]
        public double4 rbar =>  double4(x, z, w, x);
        
        /// <summary>
        /// Returns double4.xzwy swizzling.
        /// </summary>
        [Inline]
        public double4 xzwy =>  double4(x, z, w, y);
        
        /// <summary>
        /// Returns double4.rbag swizzling (equivalent to double4.xzwy).
        /// </summary>
        [Inline]
        public double4 rbag =>  double4(x, z, w, y);
        
        /// <summary>
        /// Returns double4.xzwz swizzling.
        /// </summary>
        [Inline]
        public double4 xzwz =>  double4(x, z, w, z);
        
        /// <summary>
        /// Returns double4.rbab swizzling (equivalent to double4.xzwz).
        /// </summary>
        [Inline]
        public double4 rbab =>  double4(x, z, w, z);
        
        /// <summary>
        /// Returns double4.xzww swizzling.
        /// </summary>
        [Inline]
        public double4 xzww =>  double4(x, z, w, w);
        
        /// <summary>
        /// Returns double4.rbaa swizzling (equivalent to double4.xzww).
        /// </summary>
        [Inline]
        public double4 rbaa =>  double4(x, z, w, w);
        
        /// <summary>
        /// Returns double4.xw swizzling.
        /// </summary>
        [Inline]
        public double2 xw =>  double2(x, w);
        
        /// <summary>
        /// Returns double4.ra swizzling (equivalent to double4.xw).
        /// </summary>
        [Inline]
        public double2 ra =>  double2(x, w);
        
        /// <summary>
        /// Returns double4.xwx swizzling.
        /// </summary>
        [Inline]
        public double3 xwx =>  double3(x, w, x);
        
        /// <summary>
        /// Returns double4.rar swizzling (equivalent to double4.xwx).
        /// </summary>
        [Inline]
        public double3 rar =>  double3(x, w, x);
        
        /// <summary>
        /// Returns double4.xwxx swizzling.
        /// </summary>
        [Inline]
        public double4 xwxx =>  double4(x, w, x, x);
        
        /// <summary>
        /// Returns double4.rarr swizzling (equivalent to double4.xwxx).
        /// </summary>
        [Inline]
        public double4 rarr =>  double4(x, w, x, x);
        
        /// <summary>
        /// Returns double4.xwxy swizzling.
        /// </summary>
        [Inline]
        public double4 xwxy =>  double4(x, w, x, y);
        
        /// <summary>
        /// Returns double4.rarg swizzling (equivalent to double4.xwxy).
        /// </summary>
        [Inline]
        public double4 rarg =>  double4(x, w, x, y);
        
        /// <summary>
        /// Returns double4.xwxz swizzling.
        /// </summary>
        [Inline]
        public double4 xwxz =>  double4(x, w, x, z);
        
        /// <summary>
        /// Returns double4.rarb swizzling (equivalent to double4.xwxz).
        /// </summary>
        [Inline]
        public double4 rarb =>  double4(x, w, x, z);
        
        /// <summary>
        /// Returns double4.xwxw swizzling.
        /// </summary>
        [Inline]
        public double4 xwxw =>  double4(x, w, x, w);
        
        /// <summary>
        /// Returns double4.rara swizzling (equivalent to double4.xwxw).
        /// </summary>
        [Inline]
        public double4 rara =>  double4(x, w, x, w);
        
        /// <summary>
        /// Returns double4.xwy swizzling.
        /// </summary>
        [Inline]
        public double3 xwy =>  double3(x, w, y);
        
        /// <summary>
        /// Returns double4.rag swizzling (equivalent to double4.xwy).
        /// </summary>
        [Inline]
        public double3 rag =>  double3(x, w, y);
        
        /// <summary>
        /// Returns double4.xwyx swizzling.
        /// </summary>
        [Inline]
        public double4 xwyx =>  double4(x, w, y, x);
        
        /// <summary>
        /// Returns double4.ragr swizzling (equivalent to double4.xwyx).
        /// </summary>
        [Inline]
        public double4 ragr =>  double4(x, w, y, x);
        
        /// <summary>
        /// Returns double4.xwyy swizzling.
        /// </summary>
        [Inline]
        public double4 xwyy =>  double4(x, w, y, y);
        
        /// <summary>
        /// Returns double4.ragg swizzling (equivalent to double4.xwyy).
        /// </summary>
        [Inline]
        public double4 ragg =>  double4(x, w, y, y);
        
        /// <summary>
        /// Returns double4.xwyz swizzling.
        /// </summary>
        [Inline]
        public double4 xwyz =>  double4(x, w, y, z);
        
        /// <summary>
        /// Returns double4.ragb swizzling (equivalent to double4.xwyz).
        /// </summary>
        [Inline]
        public double4 ragb =>  double4(x, w, y, z);
        
        /// <summary>
        /// Returns double4.xwyw swizzling.
        /// </summary>
        [Inline]
        public double4 xwyw =>  double4(x, w, y, w);
        
        /// <summary>
        /// Returns double4.raga swizzling (equivalent to double4.xwyw).
        /// </summary>
        [Inline]
        public double4 raga =>  double4(x, w, y, w);
        
        /// <summary>
        /// Returns double4.xwz swizzling.
        /// </summary>
        [Inline]
        public double3 xwz =>  double3(x, w, z);
        
        /// <summary>
        /// Returns double4.rab swizzling (equivalent to double4.xwz).
        /// </summary>
        [Inline]
        public double3 rab =>  double3(x, w, z);
        
        /// <summary>
        /// Returns double4.xwzx swizzling.
        /// </summary>
        [Inline]
        public double4 xwzx =>  double4(x, w, z, x);
        
        /// <summary>
        /// Returns double4.rabr swizzling (equivalent to double4.xwzx).
        /// </summary>
        [Inline]
        public double4 rabr =>  double4(x, w, z, x);
        
        /// <summary>
        /// Returns double4.xwzy swizzling.
        /// </summary>
        [Inline]
        public double4 xwzy =>  double4(x, w, z, y);
        
        /// <summary>
        /// Returns double4.rabg swizzling (equivalent to double4.xwzy).
        /// </summary>
        [Inline]
        public double4 rabg =>  double4(x, w, z, y);
        
        /// <summary>
        /// Returns double4.xwzz swizzling.
        /// </summary>
        [Inline]
        public double4 xwzz =>  double4(x, w, z, z);
        
        /// <summary>
        /// Returns double4.rabb swizzling (equivalent to double4.xwzz).
        /// </summary>
        [Inline]
        public double4 rabb =>  double4(x, w, z, z);
        
        /// <summary>
        /// Returns double4.xwzw swizzling.
        /// </summary>
        [Inline]
        public double4 xwzw =>  double4(x, w, z, w);
        
        /// <summary>
        /// Returns double4.raba swizzling (equivalent to double4.xwzw).
        /// </summary>
        [Inline]
        public double4 raba =>  double4(x, w, z, w);
        
        /// <summary>
        /// Returns double4.xww swizzling.
        /// </summary>
        [Inline]
        public double3 xww =>  double3(x, w, w);
        
        /// <summary>
        /// Returns double4.raa swizzling (equivalent to double4.xww).
        /// </summary>
        [Inline]
        public double3 raa =>  double3(x, w, w);
        
        /// <summary>
        /// Returns double4.xwwx swizzling.
        /// </summary>
        [Inline]
        public double4 xwwx =>  double4(x, w, w, x);
        
        /// <summary>
        /// Returns double4.raar swizzling (equivalent to double4.xwwx).
        /// </summary>
        [Inline]
        public double4 raar =>  double4(x, w, w, x);
        
        /// <summary>
        /// Returns double4.xwwy swizzling.
        /// </summary>
        [Inline]
        public double4 xwwy =>  double4(x, w, w, y);
        
        /// <summary>
        /// Returns double4.raag swizzling (equivalent to double4.xwwy).
        /// </summary>
        [Inline]
        public double4 raag =>  double4(x, w, w, y);
        
        /// <summary>
        /// Returns double4.xwwz swizzling.
        /// </summary>
        [Inline]
        public double4 xwwz =>  double4(x, w, w, z);
        
        /// <summary>
        /// Returns double4.raab swizzling (equivalent to double4.xwwz).
        /// </summary>
        [Inline]
        public double4 raab =>  double4(x, w, w, z);
        
        /// <summary>
        /// Returns double4.xwww swizzling.
        /// </summary>
        [Inline]
        public double4 xwww =>  double4(x, w, w, w);
        
        /// <summary>
        /// Returns double4.raaa swizzling (equivalent to double4.xwww).
        /// </summary>
        [Inline]
        public double4 raaa =>  double4(x, w, w, w);
        
        /// <summary>
        /// Returns double4.yx swizzling.
        /// </summary>
        [Inline]
        public double2 yx =>  double2(y, x);
        
        /// <summary>
        /// Returns double4.gr swizzling (equivalent to double4.yx).
        /// </summary>
        [Inline]
        public double2 gr =>  double2(y, x);
        
        /// <summary>
        /// Returns double4.yxx swizzling.
        /// </summary>
        [Inline]
        public double3 yxx =>  double3(y, x, x);
        
        /// <summary>
        /// Returns double4.grr swizzling (equivalent to double4.yxx).
        /// </summary>
        [Inline]
        public double3 grr =>  double3(y, x, x);
        
        /// <summary>
        /// Returns double4.yxxx swizzling.
        /// </summary>
        [Inline]
        public double4 yxxx =>  double4(y, x, x, x);
        
        /// <summary>
        /// Returns double4.grrr swizzling (equivalent to double4.yxxx).
        /// </summary>
        [Inline]
        public double4 grrr =>  double4(y, x, x, x);
        
        /// <summary>
        /// Returns double4.yxxy swizzling.
        /// </summary>
        [Inline]
        public double4 yxxy =>  double4(y, x, x, y);
        
        /// <summary>
        /// Returns double4.grrg swizzling (equivalent to double4.yxxy).
        /// </summary>
        [Inline]
        public double4 grrg =>  double4(y, x, x, y);
        
        /// <summary>
        /// Returns double4.yxxz swizzling.
        /// </summary>
        [Inline]
        public double4 yxxz =>  double4(y, x, x, z);
        
        /// <summary>
        /// Returns double4.grrb swizzling (equivalent to double4.yxxz).
        /// </summary>
        [Inline]
        public double4 grrb =>  double4(y, x, x, z);
        
        /// <summary>
        /// Returns double4.yxxw swizzling.
        /// </summary>
        [Inline]
        public double4 yxxw =>  double4(y, x, x, w);
        
        /// <summary>
        /// Returns double4.grra swizzling (equivalent to double4.yxxw).
        /// </summary>
        [Inline]
        public double4 grra =>  double4(y, x, x, w);
        
        /// <summary>
        /// Returns double4.yxy swizzling.
        /// </summary>
        [Inline]
        public double3 yxy =>  double3(y, x, y);
        
        /// <summary>
        /// Returns double4.grg swizzling (equivalent to double4.yxy).
        /// </summary>
        [Inline]
        public double3 grg =>  double3(y, x, y);
        
        /// <summary>
        /// Returns double4.yxyx swizzling.
        /// </summary>
        [Inline]
        public double4 yxyx =>  double4(y, x, y, x);
        
        /// <summary>
        /// Returns double4.grgr swizzling (equivalent to double4.yxyx).
        /// </summary>
        [Inline]
        public double4 grgr =>  double4(y, x, y, x);
        
        /// <summary>
        /// Returns double4.yxyy swizzling.
        /// </summary>
        [Inline]
        public double4 yxyy =>  double4(y, x, y, y);
        
        /// <summary>
        /// Returns double4.grgg swizzling (equivalent to double4.yxyy).
        /// </summary>
        [Inline]
        public double4 grgg =>  double4(y, x, y, y);
        
        /// <summary>
        /// Returns double4.yxyz swizzling.
        /// </summary>
        [Inline]
        public double4 yxyz =>  double4(y, x, y, z);
        
        /// <summary>
        /// Returns double4.grgb swizzling (equivalent to double4.yxyz).
        /// </summary>
        [Inline]
        public double4 grgb =>  double4(y, x, y, z);
        
        /// <summary>
        /// Returns double4.yxyw swizzling.
        /// </summary>
        [Inline]
        public double4 yxyw =>  double4(y, x, y, w);
        
        /// <summary>
        /// Returns double4.grga swizzling (equivalent to double4.yxyw).
        /// </summary>
        [Inline]
        public double4 grga =>  double4(y, x, y, w);
        
        /// <summary>
        /// Returns double4.yxz swizzling.
        /// </summary>
        [Inline]
        public double3 yxz =>  double3(y, x, z);
        
        /// <summary>
        /// Returns double4.grb swizzling (equivalent to double4.yxz).
        /// </summary>
        [Inline]
        public double3 grb =>  double3(y, x, z);
        
        /// <summary>
        /// Returns double4.yxzx swizzling.
        /// </summary>
        [Inline]
        public double4 yxzx =>  double4(y, x, z, x);
        
        /// <summary>
        /// Returns double4.grbr swizzling (equivalent to double4.yxzx).
        /// </summary>
        [Inline]
        public double4 grbr =>  double4(y, x, z, x);
        
        /// <summary>
        /// Returns double4.yxzy swizzling.
        /// </summary>
        [Inline]
        public double4 yxzy =>  double4(y, x, z, y);
        
        /// <summary>
        /// Returns double4.grbg swizzling (equivalent to double4.yxzy).
        /// </summary>
        [Inline]
        public double4 grbg =>  double4(y, x, z, y);
        
        /// <summary>
        /// Returns double4.yxzz swizzling.
        /// </summary>
        [Inline]
        public double4 yxzz =>  double4(y, x, z, z);
        
        /// <summary>
        /// Returns double4.grbb swizzling (equivalent to double4.yxzz).
        /// </summary>
        [Inline]
        public double4 grbb =>  double4(y, x, z, z);
        
        /// <summary>
        /// Returns double4.yxzw swizzling.
        /// </summary>
        [Inline]
        public double4 yxzw =>  double4(y, x, z, w);
        
        /// <summary>
        /// Returns double4.grba swizzling (equivalent to double4.yxzw).
        /// </summary>
        [Inline]
        public double4 grba =>  double4(y, x, z, w);
        
        /// <summary>
        /// Returns double4.yxw swizzling.
        /// </summary>
        [Inline]
        public double3 yxw =>  double3(y, x, w);
        
        /// <summary>
        /// Returns double4.gra swizzling (equivalent to double4.yxw).
        /// </summary>
        [Inline]
        public double3 gra =>  double3(y, x, w);
        
        /// <summary>
        /// Returns double4.yxwx swizzling.
        /// </summary>
        [Inline]
        public double4 yxwx =>  double4(y, x, w, x);
        
        /// <summary>
        /// Returns double4.grar swizzling (equivalent to double4.yxwx).
        /// </summary>
        [Inline]
        public double4 grar =>  double4(y, x, w, x);
        
        /// <summary>
        /// Returns double4.yxwy swizzling.
        /// </summary>
        [Inline]
        public double4 yxwy =>  double4(y, x, w, y);
        
        /// <summary>
        /// Returns double4.grag swizzling (equivalent to double4.yxwy).
        /// </summary>
        [Inline]
        public double4 grag =>  double4(y, x, w, y);
        
        /// <summary>
        /// Returns double4.yxwz swizzling.
        /// </summary>
        [Inline]
        public double4 yxwz =>  double4(y, x, w, z);
        
        /// <summary>
        /// Returns double4.grab swizzling (equivalent to double4.yxwz).
        /// </summary>
        [Inline]
        public double4 grab =>  double4(y, x, w, z);
        
        /// <summary>
        /// Returns double4.yxww swizzling.
        /// </summary>
        [Inline]
        public double4 yxww =>  double4(y, x, w, w);
        
        /// <summary>
        /// Returns double4.graa swizzling (equivalent to double4.yxww).
        /// </summary>
        [Inline]
        public double4 graa =>  double4(y, x, w, w);
        
        /// <summary>
        /// Returns double4.yy swizzling.
        /// </summary>
        [Inline]
        public double2 yy =>  double2(y, y);
        
        /// <summary>
        /// Returns double4.gg swizzling (equivalent to double4.yy).
        /// </summary>
        [Inline]
        public double2 gg =>  double2(y, y);
        
        /// <summary>
        /// Returns double4.yyx swizzling.
        /// </summary>
        [Inline]
        public double3 yyx =>  double3(y, y, x);
        
        /// <summary>
        /// Returns double4.ggr swizzling (equivalent to double4.yyx).
        /// </summary>
        [Inline]
        public double3 ggr =>  double3(y, y, x);
        
        /// <summary>
        /// Returns double4.yyxx swizzling.
        /// </summary>
        [Inline]
        public double4 yyxx =>  double4(y, y, x, x);
        
        /// <summary>
        /// Returns double4.ggrr swizzling (equivalent to double4.yyxx).
        /// </summary>
        [Inline]
        public double4 ggrr =>  double4(y, y, x, x);
        
        /// <summary>
        /// Returns double4.yyxy swizzling.
        /// </summary>
        [Inline]
        public double4 yyxy =>  double4(y, y, x, y);
        
        /// <summary>
        /// Returns double4.ggrg swizzling (equivalent to double4.yyxy).
        /// </summary>
        [Inline]
        public double4 ggrg =>  double4(y, y, x, y);
        
        /// <summary>
        /// Returns double4.yyxz swizzling.
        /// </summary>
        [Inline]
        public double4 yyxz =>  double4(y, y, x, z);
        
        /// <summary>
        /// Returns double4.ggrb swizzling (equivalent to double4.yyxz).
        /// </summary>
        [Inline]
        public double4 ggrb =>  double4(y, y, x, z);
        
        /// <summary>
        /// Returns double4.yyxw swizzling.
        /// </summary>
        [Inline]
        public double4 yyxw =>  double4(y, y, x, w);
        
        /// <summary>
        /// Returns double4.ggra swizzling (equivalent to double4.yyxw).
        /// </summary>
        [Inline]
        public double4 ggra =>  double4(y, y, x, w);
        
        /// <summary>
        /// Returns double4.yyy swizzling.
        /// </summary>
        [Inline]
        public double3 yyy =>  double3(y, y, y);
        
        /// <summary>
        /// Returns double4.ggg swizzling (equivalent to double4.yyy).
        /// </summary>
        [Inline]
        public double3 ggg =>  double3(y, y, y);
        
        /// <summary>
        /// Returns double4.yyyx swizzling.
        /// </summary>
        [Inline]
        public double4 yyyx =>  double4(y, y, y, x);
        
        /// <summary>
        /// Returns double4.gggr swizzling (equivalent to double4.yyyx).
        /// </summary>
        [Inline]
        public double4 gggr =>  double4(y, y, y, x);
        
        /// <summary>
        /// Returns double4.yyyy swizzling.
        /// </summary>
        [Inline]
        public double4 yyyy =>  double4(y, y, y, y);
        
        /// <summary>
        /// Returns double4.gggg swizzling (equivalent to double4.yyyy).
        /// </summary>
        [Inline]
        public double4 gggg =>  double4(y, y, y, y);
        
        /// <summary>
        /// Returns double4.yyyz swizzling.
        /// </summary>
        [Inline]
        public double4 yyyz =>  double4(y, y, y, z);
        
        /// <summary>
        /// Returns double4.gggb swizzling (equivalent to double4.yyyz).
        /// </summary>
        [Inline]
        public double4 gggb =>  double4(y, y, y, z);
        
        /// <summary>
        /// Returns double4.yyyw swizzling.
        /// </summary>
        [Inline]
        public double4 yyyw =>  double4(y, y, y, w);
        
        /// <summary>
        /// Returns double4.ggga swizzling (equivalent to double4.yyyw).
        /// </summary>
        [Inline]
        public double4 ggga =>  double4(y, y, y, w);
        
        /// <summary>
        /// Returns double4.yyz swizzling.
        /// </summary>
        [Inline]
        public double3 yyz =>  double3(y, y, z);
        
        /// <summary>
        /// Returns double4.ggb swizzling (equivalent to double4.yyz).
        /// </summary>
        [Inline]
        public double3 ggb =>  double3(y, y, z);
        
        /// <summary>
        /// Returns double4.yyzx swizzling.
        /// </summary>
        [Inline]
        public double4 yyzx =>  double4(y, y, z, x);
        
        /// <summary>
        /// Returns double4.ggbr swizzling (equivalent to double4.yyzx).
        /// </summary>
        [Inline]
        public double4 ggbr =>  double4(y, y, z, x);
        
        /// <summary>
        /// Returns double4.yyzy swizzling.
        /// </summary>
        [Inline]
        public double4 yyzy =>  double4(y, y, z, y);
        
        /// <summary>
        /// Returns double4.ggbg swizzling (equivalent to double4.yyzy).
        /// </summary>
        [Inline]
        public double4 ggbg =>  double4(y, y, z, y);
        
        /// <summary>
        /// Returns double4.yyzz swizzling.
        /// </summary>
        [Inline]
        public double4 yyzz =>  double4(y, y, z, z);
        
        /// <summary>
        /// Returns double4.ggbb swizzling (equivalent to double4.yyzz).
        /// </summary>
        [Inline]
        public double4 ggbb =>  double4(y, y, z, z);
        
        /// <summary>
        /// Returns double4.yyzw swizzling.
        /// </summary>
        [Inline]
        public double4 yyzw =>  double4(y, y, z, w);
        
        /// <summary>
        /// Returns double4.ggba swizzling (equivalent to double4.yyzw).
        /// </summary>
        [Inline]
        public double4 ggba =>  double4(y, y, z, w);
        
        /// <summary>
        /// Returns double4.yyw swizzling.
        /// </summary>
        [Inline]
        public double3 yyw =>  double3(y, y, w);
        
        /// <summary>
        /// Returns double4.gga swizzling (equivalent to double4.yyw).
        /// </summary>
        [Inline]
        public double3 gga =>  double3(y, y, w);
        
        /// <summary>
        /// Returns double4.yywx swizzling.
        /// </summary>
        [Inline]
        public double4 yywx =>  double4(y, y, w, x);
        
        /// <summary>
        /// Returns double4.ggar swizzling (equivalent to double4.yywx).
        /// </summary>
        [Inline]
        public double4 ggar =>  double4(y, y, w, x);
        
        /// <summary>
        /// Returns double4.yywy swizzling.
        /// </summary>
        [Inline]
        public double4 yywy =>  double4(y, y, w, y);
        
        /// <summary>
        /// Returns double4.ggag swizzling (equivalent to double4.yywy).
        /// </summary>
        [Inline]
        public double4 ggag =>  double4(y, y, w, y);
        
        /// <summary>
        /// Returns double4.yywz swizzling.
        /// </summary>
        [Inline]
        public double4 yywz =>  double4(y, y, w, z);
        
        /// <summary>
        /// Returns double4.ggab swizzling (equivalent to double4.yywz).
        /// </summary>
        [Inline]
        public double4 ggab =>  double4(y, y, w, z);
        
        /// <summary>
        /// Returns double4.yyww swizzling.
        /// </summary>
        [Inline]
        public double4 yyww =>  double4(y, y, w, w);
        
        /// <summary>
        /// Returns double4.ggaa swizzling (equivalent to double4.yyww).
        /// </summary>
        [Inline]
        public double4 ggaa =>  double4(y, y, w, w);
        
        /// <summary>
        /// Returns double4.yz swizzling.
        /// </summary>
        [Inline]
        public double2 yz =>  double2(y, z);
        
        /// <summary>
        /// Returns double4.gb swizzling (equivalent to double4.yz).
        /// </summary>
        [Inline]
        public double2 gb =>  double2(y, z);
        
        /// <summary>
        /// Returns double4.yzx swizzling.
        /// </summary>
        [Inline]
        public double3 yzx =>  double3(y, z, x);
        
        /// <summary>
        /// Returns double4.gbr swizzling (equivalent to double4.yzx).
        /// </summary>
        [Inline]
        public double3 gbr =>  double3(y, z, x);
        
        /// <summary>
        /// Returns double4.yzxx swizzling.
        /// </summary>
        [Inline]
        public double4 yzxx =>  double4(y, z, x, x);
        
        /// <summary>
        /// Returns double4.gbrr swizzling (equivalent to double4.yzxx).
        /// </summary>
        [Inline]
        public double4 gbrr =>  double4(y, z, x, x);
        
        /// <summary>
        /// Returns double4.yzxy swizzling.
        /// </summary>
        [Inline]
        public double4 yzxy =>  double4(y, z, x, y);
        
        /// <summary>
        /// Returns double4.gbrg swizzling (equivalent to double4.yzxy).
        /// </summary>
        [Inline]
        public double4 gbrg =>  double4(y, z, x, y);
        
        /// <summary>
        /// Returns double4.yzxz swizzling.
        /// </summary>
        [Inline]
        public double4 yzxz =>  double4(y, z, x, z);
        
        /// <summary>
        /// Returns double4.gbrb swizzling (equivalent to double4.yzxz).
        /// </summary>
        [Inline]
        public double4 gbrb =>  double4(y, z, x, z);
        
        /// <summary>
        /// Returns double4.yzxw swizzling.
        /// </summary>
        [Inline]
        public double4 yzxw =>  double4(y, z, x, w);
        
        /// <summary>
        /// Returns double4.gbra swizzling (equivalent to double4.yzxw).
        /// </summary>
        [Inline]
        public double4 gbra =>  double4(y, z, x, w);
        
        /// <summary>
        /// Returns double4.yzy swizzling.
        /// </summary>
        [Inline]
        public double3 yzy =>  double3(y, z, y);
        
        /// <summary>
        /// Returns double4.gbg swizzling (equivalent to double4.yzy).
        /// </summary>
        [Inline]
        public double3 gbg =>  double3(y, z, y);
        
        /// <summary>
        /// Returns double4.yzyx swizzling.
        /// </summary>
        [Inline]
        public double4 yzyx =>  double4(y, z, y, x);
        
        /// <summary>
        /// Returns double4.gbgr swizzling (equivalent to double4.yzyx).
        /// </summary>
        [Inline]
        public double4 gbgr =>  double4(y, z, y, x);
        
        /// <summary>
        /// Returns double4.yzyy swizzling.
        /// </summary>
        [Inline]
        public double4 yzyy =>  double4(y, z, y, y);
        
        /// <summary>
        /// Returns double4.gbgg swizzling (equivalent to double4.yzyy).
        /// </summary>
        [Inline]
        public double4 gbgg =>  double4(y, z, y, y);
        
        /// <summary>
        /// Returns double4.yzyz swizzling.
        /// </summary>
        [Inline]
        public double4 yzyz =>  double4(y, z, y, z);
        
        /// <summary>
        /// Returns double4.gbgb swizzling (equivalent to double4.yzyz).
        /// </summary>
        [Inline]
        public double4 gbgb =>  double4(y, z, y, z);
        
        /// <summary>
        /// Returns double4.yzyw swizzling.
        /// </summary>
        [Inline]
        public double4 yzyw =>  double4(y, z, y, w);
        
        /// <summary>
        /// Returns double4.gbga swizzling (equivalent to double4.yzyw).
        /// </summary>
        [Inline]
        public double4 gbga =>  double4(y, z, y, w);
        
        /// <summary>
        /// Returns double4.yzz swizzling.
        /// </summary>
        [Inline]
        public double3 yzz =>  double3(y, z, z);
        
        /// <summary>
        /// Returns double4.gbb swizzling (equivalent to double4.yzz).
        /// </summary>
        [Inline]
        public double3 gbb =>  double3(y, z, z);
        
        /// <summary>
        /// Returns double4.yzzx swizzling.
        /// </summary>
        [Inline]
        public double4 yzzx =>  double4(y, z, z, x);
        
        /// <summary>
        /// Returns double4.gbbr swizzling (equivalent to double4.yzzx).
        /// </summary>
        [Inline]
        public double4 gbbr =>  double4(y, z, z, x);
        
        /// <summary>
        /// Returns double4.yzzy swizzling.
        /// </summary>
        [Inline]
        public double4 yzzy =>  double4(y, z, z, y);
        
        /// <summary>
        /// Returns double4.gbbg swizzling (equivalent to double4.yzzy).
        /// </summary>
        [Inline]
        public double4 gbbg =>  double4(y, z, z, y);
        
        /// <summary>
        /// Returns double4.yzzz swizzling.
        /// </summary>
        [Inline]
        public double4 yzzz =>  double4(y, z, z, z);
        
        /// <summary>
        /// Returns double4.gbbb swizzling (equivalent to double4.yzzz).
        /// </summary>
        [Inline]
        public double4 gbbb =>  double4(y, z, z, z);
        
        /// <summary>
        /// Returns double4.yzzw swizzling.
        /// </summary>
        [Inline]
        public double4 yzzw =>  double4(y, z, z, w);
        
        /// <summary>
        /// Returns double4.gbba swizzling (equivalent to double4.yzzw).
        /// </summary>
        [Inline]
        public double4 gbba =>  double4(y, z, z, w);
        
        /// <summary>
        /// Returns double4.yzw swizzling.
        /// </summary>
        [Inline]
        public double3 yzw =>  double3(y, z, w);
        
        /// <summary>
        /// Returns double4.gba swizzling (equivalent to double4.yzw).
        /// </summary>
        [Inline]
        public double3 gba =>  double3(y, z, w);
        
        /// <summary>
        /// Returns double4.yzwx swizzling.
        /// </summary>
        [Inline]
        public double4 yzwx =>  double4(y, z, w, x);
        
        /// <summary>
        /// Returns double4.gbar swizzling (equivalent to double4.yzwx).
        /// </summary>
        [Inline]
        public double4 gbar =>  double4(y, z, w, x);
        
        /// <summary>
        /// Returns double4.yzwy swizzling.
        /// </summary>
        [Inline]
        public double4 yzwy =>  double4(y, z, w, y);
        
        /// <summary>
        /// Returns double4.gbag swizzling (equivalent to double4.yzwy).
        /// </summary>
        [Inline]
        public double4 gbag =>  double4(y, z, w, y);
        
        /// <summary>
        /// Returns double4.yzwz swizzling.
        /// </summary>
        [Inline]
        public double4 yzwz =>  double4(y, z, w, z);
        
        /// <summary>
        /// Returns double4.gbab swizzling (equivalent to double4.yzwz).
        /// </summary>
        [Inline]
        public double4 gbab =>  double4(y, z, w, z);
        
        /// <summary>
        /// Returns double4.yzww swizzling.
        /// </summary>
        [Inline]
        public double4 yzww =>  double4(y, z, w, w);
        
        /// <summary>
        /// Returns double4.gbaa swizzling (equivalent to double4.yzww).
        /// </summary>
        [Inline]
        public double4 gbaa =>  double4(y, z, w, w);
        
        /// <summary>
        /// Returns double4.yw swizzling.
        /// </summary>
        [Inline]
        public double2 yw =>  double2(y, w);
        
        /// <summary>
        /// Returns double4.ga swizzling (equivalent to double4.yw).
        /// </summary>
        [Inline]
        public double2 ga =>  double2(y, w);
        
        /// <summary>
        /// Returns double4.ywx swizzling.
        /// </summary>
        [Inline]
        public double3 ywx =>  double3(y, w, x);
        
        /// <summary>
        /// Returns double4.gar swizzling (equivalent to double4.ywx).
        /// </summary>
        [Inline]
        public double3 gar =>  double3(y, w, x);
        
        /// <summary>
        /// Returns double4.ywxx swizzling.
        /// </summary>
        [Inline]
        public double4 ywxx =>  double4(y, w, x, x);
        
        /// <summary>
        /// Returns double4.garr swizzling (equivalent to double4.ywxx).
        /// </summary>
        [Inline]
        public double4 garr =>  double4(y, w, x, x);
        
        /// <summary>
        /// Returns double4.ywxy swizzling.
        /// </summary>
        [Inline]
        public double4 ywxy =>  double4(y, w, x, y);
        
        /// <summary>
        /// Returns double4.garg swizzling (equivalent to double4.ywxy).
        /// </summary>
        [Inline]
        public double4 garg =>  double4(y, w, x, y);
        
        /// <summary>
        /// Returns double4.ywxz swizzling.
        /// </summary>
        [Inline]
        public double4 ywxz =>  double4(y, w, x, z);
        
        /// <summary>
        /// Returns double4.garb swizzling (equivalent to double4.ywxz).
        /// </summary>
        [Inline]
        public double4 garb =>  double4(y, w, x, z);
        
        /// <summary>
        /// Returns double4.ywxw swizzling.
        /// </summary>
        [Inline]
        public double4 ywxw =>  double4(y, w, x, w);
        
        /// <summary>
        /// Returns double4.gara swizzling (equivalent to double4.ywxw).
        /// </summary>
        [Inline]
        public double4 gara =>  double4(y, w, x, w);
        
        /// <summary>
        /// Returns double4.ywy swizzling.
        /// </summary>
        [Inline]
        public double3 ywy =>  double3(y, w, y);
        
        /// <summary>
        /// Returns double4.gag swizzling (equivalent to double4.ywy).
        /// </summary>
        [Inline]
        public double3 gag =>  double3(y, w, y);
        
        /// <summary>
        /// Returns double4.ywyx swizzling.
        /// </summary>
        [Inline]
        public double4 ywyx =>  double4(y, w, y, x);
        
        /// <summary>
        /// Returns double4.gagr swizzling (equivalent to double4.ywyx).
        /// </summary>
        [Inline]
        public double4 gagr =>  double4(y, w, y, x);
        
        /// <summary>
        /// Returns double4.ywyy swizzling.
        /// </summary>
        [Inline]
        public double4 ywyy =>  double4(y, w, y, y);
        
        /// <summary>
        /// Returns double4.gagg swizzling (equivalent to double4.ywyy).
        /// </summary>
        [Inline]
        public double4 gagg =>  double4(y, w, y, y);
        
        /// <summary>
        /// Returns double4.ywyz swizzling.
        /// </summary>
        [Inline]
        public double4 ywyz =>  double4(y, w, y, z);
        
        /// <summary>
        /// Returns double4.gagb swizzling (equivalent to double4.ywyz).
        /// </summary>
        [Inline]
        public double4 gagb =>  double4(y, w, y, z);
        
        /// <summary>
        /// Returns double4.ywyw swizzling.
        /// </summary>
        [Inline]
        public double4 ywyw =>  double4(y, w, y, w);
        
        /// <summary>
        /// Returns double4.gaga swizzling (equivalent to double4.ywyw).
        /// </summary>
        [Inline]
        public double4 gaga =>  double4(y, w, y, w);
        
        /// <summary>
        /// Returns double4.ywz swizzling.
        /// </summary>
        [Inline]
        public double3 ywz =>  double3(y, w, z);
        
        /// <summary>
        /// Returns double4.gab swizzling (equivalent to double4.ywz).
        /// </summary>
        [Inline]
        public double3 gab =>  double3(y, w, z);
        
        /// <summary>
        /// Returns double4.ywzx swizzling.
        /// </summary>
        [Inline]
        public double4 ywzx =>  double4(y, w, z, x);
        
        /// <summary>
        /// Returns double4.gabr swizzling (equivalent to double4.ywzx).
        /// </summary>
        [Inline]
        public double4 gabr =>  double4(y, w, z, x);
        
        /// <summary>
        /// Returns double4.ywzy swizzling.
        /// </summary>
        [Inline]
        public double4 ywzy =>  double4(y, w, z, y);
        
        /// <summary>
        /// Returns double4.gabg swizzling (equivalent to double4.ywzy).
        /// </summary>
        [Inline]
        public double4 gabg =>  double4(y, w, z, y);
        
        /// <summary>
        /// Returns double4.ywzz swizzling.
        /// </summary>
        [Inline]
        public double4 ywzz =>  double4(y, w, z, z);
        
        /// <summary>
        /// Returns double4.gabb swizzling (equivalent to double4.ywzz).
        /// </summary>
        [Inline]
        public double4 gabb =>  double4(y, w, z, z);
        
        /// <summary>
        /// Returns double4.ywzw swizzling.
        /// </summary>
        [Inline]
        public double4 ywzw =>  double4(y, w, z, w);
        
        /// <summary>
        /// Returns double4.gaba swizzling (equivalent to double4.ywzw).
        /// </summary>
        [Inline]
        public double4 gaba =>  double4(y, w, z, w);
        
        /// <summary>
        /// Returns double4.yww swizzling.
        /// </summary>
        [Inline]
        public double3 yww =>  double3(y, w, w);
        
        /// <summary>
        /// Returns double4.gaa swizzling (equivalent to double4.yww).
        /// </summary>
        [Inline]
        public double3 gaa =>  double3(y, w, w);
        
        /// <summary>
        /// Returns double4.ywwx swizzling.
        /// </summary>
        [Inline]
        public double4 ywwx =>  double4(y, w, w, x);
        
        /// <summary>
        /// Returns double4.gaar swizzling (equivalent to double4.ywwx).
        /// </summary>
        [Inline]
        public double4 gaar =>  double4(y, w, w, x);
        
        /// <summary>
        /// Returns double4.ywwy swizzling.
        /// </summary>
        [Inline]
        public double4 ywwy =>  double4(y, w, w, y);
        
        /// <summary>
        /// Returns double4.gaag swizzling (equivalent to double4.ywwy).
        /// </summary>
        [Inline]
        public double4 gaag =>  double4(y, w, w, y);
        
        /// <summary>
        /// Returns double4.ywwz swizzling.
        /// </summary>
        [Inline]
        public double4 ywwz =>  double4(y, w, w, z);
        
        /// <summary>
        /// Returns double4.gaab swizzling (equivalent to double4.ywwz).
        /// </summary>
        [Inline]
        public double4 gaab =>  double4(y, w, w, z);
        
        /// <summary>
        /// Returns double4.ywww swizzling.
        /// </summary>
        [Inline]
        public double4 ywww =>  double4(y, w, w, w);
        
        /// <summary>
        /// Returns double4.gaaa swizzling (equivalent to double4.ywww).
        /// </summary>
        [Inline]
        public double4 gaaa =>  double4(y, w, w, w);
        
        /// <summary>
        /// Returns double4.zx swizzling.
        /// </summary>
        [Inline]
        public double2 zx =>  double2(z, x);
        
        /// <summary>
        /// Returns double4.br swizzling (equivalent to double4.zx).
        /// </summary>
        [Inline]
        public double2 br =>  double2(z, x);
        
        /// <summary>
        /// Returns double4.zxx swizzling.
        /// </summary>
        [Inline]
        public double3 zxx =>  double3(z, x, x);
        
        /// <summary>
        /// Returns double4.brr swizzling (equivalent to double4.zxx).
        /// </summary>
        [Inline]
        public double3 brr =>  double3(z, x, x);
        
        /// <summary>
        /// Returns double4.zxxx swizzling.
        /// </summary>
        [Inline]
        public double4 zxxx =>  double4(z, x, x, x);
        
        /// <summary>
        /// Returns double4.brrr swizzling (equivalent to double4.zxxx).
        /// </summary>
        [Inline]
        public double4 brrr =>  double4(z, x, x, x);
        
        /// <summary>
        /// Returns double4.zxxy swizzling.
        /// </summary>
        [Inline]
        public double4 zxxy =>  double4(z, x, x, y);
        
        /// <summary>
        /// Returns double4.brrg swizzling (equivalent to double4.zxxy).
        /// </summary>
        [Inline]
        public double4 brrg =>  double4(z, x, x, y);
        
        /// <summary>
        /// Returns double4.zxxz swizzling.
        /// </summary>
        [Inline]
        public double4 zxxz =>  double4(z, x, x, z);
        
        /// <summary>
        /// Returns double4.brrb swizzling (equivalent to double4.zxxz).
        /// </summary>
        [Inline]
        public double4 brrb =>  double4(z, x, x, z);
        
        /// <summary>
        /// Returns double4.zxxw swizzling.
        /// </summary>
        [Inline]
        public double4 zxxw =>  double4(z, x, x, w);
        
        /// <summary>
        /// Returns double4.brra swizzling (equivalent to double4.zxxw).
        /// </summary>
        [Inline]
        public double4 brra =>  double4(z, x, x, w);
        
        /// <summary>
        /// Returns double4.zxy swizzling.
        /// </summary>
        [Inline]
        public double3 zxy =>  double3(z, x, y);
        
        /// <summary>
        /// Returns double4.brg swizzling (equivalent to double4.zxy).
        /// </summary>
        [Inline]
        public double3 brg =>  double3(z, x, y);
        
        /// <summary>
        /// Returns double4.zxyx swizzling.
        /// </summary>
        [Inline]
        public double4 zxyx =>  double4(z, x, y, x);
        
        /// <summary>
        /// Returns double4.brgr swizzling (equivalent to double4.zxyx).
        /// </summary>
        [Inline]
        public double4 brgr =>  double4(z, x, y, x);
        
        /// <summary>
        /// Returns double4.zxyy swizzling.
        /// </summary>
        [Inline]
        public double4 zxyy =>  double4(z, x, y, y);
        
        /// <summary>
        /// Returns double4.brgg swizzling (equivalent to double4.zxyy).
        /// </summary>
        [Inline]
        public double4 brgg =>  double4(z, x, y, y);
        
        /// <summary>
        /// Returns double4.zxyz swizzling.
        /// </summary>
        [Inline]
        public double4 zxyz =>  double4(z, x, y, z);
        
        /// <summary>
        /// Returns double4.brgb swizzling (equivalent to double4.zxyz).
        /// </summary>
        [Inline]
        public double4 brgb =>  double4(z, x, y, z);
        
        /// <summary>
        /// Returns double4.zxyw swizzling.
        /// </summary>
        [Inline]
        public double4 zxyw =>  double4(z, x, y, w);
        
        /// <summary>
        /// Returns double4.brga swizzling (equivalent to double4.zxyw).
        /// </summary>
        [Inline]
        public double4 brga =>  double4(z, x, y, w);
        
        /// <summary>
        /// Returns double4.zxz swizzling.
        /// </summary>
        [Inline]
        public double3 zxz =>  double3(z, x, z);
        
        /// <summary>
        /// Returns double4.brb swizzling (equivalent to double4.zxz).
        /// </summary>
        [Inline]
        public double3 brb =>  double3(z, x, z);
        
        /// <summary>
        /// Returns double4.zxzx swizzling.
        /// </summary>
        [Inline]
        public double4 zxzx =>  double4(z, x, z, x);
        
        /// <summary>
        /// Returns double4.brbr swizzling (equivalent to double4.zxzx).
        /// </summary>
        [Inline]
        public double4 brbr =>  double4(z, x, z, x);
        
        /// <summary>
        /// Returns double4.zxzy swizzling.
        /// </summary>
        [Inline]
        public double4 zxzy =>  double4(z, x, z, y);
        
        /// <summary>
        /// Returns double4.brbg swizzling (equivalent to double4.zxzy).
        /// </summary>
        [Inline]
        public double4 brbg =>  double4(z, x, z, y);
        
        /// <summary>
        /// Returns double4.zxzz swizzling.
        /// </summary>
        [Inline]
        public double4 zxzz =>  double4(z, x, z, z);
        
        /// <summary>
        /// Returns double4.brbb swizzling (equivalent to double4.zxzz).
        /// </summary>
        [Inline]
        public double4 brbb =>  double4(z, x, z, z);
        
        /// <summary>
        /// Returns double4.zxzw swizzling.
        /// </summary>
        [Inline]
        public double4 zxzw =>  double4(z, x, z, w);
        
        /// <summary>
        /// Returns double4.brba swizzling (equivalent to double4.zxzw).
        /// </summary>
        [Inline]
        public double4 brba =>  double4(z, x, z, w);
        
        /// <summary>
        /// Returns double4.zxw swizzling.
        /// </summary>
        [Inline]
        public double3 zxw =>  double3(z, x, w);
        
        /// <summary>
        /// Returns double4.bra swizzling (equivalent to double4.zxw).
        /// </summary>
        [Inline]
        public double3 bra =>  double3(z, x, w);
        
        /// <summary>
        /// Returns double4.zxwx swizzling.
        /// </summary>
        [Inline]
        public double4 zxwx =>  double4(z, x, w, x);
        
        /// <summary>
        /// Returns double4.brar swizzling (equivalent to double4.zxwx).
        /// </summary>
        [Inline]
        public double4 brar =>  double4(z, x, w, x);
        
        /// <summary>
        /// Returns double4.zxwy swizzling.
        /// </summary>
        [Inline]
        public double4 zxwy =>  double4(z, x, w, y);
        
        /// <summary>
        /// Returns double4.brag swizzling (equivalent to double4.zxwy).
        /// </summary>
        [Inline]
        public double4 brag =>  double4(z, x, w, y);
        
        /// <summary>
        /// Returns double4.zxwz swizzling.
        /// </summary>
        [Inline]
        public double4 zxwz =>  double4(z, x, w, z);
        
        /// <summary>
        /// Returns double4.brab swizzling (equivalent to double4.zxwz).
        /// </summary>
        [Inline]
        public double4 brab =>  double4(z, x, w, z);
        
        /// <summary>
        /// Returns double4.zxww swizzling.
        /// </summary>
        [Inline]
        public double4 zxww =>  double4(z, x, w, w);
        
        /// <summary>
        /// Returns double4.braa swizzling (equivalent to double4.zxww).
        /// </summary>
        [Inline]
        public double4 braa =>  double4(z, x, w, w);
        
        /// <summary>
        /// Returns double4.zy swizzling.
        /// </summary>
        [Inline]
        public double2 zy =>  double2(z, y);
        
        /// <summary>
        /// Returns double4.bg swizzling (equivalent to double4.zy).
        /// </summary>
        [Inline]
        public double2 bg =>  double2(z, y);
        
        /// <summary>
        /// Returns double4.zyx swizzling.
        /// </summary>
        [Inline]
        public double3 zyx =>  double3(z, y, x);
        
        /// <summary>
        /// Returns double4.bgr swizzling (equivalent to double4.zyx).
        /// </summary>
        [Inline]
        public double3 bgr =>  double3(z, y, x);
        
        /// <summary>
        /// Returns double4.zyxx swizzling.
        /// </summary>
        [Inline]
        public double4 zyxx =>  double4(z, y, x, x);
        
        /// <summary>
        /// Returns double4.bgrr swizzling (equivalent to double4.zyxx).
        /// </summary>
        [Inline]
        public double4 bgrr =>  double4(z, y, x, x);
        
        /// <summary>
        /// Returns double4.zyxy swizzling.
        /// </summary>
        [Inline]
        public double4 zyxy =>  double4(z, y, x, y);
        
        /// <summary>
        /// Returns double4.bgrg swizzling (equivalent to double4.zyxy).
        /// </summary>
        [Inline]
        public double4 bgrg =>  double4(z, y, x, y);
        
        /// <summary>
        /// Returns double4.zyxz swizzling.
        /// </summary>
        [Inline]
        public double4 zyxz =>  double4(z, y, x, z);
        
        /// <summary>
        /// Returns double4.bgrb swizzling (equivalent to double4.zyxz).
        /// </summary>
        [Inline]
        public double4 bgrb =>  double4(z, y, x, z);
        
        /// <summary>
        /// Returns double4.zyxw swizzling.
        /// </summary>
        [Inline]
        public double4 zyxw =>  double4(z, y, x, w);
        
        /// <summary>
        /// Returns double4.bgra swizzling (equivalent to double4.zyxw).
        /// </summary>
        [Inline]
        public double4 bgra =>  double4(z, y, x, w);
        
        /// <summary>
        /// Returns double4.zyy swizzling.
        /// </summary>
        [Inline]
        public double3 zyy =>  double3(z, y, y);
        
        /// <summary>
        /// Returns double4.bgg swizzling (equivalent to double4.zyy).
        /// </summary>
        [Inline]
        public double3 bgg =>  double3(z, y, y);
        
        /// <summary>
        /// Returns double4.zyyx swizzling.
        /// </summary>
        [Inline]
        public double4 zyyx =>  double4(z, y, y, x);
        
        /// <summary>
        /// Returns double4.bggr swizzling (equivalent to double4.zyyx).
        /// </summary>
        [Inline]
        public double4 bggr =>  double4(z, y, y, x);
        
        /// <summary>
        /// Returns double4.zyyy swizzling.
        /// </summary>
        [Inline]
        public double4 zyyy =>  double4(z, y, y, y);
        
        /// <summary>
        /// Returns double4.bggg swizzling (equivalent to double4.zyyy).
        /// </summary>
        [Inline]
        public double4 bggg =>  double4(z, y, y, y);
        
        /// <summary>
        /// Returns double4.zyyz swizzling.
        /// </summary>
        [Inline]
        public double4 zyyz =>  double4(z, y, y, z);
        
        /// <summary>
        /// Returns double4.bggb swizzling (equivalent to double4.zyyz).
        /// </summary>
        [Inline]
        public double4 bggb =>  double4(z, y, y, z);
        
        /// <summary>
        /// Returns double4.zyyw swizzling.
        /// </summary>
        [Inline]
        public double4 zyyw =>  double4(z, y, y, w);
        
        /// <summary>
        /// Returns double4.bgga swizzling (equivalent to double4.zyyw).
        /// </summary>
        [Inline]
        public double4 bgga =>  double4(z, y, y, w);
        
        /// <summary>
        /// Returns double4.zyz swizzling.
        /// </summary>
        [Inline]
        public double3 zyz =>  double3(z, y, z);
        
        /// <summary>
        /// Returns double4.bgb swizzling (equivalent to double4.zyz).
        /// </summary>
        [Inline]
        public double3 bgb =>  double3(z, y, z);
        
        /// <summary>
        /// Returns double4.zyzx swizzling.
        /// </summary>
        [Inline]
        public double4 zyzx =>  double4(z, y, z, x);
        
        /// <summary>
        /// Returns double4.bgbr swizzling (equivalent to double4.zyzx).
        /// </summary>
        [Inline]
        public double4 bgbr =>  double4(z, y, z, x);
        
        /// <summary>
        /// Returns double4.zyzy swizzling.
        /// </summary>
        [Inline]
        public double4 zyzy =>  double4(z, y, z, y);
        
        /// <summary>
        /// Returns double4.bgbg swizzling (equivalent to double4.zyzy).
        /// </summary>
        [Inline]
        public double4 bgbg =>  double4(z, y, z, y);
        
        /// <summary>
        /// Returns double4.zyzz swizzling.
        /// </summary>
        [Inline]
        public double4 zyzz =>  double4(z, y, z, z);
        
        /// <summary>
        /// Returns double4.bgbb swizzling (equivalent to double4.zyzz).
        /// </summary>
        [Inline]
        public double4 bgbb =>  double4(z, y, z, z);
        
        /// <summary>
        /// Returns double4.zyzw swizzling.
        /// </summary>
        [Inline]
        public double4 zyzw =>  double4(z, y, z, w);
        
        /// <summary>
        /// Returns double4.bgba swizzling (equivalent to double4.zyzw).
        /// </summary>
        [Inline]
        public double4 bgba =>  double4(z, y, z, w);
        
        /// <summary>
        /// Returns double4.zyw swizzling.
        /// </summary>
        [Inline]
        public double3 zyw =>  double3(z, y, w);
        
        /// <summary>
        /// Returns double4.bga swizzling (equivalent to double4.zyw).
        /// </summary>
        [Inline]
        public double3 bga =>  double3(z, y, w);
        
        /// <summary>
        /// Returns double4.zywx swizzling.
        /// </summary>
        [Inline]
        public double4 zywx =>  double4(z, y, w, x);
        
        /// <summary>
        /// Returns double4.bgar swizzling (equivalent to double4.zywx).
        /// </summary>
        [Inline]
        public double4 bgar =>  double4(z, y, w, x);
        
        /// <summary>
        /// Returns double4.zywy swizzling.
        /// </summary>
        [Inline]
        public double4 zywy =>  double4(z, y, w, y);
        
        /// <summary>
        /// Returns double4.bgag swizzling (equivalent to double4.zywy).
        /// </summary>
        [Inline]
        public double4 bgag =>  double4(z, y, w, y);
        
        /// <summary>
        /// Returns double4.zywz swizzling.
        /// </summary>
        [Inline]
        public double4 zywz =>  double4(z, y, w, z);
        
        /// <summary>
        /// Returns double4.bgab swizzling (equivalent to double4.zywz).
        /// </summary>
        [Inline]
        public double4 bgab =>  double4(z, y, w, z);
        
        /// <summary>
        /// Returns double4.zyww swizzling.
        /// </summary>
        [Inline]
        public double4 zyww =>  double4(z, y, w, w);
        
        /// <summary>
        /// Returns double4.bgaa swizzling (equivalent to double4.zyww).
        /// </summary>
        [Inline]
        public double4 bgaa =>  double4(z, y, w, w);
        
        /// <summary>
        /// Returns double4.zz swizzling.
        /// </summary>
        [Inline]
        public double2 zz =>  double2(z, z);
        
        /// <summary>
        /// Returns double4.bb swizzling (equivalent to double4.zz).
        /// </summary>
        [Inline]
        public double2 bb =>  double2(z, z);
        
        /// <summary>
        /// Returns double4.zzx swizzling.
        /// </summary>
        [Inline]
        public double3 zzx =>  double3(z, z, x);
        
        /// <summary>
        /// Returns double4.bbr swizzling (equivalent to double4.zzx).
        /// </summary>
        [Inline]
        public double3 bbr =>  double3(z, z, x);
        
        /// <summary>
        /// Returns double4.zzxx swizzling.
        /// </summary>
        [Inline]
        public double4 zzxx =>  double4(z, z, x, x);
        
        /// <summary>
        /// Returns double4.bbrr swizzling (equivalent to double4.zzxx).
        /// </summary>
        [Inline]
        public double4 bbrr =>  double4(z, z, x, x);
        
        /// <summary>
        /// Returns double4.zzxy swizzling.
        /// </summary>
        [Inline]
        public double4 zzxy =>  double4(z, z, x, y);
        
        /// <summary>
        /// Returns double4.bbrg swizzling (equivalent to double4.zzxy).
        /// </summary>
        [Inline]
        public double4 bbrg =>  double4(z, z, x, y);
        
        /// <summary>
        /// Returns double4.zzxz swizzling.
        /// </summary>
        [Inline]
        public double4 zzxz =>  double4(z, z, x, z);
        
        /// <summary>
        /// Returns double4.bbrb swizzling (equivalent to double4.zzxz).
        /// </summary>
        [Inline]
        public double4 bbrb =>  double4(z, z, x, z);
        
        /// <summary>
        /// Returns double4.zzxw swizzling.
        /// </summary>
        [Inline]
        public double4 zzxw =>  double4(z, z, x, w);
        
        /// <summary>
        /// Returns double4.bbra swizzling (equivalent to double4.zzxw).
        /// </summary>
        [Inline]
        public double4 bbra =>  double4(z, z, x, w);
        
        /// <summary>
        /// Returns double4.zzy swizzling.
        /// </summary>
        [Inline]
        public double3 zzy =>  double3(z, z, y);
        
        /// <summary>
        /// Returns double4.bbg swizzling (equivalent to double4.zzy).
        /// </summary>
        [Inline]
        public double3 bbg =>  double3(z, z, y);
        
        /// <summary>
        /// Returns double4.zzyx swizzling.
        /// </summary>
        [Inline]
        public double4 zzyx =>  double4(z, z, y, x);
        
        /// <summary>
        /// Returns double4.bbgr swizzling (equivalent to double4.zzyx).
        /// </summary>
        [Inline]
        public double4 bbgr =>  double4(z, z, y, x);
        
        /// <summary>
        /// Returns double4.zzyy swizzling.
        /// </summary>
        [Inline]
        public double4 zzyy =>  double4(z, z, y, y);
        
        /// <summary>
        /// Returns double4.bbgg swizzling (equivalent to double4.zzyy).
        /// </summary>
        [Inline]
        public double4 bbgg =>  double4(z, z, y, y);
        
        /// <summary>
        /// Returns double4.zzyz swizzling.
        /// </summary>
        [Inline]
        public double4 zzyz =>  double4(z, z, y, z);
        
        /// <summary>
        /// Returns double4.bbgb swizzling (equivalent to double4.zzyz).
        /// </summary>
        [Inline]
        public double4 bbgb =>  double4(z, z, y, z);
        
        /// <summary>
        /// Returns double4.zzyw swizzling.
        /// </summary>
        [Inline]
        public double4 zzyw =>  double4(z, z, y, w);
        
        /// <summary>
        /// Returns double4.bbga swizzling (equivalent to double4.zzyw).
        /// </summary>
        [Inline]
        public double4 bbga =>  double4(z, z, y, w);
        
        /// <summary>
        /// Returns double4.zzz swizzling.
        /// </summary>
        [Inline]
        public double3 zzz =>  double3(z, z, z);
        
        /// <summary>
        /// Returns double4.bbb swizzling (equivalent to double4.zzz).
        /// </summary>
        [Inline]
        public double3 bbb =>  double3(z, z, z);
        
        /// <summary>
        /// Returns double4.zzzx swizzling.
        /// </summary>
        [Inline]
        public double4 zzzx =>  double4(z, z, z, x);
        
        /// <summary>
        /// Returns double4.bbbr swizzling (equivalent to double4.zzzx).
        /// </summary>
        [Inline]
        public double4 bbbr =>  double4(z, z, z, x);
        
        /// <summary>
        /// Returns double4.zzzy swizzling.
        /// </summary>
        [Inline]
        public double4 zzzy =>  double4(z, z, z, y);
        
        /// <summary>
        /// Returns double4.bbbg swizzling (equivalent to double4.zzzy).
        /// </summary>
        [Inline]
        public double4 bbbg =>  double4(z, z, z, y);
        
        /// <summary>
        /// Returns double4.zzzz swizzling.
        /// </summary>
        [Inline]
        public double4 zzzz =>  double4(z, z, z, z);
        
        /// <summary>
        /// Returns double4.bbbb swizzling (equivalent to double4.zzzz).
        /// </summary>
        [Inline]
        public double4 bbbb =>  double4(z, z, z, z);
        
        /// <summary>
        /// Returns double4.zzzw swizzling.
        /// </summary>
        [Inline]
        public double4 zzzw =>  double4(z, z, z, w);
        
        /// <summary>
        /// Returns double4.bbba swizzling (equivalent to double4.zzzw).
        /// </summary>
        [Inline]
        public double4 bbba =>  double4(z, z, z, w);
        
        /// <summary>
        /// Returns double4.zzw swizzling.
        /// </summary>
        [Inline]
        public double3 zzw =>  double3(z, z, w);
        
        /// <summary>
        /// Returns double4.bba swizzling (equivalent to double4.zzw).
        /// </summary>
        [Inline]
        public double3 bba =>  double3(z, z, w);
        
        /// <summary>
        /// Returns double4.zzwx swizzling.
        /// </summary>
        [Inline]
        public double4 zzwx =>  double4(z, z, w, x);
        
        /// <summary>
        /// Returns double4.bbar swizzling (equivalent to double4.zzwx).
        /// </summary>
        [Inline]
        public double4 bbar =>  double4(z, z, w, x);
        
        /// <summary>
        /// Returns double4.zzwy swizzling.
        /// </summary>
        [Inline]
        public double4 zzwy =>  double4(z, z, w, y);
        
        /// <summary>
        /// Returns double4.bbag swizzling (equivalent to double4.zzwy).
        /// </summary>
        [Inline]
        public double4 bbag =>  double4(z, z, w, y);
        
        /// <summary>
        /// Returns double4.zzwz swizzling.
        /// </summary>
        [Inline]
        public double4 zzwz =>  double4(z, z, w, z);
        
        /// <summary>
        /// Returns double4.bbab swizzling (equivalent to double4.zzwz).
        /// </summary>
        [Inline]
        public double4 bbab =>  double4(z, z, w, z);
        
        /// <summary>
        /// Returns double4.zzww swizzling.
        /// </summary>
        [Inline]
        public double4 zzww =>  double4(z, z, w, w);
        
        /// <summary>
        /// Returns double4.bbaa swizzling (equivalent to double4.zzww).
        /// </summary>
        [Inline]
        public double4 bbaa =>  double4(z, z, w, w);
        
        /// <summary>
        /// Returns double4.zw swizzling.
        /// </summary>
        [Inline]
        public double2 zw =>  double2(z, w);
        
        /// <summary>
        /// Returns double4.ba swizzling (equivalent to double4.zw).
        /// </summary>
        [Inline]
        public double2 ba =>  double2(z, w);
        
        /// <summary>
        /// Returns double4.zwx swizzling.
        /// </summary>
        [Inline]
        public double3 zwx =>  double3(z, w, x);
        
        /// <summary>
        /// Returns double4.bar swizzling (equivalent to double4.zwx).
        /// </summary>
        [Inline]
        public double3 bar =>  double3(z, w, x);
        
        /// <summary>
        /// Returns double4.zwxx swizzling.
        /// </summary>
        [Inline]
        public double4 zwxx =>  double4(z, w, x, x);
        
        /// <summary>
        /// Returns double4.barr swizzling (equivalent to double4.zwxx).
        /// </summary>
        [Inline]
        public double4 barr =>  double4(z, w, x, x);
        
        /// <summary>
        /// Returns double4.zwxy swizzling.
        /// </summary>
        [Inline]
        public double4 zwxy =>  double4(z, w, x, y);
        
        /// <summary>
        /// Returns double4.barg swizzling (equivalent to double4.zwxy).
        /// </summary>
        [Inline]
        public double4 barg =>  double4(z, w, x, y);
        
        /// <summary>
        /// Returns double4.zwxz swizzling.
        /// </summary>
        [Inline]
        public double4 zwxz =>  double4(z, w, x, z);
        
        /// <summary>
        /// Returns double4.barb swizzling (equivalent to double4.zwxz).
        /// </summary>
        [Inline]
        public double4 barb =>  double4(z, w, x, z);
        
        /// <summary>
        /// Returns double4.zwxw swizzling.
        /// </summary>
        [Inline]
        public double4 zwxw =>  double4(z, w, x, w);
        
        /// <summary>
        /// Returns double4.bara swizzling (equivalent to double4.zwxw).
        /// </summary>
        [Inline]
        public double4 bara =>  double4(z, w, x, w);
        
        /// <summary>
        /// Returns double4.zwy swizzling.
        /// </summary>
        [Inline]
        public double3 zwy =>  double3(z, w, y);
        
        /// <summary>
        /// Returns double4.bag swizzling (equivalent to double4.zwy).
        /// </summary>
        [Inline]
        public double3 bag =>  double3(z, w, y);
        
        /// <summary>
        /// Returns double4.zwyx swizzling.
        /// </summary>
        [Inline]
        public double4 zwyx =>  double4(z, w, y, x);
        
        /// <summary>
        /// Returns double4.bagr swizzling (equivalent to double4.zwyx).
        /// </summary>
        [Inline]
        public double4 bagr =>  double4(z, w, y, x);
        
        /// <summary>
        /// Returns double4.zwyy swizzling.
        /// </summary>
        [Inline]
        public double4 zwyy =>  double4(z, w, y, y);
        
        /// <summary>
        /// Returns double4.bagg swizzling (equivalent to double4.zwyy).
        /// </summary>
        [Inline]
        public double4 bagg =>  double4(z, w, y, y);
        
        /// <summary>
        /// Returns double4.zwyz swizzling.
        /// </summary>
        [Inline]
        public double4 zwyz =>  double4(z, w, y, z);
        
        /// <summary>
        /// Returns double4.bagb swizzling (equivalent to double4.zwyz).
        /// </summary>
        [Inline]
        public double4 bagb =>  double4(z, w, y, z);
        
        /// <summary>
        /// Returns double4.zwyw swizzling.
        /// </summary>
        [Inline]
        public double4 zwyw =>  double4(z, w, y, w);
        
        /// <summary>
        /// Returns double4.baga swizzling (equivalent to double4.zwyw).
        /// </summary>
        [Inline]
        public double4 baga =>  double4(z, w, y, w);
        
        /// <summary>
        /// Returns double4.zwz swizzling.
        /// </summary>
        [Inline]
        public double3 zwz =>  double3(z, w, z);
        
        /// <summary>
        /// Returns double4.bab swizzling (equivalent to double4.zwz).
        /// </summary>
        [Inline]
        public double3 bab =>  double3(z, w, z);
        
        /// <summary>
        /// Returns double4.zwzx swizzling.
        /// </summary>
        [Inline]
        public double4 zwzx =>  double4(z, w, z, x);
        
        /// <summary>
        /// Returns double4.babr swizzling (equivalent to double4.zwzx).
        /// </summary>
        [Inline]
        public double4 babr =>  double4(z, w, z, x);
        
        /// <summary>
        /// Returns double4.zwzy swizzling.
        /// </summary>
        [Inline]
        public double4 zwzy =>  double4(z, w, z, y);
        
        /// <summary>
        /// Returns double4.babg swizzling (equivalent to double4.zwzy).
        /// </summary>
        [Inline]
        public double4 babg =>  double4(z, w, z, y);
        
        /// <summary>
        /// Returns double4.zwzz swizzling.
        /// </summary>
        [Inline]
        public double4 zwzz =>  double4(z, w, z, z);
        
        /// <summary>
        /// Returns double4.babb swizzling (equivalent to double4.zwzz).
        /// </summary>
        [Inline]
        public double4 babb =>  double4(z, w, z, z);
        
        /// <summary>
        /// Returns double4.zwzw swizzling.
        /// </summary>
        [Inline]
        public double4 zwzw =>  double4(z, w, z, w);
        
        /// <summary>
        /// Returns double4.baba swizzling (equivalent to double4.zwzw).
        /// </summary>
        [Inline]
        public double4 baba =>  double4(z, w, z, w);
        
        /// <summary>
        /// Returns double4.zww swizzling.
        /// </summary>
        [Inline]
        public double3 zww =>  double3(z, w, w);
        
        /// <summary>
        /// Returns double4.baa swizzling (equivalent to double4.zww).
        /// </summary>
        [Inline]
        public double3 baa =>  double3(z, w, w);
        
        /// <summary>
        /// Returns double4.zwwx swizzling.
        /// </summary>
        [Inline]
        public double4 zwwx =>  double4(z, w, w, x);
        
        /// <summary>
        /// Returns double4.baar swizzling (equivalent to double4.zwwx).
        /// </summary>
        [Inline]
        public double4 baar =>  double4(z, w, w, x);
        
        /// <summary>
        /// Returns double4.zwwy swizzling.
        /// </summary>
        [Inline]
        public double4 zwwy =>  double4(z, w, w, y);
        
        /// <summary>
        /// Returns double4.baag swizzling (equivalent to double4.zwwy).
        /// </summary>
        [Inline]
        public double4 baag =>  double4(z, w, w, y);
        
        /// <summary>
        /// Returns double4.zwwz swizzling.
        /// </summary>
        [Inline]
        public double4 zwwz =>  double4(z, w, w, z);
        
        /// <summary>
        /// Returns double4.baab swizzling (equivalent to double4.zwwz).
        /// </summary>
        [Inline]
        public double4 baab =>  double4(z, w, w, z);
        
        /// <summary>
        /// Returns double4.zwww swizzling.
        /// </summary>
        [Inline]
        public double4 zwww =>  double4(z, w, w, w);
        
        /// <summary>
        /// Returns double4.baaa swizzling (equivalent to double4.zwww).
        /// </summary>
        [Inline]
        public double4 baaa =>  double4(z, w, w, w);
        
        /// <summary>
        /// Returns double4.wx swizzling.
        /// </summary>
        [Inline]
        public double2 wx =>  double2(w, x);
        
        /// <summary>
        /// Returns double4.ar swizzling (equivalent to double4.wx).
        /// </summary>
        [Inline]
        public double2 ar =>  double2(w, x);
        
        /// <summary>
        /// Returns double4.wxx swizzling.
        /// </summary>
        [Inline]
        public double3 wxx =>  double3(w, x, x);
        
        /// <summary>
        /// Returns double4.arr swizzling (equivalent to double4.wxx).
        /// </summary>
        [Inline]
        public double3 arr =>  double3(w, x, x);
        
        /// <summary>
        /// Returns double4.wxxx swizzling.
        /// </summary>
        [Inline]
        public double4 wxxx =>  double4(w, x, x, x);
        
        /// <summary>
        /// Returns double4.arrr swizzling (equivalent to double4.wxxx).
        /// </summary>
        [Inline]
        public double4 arrr =>  double4(w, x, x, x);
        
        /// <summary>
        /// Returns double4.wxxy swizzling.
        /// </summary>
        [Inline]
        public double4 wxxy =>  double4(w, x, x, y);
        
        /// <summary>
        /// Returns double4.arrg swizzling (equivalent to double4.wxxy).
        /// </summary>
        [Inline]
        public double4 arrg =>  double4(w, x, x, y);
        
        /// <summary>
        /// Returns double4.wxxz swizzling.
        /// </summary>
        [Inline]
        public double4 wxxz =>  double4(w, x, x, z);
        
        /// <summary>
        /// Returns double4.arrb swizzling (equivalent to double4.wxxz).
        /// </summary>
        [Inline]
        public double4 arrb =>  double4(w, x, x, z);
        
        /// <summary>
        /// Returns double4.wxxw swizzling.
        /// </summary>
        [Inline]
        public double4 wxxw =>  double4(w, x, x, w);
        
        /// <summary>
        /// Returns double4.arra swizzling (equivalent to double4.wxxw).
        /// </summary>
        [Inline]
        public double4 arra =>  double4(w, x, x, w);
        
        /// <summary>
        /// Returns double4.wxy swizzling.
        /// </summary>
        [Inline]
        public double3 wxy =>  double3(w, x, y);
        
        /// <summary>
        /// Returns double4.arg swizzling (equivalent to double4.wxy).
        /// </summary>
        [Inline]
        public double3 arg =>  double3(w, x, y);
        
        /// <summary>
        /// Returns double4.wxyx swizzling.
        /// </summary>
        [Inline]
        public double4 wxyx =>  double4(w, x, y, x);
        
        /// <summary>
        /// Returns double4.argr swizzling (equivalent to double4.wxyx).
        /// </summary>
        [Inline]
        public double4 argr =>  double4(w, x, y, x);
        
        /// <summary>
        /// Returns double4.wxyy swizzling.
        /// </summary>
        [Inline]
        public double4 wxyy =>  double4(w, x, y, y);
        
        /// <summary>
        /// Returns double4.argg swizzling (equivalent to double4.wxyy).
        /// </summary>
        [Inline]
        public double4 argg =>  double4(w, x, y, y);
        
        /// <summary>
        /// Returns double4.wxyz swizzling.
        /// </summary>
        [Inline]
        public double4 wxyz =>  double4(w, x, y, z);
        
        /// <summary>
        /// Returns double4.argb swizzling (equivalent to double4.wxyz).
        /// </summary>
        [Inline]
        public double4 argb =>  double4(w, x, y, z);
        
        /// <summary>
        /// Returns double4.wxyw swizzling.
        /// </summary>
        [Inline]
        public double4 wxyw =>  double4(w, x, y, w);
        
        /// <summary>
        /// Returns double4.arga swizzling (equivalent to double4.wxyw).
        /// </summary>
        [Inline]
        public double4 arga =>  double4(w, x, y, w);
        
        /// <summary>
        /// Returns double4.wxz swizzling.
        /// </summary>
        [Inline]
        public double3 wxz =>  double3(w, x, z);
        
        /// <summary>
        /// Returns double4.arb swizzling (equivalent to double4.wxz).
        /// </summary>
        [Inline]
        public double3 arb =>  double3(w, x, z);
        
        /// <summary>
        /// Returns double4.wxzx swizzling.
        /// </summary>
        [Inline]
        public double4 wxzx =>  double4(w, x, z, x);
        
        /// <summary>
        /// Returns double4.arbr swizzling (equivalent to double4.wxzx).
        /// </summary>
        [Inline]
        public double4 arbr =>  double4(w, x, z, x);
        
        /// <summary>
        /// Returns double4.wxzy swizzling.
        /// </summary>
        [Inline]
        public double4 wxzy =>  double4(w, x, z, y);
        
        /// <summary>
        /// Returns double4.arbg swizzling (equivalent to double4.wxzy).
        /// </summary>
        [Inline]
        public double4 arbg =>  double4(w, x, z, y);
        
        /// <summary>
        /// Returns double4.wxzz swizzling.
        /// </summary>
        [Inline]
        public double4 wxzz =>  double4(w, x, z, z);
        
        /// <summary>
        /// Returns double4.arbb swizzling (equivalent to double4.wxzz).
        /// </summary>
        [Inline]
        public double4 arbb =>  double4(w, x, z, z);
        
        /// <summary>
        /// Returns double4.wxzw swizzling.
        /// </summary>
        [Inline]
        public double4 wxzw =>  double4(w, x, z, w);
        
        /// <summary>
        /// Returns double4.arba swizzling (equivalent to double4.wxzw).
        /// </summary>
        [Inline]
        public double4 arba =>  double4(w, x, z, w);
        
        /// <summary>
        /// Returns double4.wxw swizzling.
        /// </summary>
        [Inline]
        public double3 wxw =>  double3(w, x, w);
        
        /// <summary>
        /// Returns double4.ara swizzling (equivalent to double4.wxw).
        /// </summary>
        [Inline]
        public double3 ara =>  double3(w, x, w);
        
        /// <summary>
        /// Returns double4.wxwx swizzling.
        /// </summary>
        [Inline]
        public double4 wxwx =>  double4(w, x, w, x);
        
        /// <summary>
        /// Returns double4.arar swizzling (equivalent to double4.wxwx).
        /// </summary>
        [Inline]
        public double4 arar =>  double4(w, x, w, x);
        
        /// <summary>
        /// Returns double4.wxwy swizzling.
        /// </summary>
        [Inline]
        public double4 wxwy =>  double4(w, x, w, y);
        
        /// <summary>
        /// Returns double4.arag swizzling (equivalent to double4.wxwy).
        /// </summary>
        [Inline]
        public double4 arag =>  double4(w, x, w, y);
        
        /// <summary>
        /// Returns double4.wxwz swizzling.
        /// </summary>
        [Inline]
        public double4 wxwz =>  double4(w, x, w, z);
        
        /// <summary>
        /// Returns double4.arab swizzling (equivalent to double4.wxwz).
        /// </summary>
        [Inline]
        public double4 arab =>  double4(w, x, w, z);
        
        /// <summary>
        /// Returns double4.wxww swizzling.
        /// </summary>
        [Inline]
        public double4 wxww =>  double4(w, x, w, w);
        
        /// <summary>
        /// Returns double4.araa swizzling (equivalent to double4.wxww).
        /// </summary>
        [Inline]
        public double4 araa =>  double4(w, x, w, w);
        
        /// <summary>
        /// Returns double4.wy swizzling.
        /// </summary>
        [Inline]
        public double2 wy =>  double2(w, y);
        
        /// <summary>
        /// Returns double4.ag swizzling (equivalent to double4.wy).
        /// </summary>
        [Inline]
        public double2 ag =>  double2(w, y);
        
        /// <summary>
        /// Returns double4.wyx swizzling.
        /// </summary>
        [Inline]
        public double3 wyx =>  double3(w, y, x);
        
        /// <summary>
        /// Returns double4.agr swizzling (equivalent to double4.wyx).
        /// </summary>
        [Inline]
        public double3 agr =>  double3(w, y, x);
        
        /// <summary>
        /// Returns double4.wyxx swizzling.
        /// </summary>
        [Inline]
        public double4 wyxx =>  double4(w, y, x, x);
        
        /// <summary>
        /// Returns double4.agrr swizzling (equivalent to double4.wyxx).
        /// </summary>
        [Inline]
        public double4 agrr =>  double4(w, y, x, x);
        
        /// <summary>
        /// Returns double4.wyxy swizzling.
        /// </summary>
        [Inline]
        public double4 wyxy =>  double4(w, y, x, y);
        
        /// <summary>
        /// Returns double4.agrg swizzling (equivalent to double4.wyxy).
        /// </summary>
        [Inline]
        public double4 agrg =>  double4(w, y, x, y);
        
        /// <summary>
        /// Returns double4.wyxz swizzling.
        /// </summary>
        [Inline]
        public double4 wyxz =>  double4(w, y, x, z);
        
        /// <summary>
        /// Returns double4.agrb swizzling (equivalent to double4.wyxz).
        /// </summary>
        [Inline]
        public double4 agrb =>  double4(w, y, x, z);
        
        /// <summary>
        /// Returns double4.wyxw swizzling.
        /// </summary>
        [Inline]
        public double4 wyxw =>  double4(w, y, x, w);
        
        /// <summary>
        /// Returns double4.agra swizzling (equivalent to double4.wyxw).
        /// </summary>
        [Inline]
        public double4 agra =>  double4(w, y, x, w);
        
        /// <summary>
        /// Returns double4.wyy swizzling.
        /// </summary>
        [Inline]
        public double3 wyy =>  double3(w, y, y);
        
        /// <summary>
        /// Returns double4.agg swizzling (equivalent to double4.wyy).
        /// </summary>
        [Inline]
        public double3 agg =>  double3(w, y, y);
        
        /// <summary>
        /// Returns double4.wyyx swizzling.
        /// </summary>
        [Inline]
        public double4 wyyx =>  double4(w, y, y, x);
        
        /// <summary>
        /// Returns double4.aggr swizzling (equivalent to double4.wyyx).
        /// </summary>
        [Inline]
        public double4 aggr =>  double4(w, y, y, x);
        
        /// <summary>
        /// Returns double4.wyyy swizzling.
        /// </summary>
        [Inline]
        public double4 wyyy =>  double4(w, y, y, y);
        
        /// <summary>
        /// Returns double4.aggg swizzling (equivalent to double4.wyyy).
        /// </summary>
        [Inline]
        public double4 aggg =>  double4(w, y, y, y);
        
        /// <summary>
        /// Returns double4.wyyz swizzling.
        /// </summary>
        [Inline]
        public double4 wyyz =>  double4(w, y, y, z);
        
        /// <summary>
        /// Returns double4.aggb swizzling (equivalent to double4.wyyz).
        /// </summary>
        [Inline]
        public double4 aggb =>  double4(w, y, y, z);
        
        /// <summary>
        /// Returns double4.wyyw swizzling.
        /// </summary>
        [Inline]
        public double4 wyyw =>  double4(w, y, y, w);
        
        /// <summary>
        /// Returns double4.agga swizzling (equivalent to double4.wyyw).
        /// </summary>
        [Inline]
        public double4 agga =>  double4(w, y, y, w);
        
        /// <summary>
        /// Returns double4.wyz swizzling.
        /// </summary>
        [Inline]
        public double3 wyz =>  double3(w, y, z);
        
        /// <summary>
        /// Returns double4.agb swizzling (equivalent to double4.wyz).
        /// </summary>
        [Inline]
        public double3 agb =>  double3(w, y, z);
        
        /// <summary>
        /// Returns double4.wyzx swizzling.
        /// </summary>
        [Inline]
        public double4 wyzx =>  double4(w, y, z, x);
        
        /// <summary>
        /// Returns double4.agbr swizzling (equivalent to double4.wyzx).
        /// </summary>
        [Inline]
        public double4 agbr =>  double4(w, y, z, x);
        
        /// <summary>
        /// Returns double4.wyzy swizzling.
        /// </summary>
        [Inline]
        public double4 wyzy =>  double4(w, y, z, y);
        
        /// <summary>
        /// Returns double4.agbg swizzling (equivalent to double4.wyzy).
        /// </summary>
        [Inline]
        public double4 agbg =>  double4(w, y, z, y);
        
        /// <summary>
        /// Returns double4.wyzz swizzling.
        /// </summary>
        [Inline]
        public double4 wyzz =>  double4(w, y, z, z);
        
        /// <summary>
        /// Returns double4.agbb swizzling (equivalent to double4.wyzz).
        /// </summary>
        [Inline]
        public double4 agbb =>  double4(w, y, z, z);
        
        /// <summary>
        /// Returns double4.wyzw swizzling.
        /// </summary>
        [Inline]
        public double4 wyzw =>  double4(w, y, z, w);
        
        /// <summary>
        /// Returns double4.agba swizzling (equivalent to double4.wyzw).
        /// </summary>
        [Inline]
        public double4 agba =>  double4(w, y, z, w);
        
        /// <summary>
        /// Returns double4.wyw swizzling.
        /// </summary>
        [Inline]
        public double3 wyw =>  double3(w, y, w);
        
        /// <summary>
        /// Returns double4.aga swizzling (equivalent to double4.wyw).
        /// </summary>
        [Inline]
        public double3 aga =>  double3(w, y, w);
        
        /// <summary>
        /// Returns double4.wywx swizzling.
        /// </summary>
        [Inline]
        public double4 wywx =>  double4(w, y, w, x);
        
        /// <summary>
        /// Returns double4.agar swizzling (equivalent to double4.wywx).
        /// </summary>
        [Inline]
        public double4 agar =>  double4(w, y, w, x);
        
        /// <summary>
        /// Returns double4.wywy swizzling.
        /// </summary>
        [Inline]
        public double4 wywy =>  double4(w, y, w, y);
        
        /// <summary>
        /// Returns double4.agag swizzling (equivalent to double4.wywy).
        /// </summary>
        [Inline]
        public double4 agag =>  double4(w, y, w, y);
        
        /// <summary>
        /// Returns double4.wywz swizzling.
        /// </summary>
        [Inline]
        public double4 wywz =>  double4(w, y, w, z);
        
        /// <summary>
        /// Returns double4.agab swizzling (equivalent to double4.wywz).
        /// </summary>
        [Inline]
        public double4 agab =>  double4(w, y, w, z);
        
        /// <summary>
        /// Returns double4.wyww swizzling.
        /// </summary>
        [Inline]
        public double4 wyww =>  double4(w, y, w, w);
        
        /// <summary>
        /// Returns double4.agaa swizzling (equivalent to double4.wyww).
        /// </summary>
        [Inline]
        public double4 agaa =>  double4(w, y, w, w);
        
        /// <summary>
        /// Returns double4.wz swizzling.
        /// </summary>
        [Inline]
        public double2 wz =>  double2(w, z);
        
        /// <summary>
        /// Returns double4.ab swizzling (equivalent to double4.wz).
        /// </summary>
        [Inline]
        public double2 ab =>  double2(w, z);
        
        /// <summary>
        /// Returns double4.wzx swizzling.
        /// </summary>
        [Inline]
        public double3 wzx =>  double3(w, z, x);
        
        /// <summary>
        /// Returns double4.abr swizzling (equivalent to double4.wzx).
        /// </summary>
        [Inline]
        public double3 abr =>  double3(w, z, x);
        
        /// <summary>
        /// Returns double4.wzxx swizzling.
        /// </summary>
        [Inline]
        public double4 wzxx =>  double4(w, z, x, x);
        
        /// <summary>
        /// Returns double4.abrr swizzling (equivalent to double4.wzxx).
        /// </summary>
        [Inline]
        public double4 abrr =>  double4(w, z, x, x);
        
        /// <summary>
        /// Returns double4.wzxy swizzling.
        /// </summary>
        [Inline]
        public double4 wzxy =>  double4(w, z, x, y);
        
        /// <summary>
        /// Returns double4.abrg swizzling (equivalent to double4.wzxy).
        /// </summary>
        [Inline]
        public double4 abrg =>  double4(w, z, x, y);
        
        /// <summary>
        /// Returns double4.wzxz swizzling.
        /// </summary>
        [Inline]
        public double4 wzxz =>  double4(w, z, x, z);
        
        /// <summary>
        /// Returns double4.abrb swizzling (equivalent to double4.wzxz).
        /// </summary>
        [Inline]
        public double4 abrb =>  double4(w, z, x, z);
        
        /// <summary>
        /// Returns double4.wzxw swizzling.
        /// </summary>
        [Inline]
        public double4 wzxw =>  double4(w, z, x, w);
        
        /// <summary>
        /// Returns double4.abra swizzling (equivalent to double4.wzxw).
        /// </summary>
        [Inline]
        public double4 abra =>  double4(w, z, x, w);
        
        /// <summary>
        /// Returns double4.wzy swizzling.
        /// </summary>
        [Inline]
        public double3 wzy =>  double3(w, z, y);
        
        /// <summary>
        /// Returns double4.abg swizzling (equivalent to double4.wzy).
        /// </summary>
        [Inline]
        public double3 abg =>  double3(w, z, y);
        
        /// <summary>
        /// Returns double4.wzyx swizzling.
        /// </summary>
        [Inline]
        public double4 wzyx =>  double4(w, z, y, x);
        
        /// <summary>
        /// Returns double4.abgr swizzling (equivalent to double4.wzyx).
        /// </summary>
        [Inline]
        public double4 abgr =>  double4(w, z, y, x);
        
        /// <summary>
        /// Returns double4.wzyy swizzling.
        /// </summary>
        [Inline]
        public double4 wzyy =>  double4(w, z, y, y);
        
        /// <summary>
        /// Returns double4.abgg swizzling (equivalent to double4.wzyy).
        /// </summary>
        [Inline]
        public double4 abgg =>  double4(w, z, y, y);
        
        /// <summary>
        /// Returns double4.wzyz swizzling.
        /// </summary>
        [Inline]
        public double4 wzyz =>  double4(w, z, y, z);
        
        /// <summary>
        /// Returns double4.abgb swizzling (equivalent to double4.wzyz).
        /// </summary>
        [Inline]
        public double4 abgb =>  double4(w, z, y, z);
        
        /// <summary>
        /// Returns double4.wzyw swizzling.
        /// </summary>
        [Inline]
        public double4 wzyw =>  double4(w, z, y, w);
        
        /// <summary>
        /// Returns double4.abga swizzling (equivalent to double4.wzyw).
        /// </summary>
        [Inline]
        public double4 abga =>  double4(w, z, y, w);
        
        /// <summary>
        /// Returns double4.wzz swizzling.
        /// </summary>
        [Inline]
        public double3 wzz =>  double3(w, z, z);
        
        /// <summary>
        /// Returns double4.abb swizzling (equivalent to double4.wzz).
        /// </summary>
        [Inline]
        public double3 abb =>  double3(w, z, z);
        
        /// <summary>
        /// Returns double4.wzzx swizzling.
        /// </summary>
        [Inline]
        public double4 wzzx =>  double4(w, z, z, x);
        
        /// <summary>
        /// Returns double4.abbr swizzling (equivalent to double4.wzzx).
        /// </summary>
        [Inline]
        public double4 abbr =>  double4(w, z, z, x);
        
        /// <summary>
        /// Returns double4.wzzy swizzling.
        /// </summary>
        [Inline]
        public double4 wzzy =>  double4(w, z, z, y);
        
        /// <summary>
        /// Returns double4.abbg swizzling (equivalent to double4.wzzy).
        /// </summary>
        [Inline]
        public double4 abbg =>  double4(w, z, z, y);
        
        /// <summary>
        /// Returns double4.wzzz swizzling.
        /// </summary>
        [Inline]
        public double4 wzzz =>  double4(w, z, z, z);
        
        /// <summary>
        /// Returns double4.abbb swizzling (equivalent to double4.wzzz).
        /// </summary>
        [Inline]
        public double4 abbb =>  double4(w, z, z, z);
        
        /// <summary>
        /// Returns double4.wzzw swizzling.
        /// </summary>
        [Inline]
        public double4 wzzw =>  double4(w, z, z, w);
        
        /// <summary>
        /// Returns double4.abba swizzling (equivalent to double4.wzzw).
        /// </summary>
        [Inline]
        public double4 abba =>  double4(w, z, z, w);
        
        /// <summary>
        /// Returns double4.wzw swizzling.
        /// </summary>
        [Inline]
        public double3 wzw =>  double3(w, z, w);
        
        /// <summary>
        /// Returns double4.aba swizzling (equivalent to double4.wzw).
        /// </summary>
        [Inline]
        public double3 aba =>  double3(w, z, w);
        
        /// <summary>
        /// Returns double4.wzwx swizzling.
        /// </summary>
        [Inline]
        public double4 wzwx =>  double4(w, z, w, x);
        
        /// <summary>
        /// Returns double4.abar swizzling (equivalent to double4.wzwx).
        /// </summary>
        [Inline]
        public double4 abar =>  double4(w, z, w, x);
        
        /// <summary>
        /// Returns double4.wzwy swizzling.
        /// </summary>
        [Inline]
        public double4 wzwy =>  double4(w, z, w, y);
        
        /// <summary>
        /// Returns double4.abag swizzling (equivalent to double4.wzwy).
        /// </summary>
        [Inline]
        public double4 abag =>  double4(w, z, w, y);
        
        /// <summary>
        /// Returns double4.wzwz swizzling.
        /// </summary>
        [Inline]
        public double4 wzwz =>  double4(w, z, w, z);
        
        /// <summary>
        /// Returns double4.abab swizzling (equivalent to double4.wzwz).
        /// </summary>
        [Inline]
        public double4 abab =>  double4(w, z, w, z);
        
        /// <summary>
        /// Returns double4.wzww swizzling.
        /// </summary>
        [Inline]
        public double4 wzww =>  double4(w, z, w, w);
        
        /// <summary>
        /// Returns double4.abaa swizzling (equivalent to double4.wzww).
        /// </summary>
        [Inline]
        public double4 abaa =>  double4(w, z, w, w);
        
        /// <summary>
        /// Returns double4.ww swizzling.
        /// </summary>
        [Inline]
        public double2 ww =>  double2(w, w);
        
        /// <summary>
        /// Returns double4.aa swizzling (equivalent to double4.ww).
        /// </summary>
        [Inline]
        public double2 aa =>  double2(w, w);
        
        /// <summary>
        /// Returns double4.wwx swizzling.
        /// </summary>
        [Inline]
        public double3 wwx =>  double3(w, w, x);
        
        /// <summary>
        /// Returns double4.aar swizzling (equivalent to double4.wwx).
        /// </summary>
        [Inline]
        public double3 aar =>  double3(w, w, x);
        
        /// <summary>
        /// Returns double4.wwxx swizzling.
        /// </summary>
        [Inline]
        public double4 wwxx =>  double4(w, w, x, x);
        
        /// <summary>
        /// Returns double4.aarr swizzling (equivalent to double4.wwxx).
        /// </summary>
        [Inline]
        public double4 aarr =>  double4(w, w, x, x);
        
        /// <summary>
        /// Returns double4.wwxy swizzling.
        /// </summary>
        [Inline]
        public double4 wwxy =>  double4(w, w, x, y);
        
        /// <summary>
        /// Returns double4.aarg swizzling (equivalent to double4.wwxy).
        /// </summary>
        [Inline]
        public double4 aarg =>  double4(w, w, x, y);
        
        /// <summary>
        /// Returns double4.wwxz swizzling.
        /// </summary>
        [Inline]
        public double4 wwxz =>  double4(w, w, x, z);
        
        /// <summary>
        /// Returns double4.aarb swizzling (equivalent to double4.wwxz).
        /// </summary>
        [Inline]
        public double4 aarb =>  double4(w, w, x, z);
        
        /// <summary>
        /// Returns double4.wwxw swizzling.
        /// </summary>
        [Inline]
        public double4 wwxw =>  double4(w, w, x, w);
        
        /// <summary>
        /// Returns double4.aara swizzling (equivalent to double4.wwxw).
        /// </summary>
        [Inline]
        public double4 aara =>  double4(w, w, x, w);
        
        /// <summary>
        /// Returns double4.wwy swizzling.
        /// </summary>
        [Inline]
        public double3 wwy =>  double3(w, w, y);
        
        /// <summary>
        /// Returns double4.aag swizzling (equivalent to double4.wwy).
        /// </summary>
        [Inline]
        public double3 aag =>  double3(w, w, y);
        
        /// <summary>
        /// Returns double4.wwyx swizzling.
        /// </summary>
        [Inline]
        public double4 wwyx =>  double4(w, w, y, x);
        
        /// <summary>
        /// Returns double4.aagr swizzling (equivalent to double4.wwyx).
        /// </summary>
        [Inline]
        public double4 aagr =>  double4(w, w, y, x);
        
        /// <summary>
        /// Returns double4.wwyy swizzling.
        /// </summary>
        [Inline]
        public double4 wwyy =>  double4(w, w, y, y);
        
        /// <summary>
        /// Returns double4.aagg swizzling (equivalent to double4.wwyy).
        /// </summary>
        [Inline]
        public double4 aagg =>  double4(w, w, y, y);
        
        /// <summary>
        /// Returns double4.wwyz swizzling.
        /// </summary>
        [Inline]
        public double4 wwyz =>  double4(w, w, y, z);
        
        /// <summary>
        /// Returns double4.aagb swizzling (equivalent to double4.wwyz).
        /// </summary>
        [Inline]
        public double4 aagb =>  double4(w, w, y, z);
        
        /// <summary>
        /// Returns double4.wwyw swizzling.
        /// </summary>
        [Inline]
        public double4 wwyw =>  double4(w, w, y, w);
        
        /// <summary>
        /// Returns double4.aaga swizzling (equivalent to double4.wwyw).
        /// </summary>
        [Inline]
        public double4 aaga =>  double4(w, w, y, w);
        
        /// <summary>
        /// Returns double4.wwz swizzling.
        /// </summary>
        [Inline]
        public double3 wwz =>  double3(w, w, z);
        
        /// <summary>
        /// Returns double4.aab swizzling (equivalent to double4.wwz).
        /// </summary>
        [Inline]
        public double3 aab =>  double3(w, w, z);
        
        /// <summary>
        /// Returns double4.wwzx swizzling.
        /// </summary>
        [Inline]
        public double4 wwzx =>  double4(w, w, z, x);
        
        /// <summary>
        /// Returns double4.aabr swizzling (equivalent to double4.wwzx).
        /// </summary>
        [Inline]
        public double4 aabr =>  double4(w, w, z, x);
        
        /// <summary>
        /// Returns double4.wwzy swizzling.
        /// </summary>
        [Inline]
        public double4 wwzy =>  double4(w, w, z, y);
        
        /// <summary>
        /// Returns double4.aabg swizzling (equivalent to double4.wwzy).
        /// </summary>
        [Inline]
        public double4 aabg =>  double4(w, w, z, y);
        
        /// <summary>
        /// Returns double4.wwzz swizzling.
        /// </summary>
        [Inline]
        public double4 wwzz =>  double4(w, w, z, z);
        
        /// <summary>
        /// Returns double4.aabb swizzling (equivalent to double4.wwzz).
        /// </summary>
        [Inline]
        public double4 aabb =>  double4(w, w, z, z);
        
        /// <summary>
        /// Returns double4.wwzw swizzling.
        /// </summary>
        [Inline]
        public double4 wwzw =>  double4(w, w, z, w);
        
        /// <summary>
        /// Returns double4.aaba swizzling (equivalent to double4.wwzw).
        /// </summary>
        [Inline]
        public double4 aaba =>  double4(w, w, z, w);
        
        /// <summary>
        /// Returns double4.www swizzling.
        /// </summary>
        [Inline]
        public double3 www =>  double3(w, w, w);
        
        /// <summary>
        /// Returns double4.aaa swizzling (equivalent to double4.www).
        /// </summary>
        [Inline]
        public double3 aaa =>  double3(w, w, w);
        
        /// <summary>
        /// Returns double4.wwwx swizzling.
        /// </summary>
        [Inline]
        public double4 wwwx =>  double4(w, w, w, x);
        
        /// <summary>
        /// Returns double4.aaar swizzling (equivalent to double4.wwwx).
        /// </summary>
        [Inline]
        public double4 aaar =>  double4(w, w, w, x);
        
        /// <summary>
        /// Returns double4.wwwy swizzling.
        /// </summary>
        [Inline]
        public double4 wwwy =>  double4(w, w, w, y);
        
        /// <summary>
        /// Returns double4.aaag swizzling (equivalent to double4.wwwy).
        /// </summary>
        [Inline]
        public double4 aaag =>  double4(w, w, w, y);
        
        /// <summary>
        /// Returns double4.wwwz swizzling.
        /// </summary>
        [Inline]
        public double4 wwwz =>  double4(w, w, w, z);
        
        /// <summary>
        /// Returns double4.aaab swizzling (equivalent to double4.wwwz).
        /// </summary>
        [Inline]
        public double4 aaab =>  double4(w, w, w, z);
        
        /// <summary>
        /// Returns double4.wwww swizzling.
        /// </summary>
        [Inline]
        public double4 wwww =>  double4(w, w, w, w);
        
        /// <summary>
        /// Returns double4.aaaa swizzling (equivalent to double4.wwww).
        /// </summary>
        [Inline]
        public double4 aaaa =>  double4(w, w, w, w);

        //#endregion

    }
}
