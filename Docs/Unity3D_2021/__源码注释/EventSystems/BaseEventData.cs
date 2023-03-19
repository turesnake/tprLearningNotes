#region 程序集 UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.UI.dll
#endregion


namespace UnityEngine.EventSystems
{
    public class BaseEventData : AbstractEventData
    {
        public BaseEventData(EventSystem eventSystem);

        public BaseInputModule currentInputModule { get; }
        public GameObject selectedObject { get; set; }
    }
}