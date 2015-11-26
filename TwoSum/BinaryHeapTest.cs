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

        private static BinaryHeap<int> CreateHeap0To9(bool min)
        {
            return new BinaryHeap<int>(min) { 9, 2, 6, 7, 8, 5, 4, 3, 1, 0 };
        }
    }
}
