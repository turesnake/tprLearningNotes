
# =========================================================== #
#            记录 nakama 序列化 相关的笔记
# =========================================================== #


# --------------------------------------------------------- #
#  可以直接传输一个 list,  而不必把它包裹进一个 map 中;
# --------------------------------------------------------- #

#
local listData = {}
local encoded = nk.json_encode( listData )  -- lua 中序列化

#
var datas = content.FromJson<List<T>>(); // c# 中反序列化



# ----------------------------------------- #
#      替换掉 JsonUtility.FromJson<>()
# ----------------------------------------- #

var retDt = JsonUtility.FromJson<PersistentJoinMatchRet>(jData);
var retDt = jData.FromJson<PersistentJoinMatchRet>();















