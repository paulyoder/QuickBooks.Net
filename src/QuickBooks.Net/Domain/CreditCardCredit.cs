using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickBooks.Net.Domain
{
    [XmlRoot("CreditCardCreditRet")]
    public class CreditCardCredit
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
        public virtual Reference CurrencyRef { get; set; }
        public virtual float ExchangeRate { get; set; }
        public virtual decimal AmountInHomeCurrency { get; set; }
        public virtual string RefNumber { get; set; }
        public virtual string Memo { get; set; }
        [XmlElement("ExpenseLineRet")]
        public virtual List<ExpenseLine> ExpenseLines { get; set; }
    }
}
