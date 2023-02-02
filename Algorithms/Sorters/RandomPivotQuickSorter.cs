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
    public sealed class RandomPivotQuickSorter<T> : QuickSorter<T>
    {
        private readonly Random _random = new();
        protected override T SelectPivot(T[] array, IComparer<T> comparer, int left, int right)
            => array[_random.Next(left, right + 1)];
    }
}
