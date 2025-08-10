
#ifndef RIM_LIGHTING_INCLUDED
#define RIM_LIGHTING_INCLUDED


// x 在区间[t1,t2] 中, 求区间[s1,s2] 中同比例的点的值;
float Remap( float t1, float t2, float s1, float s2, float x )
{
    return ((x - t1) / (t2 - t1) * (s2 - s1) + s1);
}


/*
    Rim: 边缘光
*/
float3 GetRimLighting(
    float3 Pix2Cam_, float3 lightDir_, float3 normalWS_, 
    float3 lightColor_, float3 rimColor_,
    float rimPower_, float rimMultiply_, float sssStrength_
)
{
    float3 V =  normalize(Pix2Cam_);
    float3 N = normalWS_;
    float3 L = lightDir_;
    //---
    float rim = 1.0 - saturate(dot(N,V)); // 0:正视面, 1:边缘面

    float k1 = dot(-L,N);
    //k1 = Remap( -0.5, 1, 0, 1, k1 ));

    k1 =saturate(    smoothstep(-0.7, 0, k1) );

    rim *= k1;

    float rimValue = lerp(rim, 0, sssStrength_); // 有了 sss 了就削弱 边缘光
    float3 rimColor = lerp(rimColor_, lightColor_, rimValue) * pow(abs(rimValue), rimPower_) * rimMultiply_;  
    return rimColor;
}





#endif