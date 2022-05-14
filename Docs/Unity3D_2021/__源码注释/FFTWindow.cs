#region 程序集 UnityEngine.AudioModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.AudioModule.dll
#endregion

namespace UnityEngine
{
    //
    // 摘要:
    //     Spectrum 声谱 analysis windowing types.
    public enum FFTWindow
    {
        //
        // 摘要:
        //     W[n] = 1.0.
        Rectangular = 0,
        //
        // 摘要:
        //     W[n] = TRI(2n/N).
        Triangle = 1,
        //
        // 摘要:
        //     W[n] = 0.54 - (0.46 * COS(n/N) ).
        Hamming = 2,
        //
        // 摘要:
        //     W[n] = 0.5 * (1.0 - COS(n/N) ).
        Hanning = 3,
        //
        // 摘要:
        //     W[n] = 0.42 - (0.5 * COS(nN) ) + (0.08 * COS(2.0 * nN) ).
        Blackman = 4,
        //
        // 摘要:
        //     W[n] = 0.35875 - (0.48829 * COS(1.0 * nN)) + (0.14128 * COS(2.0 * nN)) - (0.01168
        //     * COS(3.0 * n/N)).
        BlackmanHarris = 5
    }
}
