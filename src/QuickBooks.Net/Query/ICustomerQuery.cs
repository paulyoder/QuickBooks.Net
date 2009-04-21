using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;

namespace QuickBooks.Net.Query
{
    public interface ICustomerQuery :
        ICommonQueries<ICustomerQuery>,
        IQueryBase<Customer>
    {
        ICustomerQuery TotalBalanceFilter(string @operator, decimal amount);
    }
}
