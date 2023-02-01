using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorters
{
    /// <summary>
    ///     实现归并排序的类
    /// </summary>
    /// <typeparam name="T">数组参数类型</typeparam>
    public class MergeSorter<T> : IComparisonSorter<T>
    {
        /// <summary>
        ///     时间复杂度 O(n*logn)
        ///     空间复杂度 O(n)
        ///     归并数组就是将两个有序的数组归并成更大的有序数组
        ///     通常用自顶向下比较容易理解
        ///     不断递归到大小只有 1 的数组，然后逐步向上归并
        /// </summary>
        /// <param name="array"></param>
        /// <param name="comparer"></param>
        public void Sort(T[] array, IComparer<T> comparer)
        {
            if (array.Length <= 1)
            {
                return;
            }

            var (left, right) = Split(array);
            Sort(left, comparer);
            Sort(right, comparer);
            Merge(array, left, right, comparer);
        }

        private static void Merge(T[] array, T[] left, T[] right, IComparer<T> comparer)
        {
            var mainIndex = 0;
            var leftIndex = 0;
            var rightIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                var compResult = comparer.Compare(left[leftIndex], right[rightIndex]);
                array[mainIndex++] = compResult <= 0 ? left[leftIndex++] : right[rightIndex++];
            }

            while (leftIndex < left.Length)
            {
                array[mainIndex++] = left[leftIndex++];
            }

            while (rightIndex < right.Length)
            {
                array[mainIndex++] = right[rightIndex++];
            }
        }

        private static (T[] left, T[] right) Split(T[] array)
        {
            var mid = array.Length / 2;
            return (array.Take(mid).ToArray(), array.Skip(mid).ToArray());
        }
    }
}
