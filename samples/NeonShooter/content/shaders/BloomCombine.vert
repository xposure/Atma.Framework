#version 330
uniform mat4 u_matrix;
layout(location=0) in vec2 a_position;
layout(location=1) in vec2 a_tex;
out vec2 v_tex;

void main(void)
{
    gl_Position = u_matrix * vec4(a_position.xy, 0, 1);
    v_tex = a_tex;
}
