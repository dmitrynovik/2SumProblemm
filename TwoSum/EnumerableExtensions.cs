using System.Collections.Generic;

namespace TwoSum
{
    public static class EnumerableExtensions
    {
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> items)
        {
            var ret = new HashSet<T>();
            if (items != null)
            {
                foreach (var i in items)
                {
                    ret.Add(i);
                }
            }
            return ret;
        } 
    }
}
