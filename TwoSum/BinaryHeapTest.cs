using NUnit.Framework;

namespace TwoSum
{
    [TestFixture]
    public class BinaryHeapTest
    {
        [Test]
        public void TestHeap()
        {
            var heap = new BinaryHeap<int> {9, 2, 6, 7, 8, 5, 4, 3, 1, 0 };
            for (int i = 0; i < heap.Count; ++i)
            {
                Assert.AreEqual(i, heap.Remove());
            }
        }
    }
}
