// Trying to make some kind of 'Soapy Bubble' like:
// http://static1.squarespace.com/static/50bd1127e4b035a0352e9061/5190ad8be4b0f18fde0fb526/5190ad8de4b0d1dfab8143c7/1368436110791/BubbleDev_001_0011.jpg
#define MINDIST  0.001


// 虹彩
vec3 iridescent( in float ramp_p )	// https://www.itp.uni-hannover.de/~zawischa/ITP/bilder/chitin1S.png
{
    ramp_p = fract(ramp_p);	// Wrap values 0-1
    vec3 col0, col1;
    
    if( ramp_p < 0.05 )
    {col0 = vec3(0.33, 0.49, 0.50);col1 = vec3(0.27, 0.33, 0.48);}
    if( ramp_p >= 0.05 && ramp_p < 0.1 )
    {col0 = vec3(0.27, 0.33, 0.48);col1 = vec3(0.74, 0.77, 0.81);}
    if( ramp_p >= 0.1 && ramp_p < 0.15 )
    {col0 = vec3(0.74, 0.77, 0.81);col1 = vec3(0.81, 0.58, 0.21);}
    if( ramp_p >= 0.15 && ramp_p < 0.2 )
    {col0 = vec3(0.81, 0.58, 0.21);col1 = vec3(0.37, 0.44, 0.13);}
    if( ramp_p >= 0.2 && ramp_p < 0.25 )
    {col0 = vec3(0.37, 0.44, 0.13);col1 = vec3(0.00, 0.18, 0.72);}
    if( ramp_p >= 0.25 && ramp_p < 0.3 )
    {col0 = vec3(0.00, 0.18, 0.72);col1 = vec3(0.27, 0.74, 0.59);}
    if( ramp_p >= 0.3 && ramp_p < 0.35 )
    {col0 = vec3(0.27, 0.74, 0.59);col1 = vec3(0.87, 0.67, 0.16);}
    if( ramp_p >= 0.35 && ramp_p < 0.4 )
    {col0 = vec3(0.87, 0.67, 0.16);col1 = vec3(0.89, 0.12, 0.43);}
    if( ramp_p >= 0.4 && ramp_p < 0.45 )
    {col0 = vec3(0.89, 0.12, 0.43);col1 = vec3(0.11, 0.13, 0.80);}
    if( ramp_p >= 0.45 && ramp_p < 0.5 )
    {col0 = vec3(0.11, 0.13, 0.80);col1 = vec3(0.00, 0.60, 0.28);}
    if( ramp_p >= 0.5 && ramp_p < 0.55 )
    {col0 = vec3(0.00, 0.60, 0.28);col1 = vec3(0.55, 0.68, 0.15);}
    if( ramp_p >= 0.55 && ramp_p < 0.6 )
    {col0 = vec3(0.55, 0.68, 0.15);col1 = vec3(1.00, 0.24, 0.62);}
    if( ramp_p >= 0.6 && ramp_p < 0.65 )
    {col0 = vec3(1.00, 0.24, 0.62);col1 = vec3(0.53, 0.15, 0.59);}
    if( ramp_p >= 0.65 && ramp_p < 0.7 )
    {col0 = vec3(0.53, 0.15, 0.59);col1 = vec3(0.00, 0.48, 0.21);}
    if( ramp_p >= 0.7 && ramp_p < 0.75 )
    {col0 = vec3(0.00, 0.48, 0.21);col1 = vec3(0.18, 0.62, 0.38);}
    if( ramp_p >= 0.75 && ramp_p < 0.8 )
    {col0 = vec3(0.18, 0.62, 0.38);col1 = vec3(0.80, 0.37, 0.59);}
    if( ramp_p >= 0.8 && ramp_p < 0.85 )
    {col0 = vec3(0.80, 0.37, 0.59);col1 = vec3(0.77, 0.23, 0.39);}
    if( ramp_p >= 0.85 && ramp_p < 0.9 )
    {col0 = vec3(0.77, 0.23, 0.39);col1 = vec3(0.27, 0.38, 0.32);}
    if( ramp_p >= 0.9 && ramp_p < 0.95 )
    {col0 = vec3(0.27, 0.38, 0.32);col1 = vec3(0.10, 0.53, 0.50);}
    if( ramp_p >= 0.95 && ramp_p < 1. )
    {col0 = vec3(0.10, 0.53, 0.50);col1 = vec3(0.33, 0.49, 0.50);}
    
    float bias = 1.-fract(ramp_p*20.);
    bias = smoothstep(0., 1., bias);
    vec3 col = mix(col1, col0, bias);
    return pow(col,vec3(0.8));
}


