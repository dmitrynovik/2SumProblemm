using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Stopwatch = System.Diagnostics.Stopwatch;

namespace TwoSum
{
    public class LessThan : IComparer<long>
    {
        public int Compare(long x, long y)
        {
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    public class Sum
    {
        [Test]
        public void TinyTest()
        {
            Assert.AreEqual(2, Calc2Sum(3, 4, new[] { 1L, 2, 3, 4 }));
        }

        [Test]
        public void Compute10k()
        {
            Calc2Sum(-10000, 10000, ReadDictionary());
        }

        private static int Calc2Sum(int low, int high, IEnumerable<long> numbers)
        {
            return Calc2Sum(low, high, numbers.ToDictionary(i => i, i => i));
        }

        private static int Calc2Sum(int low, int high, IDictionary<long, long> numbers)
        {
            var lowerHalf = GetLowerHalfOfKeys(numbers);
            int counter = 0;
            foreach (var sum in Enumerable.Range(low, high - low + 1))
            {
                Debug.WriteLine(sum);
                foreach (var i in numbers.Keys)
                {
                    var j = sum - i;
                    if (i < j && numbers.ContainsKey(sum - i))
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine("Output:");
            Console.WriteLine(counter);
            return counter;
        }

        private static Dictionary<long, long> GetLowerHalfOfKeys(IDictionary<long, long> numbers)
        {
            var sorted = numbers.Keys.ToArray();
            Array.Sort(sorted);
            var lh = new long[sorted.Length/2];
            Array.Copy(sorted, lh, sorted.Length/2);
            return lh.ToDictionary(i => i, i => i);
        }

        private static IDictionary<long, long> ReadDictionary()
        {
            var watch = Stopwatch.StartNew();
            const string file = "2sum.txt";
            var result = new Dictionary<long, long>();
            using (var stream = File.OpenRead(file))
            {
                using (var reader = new StreamReader(stream))
                {
                    string s;
                    while ((s = reader.ReadLine()) != null)
                    {
                        var i = long.Parse(s);
                        result[i] = i;
                    }
                }
            }
            watch.Stop();
            Debug.WriteLine("File read in {0}", watch.Elapsed);
            return result;
        }
    }    
}
