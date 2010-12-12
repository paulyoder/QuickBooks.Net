using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace QuickBooks.Net.Domain
{
    [XmlRoot("TransactionRet")]
    public class Transaction
    {
        public virtual string TxnType { get; set; }
        public virtual int TxnID { get; set; }
        public virtual int TxnLineID { get; set; }
        public virtual DateTime TimeCreated { get; set; }
        public virtual DateTime TimeModified { get; set; }
        public virtual Reference EntityRef { get; set; }
        public virtual Reference AccountRef { get; set; }
        public virtual DateTime TxnDate { get; set; }
        public virtual string RefNumber { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string Memo { get; set; }
    }
}
