#region 程序集 UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEngine.CoreModule.dll
#endregion

using System;

namespace UnityEngine.Rendering
{
    //
    // 摘要:
    //     Values for the stencil state.
    public struct StencilState : IEquatable<StencilState>
    {
        //
        // 摘要:
        //     Creates a new stencil state with the given values.
        //
        // 参数:
        //   readMask:
        //     An 8 bit mask as an 0–255 integer, used when comparing the reference value with
        //     the contents of the buffer.
        //
        //   writeMask:
        //     An 8 bit mask as an 0–255 integer, used when writing to the buffer.
        //
        //   enabled:
        //     Controls whether the stencil buffer is enabled.
        //
        //   compareFunctionFront:
        //     The function used to compare the reference value to the current contents of the
        //     buffer for front-facing geometry.
        //
        //   passOperationFront:
        //     What to do with the contents of the buffer if the stencil test (and the depth
        //     test) passes for front-facing geometry.
        //
        //   failOperationFront:
        //     What to do with the contents of the buffer if the stencil test fails for front-facing
        //     geometry.
        //
        //   zFailOperationFront:
        //     What to do with the contents of the buffer if the stencil test passes, but the
        //     depth test fails for front-facing geometry.
        //
        //   compareFunctionBack:
        //     The function used to compare the reference value to the current contents of the
        //     buffer for back-facing geometry.
        //
        //   passOperationBack:
        //     What to do with the contents of the buffer if the stencil test (and the depth
        //     test) passes for back-facing geometry.
        //
        //   failOperationBack:
        //     What to do with the contents of the buffer if the stencil test fails for back-facing
        //     geometry.
        //
        //   zFailOperationBack:
        //     What to do with the contents of the buffer if the stencil test passes, but the
        //     depth test fails for back-facing geometry.
        //
        //   compareFunction:
        //     The function used to compare the reference value to the current contents of the
        //     buffer.
        //
        //   passOperation:
        //     What to do with the contents of the buffer if the stencil test (and the depth
        //     test) passes.
        //
        //   failOperation:
        //     What to do with the contents of the buffer if the stencil test fails.
        //
        //   zFailOperation:
        //     What to do with the contents of the buffer if the stencil test passes, but the
        //     depth test.
        public StencilState(
            bool enabled = true, 
            byte readMask = 255, 
            byte writeMask = 255, 
            CompareFunction compareFunction = CompareFunction.Always, 
            StencilOp passOperation = StencilOp.Keep, 
            StencilOp failOperation = StencilOp.Keep, 
            StencilOp zFailOperation = StencilOp.Keep
        );
        public StencilState(
            bool enabled, 
            byte readMask, 
            byte writeMask, 
            CompareFunction compareFunctionFront, 
            StencilOp passOperationFront, 
            StencilOp failOperationFront, 
            StencilOp zFailOperationFront, 
            CompareFunction compareFunctionBack, 
            StencilOp passOperationBack, 
            StencilOp failOperationBack, 
            StencilOp zFailOperationBack
        );

        //
        // 摘要:
        //     Default values for the stencil state.
        public static StencilState defaultValue { get; }
        //
        // 摘要:
        //     Controls whether the stencil buffer is enabled.
        public bool enabled { get; set; }
        //
        // 摘要:
        //     What to do with the contents of the buffer if the stencil test (and the depth
        //     test) passes for back-facing geometry.
        public StencilOp passOperationBack { get; set; }
        //
        // 摘要:
        //     The function used to compare the reference value to the current contents of the
        //     buffer for back-facing geometry.
        public CompareFunction compareFunctionBack { get; set; }
        //
        // 摘要:
        //     What to do with the contents of the buffer if the stencil test passes, but the
        //     depth test fails for front-facing geometry.
        public StencilOp zFailOperationFront { get; set; }
        //
        // 摘要:
        //     What to do with the contents of the buffer if the stencil test fails for front-facing
        //     geometry.
        public StencilOp failOperationFront { get; set; }
        //
        // 摘要:
        //     What to do with the contents of the buffer if the stencil test (and the depth
        //     test) passes for front-facing geometry.
        public StencilOp passOperationFront { get; set; }
        //
        // 摘要:
        //     The function used to compare the reference value to the current contents of the
        //     buffer for front-facing geometry.
        public CompareFunction compareFunctionFront { get; set; }
        //
        // 摘要:
        //     An 8 bit mask as an 0–255 integer, used when writing to the buffer.
        public byte writeMask { get; set; }
        //
        // 摘要:
        //     An 8 bit mask as an 0–255 integer, used when comparing the reference value with
        //     the contents of the buffer.
        public byte readMask { get; set; }
        //
        // 摘要:
        //     What to do with the contents of the buffer if the stencil test passes, but the
        //     depth test fails for back-facing geometry.
        public StencilOp zFailOperationBack { get; set; }
        //
        // 摘要:
        //     What to do with the contents of the buffer if the stencil test fails for back-facing
        //     geometry.
        public StencilOp failOperationBack { get; set; }

        

        public override bool Equals(object obj);
        public bool Equals(StencilState other);
        public override int GetHashCode();
        //
        // 摘要:
        //     The function used to compare the reference value to the current contents of the
        //     buffer.
        //
        // 参数:
        //   value:
        //     The value to set.
        public void SetCompareFunction(CompareFunction value);
        //
        // 摘要:
        //     What to do with the contents of the buffer if the stencil test fails.
        //
        // 参数:
        //   value:
        //     The value to set.
        public void SetFailOperation(StencilOp value);
        //
        // 摘要:
        //     What to do with the contents of the buffer if the stencil test (and the depth
        //     test) passes.
        //
        // 参数:
        //   value:
        //     The value to set.
        public void SetPassOperation(StencilOp value);
        //
        // 摘要:
        //     What to do with the contents of the buffer if the stencil test passes, but the
        //     depth test fails.
        //
        // 参数:
        //   value:
        //     The value to set.
        public void SetZFailOperation(StencilOp value);

        public static bool operator ==(StencilState left, StencilState right);
        public static bool operator !=(StencilState left, StencilState right);
    }
}

