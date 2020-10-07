# ================================================================//
#                       clang 使用技巧
# ================================================================//

在升级操作系统后，clang 的 include path 会失效，
此时可以：

#-1- xcode-select --install
	安装 Command Line Tools

#-2- find /Applications/Xcode.app -name stdio.h
	用来寻找 目标 文件 路径

#-3- open /Library/Developer/CommandLineTools/Packages/macOS_SDK_headers_for_macOS_10.14.pkg
	安装一个 pkg

===== 到此，就能正常编译了 =======
























