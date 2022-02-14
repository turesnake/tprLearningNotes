mac-终端(bash)-笔记


command + 'k' - 清屏

pwd (print working directory) 显示当前目录的绝对路径

ls (list directory contents)  列出当前目录的内容

ls -l  控制输出格式，以列的形式呈现
ls -a  显示全部内容（包括隐藏）
ls -A 显示全部内容（包含隐藏），但省略.  和.. 也就是 当前文件夹 和父文件夹


cd (change directory) 改变当前目录，到制定的目录

cd .. 回到上一级目录
cd / 回到根目录
cd . 回到当前目录
cd name 进入名为name的文件夹
cd - 返回上一个访问的目录


rm 文件名 删除 （无法删除文件夹derictory）

cat 文件名( |less ) 在终端下查看文件

cp 文件名 目录目标 将文件拷贝到目标目录下
~ 代表root  如：～／Document／CPP2/

mkdir  新建文件夹
gcc/g++ filename 可以编译c文件／cpp文件。生成一个a.out
./a.out     执行这个out文件。

gcc/g++ filename.cpp -o filename.out  指定生产的文件名
此处的out 也可写作    o， 但是mac系统不会来读，但可在bash中运行。

[键盘] coutrol+d 中断a.out的运行
nano  编写脚本语言。
[键盘]ctrl+o。 保存

nano ….sh     打开
bash ...sh    运行脚本
echo “…$i…"   输出语句


显示隐藏文件夹：
defaults write com.apple.finder AppleShowAllFiles -bool true

隐藏 隐藏文件夹：
defaults write com.apple.finder AppleShowAllFiles -bool false

open -e filename. 打开一个文件

ps 查看进程

ps -a 显示终端中包括其他用户的所有进程
ps -A 显示所有进程
ps -x 显示无控制终端的进程
ps -u username 查看某用户的进程

top 提供运行中系统动态视图。

$ sleep 10 && say “wake up” 程序运行10秒后，语言表达文本


mkdir name 新建文件夹 在当前目录

$ rm filename.txt  删除某文件 貌似不进入垃圾箱直接被删除。文件无法恢复。

---------------------

df -lh
	检查 挂在的硬盘信息，
	类似 linux 中的 sudo fdisk -l


---------------------
终端里的python部分：

输入： exit() +回车
即可退出py交互环境。

输入： import sys
     print（sys。path）
即可获得python版本的本地路径

-----------------------














