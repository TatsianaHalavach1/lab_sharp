using System.Collections.Generic;
using System.Linq;

namespace lib_NumberRows
{
    public static class ListExtension
    {
        public static string ExtendedToString(this List<long> list)
        {
            return string.Join(" ", list.Select(item => item.ToString()));
        }
    }
}
