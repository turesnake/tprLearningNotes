// The MIT License
// Copyright © 2017 Inigo Quilez
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions: The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software. THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// https://www.youtube.com/c/InigoQuilez
// https://iquilezles.org/

// Computes the analytic derivatives of a 3D Gradient Noise. This can be used for example to compute normals to a
// 3d rocks based on Gradient Noise without approximating the gradient by having to take central differences. More
// info here: http://iquilezles.org/www/articles/gradientnoise/gradientnoise.htm


// Value    Noise 2D, Derivatives: https://www.shadertoy.com/view/4dXBRH
// Gradient Noise 2D, Derivatives: https://www.shadertoy.com/view/XdXBRH
// Value    Noise 2D             : https://www.shadertoy.com/view/lsf3WH
// Gradient Noise 2D             : https://www.shadertoy.com/view/XdXGW8
// Simplex  Noise 2D             : https://www.shadertoy.com/view/Msf3WH
// Wave     Noise 2D             : https://www.shadertoy.com/view/tldSRj


// Value    Noise 3D, Derivatives: https://www.shadertoy.com/view/XsXfRH  -- 效果不好
// Gradient Noise 3D, Derivatives: https://www.shadertoy.com/view/4dffRH  --- 本文件版本
// Value    Noise 3D             : https://www.shadertoy.com/view/4sfGzS
// Gradient Noise 3D             : https://www.shadertoy.com/view/Xsl3Dl




vec3 hash( vec3 p ) // replace this by something better. really. do
{
	p = vec3( dot(p,vec3(127.1,311.7, 74.7)),
			  dot(p,vec3(269.5,183.3,246.1)),
			  dot(p,vec3(113.5,271.9,124.6)));

	return -1.0 + 2.0*fract(sin(p)*43758.5453123);
}

// return value noise (in x) and its derivatives (in yzw)
vec4 noised( in vec3 x )
{
    // grid
    vec3 i = floor(x);
    vec3 w = fract(x);
    
    #if 1
    // quintic interpolant
    vec3 u = w*w*w*(w*(w*6.0-15.0)+10.0);
    vec3 du = 30.0*w*w*(w*(w-2.0)+1.0);
    #else
    // cubic interpolant
    vec3 u = w*w*(3.0-2.0*w);
    vec3 du = 6.0*w*(1.0-w);
    #endif    
    
    // gradients
    vec3 ga = hash( i+vec3(0.0,0.0,0.0) );
    vec3 gb = hash( i+vec3(1.0,0.0,0.0) );
    vec3 gc = hash( i+vec3(0.0,1.0,0.0) );
    vec3 gd = hash( i+vec3(1.0,1.0,0.0) );
    vec3 ge = hash( i+vec3(0.0,0.0,1.0) );
	vec3 gf = hash( i+vec3(1.0,0.0,1.0) );
    vec3 gg = hash( i+vec3(0.0,1.0,1.0) );
    vec3 gh = hash( i+vec3(1.0,1.0,1.0) );
    
    // projections
    float va = dot( ga, w-vec3(0.0,0.0,0.0) );
    float vb = dot( gb, w-vec3(1.0,0.0,0.0) );
    float vc = dot( gc, w-vec3(0.0,1.0,0.0) );
    float vd = dot( gd, w-vec3(1.0,1.0,0.0) );
    float ve = dot( ge, w-vec3(0.0,0.0,1.0) );
    float vf = dot( gf, w-vec3(1.0,0.0,1.0) );
    float vg = dot( gg, w-vec3(0.0,1.0,1.0) );
    float vh = dot( gh, w-vec3(1.0,1.0,1.0) );
	
    // interpolations
    return vec4( va + u.x*(vb-va) + u.y*(vc-va) + u.z*(ve-va) + u.x*u.y*(va-vb-vc+vd) + u.y*u.z*(va-vc-ve+vg) + u.z*u.x*(va-vb-ve+vf) + (-va+vb+vc-vd+ve-vf-vg+vh)*u.x*u.y*u.z,    // value
                 ga + u.x*(gb-ga) + u.y*(gc-ga) + u.z*(ge-ga) + u.x*u.y*(ga-gb-gc+gd) + u.y*u.z*(ga-gc-ge+gg) + u.z*u.x*(ga-gb-ge+gf) + (-ga+gb+gc-gd+ge-gf-gg+gh)*u.x*u.y*u.z +   // derivatives
                 du * (vec3(vb,vc,ve) - va + u.yzx*vec3(va-vb-vc+vd,va-vc-ve+vg,va-vb-ve+vf) + u.zxy*vec3(va-vb-ve+vf,va-vb-vc+vd,va-vc-ve+vg) + u.yzx*u.zxy*(-va+vb+vc-vd+ve-vf-vg+vh) ));
}

//===============================================================================================
//===============================================================================================
//===============================================================================================
//===============================================================================================
//===============================================================================================

void mainImage( out vec4 fragColor, in vec2 fragCoord )
{
	vec2 p = (-iResolution.xy + 2.0*fragCoord) / iResolution.y;

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

        vec4 n = noised( 12.0*pos );
        col = 0.5 + 0.5*((p.x>0.0)?n.yzw:n.xxx);
		
		col = mix( col, vec3(0.9), 1.0-exp( -0.003*tmin*tmin ) );
	}
	
	
	fragColor = vec4( col, 1.0 );
}

