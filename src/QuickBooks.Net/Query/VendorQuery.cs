using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;

namespace QuickBooks.Net.Query
{
    public class VendorQuery : CommonQueries<IVendorQuery, Vendor>, IVendorQuery
    {
        public VendorQuery(IQBSessionInternal session)
            : base(session, "VendorQueryRq", "VendorQueryRs")
        {
            _returnQuery = this;
        }

        public virtual IVendorQuery TotalBalanceFilter(string @operator, decimal amount)
        {
            AddUpdateMessage("TotalBalanceFilter", "Operator", @operator);
            AddUpdateMessage("TotalBalanceFilter", "Amount", amount.ToString());
            return this;
        }
    }
}
