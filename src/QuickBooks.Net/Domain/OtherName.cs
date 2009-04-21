using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickBooks.Net.Domain
{
    [XmlRoot("OtherNameRet")]
    public class OtherName : EntityBase
    {
        public OtherName()
            : base("OtherName")
        { }

        public virtual string CompanyName { get; set; }
        public virtual Address OtherNameAddress { get; set; }
        public virtual AddressBlock OtherNameAddressBlock { get; set; }
        public virtual string Contact { get; set; }
        public virtual string AltContact { get; set; }
    }
}
