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
        ///     
        /// </summary>
        /// <param name="array"></param>
        /// <param name="comparer"></param>
        public void Sort(T[] array, IComparer<T> comparer)
        {
            for(var i = 0;i< array.Length-1; i++)
            {
                var wasChanged = false;
                for(var j = 0; j < array.Length - i - 1; j++)
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
