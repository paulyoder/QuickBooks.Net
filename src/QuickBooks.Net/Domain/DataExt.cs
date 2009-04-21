using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Domain
{
    public class DataExt
    {
        public virtual string OwnerID { get; set; }
        public virtual string DataExtName { get; set; }
        public virtual string DataExtType { get; set; }
        public virtual string DataExtValue { get; set; }
    }
}
