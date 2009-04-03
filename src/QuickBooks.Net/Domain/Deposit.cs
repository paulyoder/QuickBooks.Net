using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickBooks.Net.Domain
{
    [XmlRoot("DepositRet")]
    public class Deposit
    {
        public virtual string TxnID { get; set; }
        public virtual DateTime TimeCreated { get; set; }
        public virtual DateTime TimeModified { get; set; }
        public virtual string EditSequence { get; set; }
        public virtual int TxnNumber { get; set; }
        public virtual DateTime TxnDate { get; set; }
        public virtual Reference DepositToAccountRef { get; set; }
        public virtual string Memo { get; set; }
        public virtual decimal DepositTotal { get; set; }
        [XmlElement("DepositLineRet")]
        public virtual List<DepositLine> DepositLines { get; set; }
    }
}
