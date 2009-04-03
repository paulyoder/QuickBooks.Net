using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBooks.Net.Domain
{
    public class DepositLine
    {
        public virtual string TxnType { get; set; }
        public virtual string TxnID { get; set; }
        public virtual string TxnLineID { get; set; }
        public virtual string PaymentTxnLineID { get; set; }
        public virtual Reference EntityRef { get; set; }
        public virtual Reference AccountRef { get; set; }
        public virtual string Memo { get; set; }
        public virtual string CheckNumber { get; set; }
        public virtual Reference PaymentMethodRef { get; set; }
        public virtual Reference ClassRef { get; set; }
        public virtual decimal Amount { get; set; }
    }
}
