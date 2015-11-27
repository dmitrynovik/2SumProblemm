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
        public void TestMedian1to2()
        {
            AssertMedian(1, Enumerable.Range(1, 2));
        }

        [Test]
        public void TestMedian0to9()
        {
            AssertMedian(4, new[] {9, 2, 6, 7, 8, 5, 4, 3, 1, 0});
        }

        private static void AssertMedian(int assert, IEnumerable<int> items)
        {
            var median = new MedianAlgorithm();
            items.ToList().ForEach(x => { median.Add(x); });
            Assert.AreEqual(assert, median.Median());
        }

        [Test]
        public void TestMedianOf100()
        {
            AssertMedian(50, Enumerable.Range(1, 100));
        }

        [Test]
        public void Assignment()
        {
            const int capacity = 10000;

            var parser = new FileParser();
            var numbers = parser.Read("Median.txt")
                .Select(i => (int)i)
                .ToArray();

            var algorithm = new MedianAlgorithm();
            long cum = numbers.Select(n => algorithm.Add(n)).Aggregate<int, long>(0, (current, median) => current + median);

            var result = cum%capacity;
            Console.WriteLine("The medians answer: {0}", result);
        }
        // A1: 427
        // A2: 1213
    }
}
