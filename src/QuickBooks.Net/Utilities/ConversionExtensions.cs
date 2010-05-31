using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Utilities.ConversionExtensions
{
    public static class ConversionExtensions
    {
        public static string ToXMLDateString(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static T As<T>(this object value)
        {
            if (String.IsNullOrEmpty(value.ToString()))
                return default(T);
            else
                return (T)Convert.ChangeType(value, typeof(T));
        }

        public static List<T> Ad<T>(this List<T> list, T item)
        {
            list.Add(item);
            return list;
        }

        public static List<T> AdRange<T>(this List<T> list, IEnumerable<T> collection)
        {
            list.AddRange(collection);
            return list;
        }
    }
}
