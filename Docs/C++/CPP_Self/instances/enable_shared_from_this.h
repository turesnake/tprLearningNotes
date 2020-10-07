
// 事例
// 如何使用 shared_ptr，weak_ptr，enable_shared_from_this
// 来实现一组 主体类／组件类。 使得 主体／组件 可以相互访问
//

#include <memory>
#include <iostream>
using std::cout;
using std::endl;



class Parent; //- declare
/* ===========================================================
 *                        Component
 * -----------------------------------------------------------
 */
class Component{
public:
    Component( int i_ ):
        i(i_)
    {
        cout << "Component: start; i = " << this->i << endl;
    }

    ~Component(){
        cout << "Component: end;" << endl;
    }


    void bind_Parent_weakPtr( std::weak_ptr<Parent> wptr_ ){
        this->parentPtr = wptr_;
    }


private:
    int i;
    std::weak_ptr<Parent> parentPtr;
    
};



/* ===========================================================
 *                        Parent
 * -----------------------------------------------------------
 */
class Parent : public std::enable_shared_from_this<Parent> {
public:

    //-- factory constructor 
    // enable_shared_from_this 要求 派生类定义 private 的 constructor
    // 然后通过一个 public static 工厂函数来 统一生成 std::shared_ptr<T>
    static std::shared_ptr<Parent> create( int mi_, int i_ ){
        std::shared_ptr<Parent> newPtr( new Parent( mi_, i_ ) ); //- can not use make_shared ??

        newPtr->anti_bind_shared_from_this();
        return newPtr;
    }

    //- 将 shared_from_this 反向绑定给 组件类实例 --
    void anti_bind_shared_from_this(){
        this->cmpt->bind_Parent_weakPtr( weak_from_this() );
        //... 更多 组件类实例 
        //...
    }

    
    ~Parent(){
        cout << "Parent: end;" << endl;
    }


private:
    Parent( int mi_, int i_ ):
        mi(mi_),
        cmpt( std::make_shared<Component>( i_ ) )
    {
        cout << "Parent: start; mi = " << this->mi << endl;
    }

    int mi;
    std::shared_ptr<Component> cmpt;

};






















