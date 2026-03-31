#region Assembly UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 9.1.0.7988
#endregion

using System;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs.LowLevel.Unsafe;

namespace Unity.Jobs;

//
// Summary:
//     Extension methods for Jobs using the IJobParallelFor.
public static class IJobParallelForExtensions
{
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    internal struct ParallelForJobStruct<T> where T : struct, IJobParallelFor
    {
        public delegate void ExecuteJobFunction(ref T data, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex);

        public static readonly IntPtr jobReflectionData = JobsUtility.CreateJobReflectionData(typeof(T), new ExecuteJobFunction(Execute));

        public unsafe static void Execute(ref T jobData, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex)
        {
            int beginIndex;
            int endIndex;
            while (JobsUtility.GetWorkStealingRange(ref ranges, jobIndex, out beginIndex, out endIndex))
            {
                JobsUtility.PatchBufferMinMaxRanges(bufferRangePatchData, UnsafeUtility.AddressOf(ref jobData), beginIndex, endIndex - beginIndex);
                int num = endIndex;
                for (int i = beginIndex; i < num; i++)
                {
                    jobData.Execute(i);
                }
            }
        }
    }

    public unsafe static JobHandle Schedule<T>(this T jobData, int arrayLength, int innerloopBatchCount, JobHandle dependsOn = default(JobHandle)) where T : struct, IJobParallelFor
    {
        JobsUtility.JobScheduleParameters parameters = new JobsUtility.JobScheduleParameters(UnsafeUtility.AddressOf(ref jobData), ParallelForJobStruct<T>.jobReflectionData, dependsOn, ScheduleMode.Batched);
        return JobsUtility.ScheduleParallelFor(ref parameters, arrayLength, innerloopBatchCount);
    }

    public unsafe static void Run<T>(this T jobData, int arrayLength) where T : struct, IJobParallelFor
    {
        JobsUtility.JobScheduleParameters parameters = new JobsUtility.JobScheduleParameters(UnsafeUtility.AddressOf(ref jobData), ParallelForJobStruct<T>.jobReflectionData, default(JobHandle), ScheduleMode.Run);
        JobsUtility.ScheduleParallelFor(ref parameters, arrayLength, arrayLength);
    }
}

