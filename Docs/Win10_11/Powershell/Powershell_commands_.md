# ========================================================= #
#           Powershell    commands
# ========================================================= #



# ----------------------------- #
#      set-location
# ----------------------------- #

# 示范:
    set-location -path "D:\AAA\"

此时 ps 会进入这个目录;

# 示范:
    set-location -path "D:\AAA\" -PassThru

进入目标目录, 然后再把这个 目录path 打印出来;


# 和 win cmd 不同, 不需要事先手动切换盘符;




# ----------------------------- #
#      新建 文件夹 / 文件
# ----------------------------- #

# New-Item -Path “C:\FFF\” -Name “AA” -ItemType Directory
    在  C:\FFF\ 下 新建一个目录 AA


# New-Item -Path . -Name “BB.txt” -ItemType "file"
    在 当前目录 (".") 新建文件 “BB.txt”



























