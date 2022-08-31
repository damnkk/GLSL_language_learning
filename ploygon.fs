#ifdef GL_ES
precision mediump float;
#endif

const float PI = 3.1415926535;
uniform vec2 u_resolution;
float ply(vec2 position, float radius, float sides){
    position = position*2.0-1.0;//有点像屏幕坐标变换到NDC坐标
    float angle = atan(position.x,position.y);//这样片段坐标又有了一个角度关系
    float slice = PI *2.0/sides;//根据边数,把360度等分,可以看作是边数个档位
    //计算当前夹角和所属档位的夹角,用这个去求余弦,得到长度,和半径相比较
    return step(radius,cos(floor(0.5+angle/slice)*slice-angle)*length(position));
}
void main()
{
    vec2 position = gl_FragCoord.xy/u_resolution;

    vec3 color = vec3(0.0);
    color = vec3(1.0,0.8,0)*vec3(ply(position,0.5,5.0));
    gl_FragColor = vec4(color,1.0);
}