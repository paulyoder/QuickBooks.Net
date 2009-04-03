using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickBooks.Net.Domain
{
    [XmlRoot("CreditCardChargeRet")]
    public class CreditCardCharge
    {
        public virtual string TxnID { get; set; }
        public virtual DateTime TimeCreated { get; set; }
        public virtual DateTime TimeModified { get; set; }
        public virtual string EditSequence { get; set; }
        public virtual int TxnNumber { get; set; }
        public virtual Reference AccountRef { get; set; }
        public virtual Reference PayeeEntityRef { get; set; }
        public virtual DateTime TxnDate { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string RefNumber { get; set; }
        public virtual string Memo { get; set; }
        [XmlElement("ExpenseLineRet")]
        public virtual List<ExpenseLine> ExpenseLines { get; set; }
    }
}
