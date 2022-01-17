/*

    依赖一张 噪声贴图 iChannel0


*/
#define PI 3.14159265359


float noise (vec2 co) {
  return length (texture (iChannel0, co));
}


mat2 rotate (float fi) {
	float cfi = cos (fi);
	float sfi = sin (fi);
	return mat2 (-sfi, cfi, cfi, sfi);
}

vec3 hsv2rgb (vec3 c) {
    vec4 K = vec4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
    vec3 p = abs(fract(c.xxx + K.xyz) * 6.0 - K.www);
    return c.z * mix(K.xxx, clamp(p - K.xxx, 0.0, 1.0), c.y);
}


float fbm (sampler2D tex, vec2 uv) {
	return (
		+noise (uv*2.0)/2.0
		+noise (uv*4.0)/4.0
		+noise (uv*8.0)/8.0
		+noise (uv*16.0)/16.0
		+noise (uv*32.0)/32.0
	);
}


vec4 compute (vec2 uv, float iTime) {	
	uv *= rotate (PI * 0.125 * sin (fbm (iChannel0, uv/512.0)*PI));
	uv = (iTime+uv)/512.0;
	vec3 col = vec3 (fbm (iChannel0, uv)*PI*2.0, 1.0, 1.0);	
	return vec4 (hsv2rgb (col),1.0) ;
}
			  
void mainImage( out vec4 fragColor, in vec2 fragCoord ) {
	float fact = 1.0/min (iResolution.y, iResolution.x);
	vec2 uv = fact*(2.0*fragCoord.xy - iResolution.xy);
	
	fragColor = compute (uv*2.0, iTime);	
}



