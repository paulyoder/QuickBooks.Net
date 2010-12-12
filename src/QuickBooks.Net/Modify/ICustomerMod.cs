using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;

namespace QuickBooks.Net.Modify
{
    public interface ICustomerMod
    {
        ICustomerMod ListID(string listId);
        ICustomerMod EditSequence(string editSequence);
        ICustomerMod CompanyName(string companyName);
        ICustomerMod FirstName(string firstName);
        ICustomerMod MiddleName(string middleName);
        ICustomerMod LastName(string lastName);
        Customer Modify();
    }
}
