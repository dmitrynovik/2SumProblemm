using System.Collections.Generic;
using System.Linq;

namespace TwoSum
{
    public class MedianAlgorithm
    {
        readonly BinaryHeap<int> _minQueue = new BinaryHeap<int>(false);
        readonly BinaryHeap<int> _maxQueue = new BinaryHeap<int>();

        public int Add(int i)
        {
            if (_minQueue.Count == _maxQueue.Count && _minQueue.Count == 0)
            {
                _minQueue.Add(i);
            }
            else if (_minQueue.Peek() >= i)
            {
                _minQueue.Add(i);
                while (_minQueue.Count > _maxQueue.Count)
                {
                    var maxOfMin = _minQueue.Remove();
                    _maxQueue.Add(maxOfMin);
                }
            }
            else
            {
                _maxQueue.Add(i);
                while (_maxQueue.Count > _minQueue.Count)
                {
                    var minOfMax = _maxQueue.Remove();
                    _minQueue.Add(minOfMax);
                }
            }

            return Median();
        }

        public int Median()
        {
            if (_minQueue.Count == _maxQueue.Count && _minQueue.Count == 0)
            {
                return default(int);
            }
            return (_maxQueue.Count > _minQueue.Count) ? _maxQueue.Peek() : _minQueue.Peek();
        }
    }
}
