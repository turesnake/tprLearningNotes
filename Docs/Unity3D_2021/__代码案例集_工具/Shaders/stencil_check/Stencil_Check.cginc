#if !defined(TPR_STENCIL_CHECK)
#define TPR_STENCIL_CHECK


struct V2F {
    float4 posCS    : SV_POSITION;
};

V2F vert ( float4 vertex : POSITION ){
    V2F i;
    i.posCS = UnityObjectToClipPos(vertex);
    return i;
}


float4 frag (V2F i) : SV_TARGET {
    #if !defined(_IS_PASS)
        clip(-1);
    #endif
    return _COLOR;          
}



#endif
