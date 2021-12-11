# ================================================================ #
#               hlsl 文件依赖关系  11.0
# ================================================================ #






# ---------------------------------------------- #
#  urp ShaderLibrary/Input.hlsl    ==
# ---------------------------------------------- #
    urp ShaderLibrary/ShaderTypes.cs.hlsl  ==
    urp ShaderLibrary/Deprecated.hlsl   ==


# ---------------------------------------------- #
#  urp ShaderLibrary/Core.hlsl     ==
# ---------------------------------------------- #
    core ShaderLibrary/Common.hlsl
    core ShaderLibrary/Packing.hlsl
    core ShaderLibrary/Version.hlsl
    urp ShaderLibrary/Input.hlsl 
        urp ShaderLibrary/ShaderTypes.cs.hlsl  ==
        urp ShaderLibrary/Deprecated.hlsl   ==


# ---------------------------------------------- #
#  urp ShaderLibrary/SurfaceInput.hlsl    ==
# ---------------------------------------------- #
    urp ShaderLibrary/Core.hlsl
        core ShaderLibrary/Common.hlsl
        core ShaderLibrary/Packing.hlsl
        core ShaderLibrary/Version.hlsl
        urp ShaderLibrary/Input.hlsl
            urp ShaderLibrary/ShaderTypes.cs.hlsl  ==
            urp ShaderLibrary/Deprecated.hlsl   ==

    urp ShaderLibrary/SurfaceData.hlsl ==
    core ShaderLibrary/Packing.hlsl
    core ShaderLibrary/CommonMaterial.hlsl

    



# ---------------------------------------------- #
#  urp Shaders/LitInput.hlsl   ==
# ---------------------------------------------- #

    urp ShaderLibrary/Core.hlsl
        core ShaderLibrary/Common.hlsl
        core ShaderLibrary/Packing.hlsl
        core ShaderLibrary/Version.hlsl
        urp ShaderLibrary/Input.hlsl
            urp ShaderLibrary/ShaderTypes.cs.hlsl  ==
            urp ShaderLibrary/Deprecated.hlsl   ==

    core ShaderLibrary/CommonMaterial.hlsl

    
    urp ShaderLibrary/SurfaceInput.hlsl
        urp ShaderLibrary/SurfaceData.hlsl ==
        core ShaderLibrary/Packing.hlsl

    core ShaderLibrary/ParallaxMapping.hlsl

# ---------------------------------------------- #
#  urp ShaderLibrary/Shadows.hlsl   ==
# ---------------------------------------------- #
    core ShaderLibrary/Common.hlsl
    core ShaderLibrary/Shadow/ShadowSamplingTent.hlsl
    urp ShaderLibrary/Core.hlsl
        core ShaderLibrary/Packing.hlsl
        core ShaderLibrary/Version.hlsl
        urp ShaderLibrary/Input.hlsl
            urp ShaderLibrary/ShaderTypes.cs.hlsl  ==
            urp ShaderLibrary/Deprecated.hlsl   ==


# ---------------------------------------------- #
#  urp ShaderLibrary/Lighting.hlsl   ==
# ---------------------------------------------- #
    core ShaderLibrary/Common.hlsl
    core ShaderLibrary/CommonMaterial.hlsl
    core ShaderLibrary/EntityLighting.hlsl
    core ShaderLibrary/ImageBasedLighting.hlsl
    core ShaderLibrary/BSDF.hlsl

    urp ShaderLibrary/Core.hlsl
        core ShaderLibrary/Packing.hlsl
        core ShaderLibrary/Version.hlsl
        urp ShaderLibrary/Input.hlsl
            urp ShaderLibrary/ShaderTypes.cs.hlsl  ==
            urp ShaderLibrary/Deprecated.hlsl   ==
   
    urp ShaderLibrary/SurfaceData.hlsl ==

    urp ShaderLibrary/Shadows.hlsl
        core ShaderLibrary/Shadow/ShadowSamplingTent.hlsl
        
    
# ---------------------------------------------- #
#  urp ShaderLibrary/ShaderVariablesFunctions.deprecated.hlsl   ==
# ---------------------------------------------- #
    urp ShaderLibrary/Input.hlsl
        urp ShaderLibrary/ShaderTypes.cs.hlsl  ==
        urp ShaderLibrary/Deprecated.hlsl   ==


# ---------------------------------------------- #
#  urp ShaderLibrary/ShaderVariablesFunctions.hlsl   ==
# ---------------------------------------------- #
    urp ShaderLibrary/ShaderVariablesFunctions.deprecated.hlsl
        urp ShaderLibrary/Input.hlsl
            urp ShaderLibrary/ShaderTypes.cs.hlsl  ==
            urp ShaderLibrary/Deprecated.hlsl   ==


# ---------------------------------------------- #
#  urp ShaderLibrary/DeclareDepthTexture.hlsl   ==
# ---------------------------------------------- #
    urp ShaderLibrary/Core.hlsl
        core ShaderLibrary/Common.hlsl
        core ShaderLibrary/Packing.hlsl
        core ShaderLibrary/Version.hlsl
        urp ShaderLibrary/Input.hlsl 
            urp ShaderLibrary/ShaderTypes.cs.hlsl  ==
            urp ShaderLibrary/Deprecated.hlsl   ==


# ---------------------------------------------- #
#  urp ShaderLibrary/DeclareNormalsTexture.hlsl   ==
# ---------------------------------------------- #
    urp ShaderLibrary/Core.hlsl
        core ShaderLibrary/Common.hlsl
        core ShaderLibrary/Packing.hlsl
        core ShaderLibrary/Version.hlsl
        urp ShaderLibrary/Input.hlsl 
            urp ShaderLibrary/ShaderTypes.cs.hlsl  ==
            urp ShaderLibrary/Deprecated.hlsl   ==


# ---------------------------------------------- #
#  urp ShaderLibrary/SSAO.hlsl   ==
# ---------------------------------------------- #
    core ShaderLibrary/Common.hlsl

    urp ShaderLibrary/ShaderVariablesFunctions.hlsl
        urp ShaderLibrary/ShaderVariablesFunctions.deprecated.hlsl
        urp ShaderLibrary/Input.hlsl
            urp ShaderLibrary/ShaderTypes.cs.hlsl  ==
            urp ShaderLibrary/Deprecated.hlsl   ==

    urp ShaderLibrary/DeclareDepthTexture.hlsl
        urp ShaderLibrary/Core.hlsl
            core ShaderLibrary/Packing.hlsl
            core ShaderLibrary/Version.hlsl
            
    urp ShaderLibrary/DeclareNormalsTexture.hlsl





































