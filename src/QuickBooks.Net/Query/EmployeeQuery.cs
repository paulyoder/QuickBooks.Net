using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities;

namespace QuickBooks.Net.Query
{
    public class EmployeeQuery : CommonQueries<IEmployeeQuery, Employee>, IEmployeeQuery
    {
        public EmployeeQuery(IQBSessionInternal session)
            : base(session, "EmployeeQueryRq", "EmployeeQueryRs")
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
