using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities;
using QuickBooks.Net.Utilities.ConversionExtensions;

namespace QuickBooks.Net.Add
{
    public class CustomerAdd : QBXMLBase<Customer>, ICustomerAdd
    {
        public CustomerAdd(IQBSessionInternal session)
            : base(session, "CustomerAddRq", "CustomerAddRs")
        { }

        protected override void AddUpdateMessage(params object[] message)
        {
            base.AddUpdateMessage(
                new List<object>().Ad("CustomerAdd").AdRange(message).ToArray());
        }

        protected override void AddMessageAllowDuplicates(params object[] message)
        {
            base.AddMessageAllowDuplicates(
                new List<object>().Ad("CustomerAdd").AdRange(message).ToArray());
        }

        public virtual ICustomerAdd Name(string name)
        {
            AddUpdateMessage("Name", name);
            return this;
        }

        public virtual ICustomerAdd IsActive(bool isActive)
        {
            AddUpdateMessage("IsActive", isActive);
            return this;
        }

        public virtual ICustomerAdd Parent(Reference parentRef)
        {
            AddReference("ParentRef", parentRef);
            return this;
        }

        public virtual ICustomerAdd CompanyName(string companyName)
        {
            AddUpdateMessage("CompanyName", companyName);
            return this;
        }

        public virtual ICustomerAdd Salutation(string salutation)
        {
            AddUpdateMessage("Salutation", salutation);
            return this;
        }

        public virtual ICustomerAdd FirstName(string firstName)
        {
            AddUpdateMessage("FirstName", firstName);
            return this;
        }

        public virtual ICustomerAdd MiddleName(string middleName)
        {
            AddUpdateMessage("MiddleName", middleName);
            return this;
        }

        public virtual ICustomerAdd LastName(string lastName)
        {
            AddUpdateMessage("LastName", lastName);
            return this;
        }

        public virtual ICustomerAdd BillAddress(Address billAddress)
        {
            AddAddress("BillAddress", billAddress);
            return this;
        }

        public virtual ICustomerAdd ShipAddress(Address shipAddress)
        {
            AddAddress("ShipAddress", shipAddress);
            return this;
        }

        public virtual ICustomerAdd Phone(string phone)
        {
            AddUpdateMessage("Phone", phone);
            return this;
        }

        public virtual ICustomerAdd AltPhone(string altPhone)
        {
            AddUpdateMessage("AltPhone", altPhone);
            return this;
        }

        public virtual ICustomerAdd Fax(string fax)
        {
            AddUpdateMessage("Fax", fax);
            return this;
        }

        public virtual ICustomerAdd Email(string email)
        {
            AddUpdateMessage("Email", email);
            return this;
        }

        public virtual ICustomerAdd Contact(string contact)
        {
            AddUpdateMessage("Contact", contact);
            return this;
        }

        public virtual ICustomerAdd AltContact(string altContact)
        {
            AddUpdateMessage("AltContact", altContact);
            return this;
        }

        public virtual ICustomerAdd CustomerType(Reference typeRef)
        {
            AddReference("CustomerTypeRef", typeRef);
            return this;
        }

        public virtual ICustomerAdd Terms(Reference termsRef)
        {
            AddReference("TermsRef", termsRef);
            return this;
        }

        public virtual ICustomerAdd SalesRep(Reference salesRef)
        {
            AddReference("SalesRepRef", salesRef);
            return this;
        }

        public virtual ICustomerAdd OpenBalance(decimal openBalance)
        {
            AddUpdateMessage("OpenBalance", openBalance);
            return this;
        }

        public virtual ICustomerAdd OpenBalanceDate(DateTime balanceDate)
        {
            AddUpdateMessage("OpenBalanceDate", balanceDate);
            return this;
        }

        public virtual ICustomerAdd SalesTaxCode(Reference salesTaxCode)
        {
            AddReference("SalesTaxCodeRef", salesTaxCode);
            return this;
        }

        public virtual ICustomerAdd ItemSalesTax(Reference itemSalesTax)
        {
            AddReference("ItemSalesTaxRef", itemSalesTax);
            return this;
        }

        public virtual ICustomerAdd ResaleNumber(string resaleNumber)
        {
            AddUpdateMessage("ResaleNumber", resaleNumber);
            return this;
        }

        public virtual ICustomerAdd AccountNumber(string accountNumber)
        {
            AddUpdateMessage("AccountNumber", accountNumber);
            return this;
        }

        public virtual ICustomerAdd CreditLimit(decimal creditLimit)
        {
            AddUpdateMessage("CreditLimit", creditLimit);
            return this;
        }

        public virtual ICustomerAdd PreferredPaymentMethod(Reference prefPayMethod)
        {
            AddReference("PreferredPaymentMethodRef", prefPayMethod);
            return this;
        }

        public virtual ICustomerAdd CreditCardInfo(CCInfo creditCard)
        {
            AddCCInfo("CreditCardInfo", creditCard);
            return this;
        }

        public virtual ICustomerAdd JobStatus(string jobStatus)
        {
            AddUpdateMessage("JobStatus", jobStatus);
            return this;
        }

        public virtual ICustomerAdd JobStartDate(DateTime startDate)
        {
            AddUpdateMessage("JobStartDate", startDate);
            return this;
        }

