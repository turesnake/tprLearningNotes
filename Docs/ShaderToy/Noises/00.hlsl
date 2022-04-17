#define ANIMATE_NOISE 1

const int c_numShadowRays = 16;  // blue noise will use 64 samples max. white noise will use however many you specify here.
const vec3 c_lightPos = vec3(0.0f, 60.0f, 40.0f);
const float c_lightRadius = 5.0f;
// direction of the spotlight
#define c_lightDir (normalize(vec3(0.0f, -1.0f, -1.0f)))
const float c_cosThetaInner = 0.8f;  // direction to light, dotted by -c_lightDir. light starts to fade here.
const float c_cosThetaOuter = 0.7f; // direction to light, dotted by -c_lightDir. light finishes fading here.
const vec3 c_lightColor = vec3(1.0f, 0.8f, 0.5f) * 5000.0f;
const vec3 c_lightAmbient = vec3(0.05f, 0.05f, 0.05f);




const float c_pi = 3.14159265359f;
const float c_goldenRatioConjugate = 0.61803398875f; // also just fract(goldenRatio)

const float c_FOV = 90.0f; // in degrees
const float c_cameraDistance = 100.0f;
const float c_minCameraAngle = c_pi / 2.0f;
const float c_maxCameraAngle = c_pi;
const vec3 c_cameraAt = vec3(0.0f, 20.0f, 0.0f);
const float c_rayMaxDist = 10000.0f;

const vec2 c_defaultMousePos = vec2(90.0f / 800.0f, 250.0f / 450.0f);

const float c_hitNormalNudge = 0.1f;


// This "blue noise in disk" array is blue noise in a circle and is used for sampling the
// sun disk for the blue noise.
// these were generated using a modified mitchell's best candidate algorithm.
// 1) It was not calculated on a torus (no wrap around distance for points)
// 2) Candidates were forced to be in the unit circle (through rejection sampling)
const vec2 BlueNoiseInDisk[64] = vec2[64](
    vec2(0.478712,0.875764),
    vec2(-0.337956,-0.793959),
    vec2(-0.955259,-0.028164),
    vec2(0.864527,0.325689),
    vec2(0.209342,-0.395657),
    vec2(-0.106779,0.672585),
    vec2(0.156213,0.235113),
    vec2(-0.413644,-0.082856),
    vec2(-0.415667,0.323909),
    vec2(0.141896,-0.939980),
    vec2(0.954932,-0.182516),
    vec2(-0.766184,0.410799),
    vec2(-0.434912,-0.458845),
    vec2(0.415242,-0.078724),
    vec2(0.728335,-0.491777),
    vec2(-0.058086,-0.066401),
    vec2(0.202990,0.686837),
    vec2(-0.808362,-0.556402),
    vec2(0.507386,-0.640839),
    vec2(-0.723494,-0.229240),
    vec2(0.489740,0.317826),
    vec2(-0.622663,0.765301),
    vec2(-0.010640,0.929347),
    vec2(0.663146,0.647618),
    vec2(-0.096674,-0.413835),
    vec2(0.525945,-0.321063),
    vec2(-0.122533,0.366019),
    vec2(0.195235,-0.687983),
    vec2(-0.563203,0.098748),
    vec2(0.418563,0.561335),
    vec2(-0.378595,0.800367),
    vec2(0.826922,0.001024),
    vec2(-0.085372,-0.766651),
    vec2(-0.921920,0.183673),
    vec2(-0.590008,-0.721799),
    vec2(0.167751,-0.164393),
    vec2(0.032961,-0.562530),
    vec2(0.632900,-0.107059),
    vec2(-0.464080,0.569669),
    vec2(-0.173676,-0.958758),
    vec2(-0.242648,-0.234303),
    vec2(-0.275362,0.157163),
    vec2(0.382295,-0.795131),
    vec2(0.562955,0.115562),
    vec2(0.190586,0.470121),
    vec2(0.770764,-0.297576),
    vec2(0.237281,0.931050),
    vec2(-0.666642,-0.455871),
    vec2(-0.905649,-0.298379),
    vec2(0.339520,0.157829),
    vec2(0.701438,-0.704100),
    vec2(-0.062758,0.160346),
    vec2(-0.220674,0.957141),
    vec2(0.642692,0.432706),
    vec2(-0.773390,-0.015272),
    vec2(-0.671467,0.246880),
    vec2(0.158051,0.062859),
    vec2(0.806009,0.527232),
    vec2(-0.057620,-0.247071),
    vec2(0.333436,-0.516710),
    vec2(-0.550658,-0.315773),
    vec2(-0.652078,0.589846),
    vec2(0.008818,0.530556),
    vec2(-0.210004,0.519896) 
);

// ACES tone mapping curve fit to go from HDR to LDR
//https://knarkowicz.wordpress.com/2016/01/06/aces-filmic-tone-mapping-curve/
vec3 ACESFilm(vec3 x)
{
    float a = 2.51f;
    float b = 0.03f;
    float c = 2.43f;
    float d = 0.59f;
    float e = 0.14f;
    return clamp((x*(a*x + b)) / (x*(c*x + d) + e), 0.0f, 1.0f);
}

vec3 LessThan(vec3 f, float value)
{
    return vec3(
        (f.x < value) ? 1.0f : 0.0f,
        (f.y < value) ? 1.0f : 0.0f,
        (f.z < value) ? 1.0f : 0.0f);
}

vec3 LinearToSRGB(vec3 rgb)
{
    rgb = clamp(rgb, 0.0f, 1.0f);
    
    return mix(
        pow(rgb * 1.055f, vec3(1.f / 2.4f)) - 0.055f,
        rgb * 12.92f,
        LessThan(rgb, 0.0031308f)
    );
}



