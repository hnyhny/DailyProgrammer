using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System;

namespace hnyhny.Extensions
{
    public static class LinqExtension
    {
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> values)
        {
            if (values.Count() <= 1)
                yield return values;

            foreach (var value in values)
            {
                var sublist = values.ToList();
                sublist.Remove(value);
                foreach (var permutation in sublist.GetPermutations())
                {
                    var list = new List<T>() { value };
                    list.AddRange(permutation);
                    yield return list;
                }
            }
        }
    }
}