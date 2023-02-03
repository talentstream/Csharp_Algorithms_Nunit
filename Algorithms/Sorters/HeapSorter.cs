using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorters
{
    /// <summary>
    ///     实现堆排序的类 这里是小根堆
    /// </summary>
    /// <typeparam name="T">数组元素类型</typeparam>
    public class HeapSorter<T> : IComparisonSorter<T>
    {
        /// <summary>
        ///     时间复杂度 O(nlogn)
        /// </summary>
        /// <param name="array"></param>
        /// <param name="comparer"></param>
        public void Sort(T[] array, IComparer<T> comparer)
            => HeapSort(array, comparer);

        private static void HeapSort(IList<T> data, IComparer<T> comparer)
        {
            // 创建堆？
            var heapSize = data.Count;
            for (var p = (heapSize - 1) / 2; p >= 0; p--)
            {
                  MakeHeap(data, heapSize, p, comparer);
            }

            // 将降序堆转化为升序队列，即将每个大根堆堆顶的元素取走然后重塑堆
            for (var i = data.Count - 1; i >= 0; i--)
            {
                var temp = data[i];
                data[i] = data[0];
                data[0] = temp;

                heapSize--;
                MakeHeap(data, heapSize, 0, comparer);
            }
        }

        private static void MakeHeap(IList<T> data, int heapSize, int index, IComparer<T> comparer)
        {
            var largest = index;
            var left = 2 * (index + 1) - 1;
            var right = 2 * (index + 1);

            if (left < heapSize && comparer.Compare(data[left], data[largest]) > 0)
            {
                largest = left;
            }

            if (right < heapSize && comparer.Compare(data[right], data[largest]) > 0)
            {
                largest = right;
            }

            if (largest != index)
            {
                var temp = data[index];
                data[index] = data[largest];
                data[largest] = temp;

                MakeHeap(data, heapSize, largest, comparer);
            }
        }
    }
}
