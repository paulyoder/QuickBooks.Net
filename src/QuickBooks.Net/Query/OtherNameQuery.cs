using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities;

namespace QuickBooks.Net.Query
{
    public class OtherNameQuery : CommonQueries<IOtherNameQuery, OtherName>, IOtherNameQuery
    {
        public OtherNameQuery(IQBSessionInternal session)
            : base(session, "OtherNameQueryRq", "OtherNameQueryRs")
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
                new ElementPosition("NameFilter",
                    "MatchCriterion",
                    "Name"),
                new ElementPosition("NameRangerFilter",
                    "FromName",
                    "toName"),
                "IncludeRetElement",
                "OwnerID");
        }
    }
}
