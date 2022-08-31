#ifdef GL_ES 
precision mediump float;
#endif
uniform vec2 u_resolution;

float circleShape(vec2 position,float radius)
{//这里使用了一个阶跃函函数step,比较两个参数的大小,小了返回0,大了返回1
//这里比较的一个是半径,一个是根据片元位置得到的向量,而片元位置是以左下角为起始点的,因此
//画出来是在屏幕左下角的1/4圆,我们将片元位置和屏幕中心位置相减,使得片元位置和屏幕中心点
//建立一种关系,就可以在屏幕中间画圆了
    return step(radius,length(position-vec2(0.5)));
}

void main()
{
    vec2 position = gl_FragCoord.xy/u_resolution;
    vec3 color = vec3(0.0);
    float circle = circleShape(position,0.2);
    color = vec3(circle);
    gl_FragColor = vec4(color,1.0);
}