# ================================================================ #
#                各种 path
#                unity path
# ================================================================ #


unity 内部使用的 path 一律用 '/' 分隔符, 哪怕是在 win 平台;



# ----------------------------------------------------------- #
#     在项目未 build, 在 editor play 模式下打印出来的结果
# ----------------------------------------------------------- #
假设 项目源码路径为:E:/unity_projects/_urp_1

# Application.dataPath              // E:/unity_projects/_urp_1/Assets
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

    

# Application.consoleLogPath         C:/Users/Administrator/AppData/Local/Unity/Editor/Editor.log

    tpr_tpr_test 是 设置的 公司名
    urp_1        是 项目名


# Application.persistentDataPath     C:/Users/Administrator/AppData/LocalLow/tpr_tpr_test/urp_1

    tpr_tpr_test 是 设置的 公司名
    urp_1        是 项目名


# Application.streamingAssetsPath    E:/unity_projects/_urp_1/b_2/urp_1_Data/StreamingAssets

    这个目录是专门用来放置 app 资源的, 比如 ab包, 这些资源将在 build 阶段被一并打进 app 程序中;


# Application.temporaryCachePath     C:/Users/CANGLA~1/AppData/Local/Temp/tpr_tpr_test/urp_1



# ----------------------------------------------------------- #
#     打成包, 在 安卓 上运行 得到的结果:
# ----------------------------------------------------------- #

# Application.dataPath                  /data/app/~~XkcDG3oH0qdLJlV0fW-TpA==/com.snake.tpr-B9rbQ2yGvVJ3Dk4XfW7VJg==/base.apk


# Application.consoleLogPath            空



# Application.persistentDataPath        /storage/emulated/0/Android/data/com.snake.tpr/files/

    !!!!!!!!!  这是 unity app 可以在 android 上读写的目录 !!!!!!!!!!!!
    如果程序想存储本地数据, 可以存在这里;
    缺点就是, 我们不太容易很方便地从手机上 访问到这个目录
    =====
    一种办法:
    假设 这个 log 文件内容很多;
    可以直接 Debug.Log() 打印出来;
        -- android studio logcat 里打印不全;
        -- unity editor console 里也打印不全
        == 但是, unity editor console 里的 "Open Editor Log" 可以打开 log 文件, 里面能完整展示;


# Application.streamingAssetsPath       jar:file:///data/app/~~XkcDG3oH0qdLJlV0fW-TpA==/com.snake.tpr-B9rbQ2yGvVJ3Dk4XfW7VJg==/base.apk!/assets



# Application.temporaryCachePath        /storage/emulated/0/Android/data/com.snake.tpr/cache
    new bing:
    This directory is created by the system when the app is installed and is used to store temporary files that are required by the app during runtime




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
















