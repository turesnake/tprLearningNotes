# =============================================================== #
#           Powershell    za
# =============================================================== #


https://docs.microsoft.com/en-us/powershell/scripting/learn/ps101/01-getting-started?view=powershell-7.2


# ------------------------------- #
#   Learn Powershell in Y minutes
https://learnxinyminutes.com/docs/powershell/

快速温习版



# ----------------- #
# clear
    清屏


# ----------------- #
# cat 001.txt


# ------------------ #
#  查找 powershell 安装路径:
    $pshome


# ============================================= #
#               cmdlets
# ============================================= #
powershell 的 指令, 就叫 cmdlets

# tpr: 输入时 大小写不敏感;


# --------------- #
# get-verb
Running this command returns a list of verbs that most commands adhere to. (大多数指令遵守的 动词列表)
The response includes a description of what these verbs do. 
As most commands follow this naming, it sets expectations(期望) on what a command does. 
This helps you select the appropriate command and what to name a command, should you be creating one.

得到:
    Verb        Group
    ----        -----
    Add         Common
    Clear       Common
    Close       Common
    Copy        Common
    Enter       Common
    Exit        Common
    Find        Common
    Format      Common
    Get         Common
    Hide        Common
    Join        Common
    Lock        Common
    Move        Common
    New         Common
    Open        Common
    Optimize    Common
    Pop         Common
    Push        Common
    Redo        Common
    Remove      Common
    Rename      Common
    Reset       Common
    Resize      Common
    Search      Common
    Select      Common
    Set         Common
    Show        Common
    Skip        Common
    Split       Common
    Step        Common
    Switch      Common
    Undo        Common
    Unlock      Common
    Watch       Common
    Backup      Data
    Checkpoint  Data
    Compare     Data
    Compress    Data
    Convert     Data
    ConvertFrom Data
    ConvertTo   Data
    Dismount    Data
    Edit        Data
    Expand      Data
    Export      Data
    Group       Data
    Import      Data
    Initialize  Data
    Limit       Data
    Merge       Data
    Mount       Data
    Out         Data
    Publish     Data
    Restore     Data
    Save        Data
    Sync        Data
    Unpublish   Data
    Update      Data
    Approve     Lifecycle
    Assert      Lifecycle
    Complete    Lifecycle
    Confirm     Lifecycle
    Deny        Lifecycle
    Disable     Lifecycle
    Enable      Lifecycle
    Install     Lifecycle
    Invoke      Lifecycle
    Register    Lifecycle
    Request     Lifecycle
    Restart     Lifecycle
    Resume      Lifecycle
    Start       Lifecycle
    Stop        Lifecycle
    Submit      Lifecycle
    Suspend     Lifecycle
    Uninstall   Lifecycle
    Unregister  Lifecycle
    Wait        Lifecycle
    Debug       Diagnostic
    Measure     Diagnostic
    Ping        Diagnostic
    Repair      Diagnostic
    Resolve     Diagnostic
    Test        Diagnostic
    Trace       Diagnostic
    Connect     Communications
    Disconnect  Communications
    Read        Communications
    Receive     Communications
    Send        Communications
    Write       Communications
    Block       Security
    Grant       Security
    Protect     Security
    Revoke      Security
    Unblock     Security
    Unprotect   Security
    Use         Other

# --------------- #
# get-command
This command retrieves a list of all commands installed on your machine.
获得你的机器上的所有 commands;

得到:
    CommandType     Name                                               Version    Source
    -----------     ----                                               -------    ------
    Alias           Add-AppPackage                                     2.0.1.0    Appx
    Alias           Add-AppPackageVolume                               2.0.1.0    Appx
    Alias           Add-AppProvisionedPackage                          3.0        Dism
    Alias           Add-ProvisionedAppPackage                          3.0        Dism
    ...

    会按照首字母大小排序;


# Get-Command -Name '*Process'
# Get-Command -Verb 'Get'
    单查动词
# Get-Command -Noun U*
# Get-Command -Verb Get -Noun U*
    更加收缩查找范围




# --------------- #
# Get-Member <一个obj>
It operates on object based output and is able to discover what object, properties and methods are available for a command.

# --------------- #
#   Get-Help  <name-of-a-command>
Invoking this command with the name of a command as an argument displays a help page describing various parts of a command.

使用示范:
    get-help Set-Location -examples

















































