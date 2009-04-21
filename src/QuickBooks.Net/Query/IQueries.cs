using System;
namespace QuickBooks.Net.Query
{
    public interface IQueries
    {
        IClassQuery Class { get; }
        ICreditCardChargeQuery CreditCardCharge { get; }
        IDepositQuery Deposit { get; }
        IEntityQuery Entity { get; }
        ICustomerQuery Customer { get; }
        IEmployeeQuery Employee { get; }
        IOtherNameQuery OtherName { get; }
        IVendorQuery Vendor { get; }
    }
}
