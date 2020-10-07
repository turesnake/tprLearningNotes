

-- b addr
	在 内存 某物理地址处 设置断点。

	----------------------

-- c
	继续执行代码，直到遇到断点

	----------------------

-- s
	单步执行

-- n
	单步执行 （遇到函数则跳过）

	----------------------

-- print-stack
	查看堆栈

--  xp /nuf addr
	xp /40bx 0x0078e
	查看内存物理地址内容

--  x /nuf addr
	x /40bx 0x13e
	查看线性地址内容

--  u start end
	u 0x30400 0x3040d
	反汇编一段内存

--  trace-on
	反汇编 执行的每一条指令

--  trace-reg
	每执行一条指令就打印 cpu 信息

	----------------------


++++++++++++++ 查看寄存器指令 --> +++++++++++++++++

-- info cpu
	查看所有寄存器信息
	

--  r 
	查看如下寄存器信息:
	eax / ecx / edx / ebx / 
	esp / ebp / esi / edi / eip
	EFLAGS


--  fp
	查看如下寄存器信息:
	status  word
	control word
	tag word
	operand
	fip / fcs / fdp / fds
	FP0 ST0(0)
	...
	FP7 ST7(0)


-- sreg
	查看如下寄存器信息:
	es / cs / ss / ds / fs / gs 
	ldtr / tr / gdtr / idtr


-- creg
	查看如下寄存器信息:
	CR0 / CR2 / CR3 ／ CR4 / EFER 


-- dreg
	查看如下寄存器信息:
	DR0
	...
	DR7


 -- mmx
 	查看如下寄存器信息:
 	MM[0]
 	...
 	MM[7] 


-- sse
	查看如下寄存器信息:
	MXCSR
	XMM[00]
	...
	XMM[07]


++++++++++++++++++++++++++++++++++++++++++++++







//-- end --