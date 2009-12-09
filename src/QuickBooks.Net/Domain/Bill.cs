using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickBooks.Net.Domain
{
    [XmlRoot("BillRet")]
    public class Bill
    {
        public virtual string TxnID { get; set; }
        public virtual DateTime TimeCreated { get; set; }
        public virtual DateTime TimeModified { get; set; }
        public virtual string EditSequence { get; set; }
        public virtual int TxnNumber { get; set; }
        public virtual Reference VendorRef { get; set; }
        public virtual Reference APAccountRef { get; set; }
        public virtual DateTime TxnDate { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual decimal AmountDue { get; set; }
        public virtual Reference CurrencyRef { get; set; }
        public virtual float ExchangeRate { get; set; }
        public virtual decimal AmountDueInHomeCurrency { get; set; }
        public virtual string RefNumber { get; set; }
        public virtual Reference TermsRef { get; set; }
        public virtual string Memo { get; set; }
        public virtual bool IsPaid { get; set; }
        [XmlElement("ExpenseLineRet")]
        public virtual List<ExpenseLine> ExpenseLines { get; set; }
        public virtual decimal OpenAmount { get; set; }
    }
}
