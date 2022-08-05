# ================================================================ #
#                   dotnet command line 
# ================================================================ #


# ---------------------------------------------- #
#    快速制作一个 标准化的 dotnet core项目
# ---------------------------------------------- #
===1===
dotnet new console

===2===
设置项目 output path，
在 .csproj 文件中添加：

  <!-- ========== Set OutputPath / PublishDir =========
        前者为 常规 输入路径： root/regularOut/
        后者为 发布版 路径：   root/build/publish/
  -->
  <PropertyGroup> <!-- out-path -->
    <BaseOutputPath>bin/</BaseOutputPath>    
    <AppendRuntimeIdentifierToOutputPath>false</AppendRuntimeIdentifierToOutputPath>
    <AppendTargetFrameworkToOutputPath>false</AppendTargetFrameworkToOutputPath>
    <OutputPath>regularOut/</OutputPath>
    <PublishDir>build/publish/</PublishDir>
  </PropertyGroup><!-- out-path -->

  ...

    <RuntimeIdentifiers>win-x64;linux-x64;osx-x64</RuntimeIdentifiers>

  ...


===3===
dotnet new nuget

===4===
安装 IL Linker，一个缩小发布包的插件
在 nuget.config 文件中 "<clear />" 后添加：

	<!-- IL Linker -->
    <add key="dotnet-core" value="https://dotnet.myget.org/F/dotnet-core/api/v3/index.json" />


然后运行：(梯内)
dotnet add package ILLink.Tasks -v 0.1.4-preview-981901 
	这样将会下载安装 IL LINK
	---
	工具会在 .csproj 自动添加：

  <ItemGroup>
    <PackageReference Include="ILLink.Tasks" Version="0.1.4-preview-981901" />
  </ItemGroup>

升级包
dotnet add package ILLink.Tasks


===5===
dotnet publish -c Release/Debug
				-r osx-x64/win-x64/linux-x64
				--self-contained true 
比如：
dotnet publish -c Release -r osx-x64 --self-contained true
dotnet publish -c Release -r win-x64 --self-contained true





# ---------------------------------------------- #
#            项目：  obj/
# ---------------------------------------------- #
这是临时生成文件目录（里面会被进一步细分）



# ---------------------------------------------- #
#           快速搭建项目：console
# ---------------------------------------------- #
dotnet new console
dotnet run
	从，2.0 开始，不再需要 dotnet restore 命令，
	它会在需要时被其他指令自动调用。比如 dotnet new,
	dotnet build, dotnet run 
	当然也可以显示调用之



# ---------------------------------------------- #
#              dotnet restore
# ---------------------------------------------- #
（2.0 之后不再需要显示调用）
此指令 调用 NuGet 来存储 项目依赖树。
NuGet 分析 xxx.csproj 文件，下载文件中 定义的 依赖包
（或者不下载，而是从本机换存中获取）
然后写入 obj/project.assets.json 文件
编译和运行需要 这个文件



# ---------------------------------------------- #
#              dotnet run
# ---------------------------------------------- #
此指令 调用 dotnet build 来确保 build targets 已经被创建
然后调用 dotnet <assembly.dll> 来运行 目标程序。

或者，用户也可以执行 dotnet build 来编译，但不 run。
这会把 程序 编译为一个 dll文件。
可以通过 dotnet bin/Debug/netcoreapp2.1/Hello.dll
来运行。

进一步，可以调用其他指令来生成 自包含程序（release版）
（Self-contained deployments）比如：

dotnet publish -r osx-x64 --self-contained true 
/.../xxx.csproj -o /.../scd



# ---------------------------------------------- #
#            deployment
# ---------------------------------------------- #
有 3 种 deployment 方式:
--1-- Framework-dependent deployment (FDD)
	依赖目标机器上的 .net core 系统级 动态库。
	此时的 app 只保护自己所需的代码，对目标机器有要求。
	生成一个 .dll 文件，可用 dotnet 指令调用

--2-- Framework-dependent executables (FDE)
	类似 FDD，但是生成一个 可执行文件

--3-- Self-contained deployment (SCD)
	自包含所需的一切组件，包括 .net core libs,
	.net core runtime, 
	-----
	这是我们需要的类型


dotnet publish -c Release/Debug
				-r osx-x64/win-x64/linux-x64
				--self-contained true 
				/.../xxx.csproj 
				-o /.../scd
	---------
	指定 .csproj 和 -o 可以省略。


-------------
执行上条指令后，会生成两份数据：
	cs_2 -> .../win-x64/cs_2.dll
	cs_2 -> .../win-x64/publish/
	---
	其中，两处地方都出现了同样的 可执行文件...
	但只有 publish/ 是真正的发行版。

-------------
甚至可以跨平台编译，比如在 mac中，直接使用 "-r win-x64"
此时生成的 publish/ 目录，可以直接被复制到 win电脑，直接运行...

-------------
如果想要缩小 发布包的尺寸，可以添加 IL LINK 模块：
dotnet new nuget
	为项目建立 nuget.config 文件，
	在此文件中添加：
	<add key="dotnet-core" value="https://dotnet.myget.org/F/dotnet-core/api/v3/index.json" />
	------

然后运行：
dotnet add package ILLink.Tasks -v 0.1.4-preview-981901
	这样将会下载安装 IL LINK

想要更新这个包，可以运行：
（不加版本号）
dotnet add package ILLink.Tasks

然后 publish编译，尺寸会缩小很多。
想要检测每个文件，具体缩小多少，可以在 publish 中添加：
/p:ShowLinkerSizeComparison=true
	当然这个选项是可选的。




# ---------------------------------------------- #
#              
# ---------------------------------------------- #




# ---------------------------------------------- #
#              
# ---------------------------------------------- #










