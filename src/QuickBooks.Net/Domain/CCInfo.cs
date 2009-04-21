using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Domain
{
    public class CCInfo
    {
        public virtual string CreditCardNumber { get; set; }
        public virtual int ExpirationMonth { get; set; }
        public virtual int ExpirationYear { get; set; }
        public virtual string NameOnCard { get; set; }
        public virtual string CreditCardAddress { get; set; }
        public virtual string CreditCardPostalCode { get; set; }
    }
}
