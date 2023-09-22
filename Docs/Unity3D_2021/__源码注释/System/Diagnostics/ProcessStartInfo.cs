#region Assembly netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// D:\Unity_1_editors\Unity 2021.3.14f1\Editor\Data\NetStandard\ref\2.1.0\netstandard.dll
#endregion

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Security;
using System.Text;

namespace System.Diagnostics
{
    /*

        new bing:
            ProcessStartInfo is a class in Unity that is used to start a new process, such as an external application or a command-line tool. 
            It is typically used in conjunction with the Process class. By using ProcessStartInfo, you can have better control over the process you start.




    */
    public sealed class ProcessStartInfo
    {
        public ProcessStartInfo();
        public ProcessStartInfo(string fileName);
        public ProcessStartInfo(string fileName, string arguments);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] Verbs { get; }
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        public string Verb { get; set; }
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        public bool UseShellExecute { get; set; }
        [NotifyParentProperty(true)]
        public string UserName { get; set; }
        public Encoding StandardOutputEncoding { get; set; }
        public Encoding StandardInputEncoding { get; set; }
        public Encoding StandardErrorEncoding { get; set; }
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        public bool RedirectStandardOutput { get; set; }
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        public bool RedirectStandardInput { get; set; }
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        public bool RedirectStandardError { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PasswordInClearText { get; set; }
        [CLSCompliant(false)]
        public SecureString Password { get; set; }
        [NotifyParentProperty(true)]
        public bool LoadUserProfile { get; set; }
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [SettingsBindable(true)]
        public string FileName { get; set; }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IntPtr ErrorDialogParentHandle { get; set; }
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        public bool ErrorDialog { get; set; }
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        public StringDictionary EnvironmentVariables { get; }
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [NotifyParentProperty(true)]
        public IDictionary<string, string> Environment { get; }
        [NotifyParentProperty(true)]
        public string Domain { get; set; }
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        public bool CreateNoWindow { get; set; }
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [SettingsBindable(true)]
        public string Arguments { get; set; }
        public Collection<string> ArgumentList { get; }
        [DefaultValue(ProcessWindowStyle.Normal)]
        [NotifyParentProperty(true)]
        public ProcessWindowStyle WindowStyle { get; set; }
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [SettingsBindable(true)]
        public string WorkingDirectory { get; set; }
    }
}