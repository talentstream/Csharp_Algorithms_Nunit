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
    public sealed class MiddlePointQuickSorter<T> : QuickSorter<T>
    {
        protected override T SelectPivot(T[] array, IComparer<T> comparer, int left, int right)
            => array[left + (right - left) / 2];
    }
}
