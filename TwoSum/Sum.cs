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
            int progress = 0;
            foreach (var x in numbers.Keys)
            {
                var y1 = -10000 - x;
                var y2 = 10000 - x;
                // Get all numbers in range [y1 ... y2]:
                counter += GetRange(y1, y2).Count(j => numbers.ContainsKey(j));
                progress++;
            }

            Console.WriteLine("Output:");
            Console.WriteLine(counter / 2);
        }

        private static IEnumerable<long> GetRange(long start, long end)
        {
            for (long i = start; i <= end; i++)
            {
                yield return i;
            }
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
