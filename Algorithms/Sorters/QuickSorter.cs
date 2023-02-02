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
    public abstract class QuickSorter<T> : IComparisonSorter<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="comparer"></param>
        public void Sort(T[] array, IComparer<T> comparer) => Sort(array, comparer, 0, array.Length - 1);

        protected abstract T SelectPivot(T[] array, IComparer<T> comparer, int left, int right);

        private void Sort(T[] array, IComparer<T> comparer, int left, int right)
        {
            if (left >= right)
            {
                return;
            }
            var mid = Partition(array, comparer, left, right);
            Sort(array, comparer, left, mid);
            Sort(array, comparer, mid + 1, right);
        }

        private int Partition(T[] array, IComparer<T> comparer, int left, int right)
        {
            var pivot = SelectPivot(array, comparer, left, right);
            var nleft = left;
            var nright = right;
            while (true)
            {
                while (comparer.Compare(array[nleft], pivot) < 0)
                {
                    nleft++;
                }
                while (comparer.Compare(array[nright], pivot) > 0)
                {
                    nright--;
                }

                if (nleft >= nright)
                {
                    return nright;
                }

                var temp = array[nleft];
                array[nleft] = array[nright];
                array[nright] = temp;

                nleft++;
                nright--;
            }
        }
    }
}
