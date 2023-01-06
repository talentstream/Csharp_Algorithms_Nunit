using Algorithms.Sorters;
using Algorithms.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Test.Sorters
{
    public static class BubbleSorterTests
    {
        [Test]
        public static void ArraySorted([Random(0,1000,100,Distinct = true)] int n)
        {
            // Arrange
            var sorter = new BubbleSorter<int>();
            var intComparer = new IntComparer();
            var (correctArray, testArray) = RandomHelper.GetArrays(n);

            // Act
            sorter.Sort(testArray, intComparer);// 前者是用自己写的算法进行比较
            Array.Sort(correctArray, intComparer);// 后者是用系统自带的比较算法进行比较

            // Assert
            Assert.AreEqual(testArray, correctArray);
        }
    }
}
