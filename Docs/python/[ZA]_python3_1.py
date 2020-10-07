
-----------------------------------------------------------------<- #!/usr/bin/env python3  到底是什么意思->

这是脚本语言共同遵守的规则：当第一行为 
#!/path/to/script/interpreter 时，指定了用来执行本脚本的解释器。
注意：
1、必须是文件的第一行
2、#!开头的，说明是脚本
3、/path/to/script/interpreter是脚本解释器的全路径名。
例如：
#!/bin/sh           shell脚本
#!/usr/bin/perl     perl脚本
#!/usr/bin/python   python脚本
#!/usr/bin/python2  python2脚本
#!/usr/bin/python3  python3脚本
而有时不太清楚脚本解释器的具体全路径名；或者开发环境与运行环境的安装路径不同。为了保证兼容性，也可以写作：
#!/usr/bin/env python3
这样运行时会自动搜索脚本解释器的绝对路径

-----
分成两种情况：
（1）如果调用python脚本时，使用:
python script.py 
#!/usr/bin/python 被忽略，等同于注释
（2）如果调用python脚本时，使用:
./script.py 
#!/usr/bin/python指定解释器的路径

-----------------------------------------------------------------







































#-end-