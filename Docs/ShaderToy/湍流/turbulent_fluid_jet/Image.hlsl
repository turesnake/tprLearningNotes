void mainImage( out vec4 fragColor, in vec2 fragCoord ){

    // Screen coordinates.
	vec2 uv = (fragCoord.xy - iResolution.xy*.5) / iResolution.y;
    
    ivec2 ifc = ivec2(round(fragCoord)); 
    
    // direct image flow visualization (but w/heavy spurious numerical diffusion)
    vec3 sceneColor = vec3(texture(iChannel2, fragCoord / iResolution.xy));
    
    
	fragColor = vec4(clamp(sceneColor, 0., 1.), 1);    
}

