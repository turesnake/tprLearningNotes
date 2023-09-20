using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;
using System.Text;



// !!!! 目前有问题, 在 安卓上无法新建和写文件

/// <summary>
///  通用 txt 文件 log 系统;
///  
///     用法:
///        程序内直接调用: TprLog.Append("..."); 即可;
/// 
///  每次运行程序, 都会新建一个独立的 log 文件, 名如: "tprLog_2023_0916_20_17_17.txt"
/// 
/// </summary>
public class TprLog
{
    // if run in Editor: 存储在: "Assets"   + 上一级 +  "/_tprLogs_/" 中
    // if run in Player: 存储在: app所在目录 + 上一级 +  "/_tprLogs_/" 中
    string outFilePath;

    static TprLog _instance;
    static TprLog Instance() 
    {
        if( _instance == null ) 
        {
            _instance = new TprLog();
        }
        return _instance;
    }

    TprLog() 
    {
        Debug.Log("koko-[Log]: Create Instance");
        //-- file path:
        string timeData = DateTime.Now.ToString("yyyy_MMdd_HH_mm_ss"); // "2023_0927_1725"
        string outFileName = "tprLog_" + timeData + ".txt"; // like: "tprLog_2023_0927_1725.txt"

        //-- folder path:
        // if Editor:  "Assets"   + 上一级 +  "/_tprLogs_/"
        // if Player:  app所在目录 + 上一级 +  "/_tprLogs_/"
        string outFolderPath = Application.dataPath + "/../__tprLogs__/";
        if (!Directory.Exists(outFolderPath))
        {
            Directory.CreateDirectory(outFolderPath);
        }
        //--
        outFilePath = outFolderPath + "/" + outFileName;
    }

    // =============================================================================:

    public static void Append( string s_ )
	{
        TprLog tprLog = Instance();
        string lineHead = "\n\n----------" + DateTime.Now.ToString("HH:mm:ss.fff") + "---------->\n";
        string data = lineHead + s_;
        Debug.Log("koko-[Log]: " + s_ );
        
        //大括号中代码执行完毕后, 会及时释放 小括号中的资源
		using (
            // 若文件未存在: 新建一个
            // 若文件已存在: 打开并指向尾后
            // ---
            // 转换为 未压缩的紧凑类型, raw binary data
			var writer = new BinaryWriter(File.Open(tprLog.outFilePath, FileMode.Append, FileAccess.Write))
		){
            writer.Write( Encoding.UTF8.GetBytes(data) );
		}
	}
}
