
#region 程序集 Unity.InputSystem, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// Unity.InputSystem.dll
#endregion

using System;
using UnityEngine.InputSystem.Utilities;

namespace UnityEngine.InputSystem
{
    public sealed class InputAction : ICloneable, IDisposable
    {
        public InputAction();
        public InputAction(string name = null, InputActionType type = InputActionType.Value, string binding = null, string interactions = null, string processors = null, string expectedControlType = null);

        public bool wantsInitialStateCheck { get; set; }
        public InputControl activeControl { get; }
        public bool triggered { get; }
        public bool enabled { get; }
        public bool inProgress { get; }
        public InputActionPhase phase { get; }
        public ReadOnlyArray<InputControl> controls { get; }
        public ReadOnlyArray<InputBinding> bindings { get; }
        public InputBinding? bindingMask { get; set; }
        public InputActionMap actionMap { get; }
        public string interactions { get; }
        public string processors { get; }
        public string expectedControlType { get; set; }
        public InputActionType type { get; }
        public Guid id { get; }
        public string name { get; }

        public event Action<CallbackContext> performed;
        public event Action<CallbackContext> canceled;
        public event Action<CallbackContext> started;

        public InputAction Clone();
        public void Disable();
        public void Dispose();
        public void Enable();
        public float GetTimeoutCompletionPercentage();
        public bool IsPressed();
        public TValue ReadValue<TValue>() where TValue : struct;
        public object ReadValueAsObject();
        public void Reset();
        public override string ToString();
        public bool WasPerformedThisFrame();
        public bool WasPressedThisFrame();
        public bool WasReleasedThisFrame();

        // input 系统 callback 的常见 参数, 使用的就是这个:
        public struct CallbackContext
        {
            public bool canceled { get; }
            public double duration { get; }
            public double startTime { get; }
            public double time { get; }
            public IInputInteraction interaction { get; }
            public InputControl control { get; }
            public InputAction action { get; }
            public Type valueType { get; }
            public int valueSizeInBytes { get; }
            public bool started { get; }
            public InputActionPhase phase { get; }
            public bool performed { get; }

            // 用来取值;
            // 比如默认的 Move, 得到的就是 Vector2 值, 可用: 
            //     Vector2 move = callbackContext.ReadValue<Vector2>();
            // 来拿到这个值;
            public TValue ReadValue<TValue>() where TValue : struct;

            public void ReadValue(void* buffer, int bufferSize);
            public bool ReadValueAsButton();
            public object ReadValueAsObject();
            public override string ToString();
        }
    }
}

