
# -----------------------------------------------------------#

configure_file( <input> <output> 
                [COPYONLY] [ESCAPE_QUOTES] [@ONLY] )

# -----------------------------------------------------------#


#-- 
调用 configure_file 的目的是 为了让 源文件 也能使用 cmake 中的 变量。

#--
将 文件 <input> 拷贝到 <output>，然后替换文件内容中 引用到的 变量值。
若 input 是相对路径。则基础路径为 当前源文件路径
input 必须是一个 文件，不能是一个 目录
若 output 是一个相对路径，则基础路径为 当前二进制输出路径
若 output 是一个已有路径，则本指令的 输出文件 将会以它原有名字，放到 output路径目录下

#--
按格式 替换文件。
以 ${VAR} 或 @VAR@ 格式 引用 cmake 中的变量
如果 此变量 尚未定义，则被替换为 空

#--
选项：
-- COPYONLY
    此时 变量不会展开。

-- ESCAPE_QUOTES
    此时，所有被替换的变量 将会按 C语言规则 被转义。（不明白）

-- @ONLY
    此时，只有 @VAR@ 格式 的变量会被替换，
    ${VAR} 格式的 会被忽略。
        这一条 很适合用来 生成 shell 脚本（毕竟 ${VAR} 格式 在 shell 脚本中也存在 ）

#-- input 文件的 编写规则

若写     #cmakedefine VAR
此句会被扩展为： 
|     #define VAR         //( 在 cmake 中，VAR 被设置 )
|     /* #undef VAR */    //( 在 cmake 中，VAR 未被设置 )


若写     #cmakedefine 01 VAR
此句会被扩展为： 
|     #define VAR  1    //( 在 cmake 中，VAR 被设为 TRUE )
|     #define VAR  0    //( 在 cmake 中，VAR 被设为 FALSE )








