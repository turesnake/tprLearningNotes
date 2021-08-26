
# ---------------------------------------------- #
#       Attribute 的 构造函数 和 命名参数
# ---------------------------------------------- #

普通 class 的实例化, 可用下列方式:

    A a = new A( 12 ){
        b=0.5f, c="koko"
    };

除了使用构造函数中的参数, 还能用后部的 {} 列表来初始化一些 public 数据.
这个部分叫做: "对象初始化语句"

但这个做法在 Attribute 中是无法实现的, 毕竟 Attribute 没有 "对象初始化语句"

# 在 Attribute 中, 可将 "成员初始化语句" 也放入 () 中,
如下例子:

    public sealed class MyAttribute : System.Attribute
    {
        public int  a;
        public float b;
        public string c;

        public MyAttribute( float b_ )
        {
            this.b = b_;
        }
    }

上文声明了一个 attribute, 它的构造函数只有一个 参数, 但剩余两个成员都是 public 的.
此时可用如下方式:

    [My( 0.123f, a=12, c="koko" )]
    public class AAA{...}

() 中, 先列出参数, 之后跟上 "对象初始化语句"








