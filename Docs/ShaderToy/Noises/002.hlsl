
// white noise, from https://www.shadertoy.com/view/4djSRW
vec2 hash23(vec3 p3)
{
	p3 = fract(p3 * vec3(.1031, .1030, .0973));
    p3 += dot(p3, p3.yzx+33.33);
    return fract((p3.xx+p3.yz)*p3.zy);
}

// halton low discrepancy sequence, from https://www.shadertoy.com/view/wdXSW8
vec2 halton (int index)
{
    const vec2 coprimes = vec2(2.0f, 3.0f);
    vec2 s = vec2(index, index);
	vec4 a = vec4(1,1,0,0);
    while (s.x > 0. && s.y > 0.)
    {
        a.xy = a.xy/coprimes;
        a.zw += a.xy*mod(s, coprimes);
        s = floor(s/coprimes);
    }
    return a.zw;
}

// analytically mipmapped checkerboard pattern from inigo quilez
// https://www.iquilezles.org/www/articles/morecheckerfiltering/morecheckerfiltering.htm
vec2 p( in vec2 x )
{
    vec2 h = fract(x/2.0)-0.5;
    return x*0.5 + h*(1.0-2.0*abs(h));
}

// return a filtered checkers pattern
float checkersGradTriangle( in vec2 uv )
{
    vec2 ddx = dFdx(uv);
    vec2 ddy = dFdy(uv);
    vec2 w = max(abs(ddx), abs(ddy)) + 0.01;    // filter kernel
    vec2 i = (p(uv+w)-2.0*p(uv)+p(uv-w))/(w*w); // analytical integral (triangle filter)
    return 0.5 - 0.5*i.x*i.y;                   // xor pattern
}

void GetCameraVectors(out vec3 cameraPos, out vec3 cameraFwd, out vec3 cameraUp, out vec3 cameraRight)
{   
    vec2 mouse = iMouse.xy;
    if (dot(mouse, vec2(1.0f, 1.0f)) == 0.0f)
        mouse = c_defaultMousePos * iResolution.xy;    
    
    float angleX = -mouse.x * 16.0f / float(iResolution.x);
    float angleY = mix(c_minCameraAngle, c_maxCameraAngle, mouse.y / float(iResolution.y));
    
    cameraPos.x = sin(angleX) * sin(angleY) * c_cameraDistance;
    cameraPos.y = -cos(angleY) * c_cameraDistance;
    cameraPos.z = cos(angleX) * sin(angleY) * c_cameraDistance;
    
    cameraPos += c_cameraAt;
    
    cameraFwd = normalize(c_cameraAt - cameraPos);
    cameraRight = normalize(cross(cameraFwd, vec3(0.0f, 1.0f, 0.0f)));
    cameraUp = normalize(cross(cameraRight, cameraFwd));   
}

struct SRayHitInfo
{
    float dist;
    vec3 normal;
    vec3 diffuse;
};
    
bool RayVsSphere(in vec3 rayPos, in vec3 rayDir, inout SRayHitInfo info, in vec4 sphere, in vec3 diffuse)
{
	//get the vector from the center of this sphere to where the ray begins.
	vec3 m = rayPos - sphere.xyz;

    //get the dot product of the above vector and the ray's vector
	float b = dot(m, rayDir);

	float c = dot(m, m) - sphere.w * sphere.w;

	//exit if r's origin outside s (c > 0) and r pointing away from s (b > 0)
	if(c > 0.0 && b > 0.0)
		return false;

	//calculate discriminant
	float discr = b * b - c;

	//a negative discriminant corresponds to ray missing sphere
	if(discr < 0.0)
		return false;
    
	//ray now found to intersect sphere, compute smallest t value of intersection
    bool fromInside = false;
	float dist = -b - sqrt(discr);
    if (dist < 0.0f)
    {
        fromInside = true;
        dist = -b + sqrt(discr);
    }
    
	if (dist > 0.0f && dist < info.dist)
    {
        info.dist = dist;        
        info.normal = normalize((rayPos+rayDir*dist) - sphere.xyz) * (fromInside ? -1.0f : 1.0f);
		info.diffuse = diffuse;        
        return true;
    }
    
    return false;
}
    
bool RayVsPlane(in vec3 rayPos, in vec3 rayDir, inout SRayHitInfo info, in vec4 plane, in vec3 diffuse)
{
    float dist = -1.0f;
    float denom = dot(plane.xyz, rayDir);
    if (abs(denom) > 0.001f)
    {
        dist = (plane.w - dot(plane.xyz, rayPos)) / denom;
    
        if (dist > 0.0f && dist < info.dist)
        {
            info.dist = dist;        
            info.normal = plane.xyz;
            info.diffuse = diffuse;
            return true;
        }
    }
    return false;
}

float ScalarTriple(vec3 u, vec3 v, vec3 w)
{
    return dot(cross(u, v), w);
}

