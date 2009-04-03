using System;
namespace QuickBooks.Net.Query
{
    public interface IQueries
    {
        IClassQuery Class { get; }
        ICreditCardChargeQuery CreditCardCharge { get; }
        IDepositQuery Deposit { get; }
    }
}
