using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickBooks.Net.Domain
{
    [XmlRoot("JournalEntryRet")]
    public class JournalEntry
    {
        public string TxnID { get; set; }
        public string TimeCreated { get; set; }
        public string TimeModified { get; set; }
        public string EditSequence { get; set; }
        public int TxnNumber { get; set; }
        public DateTime TxnDate { get; set; }
        public string RefNumber { get; set; }
        public bool IsAdjustment { get; set; }
        [XmlElement("JournalCreditLine")]
        public virtual List<JournalLine> CreditLines { get; set; }
        [XmlElement("JournalDebitLine")]
        public virtual List<JournalLine> DebitLines { get; set; }
        [XmlElement("DataExtRet")]
        public virtual List<DataExt> DataExt { get; set; }
    }
}
