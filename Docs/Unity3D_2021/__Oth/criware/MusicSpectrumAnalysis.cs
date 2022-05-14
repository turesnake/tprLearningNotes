
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

/* 
    基本步骤：
   1. 新建并初始化分析器 CriAtomExPlayerOutputAnalyzer
   2. 在声音播放前使用 AttachToAnalyzer 将分析器与音源绑定 
   3. 播放声音
   4. 程序更新时获取分析结果（结果为线性尺度，即将声音按频率平均划分音域，输出各音域的音量）
   5. （可选）将线性尺度结果转换为对数尺度（大部分市面软硬件产品所采用的显示方法）
*/

public class MusicSpectrumAnalysis : MonoBehaviour 
{

    // CriAtom音源, 类似于 AudioSource;
    // 需外部绑定
    public CriAtomSource atomSrc;


    // 设置频谱分析的频域数量，最高512
    // 需要线性尺度->对数尺度转换时建议尽量使用高数值
    const int originalBandNum = CriAtomExOutputAnalyzer.MaximumSpectrumBands;

    // 线性尺度->对数尺度转换后的频域数量
    const int logBandNum = 16;

    
    CriAtomExOutputAnalyzer anlyzr; // 频谱分析器 
    
    
    float[] spctLv = new float[originalBandNum]; // 频谱分析结果, 我们要的 512 个
    public float[] logSpctLv = new float[logBandNum]; // 线性尺度->对数尺度转换结果, 进阶版 16 个
    
    bool isError = false;

    void Start ()
    {
        isError = false;
        if( atomSrc == null )
        {
            Debug.LogWarning("需要绑定: atomSrc");
            isError = true;
            return;
        }


        // 频谱分析器的初始化
		CriAtomExOutputAnalyzer.Config anlyzrConfig = new CriAtomExOutputAnalyzer.Config();
		anlyzrConfig.enableSpectrumAnalyzer = true; // 开启 频域分析
		anlyzrConfig.numSpectrumAnalyzerBands = originalBandNum; // 设置 频域 分段数量
        
		this.anlyzr = new CriAtomExOutputAnalyzer(anlyzrConfig);

		this.atomSrc.AttachToAnalyzer(anlyzr);

        // 播放
        atomSrc.Play();
    }
	
	void Update ()
    {
        if( isError )
        {   
            Debug.LogWarning("需要绑定: atomSrc");
            return;
        }
        // 获取线性尺度的频谱分析结果
        anlyzr.GetSpectrumLevels(ref spctLv);

        // 对频谱分析结果进行线性尺度->对数尺度转换
        Linear2Log(ref spctLv, ref logSpctLv);

    }

	void OnDestroy() {
		this.atomSrc.DetachFromAnalyzer(anlyzr); // 与 "output data analysis module"(输出数据分析模块) 分离
		this.anlyzr.Dispose();
	}





	// 线性尺度->对数尺度转换
	bool Linear2Log(ref float[] iLinearLvs, ref float[] oLogLvs)
    {
        if (iLinearLvs == null || oLogLvs == null )
        { return false; }

        float   lowBand, highBand, tmpVal;
        int     lowBandIdx, highBandIdx, i, j;
        int   iBandCnt = iLinearLvs.Length;
        int   oBandCnt = oLogLvs.Length;

        for (i = 0; i < oBandCnt; ++i)
        {
            // 求各个对数频域所对应的线性频率范围 
            lowBand = Mathf.Pow((float)iBandCnt, (float)i / (float)oBandCnt);
            highBand = Mathf.Pow((float)iBandCnt, (float)(i + 1) / (float)oBandCnt);
            
            // 取整 
            lowBandIdx = Mathf.FloorToInt(lowBand) - 1;
            highBandIdx = Mathf.FloorToInt(highBand) - 1;

            // 求频率范围内电平平均值 
            tmpVal = 0;
            for (j = lowBandIdx; j <= highBandIdx; ++j)
            {
                tmpVal += iLinearLvs[j];
            }
            tmpVal /= highBandIdx - lowBandIdx + 1;

            // 输出转换结果 
            oLogLvs[i] = tmpVal;
        }
        return true;
    }
    

    // 分析结果转换为分贝数后显示
    // bandCluster: 带簇;
    // bandNum: 必须等于 bandCluster 元素的个数
    // origSpct: 原始的频谱数据
    void DrawSpectrum(List<GameObject> bandCluster, int bandNum, ref float[] origSpct)
    {
        if (bandCluster != null && bandCluster.Count == bandNum)
        {
            for (int i = 0; i < bandNum; ++i)
            {
                Vector3 tempScale = bandCluster[i].transform.localScale;
                Vector3 tempPos = bandCluster[i].transform.position;

                float tempY;

                // 分贝转换
                tempY = Mathf.Log10(origSpct[i]) * 20.0f;

                // 设置显示用的数值规模（取决于用户要求
                tempY = (tempY + 60.0f) / 20.0f;

                // 去掉异常数值，和低于0的数值（取决于用户要求）
                if (tempY < 0 || float.IsNaN(tempY) || float.IsInfinity(tempY))
                { tempY = 0; }

                // 显示，这里应修改为用户定义的显示方法
                bandCluster[i].transform.localScale = new Vector3(tempScale.x, tempY, tempScale.z);
                bandCluster[i].transform.position = new Vector3(tempPos.x, tempY / 2.0f, tempPos.z);
            }
        }
    }


}
