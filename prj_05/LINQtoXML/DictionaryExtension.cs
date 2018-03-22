using System.Collections.Generic;
using System.Text;

namespace LINQtoXML
{
    public static class DictionaryExtension
    {
        public static string ExtendedToString<T,TCount>(this Dictionary<T,TCount> dictionary)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in dictionary)
            {
                builder.AppendFormat($"{item.Key} - {item.Value}\n");
            }
            return builder.ToString();
        }
    }
}
