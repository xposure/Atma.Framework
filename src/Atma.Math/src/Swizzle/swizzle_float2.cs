using System;
namespace Atma
{
    
    /// <summary>
    /// Temporary vector of type float with 2 components, used for implementing swizzling for float2.
    /// </summary>
    public struct swizzle_float2
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

        //#endregion


        //#region Properties
        
        /// <summary>
        /// Returns float2.xx swizzling.
        /// </summary>
        [Inline]
        public float2 xx =>  float2(x, x);
        
        /// <summary>
        /// Returns float2.rr swizzling (equivalent to float2.xx).
        /// </summary>
        [Inline]
        public float2 rr =>  float2(x, x);
        
        /// <summary>
        /// Returns float2.xxx swizzling.
        /// </summary>
        [Inline]
        public float3 xxx =>  float3(x, x, x);
        
        /// <summary>
        /// Returns float2.rrr swizzling (equivalent to float2.xxx).
        /// </summary>
        [Inline]
        public float3 rrr =>  float3(x, x, x);
        
        /// <summary>
        /// Returns float2.xxxx swizzling.
        /// </summary>
        [Inline]
        public float4 xxxx =>  float4(x, x, x, x);
        
        /// <summary>
        /// Returns float2.rrrr swizzling (equivalent to float2.xxxx).
        /// </summary>
        [Inline]
        public float4 rrrr =>  float4(x, x, x, x);
        
        /// <summary>
        /// Returns float2.xxxy swizzling.
        /// </summary>
        [Inline]
        public float4 xxxy =>  float4(x, x, x, y);
        
        /// <summary>
        /// Returns float2.rrrg swizzling (equivalent to float2.xxxy).
        /// </summary>
        [Inline]
        public float4 rrrg =>  float4(x, x, x, y);
        
        /// <summary>
        /// Returns float2.xxy swizzling.
        /// </summary>
        [Inline]
        public float3 xxy =>  float3(x, x, y);
        
        /// <summary>
        /// Returns float2.rrg swizzling (equivalent to float2.xxy).
        /// </summary>
        [Inline]
        public float3 rrg =>  float3(x, x, y);
        
        /// <summary>
        /// Returns float2.xxyx swizzling.
        /// </summary>
        [Inline]
        public float4 xxyx =>  float4(x, x, y, x);
        
        /// <summary>
        /// Returns float2.rrgr swizzling (equivalent to float2.xxyx).
        /// </summary>
        [Inline]
        public float4 rrgr =>  float4(x, x, y, x);
        
        /// <summary>
        /// Returns float2.xxyy swizzling.
        /// </summary>
        [Inline]
        public float4 xxyy =>  float4(x, x, y, y);
        
        /// <summary>
        /// Returns float2.rrgg swizzling (equivalent to float2.xxyy).
        /// </summary>
        [Inline]
        public float4 rrgg =>  float4(x, x, y, y);
        
        /// <summary>
        /// Returns float2.xy swizzling.
        /// </summary>
        [Inline]
        public float2 xy =>  float2(x, y);
        
        /// <summary>
        /// Returns float2.rg swizzling (equivalent to float2.xy).
        /// </summary>
        [Inline]
        public float2 rg =>  float2(x, y);
        
        /// <summary>
        /// Returns float2.xyx swizzling.
        /// </summary>
        [Inline]
        public float3 xyx =>  float3(x, y, x);
        
        /// <summary>
        /// Returns float2.rgr swizzling (equivalent to float2.xyx).
        /// </summary>
        [Inline]
        public float3 rgr =>  float3(x, y, x);
        
        /// <summary>
        /// Returns float2.xyxx swizzling.
        /// </summary>
        [Inline]
        public float4 xyxx =>  float4(x, y, x, x);
        
        /// <summary>
        /// Returns float2.rgrr swizzling (equivalent to float2.xyxx).
        /// </summary>
        [Inline]
        public float4 rgrr =>  float4(x, y, x, x);
        
        /// <summary>
        /// Returns float2.xyxy swizzling.
        /// </summary>
        [Inline]
        public float4 xyxy =>  float4(x, y, x, y);
        
        /// <summary>
        /// Returns float2.rgrg swizzling (equivalent to float2.xyxy).
        /// </summary>
        [Inline]
        public float4 rgrg =>  float4(x, y, x, y);
        
        /// <summary>
        /// Returns float2.xyy swizzling.
        /// </summary>
        [Inline]
        public float3 xyy =>  float3(x, y, y);
        
        /// <summary>
        /// Returns float2.rgg swizzling (equivalent to float2.xyy).
        /// </summary>
        [Inline]
        public float3 rgg =>  float3(x, y, y);
        
        /// <summary>
        /// Returns float2.xyyx swizzling.
        /// </summary>
        [Inline]
        public float4 xyyx =>  float4(x, y, y, x);
        
        /// <summary>
        /// Returns float2.rggr swizzling (equivalent to float2.xyyx).
        /// </summary>
        [Inline]
        public float4 rggr =>  float4(x, y, y, x);
        
        /// <summary>
        /// Returns float2.xyyy swizzling.
        /// </summary>
        [Inline]
        public float4 xyyy =>  float4(x, y, y, y);
        
