using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;


// https://thedeveloperblog.com/multimap

// 随便找来的 c# 版 unordered_multimap 容器的 简单实现;

// 不足:
//      目前 key 的类型是固定的 string, 未来可修改

public class Unordered_MultiMap_1<V>
{
    // 1
    Dictionary<string, List<V>> _dictionary = new Dictionary<string, List<V>>();

    // 2
    public void Add(string key, V value)
    {
        List<V> list;
        if (this._dictionary.TryGetValue(key, out list))
        {
            list.Add(value);
        }
        else
        {
            list = new List<V>();
            list.Add(value);
            this._dictionary[key] = list;
        }
    }

    // 3
    public IEnumerable<string> Keys
    {
        get
        {
            return this._dictionary.Keys;
        }
    }

    // 4
    public List<V> this[string key]
    {
        get
        {
            List<V> list;
            if (!this._dictionary.TryGetValue(key, out list))
            {
                list = new List<V>();
                this._dictionary[key] = list;
            }
            return list;
        }
    }
}


