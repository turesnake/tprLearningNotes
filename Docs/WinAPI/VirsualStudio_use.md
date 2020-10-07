

# ----------------------------------------------#
                      vs项目搭建提要
# ----------------------------------------------#
-- Project->Properties:
	C++.general.Add Include Dir
	C++.language.C++ Language Standard
	Linker.general.Additional Lib Dir
	Linker.input.Additional Dependences




# ----------------------------------------------#
                代码在 夸平台中 遇到的问题
# ----------------------------------------------#

-- off_t
	在 unix，sizeof(off_t) == 8 (理想值)
	在 win,  sizeof(off_t) == 4
	---
	暂不确定，有多少 代码使用了 off_t ...



























