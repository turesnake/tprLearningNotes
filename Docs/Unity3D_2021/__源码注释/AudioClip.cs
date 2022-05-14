#region 程序集 UnityEngine.AudioModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.AudioModule.dll
#endregion

using System;

namespace UnityEngine
{
    //
    // 摘要:
    //     A container for audio data.
    [NativeHeaderAttribute("Modules/Audio/Public/ScriptBindings/Audio.bindings.h")]
    [StaticAccessorAttribute("AudioClipBindings", Bindings.StaticAccessorType.DoubleColon)]
    public sealed class AudioClip : Object
    {
        //
        // 摘要:
        //     The length of the audio clip in seconds. (Read Only)
        [NativePropertyAttribute("LengthSec")]
        public float length { get; }

        /*
        // 摘要:
        //     Returns true if the AudioClip is ready to play (read-only).
        [Obsolete("Use AudioClip.loadState instead to get more detailed information about the loading process.")]
        public bool isReadyToPlay { get; }
        */ 

        //
        // 摘要:
        //     The sample frequency of the clip in Hertz. (Read Only)
        public int frequency { get; }
        //
        // 摘要:
        //     The number of channels in the audio clip. (Read Only)
        [NativePropertyAttribute("ChannelCount")]
        public int channels { get; }
        //
        // 摘要:
        //     The length of the audio clip in samples. (Read Only)
        [NativePropertyAttribute("SampleCount")]
        public int samples { get; }
        //
        // 摘要:
        //     Returns true if this audio clip is ambisonic (read-only).
        public bool ambisonic { get; }
        //
        // 摘要:
        //     The load type of the clip (read-only).
        public AudioClipLoadType loadType { get; }
        //
        // 摘要:
        //     Preloads audio data of the clip when the clip asset is loaded. When this flag
        //     is off, scripts have to call AudioClip.LoadAudioData() to load the data before
        //     the clip can be played. Properties like length, channels and format are available
        //     before the audio data has been loaded.
        public bool preloadAudioData { get; }
        //
        // 摘要:
        //     Corresponding to the "Load In Background" flag in the inspector, when this flag
        //     is set, the loading will happen delayed without blocking the main thread.
        public bool loadInBackground { get; }

        //
        // 摘要:
        //     Returns the current load state of the audio data associated with an AudioClip.
        public AudioDataLoadState loadState { get; }

        /*
        [Obsolete("The _3D argument of AudioClip is deprecated. Use the spatialBlend property of AudioSource instead to morph between 2D and 3D playback.")]
        public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool _3D, bool stream, PCMReaderCallback pcmreadercallback, PCMSetPositionCallback pcmsetpositioncallback);
        */ 

        public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool stream, PCMReaderCallback pcmreadercallback, PCMSetPositionCallback pcmsetpositioncallback);
        
        /*
        [Obsolete("The _3D argument of AudioClip is deprecated. Use the spatialBlend property of AudioSource instead to morph between 2D and 3D playback.")]
        public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool _3D, bool stream, PCMReaderCallback pcmreadercallback);
        */ 

        /*
        // 摘要:
        //     Creates a user AudioClip with a name and with the given length in samples, channels
        //     and frequency.
        //
        // 参数:
        //   name:
        //     Name of clip.
        //
        //   lengthSamples:
        //     Number of sample frames.
        //
        //   channels:
        //     Number of channels per frame.
        //
        //   frequency:
        //     Sample frequency of clip.
        //
        //   _3D:
        //     Audio clip is played back in 3D.
        //
        //   stream:
        //     True if clip is streamed, that is if the pcmreadercallback generates data on
        //     the fly.
        //
        //   pcmreadercallback:
        //     This callback is invoked to generate a block of sample data. Non-streamed clips
        //     call this only once at creation time while streamed clips call this continuously.
        //
        //   pcmsetpositioncallback:
        //     This callback is invoked whenever the clip loops or changes playback position.
        //
        // 返回结果:
        //     A reference to the created AudioClip.
        [Obsolete("The _3D argument of AudioClip is deprecated. Use the spatialBlend property of AudioSource instead to morph between 2D and 3D playback.")]
        public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool _3D, bool stream);
        */


        //
        // 摘要:
        //     Creates a user AudioClip with a name and with the given length in samples, channels
        //     and frequency.
        //
        // 参数:
        //   name:
        //     Name of clip.
        //
        //   lengthSamples:
        //     Number of sample frames.
        //
        //   channels:
        //     Number of channels per frame.
        //
        //   frequency:
        //     Sample frequency of clip.
        //
        //   _3D:
        //     Audio clip is played back in 3D.
        //
        //   stream:
        //     True if clip is streamed, that is if the pcmreadercallback generates data on
        //     the fly.
        //
        //   pcmreadercallback:
        //     This callback is invoked to generate a block of sample data. Non-streamed clips
        //     call this only once at creation time while streamed clips call this continuously.
        //
        //   pcmsetpositioncallback:
        //     This callback is invoked whenever the clip loops or changes playback position.
        //
        // 返回结果:
        //     A reference to the created AudioClip.
        public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool stream);
        public static AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool stream, PCMReaderCallback pcmreadercallback);
        //
        // 摘要:
        //     Fills an array with sample data from the clip.
        //
        // 参数:
        //   data:
        //
        //   offsetSamples:
        public bool GetData(float[] data, int offsetSamples);
        //
        // 摘要:
        //     Loads the audio data of a clip. Clips that have "Preload Audio Data" set will
        //     load the audio data automatically.
        //
        // 返回结果:
        //     Returns true if loading succeeded.
        public bool LoadAudioData();
        //
        // 摘要:
        //     Set sample data in a clip.
        //
        // 参数:
        //   data:
        //
        //   offsetSamples:
        public bool SetData(float[] data, int offsetSamples);
        //
        // 摘要:
        //     Unloads the audio data associated with the clip. This works only for AudioClips
        //     that are based on actual sound file assets.
        //
        // 返回结果:
        //     Returns false if unloading failed.
        public bool UnloadAudioData();

        //
        // 摘要:
        //     Delegate called each time AudioClip reads data.
        //
        // 参数:
        //   data:
        //     Array of floats containing data read from the clip.
        public delegate void PCMReaderCallback(float[] data);
        //
        // 摘要:
        //     Delegate called each time AudioClip changes read position.
        //
        // 参数:
        //   position:
        //     New position in the audio clip.
        public delegate void PCMSetPositionCallback(int position);
    }
}
