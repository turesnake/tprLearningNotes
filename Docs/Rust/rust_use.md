
# ================================================================ #
#                          Rust 使用技巧
# ================================================================ #


It will add the cargo, rustc, rustup and other commands to
Cargo's bin directory, located at:

  /Users/tom/.cargo/bin

This can be modified with the CARGO_HOME environment variable.

Rustup metadata and toolchains will be installed into the Rustup
home directory, located at:

  /Users/tom/.rustup

This can be modified with the RUSTUP_HOME environment variable.

This path will then be added to your PATH environment variable by
modifying the profile files located at:

  /Users/tom/.profile
/Users/tom/.bash_profile

You can uninstall at any time with rustup self uninstall and
these changes will be reverted.

Current installation options:


   default host triple: x86_64-apple-darwin
     default toolchain: stable
               profile: default
  modify PATH variable: yes


# ----------------------------------------------#
#        安装完毕后，请主动配置 PATH
# ----------------------------------------------#
在 ~/.bash_profile 中，添加：
	source $HOME/.cargo/env

这样，每次打开一个 shell 窗口，都会主动把 "$HOME/.cargo/env" 路径
添加到 PATH 中去。


# --- 查看版本 -------------------------------------------#
rustc --version   

# --- 更新 -------------------------------------------#
rustup update















