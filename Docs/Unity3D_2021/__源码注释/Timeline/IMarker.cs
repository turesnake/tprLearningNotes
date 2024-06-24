#region Assembly Unity.Timeline, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// e:\Unity_2_projects\URP_ZAA2\Library\ScriptAssemblies\Unity.Timeline.dll
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

namespace UnityEngine.Timeline;

public interface IMarker
{
    double time { get; set; }

    TrackAsset parent { get; }  // 自己所属的 tarck 轨道的名字,  不是 marker 自己的名字

    void Initialize(TrackAsset parent);
}
