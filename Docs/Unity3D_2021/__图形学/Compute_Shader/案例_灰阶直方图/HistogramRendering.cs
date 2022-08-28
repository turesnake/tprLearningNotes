using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HistogramRendering : MonoBehaviour 
{

    public ComputeShader computeShader;
    public Texture2D     inputTexture; 
    public Material      material;


    // 仅用来查看 直方图信息, 后面可注释掉;
    public uint[] histogramDebugData;
   
    ComputeBuffer histogramBuffer;


    int handleMain;
    int handleInitialize;


    static int _HistogramData = Shader.PropertyToID("_HistogramData");
    static int _HistogramBuffer = Shader.PropertyToID("_HistogramBuffer");
    static int _InputTexture = Shader.PropertyToID("_InputTexture");
    static int _TexWidth = Shader.PropertyToID("_TexWidth");
    static int _TexHeight = Shader.PropertyToID("_TexHeight");


   
    void Start () 
    {
        if (null == computeShader || null == inputTexture || material == null ) 
        {
            Debug.Log("Shader or input texture missing.");
            return;
        }
         
        handleInitialize = computeShader.FindKernel("HistogramInitialize");
        handleMain = computeShader.FindKernel("HistogramMain");

        
        // 将 [0,1] 区间的 灰阶, 划分为 128 个层级, 做成 128 个 桶;
        histogramBuffer = new ComputeBuffer(128, sizeof(uint));
        histogramDebugData = new uint[128];

      
        if (handleInitialize < 0 || handleMain < 0 ||  null == histogramBuffer || null == histogramDebugData) 
        {
            Debug.Log("Initialization failed.");
            return;
        }

        computeShader.SetBuffer(handleInitialize, _HistogramBuffer, histogramBuffer);

        computeShader.SetTexture(handleMain, _InputTexture, inputTexture);
        computeShader.SetBuffer(handleMain, _HistogramBuffer, histogramBuffer);

        computeShader.SetInt( _TexWidth, inputTexture.width );
        computeShader.SetInt( _TexHeight, inputTexture.height );
    }
	

    void OnDestroy() 
    {
        if (null != histogramBuffer) 
        {
            histogramBuffer.Release();
            histogramBuffer = null;
        }
    }   
   

    void Update()
    {
        if (null == computeShader || null == inputTexture || material == null ||
            0 > handleInitialize || 0 > handleMain ||
            null == histogramBuffer || null == histogramDebugData) 
        {
            Debug.Log("Cannot compute histogram");
            return;
        }
        
        // divided by 64 in x because of [numthreads(64,1,1)] in the compute computeShader code
        // 一共需处理: 128 个 元素 (bin), 每个都初始化为 0;
        computeShader.Dispatch(
            handleInitialize, 
            128 / 64, 
            1, 
            1
        );
            
        // divided by 8 in x and y because of [numthreads(8,8,1)] in the compute computeShader code
        // 一整张 texture, 分成无数个 2x2 小块, 每个小块 仅采样一个像素; (减少采样次数)
        // 若是一张 2048*1024 的原始图, 则等价于处理一张 800x800 的图;
        computeShader.Dispatch(
            handleMain, 
            (inputTexture.width/2 + 7) / 8, 
            (inputTexture.height/2 + 7) / 8, 
            1
        );


        // 将直方图信息提取到 cpu 数组中, 方便展示... 未来废弃掉
        histogramBuffer.GetData(histogramDebugData);


        // 让 常规 computeShader 可以读取 直方图信息
        material.SetBuffer(_HistogramData, histogramBuffer);
        
        
    }

}
