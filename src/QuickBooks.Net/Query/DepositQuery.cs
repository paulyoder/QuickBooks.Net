using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;

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
    }
}
