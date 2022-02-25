#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

namespace UnityEditor.Build
{

    /*
        
    */
    public interface IPreprocessShaders//IPreprocessShaders__RR
        : IOrderedCallback
    {
        void OnProcessShader(Shader shader, ShaderSnippetData snippet, IList<ShaderCompilerData> data);
    }
}

