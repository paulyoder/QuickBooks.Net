using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities;

namespace QuickBooks.Net.Query
{
    public class AccountQuery : CommonQueries<IAccountQuery, Account>, IAccountQuery
    {
        public AccountQuery(IQBSessionInternal session)
            : base(session, "AccountQueryRq", "AccountQueryRs")
        {
            _returnQuery = this;
        }

        protected override void SetElementOrder()
        {
            AddElementOrder(
                "ListID",
                "FullName",
                "MaxReturned",
                "ActiveStatus",
                "FromModifiedDate",
                "ToModifiedDate",
                new ElementPosition("NameFilter", "MatchCriterion", "Name"),
                new ElementPosition("NameRangeFilter", "FromName", "ToName"),
                "IncludeRetElement");
        }
    }
}
