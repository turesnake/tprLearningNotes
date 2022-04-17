// created by florian berger (flockaroo) - 2017
// License Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License.

// 2tweet fluid

void mainImage(out vec4 c,vec2 f)
{
    // with only this line and texelFetch also in BufA count goes down to 310 chars total
    // but color satures after a while, and noisy then
    //c=texelFetch(iChannel0,ivec2(f),0);
    
    c=sin(texture(iChannel0,f/iResolution.xy).xyxy*5.);
    //c+=c.yxyx;
    c-=c-length(fwidth(c.xy));
}

