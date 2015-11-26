using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using NUnit.Framework;

namespace TwoSum
{
    [TestFixture]
    public class MedianAlgorithmTest
    {
        [Test]
        public void TestMedian0to9()
        {
            var items = new[] { 9, 2, 6, 7, 8, 5, 4, 3, 1, 0 };
            var median = new MedianAlgorithm();
            Assert.AreEqual(5, median.Calc(items));
        }

        [Test]
        public void TestMedianOf100()
        {
            var items = Enumerable.Range(1, 100);
            var median = new MedianAlgorithm();
            Assert.AreEqual(51, median.Calc(items));
        }

        [Test]
        public void Assignment()
        {
            const int capacity = 10000;

            var parser = new FileParser();
            var numbers = parser.Read("Median.txt")
                .Select(i => (int)i)
                .ToArray();

            var list = new List<int>(capacity);
            var algorithm = new MedianAlgorithm();
            long cum = 0;
            foreach (var n in numbers)
            {
                list.Add(n);
                var median = algorithm.Calc(list);
                cum += median;
            }

            var result = cum%capacity;
            Console.WriteLine("The medians answer: {0}", result);
        }
        // A1: 427
        // A2: 5129
    }
}
