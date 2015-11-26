using System.Linq;
using NUnit.Framework;

namespace TwoSum
{
    [TestFixture]
    public class BinaryHeapTest
    {
        [Test]
        public void TestMinHeap()
        {
            var heap = CreateHeap0To9(true);
            for (int i = 0; i < heap.Count; ++i)
            {
                Assert.AreEqual(i, heap.Remove());
            }
        }

        [Test]
        public void TestMaxHeap()
        {
            var heap = CreateHeap0To9(false);
            for (int i = heap.Count - 1; i >= 0; --i)
            {
                Assert.AreEqual(i, heap.Remove());
            }
        }

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

        private static BinaryHeap<int> CreateHeap0To9(bool min)
        {
            return new BinaryHeap<int>(min) { 9, 2, 6, 7, 8, 5, 4, 3, 1, 0 };
        }
    }
}
