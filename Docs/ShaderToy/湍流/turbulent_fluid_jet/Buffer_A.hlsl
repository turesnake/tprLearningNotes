// Vorticity particles
void mainImage( out vec4 fragColor, in vec2 fragCoord )
{

    
    // Screen coordinates.
	vec2 uv = (fragCoord.xy - iResolution.xy*.5) / iResolution.y;
    float aspect = float(iResolution.x) / float(iResolution.y);
    
    
	    ivec2 ifc = ivec2(round(fragCoord)); 
	    vec4 puvc = texelFetch(iChannel0, ifc, 0);
        
        vec2 pxy = vec2(puvc) * iResolution.y + iResolution.xy*.5;
        ivec2 ipxy = ivec2(round(pxy));
	    vec2 uvipxy = (vec2(ipxy) - iResolution.xy*.5) / iResolution.y;

	    vec2 vxvy = vec2(texture(iChannel1, pxy / vec2(iResolution)));
        
        float dt = 0.0001 ; // iTimeDelta * 0.01;
        
        
        fragColor = puvc + dt * vec4(vxvy, 0, 0);
        
        // Wrap the particles around if they manage to get out (not entirely physical)
        aspect = 1./1.0 * .99 * aspect;
        float aspy = .99;
        if (fragColor[0] > aspect * .5) fragColor[0] -= aspect;
        if (fragColor[0] <= -aspect * .5) fragColor[0] += aspect;
        if (fragColor[1] > aspy * .5) fragColor[1] -= aspy;
        if (fragColor[1] <= -aspy * .5) fragColor[1] += aspy;

        if (abs(fragCoord.x + fragCoord.y / iResolution.y * 20. - iMouse.x) < 1.0 && iMouse[2] > 0.) {
			vec2 muv = (vec2(iMouse) - iResolution.xy*.5) / iResolution.y;
            fragColor = vec4(muv, fragColor[2], fragColor[3]); 
        
        }        
    

    
        vec3 sceneColor;
        float stagger = trunc(fragCoord.y / 4.) / iResolution.y;
        
        if (iFrame == int(round((aspect*.5 + uv[0] + stagger) * 100.))) {
            
            if (int(round(mod(fragCoord.x / 2., 2.))) == 0) {
                fragColor = vec4(aspect*.49, -0.1, .2, 1); 
            } else {
                fragColor = vec4(aspect*.49, 0.1, -.2, 1); 
            }
        }
    
}

