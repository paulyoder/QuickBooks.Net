using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;

namespace QuickBooks.Net.Query
{
    public interface ICreditCardChargeQuery :
        ICommonTransactionQueriesWithRefNumber<ICreditCardChargeQuery, CreditCardCharge>
    { }
}
