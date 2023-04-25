#region 程序集 UnityEngine.DirectorModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.DirectorModule.dll
#endregion

using System;

namespace UnityEngine.Playables
{
    //
    // 摘要:
    //     Instantiates a PlayableAsset and controls playback of Playable objects.
    [NativeHeaderAttribute("Runtime/Mono/MonoBehaviour.h")]
    [NativeHeaderAttribute("Modules/Director/PlayableDirector.h")]
    [RequiredByNativeCodeAttribute]
    public class PlayableDirector : Behaviour, IExposedPropertyTable
    {
        public PlayableDirector();

        //
        // 摘要:
        //     The duration of the Playable in seconds.
        public double duration { get; }
        //
        // 摘要:
        //     The time at which the Playable should start when first played.
        public double initialTime { get; set; }
        //
        // 摘要:
        //     The component's current time. This value is incremented according to the PlayableDirector.timeUpdateMode
        //     when it is playing. You can also change this value manually.
        public double time { get; set; }

        //
        // 摘要:
        //     Controls how time is incremented when playing back.
        public DirectorUpdateMode timeUpdateMode { get; set; }

        //
        // 摘要:
        //     Whether the playable asset will start playing back as soon as the component awakes.
        public bool playOnAwake { get; set; }

        //
        // 摘要:
        //     The PlayableGraph created by the PlayableDirector.
        public PlayableGraph playableGraph { get; }
        
        //
        // 摘要:
        //     The PlayableAsset that is used to instantiate a playable for playback.
        public PlayableAsset playableAsset { get; set; }
        //
        // 摘要:
        //     Controls how the time is incremented when it goes beyond the duration of the
        //     playable.
        public DirectorWrapMode extrapolationMode { get; set; }
        //
        // 摘要:
        //     The current playing state of the component. (Read Only)
        public PlayState state { get; }

        public event Action<PlayableDirector> stopped;
        public event Action<PlayableDirector> played;
        public event Action<PlayableDirector> paused;

        //
        // 摘要:
        //     Clears the binding of a reference object.
        //
        // 参数:
        //   key:
        //     The source object in the PlayableBinding.
        [NativeMethodAttribute("ClearBindingFor")]
        public void ClearGenericBinding(Object key);
        //
        // 摘要:
        //     Clears an exposed reference value.
        //
        // 参数:
        //   id:
        //     Identifier of the ExposedReference.
        public void ClearReferenceValue(PropertyName id);
        //
        // 摘要:
        //     Tells the PlayableDirector to evaluate it's PlayableGraph on the next update.
        public void DeferredEvaluate();
        //
        // 摘要:
        //     Evaluates the currently playing Playable at the current time.
        [NativeThrowsAttribute]
        public void Evaluate();
        //
        // 摘要:
        //     Returns a binding to a reference object.
        //
        // 参数:
        //   key:
        //     The object that acts as a key.
        [NativeMethodAttribute("GetBindingFor")]
        public Object GetGenericBinding(Object key);
        public Object GetReferenceValue(PropertyName id, out bool idValid);
        //
        // 摘要:
        //     Pauses playback of the currently running playable.
        public void Pause();
        //
        // 摘要:
        //     Instatiates a Playable using the provided PlayableAsset and starts playback.
        //
        // 参数:
        //   asset:
        //     An asset to instantiate a playable from.
        //
        //   mode:
        //     What to do when the time passes the duration of the playable.
        [NativeThrowsAttribute]
        public void Play();
        //
        // 摘要:
        //     Instatiates a Playable using the provided PlayableAsset and starts playback.
        //
        // 参数:
        //   asset:
        //     An asset to instantiate a playable from.
        //
        //   mode:
        //     What to do when the time passes the duration of the playable.
        public void Play(PlayableAsset asset, DirectorWrapMode mode);
        //
        // 摘要:
        //     Instatiates a Playable using the provided PlayableAsset and starts playback.
        //
        // 参数:
        //   asset:
        //     An asset to instantiate a playable from.
        //
        //   mode:
        //     What to do when the time passes the duration of the playable.
        public void Play(PlayableAsset asset);
        //
        // 摘要:
        //     Rebinds each PlayableOutput of the PlayableGraph.
        [NativeThrowsAttribute]
        public void RebindPlayableGraphOutputs();
        //
        // 摘要:
        //     Discards the existing PlayableGraph and creates a new instance.
        [NativeThrowsAttribute]
        public void RebuildGraph();
        //
        // 摘要:
        //     Resume playing a paused playable.
        public void Resume();


        //
        // 摘要:
        //     Sets the binding of a reference object from a PlayableBinding.
        //
        // 参数:
        //   key:
        //     The source object in the PlayableBinding.
        //
        //   value:
        //     The object to bind to the key.
        public void SetGenericBinding(Object key, Object value);


        //
        // 摘要:
        //     Sets an ExposedReference value.
        //
        // 参数:
        //   id:
        //     Identifier of the ExposedReference.
        //
        //   value:
        //     The object to bind to set the reference value to.
        public void SetReferenceValue(PropertyName id, Object value);
        //
        // 摘要:
        //     Stops playback of the current Playable and destroys the corresponding graph.
        public void Stop();
    }
}

