using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Stopwatch = System.Diagnostics.Stopwatch;

namespace TwoSum
{
    [TestFixture]
    public class Sum
    {
        [Test]
        public void TinyTest()
        {
            Assert.AreEqual(2, Calc2Sum(3, 4, (new[] { 1L, 2, 3, 4 }).ToHashSet()));
        }

        [Test]
        public void Compute10k()
        {
            Calc2Sum(-10000, 10000, ReadNumbers());
        }

        private static int Calc2Sum(int low, int high, ICollection<long> numbers)
        {
            var lowerHalf = GetLowerHalfOfKeys(numbers);
            var found = new HashSet<int>();
            foreach (var sum in Enumerable.Range(low, high - low + 1))
            {
                Debug.WriteLine(sum);
                foreach (var i in numbers)
                {
                    var j = sum - i;
                    if (i < j && numbers.Contains(sum - i))
                    {
                        found.Add(sum);
                    }
                }
            }
            Console.WriteLine("Found: {0}", found.Count);
            Console.WriteLine();
            return found.Count;
        }

        private static HashSet<long> GetLowerHalfOfKeys(ICollection<long> numbers)
        {
            var sorted = numbers.ToArray();
            Array.Sort(sorted);
            var lh = new long[sorted.Length / 2];
            Array.Copy(sorted, lh, sorted.Length / 2);
            return lh.ToHashSet();
        }

        private static ICollection<long> ReadNumbers()
        {
            var watch = Stopwatch.StartNew();
            const string file = "2sum.txt";
            var result = new HashSet<long>();
            using (var stream = File.OpenRead(file))
            {
                using (var reader = new StreamReader(stream))
                {
                    string s;
                    while ((s = reader.ReadLine()) != null)
                    {
                        result.Add(long.Parse(s));
                    }
                }
            }
            watch.Stop();
            Debug.WriteLine("File read in {0}", watch.Elapsed);
            return result;
        }
    }    
}
