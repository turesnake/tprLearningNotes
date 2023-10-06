using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditorInternal;
using System;
using System.Collections.Generic;



// 通用 io 库:


public class TprIO
{


    public static string NormalizePathSeparator(string path)
    {
        return path.Replace("\\", "/");
    }


    public static string GetDirectoryName( string fullFilePath_ ) 
    {
        return System.IO.Path.GetDirectoryName( NormalizePathSeparator(fullFilePath_) );
    }

    // 好像对 unity path asset path 也起效
    public static void CheckAndCreateDirectory( string folderPath_ ) 
    {
        // todo: 未检测 folderPath_ 合法性
        if( !System.IO.Directory.Exists( folderPath_ ) )
        {
            System.IO.Directory.CreateDirectory( folderPath_ );
        }
    }

    // 好像对 unity path asset path 也起效
    public static void CleanDirectory( string folderPath_ ) 
    {
        // todo: 未检测 folderPath_ 合法性
        if (System.IO.Directory.Exists(folderPath_))
        {
            System.IO.Directory.Delete(folderPath_, true); // 递归删除所有 子孙内容
        }
        System.IO.Directory.CreateDirectory(folderPath_);
    }




}

