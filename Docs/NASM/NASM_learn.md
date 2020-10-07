//------ NASM learn --------



=== EFLAGS ===
# -- IF ／ interrupt flag 中断标志位
	IF = 1:
		cpu 将着手处理 可屏蔽硬件中断
	IF = 0:
		cpu 将不处理 可屏蔽硬件中断

	-----------------------------------

# -- DF ／ direction flag 方向标志位
	用来 决定 在 串操作指令执行时 有关指针寄存器 发生调整的方向
	controls the left-to-right or right-to-left direction of string processing

	CLD 指令 将 设置 df = 0
		auto-incrementing mode
		string is processed beginning from lowest to highest address

	STD 指令 将 设置 df = 1 
		auto-decrementing mode
		string is processed from highest to lowest address

	-----------------------------------

# -- .align val1, val2, val3
	对于老式 a.out 文件：
	val1 --对齐标准，
		比如 .align 2
			此处 2 表示低位 0-bit 的个数
			2个0，就是 4-byte 对齐。
	val2 -- 对齐的空缺，填充值是什么
		默认为0
	val3 -- 空缺的最大限度
		当对齐需要跳过的实际空缺，大于这个最大限度时
		则此指令不执行

	对于现代 elf 文件：
	.align 4
		表示 4-byte 对齐

	如果当前地址已经复合对齐要求。
	则此指令不执行

	-----------------------------------

# -- hlt
	暂停 cpu 直到一个外部中断发送给 cpu。
	（并非永久停止计算机）

	当OS无事可做时，可以让 OS进入 idle state（待机状态？）

	hlt 只能在 ring0 被调用
	-----------------------------------


# -- in  al,  port 
		将 port端口的数据，读取出来，保存到 寄存器reg中

# -- out  port,  al
		将 寄存器reg中的数据，输出到 端口port中 

	（out／in 指令 强行要求用 dx 存放 port）（或立即数／宏）
	 (out／in 指令 强行要求用 al 存放 数据)（或立即数／宏）
	-----------------------------------

# -- rep insw
		不停地从 port 读取数据
		w -- out word(2-bytes)/一次读取 2-byte
		直到 ecx 递减为 0

		mov  edx,  'port'      -- 要读的 端口
		mov  edi,  'buf_point' -- 缓冲区地址
		mov  ecx,  'count'     -- 循环次数

# -- rep outsw
		不停地从 port 写出数据 
		w -- out word(2-bytes)/一次写入 2-byte
		直到 ecx 递减为 0

		mov  edx,  'port'      -- 要写的 端口
		mov  esi,  'buf_point' -- 缓冲区地址
		mov  ecx,  'count'     -- 循环次数
		

	-----------------------------------

# -- org xxxh
	指令 告诉 汇编器，本程序加载到内存时，
	本程序内容 放在 内存地址偏移为 xxxh 的位置

	-----------------------------------


# -- lodsb ／ lodsw 
	取字符串指令 将位于 DS:SI 的内容，读取到 al／ax 中。
	读取完，地址 si 自动 加／减 1/2 byte
	DF = 0 时：
		SI 自动增加 
	DF = 1 时：
		SI 自动减少 

	-----------------------------------

# -- stosb / stosw / stosd
	字符串处理：
	把 al / ax / eax 的内容，存储到 es:edi 指向的内存空间
	然后，edi的值 根据 DF 的值 增加 或 减少

	-----------------------------------

# -- loop
	用 ecx 来控制 循环次数
	相当于：
		dec ecx
		jne <LABEL>

	-----------------------------------

# -- div src  除法
	- 如果 src 是 1-byte( 8-bit ) -- al
		ax 被 src除， 余数:ah 商:al
	- 如果 src 是 2-byte( 16-bit ) -- ax
		dx:ax 被 src除， 余数:dx 商:ax
	- 如果 src 是 4-byte( 32-bit )   -- eax
		edx:eax 被 src除， 余数:edx 商:eax

	-----------------------------------


# -- mul src  乘法（无符号数）
	- 如果 src 是 1-byte( 8-bit )
		ax = al * src; 
	- 如果 src 是 2-byte( 16-bit )
		dx:ax = ax * src; 高16位 写进 dx; 低16位 写进 ax ;
	- 如果 src 是 4-byte( 32-bit )
		edx:eax = eax * src; 高32位 写进 edx; 低32位 写进 eax ;

	-----------------------------------

# -- sub  reg  num  减法
	reg = reg - num 
	(我猜的)

	(num 强行要求为 立即数)
	-----------------------------------


# -- imul src 乘法（有符号数）

	-----------------------------------

# -- shl/shr  reg,  num
	将 reg 向左／右 位移 num 位／bit
		- reg 最好是 1-byte寄存器，如 al
		- num 可以是立即数，或寄存器
	左右多出来的空位都填0
	位移后的结果仍存在 reg 中

	(以上我猜的)
	-----------------------------------


# -- movzx  dect  src 
	mov 的变体。无符号扩展，并传送
	执行 mov 的过程中，dect区 剩余的位 用 0 填充


# -- movsb
	ds:si地址处的 1-byte 数据，
	复制到 es:di地址处

	源     --  ds:si
	目的地  --  es:di

	通常搭配 rep 使用：
	rep movsb
		不停地传输，直到 ecx计数器归零

	-----------------------------------

# -- resb
	占用一段空间，且把这段空间全填 0

	-----------------------------------

