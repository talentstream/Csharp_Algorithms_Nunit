using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorters
{
    /// <summary>
    ///     实现选择排序的类
    /// </summary>
    /// <typeparam name="T">数组元素类型</typeparam>
    public class SelectionSorter<T> : IComparisonSorter<T>
    {
        /// <summary>
        ///     时间复杂度 O(n^2)
        ///     空间复杂度 O(1)
        ///     找到数组最小元素，然后和第一个位置交换
        ///     指针向后移动一位，然后再在剩下的数组元素找出最小
        ///     如此往复，总共进行了 N 次交换
        /// </summary>
        /// <param name="array">排序数组</param>
        /// <param name="comparer">比较器</param>
        public void Sort(T[] array, IComparer<T> comparer)
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                var jmin = i;
                for(var j = i + 1; j < array.Length; j++)
                {
                    if(comparer.Compare(array[jmin], array[j]) > 0)
                    {
                        jmin = j;
                    }
                }
                var temp = array[i];
                array[i] = array[jmin];
                array[jmin] = temp;
            }
        }
    }
}
