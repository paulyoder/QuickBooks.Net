using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Utilities;
using QuickBooks.Net.Utilities.ConversionExtensions;
using QuickBooks.Net.Domain;

namespace QuickBooks.Net.Add
{
    public class EntityAddBase<IReturnAdd, TReturn> : QBXMLBase<TReturn>
    {
        protected IReturnAdd _returnAdd;
        private string _addElementName;

        public EntityAddBase(IQBSessionInternal session, string requestName, string responseName, string addElementName)
            : base(session, requestName, responseName)
        {
            _addElementName = addElementName;
        }

        protected override void AddUpdateMessage(params object[] message)
        {
            base.AddUpdateMessage(
                new List<object>().Ad(_addElementName).AdRange(message).ToArray());
        }

        protected override void AddMessageAllowDuplicates(params object[] message)
        {
            base.AddMessageAllowDuplicates(
                new List<object>().Ad(_addElementName).AdRange(message).ToArray());
        }

        public virtual IReturnAdd Name(string name)
        {
            AddUpdateMessage("Name", name);
            return _returnAdd;
        }

        public virtual IReturnAdd CompanyName(string companyName)
        {
            AddUpdateMessage("CompanyName", companyName);
            return _returnAdd;
        }

        public virtual IReturnAdd IsActive(bool isActive)
        {
            AddUpdateMessage("IsActive", isActive);
            return _returnAdd;
        }

        public virtual IReturnAdd Salutation(string salutation)
        {
            AddUpdateMessage("Salutation", salutation);
            return _returnAdd;
        }

        public virtual IReturnAdd FirstName(string firstName)
        {
            AddUpdateMessage("FirstName", firstName);
            return _returnAdd;
        }

        public virtual IReturnAdd MiddleName(string middleName)
        {
            AddUpdateMessage("MiddleName", middleName);
            return _returnAdd;
        }

        public virtual IReturnAdd LastName(string lastName)
        {
            AddUpdateMessage("LastName", lastName);
            return _returnAdd;
        }

        public virtual IReturnAdd Phone(string phone)
        {
            AddUpdateMessage("Phone", phone);
            return _returnAdd;
        }

        public virtual IReturnAdd AltPhone(string altPhone)
        {
            AddUpdateMessage("AltPhone", altPhone);
            return _returnAdd;
        }

        public virtual IReturnAdd Fax(string fax)
        {
            AddUpdateMessage("Fax", fax);
            return _returnAdd;
        }

        public virtual IReturnAdd Email(string email)
        {
            AddUpdateMessage("Email", email);
            return _returnAdd;
        }

        public virtual IReturnAdd Contact(string contact)
        {
            AddUpdateMessage("Contact", contact);
            return _returnAdd;
        }

        public virtual IReturnAdd AltContact(string altContact)
        {
            AddUpdateMessage("AltContact", altContact);
            return _returnAdd;
        }

        public virtual IReturnAdd AccountNumber(string accountNumber)
        {
            AddUpdateMessage("AccountNumber", accountNumber);
            return _returnAdd;
        }

        public virtual IReturnAdd Notes(string notes)
        {
            AddUpdateMessage("Notes", notes);
            return _returnAdd;
        }

        public virtual IReturnAdd Terms(Reference terms)
        {
            AddReference("TermsRef", terms);
            return _returnAdd;
        }

        public virtual IReturnAdd CreditLimit(decimal creditLimit)
        {
            AddUpdateMessage("CreditLimit", creditLimit);
            return _returnAdd;
        }

        public virtual IReturnAdd OpenBalance(decimal openBalance)
        {
            AddUpdateMessage("OpenBalance", openBalance);
            return _returnAdd;
        }

        public virtual IReturnAdd OpenBalanceDate(DateTime balanceDate)
        {
            AddUpdateMessage("OpenBalanceDate", balanceDate);
            return _returnAdd;
        }

        public virtual IReturnAdd IncludeRetElement(params string[] retElements)
        {
            foreach (var elementName in retElements)
                AddMessageAllowDuplicates("IncludeRetElement", elementName);
            return _returnAdd;
        }

        protected virtual void AddReference(string elementName, Reference reference)
        {
            if (!String.IsNullOrEmpty(reference.ListID))
                AddUpdateMessage(elementName, "ListID", reference.ListID);
            if (!String.IsNullOrEmpty(reference.FullName))
                AddUpdateMessage(elementName, "FullName", reference.FullName);
        }

        protected void AddAddress(string elementName, Address address)
        {
            if (!String.IsNullOrEmpty(address.Addr1))
                AddUpdateMessage(elementName, "Addr1", address.Addr1);
            if (!String.IsNullOrEmpty(address.Addr2))
                AddUpdateMessage(elementName, "Addr2", address.Addr2);
            if (!String.IsNullOrEmpty(address.Addr3))
                AddUpdateMessage(elementName, "Addr3", address.Addr3);
            if (!String.IsNullOrEmpty(address.Addr4))
                AddUpdateMessage(elementName, "Addr4", address.Addr4);
            if (!String.IsNullOrEmpty(address.Addr5))
                AddUpdateMessage(elementName, "Addr5", address.Addr5);
            if (!String.IsNullOrEmpty(address.City))
                AddUpdateMessage(elementName, "City", address.City);
            if (!String.IsNullOrEmpty(address.State))
                AddUpdateMessage(elementName, "State", address.State);
            if (!String.IsNullOrEmpty(address.PostalCode))
                AddUpdateMessage(elementName, "PostalCode", address.PostalCode);
            if (!String.IsNullOrEmpty(address.Country))
                AddUpdateMessage(elementName, "Country", address.Country);
            if (!String.IsNullOrEmpty(address.Note))
                AddUpdateMessage(elementName, "Note", address.Note);
        }

        protected virtual void AddCCInfo(string elementName, CCInfo creditCard)
        {
            if (!String.IsNullOrEmpty(creditCard.CreditCardNumber))
                AddUpdateMessage(elementName, "CreditCardNumber", creditCard.CreditCardNumber);
            if (creditCard.ExpirationMonth != 0)
                AddUpdateMessage(elementName, "ExpirationMonth", creditCard.ExpirationMonth);
            if (creditCard.ExpirationYear != 0)
                AddUpdateMessage(elementName, "ExpirationYear", creditCard.ExpirationYear);
            if (!String.IsNullOrEmpty(creditCard.NameOnCard))
                AddUpdateMessage(elementName, "NameOnCard", creditCard.NameOnCard);
            if (!String.IsNullOrEmpty(creditCard.CreditCardAddress))
                AddUpdateMessage(elementName, "CreditCardAddress", creditCard.CreditCardAddress);
            if (!String.IsNullOrEmpty(creditCard.CreditCardPostalCode))
                AddUpdateMessage(elementName, "CreditCardPostalCode", creditCard.CreditCardPostalCode);
        }

    }
}
