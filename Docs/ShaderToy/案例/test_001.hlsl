

/*


   
fragCoord:   本像素坐标, 像素值; [0,w], [0,h]

着色器输入
uniform vec3      iResolution;           // viewport resolution (in pixels) 画布尺寸, wh, 像素值;
uniform float     iTime;                 // shader playback time (in seconds) 时间
uniform float     iTimeDelta;            // render time (in seconds)
uniform int       iFrame;                // shader playback frame
uniform float     iChannelTime[4];       // channel playback time (in seconds) 四个贴图通道 各自的 播放时间
uniform vec3      iChannelResolution[4]; // channel resolution (in pixels)     四个贴图通道 各自的 分辨率
uniform vec4      iMouse;                // mouse pixel coords. xy: current (if 鼠标左键 down), zw: click
uniform samplerXX iChannel0..3;          // input channel. XX = 2D/Cube         四个贴图通道
uniform vec4      iDate;                 // (year, month, day, time in seconds)
uniform float     iSampleRate;           // sound sample rate (i.e., 44100)     声音采样率

*/



// 主函数
void mainImage( out vec4 fragColor, in vec2 fragCoord )
{

    // Normalized pixel coordinates [0,1]
    vec2 uv = fragCoord/iResolution.xy;

    

    // Time varying pixel color
    //vec3 col = 0.5 + 0.5*cos(iTime+uv.xyx+vec3(0,2,4));
    vec3 color = vec3( 0.2, 0.3, 0.5 );

    // Output to screen  但是
    fragColor = vec4(color,1.0);

}

