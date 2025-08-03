#ifndef SUBSURFACE_SCATTERING_INCLUDED
#define SUBSURFACE_SCATTERING_INCLUDED


// 次表面散射参数
struct SSSDatas
{
    float strength;
    float3 color;
    
};


TEXTURE2D(_SSSThickness); SAMPLER(sampler_SSSThickness);


/*
    使用 thickness map 来描述模型的厚度
*/
float GetSubsurfaceScatteringThickness( float2 uv_ )
{
    float thickness = SAMPLE_TEXTURE2D(_SSSThickness, sampler_SSSThickness, uv_).r;
    return saturate(thickness); // 0:厚 , 1:薄
}



/*
    计算 SubsurfaceScattering 次表面散射 光照叠加值

    目前只实现了 背光环境下的 sss
*/
SSSDatas SubsurfaceScattering( 
    float3 Pix2Cam_, float3 lightDir_,  float3 normalWS_, 
    float3 lightColor_, float3 interiorColor_,
    float frontDistortion_, float frontPower_, float frontMultiply_, float frontSssIntensity_, 
    float backDistortion_,  float backPower_, float backMultiply_, float thickness_
)
{
    SSSDatas sssDatas_ = (SSSDatas)0;
    //---
    float3 V =  normalize(Pix2Cam_);
    float3 N = normalWS_;
    float3 L = lightDir_;
    //---
    float frontSSS = saturate(dot(V, -( -L + N * saturate(frontDistortion_) )));
    float backSSS  = saturate(dot(V, -(  L + N * saturate(backDistortion_) )));
    frontSSS = saturate(pow(frontSSS, frontPower_)) * frontMultiply_;
    backSSS  = saturate(pow(backSSS,  backPower_))  * backMultiply_;
    float sssStrength = saturate( (backSSS + frontSSS * frontSssIntensity_) * thickness_ );

    float3 sssColor = lerp(interiorColor_, lightColor_, sssStrength ) * sssStrength;
    //---
    sssDatas_.strength = sssStrength;
    sssDatas_.color = sssColor;
    return sssDatas_;
}




#endif 

