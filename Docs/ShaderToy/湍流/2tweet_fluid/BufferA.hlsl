// created by florian berger (flockaroo) - 2017
// License Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License.

// 2tweet fluid

// down to 261 chars - thx to Fabrice!
// down to 247 chars - thx to Fabrice!  --f doesnt work on my system

// try bigger numbers than 40 in line 15 for bigger vortices 旋涡

#define C(x) texture(iChannel0,(f+x)/iResolution.xy).xy
//#define C(x) texelFetch(iChannel0,ivec2(f+x),0).xy

// -1 char: 11 is roughly 1.75pi so perfect -pi/4 substitute (instead of 1.6)
// -9 char: if S is chosen wisely the the difference between x and y is roughly (n+.5)*pi
//#define L(b) for(float a=0.;a<5.;a++) { b=sin((iTime+a)/.1+S);
// -8 char: still works but less quality
//#define L(b) for(float a=0.;a<5.;a++) { b=sin(a/.1+S);


// f: [0,0]-[w.h]
void mainImage(out vec4 c, vec2 f)
{
    // magic numbers: S.x-S.y must be roughly (n+.5)*pi, so we can use it as phase shift above
    vec2 p,q,v = (vec2)0;
    
    vec2 S=vec2(27,-28);
    // v auto initializes to 0 on my system (might not work on some other platforms)
    // v-=v;

    /*
    L(p)
        L(q)
            v+=p*dot(C((p+q).yx*S),q);
        }
    }
    */

    // 25 次采样;

    for(float j=0.; j<5.; j++) 
    { 
        p = sin( (iTime+j)/0.1 + S );

        for(float i=0.; i<5.; i++) 
        { 
            q = sin( (iTime+i)/0.1 + S);
            v += p * dot( C((p+q).yx*S), q );
        }
    }


    c.xy=C(v)+.1/(f-1.);
}