// hash and noise functions from iq's example: https://www.shadertoy.com/view/4sfGzS
float hash( float n ) { return fract(sin(n)*753.5453123); }
float noise( in vec3 x )
{
    vec3 p = floor(x);
    vec3 f = fract(x);
    f = f*f*(3.0-2.0*f);
    float n = p.x + p.y*157.0 + 113.0*p.z;
    return mix(mix(mix( hash(n+  0.0), hash(n+  1.0),f.x),
                   mix( hash(n+157.0), hash(n+158.0),f.x),f.y),
               mix(mix( hash(n+113.0), hash(n+114.0),f.x),
                   mix( hash(n+270.0), hash(n+271.0),f.x),f.y),f.z);
}



float distfield(vec3 pos)
{
    return length(pos)-1.125+ noise((pos+vec3(0, 0, iTime/3.)) * 2.0) * 0.153;
}



vec3 soap_p( in vec3 p )	// Sine Puke from WAHa_06x36
{
    p *= 2.1276764;	// Frequency
 	float ct = iTime/0.00675;	// Speed of Oily Film movement
	for(int i=1;i<115;i++)
	{
		vec3 newp = p;
		newp.x+=0.45/float(i)*cos(float(i)*p.y+(ct)*0.3/40.0+0.23*float(i))-432.6;
        newp.y+=0.45/float(i)*sin(float(i)*p.x+(ct)*0.3/50.0+0.23*float(i-66))+64.66;
        newp.z+=0.45/float(i)*cos(float(i)*p.x-p.y+(ct)*0.1/150.0+0.23*float(i+6))-56. + ct/320000.;
        p = newp;
	}
    vec3 col = vec3(0.5*sin(1.*p.x)+0.5, 0.5*sin(1.0*p.y)+0.5, 1.*sin(.8*p.z)+0.5);
    col = vec3( col.x + col.y + col.z ) / 3.;	// Just luminance
    
    return col;
}



void mainImage( out vec4 fragColor, in vec2 fragCoord )
{ 

    vec2 uv = -1.+2. * fragCoord.xy/iResolution.xy;
    uv.x *= iResolution.x/iResolution.y;	// Aspect Correction

    vec3 rayOrigin = vec3(0, 0, 1.6);
    vec3 rayDir = vec3(uv.x, -uv.y, -1.);
    
    float totalDist = 0.0;
    float dist = MINDIST;
    vec3 pos = rayOrigin;
    for(int i = 0; i < 200; i++)
    {
        if(dist < MINDIST || totalDist > 50.)
            break;	// Found Intersection or Missed Entirely
        dist = distfield(pos);
        totalDist += dist;
        pos += dist * rayDir;
    }
    fragColor = vec4(vec3(0.018),1.);	// BG Colour
    if(dist < MINDIST) // Found Intersection
    {
        // Calc distancefield gradient
        vec2 eps = vec2(MINDIST, -MINDIST);
        vec3 normal = normalize(
        eps.xyy * distfield(pos + eps.xyy) + 
        eps.yyx * distfield(pos + eps.yyx) + 
        eps.yxy * distfield(pos + eps.yxy) + 
        eps.xxx * distfield(pos + eps.xxx));
        
        // Schlick Fresnel http://filmicgames.com/archives/557
		vec3 I = normalize(rayOrigin-pos);	// Incident Vector
        float fresnel = 1.-dot(normal, I);
        fresnel = pow(fresnel, 4.25);
        fresnel = fresnel + 0.075 * (1. - fresnel);
        vec3 ref = reflect(I,normal);	// Reflection Vector
        vec3 spec = vec3(texture( iChannel0, ref ));	// Cube Map Reflection
        spec = max(vec3(0.), spec-vec3(0.7575)) + pow(spec*1.2, vec3(4.5)) * vec3(1.2,1.1,0.6);// + vec3(0.1385);                 
        spec *= fresnel*0.5;
        vec3 soap_col = soap_p(pos);	// Soapy oil film
    	soap_col = iridescent(soap_col.x);	// Map to iridescent colour rmap
        soap_col = pow(fresnel, 0.85)*pow(soap_col,vec3(0.985));
        
        // Surface Colour
        fragColor = vec4( spec + soap_col, 1.); 
    }
}