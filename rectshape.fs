#ifdef GL_ES 
precision mediump float;
#endif

uniform vec2 u_resolution;

float rectshape(vec2 position ,vec2 scale)
{
    /*
    这个函数相当于先把宽高分成两半,这样根据屏幕中点先画半个矩形,然后再画另外半个矩形,另外半个矩形的时候,
    x和y都要反转,而矩形内外的判定其实也很容易,还是使用step函数,这时因为是一个包围结构,因此要保证当前片
    段位置处于矩形边的同一边才能显示,我们在这里使用向量相乘来实现或运算。
    */
    scale  = vec2(0.5)-scale*0.5;
    vec2 shaper = vec2(step(scale.x ,position.x),step(scale.y,position.y));
    shaper *=vec2(step(scale.x,1.0-position.x),step(scale.y,1.0- position.y));
    return shaper.x*shaper.y;
}


void main()
{
    vec2 position = gl_FragCoord.xy/u_resolution;
    vec3 color = vec3(0.0);
    float rectangle = rectshape(position,vec2(0.3,0.6));
    color= vec3(rectangle);
    gl_FragColor = vec4(color,1.0);
}