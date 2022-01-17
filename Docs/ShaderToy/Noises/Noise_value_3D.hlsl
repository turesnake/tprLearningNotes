// The MIT License
// Copyright © 2013 Inigo Quilez
// https://www.youtube.com/c/InigoQuilez
// https://iquilezles.org/
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions: The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software. THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

// Fast 3D (value) noise by using two cubic-smooth bilinear interpolations in a LUT, 
// which is much faster than its hash based (purely procedural) counterpart.
//
// Note that instead of fetching from a grey scale texture twice at an offset of (37,17)
// pixels, the green channel of the texture is a copy of the red channel offset that amount
// (thx Dave Hoskins for the suggestion to try this)



// Value    Noise 2D, Derivatives: https://www.shadertoy.com/view/4dXBRH
// Gradient Noise 2D, Derivatives: https://www.shadertoy.com/view/XdXBRH
// Value    Noise 2D             : https://www.shadertoy.com/view/lsf3WH
// Gradient Noise 2D             : https://www.shadertoy.com/view/XdXGW8
// Simplex  Noise 2D             : https://www.shadertoy.com/view/Msf3WH
// Wave     Noise 2D             : https://www.shadertoy.com/view/tldSRj


// Value    Noise 3D, Derivatives: https://www.shadertoy.com/view/XsXfRH -- 效果不好
// Gradient Noise 3D, Derivatives: https://www.shadertoy.com/view/4dffRH
// Value    Noise 3D             : https://www.shadertoy.com/view/4sfGzS -- 本文件版本
// Gradient Noise 3D             : https://www.shadertoy.com/view/Xsl3Dl


//#define USE_PROCEDURAL

//===============================================================================================
//===============================================================================================
//===============================================================================================

#ifdef USE_PROCEDURAL

float hash(vec3 p)  // replace this by something better
{
    p  = fract( p*0.3183099+.1 );
	p *= 17.0;
    return fract( p.x*p.y*p.z*(p.x+p.y+p.z) );
}

float noise( in vec3 x )
{
    vec3 i = floor(x);
    vec3 f = fract(x);
    f = f*f*(3.0-2.0*f);
	
    return mix(mix(mix( hash(i+vec3(0,0,0)), 
                        hash(i+vec3(1,0,0)),f.x),
                   mix( hash(i+vec3(0,1,0)), 
                        hash(i+vec3(1,1,0)),f.x),f.y),
               mix(mix( hash(i+vec3(0,0,1)), 
                        hash(i+vec3(1,0,1)),f.x),
                   mix( hash(i+vec3(0,1,1)), 
                        hash(i+vec3(1,1,1)),f.x),f.y),f.z);
}

#else

float noise( in vec3 x )
{
    #if 1
    
    vec3 i = floor(x);
    vec3 f = fract(x);
	f = f*f*(3.0-2.0*f);
	vec2 uv = (i.xy+vec2(37.0,17.0)*i.z) + f.xy;
	vec2 rg = textureLod( iChannel0, (uv+0.5)/256.0, 0.0).yx;
	return mix( rg.x, rg.y, f.z );
    
    #else
    
    ivec3 i = ivec3(floor(x));
    vec3 f = fract(x);
	f = f*f*(3.0-2.0*f);
	ivec2 uv = i.xy + ivec2(37,17)*i.z;
	vec2 rgA = texelFetch( iChannel0, (uv+ivec2(0,0))&255, 0 ).yx;
    vec2 rgB = texelFetch( iChannel0, (uv+ivec2(1,0))&255, 0 ).yx;
    vec2 rgC = texelFetch( iChannel0, (uv+ivec2(0,1))&255, 0 ).yx;
    vec2 rgD = texelFetch( iChannel0, (uv+ivec2(1,1))&255, 0 ).yx;
    vec2 rg = mix( mix( rgA, rgB, f.x ),
                   mix( rgC, rgD, f.x ), f.y );
    return mix( rg.x, rg.y, f.z );
    
    #endif
}

#endif

//===============================================================================================
//===============================================================================================
//===============================================================================================
//===============================================================================================
//===============================================================================================

const mat3 m = mat3( 0.00,  0.80,  0.60,
                    -0.80,  0.36, -0.48,
                    -0.60, -0.48,  0.64 );

void mainImage( out vec4 fragColor, in vec2 fragCoord )
{
	vec2 p = (-iResolution.xy + 2.0*fragCoord.xy) / iResolution.y;

     // camera movement	
	float an = 0.5*iTime;
	vec3 ro = vec3( 2.5*cos(an), 1.0, 2.5*sin(an) );
    vec3 ta = vec3( 0.0, 1.0, 0.0 );
    // camera matrix
    vec3 ww = normalize( ta - ro );
    vec3 uu = normalize( cross(ww,vec3(0.0,1.0,0.0) ) );
    vec3 vv = normalize( cross(uu,ww));
	// create view ray
	vec3 rd = normalize( p.x*uu + p.y*vv + 1.5*ww );

    // sphere center	
	vec3 sc = vec3(0.0,1.0,0.0);

    // raytrace
	float tmin = 10000.0;
	vec3  nor = vec3(0.0);
	float occ = 1.0;
	vec3  pos = vec3(0.0);
	
	// raytrace-plane
	float h = (0.0-ro.y)/rd.y;
	if( h>0.0 ) 
	{ 
		tmin = h; 
		nor = vec3(0.0,1.0,0.0); 
		pos = ro + h*rd;
		vec3 di = sc - pos;
		float l = length(di);
		occ = 1.0 - dot(nor,di/l)*1.0*1.0/(l*l); 
	}

	// raytrace-sphere
	vec3  ce = ro - sc;
	float b = dot( rd, ce );
	float c = dot( ce, ce ) - 1.0;
	h = b*b - c;
	if( h>0.0 )
	{
		h = -b - sqrt(h);
		if( h<tmin ) 
		{ 
			tmin=h; 
			nor = normalize(ro+h*rd-sc); 
			occ = 0.5 + 0.5*nor.y;
		}
	}

    // shading/lighting	
	vec3 col = vec3(0.9);
	if( tmin<100.0 )
	{
	    pos = ro + tmin*rd;
	    float f = 0.0;
		
		if( p.x<0.0 )
		{
			f = noise( 16.0*pos );
		}
		else
		{
            vec3 q = 8.0*pos;
            f  = 0.5000*noise( q ); q = m*q*2.01;
            f += 0.2500*noise( q ); q = m*q*2.02;
            f += 0.1250*noise( q ); q = m*q*2.03;
            f += 0.0625*noise( q ); q = m*q*2.01;
		}
		
		
		
		f *= occ;
		col = vec3(f*1.2);
		col = mix( col, vec3(0.9), 1.0-exp( -0.003*tmin*tmin ) );
	}
	
	col = sqrt( col );
	
	col *= smoothstep( 0.006, 0.008, abs(p.x) );
	
	fragColor = vec4( col, 1.0 );
}