bool RayVsQuad(in vec3 rayPos, in vec3 rayDir, inout SRayHitInfo info, in vec3 a, in vec3 b, in vec3 c, in vec3 d, in vec3 diffuse, bool doubleSided)
{
    // calculate normal and flip vertices order if needed
    vec3 normal = normalize(cross(c-a, c-b));
    if (doubleSided && dot(normal, rayDir) > 0.0f)
    {
        normal *= -1.0f;
        
		vec3 temp = d;
        d = a;
        a = temp;
        
        temp = b;
        b = c;
        c = temp;
    }
    
    vec3 p = rayPos;
    vec3 q = rayPos + rayDir;
    vec3 pq = q - p;
    vec3 pa = a - p;
    vec3 pb = b - p;
    vec3 pc = c - p;
    
    // determine which triangle to test against by testing against diagonal first
    vec3 m = cross(pc, pq);
    float v = dot(pa, m);
    vec3 intersectPos;
    if (v >= 0.0f)
    {
        // test against triangle a,b,c
        float u = -dot(pb, m);
        if (u < 0.0f) return false;
        float w = ScalarTriple(pq, pb, pa);
        if (w < 0.0f) return false;
        float denom = 1.0f / (u+v+w);
        u*=denom;
        v*=denom;
        w*=denom;
        intersectPos = u*a+v*b+w*c;
    }
    else
    {
        vec3 pd = d - p;
        float u = dot(pd, m);
        if (u < 0.0f) return false;
        float w = ScalarTriple(pq, pa, pd);
        if (w < 0.0f) return false;
        v = -v;
        float denom = 1.0f / (u+v+w);
        u*=denom;
        v*=denom;
        w*=denom;
        intersectPos = u*a+v*d+w*c;
    }
    
    float dist;
    if (abs(rayDir.x) > 0.1f)
    {
        dist = (intersectPos.x - rayPos.x) / rayDir.x;
    }
    else if (abs(rayDir.y) > 0.1f)
    {
        dist = (intersectPos.y - rayPos.y) / rayDir.y;
    }
    else
    {
        dist = (intersectPos.z - rayPos.z) / rayDir.z;
    }
    
	if (dist > 0.0f && dist < info.dist)
    {
        info.dist = dist;        
        info.normal = normal;
		info.diffuse = diffuse;        
        return true;
    }    
    
    return false;
}

SRayHitInfo RayVsScene(in vec3 rayPos, in vec3 rayDir, bool shadowRay)
{
    SRayHitInfo hitInfo;
    hitInfo.dist = c_rayMaxDist;

    // the floor
    if(RayVsPlane(rayPos, rayDir, hitInfo, vec4(0.0f, 1.0f, 0.0f, 0.0f), vec3(0.2f, 0.2f, 0.2f)))
    {
        vec3 hitPos = rayPos + rayDir * hitInfo.dist;
        vec2 uv = hitPos.xz / 100.0f;
        float shade = mix(0.8f, 0.4f, checkersGradTriangle(uv));
        hitInfo.diffuse = vec3(shade, shade, shade);
    }
    
    // some floating spheres to cast shadows
    RayVsSphere(rayPos, rayDir, hitInfo, vec4(-60.0f, 10.0f, 0.0f, 10.0f), vec3(1.0f, 0.0f, 1.0f));
    RayVsSphere(rayPos, rayDir, hitInfo, vec4(-30.0f, 20.0f, 0.0f, 10.0f), vec3(1.0f, 0.0f, 0.0f));
    RayVsSphere(rayPos, rayDir, hitInfo, vec4(0.0f, 30.0f, 0.0f, 10.0f), vec3(0.0f, 1.0f, 0.0f));
    RayVsSphere(rayPos, rayDir, hitInfo, vec4(30.0f, 40.0f, 0.0f, 10.0f), vec3(0.0f, 0.0f, 1.0f));
    RayVsSphere(rayPos, rayDir, hitInfo, vec4(60.0f, 50.0f, 0.0f, 10.0f), vec3(1.0f, 1.0f, 0.0f));
    
    // the light
    if(!shadowRay)
    {
		if(RayVsSphere(rayPos, rayDir, hitInfo, vec4(c_lightPos, c_lightRadius), c_lightColor))
        {
            vec3 hitPos = rayPos + rayDir * hitInfo.dist;
            vec3 toLight = (c_lightPos - hitPos);
            vec3 lightDir = normalize(toLight);
    		float angleAtten = dot(lightDir, -c_lightDir);
    		angleAtten = smoothstep(c_cosThetaOuter, c_cosThetaInner, angleAtten);
            hitInfo.diffuse *= angleAtten;
        }
    }
    
    return hitInfo;
}

