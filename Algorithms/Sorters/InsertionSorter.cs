using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorters
{
    /// <summary>
    ///     实现插入排序的算法
    /// </summary>
    /// <typeparam name="T">数组元素类型</typeparam>
    public class InsertionSorter<T> : IComparisonSorter<T>
    {
        /// <summary>
        ///     时间复杂度 O(n^2)
        ///     空间复杂度 O(1)
        ///     我们保证当前需要排序的元素的前面是有序的
        ///     然后将该元素插入前面中
        ///     由于前面是有序的，假设是升序
        ///     只要找到第一个比它小的元素插入就停止
        ///     否则就一直两两交换位置直到第一位
        ///     平均情况下需要 N^2/4 次交换
        ///     最坏情况需要 N^2/2 次交换
        ///     最好情况需要 N - 1 次交换 和 0 次交换
        /// </summary>
        /// <param name="array">排序数组</param>
        /// <param name="comparer">比较器</param>
        public void Sort(T[] array, IComparer<T> comparer)
        {
            for (var i = 1; i < array.Length; i++)
            {
                for (var j = i; j > 0 && comparer.Compare(array[j], array[j - 1]) < 0; j--)
                {
                    var temp = array[j - 1];
                    array[j - 1] = array[j];
                    array[j] = temp;
                }
            }
        }
    }
}
