# ================================================================ #
#                         List<T> 使用技巧
# ================================================================ #

# ---------------------------------------------- #
#               List<T>
# ---------------------------------------------- #
# 一些常见用法:

List<int> list = new List<int>() { 1, 2, 3, 4 };
list.Add( 5 );    // 添加 元素: 5
list.Remove( 3 ); // 删除 元素: 3
int maxx = list.Max();
int minn = list.Min();
int sum = list.Sum();  // 直接获得全容器元素总和

list.Count; // 容器元素个数

list.Item[idx];  // 容器内某元素的 属性 (get,set)

list.Clear(); // 清空所有元素

bool List<T>.Contains (T item); // 检查容器 是否存在某个元素

void Insert (int idx, T item); // 向容器的 idx位置, 插入元素 item


# ---------------------------------------------- #
#            list.RemoveAt(idx);
# ---------------------------------------------- #
将目标元素删除后, 后面所有元素都会往前移动一位. 
所以可能存在 巨大开销

若 list 中元素可任意调换顺序, 可用手动法来 "移除" 一个元素:

    int lastIndex = list.Count - 1;
	shapes[index] = shapes[lastIndex];
	shapes.RemoveAt(lastIndex);

手动交换 目标元素 和 最后一个元素,
再删除最后一个元素. 




















