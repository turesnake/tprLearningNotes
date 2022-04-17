// Advection flow tracking
void mainImage( out vec4 fragColor, in vec2 fragCoord ){

    // Screen coordinates.
	vec2 uv = (fragCoord.xy - iResolution.xy*.5) / iResolution.y;
    float aspect = float(iResolution.x) / float(iResolution.y);
    
    float dt = 0.0001 ;
    

    if (iFrame < 10) {
        // inverse displacement map (but with numerical diffusion spuriously smoothing the map)
        fragColor = vec4(uv, 0, 0);        
    } else {
        ivec2 ifc = ivec2(round(fragCoord)); 

        vec2 vxvy = vec2(texture(iChannel0, fragCoord / vec2(iResolution)));

        vec2 newFragCoord = fragCoord - dt * vxvy * vec2(iResolution);

        fragColor = texture(iChannel1, newFragCoord / vec2(iResolution));
    }
}

