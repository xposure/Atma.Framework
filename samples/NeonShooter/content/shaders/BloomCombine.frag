#version 330
uniform sampler2D u_texture;
uniform sampler2D u_bloom;

uniform float BloomIntensity;
uniform float BaseIntensity;
uniform float BloomSaturation;
uniform float BaseSaturation;

in vec2 v_tex;
out vec4 o_color;

vec4 AdjustSaturation(vec4 color, float saturation)
{
    // The constants 0.3, 0.59, and 0.11 are chosen because the
    // human eye is more sensitive to green light, and less to blue.
    float grey = dot(color.xyz, vec3(0.3, 0.59, 0.11));
 
    return vec4(mix(vec3(grey), color.xyz, saturation), 1);
}

vec4 saturate(vec4 color)
{
    return clamp(color, 0.0f, 1.0f);
}

void main(void)
{    

    // Look up the bloom and original base image colors.
    vec4 base = texture(u_texture, v_tex);
    vec4 bloom = texture(u_bloom, v_tex);
 
    // Adjust color saturation and intensity.
    bloom = AdjustSaturation(bloom, BloomSaturation) * BloomIntensity;
    base = AdjustSaturation(base, BaseSaturation) * BaseIntensity;
 
    // Darken down the base image in areas where there is a lot of bloom,
    // to prevent things looking excessively burned-out.
    base *= (1 - saturate(bloom));
 
    // Combine the two images.
    o_color = base + bloom;

}