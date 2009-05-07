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

        public static T As<T>(this object @object)
        {
            return (T)Convert.ChangeType(@object, typeof(T));
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
