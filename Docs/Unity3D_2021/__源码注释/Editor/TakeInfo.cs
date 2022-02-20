
#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion



namespace UnityEditor
{
    /*
        A Takeinfo object contains all the information needed to describe a take.

        猜测, 一个 take 就是 "一个镜头" 的意思; (可理解为一个 动作片段 )

    */
    [NativeTypeAttribute(Header = "Modules/AssetPipelineEditor/Public/ModelImporting/ModelImporter.h")]
    [UsedByNativeCodeAttribute]
    public struct TakeInfo//TakeInfo__RR
    {
        
        //     Take name as define from imported file.
        public string name;

        /*
            This is the default clip name for the clip generated for this take.

            Normally it should be the same than "TakeInfo.name" unless you are using the @ convention. 
            In this case the default clip name should be set to the same value than the name after @ convention. 
            Example: For Dude@run.fbx the default clip name will be run.

        */
        public string defaultClipName;
        
        //     Start time in second.
        //  This is always the time of the first key in this take.
        public float startTime;
       
        //     Stop time in second.
        //  This is always the time of the last key in this take.
        public float stopTime;
         
        //     Start time in second.
        //  This is eiter the time of the first key 
        //  or the start time for this take as define in your DCC tools.(比如 maya)
        public float bakeStartTime;

        
        //     Stop time in second.
        //  This is eiter the time of the last key 
        //  or the stop time for this take as define in your DCC tools. (比如 maya)
        public float bakeStopTime;

        //
        // 摘要:
        //     Sample rate of the take.
        public float sampleRate;
    }
}