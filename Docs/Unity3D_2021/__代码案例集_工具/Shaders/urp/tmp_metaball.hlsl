/*

	2D Metaballs
	------------

	I have a soft spot for oldschool effects, and metaballs are among my favorite of those. Here's
	a very simple example.

	Most 2D and 3D versions you see in pixelshader form are renderings of fieldstrength isolines 
	around particles that follow a randomized sinusoidal path based on a fixed radius. The combined 
	effect gives a mild impression that particle motion is dependent on the proximity of other 
	particles, but you can tell that it's not the case when you look more closely. If you render 
	just the points themselves, it's pretty easy to see. However, by sinusoidally modulating the 
	radius between zero and its maximum, you can at least give the impression that the particles 
	are influenced by some kind of central force.

*/

#define PI 3.14159265358979

// Comment out to see just the blobs.
#define RENDER_POINTS

float hash( float n ){ return fract(sin(n)*43758.5453); }

// Meta value, field strength.
float meta(vec2 p)
{

    // Analogous to the particle radius, but used to control the size of
    // individual - and overall - blob mass. 
    const float radius = .05;
	
    // Meta value\particle field strength.
    return radius/(dot(p, p) + 0.0001);  
    
    // Alternative, round-square blobs. Every shape imaginable is possible.
    //return radius/(pow(dot(pow(p, vec2(4)), vec2(1)), 2./4.) + .001);

}


void mainImage( out vec4 fragColor, in vec2 fragCoord )
{

    // Screen coordinates.
    vec2 p = (fragCoord - iResolution.xy*.5) / iResolution.y;
    
   
    // Overall adjustable time.
    float time = iTime*.5;

    const float pNum = 10.; // Particle number.
    
    // Accumlative color value - used for the background.
    vec3 aCol = vec3(0.0);
    
    // Total field strength (or meta value) to render the blobs, and total point value used 
    // to render the points themselves.
    float totFS = 0., totPV=0.;
	
    
    // Set the particle's position, calculated it's field strength contribution, then
    // add it to the total field strength value.
	for(float i=0.; i<pNum; i++){
        	
        
        // Random sinusoidal motion for each particle. Made up on the spot, so could 
        // definitely be improved upon.
        float rnd = i*(PI*2. + .5453); //(hash(i)*.5 + .5)*PI*2.;
		vec2 pos = vec2(sin(time*0.97 + rnd*3.11)*0.5, cos(time*1.03 + rnd*5.73)*0.4);
		pos *= vec2(sin(time*1.05 + i*(i+1.)*PI/9.11), cos(time*.95 + i*(i-1.)*PI/7.73))*1.25;
        
        // Modulating the radius from zero to maximum to give the impression that the 
        // particles are attracted to the center. 
        //pos *= abs(sin(time*1.5 + i*3.14159/pNum))*1.2; // Bounce
        pos *= (cos(time*3. + i*3.14159/pNum)*.5 + .5)*1.1; // Smoother motion.
        
        float field = meta(p - pos); // Field value for each particle.
        float point = .01 - length(p-pos); // Point value for each particle.
        point = smoothstep(0., fwidth(point), point); // Tapering the borders.
		
        totFS += field/pNum; // Total field strength contribution.
        totPV = max(totPV, point); // Total point value.
        
        // Add variations on each field strength value for some background color.
		aCol += vec3(totFS, totFS*0.66, totFS*totFS*0.5)/(i*0.2+1.)*.6;
	}
    
    // Cellular membrane variation.
	//totFS = sin(clamp(log(totFS), 0.0, PI/2.)*PI)*2.;
    

    // Old trick to allow smooth tapering dependent on curvature. The result is constant 
    // pixel-precision-width lines.
    float fwDe = fwidth(totFS); // 48./iResolution.y;
    
    float d1 = smoothstep(0., fwDe, totFS - 1.); // Outer field strength line.
    float d2 = smoothstep(0., fwDe, totFS - 1.75); // Inner field strength line.
    
    // Mix the outer blob with the background.
    vec3 col = mix(clamp(aCol.zyx*(.85 + hash(totFS)*.3), 0., 1.), vec3(0), d1);
    // Inner, colored blob.
    col = mix(col, vec3(.9, .55, 1), d2);//vec3(1., .03, .075)
    
    #ifdef RENDER_POINTS
    // Mix in the points themselves.
    col = mix(col, vec3(1, 0, 0), totPV);
    #endif
 
    // Rough gamma correction, to make everything (including antialiasing) look right.
	fragColor = vec4(sqrt(clamp(col, 0., 1.)), 1);
}