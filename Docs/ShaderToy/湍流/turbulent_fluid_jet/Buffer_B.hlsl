// Velocity
void mainImage( out vec4 fragColor, in vec2 fragCoord ){

    // No-flux boundary conditions:
    // (set these to true to keep the flow boxed in -- computationally expensive, tho)
    bool boxx = true;
    
    // Screen coordinates.
	vec2 uv = (fragCoord.xy - iResolution.xy*.5) / iResolution.y;
    
    vec2 vxvy = vec2(0.0);        
    
    float aspect = 1./1.0 *  .99/.98 * .98 * float(iResolution.x) / float(iResolution.y);
    float aspy = .98;
    float rfac = 0.05; // divergence fudge factor for approximate no flux
    
   	int subsamp = 2;
    int n = int(iResolution.x) / subsamp - 1; // / 2.);
    int nv = 3; 

    for (int i = 0; i < n; i++) {
      for (int j = 0; j < nv; j++) {
        
        vec4 puvc = texelFetch(iChannel1, ivec2(i * subsamp, j * subsamp), 0);
        vec2 puv = vec2(puvc); //vec2(puvc[0], puvc[1]);
        
        vec2 duv = uv - puv;
        float d2 = dot(duv, duv);
        
        if (sqrt(d2) > 0.01) {
        	vxvy += puvc[2] * vec2(-duv[1], duv[0]) / d2;
        }
        
            
        float qinv = -puvc[2];
        vec2 pinv = vec2(aspect - puv[0], puv[1]);
        
        duv = uv - pinv;
        d2 = dot(duv, duv);
        
        if (sqrt(d2) > 0.01) {
            vxvy += qinv * (vec2(-duv[1], duv[0]) + sign(qinv) * duv * rfac) / d2;
        }
        
        float qinv = -puvc[2];
        vec2 pinv = vec2(-aspect - puv[0], puv[1]);
        
        duv = uv - pinv;
        d2 = dot(duv, duv);
        
        if (sqrt(d2) > 0.01) {
            vxvy += qinv * (vec2(-duv[1], duv[0]) + sign(qinv) * duv * rfac) / d2;
        }                        
      }
    }

    
    fragColor = vec4(vxvy, 0., 1.);
}

