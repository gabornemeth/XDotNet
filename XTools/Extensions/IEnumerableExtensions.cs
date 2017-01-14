using System;
using System.Collections.Generic;

namespace XTools
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
