using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace TwoSum
{
    [TestFixture]
    public class Sum
    {
        [Test]
        public void Compute()
        {
            var numbers = ReadDictionary();
            var sorted = numbers.Keys.ToArray();
            Array.Sort(sorted);

            foreach (var x in numbers.Keys)
            {
                var y1 = -10000 - x;
                var y2 = 10000 - x;
            }
        }

        private IDictionary<long, object> ReadDictionary()
        {
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
            return result;
        }
    }

    
}
