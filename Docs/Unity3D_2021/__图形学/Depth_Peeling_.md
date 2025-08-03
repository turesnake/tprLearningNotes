

# =========================================================== #
#               Depth Peeling
#                 深度剥离
# =========================================================== #

简单说就是: 存储最深的 fragment 的深度值;



# -1-: 基本没写啥:
https://medium.com/@pushkarevmm/depth-peeling-simple-example-with-scriptable-render-pipeline-in-unity-2c379fcbd05d



# -2- : 写的很好
https://zhuanlan.zhihu.com/p/697334162



# OIT 算法
即 Order Independent Transparency（顺序无关的半透明渲染）





# _CameraDepthAttachment:
urp 默认的 depth buffer



# 不能在一个 render pass 中既读取一个 rt, 又写入这个 rt
ai 推进用双 rt 来实现一些功能;