# -- sgdt [dst]
	将 cpu 的 gdt_ptr 存进 dst地址处。
	通常从dest地址开始，向后占用 6-byte 内存空间

	GDTR 是 一个寄存器，专门保存 GDT。

# -- lgdt [src]
	将 src 地址处的 gdt_ptr 存入 cpu

# -- lidt  [idt_ptr]
	类似上面的，

	-----------------------------------

# -- ltr / str <selector>
	load task register / save task register
	有关 TSS 的特殊寄存器
	操作数<selector> 为存放TSS的gdt子段选择子。

	-----------------------------------

# -- popf
	pop top of stack into lower 16 bits of EFLAGS
		(此处的top，可能仅仅指 当前esp处)
	出栈 16-bit 数据，提取出来赋值给 EFLAGS

# -- popfd
	pop top of stack into EFLAGS
		(此处的top，可能仅仅指 当前esp处)
	doubleword -- 4-byte
	出栈 32-bit 数据，提取出来赋值给 EFLAGS

# -- pushad
	依次入栈：
	eax,ecx,edx,ebx,krnl_esp,ebp,esi,edi

# -- popad
	依次出栈：
	edi,esi,ebp,[忽略／跳过krnl_esp],
	ebx,edx,ecx,eax

	-----------------------------------


# -- cli / sti
	将 EFLAGS 中的 IF 设置为 0 或 1.
	IF 用来管理 可屏蔽硬件中断
		当 IF = 1: 可屏蔽硬件中断 可被处理
		当 IF = 0: 可屏蔽硬件中断 不可被处理（被忽略）

	-----------------------------------



# -- retf
	far return
	长跳转返回
	一个重要的用途是，从内核层 retf 到用户程序层

	-----------------------------------

# -- iretd
	 从中断处理函数中 返回 用户进程 （软件或硬件级中断）
	 此指令 会改变 eflags 的值

	 （进入中段例程时）
	 	-- 如果 没有特权级变换
	 		依次入栈： eflags, cs, eip
	 		再入栈 error code（如果有）
	 	-- 如果 有特权级变换
	 		依次入栈： ss, esp, eflags, cs, eip
	 		再入栈 error code（如果有）
	 （执行 iretd 退出 中断例程时）
	 	- Error code 不会自动从栈中弹出
	 		执行 iretd 之前，需要先人工将它从栈中清楚掉。
	 	- 依次出栈 eip,cs,eflags,esp,ss
	 		这5个出栈的值会被立即赋值给对应的寄存器
	 		由于改变了 ss/esp.从而实现了 堆栈切换(ring0->ring3)
	 	- 此时 会改变 eflags 的值。


	-----------------------------------

# -- lea  dect  [src]
	load effective address
	加载有效地址
	把 src 的地址，赋值给 dect
	dect必须是 寄存器

# -- lds  si, ds:[ptr]
	load pointer using DS 
	取 ds:[ptr] 的值，
	这个值一般是个完整地址（c中的指针）
	然后让 ds:si 等同于这个 地址
	（这样，后面就可用 ds:si 去访问这个地址的内容）
	（以上 限于 实模式）

	同类的 reg 还有：
		 les / lgs / lss 等

	-----------------------------------

# -- rol / ror reg,  num
	循环位移指令。-- 循环圈不包含 carry位
	rotate without carry

	简单说明就是，reg 中所有位的数，向左／右 位移num位
	出界的那一位会环回到 尾部。（同时这一位也会被赋值给 carry位）


# -- rcl / rcr reg,  num
	循环位移指令。-- 循环圈包含 carry位
	rotate with carry

	简单说明就是，reg 中所有位的数，向左／右 位移num位
	出界的那一位会环回到 尾部。（同时这一位也会被赋值给 carry位）

	rcl/rcr 不同于 rol／ror 之处在于：
	rcl／rcr 的循环圈，包含 carry 位。

	(不精确)
	-----------------------------------

一些奇怪的 汇编混合代码：

# -- __asm__ __volatile__("ud2"); 
	__asm__ 是一个C中的汇编混合代码提示
	__volatile__ 表示编译器不要优化代码
			让后面的指令保留原样
	("ud2") 括号中的就是 汇编指令。

# -- ud2 汇编指令
	让cpu产生 invalid opcode exception 的软件指令
	内核发现这个异常后，会立即停止运行


	--------------------------------------





========================================
 	在 NASM 中，任何形式的 '\' 都不要使用
========================================
*
*
*
========================================
  严格注意所有的 条件判断句，
  它们很可能是无效的
-------------------------------
在 发现 BUG 来源于 dd指令 少传输了 扇区之后，
有关 条件判断句的 一系列问题 又都解决了
	....
所以，目前可以自由大胆地使用各种 条件判断句
========================================
*
*
*
========================================
	LABEL:
	.LABEL:
前面有.的标签，属于 本地Label
和 无点标签的 区别
-------------------------------
有点.的标签：
	本地Label，会自动和前一个 非本地 Label关联
	可以看作 内部 label
	所以，每个 非本地Label 后方，
	可以跟 和外部重名的 本地label
无点标签：
	可以看作全局标签。
========================================
*
*
*
========================================
    表达式 与 括号
-------------------------------
表达式 可以使用 括号
且必须是 小／圆括号， 圆括号可以嵌套圆括号
========================================












//-- end --