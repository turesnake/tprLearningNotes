# ----------------------------------------------#
#                智能指针  
# ----------------------------------------------#


-- std::shared_ptr 可以被当成 裸指针 来使用
	和 裸指针 一样，也是一个变量，也可以长期存储在 一些 class 中
	真正的对象，是由 std::make_shared 创建的。

-- 置空
	当需要置空时，可以为一个 std::shared_ptr 赋值 nullptr
	使用：
		smtPtr = std::make_shared<T>();
	并不能实现 置空，此时，smtPtr 将指向一个 默认初始化的 对象
	-----
	共有3种 置空 方法：
		ptr.reset();
		ptr = nullptr;
		ptr = {};
	推荐使用 ptr = nullptr;

-- std::bind
	std::bind 会把 实参 复制一份。所以，避免用 std::shared_ptr 
	来作为 bind 的 参数类型
	---
	陈硕推荐：使用 const std::shared_ptr<T> &; ...

-- 析构 所在的线程
	最后一个 shared_ptr 计数器在哪个线程被 清0，
	shared_ptr 指向的目标 就在那个线程 被 析构
	---
	陈硕推荐：极限情况下，可使用单独的线程来 专门做 析构。




# ----------------------------------------------#
#           std::make_shared<T>()
# ----------------------------------------------#
make_shared 依赖一个 public 的 constructor
在某些情况下，这个条件不成立，需要用 new T() 来代替。
比如：
	std::enable_shared_from_this<Parent>
	---
	所有继承这个类的 派生类，必须定义 private 的 constructor
	然后用一个 public static 工厂函数来 生成 std::shared_ptr<T>


# ----------------------------------------------#
#           shared_from_this()  (c++11)
#           weak_from_this()    (c++17)
# ----------------------------------------------#
当一个类 继承了 std::enable_shared_from_this
就可以直接使用：
	shared_from_this()
	weak_from_this()
来获得对应的 智能指针。



# ----------------------------------------------#
#         unique_ptr + std::move
# ----------------------------------------------#
-- 可以从 函数直接返回 uptr，以此来向外部转交 uptr 的所有权

-- 当获得一个 uptr，想要将其存入 容器，比如 umap
	可以使用 std::move 来实现

-- 这个组合非常方便




# ----------------------------------------------#
#         将 uptr 从一个容器传递到另一个容器
# ----------------------------------------------#
std::umap<int, std::unique_ptr<TA>> tas1 {};
std::umap<int, std::unique_ptr<TA>> tas2 {};

std::vector<int> keys{};
for( const auto &pair : tas1 ){
    keys.push_back( pair.first );
}

for( const auto &key : keys ){
    auto outPair = tas2.insert({ key, std::move(tas1.at(key)) });
    assert( outPair.second );
}
=======
如此传递之后，原始容器 元素个数没有变少，
但是元素内的 uptr 已经变成了 nullptr
---
鉴于元素并未减少，还有更简单的方法：

for( auto &pair : tas1 ){
    auto outPair = tas2.insert({ pair.first, std::move(pair.second) });
    assert( outPair.second );
}





















