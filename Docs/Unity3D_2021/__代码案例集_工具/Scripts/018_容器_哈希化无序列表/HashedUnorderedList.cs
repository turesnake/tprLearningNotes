using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
    一个哈希化的, 无序的 list 容器; 
    支持动态的, 低成本的 Add / Remove 元素;  Remove 后 list 中的元素顺序会改变;

    ---
    使用 List<> + Dictionary<> 来组合存储元素的用法很常见, 此处是把它集成了一下;


*/
public class HashedUnorderedList<KeyT, ValueT>
{   
    List<KeyValuePair<KeyT,ValueT>> _list = new List<KeyValuePair<KeyT, ValueT>>();
    Dictionary<KeyT,int> _map = new Dictionary<KeyT, int>();


    public HashedUnorderedList( int capcity_=64 ) 
    {
        _list.Capacity = capcity_;
    }

    public bool IsContainsKey( KeyT key_ ) 
    {
        return _map.ContainsKey(key_);
    }


    public ValueT Get( KeyT key_ ) // 不检测 key_ 是否有效
    {
        int idx = _map[key_];
        return _list[idx].Value;
    }   

    public int GetNum() 
    {
        return _list.Count;
    }

    public List<KeyValuePair<KeyT,ValueT>> GetList() 
    {
        return _list;
    }


    public ValueT Add( KeyT key_, ValueT value_ ) // 不检测 key_ 是否有效
    {
        int newIdx = _list.Count;
        _list.Add( new KeyValuePair<KeyT, ValueT>( key_, value_ ) );
        _map.Add( key_, newIdx );
        //---
        return _list[newIdx].Value;
    }


    public bool Remove( KeyT key_ )
    {
        if( IsContainsKey(key_) == false )
        {
            return false;
        }
        int idx = _map[key_];
        int lastIdx = _list.Count-1;
        KeyT lastElementKey = _list[lastIdx].Key;
        // copy:
        _list[idx] = _list[lastIdx];        
        _map[lastElementKey] = idx;
        // remove:
        _map.Remove(key_);
        _list.RemoveAt(lastIdx);
        //
        return true;
    }


    public void ChangeKey( KeyT oldKey_, KeyT newKey_ ) 
    {
        int idx = _map[oldKey_];
        var val = _list[idx].Value;
        _list[idx] = new KeyValuePair<KeyT, ValueT>( newKey_, val );
        _map[newKey_] = idx;
        _map.Remove(oldKey_);
    }
    

}


