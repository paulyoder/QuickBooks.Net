using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Domain
{
    public class Reference
    {
        public virtual string ListID { get; set; }
        public virtual string FullName { get; set; }

        public static Reference FromListID(string listID)
        {
            return new Reference() { ListID = listID };
        }

        public static Reference FromFullName(string fullName)
        {
            return new Reference() { FullName = fullName };
        }
    }
}
