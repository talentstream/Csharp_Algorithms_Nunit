using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Test.Helpers
{
    internal class IntComparer : IComparer<int>
    {
        int IComparer<int>.Compare(int x, int y)
        {
            return x.CompareTo(y);
        }

        // public int Compare(int x, int y) => x.CompareTo(y);
    }
}
