using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorters
{
    /// <summary>
    ///     实现三向切分快排的类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Quick3waySorter<T> : IComparisonSorter<T>
    {
        /// <summary>
        ///     时间复杂度与快排差不多
        ///     但是对大量重复元素执行效率更高
        ///     在快排的基础上，我们选一个参数
        ///     但是有重复元素，我们将重复元素放在中间
        ///     然后对左对右进行分别递归
        ///     这样子减少对重复的排序
        /// </summary>
        /// <param name="array"></param>
        /// <param name="comparer"></param>
        public void Sort(T[] array, IComparer<T> comparer)
            => Sort(array, comparer, 0, array.Length - 1);
        private void Sort(T[] array, IComparer<T> comparer, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            var (lt, rt) = Partition(array, comparer, left, right);
            Sort(array, comparer, left, lt - 1);
            Sort(array, comparer, rt + 1, right);
        }

        private (int lt, int rt) Partition(T[] array, IComparer<T> comparer, int left, int right)
        {
            var pivot = array[left];
            var lt = left;
            var i = left + 1;
            var rt = right;

            while (i <= rt)
            {

                var cmp = comparer.Compare(array[i], pivot);
                if (cmp < 0)
                {
                    Swap(array, lt++, i++);
                }
                else if (cmp > 0)
                {
                    Swap(array, i, rt--);
                }
                else
                {
                    i++;
                }
            }

            return (lt, rt);
        }

        private void Swap(T[] array, int x, int y)
        {
            var temp = array[x];
            array[x] = array[y];
            array[y] = temp;
        }
    }
}
