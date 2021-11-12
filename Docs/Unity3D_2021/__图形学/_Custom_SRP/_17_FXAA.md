



You don't need to go all the way. You could for example combine FXAA with render scale 4/3.
(1.33333) 
That would increase the amount of pixels by 1.78 instead of by four. 
This was suggested by Timothy Lottes in his presentation:

    Filtering Approaches for Real-Time Anti-Aliasing for SIGGRAPH2011.



# &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& #
#               展开静态循环:  UNITY_UNROLL
# ---------------------------------------------------------------- #

如果 shader 中的循环次数是静态的, 可要求 unity 在编译时将此循环展开:

# ---
UNITY_UNROLL
for(...){...}
# ===









