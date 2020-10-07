------------------ Bochs Manual -----------------
			安装／使用bochs 遇到的各种问题
==================================================

-- ubuntu 32 

-- bochs-2.4.5.tar.gz 
	教材原版，从 bochs 官网下载

-- cd bochs-2.4.5

-- ./configure --enable-debugger --enable-disasm

	++ ERROR ++:
	-- X windows gui was selected...
		++
		sudo apt-get install libx11-dev xserver-xorg-dev xorg-dev

	-- ERROR: pkg-config was not found, or unable to access the gtk+-2.0 package.Install pkg-config and the gtk+ development package,or disable the gui debugger, or the wxWidgets display library (whichever is being used)
		++
		sudo apt-get install libgtk2.0-dev

		...
		57% [connecting to cn.archive.ubuntu.com(2001:67c:1562::19)]
		在这个点出现停顿。。。
		但是 2mins 后继续下载了，之后完工。

-- make

	++ERROR++
	-- makefile:181 ...
		++
		在文件 Makefile.in 181行
		bochs@EXE@:... 这段的结尾
		...
		$(LIBS)\     -- (添加:"\")
		-lpthread    -- (添加:"-lpthread")

		即可编译通过。

-- sudo make intall
	通过以上步骤后，一般可安装成功

--------------------------------------------------
bochsrc 的设置：
	romimage: file=/usr/local/share/bochs/BIOS-bochs-latest
	vgaromimage: file=/usr/local/share/bochs/VGABIOS-lgpl-latest

	keyboard_mapping: enabled=1, map=/usr/local/share/bochs/keymaps/x11-pc-us.map

	---------------
	关键点为：
	$BXSHARE:
		/usr/local/share/bochs/


至此配置彻底成功！！！

====================================================


























//---------------- end ----------------