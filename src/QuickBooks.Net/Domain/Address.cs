using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Domain
{
    public class Address
    {
        public virtual string Addr1 { get; set; }
        public virtual string Addr2 { get; set; }
        public virtual string Addr3 { get; set; }
        public virtual string Addr4 { get; set; }
        public virtual string Addr5 { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
        public virtual string Note { get; set; }
    }
}
