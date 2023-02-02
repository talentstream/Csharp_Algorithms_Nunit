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
    public class HeapSorter<T> : IComparisonSorter<T>
    {
        public void Sort(T[] array, IComparer<T> comparer)
            => HeapSort(array, comparer);

        private static void HeapSort(IList<T> data, IComparer<T> comparer)
        {
            var heapSize = data.Count;
            for (var p = (heapSize - 1) / 2; p >= 0; p--)
            {
                MakeHeap(data, heapSize, p, comparer);
            }

            for (var i = data.Count - 1; i >= 0; i--)
            {
                var temp = data[i];
                data[i] = data[0];
                data[0] = temp;

                heapSize--;
                MakeHeap(data, heapSize, 0, comparer);
            }
        }

        private static void MakeHeap(IList<T> input, int heapSize, int index, IComparer<T> comparer)
        {
            var rIndex = index;

        }
    }
}
