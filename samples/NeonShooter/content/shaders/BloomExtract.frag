#version 330
uniform sampler2D u_texture;
uniform float u_bloomThreshold;

in vec2 v_tex;
out vec4 o_color;

vec4 saturate(vec4 color)
{
    return clamp(color, 0.0f, 1.0f);
}

void main(void)
{    
    vec2 tex = vec2(v_tex.x,  v_tex.y);
    vec4 color = texture(u_texture, tex);
    
    // Adjust it to keep only values brighter than the specified threshold.
    o_color = saturate((color - u_bloomThreshold) / (1 - u_bloomThreshold));
}