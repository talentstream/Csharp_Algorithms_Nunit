using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Test.Helpers
{
    public static class RandomHelper
    {
        public static (int[] correctArray, int[] testArray) GetArrays(int n)
        {
            var testArr = new int[n];
            var correctArray = new int[n];

            for(var i = 0; i < n; i++)
            {
                var t = TestContext.CurrentContext.Random.Next(1_000_000);
                testArr[i] = t;
                correctArray[i] = t;
            }

            return (correctArray, testArr);
        }
    }
} 
