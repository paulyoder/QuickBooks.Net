using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Utilities.DateTimeExtensions
{
    public static class DateTimeExtensions
    {
        public static string ToXMLDateString(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
    }
}
