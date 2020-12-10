#version 330
#define SAMPLE_COUNT 15

uniform sampler2D u_texture;
 
uniform vec2 u_sampleOffsets[SAMPLE_COUNT];
uniform float u_sampleWeights[SAMPLE_COUNT];

in vec2 v_tex;
out vec4 o_color;

void main(void)
{
    vec4 c = vec4(0,0,0,0);
    // Combine a number of weighted image filter taps.
    for (int i = 0; i < SAMPLE_COUNT; i++)
    {
        c += texture(u_texture, v_tex + u_sampleOffsets[i]) * u_sampleWeights[i];
    }
 
    o_color = c;
}