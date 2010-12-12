using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities;

namespace QuickBooks.Net.Modify
{
    public class CustomerMod : 
        ModifyBase<ICustomerMod, Customer>,
        ICustomerMod
    {
        public CustomerMod(IQBSessionInternal session)
            : base(session, "CustomerModRq", "CustomerModRs", "CustomerMod")
        {
            _returnMod = this;
        }

        public ICustomerMod ListID(string listId)
        {
            AddUpdateMessage("ListID", listId);
            return this;
        }

        public ICustomerMod EditSequence(string editSequence)
        {
            AddUpdateMessage("EditSequence", editSequence);
            return this;
        }

        public ICustomerMod CompanyName(string companyName)
        {
            AddUpdateMessage("CompanyName", companyName);
            return this;
        }

        public ICustomerMod FirstName(string firstName)
        {
            AddUpdateMessage("FirstName", firstName);
            return this;
        }

        public ICustomerMod MiddleName(string middleName)
        {
            AddUpdateMessage("MiddleName", middleName);
            return this;
        }

        public ICustomerMod LastName(string lastName)
        {
            AddUpdateMessage("LastName", lastName);
            return this;
        }

        protected override void SetElementOrder()
        {
            AddElementOrder(
                new ElementPosition("CustomerMod",
                    "ListID",
                    "EditSequence",
                    "CompanyName",
                    "FirstName",
                    "MiddleName",
                    "LastName"));
        }
    }
}
