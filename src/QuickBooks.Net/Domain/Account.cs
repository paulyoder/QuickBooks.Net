using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickBooks.Net.Domain
{
    [XmlRoot("AccountRet")]
    public class Account
    {
        public string ListID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeModified { get; set; }
        public string EditSequence { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public Reference ParentRef { get; set; }
        public int Sublevel { get; set; }
        public string AccountType { get; set; }
        public string SpecialAccountType { get; set; }
        public string AccountNumber { get; set; }
        public string BankNumber { get; set; }
        public string Desc { get; set; }
        public decimal Balance { get; set; }
        public decimal TotalBalance { get; set; }
        public string CashFlowClassification { get; set; }
        [XmlElement("DataExtRet")]
        public virtual List<DataExt> DataExt { get; set; }
    }
}
