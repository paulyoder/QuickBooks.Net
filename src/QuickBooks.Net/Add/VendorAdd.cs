using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickBooks.Net.Domain;
using QuickBooks.Net.Utilities;

namespace QuickBooks.Net.Add
{
    public class VendorAdd : EntityAddBase<IVendorAdd,Vendor>, IVendorAdd
    {
        public VendorAdd(IQBSessionInternal session)
            : base(session, "VendorAddRq", "VendorAddRs", "VendorAdd")
        {
            _returnAdd = this;
        }

        public virtual IVendorAdd Address(Address vendorAddress)
        {
            AddAddress("VendorAddress", vendorAddress);
            return this;
        }

        public virtual IVendorAdd NameOnCheck(string nameOnCheck)
        {
            AddUpdateMessage("NameOnCheck", nameOnCheck);
            return this;
        }

        public virtual IVendorAdd VendorType(Reference vendorType)
        {
            AddReference("VendorTypeRef", vendorType);
            return this;
        }

        public virtual IVendorAdd VendorTaxIdent(string taxIdent)
        {
            AddUpdateMessage("VendorTaxIdent", taxIdent);
            return this;
        }

        public virtual IVendorAdd IsVendorEligibleFor1099(string isEligible)
        {
            AddUpdateMessage("IsVendorEligibleFor1099", isEligible);
            return this;
        }

        public virtual IVendorAdd BillingRate(Reference billingRate)
        {
            AddReference("BillingRateRef", billingRate);
            return this;
        }

        public virtual IVendorAdd FromDomainObject(Vendor vendor)
        {
            return FromDomainObject(vendor, false);
        }

        public virtual IVendorAdd FromDomainObject(Vendor vendor, bool neglectReferences)
        {
            Name(vendor.Name);
            IsActive(vendor.IsActive);
            if (!String.IsNullOrEmpty(vendor.AccountNumber))
                AccountNumber(vendor.AccountNumber);
            if (!String.IsNullOrEmpty(vendor.AltContact))
                AltContact(vendor.AltContact);
            if (!String.IsNullOrEmpty(vendor.AltPhone))
                AltPhone(vendor.AltPhone);
            if (!String.IsNullOrEmpty(vendor.CompanyName))
                CompanyName(vendor.CompanyName);
            if (!String.IsNullOrEmpty(vendor.Contact))
                Contact(vendor.Contact);
            if (vendor.CreditLimit != 0)
                CreditLimit(vendor.CreditLimit);
            if (!String.IsNullOrEmpty(vendor.Email))
                Email(vendor.Email);
            if (!String.IsNullOrEmpty(vendor.Fax))
                Fax(vendor.Fax);
            if (!String.IsNullOrEmpty(vendor.FirstName))
                FirstName(vendor.FirstName);
            if (!String.IsNullOrEmpty(vendor.MiddleName))
                MiddleName(vendor.MiddleName);
            if (!String.IsNullOrEmpty(vendor.NameOnCheck))
                NameOnCheck(vendor.NameOnCheck);
            if (!String.IsNullOrEmpty(vendor.Notes))
                Notes(vendor.Notes);
            if (!String.IsNullOrEmpty(vendor.Phone))
                Phone(vendor.Phone);
            if (!String.IsNullOrEmpty(vendor.Salutation))
                Salutation(vendor.Salutation);
            if (vendor.VendorAddress != null)
                Address(vendor.VendorAddress);
            if (!String.IsNullOrEmpty(vendor.VendorTaxIdent))
                VendorTaxIdent(vendor.VendorTaxIdent);
            if (!neglectReferences)
            {
                if (vendor.BillingRateRef != null)
                    BillingRate(vendor.BillingRateRef);
                if (vendor.TermsRef != null)
                    Terms(vendor.TermsRef);
                if (vendor.VendorTypeRef != null)
                    VendorType(vendor.VendorTypeRef);
            }
            return this;
        }

        protected override void SetElementOrder()
        {
            AddElementOrder(
                new ElementPosition("VendorAdd",
                    "Name",
                    "IsActive",
                    "CompanyName",
                    "Salutation",
                    "FirstName",
                    "MiddleName",
                    "LastName",
                    new ElementPosition("VendorAddress",
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
                    "NameOnCheck",
                    "AccountNumber",
                    "Notes",
                    ElementPosition.Ref("VendorTypeRef"),
                    ElementPosition.Ref("TermsRef"),
                    "CreditLimit",
                    "VendorTaxIdent",
                    "IsVendorEligibleFor1099",
                    "OpenBalance",
                    "OpenBalanceDate",
                    ElementPosition.Ref("BillingRateRef"),
                    "IncludeRetElement"));
        }
    }
}
