using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditorInternal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;



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


    /*
        fileMode_: 
            FileMode.Create : 若文件未存在: 新建一个, 若文件已存在: 覆写此文件
            FileModeAppend  : 若文件未存在: 新建一个, 若文件已存在: 打开并指向尾后
    */
    public static void WriteToFile( string data_, string path_, FileMode fileMode_ )
	{        
        //大括号中代码执行完毕后, 会及时释放 小括号中的资源
		using (
			var writer = new BinaryWriter(File.Open(path_, fileMode_, FileAccess.Write))
		){
            // 转换为 未压缩的紧凑类型, raw binary data
            writer.Write( Encoding.UTF8.GetBytes(data_) );
		}
	}


    public static bool ReadFile( string path_, out string fileData_ )
    {
        FileInfo fInfo = new FileInfo(path_);
        if (fInfo.Exists)
        {
            StreamReader r = File.OpenText(path_);
            fileData_ = r.ReadToEnd();
            r.Close();
            return true;
        }
        else
        {
            fileData_ = "";
            return false;
        }
    }


    public static string GetGameObjectPathInScene(Transform tf)
    {
        string path = "/" + tf.name;
        while (tf.parent != null)
        {
            tf = tf.parent;
            path = "/" + tf.name + path;
        }
        return path;
    }


    public static Transform RebuildGameObjectByFullPath( string fullPathInScene_ )
    {
        string[] names = fullPathInScene_.Split('/').Where( e => e!="" ).ToArray<string>(); // 去掉头部 "" 元素

        GameObject obj = GameObject.Find( "/" + names[0] );
        if (obj == null)
        {
            obj = new GameObject(names[0]);
        }
        Transform tf = obj.transform;

        for (int i = 1; i < names.Length; i++)
        {
            Transform child = tf.Find(names[i]);
            if (child == null)
            {
                child = new GameObject(names[i]).transform;
                child.SetParent(tf);
            }
            tf = child;
        }
        return tf;
    }

}

