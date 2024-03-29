
/*

    实现类似 木星的 湍流效果

*/
float N21(vec2 p){
    float v  = dot(p,vec2(123.2,45.1));
    return fract(sin(v)*438.545312);
}


float Noise(vec2 p){
    vec2 f = fract(p);
    vec2 id = floor(p);
    float a = N21(id);
    float b = N21(id + vec2(1.,0.));
    float c = N21(id + vec2(0.,1.));
    float d = N21(id + vec2(1.,1.));
    f = smoothstep(vec2(0.0),vec2(1.0),f);
    return mix(mix(a,b,f.x),mix(c,d,f.x),f.y);
}


float fbm(vec2 p){
    float n = Noise(p*4.-vec2(iTime*0.1,0));
    n += Noise(p*8.+vec2(iTime*0.3,0))*0.5;
    n+= Noise(p*16.-vec2(iTime*0.5,0))*0.25;
	n+= Noise(p*32.+vec2(iTime*0.8,0))*0.125;
    n+= Noise(p*62.-vec2(iTime*2.,0))*0.0625;
    return (n/2.);
}


mat2 rot(float a)
{
    float c = cos(a),s = sin(a);
    return mat2(c,-s,s,c);
}


const float pi = 3.1415926;



void mainImage( out vec4 fragColor, in vec2 fragCoord )
{
    // Normalized pixel coordinates (from 0 to 1)
    vec2 uv = fragCoord/iResolution.y;

    float l1 = fbm(uv+1.);
    float l2 = fbm(rot(pi/2.)*uv+l1);
    
    float l3 = fbm(uv+vec2(l1,l2));
    
    vec3 col = vec3(0.);
    col = mix(vec3(1.),vec3(0.985,0.800,0.714),1.-l1);
    col = mix(col,vec3(1.30,.009,0.047),l2);
	col = mix(col,vec3(0.1,0.1,0.1),l3);

    // Output to screen
    fragColor = vec4(col,1.0);
}


