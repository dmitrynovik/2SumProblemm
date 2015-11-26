using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace TwoSum
{
    public class FileParser
    {
        public HashSet<long> Read(string path)
        {
            var watch = Stopwatch.StartNew();
            var result = new HashSet<long>();
            using (var stream = File.OpenRead(path))
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
