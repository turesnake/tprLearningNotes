## =========================================================== #
#            Shader keywords
## =========================================================== #
不是严格的逐句翻译, 而是大致含义的整理;


一个 keyword 启用/禁用, 就能分出两路 shader variants 来;



# Declaring shader keywords
...

# Declaring keywords with local or global scope
...



# =============================== #
#      local shader keyword
# ------------------------------- #


# -------- 使用方式 -------:
-1- 
    必须在 shader 代码中使用: 

        #pragma shader_feature_local
        #pragma multi_compile_local

[注意:带"_local"]

    声明目标keyword, 
    这样编译器才会真的生成两路 shader variants;

-2-
    在 shader 代码中, 使用这个 kayword 来获得不同的效果;

-3- 
    在 任意脚本代码中, 不管是在 Start() 还是 Update() 中,
    调用:
        material.EnableKeyword("XXX");
    
    这会立即启用这个 keyword; 
    然后,
    unity 会针对这个 material 所绑定的 shaders, 
    去寻找它们的 variants 中 支持这个 keyword的版本, 并调用这些 variants;
    ---
    这个过程是立即起效的;

# ------- 注意的细节:

# -1-:
    在笔记 "文档 HLSL in Unity.md" 中查找 "Keyword limits"
    有更详细描述;

# -2-:
        #pragma shader_feature_local
        #pragma multi_compile_local
        #pragma shader_feature
        #pragma multi_compile
    由以上指令在 shader 中定义的 local / global keywords, material.EnableKeyword() 都能控制它们;
    ---
    即, 虽然 material.EnableKeyword() 名义上只能控制 local keyword, 
    但如果此 material 绑定的 shader 中, 没有此名字的 local keyword, 但有一个同名的 gloabl keyword,
    这个函数也是能 改写它的;


# =============================== #
#      global shader keyword
# ------------------------------- #
-1- 
    必须在 shader 代码中使用: 

        #pragma shader_feature
        #pragma multi_compile
    
    声明目标keyword, 
    这样编译器才会真的生成两路 shader variants;
-2-
    在 shader 代码中, 使用这个 kayword 来获得不同的效果;
-3- 
    在 任意脚本代码中, 不管是在 Start() 还是 Update() 中,
    调用:
        Shader.EnableKeyword("XXX");
    
    这会立即启用这个 keyword; 
    然后,
    unity 会针对 整个游戏中的所有 shaders, 
    都去寻找它们的 variants 中 支持这个 keyword 的版本, 并调用这些 variants;
    ---
    这个过程是立即起效的;

# ------- 注意的细节:

# -1-:
    在笔记 "文档 HLSL in Unity.md" 中查找 "Keyword limits"
    有更详细描述;

# -2-:
    Shader.EnableKeyword() 无法影响由:
        #pragma shader_feature_local
        #pragma multi_compile_local
    定义的 local keyword;




