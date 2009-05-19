using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;

namespace QuickBooks.Net.Add
{
    public interface IVendorAdd
    {
        IVendorAdd Name(string name);
        IVendorAdd IsActive(bool isActive);
        IVendorAdd CompanyName(string companyName);
        IVendorAdd Salutation(string salutation);
        IVendorAdd FirstName(string firstName);
        IVendorAdd MiddleName(string middleName);
        IVendorAdd LastName(string lastName);
        IVendorAdd Address(Address vendorAddress);
        IVendorAdd Phone(string phone);
        IVendorAdd AltPhone(string altPhone);
        IVendorAdd Fax(string fax);
        IVendorAdd Email(string email);
        IVendorAdd Contact(string contact);
        IVendorAdd AltContact(string altContact);
        IVendorAdd NameOnCheck(string nameOnCheck);
        IVendorAdd AccountNumber(string accountNumber);
        IVendorAdd Notes(string notes);
        IVendorAdd VendorType(Reference vendorType);
        IVendorAdd Terms(Reference terms);
        IVendorAdd CreditLimit(decimal creditLimit);
        IVendorAdd VendorTaxIdent(string taxIdent);
        IVendorAdd IsVendorEligibleFor1099(string isEligible);
        IVendorAdd OpenBalance(decimal openBalance);
        IVendorAdd OpenBalanceDate(DateTime balanceDate);
        IVendorAdd BillingRate(Reference billingRate);
        IVendorAdd IncludeRetElement(params string[] retElements);
        IVendorAdd FromDomainObject(Vendor vendor);
        IVendorAdd FromDomainObject(Vendor vendor, bool neglectReferences);
        Vendor Add();
    }
}
