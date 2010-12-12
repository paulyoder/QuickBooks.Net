using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickBooks.Net.Domain
{
    [XmlRoot("VendorRet")]
    public class Vendor : EntityBase
    {
        public Vendor()
            : base("Vendor")
        { }

        public virtual string CompanyName { get; set; }
        public virtual Address VendorAddress { get; set; }
        public virtual AddressBlock VendorAddressBlock { get; set; }
        public virtual string Contact { get; set; }
        public virtual string AltContact { get; set; }
        public virtual string NameOnCheck { get; set; }
        public virtual Reference VendorTypeRef { get; set; }
        public virtual Reference TermsRef { get; set; }
        public virtual decimal CreditLimit { get; set; }
        public virtual string VendorTaxIdent { get; set; }
        public virtual bool IsVendorEligibleFor1099 { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual Reference BillingRateRef { get; set; }
    }
}
