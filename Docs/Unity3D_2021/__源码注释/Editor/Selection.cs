
#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using System;
using UnityEngine;

namespace UnityEditor
{
    //
    // 摘要:
    //     Access to the selection in the editor.
    [NativeHeaderAttribute("Editor/Src/Selection.h")]
    [NativeHeaderAttribute("Editor/Src/SceneInspector.h")]
    [NativeHeaderAttribute("Editor/Src/Gizmos/GizmoUtil.h")]
    [NativeHeaderAttribute("Editor/Src/Selection.bindings.h")]
    public sealed class Selection
    {
        //
        // 摘要:
        //     Delegate callback triggered when currently active/selected item has changed.
        public static Action selectionChanged;

        public Selection();

        //
        // 摘要:
        //     The actual unfiltered selection from the Scene returned as instance ids instead
        //     of objects.
        [StaticAccessorAttribute("SelectionBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        public static int[] instanceIDs { get; set; }
        //
        // 摘要:
        //     The actual unfiltered selection from the Scene.
        [StaticAccessorAttribute("SelectionBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        public static UnityEngine.Object[] objects { get; set; }
        //
        // 摘要:
        //     Returns the instanceID of the actual object selection. Includes Prefabs, non-modifiable
        //     objects.
        [NativeNameAttribute("ActiveID")]
        [StaticAccessorAttribute("Selection", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        public static int activeInstanceID { get; set; }
        //
        // 摘要:
        //     Returns the current context object, as was set via SetActiveObjectWithContext.
        public static UnityEngine.Object activeContext { get; }
        //
        // 摘要:
        //     Returns the actual object selection. Includes Prefabs, non-modifiable objects.
        public static UnityEngine.Object activeObject { get; set; }
        //
        // 摘要:
        //     Returns the active game object. (The one shown in the inspector).
        public static GameObject activeGameObject { get; set; }


        /*
            Returns the actual game object selection. Includes Prefabs, non-modifiable objects.

            当我们选中多个物体时, 可访问这个变量, 注意, 它的元素的排序规律是未知的, 并不按照 我们选择的次序
        */
        public static GameObject[] gameObjects { get; }


        //
        // 摘要:
        //     Returns the active transform. (The one shown in the inspector).
        public static Transform activeTransform { get; set; }
        //
        // 摘要:
        //     Returns the top level selection, excluding Prefabs.
        public static Transform[] transforms { get; }
        //
        // 摘要:
        //     Returns the guids of the selected assets.
        [StaticAccessorAttribute("SelectionBindings", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        public static string[] assetGUIDs { get; }
        //
        // 摘要:
        //     Returns the number of objects in the Selection.
        [NativeNameAttribute("SelectionCount")]
        [StaticAccessorAttribute("Selection", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
        public static int count { get; }

        //
        // 摘要:
        //     Returns whether an object is contained in the current selection.
        //
        // 参数:
        //   instanceID:
        //
        //   obj:
        public static bool Contains(UnityEngine.Object obj);
        //
        // 摘要:
        //     Returns whether an object is contained in the current selection.
        //
        // 参数:
        //   instanceID:
        //
        //   obj:
        [NativeMethodAttribute("IsSelected")]
        [StaticAccessorAttribute("GetSceneTracker()", UnityEngine.Bindings.StaticAccessorType.Dot)]
        public static bool Contains(int instanceID);
        //
        // 摘要:
        //     Returns the current selection filtered by type and mode.
        //
        // 参数:
        //   type:
        //     Only objects of this type will be retrieved.
        //
        //   mode:
        //     Further options to refine the selection.
        public static UnityEngine.Object[] GetFiltered(Type type, SelectionMode mode);
        public static T[] GetFiltered<T>(SelectionMode mode);
        //
        // 摘要:
        //     Allows for fine grained control of the selection type using the SelectionMode
        //     bitmask.
        //
        // 参数:
        //   mode:
        //     Options for refining the selection.
        [NativeMethodAttribute("GetTransformSelection", true)]
        public static Transform[] GetTransforms(SelectionMode mode);
        //
        // 摘要:
        //     Selects an object with a context.
        //
        // 参数:
        //   obj:
        //     Object being selected (will be equal activeObject).
        //
        //   context:
        //     Context object.
        [NativeMethodAttribute("SetActiveObjectWithContextInternal", true)]
        public static void SetActiveObjectWithContext(UnityEngine.Object obj, UnityEngine.Object context);
    }
}

