using System;
namespace QuickBooks.Net.Query
{
    public interface IQueries
    {
        IAccountQuery Account { get; }
        IBillQuery Bill { get; }
        IClassQuery Class { get; }
        ICheckQuery Check { get; }
        ICreditCardChargeQuery CreditCardCharge { get; }
        ICreditCardCreditQuery CreditCardCredit { get; }
        IDepositQuery Deposit { get; }
        IEntityQuery Entity { get; }
        ICustomerQuery Customer { get; }
        IEmployeeQuery Employee { get; }
        IOtherNameQuery OtherName { get; }
        IVendorQuery Vendor { get; }
        IJournalEntryQuery JournalEntry { get; }
    }
}
