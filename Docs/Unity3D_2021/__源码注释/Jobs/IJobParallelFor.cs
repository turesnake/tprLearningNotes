#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 9.1.0.7988
#endregion

using Unity.Jobs.LowLevel.Unsafe;

namespace Unity.Jobs;

[JobProducerType(typeof(IJobParallelForExtensions.ParallelForJobStruct<>))]
public interface IJobParallelFor
{
    //
    // Summary:
    //     Implement this method to perform work against a specific iteration index.
    //
    // Parameters:
    //   index:
    //     The index of the Parallel for loop at which to perform work.
    void Execute(int index);
}
