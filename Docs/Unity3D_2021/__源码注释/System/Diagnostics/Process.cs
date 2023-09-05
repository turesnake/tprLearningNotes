#region Assembly netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// D:\Unity_1_editors\Unity 2021.3.14f1\Editor\Data\NetStandard\ref\2.1.0\netstandard.dll
#endregion

using System.ComponentModel;
using System.IO;
using System.Security;
using Microsoft.Win32.SafeHandles;

namespace System.Diagnostics
{
    [DefaultEvent("Exited")]
    [DefaultProperty("StartInfo")]
    public class Process : Component
    {
        public Process();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProcessPriorityClass PriorityClass { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool PriorityBoostEnabled { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long PeakWorkingSet64 { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property has been deprecated.  Please use System.Diagnostics.Process.PeakWorkingSet64 instead.  https://go.microsoft.com/fwlink/?linkid=14202")]
        public int PeakWorkingSet { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long PeakVirtualMemorySize64 { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property has been deprecated.  Please use System.Diagnostics.Process.PeakVirtualMemorySize64 instead.  https://go.microsoft.com/fwlink/?linkid=14202")]
        public int PeakVirtualMemorySize { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long PeakPagedMemorySize64 { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property has been deprecated.  Please use System.Diagnostics.Process.PrivateMemorySize64 instead.  https://go.microsoft.com/fwlink/?linkid=14202")]
        public int PrivateMemorySize { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property has been deprecated.  Please use System.Diagnostics.Process.PeakPagedMemorySize64 instead.  https://go.microsoft.com/fwlink/?linkid=14202")]
        public int PeakPagedMemorySize { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property has been deprecated.  Please use System.Diagnostics.Process.PagedSystemMemorySize64 instead.  https://go.microsoft.com/fwlink/?linkid=14202")]
        public int PagedSystemMemorySize { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long PagedMemorySize64 { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property has been deprecated.  Please use System.Diagnostics.Process.PagedMemorySize64 instead.  https://go.microsoft.com/fwlink/?linkid=14202")]
        public int PagedMemorySize { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long NonpagedSystemMemorySize64 { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property has been deprecated.  Please use System.Diagnostics.Process.NonpagedSystemMemorySize64 instead.  https://go.microsoft.com/fwlink/?linkid=14202")]
        public int NonpagedSystemMemorySize { get; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProcessModuleCollection Modules { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IntPtr MinWorkingSet { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long PagedSystemMemorySize64 { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long PrivateMemorySize64 { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TimeSpan PrivilegedProcessorTime { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ProcessName { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long WorkingSet64 { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property has been deprecated.  Please use System.Diagnostics.Process.WorkingSet64 instead.  https://go.microsoft.com/fwlink/?linkid=14202")]
        public int WorkingSet { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long VirtualMemorySize64 { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property has been deprecated.  Please use System.Diagnostics.Process.VirtualMemorySize64 instead.  https://go.microsoft.com/fwlink/?linkid=14202")]
        public int VirtualMemorySize { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TimeSpan UserProcessorTime { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TimeSpan TotalProcessorTime { get; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProcessThreadCollection Threads { get; }
        [Browsable(false)]
        [DefaultValue(null)]
        public ISynchronizeInvoke SynchronizingObject { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime StartTime { get; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ProcessStartInfo StartInfo { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StreamReader StandardOutput { get; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StreamWriter StandardInput { get; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public StreamReader StandardError { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SessionId { get; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SafeProcessHandle SafeHandle { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Responding { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IntPtr ProcessorAffinity { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IntPtr MaxWorkingSet { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MainWindowTitle { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IntPtr MainWindowHandle { get; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MachineName { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Id { get; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HasExited { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HandleCount { get; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IntPtr Handle { get; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime ExitTime { get; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ExitCode { get; }
        [Browsable(false)]
        [DefaultValue(false)]
        public bool EnableRaisingEvents { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BasePriority { get; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProcessModule MainModule { get; }

        [Category("Behavior")]
        public event EventHandler Exited;
        [Browsable(true)]
        public event DataReceivedEventHandler ErrorDataReceived;
        [Browsable(true)]
        public event DataReceivedEventHandler OutputDataReceived;

        public static void EnterDebugMode();
        public static Process GetCurrentProcess();
        public static Process GetProcessById(int processId);
        public static Process GetProcessById(int processId, string machineName);
        public static Process[] GetProcesses(string machineName);
        public static Process[] GetProcesses();
        public static Process[] GetProcessesByName(string processName);
        public static Process[] GetProcessesByName(string processName, string machineName);
        public static void LeaveDebugMode();
        public static Process Start(ProcessStartInfo startInfo);
        public static Process Start(string fileName);
        public static Process Start(string fileName, string arguments);
        [CLSCompliant(false)]
        public static Process Start(string fileName, string userName, SecureString password, string domain);
        [CLSCompliant(false)]
        public static Process Start(string fileName, string arguments, string userName, SecureString password, string domain);
        public void BeginErrorReadLine();
        public void BeginOutputReadLine();
        public void CancelErrorRead();
        public void CancelOutputRead();
        public void Close();
        public bool CloseMainWindow();
        public void Kill();
        public void Refresh();
        public bool Start();
        public override string ToString();
        public bool WaitForExit(int milliseconds);
        public void WaitForExit();
        public bool WaitForInputIdle();
        public bool WaitForInputIdle(int milliseconds);
        protected override void Dispose(bool disposing);
        protected void OnExited();
    }
}