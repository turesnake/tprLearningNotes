#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System.ComponentModel;

namespace UnityEngine.Playables
{


    /*
        Use the PlayableGraph to manage Playable creations and destructions.


        入门教程
        https://mp.weixin.qq.com/s?__biz=MzkyMTM5Mjg3NQ==&mid=2247535622&idx=1&sn=b96a2d8ac55b49e74261d91bbffa944c&source=41#wechat_redirect



    */
    [NativeHeaderAttribute("Runtime/Export/Director/PlayableGraph.bindings.h")]
    [NativeHeaderAttribute("Runtime/Director/Core/HPlayableGraph.h")]
    [NativeHeaderAttribute("Runtime/Director/Core/HPlayableOutput.h")]
    [NativeHeaderAttribute("Runtime/Director/Core/HPlayable.h")]
    [UsedByNativeCodeAttribute]
    public struct PlayableGraph
    {

        //
        // 摘要:
        //     Creates a PlayableGraph.
        //
        // 参数:
        //   name:
        //     The name of the graph.
        //
        // 返回结果:
        //     The newly created PlayableGraph.
        public static PlayableGraph Create(string name);
        public static PlayableGraph Create();

        /*
            bool Returns true if connection is successful.
        */
        public bool Connect<U, V>(U source, int sourceOutputPort, V destination, int destinationInputPort)
            where U : struct, IPlayable
            where V : struct, IPlayable;

        //
        // 摘要:
        //     Destroys the graph.
        [FreeFunctionAttribute("PlayableGraphBindings::Destroy", HasExplicitThis = true, ThrowsException = true)]
        public void Destroy();

        public void DestroyOutput<U>(U output) where U : struct, IPlayableOutput;

        public void DestroyPlayable<U>(U playable) where U : struct, IPlayable;

        public void DestroySubgraph<U>(U playable) where U : struct, IPlayable;

        public void Disconnect<U>(U input, int inputPort) where U : struct, IPlayable;

        //
        // 摘要:
        //     Evaluates all the PlayableOutputs in the graph, and updates all the connected
        //     Playables in the graph.
        //
        // 参数:
        //   deltaTime:
        //     The time in seconds by which to advance each Playable in the graph.
        [FreeFunctionAttribute("PlayableGraphBindings::Evaluate", HasExplicitThis = true, ThrowsException = true)]
        public void Evaluate([DefaultValue("0")] float deltaTime);

        //
        // 摘要:
        //     Evaluates all the PlayableOutputs in the graph, and updates all the connected
        //     Playables in the graph.
        //
        // 参数:
        //   deltaTime:
        //     The time in seconds by which to advance each Playable in the graph.
        public void Evaluate();

        //
        // 摘要:
        //     Returns the name of the PlayableGraph.
        [FreeFunctionAttribute("PlayableGraphBindings::GetEditorName", HasExplicitThis = true, ThrowsException = true)]
        public string GetEditorName();

        //
        // 摘要:
        //     Get PlayableOutput at the given index in the graph.
        //
        // 参数:
        //   index:
        //     The output index.
        //
        // 返回结果:
        //     The PlayableOutput at this given index, otherwise null.
        public PlayableOutput GetOutput(int index);

        public PlayableOutput GetOutputByType<T>(int index) where T : struct, IPlayableOutput;

        //
        // 摘要:
        //     Returns the number of PlayableOutput in the graph.
        //
        // 返回结果:
        //     The number of PlayableOutput in the graph.
        [FreeFunctionAttribute("PlayableGraphBindings::GetOutputCount", HasExplicitThis = true, ThrowsException = true)]
        public int GetOutputCount();

        public int GetOutputCountByType<T>() where T : struct, IPlayableOutput;

        //
        // 摘要:
        //     Returns the number of Playable owned by the Graph.
        [FreeFunctionAttribute("PlayableGraphBindings::GetPlayableCount", HasExplicitThis = true, ThrowsException = true)]
        public int GetPlayableCount();

        //
        // 摘要:
        //     Returns the table used by the graph to resolve ExposedReferences.
        [FreeFunctionAttribute("PlayableGraphBindings::GetResolver", HasExplicitThis = true, ThrowsException = true)]
        public IExposedPropertyTable GetResolver();

        //
        // 摘要:
        //     Returns the Playable with no output connections at the given index.
        //
        // 参数:
        //   index:
        //     The index of the root Playable.
        public Playable GetRootPlayable(int index);

        //
        // 摘要:
        //     Returns the number of Playable owned by the Graph that have no connected outputs.
        [FreeFunctionAttribute("PlayableGraphBindings::GetRootPlayableCount", HasExplicitThis = true, ThrowsException = true)]
        public int GetRootPlayableCount();

        //
        // 摘要:
        //     Returns how time is incremented when playing back.
        [FreeFunctionAttribute("PlayableGraphBindings::GetTimeUpdateMode", HasExplicitThis = true, ThrowsException = true)]
        public DirectorUpdateMode GetTimeUpdateMode();

        //
        // 摘要:
        //     Indicates that a graph has completed its operations.
        //
        // 返回结果:
        //     A boolean indicating if the graph is done playing or not.
        [FreeFunctionAttribute("PlayableGraphBindings::IsDone", HasExplicitThis = true, ThrowsException = true)]
        public bool IsDone();

        //
        // 摘要:
        //     Indicates that a graph is presently running.
        //
        // 返回结果:
        //     A boolean indicating if the graph is playing or not.
        [FreeFunctionAttribute("PlayableGraphBindings::IsPlaying", HasExplicitThis = true, ThrowsException = true)]
        public bool IsPlaying();

        //
        // 摘要:
        //     Returns true if the PlayableGraph has been properly constructed using PlayableGraph.CreateGraph
        //     and is not deleted.
        //
        // 返回结果:
        //     A boolean indicating if the graph is invalid or not.
        public bool IsValid();

        //
        // 摘要:
        //     Plays the graph.
        [FreeFunctionAttribute("PlayableGraphBindings::Play", HasExplicitThis = true, ThrowsException = true)]
        public void Play();

        //
        // 摘要:
        //     Changes the table used by the graph to resolve ExposedReferences.
        //
        // 参数:
        //   value:
        [FreeFunctionAttribute("PlayableGraphBindings::SetResolver", HasExplicitThis = true, ThrowsException = true)]
        public void SetResolver(IExposedPropertyTable value);

        //
        // 摘要:
        //     Changes how time is incremented when playing back.
        //
        // 参数:
        //   value:
        //     The new DirectorUpdateMode.
        [FreeFunctionAttribute("PlayableGraphBindings::SetTimeUpdateMode", HasExplicitThis = true, ThrowsException = true)]
        public void SetTimeUpdateMode(DirectorUpdateMode value);

        //
        // 摘要:
        //     Stops the graph, if it is playing.
        [FreeFunctionAttribute("PlayableGraphBindings::Stop", HasExplicitThis = true, ThrowsException = true)]
        public void Stop();

    }
}

