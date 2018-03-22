using System.Collections.Generic;
using System.Linq;

namespace prj_05
{
    public static class EnumerableExtension
    {
        public static string ExtendedToString<T>(this IEnumerable<T> list)
        {
            list = list.ToList();
            return string.Join(" ", list);
        }
    }
}
