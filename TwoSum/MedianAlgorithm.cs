using System.Collections.Generic;
using NUnit.Framework;

namespace TwoSum
{
    public class MedianAlgorithm
    {
        public int Calc(IEnumerable<int> items)
        {
            var minQueue = new BinaryHeap<int>(false);
            var maxQueue = new BinaryHeap<int>();

            foreach (var i in items)
            {
                if (minQueue.Count == maxQueue.Count && minQueue.Count == 0)
                {
                    minQueue.Add(i);
                }
                else if (minQueue.Peek() >= i)
                {
                    minQueue.Add(i);
                    while (minQueue.Count > maxQueue.Count)
                    {
                        var maxOfMin = minQueue.Remove();
                        maxQueue.Add(maxOfMin);
                    }
                }
                else
                {
                    maxQueue.Add(i);
                    while (maxQueue.Count > minQueue.Count)
                    {
                        var minOfMax = maxQueue.Remove();
                        minQueue.Add(minOfMax);
                    }
                }
            }

            if (minQueue.Count == maxQueue.Count && minQueue.Count == 0)
            {
                return default(int);
            }

            return (maxQueue.Count >= minQueue.Count) ? maxQueue.Remove() : minQueue.Remove();
        }
    }
}
