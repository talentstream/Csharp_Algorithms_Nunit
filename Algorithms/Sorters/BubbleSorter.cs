using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorters
{
    /// <summary>
    ///     冒泡排序类
    /// </summary>
    /// <typeparam name="T">数组元素类型</typeparam>
    public class BubbleSorter<T> : IComparisonSorter<T>
    {
        /// <summary>
        ///     时间复杂度 O(n^2)
        ///     空间复杂度 O(1)
        ///     在这里，我们按照升序排序
        ///     比较相邻元素，大的放在后面
        ///     这样子每次最后一个是最大元素
        ///     在不包含最大元素的范围重复步骤，直到没得交换
        ///     最好情况是 N - 1 次交换和 0 次交换
        ///     最坏情况是 N * (N - 1)/2 次交换
        /// </summary>
        /// <param name="array">要排序的数组</param>
        /// <param name="comparer">比较器</param>
        public void Sort(T[] array, IComparer<T> comparer)
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                var wasChanged = false;
                for (var j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        wasChanged = true;
                    }
                }

                if (!wasChanged)
                {
                    break;
                }
            }
        }
    }
}