        public virtual ICustomerAdd JobProjectedEndDate(DateTime projectedEndDate)
        {
            AddUpdateMessage("JobProjectedEndDate", projectedEndDate);
            return this;
        }

        public virtual ICustomerAdd JobEndDate(DateTime endDate)
        {
            AddUpdateMessage("JobEndDate", endDate);
            return this;
        }

        public virtual ICustomerAdd JobDesc(string description)
        {
            AddUpdateMessage("JobDesc", description);
            return this;
        }

        public virtual ICustomerAdd JobType(Reference jobType)
        {
            AddReference("JobTypeRef", jobType);
            return this;
        }

        public virtual ICustomerAdd Notes(string notes)
        {
            AddUpdateMessage("Notes", notes);
            return this;
        }

        public virtual ICustomerAdd PriceLevel(Reference priceLevel)
        {
            AddReference("PriceLevelRef", priceLevel);
            return this;
        }

        public virtual ICustomerAdd IncludeRetElement(params string[] retElements)
        {
            foreach (var elementName in retElements)
                AddMessageAllowDuplicates("IncludeRetElement", elementName);
            return this;
        }

        public virtual ICustomerAdd FromDomainObject(Customer customer)
        {
            return FromDomainObject(customer, false);
        }

        public virtual ICustomerAdd FromDomainObject(Customer customer, bool neglectReferences)
        {
            Name(customer.Name);
            IsActive(customer.IsActive);
            if (customer.ParentRef != null && !neglectReferences)
                Parent(customer.ParentRef);
            if (!String.IsNullOrEmpty(customer.CompanyName))
                CompanyName(customer.CompanyName);
            if (!String.IsNullOrEmpty(customer.Salutation))
                Salutation(customer.Salutation);
            if (!String.IsNullOrEmpty(customer.FirstName))
                FirstName(customer.FirstName);
            if (!String.IsNullOrEmpty(customer.MiddleName))
                MiddleName(customer.MiddleName);
            if (!String.IsNullOrEmpty(customer.LastName))
                LastName(customer.LastName);
            if (customer.BillAddress != null)
                BillAddress(customer.BillAddress);
            if (customer.ShipAddress != null)
                ShipAddress(customer.ShipAddress);
            if (!String.IsNullOrEmpty(customer.Phone))
                Phone(customer.Phone);
            if (!String.IsNullOrEmpty(customer.AltPhone))
                AltPhone(customer.AltPhone);
            if (!String.IsNullOrEmpty(customer.Fax))
                Fax(customer.Fax);
            if (!String.IsNullOrEmpty(customer.Email))
                Email(customer.Email);
            if (!String.IsNullOrEmpty(customer.Contact))
                Contact(customer.Contact);
            if (!String.IsNullOrEmpty(customer.AltContact))
                AltContact(customer.AltContact);
            if (customer.CustomerTypeRef != null && !neglectReferences)
                CustomerType(customer.CustomerTypeRef);
            if (customer.TermsRef != null && !neglectReferences)
                Terms(customer.TermsRef);
            if (customer.SalesRepRef != null && !neglectReferences)
                SalesRep(customer.SalesRepRef);
            if (customer.SalesTaxCodeRef != null && !neglectReferences)
                SalesTaxCode(customer.SalesTaxCodeRef);
            if (customer.ItemSalesTaxRef != null && !neglectReferences)
                ItemSalesTax(customer.ItemSalesTaxRef);
            if (!String.IsNullOrEmpty(customer.ResaleNumber))
                ResaleNumber(customer.ResaleNumber);
            if (!String.IsNullOrEmpty(customer.AccountNumber))
                AccountNumber(customer.AccountNumber);
            if (customer.CreditLimit != 0)
                CreditLimit(customer.CreditLimit);
            if (customer.PreferredPaymentMethodRef != null && !neglectReferences)
                PreferredPaymentMethod(customer.PreferredPaymentMethodRef);
            if (customer.CreditCardInfo != null)
                CreditCardInfo(customer.CreditCardInfo);
            if (!String.IsNullOrEmpty(customer.JobStatus))
                JobStatus(customer.JobStatus);
            if (customer.JobStartDate != DateTime.MinValue)
                JobStartDate(customer.JobStartDate);
            if (customer.JobProjectedEndDate != DateTime.MinValue)
                JobProjectedEndDate(customer.JobProjectedEndDate);
            if (customer.JobEndDate != DateTime.MinValue)
                JobEndDate(customer.JobEndDate);
            if (!String.IsNullOrEmpty(customer.JobDesc))
                JobDesc(customer.JobDesc);
            if (customer.JobTypeRef != null && !neglectReferences)
                JobType(customer.JobTypeRef);
            if (!String.IsNullOrEmpty(customer.Notes))
                Notes(customer.Notes);
            if (customer.PriceLevelRef != null && !neglectReferences)
                PriceLevel(customer.PriceLevelRef);
            return this;
        }

        public virtual Customer Add()
        {
            var response = _session.ProcessRequest(_xmlBase.Xml).Descendants(_responseName).First();
            CheckForErrorMessageInResponse(response);
            _xmlBase.ResetXml();
            return XMLtoPOCOList(response).First();
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
