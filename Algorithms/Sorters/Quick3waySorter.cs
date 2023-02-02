using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorters
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Quick3waySorter<T> : IComparisonSorter<T>
    {
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
