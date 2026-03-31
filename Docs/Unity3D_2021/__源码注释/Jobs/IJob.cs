#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 9.1.0.7988
#endregion

using Unity.Jobs.LowLevel.Unsafe;

namespace Unity.Jobs;

[JobProducerType(typeof(IJobExtensions.JobStruct<>))]
public interface IJob
{
    //
    // Summary:
    //     Implement this method to perform work on a worker thread.
    void Execute();
}

