#ifdef GL_ES
precision mediump float;
#endif
uniform vec2 u_resolution;
uniform float u_time;

void main()
{
    vec2 coord =25.0*gl_FragCoord.xy/u_resolution;

    vec3 color=vec3(0);
    for(int i = 0;i<8;++i)
    {
        coord +=vec2(sin(coord.y+u_time),cos(coord.x+0.32*coord.y+u_time)+0.21);
    }
    color+=vec3(sin(coord.x+u_time*12.0)+1.34,cos(coord.y+4.0*u_time)+0.81,u_time*sin(coord.x)+1.82);
    gl_FragColor = vec4(color,1.0);
}