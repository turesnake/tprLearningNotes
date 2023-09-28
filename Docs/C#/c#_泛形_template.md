# ================================================================ #
#                    c# 泛形 template
# ================================================================ #



# -------------------------------------- #
#       加减法 operator
# -------------------------------------- #

c# 原生不支持 加减运算 的 模板操作....


# -1- 不太推荐:
# 但是 Marc Gravell 实现了一个库: 
 https://stackoverflow.com/questions/171664/how-to-turn-these-3-methods-into-one-using-c-sharp-generics

https://jonskeet.uk/csharp/miscutil/usage/genericoperators.html

    他实现为:
        Operator.Add(x, y);
        Operator.Subtract(x, y);
    这样子;



# -2- 推荐:
https://stackoverflow.com/questions/3598341/define-a-generic-that-implements-the-operator


    public interface IBase<T>
    {
        T Add(T a);
        T Minus(T a);
    }

    public class SplinesExtended<T> 
                                    where T:IBase<T>
    {
    }
    ------

    此法很简单



# -3- c# 11 部分支持:
https://stackoverflow.com/questions/5905563/c-sharp-generic-operators

但是 unity 2021 只支持 c# 8











































