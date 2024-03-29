#region 程序集 netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51
// netstandard.dll
#endregion

using System.Collections;
using System.Collections.Generic;

namespace System.Linq
{
    /*
        仔细看!!!   这只是一个 Extension Methods   扩展方法;
            这里的每一个方法, 首元素都是 this 开头的;
    */
    public static class Enumerable
    {
        public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func);
        public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func);
        public static TResult Aggregate<TSource, TAccumulate, TResult>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector);
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
        public static bool Any<TSource>(this IEnumerable<TSource> source);
        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, TSource element);
        public static IEnumerable<TSource> AsEnumerable<TSource>(this IEnumerable<TSource> source);
        public static double Average<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector);
        public static double Average<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector);
        public static decimal? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector);
        public static float Average<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector);
        public static double? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector);
        public static float? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector);
        public static double Average<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector);
        public static double? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector);
        public static decimal Average<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector);
        public static double? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector);
        public static float? Average(this IEnumerable<float?> source);
        public static decimal Average(this IEnumerable<decimal> source);
        public static double Average(this IEnumerable<int> source);
        public static double Average(this IEnumerable<long> source);
        public static double Average(this IEnumerable<double> source);
        public static double? Average(this IEnumerable<double?> source);
        public static double? Average(this IEnumerable<int?> source);
        public static double? Average(this IEnumerable<long?> source);
        public static decimal? Average(this IEnumerable<decimal?> source);
        public static float Average(this IEnumerable<float> source);
        public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source);
        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value);
        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer);
        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
        public static int Count<TSource>(this IEnumerable<TSource> source);
        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source, TSource defaultValue);
        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source);
        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source);
        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer);
        public static TSource ElementAt<TSource>(this IEnumerable<TSource> source, int index);
        public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index);
        public static IEnumerable<TResult> Empty<TResult>();
        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer);
        public static TSource First<TSource>(this IEnumerable<TSource> source);
        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source);
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer);
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector);
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer);
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector);
        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector);
        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer);
        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer);
        public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector);
        public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer);
        public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
        public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer);
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector);
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer);
        public static TSource Last<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
        public static TSource Last<TSource>(this IEnumerable<TSource> source);
        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source);
        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
        public static long LongCount<TSource>(this IEnumerable<TSource> source);
        public static long LongCount<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
        public static double? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector);
        public static long Max<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector);
        public static decimal? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector);
        public static int? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector);
        public static float? Max(this IEnumerable<float?> source);
        public static float? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector);
        public static float Max<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector);
        public static TResult Max<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector);
        public static int Max<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector);
        public static long? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector);
        public static double Max<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector);
        public static double? Max(this IEnumerable<double?> source);
        public static TSource Max<TSource>(this IEnumerable<TSource> source);
        public static float Max(this IEnumerable<float> source);
        public static long? Max(this IEnumerable<long?> source);
        public static int? Max(this IEnumerable<int?> source);
        public static decimal? Max(this IEnumerable<decimal?> source);
        public static long Max(this IEnumerable<long> source);
        public static int Max(this IEnumerable<int> source);
        public static double Max(this IEnumerable<double> source);
        public static decimal Max(this IEnumerable<decimal> source);
        public static decimal Max<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector);
        public static decimal? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector);
        public static int Min<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector);
        public static long Min<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector);
        public static double? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector);
        public static double Min<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector);
        public static long? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector);
        public static float? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector);
        public static float Min<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector);
        public static TResult Min<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector);
        public static int? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector);
        public static decimal Min<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector);
        public static double Min(this IEnumerable<double> source);
        public static float Min(this IEnumerable<float> source);
        public static float? Min(this IEnumerable<float?> source);
        public static long? Min(this IEnumerable<long?> source);
        public static int? Min(this IEnumerable<int?> source);
        public static double? Min(this IEnumerable<double?> source);
        public static decimal? Min(this IEnumerable<decimal?> source);
        public static long Min(this IEnumerable<long> source);
        public static int Min(this IEnumerable<int> source);
        public static TSource Min<TSource>(this IEnumerable<TSource> source);
        public static decimal Min(this IEnumerable<decimal> source);
        public static IEnumerable<TResult> OfType<TResult>(this IEnumerable source);
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer);
        public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
        public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer);
        public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, TSource element);
        public static IEnumerable<int> Range(int start, int count);
        public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count);


        /*
            获得一个容器的 反向迭代器; (大概这个意思)
            本函数并不关心 原始容器中存储的每个元素的内容, 它只是先按照 正向顺序 遍历一遍, 把每个迭代器塞入一个 stack 中;
            然后再逐个 pop 这些迭代器, 从而实现 反向遍历...
            ---
            说到底, 调用本函数是存在一定成本的: O(N);

            注意:
                本函数是惰性的, 调用位置不会立刻执行, 而是要等到访问 GetEnumerator() 或者 foreach 时才会执行;
            =====
            案例:
            foreach( var e in list.Reverse() )
            {
                ...
            }
        */
        public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source);

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector);
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector);
        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector);
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector);
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector);
        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector);
        public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
        public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer);
        public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
        public static TSource Single<TSource>(this IEnumerable<TSource> source);
        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source);
        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
        public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count);
        public static IEnumerable<TSource> SkipLast<TSource>(this IEnumerable<TSource> source, int count);
        public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate);
        public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
        public static decimal? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector);
        public static int Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector);
        public static long Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector);
        public static float Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector);
        public static double Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector);
        public static int? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector);
        public static long? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector);
        public static float? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector);
        public static double? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector);
        public static decimal Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector);
        public static decimal? Sum(this IEnumerable<decimal?> source);
        public static float? Sum(this IEnumerable<float?> source);
        public static long? Sum(this IEnumerable<long?> source);
        public static int? Sum(this IEnumerable<int?> source);
        public static double? Sum(this IEnumerable<double?> source);
        public static long Sum(this IEnumerable<long> source);
        public static int Sum(this IEnumerable<int> source);
        public static double Sum(this IEnumerable<double> source);
        public static decimal Sum(this IEnumerable<decimal> source);
        public static float Sum(this IEnumerable<float> source);
        public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count);
        public static IEnumerable<TSource> TakeLast<TSource>(this IEnumerable<TSource> source, int count);
        public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
        public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate);
        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector);
        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer);
        public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector);
        public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer);
        public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source);
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer);
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector);
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer);
        public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source);
        public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer);
        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source);
        public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
        public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer);
        public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector);
        public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer);
        public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second);
        public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer);
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate);
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector);
    }
}


