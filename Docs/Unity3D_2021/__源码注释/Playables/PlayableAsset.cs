#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System.Collections.Generic;

namespace UnityEngine.Playables
{
    //
    // 摘要:
    //     A base class for assets that can be used to instantiate a Playable at runtime.
    [AssetFileNameExtensionAttribute("playable", new[] { })]
    [RequiredByNativeCodeAttribute]
    public abstract class PlayableAsset : ScriptableObject, IPlayableAsset
    {
        protected PlayableAsset();

        //
        // 摘要:
        //     The playback duration in seconds of the instantiated Playable.
        public virtual double duration { get; }
        //
        // 摘要:
        //     A description of the outputs of the instantiated Playable.
        public virtual IEnumerable<PlayableBinding> outputs { get; }

        //
        // 摘要:
        //     Implement this method to have your asset inject playables into the given graph.
        //
        // 参数:
        //   graph:
        //     The graph to inject playables into.
        //
        //   owner:
        //     The game object which initiated the build.
        //
        // 返回结果:
        //     The playable injected into the graph, or the root playable if multiple playables
        //     are injected.
        public abstract Playable CreatePlayable(PlayableGraph graph, GameObject owner);
    }
}

