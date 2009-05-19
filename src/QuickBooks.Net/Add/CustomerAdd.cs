using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities;
using QuickBooks.Net.Utilities.ConversionExtensions;

namespace QuickBooks.Net.Add
{
    public class CustomerAdd : EntityAddBase<ICustomerAdd, Customer>, ICustomerAdd
    {
        public CustomerAdd(IQBSessionInternal session)
            : base(session, "CustomerAddRq", "CustomerAddRs", "CustomerAdd")
        {
            _returnAdd = this;
        }

        public virtual ICustomerAdd Parent(Reference parentRef)
        {
            AddReference("ParentRef", parentRef);
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

        public virtual ICustomerAdd CustomerType(Reference typeRef)
        {
            AddReference("CustomerTypeRef", typeRef);
            return this;
        }

        public virtual ICustomerAdd SalesRep(Reference salesRef)
        {
            AddReference("SalesRepRef", salesRef);
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

        public virtual ICustomerAdd PriceLevel(Reference priceLevel)
        {
            AddReference("PriceLevelRef", priceLevel);
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

       
        protected override void SetElementOrder()
        {
            AddElementOrder(
                new ElementPosition("CustomerAdd",
                    "Name",
                    "IsActive",
                    ElementPosition.Ref("ParentRef"),
                    "CompanyName",
                    "Salutation",
                    "FirstName",
                    "MiddleName",
                    "LastName",
                    new ElementPosition("BillAddress",
                        "Addr1",
                        "Addr2",
                        "Addr3",
                        "Addr4",
                        "Addr5",
                        "City",
                        "State",
                        "PostalCode",
                        "Country",
                        "Note"),
                    new ElementPosition("ShipAddress",
                        "Addr1",
                        "Addr2",
                        "Addr3",
                        "Addr4",
                        "Addr5",
                        "City",
                        "State",
                        "PostalCode",
                        "Country",
                        "Note"),
                    "Phone",
                    "AltPhone",
                    "Fax",
                    "Email",
                    "Contact",
                    "AltContact",
                    ElementPosition.Ref("CustomerTypeRef"),
                    ElementPosition.Ref("TermsRef"),
                    ElementPosition.Ref("SalesRepRef"),
                    "OpenBalance",
                    "OpenBalanceDate",
                    ElementPosition.Ref("SalesTaxCodeRef"),
                    ElementPosition.Ref("ItemsSalesTaxRef"),
                    "ResaleNumber",
                    "AccountNumber",
                    "CreditLimit",
                    ElementPosition.Ref("PrefferredPaymentMethodRef"),
                    new ElementPosition("CreditCardInfo",
                        "CreditCardNumber",
                        "ExpirationMonth",
                        "ExpirationYear",
                        "NameOnCard",
                        "CreditCardAddress",
                        "CreditCardPostalCode"),
                    "JobStatus",
                    "JobStartDate",
                    "JobProjectedEndDate",
                    "JobEndDate",
                    "JobDesc",
                    ElementPosition.Ref("JobTypeRef"),
                    "Notes",
                    ElementPosition.Ref("PriceLevelRef"),
                    "IncludeRetElement"));
        }
    }
}
