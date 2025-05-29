using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;


/*
    简易异步资源加载器
*/
public class EasyLoadAssetCell : IDisposable
{
    string address;
    AsyncOperationHandle<GameObject> handle; // Retain handle to release asset and operation
    GameObject result;
    // 标记对象是否已被释放
    bool _disposed = false;


    // 异步加载资源:
    public EasyLoadAssetCell(string address_)
    {
        address = address_;
        handle = Addressables.LoadAssetAsync<GameObject>(address);
        handle.Completed += Handle_Completed;
    }
    // Instantiate the loaded prefab on complete
    private void Handle_Completed(AsyncOperationHandle<GameObject> operation)
    {
        if (operation.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogError($"Asset failed to load: " + address);
        }
        result = operation.Result;
    }

    // 实例化资源:
    public Transform Instantiate(Transform parent_, Vector3 pos_)
    {
        if (result == null)
        {
            Debug.LogError("result is nil, 可能是加载尚未完成");
        }
        var go = GameObject.Instantiate(result, parent_);
        var tf = go.transform;
        tf.position = pos_;
        return tf;
    }


    // =================================

    //用户最好显式调用来释放非托管资源
    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }
        //Debug.LogError("Dispose");
        Addressables.Release(handle);
        _disposed = true;
    }


    // 终结器（备用，防止未显式 Dispose）
    ~EasyLoadAssetCell()
    {
        //Debug.LogError("~EasyLoadAssetCell");
        // 确保当用户忘记调用 Dispose() 时，非托管资源最终能被释放。
        Dispose();
    }
}




