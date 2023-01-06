using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorters
{
    /// <summary>
    ///     排序接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IComparisonSorter<T>
    {
        /// <summary>
        ///     排序方法
        /// </summary>
        /// <param name="array">需要排序的数组</param>
        /// <param name="comparer">比较用的Comparer <paramref name="array" />.</param>
        void Sort(T[] array, IComparer<T> comparer);
    }
}
