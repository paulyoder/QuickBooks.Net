using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Domain
{
    public class JournalLine
    {
        public virtual string TxnLineID { get; set; }
        public virtual string Type { get; set; }
        public virtual Reference AccountRef { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string Memo { get; set; }
        public virtual Reference EntityRef { get; set; }
        public virtual Reference ClassRef { get; set; }
        public virtual string BillableStatus { get; set; }
    }
}
