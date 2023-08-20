# ================================================================ #
#                各种 path
#                unity path
# ================================================================ #


# ----------------------------------------------------------- #
#     在项目未 build, 在 editor play 模式下打印出来的结果
# ----------------------------------------------------------- #
假设 项目源码路径为:E:/unity_projects/_urp_1

#                 // E:/unity_projects/_urp_1/Assets
    就是传统 项目/Assets/ 目录


# Application.consoleLogPath        // C:/Users/_tpr_/AppData/Local/Unity/Editor/Editor.log


# Application.persistentDataPath    // C:/Users/_tpr_/AppData/LocalLow/DefaultCompany/_urp_1


# Application.streamingAssetsPath   // E:/unity_projects/_urp_1/Assets/StreamingAssets

    这个目录是专门用来放置 app 资源的, 比如 ab包, 这些资源将在 build 阶段被一并打进 app 程序中;


# Application.temporaryCachePath    // C:/Users/CANGLA~1/AppData/Local/Temp/DefaultCompany/_urp_1



# ----------------------------------------------------------- #
#     打成 pc 包, 在pc 上运行 得到的结果:
# ----------------------------------------------------------- #


# Application.dataPath               E:/unity_projects/_urp_1/b_2/urp_1_Data
    打开 包体 目录, 就能见到的 urp_1_Data 目录:
    "{项目名}_Data"

# Application.consoleLogPath         C:/Users/_tpr_/AppData/LocalLow/tpr_tpr_test/urp_1/Player.log

    tpr_tpr_test 是 设置的 公司名
    urp_1        是 项目名


# Application.persistentDataPath     C:/Users/_tpr_/AppData/LocalLow/tpr_tpr_test/urp_1

    tpr_tpr_test 是 设置的 公司名
    urp_1        是 项目名


# Application.streamingAssetsPath    E:/unity_projects/_urp_1/b_2/urp_1_Data/StreamingAssets

    这个目录是专门用来放置 app 资源的, 比如 ab包, 这些资源将在 build 阶段被一并打进 app 程序中;


# Application.temporaryCachePath     C:/Users/CANGLA~1/AppData/Local/Temp/tpr_tpr_test/urp_1



# ----------------------------------------------------------- #
#     得到 Application.dataPath 的父级目录路径
# ----------------------------------------------------------- #

        string parentPath = "";
        int lastSlashIdx = Application.dataPath.LastIndexOf('/');
        if( lastSlashIdx != -1 )
        {    
            // 得到父目录路径, 无末尾的 '/';
            parentPath = Application.dataPath.Substring( 0, lastSlashIdx  );
        }

# 实践证明, 不管是在 editor play, 还是在 pc 打包后, 都能成功读取这个 parentPath 里文件的内容;
















