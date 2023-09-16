# ========================================================================= #
#                        unity  资源管理
# ========================================================================= #




# -------------------------------------------- #
#    AssetDatabase.LoadAssetAtPath()
#   适用于 PC Editor 端的 资源 同步加载 
# -------------------------------------------- #

    using UnityEngine;

    Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(texturePath);
    if (texture != null)
    {
        // Do something with the texture
    }