        /// <summary>
        /// Returns float2.rggg swizzling (equivalent to float2.xyyy).
        /// </summary>
        [Inline]
        public float4 rggg =>  float4(x, y, y, y);
        
        /// <summary>
        /// Returns float2.yx swizzling.
        /// </summary>
        [Inline]
        public float2 yx =>  float2(y, x);
        
        /// <summary>
        /// Returns float2.gr swizzling (equivalent to float2.yx).
        /// </summary>
        [Inline]
        public float2 gr =>  float2(y, x);
        
        /// <summary>
        /// Returns float2.yxx swizzling.
        /// </summary>
        [Inline]
        public float3 yxx =>  float3(y, x, x);
        
        /// <summary>
        /// Returns float2.grr swizzling (equivalent to float2.yxx).
        /// </summary>
        [Inline]
        public float3 grr =>  float3(y, x, x);
        
        /// <summary>
        /// Returns float2.yxxx swizzling.
        /// </summary>
        [Inline]
        public float4 yxxx =>  float4(y, x, x, x);
        
        /// <summary>
        /// Returns float2.grrr swizzling (equivalent to float2.yxxx).
        /// </summary>
        [Inline]
        public float4 grrr =>  float4(y, x, x, x);
        
        /// <summary>
        /// Returns float2.yxxy swizzling.
        /// </summary>
        [Inline]
        public float4 yxxy =>  float4(y, x, x, y);
        
        /// <summary>
        /// Returns float2.grrg swizzling (equivalent to float2.yxxy).
        /// </summary>
        [Inline]
        public float4 grrg =>  float4(y, x, x, y);
        
        /// <summary>
        /// Returns float2.yxy swizzling.
        /// </summary>
        [Inline]
        public float3 yxy =>  float3(y, x, y);
        
        /// <summary>
        /// Returns float2.grg swizzling (equivalent to float2.yxy).
        /// </summary>
        [Inline]
        public float3 grg =>  float3(y, x, y);
        
        /// <summary>
        /// Returns float2.yxyx swizzling.
        /// </summary>
        [Inline]
        public float4 yxyx =>  float4(y, x, y, x);
        
        /// <summary>
        /// Returns float2.grgr swizzling (equivalent to float2.yxyx).
        /// </summary>
        [Inline]
        public float4 grgr =>  float4(y, x, y, x);
        
        /// <summary>
        /// Returns float2.yxyy swizzling.
        /// </summary>
        [Inline]
        public float4 yxyy =>  float4(y, x, y, y);
        
        /// <summary>
        /// Returns float2.grgg swizzling (equivalent to float2.yxyy).
        /// </summary>
        [Inline]
        public float4 grgg =>  float4(y, x, y, y);
        
        /// <summary>
        /// Returns float2.yy swizzling.
        /// </summary>
        [Inline]
        public float2 yy =>  float2(y, y);
        
        /// <summary>
        /// Returns float2.gg swizzling (equivalent to float2.yy).
        /// </summary>
        [Inline]
        public float2 gg =>  float2(y, y);
        
        /// <summary>
        /// Returns float2.yyx swizzling.
        /// </summary>
        [Inline]
        public float3 yyx =>  float3(y, y, x);
        
        /// <summary>
        /// Returns float2.ggr swizzling (equivalent to float2.yyx).
        /// </summary>
        [Inline]
        public float3 ggr =>  float3(y, y, x);
        
        /// <summary>
        /// Returns float2.yyxx swizzling.
        /// </summary>
        [Inline]
        public float4 yyxx =>  float4(y, y, x, x);
        
        /// <summary>
        /// Returns float2.ggrr swizzling (equivalent to float2.yyxx).
        /// </summary>
        [Inline]
        public float4 ggrr =>  float4(y, y, x, x);
        
        /// <summary>
        /// Returns float2.yyxy swizzling.
        /// </summary>
        [Inline]
        public float4 yyxy =>  float4(y, y, x, y);
        
        /// <summary>
        /// Returns float2.ggrg swizzling (equivalent to float2.yyxy).
        /// </summary>
        [Inline]
        public float4 ggrg =>  float4(y, y, x, y);
        
        /// <summary>
        /// Returns float2.yyy swizzling.
        /// </summary>
        [Inline]
        public float3 yyy =>  float3(y, y, y);
        
        /// <summary>
        /// Returns float2.ggg swizzling (equivalent to float2.yyy).
        /// </summary>
        [Inline]
        public float3 ggg =>  float3(y, y, y);
        
        /// <summary>
        /// Returns float2.yyyx swizzling.
        /// </summary>
        [Inline]
        public float4 yyyx =>  float4(y, y, y, x);
        
        /// <summary>
        /// Returns float2.gggr swizzling (equivalent to float2.yyyx).
        /// </summary>
        [Inline]
        public float4 gggr =>  float4(y, y, y, x);
        
        /// <summary>
        /// Returns float2.yyyy swizzling.
        /// </summary>
        [Inline]
        public float4 yyyy =>  float4(y, y, y, y);
        
        /// <summary>
        /// Returns float2.gggg swizzling (equivalent to float2.yyyy).
        /// </summary>
        [Inline]
        public float4 gggg =>  float4(y, y, y, y);

        //#endregion

    }
}
