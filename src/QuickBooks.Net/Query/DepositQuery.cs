using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities;

namespace QuickBooks.Net.Query
{
    public class DepositQuery :
        CommonTransactionQueries<IDepositQuery, Deposit>, IDepositQuery
    {
        public DepositQuery(IQBSessionInternal session)
            : base(session, "DepositQueryRq", "DepositQueryRs")
        {
            _returnQuery = this;
        }

        protected override void SetElementOrder()
        {
            AddElementOrder(
                "TxnID",
                "MaxReturned",
                new ElementPosition("ModifiedDateRangeFilter",
                    "FromModifiedDate",
                    "ToModifiedDate"),
                new ElementPosition("TxnDateRangeFilter",
                    "FromTxnDate",
                    "ToTxnDate",
                    "DateMacro"),
                new ElementPosition("EntityFilter",
                    "ListID",
                    "FullName",
                    "ListIDWithChildren",
                    "FullNameWithChildren"),
                new ElementPosition("AccountFilter",
                    "ListID",
                    "FullName",
                    "ListIDWithChildren",
                    "FullNameWithChildren"),
                "IncludeLineItems",
                "IncludeRetElement",
                "OwnerID");
        }
    }
}
