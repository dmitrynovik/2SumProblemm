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
        public void Compute()
        {
            var numbers = ReadDictionary();

            int counter = 0;
            var lowerHalf = GetLowerHalfOfKeys(numbers);

            foreach (var i in Enumerable.Range(-10000, 10000))
            {
                Debug.WriteLine(i);
                foreach (var j in lowerHalf.Keys)
                {
                    if (j*2 != i && numbers.ContainsKey(i - j))
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine("Output:");
            Console.WriteLine(counter);
        }

        private static Dictionary<long, long> GetLowerHalfOfKeys(IDictionary<long, object> numbers)
        {
            var sorted = numbers.Keys.ToArray();
            Array.Sort(sorted);
            var lh = new long[sorted.Length/2];
            Array.Copy(sorted, lh, sorted.Length/2);
            var lowerHalf = lh.ToDictionary(i => i, i => i);
            return lowerHalf;
        }

        private static IDictionary<long, object> ReadDictionary()
        {
            var watch = Stopwatch.StartNew();
            const string file = "2sum.txt";
            var result = new Dictionary<long, object>();
            using (var stream = File.OpenRead(file))
            {
                using (var reader = new StreamReader(stream))
                {
                    string s;
                    while ((s = reader.ReadLine()) != null)
                    {
                        var i = long.Parse(s);
                        result[i] = null;
                    }
                }
            }
            watch.Stop();
            Debug.WriteLine("File read in {0}", watch.Elapsed);
            return result;
        }
    }    
}
