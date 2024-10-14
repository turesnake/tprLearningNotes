


sed（Stream Editor）是一个强大的文本处理工具，常用于 文本替换、插入、删除 和 其他编辑操作。
以下是 sed 的常用用法及其详细解释：

# sed 's/old_text/new_text/' filename.txt
    这将把 filename.txt 文件中, 每一行的第一个 old_text 替换为 new_text 。
    (注意，这不会修改文件本身，只会在标准输出中显示结果)
    --

# sed 's/old_text/new_text/g' filename.txt
    使用 g 选项可以替换文件中所有出现的 old_text 为 new_text。
    (注意，这不会修改文件本身，只会在标准输出中显示结果)
    --

# sed -i 's/old_text/new_text/g' filename.txt
    使用 - i选项可以直接在文件中进行替换，而不是仅在标准输出中显示结果。
    ---
    此时并不会输出什么内容

# sed -e 's/old_text/new_text/g' -e 's/another_old_text/another_new_text/g' filename.txt
    -e  允许多条编辑命令

# sed -n 's/old_text/new_text/p' filename.txt
    -n 抑制自动输出

# sed -f script.sed filename.txt
    使用 -f 选项 可以从指定的脚本文件中读取 sed 命令。


# sed -r 's/(old_text|another_old_text)/new_text/g' filename.txt
    使用 -r 选项 可以启用扩展正则表达式，允许使用更复杂的模式。


# sed '3d' filename.txt
    删除 filename.txt 中的第三行。


# sed '3s/old_text/new_text/' filename.txt
    仅在第三行中将 old_text 替换为 new_text。


# sed '3a new_line_text' filename.txt
    将在第三行后插入new_line_text。


# sed '3i new_line_text' filename.txt
    将在第三行前插入new_line_text。



