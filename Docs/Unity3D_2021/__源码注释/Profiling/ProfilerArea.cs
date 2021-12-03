#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

namespace UnityEngine.Profiling
{
    /*
        The different areas of profiling, corresponding to the charts(图表) in "ProfilerWindow".(class)

        Each area corresponds to a chart in "ProfilerWindow" and the "accompanying detail pane"(随附的详细信息窗格) 
        in its bottom half. These are the categories that "group statistical data"(分组统计数据) 
        and provide additional insights into those specific areas.

        这些是对统计数据进行分组并提供对这些特定领域的额外见解的类别。

        按照上面的描述, 这个 "ProfilerWindow" 似乎指向 editor 中那个窗口;
    */
    public enum ProfilerArea//ProfilerArea__RR
    {
        //
        // 摘要:
        //     CPU statistics.
        CPU = 0,
        //
        // 摘要:
        //     GPU statistics.
        GPU = 1,
        //
        // 摘要:
        //     Rendering statistics.
        Rendering = 2,
        //
        // 摘要:
        //     Memory statistics.
        Memory = 3,
        //
        // 摘要:
        //     Audio statistics.
        Audio = 4,
        //
        // 摘要:
        //     Video playback statistics.
        Video = 5,
        //
        // 摘要:
        //     3D Physics statistics.
        Physics = 6,
        //
        // 摘要:
        //     2D physics statistics.
        Physics2D = 7,
        //
        // 摘要:
        //     Network messages statistics.
        NetworkMessages = 8,
        //
        // 摘要:
        //     Network operations statistics.
        NetworkOperations = 9,
        //
        // 摘要:
        //     UI statistics.
        UI = 10,
        //
        // 摘要:
        //     Detailed UI statistics.
        UIDetails = 11,
        //
        // 摘要:
        //     Global Illumination statistics.
        GlobalIllumination = 12,
        //
        // 摘要:
        //     Virtual Texturing statistics.
        VirtualTexturing = 13
    }
}

