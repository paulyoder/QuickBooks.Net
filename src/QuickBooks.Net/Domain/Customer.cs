using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickBooks.Net.Domain
{
    [XmlRoot("CustomerRet")]
    public class Customer : EntityBase
    {
        public Customer()
            : base("Customer")
        { }

        public virtual string FullName { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual Reference ParentRef { get; set; }
        public virtual int Sublevel { get; set; }
        public virtual Address BillAddress { get; set; }
        public virtual AddressBlock BillAddressBlock { get; set; }
        public virtual Address ShipAddress { get; set; }
        public virtual AddressBlock ShipAddressBlock { get; set; }
        public virtual string Contact { get; set; }
        public virtual string AltContact { get; set; }
        public virtual Reference CustomerTypeRef { get; set; }
        public virtual Reference TermsRef { get; set; }
        public virtual Reference SalesRepRef { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual decimal TotalBalance { get; set; }
        public virtual Reference SalesTaxCodeRef { get; set; }
        public virtual Reference ItemSalesTaxRef { get; set; }
        public virtual string ResaleNumber { get; set; }
        public virtual decimal CreditLimit { get; set; }
        public virtual Reference PreferredPaymentMethodRef { get; set; }
        public virtual CCInfo CreditCardInfo { get; set; }
        public virtual string JobStatus { get; set; }
        public virtual DateTime JobStartDate { get; set; }
        public virtual DateTime JobProjectedEndDate { get; set; }
        public virtual DateTime JobEndDate { get; set; }
        public virtual string JobDesc { get; set; }
        public virtual Reference JobTypeRef { get; set; }
        public virtual Reference PriceLevelRef { get; set; }
    }
}
