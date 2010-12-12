using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities;

namespace QuickBooks.Net.Query
{
    public class CheckQuery :
        CommonTransactionQueriesWithRefNumber<ICheckQuery, Check>,
        ICheckQuery
    {
        public CheckQuery(IQBSessionInternal session)
            : base(session, "CheckQueryRq", "CheckQueryRs")
        {
            _returnQuery = this;
        }

        protected override void SetElementOrder()
        {
            AddElementOrder(
                "TxnID",
                "RefNumber",
                "RefNumberCaseSensitive",
                "MaxReturned",
                new ElementPosition("ModifiedDateRangeFilter",
                    "FromModifiedDate", "ToModifiedDate"),
                new ElementPosition("TxnDateRangeFilter",
                    "FromTxnDate", "ToTxnDate", "DateMacro"),
                new ElementPosition("EntityFilter",
                    "ListID", "FullName", "ListIDWithChildren", "FullNameWithChildren"),
                new ElementPosition("AccountFilter",
                    "ListID", "FullName", "ListIDWithChildren", "FullNameWithChildren"),
                new ElementPosition("RefNumberFilter",
                    "MatchCriterion", "RefNumber"),
                new ElementPosition("RefNumberRangeFilter",
                    "MatchCriterion", "RefNumber"),
                "IncludeLineItems",
                "IncludeLinkedTxns",
                "IncludeRetElement",
                "OwnerID");
        }
    }
}
