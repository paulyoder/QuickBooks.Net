using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using QuickBooks.Net;

namespace QuickBooks.Net.Query
{
    public class CreditCardChargeQuery : 
        CommonTransactionQueriesWithRefNumber<ICreditCardChargeQuery, CreditCardCharge>,
        ICreditCardChargeQuery
    {
        public CreditCardChargeQuery(IQBSessionInternal session)
            : base(session, "CreditCardChargeQueryRq", "CreditCardChargeQueryRs")
        {
            _returnQuery = this;
        }
    }
}
