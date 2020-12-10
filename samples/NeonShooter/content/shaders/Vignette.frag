#version 330
uniform sampler2D u_texture;
uniform float u_power ;
uniform float u_radius ;
uniform vec2 u_resolution;

in vec2 v_tex;
out vec4 o_color;
void main(void)
{
    	vec2 uv = gl_FragCoord.xy / u_resolution;
   
        uv *=  1.0 - uv.yx;
        
        float vig = uv.x*uv.y * u_power; // multiply with sth for intensity
        float t = 1 - pow(vig, u_radius); // change pow for modifying the extend of the  vignette

        vec4 tcolor = texture(u_texture, v_tex);
        vec4 vcolor = vec4(0,0,0,1);

        o_color = mix(tcolor, vcolor, t);
}