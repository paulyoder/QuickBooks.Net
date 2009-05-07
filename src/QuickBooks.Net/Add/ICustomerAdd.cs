using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;

namespace QuickBooks.Net.Add
{
    public interface ICustomerAdd
    {
        ICustomerAdd Name(string name);
        ICustomerAdd IsActive(bool isActive);
        ICustomerAdd Parent(Reference parentRef);
        ICustomerAdd CompanyName(string companyName);
        ICustomerAdd Salutation(string salutation);
        ICustomerAdd FirstName(string firstName);
        ICustomerAdd MiddleName(string middleName);
        ICustomerAdd LastName(string lastName);
        ICustomerAdd BillAddress(Address billAddress);
        ICustomerAdd ShipAddress(Address shipAddress);
        ICustomerAdd Phone(string phone);
        ICustomerAdd AltPhone(string altPhone);
        ICustomerAdd Fax(string fax);
        ICustomerAdd Email(string email);
        ICustomerAdd Contact(string contact);
        ICustomerAdd AltContact(string altContact);
        ICustomerAdd CustomerType(Reference typeRef);
        ICustomerAdd Terms(Reference termsRef);
        ICustomerAdd SalesRep(Reference salesRef);
        ICustomerAdd OpenBalance(decimal openBalance);
        ICustomerAdd OpenBalanceDate(DateTime balanceDate);
        ICustomerAdd SalesTaxCode(Reference salesTaxCode);
        ICustomerAdd ItemSalesTax(Reference itemSalesTax);
        ICustomerAdd ResaleNumber(string resaleNumber);
        ICustomerAdd AccountNumber(string accountNumber);
        ICustomerAdd CreditLimit(decimal creditLimit);
        ICustomerAdd PreferredPaymentMethod(Reference prefPayMethod);
        ICustomerAdd CreditCardInfo(CCInfo creditCard);
        ICustomerAdd JobStatus(string jobStatus);
        ICustomerAdd JobStartDate(DateTime startDate);
        ICustomerAdd JobProjectedEndDate(DateTime projectedEndDate);
        ICustomerAdd JobEndDate(DateTime endDate);
        ICustomerAdd JobDesc(string description);
        ICustomerAdd JobType(Reference jobType);
        ICustomerAdd Notes(string notes);
        ICustomerAdd PriceLevel(Reference priceLevel);
        ICustomerAdd IncludeRetElement(params string[] retElements);
        ICustomerAdd FromDomainObject(Customer customer);
        ICustomerAdd FromDomainObject(Customer customer, bool neglectReferences);
        Customer Add();
    }
}
