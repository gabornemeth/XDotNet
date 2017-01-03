using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTools.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool Contains<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            foreach (var item in items)
                if (predicate(item))
                    return true;

            return false;
        }
    }
}
