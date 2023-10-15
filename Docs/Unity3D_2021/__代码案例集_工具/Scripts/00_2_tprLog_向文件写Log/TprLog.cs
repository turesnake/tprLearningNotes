using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;
using System.Text;



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
        //-- file path:
        string timeData = DateTime.Now.ToString("yyyy_MMdd_HH_mm_ss_ff"); // "2023_0927_1725"
        string outFileName = "tprLog_" + timeData + ".txt"; // like: "tprLog_2023_0927_1725.txt"

        bool isMobile = Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer;

        //-- folder path:
        // if Editor:           "Assets"   + 上一级                                    +  "/__tprLogs__/"
        // if PC-Player:        app所在目录 + 上一级                                    +  "/__tprLogs__/"
        // if Android-Player:   "/storage/emulated/0/Android/data/com.xxx.xxxx/files"  + "/__tprLogs__/"
        // if iPhone-Player:    未试验...
        string outFolderPath = isMobile ?
                    Path.Combine(Application.persistentDataPath, "__tprLogs__") : 
                    Path.Combine(Application.dataPath,           "../__tprLogs__");
        outFolderPath = outFolderPath.Replace("\\", "/");
                    
        if (!Directory.Exists(outFolderPath))
        {
            Directory.CreateDirectory(outFolderPath);
        }
        //--
        outFilePath = Path.Combine(outFolderPath, outFileName).Replace("\\", "/");
        Debug.Log( "koko-[Log]: Create Instance Success; path:" + outFilePath );
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



    public static string ReadLogFile()
    {
        TprLog tprLog = Instance();
        FileInfo fInfo = new FileInfo(tprLog.outFilePath);
        if (fInfo.Exists)
        {
            StreamReader r = File.OpenText(tprLog.outFilePath);
            string logData = r.ReadToEnd();
            r.Close();
            return logData;
        }
        else
        {
            Debug.LogError( "koko - file not found: " + tprLog.outFilePath );
            return "";
        }

    }
}
