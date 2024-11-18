

https://heroiclabs.com/docs/nakama/server-framework/lua-runtime/function-reference/#Storage


# 相关函数有:
register_storage_index()
register_storage_index_filter()
storage_delete()
storage_index_list()
storage_list()
storage_read()
storage_write()


# - collection
    可以想象为一个 数据集, 

# - key:
    一个数据的 key,    


# 可将 user_id 设为 nil, 此处存储的是公共数据


# value:
    数据本体, json 格式

# permission_read
    No Read (0):        没有人可以读取该对象。
    Owner Read (1):     只有对象的所有者可以读取。
    Public Read (2):    任何人都可以读取该对象。

# permission_write
    No Write (0):       没有人可以写入该对象。
    Owner Write (1):    只有对象的所有者可以写入。




# ====================================================

# -1- 存储一个数据:  storage_write() 
Write one or more objects by their collection/keyname and optional user.
---

    local user_id = "4ec4f126-3f9d-11e7-84ef-b7c182b36521" -- 设为 nil 时表示公共数据

    local new_objects = {
        { collection = "collection_1", key = "save1", user_id = user_id, value = {} },
        { collection = "collection_1", key = "save2", user_id = user_id, value = {} },
        { collection = "collection_1", key = "save3", user_id = user_id, value = {}, permission_read = 2, permission_write = 1 },
        { collection = "collection_1", key = "save3", user_id = user_id, value = {k="_kk_",v="v_v"}, version="*", permission_read = 1, permission_write = 1 }
    }

    nk.storage_write(new_objects)



# -1- 存储一个数据:  storage_read() 
Fetch one or more records by their bucket/collection/keyname and optional user.

rets:
    objects table:  A list of storage objects matching the parameters criteria.
    error error:    An optional error value if an error occurred.
---

    local user_id = "4ec4f126-3f9d-11e7-84ef-b7c182b36521"

    local object_ids = {
        { collection = "save", key = "save1", user_id = user_id },
        { collection = "save", key = "save2", user_id = user_id },
    }

    local objects = nk.storage_read(object_ids)

    for _, r in ipairs(objects) do
        local message = string.format("read: %q, write: %q, value: %q", r.permission_read, r.permission_write, r.value)
        nk.logger_info(message)
    end





# -1- 删除掉某个 collection 中的 一个 key 数据: storage_delete()
Remove one or more objects by their collection/keyname and optional user.
ret:
    An optional error value if an error occurred.
---

    local user_id = "4ec4f126-3f9d-11e7-84ef-b7c182b36521"
    local friend_user_id = "8d98ee3f-8c9f-42c5-b6c9-c8f79ad1b820"

    local object_ids = {
        { collection = "save", key = "save1", user_id = user_id },
        { collection = "public", key = "progress", user_id = friend_user_id }
    }
    nk.storage_delete(object_ids)




# -1- 存储索引; 提高查找数据速度的:
# -1- register_storage_index()
# -1- register_storage_index_filter()