vec3 GetColorForRay(in vec3 rayPos, in vec3 rayDir, out float hitDistance, int panel, in vec2 pixelPos)
{
    // trace primary ray
	SRayHitInfo hitInfo = RayVsScene(rayPos, rayDir, false);
    
    // set the hitDistance out parameter
    hitDistance = hitInfo.dist;
    
    if (hitInfo.dist == c_rayMaxDist)
        return texture(iChannel0, rayDir).rgb;
    
    // calculate where the pixel is in world space
	vec3 hitPos = rayPos + rayDir * hitInfo.dist;
    hitPos += hitInfo.normal * c_hitNormalNudge;
    
    int frame = 0;
    #if ANIMATE_NOISE
    	frame = iFrame % 64;
    #endif
    
    // use the screen space blue noise texture and golden ratio * frame number to
    // get a "random number" to convert to an angle for how much to rotate
    // the blue noise sample positions for this pixel
    float blueNoise = texture(iChannel1, pixelPos / 1024.0f).r;
    blueNoise = fract(blueNoise + c_goldenRatioConjugate * float(frame));
    float theta = blueNoise * 2.0f * c_pi;
    float cosTheta = cos(theta);
    float sinTheta = sin(theta);
        
    // shoot some shadow rays
    vec3 toLight = (c_lightPos - hitPos);
    vec3 lightDir = normalize(toLight);
    float lightDistance = length(toLight);
    float lightRadius = c_lightRadius / lightDistance;
    float shadowTerm = 0.0f;
    
    float angleAtten = dot(lightDir, -c_lightDir);
    
    angleAtten = smoothstep(c_cosThetaOuter, c_cosThetaInner, angleAtten);
    
    vec3 lightTangent = normalize(cross(lightDir, vec3(0.0f, 1.0f, 0.0f)));
    vec3 lightBitangent = normalize(cross(lightTangent, lightDir));
    for (int shadowRayIndex = 0; shadowRayIndex < c_numShadowRays; ++shadowRayIndex)
    {
        // calculate a ray direction to a random point on a disk in the direction of the light.
        // AKA pick a random point on the sun and shoot a ray at it.
        vec3 shadowRayDir;
        {
            vec2 diskPoint;
            if ((panel%2) == 0)
            {
                // get white noise
                vec2 rng = hash23(vec3(pixelPos, float(frame * c_numShadowRays + shadowRayIndex)));

                // calculate disk point
                float pointRadius = lightRadius * sqrt(rng.x);
                float pointAngle = rng.y * 2.0f * c_pi;
                diskPoint = vec2(pointRadius*cos(pointAngle), pointRadius*sin(pointAngle));

            }
            else //if ((panel%2) == 1)
            {
                // we only have 64 blue noise samples
                // We could make more blue noise samples, but gotta set the limit somewhere since it's a constant array of vec2s.
                if (shadowRayIndex >= 64)
                    break;
                
                // get a blue noise sample position
                vec2 samplePos = BlueNoiseInDisk[shadowRayIndex];

                // rotate it
                diskPoint.x = samplePos.x * cosTheta - samplePos.y * sinTheta;
                diskPoint.y = samplePos.x * sinTheta + samplePos.y * cosTheta;

                // scale it by the disk size
                diskPoint *= lightRadius;
            }

            // calculate the normalized vector to the random point on the disk
            shadowRayDir = normalize(lightDir + diskPoint.x * lightTangent + diskPoint.y * lightBitangent);
        }

        // trace shadow ray
        SRayHitInfo shadowHitInfo = RayVsScene(hitPos, shadowRayDir, true);
        shadowTerm = mix(shadowTerm, ((shadowHitInfo.dist == c_rayMaxDist) ? 1.0f : 0.0f), 1.0f / float(shadowRayIndex+1));
    }
    
    // do diffuse lighting
    float dp = clamp(dot(hitInfo.normal, lightDir), 0.0f, 1.0f);
	return c_lightAmbient * hitInfo.diffuse + dp * hitInfo.diffuse * c_lightColor * shadowTerm / (lightDistance*lightDistance) * angleAtten;
}

void mainImage( out vec4 fragColor, in vec2 fragCoord )
{
    // get the camera vectors
    vec3 cameraPos, cameraFwd, cameraUp, cameraRight;
    GetCameraVectors(cameraPos, cameraFwd, cameraUp, cameraRight);    
    
    // calculate sub pixel jitter for anti aliasing
    vec2 subPixelJitter = (fragCoord.y < iResolution.y * 0.5f) ? halton(iFrame % 16 + 1) - 0.5f : vec2(0.0f, 0.0f);
    
    // calculate the ray direction for this pixel
    vec2 uv = (fragCoord + subPixelJitter)/iResolution.xy;
	float aspectRatio = iResolution.x / iResolution.y;
    int panel = 0;
    vec3 rayDir;
    {   
        panel = int(dot(floor(uv*2.0f), vec2(1.0f, 2.0f)));
        
		vec2 screen = fract(uv*2.0f) * 2.0f - 1.0f;
        screen.y /= aspectRatio;
                
        float cameraDistance = tan(c_FOV * 0.5f * c_pi / 180.0f);       
        rayDir = vec3(screen, cameraDistance);
        rayDir = normalize(mat3(cameraRight, cameraUp, cameraFwd) * rayDir);
    }
    
    // do rendering for this pixel
    float rayHitTime;
    vec3 pixelColor = GetColorForRay(cameraPos, rayDir, rayHitTime, panel, fragCoord);
    fragColor = vec4(pixelColor, 1.0f);    
}

