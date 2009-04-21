using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;

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
    }
}
