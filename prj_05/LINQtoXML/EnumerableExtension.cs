using System.Collections.Generic;

namespace LINQtoXML
{
    public static class EnumerableExtension
    {
        public static string ExtendedToString<T>(this IEnumerable<T> list)
        {
            return string.Join("\n", list);
        }
        public static string ToOneString<T>(this IEnumerable<T> list)
        {
            return string.Join(", ", list);
        }
    }
}
