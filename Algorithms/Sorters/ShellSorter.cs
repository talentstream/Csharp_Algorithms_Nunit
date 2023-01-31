using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorters
{
    /// <summary>
    ///     实现希尔排序的类
    /// </summary>
    /// <typeparam name="T">数组元素类型</typeparam>
    public class ShellSorter<T> : IComparisonSorter<T>
    {
        /// <summary>
        ///     希尔排序的最坏时间复杂度取决于step
        ///     在这里，我们使用比较普遍的 1,4,13,40 数列
        ///     若使用 对数组长度进行对半取，最坏时间复杂度大概为 O(n^2)
        ///     3*n+1 大概在 O(n^(3/2))
        ///     希尔排序就是用跳跃式的来减少最坏情况的发生
        ///     也就是说，原本插入可能要 N 次 交换，变到 3 次交换
        ///     最优的时间复杂度为O(n*(logn)^2),但是step的计算比较麻烦
        ///     所以通常用 3 为倍数
        /// </summary>
        /// <param name="array">排序数组</param>
        /// <param name="comparer">比较器</param>
        public void Sort(T[] array, IComparer<T> comparer)
        {
            var step = 1;
            while (step < array.Length / 3) step = 3 * step + 1;
            while(step>=1)
            {
                GappedInsertionSort(array, comparer, step);
                step /= 3;
            }
        }

        private static void GappedInsertionSort(T[] array,IComparer<T> comparer,int step)
        {
            for(var i = step; i < array.Length; i++)
            {
                for(var j = i; j>=step && comparer.Compare(array[j],array[j - step]) < 0; j-= step)
                {
                    var temp = array[j];
                    array[j] = array[j - step];
                    array[j - step] = temp;
                }
            }
        }
    }
}
