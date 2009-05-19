using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities;

namespace QuickBooks.Net.Query
{
    public class CustomerQuery : CommonQueries<ICustomerQuery, Customer>, ICustomerQuery
    {
        public CustomerQuery(IQBSessionInternal session)
            : base(session, "CustomerQueryRq", "CustomerQueryRs")
        {
            _returnQuery = this;
        }

        public virtual ICustomerQuery TotalBalanceFilter(string @operator, decimal amount)
        {
            AddUpdateMessage("TotalBalanceFilter", "Operator", @operator);
            AddUpdateMessage("TotalBalanceFilter", "Amount", amount.ToString());
            return this;
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
                new ElementPosition("TotalBalanceFilter",
                    "Operator",
                    "Amount"),
                "IncludeRetElement",
                "OwnerID");
        }
    }
}
